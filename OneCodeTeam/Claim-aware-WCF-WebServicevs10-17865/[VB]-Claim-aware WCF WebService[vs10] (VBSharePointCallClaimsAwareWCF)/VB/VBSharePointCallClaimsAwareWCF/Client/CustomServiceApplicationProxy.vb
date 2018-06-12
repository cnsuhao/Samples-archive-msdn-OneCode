'************************** Module Header ******************************\
' Module Name:    CustomServiceApplicationProxy.vb
' Project:        VBSharePointCallClaimsAwareWCF
' Copyright (c) Microsoft Corporation
'
' This class is used to define ServiceApplicationProxy
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
Imports System.ServiceModel
Imports Microsoft.SharePoint
Imports Microsoft.SharePoint.Utilities
Imports System.ServiceModel.Configuration
Imports System.ServiceModel.Channels
Imports System.Configuration
Imports System.Runtime.InteropServices

Namespace CustomService
    <IisWebServiceApplicationProxyBackupBehavior()> _
    <Guid("D409CE5C-19BD-4269-8B16-8F3EDCCB1039")> _
    Public NotInheritable Class CustomServiceApplicationProxy
        Inherits SPIisWebServiceApplicationProxy
        Private _channelFactory As ChannelFactory(Of ICustomServiceContract)
        Private _channelFactoryLock As New Object()
        Private _endpointConfigName As String

        <Persisted()> _
        Private _loadBalancer As SPServiceLoadBalancer

#Region "constructors"
        Public Sub New()
        End Sub

        Public Sub New(ByVal name As String, ByVal serviceProxy As CustomServiceProxy, ByVal serviceAppAddress As Uri)
            MyBase.New(name, serviceProxy, serviceAppAddress)
            ' create a new round robin load balancer
            _loadBalancer = New SPRoundRobinServiceLoadBalancer(serviceAppAddress)
        End Sub
#End Region

