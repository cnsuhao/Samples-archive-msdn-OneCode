Imports System

Class GuidList
    Private Sub New()
    End Sub

    Public Const guidVBVSPackagePkgString As String = "cdd4670a-225e-4121-9360-5bc4cf49d939"
    Public Const guidVBVSPackageCmdSetString As String = "2327e324-8b73-4fb6-9ed3-f849b860930c"

    Public Shared ReadOnly guidVBVSPackageCmdSet As New Guid(guidVBVSPackageCmdSetString)
End Class