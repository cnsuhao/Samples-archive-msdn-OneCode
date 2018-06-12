'**************************** Module Header ******************************\
' Module Name:    BoolToStringConverter.vb
' Project:        VBWindowsStoreAppCommandBindingInDataTemplate
' Copyright (c) Microsoft Corporation.
' 
' This is a Converter which converts between Boolean type and String type
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports Windows.UI.Xaml.Data

Namespace Common
    Class BoolToStringConverter
        Implements IValueConverter

        Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
            Return If(CBool(value), "Male", "Female")
        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
            Dim sex As String = TryCast(value, String)

            If sex = "Female" Then
                Return False
            End If
            Return True
        End Function
    End Class
End Namespace