'***************************** Module Header ******************************\
' Module Name:	Callback.aspx.vb
' Project:		VBAzureIdentifyWithLiveID
' Copyright (c) Microsoft Corporation.
' 
' The callback handler. Configure ACS to 
' redirect to this page after the user signs in.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Security.Claims
Public Class Callback
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim UserName = System.Security.Claims.ClaimsPrincipal.Current.FindFirst(ClaimTypes.Name).Value
        If UserName IsNot Nothing Then
            Session("UserName") = UserName
            Response.Redirect("Default.aspx")
        End If
    End Sub

End Class