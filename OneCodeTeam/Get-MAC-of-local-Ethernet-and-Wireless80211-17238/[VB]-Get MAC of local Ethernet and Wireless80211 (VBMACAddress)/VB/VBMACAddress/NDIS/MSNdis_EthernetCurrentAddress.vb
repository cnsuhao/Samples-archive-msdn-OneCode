'************************** Module Header ******************************'
' Module Name:  MSNdis_EthernetCurrentAddress.vb
' Project:      VBMACAddress
' Copyright (c) Microsoft Corporation.
' 
' This class represents the MSNdis_EthernetCurrentAddress WMI class. You can 
' download WMI Administrative Tools to get the detailed information of this
' class.
'  
' http://www.microsoft.com/download/en/details.aspx?id=24045
' 
' 
' The NDIS WMI classes are available in Windows Vista / Windows Server 2008 
' or later version. You can run following PowerShell script to discover
' other interesting WMI classes.
' 
' Get-WmiObject -Namespace root\wmi -List  | Where-Object {$_.name -Match "MSNdis" } | Sort-Object
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************'

Imports VBMACAddress.WMIHelper

Namespace NDIS

    <WMIClass(ClassName:="MSNdis_EthernetCurrentAddress")>
    Public Class MSNdis_EthernetCurrentAddress


        <WMIProperty(PropertyName:="Active", PropertyType:=WMIPropertyType.Bool)>
        Public Property Active() As Boolean

        <WMIProperty(PropertyName:="InstanceName", PropertyType:=WMIPropertyType.StringValue)>
        Public Property InstanceName() As String

        <WMIProperty(PropertyName:="NdisCurrentAddress",
            PropertyType:=WMIPropertyType.WMIObject,
            AssociatedWMIClass:=GetType(MSNdis_NetworkAddress))>
        Public Property NdisCurrentAddress() As MSNdis_NetworkAddress

    End Class

End Namespace
