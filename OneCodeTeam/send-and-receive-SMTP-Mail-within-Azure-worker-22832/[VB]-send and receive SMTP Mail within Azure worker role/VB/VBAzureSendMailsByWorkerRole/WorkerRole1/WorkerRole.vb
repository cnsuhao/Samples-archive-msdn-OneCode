'****************************** Module Header ******************************\
' Module Name:  WorkerRole.vb
' Project:      VBAzureSendMailsByWorkerRole
' Copyright (c) Microsoft Corporation.
' 
' As you know, System.Net.Mail api can't be used in Windows Runtime application, 
' However, we can create a WCF service to consume the api, and hold this service 
' on Azure.
' 
' In this way, we can use this service to send email in Windows Store app. 
' 
' A workrole holds the SMTP sending mail service.
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
Imports System.Diagnostics
Imports System.Linq
Imports System.Net
Imports System.Threading
Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.Diagnostics
Imports Microsoft.WindowsAzure.ServiceRuntime
Imports Microsoft.WindowsAzure.StorageClient
Imports System.ServiceModel
Imports MailService
Public Class WorkerRole
    Inherits RoleEntryPoint

    Public Overrides Sub Run()

        ' This is a sample implementation. Replace with your logic.
        Trace.WriteLine("WorkerRole1 entry point called.", "Information")

        While (True)
            Thread.Sleep(10000)
            Trace.WriteLine("Working", "Information")
        End While

    End Sub

    Public Overrides Function OnStart() As Boolean

        ' Set the maximum number of concurrent connections 
        ServicePointManager.DefaultConnectionLimit = 12

	Dim host As New ServiceHost(GetType(MailOperationService))
	host.Open()

        ' For information on handling configuration changes
        ' see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

        Return MyBase.OnStart()

    End Function

End Class
