/****************************** Module Header ******************************\
* Module Name: Program.cs
* Project:     CSSL4SocketProgrammingServer
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to use Socket achieve MultiCast function
* in Silverlight. We demonstrate ISM and SSM in this sample, The 
* application includes a console application as server side and a 
* Silverlight application as client side, the server will broadcast
* messages to client sides and client sides can also send messages 
* to other users.
*
* This class use to create a server.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Timers;
using System.Threading;
using Microsoft.Silverlight.PolicyServers;

namespace CSSL4SocketProgrammingServer
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Define UDP server and end point.
            IPEndPoint serverPoint = new IPEndPoint(IPAddress.Any, int.Parse(IPConfig.ServerIPPort));
            IPEndPoint broadcastPoint = new IPEndPoint(IPAddress.Broadcast, int.Parse(IPConfig.BroadcastIPPort));
            UdpClient udpServer = new UdpClient(serverPoint);
            Console.WriteLine("=======================================\r\n");
            Console.WriteLine("Silverlight Socket Programming Server\r\n");
            Console.WriteLine("=======================================\r\n");

            // SSM server start.
            MulticastPolicyConfiguration configSSM = new MulticastPolicyConfiguration();
            configSSM.SingleSourceConfiguration.Add("*", new MulticastResource(IPAddress.Parse(IPConfig.BroadcastIP), int.Parse(IPConfig.BroadcastIPPort)));
            MulticastPolicyServer serverSSM = new MulticastPolicyServer(configSSM);
            serverSSM.Start();
            Console.WriteLine("Server start..");

            // ISM server start.
            MulticastPolicyConfiguration configISM = new MulticastPolicyConfiguration();
            configISM.AnySourceConfiguration.Add("*", new MulticastResource(IPAddress.Parse(IPConfig.BroadcastIP), int.Parse(IPConfig.PolicyLocalPort))); 
            MulticastPolicyServer serverISM = new MulticastPolicyServer(configISM);
            serverISM.Start();

            // Create a timer and send broadcast messages every 1 seconds.
            var timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += delegate
            {
                string msg = string.Format("{0}: {1} - [{2}]", Dns.GetHostName(), " Send Message : My Time is", DateTime.Now.ToString("HH:mm:ss"));
                byte[] data = Encoding.UTF8.GetBytes(msg);

                int byteNumber = udpServer.Send(data, data.Length, broadcastPoint);
                Console.WriteLine(String.Format("The broadcast server have send {0} bytes message to clients.", byteNumber));
            };
            timer.Start();
            Console.WriteLine("Start complete.");
            Console.ReadKey();
        }


    }
}
