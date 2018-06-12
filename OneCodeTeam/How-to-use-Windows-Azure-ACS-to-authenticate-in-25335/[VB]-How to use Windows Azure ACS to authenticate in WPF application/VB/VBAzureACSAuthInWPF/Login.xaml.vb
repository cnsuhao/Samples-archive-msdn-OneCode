'**************************** Module Header ******************************\
' Module Name:	Login.xaml.vb
' Project:		VBAzureACAuthInWPF
' Copyright (c) Microsoft Corporation.
' 
' This sample shows:
' how to do authentication based on Azure Access control service(ACS).
' how to use ACS to secure your WCF service.
' 
' Let user login to Identity provider and get response token.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************/

Imports System.Web
Imports System.Net
Imports System.Globalization
Imports System.IO
Imports System.Runtime.Serialization.Json
Imports System.Text
Imports System.Security.Claims

Partial Public Class Login
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

    <System.Runtime.InteropServices.ComVisibleAttribute(True)>
    Public Class HtmlInteropClass
        Public Sub Notify(jsonToken As String)
            Dim decodedSwt As String =getDeserializedToken(jsonToken)
            Dim query = From claim In decodedSwt.Split("&"c)
                        Where claim.Contains(ClaimTypes.Email)
                        Let parts = claim.Split("="c)
                        Select New With {.ClaimType = parts(0), .Value = parts(1)}


            If query.Count() > 0 Then
                My.Settings.CustomerEmail = query.Single().Value
            End If

            My.Settings.Save()
            For Each window In Application.Current.Windows
                If TryCast(window, Login) IsNot Nothing Then
                    DirectCast(window, Login).Close()
                    DirectCast(Application.Current.MainWindow, MainWindow).stateCheck()
                End If
            Next
        End Sub


        ''' <summary>
        ''' Third part IDP provider will provide issure a Json formate token, and serialized swt in "securityToken".
        ''' This method will deserialized the Json token and return decoded swt.
        ''' </summary>
        ''' <param name="jsonToken"></param>
        ''' <returns></returns>
        Private Function getDeserializedToken(jsonToken As String) As String
            Dim start As Integer = jsonToken.IndexOf("aHR0c")
            Dim [end] As Integer = jsonToken.IndexOf("&lt;/wsse")


            Dim tokenBase64 As String = jsonToken.Substring(start, ([end] - start))
            Dim b As Byte() = Convert.FromBase64String(tokenBase64)
            'This is the SWT security module need.
            My.Settings.SWT = System.Text.Encoding.UTF8.GetString(b)

            'Need URLDecode to get emailAddress claim value.
            Return HttpUtility.UrlDecode(System.Text.Encoding.UTF8.GetString(b))
        End Function
    End Class

End Class