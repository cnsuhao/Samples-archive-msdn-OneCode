/****************************** Module Header ******************************\
Module Name:  Program.cs
Project:      ConsoleApplication1
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to access the WCF service via Access control
service token. Here we create a Silverlight application and a normal Console 
application client. The Token format is SWT, and we will use password as the 
Service identities.

The Console client first sends HttpWebRequest to ACS and gets Token back, 
then re-sends a request to service with Token in http header to get data from
WCF service.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Net;
using System.IO;
using System.Web;

namespace ConsoleApplication1
{
    class Program
    {
        /// <summary>
        /// Necessary variables from ACS Portal.
        /// </summary>
        static string serviceNamespace = "<Your ACS namespace>";
        static string acsHostUrl = "accesscontrol.windows.net";
        static string realm = "<Your ACS service path>";
        static string userUrl = "<Your user service path>";
        static string uid = "<Your service identity name>";
        static string pwd = "<Your service identity password>";

        /// <summary>
        /// Access the service via ACS Token.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string token = GetTokenFromACS(realm);

            WebClient client = new WebClient();

            string headerValue = string.Format("WRAP access_token=\"{0}\"", token);

            HttpWebRequest request = HttpWebRequest.Create(userUrl) as HttpWebRequest;
            request.ContentLength = 0;
            request.Method = "GET";
            request.Headers["Authorization"] = headerValue;

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string obj = reader.ReadToEnd();
                Console.Write(obj);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Get Token from ACS.
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        private static string GetTokenFromACS(string scope)
        {
            string wrapPassword = pwd;
            string wrapUsername = uid;

            // request a token from ACS
            WebClient client = new WebClient();
            client.BaseAddress = string.Format("https://{0}.{1}", serviceNamespace, acsHostUrl);

            NameValueCollection values = new NameValueCollection();
            values.Add("wrap_name", wrapUsername);
            values.Add("wrap_password", wrapPassword);
            values.Add("wrap_scope", scope);

            byte[] responseBytes = client.UploadValues("WRAPv0.9/", "POST", values);

            string response = Encoding.UTF8.GetString(responseBytes);

            Console.WriteLine("\nreceived token from ACS: {0}\n", response);

            return HttpUtility.UrlDecode(
                response
                .Split('&')
                .Single(value => value.StartsWith("wrap_access_token=", StringComparison.OrdinalIgnoreCase))
                .Split('=')[1]);
        }


    }
}
