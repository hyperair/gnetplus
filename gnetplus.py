#!/usr/bin/python
# -*- coding: utf-8 -*-

# gnetplus -- Python module for interfacing with PROMAG RFID card reader
# Copyright © 2013 Red Hat Inc.
#
# Authors:
#
#     Chow Loong Jin <lchow@redhat.com>
#
# This library is free software; you can redistribute it and/or
# modify it under the terms of the GNU Lesser General Public
# License as published by the Free Software Foundation; either
# version 2.1 of the License, or (at your option) any later version.
#
# This library is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
# Lesser General Public License for more details.
#
# You should have received a copy of the GNU Lesser General Public
# License along with this library; if not, write to the Free Software
# Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA



"""
Module for interfacing with the PROMAG card reader using the GNetPlus®
Protocol.

Usage:
from gnetplus import Handle

handle = Handle("/dev/ttyUSB0")
print "S/N: " + hex(handle.get_sn())
"""

import collections
import serial
import struct
import sys
import time


class InvalidMessage(Exception):
    pass


class Message(object):
    """
    Base message class for representing a message
    """

    SOH = 0x01

    def __init__(self, address, function, data):
        """
        @arg address 8-bit int containing device address (Use 0 unless you know
                     what you're doing)
        @arg function 8-bit int containing the function of this message
        @arg data     String containing payload of this message
        """
        self.address = address
        self.function = function
        self.data = data

    def __str__(self):
        """
        Converts Message to raw binary form suitable for transmission
        """
        msgstr = struct.pack('BBB', self.address, self.function,
                             len(self.data)) + self.data
        crc = self.gencrc(msgstr)

        return chr(self.SOH) + msgstr + struct.pack('>H', crc)

    def __repr__(self):
        return ("{name}(address={address}, "
                "function={function}, "
                "data={data})").format(name=self.__class__.__name__,
                                       address=hex(self.address),
                                       function=hex(self.function),
                                       data=repr(self.data))

    def sendto(self, serial):
        """
        Sends this message to `serial´
        """
        serial.write(str(self))

    @classmethod
    def readfrom(cls, serial):
        """
        Reads one message from `serial' and constructs a message from `cls'

        @arg serial serial.Serial interface to read message from
        @returns Constructed Message instance
        """
        header = serial.read(4)
        soh, address, function, length = struct.unpack('BBBB', header)

        if soh != cls.SOH:
            raise InvalidMessage("SOH does not match")

        data = serial.read(length)
        crc = serial.read(2)

        msg = cls(address=address, function=function, data=data)

        if str(msg)[-2:] != crc:
            raise InvalidMessage("CRC does not match")

        return msg

    @staticmethod
    def gencrc(msgstr):
        """
        Generate CRC for the string `msgstr'

        @arg msgstr string containing data to be checksummed
        @returns 16-bit integer containing CRC checksum
        """
        crc = 0xFFFF

        for char in msgstr:
            crc ^= ord(char)

            for i in xrange(8):
                if (crc & 1) == 1:
                    crc = (crc >> 1) ^ 0xA001
                else:
                    crc >>= 1

        return crc


class QueryMessage(Message):
    """
    A query message to be sent from host machine to card reader device. Magical
    constants taken from protocol documentation.
    """
    POLLING = 0x00
    GET_VERSION = 0x01
    SET_SLAVE_ADDR = 0x02
    LOGON = 0x03
    LOGOFF = 0x04
    SET_PASSWORD = 0x05
    CLASSNAME = 0x06
    SET_DATETIME = 0x07
    GET_DATETIME = 0x08
    GET_REGISTER = 0x09
    SET_REGISTER = 0x0A
    RECORD_COUNT = 0x0B
    GET_FIRST_RECORD = 0x0C
    GET_NEXT_RECORD = 0x0D
    ERASE_ALL_RECORDS = 0x0E
    ADD_RECORD = 0x0F
    RECOVER_ALL_RECORDS = 0x10
    DO = 0x11
    DI = 0x12
    ANALOG_INPUT = 0x13
    THERMOMETER = 0x14
    GET_NODE = 0x15
    GET_SN = 0x16
    SILENT_MODE = 0x17
    RESERVE = 0x18
    ENABLE_AUTO_MODE = 0x19
    GET_TIME_ADJUST = 0x1A
    ECHO = 0x18
    SET_TIME_ADJUST = 0x1C
    DEBUG = 0x1D
    RESET = 0x1E
    GO_TO_ISP = 0x1F
    REQUEST = 0x20
    ANTI_COLLISION = 0x21
    SELECT_CARD = 0x22
    AUTHENTICATE = 0x23
    READ_BLOCK = 0x24
    WRITE_BLOCk = 0x25
    SET_VALUE = 0x26
    READ_VALUE = 0x27
    CREATE_VALUE_BLOCK = 0x28
    ACCESS_CONDITION = 0x29
    HALT = 0x2A
    SAVE_KEY = 0x2B
    GET_SECOND_SN = 0x2C
    GET_ACCESS_CONDITION = 0x2D
    AUTHENTICATE_KEY = 0x2E
    REQUEST_ALL = 0x2F
    SET_VALUEEX = 0x32
    TRANSFER = 0x33
    RESTORE = 0x34
    GET_SECTOR = 0x3D
    RF_POWER_ONOFF = 0x3E
    AUTO_MODE = 0x3F