#Region "app proxy infrastructure"
        Private Function CreateChannelFactory(Of T)(ByVal endpointConfigName As String) As ChannelFactory(Of T)
            ' open client.config
            Dim clientConfigPath As String = SPUtility.GetGenericSetupPath("WebClients\CustomService")
            Dim clientConfig As Configuration = OpenClientConfiguration(clientConfigPath)
            Dim factory As New ConfigurationChannelFactory(Of T)(endpointConfigName, clientConfig, Nothing)

            ' configure the channel factory for IDFx claims auth
            factory.ConfigureCredentials(SPServiceAuthenticationMode.Claims)

            Return factory
        End Function

        Friend Delegate Sub CodeToRunOnApplicationProxy(ByVal appProxy As CustomServiceApplicationProxy)
        Friend Shared Sub Invoke(ByVal serviceContext As SPServiceContext, ByVal codeBlock As CodeToRunOnApplicationProxy)
            If serviceContext Is Nothing Then
                Throw New ArgumentNullException("serviceContext")
            End If

            ' get sample service app proxy from context
            Dim proxy As CustomServiceApplicationProxy = DirectCast(serviceContext.GetDefaultProxy(GetType(CustomServiceApplicationProxy)), CustomServiceApplicationProxy)
            If proxy Is Nothing Then
                Throw New InvalidOperationException("Custom service application proxy not found.")
            End If

            ' ensure the current service context is correctly set
            Using New SPServiceContextScope(serviceContext)
                ' execute the delegate
                codeBlock(proxy)
            End Using
        End Sub

        Private Delegate Sub CodeToRunOnChannel(ByVal serviceContract As ICustomServiceContract)
        Private Sub ExecuteOnChannel(ByVal operationName As String, ByVal options As ExecuteOptions, ByVal codeBlock As CodeToRunOnChannel)
            Using New SPMonitoredScope("ExecuteOnChannel:" & operationName)
                Dim loadBalancerCtx As SPServiceLoadBalancerContext = _loadBalancer.BeginOperation()
                Try
                    ' get a channel to the service app endpoint
                    Dim channel As IChannel = DirectCast(GetChannel(loadBalancerCtx.EndpointAddress, options), IChannel)
                    Try
                        ' execute the delegate
                        codeBlock(DirectCast(channel, ICustomServiceContract))

                        'close the channel
                        channel.Close()
                    Catch generatedExceptionName As TimeoutException
                        loadBalancerCtx.Status = SPServiceLoadBalancerStatus.Failed
                        Throw
                    Catch generatedExceptionName As EndpointNotFoundException
                        loadBalancerCtx.Status = SPServiceLoadBalancerStatus.Failed
                        Throw
                    Finally
                        If channel.State <> CommunicationState.Closed Then
                            channel.Abort()
                        End If
                    End Try
                Finally
                    loadBalancerCtx.EndOperation()
                End Try
            End Using
        End Sub

        ''' <summary>
        ''' Gets the endpoint configuration name for a given endpoint address.
        ''' </summary>
        ''' <param name="address">Endpoint address.</param>
        ''' <returns>The endpoint configuration name.</returns>
        ''' <remarks>The returned endpont must match one of the endpoint element names in the client.config file.</remarks>
        Private Function GetEndpointConfigurationName(ByVal address As Uri) As String
            If address Is Nothing Then
                Throw New ArgumentNullException("address")
            End If

            Dim configName As String

            If address.Scheme = Uri.UriSchemeNetTcp Then
                If address.AbsolutePath.EndsWith("/secure", StringComparison.OrdinalIgnoreCase) Then
                    configName = "tcp-ssl"
                Else
                    configName = "tcp"
                End If
            ElseIf address.Scheme = Uri.UriSchemeHttps Then
                configName = "https"
            ElseIf address.Scheme = Uri.UriSchemeHttp Then
                configName = "http"
            Else
                Throw New NotSupportedException("Unsupported endpoint address.")
            End If

            Return configName
        End Function

        Private Function GetChannel(ByVal address As Uri, ByVal options As ExecuteOptions) As ICustomServiceContract
            ' get the endpoint config name
            Dim endpointConfigName As String = GetEndpointConfigurationName(address)

            ' check for a cached channel factory for the endpoint config
            If (_channelFactory Is Nothing) OrElse (endpointConfigName <> _endpointConfigName) Then
                SyncLock _channelFactoryLock
                    ' create a channel factory using the default endpoing config name
                    _channelFactory = CreateChannelFactory(Of ICustomServiceContract)(endpointConfigName)

                    ' cache the endpoint config name
                    _endpointConfigName = endpointConfigName
                End SyncLock
            End If

            Dim channel As ICustomServiceContract

            If ExecuteOptions.AsProcess = (options And ExecuteOptions.AsProcess) Then
                ' create a channel that acts as the service's process user when authenticating with the service
                channel = _channelFactory.CreateChannelAsProcess(New EndpointAddress(address))
            Else
                ' create a channel that acts as the loged on user when authenticating with the service
                channel = _channelFactory.CreateChannelActingAsLoggedOnUser(New EndpointAddress(address))
            End If

            ' create a channel from the factory
            Return channel
        End Function
#End Region

        Public Overrides ReadOnly Property TypeName() As String
            Get
                Return "Custom Service Application Proxy"
            End Get
        End Property

        Public Overrides Sub Provision()
            _loadBalancer.Provision()
            MyBase.Provision()
            Me.Update()
        End Sub

        Public Overrides Sub Unprovision(ByVal deleteData As Boolean)
            _loadBalancer.Unprovision()
            MyBase.Unprovision(deleteData)
            Me.Update()
        End Sub

        ''' <summary>
        ''' Client method executed on WFE (front-end), for example, by a web part.
        ''' </summary>
#Region "service app methods"
        Public Function Add(ByVal a As Integer, ByVal b As Integer, ByVal options As ExecuteOptions) As Integer
            Dim result As Integer = 0

            ExecuteOnChannel("Add", options, Function(proxy) InlineAssignHelper(result, proxy.Add(a, b)))

            Return result
        End Function

        Public Function HelloWorld(ByVal options As ExecuteOptions) As String
            Dim result As String = String.Empty

            ' Execute the service application method
            Me.ExecuteOnChannel("HelloWorld", options, Function(proxy) InlineAssignHelper(result, proxy.HelloWorld()))

            Return result
        End Function

        Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
            target = value
            Return value
        End Function
#End Region
    End Class
End Namespace

