Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.Diagnostics
Imports Microsoft.WindowsAzure.ServiceRuntime
Imports Microsoft.Web.Administration

Public Class WebRole
    Inherits RoleEntryPoint

    Public Overrides Function OnStart() As Boolean
        ' For information on handling configuration changes
        ' see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

        ' Get the location of the AspNetTemp1GB resource     
        Dim aspNetTempFolder As Microsoft.WindowsAzure.ServiceRuntime.LocalResource = Microsoft.WindowsAzure.ServiceRuntime.RoleEnvironment.GetLocalResource("AspNetTemp1GB")

        ' Instantiate the IIS ServerManager     
        Dim iisManager As New ServerManager()

        ' Get the website.  Note that "_Web" is the name of the site in the ServiceDefinition.csdef, 
        ' so make sure you change this code if you change the site name in the .csdef     
        Dim app As Application = iisManager.Sites(RoleEnvironment.CurrentRoleInstance.Id + "_Web").Applications(0)

        ' Get the web.config for the site     
        Dim webHostConfig As Configuration = app.GetWebConfiguration()

        ' Get a reference to the system.web/compilation element     
        Dim compilationConfiguration As ConfigurationSection = webHostConfig.GetSection("system.web/compilation")

        ' Set the tempDirectory property to the AspNetTemp1GB folder     
        compilationConfiguration.Attributes("tempDirectory").Value = aspNetTempFolder.RootPath

        ' Commit the changes     
        iisManager.CommitChanges()

        Return MyBase.OnStart()
    End Function

End Class

