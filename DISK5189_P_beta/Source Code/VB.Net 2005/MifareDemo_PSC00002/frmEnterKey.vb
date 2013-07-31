Option Strict Off
Option Explicit On
Friend Class frmEnterKey
	Inherits System.Windows.Forms.Form
	
	Private m_bOK As Boolean
	Private m_szKey As String
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		m_bOK = True
		m_szKey = txtKEY.Text
		Me.Close()
	End Sub
	
	Private Sub txtKEY_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtKEY.Enter
		With txtKEY
			.SelectionStart = 0
			.SelectionLength = Len(.Text)
		End With
	End Sub
	
	Private Sub txtKEY_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtKEY.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case 13 'Enter
				cmdOK_Click(cmdOK, New System.EventArgs())
			Case 27 'ESC
				cmdCancel_Click(cmdCancel, New System.EventArgs())
			Case Is < 32
			Case 48 To 57 '0~9
			Case 65 To 70 'A~F
			Case 97 To 102 'a~f
				KeyAscii = KeyAscii - 32 'LCase To UCase
			Case Else
				KeyAscii = 0
		End Select
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
    Public Function GetKey() As String
        Dim szResult As String
        szResult = vbNullString
        If m_szKey <> vbNullString Then
            txtKEY.Text = m_szKey 'Previous Key
        End If
        m_bOK = False
        m_szKey = vbNullString
        Me.ShowDialog(System.Windows.Forms.Form.ActiveForm)
        If m_bOK Then
            szResult = m_szKey
        End If
        Me.Close()
        Me.Dispose()
        Return szResult
    End Function
End Class