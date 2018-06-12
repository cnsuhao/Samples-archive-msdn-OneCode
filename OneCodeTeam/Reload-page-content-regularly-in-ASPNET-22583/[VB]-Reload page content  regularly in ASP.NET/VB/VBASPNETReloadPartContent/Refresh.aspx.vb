'****************************** Module Header ******************************\
' Module Name:  Refresh.aspx.cs
' Project:      VBASPNETReloadPartContent
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to reload part of page content regularly.
' This page is used to load the data. 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Partial Public Class Refresh
    Inherits System.Web.UI.Page

    'Declare a table to store data:custom or query from Database
    Dim dtResult As DataTable = Nothing


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Put your logic here.
        BindResult()
    End Sub

    'Here i create a table to store the time of refresh,you can put your logic here instead of it.
    Private Sub BindResult()
        'In the actual scene, you may not need operating the session, here is just to test
        If Session("dtResult") IsNot Nothing Then
            dtResult = DirectCast(Session("dtResult"), DataTable)
        Else
            dtResult = New DataTable()
            dtResult.Columns.Add("Id")
            dtResult.Columns.Add("Time")
        End If

        Dim dr As DataRow = dtResult.NewRow()
        dr("Id") = dtResult.Rows.Count + 1
        dr("Time") = DateTime.Now.ToString()
        dtResult.Rows.Add(dr)

        'Save data to Session, in a 
        Session("dtResult") = dtResult
        'Bind data to GridView

        rptResult.DataSource = dtResult
        rptResult.DataBind()
    End Sub

End Class