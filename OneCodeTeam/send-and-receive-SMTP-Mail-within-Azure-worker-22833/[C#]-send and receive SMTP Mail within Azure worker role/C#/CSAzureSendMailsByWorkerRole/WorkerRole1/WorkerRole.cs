/****************************** Module Header ******************************\
Module Name:  WorkerRole.cs
Project:      CSAzureSendMailsByWorkerRole
Copyright (c) Microsoft Corporation.
 
As you know, System.Net.Mail api can't be used in Windows Runtime application, 
However, we can create a WCF service to consume the api, and hold this service 
on Azure.

In this way, we can use this service to send email in Windows Store app. 

A workrole holds the SMTP sending mail service.
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System.Diagnostics;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure.ServiceRuntime;
using System.ServiceModel;
using MailService;


namespace WorkerRole1
{
    public class WorkerRole : RoleEntryPoint
    {
        public override void Run()
        {
            // This is a sample worker implementation. Replace with your logic.
            while (true)
            {
                Thread.Sleep(10000);
                Trace.WriteLine("Working", "Information");
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            // Start the WCF host.
            ServiceHost host = new ServiceHost(typeof(MailOperationService));
            host.Open();

            return base.OnStart();
        }
    }
}
