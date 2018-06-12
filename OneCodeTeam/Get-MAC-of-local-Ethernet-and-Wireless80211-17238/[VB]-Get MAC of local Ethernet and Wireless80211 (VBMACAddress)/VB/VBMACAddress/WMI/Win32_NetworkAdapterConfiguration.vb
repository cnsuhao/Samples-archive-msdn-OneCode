'************************** Module Header ******************************'
' Module Name:  Win32_NetworkAdapterConfiguration.vb
' Project:      VBMACAddress
' Copyright (c) Microsoft Corporation.
' 
' This class represents the Win32_NetworkAdapterConfiguration WMI class. 
' The Win32_NetworkAdapterConfiguration WMI class represents the attributes
' and behaviors of a network adapter. This class includes extra properties 
' and methods that support the management of the TCP/IP and Internetwork Packet
' Exchange (IPX) protocols that are independent from the network adapter.
' http://msdn.microsoft.com/en-us/library/aa394217(VS.85).aspx
' 
' You can download WMI Administrative Tools to get the detailed information
' of this class.
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
'*************************************************************************'

Imports VBMACAddress.WMIHelper

Namespace WMI
    <WMIClass(ClassName:="Win32_NetworkAdapterConfiguration")>
    Public Class Win32_NetworkAdapterConfiguration


        <WMIProperty(PropertyName:="ArpAlwaysSourceRoute", PropertyType:=WMIPropertyType.Bool)>
        Public Property ArpAlwaysSourceRoute() As Boolean?

        <WMIProperty(PropertyName:="ArpUseEtherSNAP", PropertyType:=WMIPropertyType.Bool)>
        Public Property ArpUseEtherSNAP() As Boolean?

        <WMIProperty(PropertyName:="Caption", PropertyType:=WMIPropertyType.StringValue)>
        Public Property Caption() As String

        <WMIProperty(PropertyName:="DatabasePath", PropertyType:=WMIPropertyType.StringValue)>
        Public Property DatabasePath() As String

        <WMIProperty(PropertyName:="DeadGWDetectEnabled", PropertyType:=WMIPropertyType.Bool)>
        Public Property DeadGWDetectEnabled() As Boolean?

        <WMIProperty(PropertyName:="DefaultIPGateway", PropertyType:=WMIPropertyType.StringArray)>
        Public Property DefaultIPGateway() As String()

        <WMIProperty(PropertyName:="DefaultTOS", PropertyType:=WMIPropertyType.ByteValue
            )>
        Public Property DefaultTOS() As Byte?

        <WMIProperty(PropertyName:="DefaultTTL", PropertyType:=WMIPropertyType.ByteValue)>
        Public Property DefaultTTL() As Byte?

        <WMIProperty(PropertyName:="Description", PropertyType:=WMIPropertyType.StringValue)>
        Public Property Description() As String

        <WMIProperty(PropertyName:="DHCPEnabled", PropertyType:=WMIPropertyType.Bool)>
        Public Property DHCPEnabled() As Boolean?

        <WMIProperty(PropertyName:="DHCPLeaseExpires", PropertyType:=WMIPropertyType.DateTime)>
        Public Property DHCPLeaseExpires() As Date?

        <WMIProperty(PropertyName:="DHCPLeaseObtained", PropertyType:=WMIPropertyType.DateTime)>
        Public Property DHCPLeaseObtained() As Date?

        <WMIProperty(PropertyName:="DHCPServer", PropertyType:=WMIPropertyType.StringValue)>
        Public Property DHCPServer() As String

        <WMIProperty(PropertyName:="DNSDomain", PropertyType:=WMIPropertyType.StringValue)>
        Public Property DNSDomain() As String

        <WMIProperty(PropertyName:="DNSDomainSuffixSearchOrder", PropertyType:=WMIPropertyType.StringArray)>
        Public Property DNSDomainSuffixSearchOrder() As String()

        <WMIProperty(PropertyName:="DNSEnabledForWINSResolution", PropertyType:=WMIPropertyType.Bool)>
        Public Property DNSEnabledForWINSResolution() As Boolean?

        <WMIProperty(PropertyName:="DNSHostName", PropertyType:=WMIPropertyType.StringValue)>
        Public Property DNSHostName() As String

        <WMIProperty(PropertyName:="DNSServerSearchOrder", PropertyType:=WMIPropertyType.StringArray)>
        Public Property DNSServerSearchOrder() As String()

        <WMIProperty(PropertyName:="DomainDNSRegistrationEnabled", PropertyType:=WMIPropertyType.Bool)>
        Public Property DomainDNSRegistrationEnabled() As Boolean?

        <WMIProperty(PropertyName:="ForwardBufferMemory", PropertyType:=WMIPropertyType.UInt32)>
        Public Property ForwardBufferMemory() As UInt32?

        <WMIProperty(PropertyName:="FullDNSRegistrationEnabled", PropertyType:=WMIPropertyType.Bool)>
        Public Property FullDNSRegistrationEnabled() As Boolean?

        <WMIProperty(PropertyName:="GatewayCostMetric", PropertyType:=WMIPropertyType.UInt16Array)>
        Public Property GatewayCostMetric() As UInt16()

        <WMIProperty(PropertyName:="IGMPLevel", PropertyType:=WMIPropertyType.ByteValue)>
        Public Property IGMPLevel() As Byte?

        <WMIProperty(PropertyName:="Index", PropertyType:=WMIPropertyType.UInt32)>
        Public Property Index() As UInt32?

        <WMIProperty(PropertyName:="InterfaceIndex", PropertyType:=WMIPropertyType.UInt32)>
        Public Property InterfaceIndex() As UInt32?

        <WMIProperty(PropertyName:="IPAddress", PropertyType:=WMIPropertyType.StringArray)>
        Public Property IPAddress() As String()

        <WMIProperty(PropertyName:="IPConnectionMetric", PropertyType:=WMIPropertyType.UInt32)>
        Public Property IPConnectionMetric() As UInt32?

        <WMIProperty(PropertyName:="IPEnabled", PropertyType:=WMIPropertyType.Bool)>
        Public Property IPEnabled() As Boolean?

        <WMIProperty(PropertyName:="IPFilterSecurityEnabled", PropertyType:=WMIPropertyType.Bool)>
        Public Property IPFilterSecurityEnabled() As Boolean?

        <WMIProperty(PropertyName:="IPPortSecurityEnabled", PropertyType:=WMIPropertyType.Bool)>
        Public Property IPPortSecurityEnabled() As Boolean?

        <WMIProperty(PropertyName:="IPSecPermitIPProtocols", PropertyType:=WMIPropertyType.StringArray)>
        Public Property IPSecPermitIPProtocols() As String()

        <WMIProperty(PropertyName:="IPSecPermitTCPPorts", PropertyType:=WMIPropertyType.StringArray)>
        Public Property IPSecPermitTCPPorts() As String()

        <WMIProperty(PropertyName:="IPSecPermitUDPPorts", PropertyType:=WMIPropertyType.StringArray)>
        Public Property IPSecPermitUDPPorts() As String()

        <WMIProperty(PropertyName:="IPSubnet", PropertyType:=WMIPropertyType.StringArray)>
        Public Property IPSubnet() As String()

        <WMIProperty(PropertyName:="IPUseZeroBroadcast", PropertyType:=WMIPropertyType.Bool)>
        Public Property IPUseZeroBroadcast() As Boolean?

        <WMIProperty(PropertyName:="IPXAddress", PropertyType:=WMIPropertyType.StringValue)>
        Public Property IPXAddress() As String

        <WMIProperty(PropertyName:="IPXEnabled", PropertyType:=WMIPropertyType.Bool)>
        Public Property IPXEnabled() As Boolean?

        <WMIProperty(PropertyName:="IPXFrameType", PropertyType:=WMIPropertyType.UInt32Array)>
        Public Property IPXFrameType() As UInt32()

        <WMIProperty(PropertyName:="IPXMediaType", PropertyType:=WMIPropertyType.UInt32)>
        Public Property IPXMediaType() As UInt32?

        <WMIProperty(PropertyName:="IPXNetworkNumber", PropertyType:=WMIPropertyType.StringArray)>
        Public Property IPXNetworkNumber() As String()

        <WMIProperty(PropertyName:="IPXVirtualNetNumber", PropertyType:=WMIPropertyType.StringValue)>
        Public Property IPXVirtualNetNumber() As String

        <WMIProperty(PropertyName:="KeepAliveInterval", PropertyType:=WMIPropertyType.UInt32)>
        Public Property KeepAliveInterval() As UInt32?

        <WMIProperty(PropertyName:="KeepAliveTime", PropertyType:=WMIPropertyType.UInt32)>
        Public Property KeepAliveTime() As UInt32?

        <WMIProperty(PropertyName:="MACAddress", PropertyType:=WMIPropertyType.StringValue)>
        Public Property MACAddress() As String

        <WMIProperty(PropertyName:="MTU", PropertyType:=WMIPropertyType.UInt32)>
        Public Property MTU() As UInt32?

        <WMIProperty(PropertyName:="NumForwardPackets", PropertyType:=WMIPropertyType.UInt32)>
        Public Property NumForwardPackets() As UInt32?

        <WMIProperty(PropertyName:="PMTUBHDetectEnabled", PropertyType:=WMIPropertyType.Bool)>
        Public Property PMTUBHDetectEnabled() As Boolean?

        <WMIProperty(PropertyName:="PMTUDiscoveryEnabled", PropertyType:=WMIPropertyType.Bool)>
        Public Property PMTUDiscoveryEnabled() As Boolean?

        <WMIProperty(PropertyName:="ServiceName", PropertyType:=WMIPropertyType.StringValue)>
        Public Property ServiceName() As String

        <WMIProperty(PropertyName:="SettingID", PropertyType:=WMIPropertyType.StringValue)>
        Public Property SettingID() As String

        <WMIProperty(PropertyName:="TcpipNetbiosOptions", PropertyType:=WMIPropertyType.UInt32)>
        Public Property TcpipNetbiosOptions() As UInt32?

        <WMIProperty(PropertyName:="TcpMaxConnectRetransmissions", PropertyType:=WMIPropertyType.UInt32)>
        Public Property TcpMaxConnectRetransmissions() As UInt32?

        <WMIProperty(PropertyName:="TcpMaxDataRetransmissions", PropertyType:=WMIPropertyType.UInt32)>
        Public Property TcpMaxDataRetransmissions() As UInt32?

        <WMIProperty(PropertyName:="TcpNumConnections", PropertyType:=WMIPropertyType.UInt32)>
        Public Property TcpNumConnections() As UInt32?

        <WMIProperty(PropertyName:="TcpUseRFC1122UrgentPointer", PropertyType:=WMIPropertyType.Bool)>
        Public Property TcpUseRFC1122UrgentPointer() As Boolean?

        <WMIProperty(PropertyName:="TcpWindowSize", PropertyType:=WMIPropertyType.UInt16)>
        Public Property TcpWindowSize() As UInt16?

        <WMIProperty(PropertyName:="WINSEnableLMHostsLookup", PropertyType:=WMIPropertyType.Bool)>
        Public Property WINSEnableLMHostsLookup() As Boolean?

        <WMIProperty(PropertyName:="WINSHostLookupFile", PropertyType:=WMIPropertyType.StringValue)>
        Public Property WINSHostLookupFile() As String

        <WMIProperty(PropertyName:="WINSPrimaryServer", PropertyType:=WMIPropertyType.StringValue)>
        Public Property WINSPrimaryServer() As String

        <WMIProperty(PropertyName:="WINSScopeID", PropertyType:=WMIPropertyType.StringValue)>
        Public Property WINSScopeID() As String

        <WMIProperty(PropertyName:="WINSSecondaryServer", PropertyType:=WMIPropertyType.StringValue)>
        Public Property WINSSecondaryServer() As String

    End Class
End Namespace
