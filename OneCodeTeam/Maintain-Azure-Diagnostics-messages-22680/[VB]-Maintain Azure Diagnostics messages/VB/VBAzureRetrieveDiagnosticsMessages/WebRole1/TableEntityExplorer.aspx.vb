'***************************** Module Header ******************************\
'Module Name:  TableEntityExplorer.aspx.vb
'Project:      VBAzureRetrieveDiagnosticsMessages
'Copyright (c) Microsoft Corporation.
' 
'This programe will show you how to retrieve diagnostics message and transfer them 
'to Azure storage. And also it will show you how to view both logs in Table and logs
'in blob.
' 
' 
'Show the table list in Azure storage.
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
Imports Microsoft.WindowsAzure.StorageClient

Public Class TableEntityExplorer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                Dim account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString")
                Dim tableClient As New CloudTableClient(account.TableEndpoint.ToString(), account.Credentials)
                Dim result = tableClient.ListTables()
                Dim tableNameList As List(Of String) = result.ToList()

                Dim node As New TreeNode("")


                For Each item In tableNameList
                    Dim tableNode As New TreeNode(item)

                    tableNode.NavigateUrl = "~/TableMessageViewer.aspx?TableName=" & Convert.ToString(item)
                    tableNode.Value = item
                    node.ChildNodes.Add(tableNode)
                Next

                Me.tvTableDirectory.Nodes.Add(node)
            Catch
            End Try
        End If

    End Sub

End Class