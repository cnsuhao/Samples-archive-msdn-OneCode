'**************************** Module Header ******************************\
' Module Name:	Form1.vb
' Project:		VBAzureUploadBigFile
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to upload a big file to azure blob storage.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************
Imports Microsoft.WindowsAzure.Storage.Blob
Imports Microsoft.WindowsAzure.Storage
Imports System.ComponentModel
Imports System.IO
Imports System.Text

Partial Public Class Form1
    Inherits Form
    Private storageConnectionString As String = "DefaultEndpointsProtocol=https;AccountName={Account-Name};AccountKey={Account-Key}"

    Private bufferSize As Integer = 40 * 1024
    Private blockCount As Integer = 0
    Private blockIds As New List(Of String)()
    Private filePath As String
    Private isCanceled As Boolean = False
    Public Sub New()
        InitializeComponent()
        btnStart.Enabled = False
        btnEnd.Enabled = False
    End Sub

    Private Sub uploadBackgroundWorker_DoWork(sender As Object, e As DoWorkEventArgs)
        UploadBigFile(uploadBackgroundWorker, e)
    End Sub

    Private Sub uploadBackgroundWorker_ProgressChanged(sender As Object, e As ProgressChangedEventArgs)
        progressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub uploadBackgroundWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        If Not isCanceled Then
            blockIds.Clear()
        End If
        btnStart.Enabled = True
        browseFile.Enabled = True
        btnEnd.Enabled = False
    End Sub

    Private Sub browseFile_Click(sender As Object, e As EventArgs)
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            textBox1.Text = InlineAssignHelper(filePath, openFileDialog1.FileName)
            Using fileStream As FileStream = File.OpenRead(filePath)
                blockCount = CInt(fileStream.Length / bufferSize) + 1
            End Using
            progressBar1.Maximum = blockCount
        End If
        If Not String.IsNullOrEmpty(textBox1.Text) Then
            btnStart.Enabled = True
        End If
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs)
        If Not uploadBackgroundWorker.IsBusy Then
            btnStart.Enabled = False
            browseFile.Enabled = False
            btnEnd.Enabled = True
            uploadBackgroundWorker.RunWorkerAsync()
        End If
    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs)
        btnStart.Enabled = True
        browseFile.Enabled = True
        btnEnd.Enabled = False
        uploadBackgroundWorker.CancelAsync()
        isCanceled = True
    End Sub

    Private Sub UploadBigFile(worker As BackgroundWorker, e As DoWorkEventArgs)
        'bufferSize 40KB
        Dim bufferBytes As Byte() = New Byte(bufferSize - 1) {}
        Dim fileName As String = Path.GetFileName(filePath)

        Dim blob As CloudBlockBlob = GetBlobkBlob(fileName)

        Using fileStream As FileStream = File.OpenRead(filePath)
            'Get the total count of block
            blockCount = CInt(fileStream.Length / bufferSize) + 1
            Dim currentBlockSize As Int64 = 0
            Dim currentCount As Integer = blockIds.Count()
            fileStream.Seek(bufferSize * currentCount, SeekOrigin.Begin)
            For i As Integer = blockIds.Count To blockCount - 1
                If worker.WorkerSupportsCancellation AndAlso worker.CancellationPending Then
                    Return
                End If
                currentBlockSize = bufferSize
                If i = blockCount - 1 Then
                    currentBlockSize = fileStream.Length - bufferSize * i
                    bufferBytes = New Byte(currentBlockSize - 1) {}
                End If
                If currentBlockSize = 0 Then
                    Exit For
                End If
                'Get the block data
                fileStream.Read(bufferBytes, 0, Convert.ToInt32(currentBlockSize))
                Using memoryStream As New MemoryStream(bufferBytes)
                    Try
                        'Get Base64-encoded block Id
                        Dim blockId As String = Convert.ToBase64String(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()))
                        'Upload the block
                        blob.PutBlock(blockId, memoryStream, Nothing)
                        'Cache the block Id
                        blockIds.Add(blockId)
                        worker.ReportProgress(i + 1)

                    Catch generatedExceptionName As Exception
                    End Try
                End Using
            Next
        End Using
        'Commit all the blocks
        blob.PutBlockList(blockIds)
        isCanceled = False
    End Sub

    Private Function GetBlobkBlob(fileName As String) As CloudBlockBlob
        Dim storageAccount = CloudStorageAccount.Parse(storageConnectionString)
        Dim blobStorage As CloudBlobClient = storageAccount.CreateCloudBlobClient()

        Dim container As CloudBlobContainer = blobStorage.GetContainerReference("mycontainer")
        container.CreateIfNotExists()

        Return container.GetBlockBlobReference(fileName)
    End Function
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function
End Class