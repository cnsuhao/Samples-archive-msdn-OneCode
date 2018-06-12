'***************************** Module Header ******************************\
' Module Name:    MultiFiltering.vb
' Project:        VBASPNETMultiFiltering
' Copyright (c) Microsoft Corporation
'
' Store each filtering condition as a record.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Partial Public Class MultiFiltering
    ' Keep all column and their types
    Private Property AllColumns() As DataTable
        Get
            Return m_AllColumns
        End Get
        Set(value As DataTable)
            m_AllColumns = value
        End Set
    End Property
    Private m_AllColumns As DataTable

    ''' <summary>
    ''' This class is a structure of columns
    ''' to be bound to my user control. Because
    ''' this class can be only used in the user
    ''' control, so this is a protected nested
    ''' class.
    ''' </summary>

    <Serializable()> _
    Class [Structure]
        Implements ICloneable

        Public Property ColumnNames() As List(Of String)
            Get
                Return m_ColumnNames
            End Get
            Set(value As List(Of String))
                m_ColumnNames = value
            End Set
        End Property
        Private m_ColumnNames As List(Of String)
        Public Property Operations() As List(Of String)
            Get
                Return m_Operations
            End Get
            Set(value As List(Of String))
                m_Operations = value
            End Set
        End Property
        Private m_Operations As List(Of String)
        Public ReadOnly Property Relations() As List(Of String)
            Get
                Return New List(Of String)() From { _
                 "And", _
                 "Or" _
                }
            End Get
        End Property

        ' This is bound field
        Public Property EqualValue() As String
            Get
                Return m_EqualValue
            End Get
            Set(value As String)
                m_EqualValue = value
            End Set
        End Property
        Private m_EqualValue As String
        Public Property ColumnIndex() As Integer
            Get
                Return m_ColumnIndex
            End Get
            Set(value As Integer)
                m_ColumnIndex = value
            End Set
        End Property
        Private m_ColumnIndex As Integer
        Public Property OperationIndex() As Integer
            Get
                Return m_OperationIndex
            End Get
            Set(value As Integer)
                m_OperationIndex = value
            End Set
        End Property
        Private m_OperationIndex As Integer
        Public Property RelationIndex() As Integer
            Get
                Return m_RelationIndex
            End Get
            Set(value As Integer)
                m_RelationIndex = value
            End Set
        End Property
        Private m_RelationIndex As Integer

        ' This field illistrates the type of your field
        Public Property DataType() As Type
            Get
                Return m_DataType
            End Get
            Set(value As Type)
                m_DataType = value
            End Set
        End Property
        Private m_DataType As Type

        Public Sub New()
            ColumnIndex = 0
            OperationIndex = 0
            RelationIndex = 0
            EqualValue = ""
        End Sub
        ' Copy itself to create multiple filter
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Using ms As New MemoryStream()
                Dim f As New BinaryFormatter()
                f.Serialize(ms, Me)
                ms.Position = 0
                Return f.Deserialize(ms)
            End Using
        End Function
    End Class

    ''' <summary>
    ''' According to the specific type of structure,set proper operations.
    ''' </summary>
    Protected Function SetSpecificFieldType(stu As [Structure]) As [Structure]
        Dim s As [Structure] = stu
        s.Operations = New List(Of String)()

        s.Operations.Add("=")
        s.Operations.Add("<>")
        s.DataType = AllColumns.Columns(s.ColumnIndex).DataType

        If AllColumns.Columns(s.ColumnIndex).DataType Is GetType(String) Then
            s.Operations.Add("Like")
        ElseIf AllColumns.Columns(s.ColumnIndex).DataType IsNot GetType(Boolean) Then
            s.Operations.Add(">")
            s.Operations.Add(">=")
            s.Operations.Add("<")
            s.Operations.Add("<=")
        End If
        Return s
    End Function

    ''' <summary>
    ''' Add the struct to the list for being shown
    ''' </summary>
    Protected Function AddStruct(structures As List(Of [Structure])) As List(Of [Structure])
        Dim ss As List(Of [Structure]) = structures
        Dim s As [Structure] = Nothing

        If ss Is Nothing Then

            ss = New List(Of [Structure])()
            s = New [Structure]()
            s.ColumnNames = New List(Of String)()

            For Each item As DataColumn In AllColumns.Columns
                If item.DataType IsNot GetType(Byte()) Then
                    s.ColumnNames.Add(item.ColumnName)
                End If
            Next
            s = SetSpecificFieldType(s)
        Else
            s = DirectCast(structures(structures.Count - 1).Clone(), [Structure])
        End If
        ss.Add(s)
        Return ss

    End Function

End Class
