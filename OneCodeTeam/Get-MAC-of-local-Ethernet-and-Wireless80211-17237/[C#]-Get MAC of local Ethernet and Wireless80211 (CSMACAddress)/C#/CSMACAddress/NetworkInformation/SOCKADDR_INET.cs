/****************************** Module Header ******************************\
 * Module Name:  SOCKADDR_INET.cs
 * Project:      CSMACAddress
 * Copyright (c) Microsoft Corporation.
 * 
 * The SOCKADDR_INET union contains an IPv4, an IPv6 address, or an address 
 * family.
 *  
 * http://msdn.microsoft.com/en-us/library/aa814468(VS.85).aspx
 * 
 * Syntax
 *  
 * typedef union _SOCKADDR_INET {
 *   SOCKADDR_IN    Ipv4;
 *   SOCKADDR_IN6   Ipv6;
 *   ADDRESS_FAMILY si_family;
 * } SOCKADDR_INET, *PSOCKADDR_INET;
 * 
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

using System.Runtime.InteropServices;

namespace CSMACAddress.NetworkInformation
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    internal struct SOCKADDR_INET
    {
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.Struct)]
        internal SOCKADDR_IN Ipv4;

        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.Struct)]
        internal SOCKADDR_IN6 Ipv6;

        [FieldOffset(0)]
        internal ushort si_family;
    }



}
