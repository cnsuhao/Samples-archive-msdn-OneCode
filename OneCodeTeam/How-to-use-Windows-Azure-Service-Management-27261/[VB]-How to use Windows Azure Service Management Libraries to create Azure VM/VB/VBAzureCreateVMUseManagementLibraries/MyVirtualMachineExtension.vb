'***************************** Module Header ******************************\
' Module Name: MyVirtualMachineExtension.vb
' Project:     VBAzureCreateVMUseMangementLibraries
' Copyright (c) Microsoft Corporation.
' 
' We use this Enxtension class to make these methods similar to the REST API.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.Management.Compute
Imports Microsoft.WindowsAzure.Management.Compute.Models
Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Module MyVirtualMachineExtension
    ''' <summary>
    ''' Instantiation a new VM Role
    ''' </summary>
    <Extension()>
    Public Function CreateVMRole(client As IVirtualMachineOperations, cloudServiceName As String, roleName As String, roleSize As VirtualMachineRoleSize, userName As String, password As String, _
        osVHD As OSVirtualHardDisk) As Role
        Dim vmRole As New Role() With { _
             .RoleType = VirtualMachineRoleType.PersistentVMRole.ToString(), _
             .RoleName = roleName, _
             .Label = roleName, _
             .RoleSize = roleSize, _
             .ConfigurationSets = New List(Of ConfigurationSet)(), _
             .OSVirtualHardDisk = osVHD _
        }
        Dim configSet As New ConfigurationSet() With { _
             .ConfigurationSetType = ConfigurationSetTypes.WindowsProvisioningConfiguration, _
             .EnableAutomaticUpdates = True, _
             .ResetPasswordOnFirstLogon = False, _
             .ComputerName = roleName, _
             .AdminUserName = userName, _
             .AdminPassword = password, _
             .InputEndpoints = New BindingList(Of InputEndpoint)() From { _
                New InputEndpoint() With { _
                     .LocalPort = 3389, _
                     .Name = "RDP", _
                     .Protocol = "tcp" _
                }, _
                New InputEndpoint() With { _
                     .LocalPort = 80, _
                     .Port = 80, _
                     .Name = "web", _
                     .Protocol = "tcp" _
                } _
            } _
        }
        vmRole.ConfigurationSets.Add(configSet)
        Return vmRole
    End Function

    <Extension()>
    Public Function CreateOSVHD(operation As IVirtualMachineImageOperations, cloudserviceName As String, vmName As String, storageAccount As String, imageFamiliyName As String) As OSVirtualHardDisk
        Try
            Dim osVHD = New OSVirtualHardDisk() With { _
                 .MediaLink = GetVhdUri(String.Format("{0}.blob.core.windows.net/vhds", storageAccount), cloudserviceName, vmName), _
                 .SourceImageName = GetSourceImageNameByFamliyName(operation, imageFamiliyName) _
            }
            Return osVHD
        Catch e As CloudException

            Throw
        End Try

    End Function

    <Extension()>
    Private Function GetSourceImageNameByFamliyName(operation As IVirtualMachineImageOperations, imageFamliyName As String) As String
        Dim disk = operation.List().Where(Function(o) o.ImageFamily = imageFamliyName).FirstOrDefault()
        If disk IsNot Nothing Then
            Return disk.Name
        Else
            Throw New CloudException(String.Format("Can't find {0} OS image in current subscription"))
        End If
    End Function

    <Extension()>
    Private Function GetVhdUri(blobcontainerAddress As String, cloudServiceName As String, vmName As String, Optional cacheDisk As Boolean = False, Optional https As Boolean = False) As Uri
        Dim now = DateTime.UtcNow
        Dim dateString As String = Convert.ToString(now.Year) & "-" & Convert.ToString(now.Month) & "-" & Convert.ToString(now.Day)

        Dim address = String.Format("http{0}://{1}/{2}-{3}-{4}-{5}-650.vhd", If(https, "s", String.Empty), blobcontainerAddress, cloudServiceName, vmName, If(cacheDisk, "-CacheDisk", String.Empty), _
            dateString)
        Return New Uri(address)
    End Function

    <Extension()>
    Public Sub CreateVMDeployment(operations As IVirtualMachineOperations, cloudServiceName As String, deploymentName As String, roleList As List(Of Role), Optional slot As DeploymentSlot = DeploymentSlot.Production)
        Try
            Dim createDeploymentParams As New VirtualMachineCreateDeploymentParameters() With { _
                .Name = deploymentName, _
                 .Label = cloudServiceName, _
                 .Roles = roleList, _
                 .DeploymentSlot = slot _
            }
            operations.CreateDeployment(cloudServiceName, createDeploymentParams)
        Catch e As CloudException
            Throw
        End Try
    End Sub
End Module
