/****************************** Module Header ******************************\
* Module Name: Program.cs
* Project:     CSAzureProvideSAS
* Copyright (c) Microsoft Corporation.
* 
* To secure your Windows Azure storage, you need to generate SAS token to assign 
* user permission for CRUD. This sample will demonstrate how to generate SAS
* by using Web API, and get the SAS from client.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {

            string partitionKey = "<Partition Key>";
            

            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                var data = "="+partitionKey;
                var result = client.UploadString("http://localhost:32618/api/SASGenerater", "POST", data);
                Console.WriteLine(string.Format("Your SAS token is:{0}",result));
            }
            Console.ReadLine();

        }
    }
}
