'/****************************** Module Header ******************************\
' Module Name: ExportAndImportExcel.vb
' Project:     VBOpenXmlExportImportExcel
' Copyright(c) Microsoft Corporation.
' 
' The Main form.
' Users can use this form to export Data in GridView control to excel 
' and Import data from Excel document into GridView control.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\***************************************************************************/


Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet
Imports System.IO

Public Class ExportAndImportExcel
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Disable Export button
        Me.btnExport.Enabled = False

    End Sub

#Region "Import operation"

    ''' <summary>
    '''  Import Excel Data into GridView Control 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        ' The condition that FileUpload control contains a file 
        If FileUpload1.HasFile Then
            ' Get selected file name
            Dim filename As String = FileUpload1.PostedFile.FileName

            ' Get the extension of the selected file
            Dim fileExten As String = Path.GetExtension(filename)

            ' The condition that the extension is not xlsx
            If Not fileExten.Equals(".xlsx", StringComparison.OrdinalIgnoreCase) Then
                Response.Write("<script language=""javascript"">alert('The extension of selected file is incorrect ,please select again');</script>")
                Return
            End If

            ' Read Data in excel file
            Try
                Dim dt As DataTable = ReadExcelFile(filename)

                If dt.Rows.Count = 0 Then
                    Response.Write("<script language=""javascript"">alert('The first sheet is empty.');</script>")
                    Return
                End If

                ' Bind Datasource
                Me.gridViewTest.DataSource = dt
                Me.gridViewTest.DataBind()

                ' Enable Export button
                Me.btnExport.Enabled = True
            Catch ex As IOException
                Dim exceptionmessage As String = ex.Message
                Response.Write("<script language=""javascript"">alert(""" & exceptionmessage & """);</script>")
            End Try
        Else
            Response.Write("<script language=""javascript"">alert('You did not specify a file to import');</script>")
        End If
    End Sub

    ''' <summary>
    '''  Read Data from selected excel file on client
    ''' </summary>
    ''' <param name="filename">File Path</param>
    ''' <returns></returns>
    Private Function ReadExcelFile(filename As String) As DataTable
        ' Initializate an instance of DataTable
        Dim dt As New DataTable()

        Try
            ' Use SpreadSheetDocument class of Open XML SDK to open excel file
            Using _spreadsheetDocument As SpreadsheetDocument = SpreadsheetDocument.Open(filename, False)
                ' Get Workbook Part of Spread Sheet Document
                Dim workbookPart As WorkbookPart = _spreadsheetDocument.WorkbookPart

                ' Get all sheets in spread sheet document 
                Dim sheetcollection As IEnumerable(Of Sheet) = _spreadsheetDocument.WorkbookPart.Workbook.GetFirstChild(Of Sheets)().Elements(Of Sheet)()

                ' Get relationship Id
                Dim relationshipId As String = sheetcollection.First().Id.Value

                ' Get sheet1 Part of Spread Sheet Document
                Dim worksheetPart As WorksheetPart = DirectCast(_spreadsheetDocument.WorkbookPart.GetPartById(relationshipId), WorksheetPart)

                ' Get Data in Excel file
                Dim sheetData As SheetData = worksheetPart.Worksheet.Elements(Of SheetData)().First()
                Dim rowcollection As IEnumerable(Of Row) = sheetData.Descendants(Of Row)()

                If rowcollection.Count() = 0 Then
                    Return dt
                End If

                ' Add columns
                For Each cell As Cell In rowcollection.ElementAt(0)
                    dt.Columns.Add(GetValueOfCell(_spreadsheetDocument, cell))
                Next

                ' Add rows into DataTable
                For Each row As Row In rowcollection
                    Dim temprow As DataRow = dt.NewRow()
                    For i As Integer = 0 To row.Descendants(Of Cell)().Count() - 1
                        temprow(i) = GetValueOfCell(_spreadsheetDocument, row.Descendants(Of Cell)().ElementAt(i))
                    Next

                    ' Add the row to DataTable
                    ' the rows include header row
                    dt.Rows.Add(temprow)
                Next
            End Using

            ' Here remove header row
            dt.Rows.RemoveAt(0)
            Return dt
        Catch ex As IOException
            Throw New IOException(ex.Message)
        End Try
    End Function

    ''' <summary>
    '''  Get Value in Cell 
    ''' </summary>
    ''' <param name="spreadsheetdocument">SpreadSheet Document</param>
    ''' <param name="cell">Cell in SpreadSheet Document</param>
    ''' <returns>The value in cell</returns>
    Private Shared Function GetValueOfCell(spreadsheetdocument As SpreadsheetDocument, cell As Cell) As String
        ' Get value in Cell
        Dim sharedString As SharedStringTablePart = spreadsheetdocument.WorkbookPart.SharedStringTablePart
        If cell.CellValue Is Nothing Then
            Return String.Empty
        End If

        Dim cellValue As String = cell.CellValue.InnerText

        ' The condition that the Cell DataType is SharedString
        If cell.DataType IsNot Nothing AndAlso cell.DataType.Value = CellValues.SharedString Then
            Return sharedString.SharedStringTable.ChildElements(Integer.Parse(cellValue)).InnerText
        Else
            Return cellValue
        End If
    End Function

#End Region

#Region "Export operation"

    ''' <summary>
    '''  Export Data in GridView control to Excel file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ' Initialize an instance of DataTable
        Dim dt As DataTable = CreateDataTable(Me.gridViewTest)

        ' Save the exported file 
        Dim appPath As String = Request.PhysicalApplicationPath
        Dim filename As String = Guid.NewGuid().ToString() & ".xlsx"
        Dim filePath As String = appPath & filename

        Dim exportprovider As CreateSpreadSheetProvider = New CreateSpreadSheetProvider()
        exportprovider.ExportToExcel(dt, filePath)

        Dim savefilepath As String = "Export Excel file successfully, the exported excel file is placed in: " & filePath
        Response.Write("<script language='javascript'>alert('" & savefilepath.Replace("\", "\\") & "');</script>")

    End Sub

    ''' <summary>
    '''  Create DataTable from GridView Control
    ''' </summary>
    ''' <param name="girdViewtest">GridView Control</param>
    ''' <returns>An instance of DataTable Object</returns>
    Private Function CreateDataTable(girdViewtest As GridView) As DataTable
        Dim dt As New DataTable()

        ' Get columns from GridView
        ' Add value of columns to DataTable 
        For i As Integer = 0 To gridViewTest.HeaderRow.Cells.Count - 1
            dt.Columns.Add(gridViewTest.HeaderRow.Cells(i).Text)
        Next

        ' Get rows from GridView
        For Each row As GridViewRow In gridViewTest.Rows
            Dim datarow As DataRow = dt.NewRow()
            For i As Integer = 0 To row.Cells.Count - 1
                datarow(i) = row.Cells(i).Text.Replace("&nbsp;", " ")
            Next

            ' Add rows to DataTable
            dt.Rows.Add(datarow)

        Next

        Return dt
    End Function

#End Region

End Class