/****************************** Module Header ******************************\
 * Module Name:  MSNDISNetworkManager.cs
 * Project:      CSMACAddress
 * Copyright (c) Microsoft Corporation.
 * 
 * This class implements the IMACManager interface and use the NDIS WMI classes
 * to get MAC of the local or remote host. 
 * 
 * The NDIS WMI classes are available in Windows Vista / Windows Server 2008 
 * or later version.
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
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using CSMACAddress.WMIHelper;

namespace CSMACAddress.NDIS
{
    public class MSNdisNetworkManager : IMACManager
    {

        static MSNdisNetworkManager instance = null;
        public static MSNdisNetworkManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MSNdisNetworkManager();
                }
                return instance;
            }
        }

        object locker = new object();

        List<MSNdis_EthernetCurrentAddress> adapters = null;

        /// <summary>
        /// A list of local Ethernet Adapters.
        /// </summary>
        public ReadOnlyCollection<MSNdis_EthernetCurrentAddress> Adapters
        {
            get
            {
                if (adapters == null)
                {
                    lock (locker)
                    {
                        if (adapters == null)
                        {
                            adapters = GetLocalAdapters();
                        }
                    }
                }
                return adapters.AsReadOnly();
            }
        }

        /// <summary>
        /// Get local adapters.
        /// </summary>
        /// <returns></returns>
        List<MSNdis_EthernetCurrentAddress> GetLocalAdapters()
        {

            // The \root\wmi namespace of local machine.
            ManagementScope scope = new ManagementScope(@"\\.\root\WMI");

            return GetAdapters(scope);
        }

        /// <summary>
        /// Get all the MSNdis_EthernetCurrentAddress WMI classes in the specified
        /// scope.
        /// 
        /// They must be Ethernet and Wireless adapters. 
        /// </summary>
        List<MSNdis_EthernetCurrentAddress> GetAdapters(ManagementScope scope)
        {
            var adapterInstanceNames = GetEnumerateAdapterEx(scope);
            var physicalMediums = GetPhysicalMediums(scope);

            var adapters = new List<MSNdis_EthernetCurrentAddress>();

            // Query the MSNdis_EthernetCurrentAddress objects in the specified scope.
            SelectQuery query = new SelectQuery("MSNdis_EthernetCurrentAddress");
            ManagementObjectSearcher searcher = null;
            ManagementObjectCollection queryCollection = null;

            try
            {
                searcher = new ManagementObjectSearcher(scope, query);
                queryCollection = searcher.Get();

                foreach (ManagementObject adapterobject in queryCollection)
                {

                    // Convert the ManagementObject to a MSNdis_EthernetCurrentAddress 
                    // instance.
                    MSNdis_EthernetCurrentAddress adapter = WMIObjectFactory.GetInstance(
                        adapterobject, typeof(MSNdis_EthernetCurrentAddress), scope)
                        as MSNdis_EthernetCurrentAddress;

                    // It must be an Ethernet or Wireless adapter. 
                    if (adapter != null 
                        && adapterInstanceNames.Contains(adapter.InstanceName)
                        && physicalMediums.Contains(adapter.InstanceName))
                    {
                        adapters.Add(adapter);
                    }
                }
                return adapters;
            }
            finally
            {
                if (queryCollection != null)
                {
                    queryCollection.Dispose();
                }

                if (searcher != null)
                {
                    searcher.Dispose();
                }
            }
        }

        /// <summary>
        /// Get all the physical adapter instances.
        /// </summary>
        List<string> GetPhysicalMediums(ManagementScope scope)
        {
            List<string> physicalMediums = new List<string>();

            // Query the MSNdis_QueryPhysicalMediumTypeEx objects in the specified scope.
            SelectQuery query = new SelectQuery("MSNdis_QueryPhysicalMediumTypeEx");
            ManagementObjectSearcher searcher = null;
            ManagementObjectCollection queryCollection = null;

            try
            {
                searcher = new ManagementObjectSearcher(scope, query);
                queryCollection = searcher.Get();

                foreach (ManagementObject adapterobject in queryCollection)
                {

                    // Convert the ManagementObject to a MSNdis_QueryPhysicalMediumTypeEx 
                    //instance.
                    MSNdis_QueryPhysicalMediumTypeEx adapter = WMIObjectFactory.GetInstance(
                        adapterobject, typeof(MSNdis_QueryPhysicalMediumTypeEx), scope)
                        as MSNdis_QueryPhysicalMediumTypeEx;

                    if (adapter != null && adapter.Active==true)
                    {
                        physicalMediums.Add(adapter.InstanceName);
                    }
                }
                return physicalMediums;
            }
            finally
            {
                if (queryCollection != null)
                {
                    queryCollection.Dispose();
                }

                if (searcher != null)
                {
                    searcher.Dispose();
                }
            }
        }

        /// <summary>
        /// Get all the Ethernet and Wireless adapter instances.
        /// </summary>
        List<string> GetEnumerateAdapterEx(ManagementScope scope)
        {
            List<string> adapterInstanceNames = new List<string>();

            SelectQuery adapterQuery = new SelectQuery("MSNdis_EnumerateAdapterEx");
            ManagementObjectSearcher adapterSearcher = null;
            ManagementObjectCollection adapterQueryCollection = null;

            try
            {
                adapterSearcher = new ManagementObjectSearcher(scope, adapterQuery);
                adapterQueryCollection = adapterSearcher.Get();

                foreach (ManagementObject adapterobject in adapterQueryCollection)
                {

                    // Convert the ManagementObject to a MSNdis_EnumerateAdapterEx 
                    //instance.
                    MSNdis_EnumerateAdapterEx adapter = WMIObjectFactory.GetInstance(
                        adapterobject, typeof(MSNdis_EnumerateAdapterEx), scope)
                        as MSNdis_EnumerateAdapterEx;

                    if (adapter != null)
                    {
                        NetworkInformation.NET_LUID netluid = new NetworkInformation.NET_LUID();
                        netluid.Value = adapter.EnumerateAdapter.NetLuid;

                        switch (netluid.Info.IfType)
                        {
                            // IF_TYPE_ETHERNET_CSMACD
                            case 6:

                            // IF_TYPE_IEEE80211
                            case 71:
                                adapterInstanceNames.Add(adapter.InstanceName);
                                break;
                            default:
                                break;
                        }


                    }
                }
                return adapterInstanceNames;
            }
            finally
            {
                if (adapterQueryCollection != null)
                {
                    adapterQueryCollection.Dispose();
                }

                if (adapterSearcher != null)
                {
                    adapterSearcher.Dispose();
                }
            }
        }

        #region INetworkManager interface

        /// <summary>
        /// Get the MAC of local adapters.
        /// The Key is the adapter name, the value is the MAC of the adapter.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, PhysicalAddress> GetLocalAdaptersMAC()
        {
            var adaptersMAC = new Dictionary<string, PhysicalAddress>();

            foreach (var adapter in this.Adapters)
            {
                if (adapter.NdisCurrentAddress != null
                    && adapter.NdisCurrentAddress.Address != null)
                {
                    adaptersMAC.Add(adapter.InstanceName,
                        new PhysicalAddress(adapter.NdisCurrentAddress.Address));
                }
            }

            return adaptersMAC;
        }

        /// <summary>
        /// Get the MAC of the remote host.
        /// </summary>
        /// <param name="remoteHost">
        /// This parameter could be the machine name or an IP address.
        /// </param>
        /// <param name="credential">
        /// The credential to connect the remote host.
        /// </param>
        /// <returns>The Key is the adapter name, the value is the MAC of the adapter.</returns>
        public Dictionary<string, PhysicalAddress> GetRemoteMachineMAC(string remoteHost,
            NetworkCredential credential)
        {

            // Initialize a ConnectionOptions instance, which contains the credential
            // to connect the remote host.
            ConnectionOptions option = new ConnectionOptions();

            if (credential != null)
            {
                option.Username = string.Format("{0}\\{1}",
                    credential.Domain, credential.UserName);
                option.Password = credential.Password;
            }

            option.EnablePrivileges = true;
            option.Impersonation = ImpersonationLevel.Impersonate;
            option.Authentication = AuthenticationLevel.Default;
            option.Timeout = new TimeSpan(0, 0, 5);

            string path = string.Empty;

            IPAddress ipAddress = null;
            bool success = IPAddress.TryParse(remoteHost, out ipAddress);

            // If the remoteHost parameter is an IP Address, then add '.' to the path.
            // Like \\192.168.1.1.\root\wmi
            if (success)
            {
                path = string.Format(@"\\{0}.\root\wmi", ipAddress);
            }
            else
            {
                path = string.Format(@"\\{0}\root\wmi", remoteHost);
            }

            ManagementScope scope = new ManagementScope(path, option);

            // Get the adapters of the remote host.
            var adapters = GetAdapters(scope);

            var adaptersMAC = new Dictionary<string, PhysicalAddress>();

            foreach (var adapter in adapters)
            {
                if (adapter.NdisCurrentAddress != null && adapter.NdisCurrentAddress.Address != null)
                {
                    adaptersMAC.Add(
                        adapter.InstanceName,
                        new PhysicalAddress(adapter.NdisCurrentAddress.Address));
                }
            }

            return adaptersMAC;
        }

        public void Refresh()
        {
            this.adapters = null;
        }

        #endregion
    }
}
