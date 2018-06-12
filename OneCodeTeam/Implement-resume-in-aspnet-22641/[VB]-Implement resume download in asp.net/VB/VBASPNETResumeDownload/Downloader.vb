'***************************** Module Header ******************************\
' Module Name: Downloader.vb
' Project:     VBASPNETResumeDownload
' Copyright (c) Microsoft Corporation
'
' This module contains the Downloader class.
' 
' The Downloader class encapsulates some methods used to support resume download file.
' GetResponseHeader method gets the response header information by the request header.
' SendDownloadFile method send the download file to client.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************/

Imports System.IO
Imports System.Text
Imports System.Web

Namespace VBASPNETResumeDownload
    Public Class Downloader
        Public Shared Sub DownloadFile(ByVal httpContext As HttpContext, ByVal filePath As String)
            If Not IsFileExists(filePath) Then
                httpContext.Response.StatusCode = 404
                Return
            End If

            Dim fileInfo As New FileInfo(filePath)

            If fileInfo.Length > Int32.MaxValue Then
                httpContext.Response.StatusCode = 413
                Return
            End If

            ' Get the response header information by the http request.
            Dim responseHeader As HttpResponseHeader = GetResponseHeader(httpContext.Request, fileInfo)

            If responseHeader Is Nothing Then
                Return
            End If

            Dim fileStream As New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)

            Try
                SendDownloadFile(httpContext.Response, responseHeader, fileStream)
            Catch ex As HttpException
                httpContext.Response.StatusCode = ex.GetHttpCode()
            Finally
                fileStream.Close()
            End Try
        End Sub

        ''' <summary>
        ''' Check whether the file exists.
        ''' </summary>
        ''' <param name="filePath"></param>
        ''' <returns></returns>
        Private Shared Function IsFileExists(ByVal filePath As String) As Boolean
            Dim fileExists As Boolean = False

            If Not String.IsNullOrEmpty(filePath) Then
                If File.Exists(filePath) Then
                    fileExists = True
                End If
            End If

            Return fileExists
        End Function

        ''' <summary>
        ''' Get the response header by the http request.
        ''' </summary>
        ''' <param name="httpRequest"></param>
        ''' <param name="fileInfo"></param>
        ''' <returns></returns>
        Private Shared Function GetResponseHeader(ByVal httpRequest As HttpRequest, ByVal fileInfo As FileInfo) As HttpResponseHeader
            If httpRequest Is Nothing Then
                Return Nothing
            End If

            If fileInfo Is Nothing Then
                Return Nothing
            End If

            Dim startPosition As Long = 0
            Dim contentRange As String = ""

            Dim fileName As String = fileInfo.Name
            Dim fileLength As Long = fileInfo.Length
            Dim lastUpdateTimeStr As String = fileInfo.LastWriteTimeUtc.ToString()

            Dim eTag As String = HttpUtility.UrlEncode(fileName, Encoding.UTF8) & " " & lastUpdateTimeStr
            Dim contentDisposition As String = "attachment;filename=" & HttpUtility.UrlEncode(fileName, Encoding.UTF8).Replace("+", "%20")

            If httpRequest.Headers("Range") IsNot Nothing Then
                Dim range As String() = httpRequest.Headers("Range").Split(New Char() {"="c, "-"c})
                startPosition = Convert.ToInt64(range(1))
                If startPosition < 0 OrElse startPosition >= fileLength Then
                    Return Nothing
                End If
            End If

            If httpRequest.Headers("If-Range") IsNot Nothing Then
                If httpRequest.Headers("If-Range").Replace("""", "") <> eTag Then
                    startPosition = 0
                End If
            End If

            Dim contentLength As String = (fileLength - startPosition).ToString()

            If startPosition > 0 Then
                contentRange = String.Format(" bytes {0}-{1}/{2}", startPosition, fileLength - 1, fileLength)
            End If

            Dim responseHeader As New HttpResponseHeader()

            responseHeader.AcceptRanges = "bytes"
            responseHeader.Connection = "Keep-Alive"
            responseHeader.ContentDisposition = contentDisposition
            responseHeader.ContentEncoding = Encoding.UTF8
            responseHeader.ContentLength = contentLength
            responseHeader.ContentRange = contentRange
            responseHeader.ContentType = "application/octet-stream"
            responseHeader.Etag = eTag
            responseHeader.LastModified = lastUpdateTimeStr

            Return responseHeader
        End Function

        ''' <summary>
        ''' Send the download file to the client.
        ''' </summary>
        ''' <param name="httpResponse"></param>
        ''' <param name="responseHeader"></param>
        ''' <param name="fileStream"></param>
        Private Shared Sub SendDownloadFile(ByVal httpResponse As HttpResponse, ByVal responseHeader As HttpResponseHeader, ByVal fileStream As Stream)
            If httpResponse Is Nothing OrElse responseHeader Is Nothing Then
                Return
            End If

            If Not String.IsNullOrEmpty(responseHeader.ContentRange) Then
                httpResponse.StatusCode = 206

                ' Set the start position of the reading files.
                Dim range As String() = responseHeader.ContentRange.Split(New Char() {" "c, "="c, "-"c})
                fileStream.Position = Convert.ToInt64(range(2))
            End If
            httpResponse.Clear()
            httpResponse.Buffer = False
            httpResponse.AppendHeader("Accept-Ranges", responseHeader.AcceptRanges)
            httpResponse.AppendHeader("Connection", responseHeader.Connection)
            httpResponse.AppendHeader("Content-Disposition", responseHeader.ContentDisposition)
            httpResponse.ContentEncoding = responseHeader.ContentEncoding
            httpResponse.AppendHeader("Content-Length", responseHeader.ContentLength)
            If Not String.IsNullOrEmpty(responseHeader.ContentRange) Then
                httpResponse.AppendHeader("Content-Range", responseHeader.ContentRange)
            End If
            httpResponse.ContentType = responseHeader.ContentType
            httpResponse.AppendHeader("Etag", """" & responseHeader.Etag & """")
            httpResponse.AppendHeader("Last-Modified", responseHeader.LastModified)

            Dim buffer As [Byte]() = New [Byte](10239) {}
            Dim fileLength As Long = Convert.ToInt64(responseHeader.ContentLength)

            ' Send file to client.
            While fileLength > 0
                If httpResponse.IsClientConnected Then
                    Dim length As Integer = fileStream.Read(buffer, 0, 10240)

                    httpResponse.OutputStream.Write(buffer, 0, length)

                    httpResponse.Flush()

                    fileLength = fileLength - length
                Else
                    fileLength = -1
                End If
            End While
        End Sub
    End Class

    ''' <summary>
    ''' Respresent the HttpResponse header information.
    ''' </summary>
    Class HttpResponseHeader
        Public Property AcceptRanges() As String

        Public Property Connection() As String

        Public Property ContentDisposition() As String

        Public Property ContentEncoding() As Encoding

        Public Property ContentLength() As String

        Public Property ContentRange() As String

        Public Property ContentType() As String

        Public Property Etag() As String

        Public Property LastModified() As String

    End Class
End Namespace
