/****************************** Module Header ******************************\
 * Module Name:  MSNdis_EthernetCurrentAddress.cs
 * Project:      CSMACAddress
 * Copyright (c) Microsoft Corporation.
 * 
 * This class represents the MSNdis_EthernetCurrentAddress WMI class. You can 
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

using CSMACAddress.WMIHelper;

namespace CSMACAddress.NDIS
{
    [WMIClass(ClassName = "MSNdis_EthernetCurrentAddress")]
    public class MSNdis_EthernetCurrentAddress
    {
        [WMIProperty(PropertyName = "Active", PropertyType = WMIPropertyType.Boolean)]
        public bool? Active { get; private set; }

        [WMIProperty(PropertyName = "InstanceName", PropertyType = WMIPropertyType.String)]
        public string InstanceName { get; private set; }

        [WMIProperty(PropertyName = "NdisCurrentAddress",
            PropertyType = WMIPropertyType.WMIObject, AssociatedWMIClass = typeof(MSNdis_NetworkAddress))]
        public MSNdis_NetworkAddress NdisCurrentAddress { get; private set; }
    }
}
