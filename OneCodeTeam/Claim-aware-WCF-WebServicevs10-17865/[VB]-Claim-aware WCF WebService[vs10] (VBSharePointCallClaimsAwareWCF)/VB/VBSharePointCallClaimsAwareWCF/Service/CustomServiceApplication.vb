'*************************** Module Header ******************************\
' Module Name:    CustomServiceApplication.vb
' Project:        VBSharePointCallClaimsAwareWCF
' Copyright (c) Microsoft Corporation
'
' This class is used to implement the Service interface and create ServiceApplication.
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
Imports System.Security.Principal
Imports System.ServiceModel
Imports Microsoft.SharePoint.Administration
Imports Microsoft.SharePoint.Administration.AccessControl
Imports Microsoft.SharePoint.Utilities
Imports Microsoft.IdentityModel.Claims

Namespace CustomService
    <IisWebServiceApplicationBackupBehavior()> _
    <ServiceBehavior(InstanceContextMode:=InstanceContextMode.PerSession, ConcurrencyMode:=ConcurrencyMode.Multiple, IncludeExceptionDetailInFaults:=True, AddressFilterMode:=AddressFilterMode.Any)> _
    <System.Runtime.InteropServices.Guid("A12A5C1C-9784-4118-BF9D-B58B24337E34")> _
    Public NotInheritable Class CustomServiceApplication
        Inherits SPIisWebServiceApplication
        Implements ICustomServiceContract

        <Persisted()> _
        Private _setting As Integer

        <Persisted()> _
        Private _database As CustomServiceDatabase

#Region "constructors"
        Public Sub New()
        End Sub

        Private Sub New(ByVal name As String, ByVal service As CustomService, ByVal applicationPool As SPIisWebServiceApplicationPool, ByVal database As CustomServiceDatabase)
            MyBase.New(name, service, applicationPool)
            If database Is Nothing Then
                Throw New ArgumentNullException("database")
            End If

            _database = database
        End Sub
#End Region

        Public Shared Function Create(ByVal name As String, ByVal service As CustomService, ByVal applicationPool As SPIisWebServiceApplicationPool, ByVal databaseParameters As SPDatabaseParameters) As CustomServiceApplication
            '#Region "validation"
            If name Is Nothing Then
                Throw New ArgumentNullException("name")
            End If

            If service Is Nothing Then
                Throw New ArgumentNullException("service")
            End If

            If applicationPool Is Nothing Then
                Throw New ArgumentNullException("applicationPool")
            End If

            If databaseParameters Is Nothing Then
                Throw New ArgumentNullException("databaseParameters")
            End If
            '#End Region

            ' Register the database
            Dim database As New CustomServiceDatabase(databaseParameters)
            database.Update()

            ' Create and persist the service application
            Dim serviceApplication As New CustomServiceApplication(name, service, applicationPool, database)
            serviceApplication.Update()

            ' register supported endpoints
            serviceApplication.AddServiceEndpoint("tcp", SPIisWebServiceBindingType.NetTcp)
            serviceApplication.AddServiceEndpoint("tcp-ssl", SPIisWebServiceBindingType.NetTcp, "secure")
            serviceApplication.AddServiceEndpoint("http", SPIisWebServiceBindingType.Http)
            serviceApplication.AddServiceEndpoint("https", SPIisWebServiceBindingType.Https, "secure")

            Return serviceApplication
        End Function

#Region "Required serice app details..."
        Protected Overrides ReadOnly Property DefaultEndpointName() As String
            Get
                Return "http"
            End Get
        End Property

        Public Overrides ReadOnly Property TypeName() As String
            Get
                Return "Custom Service Application"
            End Get
        End Property

        ' The InstallPath property tells SharePoint where to find our service files
        Protected Overrides ReadOnly Property InstallPath() As String
            Get
                Return SPUtility.GetGenericSetupPath("WebServices\CustomService")
            End Get
        End Property

        ' The VirtualPath property tells SharePoint the URI of your service endpoint relative to the InstallPath directory, in this case, “CustomService.svc”. 
        Protected Overrides ReadOnly Property VirtualPath() As String
            Get
                Return "CustomService.svc"
            End Get
        End Property

        Public Overrides ReadOnly Property ApplicationClassId() As Guid
            Get
                Return New Guid("A12A5C1C-9784-4118-BF9D-B58B24337E34")
            End Get
        End Property

        Public Overrides ReadOnly Property ApplicationVersion() As Version
            Get
                Return New Version("1.0.0.0")
            End Get
        End Property
