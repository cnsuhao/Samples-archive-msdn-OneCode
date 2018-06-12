'/****************************** Module Header ******************************\
'Module Name:  CompressionArchive.VB
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
Imports System.IO.Compression
Imports System.Web
Imports System.IO.Packaging

Public Class CompressionArchive
    Private Shared folderPath As String = HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings.GetValues("FolderPath").GetValue(0).ToString())

    Private uniqueNameForZipFile As String

    Private _tempZipFilePath As String

    Public Property TempZipFilePath() As String
        Get
            Return _tempZipFilePath
        End Get
        Set(value As String)
            _tempZipFilePath = value
        End Set
    End Property

    Public Sub New()
        uniqueNameForZipFile = GenerateGuid()
    End Sub


    ''' <summary>
    ''' Compress to a zip file from the input files
    ''' </summary>
    ''' <param name="filesForCompression"></param>
    Public Sub CompressToZipArchive(filesForCompression As List(Of String))

        TempZipFilePath = HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings.GetValues("FolderPath").GetValue(0).ToString()) & uniqueNameForZipFile & ".gz"
        ' We can .zip extension also

        For Each fileToCompress As String In filesForCompression
            ' Loop through each entry and add to ZipArchive 
            CreateZip(TempZipFilePath, fileToCompress)
        Next
    End Sub

    ''' <summary>
    ''' Sends the Zip over HTTP i.e. Download Prompt
    ''' </summary>   
    Public Sub DownloadFile()
        Dim zipPathDetails As New FileInfo(TempZipFilePath)
        If IsGZipSupported() Then
            HttpContext.Current.Response.Filter = New System.IO.Compression.GZipStream(HttpContext.Current.Response.Filter, System.IO.Compression.CompressionMode.Compress)
            'decompressing the content before rendering
            HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip")
        End If
        HttpContext.Current.Response.ContentType = "application/zip"
        HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + zipPathDetails.Name)
        HttpContext.Current.Response.AddHeader("TempFileName", TempZipFilePath)
        ' Will be used in Application_EndRequest for file deletion
        HttpContext.Current.Response.WriteFile(TempZipFilePath)
        HttpContext.Current.ApplicationInstance.CompleteRequest()
    End Sub


    ''' <summary>
    ''' Determines if GZip is supported
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function IsGZipSupported() As Boolean
        Dim AcceptEncoding As String = HttpContext.Current.Request.Headers("Accept-Encoding")
        If Not String.IsNullOrEmpty(AcceptEncoding) AndAlso AcceptEncoding.Contains("gzip") OrElse AcceptEncoding.Contains("deflate") Then
            Return True
        End If
        Return False
    End Function


    ''' <summary>
    ''' Generate a unique GUID, can be used for creating a unique file name for temp Zip file
    ''' </summary>
    ''' <returns> Unique ID</returns>
    Private Function GenerateGuid() As String
        Dim result As String = ""
        Dim innerLoop As Double, outerLoop As Double
        Dim uniqueGUID As New Random()
        For outerLoop = 0 To 9
            If outerLoop = 3 OrElse outerLoop = 6 OrElse outerLoop = 9 Then
                result = result & "-"c
            End If
            innerLoop = Math.Floor(Convert.ToDouble(uniqueGUID.[Next](9999)))
            result = result & innerLoop
        Next
        Return result
    End Function

    ''' <summary>
    ''' using System.IO.Packaging to add files to a single zip file
    ''' One cavet of using the ZipPackage to create Zips is that Packages contain a content type manifest named "[Content_Types].xml". 
    ''' </summary>
    ''' <param name="tempZipPath"></param>
    ''' <param name="inputFileToAdd"></param>
    Private Sub CreateZip(tempZipPath As String, inputFileToAdd As String)
        Using package As Package = Package.Open(tempZipPath, FileMode.OpenOrCreate)
            Dim destFilename As String = ".\" & Path.GetFileName(inputFileToAdd)
            Dim uri As Uri = PackUriHelper.CreatePartUri(New Uri(destFilename, UriKind.Relative))

            ' Checking if a file already exists in the Zip
            If package.PartExists(uri) Then
                package.DeletePart(uri)
            End If

            Dim part As PackagePart = package.CreatePart(uri, "", CompressionOption.Normal)

            Using fileStream As New FileStream(inputFileToAdd, FileMode.Open, FileAccess.Read)
                CopyStream(fileStream, part.GetStream())
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Copies data from a source stream to a target stream.
    ''' </summary>
    ''' <param name="source">The source stream to copy from.</param>
    ''' <param name="target">The destination stream to copy to.</param>
    Private Sub CopyStream(source As System.IO.FileStream, target As System.IO.Stream)
        Const bufSize As Integer = &H1000
        Dim buf As Byte() = New Byte(bufSize - 1) {}
        Dim bytesRead As Integer = 0
        While (InlineAssignHelper(bytesRead, source.Read(buf, 0, bufSize))) > 0
            target.Write(buf, 0, bytesRead)
        End While
    End Sub


    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function

End Class
