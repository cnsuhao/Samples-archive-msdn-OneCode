'***************************** Module Header ******************************\
' Module Name:  WorkerRole.vb
' Project:      WorkerRole1
' Copyright (c) Microsoft Corporation.
' 
' This application shows how to run your cmd script or other executable
' file on each worker role instance.
'
' Host the WCF service on local.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports System.Net
Imports System.Threading
Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.Diagnostics
Imports Microsoft.WindowsAzure.ServiceRuntime
Imports Microsoft.WindowsAzure.StorageClient
Imports System.ServiceModel
Imports InstanceController.Interface
Imports System.ServiceModel.Description

Public Class WorkerRole
    Inherits RoleEntryPoint

    Public Overrides Sub Run()
        ' This is a sample worker implementation. Replace with your logic.
        Trace.WriteLine("WorkerRole1 entry point called", "Information")

        While True
            Thread.Sleep(10000)
            Trace.WriteLine("Working", "Information")
        End While
    End Sub

    Public Overrides Function OnStart() As Boolean
        Dim internalEndPoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints("InternalEndPoint")
        Dim host As New ServiceHost(GetType(InstanceControllerService))

        Dim binding As New BasicHttpBinding()
        binding.Security.Mode = BasicHttpSecurityMode.None

        host.AddServiceEndpoint(GetType(IInstanceController), binding, String.Format("http://{0}/InternalService", internalEndPoint.IPEndpoint))
        If host.Description.Behaviors.Find(Of ServiceMetadataBehavior)() Is Nothing Then
            Dim behavior As New ServiceMetadataBehavior()
            behavior.HttpGetEnabled = True
            behavior.HttpGetUrl = New Uri(String.Format("http://{0}/InternalService/metadata", internalEndPoint.IPEndpoint))
            host.Description.Behaviors.Add(behavior)
        End If

        host.Open()
        ' For information on handling configuration changes
        ' see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

        Return MyBase.OnStart()

    End Function

End Class
