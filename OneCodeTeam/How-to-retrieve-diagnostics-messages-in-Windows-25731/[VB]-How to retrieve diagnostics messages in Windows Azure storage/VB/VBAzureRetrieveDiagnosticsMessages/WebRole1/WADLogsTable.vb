'***************************** Module Header ******************************\
'Module Name:  WADLogsTable.vb
'Project:      VBAzureRetrieveDiagnosticsMessages
'Copyright (c) Microsoft Corporation.
' 
'This programe will show you how to retrieve diagnostics message and transfer them 
'to Azure storage. And also it will show you how to view both logs in Table and logs
'in blob.
' 
' 
'WADLogsTable entity, in this example, we defined this entity
'for Windows Azure logs which store in Azure Table storage WADLogsTable.
' 
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

Public Class WADLogsTable
    Inherits Microsoft.WindowsAzure.StorageClient.TableServiceEntity
    Public Property Message() As String

    Public Property EventTickCount() As Int64

    Public Property DeploymentId() As String

    Public Property Role() As String

    Public Property RoleInstance() As String

    Public Property Level() As Integer

    Public Property EventId() As Integer

    Public Property Pid() As Integer

    Public Property Tid() As Integer
End Class

