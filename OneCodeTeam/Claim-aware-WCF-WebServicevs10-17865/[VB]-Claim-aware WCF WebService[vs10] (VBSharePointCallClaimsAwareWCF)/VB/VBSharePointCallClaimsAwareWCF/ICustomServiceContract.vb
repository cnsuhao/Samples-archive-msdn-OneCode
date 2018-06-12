'************************** Module Header ******************************\
' Module Name:    ICustomServiceContract.vb
' Project:        VBSharePointCallClaimsAwareWCF
' Copyright (c) Microsoft Corporation
'
' This class is the interface for Wcf WebService
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************


Imports System.ServiceModel

Namespace CustomService
    <ServiceContract()> _
    Public Interface ICustomServiceContract
        <OperationContractAttribute(Name:="Add")> _
        Function Add(ByVal a As Integer, ByVal b As Integer) As Integer

        <OperationContractAttribute(Name:="HelloWorld")> _
        Function HelloWorld() As String
    End Interface
End Namespace
