' ************************************ Module Header **************************************\
' Module Name:	ThisWorkbook.vb
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

Public Class ThisWorkbook

    Private Sub ThisWorkbook_Startup() Handles Me.Startup
        ' Adds the CourseQueryPane to the ActionsPane.
        ' To toggle the ActionsPane on/off, click the View tab in Excel Ribbon,
        ' then in the Show/Hide group, toggle the Document Actions button.
        Me.ActionsPane.Controls.Add(New CourseQueryPane())
    End Sub

    Private Sub ThisWorkbook_Shutdown() Handles Me.Shutdown

    End Sub

End Class
