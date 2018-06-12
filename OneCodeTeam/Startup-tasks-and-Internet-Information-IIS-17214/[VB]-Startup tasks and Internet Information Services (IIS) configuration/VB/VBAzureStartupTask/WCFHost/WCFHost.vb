'****************************** Module Header ******************************\
' Module Name:  WCFHost.vb
' Project:      VBAzureStartupTask
' Copyright (c) Microsoft Corporation.
' 
' A Windows Azure Worker role which hosts reverse string WCF service in
' WaWorkerHost.exe
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Imports System.Net
Imports Microsoft.WindowsAzure.ServiceRuntime
Imports System.Threading
Imports ReverseStringImpl

Public Class WCFHost
    Inherits RoleEntryPoint
    Private serviceHost As ServiceHost
    Private re As Int32

    Private Sub StartService(retries As Int32)
        If retries = 0 Then
            RoleEnvironment.RequestRecycle()
            Return
        End If

        Dim httpUri As New Uri([String].Format("http://{0}/{1}", RoleEnvironment.CurrentRoleInstance.InstanceEndpoints("HttpIn").IPEndpoint.ToString(), "ReverseString"))


        serviceHost = New ServiceHost(GetType(TestWCFService), httpUri)
        re = retries

        AddHandler serviceHost.Faulted, AddressOf FaultedFunc

        Try
            Trace.TraceInformation("Trying to open service host")
            serviceHost.Open()

            Trace.TraceInformation("Service host started successfully.")
        Catch timeoutException As TimeoutException

            Trace.TraceError("The service operation time out. {0}", timeoutException.Message)
        Catch communicationException As CommunicationException
            Trace.TraceError("Could not start service host. {0}", communicationException.Message)
        End Try
    End Sub

    Private Sub StopService()
        If serviceHost IsNot Nothing Then
            Try
                serviceHost.Close()
            Catch timeoutException As TimeoutException
                Trace.TraceError("The service close time out. {0}", timeoutException.Message)

                serviceHost.Abort()
            Catch communicationException As CommunicationException
                Trace.TraceError("Could not close service host. {0}", communicationException.Message)

                serviceHost.Abort()
            End Try
        End If
    End Sub

    Sub FaultedFunc(sender, e)
        Trace.TraceError("Host fault occurred. Aborting and restarting the host. Retry count: {0}", re)

        serviceHost.Abort()
        StartService(System.Threading.Interlocked.Decrement(re))

    End Sub


    Public Overrides Sub Run()
        ' This is a sample worker implementation. Replace with your logic.
        Trace.WriteLine("WorkerRole1 entry point called", "Information")

        While True
            Thread.Sleep(10000)
            Trace.WriteLine("Working", "Information")
        End While
    End Sub

    Public Overrides Function OnStart() As Boolean
        ' Set the maximum number of concurrent connections 
        ServicePointManager.DefaultConnectionLimit = 12

        StartService(3)

        ' For information on handling configuration changes
        ' see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.
        AddHandler RoleEnvironment.Changing, AddressOf RoleEnvironmentChanging

        Return MyBase.OnStart()
    End Function

    Public Overrides Sub OnStop()
        StopService()
        MyBase.OnStop()
    End Sub


    Private Sub RoleEnvironmentChanging(sender As Object, e As RoleEnvironmentChangingEventArgs)
        If e.Changes.Any(Function(change) TypeOf change Is RoleEnvironmentConfigurationSettingChange) Then
            e.Cancel = True
        End If
    End Sub
End Class
