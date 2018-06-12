'***************************** Module Header ******************************\
' Module Name: MainModule.vb
' Project:     VBAzureControlVM
' Copyright (c) Microsoft Corporation.
' 
' To operate widnows Azure Iaas virtual machine, using the azure power shell 
' isn't the only way. We also can use mangement service API to achieve this target.
' This sample will use GET/POST/DELETE requests to operate the virtual machine.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Security.Cryptography.X509Certificates
Imports System.Net
Imports System.IO
Imports System.Text
Module MainModule
    ' Must change before running
    Private Const VirtualMachineName As String = "{Unique VM Name}"
    Private Const SettingsFilePath As String = "{publish settings file path}"
    Private Const SubscriptionID As String = "{Subscription ID}"
    Private Const StorageAccountName As String = "{Storage account name}"

    ' Optional
    Private Const ImageFamilyName As String = "Windows Server 2012 Datacenter"
    Private Const DeploymentSlot As String = "Production"
    Private Const ComputerName As String = "TESTVM"
    Private Const AdminPassword As String = "Password1!"
    Private Const AdminUsername As String = "UserName"
    Private Const RoleSize As String = "Small"

    ' Needn't to change
    Private Const Location As String = "East Asia"
    Private ClientCertificate As X509Certificate2 = Nothing
    Private ns As XNamespace = "http://schemas.microsoft.com/windowsazure"
    Private Const ContentType As String = "application/xml"
    Private Const Version As String = "2013-11-01"
    Sub Main()
        ClientCertificate = getCertificateBySubscriptionID(SettingsFilePath, SubscriptionID)
        ' Because when created the Azure virtual machine, it always set cloud service name and deployment name equal to virtual
        ' machine name, so here use Virtual MahcineName instead of cloud service name and deployment name.
        CreateAzureVM(VirtualMachineName, Location, Nothing)

        ' GetAzureVMInformations(VirtualMachineName);
        ' DeleteAzureVM(VirtualMachineName);

        Console.ReadLine()
    End Sub

