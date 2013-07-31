VERSION 5.00
Begin VB.Form frmAccess 
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Access Condition"
   ClientHeight    =   5640
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   6345
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   376
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   423
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin VB.Frame Frame1 
      Caption         =   "Access Bits / Block 3"
      Height          =   1605
      Index           =   3
      Left            =   75
      TabIndex        =   24
      Top             =   3975
      Width           =   5430
      Begin VB.ListBox lstAccess 
         BeginProperty Font 
            Name            =   "Courier New"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   735
         Index           =   3
         ItemData        =   "frmAccess.frx":0000
         Left            =   135
         List            =   "frmAccess.frx":001C
         TabIndex        =   25
         Top             =   765
         Width           =   5220
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H00C0C0C0&
         Caption         =   "Write"
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
         Index           =   20
         Left            =   4305
         TabIndex        =   34
         Top             =   480
         Width           =   765
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H00C0C0C0&
         Caption         =   "Read"
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
         Index           =   19
         Left            =   3480
         TabIndex        =   33
         Top             =   480
         Width           =   765
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H00C0C0C0&
         Caption         =   "Write"
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
         Index           =   18
         Left            =   2625
         TabIndex        =   32
         Top             =   480
         Width           =   765
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H00C0C0C0&
         Caption         =   "Read"
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
         Index           =   17
         Left            =   1800
         TabIndex        =   31
         Top             =   480
         Width           =   765
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H00C0C0C0&
         Caption         =   "Write"
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
         Index           =   16
         Left            =   960
         TabIndex        =   30
         Top             =   480
         Width           =   765
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H00C0C0C0&
         Caption         =   "Read"
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
         Index           =   15
         Left            =   135
         TabIndex        =   29
         Top             =   480
         Width           =   765
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H00C0C0C0&
         Caption         =   "Key B"
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
         Index           =   14
         Left            =   3480
         TabIndex        =   28
         Top             =   225
         Width           =   1590
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H00C0C0C0&
         Caption         =   "Access Bits"
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
         Index           =   13
         Left            =   1800
         TabIndex        =   27
         Top             =   225
         Width           =   1590
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H00C0C0C0&
         Caption         =   "Key A"
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
         Index           =   12
         Left            =   135
         TabIndex        =   26
         Top             =   225
         Width           =   1590
      End
   End
   Begin VB.Frame Frame1 
      Caption         =   "Access Bits / Block 2"
      Height          =   1275
      Index           =   2
      Left            =   90
      TabIndex        =   17
      Top             =   2685
      Width           =   3855
      Begin VB.ListBox lstAccess 
         BeginProperty Font 
            Name            =   "Courier New"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   735
         Index           =   2
         ItemData        =   "frmAccess.frx":013C
         Left            =   150
         List            =   "frmAccess.frx":0158
         TabIndex        =   18
         Top             =   465
         Width           =   3585
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H00C0C0C0&
         Caption         =   "READ"
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
         Index           =   11
         Left            =   150
         TabIndex        =   22
         Top             =   240
         Width           =   765
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H00C0C0C0&
         Caption         =   "WRITE"
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
         Index           =   10
         Left            =   990
         TabIndex        =   21
         Top             =   240
         Width           =   765
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H00C0C0C0&
         Caption         =   "INC"
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
         Index           =   9
         Left            =   1830
         TabIndex        =   20
         Top             =   240
         Width           =   765
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H00C0C0C0&
         Caption         =   "DEC"
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
         Index           =   8
         Left            =   2670
         TabIndex        =   19
         Top             =   240
         Width           =   765
      End
   End
   Begin VB.Frame Frame1 
      Caption         =   "Access Bits / Block 1"
      Height          =   1275
      Index           =   1
      Left            =   90
      TabIndex        =   11
      Top             =   1380
      Width           =   3855
      Begin VB.ListBox lstAccess 
         BeginProperty Font 
            Name            =   "Courier New"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   735
         Index           =   1
         ItemData        =   "frmAccess.frx":0228
         Left            =   150
         List            =   "frmAccess.frx":0244
         TabIndex        =   12
         Top             =   465
         Width           =   3585
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H00C0C0C0&
         Caption         =   "READ"
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
         Index           =   7
         Left            =   150
         TabIndex        =   16
         Top             =   240
         Width           =   765
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H00C0C0C0&
         Caption         =   "WRITE"
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
         Index           =   6
         Left            =   990
         TabIndex        =   15
         Top             =   240
         Width           =   765
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H00C0C0C0&
         Caption         =   "INC"
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
         Index           =   5
         Left            =   1830
         TabIndex        =   14
         Top             =   240
         Width           =   765
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H00C0C0C0&
         Caption         =   "DEC"
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
         Index           =   4
         Left            =   2670
         TabIndex        =   13
         Top             =   240
         Width           =   765
      End
   End
   Begin VB.Frame Frame1 
      Caption         =   "Access Bits / Block 0"
      Height          =   1275
      Index           =   0
      Left            =   90
      TabIndex        =   5
      Top             =   75
      Width           =   3855
      Begin VB.ListBox lstAccess 
         BeginProperty Font 
            Name            =   "Courier New"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   735
         Index           =   0
         ItemData        =   "frmAccess.frx":0314
         Left            =   150
         List            =   "frmAccess.frx":0330
         TabIndex        =   7
         Top             =   465
         Width           =   3585
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H00C0C0C0&
         Caption         =   "DEC"
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
         Index           =   3
         Left            =   2670
         TabIndex        =   10
         Top             =   240
         Width           =   765
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H00C0C0C0&
         Caption         =   "INC"
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
         Index           =   2
         Left            =   1830
         TabIndex        =   9
         Top             =   240
         Width           =   765
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H00C0C0C0&
         Caption         =   "WRITE"
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
         Index           =   1
         Left            =   990
         TabIndex        =   8
         Top             =   240
         Width           =   765
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H00C0C0C0&
         Caption         =   "READ"
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
         Index           =   0
         Left            =   150
         TabIndex        =   6
         Top             =   240
         Width           =   765
      End
   End
   Begin VB.CommandButton cmdAccess 
      Caption         =   "Update"
      Height          =   465
      Left            =   4740
      TabIndex        =   4
      Top             =   915
      Width           =   1485
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
      Index           =   1
      Left            =   4740
      MaxLength       =   12
      TabIndex        =   2
      Text            =   "FFFFFFFFFFFF"
      Top             =   510
      Width           =   1485
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
      Index           =   0
      Left            =   4740
      MaxLength       =   12
      TabIndex        =   0
      Text            =   "FFFFFFFFFFFF"
      Top             =   150
      Width           =   1485
   End
   Begin VB.Label Label2 
      BackStyle       =   0  'Transparent
      Caption         =   $"frmAccess.frx":0400
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   2115
      Left            =   4050
      TabIndex        =   23
      Top             =   1845
      Width           =   2205
   End
   Begin VB.Image Image1 
      Height          =   480
      Left            =   4020
      Picture         =   "frmAccess.frx":04F5
      Top             =   1320
      Width           =   480
   End
   Begin VB.Label labAccess 
      Alignment       =   1  'Right Justify
      Caption         =   "KEY_B "
      BeginProperty Font 
         Name            =   "Courier New"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Index           =   1
      Left            =   4050
      TabIndex        =   3
      Top             =   540
      Width           =   645
   End
   Begin VB.Label labAccess 
      Alignment       =   1  'Right Justify
      Caption         =   "KEY_A "
      BeginProperty Font 
         Name            =   "Courier New"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Index           =   0
      Left            =   4050
      TabIndex        =   1
      Top             =   180
      Width           =   645
   End
   Begin VB.Label labMsg 
      Alignment       =   1  'Right Justify
      BackStyle       =   0  'Transparent
      Height          =   195
      Left            =   4035
      TabIndex        =   35
      Top             =   1410
      Width           =   2130
   End
