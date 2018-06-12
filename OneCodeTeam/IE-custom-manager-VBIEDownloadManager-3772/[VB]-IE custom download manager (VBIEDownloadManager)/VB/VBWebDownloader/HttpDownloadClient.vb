'*************************** Module Header ******************************'
' Module Name:  HttpDownloadClient.vb
' Project:      VBWebDownloader
' Copyright (c) Microsoft Corporation.
' 
' This class is used to download files through internet.  It supplies public
' methods to Start, Pause, Resume and Cancel a download. 
' 
' When the download starts, it will check whether the destination file exists. If
' not, create a file with the same size as the file to be downloaded, then
' download the file in a background thread.
' 
' The downloaded data is stored in a MemoryStream first, and then written to local
' file.
' 
' It will fire a DownloadProgressChanged event when it has downloaded a
' specified size of data. It will also fire a DownloadCompleted event if the 
' download is completed or canceled.
' 
' The property DownloadedSize stores the size of downloaded data which will be 
' used to Resume the download.
' 
' The property StartPoint can be used in the multi-thread download scenario, and
' every thread starts to download a specific block of the whole file. 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************'

Imports System.IO
Imports System.Net
Imports System.Threading
Imports System.Text.RegularExpressions

Public Class HttpDownloadClient
    ' Used when creates or writes a file.
    Private Shared _locker As New Object()

    ' Store the used time spent in downloading data. The value does not include
    ' the paused time and it will only be updated when the download is paused, 
    ' canceled or completed.
    Private _usedTime As New TimeSpan()

    Private _lastStartTime As Date

    ''' <summary>
    ''' If the status is Downloading, then the total time is usedTime. Else the total 
    ''' should include the time used in current download thread.
    ''' </summary>
    Public ReadOnly Property TotalUsedTime() As TimeSpan
        Get
            If Me.Status <> HttpDownloadClientStatus.Downloading Then
                Return _usedTime
            Else
                Return _usedTime.Add(Date.Now.Subtract(_lastStartTime))
            End If
        End Get
    End Property

    ' The time and size in last DownloadProgressChanged event. These two fields
    ' are used to calculate the download speed.
    Private _lastNotificationTime As Date
    Private _lastNotificationDownloadedSize As Int64

    ' If get a number of buffers, then fire DownloadProgressChanged event.
    Private _bufferCountPerNotification As Integer
    Public Property BufferCountPerNotification() As Integer
        Get
            Return _bufferCountPerNotification
        End Get
        Private Set(ByVal value As Integer)
            _bufferCountPerNotification = value
        End Set
    End Property

    ' The Url of the file to be downloaded.
    Private _url As Uri
    Public Property Url() As Uri
        Get
            Return _url
        End Get
        Private Set(ByVal value As Uri)
            _url = value
        End Set
    End Property

    ''' <summary>
    ''' Specify whether the remote server supports "Accept-Ranges" header.
    ''' </summary>
    Private _isRangeSupported As Boolean
    Public Property IsRangeSupported() As Boolean
        Get
            Return _isRangeSupported
        End Get
        Private Set(ByVal value As Boolean)
            _isRangeSupported = value
        End Set
    End Property

    ' The local path to store the file.
    ' If there is no file with the same name, a new file will be created.
    Private _downloadPath As String
    Public Property DownloadPath() As String
        Get
            Return _downloadPath
        End Get
        Set(ByVal value As String)
            _downloadPath = value
        End Set
    End Property

    ' The properties StartPoint and EndPoint can be used in the multi-thread download scenario, and
    ' every thread starts to download a specific block of the whole file. 
    Private _startPoint As Integer
    Public Property StartPoint() As Integer
        Get
            Return _startPoint
        End Get
        Private Set(ByVal value As Integer)
            _startPoint = value
        End Set
    End Property

    Private _endPoint As Integer
    Public Property EndPoint() As Integer
        Get
            Return _endPoint
        End Get
        Private Set(ByVal value As Integer)
            _endPoint = value
        End Set
    End Property

    ' Set the BufferSize when read data in Response Stream.
    Private _bufferSize As Integer
    Public Property BufferSize() As Integer
        Get
            Return _bufferSize
        End Get
        Private Set(ByVal value As Integer)
            _bufferSize = value
        End Set
    End Property

    ' The cache size in memory.
    Private _maxCacheSize As Integer
    Public Property MaxCacheSize() As Integer
        Get
            Return _maxCacheSize
        End Get
        Private Set(ByVal value As Integer)
            _maxCacheSize = value
        End Set
    End Property

    Private _totalSize As Int64 = 0

    ' Ask the server for the file size and store it
    Public Property TotalSize() As Int64
        Get
            Return _totalSize
        End Get
        Private Set(value As Int64)
            _totalSize = value
        End Set
    End Property

    ' The size of downloaded data that has been writen to local file.
    Private _downloadedSize As Int64
    Public Property DownloadedSize() As Int64
        Get
            Return _downloadedSize
        End Get
        Private Set(ByVal value As Int64)
            _downloadedSize = value
        End Set
    End Property

    Private _status As HttpDownloadClientStatus

    ' If status changed, fire StatusChanged event.
    Public Property Status() As HttpDownloadClientStatus
        Get
            Return _status
        End Get

        Private Set(ByVal value As HttpDownloadClientStatus)
            If _status <> value Then
                _status = value
                Me.OnStatusChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    Public Event DownloadProgressChanged As EventHandler(Of HttpDownloadProgressChangedEventArgs)

    Public Event DownloadCompleted As EventHandler(Of HttpDownloadCompletedEventArgs)

    Public Event StatusChanged As EventHandler

    ''' <summary>
    ''' Download the whole file.
    ''' </summary>
    Public Sub New(ByVal url As String)

        Me.New(url, 0)

    End Sub

    ''' <summary>
    ''' Download the file from a start point to the end.
    ''' </summary>
    Public Sub New(ByVal url As String, ByVal startPoint As Integer)
        Me.New(url, startPoint, Integer.MaxValue)
    End Sub

    ''' <summary>
    ''' Download a block of the file. The default buffer size is 1KB, memory cache is
    ''' 2MB, and buffer count per notification is 512.
    ''' </summary>
    Public Sub New(ByVal url As String, ByVal startPoint As Integer, ByVal endPoint As Integer)
        Me.New(url, startPoint, endPoint, 1024, 2097152, 512)
    End Sub

    Public Sub New(ByVal url As String, _
                   ByVal startPoint As Integer, ByVal endPoint As Integer, _
                   ByVal bufferSize As Integer, ByVal cacheSize As Integer, _
                   ByVal bufferCountPerNotification As Integer)
        If startPoint < 0 Then
            Throw New ArgumentOutOfRangeException("StartPoint cannot be less then 0. ")
        End If

        If endPoint < startPoint Then
            Throw New ArgumentOutOfRangeException("EndPoint cannot be less then StartPoint ")
        End If

        If bufferSize < 0 Then
            Throw New ArgumentOutOfRangeException("BufferSize cannot be less then 0. ")
        End If

        If cacheSize < bufferSize Then
            Throw New ArgumentOutOfRangeException("MaxCacheSize cannot be less then BufferSize ")
        End If

        If BufferCountPerNotification <= 0 Then
            Throw New ArgumentOutOfRangeException("BufferCountPerNotification cannot be less then 0.")
        End If

        Me.StartPoint = startPoint
        Me.EndPoint = endPoint
        Me.BufferSize = bufferSize
        Me.MaxCacheSize = cacheSize
        Me._bufferCountPerNotification = BufferCountPerNotification

        Me.Url = New Uri(url, UriKind.Absolute)

        ' Set the idle status.
        Me._status = HttpDownloadClientStatus.Idle

    End Sub

    Public Sub CheckUrl(ByRef fileName As String)
        fileName = String.Empty

        ' The file could be checked only in Idle status.
        If Me.Status <> HttpDownloadClientStatus.Idle Then
            Throw New ApplicationException("The file could be checked only in Idle status.")
        End If

        ' Check the file information on the remote server.
        Dim request = CType(WebRequest.Create(Url), HttpWebRequest)

        request.Credentials = CredentialCache.DefaultCredentials

        Using response = request.GetResponse()
            For Each header In response.Headers.AllKeys
                If header.Equals("Accept-Ranges", StringComparison.OrdinalIgnoreCase) Then
                    Me.IsRangeSupported = True
                End If

                If header.Equals("Content-Disposition", StringComparison.OrdinalIgnoreCase) Then
                    Dim contentDisposition As String = response.Headers(header)

                    Dim pattern As String = ".[^;]*;\s+filename=""(?<file>.*)"""
                    Dim r As New Regex(pattern)
                    Dim m As Match = r.Match(contentDisposition)
                    If m.Success Then
                        fileName = m.Groups("file").Value
                    End If
                End If
            Next header

            Me.TotalSize = response.ContentLength

            If TotalSize <= 0 Then
                Throw New ApplicationException("The file to download does not exist!")
            End If

            If Not IsRangeSupported Then
                Me.StartPoint = 0
                Me.EndPoint = Integer.MaxValue
            End If
        End Using

        If Me.IsRangeSupported AndAlso (Me.StartPoint <> 0 OrElse Me.EndPoint <> Integer.MaxValue) Then
            request = CType(WebRequest.Create(Url), HttpWebRequest)
            If EndPoint <> Integer.MaxValue Then
                request.AddRange(StartPoint, EndPoint)
            Else
                request.AddRange(StartPoint)
            End If
            Using response = request.GetResponse()
                Me.TotalSize = response.ContentLength
            End Using
        End If

        ' Set the checked status.
        Me.Status = HttpDownloadClientStatus.Checked
    End Sub

    ''' <summary>
    ''' Start to download.
    ''' </summary>
    Public Sub Start()

        ' Check whether the destination file exist.
        CheckFileOrCreateFile()

        ' Only idle download client can be started.
        If Me.Status <> HttpDownloadClientStatus.Checked Then
            Throw New ApplicationException("Only Checked downloader can be started. ")
        End If

        ' Start to download in a background thread.
        BeginDownload()
    End Sub

    ''' <summary>
    ''' Pause the download.
    ''' </summary>
    Public Sub Pause()
        ' Only downloading client can be paused.
        If Me.Status <> HttpDownloadClientStatus.Downloading Then
            Throw New ApplicationException("Only downloading client can be paused.")
        End If

        ' The backgound thread will check the status. If it is Pausing, the download
        ' will be paused and the status will be changed to Paused.
        Me.Status = HttpDownloadClientStatus.Pausing
    End Sub

    ''' <summary>
    ''' Resume the download.
    ''' </summary>
    Public Sub [Resume]()
        ' Only paused client can be resumed.
        If Me.Status <> HttpDownloadClientStatus.Paused Then
            Throw New ApplicationException("Only paused client can be resumed.")
        End If

        ' Start to download in a background thread.
        BeginDownload()
    End Sub

    ''' <summary>
    ''' Cancel the download
    ''' </summary>
    Public Sub Cancel()
        ' Only a downloading or paused client can be canceled.
        If Me.Status <> HttpDownloadClientStatus.Paused _
            AndAlso Me.Status <> HttpDownloadClientStatus.Downloading Then
            Throw New ApplicationException("Only a downloading or paused client" _
                                           & " can be canceled.")
        End If

        ' The backgound thread will check the status. If it is Canceling, the download
        ' will be canceled and the status will be changed to Canceled.
        Me.Status = HttpDownloadClientStatus.Canceling
    End Sub

    ''' <summary>
    ''' Create a thread to download data.
    ''' </summary>
    Private Sub BeginDownload()
        Dim threadStart_Renamed As New ThreadStart(AddressOf Download)
        Dim downloadThread As New Thread(threadStart_Renamed)
        downloadThread.IsBackground = True
        downloadThread.Start()
    End Sub

    ''' <summary>
    ''' Download the data using HttpWebRequest. It will read a buffer of bytes from the
    ''' response stream, and store the buffer to a MemoryStream cache first.
    ''' If the cache is full, or the download is paused, canceled or completed, write
    ''' the data in cache to local file.
    ''' </summary>
    Private Sub Download()
        Dim request As HttpWebRequest = Nothing
        Dim response As HttpWebResponse = Nothing
        Dim responseStream As Stream = Nothing
        Dim downloadCache As MemoryStream = Nothing
        _lastStartTime = Date.Now

        ' Set the status.
        Me.Status = HttpDownloadClientStatus.Downloading

        Try

            ' Create a request to the file to be  downloaded.
            request = CType(WebRequest.Create(Url), HttpWebRequest)
            request.Method = "GET"
            request.Credentials = CredentialCache.DefaultCredentials


            ' Specify the block to download.
            If EndPoint <> Integer.MaxValue Then
                request.AddRange(CInt(StartPoint + DownloadedSize), EndPoint)
            Else
                request.AddRange(CInt(StartPoint + DownloadedSize))
            End If

            ' Retrieve the response from the server and get the response stream.
            response = CType(request.GetResponse(), HttpWebResponse)

            responseStream = response.GetResponseStream()


            ' Cache data in memory.
            downloadCache = New MemoryStream(Me.MaxCacheSize)

            Dim downloadBuffer(Me.BufferSize - 1) As Byte

            Dim bytesSize As Integer = 0
            Dim cachedSize As Integer = 0
            Dim receivedBufferCount As Integer = 0

            ' Download the file until the download is paused, canceled or completed.
            Do

                ' Read a buffer of data from the stream.
                bytesSize = responseStream.Read(downloadBuffer, 0, downloadBuffer.Length)

                ' If the cache is full, or the download is paused, canceled or 
                ' completed, write the data in cache to local file.
                If Me.Status <> HttpDownloadClientStatus.Downloading OrElse bytesSize = 0 _
                    OrElse Me.MaxCacheSize < cachedSize + bytesSize Then

                    Try
                        ' Write the data in cache to local file.
                        WriteCacheToFile(downloadCache, cachedSize)

                        Me.DownloadedSize += cachedSize

                        ' Stop downloading the file if the download is paused, 
                        ' canceled or completed. 
                        If Me.Status <> HttpDownloadClientStatus.Downloading _
                            OrElse bytesSize = 0 Then
                            Exit Do
                        End If

                        ' Reset cache.
                        downloadCache.Seek(0, SeekOrigin.Begin)
                        cachedSize = 0
                    Catch ex As Exception
                        ' Fire the DownloadCompleted event with the error.
                        Me.OnDownloadCompleted( _
                            New HttpDownloadCompletedEventArgs(Me.DownloadedSize, _
                                                               Me.TotalSize, _
                                                               Me.TotalUsedTime, _
                                                               ex))
                        Return
                    End Try

                End If


                ' Write the data from the buffer to the cache in memory.
                downloadCache.Write(downloadBuffer, 0, bytesSize)

                cachedSize += bytesSize

                receivedBufferCount += 1

                ' Fire the DownloadProgressChanged event.
                If receivedBufferCount = Me._bufferCountPerNotification Then
                    InternalDownloadProgressChanged(cachedSize)
                    receivedBufferCount = 0
                End If
            Loop


            ' Update the used time when the current doanload is stopped.
            _usedTime = _usedTime.Add(Date.Now.Subtract(_lastStartTime))

            ' Update the status of the client. Above loop will be stopped when the 
            ' status of the client is pausing, canceling or completed.
            If Me.Status = HttpDownloadClientStatus.Pausing Then
                Me.Status = HttpDownloadClientStatus.Paused
            ElseIf Me.Status = HttpDownloadClientStatus.Canceling Then
                Me.Status = HttpDownloadClientStatus.Canceled

                Dim ex As New Exception("Downloading is canceled by user's request. ")

                Me.OnDownloadCompleted( _
                    New HttpDownloadCompletedEventArgs(Me.DownloadedSize, Me.TotalSize, _
                                                       Me.TotalUsedTime, ex))
            Else
                Me.Status = HttpDownloadClientStatus.Completed
                Me.OnDownloadCompleted( _
                    New HttpDownloadCompletedEventArgs(Me.DownloadedSize, Me.TotalSize, _
                                                       Me.TotalUsedTime, Nothing))
                Return
            End If

        Finally
            ' When the above code has ended, close the streams.
            If responseStream IsNot Nothing Then
                responseStream.Close()
            End If
            If response IsNot Nothing Then
                response.Close()
            End If
            If downloadCache IsNot Nothing Then
                downloadCache.Close()
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Check whether the destination file exists. If  not, create a file with the same
    ''' size as the file to be downloaded.
    ''' </summary>
    Private Sub CheckFileOrCreateFile()
        ' Lock other threads or processes to prevent from creating the file.
        SyncLock _locker
            Dim fileToDownload As New FileInfo(DownloadPath)
            If fileToDownload.Exists Then

                ' The destination file should have the same size as the file to be downloaded.
                If fileToDownload.Length <> Me.TotalSize Then
                    Throw New ApplicationException( _
                        "The download path already has a file which does not match" _
                        & " the file to download. ")
                End If

                ' Create a file.
            Else
                If TotalSize = 0 Then
                    Throw New ApplicationException("The file to download does not exist!")
                End If

                Using fileStream_Renamed As FileStream = File.Create(Me.DownloadPath)
                    Dim createdSize As Long = 0
                    Dim buffer(4095) As Byte
                    Do While createdSize < TotalSize
                        Dim bufferSize As Integer = If((TotalSize - createdSize) < 4096, _
                                                       CInt(Fix(TotalSize - createdSize)), _
                                                       4096)
                        fileStream_Renamed.Write(buffer, 0, BufferSize)
                        createdSize += BufferSize
                    Loop
                End Using
            End If
        End SyncLock
    End Sub

    ''' <summary>
    ''' Write the data in cache to local file.
    ''' </summary>
    Private Sub WriteCacheToFile(ByVal downloadCache As MemoryStream, _
                                 ByVal cachedSize As Integer)
        ' Lock other threads or processes to prevent from writing data to the file.
        SyncLock _locker
            Using fileStream_Renamed As New FileStream(DownloadPath, FileMode.Open)
                Dim cacheContent(cachedSize - 1) As Byte
                downloadCache.Seek(0, SeekOrigin.Begin)
                downloadCache.Read(cacheContent, 0, cachedSize)
                fileStream_Renamed.Seek(DownloadedSize + StartPoint, SeekOrigin.Begin)
                fileStream_Renamed.Write(cacheContent, 0, cachedSize)
            End Using
        End SyncLock
    End Sub


    Protected Overridable Sub OnDownloadCompleted(ByVal e As HttpDownloadCompletedEventArgs)
        RaiseEvent DownloadCompleted(Me, e)
    End Sub

    ''' <summary>
    ''' Calculate the download speed and fire the  DownloadProgressChanged event.
    ''' </summary>
    ''' <param name="cachedSize"></param>
    Private Sub InternalDownloadProgressChanged(ByVal cachedSize As Integer)
        Dim speed As Integer = 0
        Dim current As Date = Date.Now
        Dim interval As TimeSpan = current.Subtract(_lastNotificationTime)

        If interval.TotalSeconds < 60 Then
            speed = CInt(Fix(Math.Floor((Me.DownloadedSize + cachedSize - _
                     Me._lastNotificationDownloadedSize) / interval.TotalSeconds)))
        End If
        _lastNotificationTime = current
        _lastNotificationDownloadedSize = Me.DownloadedSize + cachedSize

        Me.OnDownloadProgressChanged( _
            New HttpDownloadProgressChangedEventArgs(Me.DownloadedSize + cachedSize, _
                                                    Me.TotalSize, speed))


    End Sub

    Protected Overridable Sub OnDownloadProgressChanged(ByVal e As HttpDownloadProgressChangedEventArgs)
        RaiseEvent DownloadProgressChanged(Me, e)
    End Sub

    Protected Overridable Sub OnStatusChanged(ByVal e As EventArgs)
        RaiseEvent StatusChanged(Me, e)
    End Sub
End Class

