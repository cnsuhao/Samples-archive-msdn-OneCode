'************************** Module Header ******************************'
' Module Name:  MSNdis_NetworkAddress.vb
' Project:      VBMACAddress
' Copyright (c) Microsoft Corporation.
' 
' This class represents the MSNdis_NetworkAddress WMI class. You can 
' download WMI Administrative Tools to get the detailed information of this
' class.
'  
' http://www.microsoft.com/download/en/details.aspx?id=24045
' 
' 
' The NDIS WMI classes are available in Windows Vista / Windows Server 2008 
' or later version.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'************************************************************************'

Imports VBMACAddress.WMIHelper

Namespace NDIS
    <WMIClass(ClassName:="MSNdis_NetworkAddress")>
    Public Class MSNdis_NetworkAddress

        <WMIProperty(PropertyName:="Address", PropertyType:=WMIPropertyType.ByteArray)>
        Public Property Address() As Byte()

    End Class
End Namespace
