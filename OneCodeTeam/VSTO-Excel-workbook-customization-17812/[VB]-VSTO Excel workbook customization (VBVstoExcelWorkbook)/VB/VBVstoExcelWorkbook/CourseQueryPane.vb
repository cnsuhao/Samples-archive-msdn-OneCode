' ************************************* Module Header **************************************\
' Module Name:	CourseQueryPane.vb
' Project:		VBVstoExcelWorkbook
' Copyright (c) Microsoft Corporation.
' The VBVstoExcelWorkbook provides the examples on how to customize Excel 
' Workbooks by using the ListObject and the document Actions Pane.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' ARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
' ***************************************************************************/

Public Class CourseQueryPane

    Private Sub CourseQueryPane_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Fill the student names list.
        Me.StudentListTableAdapter.Fill(Me.SchoolDataSet.StudentList)
    End Sub

    Private Sub cmdQuery_Click(sender As System.Object, e As System.EventArgs) Handles cmdQuery.Click
        ' Update course list for selected student.
        Globals.Sheet1.UpdateCourseList(cboName.Text.Trim())
    End Sub
End Class
