VERSION 5.00
Object = "{DA71FD02-BE12-4678-B06E-78BBCE11E4A1}#1.0#0"; "MF5Ax.ocx"
Begin VB.Form frmMain 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "I/O Control Demo"
   ClientHeight    =   4680
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   4605
   Icon            =   "frmMain.frx":0000
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   MaxButton       =   0   'False
   ScaleHeight     =   4680
   ScaleWidth      =   4605
   StartUpPosition =   2  'CenterScreen
   Begin MF5AXLib.MF5Ax MF5x1 
      Left            =   555
      Top             =   4290
      _Version        =   65536
      _ExtentX        =   847
      _ExtentY        =   847
      _StockProps     =   0
   End
   Begin VB.Timer TimerClear 
      Enabled         =   0   'False
      Interval        =   1000
      Left            =   60
      Top             =   4230
   End
   Begin VB.CommandButton cmdAutoScan 
      Caption         =   "Auto Scan"
      Height          =   375
      Left            =   2910
      TabIndex        =   16
      Top             =   4245
      Width           =   1650
   End
   Begin VB.CheckBox chkAutoMode 
      Caption         =   "Disable Auto Mode"
      Height          =   375
      Left            =   1245
      Style           =   1  'Graphical
      TabIndex        =   14
      Top             =   4245
      Width           =   1650
   End
   Begin VB.Frame Frame1 
      Caption         =   "PIO && Interrupt"
      Height          =   4155
      Left            =   30
      TabIndex        =   0
      Top             =   45
      Width           =   4545
      Begin VB.CheckBox chkPIO 
         Caption         =   "PIO 11"
         Height          =   255
         Index           =   11
         Left            =   240
         TabIndex        =   13
         Top             =   3390
         Width           =   855
      End
      Begin VB.CheckBox chkPIO 
         Caption         =   "PIO 10"
         Height          =   255
         Index           =   10
         Left            =   240
         TabIndex        =   12
         Top             =   3120
         Width           =   855
      End
      Begin VB.CheckBox chkPIO 
         Caption         =   "PIO 9"
         Height          =   255
         Index           =   9
         Left            =   240
         TabIndex        =   11
         Top             =   2850
         Width           =   855
      End
      Begin VB.CheckBox chkPIO 
         Caption         =   "PIO 8"
         Height          =   255
         Index           =   8
         Left            =   240
         TabIndex        =   10
         Top             =   2580
         Width           =   855
      End
      Begin VB.CheckBox chkPIO 
         Caption         =   "PIO 7"
         Height          =   255
         Index           =   7
         Left            =   240
         TabIndex        =   9
         Top             =   2310
         Width           =   855
      End
      Begin VB.CheckBox chkPIO 
         Caption         =   "PIO 6"
         Height          =   255
         Index           =   6
         Left            =   240
         TabIndex        =   8
         Top             =   2040
         Width           =   855
      End
      Begin VB.CheckBox chkPIO 
         Caption         =   "PIO 5"
         Height          =   255
         Index           =   5
         Left            =   240
         TabIndex        =   7
         Top             =   1770
         Width           =   855
      End
      Begin VB.CheckBox chkPIO 
         Caption         =   "PIO 4"
         Height          =   255
         Index           =   4
         Left            =   240
         TabIndex        =   6
         Top             =   1500
         Width           =   855
      End
      Begin VB.CheckBox chkPIO 
         Caption         =   "PIO 3"
         Height          =   255
         Index           =   3
         Left            =   240
         TabIndex        =   5
         Top             =   1230
         Width           =   855
      End
      Begin VB.CheckBox chkPIO 
         Caption         =   "PIO 2"
         Height          =   255
         Index           =   2
         Left            =   240
         TabIndex        =   4
         Top             =   960
         Width           =   855
      End
      Begin VB.CheckBox chkPIO 
         Caption         =   "PIO 1"
         Height          =   255
         Index           =   1
         Left            =   240
         TabIndex        =   3
         Top             =   675
         Width           =   855
      End
      Begin VB.CommandButton cmdPIO 
         Caption         =   "Read"
         Height          =   390
         Index           =   0
         Left            =   2715
         TabIndex        =   2
         Top             =   3690
         Width           =   1650
      End
      Begin VB.CheckBox chkPIO 
         Caption         =   "PIO 0"
         Height          =   255
         Index           =   0
         Left            =   240
         TabIndex        =   1
         Top             =   405
         Width           =   855
      End
      Begin VB.Label Label2 
         Alignment       =   2  'Center
         BackColor       =   &H00808080&
         Caption         =   "PIO Description"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FF0000&
         Height          =   195
         Index           =   1
         Left            =   1245
         TabIndex        =   30
         Top             =   210
         Width           =   3105
      End
      Begin VB.Label Label2 
         Alignment       =   2  'Center
         BackColor       =   &H00808080&
         Caption         =   "PIO"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FF0000&
         Height          =   195
         Index           =   0
         Left            =   240
         TabIndex        =   29
         Top             =   210
         Width           =   855
      End
      Begin VB.Label Label1 
         Caption         =   "PIO 11"
         Height          =   195
         Index           =   11
         Left            =   1245
         TabIndex        =   28
         Top             =   3420
         Width           =   3105
      End
      Begin VB.Label Label1 
         Caption         =   "PIO 10"
         Height          =   195
         Index           =   10
         Left            =   1245
         TabIndex        =   27
         Top             =   3150
         Width           =   3105
      End
      Begin VB.Label Label1 
         Caption         =   "PIO 9"
         Height          =   195
         Index           =   9
         Left            =   1245
         TabIndex        =   26
         Top             =   2880
         Width           =   3105
      End
      Begin VB.Label Label1 
         Caption         =   "PIO 8"
         Height          =   195
         Index           =   8
         Left            =   1245
         TabIndex        =   25
         Top             =   2610
         Width           =   3105
      End
      Begin VB.Label Label1 
         Caption         =   "PIO 7"
         Height          =   195
         Index           =   7
         Left            =   1245
         TabIndex        =   24
         Top             =   2340
         Width           =   3105
      End
      Begin VB.Label Label1 
         Caption         =   "PIO 6"
         Height          =   195
         Index           =   6
         Left            =   1245
         TabIndex        =   23
         Top             =   2070
         Width           =   3105
      End
      Begin VB.Label Label1 
         Caption         =   "PIO 5"
         Height          =   195
         Index           =   5
         Left            =   1245
         TabIndex        =   22
         Top             =   1800
         Width           =   3105
      End
      Begin VB.Label Label1 
         Caption         =   "PIO 4"
         Height          =   195
         Index           =   4
         Left            =   1245
         TabIndex        =   21
         Top             =   1530
         Width           =   3105
      End
      Begin VB.Label Label1 
         Caption         =   "PIO 3"
         Height          =   195
         Index           =   3
         Left            =   1245
         TabIndex        =   20
         Top             =   1260
         Width           =   3105
      End
      Begin VB.Label Label1 
         Caption         =   "PIO 2"
         Height          =   195
         Index           =   2
         Left            =   1245
         TabIndex        =   19
         Top             =   990
         Width           =   3105
      End
      Begin VB.Label Label1 
         Caption         =   "PIO 1"
         Height          =   195
         Index           =   1
         Left            =   1245
         TabIndex        =   18
         Top             =   705
         Width           =   3105
      End
      Begin VB.Label Label1 
         Caption         =   "PIO 0"
         Height          =   195
         Index           =   0
         Left            =   1245
         TabIndex        =   17
         Top             =   435
         Width           =   3105
      End
      Begin VB.Label labOnIRQ 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BorderStyle     =   1  'Fixed Single
         Caption         =   "OnIRQ Event"
         ForeColor       =   &H00FFFFFF&
         Height          =   240
         Left            =   240
         TabIndex        =   15
         Top             =   3765
         Width           =   2370
      End
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)

