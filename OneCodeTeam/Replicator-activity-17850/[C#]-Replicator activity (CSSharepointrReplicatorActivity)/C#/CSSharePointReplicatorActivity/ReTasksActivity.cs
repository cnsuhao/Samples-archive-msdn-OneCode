/****************************** Module Header ******************************\
* Module Name:    ReTasksActivity.cs
* Project:        CSSharePointReplicatorActivity
* Copyright (c) Microsoft Corporation
*
* This is the custom reusable activity.
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
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;

namespace MyWorkflow.Workflow
{
    public partial class ReTasksActivity : SequenceActivity
    {
        public ReTasksActivity()
        {
            InitializeComponent();
        }

        #region TaskProperties
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public string TaskAssignedTo { get; set; }
        public DateTime TaskDueDate { get; set; }
        public Guid TaskStatusFieldId = new Guid("c15b34c3-ce7d-490a-b133-3f4de8801b76");
        #endregion

        // Flag for while Condition
        private bool isFinished;      
        
        private void createTask1_MethodInvoking(object sender, EventArgs e)
        {
            // Create Task
            TaskId = Guid.NewGuid();

            // Initialize an instance of SPWorkflowTaskProperties and set value.
            TaskProperties = new SPWorkflowTaskProperties();
            TaskProperties.Title = TaskTitle;
            TaskProperties.Description = TaskDescription;
            TaskProperties.AssignedTo = TaskAssignedTo;
            TaskProperties.PercentComplete = 0;
            TaskProperties.StartDate = DateTime.Today;
            TaskProperties.DueDate = TaskDueDate; 
        }

        /// <summary>
        /// Handle OnTaskChanged event.
        /// Set the value of the loop condition flag according to the taskStatus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        private void onTaskChanged1_Invoked(object sender, ExternalDataEventArgs e)
        {
            string taskStatus = AfterProperties.ExtendedProperties[TaskStatusFieldId].ToString();
            if (taskStatus.Equals("Completed"))
                isFinished = true;
        }

        // Condition of while.
        private void while1Invoke(object sender, ConditionalEventArgs e)
        {
            e.Result = !isFinished;
        }

        // Handle CompleteTask event.
        private void completeTask1_MethodInvoking(object sender, EventArgs e)
        {
            TaskOutcome = "Task Complete";
        }


        // TaskProperties
        public static DependencyProperty TaskPropertiesProperty = DependencyProperty.Register("TaskProperties", 
            typeof(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), typeof(MyWorkflow.Workflow.ReTasksActivity));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public SPWorkflowTaskProperties TaskProperties
        {
            get
            {
                return ((Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)(base.GetValue(MyWorkflow.Workflow.ReTasksActivity.TaskPropertiesProperty)));
            }
            set
            {
                base.SetValue(MyWorkflow.Workflow.ReTasksActivity.TaskPropertiesProperty, value);
            }
        }

        // TaskId
        public static DependencyProperty TaskIdProperty = DependencyProperty.Register("TaskId", typeof(System.Guid), 
            typeof(MyWorkflow.Workflow.ReTasksActivity));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public Guid TaskId
        {
            get
            {
                return ((System.Guid)(base.GetValue(MyWorkflow.Workflow.ReTasksActivity.TaskIdProperty)));
            }
            set
            {
                base.SetValue(MyWorkflow.Workflow.ReTasksActivity.TaskIdProperty, value);
            }
        }

        // AfterProperties
        public static DependencyProperty AfterPropertiesProperty = DependencyProperty.Register("AfterProperties", 
            typeof(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), typeof(MyWorkflow.Workflow.ReTasksActivity));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public SPWorkflowTaskProperties AfterProperties
        {
            get
            {
                return ((Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)(base.GetValue(MyWorkflow.Workflow.ReTasksActivity.AfterPropertiesProperty)));
            }
            set
            {
                base.SetValue(MyWorkflow.Workflow.ReTasksActivity.AfterPropertiesProperty, value);
            }
        }

        // BeforeProperties
        public static DependencyProperty BeforePropertiesProperty = DependencyProperty.Register("BeforeProperties", 
            typeof(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), typeof(MyWorkflow.Workflow.ReTasksActivity));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public SPWorkflowTaskProperties BeforeProperties
        {
            get
            {
                return ((Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)(base.GetValue(MyWorkflow.Workflow.ReTasksActivity.BeforePropertiesProperty)));
            }
            set
            {
                base.SetValue(MyWorkflow.Workflow.ReTasksActivity.BeforePropertiesProperty, value);
            }
        }

        // TaskOutcome
        public static DependencyProperty TaskOutcomeProperty = DependencyProperty.Register("TaskOutcome", 
            typeof(System.String), typeof(MyWorkflow.Workflow.ReTasksActivity));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public String TaskOutcome
        {
            get
            {
                return ((string)(base.GetValue(MyWorkflow.Workflow.ReTasksActivity.TaskOutcomeProperty)));
            }
            set
            {
                base.SetValue(MyWorkflow.Workflow.ReTasksActivity.TaskOutcomeProperty, value);
            }
        }

    }

}






