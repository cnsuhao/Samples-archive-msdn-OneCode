'**************************** Module Header ******************************\
' Module Name:	Default.aspx.vb
' Project:		VBAzureDetermineRoleLocation
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to determine which role instance handles the request.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************/
Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.ServiceRuntime
Imports Microsoft.WindowsAzure.WebSitesExtensions.Models
Imports Microsoft.WindowsAzure.Management.Compute
Imports System.Security.Cryptography.X509Certificates
Imports Microsoft.WindowsAzure.Management.Compute.Models


Public Class _Default
    Inherits System.Web.UI.Page

    'You can store your cloudServiceName in Azure Table storage, and get the value dynamically.
    Public Shared cloudServiceNames As String() = New String(2) {"testcloud", "testcloud1", "testcloud2"}
    Public Shared subscriptionId As String = CloudConfigurationManager.GetSetting("subscriptionId")
    Public Shared base64EncodedCertificate As String = CloudConfigurationManager.GetSetting("base64EncodedCertificate")
    Protected Sub Page_Load(sender As Object, e As EventArgs)
        Dim hostedServiceDetails = getCloudServiceDetailsByDeploymentId()
        If hostedServiceDetails IsNot Nothing Then
            lbRoleName.Text = RoleEnvironment.CurrentRoleInstance.Id
            Dim deployment = hostedServiceDetails.Deployments.Where(Function(dep) dep.PrivateId = RoleEnvironment.DeploymentId).FirstOrDefault()
            lbDeploymentName.Text = deployment.Label
            lbHostServiceName.Text = hostedServiceDetails.ServiceName
            lbRegionOrGroup.Text = If(hostedServiceDetails.Properties.AffinityGroup Is Nothing, hostedServiceDetails.Properties.Location, hostedServiceDetails.Properties.AffinityGroup)
            lbslot.Text = deployment.DeploymentSlot.ToString()
        Else
            Response.Write("can't find this VM in current subscription")
        End If
    End Sub

    Private Shared Function getCloudServiceDetailsByDeploymentId() As HostedServiceGetDetailedResponse
        Dim managementClient = New ComputeManagementClient(getCredentials())
        Dim currentDeployment = New Deployment()
        For Each serviceName In cloudServiceNames
            Dim hostedServiceDetails = managementClient.HostedServices.GetDetailed(serviceName)
            For Each deployment In hostedServiceDetails.Deployments
                If deployment.PrivateId = RoleEnvironment.DeploymentId Then
                    Return hostedServiceDetails
                End If
            Next
        Next
        Return Nothing
    End Function

    Private Shared Function getCredentials() As SubscriptionCloudCredentials
        Return New CertificateCloudCredentials(subscriptionId, New X509Certificate2(Convert.FromBase64String(base64EncodedCertificate)))
    End Function

End Class