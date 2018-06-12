'****************************** Module Header ******************************\
' Module Name:    SongEdit.xaml.vb
' Project:        VBWP8MedialibrarySong
' Copyright (c) Microsoft Corporation
'
' This sample will show you how to list songs and read/write their properties 
' in Windows Phone app.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports Microsoft.Xna.Framework.Media.PhoneExtensions
Imports Microsoft.Xna.Framework.Media

Partial Public Class SongEdit
    Inherits PhoneApplicationPage
    ''' <summary>
    ''' MediaLibrary
    ''' </summary>
    Private ml As New MediaLibrary()
    Private currentSong As Song = Nothing
    Private strSongName As String

    Public Sub New()
        InitializeComponent()

        AddHandler Loaded, AddressOf SongEdit_Loaded
    End Sub

    Private Sub SongEdit_Loaded(sender As Object, e As RoutedEventArgs)
        currentSong = (From m In ml.Songs Where m.Name.Contains(strSongName)).First()
        Me.DataContext = currentSong
    End Sub

    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        If NavigationContext.QueryString.Keys.Contains("SongName") Then
            strSongName = NavigationContext.QueryString("SongName")
        End If

        MyBase.OnNavigatedTo(e)
    End Sub

    Protected Overrides Sub OnNavigatedFrom(e As NavigationEventArgs)
        strSongName = Nothing
        MyBase.OnNavigatedFrom(e)
    End Sub

    ''' <summary>
    ''' Save the new SongMetadata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AppSaveBar_Click(sender As Object, e As EventArgs)
        ' Uri for current song.
        Dim songUri As Uri = Nothing

        Dim metaData As New SongMetadata()
        metaData.Name = tbName.Text.Trim().ToString()
        metaData.AlbumName = tbAlbumName.Text.Trim().ToString()
        metaData.ArtistName = tbArtistName.Text.Trim().ToString()
        metaData.GenreName = "test"

        For Each item As MySong In App.listMySong
            If currentSong.Name.Equals(item.song.Name) Then
                songUri = item.FilePath
            End If
        Next

        ' The identity of whether to delete , to avoid duplication.
        Dim isToDelete As Boolean = True

        If songUri IsNot Nothing Then
            Try
                MediaLibraryExtensions.Delete(ml, currentSong)
            Catch ex As Exception
                If ex.Message.Equals("The user declined the delete request.") Then
                    isToDelete = False
                End If
            Finally
                If isToDelete Then
                    Dim song = MediaLibraryExtensions.SaveSong(ml, songUri, metaData, SaveSongOperation.CopyToLibrary)
                End If
            End Try
        End If

        NavigationService.Navigate(New Uri("/MainPage.xaml", UriKind.Relative))
    End Sub
End Class