#Region "Create Azure Virtual Machine"
    Public Sub CreateAzureVM(vmName As String, Optional location As String = Nothing, Optional affinityGroup As String = Nothing)
        ' Step 1:Create Hosted Service
        Dim createHostedServiceResponse = createHostedService(vmName, location, affinityGroup)

        ' A successful operation returns status code 201 (Created).
        If CInt(createHostedServiceResponse.StatusCode) = 201 Then
            Console.WriteLine("Create cloud service success!")
            ' Step 2: Create Virtual Machin Deployment
            Dim createDeploymentResponse = createVMDeployment(vmName, vmName, vmName)
            If CInt(createDeploymentResponse.StatusCode) = 202 Then
                Console.WriteLine("Create VM successfully!")
            Else
                Console.WriteLine("Error:" & getErrorMessageFromResponse(createDeploymentResponse))
            End If
        Else
            Console.WriteLine("Error:" & getErrorMessageFromResponse(createHostedServiceResponse))
        End If
    End Sub

    Private Function createHostedService(serviceName As String, Optional location As String = Nothing, Optional affinityGroup As String = Nothing) As HttpWebResponse
        Dim locationOrAffinity As String = String.Empty
        Dim value As String = String.Empty


        If String.IsNullOrEmpty(location) = False Then
            locationOrAffinity = "Location"
            value = location
        Else
            locationOrAffinity = "AffinityGroup"
            value = affinityGroup
        End If

        Dim requestBody As New XDocument(New XElement(ns.ToString() & "CreateHostedService", New XElement(ns.ToString() & "ServiceName", serviceName), New XElement(ns.ToString() & "Label", convertToBase64(serviceName)), New XElement(ns.ToString() & locationOrAffinity, value)))

        Dim response = sendHttpReqeust("https://management.core.windows.net/" & SubscriptionID & "/services/hostedservices", "POST", ClientCertificate, ContentType, Version, requestBody)
        Return response
    End Function

    Private Function createVMDeployment(cloudServiceName As String, deploymentName As String, VMName As String) As HttpWebResponse
        Dim now = DateTime.UtcNow
        Dim dateString As String = Convert.ToString(now.Year) & "-" & Convert.ToString(now.Month) & "-" & Convert.ToString(now.Day) & Convert.ToString(now.Hour) & Convert.ToString(now.Minute) & Convert.ToString(now.Second) & Convert.ToString(now.Millisecond)

        Dim requestBody As New XDocument(New XElement(ns.ToString() & "Deployment", New XElement(ns.ToString() & "Name", deploymentName), New XElement(ns.ToString() & "DeploymentSlot", DeploymentSlot), New XElement(ns.ToString() & "Label", convertToBase64(deploymentName)), New XElement(ns.ToString() & "RoleList", New XElement(ns.ToString() & "Role", New XElement(ns.ToString() & "RoleName", VMName), New XElement(ns.ToString() & "RoleType", "PersistentVMRole"), New XElement(ns.ToString() & "ConfigurationSets", New XElement(ns.ToString() & "ConfigurationSet", New XElement(ns.ToString() & "ConfigurationSetType", "WindowsProvisioningConfiguration"), New XElement(ns.ToString() & "InputEndpoints", New XElement(ns.ToString() & "InputEndpoint", New XElement(ns.ToString() & "LocalPort", 3389), New XElement(ns.ToString() & "Name", "RDP"), New XElement(ns.ToString() & "Protocol", "tcp")), New XElement(ns.ToString() & "InputEndpoint", New XElement(ns.ToString() & "LocalPort", 80), New XElement(ns.ToString() & "Name", "web"), New XElement(ns.ToString() & "Port", 80), New XElement(ns.ToString() & "Protocol", "tcp"))), New XElement(ns.ToString() & "ComputerName", VMName), New XElement(ns.ToString() & "AdminPassword", AdminPassword), New XElement(ns.ToString() & "AdminUsername", AdminUsername))), New XElement(ns.ToString() & "Label", VMName), New XElement(ns.ToString() & "OSVirtualHardDisk", New XElement(ns.ToString() & "MediaLink", String.Format("http://{0}.blob.core.windows.net/vhds/{1}.vhd", StorageAccountName, dateString)), New XElement(ns.ToString() & "SourceImageName", getSourceImageNameByFamliyName(ImageFamilyName))), _
            New XElement(ns.ToString() & "RoleSize", RoleSize)))))

        Dim response = sendHttpReqeust(String.Format("https://management.core.windows.net/{0}/services/hostedservices/{1}/deployments", SubscriptionID, cloudServiceName), "POST", ClientCertificate, ContentType, Version, requestBody)

        Return response

    End Function

    Private Function convertToBase64(targetString As String) As String
        Dim ae As New System.Text.ASCIIEncoding()
        Dim svcNameBytes As Byte() = ae.GetBytes(targetString)
        Return Convert.ToBase64String(svcNameBytes)
    End Function

    Private Function getSourceImageNameByFamliyName(imageFamliyName As String) As String
        Dim imageName As String = Nothing
        Dim response = sendHttpReqeust(String.Format("https://management.core.windows.net/{0}/services/images", SubscriptionID), "GET", ClientCertificate, "application/xml", "2014-02-01", Nothing)
        Using responseStream As Stream = response.GetResponseStream()
            Using reader As New StreamReader(responseStream)
                Dim imagesXML = reader.ReadToEnd()
                imageName = XElement.Parse(imagesXML).Elements().Where(Function(o) o.Descendants(ns.ToString() & "ImageFamily").Count() > 0).Where(Function(o) o.Element(ns.ToString() & "ImageFamily").Value.ToString() = imageFamliyName).Last().Element(ns.ToString() & "Name").Value.ToString()
            End Using
        End Using
        Return imageName
    End Function
#End Region

