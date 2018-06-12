'***************************** Module Header ******************************\
' Module Name:	Module1.vb
' Project:		VBAzureAddSubDomainBinding
' Copyright (c) Microsoft Corporation.
' 
' This sample shows how to add/delete CName to Azure Website programmatically.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/
Imports Microsoft.WindowsAzure.Management.WebSites.Models
Imports Microsoft.WindowsAzure.Management.WebSites
Imports Microsoft.WindowsAzure
Imports System.Security.Cryptography.X509Certificates

Module Module1

    Public Const base64EncodedCertificate As String = "{Your-sertificate-base64string}"
    Public Const subscriptionId As String = "{Your-subscription-id}"
    Public websiteName As String = "{Your-web-site-name}"
    Public subDomainName As String = "{sub-domain-name}"

    Sub Main()
        AddDomainName(WebSpaceNames.WestEuropeWebSpace, "onecode", "www.onecode.com")
        'DeleteDomainName(WebSpaceNames.WestEuropeWebSpace, "onecode", "www.onecode.com");    
        Console.ReadLine()
    End Sub

    Private Function getCredentials() As SubscriptionCloudCredentials
        Return New CertificateCloudCredentials(subscriptionId, New X509Certificate2(Convert.FromBase64String(base64EncodedCertificate)))
    End Function

    Private Sub AddDomainName(webspaceName As String, websiteName As String, subDomainName As String)
        Try
            Dim client As New WebSiteManagementClient(getCredentials())

            Dim website = client.WebSites.[Get](webspaceName, websiteName, New Microsoft.WindowsAzure.Management.WebSites.Models.WebSiteGetParameters())
            website.WebSite.HostNames.Add(subDomainName)

            Dim parm = New WebSiteUpdateParameters()
            parm.HostNames = website.WebSite.HostNames
            client.WebSites.Update(webspaceName, websiteName, parm)
            Console.WriteLine("Add CName: {0} to {1} successfully!", subDomainName, websiteName)
        Catch exception As WebSiteCloudException
            Console.WriteLine(exception.ErrorMessage)
        End Try
    End Sub

    Private Sub DeleteDomainName(webspaceName As String, websiteName As String, subDomainName As String)
        Try
            Dim client As New WebSiteManagementClient(getCredentials())

            Dim website = client.WebSites.[Get](webspaceName, websiteName, New Microsoft.WindowsAzure.Management.WebSites.Models.WebSiteGetParameters())
            website.WebSite.HostNames.Remove(subDomainName)

            Dim parm = New WebSiteUpdateParameters()
            parm.HostNames = website.WebSite.HostNames
            client.WebSites.Update(webspaceName, websiteName, parm)
            Console.WriteLine("Delete CName: {0} from {1} successfully!", subDomainName, websiteName)
        Catch exception As WebSiteCloudException

            Console.WriteLine(exception.ErrorMessage)
        End Try
    End Sub
End Module
