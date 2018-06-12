Imports System


Class GuidList
    Private Sub New()
    End Sub

    Public Const guidVBVSPackageStatusBarPkgString As String = "514066c8-32d5-481c-984b-b096f591b13e"
    Public Const guidVBVSPackageStatusBarCmdSetString As String = "2fa6fbf0-ada8-4d30-bc42-bfd2c1e6d310"
    Public Const guidToolWindowPersistanceString As String = "c661d401-e11a-47f0-997c-f09e249cd873"

    Public Shared ReadOnly guidVBVSPackageStatusBarCmdSet As New Guid(guidVBVSPackageStatusBarCmdSetString)
End Class