'*************************** Module Header ******************************\
' Module Name:    CustomServiceHostFactory.vb
' Project:        VBSharePointCallClaimsAwareWCF
' Copyright (c) Microsoft Corporation
'
' This is the Custom ServiceHostFactory Class
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\****************************************************************************


Imports System.ServiceModel
Imports System.ServiceModel.Activation
Imports Microsoft.SharePoint.Administration
Imports Microsoft.SharePoint

Namespace CustomService
    Friend NotInheritable Class CustomServiceHostFactory
        Inherits ServiceHostFactory
        Public Overrides Function CreateServiceHost(ByVal constructorString As String, ByVal baseAddresses As Uri()) As ServiceHostBase
            Dim serviceHost As New ServiceHost(GetType(CustomServiceApplication), baseAddresses)

            ' Configure the service host for claims authentication
            serviceHost.Configure(SPServiceAuthenticationMode.Claims)
            Return serviceHost
        End Function
    End Class
End Namespace
