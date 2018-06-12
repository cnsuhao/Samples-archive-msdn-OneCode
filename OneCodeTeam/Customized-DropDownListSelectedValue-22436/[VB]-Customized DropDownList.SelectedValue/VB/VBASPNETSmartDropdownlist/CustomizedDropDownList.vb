'**************************** Module Header ******************************\
' Module Name: CustomizedDropDownList.vb
' Project:     VBASPNETSmartDropdownlist
' Copyright (c) Microsoft Corporation
'
' The "SelectedVale" is a value from DropDownList that will be saved into the
' field bound to the data table. However, if the field value does not belong 
' to any element of the collection of the DropDownList itself, it will throw 
' an ArguementOutOfRangeException exception. This sample creates a customized 
' DropDownList that will fix this problem. 
' 
' This is a customized DropDownList that inherits DropDownList control and 
' overrides SelectedValue property. 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************/




Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Reflection


<DefaultProperty("Text"), ToolboxData("<{0}:ServerControl1 runat=server></{0}:ServerControl1>")>
Public Class CustomizedDropDownList
    Inherits DropDownList

    <Bindable(True), Category("Appearance"), DefaultValue(""), Localizable(True)>
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        MyBase.Render(writer)
    End Sub

    Public Overrides Property SelectedValue As String
        Get
            Return MyBase.SelectedValue
        End Get
        Set(ByVal value As String)
            ' If data source is SqlDataSource.
            If TypeOf DataSource Is DataView Then
                Dim dataView As DataView = TryCast(DataSource, DataView)
                Dim tabView As DataTable = dataView.Table
                Dim typeColumns As Type = tabView.Columns(DataValueField).DataType
                Dim rowFilter As String = String.Empty
                If typeColumns.Equals(Type.[GetType]("System.String")) Then
                    rowFilter = String.Format("{0}='{1}'", DataValueField, value)
                ElseIf typeColumns.Equals(Type.[GetType]("System.Int32")) OrElse typeColumns.Equals(Type.[GetType]("System.Int64")) Then
                    rowFilter = String.Format("{0}={1}", DataValueField, value)
                Else
                    Throw New NotImplementedException("unsupported type")
                End If

                dataView.RowFilter = rowFilter
                If dataView.Count <> 0 Then
                    dataView.RowFilter = String.Empty
                    MyBase.SelectedValue = value
                Else
                    dataView.RowFilter = String.Empty
                    MyBase.SelectedValue = Items(0).Value
                End If
                ' If data source is ObjectDataSource
            ElseIf TypeOf DataSource Is IEnumerable Then
                Dim bolFlag As Boolean = False
                For Each obj As Object In TryCast(DataSource, IEnumerable)
                    Dim typeObj As Type = obj.[GetType]()
                    Dim info As PropertyInfo = typeObj.GetProperty(DataValueField)
                    Dim valueProperty As String = info.GetValue(obj, Nothing).ToString()
                    If valueProperty.Equals(value) Then
                        bolFlag = True
                        Exit For
                    End If
                Next

                If bolFlag Then
                    MyBase.SelectedValue = value
                Else
                    MyBase.SelectedValue = Items(0).Value
                End If
            End If

            ' If user change the selected value after postback.
            If DataSource Is Nothing Then
                Dim bolFlag As Boolean = False
                For i As Integer = 0 To Items.Count - 1
                    If Items(i).Value.Equals(value) Then
                        bolFlag = True
                        Exit For
                    End If
                Next
                If bolFlag Then
                    MyBase.SelectedValue = value
                Else
                    MyBase.SelectedValue = Items(0).Value
                End If
            End If

        End Set
    End Property
End Class
