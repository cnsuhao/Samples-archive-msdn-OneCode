/****************************** Module Header ******************************\
* Module Name:    CustomServiceCmdlets.cs
* Project:        CSSharePointCallClaimsAwareWCF
* Copyright (c) Microsoft Corporation
*
* This class is used to host the Service PowerShellRegistration
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
using System.Net;

namespace CustomService.PowerShell
{
    [Cmdlet(VerbsLifecycle.Install, "CustomService", SupportsShouldProcess = true)]
    public class InstallCustomService : SPCmdlet
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



            if (ShouldProcess("Custom Service"))
            {
                // Ensure the custom service exists
                CustomService service = farm.Services.GetValue<CustomService>();

                // If the service is NOT already installed, install it.
                if (service == null)
                {
                    // Create the service
                    service = new CustomService(farm);
                    service.Update();
                }

                // With the service added to the farm, see if there is a running instance on the server... 
                // if not, create it.
                CustomServiceInstance serverSvcInstance = new CustomServiceInstance(server, service);
                serverSvcInstance.Update(true);
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "CustomServiceApplication", SupportsShouldProcess = true)]
    public class NewCustomServiceApplication : SPCmdlet
    {
        private const string DbPrefix = "CustomService";

        #region Cmdlet Parameters
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name;

        // The SPIisWebServiceApplicationPoolPipeBind parameter accepts a service
        // application pool object, which can be created by the New-SPServiceApplicationPool
        // cmdlet. Alternatively, an administration can use the Get-SPServiceApplicationPool
        // cmdlet to select an existing service application pool to be used for the new
        // service application.
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public SPIisWebServiceApplicationPoolPipeBind ApplicationPool;

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string DatabaseServer;

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string FailoverDatabaseServer;

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string DatabaseName;

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public PSCredential DatabaseCredentials;
        #endregion

        protected override bool RequireUserFarmAdmin()
        {
            return true;
        }

        /// <summary>
        /// The InternalProcessRecord method is where the work happens.
        /// </summary>
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

            // ensure can hit local server
            SPServer server = SPServer.Local;
            if (farm == null)
            {
                ThrowTerminatingError(new InvalidOperationException("SharePoint local server not found."), ErrorCategory.ResourceUnavailable, this);
                SkipProcessCurrentRecord();
            }

            // ensure can hit service application
            CustomService service = farm.Services.GetValue<CustomService>();
            if (service == null)
            {
                ThrowTerminatingError(new InvalidOperationException("Custom Service not found (likely not installed)."), ErrorCategory.ResourceUnavailable, this);
                SkipProcessCurrentRecord();
            }

            // ensure can hit app pool
            SPIisWebServiceApplicationPool appPool = this.ApplicationPool.Read();
            if (appPool == null)
            {
                ThrowTerminatingError(new InvalidOperationException("Application pool not found."), ErrorCategory.ResourceUnavailable, this);
                SkipProcessCurrentRecord();
            }

            // ensure can hit database
            string dbServer = this.DatabaseServer;
            if (string.IsNullOrEmpty(dbServer))
            {
                dbServer = SPWebService.ContentService.DefaultDatabaseInstance.NormalizedDataSource;
            }
            #endregion

            // Ensure a service application does not already exist
            CustomServiceApplication existingCustomServiceApp = service.Applications.GetValue<CustomServiceApplication>();
            if (existingCustomServiceApp != null)
            {
                WriteError(new InvalidOperationException("Custom service application already exists."),
                    ErrorCategory.ResourceExists,
                    existingCustomServiceApp);
                SkipProcessCurrentRecord();
            }

            // Get database credentials
            string dbUsername = null;
            string dbPassword = null;
            if (DatabaseCredentials != null)
            {
                NetworkCredential dbCredential = (NetworkCredential)DatabaseCredentials;
                dbUsername = dbCredential.UserName;
                dbPassword = dbCredential.Password;
            }

            SPDatabaseParameterOptions dbOptions = SPDatabaseParameterOptions.None;

            // Get database name
            string dbName = DatabaseName;
            if (dbName == null)
            {
                dbName = "CustomServiceDB";
                dbOptions = SPDatabaseParameterOptions.GenerateUniqueName;
            }

            // Create settings for a new database
            SPDatabaseParameters dbParameters = SPDatabaseParameters.CreateParameters(
                dbName,
                dbServer,
                dbUsername,
                dbPassword,
                FailoverDatabaseServer,
                dbOptions);

            // Create & provision the service application 
            if (ShouldProcess(this.Name))
            {
                CustomServiceApplication serviceApp = CustomServiceApplication.Create(
                    this.Name,
                    service,
                    appPool,
                    dbParameters);

                // Provision the service app
                serviceApp.Provision();

                // Writes the new service application object out to the PowerShell pipeline
                // where it can be piped as input to the next cmdlet in the pipeline.
                WriteObject(serviceApp);
            }
        }
    }
}
