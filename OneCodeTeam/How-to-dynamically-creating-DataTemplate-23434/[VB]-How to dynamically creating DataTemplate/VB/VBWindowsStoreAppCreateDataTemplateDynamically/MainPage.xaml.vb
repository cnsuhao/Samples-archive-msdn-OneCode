'***************************** Module Header ******************************\
' Module Name:    MainPage.xaml.vb
' Project:        VBWindowsStoreAppCreateDataTemplateDynamically
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to create DataTemplate Dynamically
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports Windows.UI.Xaml.Navigation
Imports System.Text
Imports Windows.UI.Xaml.Markup

' The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

''' <summary>
''' A basic page that provides characteristics common to most applications.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Common.LayoutAwarePage

#Region "Common methods"

    ''' <summary>
    ''' The the event handler for the click event of the link in the footer. 
    ''' </summary>
    ''' <param name="sender">
    ''' The sender.
    ''' </param>
    ''' <param name="e">
    ''' The event arguments.
    ''' </param>
    Private Async Sub FooterClick(sender As Object, e As RoutedEventArgs)
        Dim hyperlinkButton As HyperlinkButton = TryCast(sender, HyperlinkButton)
        If hyperlinkButton IsNot Nothing Then
            Await Windows.System.Launcher.LaunchUriAsync(New Uri(hyperlinkButton.Tag.ToString()))
        End If
    End Sub

    Public Sub NotifyUser(message As String)
        Me.StatusText.Text = message
    End Sub

#End Region

    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        Dim Books As List(Of Book) = Book.GetBooks()
        BookGridView.ItemsSource = Books
        BookListView.ItemsSource = Books

        Dim sb As New StringBuilder()
        sb.Append("<DataTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"">")
        sb.Append("<Grid Width=""200"" Height=""100"">")
        sb.Append("<StackPanel>")
        sb.Append("<StackPanel Orientation=""Horizontal"" Margin=""3,3,0,3""><TextBlock Text=""Name:"" Style=""{StaticResource AppBodyTextStyle}"" Margin=""0,0,5,0""/><TextBlock Text=""{Binding Name}"" Style=""{StaticResource AppBodyTextStyle}""/></StackPanel>")
        sb.Append("<StackPanel Orientation=""Horizontal"" Margin=""3,3,0,3""><TextBlock Text=""Price:"" Style=""{StaticResource AppBodyTextStyle}"" Margin=""0,0,5,0""/><TextBlock Text=""{Binding Price}"" Style=""{StaticResource AppBodyTextStyle}""/></StackPanel>")
        sb.Append("<StackPanel Orientation=""Horizontal"" Margin=""3,3,0,3""><TextBlock Text=""Author:"" Style=""{StaticResource AppBodyTextStyle}"" Margin=""0,0,5,0""/><TextBlock Text=""{Binding Author}"" Style=""{StaticResource AppBodyTextStyle}""/></StackPanel>")
        sb.Append("</StackPanel>")
        sb.Append("</Grid>")
        sb.Append("</DataTemplate>")

        Dim datatemplate As DataTemplate = DirectCast(XamlReader.Load(sb.ToString()), DataTemplate)
        BookGridView.ItemTemplate = datatemplate
        BookListView.ItemTemplate = datatemplate

        MyBase.OnNavigatedTo(e)
    End Sub

End Class
