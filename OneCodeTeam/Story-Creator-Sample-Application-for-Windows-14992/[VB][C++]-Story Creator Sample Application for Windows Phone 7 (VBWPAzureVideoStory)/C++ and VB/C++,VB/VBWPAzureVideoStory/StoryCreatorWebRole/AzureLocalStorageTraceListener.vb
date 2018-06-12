Imports System.IO
Imports Microsoft.WindowsAzure.Diagnostics
Imports Microsoft.WindowsAzure.ServiceRuntime

Public Class AzureLocalStorageTraceListener
    Inherits XmlWriterTraceListener

    Public Sub New()
        MyBase.New(Path.Combine(AzureLocalStorageTraceListener.GetLogDirectory().Path, "StoryCreatorWebRole.svclog"))
    End Sub

    ' Supress CA2122 as the code is automatically generated.
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")> _
    Public Shared Function GetLogDirectory() As DirectoryConfiguration
        Dim directory As New DirectoryConfiguration()
        directory.Container = "wad-tracefiles"
        directory.DirectoryQuotaInMB = 10
        directory.Path = RoleEnvironment.GetLocalResource("StoryCreatorWebRole.svclog").RootPath
        Return directory
    End Function
End Class
