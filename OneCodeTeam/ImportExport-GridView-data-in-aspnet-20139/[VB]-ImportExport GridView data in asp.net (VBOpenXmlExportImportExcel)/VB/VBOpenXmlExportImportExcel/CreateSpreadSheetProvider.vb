'/****************************** Module Header ******************************\
' Module Name: CreateSpreadSheetProvider.vb
' Project:     VBOpenXmlExportImportExcel
' Copyright(c) Microsoft Corporation.
' 
' The class is used to create spreadsheet document. 
' We can create spreadsheet document structure and content by using strongly-typed 
' classes that correspond to SpreadsheetMl elements in Open XML SDK 2.0.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\***************************************************************************/


Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet

Public Class CreateSpreadSheetProvider

    ' The collection of Excel columns
    Private Shared excelColumns As String() = {"A", "B", "C", "D", "E", "F",
     "G", "H", "I", "J", "K", "L",
     "M", "N", "O", "P", "Q", "R",
     "S", "T", "U", "V", "W", "X",
     "Y", "Z"}
    Private cellHeaders As List(Of String) = Nothing

    Public Sub New()
        Me.InitilizeCellHeaders()
    End Sub

    ''' <summary>
    '''  Add the item into List
    ''' </summary>
    Private Sub InitilizeCellHeaders()
        cellHeaders = New List(Of String)()
        For Each sItem As String In excelColumns
            cellHeaders.Add(sItem)
        Next
    End Sub
    ''' <summary>
    '''  Returns the column caption for the given row and column index
    ''' </summary>
    ''' <param name="rowIndex">Index of the row.</param>
    ''' <param name="columnIndex">Index of the column.</param>
    ''' <returns></returns>
    Private Function [Get](columnIndex As Integer, rowIndex As Integer) As String
        Return Me.cellHeaders.ElementAt(columnIndex) & (rowIndex + 1).ToString()
    End Function

    ''' <summary>
    '''  Generate an excel file with data in GridView control
    ''' </summary>
    ''' <param name="datatable">DataTable object</param>
    ''' <param name="filepath">The Path of exported excel file</param>
    Public Sub ExportToExcel(datatable As DataTable, filepath As String)
        ' Initialize an instance of  SpreadSheet Document 
        Using _spreadsheetDocument As SpreadsheetDocument = SpreadsheetDocument.Create(filepath, SpreadsheetDocumentType.Workbook)
            CreateExcelFile(_spreadsheetDocument, datatable)
        End Using
    End Sub

    ''' <summary>
    '''  Create SpreadSheet Document and Fill datas
    ''' </summary>
    ''' <param name="spreadsheetdoc">SpreadSheet Document</param>
    ''' <param name="table">DataTable Object</param>
    Private Sub CreateExcelFile(spreadsheetdoc As SpreadsheetDocument, table As DataTable)
        ' Initialize an instance of WorkbookPart
        Dim workBookPart As WorkbookPart = spreadsheetdoc.AddWorkbookPart()

        ' Create WorkBook 
        CreateWorkBookPart(workBookPart)

        ' Add WorkSheetPart into WorkBook
        Dim worksheetPart1 As WorksheetPart = workBookPart.AddNewPart(Of WorksheetPart)("rId1")
        CreateWorkSheetPart(worksheetPart1, table)

        ' Add SharedStringTable Part into WorkBook
        Dim sharedStringTablePart As SharedStringTablePart = workBookPart.AddNewPart(Of SharedStringTablePart)("rId2")
        CreateSharedStringTablePart(sharedStringTablePart, table)

        ' Add WorkbookStyles Part into Workbook
        Dim workbookStylesPart As WorkbookStylesPart = workBookPart.AddNewPart(Of WorkbookStylesPart)("rId3")
        CreateWorkBookStylesPart(workbookStylesPart)

        ' Save workbook
        workBookPart.Workbook.Save()
    End Sub

    ''' <summary>
    ''' Create an Workbook instance and add its children
    ''' </summary>
    ''' <param name="workbookPart">WorkbookPart Object</param>
    Private Sub CreateWorkBookPart(workbookPart As WorkbookPart)
        Dim workbook As New Workbook()
        Dim sheets As New Sheets()

        ' Initilize an instance of Sheet Object
        Dim sheet1 As New Sheet() With { _
         .Name = "Sheet1", _
         .SheetId = Convert.ToUInt32(1),
         .Id = "rId1"
        }

        ' Add the sheet into sheets collection
        sheets.Append(sheet1)

        Dim calculationProperties1 As New CalculationProperties() With { _
          .CalculationId = Convert.ToUInt32(111222)
        }

        ' Add elements into workbook
        workbook.Append(sheets)
        workbook.Append(calculationProperties1)
        workbookPart.Workbook = workbook
    End Sub

    ''' <summary>
    '''  Generates content of worksheetPart
    ''' </summary>
    ''' <param name="worksheetPart">WorksheetPart Object</param>
    ''' <param name="table">DataTable Object</param>
    Private Sub CreateWorkSheetPart(worksheetPart As WorksheetPart, table As DataTable)
        ' Initialize worksheet and set the properties
        Dim worksheet1 As New Worksheet() With { _
          .MCAttributes = New MarkupCompatibilityAttributes() With {
           .Ignorable = "x14ac"
         }
        }
        worksheet1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships")
        worksheet1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006")
        worksheet1.AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac")

        Dim sheetViews1 As New SheetViews()

        ' Initialize an instance of the sheetview class
        Dim sheetView1 As New SheetView() With { _
          .WorkbookViewId = Convert.ToUInt32(0)
        }

        Dim selection As New Selection() With { _
          .ActiveCell = "A1"
        }

        sheetView1.Append(selection)

        sheetViews1.Append(sheetView1)
        Dim sheetFormatProperties1 As New SheetFormatProperties() With { _
          .DefaultRowHeight = 15.0, _
          .DyDescent = 0.25 _
        }

        Dim sheetData1 As New SheetData()
        Dim rowIndex As UInt32 = 1UI
        Dim pageMargins1 As New PageMargins() With { _
          .Left = 0.7, _
          .Right = 0.7, _
          .Top = 0.75, _
          .Bottom = 0.75, _
          .Header = 0.3, _
          .Footer = 0.3
        }

        Dim row1 As New Row() With { _
          .RowIndex = rowIndex, _
          .Spans = New ListValue(Of StringValue)() With { _
           .InnerText = "1:3" _
         }, _
          .DyDescent = 0.25 _
        }

        ' Add columns in DataTable to columns collection of SpreadSheet Document 
        For columnindex As Integer = 0 To table.Columns.Count - 1
            Dim cell As New Cell() With { _
              .CellReference = New CreateSpreadSheetProvider().[Get](columnindex, (Convert.ToInt32(UInt32Value.ToUInt32(rowIndex)) - 1)), _
              .DataType = CellValues.[String]
            }

            ' Get Value of DataTable and append the value to cell of spreadsheet document
            Dim cellValue As New CellValue()
            cellValue.Text = table.Columns(columnindex).ColumnName.ToString()
            cell.Append(cellValue)

            row1.Append(cell)
        Next

        ' Add row to sheet
        sheetData1.Append(row1)

        ' Add rows in DataTable to rows collection of SpreadSheet Document 
        For rIndex As Integer = 0 To table.Rows.Count - 1
            rowIndex = UInt32Value.ToUInt32(rowIndex) + 1
            Dim row As New Row() With { _
              .RowIndex = rowIndex, _
              .Spans = New ListValue(Of StringValue)() With { _
               .InnerText = "1:3" _
             }, _
              .DyDescent = 0.25 _
            }

            For cIndex As Integer = 0 To table.Columns.Count - 1
                Dim cell As New Cell() With { _
                  .CellReference = New CreateSpreadSheetProvider().[Get](cIndex, (Convert.ToInt32(UInt32Value.ToUInt32(rowIndex)) - 1)), _
                  .DataType = CellValues.[String] _
                }

                Dim cellValue As New CellValue()
                cellValue.Text = table.Rows(rIndex)(cIndex).ToString()
                cell.Append(cellValue)
                row.Append(cell)
            Next

            ' Add row to Sheet Data
            sheetData1.Append(row)
        Next

        ' Add elements to worksheet
        worksheet1.Append(sheetViews1)
        worksheet1.Append(sheetFormatProperties1)
        worksheet1.Append(sheetData1)
        worksheet1.Append(pageMargins1)

        worksheetPart.Worksheet = worksheet1
    End Sub

    ''' <summary>
    ''' Generates content of sharedStringTablePart
    ''' </summary>
    ''' <param name="sharedStringTablePart">SharedStringTablePart Object</param>
    ''' <param name="table">DataTable Object</param>
    Private Sub CreateSharedStringTablePart(sharedStringTablePart As SharedStringTablePart, table As DataTable)
        Dim stringCount As UInt32Value = Convert.ToUInt32(table.Rows.Count) + Convert.ToUInt32(table.Columns.Count)

        ' Initialize an instance of SharedString Table
        Dim sharedStringTable As New SharedStringTable() With { _
          .Count = stringCount, _
          .UniqueCount = stringCount
        }

        ' Add columns of DataTable to sharedString iteam
        For columnIndex As Integer = 0 To table.Columns.Count - 1
            Dim sharedStringItem As New SharedStringItem()
            Dim text As New Text()
            text.Text = table.Columns(columnIndex).ColumnName
            sharedStringItem.Append(text)

            ' Add sharedstring item to sharedstring Table
            sharedStringTable.Append(sharedStringItem)
        Next

        ' Add rows of DataTable to sharedString iteam
        For rowIndex As Integer = 0 To table.Rows.Count - 1
            Dim sharedStringItem As New SharedStringItem()
            Dim text As New Text()
            text.Text = table.Rows(rowIndex)(0).ToString()
            sharedStringItem.Append(text)
            sharedStringTable.Append(sharedStringItem)
        Next

        sharedStringTablePart.SharedStringTable = sharedStringTable
    End Sub

    ''' <summary>
    ''' Generates content of workbookStylesPart
    ''' </summary>
    ''' <param name="workbookStylesPart">WorkbookStylesPart Object</param>
    Private Sub CreateWorkBookStylesPart(workbookStylesPart As WorkbookStylesPart)
        ' Define Style of Sheet in workbook
        Dim stylesheet1 As New Stylesheet() With { _
          .MCAttributes = New MarkupCompatibilityAttributes() With { _
           .Ignorable = "x14ac" _
         } _
        }
        stylesheet1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006")
        stylesheet1.AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac")

        ' Initialize  an instance of fonts
        Dim fonts As New Fonts() With { _
          .Count = 2UI, _
          .KnownFonts = True
        }

        ' Initialize  an instance of font,fontsize,color
        Dim font As New Font()
        Dim fontSize As New FontSize() With { _
          .Val = 14.0 _
        }
        Dim color As New Color() With { _
          .Theme = 1UI
        }
        Dim fontName As New FontName() With { _
          .Val = "Calibri" _
        }
        Dim fontFamilyNumbering As New FontFamilyNumbering() With { _
          .Val = 2UI
        }
        Dim fontScheme As New FontScheme() With { _
          .Val = FontSchemeValues.Minor _
        }

        ' Add elements to font
        font.Append(fontSize)
        font.Append(color)
        font.Append(fontName)
        font.Append(fontFamilyNumbering)
        font.Append(fontScheme)

        fonts.Append(font)

        ' Define the StylesheetExtensionList Class. When the object is serialized out as xml, its qualified name is x:extLst
        Dim stylesheetExtensionList1 As New StylesheetExtensionList()

        ' Define the StylesheetExtension Class
        Dim stylesheetExtension1 As New StylesheetExtension() With { _
          .Uri = "{EB79DEF2-80B8-43e5-95BD-54CBDDF9020C}" _
        }
        stylesheetExtension1.AddNamespaceDeclaration("x14", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main")
        Dim slicerStyles1 As New DocumentFormat.OpenXml.Office2010.Excel.SlicerStyles() With { _
          .DefaultSlicerStyle = "SlicerStyleLight1" _
        }

        stylesheetExtension1.Append(slicerStyles1)
        stylesheetExtensionList1.Append(stylesheetExtension1)

        ' Add elements to stylesheet
        stylesheet1.Append(fonts)
        stylesheet1.Append(stylesheetExtensionList1)

        ' Set the style of workbook
        workbookStylesPart.Stylesheet = stylesheet1
    End Sub

End Class
