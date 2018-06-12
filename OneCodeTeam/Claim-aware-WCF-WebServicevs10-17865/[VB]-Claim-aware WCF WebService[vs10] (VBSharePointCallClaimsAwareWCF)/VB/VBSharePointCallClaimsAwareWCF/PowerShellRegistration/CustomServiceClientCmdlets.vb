'*************************** Module Header ******************************\
' Module Name:    CustomServiceClientCmdlets.vb
' Project:        VBSharePointCallClaimsAwareWCF
' Copyright (c) Microsoft Corporation
'
' This class is used to host the Client PowerShellRegistration
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

Namespace CustomService.PowerShell
    <Cmdlet(VerbsLifecycle.Install, "CustomServiceProxy", SupportsShouldProcess:=True)> _
    Public Class InstallCustomServiceProxy
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


            ' Install the service proxy into the farm if it's not already installed.
            If ShouldProcess("Custom Service Proxy") Then
                Dim serviceProxy As CustomServiceProxy = farm.ServiceProxies.GetValue(Of CustomServiceProxy)()

                If serviceProxy Is Nothing Then
                    serviceProxy = New CustomServiceProxy(farm)
                    serviceProxy.Update(True)
                End If
            End If
        End Sub
    End Class

    <Cmdlet(VerbsCommon.[New], "CustomServiceApplicationProxy", SupportsShouldProcess:=True)> _
    Public Class NewCustomServiceApplicationProxy
        Inherits SPCmdlet
        Private _name As String
        Private _uri As Uri
        Private _pipeBind As SPServiceApplicationPipeBind

        <Parameter(Mandatory:=True)> _
        <ValidateNotNullOrEmpty()> _
        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property

        <Parameter(Mandatory:=True, ParameterSetName:="Uri")> _
        <ValidateNotNullOrEmpty()> _
        Public Property Uri() As String
            Get
                Return _uri.ToString()
            End Get
            Set(ByVal value As String)
                _uri = New Uri(value)
            End Set
        End Property

        <Parameter(Mandatory:=True, ValueFromPipeline:=True, ParameterSetName:="ServiceApplication")> _
        Public Property ServiceApplication() As SPServiceApplicationPipeBind
            Get
                Return _pipeBind
            End Get
            Set(ByVal value As SPServiceApplicationPipeBind)
                _pipeBind = value
            End Set
        End Property

        Protected Overrides Function RequireUserFarmAdmin() As Boolean
            Return True
        End Function

        Protected Overrides Sub InternalProcessRecord()
            ' Ensure can hit farm
            Dim farm As SPFarm = SPFarm.Local
            If farm Is Nothing Then
                ThrowTerminatingError(New InvalidOperationException("SharePoint farm not found."), ErrorCategory.ResourceUnavailable, Me)
                SkipProcessCurrentRecord()
            End If

            ' Ensure the service proxy is installed
            Dim serviceProxy As CustomServiceProxy = farm.ServiceProxies.GetValue(Of CustomServiceProxy)()
            If serviceProxy Is Nothing Then
                ThrowTerminatingError(New InvalidOperationException("Custom service application proxy not found."), ErrorCategory.NotInstalled, Me)
            End If

            ' Ensure the proxy isn't already created
            Dim existingServiceAppProxy As CustomServiceApplicationProxy = serviceProxy.ApplicationProxies.GetValue(Of CustomServiceApplicationProxy)()
            If existingServiceAppProxy IsNot Nothing Then
                WriteError(New InvalidOperationException("Custom service application proxy already exists."), ErrorCategory.ResourceExists, existingServiceAppProxy)
                ' Skip this command
                SkipProcessCurrentRecord()
            End If

            Dim serviceAppUri As Uri = Nothing
            If ParameterSetName = "Uri" Then
                serviceAppUri = _uri
            ElseIf ParameterSetName = "ServiceApplication" Then
                Dim serviceApp As SPServiceApplication = _pipeBind.Read()
                If serviceApp Is Nothing Then
                    WriteError(New InvalidOperationException("Service application not found."), ErrorCategory.ResourceExists, serviceApp)
                    SkipProcessCurrentRecord()
                End If

                Dim sharedServiceApp As ISharedServiceApplication = TryCast(serviceApp, ISharedServiceApplication)
                If sharedServiceApp Is Nothing Then
                    WriteError(New InvalidOperationException("Connecting to specified service application is not supported."), ErrorCategory.ResourceExists, serviceApp)
                    SkipProcessCurrentRecord()
                End If

                serviceAppUri = sharedServiceApp.Uri
            Else
                ThrowTerminatingError(New InvalidOperationException("Invalid parameter set."), ErrorCategory.InvalidArgument, Me)
            End If

            If (serviceAppUri IsNot Nothing) AndAlso ShouldProcess(Name) Then
                ' Create service app proxy
                Dim serviceAppProxy As New CustomServiceApplicationProxy(Name, serviceProxy, serviceAppUri)

                ' Provision the sample service app proxy
                serviceAppProxy.Provision()

                ' Write new sample service app proxy to pipeline
                WriteObject(serviceAppProxy)
            End If

        End Sub
    End Class

    <Cmdlet("Invoke", "CustomService", SupportsShouldProcess:=True)> _
    Public Class InvokeCustomService
        Inherits SPCmdlet
        Private _values As Integer()
        Private _serviceContext As SPServiceContextPipeBind

        <Parameter(Mandatory:=True, ValueFromPipeline:=True, Position:=0)> _
        Public Property ServiceContext() As SPServiceContextPipeBind
            Get
                Return _serviceContext
            End Get
            Set(ByVal value As SPServiceContextPipeBind)
                _serviceContext = value
            End Set
        End Property

        <Parameter(ParameterSetName:="Add", Mandatory:=True)> _
        Public Property Add() As Integer()
            Get
                Return _values
            End Get
            Set(ByVal value As Integer())
                _values = value
            End Set
        End Property

        Protected Overrides Sub InternalProcessRecord()
            ' Read the specified service context pipebind
            Dim serviceCtx As SPServiceContext = _serviceContext.Read()
            If serviceCtx Is Nothing Then
                WriteError(New InvalidOperationException("Invalid service context."), ErrorCategory.ResourceExists, serviceCtx)

                Return
            Else
                ' Create a new Service client
                Dim client As New CustomServiceClient(serviceCtx)

                ' Validate at least two values were passed in
                If _values.Length < 2 Then
                    WriteError(New InvalidOperationException("A minimum of two values are required for this operation."), ErrorCategory.InvalidArgument, _values)
                Else
                    ' Loop through all values passed in, calling the service app to add them up.
                    Dim sum As Integer = _values(0)
                    For x As Integer = 1 To _values.Length - 1
                        sum = client.Add(sum, _values(x), ExecuteOptions.None)
                    Next

                    ' Write the results
                    WriteObject(sum)
                End If

                ' Result 
                Dim result As String = client.HelloWorld()

                ' Write the sum to the pipeline
                Me.WriteObject(result)
            End If
        End Sub

    End Class
End Namespace

