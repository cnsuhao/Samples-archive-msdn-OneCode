'***************************** Module Header ******************************\
' Module Name:	MainModule.vb
' Project:		VBWF4ActivitiesCorrelation
' Copyright (c) Microsoft Corporation.
' 
' This sample shows how to correlate two workflow services to work together.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/
Imports System.Activities
Imports System.Activities.Statements
Imports System.Linq
Imports System.Activities.DurableInstancing
Imports System.Threading
Imports System.Configuration
Imports System.ServiceModel.Activities

Module MainModule

    Sub Main()
        Dim wfAddress As New Uri("http://localhost:8000/WFServices")
        Dim waitHandler As New AutoResetEvent(False)
        Using host As New WorkflowServiceHost(New Workflow1(), wfAddress)
            host.WorkflowExtensions.Add(SetupSimplySqlPersistenceStore())
            AddHandler host.Closed, Function(obj, arg) waitHandler.Set()
            host.Open()
            Console.WriteLine("http://localhost:8000/WFServices is opening")
            waitHandler.WaitOne()
        End Using
    End Sub

    Private Function SetupSimplySqlPersistenceStore() As SqlWorkflowInstanceStore
        Dim connectionString As String =
            ConfigurationManager.AppSettings("SqlWF4PersistenceConnectionString").ToString()
        Dim sqlInstanceStore As SqlWorkflowInstanceStore =
            New SqlWorkflowInstanceStore(connectionString)
        sqlInstanceStore.HostLockRenewalPeriod = TimeSpan.FromSeconds(30)
        Return sqlInstanceStore
    End Function

End Module
