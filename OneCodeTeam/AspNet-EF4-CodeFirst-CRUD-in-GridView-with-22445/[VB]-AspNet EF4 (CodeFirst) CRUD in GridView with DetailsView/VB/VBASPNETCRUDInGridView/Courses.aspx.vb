'***************************** Module Header ******************************\
'* Module Name:    Courses.vb
'* Project:        VBASPNETCodeFirstCRUDInGridViewWithDetailsView
'* Copyright (c) Microsoft Corporation
'*
'* The Courses.aspx page has a GridView to list all the courses and a DetailsView
'* for inserting, deleting and updating a course.
'* 
'* This source is subject to the Microsoft Public License.
'* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
'* All other rights reserved.
'\**************************************************************************


Imports System.Web
Imports System.Web.UI.WebControls


Partial Public Class Courses
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    ''' <summary>
    ''' After updating, reset the DetailsView and rebind GridView, DetailsView
    ''' to show the latest data contents.
    ''' </summary>
    Protected Sub DetailsView1_ItemUpdated(ByVal sender As Object, ByVal e As DetailsViewUpdatedEventArgs)
        GridView1.DataBind()
        DetailsView1.DataBind()
        DetailsView1.ChangeMode(DetailsViewMode.[ReadOnly])
        DetailsView1.DefaultMode = DetailsViewMode.[ReadOnly]
    End Sub

    ''' <summary>
    ''' After Selecting a specific data, set DetailsView to Edit mode for editing.
    ''' </summary>
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        DetailsView1.ChangeMode(DetailsViewMode.Edit)
        DetailsView1.DefaultMode = DetailsViewMode.Edit
    End Sub

    ''' <summary>
    ''' After inserted successfully, rebind GridView, DetailsView
    ''' to show the latest data contents.
    ''' </summary>
    Protected Sub DetailsView1_ItemInserted(ByVal sender As Object, ByVal e As DetailsViewInsertedEventArgs)
        GridView1.DataBind()
        DetailsView1.DataBind()
    End Sub

    ''' <summary>
    ''' Check whether CourseName is empty or not when inserting.
    ''' </summary>
    Protected Sub DetailsView1_ItemInserting(ByVal sender As Object, ByVal e As DetailsViewInsertEventArgs)
        Dim rv As RequiredFieldValidator = TryCast(DetailsView1.Rows(1).FindControl("RequiredFieldValidator2"), RequiredFieldValidator)
        rv.Validate()
        e.Cancel = Not rv.IsValid
    End Sub

    ''' <summary>
    ''' Check whether CourseName is empty or not when updating
    ''' </summary>
    Protected Sub DetailsView1_ItemUpdating(ByVal sender As Object, ByVal e As DetailsViewUpdateEventArgs)
        Dim rv As RequiredFieldValidator = TryCast(DetailsView1.Rows(1).FindControl("RequiredFieldValidator1"), RequiredFieldValidator)
        rv.Validate()
        e.Cancel = Not rv.IsValid
    End Sub

    ''' <summary>
    ''' Reset the DetailsView when clicking Cancel button.
    ''' </summary>
    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As EventArgs)
        DetailsView1.ChangeMode(DetailsViewMode.[ReadOnly])
        DetailsView1.DefaultMode = DetailsViewMode.[ReadOnly]
    End Sub
End Class

