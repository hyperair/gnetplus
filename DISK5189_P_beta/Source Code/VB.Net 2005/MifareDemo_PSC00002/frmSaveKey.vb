Option Strict Off
Option Explicit On
Imports GIGATMS.NF

Friend Class frmSaveKey
    Inherits System.Windows.Forms.Form

    Private m_bIsExecutingCommand As Boolean

    Private m_oMifareReader As MifareReader

    Private Sub cmdSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSave.Click
        Dim Index As Short = cmdSave.GetIndex(eventSender)
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
        Debug.Print("cmdSave_Click(" & Index & ") - " & Err.Description & "(" & Err.Number & ")")
        Resume Err_Exit
    End Sub

    Private Sub ExecutingCommand(ByVal Index As Short)
        Dim szKey As String
        Dim res As Boolean
        Dim nSector, retry As Short

        ' fill to 12 char (6 HEXs)
        txtKEY.Text = txtKEY.Text & New String("0", 12 - Len(txtKEY.Text))

        nSector = cmbSector.SelectedIndex

        Select Case Index
            Case 0
                'Save Key To EEPROM for one sector
                If optKEY(0).Checked Then ' Key Type A
                    res = m_oMifareReader.mfSaveKey(nSector, MifareReader.bKeyTypeConstants.KEY_A, txtKEY.Text)
                Else ' Key Type B
                    res = m_oMifareReader.mfSaveKey(nSector, MifareReader.bKeyTypeConstants.KEY_B, txtKEY.Text)
                End If

                If res Then ' show status
                    labStatus.Text = "Save Key To EEPROM:OK(" & CStr(nSector) & ")"
                Else
                    labStatus.Text = "Save Key To EEPROM:NG(" & CStr(nSector) & ")"
                End If
            Case 1
                ' Save Key To EEPROM for all sector
                szKey = txtKEY.Text
                For nSector = 0 To cmbSector.Items.Count - 1 ' for MIFARE 1K (total 16 sectors)
                    For retry = 1 To 3
                        If optKEY(0).Checked Then ' Key Type A
                            res = m_oMifareReader.mfSaveKey(nSector, MifareReader.bKeyTypeConstants.KEY_A, szKey)
                        Else ' Key Type B
                            res = m_oMifareReader.mfSaveKey(nSector, MifareReader.bKeyTypeConstants.KEY_B, szKey)
                        End If

                        If res Then ' show status
                            labStatus.Text = "Save Key To EEPROM:OK(" & CStr(nSector) & ")"
                            Exit For
                        Else
                            labStatus.Text = "Save Key To EEPROM:NG(" & CStr(nSector) & ")"
                            Debug.Print(labStatus.Text)
                        End If
                    Next retry
                    System.Windows.Forms.Application.DoEvents()
                Next nSector
            Case 2
                Me.Close()
                Me.Dispose()
        End Select
    End Sub

    Private Sub frmSaveKey_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        modMifare.SaveFormPosision(Me)
    End Sub

    Private Sub txtKEY_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtKEY.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case Is < &H20S
            Case &H30S To &H39S '0~9
            Case &H41S To &H46S 'A~F
            Case &H61S To &H66S 'a~f
                eventArgs.KeyChar = UCase(eventArgs.KeyChar)
            Case Else
                eventArgs.Handled = True
        End Select
    End Sub

    Public Sub ShowSaveKey(ByRef oMifareReader As MifareReader, ByVal iSelSector As Integer, ByVal iMaxSectorCount As Integer)
        Dim I As Integer

        m_oMifareReader = oMifareReader
        With cmbSector
            With .Items
                .Clear()
                For I = 0 To (iMaxSectorCount - 1)
                    .Add("Sector " & CStr(I))
                    If I = iSelSector Then

                    End If
                Next I
            End With
            Select Case iSelSector
                Case 0 To (.Items.Count - 1)
                    .SelectedIndex = iSelSector
            End Select
        End With

        modMifare.LoadFormPosision(Me)
        Me.ShowDialog()
        Me.Dispose()
    End Sub
End Class