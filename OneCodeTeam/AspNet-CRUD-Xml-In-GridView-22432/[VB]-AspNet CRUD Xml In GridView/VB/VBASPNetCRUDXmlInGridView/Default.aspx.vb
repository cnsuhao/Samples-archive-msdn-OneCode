'***************************** Module Header ******************************\
'* Module Name:    Default.aspx.vb
'* Project:        ASPNETCRUDXmlInGridView
'* Copyright (c) Microsoft Corporation
'*
'* The project shows up how to insert/delete/update a record into the xml file
'* by the GridView.
'* 
'* This source is subject to the Microsoft Public License.
'* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
'* All other rights reserved.
'\**************************************************************************

Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data

Public Class _Default
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' For the first time when the page loads, load data into DataTable 
    ''' with DataSet, and save the DataTable into ViewState for further
    ''' usage.
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim ds As New DataSet()
            ds.ReadXml(Request.MapPath("try.xml"))
            GridView1.DataSource = ds.Tables(0)
            GridView1.DataBind()
            ViewState("dt") = ds.Tables(0)
        End If
    End Sub

    ''' <summary>
    ''' Handle the Edit event of GridView for assigning the specific row to be 
    ''' in the edit mode.
    ''' </summary>
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        GridView1.EditIndex = e.NewEditIndex
        GridView1.DataSource = DirectCast(ViewState("dt"), DataTable)
        GridView1.DataBind()
    End Sub

    ''' <summary>
    ''' Update the specific row in the DataTable with the data from GridView,
    ''' re-write the data into the xml file and re-databind again.
    ''' </summary>
    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)
        Dim dt As DataTable = DirectCast(ViewState("dt"), DataTable)

        For i As Integer = 1 To GridView1.Rows(e.RowIndex).Cells.Count - 1
            dt.Rows(e.RowIndex)(i - 1) = TryCast(GridView1.Rows(e.RowIndex).Cells(i).Controls(0), TextBox).Text
        Next
        dt.AcceptChanges()
        GridView1.EditIndex = -1
        GridView1.DataSource = dt
        GridView1.DataBind()
        dt.WriteXml(Request.MapPath("try.xml"))
    End Sub

    ''' <summary>
    ''' Cancel edit and set the mode of the GridView to normal viewing mode.
    ''' </summary>
    Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)
        GridView1.EditIndex = -1
        Dim dt As DataTable = DirectCast(ViewState("dt"), DataTable)
        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub

    ''' <summary>
    ''' Insert the data into the DataTable, re-write into the xml file and
    ''' re-databind to the GridView.
    ''' </summary>
    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim dt As DataTable = DirectCast(ViewState("dt"), DataTable)
        dt.Rows.Add(tbAuthor.Text, tbTitle.Text, tbGenre.Text, tbPrice.Text, tbPublishDate.Text, tbDescription.Text, _
         tbId.Text)
        dt.AcceptChanges()
        dt.WriteXml(Request.MapPath("try.xml"))
        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub

    ''' <summary>
    ''' Delete the row from DataTable and write data into xml file,
    ''' re-databind to the GridView.
    ''' </summary>
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)
        Dim dt As DataTable = DirectCast(ViewState("dt"), DataTable)
        dt.Rows.RemoveAt(e.RowIndex)
        dt.WriteXml(Request.MapPath("try.xml"))
        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub

End Class