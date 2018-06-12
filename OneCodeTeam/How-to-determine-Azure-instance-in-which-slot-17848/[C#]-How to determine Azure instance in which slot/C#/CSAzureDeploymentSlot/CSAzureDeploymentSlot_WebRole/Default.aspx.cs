/****************************** Module Header ******************************\
Module Name:  Default.aspx.cs
Project:      CSAzureDeploymentSlot
Copyright (c) Microsoft Corporation.
 
This page is used to retrieve Deployment ID of Staging and Production state role,
then compare with RoleEnvironment.DeploymentID properties.

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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using Microsoft.WindowsAzure.ServiceRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;


namespace CSAzureDeploymentSlot_WebRole
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // You basic information of the Deployment of Azure application.
            string deploymentId = RoleEnvironment.DeploymentId;
            string subscriptionID = "<Your subscription ID>";
            string thrumbnail = "<Your certificate thumbnail print>";
            string hostedServiceName = "<Your hosted service name>";
            string productionString = string.Format("https://management.core.windows.net/{0}/services/hostedservices/{1}/deploymentslots/{2}", subscriptionID, hostedServiceName, "Production");
            Uri requestUri = new Uri(productionString);

            // Add client certificate.
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.OpenExistingOnly);
            X509Certificate2Collection collection = store.Certificates.Find(X509FindType.FindByThumbprint, thrumbnail, false);
            store.Close();

            if (collection.Count != 0)
            {
                X509Certificate2 certificate = collection[0];
                HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create(requestUri);
                httpRequest.ClientCertificates.Add(certificate);
                httpRequest.Headers.Add("x-ms-version", "2011-10-01");
                httpRequest.KeepAlive = false;
                HttpWebResponse httpResponse = httpRequest.GetResponse() as HttpWebResponse;

                // Get response stream from Management API.
                Stream stream = httpResponse.GetResponseStream();
                string result = string.Empty;
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();

                }
                if (result == null || result.Trim() == string.Empty)
                {
                    return;
                }

                XDocument document = XDocument.Parse(result);
                string serverID = string.Empty;
                var list = from item in document.Descendants(XName.Get("PrivateID", "http://schemas.microsoft.com/windowsazure"))
                           select item;
                
                serverID = list.First().Value;
                Response.Write("Check Production: <br />");
                Response.Write("DeploymentID : " + deploymentId + "<br> ServerID :" + serverID);
                if (deploymentId.Equals(serverID))
                    lbStatus.Text = "Production";
                else
                {
                    // If the application not in Production slot, try to check Staging slot.
                    string stagingString = string.Format("https://management.core.windows.net/{0}/services/hostedservices/{1}/deploymentslots/{2}", subscriptionID, hostedServiceName, "Staging");
                    Uri stagingUri = new Uri(stagingString);
                    httpRequest = (HttpWebRequest)HttpWebRequest.Create(stagingUri);
                    httpRequest.ClientCertificates.Add(certificate);
                    httpRequest.Headers.Add("x-ms-version", "2011-10-01");
                    httpRequest.KeepAlive = false;
                    httpResponse = httpRequest.GetResponse() as HttpWebResponse;
                    stream = httpResponse.GetResponseStream();
                    result = string.Empty;
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        result = reader.ReadToEnd();

                    }
                    if (result == null || result.Trim() == string.Empty)
                    {
                        return;
                    }

                    document = XDocument.Parse(result);
                    serverID = string.Empty;
                    list = from item in document.Descendants(XName.Get("PrivateID", "http://schemas.microsoft.com/windowsazure"))
                               select item;

                    serverID = list.First().Value;
                    Response.Write("<br /> Check Staging:");
                    Response.Write("<br /> DeploymentID : " + deploymentId + "<br> ServerID :" + serverID);
                    if (deploymentId.Equals(serverID))
                    {
                        lbStatus.Text = "Staging";
                    }
                    else
                    {
                        lbStatus.Text = "Do not find this id";
                    }
                }
                httpResponse.Close();
                stream.Close();
            }
        }
    }
}