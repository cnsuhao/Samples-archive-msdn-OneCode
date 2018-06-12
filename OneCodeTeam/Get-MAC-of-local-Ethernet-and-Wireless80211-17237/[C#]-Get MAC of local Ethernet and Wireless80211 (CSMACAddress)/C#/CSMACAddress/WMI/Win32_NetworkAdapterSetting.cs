/****************************** Module Header ******************************\
 * Module Name:  Win32_NetworkAdapterSetting.cs
 * Project:      CSMACAddress
 * Copyright (c) Microsoft Corporation.
 * 
 * The Win32_NetworkAdapterSetting association WMI class relates a network 
 * adapter and its configuration settings.
 * 
 * This class represents the Win32_NetworkAdapterSetting WMI class. 
 * 
 * http://msdn.microsoft.com/en-us/library/aa394218(VS.85).aspx
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

using CSMACAddress.WMIHelper;

namespace CSMACAddress.WMI
{
    [WMIClass(ClassName = "Win32_NetworkAdapterSetting")]
    public class Win32_NetworkAdapterSetting
    {
        [WMIProperty(PropertyName = "Element",
            PropertyType = WMIPropertyType.WMIObject,
            AssociatedWMIClass=typeof(Win32_NetworkAdapter))]
        public Win32_NetworkAdapter Element { get; private set; }

        [WMIProperty(PropertyName = "Setting", 
            PropertyType = WMIPropertyType.WMIObject,
            AssociatedWMIClass = typeof(Win32_NetworkAdapterConfiguration))]
        public Win32_NetworkAdapterConfiguration Setting { get; private set; }
    }
}
