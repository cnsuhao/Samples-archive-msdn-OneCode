/****************************** Module Header ******************************\
 * Module Name:  MIB_IPNET_ROW2.cs
 * Project:      CSMACAddress
 * Copyright (c) Microsoft Corporation.
 * 
 * The MIB_IPNET_ROW2 structure stores information about a neighbor IP address.
 *  
 * http://msdn.microsoft.com/en-us/library/aa814498(VS.85).aspx
 * 
 * Syntax
 *  
 * typedef struct _MIB_IPNET_ROW2 {
 *   SOCKADDR_INET     Address;
 *   NET_IFINDEX       InterfaceIndex;
 *   NET_LUID          InterfaceLuid;
 *    UCHAR            PhysicalAddress[IF_MAX_PHYS_ADDRESS_LENGTH];
 *   ULONG             PhysicalAddressLength;
 *   NL_NEIGHBOR_STATE State;
 *   union {
 *     struct {
 *       BOOLEAN IsRouter  :1;
 *       BOOLEAN IsUnreachable  :1;
 *     };
 *     UCHAR  Flags;
 *   };
 *   union {
 *     ULONG LastReachable;
 *     ULONG LastUnreachable;
 *   } ReachabilityTime;
 * } MIB_IPNET_ROW2, *PMIB_IPNET_ROW2;
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
    /// The MIB_IPNET_ROW2 structure stores information about a neighbor IP address.
    /// Its size is 88 bytes.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct MIB_IPNET_ROW2//88
    {

        /// <summary>
        /// The neighbor IP address. This member can be an IPv6 address or an IPv4 address.
        /// Its size is 28 bytes.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)]
        internal SOCKADDR_INET Address;

        /// <summary>
        /// The local index value for the network interface associated with this IP address.
        /// typedef ULONG NET_IFINDEX, *PNET_IFINDEX; Its size is 4 bytes.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        internal uint InterfaceIndex;

        /// <summary>
        /// The locally unique identifier (LUID) for the network interface associated
        /// with this IP address.
        /// Its size is 8 bytes.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)]
        internal NET_LUID InterfaceLuid;

        /// <summary>
        /// The physical hardware address of the adapter for the network interface
        /// associated with this IP address.
        /// #define IF_MAX_PHYS_ADDRESS_LENGTH 32; Its size is 32 bytes.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        internal byte[] PhysicalAddress;

        /// <summary>
        /// The length, in bytes, of the physical hardware address specified by 
        /// the PhysicalAddress member. The maximum value supported is 32 bytes.
        /// Its size is 4 bytes.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        internal uint PhysicalAddressLength;

        /// <summary>
        /// The state of a network neighbor IP address as defined in RFC 2461,
        /// section 7.3.2. For more information, see http://www.ietf.org/rfc/rfc2461.txt. 
        /// This member can be one of the values from the NL_NEIGHBOR_STATE enumeration
        /// type defined in the Nldef.h header file. 
        /// Its size is 4 bytes
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        internal NL_NEIGHBOR_STATE State;

        /// <summary>
        /// Its size is 4 bytes
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)]
        internal MIB_IPNET_ROW2_Flags_Union Union;

        /// <summary>
        /// Its size is 4 bytes
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)]
        internal MIB_IPNET_ROW2_ReachabilityTime ReachabilityTime;
    }


    [StructLayout(LayoutKind.Explicit)]
    internal struct MIB_IPNET_ROW2_Flags_Union
    {

        [FieldOffset(0)]
        internal MIB_IPNET_ROW2_Flags_Struct Struct;

        /// <summary>
        /// A set of flags that indicate whether the IP address is a router and
        /// whether the IP address is unreachable.
        /// </summary>
        [FieldOffset(0)]
        internal byte Flags;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct MIB_IPNET_ROW2_Flags_Struct
    {
        internal uint value;

        /// <summary>
        /// A value that indicates if this IP address is a router.
        /// Its value is the lowest bit of the value field.
        /// </summary>
        internal uint IsRouter
        {
            get
            {
                return (uint)(this.value & 0x00000001);
            }
            set
            {
                this.value = (uint)(value | this.value);
            }
        }

        /// <summary>
        /// A value that indicates if this IP address is unreachable.
        /// Its value is the second lowest bit of the value field.
        /// </summary>
        internal uint IsUnreachable
        {
            get
            {
                return (uint)((this.value & 0x00000002) >> 1);
            }
            set
            {
                this.value = (uint)((value << 1) | this.value);
            }
        }

    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct MIB_IPNET_ROW2_ReachabilityTime
    {

        /// <summary>
        /// The time, in milliseconds, that a node assumes a neighbor is
        /// reachable after having received a reachability confirmation. 
        /// </summary>
        [FieldOffset(0)]
        internal uint LastReachable;

        /// <summary>
        /// The time, in milliseconds, that a node assumes a neighbor is 
        /// unreachable after not having received a reachability confirmation. 
        /// </summary>
        [FieldOffset(0)]
        internal uint LastUnreachable;
    }
}
