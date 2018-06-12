/****************************** Module Header ******************************\
 * Module Name:  SOCKADDR_IN.cs
 * Project:      CSMACAddress
 * Copyright (c) Microsoft Corporation.
 * 
 * The sockaddr structure varies depending on the protocol selected. Except 
 * for the sin*_family parameter, sockaddr contents are expressed in network
 * byte order.
 *  
 * http://msdn.microsoft.com/en-us/library/aa814468(VS.85).aspx
 * 
 * The sockaddr_in structures below is used with IPv4.
 * 
 * Syntax
 *  
 * struct sockaddr_in {
 *         short   sin_family;
 *         u_short sin_port;
 *         struct  in_addr sin_addr;
 *         char    sin_zero[8];
 * };SOCKADDR_INET, *PSOCKADDR_INET;
 * 
 * The sockaddr_in6 structure below is used with IPv6. 
 * 
 * Syntax
 *  
 * struct sockaddr_in6 {
 *         short   sin6_family;
 *         u_short sin6_port;
 *         u_long  sin6_flowinfo;
 *         struct  in6_addr sin6_addr;
 *         u_long  sin6_scope_id;
 * };
 * 
 * typedef struct sockaddr_in6 SOCKADDR_IN6;

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

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal struct SOCKADDR_IN
    {
        internal ushort sin_family;
        internal ushort sin_port;
        internal byte sin_addr0;
        internal byte sin_addr1;
        internal byte sin_addr2;
        internal byte sin_addr3;
        
        internal byte[] Address
        {
            get
            {
                return new byte[] { sin_addr0, sin_addr1, sin_addr2, sin_addr3 };
            }
        }
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal struct SOCKADDR_IN6
    {       
        internal ushort sin6_family;
        internal ushort sin6_port;
        internal uint sin6_flowinfo;
        internal byte sin6_addr0;
        internal byte sin6_addr1;
        internal byte sin6_addr2;
        internal byte sin6_addr3;
        internal byte sin6_addr4;
        internal byte sin6_addr5;
        internal byte sin6_addr6;
        internal byte sin6_addr7;
        internal byte sin6_addr8;
        internal byte sin6_addr9;
        internal byte sin6_addr10;
        internal byte sin6_addr11;
        internal byte sin6_addr12;
        internal byte sin6_addr13;
        internal byte sin6_addr14;
        internal byte sin6_addr15;
        internal uint sin6_scope_id;

        internal byte[] Address
        {
            get
            {
                return new byte[] {
                    sin6_addr0, sin6_addr1, sin6_addr2, sin6_addr3 ,
                    sin6_addr4, sin6_addr5, sin6_addr6, sin6_addr7 ,
                    sin6_addr8, sin6_addr9, sin6_addr10, sin6_addr11 ,
                    sin6_addr12, sin6_addr13, sin6_addr14, sin6_addr15 };
            }
        }
    }
}
