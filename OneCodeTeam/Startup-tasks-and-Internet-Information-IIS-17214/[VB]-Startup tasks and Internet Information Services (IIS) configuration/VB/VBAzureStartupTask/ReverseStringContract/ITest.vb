'****************************** Module Header ******************************\
' Module Name:  ITest.vb
' Project:      VBAzureStartupTask
' Copyright (c) Microsoft Corporation.
'
' Definition of reverse string WCF service contract
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.ServiceModel

<ServiceContract()> _
Public Interface ITestWCFService
    <OperationContract()> _
    Function ReverseString(s As String) As String
End Interface
