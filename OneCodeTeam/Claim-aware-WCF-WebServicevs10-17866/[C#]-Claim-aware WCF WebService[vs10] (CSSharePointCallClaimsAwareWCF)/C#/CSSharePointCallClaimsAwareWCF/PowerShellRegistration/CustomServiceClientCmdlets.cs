/****************************** Module Header ******************************\
* Module Name:    CustomServiceClientCmdlets.cs
* Project:        CSSharePointCallClaimsAwareWCF
* Copyright (c) Microsoft Corporation
*
* This class is used to host the Client PowerShellRegistration
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
using Microsoft.SharePoint.PowerShell;
using System.Management.Automation;
using Microsoft.SharePoint.Administration;
using CustomService;
using Microsoft.SharePoint;

namespace CustomService.PowerShell
{
    [Cmdlet(VerbsLifecycle.Install, "CustomServiceProxy", SupportsShouldProcess = true)]
    public class InstallCustomServiceProxy : SPCmdlet
    {
        protected override bool RequireUserFarmAdmin()
        {
            return true;
        }

        protected override void InternalProcessRecord()
        {
            #region validation stuff

            SPFarm farm = SPFarm.Local;
            if (farm == null)
                ThrowTerminatingError(new InvalidOperationException("SharePoint farm not found."), ErrorCategory.ResourceUnavailable, this);

            SPServer server = SPServer.Local;
            if (farm == null)
                ThrowTerminatingError(new InvalidOperationException("SharePoint local server not found."), ErrorCategory.ResourceUnavailable, this);

            #endregion

            // Install the service proxy into the farm if it's not installed.
            if (ShouldProcess("Custom Service Proxy"))
            {
                CustomServiceProxy serviceProxy = farm.ServiceProxies.GetValue<CustomServiceProxy>();

                if (serviceProxy == null)
                {
                    serviceProxy = new CustomServiceProxy(farm);
                    serviceProxy.Update(true);
                }
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "CustomServiceApplicationProxy", SupportsShouldProcess = true)]
    public class NewCustomServiceApplicationProxy : SPCmdlet
    {
        private string _name;
        private Uri _uri;
        private SPServiceApplicationPipeBind _pipeBind;

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Parameter(Mandatory = true, ParameterSetName = "Uri")]
        [ValidateNotNullOrEmpty]
        public string Uri
        {
            get { return _uri.ToString(); }
            set { _uri = new Uri(value); }
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "ServiceApplication")]
        public SPServiceApplicationPipeBind ServiceApplication
        {
            get { return _pipeBind; }
            set { _pipeBind = value; }
        }

        protected override bool RequireUserFarmAdmin()
        {
            return true;
        }

        protected override void InternalProcessRecord()
        {
            #region validation stuff
            // ensure can hit farm
            SPFarm farm = SPFarm.Local;
            if (farm == null)
            {
                ThrowTerminatingError(new InvalidOperationException("SharePoint farm not found."), ErrorCategory.ResourceUnavailable, this);
                SkipProcessCurrentRecord();
            }

            // ensure the service proxy is installed
            CustomServiceProxy serviceProxy = farm.ServiceProxies.GetValue<CustomServiceProxy>();
            if (serviceProxy == null)
            {
                ThrowTerminatingError(new InvalidOperationException("Custom service application proxy not found."), ErrorCategory.NotInstalled, this);
            }

            // ensure the proxy isn't already created
            CustomServiceApplicationProxy existingServiceAppProxy = serviceProxy.ApplicationProxies.GetValue<CustomServiceApplicationProxy>();
            if (existingServiceAppProxy != null)
            {
                WriteError(new InvalidOperationException("Custom service application proxy already exists."), ErrorCategory.ResourceExists, existingServiceAppProxy);
                // skip this command
                SkipProcessCurrentRecord();
            }
            #endregion

            Uri serviceAppUri = null;
            if (ParameterSetName == "Uri")
                serviceAppUri = _uri;
            else if (ParameterSetName == "ServiceApplication")
            {
                SPServiceApplication serviceApp = _pipeBind.Read();
                if (serviceApp == null)
                {
                    WriteError(new InvalidOperationException("Service application not found."), ErrorCategory.ResourceExists, serviceApp);
                    SkipProcessCurrentRecord();
                }

                ISharedServiceApplication sharedServiceApp = serviceApp as ISharedServiceApplication;
                if (sharedServiceApp == null)
                {
                    WriteError(new InvalidOperationException("Connecting to specified service application is not supported."), ErrorCategory.ResourceExists, serviceApp);
                    SkipProcessCurrentRecord();
                }

                serviceAppUri = sharedServiceApp.Uri;
            }
            else
                ThrowTerminatingError(new InvalidOperationException("Invalid parameter set."), ErrorCategory.InvalidArgument, this);

            if ((serviceAppUri != null) && ShouldProcess(Name))
            {
                // Create service app proxy
                CustomServiceApplicationProxy serviceAppProxy = new CustomServiceApplicationProxy(Name, serviceProxy, serviceAppUri);

                // Provision the sample service app proxy
                serviceAppProxy.Provision();

                // Write new sample service app proxy to pipeline
                WriteObject(serviceAppProxy);
            }

        }
    }

    [Cmdlet("Invoke", "CustomService", SupportsShouldProcess = true)]
    public class InvokeCustomService : SPCmdlet
    {
        private int[] _values;
        private SPServiceContextPipeBind _serviceContext;

        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0)]
        public SPServiceContextPipeBind ServiceContext
        {
            get { return _serviceContext; }
            set { _serviceContext = value; }
        }

        [Parameter(ParameterSetName = "Add", Mandatory = true)]
        public int[] Add
        {
            get { return _values; }
            set { _values = value; }
        }

        protected override void InternalProcessRecord()
        {
            // Read the specified service context pipebind
            SPServiceContext serviceCtx = _serviceContext.Read();
            if (serviceCtx == null)
            {
                WriteError(new InvalidOperationException("Invalid service context."),
                    ErrorCategory.ResourceExists, serviceCtx);

                return;
            }
            else
            {
                // Create a new Service client
                CustomServiceClient client = new CustomServiceClient(serviceCtx);

                // Validate at least two values were passed in
                if (_values.Length < 2)
                    WriteError(new InvalidOperationException("A minimum of two values are required for this operation."), ErrorCategory.InvalidArgument, _values);
                else
                {
                    // Loop through all values passed in, calling the service app to add them up.
                    int sum = _values[0];
                    for (int x = 1; x < _values.Length; x++)
                        sum = client.Add(sum, _values[x], ExecuteOptions.None);

                    // Write the results
                    WriteObject(sum);
                }

                // Result 
                string result = client.HelloWorld();

                // Write the sum to the pipeline
                this.WriteObject(result);
            }
        }

    }
}
