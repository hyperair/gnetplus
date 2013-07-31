VERSION 5.00
Begin VB.Form frmEnterKey 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Enter Key"
   ClientHeight    =   1200
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   4035
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   1200
   ScaleWidth      =   4035
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin VB.CommandButton cmdCancel 
      Caption         =   "Cancel"
      Height          =   345
      Left            =   2220
      TabIndex        =   3
      Top             =   720
      Width           =   1335
   End
   Begin VB.CommandButton cmdOK 
      Caption         =   "OK"
      Height          =   345
      Left            =   570
      TabIndex        =   2
      Top             =   720
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
      Left            =   2070
      MaxLength       =   12
      TabIndex        =   0
      Text            =   "FFFFFFFFFFFF"
      Top             =   120
      Width           =   1875
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
      Left            =   630
      TabIndex        =   1
      Top             =   180
      Width           =   1335
   End
   Begin VB.Image Image1 
      Height          =   480
      Left            =   0
      Picture         =   "frmEnterKey.frx":0000
      Top             =   0
      Width           =   480
   End
End
Attribute VB_Name = "frmEnterKey"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private m_bOK As Boolean
Private m_szKey As String

Private Sub cmdCancel_Click()
    Unload Me
End Sub

Private Sub cmdOK_Click()
    m_bOK = True
    m_szKey = txtKEY.Text
    Unload Me
End Sub

Private Sub txtKEY_GotFocus()
    With txtKEY
        .SelStart = 0
        .SelLength = Len(.Text)
    End With
End Sub

Private Sub txtKEY_KeyPress(KeyAscii As Integer)
    Select Case KeyAscii
    Case 13 'Enter
        cmdOK_Click
    Case 27 'ESC
        cmdCancel_Click
    Case Is < 32
    Case 48 To 57 '0~9
    Case 65 To 70 'A~F
    Case 97 To 102 'a~f
        KeyAscii = KeyAscii - 32 'LCase To UCase
    Case Else
        KeyAscii = 0
    End Select
End Sub

Public Function GetKey() As String
    GetKey = vbNullString
    If m_szKey <> vbNullString Then
        txtKEY.Text = m_szKey 'Previous Key
    End If
    m_bOK = False
    m_szKey = vbNullString
    Me.Show vbModal
    If m_bOK Then GetKey = m_szKey
    Unload Me
End Function
