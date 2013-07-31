VERSION 5.00
Begin VB.Form frmValueEx 
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Card Value"
   ClientHeight    =   6210
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   5295
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   9.75
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6210
   ScaleWidth      =   5295
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin VB.TextBox txtTransferValue 
      BackColor       =   &H8000000F&
      Height          =   360
      Left            =   1485
      Locked          =   -1  'True
      TabIndex        =   11
      Text            =   "0"
      Top             =   5370
      Width           =   2385
   End
   Begin VB.ComboBox cboTransferBlock 
      Height          =   360
      Left            =   1485
      Style           =   2  'Dropdown List
      TabIndex        =   10
      Top             =   5010
      Width           =   2400
   End
   Begin VB.CommandButton cmdValueOpt 
      Caption         =   "Transfer"
      Enabled         =   0   'False
      Height          =   405
      Index           =   5
      Left            =   825
      TabIndex        =   9
      Top             =   4290
      Width           =   3720
   End
   Begin VB.TextBox txtDataRegister 
      BackColor       =   &H8000000F&
      Height          =   360
      Left            =   825
      Locked          =   -1  'True
      TabIndex        =   8
      Top             =   3615
      Width           =   3690
   End
   Begin VB.TextBox txtOptValue 
      Height          =   360
      Left            =   1485
      TabIndex        =   7
      Top             =   1950
      Width           =   2370
   End
   Begin VB.CommandButton cmdValueOpt 
      Caption         =   "Restore"
      Height          =   375
      Index           =   4
      Left            =   3390
      TabIndex        =   6
      Top             =   2715
      Width           =   1155
   End
   Begin VB.CommandButton cmdValueOpt 
      Caption         =   "Decrement"
      Height          =   375
      Index           =   3
      Left            =   2100
      TabIndex        =   5
      Top             =   2715
      Width           =   1155
   End
   Begin VB.CommandButton cmdValueOpt 
      Caption         =   "Increment"
      Height          =   375
      Index           =   2
      Left            =   810
      TabIndex        =   4
      Top             =   2730
      Width           =   1155
   End
   Begin VB.TextBox txtBlockValue 
      BackColor       =   &H8000000F&
      Height          =   360
      Left            =   1485
      Locked          =   -1  'True
      TabIndex        =   3
      Top             =   1305
      Width           =   2385
   End
   Begin VB.ComboBox cboBlock 
      Enabled         =   0   'False
      Height          =   360
      Left            =   1500
      Style           =   2  'Dropdown List
      TabIndex        =   2
      Top             =   960
      Width           =   2385
   End
   Begin VB.CommandButton cmdValueOpt 
      Caption         =   "Read Value"
      Height          =   360
      Index           =   1
      Left            =   2760
      TabIndex        =   1
      Top             =   75
      Width           =   1560
   End
   Begin VB.CommandButton cmdValueOpt 
      Caption         =   "Format"
      Height          =   345
      Index           =   0
      Left            =   1065
      TabIndex        =   0
      Top             =   90
      Width           =   1545
   End
   Begin VB.Label labStatus 
      Alignment       =   2  'Center
      BackColor       =   &H00808080&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   360
      Left            =   -15
      TabIndex        =   14
      Top             =   5850
      Width           =   5325
   End
   Begin VB.Label labCaptionis 
      Alignment       =   1  'Right Justify
      AutoSize        =   -1  'True
      Caption         =   "Value"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FF0000&
      Height          =   240
      Index           =   1
      Left            =   1530
      TabIndex        =   13
      Top             =   1710
      Width           =   555
   End
   Begin VB.Label labCaptionis 
      Alignment       =   1  'Right Justify
      AutoSize        =   -1  'True
      Caption         =   "Data Register"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FF0000&
      Height          =   240
      Index           =   0
      Left            =   855
      TabIndex        =   12
      Top             =   3225
      Width           =   1275
   End
   Begin VB.Image Image1 
      Height          =   480
      Left            =   90
      Picture         =   "frmValueEx.frx":0000
      Top             =   120
      Width           =   480
   End
   Begin VB.Image Image2 
      Height          =   5715
      Left            =   780
      Picture         =   "frmValueEx.frx":0442
      Stretch         =   -1  'True
      Top             =   60
      Width           =   3810
   End
