Imports System

Class GuidList
    Private Sub New()
    End Sub

    Public Const guidVBVSPackageOptionPageWithTypeConverterPkgString As String = "7976a25e-3a48-4130-a5dd-7e3b7ac7d731"
    Public Const guidVBVSPackageOptionPageWithTypeConverterCmdSetString As String = "3f9a7a41-7100-4f07-9597-68a2c5d70aba"

    Public Shared ReadOnly guidVBVSPackageOptionPageWithTypeConverterCmdSet As New Guid(guidVBVSPackageOptionPageWithTypeConverterCmdSetString)
End Class