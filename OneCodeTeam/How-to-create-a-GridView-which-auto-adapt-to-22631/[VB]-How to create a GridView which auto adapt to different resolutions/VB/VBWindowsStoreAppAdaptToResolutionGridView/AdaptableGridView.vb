'***************************** Module Header ******************************\
' Module Name:  AdaptableGridView.vb
' Project:      VBWindowsStoreAppAdaptToResolutionGridView
' Copyright (c) Microsoft Corporation.
'  
' This is a custom GridViwe which can adapt to different resolutions
'   
'  
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/


Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls

Public Class AdaptableGridView
    Inherits GridView
    ' Default itemWidth
    Private Const m_itemWidth As Double = 100.0
    Public Property ItemWidth() As Double
        Get
            Return CDbl(GetValue(ItemWidthProperty))
        End Get
        Set(value As Double)
            SetValue(ItemWidthProperty, value)
        End Set
    End Property
    Public Shared ReadOnly ItemWidthProperty As DependencyProperty = DependencyProperty.Register("ItemWidth", GetType(Double), GetType(AdaptableGridView), New PropertyMetadata(m_itemWidth))

    ' Default max number of rows or columns
    Private Const m_maxRowsOrColumns As Integer = 3
    Public Property MaxRowsOrColumns() As Integer
        Get
            Return CInt(GetValue(MaxRowColProperty))
        End Get
        Set(value As Integer)
            SetValue(MaxRowColProperty, value)
        End Set
    End Property
    Public Shared ReadOnly MaxRowColProperty As DependencyProperty = DependencyProperty.Register("MaxRowsOrColumns", GetType(Integer), GetType(AdaptableGridView), New PropertyMetadata(m_maxRowsOrColumns))


    Public Sub New()
        AddHandler Me.SizeChanged, AddressOf AdaptableGridViewSizeChanged
    End Sub

    Private Sub AdaptableGridViewSizeChanged(sender As Object, e As SizeChangedEventArgs)
        ' Calculate the proper max rows or columns based on new size 
        Me.MaxRowsOrColumns = If(Me.ItemWidth > 0, Convert.ToInt32(Math.Floor(e.NewSize.Width / Me.ItemWidth)), m_maxRowsOrColumns)
    End Sub
End Class