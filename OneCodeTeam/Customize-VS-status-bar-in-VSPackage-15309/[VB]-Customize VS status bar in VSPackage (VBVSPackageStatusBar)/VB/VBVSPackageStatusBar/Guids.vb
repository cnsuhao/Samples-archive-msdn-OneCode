Imports System

Class GuidList
    Private Sub New()
    End Sub

    Public Const guidVBVSPackageStatusBarPkgString As String = "49bc51bd-09e6-4213-be67-59347d6f8f82"
    Public Const guidVBVSPackageStatusBarCmdSetString As String = "c1c96173-f280-4921-a07b-2edcba7d65ce"
    Public Const guidToolWindowPersistanceString As String = "ba6bf6a9-e189-4e5e-9f99-74947ac79ae0"

    Public Shared ReadOnly guidVBVSPackageStatusBarCmdSet As New Guid(guidVBVSPackageStatusBarCmdSetString)
End Class