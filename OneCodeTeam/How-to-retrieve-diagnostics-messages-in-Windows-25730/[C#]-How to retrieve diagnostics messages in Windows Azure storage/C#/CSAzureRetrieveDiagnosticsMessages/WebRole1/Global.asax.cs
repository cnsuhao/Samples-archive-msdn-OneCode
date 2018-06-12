using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Diagnostics;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;

namespace CSAzureRetrieveDiagnosticsMessages_WebRole
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

            // This code sets up a handler to update CloudStorageAccount instances when their corresponding
            // configuration settings change in the service configuration file.
            CloudStorageAccount.SetConfigurationSettingPublisher((configName, configSetter) =>
            {
                // Provide the configSetter with the initial value
                configSetter(RoleEnvironment.GetConfigurationSettingValue(configName));
            });

            /// Create data table from MessageDataServiceContext
            /// It is recommended the data tables should be only created once. It is typically done as a 
            /// provisioning step and rarely in application code.
            var account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
            //Add this message to Windows Azure Logs and it will transfer to WADLogsTable(table)
            System.Diagnostics.Trace.WriteLine("Application start");
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}