'***************************** Module Header ******************************\
'Module Name:  BlobDirecotryExplorer.aspx.vb
'Project:      VBAzureRetrieveDiagnosticsMessages
'Copyright (c) Microsoft Corporation.
'
'This programe will show you how to retrieve diagnostics message and transfer them 
'to Azure storage. And also it will show you how to view both logs in Table and logs
'in blob.
'
'
'This page shows the blob storage structure.
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
Imports System.IO

Public Class BlobDirectoryExplorer
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim statusMessage = String.Empty
            Try
                Dim account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString")
                Dim blobClient As CloudBlobClient = account.CreateCloudBlobClient()
                Dim rootContainer As CloudBlobContainer = blobClient.GetContainerReference("/")

                Dim node As New TreeNode("Root")
                node.Value = rootContainer.Uri.ToString()


                Dim containers = blobClient.ListContainers()


                ' Create sub node to treeview.
                For Each BlobContainer As CloudBlobContainer In containers
                    Dim containerNode As New TreeNode(BlobContainer.Name)
                    containerNode.Value = BlobContainer.Uri.ToString()
                    node.ChildNodes.Add(containerNode)

                    Dim blobItems As IEnumerable(Of IListBlobItem) = BlobContainer.ListBlobs()

                    For Each blobItem As IListBlobItem In blobItems
                        If TypeOf blobItem Is CloudBlobDirectory Then
                            Me.CreatTreeNodeItem(containerNode, TryCast(blobItem, CloudBlobDirectory))
                        Else
                            Me.CreatTreeNodeItem(containerNode, TryCast(blobItem, CloudBlob))
                        End If
                    Next
                Next

                Me.tvBlobDirectory.Nodes.Add(node)
            Catch ex As Exception
                statusMessage = "Unable to connect to the table storage server. Please check that the service is running.<br>" + ex.Message
            End Try
        End If

    End Sub

    ''' <summary>
    ''' Create blob structure treeview.
    ''' </summary>
    ''' <param name="Node"></param>
    ''' <param name="BlobItem"></param>
    Private Sub CreatTreeNodeItem(Node As TreeNode, BlobItem As Object)
        Dim subNode As TreeNode = Nothing
        If TypeOf BlobItem Is CloudBlobDirectory Then
            Dim blobDirectory As CloudBlobDirectory = TryCast(BlobItem, CloudBlobDirectory)

            Dim path__1 As String() = Path.GetDirectoryName(blobDirectory.Uri.AbsolutePath).Split(New String() {"%20", "\"}, StringSplitOptions.RemoveEmptyEntries)
            subNode = New TreeNode(path__1(path__1.Length - 1))
            subNode.Value = blobDirectory.Uri.ToString()


            Dim blobItems As IEnumerable(Of IListBlobItem) = blobDirectory.ListBlobs()

            For Each Item In blobItems
                If TypeOf Item Is CloudBlobDirectory Then

                    CreatTreeNodeItem(subNode, TryCast(Item, CloudBlobDirectory))
                Else
                    CreatTreeNodeItem(subNode, TryCast(Item, CloudBlob))
                End If
            Next
        Else

            Dim Item As CloudBlob = TryCast(BlobItem, CloudBlob)

            subNode = New TreeNode((Path.GetFileName(Item.Uri.AbsolutePath) & "-") + Item.Uri.AbsoluteUri)
            subNode.Value = Item.Uri.ToString()
            subNode.NavigateUrl = ("~/BlobTextViewer.aspx?containerName=" + Item.Container.Name & "&blobFileName=") + Item.Name
        End If
        Node.ChildNodes.Add(subNode)
    End Sub


End Class