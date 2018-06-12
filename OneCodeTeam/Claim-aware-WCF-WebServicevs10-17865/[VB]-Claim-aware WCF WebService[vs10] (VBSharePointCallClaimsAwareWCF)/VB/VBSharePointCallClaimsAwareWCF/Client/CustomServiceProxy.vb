'*************************** Module Header ******************************\
' Module Name:    CustomServiceProxy.vb
' Project:        VBSharePointCallClaimsAwareWCF
' Copyright (c) Microsoft Corporation
'
' This class is used to define Service Proxy
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\****************************************************************************


Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Runtime.InteropServices
Imports Microsoft.SharePoint.Administration

Namespace CustomService
    <Guid("72B01562-6AEE-4ab3-BA64-F7B6A02E3AC6")> _
    <SupportedServiceApplication("A12A5C1C-9784-4118-BF9D-B58B24337E34", "1.0.0.0", GetType(CustomServiceApplicationProxy))> _
    Public NotInheritable Class CustomServiceProxy
        Inherits SPIisWebServiceProxy
        Implements IServiceProxyAdministration

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal farm As SPFarm)
            MyBase.New(farm)
        End Sub


        Public Function CreateProxy(ByVal serviceApplicationProxyType As System.Type, ByVal name As String, ByVal serviceApplicationUri As System.Uri, ByVal provisioningContext As Microsoft.SharePoint.Administration.SPServiceProvisioningContext) As Microsoft.SharePoint.Administration.SPServiceApplicationProxy Implements Microsoft.SharePoint.Administration.IServiceProxyAdministration.CreateProxy
            If serviceApplicationProxyType IsNot GetType(CustomServiceApplicationProxy) Then
                Throw New NotSupportedException()
            End If

            Return New CustomServiceApplicationProxy(name, Me, serviceApplicationUri)
        End Function

        Public Overrides Function GetCreateProxyLink(ByVal serviceApplicationProxyType As System.Type) As Microsoft.SharePoint.Administration.SPAdministrationLink Implements Microsoft.SharePoint.Administration.IServiceProxyAdministration.GetCreateProxyLink
            Return New SPAdministrationLink("")
        End Function

        Public Function GetProxyTypeDescription(ByVal serviceApplicationProxyType As System.Type) As Microsoft.SharePoint.Administration.SPPersistedTypeDescription Implements Microsoft.SharePoint.Administration.IServiceProxyAdministration.GetProxyTypeDescription
            Return New SPPersistedTypeDescription("Custom Service Proxy", "Connects to the sample custom service.")
        End Function

        Public Function GetProxyTypes() As System.Type() Implements Microsoft.SharePoint.Administration.IServiceProxyAdministration.GetProxyTypes
            Return New Type() {GetType(CustomServiceApplicationProxy)}
        End Function
    End Class
End Namespace

