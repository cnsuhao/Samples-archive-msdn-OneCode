'***************************** Module Header ******************************\
' Module Name:  EnumToBoolConverter.vb
' Project:      VBWindowsStoreAppBindEnumToRadioButton
' Copyright (c) Microsoft Corporation.
'  
' This is converter of Boolean type and Enum type
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

Namespace Common

    Public Class EnumToBoolConverter
        Implements IValueConverter


        Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
            Dim param As String = TryCast(parameter, String)
            If param Is Nothing Then
                Return DependencyProperty.UnsetValue
            End If
            If [Enum].IsDefined(value.[GetType](), value) = False Then
                Return DependencyProperty.UnsetValue
            End If

            Dim paramValue As Object = [Enum].Parse(value.[GetType](), param)
            Return paramValue.Equals(value)
        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
            Dim param As String = TryCast(parameter, String)
            If parameter Is Nothing Then
                Return DependencyProperty.UnsetValue
            End If

            Return [Enum].Parse(GetType(Sport), param)
        End Function
    End Class
End Namespace
