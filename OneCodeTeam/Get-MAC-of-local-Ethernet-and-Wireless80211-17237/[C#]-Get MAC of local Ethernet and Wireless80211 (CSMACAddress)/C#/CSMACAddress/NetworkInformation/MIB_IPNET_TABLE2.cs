/****************************** Module Header ******************************\
 * Module Name:  MIB_IPNET_TABLE2.cs
 * Project:      CSMACAddress
 * Copyright (c) Microsoft Corporation.
 * 
 * The MIB_IPNET_TABLE2 structure contains a table of neighbor IP address entries.
 *  
 * http://msdn.microsoft.com/en-us/library/aa814499(VS.85).aspx
 * 
 * Syntax
 *  
 * typedef struct _MIB_IPNET_TABLE2 {
 *     ULONG       NumEntries;
 *     MIB_IF_ROW2 Table[ANY_SIZE];
 * } MIB_IPNET_TABLE2, *PMIB_IPNET_TABLE2;
 * 
 * Because the length of the Table field is not fixed, we cannot marshal it
 * directly. If we get the pointer of the MIB_IPNET_TABLE2 instance, we have 
 * to get the MIB_IF_ROW2 instance one by one using the pointer.
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
using System.Runtime.InteropServices;

namespace CSMACAddress.NetworkInformation
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct MIB_IPNET_TABLE2
    {
        /// <summary>
        /// A value that specifies the number of IP network neighbor 
        /// address entries in the array.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        internal uint NumEntries;


        /// <summary>
        /// MIB_IF_ROW2 Table[ANY_SIZE];
        /// Because the length of the Table field is not fixed, we cannot marshal it
        /// directly. If we get the pointer of the MIB_IPNET_TABLE2 instance, we have 
        /// to get the MIB_IF_ROW2 instance one by one using the pointer.
        /// </summary>
        /// <param name="pMIB_IPNET_TABLE2">
        /// A pointer to a MIB_IPNET_TABLE2 structure that contains a table of neighbor
        /// IP address entries on the local computer. 
        /// </param>
        /// <returns></returns>
        public static MIB_IPNET_ROW2[] GetTable(IntPtr pMIB_IPNET_TABLE2)
        {
            MIB_IPNET_ROW2[] table = null;
            try
            {

                // Marshal a MIB_IPNET_TABLE2 instance from the pointer.
                MIB_IPNET_TABLE2 mib_ipnet_table2 = (MIB_IPNET_TABLE2)Marshal.PtrToStructure(
                    pMIB_IPNET_TABLE2,
                    typeof(MIB_IPNET_TABLE2));

                // The array length is the NumEntries.
                table = new MIB_IPNET_ROW2[mib_ipnet_table2.NumEntries];

                // Get the start address of the MIB_IPNET_ROW2 array.
                IntPtr currentPointer = pMIB_IPNET_TABLE2 + 8;

                for (int i = 0; i < mib_ipnet_table2.NumEntries; i++)
                {

                    table[i] = (MIB_IPNET_ROW2)Marshal.PtrToStructure(
                        currentPointer,
                        typeof(MIB_IPNET_ROW2));

                    currentPointer += Marshal.SizeOf(table[i]);
                }

                return table;
            }
            catch
            {
                return null;
            }
           

        }
    }

}
