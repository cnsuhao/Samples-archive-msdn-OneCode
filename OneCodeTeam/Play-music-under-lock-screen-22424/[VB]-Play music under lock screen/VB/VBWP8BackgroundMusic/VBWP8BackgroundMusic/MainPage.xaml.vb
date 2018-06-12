'****************************** Module Header ******************************\
' Module Name:  MainPage.xaml.vb
' Project:      VBWP8BackgroundMusic
' Copyright (c) Microsoft Corporation
'
' This is the main page of this sample that illustrate how 
' to play audio under lock screen.
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
Imports System.Threading
Imports System.Windows.Controls
Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Shell
Imports Microsoft.Phone.BackgroundAudio

Partial Public Class MainPage
    Inherits PhoneApplicationPage
    ' Constructor
    Public Sub New()
        InitializeComponent()

        AddHandler BackgroundAudioPlayer.Instance.PlayStateChanged, New EventHandler(AddressOf Instance_PlayStateChanged)
    End Sub

    ''' <summary>
    ''' Checks to see if the BackgroundAudioPlayer is already playing.
    ''' Initializes the UI controls accordingly.
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        If PlayState.Playing = BackgroundAudioPlayer.Instance.PlayerState Then
            ' Change to pause button
            playButton.Content = "Pause"

            txtCurrentTrack.Text = BackgroundAudioPlayer.Instance.Track.Title + " by " + BackgroundAudioPlayer.Instance.Track.Artist
        Else
            ' Change to play button
            playButton.Content = "Play"
            txtCurrentTrack.Text = ""
        End If
    End Sub

    ''' <summary>
    ''' Updates the UI with the current song data.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Instance_PlayStateChanged(sender As Object, e As EventArgs)
        Select Case BackgroundAudioPlayer.Instance.PlayerState
            Case PlayState.Playing
                ' Change to pause button
                playButton.Content = "Pause"
                prevButton.IsEnabled = True
                nextButton.IsEnabled = True
                Exit Select

            Case PlayState.Paused, PlayState.Stopped
                ' Change to play button
                playButton.Content = "Play"
                Exit Select
        End Select

        If BackgroundAudioPlayer.Instance.Track IsNot Nothing Then
            txtCurrentTrack.Text = BackgroundAudioPlayer.Instance.Track.Title + " by " + BackgroundAudioPlayer.Instance.Track.Artist
        End If
    End Sub

#Region "Button Click Event Handlers"

    ''' <summary>
    ''' Tells the background audio agent to skip to the previous track.
    ''' </summary>
    ''' <param name="sender">The button</param>
    ''' <param name="e">Click event args</param>
    Private Sub prevButton_Click(sender As Object, e As RoutedEventArgs)
        BackgroundAudioPlayer.Instance.SkipPrevious()

        ' Prevent the user from repeatedly pressing the button and causing 
        ' a backlong of button presses to be handled. This button is re-eneabled 
        ' in the TrackReady Playstate handler.
        prevButton.IsEnabled = False
    End Sub


    ''' <summary>
    ''' Tells the background audio agent to play the current 
    ''' track or to pause if we're already playing.
    ''' </summary>
    ''' <param name="sender">The button</param>
    ''' <param name="e">Click event args</param>
    Private Sub playButton_Click(sender As Object, e As RoutedEventArgs)
        If PlayState.Playing = BackgroundAudioPlayer.Instance.PlayerState Then
            BackgroundAudioPlayer.Instance.Pause()
        Else
            BackgroundAudioPlayer.Instance.Play()
        End If

    End Sub

    ''' <summary>
    ''' Tells the background audio agent to skip to the next track.
    ''' </summary>
    ''' <param name="sender">The button</param>
    ''' <param name="e">Click event args</param>
    Private Sub nextButton_Click(sender As Object, e As RoutedEventArgs)
        BackgroundAudioPlayer.Instance.SkipNext()

        ' Prevent the user from repeatedly pressing the button and causing 
        ' a backlong of button presses to be handled. This button is re-eneabled 
        ' in the TrackReady Playstate handler.
        nextButton.IsEnabled = False
    End Sub

#End Region
End Class
