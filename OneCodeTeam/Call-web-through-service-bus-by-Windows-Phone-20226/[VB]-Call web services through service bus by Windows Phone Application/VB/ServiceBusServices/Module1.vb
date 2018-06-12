'****************************** Module Header ******************************\
'Module Name:  Program.vb
'Project:      ServiceBusServices
'Copyright (c) Microsoft Corporation.
'
'The sample code demonstrates how to expose an on-premise REST service to Internet
'via Service Bus, then you can access this service by Windows Phone application.
'The service includes normal string, generics and image methods.
'
'We use ServiceHost class to expose the service to the Microsoft Windows Azure
'Service Bus, here you need input your Service Bus issuer and key before running
'the Console application.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.Configuration
Imports Microsoft.ServiceBus
Imports System.ServiceModel
Imports System.ServiceModel.Description

Module Module1

    Sub Main()
        Dim serviceNamespace As String = ConfigurationManager.AppSettings("serviceNamespace")
        Dim address As Uri = ServiceBusEnvironment.CreateServiceUri("http", serviceNamespace, "")

        ' Create WebHttpRelayBinding instance.
        Dim binding As New WebHttpRelayBinding(EndToEndWebHttpSecurityMode.None, RelayClientAuthenticationType.None)

        ' Create ServiceHost with endpoint.
        Dim host = New ServiceHost(GetType(WindowsPhoneService), address)
        host.AddServiceEndpoint(GetType(IWindowsPhoneService), binding, address)
        Dim behavior = host.Description.Endpoints(0).Behaviors

        ' Add ServiceBus key.
        behavior.Add(New TransportClientEndpointBehavior(TokenProvider.CreateSharedSecretTokenProvider(ConfigurationManager.AppSettings("issuer"), ConfigurationManager.AppSettings("key"))))
        behavior.Add(New WebHttpBehavior())
        host.Open()

        Console.WriteLine(String.Format("Service listening at: {0}", host.Description.Endpoints(0).Address))
        Console.WriteLine("Press any key to exit...")
        Console.ReadKey()

        host.Close()
    End Sub

End Module
