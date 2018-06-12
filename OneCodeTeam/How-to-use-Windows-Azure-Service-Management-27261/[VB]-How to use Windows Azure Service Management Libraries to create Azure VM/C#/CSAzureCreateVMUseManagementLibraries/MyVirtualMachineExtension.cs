/****************************** Module Header ******************************\
* Module Name: MyVirtualMachineExtension.cs
* Project:     CSAzureCreateVMUseMangementLibaries
* Copyright (c) Microsoft Corporation.
* 
* We use this Enxtension class make the method similar to the REST API
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/


using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CSAzureCreateVMUseMangementLibaries
{
    public static class MyVirtualMachineExtension
    {
        /// <summary>
        /// Instantiate a new VM Role
        /// </summary>
        public static Role CreateVMRole(this IVirtualMachineOperations client, string cloudServiceName, string roleName, VirtualMachineRoleSize roleSize, string userName, string password, OSVirtualHardDisk osVHD)
        {
            Role vmRole = new Role
            {
                RoleType = VirtualMachineRoleType.PersistentVMRole.ToString(),
                RoleName = roleName,
                Label = roleName,
                RoleSize = roleSize,
                ConfigurationSets = new List<ConfigurationSet>(),
                OSVirtualHardDisk = osVHD
            };
            ConfigurationSet configSet = new ConfigurationSet
            {
                ConfigurationSetType = ConfigurationSetTypes.WindowsProvisioningConfiguration,
                EnableAutomaticUpdates = true,
                ResetPasswordOnFirstLogon = false,
                ComputerName = roleName,
                AdminUserName = userName,
                AdminPassword = password,
                InputEndpoints = new BindingList<InputEndpoint>
                {
                    new InputEndpoint { LocalPort = 3389, Name = "RDP", Protocol = "tcp" },
                    new InputEndpoint { LocalPort = 80, Port = 80, Name = "web", Protocol = "tcp" }
                }
            };
            vmRole.ConfigurationSets.Add(configSet);
            return vmRole;
        }

        public static OSVirtualHardDisk CreateOSVHD(this IVirtualMachineImageOperations operation, string cloudserviceName, string vmName, string storageAccount, string imageFamiliyName)
        {
            try
            {
                var osVHD = new OSVirtualHardDisk
                {
                    MediaLink = GetVhdUri(string.Format("{0}.blob.core.windows.net/vhds", storageAccount), cloudserviceName, vmName),
                    SourceImageName = GetSourceImageNameByFamliyName(operation, imageFamiliyName)
                };
                return osVHD;
            }
            catch (CloudException e)
            {

                throw;
            }

        }

        private static string GetSourceImageNameByFamliyName(this IVirtualMachineImageOperations operation, string imageFamliyName)
        {
            var disk = operation.List().Where(o => o.ImageFamily == imageFamliyName).FirstOrDefault();
            if (disk != null)
            {
                return disk.Name;
            }
            else
            {
                throw new CloudException(string.Format("Can't find {0} OS image in current subscription"));
            }
        }

        private static Uri GetVhdUri(string blobcontainerAddress, string cloudServiceName, string vmName, bool cacheDisk = false, bool https = false)
        {
            var now = DateTime.UtcNow;
            string dateString = now.Year + "-" + now.Month + "-" + now.Day;

            var address = string.Format("http{0}://{1}/{2}-{3}-{4}-{5}-650.vhd", https ? "s" : string.Empty, blobcontainerAddress, cloudServiceName, vmName, cacheDisk ? "-CacheDisk" : string.Empty, dateString);
            return new Uri(address);
        }

        public static void CreateVMDeployment(this IVirtualMachineOperations operations, string cloudServiceName, string deploymentName, List<Role> roleList, DeploymentSlot slot = DeploymentSlot.Production)
        {

            try
            {
                VirtualMachineCreateDeploymentParameters createDeploymentParams = new VirtualMachineCreateDeploymentParameters
                {

                    Name = deploymentName,
                    Label = cloudServiceName,
                    Roles = roleList,
                    DeploymentSlot = slot
                };
                operations.CreateDeployment(cloudServiceName, createDeploymentParams);
            }
            catch (CloudException e)
            {
                throw;
            }
        }
    }
}
