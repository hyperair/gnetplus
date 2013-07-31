Option Strict Off
Option Explicit On

Imports VB = Microsoft.VisualBasic

Module modMifare
    Structure MFRecord
        Dim Id As Integer
        Dim dt As Date
        Dim Action As Short
        Dim Reserve As Integer
        Dim Value1 As Integer
        Dim Value2 As Integer
    End Structure

    Public Function LenX(ByRef szData As String) As Integer
        Dim I, lLen As Integer
        lLen = 0
        For I = 1 To Len(szData)
            Select Case Asc(Mid(szData, I, 1))
                Case 0 To 255 'ASCII
                    lLen = lLen + 1
                Case Else 'DBCS
                    lLen = lLen + 2
            End Select
        Next I
        LenX = lLen
    End Function

    Public Function HexToBytes(ByVal szHex As String) As Byte()
        Dim bData() As Byte
        Dim L As Integer
        Dim I As Integer
        L = Len(szHex)
        ReDim bData((Int(L / 2 + 0.5) - 1))
        For I = 1 To L Step 2
            bData((I - 1) / 2) = Val("&H" & Mid(szHex, I, 2))
        Next I
        HexToBytes = VB6.CopyArray(bData)
    End Function

    Public Function HexToString(ByVal szHex As String) As String
        Dim bData() As Byte
        Dim L As Integer
        Dim I As Integer
        Dim oBuffer As New System.Text.StringBuilder
        L = Len(szHex)
        ReDim bData((Int(L / 2 + 0.5) - 1))
        For I = 1 To L Step 2
            Try
                oBuffer.Append(Chr(CInt("&H" & Mid(szHex, I, 2))))
            Catch ex As Exception

            End Try
        Next I
        HexToString = oBuffer.ToString()
    End Function

    Public Function BytesToHex(ByRef bData() As Byte) As String
        Dim I As Integer
        Dim oBuffer As New System.Text.StringBuilder
        For I = LBound(bData) To UBound(bData)
            Try
                oBuffer.Append(Right(Hex(&H100S + bData(I)), 2))
            Catch ex As Exception

            End Try
        Next I
        BytesToHex = oBuffer.ToString()
    End Function

    Public Function StringToHex(ByVal szData As String) As String
        Dim I As Integer, iLen As Integer
        Dim oBuffer As New System.Text.StringBuilder
        iLen = Len(szData)
        For I = 1 To iLen
            Try
                oBuffer.Append(VB.Right(Hex$(&H100 + Asc(Mid(szData, I, 1))), 2))
            Catch ex As Exception

            End Try
        Next I
        Return oBuffer.ToString()
    End Function

    Public Sub PushToByteArray(ByVal iValue As Integer, ByRef bBuffer() As Byte, ByRef iStart As Integer, Optional ByVal bIsMSBFirst As Boolean = False)
        Dim I As Integer
        Dim iBegin As Integer, iEnd As Integer, iStep As Integer
        If bIsMSBFirst Then
            iBegin = iStart + 3
            iEnd = iStart
            iStep = -1
        Else
            iBegin = iStart
            iEnd = iStart + 3
            iStep = 1
        End If
        Try
            For I = iBegin To iEnd Step iStep
                bBuffer(I) = CByte(iValue And &HFF%)
                iValue = (iValue >> 8)
            Next I
            iStart += 4
        Catch ex As Exception

        End Try
    End Sub

    Public Sub PushToByteArray(ByVal nValue As Short, ByRef bBuffer() As Byte, ByRef iStart As Integer, Optional ByVal bIsMSBFirst As Boolean = False)
        Dim I As Integer
        Dim iBegin As Integer, iEnd As Integer, iStep As Integer
        If bIsMSBFirst Then
            iBegin = iStart + 1
            iEnd = iStart
            iStep = -1
        Else
            iBegin = iStart
            iEnd = iStart + 1
            iStep = 1
        End If
        Try
            For I = iBegin To iEnd Step iStep
                bBuffer(I) = CByte(nValue And CShort(&HFF))
                nValue = (nValue >> 8)
            Next I
            iStart += 2
        Catch ex As Exception

        End Try
    End Sub

    Public Sub LoadFormPosision(ByRef oForm As System.Windows.Forms.Form)
        Dim iTop As Integer
        Dim iLeft As Integer
        Dim szName As String
        szName = oForm.Name
        With My.Application.Info
            iTop = CInt(GetSetting(.Title, szName, "Top", CStr(oForm.Top)))
            iLeft = CInt(GetSetting(.Title, szName, "Left", CStr(oForm.Left)))
        End With
        Select Case iTop
            Case 0 To System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
            Case Else
                iTop = oForm.Top
        End Select
        Select Case iLeft
            Case 0 To System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
            Case Else
                iLeft = oForm.Left
        End Select
        oForm.Top = iTop
        oForm.Left = iLeft
    End Sub

    Public Sub SaveFormPosision(ByRef oForm As System.Windows.Forms.Form)
        Dim szName As String
        szName = oForm.Name
        With My.Application.Info
            SaveSetting(.Title, szName, "Top", CStr(oForm.Top))
            SaveSetting(.Title, szName, "Left", CStr(oForm.Left))
        End With
    End Sub
End Module