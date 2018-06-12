'***************************** Module Header ******************************\
' Module Name:	Default.aspx.vb
' Project:		VBAzureIdentifyWithLiveID
' Copyright (c) Microsoft Corporation.
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

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("UserName") IsNot Nothing Then
            hlkLogin.Visible = False
            lblUserName.Visible = True
            lblUserName.Text = "Welcome! " + Session("UserName").ToString()
        Else
            hlkLogin.Visible = True
            lblUserName.Visible = False
        End If
    End Sub

End Class