Const GNET_QUERY_DO = &H11
Const GNET_QUERY_DI = &H12
Const GNET_QUERY_AUTOMODE = &H3F

Const GNET_ACK = &H6
Const GNET_NAK = &H15

Private m_bUpdate As Boolean

Function GNet_DI(ByVal Index As Byte, ByRef bValue As Byte) As Boolean
    Dim bResult As Boolean
    bResult = MF5x1.Query(GNET_QUERY_DI, Index)
    If bResult Then
        bValue = MF5x1.GetReplyValue(gnetByte)
    End If
    GNet_DI = bResult
End Function

Function GNet_DO(ByVal Index As Byte, ByRef bValue As Byte) As Boolean
    Dim bParams(0 To 1) As Byte
    bParams(0) = Index
    bParams(1) = bValue
    GNet_DO = MF5x1.Query(GNET_QUERY_DO, bParams)
End Function

Function GNet_SetPort(ByRef bValue As Byte) As Boolean
    GNet_SetPort = MF5x1.SetRegister(0, bValue)
End Function

Function GNet_GetPort(ByRef bValue As Byte) As Boolean
    GNet_GetPort = MF5x1.GetRegisterEx(0, VarPtr(bValue), 1)
End Function

Function mfAutoMode(bEnable As Boolean) As Boolean
    mfAutoMode = MF5x1.mfAutoMode(bEnable)
