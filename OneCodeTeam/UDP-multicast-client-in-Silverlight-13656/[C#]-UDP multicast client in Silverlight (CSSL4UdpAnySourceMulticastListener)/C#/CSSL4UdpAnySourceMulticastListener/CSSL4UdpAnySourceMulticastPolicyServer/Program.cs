/****************************** Module Header ******************************\
* Module Name:  Program.cs
* Project: CSSL4UdpAnySourceMulticastPolicyServer
* Copyright (c) Microsoft Corporation.
* 
* This file contains the simple console application that hosts a Silverlight
* Multicast Policy Server for the purposes of this sample.  
* It simply loads the multicast policy server on the default multicast IP, 
* on an arbitrarily chosen port, 8888, 
* and waits for the user to press a key to continue.
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
using System.Net;
using Microsoft.Silverlight.PolicyServers;

namespace CSSL4UdpAnySourceMulticastPolicyServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a configuration.  This comes from the Microsoft.Silverlight.PolicyServers.dll reference.
            // The reference is from the Microsoft sample providing a simple implementation of an SL policy server.
            // The code for the policy server sample can be found here:  
            // http://archive.msdn.microsoft.com/Project/Download/FileDownload.aspx?ProjectName=silverlightsdk&DownloadId=8312
            MulticastPolicyConfiguration config = new MulticastPolicyConfiguration();
            
            // Allow UDP multicast on the default multicast IP, with arbitrarily selected port 8888.
            config.AnySourceConfiguration.Add("*", new MulticastResource(IPAddress.Parse("224.0.0.1"), 8888));
            
            // Create a policy server based on the provided configuration.  This allows multicast 
            // to be used from Silverlight clients.
            // The policy server returns an XML policy file to SL clients requesting multicast 
            // on that port, similar to CrossDomainPolicy.xml.
            // The policy file is served over UDP though, so cannot be provided via a web server 
            // as is commonly done with web traffic from SL.
            MulticastPolicyServer server = new MulticastPolicyServer(config);
            server.Start();
            Console.WriteLine("MulticastPolicyServer running on port 8888...");
            Console.WriteLine("Press enter to stop...");
            Console.ReadLine();
            server.Stop();
        }
    }
}
