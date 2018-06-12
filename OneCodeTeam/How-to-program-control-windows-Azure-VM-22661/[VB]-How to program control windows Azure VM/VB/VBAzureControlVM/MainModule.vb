'***************************** Module Header ******************************\
' Module Name: MainModule.vb
' Project:     VBAzureControlVM
' Copyright (c) Microsoft Corporation.
'
' To operate windows azure Iaas virtual machine, using the azure power shell 
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
Imports System.IO
Imports System.Net
Imports System.Xml

Module MainModule

    'First set the subscription ID, you can find it in your Azure portal.
    Public SubscriptionID As String = "YOUR_SUBSCRIPTION_ID"

    'A VM need a host service, you can create it in your Azure portal.
    Public ServiceName As String = "SERVICE_NAME"

    'You need to make sure this certificate is in your Azure management certificate pool.
    'And it's also in your local computer personal certificate pool.
    Public CertificateThumbprint As String = "MANAGEMENT_CERTIFICATE"
    Public Certificate As X509Certificate2
    Public Delegate Function VMOperateRequest() As HttpWebRequest

    Public Sub Main(args As String())
        Console.WriteLine("Please first input your subscription ID")
        SubscriptionID = Console.ReadLine()

        Console.WriteLine("Please enter the service name you want to hold the VM")
        ServiceName = Console.ReadLine()

        Console.WriteLine("Please enter the Azure management certificate thumbprint:")
        CertificateThumbprint = Console.ReadLine()

        Dim vmDels As VMOperateRequest() = New VMOperateRequest() {
            AddressOf AddVirtualMachine,
            AddressOf GetVirtualMachineState,
            AddressOf DeleteVirtualMachine}

        Dim certificateStore As New X509Store(StoreName.My, StoreLocation.CurrentUser)
        certificateStore.Open(OpenFlags.[ReadOnly])
        Dim certs As X509Certificate2Collection = certificateStore.Certificates.Find(X509FindType.FindByThumbprint, CertificateThumbprint, False)


        If certs.Count = 0 Then
            Console.WriteLine("Can't find the certificate in your local computer.")
            Console.ReadKey()
            Return
        Else
            Certificate = certs(0)
        End If

        Console.WriteLine("Please choose the operation:" & vbLf & "1.Add new VM" & vbLf & "2.Get VM state" & vbLf & "3.delete VM" & vbLf & "Please input the number")
        Dim number As Integer = Integer.Parse(Console.ReadLine()) - 1
        Dim request As HttpWebRequest
        While True
            If number >= 0 AndAlso number <= 2 Then
                request = vmDels(number)()
                Exit While
            Else
                Console.Write("Please input right number.")
            End If
        End While


        Try
            Dim response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)

            ' Display the web response status code.
            Console.WriteLine("Response status code: " & Convert.ToString(response.StatusCode))

            ' Display the request ID returned by Windows Azure.
            If response.Headers IsNot Nothing Then

                Console.WriteLine("x-ms-request-id:" & response.Headers("x-ms-request-id"))
            End If
            ' Parse the web response.
            Dim responseStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(responseStream)

            ' Display the raw response.
            Console.WriteLine("Response output:")
            Console.WriteLine(reader.ReadToEnd())
            Console.WriteLine("Status code:{0}", response.StatusCode)


            ' Close the resources no longer needed.
            response.Close()
            responseStream.Close()
            reader.Close()
            Console.ReadKey()
        Catch ex As WebException
            Console.Write(ex.Response.Headers.ToString())
            Console.Read()
        End Try

    End Sub

    ''' <summary>
    ''' Add a windows server 2008 R2 virtual machine.
    ''' Need to set the AddVirtualMachine.xml file first
    ''' </summary>
    ''' <returns></returns>
    Private Function AddVirtualMachine() As HttpWebRequest

        'For more details about how to add virtual machine please refer to:
        'http://msdn.microsoft.com/en-us/library/windowsazure/jj157194.aspx.
        Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(New Uri("https://management.core.windows.net/" & SubscriptionID & "/services/hostedservices/" & ServiceName & "/deployments")), HttpWebRequest)

        request.Method = "POST"
        request.ClientCertificates.Add(Certificate)
        request.ContentType = "application/xml"
        request.Headers.Add("x-ms-version", "2012-03-01")

        ' Add body to the request
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load("..\..\AddVirtualMachine.xml")

        Dim requestStream As Stream = request.GetRequestStream()
        Dim streamWriter As New StreamWriter(requestStream, System.Text.UTF8Encoding.UTF8)
        xmlDoc.Save(streamWriter)

        streamWriter.Close()
        requestStream.Close()

        Return request

    End Function

    ''' <summary>
    ''' Get the virtual machine state by specific service name.
    ''' </summary>
    ''' <returns></returns>
    Private Function GetVirtualMachineState() As HttpWebRequest
        Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(New Uri("https://management.core.windows.net/" & SubscriptionID & "/services/hostedservices/" & ServiceName & "/deploymentslots/Production")), HttpWebRequest)

        request.Method = "GET"
        request.ClientCertificates.Add(Certificate)

        request.ContentType = "application/xml"
        request.Headers.Add("x-ms-version", "2012-03-01")

        Return request
    End Function

    ''' <summary>
    ''' Delete the virtual machine by specific service name. 
    ''' </summary>
    ''' <returns></returns>
    Private Function DeleteVirtualMachine() As HttpWebRequest
        Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(New Uri("https://management.core.windows.net/" & SubscriptionID & "/services/hostedservices/" & ServiceName & "/deploymentslots/Production")), HttpWebRequest)

        request.Method = "DELETE"
        request.ClientCertificates.Add(Certificate)

        request.ContentType = "application/xml"
        request.Headers.Add("x-ms-version", "2012-03-01")

        Return request
    End Function

End Module
