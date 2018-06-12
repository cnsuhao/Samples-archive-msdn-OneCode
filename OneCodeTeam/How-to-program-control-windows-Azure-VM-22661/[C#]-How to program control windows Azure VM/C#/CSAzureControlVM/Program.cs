/****************************** Module Header ******************************\
* Module Name: Program.cs
* Project:     CSAzureControlVM
* Copyright (c) Microsoft Corporation.
* 
* To operate widnows Azure Iaas virtual machine, using the azure power shell 
* isn't the only way. We also can use mangement service API to achieve this target.
* This sample will use GET/POST/DELETE requests to operate the virtual machine.
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
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.IO;

namespace CSAzureControlVM
{
    class Program
    {
        //First set the subscription ID, you can find it in your Azure portal.
        public static string SubscriptionID = "YOUR_SUBSCRIPTION_ID";

        //A VM need a host service, you can create it in your Azure portal.
        public static string ServiceName = "SERVICE_NAME";

        //You need to make sure this certificate is in your Azure management certificate pool.
        //And it's also in your local computer personal certificate pool.
        public static string CertificateThumbprint = "MANAGEMENT_CERTIFICATE";
        public static X509Certificate2 Certificate;
        public delegate HttpWebRequest VMOperateRequest();
  
        public static void Main(string[] args)
        {
            Console.WriteLine("Please first input your subscription ID");
            SubscriptionID = Console.ReadLine();

            Console.WriteLine("Please enter the service name you want to hold the VM");
            ServiceName = Console.ReadLine();

            Console.WriteLine("Please enter the Azure management certificate thumbprint:");
            CertificateThumbprint = Console.ReadLine();

            VMOperateRequest[] vmDels = new VMOperateRequest[] { 
                AddVirtualMachine, //Post request
                GetVirtualMachineState, //Get request
                DeleteVirtualMachine };//Delete request

            X509Store certificateStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            certificateStore.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certs = certificateStore.Certificates.Find(
                X509FindType.FindByThumbprint,
                CertificateThumbprint,
                false);


            if (certs.Count == 0)
            {
                Console.WriteLine("Can't find the certificate in your local computer.");
                Console.ReadKey();
                return;
            }
            else
            {
                Certificate = certs[0];
            }

            Console.WriteLine("Please choose the operation:" +
                "\n1.Add new VM\n2.Get VM state\n3.delete VM\n" +
                "Please input the number");
            int number = int.Parse(Console.ReadLine()) - 1;
            HttpWebRequest request;

            while (true)
            {
                if (number >= 0 && number <= 2)
                {
                    request = vmDels[number]();
                    break;
                }
                else
                {
                    Console.Write("Please input right number.");
                }
            }


            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // Display the web response status code.
                Console.WriteLine("Response status code: " + response.StatusCode);

                // Display the request ID returned by Windows Azure.
                if (null != response.Headers)
                {
                    Console.WriteLine("x-ms-request-id:"
                    + response.Headers["x-ms-request-id"]);

                }
                // Parse the web response.
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                // Display the raw response.
                Console.WriteLine("Response output:");
                Console.WriteLine(reader.ReadToEnd());
                Console.WriteLine("Status code:{0}", response.StatusCode);


                // Close the resources no longer needed.
                response.Close();
                responseStream.Close();
                reader.Close();
                Console.ReadKey();
            }
            catch (WebException ex)
            {
                Console.Write(ex.Response.Headers.ToString());
                Console.Read();
            }

        }

        /// <summary>
        /// Add a windows server 2008 R2 virtual machine.
        /// Need to set the AddVirtualMachine.xml file first
        /// </summary>
        /// <returns></returns>
        static HttpWebRequest AddVirtualMachine()
        {
            //For more details about how to add virtual machine please refer to:
            //http://msdn.microsoft.com/en-us/library/windowsazure/jj157194.aspx
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri("https://management.core.windows.net/" + SubscriptionID
            + "/services/hostedservices/" + ServiceName + "/deployments" ));

            request.Method = "POST";
            request.ClientCertificates.Add(Certificate);
            request.ContentType = "application/xml";
            request.Headers.Add("x-ms-version", "2012-03-01");

            // Add body to the request
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("..\\..\\AddVirtualMachine.xml");

            Stream requestStream = request.GetRequestStream();
            StreamWriter streamWriter = new StreamWriter(requestStream, System.Text.UTF8Encoding.UTF8);
            xmlDoc.Save(streamWriter);

            streamWriter.Close();
            requestStream.Close();

            return request;

        }

        /// <summary>
        /// Get the virtual machine state by specific service name.
        /// </summary>
        /// <returns></returns>
        static HttpWebRequest GetVirtualMachineState()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri("https://management.core.windows.net/" + SubscriptionID
           + "/services/hostedservices/" + ServiceName + "/deploymentslots/Production"));

            request.Method = "GET";
            request.ClientCertificates.Add(Certificate);

            request.ContentType = "application/xml";
            request.Headers.Add("x-ms-version", "2012-03-01");

            return request;
        }

        /// <summary>
        /// Delete the virtual machine by specific service name. 
        /// </summary>
        /// <returns></returns>
        static HttpWebRequest DeleteVirtualMachine()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri("https://management.core.windows.net/" + SubscriptionID
           + "/services/hostedservices/" + ServiceName + "/deploymentslots/Production"));

            request.Method = "DELETE";
            request.ClientCertificates.Add(Certificate);

            request.ContentType = "application/xml";
            request.Headers.Add("x-ms-version", "2012-03-01");

            return request;
        }
    }
}
