'***************************** Module Header ******************************\
'Module Name:  TableMessageViewer.aspx.vb
'Project:      VBAzureRetrieveDiagnosticsMessages
'Copyright (c) Microsoft Corporation.
' 
'This programe will show you how to retrieve diagnostics message and transfer them 
'to Azure storage. And also it will show you how to view both logs in Table and logs
'in blob.
' 
' 
'This page will show all the message in WADLogsTable.
'If you want to view other tables, please add the table entity to this project.
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
Imports Microsoft.WindowsAzure
Imports System.Data.Services.Client

Public Class TableMessageViewer_aspx
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'This page will show all the message in WADLogsTable.
        'If you want to view other tables, please add the table entity to this project.

        If Request.QueryString("TableName") = "WADLogsTable" Then
            Dim statusMessage = String.Empty
            Try
                Dim account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString")
                Dim context = New WADLogsTableDataServiceContext(account.TableEndpoint.ToString(), account.Credentials)

                Me.gdvMessageList.DataSource = context.WADLogs
                Me.gdvMessageList.DataBind()
            Catch ex As DataServiceRequestException
                statusMessage = "Unable to connect to the table storage server. Please check that the service is running.<br>" + ex.Message
            End Try

            lbStatus.Text = statusMessage
        Else
            lbStatus.Text = "This example only support WADLogsTable table."
        End If

    End Sub

End Class