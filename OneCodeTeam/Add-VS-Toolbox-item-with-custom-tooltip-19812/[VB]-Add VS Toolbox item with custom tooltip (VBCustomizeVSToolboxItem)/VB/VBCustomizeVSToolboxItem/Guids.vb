Imports System

Class GuidList
    Private Sub New()
    End Sub

    Public Const guidVBCustomizeVSToolboxItemPkgString As String = "d7994e5b-5e14-4502-8f44-a79d4fb63494"
    Public Const guidVBCustomizeVSToolboxItemCmdSetString As String = "af666b80-ad48-48bf-aeb6-5f1a81c88866"

    Public Shared ReadOnly guidVBCustomizeVSToolboxItemCmdSet As New Guid(guidVBCustomizeVSToolboxItemCmdSetString)
End Class