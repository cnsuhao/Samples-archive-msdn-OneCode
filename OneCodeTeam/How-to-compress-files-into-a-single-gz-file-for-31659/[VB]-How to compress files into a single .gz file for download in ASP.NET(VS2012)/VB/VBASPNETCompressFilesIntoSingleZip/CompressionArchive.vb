'****************************** Module Header ******************************
'Module Name:  CompressionArchive.vb
'Project:      CSASPNETCompressFilesIntoSingleZip
'Copyright (c) Microsoft Corporation.

'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
'All other rights reserved.

'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************

Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.IO.Compression
Imports System.Web

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

        Using compressedFileStream As FileStream = File.Create(TempZipFilePath)
            'ZipArchive class represents a package of compressed files in the zip archive format
            Using archive As New ZipArchive(compressedFileStream, ZipArchiveMode.Update)
                For Each fileToCompress As String In filesForCompression
                    Dim fileToCompressDetails As New FileInfo(fileToCompress)
                    ' Loop through each entry and add to ZipArchive 
                    Dim readmeEntry As ZipArchiveEntry = archive.CreateEntryFromFile(fileToCompress, fileToCompressDetails.Name)
                Next
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Sends the Zip over HTTP i.e. Download Prompt
    ''' </summary>
    ''' <param name="zipFilePath"></param>
    Public Sub DownloadFile()
        Dim zipPathDetails As New FileInfo(TempZipFilePath)
        HttpContext.Current.Response.ContentType = "application/zip"
        HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + zipPathDetails.Name)
        HttpContext.Current.Response.AddHeader("TempFileName", TempZipFilePath)
        ' Will be used in Application_EndRequest for file deletion
        HttpContext.Current.Response.WriteFile(TempZipFilePath)
        HttpContext.Current.ApplicationInstance.CompleteRequest()
    End Sub

    ''' <summary>
    ''' Generate a unique GUID, can be used for creating a unique file name for temp Zip file
    ''' </summary>
    ''' <returns>Unique GUID </returns>
    ''' <remarks></remarks>
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


End Class
