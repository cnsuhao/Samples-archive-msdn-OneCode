'****************************** Module Header ******************************\
' Module Name:  Default.aspx.vb
' Project:      AzureNTierWebRoleWithSession_WebRole
' Copyright (c) Microsoft Corporation.
'
' The sample code demonstrates how to build a simple 3-tier Asp.net Web Role, 
' which uses Entity Framework (SQL Azure database) as the Data Access Layer. 
' This sample also shows how to implement a User Session Handling (With Azure Cache Service).
'
' The default page loads the data from BLL method, and loads the user's information from 
' Azure Cache Service.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports BusinessLayer

Public Class _Default
    Inherits System.Web.UI.Page
    Public manager As BusinessManager
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Load user name from Azure Cache Service.
        If Session("user") IsNot Nothing Then
            Dim user As New UserEntity()
            user = TryCast(Session("user"), UserEntity)
            lbUser.Text = user.UserName
        End If

        ' Load TestTable data from BLL.
        manager = New BusinessManager()
        If Not Page.IsPostBack Then
            gvwDataSource.DataSource = manager.GetData()
            gvwDataSource.DataBind()
        End If
    End Sub

End Class