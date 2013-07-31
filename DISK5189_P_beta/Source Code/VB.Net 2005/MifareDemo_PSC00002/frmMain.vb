Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports GIGATMS.NF.MifareReader
Imports GIGATMS.NF.GNetPlus

Friend Class frmMain
    Inherits System.Windows.Forms.Form

    Private Const NO_ITEM As Integer = -1

    Private m_szCardSN As String
    Private m_szROMType, m_szVersion As String
    Private m_szModuleName As String
    Private m_bDisableAutoMode As Boolean

    Private m_szLastCommPort As String = "COM1"
    Private m_szLastPortSettings As String = "19200,N,8,1"

    Public WithEvents MF5x1 As New GIGATMS.NF.MifareReader

    Private m_bNoChangeEvent As Boolean

    Private m_bIsShowCR As Boolean
    Private m_bIsGNetEvent As Boolean

    Private m_bIsSupportTransfer As Boolean
    Private m_iSupportSaveKeyCount As Integer

    Private m_szCaption As String

    Private m_bIsExecutingCommand As Boolean
    Private m_bIsDeviceScaning As Boolean

    Public Sub AddRecord(ByRef Action As Byte, ByRef iValue As Integer)
        Dim I As Integer, bBuffer() As Byte
        Dim iSerialNumber As Integer
        ReDim bBuffer(0 To 15)
        Dim bResult As Boolean

        Try
            iSerialNumber = CInt(Val("&H" & VB.Right("00000000" & m_szCardSN, 8)))
        Catch ex As Exception
            iSerialNumber = 0
        End Try
        modMifare.PushToByteArray(iSerialNumber, bBuffer, I, True)
        bBuffer(I) = CByte("&H" & CStr(Second(Now)))
        bBuffer(I + 1) = CByte("&H" & CStr(Minute(Now)))
        bBuffer(I + 2) = CByte("&H" & CStr(Hour(Now)))
        bBuffer(I + 3) = CByte("&H" & CStr(Microsoft.VisualBasic.DateAndTime.Day(Now)))
        bBuffer(I + 4) = CByte("&H" & CStr(Month(Now)))
        bBuffer(I + 5) = CByte("&H" & CStr(Year(Now) - 2000))
        I += 6
        modMifare.PushToByteArray(CShort(Action), bBuffer, I, True)
        modMifare.PushToByteArray(iValue, bBuffer, I, True)
        modMifare.PushToByteArray(CInt(0), bBuffer, I, True)
        If m_szModuleName = "PCR310/PRW106/MFR350" Then ' for PRW106/PCR310 RWD
            bResult = MF5x1.AddRecord(bBuffer)
        End If
    End Sub

    Sub EnableAccess(ByRef bFlag As Boolean)
        Select Case MF5x1.mfCurrentClassEx
            Case iCardTypeExConstants.MIFARE_ULTRALIGHT_CL2
                cmdMF5(4).Enabled = True ' read
                cmdMF5(6).Enabled = True ' write
                cmdMF5(5).Enabled = False ' value
                cmdMF5(8).Enabled = False ' condition
                cmdMF5(3).Enabled = False ' Authenticate
                optKEY(0).Enabled = False
                optKEY(1).Enabled = False
                cmbSector.Enabled = False
                cmbBlock.Enabled = True
                txtBlock.MaxLength = 8 ' 4 bytes pre 1 page
                txtBlock.Enabled = bFlag
                txtASCBlock.MaxLength = txtBlock.MaxLength / 2
                txtASCBlock.Enabled = bFlag
                CheckWritable()
            Case iCardTypeExConstants.MIFARE_DESFIRE_CL2
                cmdMF5(4).Enabled = False ' read
                cmdMF5(6).Enabled = False ' write
                cmdMF5(5).Enabled = False ' value
                cmdMF5(8).Enabled = False ' condition
                cmdMF5(3).Enabled = False ' Authenticate
                optKEY(0).Enabled = False
                optKEY(1).Enabled = False
                cmbSector.Enabled = False
                cmbBlock.Enabled = False
            Case Else
                cmdMF5(4).Enabled = bFlag ' read
                cmdMF5(6).Enabled = bFlag ' write
                cmdMF5(5).Enabled = bFlag ' value
                cmdMF5(8).Enabled = bFlag ' condition
                txtBlock.MaxLength = 32 ' 16 bytes pre 1 block
                txtBlock.Enabled = bFlag
                txtASCBlock.MaxLength = txtBlock.MaxLength / 2
                txtASCBlock.Enabled = bFlag
                cmbBlock.Enabled = bFlag
                CheckWritable()
        End Select
    End Sub

    Public Sub OnMfError()
        Dim I As Short
        ' any erroy, all operator must restart
        optKEY(0).Enabled = False
        optKEY(1).Enabled = False
        For I = 1 To cmdMF5.Count - 1
            If I <> 7 And I <> 9 Then
                cmdMF5(I).Enabled = False
            End If
        Next I
        cmdValueEx.Enabled = False
        cmbSector.Enabled = False
        cmbBlock.Enabled = False
        txtBlock.Enabled = False
    End Sub

    Sub ResetStatus()
        Dim lab As System.Windows.Forms.Label

        For Each lab In labMF5
            lab.Text = vbNullString
        Next lab
        labCardType.Text = vbNullString
    End Sub

    Sub SetMaxBlock(ByRef MaxBlock As Short)
        Dim I As Short
        Dim lOldIndex As Integer

        lOldIndex = cmbBlock.SelectedIndex
        cmbBlock.Items.Clear()
        For I = 0 To MaxBlock - 1
            If MF5x1.mfCurrentClassEx <> iCardTypeExConstants.MIFARE_ULTRALIGHT_CL2 Then
                cmbBlock.Items.Add("Block " & CStr(I))
            Else
                cmbBlock.Items.Add("Page " & CStr(I))
            End If
        Next I

        If lOldIndex < cmbBlock.Items.Count And lOldIndex <> -1 Then
            cmbBlock.SelectedIndex = lOldIndex
        Else
            cmbBlock.SelectedIndex = 0
        End If
    End Sub

    Sub SetMaxSector(ByRef MaxSector As Short)
        Dim I As Short
        Dim lOldIndex As Integer

        lOldIndex = cmbSector.SelectedIndex
        cmbSector.Items.Clear()
        If MaxSector > 0 And MF5x1.mfCurrentClassEx <> iCardTypeExConstants.MIFARE_ULTRALIGHT_CL2 Then
            cmbSector.Enabled = True
            For I = 0 To MaxSector - 1
                cmbSector.Items.Add("Sector " & Str(I)) ' 1K & 4K
            Next I
            If lOldIndex < cmbSector.Items.Count And lOldIndex <> -1 Then
                cmbSector.SelectedIndex = lOldIndex
            Else
                cmbSector.SelectedIndex = 0
            End If
        Else
            cmbSector.Enabled = False
        End If
    End Sub

    Public Sub CheckWritable()
        Dim bDisabledWrite As Boolean
        If MF5x1.mfCurrentClassEx = iCardTypeExConstants.MIFARE_ULTRALIGHT_CL2 Then
        ElseIf cmbBlock.SelectedIndex = 0 And cmbSector.SelectedIndex = 0 Then
            bDisabledWrite = True
        ElseIf cmbBlock.SelectedIndex = (cmbBlock.Items.Count - 1) Then
            bDisabledWrite = True
        End If
        If bDisabledWrite Then
            'Can't Write or Set Value to Last Block
            cmdValueEx.Enabled = False ' ValueEx
            cmdMF5(5).Enabled = False 'Value
            cmdMF5(6).Enabled = False 'Write
        Else
            Select Case MF5x1.mfCurrentClassEx
                Case iCardTypeExConstants.MIFARE_ULTRALIGHT_CL2, iCardTypeExConstants.MIFARE_DESFIRE_CL2
                    cmdValueEx.Enabled = False
                    cmdMF5(5).Enabled = False   'Value
                Case Else
                    cmdValueEx.Enabled = cmbBlock.Enabled And m_bIsSupportTransfer
                    cmdMF5(5).Enabled = cmbBlock.Enabled    'Value
            End Select
            cmdMF5(6).Enabled = cmbBlock.Enabled        'Write
        End If
    End Sub

    Private Sub cmbBlock_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbBlock.SelectedIndexChanged
        CheckWritable()
    End Sub

    Private Sub cmbSector_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbSector.SelectedIndexChanged
        EnableAccess(False)
        If cmbSector.SelectedIndex < 32 Then
            SetMaxBlock(4) ' MIFARE 1K
        Else
            SetMaxBlock(16) ' MIFARE 4K after sector 32
        End If
    End Sub

    Private Function IdentificationDevices() As Boolean
        Dim bIsFound As Boolean
        Dim dblVersion As Double
        m_iSupportSaveKeyCount = 16

        m_szVersion = MF5x1.GetVersion ' Get RWD version for make sure are AC906
        m_szROMType = VB.Left(m_szVersion, InStr(1, m_szVersion & " ", " ", CompareMethod.Text) - 1)
        dblVersion = Val(Mid(m_szVersion, InStr(1, m_szVersion, "V", CompareMethod.Text) + 1))
        dblVersion = dblVersion + Val(Mid(m_szVersion, InStr(1, m_szVersion, "R", CompareMethod.Text) + 1)) / 100000.0#

        bIsFound = True
        Select Case m_szROMType
            Case "PGM0488", "PGM-T0488"     ' AC906
                m_szModuleName = "AC906"

            Case "PGM0487", "PGM-T0487"     ' PCR310/PRW106/MFR350
                m_szModuleName = "PCR310/PRW106/MFR350"
                If dblVersion >= 1.30006 Then
                    m_bIsSupportTransfer = True
                End If

            Case "PGM0494", "PGM-T0494"     ' RWD906
                m_szModuleName = "RWD906-00"

            Case "PGM0517", "PGM-T0517"     ' RWD906-UT
                m_szModuleName = "RWD906-UT"

            Case "PGM0499", "PGM-T0499"     ' MF5
                m_szModuleName = "MF5"
                If dblVersion >= 1.3 Then
                    m_bIsSupportTransfer = True
                End If

            Case "PGM-T0748"                ' DF5
                m_szModuleName = "DF5"
                m_bIsSupportTransfer = True

            Case "PGM-T0985"                ' MF6
                m_szModuleName = "MF6"
                m_bIsSupportTransfer = True

            Case "PGM-T0811"                ' MF10 with baudrate 57600
                m_szModuleName = "MF10"

            Case "ROM-T0636"                ' MF5 with baudrate 9600
                m_szModuleName = "MF5-01 (ODM)"

            Case "PGM-T0668"
                m_szModuleName = "MF5-02 (ODM)"

            Case "PGM-T0593"                ' PCR216
                m_szModuleName = "PCR216"

            Case "PGM-T0583"                ' MF700-00
                m_szModuleName = "MF700-00"
                m_bDisableAutoMode = True

            Case "PGM-T0604", "PGM-T0724", "PGM-T1023", "PGM-T1000" ' MF700-10
                m_szModuleName = "MF700-10"
                m_bDisableAutoMode = True

            Case "PGM-T0633"                ' MF700-30
                m_szModuleName = "MF700-30"
                m_bDisableAutoMode = True

            Case "PGM-T0605"                ' RWD145-00
                m_szModuleName = "RWD145-00"

            Case "PGM-T0829"                ' MF700-AB
                m_szModuleName = "MF700-AB"
                If dblVersion >= 1.000002 Then
                    m_bIsSupportTransfer = True
                End If

            Case "PGM-T0830"                ' MF12-00
                m_szModuleName = "MF12-00"

            Case "PGM-T1039"                ' MF12-01
                m_szModuleName = "MF12-01"

            Case "PGM-T0843"                ' MF700-DK
                m_szModuleName = "MF700-DK"

            Case "PGM-T0987"                ' MF700-STF
                m_szModuleName = "MF700-STF"
                m_bIsSupportTransfer = True
                m_bDisableAutoMode = True

            Case "PGM-T0995"                ' RF30
                m_szModuleName = "RF30"
                m_bIsSupportTransfer = True

            Case "PGM-T0985"                ' MF6
                m_szModuleName = "MF6"
                m_bIsSupportTransfer = True

            Case "PGM-T0999"                ' DF700
                m_szModuleName = "DF700"
                m_bIsSupportTransfer = True

            Case "PGM-T1030", "PGM-T1031"   ' DF750
                m_szModuleName = "DF750"
                m_bIsSupportTransfer = True

            Case "PGM-T1074"                ' MF5-AU56
                m_szModuleName = "MF5-AU56"
                m_bIsSupportTransfer = True

            Case "PGM-T1100"                ' PCR320
                m_szModuleName = "PCR320"
                m_bIsSupportTransfer = True
                If dblVersion >= 1.2 Then
                    m_iSupportSaveKeyCount = 40
                End If

            Case "PGM-T1186"                ' DF20
                m_szModuleName = "DF20"
                m_bIsSupportTransfer = True
                m_iSupportSaveKeyCount = 0
                If dblVersion >= 1.2 Then
                    m_iSupportSaveKeyCount = 40
                End If

            Case "PGM-T1142"                 ' MF700-36
                m_szModuleName = "MF700-36"
                m_bDisableAutoMode = True

            Case "PGM-T1235"                ' MF20
                m_szModuleName = "MF20"
                m_bIsSupportTransfer = True
                If dblVersion >= 1.1 Then
                    m_iSupportSaveKeyCount = 40
                End If

            Case "PGM1383", "PGM-T1383"     ' Like the PCR310 with Card Serial Number by little endian
                m_szModuleName = "PCR310-ACU"
                m_bIsSupportTransfer = True

            Case "PGM-T1242"                ' PCR320-19K (DF750-PT)
                m_szModuleName = "DF750-PT"
                m_bIsSupportTransfer = True
                m_bDisableAutoMode = True
                bIsFound = True

            Case Else
                bIsFound = False
        End Select
        Return bIsFound
    End Function

    Private Function MoveArrayItemToHead(ByRef szSrcArray() As String, ByVal szItem As String) As Boolean
        Dim bResult As Boolean
        Dim I As Integer
        Dim J As Integer
        If szSrcArray IsNot Nothing AndAlso szItem IsNot Nothing AndAlso Len(szItem) > 0 Then
            For I = 0 To UBound(szSrcArray)
                If szSrcArray(I) = szItem Then
                    For J = I To 1 Step -1
                        szSrcArray(J) = szSrcArray(J - 1)
                    Next J
                    szSrcArray(J) = szItem
                    bResult = True
                End If
            Next I
        End If
        Return bResult
    End Function

    Private Sub cmdAutoScan_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAutoScan.Click
        Dim I As Integer
        Dim nEvent As Short
        Dim iSettingsIndex As Integer
        Dim szSettingsList() As String
        Dim iCount As Integer
        Dim szPorts() As String
        Dim bIsFound As Boolean
        Dim iCurBaudrate As Integer

        cmdAutoScan.Enabled = False
        m_bIsDeviceScaning = True

        m_bDisableAutoMode = False

        If cboPorts.SelectedIndex <= 0 Then
            With MF5x1
                iCount = .NumOfPorts
                ReDim szPorts(0 To (iCount - 1))
                For I = 0 To (iCount - 1)
                    szPorts(I) = .EnumCommPort(I)
                Next I
            End With
            MoveArrayItemToHead(szPorts, m_szLastCommPort)
        Else
            ReDim szPorts(0 To 0)
            szPorts(0) = cboPorts.SelectedItem
        End If

        If cboBaudrates.SelectedIndex <= 0 Then
            szSettingsList = Split("19200,N,8,1;38400,N,8,1;9600,N,8,1;57600,N,8,1;115200,N,8,1", ";")
            MoveArrayItemToHead(szSettingsList, m_szLastPortSettings)
        Else
            ReDim szSettingsList(0 To 0)
            szSettingsList(0) = cboBaudrates.SelectedItem & ",N,8,1"
        End If

        ' Clear all status label
        ResetStatus()
        Call OnMfError()

        ' Disable Command Box
        cmdMF5(0).Enabled = False
        txtBlock.Text = vbNullString
        labVersion.Visible = False

        If MF5x1.PortOpen Then
            MF5x1.PortOpen = False
            System.Threading.Thread.Sleep(100)
        End If

        ' Show Version
        Me.Text = m_szCaption
        bIsFound = False
        m_iSupportSaveKeyCount = 16
        For I = 0 To UBound(szPorts) ' Loop by Comm Port
            If Len(szPorts(I)) > 0 Then
                With MF5x1
                    If .PortOpen Then
                        .PortOpen = False
                        System.Threading.Thread.Sleep(150)
                    End If
                    .PortName = szPorts(I)
                    For iSettingsIndex = 0 To UBound(szSettingsList) ' Loop by Baudrate
                        If .PortOpen Then
                            .PortOpen = False
                            System.Threading.Thread.Sleep(150)
                        End If
                        .Settings = szSettingsList(iSettingsIndex)
                        .PortOpen = True
                        If .PortOpen Then
                            nEvent = .Polling(0) ' Addr=0 (Broadcast)
                            If nEvent <> -1 Then
                                bIsFound = IdentificationDevices()
                            End If
                        End If
                        If bIsFound Then
                            m_szLastCommPort = .PortName
                            m_szLastPortSettings = .Settings
                            Exit For
                        End If
                    Next iSettingsIndex
                End With
            End If
            If bIsFound Then
                Exit For
            End If
            MF5x1.PortOpen = False
        Next I
        If bIsFound Then
            With MF5x1
                If m_bDisableAutoMode Then
                    'Disable Auto Mode
                    .mfAutoMode(False)
                Else
                    .mfAutoMode()
                End If
            End With

            cmdMF5(0).Enabled = True
            labVersion.Visible = True
			I = InStr(1, m_szLastPortSettings, ",")
			If I > 0 Then
                iCurBaudrate = Val(VB.Left(m_szLastPortSettings, (I - 1)))
			Else 
                iCurBaudrate = Val(m_szLastPortSettings)
			End If
            If iCurBaudrate = 19200 Then
                labVersion.Text = "Reader Version: " & m_szVersion
                Me.Text = m_szCaption & " - Mifare Reader On COM" & MF5x1.CommPort
            Else
                labVersion.Text = "Reader(" & iCurBaudrate & " bps) Version: " & m_szVersion
                Me.Text = m_szCaption & " - Mifare Reader On COM" & MF5x1.CommPort
            End If
            cmdMF5(7).Enabled = True
            cmdMF5(9).Enabled = CBool(m_iSupportSaveKeyCount > 0)
        Else
            MsgBox("No RWD on serial prot!!", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation)
        End If
        m_bIsDeviceScaning = False
        cmdAutoScan.Enabled = True
    End Sub

    Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Public Sub cmdMF5_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMF5.Click
        Dim Index As Short = cmdMF5.GetIndex(eventSender)
        Dim bIsExecutingCommand As Boolean
        On Error GoTo Err_Proc
        bIsExecutingCommand = m_bIsExecutingCommand
        If m_bIsExecutingCommand = False Then
            Select Case Index
                Case 5, 8, 9 ' Value, Condition, Save Key
                Case Else
                    m_bIsExecutingCommand = True
            End Select
            ExecutingCommand(Index)
        End If
