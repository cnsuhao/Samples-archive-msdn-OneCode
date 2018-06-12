'**************************** Module Header ******************************\
' Module Name:  Default.aspx.vb
' Project:      VBSQLAzureStoreImages_WebRole
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to store images in Windows Azure SQL Server.
' Sometimes the developers need to store the files in the Windows Azure. In 
' this sample, we introduce two ways to implement this function:
' 1. Store the image data in SQL Azure. It's easy to search and manage the images.
' 2. Store the image in the Blob and store the Uri of the Blob in SQL Azure. 
' The space of Blob is cheaper. If we can store the image in the Blob and store 
' the information of image in SQL Azure, it's also easy to manage the images.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Configuration
Imports System.Linq
Imports System.Web.UI.WebControls
Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.ServiceRuntime
Imports Microsoft.WindowsAzure.StorageClient
Imports Microsoft.WindowsAzure.StorageClient.Protocol


Partial Public Class _Default
    Inherits System.Web.UI.Page

    Public imagesDb As New ImagesContext()
    ' Store the SelectedValue of the imageLocation
    Public selectedValue As String = Nothing

    Private Const BLOB As String = "BLOB"
    Private Const SQL As String = "SQL"

    ''' <summary>
    ''' Load the Page
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Try
            If Not IsPostBack Then
                ' Make sure that eh container of Blob exists.
                Me.EnsureContainerExists()
            Else
                ' Store the SelectedValue of the imageLocation to the variable.
                Me.selectedValue = imageLocation.SelectedValue
            End If

            ' Get the images.
            Me.RefreshGallery()
        Catch we As System.Net.WebException
            Me.status.Text = "Network error: " & we.Message
        Catch se As StorageException
            Console.WriteLine("Storage service error: " & se.Message)
        End Try

    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles Me.PreRender
        If RoleEnvironment.IsAvailable Then
            Dim source() As ListItem =
            {
                New ListItem With {.Text = "Blob Service", .Value = BLOB},
                New ListItem With {.Text = "SQL Azure", .Value = SQL}
            }
            Me.imageLocation.Items.Clear()
            Me.imageLocation.Items.AddRange(source)

            Me.imageLocation.SelectedValue = Me.selectedValue
        End If
    End Sub

    Protected Sub Upload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles upload.Click
        If Me.imageFile.HasFile Then
            Me.status.Text = "Inserted [" & Me.imageFile.FileName & "] - Content Type [" &
                Me.imageFile.PostedFile.ContentType & "] - Length [" & Me.imageFile.PostedFile.ContentLength & "]"

            Me.SaveImage(
                Me.imageName.Text,
                Me.imageDescription.Text,
                Me.imageFile.FileName,
                Me.imageFile.PostedFile.ContentType,
                Me.imageFile.FileBytes
                )

            Me.RefreshGallery()
        Else
            Me.status.Text = "No image file"
        End If

    End Sub

    ''' <summary>
    ''' Set the uri of images.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub OnDataBound(ByVal sender As Object, ByVal e As ListViewItemEventArgs) Handles images.ItemDataBound

        If e.Item.ItemType = ListViewItemType.DataItem Then
            Dim img As Image = TryCast(e.Item.FindControl("img"), Image)

            ' According to the choose of location, we set the uri of image.
            If String.IsNullOrEmpty(Me.selectedValue) OrElse Me.selectedValue.Equals(BLOB) Then
                Dim image As ImageInBlob = TryCast(e.Item.DataItem, ImageInBlob)
                img.ImageUrl = image.BlobUri
            ElseIf Me.selectedValue.Equals(SQL) Then
                Dim image As ImageInSQLAzure = TryCast(e.Item.DataItem, ImageInSQLAzure)
                img.ImageUrl = "GetImage.ashx?ImageId=" & image.ImageId
            End If

        End If

    End Sub

    ''' <summary>
    ''' Delete an image by ImageId.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub OnDeleteImage(ByVal sender As Object, ByVal e As CommandEventArgs)
        Try
            If e.CommandName = "Delete" Then
                Dim imageId As Int32 = Int32.Parse(TryCast(e.CommandArgument, String))

                If String.IsNullOrEmpty(Me.selectedValue) OrElse Me.selectedValue.Equals(BLOB) Then
                    Dim deletedImage As ImageInBlob = (
                        From i In imagesDb.BlobImages
                        Where i.ImageId = imageId
                        Select i).FirstOrDefault()
                    If deletedImage IsNot Nothing Then
                        ' Delete an blob by uri.
                        Dim blob = Me.GetContainer().GetBlobReference(deletedImage.BlobUri)
                        blob.DeleteIfExists()

                        imagesDb.BlobImages.Remove(deletedImage)
                        imagesDb.SaveChanges()
                    End If
                ElseIf Me.selectedValue.Equals(SQL) Then
                    Dim deletedImage As ImagesTable = (
                        From i In imagesDb.ImagesTable
                        Where i.ImageId = imageId
                        Select i).FirstOrDefault()

                    If deletedImage IsNot Nothing Then
                        Dim deletedImageInfo As ImageInSQLAzure = deletedImage.ImageInfo

                        imagesDb.SQLAzureImages.Remove(deletedImageInfo)
                        imagesDb.ImagesTable.Remove(deletedImage)
                        imagesDb.SaveChanges()
                    End If
                End If
            End If
        Catch se As StorageClientException
            Me.status.Text = "Storage client error: " & se.Message
        Catch e1 As Exception
        End Try

        Me.RefreshGallery()

    End Sub

    ''' <summary>
    ''' Copy an image by ImageId
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub OnCopyImage(ByVal sender As Object, ByVal e As CommandEventArgs)
        If e.CommandName = "Copy" Then
            Dim imageId As Int32 = Int32.Parse(TryCast(e.CommandArgument, String))
            If String.IsNullOrEmpty(Me.selectedValue) OrElse Me.selectedValue.Equals(BLOB) Then
                Dim copiedImage As ImageInBlob = (
                    From i In imagesDb.BlobImages
                    Where i.ImageId = imageId
                    Select i).FirstOrDefault()
                If copiedImage IsNot Nothing Then
                    Dim srcBlob = Me.GetContainer().GetBlobReference(copiedImage.BlobUri)

                    Dim newImageName As String = "Copy of """ & copiedImage.ImageName & """"
                    Dim newBlob = Me.GetContainer().GetBlobReference(Guid.NewGuid().ToString())

                    ' Copy content from source blob
                    newBlob.CopyFromBlob(srcBlob)

                    ' Copy the info of image.
                    Dim newImage As New ImageInBlob()
                    newImage.FileName = copiedImage.FileName
                    newImage.ImageName = newImageName
                    newImage.Description = copiedImage.Description
                    newImage.BlobUri = newBlob.Uri.ToString()

                    imagesDb.BlobImages.Add(newImage)
                    imagesDb.SaveChanges()

                    Me.RefreshGallery()
                End If
            ElseIf Me.selectedValue.Equals(SQL) Then
                Dim copiedImage As ImagesTable = (
                    From i In imagesDb.ImagesTable
                    Where i.ImageId = imageId
                    Select i).FirstOrDefault()

                If copiedImage IsNot Nothing Then
                    Dim copiedImageInfo As ImageInSQLAzure = copiedImage.ImageInfo
                    Dim newImage As New ImagesTable()
                    Dim newImageInfo As New ImageInSQLAzure()

                    ' Copy the info of image.
                    newImageInfo.FileName = copiedImageInfo.FileName
                    newImageInfo.ImageName = "Copy of """ & copiedImageInfo.ImageName & """"
                    newImageInfo.Description = copiedImageInfo.Description

                    newImage.ImageData = copiedImage.ImageData
                    newImage.ImageInfo = newImageInfo

                    imagesDb.SQLAzureImages.Add(newImageInfo)
                    imagesDb.ImagesTable.Add(newImage)
                    imagesDb.SaveChanges()

                    Me.RefreshGallery()
                End If
            End If
        End If

    End Sub

    ''' <summary>
    ''' Make sure that the Container exits. If it's not, create one.
    ''' </summary>
    Private Sub EnsureContainerExists()
        Dim container = Me.GetContainer()
        container.CreateIfNotExist()

        Dim permissions = container.GetPermissions()
        permissions.PublicAccess = BlobContainerPublicAccessType.Container
        container.SetPermissions(permissions)
    End Sub

    Private Function GetContainer() As CloudBlobContainer
        ' Get a handle on account, create a blob service client and get container proxy
        Dim account = CloudStorageAccount.FromConfigurationSetting("StorageConnectionString")
        Dim client = account.CreateCloudBlobClient()

        Return client.GetContainerReference(RoleEnvironment.GetConfigurationSettingValue("StorageName"))
    End Function


    ''' <summary>
    ''' Get the images by the choose of locations
    ''' </summary>
    Private Sub RefreshGallery()
        If String.IsNullOrEmpty(Me.selectedValue) OrElse Me.selectedValue.Equals(BLOB) Then
            Me.images.DataSource = imagesDb.BlobImages.ToList()
        ElseIf Me.selectedValue.Equals(SQL) Then
            Me.images.DataSource = imagesDb.SQLAzureImages.ToList()
        End If

        Me.images.DataBind()
    End Sub

    ''' <summary>
    ''' Save the images to the location
    ''' </summary>
    ''' <param name="name">It's the name that user inputs.</param>
    ''' <param name="description">It's the description that user inputs.</param>
    ''' <param name="fileName">It's the name of the file.</param>
    ''' <param name="contentType">It's the type of the file.</param>
    ''' <param name="data">It's the content of the file</param>
    Private Sub SaveImage(ByVal name As String,
                          ByVal description As String,
                          ByVal fileName As String,
                          ByVal contentType As String,
                          ByVal data() As Byte)
        ' Store the images to the Blob and SQL Azure by the choose of the location.
        If Me.selectedValue.Equals(BLOB) Then
            name = If(String.IsNullOrEmpty(name), "unknown", name)
            Dim blob = Me.GetContainer().GetBlobReference(name)

            blob.Properties.ContentType = contentType

            Dim newImage As New ImageInBlob()
            newImage.FileName = fileName
            newImage.ImageName = name
            newImage.Description = If(String.IsNullOrEmpty(description), "unknown", description)

            blob.UploadByteArray(data)
            newImage.BlobUri = blob.Uri.ToString()

            imagesDb.BlobImages.Add(newImage)
            imagesDb.SaveChanges()
        ElseIf Me.selectedValue.Equals(SQL) Then
            Dim newImageInfo As New ImageInSQLAzure()
            Dim newImage As New ImagesTable()

            newImageInfo.FileName = fileName
            newImageInfo.ImageName = If(String.IsNullOrEmpty(name), "unknown", name)
            newImageInfo.Description = If(String.IsNullOrEmpty(description), "unknown", description)

            newImage.ImageInfo = newImageInfo
            newImage.ImageData = data

            imagesDb.SQLAzureImages.Add(newImageInfo)
            imagesDb.ImagesTable.Add(newImage)
            imagesDb.SaveChanges()
        End If
    End Sub
End Class

