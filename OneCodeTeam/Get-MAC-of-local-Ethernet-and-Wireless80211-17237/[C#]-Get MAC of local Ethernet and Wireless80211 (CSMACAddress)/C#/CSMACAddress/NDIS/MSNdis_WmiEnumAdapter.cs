/****************************** Module Header ******************************\
 * Module Name:  MSNdis_WmiEnumAdapter.cs
 * Project:      CSMACAddress
 * Copyright (c) Microsoft Corporation.
 * 
 * This class represents the MSNdis_WmiEnumAdapter WMI class. You can 
 * download WMI Administrative Tools to get the detailed information of this
 * class.
 *  
 * http://www.microsoft.com/download/en/details.aspx?id=24045
 * 
 * 
 * The NDIS WMI classes are available in Windows Vista / Windows Server 2008 
 * or later version. You can run following PowerShell script to discover
 * other interesting WMI classes.
 * 
 * Get-WmiObject -Namespace root\wmi -List  | Where-Object {$_.name -Match "MSNdis" } | Sort-Object
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

namespace CSMACAddress.NDIS
{

    [WMIClass(ClassName = "MSNdis_WmiEnumAdapter")]
    public class MSNdis_WmiEnumAdapter
    {
        [WMIProperty(PropertyName = "DeviceName", PropertyType = WMIPropertyType.String)]
        public string DeviceName { get; private set; }

        [WMIProperty(PropertyName = "Header", PropertyType = WMIPropertyType.WMIObject,
            AssociatedWMIClass=typeof(MSNdis_ObjectHeader))]
        public MSNdis_ObjectHeader Header { get; private set; }

        [WMIProperty(PropertyName = "IfIndex", PropertyType = WMIPropertyType.UInt32)]
        public UInt32 IfIndex { get; private set; }

        [WMIProperty(PropertyName = "NetLuid", PropertyType = WMIPropertyType.UInt64)]
        public UInt64 NetLuid { get; private set; }
    }
}
