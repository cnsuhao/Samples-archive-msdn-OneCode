'***************************** Module Header ******************************\
'* Module Name:    CourseChooice.vb
'* Project:        VBASPNETCodeFirstCRUDInGridViewWithDetailsView
'* Copyright (c) Microsoft Corporation
'*
'* This page offers a UI for us to create, delete or update a course choice
'* information.
'* 
'* This source is subject to the Microsoft Public License.
'* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
'* All other rights reserved.
'\**************************************************************************


Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls


Public Class CourseChoice
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' Rebind the Rest Courses' Dropdownlist and decide whether to show
    ''' error message and enable the "Add" button.
    ''' </summary>
    Private Sub ReBind()
        ddrRestCourses.DataBind()
        btnAdd.Enabled = (ddrRestCourses.Items.Count > 0)
        lbmsg.Visible = (ddrRestCourses.Items.Count = 0)

    End Sub

    ''' <summary>
    ''' first time when loading to check.
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ReBind()
        End If
    End Sub

    ''' <summary>
    ''' After adding a course choice, refresh the dropdownlist.
    ''' </summary>
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs)
        Student_CourseDataSource.InsertParameters("sid").DefaultValue = ddrStudents.SelectedValue
        Student_CourseDataSource.InsertParameters("cid").DefaultValue = ddrRestCourses.SelectedValue
        Student_CourseDataSource.InsertParameters("score").DefaultValue = tbScore.Text
        Student_CourseDataSource.Insert()
        GridView1.DataBind()
        ddrRestCourses.DataBind()
        ReBind()
    End Sub

    ''' <summary>
    ''' After deleting a course choice, refresh the dropdownlist.
    ''' </summary>
    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As GridViewDeletedEventArgs)
        ReBind()
    End Sub

    ''' <summary>
    ''' After selecting a course choice, refresh the dropdownlist.
    ''' </summary>
    Protected Sub ddrStudents_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddrStudents.SelectedIndexChanged
        ReBind()
    End Sub

End Class