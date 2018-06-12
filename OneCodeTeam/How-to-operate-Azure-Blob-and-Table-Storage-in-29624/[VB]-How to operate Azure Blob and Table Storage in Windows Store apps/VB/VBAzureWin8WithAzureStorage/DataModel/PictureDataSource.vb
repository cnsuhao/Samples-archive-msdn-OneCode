'**************************** Module Header ******************************\
' Module Name:	PictureDataSource.vb
' Project:		VBAzureWin8WithAzureStorage
' Copyright (c) Microsoft Corporation.
' 
' This sample shows how to store images to Windows Azure Blob storage,
' and save image information to table storage.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************/
Imports Microsoft.WindowsAzure.Storage.Table
Imports Microsoft.WindowsAzure.Storage.Blob

Public Class PictureDataSource

    Public Shared pictureDataSource As New PictureDataSource()
    Private m_allImages As New ObservableCollection(Of PictureViewModel)()


    Public Sub New()
        GetPictureInfoFromTableStorage()
    End Sub

    Public ReadOnly Property AllImages() As ObservableCollection(Of PictureViewModel)
        Get
            Return m_allImages
        End Get
    End Property
    Public Shared Async Function UploadPictureToCloud(pictureViewModel As PictureViewModel) As Task(Of Boolean)

        Try
            Dim blockBlobClient = App.account.CreateCloudBlobClient()
            Dim contianer = blockBlobClient.GetContainerReference(App.contianerName)
            Await contianer.CreateIfNotExistsAsync()
            Dim picture As CloudBlockBlob = contianer.GetBlockBlobReference(Guid.NewGuid().ToString())
            Using filestream = Await pictureViewModel.PictureFile.OpenAsync(FileAccessMode.ReadWrite)
                Await picture.UploadFromStreamAsync(filestream)
                pictureViewModel.PictureUrl = picture.Uri.ToString()
            End Using


            Dim tableClient = App.account.CreateCloudTableClient()
            Dim table = tableClient.GetTableReference(App.tableName)
            Await table.CreateIfNotExistsAsync()

            Dim operation = TableOperation.Insert(pictureViewModel.PictureTableEntity)
            Await table.ExecuteAsync(operation)

            pictureDataSource.AllImages.Add(pictureViewModel)

            Return True
        Catch ex As Exception


            Throw ex
        End Try

    End Function

    Public Async Function GetPictureInfoFromTableStorage() As Task
        Dim client = App.account.CreateCloudTableClient()
        Dim table = client.GetTableReference(App.tableName)
        Await table.CreateIfNotExistsAsync()

        Dim results = Await table.ExecuteQuerySegmentedAsync(New TableQuery(), Nothing)
        For Each item In results
            pictureDataSource.AllImages.Add(New PictureViewModel() With { _
                 .PictureTableEntity = item _
            })
        Next
    End Function

    Public Shared Function GetAllImages() As ObservableCollection(Of PictureViewModel)
        Return pictureDataSource.AllImages
    End Function

    Public Shared Async Function DeletePictureFormCloud(pictureViewModel As PictureViewModel) As Task(Of Boolean)
        Try
            Dim blob = New CloudBlockBlob(New Uri(pictureViewModel.PictureUrl), App.credentials)
            Await blob.DeleteAsync()

            Dim tableClient = App.account.CreateCloudTableClient()
            Dim table = tableClient.GetTableReference(App.tableName)

            Dim operation = TableOperation.Delete(pictureViewModel.PictureTableEntity)
            Await table.ExecuteAsync(operation)

            pictureDataSource.AllImages.Remove(pictureViewModel)
            Return True
        Catch ex As Exception


            Throw ex
        End Try
    End Function


End Class