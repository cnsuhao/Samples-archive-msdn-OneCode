'***************************** Module Header ******************************\
' Module Name:    SaveToPdf.aspx.vb
' Project:        VBASPNETChartExport
' Copyright (c) Microsoft Corporation
'
' This page shows how to export Chart to a Pdf file.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************/
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Web.UI.DataVisualization.Charting

Public Class SaveToPdf
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Render the chart
        Utilities.DisplayChart(myChart)
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Specify the content type.
        Response.ContentType = "application/pdf"

        ' Add a Content-Disposition header.
        Response.AddHeader("Content-Disposition", [String].Format("attachment; filename={0}.pdf", "test"))

        ' Render the chart.
        Utilities.DisplayChart(myChart)

        ' Create a Document object
        Dim doc As New Document()

        Try
            ' Create a writer to dump the contents of the Document to the Response.OutputStream stream
            Dim writer As PdfWriter = PdfWriter.GetInstance(doc, Response.OutputStream)
            doc.Open()

            ' Now create the chart image and add it to the PDF
            Using imgStream As New MemoryStream()
                ' Save the chart to a MemoryStream
                myChart.SaveImage(imgStream, ChartImageFormat.Png)

                ' Create an Image object from the MemoryStream data
                Dim img As Image = Image.GetInstance(imgStream.ToArray())

                ' Scale the Image object to fit within the boundary of the PDF document and add it
                img.ScaleToFit(doc.PageSize.Width - (doc.LeftMargin + doc.RightMargin), doc.PageSize.Height - (doc.TopMargin + doc.BottomMargin))
                doc.Add(img)
            End Using
        Finally
            doc.Close()
        End Try

        ' Indicate that the data to send to the client has ended
        Response.[End]()

    End Sub
End Class