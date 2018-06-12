/****************************** Module Header ******************************\
Module Name:  WebRoles.cs
Project:      CSAzureRetrieveDiagnosticsMessages
Copyright (c) Microsoft Corporation.
 
This programe will show you how to retrieve diagnostics message and transfer them 
to Azure storage. And also it will show you how to view both logs in Table and logs
in blob.
 
This class shows how to transfer logs to Azure storage. 
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using System.Diagnostics;
using Microsoft.Web.Administration;

namespace CSAzureRetrieveDiagnosticsMessages_WebRole
{
    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            DiagnosticMonitorConfiguration config = DiagnosticMonitor.GetDefaultInitialConfiguration();

            // Windows Performance Counters
            List<string> counters = new List<string>();
            counters.Add(@"\Processor(_Total)\% Processor Time");
            counters.Add(@"\Memory\Available Mbytes");
            counters.Add(@"\TCPv4\Connections Established");
            counters.Add(@"\ASP.NET Applications(__Total__)\Requests/Sec");
            counters.Add(@"\Network Interface(*)\Bytes Received/sec");
            counters.Add(@"\Network Interface(*)\Bytes Sent/sec");
            foreach (string counter in counters)
            {
                PerformanceCounterConfiguration counterConfig = new PerformanceCounterConfiguration();
                counterConfig.CounterSpecifier = counter;
                counterConfig.SampleRate = TimeSpan.FromMinutes(5);
                config.PerformanceCounters.DataSources.Add(counterConfig);
            }
            config.PerformanceCounters.ScheduledTransferPeriod = TimeSpan.FromMinutes(5);

            // Windows Event Logs
            // WADWindowsEventLogsTable
            config.WindowsEventLog.DataSources.Add("System!*");
            
            // WADLogsTable
            config.WindowsEventLog.DataSources.Add("Application!*");
            config.WindowsEventLog.ScheduledTransferPeriod = TimeSpan.FromMinutes(1.0);
            config.WindowsEventLog.ScheduledTransferLogLevelFilter = LogLevel.Verbose;

            // Azure Trace Logs
            config.Logs.ScheduledTransferPeriod = TimeSpan.FromMinutes(1.0);
            config.Logs.ScheduledTransferLogLevelFilter = LogLevel.Verbose;
            
            // Crash Dumps
            CrashDumps.EnableCollection(true);

            // IIS Logs
            config.Directories.ScheduledTransferPeriod = TimeSpan.FromMinutes(1);
            Trace.WriteLine("WAD Monitor started", "Information");
            DiagnosticMonitor.Start("Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString", config);
            RoleEnvironment.Changing += RoleEnvironmentChanging;

            // Enabled IIS faild request logs.
            // This log file only generate after you have a faild request.
            using (ServerManager serverManager = new ServerManager())
            {
                Configuration iisConfig = serverManager.GetApplicationHostConfiguration();

                ConfigurationSection sitesSection = iisConfig.GetSection("system.applicationHost/sites");

                ConfigurationElement siteDefaultsElement = sitesSection.GetChildElement("siteDefaults");

                ConfigurationElement logFileElement = siteDefaultsElement.GetChildElement("logFile");
                logFileElement["enabled"] = true;


                serverManager.CommitChanges();
            }
            return base.OnStart();
        }

        private void RoleEnvironmentChanging(object sender, RoleEnvironmentChangingEventArgs e)
        {
            if (e.Changes.Any(change => change is RoleEnvironmentConfigurationSettingChange))
                e.Cancel = true;
        }
    }
}
