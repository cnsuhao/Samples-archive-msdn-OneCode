Imports System

Class GuidList
    Private Sub New()
    End Sub

    Public Const guidVBVSToolWindowPkgString As String = "68da8729-2dd6-4fee-92fe-4c05c821bbb2"
    Public Const guidVBVSToolWindowCmdSetString As String = "f7932581-ece7-47e0-9881-3eddf2aa9664"
    Public Const guidToolWindowPersistanceString As String = "cda0c418-55c4-45de-8e85-4c54ab697179"

    Public Shared ReadOnly guidVBVSToolWindowCmdSet As New Guid(guidVBVSToolWindowCmdSetString)
End Class