'****************************** Module Header ******************************\
' Module Name:    MainPage.xaml.vb
' Project:        VBWP8RssFeedSort
' Copyright (c) Microsoft Corporation
'
' This demo shows how to sort RssFeeds.
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
Imports System.Collections.ObjectModel

Partial Public Class MainPage
    Inherits PhoneApplicationPage
    ' Enum for sort type.
    Public Enum SortTypeEnum
        PublishDate
        Title
        Authors
    End Enum

    ' Enum for sort order.
    Public Enum SortEnum
        asc
        desc
    End Enum

    Private strURL As String = "http://windowsteamblog.com/windows_phone/b/windowsphone/rss.aspx" ' URL of RssFeeds.
    Private tempSortType As SortTypeEnum = SortTypeEnum.PublishDate                               ' Default (temporary) Sort type.
    Private tempSortEnum As SortEnum = SortEnum.asc                                               ' Default (temporary) sort order.

    ' Constructor
    Public Sub New()
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Click handler that runs when the 'Load Feed' or 'Refresh Feed' button is clicked. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub loadFeedButton_Click(sender As Object, e As System.Windows.RoutedEventArgs)
        DownloadFeed()
    End Sub

    ''' <summary>
    ''' Test sort by Authors by using local data.
    ''' </summary>
    Private Sub SortByAuthors()
        tempSortType = SortTypeEnum.Authors

        ' Load the feed into a SyndicationFeed instance.
        Dim _xmlReader As XmlReader = XmlReader.Create("Feeds.xml")
        Dim feed As SyndicationFeed = SyndicationFeed.Load(_xmlReader)

        ' Update UI.
        UpdateUI(feed)
    End Sub

    ''' <summary>
    ''' Download feed from the specified URL.
    ''' </summary>
    Private Sub DownloadFeed()
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
    ''' Use the Dispatcher to update the UI. This keeps the UI thread free from heavy processing.
    ''' </summary>
    ''' <param name="feed"></param>
    Private Sub UpdateUI(feed As SyndicationFeed)
        Deployment.Current.Dispatcher.BeginInvoke(Sub()
                                                      feedListBox.ItemsSource = SortByType(feed.Items, tempSortType, tempSortEnum)
                                                      loadFeedButton.Content = "Refresh Feed"
                                                  End Sub)
    End Sub

    ''' <summary>
    ''' This method sets up the feed and binds it to our ListBox.
    ''' </summary>
    ''' <param name="feedXML"></param> 
    Private Sub UpdateFeedList(feedXML As String)
        ' Load the feed into a SyndicationFeed instance.
        Dim stringReader As New StringReader(feedXML)
        Dim _xmlReader As XmlReader = XmlReader.Create(stringReader)
        Dim feed As SyndicationFeed = SyndicationFeed.Load(_xmlReader)

        UpdateUI(feed)
    End Sub

    ''' <summary>
    ''' Sort the list according to the specified sort type and order.
    ''' </summary>
    ''' <param name="items">RssFeeds</param>
    ''' <param name="sortType">sort type</param>
    ''' <param name="sort">sort order</param>
    ''' <returns></returns>
    Private Function SortByType(items As IEnumerable(Of SyndicationItem), sortType As SortTypeEnum, sort As SortEnum) As IEnumerable(Of SyndicationItem)
        ' RssFeed list.
        Dim feedItems As New List(Of SyndicationItem)(items)

        ' Perform the sort.
        Select Case sortType
            Case SortTypeEnum.PublishDate
                If sort.Equals(SortEnum.desc) Then
                    ' newest first                           
                    feedItems.Sort(Function(a, b)
                                       Return b.PublishDate.CompareTo(a.PublishDate)

                                   End Function)
                Else
                    ' oldest first
                    feedItems.Sort(Function(a, b)
                                       Return a.PublishDate.CompareTo(b.PublishDate)

                                   End Function)
                End If
                Exit Select
            Case SortTypeEnum.Title
                If sort.Equals(SortEnum.desc) Then
                    feedItems.Sort(Function(a, b)
                                       Return b.Title.Text.CompareTo(a.Title.Text)

                                   End Function)
                Else
                    feedItems.Sort(Function(a, b)
                                       Return a.Title.Text.CompareTo(b.Title.Text)

                                   End Function)
                End If
                Exit Select
            Case SortTypeEnum.Authors
                If sort.Equals(SortEnum.desc) Then
                    feedItems.Sort(Function(a, b)
                                       Return MyCompareClass.CompareSyndicationPerson(b, a)

                                   End Function)
                Else
                    feedItems.Sort(Function(a, b)
                                       Return MyCompareClass.CompareSyndicationPerson(a, b)

                                   End Function)
                End If
                Exit Select
            Case Else
                Exit Select
        End Select

        Return feedItems
    End Function

    ''' <summary>
    ''' Set the sort order.
    ''' </summary>
    Private Sub SetSort()
        If tempSortEnum = SortEnum.desc Then
            tempSortEnum = SortEnum.asc
        Else
            tempSortEnum = SortEnum.desc
        End If
    End Sub

    ''' <summary>
    ''' Sort by title.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSortByTitle_Click(sender As Object, e As RoutedEventArgs)
        tempSortType = SortTypeEnum.Title
        DownloadFeed()
        SetSort()
    End Sub

    ''' <summary>
    ''' Sort by Authors.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSortByAuthors_Click(sender As Object, e As RoutedEventArgs)
        SortByAuthors()
        SetSort()
    End Sub

    ''' <summary>
    ''' Sort by PublishDate.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSortByPublishDate_Click(sender As Object, e As RoutedEventArgs)
        tempSortType = SortTypeEnum.PublishDate
        DownloadFeed()
        SetSort()
    End Sub
End Class

''' <summary>
'''  Helper class for sorting by Authors.
''' </summary>
Public Class MyCompareClass
    ''' <summary>
    ''' Compare the two Collections.
    ''' </summary>
    ''' <typeparam name="T">Base Class</typeparam>
    ''' <param name="a"></param>
    ''' <param name="b"></param>
    ''' <returns></returns>
    Public Shared Function Compare(Of T As IComparable(Of T))(a As Collection(Of T), b As Collection(Of T)) As Integer
        If a.Count = b.Count Then
            Dim aTotalValue As Integer = 0
            Dim bTotalValue As Integer = 0

            For i As Integer = 0 To a.Count - 1
                If a(i).CompareTo(b(i)) > 0 Then
                    aTotalValue += 1
                ElseIf a(i).CompareTo(b(i)) < 0 Then
                    bTotalValue += 1
                End If
            Next
            Return aTotalValue - bTotalValue
        End If
        Return a.Count - b.Count
    End Function

    ''' <summary>
    ''' Compare SyndicationPerson for sorting. Use custom class to sort.
    ''' </summary>
    ''' <param name="a"></param>
    ''' <param name="b"></param>
    ''' <returns></returns>
    Public Shared Function CompareSyndicationPerson(a As SyndicationItem, b As SyndicationItem) As Integer
        Dim authors1 As Collection(Of SyndicationPerson) = a.Authors
        ' a's Authors
        Dim authors2 As Collection(Of SyndicationPerson) = b.Authors
        ' b's Authors
        Dim tempAuthors1 As New Collection(Of SyndicationPersonTemp)()
        Dim tempAuthors2 As New Collection(Of SyndicationPersonTemp)()

        ' Store SyndicationPerson's data to SyndicationPersonTemp. Then we will 
        ' sort the list of SyndicationPersonTemp.
        For Each item As SyndicationPerson In authors1
            tempAuthors1.Add(New SyndicationPersonTemp(item))
        Next
        For Each item As SyndicationPerson In authors2
            tempAuthors2.Add(New SyndicationPersonTemp(item))
        Next

        ' Perform the compare.
        Dim result As Integer = Compare(Of SyndicationPersonTemp)(tempAuthors1, tempAuthors2)
        Return result
    End Function
End Class

''' <summary>
''' This class is used to store SyndicationPerson's data for sorting.
''' </summary>
Public Class SyndicationPersonTemp
    Inherits SyndicationPerson
    Implements IComparable(Of SyndicationPersonTemp)

    ' Constructor. Initialization SyndicationPersonTemp by using SyndicationPerson's data .
    Public Sub New(sp As SyndicationPerson)
        MyBase.New()
        Me.Email = sp.Email
        Me.Name = sp.Name
        Me.Uri = sp.Uri
    End Sub

    ''' <summary>
    ''' IComparable.CompareTo implementation.
    ''' </summary>
    ''' <param name="other"></param>
    ''' <returns></returns>
    Public Function CompareTo(other As SyndicationPersonTemp) As Integer Implements IComparable(Of SyndicationPersonTemp).CompareTo
        ' Alphabetic sort if Email is not equal. [A to Z]
        If Me.Email <> other.Email Then
            Return Me.Email.CompareTo(other.Email)
        ElseIf Me.Name <> other.Name Then
            Return Me.Name.CompareTo(other.Name)
        ElseIf Me.Uri <> other.Uri Then
            Return Me.Uri.CompareTo(other.Uri)
        End If

        ' Default to Email sort. [High to low]
        Return Me.Email.CompareTo(other.Email)
    End Function
End Class
