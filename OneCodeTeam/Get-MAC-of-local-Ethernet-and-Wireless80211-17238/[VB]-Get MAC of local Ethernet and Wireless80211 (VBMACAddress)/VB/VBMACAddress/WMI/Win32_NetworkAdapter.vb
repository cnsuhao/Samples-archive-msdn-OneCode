'************************** Module Header ******************************'
' Module Name:  Win32_NetworkAdapter.vb
' Project:      VBMACAddress
' Copyright (c) Microsoft Corporation.
'
' The Win32_NetworkAdapter WMI class represents a network adapter of a computer 
' running a Windows operating system. Win32_NetworkAdapter only supplies IPv4
' data. For more information, see IPv6 and IPv4 Support in WMI.
' 
' This class represents the Win32_NetworkAdapter class WMI. 
' http://msdn.microsoft.com/en-us/library/aa394216(VS.85).aspx
' 
' You can download WMI Administrative Tools to get the detailed information of this
' class.
'  
' http://www.microsoft.com/download/en/details.aspx?id=24045
' 
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

Namespace WMI
    <WMIClass(ClassName:="Win32_NetworkAdapter")>
    Public Class Win32_NetworkAdapter

        <WMIProperty(PropertyType:=WMIPropertyType.StringValue)>
        Public Property AdapterType() As String

        <WMIProperty(PropertyType:=WMIPropertyType.UInt16)>
        Public Property AdapterTypeID() As UInt16?

        <WMIProperty(PropertyType:=WMIPropertyType.Bool)>
        Public Property AutoSense() As Boolean?

        <WMIProperty(PropertyType:=WMIPropertyType.UInt16)>
        Public Property Availability() As UInt16?

        <WMIProperty(PropertyType:=WMIPropertyType.StringValue)>
        Public Property Caption() As String

        <WMIProperty(PropertyType:=WMIPropertyType.UInt32)>
        Public Property ConfigManagerErrorCode() As UInt32?

        <WMIProperty(PropertyType:=WMIPropertyType.Bool)>
        Public Property ConfigManagerUserConfig() As Boolean?

        <WMIProperty(PropertyType:=WMIPropertyType.StringValue)>
        Public Property CreationClassName() As String

        <WMIProperty(PropertyType:=WMIPropertyType.StringValue)>
        Public Property Description() As String

        <WMIProperty(PropertyType:=WMIPropertyType.StringValue)>
        Public Property DeviceID() As String

        <WMIProperty(PropertyType:=WMIPropertyType.Bool)>
        Public Property ErrorCleared() As Boolean?

        <WMIProperty(PropertyType:=WMIPropertyType.StringValue)>
        Public Property ErrorDescription() As String

        <WMIProperty(PropertyType:=WMIPropertyType.StringValue)>
        Public Property GUID() As String

        <WMIProperty(PropertyType:=WMIPropertyType.UInt32)>
        Public Property Index() As UInt32?

        <WMIProperty(PropertyType:=WMIPropertyType.DateTime)>
        Public Property InstallDate() As Date?

        <WMIProperty(PropertyType:=WMIPropertyType.Bool)>
        Public Property Installed() As Boolean?

        <WMIProperty(PropertyType:=WMIPropertyType.UInt32)>
        Public Property InterfaceIndex() As UInt32?

        <WMIProperty(PropertyType:=WMIPropertyType.UInt32)>
        Public Property LastErrorCode() As UInt32?

        <WMIProperty(PropertyType:=WMIPropertyType.StringValue)>
        Public Property MACAddress() As String

        <WMIProperty(PropertyType:=WMIPropertyType.StringValue)>
        Public Property Manufacturer() As String

        <WMIProperty(PropertyType:=WMIPropertyType.UInt32)>
        Public Property MaxNumberControlled() As UInt32?

        <WMIProperty(PropertyType:=WMIPropertyType.UInt64)>
        Public Property MaxSpeed() As UInt64?

        <WMIProperty(PropertyType:=WMIPropertyType.StringValue)>
        Public Property Name() As String

        <WMIProperty(PropertyType:=WMIPropertyType.StringValue)>
        Public Property NetConnectionID() As String

        <WMIProperty(PropertyType:=WMIPropertyType.UInt16)>
        Public Property NetConnectionStatus() As UInt16?

        <WMIProperty(PropertyType:=WMIPropertyType.Bool)>
        Public Property NetEnabled() As Boolean?

        <WMIProperty(PropertyType:=WMIPropertyType.StringArray)>
        Public Property NetworkAddresses() As String()

        <WMIProperty(PropertyType:=WMIPropertyType.StringValue)>
        Public Property PermanentAddress() As String

        <WMIProperty(PropertyType:=WMIPropertyType.Bool)>
        Public Property PhysicalAdapter() As Boolean?

        <WMIProperty(PropertyType:=WMIPropertyType.StringValue)>
        Public Property PNPDeviceID() As String

        <WMIProperty(PropertyType:=WMIPropertyType.UInt16Array)>
        Public Property PowerManagementCapabilities() As UInt16()

        <WMIProperty(PropertyType:=WMIPropertyType.Bool)>
        Public Property PowerManagementSupported() As Boolean?

        <WMIProperty(PropertyType:=WMIPropertyType.StringValue)>
        Public Property ProductName() As String

        <WMIProperty(PropertyType:=WMIPropertyType.StringValue)>
        Public Property ServiceName() As String

        <WMIProperty(PropertyType:=WMIPropertyType.UInt64)>
        Public Property Speed() As UInt64?

        <WMIProperty(PropertyType:=WMIPropertyType.StringValue)>
        Public Property Status() As String

        <WMIProperty(PropertyType:=WMIPropertyType.UInt16)>
        Public Property StatusInfo() As UInt16?

        <WMIProperty(PropertyType:=WMIPropertyType.StringValue)>
        Public Property SystemCreationClassName() As String

        <WMIProperty(PropertyType:=WMIPropertyType.StringValue)>
        Public Property SystemName() As String

        <WMIProperty(PropertyType:=WMIPropertyType.DateTime)>
        Public Property TimeOfLastReset() As Date?

    End Class
End Namespace