class GNetPlusError(Exception):
    """
    Exception thrown when receiving a ResponseMessage with function=NAK
    """
    pass


class ResponseMessage(Message):
    """
    Message received from card reader
    """
    ACK = 0x06
    NAK = 0x15
    EVN = 0x12

    def to_error(self):
        """
        Construct a GNetPlusError for NAK response.

        @returns Constructed instance of GNetPlusError for this response
        """
        if self.function != self.NAK:
            return None

        return GNetPlusError("Error: " + repr(self.data))


class Handle(object):
    """
    Main class used for interfacing with the card reader.
    """

    def __init__(self, port, baudrate=19200, deviceaddr=0):
        """
        Initializes a Handle instance.
        @arg port String containing name of serial port, e.g. /dev/ttyUSB0
        @arg baudrate Baudrate for interfacing with the device. Don't change
                      this unless you know what you're doing.
        @arg deviceaddr Integer containing the device address. Defaults to 0.
        """
        self.baudrate = baudrate
        self.port = port
        self.serial = serial.Serial(port, baudrate=baudrate)
        self.deviceaddr = deviceaddr

    def sendmsg(self, function, data=''):
        """
        Constructs and sends a QueryMessage to the device

        @arg function @see Message.function
        @arg data @see Message.data
        """
        QueryMessage(self.deviceaddr, function, data).sendto(self.serial)

    def readmsg(self, sink_events=False):
        """
        Reads a message, optionally ignoring event (EVN) messages which are
        device-driven.

        @arg sink_events Boolean dictating whether or not events should be
                         ignored.
        """
        while True:
            response = ResponseMessage.readfrom(self.serial)

            # skip over events. spec doesn't say what to do with them
            if sink_events and response.function == ResponseMessage.EVN:
                continue

            break

        if response.function == ResponseMessage.NAK:
            raise response.to_error()

        return response

    def get_sn(self):
        """
        Get serial number of the card currently scanned.

        @returns 16-bit integer containing serial number of the scanned card.
        """
        self.sendmsg(QueryMessage.REQUEST)
        self.readmsg(sink_events=True)

        self.sendmsg(QueryMessage.ANTI_COLLISION)
        response = self.readmsg(sink_events=True)

        return struct.unpack('>L', response.data)[0]

    def get_version(self):
        """
        Get product version string. May contain null bytes, so be careful when
        using it.

        @returns Product version string of the device connected to this handle.
        """
        self.sendmsg(QueryMessage.GET_VERSION)
        return self.readmsg().data

    def set_auto_mode(self, enabled=True):
        """
        Toggle auto mode, i.e. whether the device emits events when a card
        comes close.

        @arg enabled Whether to enable or disable auto mode.
        """
        self.sendmsg(QueryMessage.AUTO_MODE, chr(enabled))
        self.readmsg(sink_events=True)

    def wait_for_card(self):
        """
        Block until card is present at the device. Does not check if a card is
        already present before entering the function.
        """
        self.set_auto_mode()

        while True:
            response = self.readmsg()
            if ((response.function == ResponseMessage.EVN and
                 response.data == 'I')):
                return

if __name__ == '__main__':
    try:
        port = sys.argv[1]
    except IndexError:
        sys.stderr.write("Usage: {0} <serial port>\n".format(sys.argv[0]))

    handle = Handle(port)

    while True:
        handle.wait_for_card()

        try:
            print "Found card: {0}".format(hex(handle.get_sn()))

        except GNetPlusError:
            print "Tap card again."
