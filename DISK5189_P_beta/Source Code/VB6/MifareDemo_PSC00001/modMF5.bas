Attribute VB_Name = "modMF5"
Option Explicit

Private Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (Destination As Any, Source As Any, ByVal Length As Long)

Public Function LenX(ByRef szData As String) As Long
    Dim I As Long, lLen As Long
    lLen = 0
    For I = 1 To Len(szData)
        Select Case Asc(Mid$(szData, I, 1))
        Case 0 To 255   'ASCII
            lLen = lLen + 1
        Case Else       'DBCS
            lLen = lLen + 2
        End Select
    Next I
    LenX = lLen
End Function

Public Function HexToBytes(ByVal szHex As String) As Byte()
    Dim bData() As Byte, L As Long
    Dim I As Long
    L = Len(szHex)
    ReDim bData(0 To (Int(L / 2 + 0.5) - 1))
    For I = 1 To L Step 2
        bData(((I - 1) / 2)) = Val("&H" & Mid(szHex, I, 2))
    Next I
    HexToBytes = bData
End Function

Public Function HexToString(ByVal szHex As String) As String
    Dim bData() As Byte, lLen As Long, szData As String
    On Error GoTo Error_Proc
    If szHex <> vbNullString Then
        bData = HexToBytes(szHex)
        lLen = UBound(bData) - LBound(bData) + 1
        szData = String$(lLen, 0)
        CopyMemory ByVal szData, bData(LBound(bData)), lLen
    End If
Error_Exit:
    HexToString = szData
    Exit Function
Error_Proc:
    szData = vbNullString
    Resume Error_Exit
End Function

Public Function BytesToHex(ByRef bData() As Byte) As String
    Dim I As Long, szData As String
    On Error GoTo Error_Proc
    szData = vbNullString
    For I = LBound(bData) To UBound(bData)
        szData = szData & Right(Hex(&H100 + bData(I)), 2)
    Next I
Error_Exit:
    BytesToHex = szData
    Exit Function
Error_Proc:
    szData = vbNullString
    Resume Error_Exit
End Function

Public Function StringToHex(ByVal szData As String) As String
    Dim lLen As Long, bData() As Byte, szResult As String
    lLen = LenX(szData)
    If lLen > 0 Then
        ReDim bData(1 To lLen)
        CopyMemory bData(1), ByVal szData, lLen
        StringToHex = BytesToHex(bData)
    End If
End Function

