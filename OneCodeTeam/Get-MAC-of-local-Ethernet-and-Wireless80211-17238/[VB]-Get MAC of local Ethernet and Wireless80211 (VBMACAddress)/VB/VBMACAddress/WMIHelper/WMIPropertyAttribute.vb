'************************** Module Header ******************************'
' Module Name:  WMIPropertyAttribute.vb
' Project:      VBMACAddress
' Copyright (c) Microsoft Corporation.
'
' This attribute indicates that the property is related to a WMI object 
' property.
' 
' 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************'


Namespace WMIHelper
    <AttributeUsage(AttributeTargets.Property)>
    Public Class WMIPropertyAttribute
        Inherits Attribute

        ''' <summary>
        ''' The related WMI object property name.
        ''' </summary>
        Public Property PropertyName() As String

        ''' <summary>
        ''' The type of the related WMI object property value.
        ''' </summary>
        Public Property PropertyType() As WMIPropertyType

        ''' <summary>
        ''' Specify the .NET type if the WMI object property is referring to another 
        ''' WMI object.
        ''' </summary>
        Public Property AssociatedWMIClass() As Type
    End Class

End Namespace
