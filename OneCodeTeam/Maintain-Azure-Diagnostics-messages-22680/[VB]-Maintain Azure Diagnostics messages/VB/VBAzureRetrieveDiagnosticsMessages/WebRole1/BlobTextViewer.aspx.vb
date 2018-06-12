'***************************** Module Header ******************************\
'Module Name:  BlobTextViewer.aspx.vb
'Project:      VBAzureRetrieveDiagnosticsMessages
'Copyright (c) Microsoft Corporation.
' 
'This programe will show you how to retrieve diagnostics message and transfer them 
'to Azure storage. And also it will show you how to view both logs in Table and logs
'in blob.
' 
'
'This page shows the xml message in the blob log file.
' 
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
'All other rights reserved.
' 
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Threading
Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.StorageClient
Imports System.IO



Public Class BlobTextViewer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("containerName") IsNot Nothing AndAlso Request.QueryString("blobFileName") IsNot Nothing Then
            Dim containerName As String = Request.QueryString("containerName").ToString()
            Dim blobFileName As String = Request.QueryString("blobFileName").ToString()
            Try
                Dim account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString")
                Dim blobClient As CloudBlobClient = account.CreateCloudBlobClient()

                Dim blobContainer As CloudBlobContainer = blobClient.GetContainerReference(containerName)
                Dim cloudBlob As CloudBlob = blobContainer.GetBlobReference(blobFileName)

                Dim text As String = cloudBlob.DownloadText()
                Dim stringWriter As New StringWriter()
                stringWriter.WriteLine(text)
                Response.ContentType = "text/plain"
                Response.AddHeader("Content-disposition", "attachment; filename=" & blobFileName & ".txt")
                Response.Clear()
                Using writer As New StreamWriter(Response.OutputStream, Encoding.UTF8)
                    writer.Write(stringWriter.ToString())
                End Using
                Response.End()
                'Response.End() will cause this exception. Should be ignore.
            Catch ex As ThreadAbortException
            Catch
                Response.Write("This blob file isn't a valiable text file.")

            End Try
        Else
            Response.Write("Please choose right file in BlobDirectoryExplorer.aspx")
        End If

    End Sub

End Class