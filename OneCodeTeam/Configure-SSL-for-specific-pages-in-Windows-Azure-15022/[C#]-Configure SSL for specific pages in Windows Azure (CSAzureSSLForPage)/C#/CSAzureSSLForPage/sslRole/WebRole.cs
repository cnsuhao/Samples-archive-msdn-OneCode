/****************************** Module Header ******************************\
* Module Name: WebRole.cs
* Project:     sslRole
* Copyright (c) Microsoft Corporation.
* 
* While hosting the applications in Azure, developers are required to modify IIS 
* settings to suit their application requirements. Many of these IIS settings can 
* be modified only programmatically and developers are required to write code, 
* startup tasks to achieve what they are looking for. One common things customers 
* do while hosting the applications on-premise is to mix the SSL content with 
* non-SSL content. In Azure, by default you can enable SSL for entire site. There
* is no provision to enable SSL only for few pages. Hence, I have written this sample 
* that can be used it with out investing more time to achieve the task.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.Web.Administration;
namespace sslRole
{
    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            // Create new ServerManager object to modify IIS7 configuration
            ServerManager serverManager = new ServerManager();

            // Retrieve Current Application Host Configuration of IIS
            Configuration config = serverManager.GetApplicationHostConfiguration();
            
            // Since we are looking to enable SSL for only specific page, get the section 
            // of configuration which needs to be changed for specific location
            // Website name can be obtained using  RoleEnvironment.CurrentRoleInstance.Id 
            // and then append "_" along with actual site name specified in ServiceDefinition.csdef
            // Default name of the website is Web. If you have specified different sitename, 
            // please replace "Web" with the specified name in below line of code.
            ConfigurationSection section = config.GetSection("system.webServer/security/access",
                RoleEnvironment.CurrentRoleInstance.Id + "_Web" + "/sslpage.aspx");
            
            // Get the sslFlags attribute which is used for configuring SSL settings
            ConfigurationAttribute enabled = section.GetAttribute("sslFlags");
            
            // Configure sslFlags value as "ssl". This will enable "Require SSL" flag
            enabled.Value = "Ssl";
            
            // Save the changes. If role is not running under elevated executionContext, 
            // this line will result in exception.
            serverManager.CommitChanges();

            return base.OnStart();
        }
    }
}
