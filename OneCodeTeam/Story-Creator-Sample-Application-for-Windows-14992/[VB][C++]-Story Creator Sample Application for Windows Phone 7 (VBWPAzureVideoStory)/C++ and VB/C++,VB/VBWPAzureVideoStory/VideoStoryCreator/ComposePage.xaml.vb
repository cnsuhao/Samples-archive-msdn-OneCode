'********************************* Module Header *********************************\
' Module Name: ComposePage.xaml.vb
' Project: VideoStoryCreator
' Copyright (c) Microsoft Corporation.
' 
' The page used to compose the story.
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

<CLSCompliant(False)> _
Partial Public Class ComposePage
    Inherits PhoneApplicationPage
    Private _photoDataSource As ObservableCollection(Of ComposePhotoViewModel)
    Private _viewModelBackup As ComposePhotoViewModel
    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnNavigatedTo(e As System.Windows.Navigation.NavigationEventArgs)
        ' Prepare the data source.
        Me._photoDataSource = New ObservableCollection(Of ComposePhotoViewModel)()
        Me.nameTextBox.Text = App.CurrentStoryName
        For Each photo As Photo In App.MediaCollection
            _photoDataSource.Add(ComposePhotoViewModel.CreateFromModel(photo))
        Next
        Me.photoListBox.ItemsSource = Me._photoDataSource

        MyBase.OnNavigatedTo(e)
    End Sub

    Protected Overrides Sub OnNavigatedFrom(e As System.Windows.Navigation.NavigationEventArgs)
        Me.UpdateModels()
        MyBase.OnNavigatedFrom(e)
    End Sub

    ''' <summary>
    ''' The controls are bound to view model.
    ''' So we need to explicitly update the underlying model when needed.
    ''' </summary>
    Private Sub UpdateModels()
        For Each viewModel As ComposePhotoViewModel In Me._photoDataSource
            viewModel.UpdateModel()
        Next
    End Sub

    Private Sub PreviewButton_Click(sender As Object, e As System.EventArgs)
        Me.NavigationService.Navigate(New Uri("/PreviewPage.xaml", UriKind.Relative))
    End Sub

    Private Sub EditPhotoButton_Click(sender As Object, e As System.EventArgs)
        If Me.photoListBox.SelectedItem IsNot Nothing AndAlso TypeOf Me.photoListBox.SelectedItem Is ComposePhotoViewModel Then
            Me.photoListBox.IsEnabled = False

            ' Backup a copy of the view model, so we can cancel the update operation.
            Me._viewModelBackup = DirectCast(Me.photoListBox.SelectedItem, ComposePhotoViewModel).CopyTo()
            Me.ShowEditPanelStoryboard.Begin()
        End If
    End Sub

    Private Sub OKButton_Click(sender As Object, e As System.Windows.RoutedEventArgs)
        Me.photoListBox.IsEnabled = True
        Me.CloseEditPanelStoryboard.Begin()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As System.Windows.RoutedEventArgs)
        ' Restore the view model backup.
        If Me._viewModelBackup IsNot Nothing Then
            DirectCast(Me.photoListBox.SelectedItem, ComposePhotoViewModel).CopyFrom(Me._viewModelBackup)
        End If
        Me.photoListBox.IsEnabled = True
        Me.CloseEditPanelStoryboard.Begin()
    End Sub

    Private Sub AddPhotoButton_Click(sender As Object, e As System.EventArgs)
        Me.NavigationService.Navigate(New Uri("/ChooseMediaPage.xaml", UriKind.Relative))
    End Sub

    Private Sub RemovePhotoButton_Click(sender As Object, e As System.EventArgs)
        ' Remove the selected item, and close the corresponding stream.
        If Me.photoListBox.SelectedItem IsNot Nothing AndAlso TypeOf Me.photoListBox.SelectedItem Is ComposePhotoViewModel Then
            Dim photo As ComposePhotoViewModel = DirectCast(Me.photoListBox.SelectedItem, ComposePhotoViewModel)
            photo.MediaStream.Close()
            Me._photoDataSource.Remove(photo)
            photo.RemoveModel()
        End If
    End Sub

    Private Sub nameTextBox_LostFocus(sender As Object, e As System.Windows.RoutedEventArgs)
        ' Update the story name.
        If App.CurrentStoryName <> Me.nameTextBox.Text AndAlso Me.nameTextBox.Text IsNot Nothing Then
            If IsolatedStorageHelper.FileExists(Convert.ToString(Me.nameTextBox.Text) & ".xml") Then
                If MessageBox.Show("A story with the same name already exists. Do you want to override it?", "Confirm", MessageBoxButton.OKCancel) = MessageBoxResult.OK Then
                    Me.RenameStory()
                Else
                    ' Revert to the old name.
                    Me.nameTextBox.Text = App.CurrentStoryName
                End If
            Else
                Me.RenameStory()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Rename the story.
    ''' </summary>
    Private Sub RenameStory()
        IsolatedStorageHelper.RenameFile(App.CurrentStoryName + ".xml", Convert.ToString(Me.nameTextBox.Text) & ".xml")
        App.CurrentStoryName = Me.nameTextBox.Text
    End Sub

    Private Sub UploadButton_Click(sender As Object, e As EventArgs)
        ' Make sure we're using the latest data.
        Me.UpdateModels()
        Dim locator As New StoryServiceLocator()
        AddHandler locator.StoryUploaded, AddressOf locator_StoryUploaded
        locator.UploadStory()
    End Sub

    Private Sub locator_StoryUploaded(sender As Object, e As EventArgs)
        Me.Dispatcher.BeginInvoke(Sub()
                                      MessageBox.Show("Story successfully uploaded to the cloud.")

                                  End Sub)
    End Sub

    Private Sub TransitionList_SelectionChanged(sender As Object, e As System.Windows.Controls.SelectionChangedEventArgs)
        If Me.photoListBox.SelectedItem IsNot Nothing AndAlso TypeOf Me.photoListBox.SelectedItem Is ComposePhotoViewModel Then
            ' Update the designer to show additional controls for the selected transition.
            ' The UI is a ContentControl whose Content is bound to the view model's TransitionDesigner property.
            Dim photo As ComposePhotoViewModel = DirectCast(Me.photoListBox.SelectedItem, ComposePhotoViewModel)
            photo.TransitionDesigner = TransitionFactory.CreateTransitionDesigner(Me.transitionList.SelectedItem.ToString())
        End If
    End Sub

    Private Sub HomeButton_Click(sender As Object, e As EventArgs)
        Me.NavigationService.Navigate(New Uri("/MainPage.xaml", UriKind.Relative))
    End Sub
End Class
