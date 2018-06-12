/****************************** Module Header ******************************\
 * Module Name:  NDISNetworkManager.cs
 * Project:      CSMACAddress
 * Copyright (c) Microsoft Corporation.
 * 
 * This class implements the IMACManager interface and use the IP Helper APIs
 * to get MAC of the local or remote host. 
 * 
 * These new APIs are introduced in Windows Vista / Windows Server 2008 or later
 * versions.
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Net.Sockets;

namespace CSMACAddress.NetworkInformation
{
    public class NetworkInformationManager : IMACManager
    {

        static NetworkInformationManager instance = null;
        public static NetworkInformationManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NetworkInformationManager();
                }
                return instance;
            }
        }

        object locker = new object();

        NetworkInterface[] interfaces = null;

        /// <summary>
        /// A list of local adapters.
        /// </summary>
        public ReadOnlyCollection<NetworkInterface> Interfaces
        {
            get
            {
                if (interfaces == null)
                {
                    lock (locker)
                    {
                        if (interfaces == null)
                        {
                            interfaces = NetworkInterface.GetAllNetworkInterfaces();
                        }
                    }
                }
                return Array.AsReadOnly<NetworkInterface>(interfaces);
            }
        }

        #region INetworkManager interface


        /// <summary>
        /// Get local Ethernet and Wireless adapters. 
        /// The Key is the adapter name, the value is the MAC of the adapter.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, PhysicalAddress> GetLocalAdaptersMAC()
        {
            var adaptersMAC = new Dictionary<string, PhysicalAddress>();

            foreach (var networkInterface in Interfaces)
            {

                // It must be an Ethernet and Wireless adapters. 
                switch (networkInterface.NetworkInterfaceType)
                {
                    case NetworkInterfaceType.Ethernet:
                    case NetworkInterfaceType.Wireless80211:
                        var address = networkInterface.GetPhysicalAddress();
                        if (address != null )
                        {
                            adaptersMAC.Add(networkInterface.Description, address);
                        }
                        break;
                    default:
                        break;

                }


            }
            return adaptersMAC;
        }

        /// <summary>
        /// Get the MAC of the remote host.
        /// </summary>
        /// <param name="remoteHost">
        ///  This parameter could be the machine name or an IP address.
        /// </param>
        /// <param name="credential">The credential to connect the remote host.</param>
        /// <returns>
        /// The Key is the IP address, the value is the MAC of the adapter.
        /// </returns>
        public Dictionary<string, PhysicalAddress> GetRemoteMachineMAC(string remoteHost, NetworkCredential credential)
        {
            var results = new Dictionary<string, PhysicalAddress>();

            // Resolve the IP addresses of the remote host.
            var addresses = ResolveIPAddress(remoteHost);

            if (addresses == null || addresses.Count() == 0)
            {
                return results;
            }

            IntPtr ptable = IntPtr.Zero;
            try
            {

                // Get the IP neighbor table. 
                int hr = NativeMethods.GetIpNetTable2(
                    (ushort)AddressFamily.Unspecified, out ptable);

                Marshal.ThrowExceptionForHR(hr);

                // Get the MIB_IPNET_ROW2 array.
                var rows = MIB_IPNET_TABLE2.GetTable(ptable);

                // Search the IP neighbor table for the specified IP address.
                foreach (var remoteMachineAddress in addresses)
                {
                    if (remoteMachineAddress.AddressFamily != AddressFamily.InterNetwork
                        && remoteMachineAddress.AddressFamily != AddressFamily.InterNetworkV6)
                    {
                        continue;
                    }

                    foreach (var row in rows)
                    {

                        if (row.PhysicalAddressLength > 0)
                        {
                            IPAddress ipAddress = null;
                            if (remoteMachineAddress.AddressFamily == AddressFamily.InterNetwork)
                            {
                                ipAddress = new IPAddress(row.Address.Ipv4.Address);
                            }
                            else
                            {
                                ipAddress = new IPAddress(row.Address.Ipv6.Address);
                            }

                            if (remoteMachineAddress.Equals(ipAddress))
                            {
                                var macAddress = new PhysicalAddress(
                                    row.PhysicalAddress.Take((int)row.PhysicalAddressLength).ToArray());
                                results.Add(ipAddress.ToString(), macAddress);
                                break;
                            }
                        }
                    }
                }
            }
            finally
            {
                if (ptable != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(ptable);
                }
            }

            return results;

        }

        public void Refresh()
        {
            interfaces = null;
        }

        #endregion

        IEnumerable<IPAddress> ResolveIPAddress(string remoteHost)
        {
            IPAddress[] addresses = null;
            IPAddress ipAddress = null;
            bool success = IPAddress.TryParse(remoteHost, out ipAddress);

            if (!success)
            {
                var entry = Dns.GetHostEntry(remoteHost);
                if (entry != null && entry.AddressList.Length > 0)
                {
                    addresses = entry.AddressList;
                }
            }
            else
            {
                addresses = new IPAddress[] { ipAddress };
            }

            return addresses;
        }

    }
}
