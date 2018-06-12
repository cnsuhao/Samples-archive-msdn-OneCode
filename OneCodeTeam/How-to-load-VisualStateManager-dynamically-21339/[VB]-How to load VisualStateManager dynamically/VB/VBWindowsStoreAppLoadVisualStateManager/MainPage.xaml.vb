'***************************** Module Header ******************************\
' Module Name:  MainPage.vb
' Project:      VBWindowsStoreAppLoadVisualStateManager
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to load VisualStateManager dynamically and attach 
' it to the page at runtime.
'   
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'  
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

' The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

''' <summary>
''' A basic page that provides characteristics common to most applications.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Common.LayoutAwarePage

    Protected Overrides Sub OnNavigatedTo(e As Navigation.NavigationEventArgs)
        Dim sampleData As New SampleData()
        BooksGridView.ItemsSource = sampleData.Books
        BooksListView.ItemsSource = sampleData.Books

        LoadVisualStateManager.AttachVisualStateGroups(rootContent)
        MyBase.OnNavigatedTo(e)
    End Sub

#Region "Common methods"

    Private Async Sub Footer_Click(sender As Object, e As RoutedEventArgs)
        Await Windows.System.Launcher.LaunchUriAsync(New Uri(TryCast(sender, HyperlinkButton).Tag.ToString()))
    End Sub


    Public Sub NotifyUser(message As String)
        Me.statusText.Text = message
    End Sub

#End Region
End Class
