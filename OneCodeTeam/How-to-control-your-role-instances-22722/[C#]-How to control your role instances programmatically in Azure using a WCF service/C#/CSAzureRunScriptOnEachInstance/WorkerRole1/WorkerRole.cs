/****************************** Module Header ******************************\
Module Name:  WorkerRole.cs
Project:      WorkerRole1
Copyright (c) Microsoft Corporation.
 
This application shows how to run your cmd script or other executable
file on each worker role instance.

Host the WCF service on local.
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.WindowsAzure.ServiceRuntime;
using System.ServiceModel;
using InstanceController.Interface;
using System.ServiceModel.Description;



namespace WorkerRole1
{
    public class WorkerRole : RoleEntryPoint
    {
        public override void Run()
        {
            // This is a sample worker implementation. Replace with your logic.
            Trace.WriteLine("WorkerRole1 entry point called", "Information");

            while (true)
            {
                Thread.Sleep(10000);
                Trace.WriteLine("Working", "Information");
            }
        }

        public override bool OnStart()
        {
            var internalEndPoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["InternalEndPoint"];

            ServiceHost host = new ServiceHost(typeof(InstanceControllerService));
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Security.Mode = BasicHttpSecurityMode.None;

            host.AddServiceEndpoint(typeof(IInstanceController), binding, string.Format("http://{0}/InternalService", internalEndPoint.IPEndpoint));
            if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
            {
                ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                behavior.HttpGetEnabled = true;
                behavior.HttpGetUrl = new Uri(string.Format("http://{0}/InternalService/metadata", internalEndPoint.IPEndpoint));
                host.Description.Behaviors.Add(behavior);
            }
         
            host.Open();
            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            return base.OnStart();
        }
    }
}
