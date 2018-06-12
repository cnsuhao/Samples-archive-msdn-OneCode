'**************************** Module Header ******************************\
' Module Name:  PivotRow.vb
' Project:      VBEFPivotOperation
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to implement the Pivot and Unpivot operation in 
' Entity Framework.
' This file includes the definition of PivotRow class that stores the Pivot 
' result.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Linq

Namespace VBEFPivotOperation
    ''' <summary>
    ''' Store the row of the Pivot result.
    ''' </summary>
    ''' <typeparam name="TypeId">Type of ObjectId</typeparam>
    ''' <typeparam name="TypeAttr">Type of Attribute</typeparam>
    ''' <typeparam name="TypeValue">Type of Value</typeparam>
    Public Class PivotRow(Of TypeId, TypeAttr, TypeValue)
        Public Property ObjectId() As TypeId
        Public Property Attributes() As IEnumerable(Of TypeAttr)
        Public Property Values() As IEnumerable(Of TypeValue)

        ''' <summary>
        ''' Get the Pivot table
        ''' </summary>
        ''' <param name="attributeNames">the list of attributes</param>
        ''' <param name="source">the data of Pivot source</param>
        ''' <returns>the Pivot table</returns>
        Public Shared Function GetPivotTable(ByVal attributeNames As List(Of TypeAttr),
                    ByVal source As List(Of PivotRow(Of TypeId, TypeAttr, TypeValue))) As DataTable
            Dim dt As New DataTable()

            Dim dc As New DataColumn("ID", GetType(TypeId))
            dt.Columns.Add(dc)

            ' Creat the new DataColumn for each attribute
            attributeNames.ForEach(Sub(name)
                                       dc = New DataColumn(name.ToString(), GetType(TypeValue))
                                       dt.Columns.Add(dc)
                                   End Sub)

            ' Insert the data into the Pivot table
            For Each row As PivotRow(Of TypeId, TypeAttr, TypeValue) In source
                Dim dr As DataRow = dt.NewRow()
                dr("ID") = row.ObjectId

                Dim attributes As List(Of TypeAttr) = row.Attributes.ToList()
                Dim values As List(Of TypeValue) = row.Values.ToList()

                ' Set the value basing the attribute names.
                For i As Integer = 0 To values.Count - 1
                    dr(attributes(i).ToString()) = values(i)
                Next i

                dt.Rows.Add(dr)
            Next row

            Return dt
        End Function
    End Class
End Namespace
