'****************************** Module Header ******************************\
' Module Name:    a.aspx.vb
' Project:        VBASPNETClearVariablesOnClickOfBackButton
' Copyright (c) Microsoft Corporation

'  The VBASPNETClearVariablesOnClickOfBackButton sample demonstrates how to clear variables on click of Back button to previous page on browser

' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Partial Public Class a
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Clear out the session variable.
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1))
        Response.Cache.SetNoStore()
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        If Not String.IsNullOrEmpty(tbName.Text.Trim()) AndAlso Not String.IsNullOrEmpty(tbPwd.Text.Trim()) Then
            Session("uName") = tbName.Text
            Session("uPwd") = tbPwd.Text
            Response.Redirect("b.aspx")
        End If
    End Sub
End Class