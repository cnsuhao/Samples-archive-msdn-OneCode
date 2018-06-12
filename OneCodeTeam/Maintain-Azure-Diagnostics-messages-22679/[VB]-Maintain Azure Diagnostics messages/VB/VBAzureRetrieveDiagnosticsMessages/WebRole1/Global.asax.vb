Imports System.Web.SessionState
Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.ServiceRuntime

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' This code sets up a handler to update CloudStorageAccount instances when their corresponding
        ' configuration settings change in the service configuration file.
        CloudStorageAccount.SetConfigurationSettingPublisher(Sub(configName, configSetter)
                                                                 ' Provide the configSetter with the initial value
                                                                 configSetter(RoleEnvironment.GetConfigurationSettingValue(configName))

                                                             End Sub)

        ' Create data table from MessageDataServiceContext
        ' It is recommended the data tables should be only created once. It is typically done as a 
        ' provisioning step and rarely in application code.
        Dim account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString")
        'Add this message to Windows Azure Logs and it will transfer to WADLogsTable(table)
        System.Diagnostics.Trace.WriteLine("Application start")

    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class