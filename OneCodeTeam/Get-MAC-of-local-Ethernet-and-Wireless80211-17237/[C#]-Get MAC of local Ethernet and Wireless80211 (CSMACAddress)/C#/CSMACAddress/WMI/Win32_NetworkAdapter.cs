/****************************** Module Header ******************************\
 * Module Name:  Win32_NetworkAdapter.cs
 * Project:      CSMACAddress
 * Copyright (c) Microsoft Corporation.
 *
 * The Win32_NetworkAdapter WMI class represents a network adapter of a computer 
 * running a Windows operating system. Win32_NetworkAdapter only supplies IPv4
 * data. For more information, see IPv6 and IPv4 Support in WMI.
 * 
 * This class represents the Win32_NetworkAdapter class WMI. 
 * http://msdn.microsoft.com/en-us/library/aa394216(VS.85).aspx
 * 
 * You can download WMI Administrative Tools to get the detailed information of this
 * class.
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
    [WMIClass(ClassName = "Win32_NetworkAdapter")]
    public class Win32_NetworkAdapter
    {
        [WMIProperty(PropertyType = WMIPropertyType.String)]
        public string AdapterType { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.UInt16)]
        public UInt16? AdapterTypeID { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.Boolean)]
        public bool? AutoSense { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.UInt16)]
        public UInt16? Availability { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.String)]
        public string Caption { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.UInt32)]
        public UInt32? ConfigManagerErrorCode { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.Boolean)]
        public bool? ConfigManagerUserConfig { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.String)]
        public string CreationClassName { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.String)]
        public string Description { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.String)]
        public string DeviceID { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.Boolean)]
        public bool? ErrorCleared { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.String)]
        public string ErrorDescription { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.String)]
        public string GUID { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.UInt32)]
        public UInt32? Index { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.DateTime)]
        public DateTime? InstallDate { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.Boolean)]
        public bool? Installed { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.UInt32)]
        public UInt32? InterfaceIndex { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.UInt32)]
        public UInt32? LastErrorCode { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.String)]
        public string MACAddress { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.String)]
        public string Manufacturer { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.UInt32)]
        public UInt32? MaxNumberControlled { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.UInt64)]
        public UInt64? MaxSpeed { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.String)]
        public string Name { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.String)]
        public string NetConnectionID { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.UInt16)]
        public UInt16? NetConnectionStatus { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.Boolean)]
        public bool? NetEnabled { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.StringArray)]
        public string[] NetworkAddresses { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.String)]
        public string PermanentAddress { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.Boolean)]
        public bool? PhysicalAdapter { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.String)]
        public string PNPDeviceID { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.UInt16Array)]
        public UInt16[] PowerManagementCapabilities { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.Boolean)]
        public bool? PowerManagementSupported { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.String)]
        public string ProductName { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.String)]
        public string ServiceName { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.UInt64)]
        public UInt64? Speed { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.String)]
        public string Status { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.UInt16)]
        public UInt16? StatusInfo { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.String)]
        public string SystemCreationClassName { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.String)]
        public string SystemName { get; private set; }

        [WMIProperty(PropertyType = WMIPropertyType.DateTime)]
        public DateTime? TimeOfLastReset { get; private set; }
    }
}
