/****************************** Module Header ******************************\
* Module Name:    ReplicatorTask.cs
* Project:        CSSharePointReplicatorActivity
* Copyright (c) Microsoft Corporation
*
* This is the workflow for demonstrating Replicator.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using System.Xml;
using System.Xml.Serialization;
using CSSharePointReplicatorActivity.MyWorkflow;

namespace MyWorkflow.Workflow
{
    public sealed partial class myWorkflow : SequentialWorkflowActivity
    {
        public myWorkflow()
        {
            InitializeComponent();
        }

        // workflowId
        public Guid workflowId = default(System.Guid);

        // workflowProperties
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();

        // Handler of OnWorkflowActivated
        private void onWorkflowActivated1_Invoked(object sender, ExternalDataEventArgs e)
        {
            workflowId = workflowProperties.WorkflowId;
        }

        private void replicatorActivity1_Initialized(object sender, EventArgs e)
        {
            // Create a set of InitialChildData for task
            // De-serialize workflowProperties.InitiationData to get the initial form instance.
            XmlSerializer serializer = new XmlSerializer(typeof(AssociationData));
            XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(workflowProperties.AssociationData));
            AssociationData wfData = (AssociationData)serializer.Deserialize(reader);

            // Set InitialChild Data
            InitialChildData = new ArrayList();
            for (int i = 0; i < wfData.Partners.ContactList.Count; i++)
            {
                InitialChildData.Add(wfData.Partners.ContactList[i]);
            }
           
            // Set data for first task       
            reTasksActivity1.TaskAssignedTo = InitialChildData[InitialChildData.Count - 1].ToString();
            reTasksActivity1.TaskTitle = "Vacation Request Approval";
            reTasksActivity1.TaskDescription = "Approve Vacation";
            reTasksActivity1.TaskDueDate = DateTime.Today.AddDays(7);
        }

        private void rePlicatorActivity_ChildInitialized(object sender, ReplicatorChildEventArgs e)
        {
            // Looping through each assignee   
            reTasksActivity1.TaskAssignedTo = e.InstanceData.ToString();
            reTasksActivity1.TaskTitle = "Vacation Request Approval";
            reTasksActivity1.TaskDescription = "Approve Vacation";
            reTasksActivity1.TaskDueDate = DateTime.Today.AddDays(7);
        }

        // InitialChildData
        public static DependencyProperty InitialChildDataProperty = DependencyProperty.Register("InitialChildData", 
            typeof(System.Collections.IList), typeof(MyWorkflow.Workflow.myWorkflow));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Properties")]
        public IList InitialChildData
        {
            get
            {
                return ((System.Collections.IList)(base.GetValue(MyWorkflow.Workflow.myWorkflow.InitialChildDataProperty)));
            }
            set
            {
                base.SetValue(MyWorkflow.Workflow.myWorkflow.InitialChildDataProperty, value);
            }
        }
    }

}

