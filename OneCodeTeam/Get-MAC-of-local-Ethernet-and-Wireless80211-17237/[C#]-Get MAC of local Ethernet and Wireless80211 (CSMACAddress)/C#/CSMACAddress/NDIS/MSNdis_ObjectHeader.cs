/****************************** Module Header ******************************\
 * Module Name:  MSNdis_ObjectHeader.cs
 * Project:      CSMACAddress
 * Copyright (c) Microsoft Corporation.
 * 
 * This class represents the MSNdis_ObjectHeader WMI class. You can 
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

    [WMIClass(ClassName = "MSNdis_ObjectHeader")]
    public class MSNdis_ObjectHeader  
    {

        [WMIProperty(PropertyName = "Revision", PropertyType = WMIPropertyType.Byte)]
        public byte? Revision { get; private set; }

        [WMIProperty(PropertyName = "Size", PropertyType = WMIPropertyType.UInt16)]
        public UInt16? Size { get; private set; }

        [WMIProperty(PropertyName = "Type", PropertyType = WMIPropertyType.Byte)]
        public byte? Type { get; private set; }
    }
}
