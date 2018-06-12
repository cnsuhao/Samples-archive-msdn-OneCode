/****************************** Module Header ******************************\
* Module Name:    Program.cs
* Project:        CSWCFClientTest
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to use both User Name and Client Certificates 
* as client credential type in WCF.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
* All other rights reserved.
*
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System;

namespace CSWCFClientTest
{
    class Program
    {
        static void Main(string[] args)
        {      
            string output = "";

            // Define the proxy 
            ServiceReference1.Service1Client c = new ServiceReference1.Service1Client();

            c.ClientCredentials.UserName.UserName = "Melissa";
            c.ClientCredentials.UserName.Password = "123@abc";
            output = c.GetData("123");
            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
}
