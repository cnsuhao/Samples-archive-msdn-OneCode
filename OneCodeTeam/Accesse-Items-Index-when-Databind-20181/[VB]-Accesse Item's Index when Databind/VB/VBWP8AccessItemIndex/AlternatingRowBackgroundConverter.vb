'****************************** Module Header ******************************\
' Module Name:  AlternatingRowBackgroundConverter.vb
' Project:      VBWP8AccessItemIndex
' Copyright (c) Microsoft Corporation
'
' This is a custom Converter. We will use it to alternate the row's background.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Imports System.Windows.Data
Imports System.Globalization

Public Class AlternatingRowBackgroundConverter
    Implements IValueConverter
    ' Normal Brush
    Public Property NormalBrush() As Brush
        Get
            Return _normalBrush
        End Get
        Set(value As Brush)
            _normalBrush = value
        End Set
    End Property
    Private _normalBrush As Brush

    ' Alternate Brush
    Public Property AlternateBrush() As Brush
        Get
            Return _alternateBrush
        End Get
        Set(value As Brush)
            _alternateBrush = value
        End Set
    End Property
    Private _alternateBrush As Brush

    ''' <summary>
    ''' Deal with the background brush of current UIElement element.
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="targetType"></param>
    ''' <param name="parameter"></param>
    ''' <param name="culture"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
        Dim element As Panel = DirectCast(value, Panel)
        AddHandler element.Loaded, AddressOf Element_Loaded

        Return NormalBrush
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function

    ''' <summary>
    ''' Get the index of UIElement element and in accordance with the index to
    ''' perform background color alternating.
    ''' </summary>
    ''' <param name="sender">UIElement</param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Element_Loaded(sender As Object, e As RoutedEventArgs)
        Dim intIndex As Integer = -1                   ' index
        Dim element As Panel = TryCast(sender, Panel)  ' Current UIElement          

        intIndex = Utilities.GetIndexOfUIElement(element)

        If intIndex <> (-1) Then
            If intIndex Mod 2 <> 0 Then
                element.Background = AlternateBrush
            End If
        End If
    End Sub
End Class

