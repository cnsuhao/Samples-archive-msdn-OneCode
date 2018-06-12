'****************************** Module Header ******************************\
'Module Name:  ContentPage.aspx.vb
'Project:      VBASPNETMasterPage
'Copyright (c) Microsoft Corporation.
'
'This page is the content page of Master.master page.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Partial Public Class ContentPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim lbMasterPageHello As Label = TryCast(Master.FindControl("lbHello"), Label)

        If lbMasterPageHello IsNot Nothing Then
            lbMasterPageHello.Text = "Hello, " & txtName.Text & "!"
        End If
    End Sub
End Class