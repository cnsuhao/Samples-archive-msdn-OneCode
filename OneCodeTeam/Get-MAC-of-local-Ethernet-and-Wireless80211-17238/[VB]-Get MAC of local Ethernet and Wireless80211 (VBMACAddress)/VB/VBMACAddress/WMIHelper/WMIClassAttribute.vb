'************************** Module Header *******************************'
' Module Name:  WMIPropertyAttribute.vb
' Project:      VBMACAddress
' Copyright (c) Microsoft Corporation.
'
' This attribute indicates that the class is related to a WMI object.
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

    <AttributeUsage(AttributeTargets.Class)>
    Public Class WMIClassAttribute
        Inherits Attribute

        ''' <summary>
        ''' The related WMI class name.
        ''' </summary>
        Public Property ClassName() As String

    End Class
End Namespace
