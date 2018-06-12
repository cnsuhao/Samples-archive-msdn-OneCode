'****************************** Module Header ******************************\
'Module Name:  Default.aspx.vb
'Project:      AzureBackup_WebRole
'Copyright (c) Microsoft Corporation.
'
'The sample code demonstrates how to backup Azure Storage in Cloud. Though 
'Windows Azure Platform have 3 copies for our data, but this is only physical
'backup, if a logical errors occurred that all copies of storage would been
'modified, so this sample shows how to protect our important data with code.
'
'This page is used to help your backup your data in blob storage and table 
'storage. Click upload button to upload sample data in storage, then input
'your source storage and copies storage (Blob container or table) in related 
'TextBox control, then you can view them with REST Service or tools (Azure
'Storage Explorer or Server Explorer).
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.StorageClient
Imports TableStoargeManager

Public Class _Default
    Inherits System.Web.UI.Page
    Private account As CloudStorageAccount
    Private nameList As New List(Of String)() From { _
     "MSDN.jpg", _
     "Microsoft.jpg" _
    }

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lbBackup.Text = String.Empty
        lbContent.Text = String.Empty
        account = CloudStorageAccount.FromConfigurationSetting("StorageConnections")
    End Sub

    ''' <summary>
    ''' Upload resources to Storage.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnUpload_Click(sender As Object, e As EventArgs)
        Try
            Dim source As New FileDataSource("files")
            Dim client As CloudBlobClient = account.CreateCloudBlobClient()
            Dim container As CloudBlobContainer = client.GetContainerReference("blob")
            container.CreateIfNotExist()
            Dim permission = container.GetPermissions()
            permission.PublicAccess = BlobContainerPublicAccessType.Container
            container.SetPermissions(permission)
            Dim flag As Boolean = False

            For Each name As String In nameList
                If Not source.FileExists(name, "image") Then
                    flag = True
                    Dim blob As CloudBlob = container.GetBlobReference(name)
                    Dim path As String = String.Format("{0}/{1}", "Files", name)
                    blob.UploadFile(Server.MapPath(path))

                    Dim entity As New FileEntity("image")
                    entity.FileName = name
                    entity.FileUrl = blob.Uri.ToString()
                    source.AddFile(entity)
                    lbContent.Text += [String].Format("The image file {0} is uploaded successes. <br />", name)
                End If
            Next
            If Not flag Then
                lbContent.Text = "You had uploaded these resources. The blob container name is 'blob', table name is 'files'"
            Else
                lbContent.Text += "The blob container name is 'blob', The table name is 'files'"
            End If
        Catch ex As Exception
            lbContent.Text = ex.Message
        End Try
    End Sub



    Protected Sub btnBackup_Click(sender As Object, e As EventArgs)
        Try
            If tbSource.Text.Trim().Equals(String.Empty) AndAlso tbCopies.Text.Trim().Equals(String.Empty) Then
                lbBackup.Text = "Source TextBox and Copies TextBox can not be empty"
                Return
            End If

            Dim sourceContainerName As String = tbSource.Text.Trim()
            Dim copiesContainerName As String = tbCopies.Text.Trim()
            Dim client As CloudBlobClient = account.CreateCloudBlobClient()

            Dim sourceContainer As CloudBlobContainer = client.GetContainerReference(sourceContainerName)
            If Not StorageManager.CheckIfExists(sourceContainer) Then
                lbBackup.Text = "The source blob container is not exists"
                Return
            End If
            Dim copiesContainer As CloudBlobContainer = client.GetContainerReference(copiesContainerName)
            copiesContainer.CreateIfNotExist()
            Dim permission = copiesContainer.GetPermissions()
            permission.PublicAccess = BlobContainerPublicAccessType.Container
            copiesContainer.SetPermissions(permission)


            For Each blob In sourceContainer.ListBlobs()
                Dim uri As String = blob.Uri.AbsolutePath
                Dim matches As String() = New String() {"blob/"}
                Dim FileName As String = uri.Split(matches, StringSplitOptions.None)(1).Substring(0)
                Dim sourceBlob As CloudBlob = sourceContainer.GetBlobReference(FileName)
                Dim copiesBlob As CloudBlob = copiesContainer.GetBlobReference(FileName)
                copiesBlob.CopyFromBlob(sourceBlob)
                lbBackup.Text += [String].Format("The image file {0} is backup successes. Copies container name is {1} <br />", FileName, copiesContainerName)
            Next
        Catch ex As StorageClientException
            If ex.ExtendedErrorInformation.ErrorCode.Equals("OutOfRangeInput") Then
                lbBackup.Text = "Please check your blob container name."
            Else
                lbBackup.Text = ex.Message
            End If
        Catch all As Exception
            lbBackup.Text = all.Message
        End Try
    End Sub



    Protected Sub btnBackupTable_Click(sender As Object, e As EventArgs)
        Try
            If tbTabelSource.Text.Trim().Equals(String.Empty) AndAlso tbTableCopies.Text.Trim().Equals(String.Empty) Then
                lbBackupTable.Text = "Source TextBox and Copies TextBox can not be empty"
                Return
            End If

            Dim sourceTableName As String = tbTabelSource.Text.Trim()
            Dim copiesTableName As String = tbTableCopies.Text.Trim()
            Dim client As CloudTableClient = account.CreateCloudTableClient()


            If Not client.DoesTableExist(sourceTableName) Then
                lbBackupTable.Text = "The source table is not exists"
                Return
            End If

            Dim tableDataSource As New FileDataSource(sourceTableName)
            Dim sourceList As List(Of FileEntity) = tableDataSource.GetAllEntities().ToList()
            client.DeleteTableIfExist(copiesTableName)
            Dim tableDataCopies As New FileDataSource(copiesTableName)
            tableDataCopies.AddNumbersOfFiles(sourceList)
            lbBackupTable.Text = [String].Format("The source table {0} is backup successes. Copies table name is {1}", sourceTableName, copiesTableName)
        Catch ex As StorageClientException
            If ex.ExtendedErrorInformation.ErrorCode.Equals("OutOfRangeInput") Then
                lbBackupTable.Text = "Please check your blob container name."
            Else
                lbBackupTable.Text = ex.Message
            End If
        Catch all As Exception
            lbBackupTable.Text = all.Message
        End Try
    End Sub
End Class