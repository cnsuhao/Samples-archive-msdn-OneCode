/****************************** Module Header ******************************\
 * Module Name:  WMINetworkManager.cs
 * Project:      CSMACAddress
 * Copyright (c) Microsoft Corporation.
 * 
 * This class implements the IMACManager interface and use the Win32 WMI classes
 * to get MAC of the local or remote host. 
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

namespace CSMACAddress.WMI
{
    public class WMINetworkManager : IMACManager
    {

        static WMINetworkManager instance = null;
        public static WMINetworkManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WMINetworkManager();
                }
                return instance;
            }
        }

        object locker = new object();

        List<Win32_NetworkAdapterSetting> adapters = null;

        /// <summary>
        /// A list of local adapters.
        /// </summary>
        public ReadOnlyCollection<Win32_NetworkAdapterSetting> Adapters
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
        List<Win32_NetworkAdapterSetting> GetLocalAdapters()
        {

            // The \root\wmi namespace of local machine.
            ManagementScope scope = new ManagementScope(@"\\.\root\cimv2");

            return GetAdapters(scope);
        }

        /// <summary>
        /// Get all the Win32_NetworkAdapterSetting WMI classes in the specified
        /// scope.
        /// </summary>
        List<Win32_NetworkAdapterSetting> GetAdapters(ManagementScope scope)
        {
            var adapters = new List<Win32_NetworkAdapterSetting>();

            // Query the MSNdis_EthernetCurrentAddress objects in the specified scope.
            SelectQuery query = new SelectQuery("Win32_NetworkAdapterSetting");
            ManagementObjectSearcher searcher = null;
            ManagementObjectCollection queryCollection = null;

            try
            {
                searcher = new ManagementObjectSearcher(scope, query);
                queryCollection = searcher.Get();

                foreach (ManagementObject adapterobject in queryCollection)
                {

                    // Convert the ManagementObject to a MSNdis_EthernetCurrentAddress 
                    //instance.
                    Win32_NetworkAdapterSetting adapter = WMIObjectFactory.GetInstance(
                        adapterobject, typeof(Win32_NetworkAdapterSetting), scope)
                        as Win32_NetworkAdapterSetting;

                    if (adapter != null
                        && adapter.Element.PhysicalAdapter == true
                        && !string.IsNullOrEmpty(adapter.Setting.MACAddress))
                    {

                        switch (adapter.Element.AdapterTypeID)
                        {
                            // Ethernet 802.3
                            case 0:

                            // Wireless
                            case 9:
                                adapters.Add(adapter);
                                break;
                            default:
                                break;
                        }
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

        #region INetworkManager interface


        /// <summary>
        /// Get the MAC of local Ethernet and Wireless adapters. 
        /// The Key is the adapter name, the value is the MAC of the adapter.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, PhysicalAddress> GetLocalAdaptersMAC()
        {
            var adaptersMAC = new Dictionary<string, PhysicalAddress>();

            foreach (var adapter in this.Adapters)
            {
                adaptersMAC.Add(adapter.Element.Name,
                    PhysicalAddress.Parse(
                    adapter.Setting.MACAddress.Replace(":", string.Empty)));
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
                path = string.Format(@"\\{0}.\root\cimv2", ipAddress);
            }
            else
            {
                path = string.Format(@"\\{0}\root\cimv2", remoteHost);
            }

            ManagementScope scope = new ManagementScope(path, option);

            // Get the adapters of the remote host.
            var adapters = GetAdapters(scope);

            var adaptersMAC = new Dictionary<string, PhysicalAddress>();

            foreach (var adapter in adapters)
            {
                adaptersMAC.Add(adapter.Element.Name, PhysicalAddress.Parse(
                    adapter.Setting.MACAddress.Replace(":", string.Empty)));
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
