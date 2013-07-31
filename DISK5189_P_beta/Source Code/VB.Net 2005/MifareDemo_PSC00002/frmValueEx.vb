Option Strict Off
Option Explicit On
Friend Class frmValueEx
	Inherits System.Windows.Forms.Form
	
    Private Enum iValueBlockOptConstants
        OnBlockSuccess
        OnBlockError
        OnBlockChanged
    End Enum
	
    Private m_oMF5x As GIGATMS.NF.MifareReader
	Private m_iSector As Short
    Private m_oBlock As System.Windows.Forms.ComboBox
    Private m_bIsSetDataRegister As Boolean
    Private m_bIsExecutingCommand As Boolean

	Private m_bIsLoading As Boolean
	
    Public Sub ShowValueOpt(ByRef oMF5x As GIGATMS.NF.MifareReader, ByRef oBlock As System.Windows.Forms.ComboBox, ByVal iSector As Short)
        Dim I As Integer
        Dim szData As String
        m_oMF5x = oMF5x
        m_oBlock = oBlock
        m_iSector = iSector
        m_bIsLoading = True
        With oBlock
            cboBlock.Items.Clear()
            cboTransferBlock.Items.Clear()
            For I = 0 To .Items.Count - 1
                szData = VB6.GetItemString(oBlock, I)
                cboBlock.Items.Add(szData)
                cboTransferBlock.Items.Add(szData)
            Next I
            I = .SelectedIndex
            cboBlock.SelectedIndex = I
            cboTransferBlock.SelectedIndex = I
        End With
        m_bIsLoading = False
        cmdValueOpt_Click(cmdValueOpt.Item(1), New System.EventArgs()) ' Call Read Value
        CheckWritable()
        Me.ShowDialog(System.Windows.Forms.Form.ActiveForm)
    End Sub
	
	Public Sub CheckWritable()
		Dim bWritable As Boolean
		bWritable = IsWritable(m_iSector, m_oBlock.SelectedIndex)
		cmdValueOpt(0).Enabled = bWritable ' Format
		bWritable = IsWritable(m_iSector, cboTransferBlock.SelectedIndex)
        cmdValueOpt(5).Enabled = bWritable And m_bIsSetDataRegister  ' Transfer
	End Sub
	
	Public Function IsWritable(ByVal iSector As Short, ByVal iBlock As Short) As Boolean
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
	
    Private Sub cboBlock_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboBlock.SelectedIndexChanged
        If m_bIsLoading = False Then
            m_oBlock.SelectedIndex = cboBlock.SelectedIndex
            CheckWritable()
        End If
    End Sub
	
    Private Sub cboTransferBlock_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboTransferBlock.SelectedIndexChanged
        If m_bIsLoading = False Then
            CheckWritable()
        End If
    End Sub
	
	Private Sub cmdValueOpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdValueOpt.Click
		Dim Index As Short = cmdValueOpt.GetIndex(eventSender)
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
        Debug.Print("cmdValueOpt_Click(" & Index & ") - " & Err.Description & "(" & Err.Number & ")")
        Resume Err_Exit
    End Sub

    Private Sub ExecutingCommand(ByVal Index As Integer)
        Dim bIsResult As Boolean
        Dim bIsDataChagned As Boolean
        Dim bBlockOpt As GIGATMS.NF.MifareReader.bMifareOptConstants
        Dim lOptValue As Integer
        Dim iBlock As Short
        Dim lBlockValue As Integer
        Dim iTransferBlock As Short
        Dim lDataRegister As Integer
        Dim bIsSetDataRegister As Boolean
        Dim bIslTransfer As Boolean
        Const VALUE_OPT_NONE As Integer = 0
        On Error GoTo Err_Proc

        bBlockOpt = VALUE_OPT_NONE
        txtDataRegister.Text = vbNullString
        txtTransferValue.Text = vbNullString
        lBlockValue = Val(txtBlockValue.Text)
        iBlock = cboBlock.SelectedIndex
        iTransferBlock = cboTransferBlock.SelectedIndex
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
                bBlockOpt = GIGATMS.NF.MifareReader.bMifareOptConstants.MIFARE_OPT_INC
                bIsResult = m_oMF5x.mfValueOptEx(iBlock, bBlockOpt, lOptValue)
                If bIsResult Then
                    lDataRegister = lBlockValue + lOptValue
                    bIsSetDataRegister = True
                End If
            Case 3 ' Decrement
                lOptValue = Val(txtOptValue.Text)
                bBlockOpt = GIGATMS.NF.MifareReader.bMifareOptConstants.MIFARE_OPT_DEC
                bIsResult = m_oMF5x.mfValueOptEx(iBlock, bBlockOpt, lOptValue)
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
                ShowStatus(cmdValueOpt(Index).Text & " OK", System.Drawing.Color.Lime)
                OnValueEvent(iValueBlockOptConstants.OnBlockSuccess)
                If bIsDataChagned Then
                    OnValueEvent(iValueBlockOptConstants.OnBlockChanged)
                End If
                If bBlockOpt <> VALUE_OPT_NONE Then
                    frmMain.AddRecord(bBlockOpt, lOptValue)
                End If
            Else
                If m_oMF5x.GNetErrorCode = 0 Then
                    ShowStatus(cmdValueOpt(Index).Text & " Error", System.Drawing.Color.Red)
                Else
                    ShowStatus(cmdValueOpt(Index).Text & " Error(" & m_oMF5x.GNetErrorCodeStr & ")", System.Drawing.Color.Red)
                End If
            End If
        Else
            If m_oMF5x.GNetErrorCode = 0 Then
                ShowStatus(cmdValueOpt(Index).Text & " Error", System.Drawing.Color.Red)
            Else
                ShowStatus(cmdValueOpt(Index).Text & " Error(" & m_oMF5x.GNetErrorCodeStr & ")", System.Drawing.Color.Red)
            End If
            OnValueEvent(iValueBlockOptConstants.OnBlockError)
        End If
        CheckWritable()
