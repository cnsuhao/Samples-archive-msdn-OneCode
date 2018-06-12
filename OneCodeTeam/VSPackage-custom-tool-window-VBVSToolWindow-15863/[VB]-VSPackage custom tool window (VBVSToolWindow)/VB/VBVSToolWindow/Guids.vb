Imports System

Class GuidList
    Private Sub New()
    End Sub

    Public Const guidVBVSToolWindowPkgString As String = "820b791b-405f-45f3-b685-e4923a1659f4"
    Public Const guidVBVSToolWindowCmdSetString As String = "86fb02c4-9a7c-4dd1-8f20-c5860c4a99e5"
    Public Const guidToolWindowPersistanceString As String = "b8e804e2-5525-4cfe-980e-c9a31c7c3cba"

    Public Shared ReadOnly guidVBVSToolWindowCmdSet As New Guid(guidVBVSToolWindowCmdSetString)
End Class