'****************************** Module Header ******************************\
' Module Name:  MainPage.xaml.vb
' Project:      VBWP8AccessItemIndex
' Copyright (c) Microsoft Corporation
'
' This sample demonstrates how to get the item index of ItemsControl's item
' and how to use it.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Imports System
Imports System.Threading
Imports System.Windows.Controls
Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Shell

Partial Public Class MainPage
    Inherits PhoneApplicationPage

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Page_Loaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' data bind
        Me.ItemView1.DataContext = App.ViewModel
        Me.ItemView2.itmCustomType.ItemsSource = App.ViewModel.UserDatas
    End Sub
End Class
