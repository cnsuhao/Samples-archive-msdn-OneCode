'***************************** Module Header ******************************\ 
' Module Name:   CompareHelper.vb
' Project:       VBExcelCompareCells
' Copyright (c)  Microsoft Corporation. 
'  
' The Class is used to compare cells in excel file
' 
'  
' This source is subject to the Microsoft Public License. 
' See http://www.microsoft.com/en-us/openness/licenses.aspx. 
' All other rights reserved. 
'  
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,  
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED  
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
'**************************************************************************/


Imports System.Runtime.InteropServices
Imports Excel = Microsoft.Office.Interop.Excel


Public Class CompareHelper

    ' Define Variables
    Private excelApp As Excel.Application
    Private excelWorkbook As Excel.Workbook
    Private excelWorkSheet1 As Excel.Worksheet
    Private excelWorkSheet2 As Excel.Worksheet
    Private lastLine As Integer

    ''' <summary>
    ''' Compare Cells in different columns in the same sheet of an excel file
    ''' </summary>
    ''' <param name="sourceCol">Source Column</param>
    ''' <param name="targetCol">Taget Column</param>
    ''' <param name="excelFile">The Path of Excel File</param>
    Public Sub CompareColumns(sourceCol As String, targetCol As String, excelFile As String)
        Try
            ' Create an instance of Microsoft Excel and make it invisible
            excelApp = New Excel.Application()
            excelApp.Visible = False

            ' open a Workbook and get the active Worksheet
            excelWorkbook = excelApp.Workbooks.Open(excelFile)
            excelWorkSheet1 = excelWorkbook.ActiveSheet

            ' maximum Row
            lastLine = excelWorkSheet1.UsedRange.Rows.Count
            For row As Integer = 1 To lastLine
                ' Compare cell value
                If excelWorkSheet1.Range(sourceCol & row.ToString()).Value <> excelWorkSheet1.Range(targetCol & row.ToString()).Value Then
                    excelWorkSheet1.Range(sourceCol & row.ToString()).Interior.Color = 255
                    excelWorkSheet1.Range(targetCol & row.ToString()).Interior.Color = 5296274
                End If
            Next

            ' Save WorkBook and close
            excelWorkbook.Save()
            excelWorkbook.Close()

            ' Quit Excel Application
            excelApp.Quit()
        Catch
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Compare Cells in different sheets of an excel file
    ''' </summary>
    ''' <param name="sourceSheetNum">Source Sheet Number</param>
    ''' <param name="targetSheetNum">Target Sheet Number</param>
    ''' <param name="excelFile">Path of Excel File</param>
    Public Sub CompareSheets(sourceSheetNum As Integer, targetSheetNum As Integer, excelFile As String)
        Try
            ' Create an instance of Microsoft Excel and make it invisible
            excelApp = New Excel.Application()
            excelApp.Visible = False
            excelWorkbook = excelApp.Workbooks.Open(excelFile)
            excelWorkSheet1 = excelWorkbook.Sheets(sourceSheetNum)
            excelWorkSheet2 = excelWorkbook.Sheets(targetSheetNum)
            lastLine = Math.Max(excelWorkSheet1.UsedRange.Rows.Count, excelWorkSheet2.UsedRange.Rows.Count)
            For row As Integer = 1 To lastLine
                ' maximum column 
                Dim lastCol As Integer = Math.Max(excelWorkSheet1.UsedRange.Columns.Count, excelWorkSheet2.UsedRange.Columns.Count)
                For column As Integer = 1 To lastCol
                    If excelWorkSheet1.Cells(row, column).Value <> excelWorkSheet2.Cells(row, column).Value Then
                        DirectCast(excelWorkSheet1.Cells(row, column), Excel.Range).Interior.Color = 255
                        DirectCast(excelWorkSheet2.Cells(row, column), Excel.Range).Interior.Color = 5296274
                    End If
                Next
            Next

            ' Save WorkBook and close
            excelWorkbook.Save()
            excelWorkbook.Close()

            ' Quit Excel Application
            excelApp.Quit()
        Catch
            Throw
        End Try
    End Sub

End Class
