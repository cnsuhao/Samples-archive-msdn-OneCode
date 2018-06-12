Imports System

Class GuidList
    Private Sub New()
    End Sub

    Public Const guidVBVSPackagePkgString As String = "7c56b385-fb25-4cd4-aaf0-a7c585bbb72d"
    Public Const guidVBVSPackageCmdSetString As String = "87908fb1-3710-476b-af31-05a3dc2336b8"

    Public Shared ReadOnly guidVBVSPackageCmdSet As New Guid(guidVBVSPackageCmdSetString)
End Class