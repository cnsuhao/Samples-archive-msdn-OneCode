'***************************** Module Header ******************************\
' Module Name:    SaveToImage.aspx.vb
' Project:        VBASPNETChartExport
' Copyright (c) Microsoft Corporation
'
' This page shows how to export Chart to an Image file.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************/

Imports System.Web.UI.DataVisualization.Charting
Public Class SaveToImage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Render the chart
        Utilities.DisplayChart(myChart)
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim exportFileName As String = Server.MapPath("Images") & "/testImage.jpg"
        myChart.SaveImage(exportFileName, ChartImageFormat.Jpeg)
        Me.ClientScript.RegisterStartupScript(Me.GetType(), "exportChart", String.Format("alert('It has been successfully exported to:{0}');", exportFileName.Replace("\"c, "/"c)), True)
    End Sub
End Class