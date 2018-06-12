/****************************** Module Header ******************************\
 * Module Name:  NET_LUID.cs
 * Project:      CSMACAddress
 * Copyright (c) Microsoft Corporation.
 * 
 * The NET_LUID union is the locally unique identifier (LUID) for a network
 * interface.
 *  
 * http://msdn.microsoft.com/en-us/library/aa366320(VS.85).aspx
 * 
 * Syntax
 *  
 * typedef union _NET_LUID {
 *   ULONG64 Value;
 *   struct {
 *     ULONG64 Reserved  :24;
 *     ULONG64 NetLuidIndex  :24;
 *     ULONG64 IfType  :16;
 *   } Info;
 * } NET_LUID, *PNET_LUID;
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
    [StructLayout(LayoutKind.Explicit)]
    internal struct NET_LUID
    {

        [FieldOffset(0)]
        internal ulong Value;

        [FieldOffset(0)]
        internal NET_LUID_Info Info;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NET_LUID_Info
    {

        internal ulong value;

        public ulong Reserved
        {
            get
            {
                return (ulong)(this.value & 0x0000000000FFFFFF);
            }
            set
            {
                this.value = (ulong)(value  | this.value);
            }
        }

        internal ulong NetLuidIndex
        {
            get
            {
                return (ulong)((this.value & 0x0000FFFFFF000000) >> 24);
            }
            set
            {
                this.value = (ulong)((value << 24) | this.value);
            }
        }

        internal ulong IfType
        {
            get
            {
                return (ulong)((this.value & 0xFFFF000000000000) >> 48);
            }
            set
            {
                this.value = (ulong)((value << 48) | this.value);
            }
        }
    }

}

