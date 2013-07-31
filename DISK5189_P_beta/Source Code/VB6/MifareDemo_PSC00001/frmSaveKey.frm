VERSION 5.00
Begin VB.Form frmSaveKey 
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Save Key To Reader EEPROM"
   ClientHeight    =   1575
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   5805
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   1575
   ScaleWidth      =   5805
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin VB.CommandButton cmdSave 
      Caption         =   "Save All"
      Height          =   375
      Index           =   1
      Left            =   4320
      TabIndex        =   5
      Top             =   600
      Width           =   1335
   End
   Begin VB.CommandButton cmdSave 
      Caption         =   "Exit"
      Height          =   375
      Index           =   2
      Left            =   4320
      TabIndex        =   6
      Top             =   1080
      Width           =   1335
   End
   Begin VB.CommandButton cmdSave 
      Caption         =   "Save"
      Height          =   375
      Index           =   0
      Left            =   4320
      TabIndex        =   4
      Top             =   120
      Width           =   1335
   End
   Begin VB.TextBox txtKEY 
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
      Left            =   2250
      MaxLength       =   12
      TabIndex        =   3
      Text            =   "FFFFFFFFFFFF"
      Top             =   630
      Width           =   1875
   End
   Begin VB.OptionButton optKEY 
      Caption         =   "KEY_A"
      BeginProperty Font 
         Name            =   "Courier New"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   285
      Index           =   0
      Left            =   2280
      TabIndex        =   1
      Top             =   180
      Value           =   -1  'True
      Width           =   885
   End
   Begin VB.OptionButton optKEY 
      Caption         =   "KEY_B"
      BeginProperty Font 
         Name            =   "Courier New"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   285
      Index           =   1
      Left            =   3240
      TabIndex        =   2
      Top             =   180
      Width           =   885
   End
   Begin VB.ComboBox cmbSector 
      Height          =   315
      ItemData        =   "frmSaveKey.frx":0000
      Left            =   780
      List            =   "frmSaveKey.frx":0034
      Style           =   2  'Dropdown List
      TabIndex        =   0
      Top             =   165
      Width           =   1365
   End
   Begin VB.Label labStatus 
      BackColor       =   &H00808080&
      BeginProperty Font 
         Name            =   "Courier New"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   120
      TabIndex        =   8
      Top             =   1200
      Width           =   4095
   End
   Begin VB.Image Image1 
      Height          =   480
      Left            =   60
      Picture         =   "frmSaveKey.frx":00DE
      Top             =   210
      Width           =   480
   End
   Begin VB.Label Label1 
      Alignment       =   1  'Right Justify
      Caption         =   "KEY (HEX) : "
      BeginProperty Font 
         Name            =   "Courier New"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   225
      Left            =   780
      TabIndex        =   7
      Top             =   675
      Width           =   1335
   End
End
Attribute VB_Name = "frmSaveKey"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private m_bIsExecutingCommand As Boolean

Private Sub cmdSave_Click(Index As Integer)
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
    Debug.Print "cmdSave_Click(" & Index & ") - " & Err.Description & "(" & Err.Number & ")"
    Resume Err_Exit
End Sub

Private Sub ExecutingCommand(Index As Integer)
    Dim szKey As String, res As Boolean, nSector As Integer, retry As Integer
    
    ' fill to 12 char (6 HEXs)
    txtKEY.Text = txtKEY.Text + String(12 - Len(txtKEY.Text), "0")
    
    
    
    Select Case Index
        Case 0
            nSector = cmbSector.ListIndex
            
            'Save Key To EEPROM for one sector
            With frmMain
                If optKEY(0).Value Then ' Key Type A
                    res = .MF5x1.mfSaveKey(KEY_A, nSector, txtKEY.Text)
                Else                    ' Key Type B
                    res = .MF5x1.mfSaveKey(KEY_B, nSector, txtKEY.Text)
                End If
                
                If res Then ' show status
                    labStatus.Caption = "Save Key To EEPROM:OK(" + CStr(nSector) + ")"
                Else
                    labStatus.Caption = "Save Key To EEPROM:NG(" + CStr(nSector) + ")"
                End If
            End With
        Case 1
            nSector = 0
            
            ' Save Key To EEPROM for all sector
            With frmMain
                Do                  ' for MIFARE 1K (total 16 sectors)
                    DoEvents
                    For retry = 1 To 3
                        If optKEY(0).Value Then ' Key Type A
                            res = .MF5x1.mfSaveKey(KEY_A, nSector, txtKEY.Text)
                        Else                    ' Key Type B
                            res = .MF5x1.mfSaveKey(KEY_B, nSector, txtKEY.Text)
                        End If
                        
                        If res Then ' show status
                            labStatus.Caption = "Save Key To EEPROM:OK(" + CStr(nSector) + ")"
                            Exit For
                        Else
                            labStatus.Caption = "Save Key To EEPROM:NG(" + CStr(nSector) + ")"
                            Debug.Print labStatus.Caption
                        End If
                    Next retry
                    nSector = nSector + 1
                Loop Until (res = False Or nSector = cmbSector.ListCount)
            End With
        Case 2
            Unload Me
    End Select
End Sub

Private Sub Form_Load()
    Dim s As Integer
    Dim lSaveKeyMaxCount As Long
    
    lSaveKeyMaxCount = frmMain.SaveKeyMaxCount
    
    cmbSector.Clear
    For s = 0 To lSaveKeyMaxCount - 1
        cmbSector.AddItem "Sector " & CStr(s)
    Next s
    
    Select Case frmMain.cmbSector.ListIndex
    Case 0 To cmbSector.ListCount - 1
        cmbSector.ListIndex = frmMain.cmbSector.ListIndex
    Case Else
        cmbSector.ListIndex = -1
    End Select
    
    Me.Top = GetSetting(App.Title, "SaveWin", "top", Me.Top)
    Me.Left = GetSetting(App.Title, "SaveWin", "left", Me.Left)
    
End Sub


Private Sub Form_Unload(Cancel As Integer)
    
    SaveSetting App.Title, "SaveWin", "top", Me.Top
    SaveSetting App.Title, "SaveWin", "left", Me.Left
    
End Sub


Private Sub txtKEY_KeyPress(KeyAscii As Integer)
    If KeyAscii >= &H30 And KeyAscii <= &H39 Then
    
    ElseIf KeyAscii >= &H41 And KeyAscii <= &H46 Then
    
    ElseIf KeyAscii >= &H61 And KeyAscii <= &H66 Then
    
        KeyAscii = KeyAscii - &H20
        
    ElseIf KeyAscii > &H20 Then
        KeyAscii = 0
    End If
End Sub