End Function

Private Sub chkAutoMode_Click()
    If chkAutoMode.Value <> 0 Then
        Call mfAutoMode(False)
    Else
        Call mfAutoMode(True)
    End If
End Sub

Private Sub chkPIO_Click(Index As Integer)
    Dim bValue As Byte
    Dim I As Long
    Dim bResult As Boolean
    
    If m_bUpdate = False Then
        bValue = CByte(chkPIO(Index).Value)
        TimerClear.Enabled = False
        chkPIO(Index).BackColor = &H8000000F
        Label1(Index).BackColor = &H8000000F
        If MF5x1.PortOpen = False Then
            bResult = False
        Else
            bResult = GNet_DO(Index, bValue)
        End If
        If bResult = False Then
            chkPIO(Index).BackColor = vbRed
            Label1(Index).BackColor = vbRed
        Else
            chkPIO(Index).BackColor = vbGreen
            Label1(Index).BackColor = vbGreen
        End If
        TimerClear.Enabled = True
    End If
End Sub

Private Sub cmdAutoScan_Click()
    Dim I As Integer, iPort As Integer
    Dim iEvent As Integer
    Dim bFound As Boolean
    Dim iResponse As Integer, bData As Byte
    Dim szPortNames() As String, szPortName As String, m_szVersion As String, m_szROMType As String, m_szModuleName As String
    Dim szBaudrates() As String, lBaudrate As Long
    
    cmdAutoScan.Enabled = False
    
    szBaudrates = Split("19200;38400;9600", ";")
    
    If MF5x1.PortOpen Then
        MF5x1.PortOpen = False
        Sleep 100
    End If
    szPortName = "P1.0,P1.1,P1.2 (FOR SK ORG LED),P1.3 (FOR SK GREEN LED),P1.4 (FOR SK RED LED),P1.5 (FOR SK BUZZER),P1.6 (FOR SK RTSD),P1.7 (FOR SK CTSD),P4.0,P4.1,P4.2,P4.3 (ISP Enable note)"
    
    ' show version
    For I = 0 To 255                                ' Loop by Comm Port
        iPort = Val(Mid(MF5x1.EnumCommPort(I), 4))
        If iPort > 0 Then
            With MF5x1
                If .PortOpen Then
                    .PortOpen = False
                    Sleep 150
                End If
                .CommPort = iPort
            End With
            For lBaudrate = 0 To UBound(szBaudrates)    ' Loop by Baudrate
                With MF5x1
                    .Settings = szBaudrates(lBaudrate)
                    .PortOpen = True
                End With
                If MF5x1.PortOpen Then
                    iEvent = MF5x1.Polling(0)       ' Addr=0 (Broadcast)
                    If iEvent >= 0 Then
                        m_szVersion = MF5x1.GetVersion   ' Get RWD version for make sure are AC906
                        m_szROMType = Left$(m_szVersion, InStr(1, m_szVersion & " ", " ", vbTextCompare) - 1)
                        MF5x1.mfAutoMode
                        Select Case m_szROMType
                        Case "PGM0499", "PGM-T0499"    ' MF5
                            m_szModuleName = "MF5"
                            bFound = True
                        Case "ROM-T0636"
                            m_szModuleName = "MF5-01 (ODM)"
                            bFound = True
                        Case "PGM-T0668"
                            m_szModuleName = "MF5-02 (ODM)"
                            bFound = True
                        Case "PGM-T0562"
                            szPortName = "PIO 0,PIO 1,PIO 2,PIO 3,PIO 4 (Buzzer),PIO 5 (LED Green),PIO 6 (LED Red),PIO 7 (LED Orange),PIO 8 (TXEN),PIO 9,DO1 (Output Only),DO2 (Output Only)"
                            m_szModuleName = "RWM600"
                            bFound = True
                        Case "PGM-T0702"
                            szPortName = "PIO 0 (JTAG),PIO 1 (JTAG),PIO 2 (JTAG),PIO 3 (JTAG),PIO 4 (Buzzer),PIO 5 (LED Green),PIO 6 (LED Red),PIO 7 (LED Orange),PIO 8 (TXEN),PIO 9 (IRQ),DO1 (Output Only),DO2 (Output Only)"
                            m_szModuleName = "RWM600A"
                            bFound = True
                        End Select
                    End If
                End If
                If bFound Then
                    Exit For
                End If
            Next lBaudrate
        End If
        If bFound Then
            Exit For
        End If
        MF5x1.PortOpen = False
    Next I
    
    If bFound Then
        Me.Caption = "I/O Control Demo" & " - " & m_szModuleName & " On COM" & MF5x1.CommPort
        chkAutoMode.Value = 1 ' Disable auto mode
        If szPortName <> vbNullString Then
            szPortNames = Split(szPortName, ",")
            For I = 0 To UBound(szPortNames)
                Label1(I).Caption = szPortNames(I)
            Next I
        End If
        cmdPIO_Click 0
    Else
        MsgBox "No MF5/RWM600A on serial prot!!", vbOKOnly Or vbExclamation
    End If
    
    cmdAutoScan.Enabled = True