End
Attribute VB_Name = "frmAccess"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private CB0 As Integer, CB1  As Integer, CB2  As Integer, CB3  As Integer, GPB  As Integer

Private Sub cmdAccess_Click()
    Dim res As Boolean, bCancel As Boolean
    
    CB0 = lstAccess(0).ListIndex
    CB1 = lstAccess(1).ListIndex
    CB2 = lstAccess(2).ListIndex
    CB3 = lstAccess(3).ListIndex
    
    txtKEY(0).Text = txtKEY(0).Text + String(12 - Len(txtKEY(0).Text), "0")
    txtKEY(1).Text = txtKEY(1).Text + String(12 - Len(txtKEY(1).Text), "0")
    
    labMsg.Caption = vbNullString

    Select Case CB3
    Case 4, 5, 6
        bCancel = False
    Case Else
        If MsgBox("If you select Access bits=" & CB3 & " the access bits will be READ-ONLY." & vbCrLf & "Do you want to continue update?", vbOKCancel Or vbExclamation) = vbOK Then
            bCancel = False 'vbOK
        Else
            bCancel = True  'vbCancel
        End If
    End Select
    
    If bCancel = False Then
        If frmMain.MF5x1.mfAccessCondition(txtKEY(0).Text, txtKEY(1).Text, CB0, CB1, CB2, CB3) Then
            labMsg.ForeColor = vbBlue
            labMsg.Caption = "OK"
        Else
            labMsg.ForeColor = vbRed
            If frmMain.MF5x1.GNetErrorCode = 0 Then
                labMsg.Caption = "NG"
            Else
                labMsg.Caption = "NG(" & frmMain.MF5x1.GNetErrorCodeStr & ")"
            End If
            Call frmMain.OnMfError
        End If
    End If
