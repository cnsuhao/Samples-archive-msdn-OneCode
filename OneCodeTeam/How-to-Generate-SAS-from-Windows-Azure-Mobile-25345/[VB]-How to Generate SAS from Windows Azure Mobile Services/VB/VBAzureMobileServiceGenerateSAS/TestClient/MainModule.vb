'****************************** Module Header ******************************\
' Module Name: MainModule.vb
' Project:     TestClient
' Copyright (c) Microsoft Corporation.
' 
' This project is designed for verifying the SAS token here.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Imports Microsoft.WindowsAzure.Storage.Auth
Imports Microsoft.WindowsAzure.Storage.Blob
Imports Microsoft.WindowsAzure.Storage
Imports System.IO
Imports System.Text

Module MainModule

    Sub Main()
        ' Token formate should like this: "?se=2013-09-28T14%3A35%3A34Z&sr=c&sp=rwdl&sig=GHnBW...";
        Dim sasToken As String = "YOUR SAS TOKEN"
        Dim accountName As String = "YOU STORAGE ACCOUNT NAME"
        ' First create a File in Azure storage container

        Dim blobUri As New Uri(String.Format("https://{0}.blob.core.windows.net/generateazuretablesas/myblob.txt", accountName))
        Dim blobUri1 As New Uri(String.Format("https://{0}.blob.core.windows.net/generateazuretablesas/myblob1.txt", accountName))
        Dim containerUri As New Uri(String.Format("https://{0}.blob.core.windows.net/generateazuretablesas/", accountName))

        ' Create credentials with the SAS token. The SAS token was created in previous example.
        Dim credential As New StorageCredentials(sasToken)
        CreateBlob(blobUri, credential)
        CreateBlob(blobUri1, credential)
        WriteBlob(blobUri, credential)
        DeleteBlob(blobUri, credential)
        ListBlobs(containerUri, credential)
        Console.ReadLine()
    End Sub

    Private Sub CreateBlob(blobUri As Uri, credential As StorageCredentials)
        ' Create a new blob.
        Dim blob As New CloudBlockBlob(blobUri, credential)
        Try
            ' Upload the blob. 
            ' If the blob does not yet exist, it will be created. 
            ' If the blob does exist, its existing content will be overwritten.
            Dim fileStream = generateStreamFromString("This is a new text file create by TestClient")
            blob.UploadFromStream(fileStream)

            Console.WriteLine("Create blob successfully! Blob URI:" & vbLf & "{0} ", blobUri.ToString())
        Catch ex As StorageException
            Console.WriteLine(ex.InnerException.ToString())

            Console.WriteLine("Create blob failed, please check your credential, make sure it's right.")
        End Try

    End Sub

    Private Sub WriteBlob(blobUri As Uri, credential As StorageCredentials)
        ' Write an exist blob.
        Dim blob As New CloudBlockBlob(blobUri, credential)
        Try

            Using stream As Stream = blob.OpenWrite()
                Dim line As String = "this is a new line over written by WriteBlob method"
                Dim buffer As Byte() = Encoding.[Default].GetBytes(line)
                stream.Write(buffer, 0, buffer.Length)
            End Using

            Console.WriteLine("Write blob successfully! Blob URI:" & vbLf & "{0}", blobUri.ToString())
        Catch ex As StorageException
            Console.WriteLine(ex.Message.ToString())
            Console.WriteLine("Write blob failed, please check your credential, make sure it's right.")
        End Try
    End Sub

    Private Sub DeleteBlob(blobUri As Uri, credential As StorageCredentials)
        Dim blob As New CloudBlockBlob(blobUri, credential)
        Try
            If blob.DeleteIfExists() Then
                Console.WriteLine("Delete Blob successfully! Blob URI:" & vbLf & "{0}", blobUri.ToString())
            Else
                Console.WriteLine("The blob doens't exist. Blob URI:" & vbLf & "{0}", blobUri.ToString())
            End If
        Catch ex As StorageException
            Console.WriteLine(ex.InnerException.ToString())
            Console.WriteLine("Delete blob failed, please check your credential, make sure it's right.")
        End Try
    End Sub

    Private Sub ListBlobs(containerUri As Uri, credential As StorageCredentials)
        Console.WriteLine("List container start")
        Try
            Dim container As New CloudBlobContainer(containerUri, credential)
            For Each item In container.ListBlobs(Nothing, True)

                If item.[GetType]() = GetType(CloudBlockBlob) Then
                    Dim blob As CloudBlockBlob = DirectCast(item, CloudBlockBlob)
                    Console.WriteLine("Block blob of length {0}: {1}", blob.Properties.Length, blob.Uri)
                ElseIf item.[GetType]() = GetType(CloudPageBlob) Then
                    Dim pageBlob As CloudPageBlob = DirectCast(item, CloudPageBlob)
                    Console.WriteLine("Page blob of length {0}: {1}", pageBlob.Properties.Length, pageBlob.Uri)
                ElseIf item.[GetType]() = GetType(CloudBlobDirectory) Then
                    Dim directory As CloudBlobDirectory = DirectCast(item, CloudBlobDirectory)
                    Console.WriteLine("Directory: {0}", directory.Uri)
                End If
            Next
            Console.WriteLine("List container successfully!")
        Catch ex As StorageException
            Console.WriteLine(ex.InnerException.ToString())
            Console.WriteLine("List blobs failed, please check your credential, make sure it's right.")
        End Try
    End Sub

    Private Function generateStreamFromString(s As String) As Stream
        Dim stream As New MemoryStream()
        Dim writer As New StreamWriter(stream)
        writer.Write(s)
        writer.Flush()
        stream.Position = 0
        Return stream
    End Function

End Module
