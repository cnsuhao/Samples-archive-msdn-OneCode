'****************************** Module Header ******************************\
' Module Name:    MainPage.xaml.vb
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
Imports System
Imports System.Threading
Imports System.Windows.Controls
Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Shell
Imports Microsoft.Xna.Framework.Media

Partial Public Class MainPage
    Inherits PhoneApplicationPage

    ''' <summary>
    ''' MediaLibrary
    ''' </summary>
    Private ml As New MediaLibrary()

    ' Constructor
    Public Sub New()
        InitializeComponent()
        SupportedOrientations = SupportedPageOrientation.Portrait Or SupportedPageOrientation.Landscape
        AddHandler Loaded, AddressOf MainPage_Loaded
    End Sub

    Private Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs)
        ' Load Song list.
        lls.ItemsSource = ml.Songs.ToList()
    End Sub

    ''' <summary>
    ''' Navigation for selected song.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lls_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim song As Song = TryCast(lls.SelectedItem, Song)
        NavigationService.Navigate(New Uri("/SongEdit.xaml?SongName=" & song.Name.ToString(), UriKind.Relative))
    End Sub

    ''' <summary>
    ''' Search by name.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSearch_Click(sender As Object, e As RoutedEventArgs)
        Dim filterList = (From m In ml.Songs Where m.Name.Contains(tbKeywords.Text.Trim().ToString())).ToList()

        Deployment.Current.Dispatcher.BeginInvoke(Function()
                                                      lls.ItemsSource = filterList
                                                      Return Nothing
                                                  End Function)
    End Sub
End Class
