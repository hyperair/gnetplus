Option Strict Off
Option Explicit On

Friend Class frmValue
    Inherits System.Windows.Forms.Form

    Private m_bIsExecutingCommand As Boolean

    Private Sub cmdValue_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdValue.Click
        Dim Index As Short = cmdValue.GetIndex(eventSender)
        Dim bIsExecutingCommand As Boolean
        On Error GoTo Err_Proc
        bIsExecutingCommand = m_bIsExecutingCommand
        If m_bIsExecutingCommand = False Then
            m_bIsExecutingCommand = True
            ExecutingCommand(Index)
        End If
Err_Exit:
        m_bIsExecutingCommand = bIsExecutingCommand
        Exit Sub

Err_Proc:
        Debug.Print("cmdValue_Click(" & Index & ") - " & Err.Description & "(" & Err.Number & ")")
        Resume Err_Exit
    End Sub

    Private Sub ExecutingCommand(ByVal Index As Integer)
        Dim res As String
        Dim iValue As Integer
        Dim blk As Byte

        On Error Resume Next

        blk = frmMain.cmbBlock.SelectedIndex

        Select Case Index
            Case 0 ' Format
                If frmMain.MF5x1.mfSetValue(blk, 0) Then
                    frmMain.labMF5(5).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(2))
                    frmMain.labMF5(5).Text = "Ok"
                    frmMain.cmdMF5_Click(Nothing, New System.EventArgs())
                Else
                    frmMain.labMF5(5).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(12))
                    frmMain.labMF5(5).Text = "Fail"
                    Call frmMain.OnMfError()
                End If
            Case 1 ' Read Value
                If frmMain.MF5x1.mfGetValue(blk, iValue) Then
                    labValue.Text = iValue.ToString()
                    frmMain.labMF5(5).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(2))
                    frmMain.labMF5(5).Text = "Ok"
                Else
                    labValue.Text = "Fail"
                    frmMain.labMF5(5).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(12))
                    frmMain.labMF5(5).Text = "Fail"
                    Call frmMain.OnMfError()
                End If
            Case 2 ' Inc
                If frmMain.MF5x1.mfValueOpt(blk, GIGATMS.NF.MifareReader.bMifareOptConstants.MIFARE_OPT_INC, Val(txtValue(0).Text)) Then
                    frmMain.labMF5(5).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(2))
                    frmMain.labMF5(5).Text = "Ok"
                    frmMain.cmdMF5_Click(Nothing, New System.EventArgs())
                    frmMain.AddRecord(GIGATMS.NF.MifareReader.bMifareOptConstants.MIFARE_OPT_INC, Val(txtValue(0).Text))
                Else
                    frmMain.labMF5(5).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(12))
                    frmMain.labMF5(5).Text = "Fail"
                    Call frmMain.OnMfError()
                End If
            Case 3 ' Dec
                If frmMain.MF5x1.mfValueOpt(blk, GIGATMS.NF.MifareReader.bMifareOptConstants.MIFARE_OPT_DEC, Val(txtValue(1).Text)) Then
                    frmMain.labMF5(5).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(2))
                    frmMain.labMF5(5).Text = "Ok"
                    frmMain.cmdMF5_Click(Nothing, New System.EventArgs())
                    frmMain.AddRecord(GIGATMS.NF.MifareReader.bMifareOptConstants.MIFARE_OPT_DEC, Val(txtValue(0).Text))
                Else
                    frmMain.labMF5(5).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(12))
                    frmMain.labMF5(5).Text = "Fail"
                    Call frmMain.OnMfError()
                End If
        End Select
    End Sub

    Private Sub frmValue_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        modMifare.LoadFormPosision(Me)
    End Sub

    Private Sub frmValue_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        modMifare.SaveFormPosision(Me)
    End Sub

    Private Sub txtValue_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtValue.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = txtValue.GetIndex(eventSender)
        If (KeyAscii < &H30S Or KeyAscii > &H39S) And KeyAscii >= &H20S Then
            KeyAscii = 0
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
End Class