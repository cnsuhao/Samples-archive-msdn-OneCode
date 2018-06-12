'***************************** Module Header ******************************\
' Module Name:    Default.aspx.vb
' Project:        VBASPNETMultiFiltering
' Copyright (c) Microsoft Corporation
'
' This is the default interface that is used to show the user-defined control
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************/
Public Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            MultiFiltering1.BindingSqlDataSourceId = "SqlDataSource1"
        End If
    End Sub

    Protected Sub GridView1_PageIndexChanged(sender As Object, e As EventArgs)
        SqlDataSource1.FilterExpression = MultiFiltering1.FilterExpression
    End Sub

End Class