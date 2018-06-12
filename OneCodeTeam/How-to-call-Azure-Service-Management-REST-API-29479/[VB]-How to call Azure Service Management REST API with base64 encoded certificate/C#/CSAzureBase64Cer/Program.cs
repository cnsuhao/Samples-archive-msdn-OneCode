/****************************** Module Header ******************************\
* Module Name: Program.cs
* Project:     CSAzureBase64Cer
* Copyright (c) Microsoft Corporation.
* 
* Managing Azure in Role instance may be difficult, because it requires a client 
* certificate. This sample will show how to use the base64 string certificate 
* instead of getting the certificate from Certificates store
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
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure;
using System.Net;
using System.IO;



namespace CSAzureBase64Cer
{
    class Program
    {
        static void Main(string[] args)
        {
            string credentialsPath = @"<Credentials File path>";
            string subscriptionId = "<Subscription Id>";

            XElement x=XElement.Load(credentialsPath);

            var Base64cer = (from c in x.Descendants("Subscription")
                                where c.Attribute("Id").Value == subscriptionId
                                select (string)c.Attribute("ManagementCertificate").Value).FirstOrDefault();

            X509Certificate2 cer = null;
            if (Base64cer != null)
            {
                cer = new X509Certificate2(Convert.FromBase64String(Base64cer));
            }
            if (cer != null)
            {
                //GetHostedServicesByManagementAPI(new CertificateCloudCredentials(subscriptionId, cer));
                GetHostedServicesByRESTAPI(subscriptionId, cer);
            }
            Console.ReadLine();        
        }

        static void GetHostedServicesByManagementAPI(CertificateCloudCredentials cer)
        {
            try
            {
                 ComputeManagementClient client = new ComputeManagementClient(cer);
                var hostedServicesList = client.HostedServices.List();
                foreach (var item in hostedServicesList)
                {
                    Console.WriteLine(item.ServiceName);
                }
                Console.WriteLine();
            }
            catch (CloudException e)
            {
                // Handle the exception here
                throw;
            }
        }

        static void GetHostedServicesByManagementAPI(string subscriptionId,X509Certificate2 certificate)
        {
            GetHostedServicesByManagementAPI(new CertificateCloudCredentials(subscriptionId,certificate));
        }

        static void GetHostedServicesByRESTAPI(string subscriptionId, X509Certificate2 certificate)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri("https://management.core.windows.net/" + subscriptionId + "/services/hostedservices"));

            request.Method = "GET";
            request.ClientCertificates.Add(certificate);
            request.ContentType = "application/xml";
            request.Headers.Add("x-ms-version", "2012-03-01");

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                // Parse the web response.
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                string xml = reader.ReadToEnd();                
                XDocument doc = XDocument.Parse(xml);
                XNamespace ns = doc.Root.Name.Namespace;
                var hostedServicesName = from item in doc.Descendants(ns + "ServiceName")
                                         select item;
                foreach (var name in hostedServicesName)
                {
                    Console.WriteLine(name.Value);
                }

                // Close the no longer needed resources.
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
    }
}
