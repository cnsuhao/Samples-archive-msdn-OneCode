'****************************** Module Header ******************************\
' Module Name:  MainPage.xaml.vb
' Project:      SilverlightWebpart
' Copyright (c) Microsoft Corporation
'
' This is the main page of this sample.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Partial Public Class MainPage
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub btnClk_Click(sender As System.Object, e As System.Windows.RoutedEventArgs)
        MessageBox.Show("Hello from Silverlight within SharePoint !!")
    End Sub
End Class