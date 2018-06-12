'****************************** Module Header ******************************\
' Module Name:  Default.aspx.vb
' Project:      VBASPNETMultiHeadGridView
' Copyright (c) Microsoft Corporation
'
' This is the main page of this sample that illustrates how to build
' the Multi-Head GridView
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Public Class Defaut
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    ''' <summary>
    ''' Handle the RowCreated event to create Multiple-Headed.
    ''' Create some TableCell's instance and then added to the 
    ''' Header Row, and then added to the GridView. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub gdvData_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdvData.RowCreated
        ' To judge whether RowHeader.
        If e.Row.RowType = DataControlRowType.Header Then
            ' TableCell for Header 1
            Dim headerCell1 As TableCell = New TableCell()
            Dim headerCell2 As TableCell = New TableCell()

            ' The TableCell's definition
            headerCell1.ColumnSpan = 3
            headerCell1.Text = "Main Header 1"
            headerCell1.BackColor = Drawing.Color.LightGray
            headerCell1.HorizontalAlign = HorizontalAlign.Center

            ' The TableCell's definition
            headerCell2.ColumnSpan = 2
            headerCell2.Text = "Main Header 2"
            headerCell2.BackColor = Drawing.Color.LightGray
            headerCell2.HorizontalAlign = HorizontalAlign.Center

            ' Add TableCell to TableRow.Cells and then add tableRow to GridView(gdvData)
            Dim rowHeader1 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
            rowHeader1.Cells.Add(headerCell1)
            rowHeader1.Cells.Add(headerCell2)
            rowHeader1.ForeColor = Drawing.Color.Black
            rowHeader1.Font.Bold = True
            rowHeader1.Visible = True
            gdvData.Controls(0).Controls.AddAt(0, rowHeader1)

            ' TableCell for Header 2
            Dim fields2 As TableCellCollection = e.Row.Cells
            Dim headerCell11 As TableCell = New TableCell()
            Dim headerCell12 As TableCell = New TableCell()

            headerCell11.ColumnSpan = 2
            headerCell11.Text = "ID and Name"
            headerCell11.BackColor = Drawing.Color.Maroon

            headerCell12.ColumnSpan = 3
            headerCell12.Text = "Age and Sex"
            headerCell12.BackColor = Drawing.Color.Maroon

            ' Add TableCell to TableRow.Cells and then add tableRow to GridView(gdvData)
            Dim rowHeader2 As GridViewRow = New GridViewRow(1, 1, DataControlRowType.Header, DataControlRowState.Normal)
            rowHeader2.Cells.Add(headerCell11)
            rowHeader2.Cells.Add(headerCell12)

            rowHeader2.Font.Size = 12
            rowHeader2.ForeColor = Drawing.Color.White
            rowHeader2.HorizontalAlign = HorizontalAlign.Center
            rowHeader2.Visible = True
            rowHeader2.Font.Bold = True
            gdvData.Controls(0).Controls.AddAt(1, rowHeader2)
        End If
    End Sub

End Class