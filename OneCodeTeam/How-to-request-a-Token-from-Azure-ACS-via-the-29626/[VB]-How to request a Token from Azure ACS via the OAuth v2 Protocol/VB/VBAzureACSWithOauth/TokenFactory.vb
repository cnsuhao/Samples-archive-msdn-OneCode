'**************************** Module Header ******************************\
' Module Name:	TokenFactory.vb
' Project:		VBAzureACSWithOauth
' Copyright (c) Microsoft Corporation.
' 
' This sample shows how to request a token from ACS via the OAuth.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************/
Imports System.Security.Cryptography
Imports System.Web
Imports System.Text

Public Class TokenFactory
    Private signingKey As String
    Private issuer As String

    Public Sub New(issuer As String, signingKey As String)
        Me.issuer = issuer
        Me.signingKey = signingKey
    End Sub

    Public Function CreateToken() As String
        Dim builder As New StringBuilder()

        ' Add the issuer name
        builder.Append("Issuer=")
        builder.Append(HttpUtility.UrlEncode(Me.issuer))

        Dim signature As String = Me.GenerateSignature(builder.ToString(), Me.signingKey)
        builder.Append("&HMACSHA256=")
        builder.Append(signature)

        Return builder.ToString()
    End Function


    Private Function GenerateSignature(unsignedToken As String, signingKey As String) As String
        Dim hmac As New HMACSHA256(Convert.FromBase64String(signingKey))

        Dim locallyGeneratedSignatureInBytes As Byte() = hmac.ComputeHash(Encoding.ASCII.GetBytes(unsignedToken))

        Dim locallyGeneratedSignature As String = HttpUtility.UrlEncode(Convert.ToBase64String(locallyGeneratedSignatureInBytes))

        Return locallyGeneratedSignature
    End Function
End Class