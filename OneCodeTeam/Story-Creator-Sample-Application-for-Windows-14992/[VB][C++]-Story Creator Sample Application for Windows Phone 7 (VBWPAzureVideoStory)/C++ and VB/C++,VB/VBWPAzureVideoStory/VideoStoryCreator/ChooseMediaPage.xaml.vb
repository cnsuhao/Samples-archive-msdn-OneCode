'********************************* Module Header *********************************\
' Module Name: ChooseMediaPage.xaml.vb
' Project: VideoStoryCreator
' Copyright (c) Microsoft Corporation.
' 
' This page allows the user to choose photos.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.Collections.ObjectModel
Imports Microsoft.Xna.Framework.Media
Imports System.IO

<CLSCompliant(False)> _
Partial Public Class ChooseMediaPage
    Inherits PhoneApplicationPage
    Private _photoDataSource As ObservableCollection(Of ChoosePhotoViewModel)
    Private _selectedPhotos As List(Of ChoosePhotoViewModel)
    Private _currentPage As Integer = 0

    ''' <summary>
    ''' TODO: Design consideration: Currently hard code 20.
    ''' Should we move all hard coded value to a single place,
    ''' so in the future, it will be easier to support user configuration?
    ''' </summary>
    Private _pageSize As Integer = 20

    Public Sub New()
        InitializeComponent()

        Me._photoDataSource = New ObservableCollection(Of ChoosePhotoViewModel)()
        Me._selectedPhotos = New List(Of ChoosePhotoViewModel)()
        Me.GetPicturesForCurrentPage()
        Me.MediaListBox.ItemsSource = _photoDataSource
    End Sub


    ''' <summary>
    ''' It's not a good idea to display all photos at once.
    ''' This method implements paging.
    ''' TODO: Design consideration: Should we create a helper class to interact with media library
    ''' instead of putting the code in code behind for a XAML page?
    ''' </summary>
    Private Sub GetPicturesForCurrentPage()
        ' Page number should not be less than 0.
        If Me._currentPage < 0 Then
            Me._currentPage = 0
            Return
        End If

        Dim mediaLibrary As New MediaLibrary()

        ' Already the last page.
        Dim pageCount As Integer = mediaLibrary.Pictures.Count / Me._pageSize
        If Me._currentPage > pageCount Then
            Me._currentPage = pageCount
            Return
        End If

        ' Store the selection.
        Me.StoreSelection()

        ' Reset the data source.
        Me._photoDataSource.Clear()

        Dim picturesOnCurrentPage = mediaLibrary.Pictures.Skip(Me._currentPage * Me._pageSize).Take(Me._pageSize)
        For Each picture In picturesOnCurrentPage
            Dim pictureStream As Stream = picture.GetThumbnail()
            Dim viewModel As New ChoosePhotoViewModel() With { _
              .Name = picture.Name, _
              .MediaStream = pictureStream _
            }

            ' In PhotoViewModel, we override Equals to compare the name of the photo rather than the reference.
            ' So if a photo with the same name is found in selected photos, Contains will return true.
            If Me._selectedPhotos.Contains(viewModel) Then
                viewModel.IsSelected = True
            End If

            _photoDataSource.Add(viewModel)
        Next
    End Sub

    ''' <summary>
    ''' Add selected photos on the current page to selected photo list,
    ''' and close unselected photos.
    ''' </summary>
    Private Sub StoreSelection()
        For Each photo As ChoosePhotoViewModel In Me._photoDataSource
            If photo.IsSelected AndAlso Not Me._selectedPhotos.Contains(photo) Then
                Me._selectedPhotos.Add(photo)
            Else
                ' If the media is not chosen, close the thumbnail stream.
                photo.MediaStream.Close()
            End If
        Next
    End Sub

    Private Sub OKButton_Click(sender As Object, e As System.EventArgs)
        Me.StoreSelection()

        ' Add all selected photos to App.MediaCollection.
        For Each photo As ChoosePhotoViewModel In Me._selectedPhotos
            Dim photoModel As New Photo() With { _
              .Name = photo.Name, _
              .ThumbnailStream = photo.MediaStream, _
              .PhotoDuration = TimeSpan.FromSeconds(5.0), _
              .Transition = TransitionFactory.CreateDefaultTransition() _
            }
            If Not App.MediaCollection.Contains(photoModel) Then
                App.MediaCollection.Add(photoModel)
            End If
        Next

        ' Go back to the calling page.
        Me.NavigationService.GoBack()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As System.EventArgs)
        ' Close all thumbnail streams.
        For Each photo As ChoosePhotoViewModel In Me._photoDataSource
            photo.MediaStream.Close()
        Next

        ' Go back to the calling page without doing anything.
        Me.NavigationService.GoBack()
    End Sub

    Private Sub PreviousPageButton_Click(sender As Object, e As System.EventArgs)
        Me._currentPage -= 1
        Me.GetPicturesForCurrentPage()
    End Sub

    Private Sub NextPageButton_Click(sender As Object, e As System.EventArgs)
        Me._currentPage += 1
        Me.GetPicturesForCurrentPage()
    End Sub
End Class
