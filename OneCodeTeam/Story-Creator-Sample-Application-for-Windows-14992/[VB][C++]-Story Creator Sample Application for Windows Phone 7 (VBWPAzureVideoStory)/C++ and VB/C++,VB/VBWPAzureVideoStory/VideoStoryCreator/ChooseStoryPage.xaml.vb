'********************************* Module Header *********************************\
' Module Name: ChooseStoryPage.xaml.vb
' Project: VideoStoryCreator
' Copyright (c) Microsoft Corporation.
' 
' The page that allows user to open an existing story.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/




<CLSCompliant(False)> _
Partial Public Class ChooseStoryPage
    Inherits PhoneApplicationPage

    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnNavigatedTo(e As System.Windows.Navigation.NavigationEventArgs)
        Me.StoryListBox.ItemsSource = PersistenceHelper.EnumerateStories()
        MyBase.OnNavigatedTo(e)
    End Sub

    Private Sub OKButton_Click(sender As Object, e As System.Windows.RoutedEventArgs)
        If Me.StoryListBox.SelectedItem IsNot Nothing OrElse TypeOf Me.StoryListBox.SelectedItem Is String Then
            Dim storyName As String = DirectCast(Me.StoryListBox.SelectedItem, String)
            Try
                ' Clear any in-memory data.
                For Each photo In App.MediaCollection
                    photo.ThumbnailStream.Close()
                Next
                App.MediaCollection.Clear()
                App.CurrentStoryName = storyName
                PersistenceHelper.ReadStoryFile(storyName)
                Me.NavigationService.Navigate(New Uri("/ComposePage.xaml", UriKind.Relative))
            Catch
                MessageBox.Show("Unable to load the story. The file is likely to be cruppted.")
            End Try
        End If
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As System.Windows.RoutedEventArgs)
        Me.NavigationService.Navigate(New Uri("/MainPage.xaml", UriKind.Relative))
    End Sub
End Class
