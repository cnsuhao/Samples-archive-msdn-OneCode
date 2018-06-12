/****************************** Module Header ******************************\
 * Module Name:  Win32_NetworkAdapterConfiguration.cs
 * Project:      CSMACAddress
 * Copyright (c) Microsoft Corporation.
 * 
 * This class represents the Win32_NetworkAdapterConfiguration WMI class. 
 * The Win32_NetworkAdapterConfiguration WMI class represents the attributes
 * and behaviors of a network adapter. This class includes extra properties 
 * and methods that support the management of the TCP/IP and Internetwork Packet
 * Exchange (IPX) protocols that are independent from the network adapter.
 * http://msdn.microsoft.com/en-us/library/aa394217(VS.85).aspx
 * 
 * You can download WMI Administrative Tools to get the detailed information
 * of this class.
 *  
 * http://www.microsoft.com/download/en/details.aspx?id=24045
 * 
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using CSMACAddress.WMIHelper;

namespace CSMACAddress.WMI
{
    [WMIClass(ClassName = "Win32_NetworkAdapterConfiguration")]
    public class Win32_NetworkAdapterConfiguration
    {

        [WMIProperty(PropertyName = "ArpAlwaysSourceRoute", PropertyType = WMIPropertyType.Boolean)]
        public bool? ArpAlwaysSourceRoute { get; private set; }

        [WMIProperty(PropertyName = "ArpUseEtherSNAP", PropertyType = WMIPropertyType.Boolean)]
        public bool? ArpUseEtherSNAP { get; private set; }

        [WMIProperty(PropertyName = "Caption", PropertyType = WMIPropertyType.String)]
        public string Caption { get; private set; }

        [WMIProperty(PropertyName = "DatabasePath", PropertyType = WMIPropertyType.String)]
        public string DatabasePath { get; private set; }

        [WMIProperty(PropertyName = "DeadGWDetectEnabled", PropertyType = WMIPropertyType.Boolean)]
        public bool? DeadGWDetectEnabled { get; private set; }

        [WMIProperty(PropertyName = "DefaultIPGateway", PropertyType = WMIPropertyType.StringArray)]
        public string[] DefaultIPGateway { get; private set; }

        [WMIProperty(PropertyName = "DefaultTOS", PropertyType = WMIPropertyType.Byte)]
        public byte? DefaultTOS { get; private set; }

        [WMIProperty(PropertyName = "DefaultTTL", PropertyType = WMIPropertyType.Byte)]
        public byte? DefaultTTL { get; private set; }

        [WMIProperty(PropertyName = "Description", PropertyType = WMIPropertyType.String)]
        public string Description { get; private set; }

        [WMIProperty(PropertyName = "DHCPEnabled", PropertyType = WMIPropertyType.Boolean)]
        public bool? DHCPEnabled { get; private set; }

        [WMIProperty(PropertyName = "DHCPLeaseExpires", PropertyType = WMIPropertyType.DateTime)]
        public DateTime? DHCPLeaseExpires { get; private set; }

        [WMIProperty(PropertyName = "DHCPLeaseObtained", PropertyType = WMIPropertyType.DateTime)]
        public DateTime? DHCPLeaseObtained { get; private set; }

        [WMIProperty(PropertyName = "DHCPServer", PropertyType = WMIPropertyType.String)]
        public string DHCPServer { get; private set; }

        [WMIProperty(PropertyName = "DNSDomain", PropertyType = WMIPropertyType.String)]
        public string DNSDomain { get; private set; }

        [WMIProperty(PropertyName = "DNSDomainSuffixSearchOrder", PropertyType = WMIPropertyType.StringArray)]
        public string[] DNSDomainSuffixSearchOrder { get; private set; }

        [WMIProperty(PropertyName = "DNSEnabledForWINSResolution", PropertyType = WMIPropertyType.Boolean)]
        public bool? DNSEnabledForWINSResolution { get; private set; }

        [WMIProperty(PropertyName = "DNSHostName", PropertyType = WMIPropertyType.String)]
        public string DNSHostName { get; private set; }

        [WMIProperty(PropertyName = "DNSServerSearchOrder", PropertyType = WMIPropertyType.StringArray)]
        public string[] DNSServerSearchOrder { get; private set; }

        [WMIProperty(PropertyName = "DomainDNSRegistrationEnabled", PropertyType = WMIPropertyType.Boolean)]
        public bool? DomainDNSRegistrationEnabled { get; private set; }

        [WMIProperty(PropertyName = "ForwardBufferMemory", PropertyType = WMIPropertyType.UInt32)]
        public UInt32? ForwardBufferMemory { get; private set; }

        [WMIProperty(PropertyName = "FullDNSRegistrationEnabled", PropertyType = WMIPropertyType.Boolean)]
        public bool? FullDNSRegistrationEnabled { get; private set; }

        [WMIProperty(PropertyName = "GatewayCostMetric", PropertyType = WMIPropertyType.UInt16Array)]
        public UInt16[] GatewayCostMetric { get; private set; }

        [WMIProperty(PropertyName = "IGMPLevel", PropertyType = WMIPropertyType.Byte)]
        public byte? IGMPLevel { get; private set; }

        [WMIProperty(PropertyName = "Index", PropertyType = WMIPropertyType.UInt32)]
        public UInt32? Index { get; private set; }

        [WMIProperty(PropertyName = "InterfaceIndex", PropertyType = WMIPropertyType.UInt32)]
        public UInt32? InterfaceIndex { get; private set; }

        [WMIProperty(PropertyName = "IPAddress", PropertyType = WMIPropertyType.StringArray)]
        public string[] IPAddress { get; private set; }

        [WMIProperty(PropertyName = "IPConnectionMetric", PropertyType = WMIPropertyType.UInt32)]
        public UInt32? IPConnectionMetric { get; private set; }

        [WMIProperty(PropertyName = "IPEnabled", PropertyType = WMIPropertyType.Boolean)]
        public bool? IPEnabled { get; private set; }

        [WMIProperty(PropertyName = "IPFilterSecurityEnabled", PropertyType = WMIPropertyType.Boolean)]
        public bool? IPFilterSecurityEnabled { get; private set; }

        [WMIProperty(PropertyName = "IPPortSecurityEnabled", PropertyType = WMIPropertyType.Boolean)]
        public bool? IPPortSecurityEnabled { get; private set; }

        [WMIProperty(PropertyName = "IPSecPermitIPProtocols", PropertyType = WMIPropertyType.StringArray)]
        public string[] IPSecPermitIPProtocols { get; private set; }

        [WMIProperty(PropertyName = "IPSecPermitTCPPorts", PropertyType = WMIPropertyType.StringArray)]
        public string[] IPSecPermitTCPPorts { get; private set; }

        [WMIProperty(PropertyName = "IPSecPermitUDPPorts", PropertyType = WMIPropertyType.StringArray)]
        public string[] IPSecPermitUDPPorts { get; private set; }

        [WMIProperty(PropertyName = "IPSubnet", PropertyType = WMIPropertyType.StringArray)]
        public string[] IPSubnet { get; private set; }

        [WMIProperty(PropertyName = "IPUseZeroBroadcast", PropertyType = WMIPropertyType.Boolean)]
        public bool? IPUseZeroBroadcast { get; private set; }

        [WMIProperty(PropertyName = "IPXAddress", PropertyType = WMIPropertyType.String)]
        public string IPXAddress { get; private set; }

        [WMIProperty(PropertyName = "IPXEnabled", PropertyType = WMIPropertyType.Boolean)]
        public bool? IPXEnabled { get; private set; }

        [WMIProperty(PropertyName = "IPXFrameType", PropertyType = WMIPropertyType.UInt32Array)]
        public UInt32[] IPXFrameType { get; private set; }

        [WMIProperty(PropertyName = "IPXMediaType", PropertyType = WMIPropertyType.UInt32)]
        public UInt32? IPXMediaType { get; private set; }

        [WMIProperty(PropertyName = "IPXNetworkNumber", PropertyType = WMIPropertyType.StringArray)]
        public string[] IPXNetworkNumber { get; private set; }

        [WMIProperty(PropertyName = "IPXVirtualNetNumber", PropertyType = WMIPropertyType.String)]
        public string IPXVirtualNetNumber { get; private set; }

        [WMIProperty(PropertyName = "KeepAliveInterval", PropertyType = WMIPropertyType.UInt32)]
        public UInt32? KeepAliveInterval { get; private set; }

        [WMIProperty(PropertyName = "KeepAliveTime", PropertyType = WMIPropertyType.UInt32)]
        public UInt32? KeepAliveTime { get; private set; }

        [WMIProperty(PropertyName = "MACAddress", PropertyType = WMIPropertyType.String)]
        public string MACAddress { get; private set; }

        [WMIProperty(PropertyName = "MTU", PropertyType = WMIPropertyType.UInt32)]
        public UInt32? MTU { get; private set; }

        [WMIProperty(PropertyName = "NumForwardPackets", PropertyType = WMIPropertyType.UInt32)]
        public UInt32? NumForwardPackets { get; private set; }

        [WMIProperty(PropertyName = "PMTUBHDetectEnabled", PropertyType = WMIPropertyType.Boolean)]
        public bool? PMTUBHDetectEnabled { get; private set; }

        [WMIProperty(PropertyName = "PMTUDiscoveryEnabled", PropertyType = WMIPropertyType.Boolean)]
        public bool? PMTUDiscoveryEnabled { get; private set; }

        [WMIProperty(PropertyName = "ServiceName", PropertyType = WMIPropertyType.String)]
        public string ServiceName { get; private set; }

        [WMIProperty(PropertyName = "SettingID", PropertyType = WMIPropertyType.String)]
        public string SettingID { get; private set; }

        [WMIProperty(PropertyName = "TcpipNetbiosOptions", PropertyType = WMIPropertyType.UInt32)]
        public UInt32? TcpipNetbiosOptions { get; private set; }

        [WMIProperty(PropertyName = "TcpMaxConnectRetransmissions", PropertyType = WMIPropertyType.UInt32)]
        public UInt32? TcpMaxConnectRetransmissions { get; private set; }

        [WMIProperty(PropertyName = "TcpMaxDataRetransmissions", PropertyType = WMIPropertyType.UInt32)]
        public UInt32? TcpMaxDataRetransmissions { get; private set; }

        [WMIProperty(PropertyName = "TcpNumConnections", PropertyType = WMIPropertyType.UInt32)]
        public UInt32? TcpNumConnections { get; private set; }

        [WMIProperty(PropertyName = "TcpUseRFC1122UrgentPointer", PropertyType = WMIPropertyType.Boolean)]
        public bool? TcpUseRFC1122UrgentPointer { get; private set; }

        [WMIProperty(PropertyName = "TcpWindowSize", PropertyType = WMIPropertyType.UInt16)]
        public UInt16? TcpWindowSize { get; private set; }

        [WMIProperty(PropertyName = "WINSEnableLMHostsLookup", PropertyType = WMIPropertyType.Boolean)]
        public bool? WINSEnableLMHostsLookup { get; private set; }

        [WMIProperty(PropertyName = "WINSHostLookupFile", PropertyType = WMIPropertyType.String)]
        public string WINSHostLookupFile { get; private set; }

        [WMIProperty(PropertyName = "WINSPrimaryServer", PropertyType = WMIPropertyType.String)]
        public string WINSPrimaryServer { get; private set; }

        [WMIProperty(PropertyName = "WINSScopeID", PropertyType = WMIPropertyType.String)]
        public string WINSScopeID { get; private set; }

        [WMIProperty(PropertyName = "WINSSecondaryServer", PropertyType = WMIPropertyType.String)]
        public string WINSSecondaryServer { get; private set; }
    }
}
