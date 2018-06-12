'****************************** Module Header ******************************\
'Module Name:  FileUploadPage.aspx.vb
'Project:      ServeFilesFromBlobStorageWebRole
'Copyright (c) Microsoft Corporation.
'
'The sample code demonstrates a way to serve files from storage via a web role.
'A file from blob storage(such as http://xxx.cloudapp.net/files/File1) can be
'reached as the normal files in your application by relative path ("files/File1").
'And this http module can also filter some specify types files.
'
'This page is used to upload some existing resources for sample, it requires your
'cloud account and key.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports Microsoft.WindowsAzure
Imports TableStorageManager
Imports Microsoft.WindowsAzure.StorageClient
Imports System.IO

Public Class FileUploadPage
    Inherits System.Web.UI.Page
    Private Shared account As CloudStorageAccount
    Public files As New List(Of FileEntity)()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        account = CloudStorageAccount.FromConfigurationSetting("StorageConnections")
    End Sub

    ''' <summary>
    ''' Upload existing resources. ("Files" folder)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Dim source As New FileDataSource()
        Dim nameList As New List(Of String)() From { _
         "Files/Microsoft.jpg", _
         "Files/MSDN.jpg", _
         "Files/Site.css" _
        }
        Dim client As CloudBlobClient = account.CreateCloudBlobClient()
        Dim container As CloudBlobContainer = client.GetContainerReference("container")
        container.CreateIfNotExist()
        Dim permission = container.GetPermissions()
        permission.PublicAccess = BlobContainerPublicAccessType.Container
        container.SetPermissions(permission)

        For Each name As String In nameList
            If name.Substring(name.LastIndexOf("."c) + 1).Equals("jpg") AndAlso File.Exists(Server.MapPath(name)) Then
                If Not source.FileExists(name, "image") Then
                    Dim blob As CloudBlob = container.GetBlobReference(name)
                    blob.UploadFile(Server.MapPath(name))

                    Dim entity As New FileEntity("image")
                    entity.FileName = name
                    entity.FileUrl = blob.Uri.ToString()
                    source.AddFile(entity)
                    lbContent.Text += [String].Format("The image file {0} is uploaded successes. <br />", name)
                End If
            ElseIf name.Substring(name.LastIndexOf("."c) + 1).Equals("css") AndAlso File.Exists(Server.MapPath(name)) Then
                If Not source.FileExists(name, "css") Then
                    Dim blob As CloudBlob = container.GetBlobReference(name)
                    blob.UploadFile(Server.MapPath(name))

                    Dim entity As New FileEntity("css")
                    entity.FileName = name
                    entity.FileUrl = blob.Uri.ToString()
                    source.AddFile(entity)
                    lbContent.Text += [String].Format("The css file {0} is uploaded successes. <br />", name)
                End If
            End If
        Next

        If nameList.Count <= 0 Then
            lbContent.Text = "You had uploaded these resources"
        End If

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Response.Redirect("Default.aspx")
    End Sub
End Class