'***************************** Module Header ******************************\
' Module Name:    MainPage.xaml.vb
' Project:        VBWP8CameraFeedByteConverter
' Copyright (c) Microsoft Corporation
'
' This sample will demo how to convert live camera feed from Windows Phone
' to byte[] and then from byte[] to VideoBrush for rendering.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\****************************************************************************

Imports System.IO
Imports System.IO.IsolatedStorage
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Navigation
Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Shell

Partial Public Class MainPage
    Inherits PhoneApplicationPage
    ' Store video data for transfer.
    Private data As Byte()
    ' Use this video to initialize the VideoBrush which will be displayed the video from byte.
    Private strLocalName As String = "howto.wmv"
    ' Byte-generated video.
    Public strImageName As String = "test.wmv"

    ' Viewfinder for capturing video.
    Private videoRecorderBrush As VideoBrush

    ' Source and device for capturing video.
    Private captureSource As CaptureSource
    Private videoCaptureDevice As VideoCaptureDevice

    ' File details for storing the recording.        
    Private isoVideoFile As IsolatedStorageFileStream
    Private fileSink As FileSink
    Private isoVideoFileName As String = "CameraMovie.mp4"

    ' For managing button and application state.
    Private Enum ButtonState
        Initialized
        Ready
        Recording
        Playback
        Paused
        NoChange
        CameraNotSupported
    End Enum
    Private currentAppState As ButtonState

    ' Constructor
    Public Sub New()
        InitializeComponent()
        ' Initialize the VideoBrush which will be displayed the video from byte.
        myMediaElement.Source = New Uri(strLocalName, UriKind.Relative)
        ' Prepare ApplicationBar and buttons.
        PhoneAppBar = DirectCast(ApplicationBar, ApplicationBar)
        PhoneAppBar.IsVisible = True
        StartRecording = DirectCast(ApplicationBar.Buttons(0), ApplicationBarIconButton)
        StopPlaybackRecording = DirectCast(ApplicationBar.Buttons(1), ApplicationBarIconButton)
    End Sub

    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        MyBase.OnNavigatedTo(e)

        ' Initialize the video recorder.
        InitializeVideoRecorder()
    End Sub

    Protected Overrides Sub OnNavigatedFrom(e As NavigationEventArgs)
        ' Dispose of camera and media objects.
        DisposeVideoPlayer()
        DisposeVideoRecorder()

        MyBase.OnNavigatedFrom(e)
    End Sub

    ''' <summary>
    ''' Update the buttons and text on the UI thread based on app state.
    ''' </summary>
    ''' <param name="currentButtonState"></param>
    ''' <param name="statusMessage"></param>
    Private Sub UpdateUI(currentButtonState As ButtonState, statusMessage As String)
        ' Run code on the UI thread.
        Dispatcher.BeginInvoke(Sub()
                                   Select Case currentButtonState
                                       ' When the camera is not supported by the device.
                                       Case ButtonState.CameraNotSupported
                                           StartRecording.IsEnabled = False
                                           StopPlaybackRecording.IsEnabled = False
                                           Exit Select
                                           ' First launch of the application, so no video is available.
                                       Case ButtonState.Initialized
                                           StartRecording.IsEnabled = True
                                           StopPlaybackRecording.IsEnabled = False
                                           Exit Select
                                           ' Ready to record, so video is available for viewing.
                                       Case ButtonState.Ready
                                           StartRecording.IsEnabled = True
                                           StopPlaybackRecording.IsEnabled = False
                                           Exit Select
                                           ' Video recording is in progress.
                                       Case ButtonState.Recording
                                           StartRecording.IsEnabled = False
                                           StopPlaybackRecording.IsEnabled = True
                                           Exit Select
                                           ' Video playback is in progress.
                                       Case ButtonState.Playback
                                           StartRecording.IsEnabled = False
                                           StopPlaybackRecording.IsEnabled = True
                                           Exit Select
                                           ' Video playback has been paused.
                                       Case ButtonState.Paused
                                           StartRecording.IsEnabled = False
                                           StopPlaybackRecording.IsEnabled = True
                                           Exit Select
                                       Case Else
                                           Exit Select
                                   End Select

                                   ' Display a message.
                                   txtDebug.Text = statusMessage

                                   ' Note the current application state.
                                   currentAppState = currentButtonState

                               End Sub)
    End Sub

    ''' <summary>
    ''' Initialize the video recorder.
    ''' </summary>
    Public Sub InitializeVideoRecorder()
        If captureSource Is Nothing Then
            ' Create the VideoRecorder objects.
            captureSource = New CaptureSource()
            fileSink = New FileSink()

            videoCaptureDevice = CaptureDeviceConfiguration.GetDefaultVideoCaptureDevice()

            ' Add eventhandlers for captureSource.
            AddHandler captureSource.CaptureFailed, New EventHandler(Of ExceptionRoutedEventArgs)(AddressOf OnCaptureFailed)

            ' Initialize the camera if it exists on the device.
            If videoCaptureDevice IsNot Nothing Then
                ' Create the VideoBrush for the viewfinder.
                videoRecorderBrush = New VideoBrush()
                videoRecorderBrush.SetSource(captureSource)

                ' Display the viewfinder image on the rectangle.
                viewfinderRectangle.Fill = videoRecorderBrush

                ' Start video capture and display it on the viewfinder.
                captureSource.Start()

                ' Set the button state and the message.
                UpdateUI(ButtonState.Initialized, "Tap record to start recording...")
            Else
                ' Disable buttons when the camera is not supported by the device.
                UpdateUI(ButtonState.CameraNotSupported, "A camera is not supported on this device.")
            End If
        End If
    End Sub

    ''' <summary>
    ''' Set recording state: start recording.
    ''' </summary> 
    Private Sub StartVideoRecording()
        Try
            ' Connect fileSink to captureSource.
            If captureSource.VideoCaptureDevice IsNot Nothing AndAlso captureSource.State = CaptureState.Started Then
                captureSource.[Stop]()

                ' Connect the input and output of fileSink.
                fileSink.CaptureSource = captureSource
                fileSink.IsolatedStorageFileName = isoVideoFileName
            End If

            ' Begin recording.
            If captureSource.VideoCaptureDevice IsNot Nothing AndAlso captureSource.State = CaptureState.Stopped Then
                captureSource.Start()
            End If

            ' Set the button states and the message.
            UpdateUI(ButtonState.Recording, "Recording...")

            ' If recording fails, display an error.
        Catch e As Exception
            Me.Dispatcher.BeginInvoke(Sub() txtDebug.Text = "ERROR: " & e.Message.ToString())
        End Try
    End Sub

    ''' <summary>
    ''' Set the recording state: stop recording.
    ''' </summary> 
    Private Sub StopVideoRecording()
        Try
            ' Stop recording.
            If captureSource.VideoCaptureDevice IsNot Nothing AndAlso captureSource.State = CaptureState.Started Then
                captureSource.[Stop]()

                isoVideoFile = New IsolatedStorageFileStream(isoVideoFileName, FileMode.Open, FileAccess.Read, IsolatedStorageFile.GetUserStoreForApplication())

                data = ReadFully(isoVideoFile)

                ' Disconnect fileSink.
                fileSink.CaptureSource = Nothing
                fileSink.IsolatedStorageFileName = Nothing

                ' Set the button states and the message.
                UpdateUI(ButtonState.NoChange, "Preparing viewfinder...")

                StartVideoPreview()
            End If
            ' If stop fails, display an error.
        Catch e As Exception
            Me.Dispatcher.BeginInvoke(Sub() txtDebug.Text = "ERROR: " & e.Message.ToString())
        End Try
    End Sub

    ''' <summary>
    ''' Set the recording state: display the video on the viewfinder.
    ''' </summary>
    Private Sub StartVideoPreview()
        Try
            ' Display the video on the viewfinder.
            If captureSource.VideoCaptureDevice IsNot Nothing AndAlso captureSource.State = CaptureState.Stopped Then
                ' Add captureSource to videoBrush.
                videoRecorderBrush.SetSource(captureSource)

                ' Add videoBrush to the visual tree.
                viewfinderRectangle.Fill = videoRecorderBrush

                captureSource.Start()

                ' Set the button states and the message.
                UpdateUI(ButtonState.Ready, "Ready to record.")
            End If
            ' If preview fails, display an error.
        Catch e As Exception
            Me.Dispatcher.BeginInvoke(Sub() txtDebug.Text = "ERROR: " & e.Message.ToString())
        End Try
    End Sub

    ''' <summary>
    ''' Start the video recording.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub StartRecording_Click(sender As Object, e As EventArgs)
        ' Avoid duplicate taps.
        StartRecording.IsEnabled = False

        StartVideoRecording()
    End Sub

    ''' <summary>
    ''' Handle stop requests.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub StopPlaybackRecording_Click(sender As Object, e As EventArgs)
        ' Avoid duplicate taps.
        StopPlaybackRecording.IsEnabled = False

        ' Stop during video recording.
        If currentAppState = ButtonState.Recording Then
            StopVideoRecording()

            ' Set the button state and the message.
            UpdateUI(ButtonState.NoChange, "Recording stopped.")
        Else

            ' Stop during video playback.
            ' Remove playback objects.
            DisposeVideoPlayer()

            StartVideoPreview()

            ' Set the button state and the message.
            UpdateUI(ButtonState.NoChange, "Playback stopped.")
        End If
    End Sub

    ''' <summary>
    ''' Remove playback objects.
    ''' </summary>
    Private Sub DisposeVideoPlayer()
        If VideoPlayer IsNot Nothing Then
            ' Stop the VideoPlayer MediaElement.
            VideoPlayer.[Stop]()

            ' Remove playback objects.
            VideoPlayer.Source = Nothing
            isoVideoFile = Nothing

            ' Remove the event handler.
            RemoveHandler VideoPlayer.MediaEnded, AddressOf VideoPlayerMediaEnded
        End If
    End Sub

    Private Sub DisposeVideoRecorder()
        If captureSource IsNot Nothing Then
            ' Stop captureSource if it is running.
            If captureSource.VideoCaptureDevice IsNot Nothing AndAlso captureSource.State = CaptureState.Started Then
                captureSource.[Stop]()
            End If

            ' Remove the event handlers for capturesource and the shutter button.
            RemoveHandler captureSource.CaptureFailed, AddressOf OnCaptureFailed

            ' Remove the video recording objects.
            captureSource = Nothing
            videoCaptureDevice = Nothing
            fileSink = Nothing
            videoRecorderBrush = Nothing
        End If
    End Sub

    ''' <summary>
    ''' If recording fails, display an error message.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param> 
    Private Sub OnCaptureFailed(sender As Object, e As ExceptionRoutedEventArgs)
        Me.Dispatcher.BeginInvoke(Sub() txtDebug.Text = "ERROR: " & e.ErrorException.Message.ToString())
    End Sub

    ''' <summary>
    ''' Display the viewfinder when playback ends.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Sub VideoPlayerMediaEnded(sender As Object, e As RoutedEventArgs)
        ' Remove the playback objects.
        DisposeVideoPlayer()

        StartVideoPreview()
    End Sub

    ''' <summary>
    ''' Stream to byte.
    ''' </summary>
    ''' <param name="input"></param>
    ''' <returns></returns>
    Public Shared Function ReadFully(input As Stream) As Byte()
        Dim buffer As Byte() = New Byte(input.Length - 1) {}

        Using ms As New MemoryStream()
            Dim read As Integer
            While (InlineAssignHelper(read, input.Read(buffer, 0, buffer.Length))) > 0
                ms.Write(buffer, 0, read)
            End While
            Return ms.ToArray()
        End Using
    End Function

    ''' <summary>
    ''' Handle btnUse's click event. We will use the acquired data to create a video
    ''' then associated it with VideoBrush.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnUse_Click(sender As Object, e As RoutedEventArgs)
        Using iso As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
            If iso.FileExists(strImageName) Then
                iso.DeleteFile(strImageName)
            End If

            Using isostream As IsolatedStorageFileStream = iso.CreateFile(strImageName)
                isostream.Write(data, 0, data.Length)
                isostream.Close()
            End Using
        End Using

        ' Create the file stream and attach it to the MediaElement.
        isoVideoFile = New IsolatedStorageFileStream(strImageName, FileMode.Open, FileAccess.Read, IsolatedStorageFile.GetUserStoreForApplication())

        myMediaElement.SetSource(isoVideoFile)
    End Sub

    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function
End Class

