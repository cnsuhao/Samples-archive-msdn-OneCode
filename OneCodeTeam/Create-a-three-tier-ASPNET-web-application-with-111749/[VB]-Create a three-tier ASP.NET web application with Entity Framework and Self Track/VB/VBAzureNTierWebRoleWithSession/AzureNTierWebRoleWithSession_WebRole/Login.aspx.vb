'****************************** Module Header ******************************\
' Module Name:  Login.aspx.vb
' Project:      AzureNTierWebRoleWithSession_WebRole
' Copyright (c) Microsoft Corporation.
'
' The sample code demonstrates how to build a simple 3-tier Asp.net Web Role, 
' which uses Entity Framework (SQL Azure database) as the Data Access Layer. 
' This sample also shows how to implement a User Session Handling (With Azure Cache Service).
'
' The login page demonstrates a simple login function to record user's basic information
' in cache.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    ''' <summary>
    ''' User login function.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        If tbUsername.Text.Trim() = "default" AndAlso tbPassword.Text.Trim() = "123" Then
            Dim user As New UserEntity()
            user.UserName = tbUsername.Text.Trim()
            user.PassWord = tbPassword.Text.Trim()
            Session("user") = user
            Response.Redirect("Default.aspx")
        Else
            lbContent.Text = "Username or password is invalid."
        End If
    End Sub
End Class