Err_Exit:
        Exit Sub
Err_Proc:
        Debug.Print("cmdValueOpt_Click -" & Err.Description & "(" & Err.Number & ")")
        Resume Err_Exit
    End Sub
	
    Public Sub ShowStatus(ByRef szMsg As String, ByRef lColor As System.Drawing.Color)
        If IsNothing(lColor) Then
            lColor = System.Drawing.Color.Black
        End If
        With labStatus
            .Text = szMsg
            .ForeColor = lColor
        End With
    End Sub
	
    Private Sub txtOptValue_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtOptValue.TextChanged
        Dim szData As String
        With txtOptValue
            szData = .Text
            If IsNumeric(szData) = False Then
                szData = CStr(Val(szData))
                .Text = szData
                .SelectionStart = Len(szData)
            End If
        End With
    End Sub
	
	Private Sub txtOptValue_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtOptValue.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Select Case KeyAscii
			Case Is < 32
			Case 48 To 57 ' 0 to 9
			Case Else
				KeyAscii = 0
		End Select
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
    End Sub

    Private Sub OnValueEvent(ByRef iEvent As iValueBlockOptConstants)
        Select Case iEvent
            Case iValueBlockOptConstants.OnBlockSuccess
                frmMain.labMF5(5).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(2))
                frmMain.labMF5(5).Text = "Ok"
            Case iValueBlockOptConstants.OnBlockError
                frmMain.labMF5(5).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(12))
                frmMain.labMF5(5).Text = "Fail"
                Call frmMain.OnMfError()
            Case iValueBlockOptConstants.OnBlockChanged
                frmMain.cmdMF5_Click(frmMain.cmdMF5.Item(4), New System.EventArgs())
        End Select
    End Sub
End Class