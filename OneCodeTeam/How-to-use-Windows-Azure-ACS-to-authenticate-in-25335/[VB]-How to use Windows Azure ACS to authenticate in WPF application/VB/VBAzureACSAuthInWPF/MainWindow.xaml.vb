'***************************** Module Header ******************************\
' Module Name:	MainWindow.xaml.vb
' Project:		VBAzureACAuthInWPF
' Copyright (c) Microsoft Corporation.
' 
' This sample shows:
' how to do authentication based on Azure Access control service(ACS).
' how to use ACS to secure your WCF service.
'
' MainWindow
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/
Imports System.IO
Imports System.Net

Partial Public Class MainWindow
    Inherits Window
    Public Sub New()
        InitializeComponent()
        stateClear()
        stateCheck()
    End Sub

    ''' <summary>
    ''' Clear User Information in Settings
    ''' </summary>
    Friend Sub stateClear()
        My.Settings.CustomerEmail = String.Empty
        My.Settings.SWT = String.Empty
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As RoutedEventArgs)
        If btnLogin.Content.ToString() = "Login" Then
            Dim newLogin = New Login()
            newLogin.Show()
        Else
            stateClear()
            My.Settings.Save()
            stateCheck()
        End If
    End Sub


    Friend Sub stateCheck()
        If My.Settings.CustomerEmail <> String.Empty Then
            lblUserName.Visibility = Visibility.Visible
            lblUserName.Content = My.Settings.CustomerEmail
            btnLogin.Content = "Logout"
        Else
            btnLogin.Content = "Login"
            lblUserName.Visibility = Visibility.Hidden
        End If
    End Sub

    ''' <summary>
    ''' Make a request to WCF service attach SWT.
    ''' </summary>
    Private Sub btnGetMessage_Click(sender As Object, e As RoutedEventArgs)
        If My.Settings.SWT <> String.Empty Then
            Dim client As New WebClient()
            Dim headerValue As String = String.Format("WRAP access_token=\{0}\", My.Settings.SWT)

            client.Headers.Add("Authorization", headerValue)
            Dim stream As Stream = client.OpenRead("http://localhost:12526/RESTUserService.svc/users")

            Dim reader As New StreamReader(stream)
            tblMessage.Text = reader.ReadToEnd()
        Else
            System.Windows.MessageBox.Show("Please login first")
        End If
    End Sub
End Class