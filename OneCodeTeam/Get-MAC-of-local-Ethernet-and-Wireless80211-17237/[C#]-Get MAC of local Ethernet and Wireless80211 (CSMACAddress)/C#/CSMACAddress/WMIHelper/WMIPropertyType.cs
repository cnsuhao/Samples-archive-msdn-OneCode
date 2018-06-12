/****************************** Module Header ******************************\
 * Module Name:  WMIPropertyType.cs
 * Project:      CSMACAddress
 * Copyright (c) Microsoft Corporation.
 *
 * The enum defines the WMI property types, which will be used to convert the 
 * WMI property value to a .NET type. 
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
namespace CSMACAddress.WMIHelper
{
    public enum WMIPropertyType
    {
        Boolean,
        Byte,
        Int16,
        Int32,
        Int64,
        UInt16,
        UInt32,
        UInt64,
        DateTime,
        String,
        ByteArray,
        UInt16Array,
        UInt32Array,
        StringArray,
        WMIObject
    }
}
