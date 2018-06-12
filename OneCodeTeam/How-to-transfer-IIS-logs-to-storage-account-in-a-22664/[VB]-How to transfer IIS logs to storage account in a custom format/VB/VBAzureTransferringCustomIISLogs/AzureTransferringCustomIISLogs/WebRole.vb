'****************************** Module Header ******************************\
' Module Name:  WebRole.vb
' Project:      AzureTransferringCustomIISLogs
' Copyright (c) Microsoft Corporation.
'  
' Because any log file transfer to Azure storage are billable ,custom log file 
' before transfer will help you save money. This sample will show you how to 
' custom IIS logs in your Azure web role. This is a frequently asked question in forum,
' so we provide this sample code to show how to achieve this in .NET.
' 
' This class shows how to use ServerManager Class costom IIS log before transfer to 
' storage.
'  
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'  
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
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
        ' Get this connection string in web role's setting tab
        Dim storageConnectionString As String = "Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString"

        ' Get default config
        Dim config As DiagnosticMonitorConfiguration = DiagnosticMonitor.GetDefaultInitialConfiguration()

        ' Transfer the IIS and IIS Failed Request Logs
        config.Directories.ScheduledTransferPeriod = TimeSpan.FromMinutes(1.0)

        ' 'Custom diagnostic logging
        'Using serverManager As New ServerManager()
        '    ' Get the website.
        '    ' First make sure your cloud programe use IIS Web Server not IIS express.
        '    ' Note that "_Web" is the name of the site in the ServiceDefinition.csdef,
        '    ' so make sure you change this code if you change the site name in the .csdef
        '    Dim site As Site = serverManager.Sites(RoleEnvironment.CurrentRoleInstance.Id + "_Web")
        '    site.LogFile.LogExtFileFlags = LogExtFileFlags.[Date] Or
        '        LogExtFileFlags.Time Or LogExtFileFlags.ClientIP Or
        '        LogExtFileFlags.Host Or LogExtFileFlags.BytesSent Or
        '        LogExtFileFlags.BytesRecv
        '    site.LogFile.Period = LoggingRolloverPeriod.Hourly
        '    serverManager.CommitChanges()
        'End Using

        DiagnosticMonitor.Start(storageConnectionString, config)
        AddHandler RoleEnvironment.Changing, AddressOf RoleEnvironmentChanging
        Return MyBase.OnStart()
    End Function

    Private Sub RoleEnvironmentChanging(sender As Object, e As RoleEnvironmentChangingEventArgs)
        If e.Changes.Any(Function(change) TypeOf change Is RoleEnvironmentConfigurationSettingChange) Then
            e.Cancel = True
        End If
    End Sub


End Class

