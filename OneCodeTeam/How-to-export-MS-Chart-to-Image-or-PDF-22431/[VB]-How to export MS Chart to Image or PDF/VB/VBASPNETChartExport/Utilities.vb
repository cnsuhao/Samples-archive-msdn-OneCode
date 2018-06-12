'***************************** Module Header ******************************\
' Module Name:    Utilities.vb
' Project:        VBASPNETChartExport
' Copyright (c) Microsoft Corporation
'
' This is a utilities Class.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************/

Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Data
Imports System.Web.UI.DataVisualization.Charting

Public NotInheritable Class Utilities
    Private Sub New()
    End Sub
    ''' <summary>
    ''' Create a DataTable as the data source of the Chart control 
    ''' </summary>
    ''' <returns>DataTable</returns>
    Public Shared Function CreateDataTable() As DataTable
        ' Temp DataTable
        Dim dt As New DataTable()

        'Add three columns to the DataTable 
        dt.Columns.Add("Date")
        dt.Columns.Add("Volume1")
        dt.Columns.Add("Volume2")

        Dim dr As DataRow

        ' Add rows to the table which contains some random data for demonstration 
        dr = dt.NewRow()
        dr("Date") = "Jan"
        dr("Volume1") = 3731
        dr("Volume2") = 4101
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Date") = "Feb"
        dr("Volume1") = 6024
        dr("Volume2") = 4324
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Date") = "Mar"
        dr("Volume1") = 4935
        dr("Volume2") = 2935
        dt.Rows.Add(dr)

        Return dt
    End Function

    ''' <summary>
    ''' Render the chart.
    ''' </summary>
    ''' <param name="myChart">The Chart will be bound to</param>
    Public Shared Sub DisplayChart(myChart As Chart)
        myChart.DataSource = CreateDataTable()

        ' Give two columns of data to Y-axle 
        myChart.Series(0).YValueMembers = "Volume1"
        myChart.Series(1).YValueMembers = "Volume2"

        ' Set the X-axle as date value 
        myChart.Series(0).XValueMember = "Date"

        ' Bind the Chart control with the setting above 
        myChart.DataBind()
    End Sub
End Class