End Sub

Private Sub Form_Load()
    Dim szData As String
    If frmMain.MF5x1.mfGetAccessCondition(CB0, CB1, CB2, CB3, GPB) Then
        lstAccess(0).ListIndex = CB0
        lstAccess(1).ListIndex = CB1
        lstAccess(2).ListIndex = CB2
        lstAccess(3).ListIndex = CB3
    Else
        lstAccess(0).ListIndex = 0  ' default
        lstAccess(1).ListIndex = 0  ' default
        lstAccess(2).ListIndex = 0  ' default
        lstAccess(3).ListIndex = 4  ' default
    End If
    If frmMain.cmbSector.ListIndex > 31 Then
        Frame1(0).Caption = "Access Bits / Block 0~4"
        Frame1(1).Caption = "Access Bits / Block 5~9"
        Frame1(2).Caption = "Access Bits / Block 10~14"
        Frame1(3).Caption = "Access Bits / Block 15"
    End If
    Select Case CB3
    Case 0, 2, 4 ' Allow Read Key B
        If frmMain.MF5x1.mfReadHex((frmMain.cmbBlock.ListCount - 1), szData) Then
            If Len(szData) = 32 Then
                txtKEY(1).Text = Right$(szData, 12) 'Key B
            End If
        End If
    End Select
    
    ' keep window posision
    Me.Top = GetSetting(App.Title, "AccWin", "top", Me.Top)
    Me.Left = GetSetting(App.Title, "AccWin", "left", Me.Left)
    
    labMsg.Caption = vbNullString
End Sub


Private Sub Form_Unload(Cancel As Integer)
    SaveSetting App.Title, "AccWin", "top", Me.Top
    SaveSetting App.Title, "AccWin", "left", Me.Left
End Sub

Private Sub txtKEY_KeyPress(Index As Integer, KeyAscii As Integer)
    If KeyAscii >= &H30 And KeyAscii <= &H39 Then
    
    ElseIf KeyAscii >= &H41 And KeyAscii <= &H46 Then
    
    ElseIf KeyAscii >= &H61 And KeyAscii <= &H66 Then
    
        KeyAscii = KeyAscii - &H20
        
    ElseIf KeyAscii > &H20 Then
        KeyAscii = 0
    End If

End Sub

