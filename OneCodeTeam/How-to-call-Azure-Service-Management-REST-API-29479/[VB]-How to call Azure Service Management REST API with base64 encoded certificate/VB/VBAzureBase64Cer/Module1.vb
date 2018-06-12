'***************************** Module Header ******************************\
' Module Name: Module1.vb
' Project:     VBAzureBase64Cer
' Copyright (c) Microsoft Corporation.
' 
' Managing Azure in Role instance may be difficult, because it requires a client
' certificate. This sample will show how to use the base64 string certificate instead
' of getting the certificate from Certificates store.
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
Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.Management.Compute
Imports System.Net
Imports System.IO

Module Module1

    Sub Main()
        Dim credentialsPath As String = "<Credentials File path>"
        Dim subscriptionId As String = "<Subscription Id>"

        Dim x As XElement = XElement.Load(credentialsPath)

        Dim Base64cer = (From c In x.Descendants("Subscription")
                         Where c.Attribute("Id").Value = subscriptionId
                         Select DirectCast(c.Attribute("ManagementCertificate").Value, String)).FirstOrDefault()

        Dim cer As X509Certificate2 = Nothing
        If Base64cer IsNot Nothing Then
            cer = New X509Certificate2(Convert.FromBase64String(Base64cer))
        End If
        If cer IsNot Nothing Then
            'GetHostedServicesByManagementAPI(new CertificateCloudCredentials(subscriptionId, cer));
            GetHostedServicesByRESTAPI(subscriptionId, cer)
        End If
        Console.ReadLine()
    End Sub



    Private Sub GetHostedServicesByManagementAPI(cer As CertificateCloudCredentials)
        Try
            Dim client As New ComputeManagementClient(cer)
            Dim hostedServicesList = client.HostedServices.List()
            For Each item In hostedServicesList
                Console.WriteLine(item.ServiceName)
            Next
            Console.WriteLine()
        Catch e As CloudException

            Throw
        End Try
    End Sub

    Private Sub GetHostedServicesByManagementAPI(subscriptionId As String, certificate As X509Certificate2)
        GetHostedServicesByManagementAPI(New CertificateCloudCredentials(subscriptionId, certificate))
    End Sub

    Private Sub GetHostedServicesByRESTAPI(subscriptionId As String, certificate As X509Certificate2)
        Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(New Uri((Convert.ToString("https://management.core.windows.net/") & subscriptionId) + "/services/hostedservices")), HttpWebRequest)

        request.Method = "GET"
        request.ClientCertificates.Add(certificate)
        request.ContentType = "application/xml"
        request.Headers.Add("x-ms-version", "2012-03-01")

        Try
            Dim response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
            ' Parse the web response.
            Dim responseStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(responseStream)

            Dim xml As String = reader.ReadToEnd()
            Dim doc As XDocument = XDocument.Parse(xml)
            Dim ns As XNamespace = doc.Root.Name.[Namespace]
            Dim hostedServicesName = From item In doc.Descendants(ns + "ServiceName") Select item
            For Each name In hostedServicesName
                Console.WriteLine(name.Value)
            Next
            ' Close the no longer needed resources.
            response.Close()
            responseStream.Close()
            reader.Close()
            Console.ReadKey()
        Catch ex As WebException
            Console.Write(ex.Response.Headers.ToString())
            Console.Read()
        End Try

    End Sub



End Module
