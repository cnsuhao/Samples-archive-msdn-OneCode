'***************************** Module Header ******************************\
'Module Name:  WebRoles.vb
'Project:      VBAzureRetrieveDiagnosticsMessages
'Copyright (c) Microsoft Corporation.
' 
'This programe will show you how to retrieve diagnostics message and transfer them 
'to Azure storage. And also it will show you how to view both logs in Table and logs
'in blob.
' 
' 
'This class shows how to transfer logs to Azure storage. 
' 
' 
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
'All other rights reserved.
' 
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.Diagnostics
Imports Microsoft.WindowsAzure.ServiceRuntime

Public Class WebRole
    Inherits RoleEntryPoint
    Public Overrides Function OnStart() As Boolean
        Dim config As DiagnosticMonitorConfiguration = DiagnosticMonitor.GetDefaultInitialConfiguration()

        ' Windows Performance Counters
        Dim counters As New List(Of String)()
        counters.Add("\Processor(_Total)\% Processor Time")
        counters.Add("\Memory\Available Mbytes")
        counters.Add("\TCPv4\Connections Established")
        counters.Add("\ASP.NET Applications(__Total__)\Requests/Sec")
        counters.Add("\Network Interface(*)\Bytes Received/sec")
        counters.Add("\Network Interface(*)\Bytes Sent/sec")
        For Each counter As String In counters
            Dim counterConfig As New PerformanceCounterConfiguration()
            counterConfig.CounterSpecifier = counter
            counterConfig.SampleRate = TimeSpan.FromMinutes(5)
            config.PerformanceCounters.DataSources.Add(counterConfig)
        Next
        config.PerformanceCounters.ScheduledTransferPeriod = TimeSpan.FromMinutes(5)

        ' Windows Event Logs
        ' WADWindowsEventLogsTable
        config.WindowsEventLog.DataSources.Add("System!*")
        ' WADLogsTable
        config.WindowsEventLog.DataSources.Add("Application!*")
        config.WindowsEventLog.ScheduledTransferPeriod = TimeSpan.FromMinutes(1.0)
        config.WindowsEventLog.ScheduledTransferLogLevelFilter = LogLevel.Verbose

        ' Azure Trace Logs
        config.Logs.ScheduledTransferPeriod = TimeSpan.FromMinutes(1.0)
        config.Logs.ScheduledTransferLogLevelFilter = LogLevel.Verbose
        ' Crash Dumps
        CrashDumps.EnableCollection(True)

        ' IIS Logs
        config.Directories.ScheduledTransferPeriod = TimeSpan.FromMinutes(1)
        Trace.WriteLine("WAD Monitor started", "Information")
        DiagnosticMonitor.Start("Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString", config)
        AddHandler RoleEnvironment.Changing, AddressOf RoleEnvironmentChanging

        ' Enabled IIS faild request logs.
        ' This log file only generate after you have a faild request.
        Using serverManager As New Microsoft.Web.Administration.ServerManager()
            Dim iisConfig = serverManager.GetApplicationHostConfiguration()

            Dim sitesSection = iisConfig.GetSection("system.applicationHost/sites")

            Dim siteDefaultsElement = sitesSection.GetChildElement("siteDefaults")

            Dim logFileElement = siteDefaultsElement.GetChildElement("logFile")
            logFileElement("enabled") = True


            serverManager.CommitChanges()
        End Using
        Return MyBase.OnStart()
    End Function

    Private Sub RoleEnvironmentChanging(sender As Object, e As RoleEnvironmentChangingEventArgs)
        If e.Changes.Any(Function(change) TypeOf change Is RoleEnvironmentConfigurationSettingChange) Then
            e.Cancel = True
        End If
    End Sub
End Class


