'************************** Module Header ******************************\
' Module Name:    GetIdentityClass.vb
' Project:        VBSharePointCallClaimsAwareWCF
' Copyright (c) Microsoft Corporation
'
' This class is used to get SharePoint Logged-on user’s security Token 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************

Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Microsoft.IdentityModel.Claims

Namespace CustomService
    Public NotInheritable Class GetIdentityClass
        Private Sub New()
        End Sub
        Private Const IdentityClaimType As String = "http://schemas.microsoft.com/sharepoint/2009/08/claims/userid"

        Public Shared Function GetIdentity() As String
            ' Identity Name
            Dim identityName As String = [String].Empty

            ' Get the Identity of the Current Principal
            Dim claimsIdentity As IClaimsIdentity = TryCast(System.Threading.Thread.CurrentPrincipal.Identity, IClaimsIdentity)

            If claimsIdentity IsNot Nothing Then
                ' claim
                For Each claim As Claim In claimsIdentity.Claims
                    If [String].Equals(IdentityClaimType, claim.ClaimType, StringComparison.OrdinalIgnoreCase) Then
                        identityName = claim.Value
                        Exit For
                    End If
                Next
            Else
                identityName = System.Threading.Thread.CurrentPrincipal.Identity.Name
            End If

            Return identityName
        End Function
    End Class
End Namespace
