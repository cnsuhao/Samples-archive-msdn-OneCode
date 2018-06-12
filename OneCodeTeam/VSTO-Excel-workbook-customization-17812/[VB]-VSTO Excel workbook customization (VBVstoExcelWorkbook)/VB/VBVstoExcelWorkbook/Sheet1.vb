' ************************************* Module Header **************************************\
' Module Name:	Sheet1.vb
' Project:		VBVstoExcelWorkbook
' Copyright (c) Microsoft Corporation.
' 
' The VBVstoExcelWorkbook provides the examples on how to customize Excel 
' Workbooks by using the ListObject and the document Actions Pane.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
' ***************************************************************************/

Public Class Sheet1

    Friend Sub UpdateCourseList(ByVal studentName As String)
        ' Update the title.
        Me.Range("A1", "A1").Value2 = "Course List for " & studentName
        ' Update the DataTable.
        CourseListTableAdapter.Fill(SchoolDataSet.CourseList, studentName)
    End Sub

    Private Sub Sheet1_Startup() Handles Me.Startup

    End Sub

    Private Sub Sheet1_Shutdown() Handles Me.Shutdown

    End Sub

End Class
