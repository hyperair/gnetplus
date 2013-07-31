import collections
import serial
import struct
import time


class InvalidMessage(Exception):
    pass


class Message(object):
    """
    Base message class for representing a message
    """

    SOH = 0x01

    def __init__(self, address, function, data):
        self.address = address
        self.function = function
        self.data = data

    def __str__(self):
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
        serial.write(str(self))

    @classmethod
    def readfrom(cls, serial):
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
    pass


class ResponseMessage(Message):
    ACK = 0x06
    NAK = 0x15
    EVN = 0x12

    def to_error(self):
        if self.function != self.NAK:
            return None

        return GNetPlusError("Error: " + repr(self.data))


class Handle(object):
    def __init__(self, port, baudrate=19200, deviceaddr=0):
        self.baudrate = baudrate
        self.port = port
        self.serial = serial.Serial(port, baudrate=baudrate)
        self.deviceaddr = deviceaddr

    def sendmsg(self, function, data=''):
        QueryMessage(self.deviceaddr, function, data).sendto(self.serial)

    def readmsg(self, sink_events=False):
        while sink_events:
            response = ResponseMessage.readfrom(self.serial)

            # skip over events. spec doesn't say what to do with them
            if response.function == ResponseMessage.EVN:
                continue

            break

        if response.function == ResponseMessage.NAK:
            raise response.to_error()

        return response

    def get_sn(self):
        self.sendmsg(QueryMessage.REQUEST)
        self.readmsg(sink_events=True)

        self.sendmsg(QueryMessage.ANTI_COLLISION)
        response = self.readmsg(sink_events=True)

        return hex(struct.unpack('>L', response.data)[0])

    def get_version(self):
        self.sendmsg(QueryMessage.GET_VERSION)
        return self.readmsg().data


if __name__ == '__main__':
    handle = Handle('/dev/ttyUSB0')
    print handle.get_sn()
