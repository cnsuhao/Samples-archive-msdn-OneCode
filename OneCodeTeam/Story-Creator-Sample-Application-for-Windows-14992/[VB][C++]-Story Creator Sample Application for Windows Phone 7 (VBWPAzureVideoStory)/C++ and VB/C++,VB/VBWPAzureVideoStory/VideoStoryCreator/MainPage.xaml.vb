'********************************* Module Header *********************************\
' Module Name: MainPage.xaml.vb
' Project: VideoStoryCreator
' Copyright (c) Microsoft Corporation.
' 
' The main page. It contains buttons that link to other pages.
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
Partial Public Class MainPage
    Inherits PhoneApplicationPage

    ' Constructor
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub NewStoryButton_Click(sender As Object, e As System.Windows.RoutedEventArgs)
        If MessageBox.Show("If you begin a new story, unsaved progress in the current story may be lost. Do you wish to continue?", "Confirm", MessageBoxButton.OKCancel) = MessageBoxResult.OK Then
            Me.newStoryStoryboard.Begin()
        End If
    End Sub

    Private Sub LastStoryButton_Click(sender As Object, e As System.Windows.RoutedEventArgs)
        If String.IsNullOrEmpty(App.CurrentStoryName) Then
            MessageBox.Show("Current story not found.")
            Return
        End If
        Me.NavigationService.Navigate(New Uri("/ComposePage.xaml", UriKind.Relative))
    End Sub

    Private Sub PreviousStoryButton_Click(sender As Object, e As System.Windows.RoutedEventArgs)
        Me.NavigationService.Navigate(New Uri("/ChooseStoryPage.xaml", UriKind.Relative))
    End Sub

    Private Sub newStoryOKButton_Click(sender As Object, e As System.Windows.RoutedEventArgs)
        If Not String.IsNullOrEmpty(Me.newStoryNameTextBox.Text) Then
            ' Clear any in-memory data.
            For Each photo In App.MediaCollection
                photo.ThumbnailStream.Close()
            Next
            App.MediaCollection.Clear()
            App.CurrentStoryName = Me.newStoryNameTextBox.Text
            Me.closeNewStoryStoryboard.Begin()
            Me.NavigationService.Navigate(New Uri("/ComposePage.xaml", UriKind.Relative))
        End If
    End Sub

    Private Sub newStoryCancelButton_Click(sender As Object, e As System.Windows.RoutedEventArgs)
        Me.closeNewStoryStoryboard.Begin()
    End Sub
End Class

