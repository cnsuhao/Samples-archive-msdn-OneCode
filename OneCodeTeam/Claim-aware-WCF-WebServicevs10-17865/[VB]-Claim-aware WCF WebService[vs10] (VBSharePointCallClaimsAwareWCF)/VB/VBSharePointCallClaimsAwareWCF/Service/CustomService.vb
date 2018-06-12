'************************** Module Header ******************************\
' Module Name:    CustomService.vb
' Project:        VBSharePointCallClaimsAwareWCF
' Copyright (c) Microsoft Corporation
'
' This class is the server side of CustomService
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
Imports Microsoft.SharePoint.Administration

Namespace CustomService
    <System.Runtime.InteropServices.Guid("E82CD185-E958-43a9-B032-FFE433FCE324")> _
    Public Class CustomService
        Inherits SPIisWebService
        Implements IServiceAdministration

        ''' <summary>
        ''' Internal use only.
        ''' </summary>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' Creates a new service proxy.
        ''' </summary>
        ''' <param name="farm">The parent farm object.</param>
        Public Sub New(ByVal farm As SPFarm)
            MyBase.New(farm)
        End Sub

#Region "IServiceAdministration Members"
        Public Function CreateApplication(ByVal name As String, ByVal serviceApplicationType As System.Type, ByVal provisioningContext As Microsoft.SharePoint.Administration.SPServiceProvisioningContext) As Microsoft.SharePoint.Administration.SPServiceApplication Implements Microsoft.SharePoint.Administration.IServiceAdministration.CreateApplication
            '#Region "validation"
            If provisioningContext Is Nothing Then
                Throw New ArgumentNullException("provisioningContext")
            End If
            If serviceApplicationType IsNot GetType(CustomServiceApplication) Then
                Throw New NotSupportedException()
            End If
            '#End Region

            ' check to see if this service application already exists
            Dim application As CustomServiceApplication = TryCast(Me.Farm.GetObject(name, Me.Id, serviceApplicationType), CustomServiceApplication)

            If application Is Nothing Then

                ' Generate a unique database name based on the application name, using the default SQL Server
                Dim databaseParameters As SPDatabaseParameters = SPDatabaseParameters.CreateParameters(name, SPDatabaseParameterOptions.GenerateUniqueName)

                ' Create the service application
                application = CustomServiceApplication.Create(name, Me, provisioningContext.IisWebServiceApplicationPool, databaseParameters)
            End If

            Return application
        End Function

        Public Function CreateProxy(ByVal name As String, ByVal serviceApplication As Microsoft.SharePoint.Administration.SPServiceApplication, ByVal provisioningContext As Microsoft.SharePoint.Administration.SPServiceProvisioningContext) As Microsoft.SharePoint.Administration.SPServiceApplicationProxy Implements Microsoft.SharePoint.Administration.IServiceAdministration.CreateProxy
            '#Region "validation"
            If serviceApplication Is Nothing Then
                Throw New ArgumentNullException("serviceApplication")
            End If
            If serviceApplication.[GetType]() IsNot GetType(CustomServiceApplication) Then
                Throw New NotSupportedException()
            End If

            ' verify service proxy exists
            Dim serviceProxy As CustomServiceProxy = DirectCast(Me.Farm.GetObject(String.Empty, Me.Farm.Id, GetType(CustomServiceProxy)), CustomServiceProxy)
            If serviceProxy Is Nothing Then
                Throw New InvalidOperationException("CustomServiceApplicationProxy does not exist in the farm")
            End If
            '#End Region

            ' if no app proxy exists, create it
            Dim appProxy As CustomServiceApplicationProxy = serviceProxy.ApplicationProxies.GetValue(Of CustomServiceApplicationProxy)(name)
            If appProxy Is Nothing Then
                appProxy = New CustomServiceApplicationProxy(name, serviceProxy, DirectCast(serviceApplication, CustomServiceApplication).Uri)
            End If

            Return appProxy
        End Function

        ''' <summary>
        ''' Gets a description of the specified service application type.
        ''' </summary>
        ''' <param name="serviceApplicationType">The service application type.</param>
        ''' <returns>A description of the specified type suitable for display.</returns>
        Public Function GetApplicationTypeDescription(ByVal serviceApplicationType As System.Type) As Microsoft.SharePoint.Administration.SPPersistedTypeDescription Implements Microsoft.SharePoint.Administration.IServiceAdministration.GetApplicationTypeDescription
            If serviceApplicationType IsNot GetType(CustomServiceApplication) Then
                Throw New NotSupportedException()
            End If

            Return New SPPersistedTypeDescription("Custom Service Application", "A custom service application sample by AC.")
        End Function

        ''' <summary>
        ''' Gets an array of the service application types supported by the service.
        ''' </summary>
        ''' <returns>An array of supported types.</returns>
        Public Function GetApplicationTypes() As System.Type() Implements Microsoft.SharePoint.Administration.IServiceAdministration.GetApplicationTypes
            Return New Type() {GetType(CustomServiceApplication)}
        End Function

        ''' <summary>
        ''' Gets the link used to create a service application of a specified type.
        ''' </summary>
        ''' <param name="serviceApplicationType">The service application type.</param>
        ''' <returns>The requested link.</returns>
        Public Overrides Function GetCreateApplicationLink(ByVal serviceApplicationType As System.Type) As Microsoft.SharePoint.Administration.SPAdministrationLink Implements Microsoft.SharePoint.Administration.IServiceAdministration.GetCreateApplicationLink
            Return New SPAdministrationLink("/_admin/CreateCustomServiceApplication")
        End Function
#End Region

        Public Overrides Function GetCreateApplicationOptions(ByVal serviceApplicationType As System.Type) As Microsoft.SharePoint.Administration.SPCreateApplicationOptions Implements Microsoft.SharePoint.Administration.IServiceAdministration.GetCreateApplicationOptions
            Return SPCreateApplicationOptions.Default
        End Function
    End Class
End Namespace
