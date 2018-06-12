/****************************** Module Header ******************************\
* Module Name:    CustomServiceApplicationProxy.cs
* Project:        CSSharePointCallClaimsAwareWCF
* Copyright (c) Microsoft Corporation
*
* This class is used to define ServiceApplicationProxy
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Administration;
using System.ServiceModel;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System.ServiceModel.Configuration;
using System.ServiceModel.Channels;
using System.Configuration;
using System.Runtime.InteropServices;

namespace CustomService
{
    [IisWebServiceApplicationProxyBackupBehavior]
    [Guid("D409CE5C-19BD-4269-8B16-8F3EDCCB1039")]
    public sealed class CustomServiceApplicationProxy : SPIisWebServiceApplicationProxy
    {
        private ChannelFactory<ICustomServiceContract> _channelFactory;
        private object _channelFactoryLock = new object();
        private string _endpointConfigName;

        [Persisted]
        private SPServiceLoadBalancer _loadBalancer;

        #region constructors
        public CustomServiceApplicationProxy() { }

        public CustomServiceApplicationProxy(string name, CustomServiceProxy serviceProxy, Uri serviceAppAddress)
            : base(name, serviceProxy, serviceAppAddress)
        {
            // create a new round robin load balancer
            _loadBalancer = new SPRoundRobinServiceLoadBalancer(serviceAppAddress);
        }
        #endregion

        #region app proxy infrastructure
        private ChannelFactory<T> CreateChannelFactory<T>(string endpointConfigName)
        {
            // open client.config
            string clientConfigPath = SPUtility.GetGenericSetupPath(@"WebClients\CustomService");
            Configuration clientConfig = OpenClientConfiguration(clientConfigPath);
            ConfigurationChannelFactory<T> factory = new ConfigurationChannelFactory<T>(endpointConfigName, clientConfig, null);

            // configure the channel factory for IDFx claims auth
            factory.ConfigureCredentials(SPServiceAuthenticationMode.Claims);

            return factory;
        }

        internal delegate void CodeToRunOnApplicationProxy(CustomServiceApplicationProxy appProxy);
        internal static void Invoke(SPServiceContext serviceContext, CodeToRunOnApplicationProxy codeBlock)
        {
            if (serviceContext == null)
                throw new ArgumentNullException("serviceContext");

            // get sample service app proxy from context
            CustomServiceApplicationProxy proxy = (CustomServiceApplicationProxy)serviceContext.GetDefaultProxy(typeof(CustomServiceApplicationProxy));
            if (proxy == null)
                throw new InvalidOperationException("Custom service application proxy not found.");

            // ensure the current service context is correctly set
            using (new SPServiceContextScope(serviceContext))
            {
                // execute the delegate
                codeBlock(proxy);
            }
        }

        private delegate void CodeToRunOnChannel(ICustomServiceContract serviceContract);
        private void ExecuteOnChannel(string operationName, ExecuteOptions options, CodeToRunOnChannel codeBlock)
        {
            using (new SPMonitoredScope("ExecuteOnChannel:" + operationName))
            {
                SPServiceLoadBalancerContext loadBalancerCtx = _loadBalancer.BeginOperation();
                try
                {
                    // get a channel to the service app endpoint
                    IChannel channel = (IChannel)GetChannel(loadBalancerCtx.EndpointAddress, options);
                    try
                    {
                        // execute the delegate
                        codeBlock((ICustomServiceContract)channel);

                        //close the channel
                        channel.Close();
                    }
                    catch (TimeoutException)
                    {
                        loadBalancerCtx.Status = SPServiceLoadBalancerStatus.Failed;
                        throw;
                    }
                    catch (EndpointNotFoundException)
                    {
                        loadBalancerCtx.Status = SPServiceLoadBalancerStatus.Failed;
                        throw;
                    }
                    finally
                    {
                        if (channel.State != CommunicationState.Closed)
                            channel.Abort();
                    }
                }
                finally
                {
                    loadBalancerCtx.EndOperation();
                }
            }
        }

        /// <summary>
        /// Gets the endpoint configuration name for a given endpoint address.
        /// </summary>
        /// <param name="address">Endpoint address.</param>
        /// <returns>The endpoint configuration name.</returns>
        /// <remarks>The returned endpont must match one of the endpoint element names in the client.config file.</remarks>
        private string GetEndpointConfigurationName(Uri address)
        {
            if (address == null)
                throw new ArgumentNullException("address");

            string configName;

            if (address.Scheme == Uri.UriSchemeNetTcp)
            {
                if (address.AbsolutePath.EndsWith("/secure", StringComparison.OrdinalIgnoreCase))
                    configName = "tcp-ssl";
                else configName = "tcp";
            }
            else if (address.Scheme == Uri.UriSchemeHttps)
                configName = "https";
            else if (address.Scheme == Uri.UriSchemeHttp)
                configName = "http";
            else
                throw new NotSupportedException("Unsupported endpoint address.");

            return configName;
        }

        private ICustomServiceContract GetChannel(Uri address, ExecuteOptions options)
        {
            // get the endpoint config name
            string endpointConfigName = GetEndpointConfigurationName(address);

            // check for a cached channel factory for the endpoint config
            if ((_channelFactory == null) || (endpointConfigName != _endpointConfigName))
            {
                lock (_channelFactoryLock)
                {
                    // create a channel factory using the default endpoing config name
                    _channelFactory = CreateChannelFactory<ICustomServiceContract>(endpointConfigName);

                    // cache the endpoint config name
                    _endpointConfigName = endpointConfigName;
                }
            }

            ICustomServiceContract channel;

            if (ExecuteOptions.AsProcess == (options & ExecuteOptions.AsProcess))
                // create a channel that acts as the service's process user when authenticating with the service
                channel = _channelFactory.CreateChannelAsProcess<ICustomServiceContract>(new EndpointAddress(address));
            else
                // create a channel that acts as the loged on user when authenticating with the service
                channel = _channelFactory.CreateChannelActingAsLoggedOnUser<ICustomServiceContract>(new EndpointAddress(address));

            // create a channel from the factory
            return channel;
        }
        #endregion

        public override string TypeName
        {
            get { return "Custom Service Application Proxy"; }
        }

        public override void Provision()
        {
            _loadBalancer.Provision();
            base.Provision();
            this.Update();
        }

        public override void Unprovision(bool deleteData)
        {
            _loadBalancer.Unprovision();
            base.Unprovision(deleteData);
            this.Update();
        }

        /// <summary>
        /// Client method executed on WFE (front-end), for example, by a web part.
        /// </summary>
        #region service app methods
        public int Add(int a, int b, ExecuteOptions options)
        {
            int result = 0;

            ExecuteOnChannel("Add", options, delegate(ICustomServiceContract channel)
            {
                result = channel.Add(a, b);
            });

            return result;
        }

        public string HelloWorld(ExecuteOptions options)
        {
            string result = string.Empty;

            // Execute the service application method
            this.ExecuteOnChannel("HelloWorld", options, delegate(ICustomServiceContract channel)
            {
                result = channel.HelloWorld();
            });               

            return result;
        }
        #endregion
    }
}