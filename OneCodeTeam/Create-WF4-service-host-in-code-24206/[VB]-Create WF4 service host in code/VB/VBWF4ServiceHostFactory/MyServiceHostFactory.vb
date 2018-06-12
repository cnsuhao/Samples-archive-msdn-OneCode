'****************************** Module Header ******************************\
' Module Name:  MyServiceHostFactory.vb
' Project:		VBWF4ServiceHostFactory
' Copyright (c) Microsoft Corporation.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Imports System.Activities.DurableInstancing
Imports System.ServiceModel.Activities
Imports System.ServiceModel.Activities.Activation

Public Class MyServiceHostFactory
    Inherits WorkflowServiceHostFactory
    Protected Overrides Function CreateWorkflowServiceHost(service As WorkflowService, baseAddresses As Uri()) As WorkflowServiceHost
        Dim host As WorkflowServiceHost = MyBase.CreateWorkflowServiceHost(service, baseAddresses)
        Dim connectionString As String = ConfigurationManager.AppSettings("SqlWF4PersistenceConnectionString").ToString()
        Dim instanceStore As New SqlWorkflowInstanceStore(connectionString)
        instanceStore.InstanceCompletionAction = InstanceCompletionAction.DeleteNothing
        host.DurableInstancingOptions.InstanceStore = instanceStore
        Return host
    End Function
End Class


