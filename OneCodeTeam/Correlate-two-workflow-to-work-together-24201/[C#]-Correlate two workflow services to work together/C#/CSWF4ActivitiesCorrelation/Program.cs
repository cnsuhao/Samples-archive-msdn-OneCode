/***************************** Module Header ******************************\
* Module Name:	Program.cs
* Project:		CSWF4ActivitiesCorrelation
* Copyright (c) Microsoft Corporation.
* 
* This sample shows how to correlate two workflow services to work together.
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
using System.Activities.DurableInstancing;
using System.Configuration;
using System.Threading;
using System.ServiceModel.Activities;

namespace CSWF4ActivitiesCorrelation
{

    class Program
    {
        static void Main(string[] args)
        {
            Uri wfAddress = new Uri(@"http://localhost:8000/WFServices");
            AutoResetEvent waitHandler = new AutoResetEvent(false);
            using (WorkflowServiceHost host =
                new WorkflowServiceHost(new Workflow1(), wfAddress))
            {
                host.WorkflowExtensions.Add(SetupSimplySqlPersistenceStore());
                host.Closed += (obj, arg) =>
                {
                    waitHandler.Set();
                };
                host.Open();
                Console.WriteLine(@"http://localhost:8000/WFServices is opening");
                waitHandler.WaitOne();
            }
        }

        private static SqlWorkflowInstanceStore SetupSimplySqlPersistenceStore()
        {
            string connectionString =
                ConfigurationManager.AppSettings["SqlWF4PersistenceConnectionString"].ToString();
            SqlWorkflowInstanceStore sqlInstanceStore =
                new SqlWorkflowInstanceStore(connectionString);
            sqlInstanceStore.HostLockRenewalPeriod = TimeSpan.FromSeconds(30);
            return sqlInstanceStore;
        }
    }
}
