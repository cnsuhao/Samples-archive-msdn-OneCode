'***************************** Module Header ******************************\
'* Module Name:    Students.aspx.vb
'* Project:        VBASPNETCodeFirstCRUDInGridViewWithDetailsView
'* Copyright (c) Microsoft Corporation
'*
'* The whole file offers several CRUDs for Students page, Courses page as well
'* as CourseChoice page.
'* 
'* This source is subject to the Microsoft Public License.
'* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
'* All other rights reserved.
'\**************************************************************************

Imports System
Imports System.Web.UI

Partial Public Class Students
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
        End If
    End Sub

    ''' <summary>
    ''' Do inserting of Student and rebind to show the latest data.
    ''' </summary>
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        StudentDataSource.InsertParameters("StudentName").DefaultValue = tbStudentName.Text
        StudentDataSource.Insert()
        GridView1.DataBind()
        tbStudentName.Text = ""
    End Sub
End Class
