'****************************** Module Header ******************************\
' Module Name: MainPage.xaml.vb
' Project:     VBSL4MusicPlayer
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to create a media player in silverlight.
' User can upload some music files in Web application and generate an xml
' file. The music list would be from xml file, when you click music name
' of list, you can begin to enjoy your music. 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/



Imports System.Windows.Threading
Imports System.Windows.Browser
Imports System.IO

Partial Public Class MainPage
    Inherits UserControl
    ' Define some public properties of application, include data items, 
    ' some signal variables, a TimeSpan class and a timer. 
    Public DataItems As List(Of DataItem)
    Public blnIsMuted As Boolean = False
    Public blnIsFull As Boolean = False
    Private timeDuration As TimeSpan

    Public Sub New()
        InitializeComponent()
        Me.XmlProcessMethod()
    End Sub

    ''' <summary>
    ''' This method used to asynchronous loading data from xml file and 
    ''' adds DownLoadXmlComplete method with WebCient, it will add other 
    ''' methods to timer and media element.
    ''' </summary>
    Private Sub XmlProcessMethod()
        Dim webClient As New WebClient()
        webClient.DownloadStringAsync(New Uri(HtmlPage.Document.DocumentUri, "Resource/MusicList.xml"))
        AddHandler webClient.DownloadStringCompleted, AddressOf Me.DownLoadXmlComplete
    End Sub


    Private Sub mediaElement_CurrentStateChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
        tbStatus.Text = mediaElement.CurrentState.ToString()
        If mediaElement.CurrentState <> MediaElementState.Playing AndAlso mediaElement.CurrentState <> MediaElementState.Paused Then
            sliderProcess.IsEnabled = False
        Else
            sliderProcess.IsEnabled = True
        End If
    End Sub

    Private Sub mediaElement_MediaEnded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        tbStatus.Text = "complete"
        mediaElement.Pause()
        mediaElement.Position = TimeSpan.Zero
    End Sub

    Private Sub mediaElement_MediaOpened(ByVal sender As Object, ByVal e As RoutedEventArgs)
        tbStatus.Text = "start"
        ' Retrieve music's total time.
        timeDuration = If(MediaElement.NaturalDuration.HasTimeSpan, MediaElement.NaturalDuration.TimeSpan, TimeSpan.FromMilliseconds(0))
        sliderProcess.Maximum = timeDuration.TotalSeconds
    End Sub

    Private Sub btnStop_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        mediaElement.Position = TimeSpan.Zero
        mediaElement.Stop()
    End Sub

    Private Sub btnPlay_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        mediaElement.Play()
    End Sub

    Private Sub btnPause_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        mediaElement.Pause()
    End Sub

    ''' <summary>
    ''' Muted method
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnMuted_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Not blnIsMuted Then
            btnMuted.Content = "Unmute"
            MediaElement.IsMuted = True
            blnIsMuted = True
        Else
            btnMuted.Content = "Muted"
            MediaElement.IsMuted = False
            blnIsMuted = False
        End If
    End Sub

    ''' <summary>
    ''' Full screen method
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnFullScreen_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Not blnIsFull Then
            btnFullScreen.Content = "Small Screen"
            Application.Current.Host.Content.IsFullScreen = True
            blnIsFull = True
        Else
            btnFullScreen.Content = "Full Screen"
            Application.Current.Host.Content.IsFullScreen = False
            blnIsFull = False
        End If
    End Sub

    ''' <summary>
    ''' Load music data from xml file and convert data to a List of DataItem
    ''' instances. Bind DataGrid control's ItemSource with it.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DownLoadXmlComplete(ByVal sender As Object, ByVal e As DownloadStringCompletedEventArgs)
        Using reader As XmlReader = XmlReader.Create(New StringReader(e.Result))
            DataItems = New List(Of DataItem)()
            While reader.Read()
                If reader.IsStartElement() AndAlso reader.GetAttribute("open") = "1" Then
                    Dim pathMusic As String = reader.GetAttribute("path").ToString()
                    Dim nameMusic As String = reader.GetAttribute("name").ToString()
                    Dim dataItem As New DataItem()
                    dataItem.NameItem = nameMusic
                    dataItem.PathItem = pathMusic
                    DataItems.Add(dataItem)
                End If
            End While
            girdList.ItemsSource = DataItems
        End Using
    End Sub

    ''' <summary>
    ''' Allow user to change another song.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub girdList_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
        sliderProcess.IsEnabled = True
        mediaElement.Position = New TimeSpan(0)
        Dim selectItem As DataItem = DirectCast(girdList.SelectedItem, DataItem)
        mediaElement.Source = New Uri(HtmlPage.Document.DocumentUri, selectItem.PathItem)
        mediaElement.Play()
    End Sub

    ''' <summary>
    ''' Go back to the beginning of slider control when music plays complete
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub mdeMusic_MediaEnded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        mediaElement.Position = TimeSpan.Zero
    End Sub

End Class