End Sub

Private Sub cmdPIO_Click(Index As Integer)
    Dim I As Integer, bValue As Byte
    
    cmdPIO(Index).Enabled = False
    
    m_bUpdate = True
    TimerClear.Enabled = False
    For I = 0 To chkPIO.Count - 1
        If GNet_DI(I, bValue) Then
            chkPIO(I).Value = CInt(bValue)
            chkPIO(I).BackColor = vbGreen
            Label1(I).BackColor = vbGreen
        Else
            chkPIO(I).BackColor = vbRed
            Label1(I).BackColor = vbRed
        End If
    Next I
    m_bUpdate = False
    
    TimerClear.Enabled = True
    cmdPIO(Index).Enabled = True
End Sub

Private Sub Form_Unload(Cancel As Integer)
    chkAutoMode.Value = 0
End Sub

Private Sub Label1_Click(Index As Integer)
    chkPIO(Index).Value = (Not chkPIO(Index).Value) And 1&
End Sub

Private Sub MF5x1_OnIRQ()
    labOnIRQ.BackColor = vbRed
    TimerClear.Enabled = True
End Sub

Private Sub TimerClear_Timer()
    Dim I As Long
    TimerClear.Enabled = False
    For I = 0 To chkPIO.Count - 1
        chkPIO(I).BackColor = &H8000000F
        Label1(I).BackColor = &H8000000F
    Next I
    labOnIRQ.BackColor = &H8000000F
End Sub
