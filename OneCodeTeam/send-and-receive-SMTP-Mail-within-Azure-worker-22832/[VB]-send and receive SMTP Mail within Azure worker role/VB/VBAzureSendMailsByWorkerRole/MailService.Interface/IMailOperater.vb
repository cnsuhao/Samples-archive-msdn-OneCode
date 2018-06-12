'***************************** Module Header ******************************\
' Module Name:  IMailOperater.vb
' Project:      VBAzureSendMailsByWorkerRole
' Copyright (c) Microsoft Corporation.
' 
' As you know, System.Net.Mail api can't be used in Windows Runtime application, 
' However, we can create a WCF service to consume the api, and hold this service 
' on Azure.
' 
' In this way, we can use this service to send email in Windows Store app. 
' 
' This interface defines the contracts of the WCF service.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************/

Imports System.ServiceModel
Imports MailService.Model

<ServiceContract(Name:="MailService", [Namespace]:="http://127.0.0.1:3721/")>
Public Interface IMailOperater

    ''' <summary>
    ''' Send mail method
    ''' </summary>
    ''' <param name="Model"></param>
    ''' <returns></returns>
    <OperationContract()>
    Function SendMail(Model As MailModel) As Boolean
End Interface