End
Attribute VB_Name = "frmValueEx"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Public Enum iValueBlockOptConstants
    OnBlockSuccess
    OnBlockError
    OnBlockChanged
End Enum

Public Event OnValueEvent(ByRef iEvent As iValueBlockOptConstants)
Public Event OnAddRecord(ByVal lAction As Long, lValue As Long)

Private m_oMF5x As MF5Ax
Private m_iSector As Integer
Private m_oBlock As ComboBox
Private m_bIsSetDataRegister As Boolean
Private m_bIsExecutingCommand As Boolean

Private m_bIsLoading As Boolean

Public Sub ShowValueOpt(ByRef oMF5x As MF5Ax, ByRef oBlock As ComboBox, ByVal iSector As Integer)
    Dim I As Long, szData As String
    Set m_oMF5x = oMF5x
    Set m_oBlock = oBlock
    m_iSector = iSector
    m_bIsLoading = True
    With oBlock
        cboBlock.Clear
        cboTransferBlock.Clear
        For I = 0 To .ListCount - 1
            szData = .List(I)
            cboBlock.AddItem szData
            cboTransferBlock.AddItem szData
        Next I
        I = .ListIndex
        cboBlock.ListIndex = I
        cboTransferBlock.ListIndex = I
    End With
    m_bIsLoading = False
    cmdValueOpt_Click 1     ' Call Read Value
    CheckWritable
    Me.Show vbModal
End Sub

Public Sub CheckWritable()
    Dim bWritable As Boolean
    bWritable = IsWritable(m_iSector, m_oBlock.ListIndex)
    cmdValueOpt(0).Enabled = bWritable  ' Format
    bWritable = IsWritable(m_iSector, cboTransferBlock.ListIndex)
    cmdValueOpt(5).Enabled = bWritable And m_bIsSetDataRegister  ' Transfer
End Sub

Public Function IsWritable(ByVal iSector As Integer, ByVal iBlock As Integer) As Boolean
    Dim bIsWritable As Boolean
    Select Case iSector
    Case 0
        If iBlock = 0 Or iBlock = 3 Then
            bIsWritable = False
        Else
            bIsWritable = True
        End If
    Case 1 To 31
        If iBlock = 3 Then
            bIsWritable = False
        Else
            bIsWritable = True
        End If
    Case 32 To 39
        If iBlock = 15 Then
            bIsWritable = False
        Else
            bIsWritable = True
        End If
    End Select
    IsWritable = bIsWritable
End Function

Private Sub cboBlock_Click()
    If m_bIsLoading = False Then
        m_oBlock.ListIndex = cboBlock.ListIndex
        CheckWritable
    End If
End Sub

Private Sub cboTransferBlock_Click()
    If m_bIsLoading = False Then
        CheckWritable
    End If
End Sub

Private Sub cmdValueOpt_Click(Index As Integer)
    Dim bIsExecutingCommand As Boolean
    On Error GoTo Err_Proc
    bIsExecutingCommand = m_bIsExecutingCommand
    If m_bIsExecutingCommand = False Then
        m_bIsExecutingCommand = True
        ExecutingCommand Index
    End If
Err_Exit:
    m_bIsExecutingCommand = bIsExecutingCommand
    Exit Sub

Err_Proc:
    Debug.Print "cmdValueOpt_Click(" & Index & ") - " & Err.Description & "(" & Err.Number & ")"
    Resume Err_Exit
End Sub

