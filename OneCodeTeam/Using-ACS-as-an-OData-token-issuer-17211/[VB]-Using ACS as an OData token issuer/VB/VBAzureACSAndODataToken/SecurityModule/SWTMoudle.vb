'****************************** Module Header ******************************\
' Module Name:  SWTMoudle.vb
' Project:      SecurityModule
' Copyright (c) Microsoft Corporation.
'
' The sample code demonstrates how to access the WCF service via Access control
' service token. Here we create a Silverlight application and a normal Console 
' application client. The Token format is SWT, and we will use password as the 
' Service identities.
'
' This class gets token from ACS via TokenPolicyKey.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.Web

Public Class SWTMoudle
    Implements IHttpModule
    Private serviceNamespace As String = "<Your ACS namespace>"
    Private acsHostName As String = "accesscontrol.windows.net"
    ' Certificate and keys
    Private trustedTokenPolicyKey As String = "<Your Signing certificate symmetric key>"
    ' Service Realm
    Private trustedAudience As String = "<Your ACS service path>"


    Private Sub IHttpModule_Dispose() Implements IHttpModule.Dispose

    End Sub

    Private Sub IHttpModule_Init(context As HttpApplication) Implements IHttpModule.Init
        AddHandler context.BeginRequest, AddressOf context_BeginRequest
    End Sub

    Private Sub context_BeginRequest(sender As Object, e As EventArgs)
        If HttpContext.Current.Request.Url.AbsolutePath.EndsWith(".svc") Then
            ' Get the authorization header
            Dim headerValue As String = HttpContext.Current.Request.Headers.[Get]("Authorization")

            ' Check that a value is there
            If String.IsNullOrEmpty(headerValue) Then
                Throw New ApplicationException("unauthorized")
            End If

            ' Check that it starts with 'WRAP'
            If Not headerValue.StartsWith("WRAP ") Then
                Throw New ApplicationException("unauthorized")
            End If

            Dim nameValuePair As String() = headerValue.Substring("WRAP ".Length).Split(New Char() {"="c}, 2)

            If nameValuePair.Length <> 2 OrElse nameValuePair(0) <> "access_token" OrElse Not nameValuePair(1).StartsWith("""") OrElse Not nameValuePair(1).EndsWith("""") Then
                Throw New ApplicationException("unauthorized")
            End If

            ' Trim off the leading and trailing double-quotes
            Dim token As String = nameValuePair(1).Substring(1, nameValuePair(1).Length - 2)

            ' Create a token validate
            Dim validator As New TokenValidator(Me.acsHostName, Me.serviceNamespace, Me.trustedAudience, Me.trustedTokenPolicyKey)

            ' Validate the token
            If Not validator.Validate(token) Then
                Throw New ApplicationException("unauthorized")
            End If
        End If
    End Sub
End Class
