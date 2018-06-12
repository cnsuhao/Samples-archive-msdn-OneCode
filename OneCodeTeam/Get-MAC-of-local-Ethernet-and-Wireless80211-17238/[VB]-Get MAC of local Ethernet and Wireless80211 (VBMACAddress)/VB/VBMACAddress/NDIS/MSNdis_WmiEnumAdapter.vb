'************************** Module Header ******************************'
' Module Name:  MSNdis_WmiEnumAdapter.vb
' Project:      VBMACAddress
' Copyright (c) Microsoft Corporation.
' 
' This class represents the MSNdis_WmiEnumAdapter WMI class. You can 
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


Imports System
Imports VBMACAddress.WMIHelper

Namespace NDIS

    <WMIClass(ClassName:="MSNdis_WmiEnumAdapter")>
    Public Class MSNdis_WmiEnumAdapter
        Private privateDeviceName As String
        <WMIProperty(PropertyName:="DeviceName", PropertyType:=WMIPropertyType.StringValue)>
        Public Property DeviceName() As String
            Get
                Return privateDeviceName
            End Get
            Private Set(ByVal value As String)
                privateDeviceName = value
            End Set
        End Property

        Private privateHeader As MSNdis_ObjectHeader
        <WMIProperty(PropertyName:="Header", PropertyType:=WMIPropertyType.WMIObject, AssociatedWMIClass:=GetType(MSNdis_ObjectHeader))>
        Public Property Header() As MSNdis_ObjectHeader
            Get
                Return privateHeader
            End Get
            Private Set(ByVal value As MSNdis_ObjectHeader)
                privateHeader = value
            End Set
        End Property

        Private privateIfIndex As UInt32
        <WMIProperty(PropertyName:="IfIndex", PropertyType:=WMIPropertyType.UInt32)>
        Public Property IfIndex() As UInt32
            Get
                Return privateIfIndex
            End Get
            Private Set(ByVal value As UInt32)
                privateIfIndex = value
            End Set
        End Property

        Private privateNetLuid As UInt64
        <WMIProperty(PropertyName:="NetLuid", PropertyType:=WMIPropertyType.UInt64)>
        Public Property NetLuid() As UInt64
            Get
                Return privateNetLuid
            End Get
            Private Set(ByVal value As UInt64)
                privateNetLuid = value
            End Set
        End Property
    End Class
End Namespace