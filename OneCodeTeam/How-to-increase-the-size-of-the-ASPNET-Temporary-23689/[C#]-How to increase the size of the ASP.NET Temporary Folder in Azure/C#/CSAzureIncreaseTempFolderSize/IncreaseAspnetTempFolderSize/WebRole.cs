/****************************** Module Header ******************************\
Module Name:  WebRole.cs
Project:      IncreaseAspnetTempFolderSize
Copyright (c) Microsoft Corporation.

Increase the size of Asp.net Temporary folder in Azure. 
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
using System;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.Web.Administration;

namespace IncreaseAspnetTempFolderSize
{
    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.
            
            // Get the location of the AspNetTemp1GB resource     
            Microsoft.WindowsAzure.ServiceRuntime.LocalResource aspNetTempFolder = 
                Microsoft.WindowsAzure.ServiceRuntime.RoleEnvironment.GetLocalResource("AspNetTemp1GB");   
    
            //Instantiate the IIS ServerManager     
            ServerManager iisManager = new ServerManager();     

            // Get the website.  Note that "_Web" is the name of the site in the ServiceDefinition.csdef, 
            // so make sure you change this code if you change the site name in the .csdef     
            Application app = iisManager.Sites[RoleEnvironment.CurrentRoleInstance.Id + "_Web"].Applications[0];    
 
            // Get the web.config for the site     
            Configuration webHostConfig = app.GetWebConfiguration();     

            // Get a reference to the system.web/compilation element     
            ConfigurationSection compilationConfiguration = webHostConfig.GetSection("system.web/compilation");  
   
            // Set the tempDirectory property to the AspNetTemp1GB folder     
            compilationConfiguration.Attributes["tempDirectory"].Value = aspNetTempFolder.RootPath;   
  
            // Commit the changes     
            iisManager.CommitChanges();

            return base.OnStart();
        }
    }
}
