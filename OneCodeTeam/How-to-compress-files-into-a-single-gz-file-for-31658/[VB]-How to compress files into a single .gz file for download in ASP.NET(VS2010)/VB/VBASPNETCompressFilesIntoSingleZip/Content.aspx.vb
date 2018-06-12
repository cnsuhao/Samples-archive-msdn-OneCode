'/****************************** Module Header ******************************\
'Module Name:  Content.aspx.vb
'Project:      CSASPNETCompressFilesIntoSingleZip
'Copyright (c) Microsoft Corporation.

'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
'All other rights reserved.

'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\***************************************************************************/


Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO.Compression


Public Class Content
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Listing the files in the gridview. Folder path is confiigured in web.config
        If Not IsPostBack Then
            Dim filePaths As String() = Directory.GetFiles(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings.GetValues("FolderPath").GetValue(0).ToString()))
            Dim files As New List(Of ListItem)()
            For Each filePath As String In filePaths

                files.Add(New ListItem(Path.GetFileName(filePath), filePath))
            Next
            gdvFolderContents.DataSource = files
            gdvFolderContents.DataBind()
        End If
    End Sub

    Protected Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        Dim filesToCompress As New List(Of String)()

        For Each gdvRow As GridViewRow In gdvFolderContents.Rows
            Dim chkSelectedTemp As New CheckBox()
            chkSelectedTemp = DirectCast(gdvRow.FindControl("chkSelect"), CheckBox)
            If chkSelectedTemp IsNot Nothing AndAlso chkSelectedTemp.Checked = True Then
                filesToCompress.Add(gdvRow.Cells(2).Text)
            End If
        Next

        If filesToCompress.Count > 0 Then
            'Creating Object of class to compress and download as a zip
            Dim CompressSelectedFiles As New CompressionArchive()

            ' Compress to a zip file
            CompressSelectedFiles.CompressToZipArchive(filesToCompress)

            Cache("TempFileName") = CompressSelectedFiles.TempZipFilePath

            ' Sends the Zip over HTTP

            CompressSelectedFiles.DownloadFile()
        End If

    End Sub

End Class