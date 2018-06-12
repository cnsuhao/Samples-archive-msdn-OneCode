'****************************** Module Header ******************************\
' Module Name:    b.aspx.vb
' Project:        VBASPNETClearVariablesOnClickOfBackButton
' Copyright (c) Microsoft Corporation

' A page will show the data enter in a.aspx.

' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Partial Public Class b
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not String.IsNullOrEmpty(TryCast(Session("uName"), String)) Then
            Response.Write(Session("uName").ToString())
        End If
        Response.Write("<br/>")
        If Not String.IsNullOrEmpty(TryCast(Session("uPwd"), String)) Then
            Response.Write(Session("uPwd").ToString())
        End If
    End Sub

End Class