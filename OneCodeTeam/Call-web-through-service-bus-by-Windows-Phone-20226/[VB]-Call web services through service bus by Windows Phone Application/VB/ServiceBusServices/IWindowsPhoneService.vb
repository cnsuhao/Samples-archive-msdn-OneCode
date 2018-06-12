'****************************** Module Header ******************************\
'Module Name:  IWindowsPhoneService.vb
'Project:      ServiceBusServices
'Copyright (c) Microsoft Corporation.
'
'The sample code demonstrates how to expose an on-premise REST service to Internet
'via Service Bus, then you can access this service by Windows Phone application.
'The service includes normal string, generics and image methods.
'
'This is the REST service interface contract.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.ServiceModel
Imports System.ServiceModel.Web
Imports System.IO

<ServiceContract()> _
Public Interface IWindowsPhoneService
    ''' <summary>
    ''' Hello method contract.
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    <WebGet(UriTemplate:="/Hello?name={name}")> _
    Function Hello(name As String) As [String]

    ''' <summary>
    ''' Image method contract.
    ''' </summary>
    ''' <returns></returns>
    <WebGet(UriTemplate:="/Image")> _
    Function Image() As Stream

    ''' <summary>
    ''' Person method contract.
    ''' </summary>
    ''' <returns></returns>
    <WebGet(UriTemplate:="/Person")> _
    Function Persons() As List(Of Person)
End Interface
