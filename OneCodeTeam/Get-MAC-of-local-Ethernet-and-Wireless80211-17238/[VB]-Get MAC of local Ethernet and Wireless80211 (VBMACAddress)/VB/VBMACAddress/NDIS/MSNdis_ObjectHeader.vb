'************************** Module Header ******************************'
' Module Name:  MSNdis_ObjectHeader.vb
' Project:      VBMACAddress
' Copyright (c) Microsoft Corporation.
' 
' This class represents the MSNdis_ObjectHeader WMI class. You can 
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

    <WMIClass(ClassName:="MSNdis_ObjectHeader")>
    Public Class MSNdis_ObjectHeader

        Private privateRevision? As Byte
        <WMIProperty(PropertyName:="Revision", PropertyType:=WMIPropertyType.ByteValue)>
        Public Property Revision() As Byte?
            Get
                Return privateRevision
            End Get
            Private Set(ByVal value? As Byte)
                privateRevision = value
            End Set
        End Property

        Private privateSize? As UInt16
        <WMIProperty(PropertyName:="Size", PropertyType:=WMIPropertyType.UInt16)>
        Public Property Size() As UInt16?
            Get
                Return privateSize
            End Get
            Private Set(ByVal value? As UInt16)
                privateSize = value
            End Set
        End Property

        Private privateType? As Byte
        <WMIProperty(PropertyName:="Type", PropertyType:=WMIPropertyType.ByteValue)>
        Public Property Type() As Byte?
            Get
                Return privateType
            End Get
            Private Set(ByVal value? As Byte)
                privateType = value
            End Set
        End Property
    End Class
End Namespace