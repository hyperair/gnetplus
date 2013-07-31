Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic

Friend Class frmAccess
    Inherits System.Windows.Forms.Form

    Private CB3, CB1, CB0, CB2, GPB As Short

    Private Sub cmdAccess_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAccess.Click
        Dim bCancel As Boolean

        CB0 = lstAccess(0).SelectedIndex
        CB1 = lstAccess(1).SelectedIndex
        CB2 = lstAccess(2).SelectedIndex
        CB3 = lstAccess(3).SelectedIndex

        txtKEY(0).Text = txtKEY(0).Text & New String("0", 12 - Len(txtKEY(0).Text))
        txtKEY(1).Text = txtKEY(1).Text & New String("0", 12 - Len(txtKEY(1).Text))

        labMsg.Text = vbNullString

        Select Case CB3
            Case 4, 5, 6
                bCancel = False
            Case Else
                If MsgBox("If you select Access bits=" & CB3 & " the access bits will be READ-ONLY." & vbCrLf & "Do you want to continue update?", MsgBoxStyle.OkCancel Or MsgBoxStyle.Exclamation) = MsgBoxResult.Ok Then
                    bCancel = False 'vbOK
                Else
                    bCancel = True 'vbCancel
                End If
        End Select

        If bCancel = False Then
            If frmMain.MF5x1.mfAccessCondition(txtKEY(0).Text, txtKEY(1).Text, CB0, CB1, CB2, CB3) Then
                labMsg.ForeColor = System.Drawing.Color.Blue
                labMsg.Text = "OK"
            Else
                labMsg.ForeColor = System.Drawing.Color.Red
                If frmMain.MF5x1.GNetErrorCode = 0 Then
                    labMsg.Text = "NG"
                Else
                    labMsg.Text = "NG(" & frmMain.MF5x1.GNetErrorCodeStr & ")"
                End If
                Call frmMain.OnMfError()
            End If
        End If
    End Sub

    Private Sub frmAccess_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim szData As String = vbNullString
        Dim bBuffer() As Byte
        If frmMain.MF5x1.mfGetAccessCondition(CB0, CB1, CB2, CB3, GPB) Then
            lstAccess(0).SelectedIndex = CB0
            lstAccess(1).SelectedIndex = CB1
            lstAccess(2).SelectedIndex = CB2
            lstAccess(3).SelectedIndex = CB3
        Else
            lstAccess(0).SelectedIndex = 0 ' default
            lstAccess(1).SelectedIndex = 0 ' default
            lstAccess(2).SelectedIndex = 0 ' default
            lstAccess(3).SelectedIndex = 4 ' default
        End If
        If frmMain.cmbSector.SelectedIndex >= 32 Then
            Frame1(0).Text = "Access Bits / Block 0~4"
            Frame1(1).Text = "Access Bits / Block 5~9"
            Frame1(2).Text = "Access Bits / Block 10~14"
            Frame1(3).Text = "Access Bits / Block 15"
        Else
            Frame1(0).Text = "Access Bits / Block 0"
            Frame1(1).Text = "Access Bits / Block 1"
            Frame1(2).Text = "Access Bits / Block 2"
            Frame1(3).Text = "Access Bits / Block 3"
        End If
        Select Case CB3
            Case 0, 2, 4 ' Allow Read Key B
                ReDim bBuffer(0 To 15)
                If frmMain.MF5x1.mfRead(frmMain.cmbBlock.Items.Count - 1, bBuffer) Then
                    szData = modMifare.BytesToHex(bBuffer)
                    If Len(szData) = 32 Then
                        txtKEY(1).Text = VB.Right(szData, 12) 'Key B
                    End If
                End If
        End Select

        modMifare.LoadFormPosision(Me)
        labMsg.Text = vbNullString
    End Sub

    Private Sub frmAccess_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        modMifare.SaveFormPosision(Me)
    End Sub

    Private Sub txtKEY_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtKEY.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = txtKEY.GetIndex(eventSender)
        If KeyAscii >= &H30S And KeyAscii <= &H39S Then
        ElseIf KeyAscii >= &H41S And KeyAscii <= &H46S Then
        ElseIf KeyAscii >= &H61S And KeyAscii <= &H66S Then
            KeyAscii = KeyAscii - &H20S
        ElseIf KeyAscii > &H20S Then
            KeyAscii = 0
        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
End Class