Private Sub ExecutingCommand(Index As Integer)
    Dim bIsResult As Boolean
    Dim bIsDataChagned As Boolean
    Dim lBlockOpt As Long
    Dim lOptValue As Long
    Dim iBlock As Integer
    Dim lBlockValue As Long
    Dim iTransferBlock As Integer
    Dim lDataRegister As Long
    Dim bIsSetDataRegister As Boolean
    Dim bIslTransfer As Boolean
    Const VALUE_OPT_NONE As Long = 0
    On Error GoTo Err_Proc
    
    lBlockOpt = VALUE_OPT_NONE
    txtDataRegister.Text = vbNullString
    lBlockValue = Val(txtBlockValue.Text)
    iBlock = cboBlock.ListIndex
    iTransferBlock = cboTransferBlock.ListIndex
    Select Case Index
    Case 0 ' Format
        bIsResult = m_oMF5x.mfSetValue(iBlock, 0)
        If bIsResult Then
            lBlockValue = 0
            bIsDataChagned = True
        End If
    Case 1 ' Read Value
        bIsResult = m_oMF5x.mfGetValue(iBlock, lBlockValue)
        If bIsResult Then
            bIsDataChagned = True
        End If
    Case 2 ' Increment
        lOptValue = Val(txtOptValue.Text)
        lBlockOpt = MF_INC
        bIsResult = m_oMF5x.mfValueSetEx(iBlock, lBlockOpt, lOptValue)
        If bIsResult Then
            lDataRegister = lBlockValue + lOptValue
            bIsSetDataRegister = True
        End If
    Case 3 ' Decrement
        lOptValue = Val(txtOptValue.Text)
        lBlockOpt = MF_DEC
        bIsResult = m_oMF5x.mfValueSetEx(iBlock, lBlockOpt, lOptValue)
        If bIsResult Then
            lDataRegister = lBlockValue - lOptValue
            bIsSetDataRegister = True
        End If
    Case 4 ' Restore
        bIsResult = m_oMF5x.mfRestore(iBlock)
        If bIsResult Then
            lDataRegister = lBlockValue
            bIsSetDataRegister = True
        End If
    Case 5 ' Transfer
        bIsResult = m_oMF5x.mfTransfer(iTransferBlock)
        If bIsResult Then
            bIsDataChagned = True
            bIslTransfer = True
            m_bIsSetDataRegister = False
        End If
    End Select
    If bIsResult Then
        txtBlockValue.Text = CStr(lBlockValue)
        If bIsSetDataRegister Then
            m_bIsSetDataRegister = True
            txtDataRegister.Text = CStr(lDataRegister)
        End If
        If bIsDataChagned Then
            bIsResult = m_oMF5x.mfGetValue(iBlock, lBlockValue)
        End If
        If bIsResult Then
            txtBlockValue.Text = CStr(lBlockValue)
            If bIslTransfer Then
                If iTransferBlock <> iBlock Then
                    bIsResult = m_oMF5x.mfGetValue(iTransferBlock, lBlockValue)
                End If
                If bIsResult Then
                    txtTransferValue.Text = CStr(lBlockValue)
                End If
            End If
        End If
        If bIsResult Then
            ShowStatus cmdValueOpt(Index).Caption & " OK", vbGreen
            RaiseEvent OnValueEvent(OnBlockSuccess)
            If bIsDataChagned Then
                RaiseEvent OnValueEvent(OnBlockChanged)
            End If
            If lBlockOpt <> VALUE_OPT_NONE Then
                RaiseEvent OnAddRecord(lBlockOpt, lOptValue)
            End If
        Else
            If m_oMF5x.GNetErrorCode = 0 Then
                ShowStatus cmdValueOpt(Index).Caption & " Error", vbRed
            Else
                ShowStatus cmdValueOpt(Index).Caption & " Error(" & m_oMF5x.GNetErrorCodeStr & ")", vbRed
            End If
        End If
    Else
        If m_oMF5x.GNetErrorCode = 0 Then
            ShowStatus cmdValueOpt(Index).Caption & " Error", vbRed
        Else
            ShowStatus cmdValueOpt(Index).Caption & " Error(" & m_oMF5x.GNetErrorCodeStr & ")", vbRed
        End If
        RaiseEvent OnValueEvent(OnBlockError)
    End If
    CheckWritable
Err_Exit:
    Exit Sub
Err_Proc:
    Debug.Print "cmdValueOpt_Click -" & Err.Description & "(" & Err.Number & ")"
    Resume Err_Exit
End Sub

Public Sub ShowStatus(ByRef szMsg As String, Optional lColor As ColorConstants = vbBlack)
    With labStatus
        .Caption = szMsg
        .ForeColor = lColor
    End With
End Sub

Private Sub txtOptValue_Change()
    Dim szData As String
    With txtOptValue
        szData = .Text
        If IsNumeric(szData) = False Then
            szData = CStr(Val(szData))
            .Text = szData
            .SelStart = Len(szData)
        End If
    End With
End Sub

Private Sub txtOptValue_KeyPress(KeyAscii As Integer)
    Select Case KeyAscii
    Case Is < 32
    Case 48 To 57 ' 0 to 9
    Case Else
        KeyAscii = 0
    End Select
End Sub
