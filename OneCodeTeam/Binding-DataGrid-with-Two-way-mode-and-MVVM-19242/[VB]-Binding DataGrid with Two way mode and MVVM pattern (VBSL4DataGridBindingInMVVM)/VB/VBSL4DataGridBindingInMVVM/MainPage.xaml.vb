'****************************** Module Header ******************************\
' Module Name: MainPage.xaml.vb
' Project:     VBSL4DataGridBindingInMVVM
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to bind data source with using two way mode with
' frequent changed data, the clients can be notified when properties has been 
' changed. The sample designed by MVVM pattern, the lightly pattern provides a 
' flexible way for improving code re-use, simply maintenance and testing.
' 
' The main page is used to display binding message.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/



Imports System.IO.IsolatedStorage

Partial Public Class MainPage
    Inherits UserControl
    Private flag As Boolean = True
    Private appSetting As IsolatedStorageSettings

    Public Sub New()
        InitializeComponent()
        appSetting = IsolatedStorageSettings.ApplicationSettings
        If Not appSetting.Contains("validateFlag") Then
            appSetting.Add("validateFlag", Me.flag)
        End If

    End Sub

    ''' <summary>
    ''' The method is used for catching binding exceptions.
    ''' We can also store validate variable with IsolatedStorageSettings.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Sub tbValidate(ByVal sender As Object, ByVal e As ValidationErrorEventArgs)
        If e.Action = ValidationErrorEventAction.Added Then
            TryCast(e.OriginalSource, Control).Background = New SolidColorBrush(Colors.Yellow)
            flag = False
        End If
        If e.Action = ValidationErrorEventAction.Removed Then
            TryCast(e.OriginalSource, Control).Background = New SolidColorBrush(Colors.White)
            flag = True
        End If
        appSetting("validateFlag") = flag
    End Sub
End Class