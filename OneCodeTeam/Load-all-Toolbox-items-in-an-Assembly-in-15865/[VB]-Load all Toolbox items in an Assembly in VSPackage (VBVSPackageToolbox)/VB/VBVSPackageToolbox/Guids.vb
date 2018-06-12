Imports System

Class GuidList
    Private Sub New()
    End Sub

    Public Const guidVBVSPackageToolboxPkgString As String = "b6913c2a-6a38-4886-a029-a1ede1378dd4"
    Public Const guidVBVSPackageToolboxCmdSetString As String = "5b436182-3132-4201-b3be-ae4aee76d364"

    Public Shared ReadOnly guidVBVSPackageToolboxCmdSet As New Guid(guidVBVSPackageToolboxCmdSetString)
End Class