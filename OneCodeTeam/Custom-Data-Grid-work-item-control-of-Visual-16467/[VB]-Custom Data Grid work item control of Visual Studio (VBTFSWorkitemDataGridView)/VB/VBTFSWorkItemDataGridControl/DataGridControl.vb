'************************** Module Header ******************************'
' Module Name:   DataGridControl.vb
' Project:       VBTFSWorkItemDataGridControl
' Copyright (c) Microsoft Corporation.
' 
' This class inherits the BaseWITControl and it uses a DataGridView to 
' represent a workitem field.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'************************************************************************'

Imports System.IO
Imports System.Text.RegularExpressions

Partial Public Class DataGridControl
    Inherits BaseWITControl

    ' The pattern to identify the columns from the attribute.
    ' The attribute should like 
    ' Column A(FieldA);Column B(FieldB);
    Private Const _columnDefinitionPattern As String = "(?<display>.+?)\((?<field>.+?)\);"

    ' Use DataTable to read the value of this field, and write XML to 
    ' this field.
    Private _table As DataTable
    Private _source As BindingSource

    Public Sub New()
        InitializeComponent()

        Me.gvData.AutoGenerateColumns = False

        ' Initialize data source.
        Me._table = New DataTable("DataTable")
        Me._source = New BindingSource()
        Me._source.DataSource = _table
        Me.gvData.DataSource = _source
    End Sub

    ' Override some methods of BaseWITControl.
#Region "IWorkItemControl"

    ''' <summary>
    ''' Control is requested to flush any data to workitem object. 
    ''' Clear the data in the table.
    ''' </summary>
    Public Overrides Sub Clear()
        If Me._table IsNot Nothing Then
            Me._table.Rows.Clear()
        End If
    End Sub

    ''' <summary>
    ''' Control is requested to flush any data to workitem object. 
    ''' Write the data in DataTable as XML, and then set the value of current 
    ''' field to the XML.
    ''' </summary>
    Public Overrides Sub FlushToDatasource()
        If Me._table IsNot Nothing Then

            Using writer As New StringWriter()
                Me._table.WriteXml(writer, XmlWriteMode.WriteSchema)
                Me.SetFieldValue(writer.ToString())
            End Using
        Else
            Me.SetFieldValue(Nothing)
        End If
    End Sub

    '''<summary>
    ''' Asks control to invalidate the contents and redraw.
    ''' Read the value (XML) of current field.
    ''' </summary>
    Public Overrides Sub InvalidateDatasource()
        Me.Field = Nothing
        Me.Clear()

        If Me.HasValidField Then
            Try
                Me._table.Clear()
                Using reader As New StringReader(TryCast(Me.Field.Value, String))
                    Me._table.ReadXml(reader)
                End Using
            Catch
            End Try

            SetReadOnly((Not Me.Field.IsEditable))

            ' If the columns definition changed, update the DataTable.
            For Each col As DataGridViewColumn In Me.gvData.Columns
                If Not _table.Columns.Contains(col.DataPropertyName) Then
                    _table.Columns.Add(col.DataPropertyName)
                End If
            Next col
        End If
    End Sub

    '''<summary>
    ''' All attributes specified in work item type definition file for this 
    ''' control, including custom attributes.
    ''' 
    ''' We need the "columns" attribute to initialize the columns of DataGridView.
    ''' </summary>
    Public Overrides Property Properties() As System.Collections.Specialized.StringDictionary
        Get
            Return MyBase.Properties
        End Get
        Set(ByVal value As System.Collections.Specialized.StringDictionary)
            MyBase.Properties = value
            UpdateGridViewColumns(MyBase.Properties("columns"))
        End Set
    End Property



#End Region

    ''' <summary>
    ''' Initialize the columns of DataGridView. The attributes should like 
    ''' Column A(FieldA);Column B(FieldB);
    ''' </summary>
    ''' <param name="columnsAttribute"></param>
    Private Sub UpdateGridViewColumns(ByVal columnsAttribute As String)
        ' The definition of the columns does not change.
        If String.IsNullOrEmpty(columnsAttribute) Then
            Return
        End If

        ' Clear the columns.
        Me.gvData.Columns.Clear()

        ' Get the new columns definition.
        Dim matches As MatchCollection = Regex.Matches(columnsAttribute,
                                                       _columnDefinitionPattern)

        For Each match As Match In matches
            Dim colum As DataGridViewColumn = New DataGridViewTextBoxColumn()
            colum.DataPropertyName = match.Groups("field").Value
            colum.HeaderText = match.Groups("display").Value
            Me.gvData.Columns.Add(colum)
        Next match
    End Sub

    ''' <summary>
    ''' Enable or disable the DataGridView.
    ''' </summary>
    Protected Overrides Sub SetReadOnly(ByVal [readOnly] As Boolean)
        Dim canedit As Boolean = (Not [readOnly]) AndAlso Not Me.ReadOnly

        MyBase.SetReadOnly((Not canedit))
        Me.gvData.ReadOnly = Not canedit
        Me.gvData.AllowUserToDeleteRows = canedit
        Me.gvData.AllowUserToAddRows = canedit
    End Sub

    ''' <summary>
    ''' Update the field's value if a cell changed.
    ''' </summary>
    Private Sub gvData_CellValueChanged(ByVal sender As Object,
                                        ByVal e As DataGridViewCellEventArgs) _
                                    Handles gvData.CellValueChanged
        Me.FlushToDatasource()
    End Sub

    ''' <summary>
    ''' Update the field's value if a row is deleted.
    ''' </summary>
    Private Sub gvData_UserDeletedRow(ByVal sender As Object,
                                      ByVal e As DataGridViewRowEventArgs) _
                                  Handles gvData.UserDeletedRow
        Me.FlushToDatasource()
    End Sub



End Class

