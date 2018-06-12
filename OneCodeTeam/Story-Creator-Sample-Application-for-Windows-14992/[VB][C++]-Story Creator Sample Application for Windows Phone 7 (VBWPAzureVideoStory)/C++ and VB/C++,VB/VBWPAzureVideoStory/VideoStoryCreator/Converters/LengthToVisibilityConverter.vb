'********************************* Module Header *********************************\
' Module Name: LengthToVisibilityConverter.vb
' Project: VideoStoryCreator
' Copyright (c) Microsoft Corporation.
' 
' Converts an integer to Visibility.
' Returns Collapsed if and only if the integer is larger than 0.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.Windows.Data
''' <summary>
''' A converter. The value must be of type int.
''' If the value is greater than 0, return visible. Otherwise return collapsed.
''' </summary>
''' </summary>
''' <remarks></remarks>
Public Class LengthToVisibilityConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert
        If TypeOf value Is Integer Then
            Dim length As Integer = CInt(value)
            If length <= 0 Then
                Return Visibility.Visible
            End If
        End If
        Return Visibility.Collapsed
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class