Err_Exit:
        m_bIsExecutingCommand = bIsExecutingCommand
        Exit Sub

Err_Proc:
        Debug.Print("cmdMF5_Click(" & Index & ") - " & Err.Description & "(" & Err.Number & ")")
        Resume Err_Exit
    End Sub

    Private Sub ExecutingCommand(ByVal Index As Short)
        Dim nResult As Short
        Dim bResult As Boolean
        Dim sResult As String
        Dim BlkNum As Short
        Dim bBuffer() As Byte
        Dim szKey As String
        Dim bIsCancelEnter As Boolean
        Dim bIsUseSaveKey As Boolean

        BlkNum = cmbBlock.SelectedIndex

        Select Case Index
            Case 0 ' Request ---------------------------
                ResetStatus() ' Clear all status label
                Call OnMfError()

                nResult = MF5x1.mfRequest ' Answer & Request, return card class
                If nResult > 0 Then
                    labMF5(0).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(2))
                    labMF5(0).Text = "ATQA: 0x" & nResult.ToString("X").PadLeft(4, "0"c)
                    cmdMF5(1).Enabled = True
                Else
                    labMF5(0).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(12))
                    labMF5(0).Text = MF5x1.GNetErrorCodeStr
                End If

            Case 1 ' Anticollision-----------------------
                If MF5x1.mfAnticollision(m_szCardSN) Then
                    labMF5(1).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(2))
                    If MF5x1.mfIsNextAnticollision Then
                        labMF5(1).Text = VB.Left(m_szCardSN.PadLeft(8, "0"), 6)
                    Else
                        labMF5(1).Text = m_szCardSN
                    End If
                    cmdMF5(2).Enabled = True
                Else
                    labMF5(1).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(12))
                    labMF5(1).Text = MF5x1.GNetErrorCodeStr
                    Call OnMfError()
                End If

            Case 2 ' Select Card-------------------------
                nResult = MF5x1.mfSelectCard(m_szCardSN)

                If nResult <> -1 Then
                    labMF5(2).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(2))
                    labMF5(2).Text = "SAK: 0x" & nResult.ToString("X").PadLeft(2, "0"c)
                    labCardType.Text = MF5x1.mfCurrentClassStr
                    cmdMF5(3).Enabled = True
                    cmbSector.Enabled = True
                    optKEY(0).Enabled = True
                    optKEY(1).Enabled = True
                    ' Check Card Type
                    If MF5x1.mfIsNextAnticollision Then
                        labMF5(1).Text = MF5x1.mfAnticollision2.ToString("X").PadLeft(6, "0") & m_szCardSN.PadLeft(8, "0")
                    End If

                    Select Case MF5x1.mfCurrentClassEx
                        Case iCardTypeExConstants.MIFARE_ULTRALIGHT_CL2
                            SetMaxBlock(16) ' 16 page
                            SetMaxSector(0)
                            EnableAccess(True)

                        Case iCardTypeExConstants.MIFARE_1K_CL1, iCardTypeExConstants.MIFARE_1K_CL1_UID7, _
                                iCardTypeExConstants.MIFARE_PRO_1K_CL1, iCardTypeExConstants.MIFARE_PRO_1K_CL2_UID7
                            'SetMaxBlock 4
                            SetMaxSector(16) ' Max 16 Sector

                        Case iCardTypeExConstants.MIFARE_4K_CL1, iCardTypeExConstants.MIFARE_4K_CL1_UID7, _
                                iCardTypeExConstants.MIFARE_PRO_4K_CL1, iCardTypeExConstants.MIFARE_PRO_4K_CL2_UID7
                            'SetMaxBlock 4
                            SetMaxSector(40) ' Max 40 Sector

                        Case Else
                            SetMaxSector(0)
                            cmdMF5(3).Enabled = False
                    End Select

                Else
                    labMF5(2).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(12))
                    labMF5(2).Text = MF5x1.GNetErrorCodeStr
                    Call OnMfError()
                End If

            Case 3 ' Authenticate, using EEPROM key
                bIsUseSaveKey = False
                If cmbSector.SelectedIndex < m_iSupportSaveKeyCount Then
                    bIsUseSaveKey = True
                End If
                If bIsUseSaveKey Then
                    szKey = vbNullString 'Authenticate Key by Save Key
                Else
                    szKey = "FFFFFFFFFFFF" ' Authenticate with New Card Key
                End If
                If optKEY(0).Checked Then
                    bResult = MF5x1.mfAuthenticate(cmbSector.SelectedIndex, bKeyTypeConstants.KEY_A, szKey)
                Else
                    bResult = MF5x1.mfAuthenticate(cmbSector.SelectedIndex, bKeyTypeConstants.KEY_B, szKey)
                End If
                If bResult = False Then
                    If bIsUseSaveKey = False Then
                        szKey = frmEnterKey.GetKey
                        If szKey = vbNullString Then
                            'No Enter any Key
                            bIsCancelEnter = True
                        Else
                            If optKEY(0).Checked Then
                                bResult = MF5x1.mfAuthenticate(cmbSector.SelectedIndex, bKeyTypeConstants.KEY_A, szKey)
                            Else
                                bResult = MF5x1.mfAuthenticate(cmbSector.SelectedIndex, bKeyTypeConstants.KEY_B, szKey)
                            End If
                        End If
                    End If
                End If
                If bIsCancelEnter = False Then
                    If bResult Then
                        labMF5(3).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(2))
                        labMF5(3).Text = "Pass"
                        EnableAccess(True) ' To enable read/write/value etc. button
                    Else
                        labMF5(3).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(12))
                        labMF5(3).Text = MF5x1.GNetErrorCodeStr
                        EnableAccess(False) ' To disable read/write/value etc. button
                        Call OnMfError()
                    End If
                End If

            Case 4 ' Read Block Data, using Hex String
                bResult = False
                ReDim bBuffer(0 To 15)
                If MF5x1.mfRead(BlkNum, bBuffer) Then
                    sResult = modMifare.BytesToHex(bBuffer)
                    bResult = True
                    If MF5x1.mfCurrentClassEx = iCardTypeExConstants.MIFARE_ULTRALIGHT_CL2 Then
                        txtBlock.Text = Mid(sResult, 1, 8)
                    Else
                        txtBlock.Text = sResult
                    End If
                End If

                If Len(txtBlock.Text) > 0 And bResult Then
                    labMF5(6).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(2))
                    labMF5(6).Text = "Ok"
                Else
                    labMF5(6).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(12))
                    labMF5(6).Text = MF5x1.GNetErrorCodeStr
                    Call OnMfError()
                End If

            Case 6 ' Write Block Data, using Hex String

                bBuffer = modMifare.HexToBytes(txtBlock.Text)
                If MF5x1.mfWrite(BlkNum, bBuffer) Then
                    labMF5(4).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(2))
                    labMF5(4).Text = "Ok"
                Else
                    labMF5(4).ForeColor = System.Drawing.ColorTranslator.FromOle(QBColor(12))
                    labMF5(4).Text = MF5x1.GNetErrorCodeStr
                    Call OnMfError()
                End If

            Case 7 ' Halt ----------------------------
                MF5x1.mfHalt()
                EnableAccess(False)
                ResetStatus()

                If m_bDisableAutoMode Then
                    'Disable Auto Mode
                    MF5x1.mfAutoMode(False)
                End If
            Case 5
                frmValue.ShowDialog(Me)
            Case 8
                frmAccess.ShowDialog(Me)
            Case 9
                frmSaveKey.ShowSaveKey(MF5x1, cmbSector.SelectedIndex, m_iSupportSaveKeyCount)
        End Select
    End Sub

    Private Sub cmdValueEx_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdValueEx.Click
        frmValueEx.ShowValueOpt(MF5x1, cmbBlock, cmbSector.SelectedIndex)
    End Sub

    Private Sub ReListComboBox(ByRef oComboBox As ComboBox, ByVal szItemList As String, ByVal szDefault As String, Optional ByVal szDelimiter As String = ";")
        Dim szList() As String
        Dim szSelItem As String
        Dim I As Integer
        Dim iSelItem As Integer
        szList = Split(szItemList, szDelimiter)
        With oComboBox
            If .SelectedIndex = -1 Then
                szSelItem = szDefault
            Else
                szSelItem = .SelectedItem
            End If
            iSelItem = -1
            With .Items
                .Clear()
                For I = 0 To UBound(szList)
                    If szList(I) = szSelItem Then
                        iSelItem = .Add(szList(I))
                    Else
                        .Add(szList(I))
                    End If
                Next I
            End With
            If iSelItem = -1 AndAlso .Items.Count > 0 Then
                iSelItem = 0
            End If
            .SelectedIndex = iSelItem
        End With
    End Sub

    Private Sub frmMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim I As Integer
        Dim szData As String
        ' select last time comm port
        On Error Resume Next
        m_szLastCommPort = GetSetting(My.Application.Info.Title, "COMM", "LastCommPort", m_szLastCommPort)
        m_szLastPortSettings = GetSetting(My.Application.Info.Title, "COMM", "LastPortSettings", m_szLastPortSettings)
        MF5x1.CommPort = CShort(GetSetting(My.Application.Info.Title, "COMM", "PORT", CStr(1)))

        I = InStr(m_szLastPortSettings, ",")
        If I > 0 Then
            szData = VB.Left(m_szLastPortSettings, I - 1)
        Else
            szData = "19200"
        End If
        ReListComboBox(cboBaudrates, "Auto;9600;19200;38400;57600;115200", szData)

        szData = "Auto"
        With MF5x1
            For I = 0 To (.NumOfPorts - 1)
                szData = szData & ";" & .EnumCommPort(I)
            Next I
        End With
        ReListComboBox(cboPorts, szData, m_szLastCommPort)

        ' show version
        With My.Application.Info.Version
            m_szCaption = Me.Text & " V" & .Major & "." & .Minor & "R" & .Revision
        End With
        Me.Text = m_szCaption

        cmbSector.SelectedIndex = 0
        cmbBlock.SelectedIndex = 0

        modMifare.LoadFormPosision(Me)
        m_bNoChangeEvent = False
        m_iSupportSaveKeyCount = 16
    End Sub

    Private Sub frmMain_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim oform As System.Windows.Forms.Form

        SaveSetting(My.Application.Info.Title, "COMM", "PORT", CStr(MF5x1.CommPort))
        SaveSetting(My.Application.Info.Title, "COMM", "LastCommPort", m_szLastCommPort)
        SaveSetting(My.Application.Info.Title, "COMM", "LastPortSettings", m_szLastPortSettings)

        modMifare.SaveFormPosision(Me)

        For Each oform In My.Application.OpenForms
            Try
                oform.Close()
                oform.Dispose()
            Catch ex As Exception

            End Try
        Next oform
    End Sub

    Private Sub Text1_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text1.DoubleClick
        Text1.Text = vbNullString
    End Sub

    Private Sub txtASCBlock_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtASCBlock.TextChanged
        If m_bNoChangeEvent = False Then
            m_bNoChangeEvent = True
            With txtBlock
                .Text = VB.Left(modMifare.StringToHex(txtASCBlock.Text) & New String("0", .MaxLength), .MaxLength)
            End With
            m_bNoChangeEvent = False
        End If
    End Sub

    Private Sub txtASCBlock_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtASCBlock.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim lLen As Integer
        With txtASCBlock
            lLen = modMifare.LenX(.Text)
            Select Case KeyAscii
                Case 0 To 31 'ASCII Control Char
                Case 32 To 255 'ASCII
                    lLen = lLen + 1
                Case Else 'DBCS
                    lLen = lLen + 2
            End Select
            If (lLen - .SelectionLength) > .MaxLength Then
                KeyAscii = 0
            End If
        End With
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtBlock_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBlock.TextChanged
        If m_bNoChangeEvent = False Then
            m_bNoChangeEvent = True
            txtASCBlock.Text = modMifare.HexToString(txtBlock.Text)
            m_bNoChangeEvent = False
        End If
    End Sub

    Private Sub txtBlock_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtBlock.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Select Case KeyAscii
            Case Is < 32
            Case &H30S To &H39S, &H41S To &H46S '0~9,A~F
            Case &H61S To &H66S 'a~f
                KeyAscii = KeyAscii - 32
            Case Else
                KeyAscii = 0
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Public Sub ShowMsg(ByVal szData As String, Optional ByVal bNewLine As Boolean = True)
        Dim L As Integer, iLen As Integer
        Dim szTemp As String
        With Text1
            szTemp = .Text
            iLen = Len(szTemp)
            If Not (iLen = 0 AndAlso szData = vbCrLf) Then
                .SelectionStart = iLen
                If bNewLine AndAlso VB.Right(szTemp, 2) <> vbCrLf AndAlso iLen > 0 Then
                    .SelectedText = vbCrLf
                ElseIf m_bIsShowCR Then
                    .SelectedText = vbCrLf
                    m_bIsShowCR = False
                End If
                .SelectedText = szData
                If bNewLine Then
                    .SelectedText = vbCrLf
                End If
                szTemp = .Text
                If Len(szTemp) > 5210 Then
                    L = InStr(2048, szTemp, vbCrLf, CompareMethod.Text)
                    If L <= 0 Then L = 2048
                    szTemp = Mid(szTemp, L)
                    .Text = szTemp
                    .SelectionStart = Len(szTemp)
                End If
            End If
        End With
    End Sub

    Private Function GetASCIIName(ByVal bChar As Byte) As String
        Dim szResult As String
        szResult = vbNullString
        Select Case bChar
            Case 0 : szResult = "NUL"
            Case 1 : szResult = "SOH"
            Case 2 : szResult = "STX"
            Case 3 : szResult = "ETX"
            Case 4 : szResult = "EOT"
            Case 5 : szResult = "ENQ"
            Case 6 : szResult = "ACK"
            Case 7 : szResult = "BEL"
            Case 8 : szResult = "BS"
            Case 9 : szResult = "TAB"
            Case 10 : szResult = "LF"
            Case 11 : szResult = "VT"
            Case 12 : szResult = "FF"
            Case 13 : szResult = "CR"
            Case 14 : szResult = "SO"
            Case 15 : szResult = "SI"
            Case 16 : szResult = "DLE"
            Case 17 : szResult = "DC1"
            Case 18 : szResult = "DC2"
            Case 19 : szResult = "DC3"
            Case 20 : szResult = "DC4"
            Case 21 : szResult = "NAK"
            Case 22 : szResult = "SYN"
            Case 23 : szResult = "ETB"
            Case 24 : szResult = "CAN"
            Case 25 : szResult = "EM"
            Case 26 : szResult = "SUB"
            Case 27 : szResult = "ESC"
            Case 28 : szResult = "FS"
            Case 29 : szResult = "GS"
            Case 30 : szResult = "RS"
            Case 31 : szResult = "US"
            Case 32 : szResult = "(SP)"
            Case 128 To 254
                szResult = "0x" & VB.Right(VB.Hex(&H0 + bChar), 2)
            Case Is < 128
                szResult = VB.Chr(bChar)
            Case Else
                szResult = vbNullString
        End Select
        Return szResult
    End Function

    Private Sub MF5x1_OnComm() Handles MF5x1.OnComm
        Dim bBuffer() As Byte
        Dim I As Integer
        Dim bIsEventMode As Boolean
        If MF5x1.CommEvent = CommEventConstants.comEvReceive Then
            bBuffer = MF5x1.Input
            If m_bIsDeviceScaning = False AndAlso bBuffer IsNot Nothing Then
                If optEventMode(0).Checked Then
                    bIsEventMode = True
                End If
                For I = 0 To UBound(bBuffer)
                    If bIsEventMode Then
                        Select Case bBuffer(I)
                            Case 3  ' ETX
                                If m_bIsGNetEvent Then
                                    m_bIsGNetEvent = False
                                    m_bIsShowCR = False
                                    ShowMsg("<" & GetASCIIName(bBuffer(I)) & ">", False)
                                    ShowMsg(vbCrLf, False)
                                Else
                                    ShowMsg("<" & GetASCIIName(bBuffer(I)) & ">", False)
                                End If
                            Case 13 ' CR
                                ShowMsg("<" & GetASCIIName(bBuffer(I)) & ">", False)
                                m_bIsShowCR = True
                            Case 10 ' LF
                                If m_bIsShowCR Then
                                    m_bIsShowCR = False
                                    ShowMsg("<" & GetASCIIName(bBuffer(I)) & ">", False)
                                    ShowMsg(vbCrLf, False)
                                Else
                                    ShowMsg("<" & GetASCIIName(bBuffer(I)) & ">", False)
                                End If
                            Case 33 To 127
                                ShowMsg(VB.Chr(bBuffer(I)), False)
                            Case Else
                                ShowMsg("<" & GetASCIIName(bBuffer(I)) & ">", False)
                        End Select
                    Else
                        Select Case bBuffer(I)
                            Case 2  ' STX
                                ShowMsg(vbCrLf, False)
                                ShowMsg(VB.Right(Hex(&H100S + bBuffer(I)), 2) & " ", False)
                            Case 3  ' ETX
                                If m_bIsShowCR Then
                                    m_bIsShowCR = False
                                    ShowMsg(VB.Right(Hex(&H100S + bBuffer(I)), 2) & " ", False)
                                    ShowMsg(vbCrLf, False)
                                Else
                                    ShowMsg(VB.Right(Hex(&H100S + bBuffer(I)), 2) & " ", False)
                                End If
                            Case 13 ' CR
                                ShowMsg(VB.Right(Hex(&H100S + bBuffer(I)), 2) & " ", False)
                                m_bIsShowCR = True
                            Case 10 ' LF
                                If m_bIsShowCR Then
                                    m_bIsShowCR = False
                                    ShowMsg(VB.Right(Hex(&H100S + bBuffer(I)), 2) & " ", False)
                                    m_bIsShowCR = True
                                Else
                                    ShowMsg(VB.Right(Hex(&H100S + bBuffer(I)), 2) & " ", False)
                                End If
                            Case Else
                                ShowMsg(VB.Right(Hex(&H100S + bBuffer(I)), 2) & " ", False)
                        End Select
                    End If
                Next I
            End If
        End If
    End Sub

    Private Sub MF5x1_OnGNetEvent(ByVal szEvent As String) Handles MF5x1.OnGNetEvent
        ShowMsg(vbCrLf, False)
        ShowMsg("<STX>" & VB.Replace(szEvent, VB.Chr(3), "<ETX>") & "<CR>", False)
        m_bIsShowCR = True
        m_bIsGNetEvent = True
    End Sub

    Private Sub MF5x1_OnGNetPlus(ByVal iEvent As Integer) Handles MF5x1.OnGNetPlus
        Select Case iEvent
            Case 33 To 127
                ShowMsg("OnGNetPlus - Code:=0x" & VB.Hex(iEvent) & "(" & VB.Chr(iEvent) & ")")
            Case Else
                ShowMsg("OnGNetPlus - Code:=0x" & VB.Hex(iEvent))
        End Select
    End Sub

    Private Sub MF5x1_OnPort(ByVal iAction As GIGATMS.NF.GNetPlus.CommPortEventConstants, ByVal CommPort As String) Handles MF5x1.OnPort
        Dim iFindItem As Integer
        Dim iSelItem As Integer
        With cboPorts
            iFindItem = .FindString(CommPort)
            Select Case iAction
                Case CommPortEventConstants.comEvPlugin
                    If iFindItem = NO_ITEM Then
                        iFindItem = .Items.Add(CommPort)
                    End If

                    iSelItem = NO_ITEM
                    With MF5x1
                        If .PortOpen Then
                            ShowMsg(CommPort & " Insert")
                        Else
                            .PortName = CommPort
                            .PortOpen = True
                            If .PortOpen Then
                                iSelItem = iFindItem
                                ShowMsg(CommPort & " Insert and Opened")
                            Else
                                ShowMsg(CommPort & " Insert")
                            End If
                        End If
                    End With
                    If iSelItem <> NO_ITEM Then
                        .SelectedIndex = iSelItem
                    End If

                Case CommPortEventConstants.comEvRemove, CommPortEventConstants.comEvRemoveClosed
                    If iFindItem <> NO_ITEM Then
                        .Items.RemoveAt(iFindItem)
                        If .SelectedIndex = -1 AndAlso .Items.Count > 0 Then
                            If iFindItem < .Items.Count Then
                                .SelectedIndex = iFindItem
                            Else
                                .SelectedIndex = .Items.Count - 1
                            End If
                        End If
                    End If
                    If iAction = CommPortEventConstants.comEvRemoveClosed Then
                        Me.Text = m_szCaption
                        ResetStatus() ' Clear all status label
                        Call OnMfError()
                        cmdMF5(7).Enabled = False
                        cmdMF5(9).Enabled = False
                        ShowMsg(CommPort & " Removed and Closed")
                    Else
                        ShowMsg(CommPort & " Removed")
                    End If
            End Select
        End With
    End Sub

    Private Sub MF5x1_OnReaderEvent(ByVal iReaderEvent As GIGATMS.NF.MifareReader.iReaderEventConstants) Handles MF5x1.OnReaderEvent
        Select Case iReaderEvent
            Case iReaderEventConstants.READER_CARD_PRESENT
                ShowMsg("Card Present")
            Case iReaderEventConstants.READER_CARD_REMOVE
                ShowMsg("Card Remove")
                ResetStatus() ' Clear all status label
                Call OnMfError()
            Case iReaderEventConstants.READER_KEY_PRESS
                ShowMsg("Hot-Key Press")
            Case iReaderEventConstants.READER_ON_IRQ
                ShowMsg("On IRQ")
        End Select
    End Sub

    Private Sub optEventMode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optEventMode.Click
        Dim Index As Short = optEventMode.GetIndex(sender)
        If Index = 1 Then
            MF5x1.GNetEvent = GNetEventConstants.GNetEvent_GNetPlus
        Else
            MF5x1.GNetEvent = GNetEventConstants.GNetEvent_Both
        End If
    End Sub
End Class