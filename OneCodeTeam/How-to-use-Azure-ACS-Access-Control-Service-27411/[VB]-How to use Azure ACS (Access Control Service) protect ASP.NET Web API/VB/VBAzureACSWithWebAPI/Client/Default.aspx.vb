'***************************** Module Header ******************************\
' Module Name:	Default.aspx.vb
' Project:		VBAzureACSWithWebAPI
' Copyright (c) Microsoft Corporation.
' 
' Secure Web API is a hot topic in asp.net forum.
' This sample will show you how to use Azure ACS secure the web API.
' It will require you sign in with Live ID/Google/Yahoo/Live connect account 
' first before you use the web API.
'
' Default page
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/
Imports System.Net
Imports System.IO

Public Class _Default
    Inherits System.Web.UI.Page
    Shared serviceNamespace As String = "your namespace"
    Shared acsHostUrl As String = "accesscontrol.windows.net"
    'Your WebAPI project realm
    Shared realm As String = "your realm"
    Shared uid As String = "your service identity name"
    Shared pwd As String = "your service identity password"

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Get the user name from Claims.
        Dim Name As String = System.Security.Claims.ClaimsPrincipal.Current.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value
        If Name <> "" Then
            Dim token As String = GetTokenFromACS(realm)
            Dim client As New WebClient()
            Dim headerValue As String = String.Format("WRAP access_token=""{0}""", token)

            client.Headers.Add("Authorization", headerValue)
            Dim stream As Stream = client.OpenRead("http://localhost:22221/api/products")
            Dim reader As New StreamReader(stream)

            tbContent.Text = reader.ReadToEnd()
            hlkLogin.Visible = False

            lbUserName.Text = "Hello" & Name
        Else
            hlkLogin.Enabled = True
            lbUserName.Text = Nothing


            tbContent.Text = "You need to login first if you want to use the WebApi"
        End If
    End Sub

    Private Shared Function GetTokenFromACS(scope As String) As String
        Dim wrapPassword As String = pwd
        Dim wrapUsername As String = uid

        ' request a token from ACS
        Dim client As New WebClient()
        client.BaseAddress = String.Format("https://{0}.{1}", serviceNamespace, acsHostUrl)

        Dim values As New NameValueCollection()
        values.Add("wrap_name", wrapUsername)
        values.Add("wrap_password", wrapPassword)
        values.Add("wrap_scope", scope)

        Dim responseBytes As Byte() = client.UploadValues("WRAPv0.9/", "POST", values)

        Dim response As String = Encoding.UTF8.GetString(responseBytes)

        Console.WriteLine(vbLf & "received token from ACS: {0}" & vbLf, response)

        Return HttpUtility.UrlDecode(response.Split("&"c).[Single](Function(value) value.StartsWith("wrap_access_token=", StringComparison.OrdinalIgnoreCase)).Split("="c)(1))
    End Function

    
End Class