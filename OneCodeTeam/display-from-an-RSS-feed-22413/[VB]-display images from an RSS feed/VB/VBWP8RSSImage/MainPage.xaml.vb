'****************************** Module Header ******************************\
' Module Name:    MainPage.xaml.vb
' Project:        VBWP8RSSImage
' Copyright (c) Microsoft Corporation
'
' This demo shows how to display images from an RSS feed.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/
Imports System
Imports System.Threading
Imports System.Windows.Controls
Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Shell
Imports System.ServiceModel.Syndication
Imports System.IO

Partial Public Class MainPage
    Inherits PhoneApplicationPage

    Private strURL As String = "http://windowsteamblog.com/windows_phone/b/windowsphone/rss.aspx" ' URL of RssFeeds.

    ' Constructor
    Public Sub New()
        InitializeComponent()

        SupportedOrientations = SupportedPageOrientation.Portrait Or SupportedPageOrientation.Landscape
    End Sub

    Private Sub loadFeedButton_Click(sender As Object, e As RoutedEventArgs)
        Dim webClient As New WebClient()
        AddHandler webClient.DownloadStringCompleted, New DownloadStringCompletedEventHandler(AddressOf webClient_DownloadStringCompleted)
        webClient.DownloadStringAsync(New System.Uri(strURL))
    End Sub

    ''' <summary>
    ''' Event handler which runs after the feed is fully downloaded.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub webClient_DownloadStringCompleted(sender As Object, e As DownloadStringCompletedEventArgs)
        If e.[Error] IsNot Nothing Then
            Deployment.Current.Dispatcher.BeginInvoke(Sub() MessageBox.Show(e.[Error].Message))
        Else
            ' Save the feed into the State property in case the application is tombstoned. 
            Me.State("feed") = e.Result

            UpdateFeedList(e.Result)
        End If
    End Sub

    ''' <summary>
    ''' This method determines whether the user has navigated to the application after the application was tombstoned.
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnNavigatedTo(e As System.Windows.Navigation.NavigationEventArgs)
        ' First, check whether the feed is already saved in the page state.
        If Me.State.ContainsKey("feed") Then
            ' Get the feed again only if the application was tombstoned, which means the ListBox will be empty.
            ' This is because the OnNavigatedTo method is also called when navigating between pages in your application.
            ' You would want to rebind only if your application was tombstoned and page state has been lost. 
            If feedListBox.Items.Count = 0 Then
                UpdateFeedList(TryCast(State("feed"), String))
            End If
        End If
    End Sub

    ''' <summary>
    ''' This method sets up the feed and binds it to our ListBox.
    ''' </summary>
    ''' <param name="feedXML"></param> 
    Private Sub UpdateFeedList(feedXML As String)
        ' Load the feed into a SyndicationFeed instance.
        Dim stringReader As New StringReader(feedXML)
        Dim xmlReader__1 As XmlReader = XmlReader.Create(stringReader)
        Dim feed As SyndicationFeed = SyndicationFeed.Load(xmlReader__1)

        ' Use the Dispatcher to update the UI. This keeps the UI thread free from heavy processing.
        Deployment.Current.Dispatcher.BeginInvoke(Sub()
                                                      feedListBox.ItemsSource = feed.Items
                                                      loadFeedButton.Content = "Refresh Feed"
                                                  End Sub)
    End Sub
End Class