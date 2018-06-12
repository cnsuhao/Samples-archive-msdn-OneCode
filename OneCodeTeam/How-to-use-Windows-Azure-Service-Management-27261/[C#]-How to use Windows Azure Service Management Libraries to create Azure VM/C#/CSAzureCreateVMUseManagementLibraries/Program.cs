/****************************** Module Header ******************************\
* Module Name: Program.cs
* Project:     CSAzureCreateVMUseMangementLibaries
* Copyright (c) Microsoft Corporation.
* 
* This sample shows how to create Azure Virtual Machine using Management Libraries
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
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure;
using System.Security.Cryptography.X509Certificates;

namespace CSAzureCreateVMUseMangementLibaries
{
    class Program
    {
        // TODO: The following variables should be filled up with your information before you build and run the sample.
        public const string base64EncodedCertificate = "";
        public const string subscriptionId = "";

        public static string vmName = "";
        public static string location = "";
        public static string storageAccountName = "";
        public static string userName = "";
        public static string password = "";

        public static string imageFamiliyName = "Windows Server 2012 Datacenter";

        
        static void Main(string[] args)
        {
            ComputeManagementClient client = new ComputeManagementClient(getCredentials());
            
            // You need a hosted service to host VM.
            if (client.HostedServices.Get(vmName) == null)
            {
                createCloudServiceByLocation(vmName, location);
            }

            var OSVHD = client.VirtualMachineImages.CreateOSVHD(vmName, vmName, storageAccountName, imageFamiliyName);
            var VMROle = client.VirtualMachines.CreateVMRole(vmName, vmName, VirtualMachineRoleSize.Small, userName, password, OSVHD);
            List<Role> roleList = new List<Role>{
                VMROle
            };
            client.VirtualMachines.CreateVMDeployment(vmName, vmName, roleList);
            Console.WriteLine("Create VM successfully");

            Console.ReadLine();
        }

        public static void createCloudServiceByLocation(string cloudServiceName, string location)
        {
            ComputeManagementClient client = new ComputeManagementClient(getCredentials());
            HostedServiceCreateParameters hostedServiceCreateParams = new HostedServiceCreateParameters
            {
                ServiceName = cloudServiceName,
                Location = location,
                Label = EncodeToBase64(cloudServiceName),
            };
            try
            {
                client.HostedServices.Create(hostedServiceCreateParams);
            }
            catch (CloudException e)
            {
                throw;
            }

        }


        public static void createCloudServiceByAffinityGroup(string cloudServiceName, string affinityGroupName)
        {
            ComputeManagementClient client = new ComputeManagementClient(getCredentials());
            HostedServiceCreateParameters hostedServiceCreateParams = new HostedServiceCreateParameters
            {
                ServiceName = cloudServiceName,
                AffinityGroup = affinityGroupName,
                Label = EncodeToBase64(cloudServiceName),
            };
            try
            {
                client.HostedServices.Create(hostedServiceCreateParams);
            }
            catch (CloudException e)
            {
                throw;
            }

        }
        public static string EncodeToBase64(string toEncode)
        {
            byte[] toEncodeAsBytes
            = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue
                  = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        public static SubscriptionCloudCredentials getCredentials()
        {
            return new CertificateCloudCredentials(subscriptionId, new X509Certificate2(Convert.FromBase64String(base64EncodedCertificate)));
        }

    }
}
