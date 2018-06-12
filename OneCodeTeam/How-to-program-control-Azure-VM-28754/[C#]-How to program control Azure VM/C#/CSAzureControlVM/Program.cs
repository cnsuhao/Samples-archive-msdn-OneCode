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
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

namespace CSAzureControlVM
{
    class Program
    {
        // Must change before running
        private const string VirtualMachineName = "{Unique VM Name}";
        private const string SettingsFilePath = @"{publish settings file path}";
        private const string SubscriptionID = "{Subscription ID}";
        private const string StorageAccountName = "{Storage account name}";

        // Optional
        private const string ImageFamilyName = "Windows Server 2012 Datacenter";
        private const string DeploymentSlot = "Production";
        private const string ComputerName = "TESTVM";
        private const string AdminPassword = "Password1!";
        private const string AdminUsername = "UserName";
        private const string RoleSize = "Small";

        // Needn't to change
        private const string Location = "East Asia";
        private static X509Certificate2 ClientCertificate = null;
        private static XNamespace ns = "http://schemas.microsoft.com/windowsazure";
        private const string ContentType = "application/xml";
        private const string Version = "2013-11-01";

        static void Main(string[] args)
        {
            ClientCertificate = getCertificateBySubscriptionID(SettingsFilePath, SubscriptionID);

            // Because when created the Azure virtual machine, it always set cloud service name and deployment name equal to virtual
            // machine name, so here use Virtual MahcineName instead of cloud service name and deployment name.
            CreateAzureVM(VirtualMachineName, Location, null);

            // GetAzureVMInformations(VirtualMachineName);
            // DeleteAzureVM(VirtualMachineName);

            Console.ReadLine();
        }
        #region Create Azure Virtual Machine
        public static void CreateAzureVM(string vmName, string location = null, string affinityGroup = null)
        {
            // Step 1:Create Hosted Service
            var createHostedServiceResponse=createHostedService(vmName,location,affinityGroup);

            // A successful operation returns status code 201 (Created).
            if ((int)createHostedServiceResponse.StatusCode == 201)
            {
                Console.WriteLine("Create cloud service success!");
            // Step 2: Create Virtual Machin Deployment
                var createDeploymentResponse = createVMDeployment(vmName, vmName, vmName);
                if ((int)createDeploymentResponse.StatusCode==202)
                {
                    Console.WriteLine("Create VM successfully!");
                }
                else
                {
                    Console.WriteLine("Error:" + getErrorMessageFromResponse(createDeploymentResponse));
                }
            }
            else
            {
                Console.WriteLine("Error:"+getErrorMessageFromResponse(createHostedServiceResponse));
            }
        }

        private static HttpWebResponse createHostedService(string serviceName, string location = null, string affinityGroup = null)
        {
            string locationOrAffinity = string.Empty;
            string value = string.Empty;


            if (string.IsNullOrEmpty(location) == false)
            {
                locationOrAffinity = "Location";
                value = location;
            }
            else
            {
                locationOrAffinity = "AffinityGroup";
                value = affinityGroup;
            }

            XDocument requestBody = new XDocument(
                new XElement(ns + "CreateHostedService",
                new XElement(ns + "ServiceName", serviceName),
                new XElement(ns + "Label", convertToBase64(serviceName)),
                new XElement(ns + locationOrAffinity, value))
                   );

            var response = sendHttpReqeust(
               "https://management.core.windows.net/" + SubscriptionID + "/services/hostedservices",
               "POST",
               ClientCertificate,
               ContentType,
               Version,
               requestBody
               );
            return response;
        }

        private static HttpWebResponse createVMDeployment(string cloudServiceName, string deploymentName, string VMName)
        {
            var now = DateTime.UtcNow;
            string dateString = now.Year + "-" + now.Month + "-" + now.Day + now.Hour + now.Minute + now.Second + now.Millisecond;

            XDocument requestBody = new XDocument(
               new XElement(ns + "Deployment",
          new XElement(ns + "Name", deploymentName),
          new XElement(ns + "DeploymentSlot", DeploymentSlot),
          new XElement(ns + "Label", convertToBase64(deploymentName)),
          new XElement(ns + "RoleList",
            new XElement(ns + "Role",
              new XElement(ns + "RoleName", VMName),
              new XElement(ns + "RoleType", "PersistentVMRole"),
              new XElement(ns + "ConfigurationSets",
                new XElement(ns + "ConfigurationSet",
                  new XElement(ns + "ConfigurationSetType", "WindowsProvisioningConfiguration"),
                  new XElement(ns + "InputEndpoints",
                      new XElement(ns + "InputEndpoint",
                          new XElement(ns + "LocalPort", 3389),
                          new XElement(ns + "Name", "RDP"),
                          new XElement(ns + "Protocol", "tcp")),
                       new XElement(ns + "InputEndpoint",
                          new XElement(ns + "LocalPort", 80),
                          new XElement(ns + "Name", "web"),
                          new XElement(ns + "Port", 80),
                          new XElement(ns + "Protocol", "tcp"))),
                  new XElement(ns + "ComputerName", VMName),
                  new XElement(ns + "AdminPassword", AdminPassword),
                  new XElement(ns + "AdminUsername", AdminUsername))),
              new XElement(ns + "Label", VMName),
              new XElement(ns + "OSVirtualHardDisk",
                new XElement(ns + "MediaLink", string.Format("http://{0}.blob.core.windows.net/vhds/{1}.vhd", StorageAccountName, dateString)),
                new XElement(ns + "SourceImageName", getSourceImageNameByFamliyName(ImageFamilyName))),
              new XElement(ns + "RoleSize", RoleSize)
                ))));

            var response = sendHttpReqeust(
                string.Format("https://management.core.windows.net/{0}/services/hostedservices/{1}/deployments", SubscriptionID, cloudServiceName),
                "POST",
                ClientCertificate,
                ContentType,
                Version,
                requestBody);

            return response;

        }

        private static string convertToBase64(string targetString)
        {
            System.Text.ASCIIEncoding ae = new System.Text.ASCIIEncoding();
            byte[] svcNameBytes = ae.GetBytes(targetString);
            return Convert.ToBase64String(svcNameBytes);
        }

        private static string getSourceImageNameByFamliyName(string imageFamliyName)
        {
            string imageName = null;
            var response = sendHttpReqeust(
                string.Format("https://management.core.windows.net/{0}/services/images", SubscriptionID),
                "GET",
                ClientCertificate,
                 "application/xml",
                 "2014-02-01",
                 null
                );
            using (Stream responseStream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    var imagesXML = reader.ReadToEnd();
                    imageName = XElement.Parse(imagesXML).Elements()
                       .Where(o => o.Descendants(ns + "ImageFamily").Count() > 0)
                       .Where(o => o.Element(ns + "ImageFamily").Value.ToString() == imageFamliyName)
                       .Last().Element(ns + "Name")
                       .Value.ToString();
                }
            }
            return imageName;
        }
        #endregion

        #region Delete Azure Virtual Machine
        public static void DeleteAzureVM(string vmName)
        {
            Console.WriteLine("Start to delete Azure VM, VM Name={0} this delete operation only works fine when there are multiple Virtual Machines in one VMDeployment",vmName);
            var response = deleteVM(vmName, vmName, vmName);
            if ((int)response.StatusCode==202)
            {
                Console.WriteLine("Delete successfully!");
            }
            else
            {
                Console.WriteLine("Error:" + getErrorMessageFromResponse(response));
            }
        }
        private static HttpWebResponse deleteVM(string servicName, string deploymentName, string vmName)
        {
            var response = sendHttpReqeust(string.Format("https://management.core.windows.net/{0}/services/hostedservices/{1}/deployments/{2}/roles/{3}?comp=media", SubscriptionID, servicName, deploymentName, vmName),
                "DELETE",
                ClientCertificate,
                null,
                Version,
                null);
            return response;
        }
        #endregion

        #region Get Azure Vitrual Machine Informations
        public static void GetAzureVMInformations(string vmName)
        {
            Console.WriteLine("Start to get VM {0}'s informations",vmName);
            var response = getAzureVM(vmName, vmName, vmName);
            if ((int)response.StatusCode==200)
            {
                  using (Stream responseStream=response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                var imagesXML = reader.ReadToEnd();
                                Console.WriteLine(imagesXML);
                            }
                        }
            }
            else
            {
                Console.WriteLine("Error:" + getErrorMessageFromResponse(response));
            }
        }
        private static HttpWebResponse getAzureVM(string servicName, string deploymentName, string vmName)
        {
            var response = sendHttpReqeust(string.Format("https://management.core.windows.net/{0}/services/hostedservices/{1}/deployments/{2}/roles/{3}", SubscriptionID, servicName, deploymentName, vmName),
                "GET",
                ClientCertificate,
                ContentType,
                Version,
                null);
            return response;
        }
        #endregion

        private static HttpWebResponse sendHttpReqeust(string uri, string method, X509Certificate2 clientCer, string ContentType, string xmsVersion, XDocument requestBody = null)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(uri));
            request.Method = method;

            request.ClientCertificates.Add(clientCer);
            if (ContentType!=null)
            {
                request.ContentType = ContentType;
            }
            
            request.Headers.Add("x-ms-version",xmsVersion);

            if (requestBody !=null)
            {
                using (Stream requestStream = request.GetRequestStream())
                {
                    using (StreamWriter streamWriter = new StreamWriter(
                        requestStream, System.Text.UTF8Encoding.UTF8))
                    {
                        requestBody.Save(streamWriter, SaveOptions.DisableFormatting);
                    }
                } 
            }

            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                return response;
            }
            catch (WebException ex)
            {
                
                response = (HttpWebResponse)ex.Response;
                
                return response;
            }
        }

        private static X509Certificate2 getCertificateBySubscriptionID(string settingsFilePath, string subscriptionID)
        {
            XElement xElement = XElement.Load(settingsFilePath);
            var subscriptionElements = xElement.Descendants("Subscription");
            var base64cer = subscriptionElements
                .Where(e => e.Attribute("Id").Value.ToString() == subscriptionID)
                .FirstOrDefault()
                .Attribute("ManagementCertificate").Value.ToString();
            return new X509Certificate2(Convert.FromBase64String(base64cer));
        }

        private static string getErrorMessageFromResponse(HttpWebResponse exResponse)
        {
            XElement xDoc = null;
            var responseStream = exResponse.GetResponseStream() as MemoryStream;
            if (responseStream != null)
            {
                var responseBytes = responseStream.ToArray();
                var responseString = Encoding.UTF8.GetString(responseBytes);
                xDoc = XElement.Parse(responseString);
            }
            return xDoc.Element(ns + "Message").Value.ToString(); 
        }
    }
}
