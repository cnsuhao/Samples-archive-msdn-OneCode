/****************************** Module Header ******************************\
* Module Name:  MyServiceHostFactory.cs
* Project:		CSWF4ServiceHostFactory
* Copyright (c) Microsoft Corporation.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
using System;
using System.ServiceModel.Activities;
using System.Activities.DurableInstancing;
using System.Configuration;

namespace CSWF4ServiceHostFactory
{
    public class MyServiceHostFactory : 
            System.ServiceModel.Activities.Activation.WorkflowServiceHostFactory 
    {
        protected override WorkflowServiceHost CreateWorkflowServiceHost(WorkflowService service,
                                                                         Uri[] baseAddresses) 
        {
            WorkflowServiceHost host = 
                base.CreateWorkflowServiceHost(service, baseAddresses);
            string connectionString = 
                ConfigurationManager.AppSettings["SqlWF4PersistenceConnectionString"].ToString();
            SqlWorkflowInstanceStore instanceStore = 
                new SqlWorkflowInstanceStore(connectionString);
            instanceStore.InstanceCompletionAction = 
                InstanceCompletionAction.DeleteNothing;
            host.DurableInstancingOptions.InstanceStore = instanceStore;
            return host;
        }
    }
}
