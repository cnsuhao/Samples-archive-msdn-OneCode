'**************************** Module Header ******************************\
'* Module Name:	Login.xaml.cs
'* Project:		VBAzureACSJWT
'* Copyright (c) Microsoft Corporation.
'* 
'* This sample shows:
'* how to do authentication based on Azure Access control service(ACS).
'* 
'* Let user login to Identity provider and get response token.
'* 
'* This source is subject to the Microsoft Public License.
'* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
'* All other rights reserved.
'* 
'* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\*************************************************************************
Imports System.Globalization
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Runtime.Serialization.Json
Imports System.Web
Imports Newtonsoft.Json
Imports System.IdentityModel.Tokens

''' <summary>
''' Interaction logic for Login.xaml
''' </summary>
Public Class Login
    Inherits Window
    Private ipCollection As IEnumerable(Of IdentityProviderInfo)

    Friend Event SettingsChanged As Action

    Public Sub New()
        InitializeComponent()
        GetIdentityProviders()
    End Sub
    Public Sub OnSettingsChanged()
        RaiseEvent SettingsChanged()
    End Sub

    Private Sub GetIdentityProviders()
        If True Then
            Dim identityProviderDiscovery As New Uri(String.Format(CultureInfo.InvariantCulture, "https://{0}.{1}/v2/metadata/IdentityProviders.js?protocol=javascriptnotify&realm={2}&version=1.0", Application.serviceNamespace, Application.acsHostUrl, HttpUtility.UrlEncode(Application.realm)), UriKind.Absolute)

            Dim webClient As New WebClient()
            AddHandler webClient.DownloadStringCompleted, AddressOf WebClientDownloadStringCompleted
            webClient.DownloadStringAsync(identityProviderDiscovery)
        End If
    End Sub


    Private Sub WebClientDownloadStringCompleted(sender As Object, e As DownloadStringCompletedEventArgs)
        Using ms As New MemoryStream(Encoding.Unicode.GetBytes(e.Result))
            Dim serializer As New DataContractJsonSerializer(GetType(IdentityProviderInfo()))
            ipCollection = TryCast(serializer.ReadObject(ms), IEnumerable(Of IdentityProviderInfo))
            For Each item In ipCollection
                Select Case item.Name
                    Case "Google"
                        btnGoogle.Visibility = Visibility.Visible
                        Exit Select
                    Case "Yahoo!"
                        btnYahoo.Visibility = Visibility.Visible
                        Exit Select
                    Case Else
                        Exit Select
                End Select
            Next
        End Using
    End Sub

    Private Sub LoginButton_Click(sender As Object, e As RoutedEventArgs)

        Dim ipName As String = Nothing

        Select Case DirectCast(sender, Button).Name
            Case "btnGoogle"
                ipName = "Google"
                Exit Select
            Case "btnYahoo"
                ipName = "Yahoo!"
                Exit Select
            Case Else
                Exit Select
        End Select
        If ipCollection IsNot Nothing Then
            Dim ip = ipCollection.Where(Function(item) item.Name = ipName).[Single]()

            Dim idpUrl As String = DirectCast(ip, IdentityProviderInfo).LoginUrl
            wbsLogin.Navigate(idpUrl)
        End If
    End Sub

    Private Sub wbsLogin_Loaded(sender As Object, e As RoutedEventArgs)
        DirectCast(sender, WebBrowser).ObjectForScripting = New HtmlInteropClass()

    End Sub

    <System.Runtime.InteropServices.ComVisibleAttribute(True)> _
    Public Class HtmlInteropClass
        Public Sub Notify(jsonToken As String)

            Dim jwtSTH = getDeserializedToken(jsonToken)
            For Each claim In jwtSTH.Claims
                If claim.Type = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress" Then
                    My.Settings.CustomerEmail = claim.Value
                End If
                DirectCast(Application.Current.MainWindow, MainWindow).tblMessage.Text += claim.ToString() + vbLf
            Next

            For Each window In Application.Current.Windows
                If TryCast(window, Login) IsNot Nothing Then
                    DirectCast(window, Login).Close()
                    DirectCast(Application.Current.MainWindow, MainWindow).stateCheck()
                End If
            Next
        End Sub


        ''' <summary>
        ''' Third part IDP provider will provide issure a Json formate token, and serialized JWT in "securityToken".
        ''' This method will deserialized the Json token and return JwtSecurityToken.
        ''' </summary>
        ''' <param name="jsonToken"></param>
        ''' <returns></returns>
        Private Function getDeserializedToken(jsonToken As String) As JwtSecurityToken
            Dim jObj As Object = JsonConvert.DeserializeObject(jsonToken)
            Dim securityTokenValue = jObj("securityToken").ToString()


            Dim jwtSTH As New JwtSecurityTokenHandler()
            Dim jwtST = TryCast(jwtSTH.ReadToken(securityTokenValue), JwtSecurityToken)
            Return jwtST
        End Function
    End Class

End Class