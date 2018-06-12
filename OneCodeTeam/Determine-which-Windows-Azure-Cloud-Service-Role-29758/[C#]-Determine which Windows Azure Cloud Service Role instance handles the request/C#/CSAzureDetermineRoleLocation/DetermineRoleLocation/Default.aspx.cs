/***************************** Module Header ******************************\
* Module Name:	Default.aspx.cs
* Project:		CSAzureDetermineRoleLocation
* Copyright (c) Microsoft Corporation.
* 
* This sample demonstrates how to determine which role instance handles the request.
*
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\**************************************************************************/
using Microsoft.WindowsAzure.ServiceRuntime;
using System;
using System.Linq;
using Microsoft.WindowsAzure;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace DetermineRoleLocation
{
    public partial class Default : System.Web.UI.Page
    {
        //You can store your cloudServiceName in Azure Table storage, and get the value dynamically.
        public static string[] cloudServiceNames = new string[3] { "testcloud", "testcloud1", "testcloud2" };
        public static string subscriptionId = CloudConfigurationManager.GetSetting("subscriptionId");
        public static string base64EncodedCertificate = CloudConfigurationManager.GetSetting("base64EncodedCertificate");
        protected void Page_Load(object sender, EventArgs e)
        {
            var hostedServiceDetails = getCloudServiceDetailsByDeploymentId();
            if (hostedServiceDetails!=null)
            {
                lbRoleName.Text = RoleEnvironment.CurrentRoleInstance.Id;
                var deployment = hostedServiceDetails.Deployments.Where(dep => dep.PrivateId == RoleEnvironment.DeploymentId).FirstOrDefault();
                lbDeploymentName.Text = deployment.Label;
                lbHostServiceName.Text = hostedServiceDetails.ServiceName;
                lbRegionOrGroup.Text = 
                    hostedServiceDetails.Properties.AffinityGroup == null ? hostedServiceDetails.Properties.Location : hostedServiceDetails.Properties.AffinityGroup;
                lbslot.Text = deployment.DeploymentSlot.ToString();
            }
            else
            {
                Response.Write("can't find this VM in current subscription");
            }
        }

        static HostedServiceGetDetailedResponse getCloudServiceDetailsByDeploymentId()
        {
            var managementClient = new ComputeManagementClient(getCredentials());
            var currentDeployment = new HostedServiceGetDetailedResponse.Deployment();
            foreach (var serviceName in cloudServiceNames)
            {
                var hostedServiceDetails = managementClient.HostedServices.GetDetailed(serviceName);
                foreach (var deployment in hostedServiceDetails.Deployments)
                {
                    if (deployment.PrivateId == RoleEnvironment.DeploymentId)
                    {
                        return hostedServiceDetails;
                    }
                }              
            }
            return null;
        }

        static SubscriptionCloudCredentials getCredentials()
        {
            return new CertificateCloudCredentials(subscriptionId, new X509Certificate2(Convert.FromBase64String(base64EncodedCertificate)));
        }
    }
}