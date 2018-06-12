/****************************** Module Header ******************************\
Module Name:  Program.cs
Project:      ConsoleApplication1
Copyright (c) Microsoft Corporation.

This is a client project which will run on your on-promise computer.

 Inovke the WCF service directly.
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
using System;
using System.ServiceModel;
using InstanceController.Interface;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicHttpBinding binding = new BasicHttpBinding();
           
            using (ChannelFactory<IInstanceController> channel = new ChannelFactory<IInstanceController>(binding, "http://168.63.213.69:3721/InternalService"))  
            {
                IInstanceController proxy = channel.CreateChannel();
                if (proxy.RunScriptOnEveryInstance("batcontainer", "ConsoleApplication1.exe"))
                {
                    Console.WriteLine("The file is executed correctly!");
                }
                else
                {
                    Console.WriteLine("The file can't be executed correctly!");
                }
                Console.Read();
            }
        }
    }
}
