'****************************** Module Header ******************************\
' Module Name: MainWindow.xaml.vb
' Project:     AzureMobileServiceGenerateSAS
' Copyright (c) Microsoft Corporation.
' 
' This project will show you the token.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Imports Microsoft.WindowsAzure.MobileServices
Imports System.Net.Http
Imports Newtonsoft.Json

Public Class SASToken
    Public Property SAS() As String
        Get
            Return m_SAS
        End Get
        Set(value As String)
            m_SAS = value
        End Set
    End Property
    Private m_SAS As String
End Class


''' <summary>
''' Interaction logic for MainWindow.xaml
''' </summary>
Partial Public Class MainWindow
    Inherits Window
    Public Shared MobileService As New MobileServiceClient("https://[You mobile service name].azure-mobile.net/", "[Mobile Service Key]")
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Async Sub btnStart_Click(sender As Object, e As RoutedEventArgs)
        Try
            btnStart.IsEnabled = False
            'TODO: there is a known issure here, LoginAsync will cause an error so we ignore Authentication in VB version
            'Dim token As Newtonsoft.Json.Linq.JObject = Nothing
            'Await MobileService.LoginAsync(MobileServiceAuthenticationProvider.MicrosoftAccount, token)
            'Dim user = Await MobileService.LoginAsync(MobileServiceAuthenticationProvider.MicrosoftAccount)
            'tbUserID.Text = user.UserId
            Dim httpMethod As New HttpMethod("GET")

            Dim dic As New Dictionary(Of String, String)()
            Dim apiResult = Await MobileService.InvokeApiAsync("generateazuretablesas", httpMethod, dic)
            tbSAS.Text = apiResult.SelectToken("sas").ToString()
            AddToDebug("Get sas from mobile service API successfully, please copy the sas value and use it in TestClient")
        Catch ex As Exception
            AddToDebug("An error occurs: {0} " & vbLf & " Please try again", ex)
        Finally
            btnStart.IsEnabled = True
        End Try
    End Sub

    Private Sub AddToDebug(text As String, ParamArray args As Object())
        If args IsNot Nothing AndAlso args.Length > 0 Then
            text = String.Format(text, args)
        End If
        Me.txtDebug.Text = (Convert.ToString(Me.txtDebug.Text) & text) + Environment.NewLine
    End Sub
End Class