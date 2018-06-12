'********************************* Module Header *********************************\
' Module Name: NullToBoolConverter.vb
' Project: VideoStoryCreator
' Copyright (c) Microsoft Corporation.
' 
' Converts an object to a boolean.
' If the object is null, returns false.
' Otherwise returns true.
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
''' A converter. If the value is null, return false. Otherwise return true.
''' </summary>
''' <remarks></remarks>
Public Class NullToBoolConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert
        Return (value IsNot Nothing)
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class
