'''**************************** Module Header ******************************\
''' Module Name:  Page1.xaml.vb
''' Project:      VBWPFNavigationUsage
''' Copyright (c) Microsoft Corporation.
'''
''' The sample demonstrates navigation usages in a WPF application.
'''
''' This source is subject to the Microsoft Public License.
''' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
''' All other rights reserved.
'''
''' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
''' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
''' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'''\*************************************************************************/

Imports System.Text

Namespace VBWPFNavigationUsage
    ''' <summary>
    ''' Interaction logic for Page1.xaml
    ''' </summary>
    Partial Public Class Page1
        Inherits Page
        Public Sub New()
            InitializeComponent()
            ' Get a reference to the NavigationService that navigated to this Page
            Dim ns As NavigationService = NavigationService.GetNavigationService(Me)
        End Sub
        Private Sub hyperlink_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Create a pack URI
            Dim uri As New Uri("AnotherPage.xaml", UriKind.Relative)
            ' Get the navigation service that was used to 
            ' navigate to this page, and navigate to 
            ' AnotherPage.xaml
            Me.NavigationService.Navigate(uri)
        End Sub
    End Class
End Namespace
