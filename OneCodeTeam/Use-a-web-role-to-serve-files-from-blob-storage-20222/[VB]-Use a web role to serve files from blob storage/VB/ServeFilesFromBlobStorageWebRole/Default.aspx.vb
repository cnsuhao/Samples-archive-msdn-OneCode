'****************************** Module Header ******************************\
'Module Name:  Default.aspx.vb
'Project:      ServeFilesFromBlobStorageWebRole
'Copyright (c) Microsoft Corporation.
'
'The sample code demonstrates a way to serve files from storage via a web role.
'A file from blob storage(such as http://xxx.cloudapp.net/files/File1) can be
'reached as the normal files in your application by relative path ("files/File1").
'And this http module can also filter some specify types files.
'
'The page is used to show some link examples.
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

Public Class _Default
    Inherits System.Web.UI.Page
    Private Shared account As CloudStorageAccount
    Public embedString As String = String.Empty
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            account = CloudStorageAccount.FromConfigurationSetting("StorageConnections")
            Dim source As New FileDataSource()
            Dim list As IEnumerable(Of FileEntity) = source.GetAllEntities()
            Dim sb As New StringBuilder()
            If list.Count() > 0 Then
                sb.Append("Then please check them: <br />")
                For Each entity As FileEntity In list
                    sb.Append("<a href='File/")
                    sb.Append(entity.FileName)
                    sb.Append("' target='_blank'>")
                    sb.Append(entity.FileName)
                    sb.Append("</a>")
                    sb.Append("<br />")


                Next
            End If
            sb.Append("<a href='HTMLSamoke.htm' target='_blank' >HTML resource (No available)</a><br />")
            sb.Append("<a href='HTMLSamoke.jpg' target='_blank' >HTML resource (No resources)</a>")
            embedString = sb.ToString()
        End If
    End Sub

    Protected Sub Unnamed1_Click(sender As Object, e As EventArgs) Handles Linkbutton1.Click
        Response.Redirect("FileUploadPage.aspx")
    End Sub
End Class