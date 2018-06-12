'**************************** Module Header ******************************\
'* Module Name:	MainWindow.xamlcs
'* Project:		VBAzureACSJWT
'* Copyright (c) Microsoft Corporation.
'* 
'* This sample shows:
'* how to do authentication based on Azure Access control service(ACS).
'* 
'* MainWindow
'* 
'* This source is subject to the Microsoft Public License.
'* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
'* All other rights reserved.
'* 
'* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\*************************************************************************
Public Class MainWindow
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
            tblMessage.Text = String.Empty
        End If
    End Sub
End Class
