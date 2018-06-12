'****************************** Module Header ******************************\
' Module Name:  MainWindow.vb
' Project:      ListBox_HighlightMatchString
' Copyright (c) Microsoft Corporation.
'
' Main window class where the controls are added for testing.
'
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

Class MainWindow
    Private Sub chkMatchCase_Checked(sender As Object, e As RoutedEventArgs)
        txtSearch.Text = String.Empty
    End Sub

    Private Sub chkMatchWholeWord_Checked(sender As Object, e As RoutedEventArgs)
        txtSearch.Text = String.Empty
    End Sub

    Private Sub chkMatchCase_Unchecked(sender As Object, e As RoutedEventArgs)
        txtSearch.Text = String.Empty
    End Sub

    Private Sub chkMatchWholeWord_Unchecked(sender As Object, e As RoutedEventArgs)
        txtSearch.Text = String.Empty
    End Sub

End Class