#End Region

        ''' <summary>
        ''' Setting persisted in configuration database.
        ''' </summary>
        Public Property Setting() As Integer
            Get
                Return _setting
            End Get

            ' NOTE: Since this method requires an access check, it must impersonate the client.
            <OperationBehavior(Impersonation:=ImpersonationOption.Required)> _
            Set(ByVal value As Integer)
                ' Demand the "Write" custom administration right
                DemandAdministrationAccess(CustomServiceCentralAdministrationRights.Write)

                _setting = value
            End Set
        End Property

        Public Overrides Sub Provision()
            _database.Provision()
            MyBase.Provision()
        End Sub

        Public Overrides Sub Unprovision(ByVal deleteData As Boolean)
            MyBase.Unprovision(deleteData)
            _database.Unprovision()
        End Sub

        Protected Overrides Sub OnProcessIdentityChanged(ByVal processSecurityIdentifier As SecurityIdentifier)
            MyBase.OnProcessIdentityChanged(processSecurityIdentifier)
            _database.GrantApplicationPoolAccess(processSecurityIdentifier)
        End Sub

        ''' <summary>
        ''' Target location admin is sent to from within CA when clicking on Service App or 
        ''' selecting it and picking Manage in the ribbon from CA > Manage Service Apps page.
        ''' </summary>
        Public Overrides ReadOnly Property ManageLink() As SPAdministrationLink
            Get
                Return New SPAdministrationLink("/_admin/ManageSample?id=" & Me.Id.ToString())
            End Get
        End Property

        ''' <summary>
        ''' Target location admin is sent to from within CA when selecting the service all
        ''' and picking Properties in the ribbon from CA > Manage Service Apps page.
        ''' </summary>
        Public Overrides ReadOnly Property PropertiesLink() As SPAdministrationLink
            Get
                Return New SPAdministrationLink("/_admin/EditSample?id=" & Me.Id.ToString())
            End Get
        End Property

#Region "Custom Permissions & Access Rights"
        ''' <summary>
        ''' Override the default named administration access rights to include custom rights.
        ''' These options will show in the CA > Manage Service Apps > [select service app] > Administrators
        ''' </summary>
        ''' <remarks>The returned items will be used for display in the ACL editor UI 
        ''' control and the PowerShell Grant and Revoke Cmdlets.</remarks>
        Protected Overrides ReadOnly Property AdministrationAccessRights() As SPNamedCentralAdministrationRights()
            Get
                Return New SPNamedCentralAdministrationRights() {SPNamedCentralAdministrationRights.FullControl, New SPNamedCentralAdministrationRights("Modify", SPCentralAdministrationRights.Read Or CustomServiceCentralAdministrationRights.Write), SPNamedCentralAdministrationRights.Read}
            End Get
        End Property

        ''' <summary>
        ''' Override the default access rights to include custom rights.
        ''' These optiosn will show in the CA > Manage Service Apps > [select service app] > Permissions
        ''' </summary>
        ''' <remarks>These can be used to ensure the caller has specific rights granted to it, and enforced in 
        ''' the caller below using the DemandAccess() method.</remarks>
        Protected Overrides ReadOnly Property AccessRights() As SPNamedIisWebServiceApplicationRights()
            Get
                Return New SPNamedIisWebServiceApplicationRights() {SPNamedIisWebServiceApplicationRights.FullControl, New SPNamedIisWebServiceApplicationRights("Add", CustomServiceAccessRights.Add), New SPNamedIisWebServiceApplicationRights("Subtract", CustomServiceAccessRights.Subtract), SPNamedIisWebServiceApplicationRights.Read}
            End Get
        End Property
#End Region

#Region "All the methods that do the work within the service application. {ISampleWebServiceContract Members}"
        Public Function Add(ByVal a As Integer, ByVal b As Integer) As Integer Implements ICustomServiceContract.Add
            DemandAccess(CustomServiceAccessRights.Add)
            Return a + b
        End Function

        Public Function Subtract(ByVal a As Integer, ByVal b As Integer) As Integer
            DemandAccess(CustomServiceAccessRights.Subtract)
            Return a - b
        End Function

        Public Function HelloWorld() As String Implements ICustomServiceContract.HelloWorld
            DemandAccess(CustomServiceAccessRights.Hello)
            Dim id As String = GetIdentityClass.GetIdentity()

            Return "Hello World from WCF and SharePoint 2010; GetIdentity" & id
        End Function

#End Region

    End Class
End Namespace
