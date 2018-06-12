'**************************** Module Header ******************************\
' Module Name:  MainPage.xaml.vb
' Project:      VBWPFNavigationUsage
' Copyright (c) Microsoft Corporation.
'
' The sample demonstrates navigation usages in a WPF application.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Text

Namespace VBWPFNavigationUsage
    Partial Public Class MainPage
        Inherits Page
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub OnHyperlink(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.NavigationService.Navigate(New Uri("Page1.xaml", UriKind.Relative))
        End Sub

        Private Sub OnNavagateToObject(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim obj As New MyDummy() With {.Property1 = "Hello", .Property2 = "everyone"}
            Me.NavigationService.Navigate(obj)
        End Sub

        Private Sub OnNavagateToPage(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.NavigationService.Navigate(New Uri("FramePage.xaml", UriKind.Relative))
        End Sub
    End Class

    Public Class MyDummy
        Private _Property1 As String
        Private _Property2 As String
        Public Property Property1() As String
            Get
                Return _Property1
            End Get
            Set(ByVal value As String)
                _Property1 = value
            End Set
        End Property
        Public Property Property2() As String
            Get
                Return _Property2
            End Get
            Set(ByVal value As String)
                _Property2 = value
            End Set
        End Property
    End Class
End Namespace
