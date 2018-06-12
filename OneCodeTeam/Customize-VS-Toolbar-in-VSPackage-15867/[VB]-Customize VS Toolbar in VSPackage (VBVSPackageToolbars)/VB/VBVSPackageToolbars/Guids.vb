Imports System

Class GuidList
    Private Sub New()
    End Sub

    Public Const guidVBVSPackageToolbarsPkgString As String = "18c4d752-1d18-4673-a28d-89b926c85349"
    Public Const guidVBVSPackageToolbarsCmdSetString As String = "59f94698-45b5-442d-95e9-e9ee30569d34"

    Public Shared ReadOnly guidVBVSPackageToolbarsCmdSet As New Guid(guidVBVSPackageToolbarsCmdSetString)
End Class