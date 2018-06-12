/****************************** Module Header ******************************\
 * Module Name:  Program.cs
 * Project:      CSMACAddress
 * Copyright (c) Microsoft Corporation.
 * 
 * The main method of this application.
 * 
 * As the WMINetworkManager, NetworkInformationManager and NDISNetworkManager
 * classes all implements the IMACManager interface, we only have to pass an
 * IMACManager instance to get the MAC of local adapters or remote host.
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

namespace CSMACAddress
{
    class Program
    {
        const string mainOptions = @"
Choose a method to get MAC Address:
1. WMI.
2. NetworkInformation (IPHelper API)
3. MSNdis (WMI)
0: Exit.";

        const string wmiOptions = @"
Use WMI to get MAC Address.
1. Get all the MAC Addresses of local adapters.
2. Get remote MAC address.
0. Back to main options.
";

        const string networkInformationOptions = @"
Use WMNetworkInformation (IPHelper API) to get MAC Address.
1. Get all the MAC Addresses of local adapters.
2. Get remote MAC address.
0. Back to main options.
";

        const string msNdisOptions = @"
Use MSNdis (WMI classes) to get MAC Address.
1. Get all the MAC Addresses of local adapters.
2. Get remote MAC address.
0. Back to main options.
";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(mainOptions);

                int mainOption = 0;

                if (!int.TryParse(Console.ReadLine(), out mainOption))
                {
                    Console.WriteLine("Wrong input!");
                    continue;
                }
                if (mainOption == 0)
                {
                    break;
                }
                try
                {
                    switch (mainOption)
                    {
                        case 1:
                            GetMACAddress(WMI.WMINetworkManager.Instance, wmiOptions);
                            break;
                        case 2:
                            GetMACAddress(
                                NetworkInformation.NetworkInformationManager.Instance,
                                networkInformationOptions);
                            break;
                        case 3:
                            GetMACAddress(NDIS.MSNdisNetworkManager.Instance, msNdisOptions);
                            break;
                        default:
                            Console.WriteLine("Wrong input!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            Console.ReadLine();
        }

        static void GetMACAddress(IMACManager manager, string subOptions)
        {

            while (true)
            {
                Console.WriteLine(subOptions);
                int subOption = 0;

                if (!int.TryParse(Console.ReadLine(), out subOption))
                {
                    Console.WriteLine("Wrong input!");
                    continue;
                }

                if (subOption == 0)
                {
                    break;
                }

                switch (subOption)
                {
                    case 1:
                        var adaptersMAC = manager.GetLocalAdaptersMAC();
                        foreach (var item in adaptersMAC)
                        {
                            Console.WriteLine("MAC:{1} Name:{0}", item.Key, item.Value);
                        }
                        break;
                    case 2:
                        while (true)
                        {
                            Console.WriteLine("Type the remote machine and credentials (if necessary). Empty to back.");
                            Console.WriteLine("MachineName|IP [Domain UserName Password]");
                            string input = Console.ReadLine();

                            if (string.IsNullOrEmpty(input))
                            {
                                break;
                            }

                            string[] parameters = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                            if (parameters.Length != 1 && parameters.Length != 4)
                            {
                                Console.WriteLine("The input format is not correct.");
                                break;
                            }

                            string machine = parameters[0];
                            NetworkCredential credential = null;

                            if (parameters.Length == 4)
                            {
                                credential = new NetworkCredential(
                                    parameters[2], parameters[3], parameters[1]);
                            }



                            var maclist = manager.GetRemoteMachineMAC(machine, credential);
                            if (maclist != null && maclist.Count>0)
                            {
                                foreach (var mac in maclist)
                                {
                                    Console.WriteLine("MAC:{1} Name:{0}", mac.Key, mac.Value);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Can not find the Physical Address.");
                            }

                            Console.WriteLine();
                        }

                        break;
                    default:
                        Console.WriteLine("Wrong input!");
                        break;
                }

            }
        }
    }
}
