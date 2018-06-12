'**************************** Module Header ******************************\
' Module Name:  ObjectShredder.vb
' Project:      VBEFtoDataTable
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to fill a DataTable with the result of the Linq 
' to Entity query.
' The ObjectShredder<T> class contains the logic to create a DataTable from an 
' IEnumerable<T> source.The Shred method of the ObjectShredder<T> class returns 
' the filled DataTable and accepts three input parameters: an IEnumerable<T> 
' source, a DataTable, and a LoadOption enumeration. The initial schema of the 
' returned DataTable is based on the schema of the type T. If an existing table 
' is provided as input, the schema must be consistent with the schema of the type 
' T. Each public primitive property and field of the type T is converted to a 
' DataColumn in the returned table. If the source sequence contains a type derived 
' from T, the returned table schema is expanded for any additional public properties 
' or fields. 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Reflection

Namespace VBEFtoDataTable
    Public Class ObjectShredder(Of T)
        Private _fi() As System.Reflection.FieldInfo
        Private _pi() As System.Reflection.PropertyInfo
        Private _ordinalMap As Dictionary(Of String, Integer)
        Private _type As Type

        ' ObjectShredder constructor.
        Public Sub New()
            _type = GetType(T)
            _fi = _type.GetFields()
            _pi = _type.GetProperties()
            _ordinalMap = New Dictionary(Of String, Integer)()
        End Sub

        ''' <summary>
        ''' Loads a DataTable from a sequence of objects.
        ''' </summary>
        ''' <param name="source">The sequence of objects to load into the DataTable.</param>
        ''' <param name="table">The input table. The schema of the table must match that 
        ''' the type T.  If the table is null, a new table is created with a schema 
        ''' created from the public properties and fields of the type T.</param>
        ''' <param name="options">Specifies how values from the source sequence will be applied to 
        ''' existing rows in the table.</param>
        ''' <returns>A DataTable created from the source sequence.</returns>
        Public Function Shred(ByVal source As IEnumerable(Of T), ByVal table As DataTable, ByVal options? As LoadOption) As DataTable
            ' Load the table from the scalar sequence if T is a primitive type.
            If GetType(T).IsPrimitive Then
                Return ShredPrimitive(source, table, options)
            End If

            ' Create a new table if the input table is null.
            If table Is Nothing Then
                table = New DataTable(GetType(T).Name)
            End If

            ' Initialize the ordinal map and extend the table schema based on type T.
            table = ExtendTable(table, GetType(T))

            ' Enumerate the source sequence and load the object values into rows.
            table.BeginLoadData()
            Using e As IEnumerator(Of T) = source.GetEnumerator()
                Do While e.MoveNext()
                    If options IsNot Nothing Then
                        table.LoadDataRow(ShredObject(table, e.Current), CType(options, LoadOption))
                    Else
                        table.LoadDataRow(ShredObject(table, e.Current), True)
                    End If
                Loop
            End Using
            table.EndLoadData()

            ' Return the table.
            Return table
        End Function

        Public Function ShredPrimitive(ByVal source As IEnumerable(Of T), ByVal table As DataTable, ByVal options? As LoadOption) As DataTable
            ' Create a new table if the input table is null.
            If table Is Nothing Then
                table = New DataTable(GetType(T).Name)
            End If

            If Not table.Columns.Contains("Value") Then
                table.Columns.Add("Value", GetType(T))
            End If

            ' Enumerate the source sequence and load the scalar values into rows.
            table.BeginLoadData()
            Using e As IEnumerator(Of T) = source.GetEnumerator()
                Dim values(table.Columns.Count - 1) As Object
                Do While e.MoveNext()
                    values(table.Columns("Value").Ordinal) = e.Current

                    If options IsNot Nothing Then
                        table.LoadDataRow(values, CType(options, LoadOption))
                    Else
                        table.LoadDataRow(values, True)
                    End If
                Loop
            End Using
            table.EndLoadData()

            ' Return the table.
            Return table
        End Function

        Public Function ShredObject(ByVal table As DataTable, ByVal instance As T) As Object()

            Dim fi() As FieldInfo = _fi
            Dim pi() As PropertyInfo = _pi

            If instance.GetType() IsNot GetType(T) Then
                ' If the instance is derived from T, extend the table schema
                ' and get the properties and fields.
                ExtendTable(table, instance.GetType())
                fi = instance.GetType().GetFields()
                pi = instance.GetType().GetProperties()
            End If

            ' Add the property and field values of the instance to an array.
            Dim values(table.Columns.Count - 1) As Object
            For Each f As FieldInfo In fi
                ' Get the fields of the primitive types or String type.
                If f.FieldType.IsPrimitive OrElse f.FieldType Is GetType(String) Then
                    values(_ordinalMap(f.Name)) = f.GetValue(instance)
                End If
            Next f

            For Each p As PropertyInfo In pi
                ' Get the properties of the primitive types or String type.
                If p.PropertyType.IsPrimitive OrElse p.PropertyType Is GetType(String) Then
                    values(_ordinalMap(p.Name)) = p.GetValue(instance, Nothing)
                End If
            Next p

            ' Return the property and field values of the instance.
            Return values
        End Function

        Public Function ExtendTable(ByVal table As DataTable, ByVal type As Type) As DataTable
            ' Extend the table schema if the input table was null or if the value 
            ' in the sequence is derived from type T.            
            For Each f As FieldInfo In type.GetFields()
                ' Get the fields of the primitive types or String type.
                If ((Not _ordinalMap.ContainsKey(f.Name))) AndAlso (f.FieldType.IsPrimitive OrElse f.FieldType Is GetType(String)) Then
                    ' Add the field as a column in the table if it doesn't exist
                    ' already.
                    Dim dc As DataColumn = If(table.Columns.Contains(f.Name), table.Columns(f.Name), table.Columns.Add(f.Name, f.FieldType))

                    ' Add the field to the ordinal map.
                    _ordinalMap.Add(f.Name, dc.Ordinal)
                End If
            Next f
            For Each p As PropertyInfo In type.GetProperties()
                ' Get the properties of the primitive types or String type.
                If ((Not _ordinalMap.ContainsKey(p.Name))) AndAlso (p.PropertyType.IsPrimitive OrElse p.PropertyType Is GetType(String)) Then
                    ' Add the property as a column in the table if it doesn't exist
                    ' already.
                    Dim dc As DataColumn = If(table.Columns.Contains(p.Name), table.Columns(p.Name), table.Columns.Add(p.Name, p.PropertyType))

                    ' Add the property to the ordinal map.
                    _ordinalMap.Add(p.Name, dc.Ordinal)
                End If
            Next p

            ' Return the table.
            Return table
        End Function
    End Class
End Namespace
