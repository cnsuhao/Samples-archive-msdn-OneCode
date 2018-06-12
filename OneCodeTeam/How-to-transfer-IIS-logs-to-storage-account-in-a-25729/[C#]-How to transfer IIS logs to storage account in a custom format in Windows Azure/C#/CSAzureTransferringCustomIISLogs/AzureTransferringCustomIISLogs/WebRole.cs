/****************************** Module Header ******************************\
* Module Name:  WebRoles.cs
* Project:      AzureTransferringCustomIISLogs
* Copyright (c) Microsoft Corporation.
*  
* Because any log file transfer to Azure storage are billable ,custom log file 
* before transfer will help you save money. This sample will show you how to 
* custom IIS logs in your Azure web role. This is a frequently asked question in forum,
* so we provide this sample code to show how to achieve this in .NET.
* 
* This class shows how to use ServerManager Class costom IIS log before transfer to 
* storage.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
* All other rights reserved.
*  
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Linq;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.Web.Administration;

namespace AzureTransferringCustomIISLogs
{
    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            // Get this connection string in web role's setting tab
            string storageConnectionString = "Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString";
            
            // Get default config
            DiagnosticMonitorConfiguration config = DiagnosticMonitor.GetDefaultInitialConfiguration();
            
            // Transfer the IIS and IIS Failed Request Logs
            config.Directories.ScheduledTransferPeriod = TimeSpan.FromMinutes(1.0);

            // Custom diagnostic logging
            //using (ServerManager serverManager = new ServerManager())
            //{
            //    // Get the website.
            //    // First make sure your cloud programe use IIS Web Server not IIS express.
            //    // Note that "_Web" is the name of the site in the ServiceDefinition.csdef,
            //    // so make sure you change this code if you change the site name in the .csdef
            //    Site site = serverManager.Sites[RoleEnvironment.CurrentRoleInstance.Id + "_Web"];
            //    site.LogFile.LogExtFileFlags = LogExtFileFlags.Date | LogExtFileFlags.Time 
            //        | LogExtFileFlags.ClientIP | LogExtFileFlags.Host | LogExtFileFlags.BytesSent 
            //        | LogExtFileFlags.BytesRecv;
            //    site.LogFile.Period = LoggingRolloverPeriod.Hourly;
            //    serverManager.CommitChanges();
            //}

            DiagnosticMonitor.Start(storageConnectionString, config);
            RoleEnvironment.Changing += RoleEnvironmentChanging;

            return base.OnStart();
        }

        private void RoleEnvironmentChanging(object sender, RoleEnvironmentChangingEventArgs e)
        {
            if (e.Changes.Any(change => change is RoleEnvironmentConfigurationSettingChange))
                e.Cancel = true;
        }
    }
}

