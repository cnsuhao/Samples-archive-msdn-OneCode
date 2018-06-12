/***************************** Module Header ******************************\
* Module Name:	CSAzureAddCNameProgrammatically.cs
* Project:		CSAzureAddCNameProgrammatically
* Copyright (c) Microsoft Corporation.
* 
* This sample shows how to add/delete CName to Azure Website programmatically.
*
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\**************************************************************************/

using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management.WebSites;
using Microsoft.WindowsAzure.Management.WebSites.Models;
using System;
using System.Security.Cryptography.X509Certificates;

namespace CSAzureAddCNameProgrammatically
{
    class Program
    {
        public const string base64EncodedCertificate = "{Your-sertificate-base64string}";
        public const string subscriptionId = "{Your-subscription-id}";
        public static string websiteName = "{Your-web-site-name}";
        public static string subDomainName = "{sub-domain-name}";

        static void Main(string[] args)
        {
            AddDomainName(WebSpaceNames.WestEuropeWebSpace,"onecode","www.onecode.com");
            //DeleteDomainName(WebSpaceNames.WestEuropeWebSpace, "onecode", "www.onecode.com");    
            Console.ReadLine();
        }

        static SubscriptionCloudCredentials getCredentials()
        {
            return new CertificateCloudCredentials(subscriptionId, new X509Certificate2(Convert.FromBase64String(base64EncodedCertificate)));
        }

        static void AddDomainName(string webspaceName,string websiteName,string subDomainName)
        {
            try
            {
                WebSiteManagementClient client = new WebSiteManagementClient(getCredentials());

                var website = client.WebSites.Get(webspaceName, websiteName, new Microsoft.WindowsAzure.Management.WebSites.Models.WebSiteGetParameters());
                website.WebSite.HostNames.Add(subDomainName);
               
                var parm = new WebSiteUpdateParameters();
                parm.HostNames = website.WebSite.HostNames;
                client.WebSites.Update(webspaceName, websiteName, parm);
                Console.WriteLine("Add CName: {0} to {1} successfully!",subDomainName,websiteName);
            }
            catch (WebSiteCloudException exception)
            {
                Console.WriteLine(exception.ErrorMessage); 
            }
        }

        static void DeleteDomainName(string webspaceName, string websiteName, string subDomainName)
        {
            try
            {
                WebSiteManagementClient client = new WebSiteManagementClient(getCredentials());

                var website = client.WebSites.Get(webspaceName, websiteName, new Microsoft.WindowsAzure.Management.WebSites.Models.WebSiteGetParameters());
                website.WebSite.HostNames.Remove(subDomainName);
               
                var parm = new WebSiteUpdateParameters();
                parm.HostNames = website.WebSite.HostNames;
                client.WebSites.Update(webspaceName, websiteName, parm);
                Console.WriteLine("Delete CName: {0} from {1} successfully!", subDomainName, websiteName);
            }
            catch (WebSiteCloudException exception)
            {

                Console.WriteLine(exception.ErrorMessage);
            }
        }
    }
}
