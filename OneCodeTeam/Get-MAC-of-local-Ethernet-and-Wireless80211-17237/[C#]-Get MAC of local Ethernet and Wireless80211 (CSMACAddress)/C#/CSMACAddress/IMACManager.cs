/****************************** Module Header ******************************\
 * Module Name:  IMACManager.cs
 * Project:      CSMACAddress
 * Copyright (c) Microsoft Corporation.
 * 
 * This interface defines the basic methods used to get the MAC of local or 
 * remote host.
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

namespace CSMACAddress
{
    public interface IMACManager
    {

        /// <summary>
        /// Get the MAC of local adapters.
        /// </summary>
        Dictionary<string, PhysicalAddress> GetLocalAdaptersMAC();

        /// <summary>
        /// Get the MAC of remote host.
        /// </summary>
        /// <param name="credential">
        /// If necessary, we have to supply the credential to connect to 
        /// remote host.
        /// </param>
        Dictionary<string, PhysicalAddress> GetRemoteMachineMAC(
            string remoteHost, NetworkCredential credential);

        /// <summary>
        /// Refresh the result.
        /// </summary>
        void Refresh();
    }
}
