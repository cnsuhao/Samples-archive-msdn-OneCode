'****************************** Module Header ******************************\
' Module Name:  AudioPlayer.vb
' Project:      VBWP8BackgroundMusic
' Copyright (c) Microsoft Corporation
'
' This is the AudioPlayerAgent.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Imports System
Imports System.Diagnostics
Imports System.Windows
Imports Microsoft.Phone.BackgroundAudio
Imports System.Collections.Generic

Public Class AudioPlayer
    Inherits AudioPlayerAgent

    ' Flag for Initialized.
    Private Shared isInitialized As Boolean
    ' Index of current track.
    Shared currentTrackNumber As Integer = 0
    ' A playlist made up of AudioTrack items.
    Private Shared playList As New List(Of AudioTrack)()
    ' Current AudioTrack.
    Shared currentTrack As AudioTrack = Nothing

    ''' <remarks>
    ''' AudioPlayer instances can share the same process.
    ''' Static fields can be used to share state between AudioPlayer instances
    ''' or to communicate with the Audio Streaming agent.
    ''' </remarks>
    Shared Sub New()
        '#Region "Test data"
        Dim audioTrack As AudioTrack = Nothing
        For i As Integer = 1 To 2
            audioTrack = New AudioTrack(New Uri("Ring0" & i & ".wma", UriKind.Relative), "Ringtone " & i, "Windows Phone",
                                        "Windows Phone Ringtones", Nothing)

            playList.Add(audioTrack)
        Next

        ' A remote URI
        audioTrack = New AudioTrack(New Uri("http://traffic.libsyn.com/wpradio/WPRadio_29.mp3", UriKind.Absolute),
                        "Episode 29",
                        "Windows Phone Radio",
                        "Windows Phone Radio Podcast",
                        New Uri("shared/media/Episode29.jpg", UriKind.Relative))
        playList.Add(audioTrack)
        '#End Region

        If Not isInitialized Then
            isInitialized = True

            ' Subscribe to the managed exception handler
            Deployment.Current.Dispatcher.BeginInvoke(
            Sub()
                AddHandler Application.Current.UnhandledException, AddressOf UnhandledException
            End Sub)
        End If
    End Sub

    ' Code to execute on Unhandled Exceptions
    Private Shared Sub UnhandledException(ByVal sender As Object, ByVal e As ApplicationUnhandledExceptionEventArgs)

        If Debugger.IsAttached Then
            ' An unhandled exception has occurred break into the debugger
            Debugger.Break()
        End If

    End Sub

    ''' <summary>
    ''' Called when the playstate changes, except for the Error state (see OnError)
    ''' </summary>
    ''' <param name="player">The BackgroundAudioPlayer</param>
    ''' <param name="track">The track playing at the time the playstate changed</param>
    ''' <param name="playState">The new playstate of the player</param>
    ''' <remarks>
    ''' Play State changes cannot be cancelled. They are raised even if the application
    ''' caused the state change itself, assuming the application has opted-in to the callback.
    '''
    ''' Notable playstate events:
    ''' (a) TrackEnded: invoked when the player has no current track. The agent can set the next track.
    ''' (b) TrackReady: an audio track has been set and it is now ready for playack.
    '''
    ''' Call NotifyComplete() only once, after the agent request has been completed, including async callbacks.
    ''' </remarks>
    Protected Overrides Sub OnPlayStateChanged(ByVal player As BackgroundAudioPlayer, ByVal track As AudioTrack, ByVal playState As PlayState)

        Select Case (playState)

            Case playState.TrackEnded
                ' Set cycle.
                SetStopToPlay(player)
                ' Set current Track.
                currentTrack = GetNextTrack()
                ' Play Track.
                PlayTrack(player)
            Case playState.TrackReady
                player.Play()
            Case playState.Shutdown
                ' TODO: Handle the shutdown state here (e.g. save state)
            Case playState.Unknown
            Case playState.Stopped
                ' Set cycle.
                SetStopToPlay(player)
            Case playState.Paused
            Case playState.Playing
            Case playState.BufferingStarted
            Case playState.BufferingStopped
            Case playState.Rewinding
            Case playState.FastForwarding
        End Select

        NotifyComplete()

    End Sub

    ''' <summary>
    ''' Called when the user requests an action using application/system provided UI
    ''' </summary>
    ''' <param name="player">The BackgroundAudioPlayer</param>
    ''' <param name="track">The track playing at the time of the user action</param>
    ''' <param name="action">The action the user has requested</param>
    ''' <param name="param">The data associated with the requested action.
    ''' In the current version this parameter is only for use with the Seek action,
    ''' to indicate the requested position of an audio track</param>
    ''' <remarks>
    ''' User actions do not automatically make any changes in system state the agent is responsible
    ''' for carrying out the user actions if they are supported.
    '''
    ''' Call NotifyComplete() only once, after the agent request has been completed, including async callbacks.
    ''' </remarks>
    Protected Overrides Sub OnUserAction(ByVal player As BackgroundAudioPlayer, ByVal track As AudioTrack, ByVal action As UserAction, ByVal param As Object)

        Select Case (action)
            Case UserAction.Play
                ' Set current Track.
                currentTrack = playList(currentTrackNumber)
                ' Play Track.
                PlayTrack(player)
            Case UserAction.Stop
                player.Stop()
            Case UserAction.Pause
                player.Pause()
            Case UserAction.FastForward
                player.FastForward()
            Case UserAction.Rewind
                player.Rewind()
            Case UserAction.Seek
                player.Position = param
            Case UserAction.SkipNext
                ' Set current Track.
                currentTrack = GetNextTrack()
                ' Play Track.
                PlayTrack(player)
            Case UserAction.SkipPrevious
                ' Set current Track.
                currentTrack = GetPreviousTrack()
                ' Play Track.
                PlayTrack(player)
        End Select

        NotifyComplete()
    End Sub

    ''' <summary>
    ''' Implements the logic to get the next AudioTrack instance.
    ''' In a playlist, the source can be from a file, a web request, etc.
    ''' </summary>
    ''' <remarks>
    ''' The AudioTrack URI determines the source, which can be:
    ''' (a) Isolated-storage file (Relative URI, represents path in the isolated storage)
    ''' (b) HTTP URL (absolute URI)
    ''' (c) MediaStreamSource (null)
    ''' </remarks>
    ''' <returns>an instance of AudioTrack, or null if the playback is completed</returns>
    Private Function GetNextTrack() As AudioTrack
        Dim track As AudioTrack = Nothing

        ' Specify the Track.
        If System.Threading.Interlocked.Increment(currentTrackNumber) >= playList.Count Then
            currentTrackNumber = 0
        End If

        track = playList(currentTrackNumber)
        Return track

    End Function

    ''' <summary>
    ''' Implements the logic to get the previous AudioTrack instance.
    ''' </summary>
    ''' <remarks>
    ''' The AudioTrack URI determines the source, which can be:
    ''' (a) Isolated-storage file (Relative URI, represents path in the isolated storage)
    ''' (b) HTTP URL (absolute URI)
    ''' (c) MediaStreamSource (null)
    ''' </remarks>
    ''' <returns>an instance of AudioTrack, or null if previous track is not allowed</returns>
    Private Function GetPreviousTrack() As AudioTrack
        Dim track As AudioTrack = Nothing

        ' Specify the Track.
        If System.Threading.Interlocked.Decrement(currentTrackNumber) < 0 Then
            currentTrackNumber = playList.Count - 1
        End If

        track = playList(currentTrackNumber)
        Return track

    End Function

    ''' <summary>
    ''' Called whenever there is an error with playback, such as an AudioTrack not downloading correctly
    ''' </summary>
    ''' <param name="player">The BackgroundAudioPlayer</param>
    ''' <param name="track">The track that had the error</param>
    ''' <param name="error">The error that occured</param>
    ''' <param name="isFatal">If true, playback cannot continue and playback of the track will stop</param>
    ''' <remarks>
    ''' This method is not guaranteed to be called in all cases. For example, if the background agent
    ''' itself has an unhandled exception, it won't get called back to handle its own errors.
    ''' </remarks>
    Protected Overrides Sub OnError(player As Microsoft.Phone.BackgroundAudio.BackgroundAudioPlayer, track As Microsoft.Phone.BackgroundAudio.AudioTrack, [error] As System.Exception, isFatal As Boolean)
        If isFatal Then
            Abort()
        Else
            NotifyComplete()
        End If
    End Sub

    ''' <summary>
    ''' Called when the agent request is getting cancelled
    ''' </summary>
    ''' <remarks>
    ''' Once the request is Cancelled, the agent gets 5 seconds to finish its work,
    ''' by calling NotifyComplete()/Abort().
    ''' </remarks>
    Protected Overrides Sub OnCancel()
    End Sub

    ''' <summary>
    ''' Play Trace
    ''' </summary>
    ''' <param name="player">The BackgroundAudioPlayer</param>
    Private Shared Sub PlayTrack(player As BackgroundAudioPlayer)
        If currentTrack IsNot Nothing Then
            If player.PlayerState = PlayState.Paused Then
                player.Play()
            Else
                player.Track = currentTrack
            End If
        End If
    End Sub

    ''' <summary>  
    ''' This method will achieve loop playback.
    ''' Check the Current State of the BackgroundAudioPlayer before allowing Play to be called.
    ''' And Plays the track in our playlist at the currentTrackNumber position.
    ''' </summary>
    ''' <param name="player">The BackgroundAudioPlayer</param>      
    Private Shared Sub SetStopToPlay(player As BackgroundAudioPlayer)
        If player.PlayerState <> PlayState.Playing Then
            player.[Stop]()
            player.Play()
        End If
    End Sub

End Class