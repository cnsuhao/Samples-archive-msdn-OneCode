'**************************** Module Header ******************************'
' Module Name:  OptionsPage.vb
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
Imports Microsoft.VisualStudio.Shell
Imports System.ComponentModel

'/////////////////////////////////////////////////////////////////////////////
' Define an enum type which will be shown in the Option Page.
' 
Public Enum MyEnumProperty
    None
    First
    Second
    Third
End Enum

'/////////////////////////////////////////////////////////////////////////////
' Create a class named OptionsPage which derived from DialogPage class, add
' a MyEnumProperty property in it.
' 
Friend Class OptionsPage
    Inherits DialogPage
#Region "Fields"
    Private _myProperty As MyEnumProperty = MyEnumProperty.None
#End Region ' Fields

#Region "Properties"
    <Category("Enum Options"), Description("My enum option"), TypeConverter(GetType(EnumTypeConverter))> _
    Public Property MyProperty() As MyEnumProperty
        Get
            Return _myProperty
        End Get
        Set(ByVal value As MyEnumProperty)
            _myProperty = value
        End Set
    End Property
#End Region ' Properties
End Class

