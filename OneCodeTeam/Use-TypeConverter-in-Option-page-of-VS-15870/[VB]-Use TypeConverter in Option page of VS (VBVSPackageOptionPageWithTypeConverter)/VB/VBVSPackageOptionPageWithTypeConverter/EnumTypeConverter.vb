'**************************** Module Header ******************************'
' Module Name:  EnumTypeConverter.vb
' Project:      VBVSPackageOptionPageWithTypeConverter
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to use TypeConverter in Option Page.
' A type converter can be used to convert values between data types, and to
' assist property configuration at design time by providing text-to-value
' conversion or a drop-down list of values to select from.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************'

Imports System.Linq
Imports System.Text
Imports System.ComponentModel
Imports System.Globalization

'/////////////////////////////////////////////////////////////////////////////
' Create a class named EnumTypeConverter which derived from EnumConverter,
' implement the methods of EnumConverter.
' About how to implement a Type Converter, please check this document:
' http://msdn.microsoft.com/en-us/library/ayybcxe5.aspx
' 
Friend Class EnumTypeConverter
    Inherits EnumConverter
    Public Sub New()
        MyBase.New(GetType(MyEnumProperty))
    End Sub

    Public Overloads Overrides Function CanConvertFrom(ByVal context As ITypeDescriptorContext, ByVal sourceType As Type) As Boolean
        If sourceType Is GetType(String) Then
            Return True
        End If

        Return MyBase.CanConvertFrom(context, sourceType)
    End Function

    Public Overloads Overrides Function ConvertFrom(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object) As Object
        Dim str As String = TryCast(value, String)

        If str IsNot Nothing Then
            If str = "Beautiful None" Then
                Return MyEnumProperty.None
            End If
            If str = "Beautiful First" Then
                Return MyEnumProperty.First
            End If
            If str = "Beautiful Second" Then
                Return MyEnumProperty.Second
            End If
            If str = "Beautiful Third" Then
                Return MyEnumProperty.Third
            End If
        End If

        Return MyBase.ConvertFrom(context, culture, value)
    End Function

    Public Overloads Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
        If destinationType Is GetType(String) Then
            Dim result As String = Nothing
            If CInt(Fix(value)) = 0 Then
                result = "Beautiful None"
            ElseIf CInt(Fix(value)) = 1 Then
                result = "Beautiful First"
            ElseIf CInt(Fix(value)) = 2 Then
                result = "Beautiful Second"
            ElseIf CInt(Fix(value)) = 3 Then
                result = "Beautiful Third"
            End If

            If result IsNot Nothing Then
                Return result
            End If
        End If

        Return MyBase.ConvertTo(context, culture, value, destinationType)
    End Function
End Class

