'***************************** Module Header ******************************\
' Module Name: Module1.vb
' Project:     VBAzureCreateVMUseMangementLibraries
' Copyright (c) Microsoft Corporation.
' 
' This sample shows how to create Azure Virtual Machine using Management Libraries
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports Microsoft.WindowsAzure.Management.Compute
Imports Microsoft.WindowsAzure
Imports System.Security.Cryptography.X509Certificates
Imports Microsoft.WindowsAzure.Management.Compute.Models

Module Module1
    'TODO: The following variables should be filled up with your information before you build and run the sample.
    Public Const base64EncodedCertificate As String = ""
    Public Const subscriptionId As String = ""

    Public vmName As String = ""
    Public location As String = ""

    Public storageAccountName As String = ""
    Public userName As String = ""

    Public password As String = ""
    Public imageFamiliyName As String = "Windows Server 2012 Datacenter"

    Sub Main()
        Dim client As New ComputeManagementClient(getCredentials())
        'You need a hosted service to host VM.
        Try
            Dim hostedService = client.HostedServices.Get(vmName)
        Catch ex As CloudException
            createCloudServiceByLocation(vmName, location)
            Console.Write("Create CloudService First")
        End Try
        

        Dim OSVHD = client.VirtualMachineImages.CreateOSVHD(vmName, vmName, storageAccountName, imageFamiliyName)
        Dim VMROle = client.VirtualMachines.CreateVMRole(vmName, vmName, VirtualMachineRoleSize.Small, userName, password, OSVHD)
        Dim roleList As New List(Of Role)() From { _
            VMROle _
        }
        client.VirtualMachines.CreateVMDeployment(vmName, vmName, roleList)
        Console.WriteLine("Create VM successfully")

        Console.ReadLine()
    End Sub

    Public Sub createCloudServiceByLocation(cloudServiceName As String, location As String)
        Dim client As New ComputeManagementClient(getCredentials())
        Dim hostedServiceCreateParams As New HostedServiceCreateParameters() With { _
             .ServiceName = cloudServiceName, _
             .Location = location, _
             .Label = EncodeToBase64(cloudServiceName) _
        }
        Try
            client.HostedServices.Create(hostedServiceCreateParams)
        Catch e As CloudException
            Throw
        End Try

    End Sub

    Public Sub createCloudServiceByAffinityGroup(cloudServiceName As String, affinityGroupName As String)
        Dim client As New ComputeManagementClient(getCredentials())
        Dim hostedServiceCreateParams As New HostedServiceCreateParameters() With { _
             .ServiceName = cloudServiceName, _
             .AffinityGroup = affinityGroupName, _
             .Label = EncodeToBase64(cloudServiceName) _
        }
        Try
            client.HostedServices.Create(hostedServiceCreateParams)
        Catch e As CloudException
            Throw
        End Try

    End Sub

    Public Function EncodeToBase64(toEncode As String) As String
        Dim toEncodeAsBytes As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode)
        Dim returnValue As String = System.Convert.ToBase64String(toEncodeAsBytes)
        Return returnValue
    End Function

    Public Function getCredentials() As SubscriptionCloudCredentials
        Return New CertificateCloudCredentials(subscriptionId, New X509Certificate2(Convert.FromBase64String(base64EncodedCertificate)))
    End Function
End Module
