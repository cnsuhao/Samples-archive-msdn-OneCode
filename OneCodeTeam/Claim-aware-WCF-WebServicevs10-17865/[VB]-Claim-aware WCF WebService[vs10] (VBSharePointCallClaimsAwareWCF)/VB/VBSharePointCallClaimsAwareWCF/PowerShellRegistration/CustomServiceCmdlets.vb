'*************************** Module Header ******************************\
' Module Name:    CustomServiceCmdlets.vb
' Project:        VBSharePointCallClaimsAwareWCF
' Copyright (c) Microsoft Corporation
'
' This class is used to host the Service PowerShellRegistration
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
Imports Microsoft.SharePoint.PowerShell
Imports System.Management.Automation
Imports Microsoft.SharePoint.Administration
Imports CustomService
Imports Microsoft.SharePoint
Imports System.Net

Namespace CustomService.PowerShell
    <Cmdlet(VerbsLifecycle.Install, "CustomService", SupportsShouldProcess:=True)> _
    Public Class InstallCustomService
        Inherits SPCmdlet
        Protected Overrides Function RequireUserFarmAdmin() As Boolean
            Return True
        End Function

        Protected Overrides Sub InternalProcessRecord()
            Dim farm As SPFarm = SPFarm.Local
            If farm Is Nothing Then
                ThrowTerminatingError(New InvalidOperationException("SharePoint farm not found."), ErrorCategory.ResourceUnavailable, Me)
            End If

            Dim server As SPServer = SPServer.Local
            If farm Is Nothing Then
                ThrowTerminatingError(New InvalidOperationException("SharePoint local server not found."), ErrorCategory.ResourceUnavailable, Me)
            End If


            If ShouldProcess("Custom Service") Then
                ' Ensure the custom service exists
                Dim service As CustomService = farm.Services.GetValue(Of CustomService)()

                ' If the service is NOT already installed, install it.
                If service Is Nothing Then
                    ' Create the service
                    service = New CustomService(farm)
                    service.Update()
                End If

                ' With the service added to the farm, see if there is a running instance on the server... 
                ' if not, create it.
                Dim serverSvcInstance As New CustomServiceInstance(server, service)
                serverSvcInstance.Update(True)
            End If
        End Sub
    End Class

    <Cmdlet(VerbsCommon.[New], "CustomServiceApplication", SupportsShouldProcess:=True)> _
    Public Class NewCustomServiceApplication
        Inherits SPCmdlet
        Private Const DbPrefix As String = "CustomService"

#Region "Cmdlet Parameters"
        <Parameter(Mandatory:=True)> _
        <ValidateNotNullOrEmpty()> _
        Public Name As String

        ' The SPIisWebServiceApplicationPoolPipeBind parameter accepts a service
        ' application pool object, which can be created by the New-SPServiceApplicationPool
        ' cmdlet. Alternatively, an administration can use the Get-SPServiceApplicationPool
        ' cmdlet to select an existing service application pool to be used for the new
        ' service application.
        <Parameter(Mandatory:=True)> _
        <ValidateNotNullOrEmpty()> _
        Public ApplicationPool As SPIisWebServiceApplicationPoolPipeBind

        <Parameter(Mandatory:=False)> _
        <ValidateNotNullOrEmpty()> _
        Public DatabaseServer As String

        <Parameter(Mandatory:=False)> _
        <ValidateNotNullOrEmpty()> _
        Public FailoverDatabaseServer As String

        <Parameter(Mandatory:=True)> _
        <ValidateNotNullOrEmpty()> _
        Public DatabaseName As String

        <Parameter(Mandatory:=False)> _
        <ValidateNotNullOrEmpty()> _
        Public DatabaseCredentials As PSCredential
#End Region

        Protected Overrides Function RequireUserFarmAdmin() As Boolean
            Return True
        End Function

        ''' <summary>
        ''' The InternalProcessRecord method is where the work happens.
        ''' </summary>
        Protected Overrides Sub InternalProcessRecord()
            ' Ensure can hit farm
            Dim farm As SPFarm = SPFarm.Local
            If farm Is Nothing Then
                ThrowTerminatingError(New InvalidOperationException("SharePoint farm not found."), ErrorCategory.ResourceUnavailable, Me)
                SkipProcessCurrentRecord()
            End If

            ' Ensure can hit local server
            Dim server As SPServer = SPServer.Local
            If farm Is Nothing Then
                ThrowTerminatingError(New InvalidOperationException("SharePoint local server not found."), ErrorCategory.ResourceUnavailable, Me)
                SkipProcessCurrentRecord()
            End If

            ' Ensure can hit service application
            Dim service As CustomService = farm.Services.GetValue(Of CustomService)()
            If service Is Nothing Then
                ThrowTerminatingError(New InvalidOperationException("Custom Service not found (likely not installed)."), ErrorCategory.ResourceUnavailable, Me)
                SkipProcessCurrentRecord()
            End If

            ' Ensure can hit app pool
            Dim appPool As SPIisWebServiceApplicationPool = Me.ApplicationPool.Read()
            If appPool Is Nothing Then
                ThrowTerminatingError(New InvalidOperationException("Application pool not found."), ErrorCategory.ResourceUnavailable, Me)
                SkipProcessCurrentRecord()
            End If

            ' Ensure can hit database
            Dim dbServer As String = Me.DatabaseServer
            If String.IsNullOrEmpty(dbServer) Then
                dbServer = SPWebService.ContentService.DefaultDatabaseInstance.NormalizedDataSource
            End If

            ' Ensure a service application does not already exist
            Dim existingCustomServiceApp As CustomServiceApplication = service.Applications.GetValue(Of CustomServiceApplication)()
            If existingCustomServiceApp IsNot Nothing Then
                WriteError(New InvalidOperationException("Custom service application already exists."), ErrorCategory.ResourceExists, existingCustomServiceApp)
                SkipProcessCurrentRecord()
            End If

            ' Get database credentials
            Dim dbUsername As String = Nothing
            Dim dbPassword As String = Nothing
            If DatabaseCredentials IsNot Nothing Then
                Dim dbCredential As NetworkCredential = CType(DatabaseCredentials, NetworkCredential)
                dbUsername = dbCredential.UserName
                dbPassword = dbCredential.Password
            End If

            Dim dbOptions As SPDatabaseParameterOptions = SPDatabaseParameterOptions.None

            ' Get database name
            Dim dbName As String = DatabaseName
            If dbName Is Nothing Then
                dbName = "CustomServiceDB"
                dbOptions = SPDatabaseParameterOptions.GenerateUniqueName
            End If

            ' Create settings for a new database
            Dim dbParameters As SPDatabaseParameters = SPDatabaseParameters.CreateParameters(dbName, dbServer, dbUsername, dbPassword, FailoverDatabaseServer, dbOptions)

            ' Create & provision the service application 
            If ShouldProcess(Me.Name) Then
                Dim serviceApp As CustomServiceApplication = CustomServiceApplication.Create(Me.Name, service, appPool, dbParameters)

                ' Provision the service app
                serviceApp.Provision()

                ' Writes the new service application object out to the PowerShell pipeline
                ' where it can be piped as input to the next cmdlet in the pipeline.
                WriteObject(serviceApp)
            End If
        End Sub
    End Class
End Namespace

