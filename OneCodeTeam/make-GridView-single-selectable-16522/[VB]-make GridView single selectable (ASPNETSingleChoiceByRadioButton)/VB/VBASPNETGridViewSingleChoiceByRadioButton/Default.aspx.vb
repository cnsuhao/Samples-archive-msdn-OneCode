'***************************** Module Header ******************************\
' Module Name:    Default.aspx.vb
' Project:        VBASPNETGridViewSingleChoiceByRadioButton
' Copyright (c) Microsoft Corporation
'
' This page shows how to make a GridView "single selectable" by clicking the 
' radio button each time.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Public Class _Default
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' Create a dynamic datatable and store it into ViewState 
    ''' for further use.
    ''' </summary>
    Private Sub MyDataBind()
        If ViewState("dt") Is Nothing Then
            Dim dt As New DataTable()
            dt.Columns.Add("Id", GetType(Integer))

            For i As Integer = 1 To 20
                dt.Rows.Add(i)
            Next
            ViewState("dt") = dt
        End If
        GridView1.DataSource = TryCast(ViewState("dt"), DataTable)
        GridView1.DataBind()
    End Sub

    ''' <summary>
    ''' Initializing to bind with the generated data table.
    ''' </summary>
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            MyDataBind()
        End If
    End Sub

    ''' <summary>
    ''' Change the current GridView's PageIndex
    ''' </summary>
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
    End Sub

    ''' <summary>
    ''' After changing the current GridView's PageIndex, rebind to the GridView.
    ''' </summary>
    Protected Sub GridView1_PageIndexChanged(sender As Object, e As EventArgs)
        MyDataBind()
        GridView1.SelectedIndex = -1
    End Sub

    ''' <summary>
    ''' When choosing a radio button, get the selected row's primary key's value. 
    ''' And make this row selected to change its background color.
    ''' </summary>
    Protected Sub radChoice_CheckedChanged(sender As Object, e As EventArgs)
        Dim gr As GridViewRow = TryCast(DirectCast(sender, Control).NamingContainer, GridViewRow)
        lbId.Text = "The current selected row's primary key's value is：" & GridView1.DataKeys(gr.RowIndex).Value.ToString()
        GridView1.SelectedIndex = Convert.ToInt32(hidSelectedRowIndex.Value)
    End Sub

End Class