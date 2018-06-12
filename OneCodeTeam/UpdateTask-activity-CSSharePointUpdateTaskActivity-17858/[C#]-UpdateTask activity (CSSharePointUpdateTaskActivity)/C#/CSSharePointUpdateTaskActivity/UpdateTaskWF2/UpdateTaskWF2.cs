/****************************** Module Header ******************************\
* Module Name:    myWorkflow.cs
* Project:        CSSharePointUpdateTaskActivity
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to Use UpdateTask activity in SharePoint Visual Studio Workflow.
* In this sample, we assume that the approval requires two steps, 
* the first person (the Approver) completes the first step in the approval,
* and then we will re-register the workflow to the second person.
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
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.WorkflowActions;

namespace MyWorkflow.UpdateTaskWF2
{
    public sealed partial class UpdateTaskWF2 : SequentialWorkflowActivity
    {
        public UpdateTaskWF2()
        {
            InitializeComponent();
        }

        #region Properties
        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();

        // Fields to store initiation data from initiation form     
        public string Approver = default(string); // Approver     
       
        #region Workflow history
        public String HistoryDescription = default(System.String);
        public String HistoryOutcome = default(System.String);
        #endregion
        
        public Guid TaskId = default(System.Guid);
        public SPWorkflowTaskProperties TaskProperties = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        string TaskStatus = "Pending Approval";

        /// <summary>
        /// SpecialPermissions
        /// </summary>
        public HybridDictionary SpecialPermissions
        {
            get
            {
                HybridDictionary taskPermissions = new HybridDictionary();
                taskPermissions[TaskProperties.AssignedTo] = SPRoleType.Contributor;
                return taskPermissions;
            }
        }

        // AfterProperties of OnTaskChanged
        public SPWorkflowTaskProperties TaskAfterProperties = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();

        // Flag for while.
        private bool isFinished = false;
        #endregion

        private void onWorkflowActivated1_Invoked(object sender, ExternalDataEventArgs e)
        {
            Approver = "v-seiyas";
        }

        /// <summary>
        /// CreateTask Created
        /// </summary>
        private void createTask1_MethodInvoking(object sender, EventArgs e)
        {
            // Generate a new GUID, it's used to initialize task correlation token. 
            TaskId = Guid.NewGuid();

            // Assign initial properties prior to task creation 
            TaskProperties.Title = string.Format("Review:【{0}】", this.workflowProperties.Item.DisplayName);
            TaskProperties.PercentComplete = 0;
            TaskProperties.StartDate = DateTime.Today;
            TaskProperties.DueDate = DateTime.Today.AddDays(3);
            TaskProperties.ExtendedProperties["TaskStatus"] = TaskStatus;
            TaskProperties.AssignedTo = Approver;

            createApprovalTask.SpecialPermissions = SpecialPermissions;
        }

        // Condition of while
        private void while1Invoke(object sender, ConditionalEventArgs e)
        {
            e.Result = !isFinished;
        }

        // Handler of OnTaskChanged
        private void onTaskChanged_Invoked(object sender, ExternalDataEventArgs e)
        {
            // If this is the second approval, complete the workflow.
            if (!TaskProperties.AssignedTo.Equals(Approver))
            {
                isFinished = (TaskAfterProperties.ExtendedProperties["TaskStatus"].ToString() == "Completed");
            }
        }

        /// <summary>
        /// Handler of UpdateTask
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateTask1_MethodInvoking(object sender, EventArgs e)
        {
            // If this is the first approval, re-register the workflow to the second person.
            if (TaskProperties.AssignedTo.Equals(Approver))
            {
                int itemId = TaskAfterProperties.TaskItemId;
                updateTask1.TaskProperties.TaskItemId = itemId;
                updateTask1.TaskProperties.AssignedTo = "Seiya-MSFT\\Seiya";
                updateTask1.TaskProperties.Title = string.Format("【{0}】", this.workflowProperties.Item.DisplayName);
                updateTask1.TaskProperties.DueDate = DateTime.Today.AddDays(5);
            }
        }

        #region Log to History list
        /// <summary>
        /// Log for Activate
        /// </summary>
        private void logActivated_MethodInvoking(object sender, EventArgs e)
        {
            HistoryDescription = "Workflow data: " +
                                 "Approver=" + Approver + "; ";
            HistoryOutcome = "Workflow activated";
        }

        /// <summary>
        /// Log for TaskCreated
        /// </summary>
        private void logTaskCreated_MethodInvoking(object sender, EventArgs e)
        {
            HistoryDescription = "Task data: " +
                                  "AssignedTo=" + TaskProperties.AssignedTo + "; " +
                                  "TaskStatus=" + TaskProperties.ExtendedProperties["TaskStatus"].ToString() + "; " +
                                  "TaskTitle=" + TaskProperties.Title;
            HistoryOutcome = "Task created";
        }

        /// <summary>
        /// Log for OnTaskChanged
        /// </summary>
        private void logTaskUpdated_MethodInvoking(object sender, EventArgs e)
        {
            HistoryOutcome = "Task updated";
            HistoryDescription = "TaskStatus: " +
                                 TaskAfterProperties.ExtendedProperties["TaskStatus"].ToString() + "; " +
                                   "AssignedTo=" + TaskProperties.AssignedTo + "; " + "ApproverComments: " +
                                   TaskAfterProperties.ExtendedProperties["ApproverComments"].ToString();
        }

        /// <summary>
        /// Log for UpdateTask activity
        /// </summary>
        private void logUpdateTask_MethodInvoking(object sender, EventArgs e)
        {

            HistoryDescription = "TaskStatus: " +
                                     TaskAfterProperties.ExtendedProperties["TaskStatus"].ToString() + "; " + "TaskOutcome: " +
                                    TaskAfterProperties.ExtendedProperties["TaskOutcome"].ToString() + ";AssignedTo:" + TaskProperties.AssignedTo + ";isFinished=" + isFinished;

            HistoryOutcome = "Update Task";

        }

        /// <summary>
        /// Log for TaskComplete
        /// </summary>
        private void logTaskComplete_MethodInvoking(object sender, EventArgs e)
        {
            HistoryDescription = "TaskOutcome: " +
                                 TaskAfterProperties.ExtendedProperties["TaskOutcome"].ToString() + ";AssignedTo:" + TaskProperties.AssignedTo;

            HistoryOutcome = "Task Completed";
        }
        #endregion
    }
}