#Region "Delete Azure Virtual Machine"
    Public Sub DeleteAzureVM(vmName As String)
        Console.WriteLine("Start to delete Azure VM, VM Name={0} this delete operation only works fine when there are multiple Virtual Machines in one VMDeployment", vmName)
        Dim response = deleteVM(vmName, vmName, vmName)
        If CInt(response.StatusCode) = 202 Then
            Console.WriteLine("Delete successfully!")
        Else
            Console.WriteLine("Error:" & getErrorMessageFromResponse(response))
        End If
    End Sub
    Private Function deleteVM(servicName As String, deploymentName As String, vmName As String) As HttpWebResponse
        Dim response = sendHttpReqeust(String.Format("https://management.core.windows.net/{0}/services/hostedservices/{1}/deployments/{2}/roles/{3}?comp=media", SubscriptionID, servicName, deploymentName, vmName), "DELETE", ClientCertificate, Nothing, Version, Nothing)
        Return response
    End Function
#End Region

#Region "Get Azure Vitrual Machine Informations"
    Public Sub GetAzureVMInformations(vmName As String)
        Console.WriteLine("Start to get VM {0}'s information", vmName)
        Dim response = getAzureVM(vmName, vmName, vmName)
        If CInt(response.StatusCode) = 200 Then
            Using responseStream As Stream = response.GetResponseStream()
                Using reader As New StreamReader(responseStream)
                    Dim imagesXML = reader.ReadToEnd()
                    Console.WriteLine(imagesXML)
                End Using
            End Using
        Else
            Console.WriteLine("Error:" & getErrorMessageFromResponse(response))
        End If
    End Sub
    Private Function getAzureVM(servicName As String, deploymentName As String, vmName As String) As HttpWebResponse
        Dim response = sendHttpReqeust(String.Format("https://management.core.windows.net/{0}/services/hostedservices/{1}/deployments/{2}/roles/{3}", SubscriptionID, servicName, deploymentName, vmName), "GET", ClientCertificate, ContentType, Version, Nothing)
        Return response
    End Function
#End Region

    Private Function sendHttpReqeust(uri As String, method As String, clientCer As X509Certificate2, ContentType As String, xmsVersion As String, Optional requestBody As XDocument = Nothing) As HttpWebResponse
        Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(New Uri(uri)), HttpWebRequest)
        request.Method = method

        request.ClientCertificates.Add(clientCer)
        If ContentType IsNot Nothing Then
            request.ContentType = ContentType
        End If

        request.Headers.Add("x-ms-version", xmsVersion)

        If requestBody IsNot Nothing Then
            Using requestStream As Stream = request.GetRequestStream()
                Using streamWriter As New StreamWriter(requestStream, System.Text.UTF8Encoding.UTF8)
                    requestBody.Save(streamWriter, SaveOptions.DisableFormatting)
                End Using
            End Using
        End If

        Dim response As HttpWebResponse
        Try
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            Return response
        Catch ex As WebException

            response = DirectCast(ex.Response, HttpWebResponse)

            Return response
        End Try
    End Function

    Private Function getCertificateBySubscriptionID(settingsFilePath As String, subscriptionID As String) As X509Certificate2
        Dim xElement__1 As XElement = XElement.Load(settingsFilePath)
        Dim subscriptionElements = xElement__1.Descendants("Subscription")
        Dim base64cer = subscriptionElements.Where(Function(e) e.Attribute("Id").Value.ToString() = subscriptionID).FirstOrDefault().Attribute("ManagementCertificate").Value.ToString()
        Return New X509Certificate2(Convert.FromBase64String(base64cer))
    End Function

    Private Function getErrorMessageFromResponse(exResponse As HttpWebResponse) As String
        Dim xDoc As XElement = Nothing
        Dim responseStream = TryCast(exResponse.GetResponseStream(), MemoryStream)
        If responseStream IsNot Nothing Then
            Dim responseBytes = responseStream.ToArray()
            Dim responseString = Encoding.UTF8.GetString(responseBytes)
            xDoc = XElement.Parse(responseString)
        End If
        Return xDoc.Element(ns.ToString() & "Message").Value.ToString()
    End Function

End Module
