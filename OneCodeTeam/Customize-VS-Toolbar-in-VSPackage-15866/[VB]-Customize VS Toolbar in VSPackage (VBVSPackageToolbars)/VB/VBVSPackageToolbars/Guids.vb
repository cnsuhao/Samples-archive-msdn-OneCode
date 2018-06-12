Imports System

Class GuidList
    Private Sub New()
    End Sub

    Public Const guidVBVSPackageToolbarsPkgString As String = "63dd5d66-d98c-478f-94f1-0587cb7fa58c"
    Public Const guidVBVSPackageToolbarsCmdSetString As String = "d5e5d042-4c2b-497c-afef-32d493b8fa3f"

    Public Shared ReadOnly guidVBVSPackageToolbarsCmdSet As New Guid(guidVBVSPackageToolbarsCmdSetString)
End Class