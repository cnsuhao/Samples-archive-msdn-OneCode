'***************************** Module Header ******************************\
'* Module Name:  App.xaml
'* Project: VBSL4FragmentSearch
'* Copyright (c) Microsoft Corporation.
'* 
'* MainPage.xaml.cs is the primary code behind for the Silverlight component in the sample.
'*  It performs a simple search using the Bing API using fragment navigation from a Silverlight frame,
'*  which allows bookmarking from URL for search pages that will subsequently return consistent results.
'* 
'* This source is subject to the Microsoft Public License.
'* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
'* All other rights reserved.
'* 
'* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\**************************************************************************

Imports System.Collections.ObjectModel
Imports VBSL4FragmentSearch.Bing

Partial Public Class MainPage
    Inherits UserControl
    Dim results As New ObservableCollection(Of WebResult)()
    Public Sub New()
        InitializeComponent()
        SearchResults.ItemsSource = results
    End Sub

    Private Sub Frame_FragmentNavigation(ByVal sender As Object, ByVal e As System.Windows.Navigation.FragmentNavigationEventArgs)
        results.Clear()

        Dim sr As New Bing.SearchRequest()
        sr.Query = Convert.ToString(e.Fragment) & " (site:microsoft.com)"
        ' All-In-One Code Framework app id, you can change to your own one.
        sr.AppId = "4867DA88D6C30C7BB4A8FDA7E5167D79FF99CA0A"
        sr.Sources = New SourceType() {SourceType.Web}
        sr.Web = New Bing.WebRequest()
        Dim bing As Bing.BingPortTypeClient = New BingPortTypeClient()
        AddHandler bing.SearchCompleted, AddressOf bing_SearchCompleted
        bing.SearchAsync(sr)
    End Sub

    Private Sub bing_SearchCompleted(ByVal sender As Object, ByVal e As SearchCompletedEventArgs)
        If e.Result.Web.Results IsNot Nothing Then
            For Each wr As WebResult In e.Result.Web.Results
                results.Add(wr)
            Next
        End If
    End Sub

    Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ContentFrame.Navigate(New Uri("#" + SearchText.Text, UriKind.Relative))
    End Sub

    Private Sub Link_MouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        Dim uri As New Uri(TryCast(TryCast(sender, StackPanel).Tag, String))
        System.Windows.Browser.HtmlPage.Window.Navigate(uri)
    End Sub
End Class