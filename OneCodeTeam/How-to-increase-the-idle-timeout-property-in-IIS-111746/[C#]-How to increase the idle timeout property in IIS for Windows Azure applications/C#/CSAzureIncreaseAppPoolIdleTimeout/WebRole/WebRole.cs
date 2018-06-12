/***************************** Module Header ******************************\
* Module Name:	WebRole.cs
* Project:		WebRole
* Copyright (c) Microsoft Corporation.
* 
* App-pool Idle Time-out is the amount of time (in minutes) a worker process 
* will remain idle before it shuts down. A worker process is idle if it is 
* not processing requests and no new requests are received.   
* Idle Time-out property can be changed in IIS after you RDP into the VM's of
* Azure, but this is not recommended and remote desktop must be used only
* for basic troubleshooting. Any changes done on the Virtual Machine manually
* after RDP will not be persisted.This is because, in the event of any hardware 
* failure or automatic OS upgrade in Azure cloud, Fabric controller will bring 
* down the VM instance and automatically deploy your package on another VM/on 
* the same VM (Virtual machine). If this happens all the changes done manually 
* on the VM will be lost. Therefore the recommended approach is to perform all 
* the operation by code and deploy the package.
* You can implement this by using ServerManager class defined in Microsoft.Web.Administration DLL.
*
* WebRole.cs
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\**************************************************************************/

using System;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.Web.Administration;


namespace WebRole
{
    public class WebRole : RoleEntryPoint
    {

        public override bool OnStart()
        {
            ServerManager iisManager = new ServerManager();
            Application app = iisManager.Sites[RoleEnvironment.CurrentRoleInstance.Id + "_Web"].Applications[0];

            //================ idle timeout ====================================================//               
            string dt = iisManager.ApplicationPoolDefaults.ProcessModel.IdleTimeout.ToString();
            TimeSpan ts = new TimeSpan(0, 60, 00);
            iisManager.ApplicationPoolDefaults.ProcessModel.IdleTimeout = ts;



            //================ Enable or disable static/Dynamic compression ===================//
            Configuration config = iisManager.Sites[RoleEnvironment.CurrentRoleInstance.Id + "_Web"].GetWebConfiguration();
            ConfigurationSection urlCompressionSection = config.GetSection("system.webServer/urlCompression");
            urlCompressionSection["doStaticCompression"] = true;
            urlCompressionSection["doDynamicCompression"] = true;

            //================ To change Application pool name ================================//

            app.ApplicationPoolName = "ASP.NET v4.0 Classic";
            // Commit the changes done to server manager. 

            iisManager.CommitChanges();

            return base.OnStart();

        }

    }

}