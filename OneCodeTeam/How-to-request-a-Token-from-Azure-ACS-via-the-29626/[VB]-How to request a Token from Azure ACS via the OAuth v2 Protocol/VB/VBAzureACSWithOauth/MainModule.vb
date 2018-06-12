'**************************** Module Header ******************************\
' Module Name:	MainModule.vb
' Project:		VBAzureACSWithOauth
' Copyright (c) Microsoft Corporation.
' 
' This sample shows how to request a token from ACS via the OAuth.
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
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Web.Script.Serialization
Imports System.Web
Imports System.Collections.Specialized

Module MainModule
    Public Const ACSNameSpace As String = "{Your-ACS-NameSpace}"
    Sub Main()
        Dim accessToken = HttpUtility.UrlDecode(GetTokenBySymmetricKey("http://dinohy.com/"))
        Console.WriteLine(accessToken)
        Console.ReadLine()
    End Sub

    Public Function GetTokenByPassword(scope As String) As String
        Try
            Const identityName As String = "{Service-Identity-Name}"
            Const identityPassword As String = "{Password}"

            ' Request a token from ACS
            Dim client = New WebClient()
            Dim address = New Uri(String.Format("https://{0}.accesscontrol.windows.net/v2/OAuth2-13", ACSNameSpace))

            Dim values = New NameValueCollection()

            values.Add("grant_type", "client_credentials")
            values.Add("client_id", identityName)
            values.Add("client_secret", identityPassword)
            values.Add("scope", scope)

            Dim responseBytes As Byte() = client.UploadValues(address, "POST", values)

            Dim response As String = Encoding.UTF8.GetString(responseBytes)

            ' Parse the JSON response and return the access token
            Dim serializer = New JavaScriptSerializer()

            Dim decodedDictionary = TryCast(serializer.DeserializeObject(response), Dictionary(Of String, Object))

            Return TryCast(decodedDictionary("access_token"), String)
        Catch wex As WebException
            Dim value As String = New StreamReader(wex.Response.GetResponseStream()).ReadToEnd()
            Throw
        End Try

    End Function

    Public Function GetTokenBySymmetricKey(scope As String) As String
        Try
            ' Request a token from ACS
            Dim client = New WebClient()
            Dim address = New Uri(String.Format("https://{0}.accesscontrol.windows.net/v2/OAuth2-13", ACSNameSpace))

            Dim values = New NameValueCollection()

            values.Add("grant_type", "http://schemas.xmlsoap.org/ws/2009/11/swt-token-profile-1.0")
            values.Add("assertion", createSWT("{Service-Identity-Name}", "0ytBPxRB6nc05zv6mjP2aK8rCWWPnP3fR+IDTDHEfSM="))
            values.Add("scope", scope)

            Dim responseBytes As Byte() = client.UploadValues(address, "POST", values)

            Dim response As String = Encoding.UTF8.GetString(responseBytes)

            ' Parse the JSON response and return the access token
            Dim serializer = New JavaScriptSerializer()

            Dim decodedDictionary = TryCast(serializer.DeserializeObject(response), Dictionary(Of String, Object))

            Return TryCast(decodedDictionary("access_token"), String)
        Catch wex As WebException
            Dim value As String = New StreamReader(wex.Response.GetResponseStream()).ReadToEnd()
            Throw
        End Try
    End Function

    Public Function GetTokenFromAcsBySAML(scope As String, samlToken As String) As String
        'For how to create a samlToken please refer to:
        'http://msdn.microsoft.com/en-us/library/aa355062(v=vs.110).aspx
        Try
            ' Request a token from ACS
            Dim client = New WebClient()
            Dim address = New Uri(String.Format("https://{0}.accesscontrol.windows.net/v2/OAuth2-13", ACSNameSpace))

            Dim values = New NameValueCollection()

            values.Add("grant_type", "saml2-bearer")
            values.Add("assertion", samlToken)
            values.Add("scope", scope)

            Dim responseBytes As Byte() = client.UploadValues(address, "POST", values)

            Dim response As String = Encoding.UTF8.GetString(responseBytes)

            ' Parse the JSON response and return the access token
            Dim serializer = New JavaScriptSerializer()

            Dim decodedDictionary = TryCast(serializer.DeserializeObject(response), Dictionary(Of String, Object))

            Return TryCast(decodedDictionary("access_token"), String)
        Catch wex As WebException
            Dim value As String = New StreamReader(wex.Response.GetResponseStream()).ReadToEnd()
            Throw
        End Try
    End Function

    Public Function createSWT(issuer As String, signingKey As String) As String
        Dim factory = New TokenFactory(issuer, signingKey)
        Return factory.CreateToken()
    End Function
End Module
