'**************************** Module Header ******************************\
' Module Name:  ClonedDataTable.vb
' Project:      VBDataTableUpdate
' Copyright (c) Microsoft Corporation.
' 
' In this sample, we will demonstrate how to update the structure and constraints 
' of the destination table after DataTable.Clone.
' ClonedDataTable class will return a destiantion table after construct and
' includes all the updating events.
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
Imports System.ComponentModel

Namespace VBDataTableUpdate
    Public Class ClonedDataTable
        Private sourceTable As DataTable
        Private destinationDataTable As DataTable

        Public Sub New(ByVal source As DataTable)
            sourceTable = source
            ' set the cloned result
            destinationDataTable = sourceTable.Clone()
        End Sub

        Public Sub UpdateAddedColumn()
            AddHandler sourceTable.Columns.CollectionChanged, AddressOf ColumnAdded
        End Sub

        Public Sub UpdateDeletedColumn()
            AddHandler sourceTable.Columns.CollectionChanged, AddressOf ColumnDeleted
        End Sub

        Public Sub UpdateUniqueConstraint()
            AddHandler sourceTable.Constraints.CollectionChanged, AddressOf UniqueConstraint_Changed
        End Sub

        Public Sub UpdateForeignKeyConstraint()
            AddHandler sourceTable.Constraints.CollectionChanged, AddressOf ForeignKeyConstraint_Changed
        End Sub

        ''' <summary>
        ''' After the source table adds a column, the method will be trigged and add the same 
        ''' column in destination table.
        ''' </summary>
        Private Sub ColumnAdded(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs)
            If e.Action = CollectionChangeAction.Add Then
                Dim column As DataColumn = TryCast(e.Element, DataColumn)

                If column IsNot Nothing Then
                    Dim newColumn As New DataColumn(column.ColumnName, column.DataType,
                                                    column.Expression, column.ColumnMapping)

                    If Not destinationDataTable.Columns.Contains(newColumn.ColumnName) Then
                        destinationDataTable.Columns.Add(newColumn)
                    End If
                End If
            End If
        End Sub

        ''' <summary>
        ''' After the source table deletes a column, the method will be trigged and delete the same 
        ''' column in destination table.
        ''' </summary>
        Private Sub ColumnDeleted(ByVal sender As Object, ByVal e As CollectionChangeEventArgs)
            If e.Action = CollectionChangeAction.Remove Then
                Dim column As DataColumn = TryCast(e.Element, DataColumn)

                If column IsNot Nothing Then
                    If destinationDataTable.Columns.Contains(column.ColumnName) Then
                        destinationDataTable.Columns.Remove(column.ColumnName)
                    End If
                End If
            End If
        End Sub

        ''' <summary>
        ''' After the source table changes the UniqueConstraint, the method will be trigged and change  
        ''' the same UniqueConstraint in destination table.
        ''' </summary>
        Private Sub UniqueConstraint_Changed(ByVal sender As Object, ByVal e As CollectionChangeEventArgs)
            Dim constraint As UniqueConstraint = TryCast(e.Element, UniqueConstraint)

            If constraint Is Nothing Then
                Return
            End If

            Dim constraintName As String = constraint.ConstraintName

            If e.Action = CollectionChangeAction.Add Then
                Dim columns(constraint.Columns.Count() - 1) As DataColumn
                Dim isPrimaryKey As Boolean = constraint.IsPrimaryKey

                ' Get the columns used in new constraint from the destiantion table.
                For i As Int32 = 0 To constraint.Columns.Count() - 1
                    Dim columnName As String = constraint.Columns(i).ColumnName

                    If destinationDataTable.Columns.Contains(columnName) Then
                        columns(i) = destinationDataTable.Columns(columnName)
                    Else
                        Return
                    End If
                Next i

                Dim newConstraint As New UniqueConstraint(constraintName, columns, isPrimaryKey)

                If Not destinationDataTable.Constraints.Contains(constraintName) Then
                    destinationDataTable.Constraints.Add(newConstraint)
                End If

            ElseIf e.Action = CollectionChangeAction.Remove Then
                If destinationDataTable.Constraints.Contains(constraintName) Then
                    destinationDataTable.Constraints.Remove(constraintName)
                End If
            End If

        End Sub

        ''' <summary>
        ''' After the source table changes the ForeignKeyConstraint, the method will be trigged and change  
        ''' the same ForeignKeyConstraint in destination table.
        ''' </summary>
        Private Sub ForeignKeyConstraint_Changed(ByVal sender As Object, ByVal e As CollectionChangeEventArgs)
            Dim constraint As ForeignKeyConstraint = TryCast(e.Element, ForeignKeyConstraint)

            If constraint Is Nothing Then
                Return
            End If

            ' If the source and destination are not in the same DataSet, we won't change the ForeignKeyConstraint.
            If sourceTable.DataSet IsNot DestinationTable.DataSet Then
                Return
            End If

            Dim constraintName As String = constraint.ConstraintName

            If e.Action = CollectionChangeAction.Add Then
                Dim columns(constraint.Columns.Count() - 1) As DataColumn
                Dim parentColumns() As DataColumn = constraint.RelatedColumns

                ' Get the columns used in new constraint from the destination table.
                For i As Integer = 0 To constraint.Columns.Count() - 1
                    Dim columnName As String = constraint.Columns(i).ColumnName

                    If destinationDataTable.Columns.Contains(columnName) Then
                        columns(i) = destinationDataTable.Columns(columnName)
                    Else
                        Return
                    End If
                Next i

                Dim newConstraint As New ForeignKeyConstraint(constraintName, parentColumns, columns)
                newConstraint.AcceptRejectRule = constraint.AcceptRejectRule
                newConstraint.DeleteRule = constraint.DeleteRule
                newConstraint.UpdateRule = constraint.UpdateRule

                If Not destinationDataTable.Constraints.Contains(constraintName) Then
                    destinationDataTable.Constraints.Add(newConstraint)
                End If
            ElseIf e.Action = CollectionChangeAction.Remove Then
                If destinationDataTable.Constraints.Contains(constraintName) Then
                    destinationDataTable.Constraints.Remove(constraintName)
                End If
            End If
        End Sub

        ' return the destination table.
        Public ReadOnly Property DestinationTable() As DataTable
            Get
                Return destinationDataTable
            End Get
        End Property
    End Class
End Namespace
