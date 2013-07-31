VERSION 5.00
Begin VB.Form frmValue 
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Card Value"
   ClientHeight    =   1965
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   3345
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   1965
   ScaleWidth      =   3345
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin VB.TextBox txtValue 
      Alignment       =   1  'Right Justify
      Height          =   315
      Index           =   1
      Left            =   1800
      MaxLength       =   9
      TabIndex        =   5
      Text            =   "0"
      Top             =   1500
      Width           =   1305
   End
   Begin VB.TextBox txtValue 
      Alignment       =   1  'Right Justify
      Height          =   315
      Index           =   0
      Left            =   1800
      MaxLength       =   9
      TabIndex        =   3
      Text            =   "0"
      Top             =   1050
      Width           =   1305
   End
   Begin VB.CommandButton cmdValue 
      Caption         =   "Decrement"
      Height          =   375
      Index           =   3
      Left            =   720
      TabIndex        =   4
      Top             =   1470
      Width           =   1095
   End
   Begin VB.CommandButton cmdValue 
      Caption         =   "Increment"
      Height          =   375
      Index           =   2
      Left            =   720
      TabIndex        =   2
      Top             =   1020
      Width           =   1095
   End
   Begin VB.CommandButton cmdValue 
      Caption         =   "Read Value"
      Height          =   375
      Index           =   1
      Left            =   720
      TabIndex        =   1
      Top             =   570
      Width           =   1095
   End
   Begin VB.CommandButton cmdValue 
      Caption         =   "Format"
      Height          =   375
      Index           =   0
      Left            =   720
      TabIndex        =   0
      Top             =   120
      Width           =   1095
   End
   Begin VB.Image Image1 
      Height          =   480
      Left            =   90
      Picture         =   "frmValue.frx":0000
      Top             =   120
      Width           =   480
   End
   Begin VB.Label labValue 
      Alignment       =   1  'Right Justify
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "Courier New"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      Left            =   1800
      TabIndex        =   6
      Top             =   600
      Width           =   1305
   End
End
Attribute VB_Name = "frmValue"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private m_bIsExecutingCommand As Boolean

Private Sub cmdValue_Click(Index As Integer)
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
    Debug.Print "cmdValue_Click(" & Index & ") - " & Err.Description & "(" & Err.Number & ")"
    Resume Err_Exit
End Sub

Private Sub ExecutingCommand(Index As Integer)
    Dim res As String, Value As Long
    Dim blk As Byte
    
    On Error GoTo Err_Proc
    
    blk = frmMain.cmbBlock.ListIndex
    
    Select Case Index
        Case 0  ' format
            If frmMain.MF5x1.mfSetValue(blk, 0) Then
                frmMain.labMF5(5).ForeColor = QBColor(2)
                frmMain.labMF5(5).Caption = "Ok"
                frmMain.cmdMF5_Click 4
            Else
                frmMain.labMF5(5).ForeColor = QBColor(12)
                frmMain.labMF5(5).Caption = "Fail"
                Call frmMain.OnMfError
            End If
            
        Case 1  ' Read Value
            If frmMain.MF5x1.mfGetValue(blk, Value) Then
                labValue.Caption = CStr(Value)
                frmMain.labMF5(5).ForeColor = QBColor(2)
                frmMain.labMF5(5).Caption = "Ok"
            Else
                labValue.Caption = "Fail"
                frmMain.labMF5(5).ForeColor = QBColor(12)
                frmMain.labMF5(5).Caption = "Fail"
                Call frmMain.OnMfError
            End If
            
        Case 2  ' Inc
            If frmMain.MF5x1.mfValueSet(blk, MF_INC, Val(txtValue(0).Text)) Then
                frmMain.labMF5(5).ForeColor = QBColor(2)
                frmMain.labMF5(5).Caption = "Ok"
                frmMain.cmdMF5_Click 4
                frmMain.MF5x1.mfGetValue blk, Value
                frmMain.AddRecord MF_INC, Val(txtValue(0).Text), Value
            Else
                frmMain.labMF5(5).ForeColor = QBColor(12)
                frmMain.labMF5(5).Caption = "Fail"
                Call frmMain.OnMfError
            End If
        
        Case 3  ' Dec
            If frmMain.MF5x1.mfValueSet(blk, MF_DEC, Val(txtValue(1).Text)) Then
                frmMain.labMF5(5).ForeColor = QBColor(2)
                frmMain.labMF5(5).Caption = "Ok"
                frmMain.cmdMF5_Click 4
                frmMain.MF5x1.mfGetValue blk, Value
                frmMain.AddRecord MF_DEC, Val(txtValue(1).Text), Value
            Else
                frmMain.labMF5(5).ForeColor = QBColor(12)
                frmMain.labMF5(5).Caption = "Fail"
                Call frmMain.OnMfError
            End If
    End Select
Err_Exit:
    Exit Sub

Err_Proc:
    Debug.Print "cmdValue_Click - " & Err.Description & "(" & Err.Number & ")"
    Resume Err_Exit
End Sub

Private Sub Form_Load()
    Me.Top = GetSetting(App.Title, "ValueWin", "top", Me.Top)
    Me.Left = GetSetting(App.Title, "ValueWin", "left", Me.Left)
End Sub

Private Sub Form_Unload(Cancel As Integer)
    SaveSetting App.Title, "ValueWin", "top", Me.Top
    SaveSetting App.Title, "ValueWin", "left", Me.Left
End Sub


Private Sub txtValue_KeyPress(Index As Integer, KeyAscii As Integer)
    If (KeyAscii < &H30 Or KeyAscii > &H39) And KeyAscii >= &H20 Then
        KeyAscii = 0
    End If
End Sub


