/****************************** Module Header ******************************\
* Module Name:    MyAlertTaskWF.cs
* Project:        CSSharePointAlertTask
* Copyright (c) Microsoft Corporation
*
* This sample code will demo how to use AlertTask method to deal with a workflow task.
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
using System.Workflow.ComponentModel;
using System.Workflow.Activities;
using Microsoft.SharePoint.Workflow;

namespace CSSharePointAlertTask.MyAlertTaskWF
{
    public sealed partial class MyAlertTaskWF : SequentialWorkflowActivity
    {
        public MyAlertTaskWF()
        {
            InitializeComponent();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();

        #region Properties

        // reassignee
        string strReassignee = string.Empty;
        // flag for reassign
        private bool isReassign = false;
        // assignee
        string assignee = default(System.String);
        // init taskStatus
        string strTaskStatus = "Pending Approval";
        // Flag for while.
        private bool isFinished = false;
        #endregion

        /// <summary>
        /// CreateTask Created
        /// </summary>
        private void createTask1_MethodInvoking(object sender, EventArgs e)
        {
            // Generate new GUID used to initialize task correlation token 
            TaskId = Guid.NewGuid();

            if (strReassignee != null && isReassign == true)
            {
                TaskProperties.AssignedTo = strReassignee;
                TaskProperties.Title = string.Format("Review 2:【{0}】", this.workflowProperties.Item.DisplayName);
            }
            else
            {
                TaskProperties = new SPWorkflowTaskProperties();
                // Assign initial properties prior to task creation 
                TaskProperties.Title = string.Format("Review:【{0}】", this.workflowProperties.Item.DisplayName);
                TaskProperties.PercentComplete = 0;
                TaskProperties.StartDate = DateTime.Today;
                TaskProperties.DueDate = DateTime.Today.AddDays(3);
                TaskProperties.ExtendedProperties["TaskStatus"] = strTaskStatus;
                TaskProperties.AssignedTo = assignee;
            }

        }

        // Condition of while
        private void while1Invoke(object sender, ConditionalEventArgs e)
        {
            e.Result = !isFinished;
        }

        // Handler of OnTaskChanged
        private void onTaskChanged_Invoked(object sender, ExternalDataEventArgs e)
        {
            try
            {
                isReassign = bool.Parse(TaskAfterProperties.ExtendedProperties["isReassign"].ToString());
                if (isReassign == true)
                {
                    strReassignee = TaskAfterProperties.ExtendedProperties["ReAssignedTo"].ToString();
                    isFinished = false;
                }
                else
                {
                    if (TaskAfterProperties.ExtendedProperties["TaskStatus"].ToString() == "Canceled")
                    {
                        isFinished = false;
                    }
                    else
                    {
                        isFinished = (TaskAfterProperties.ExtendedProperties["TaskStatus"].ToString() == "Completed");
                    }
                }
            }
            catch (Exception ex)
            {

                logForTaskChanged.HistoryDescription = ex.ToString();
            }

        }

        public static DependencyProperty TaskIdProperty = DependencyProperty.Register("TaskId", typeof(System.Guid), typeof(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public Guid TaskId
        {
            get
            {
                return ((System.Guid)(base.GetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.TaskIdProperty)));
            }
            set
            {
                base.SetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.TaskIdProperty, value);
            }
        }

        public static DependencyProperty TaskPropertiesProperty = DependencyProperty.Register("TaskProperties", typeof(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), typeof(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public SPWorkflowTaskProperties TaskProperties
        {
            get
            {
                return ((Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)(base.GetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.TaskPropertiesProperty)));
            }
            set
            {
                base.SetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.TaskPropertiesProperty, value);
            }
        }

        public static DependencyProperty TaskAfterPropertiesProperty = DependencyProperty.Register("TaskAfterProperties", typeof(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), typeof(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public SPWorkflowTaskProperties TaskAfterProperties
        {
            get
            {
                return ((Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)(base.GetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.TaskAfterPropertiesProperty)));
            }
            set
            {
                base.SetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.TaskAfterPropertiesProperty, value);
            }
        }

        public static DependencyProperty HistoryDescriptionProperty = DependencyProperty.Register("HistoryDescription", typeof(System.String), typeof(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public String HistoryDescription
        {
            get
            {
                return ((string)(base.GetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.HistoryDescriptionProperty)));
            }
            set
            {
                base.SetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.HistoryDescriptionProperty, value);
            }
        }

        public static DependencyProperty HistoryOutcomeProperty = DependencyProperty.Register("HistoryOutcome", typeof(System.String), typeof(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public String HistoryOutcome
        {
            get
            {
                return ((string)(base.GetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.HistoryOutcomeProperty)));
            }
            set
            {
                base.SetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.HistoryOutcomeProperty, value);
            }
        }

        private void logTaskComplete_MethodInvoking(object sender, EventArgs e)
        {
            HistoryDescription = "TaskOutcome: " +
                                          TaskAfterProperties.ExtendedProperties["TaskOutcome"].ToString() + ";AssignedTo:" + TaskProperties.AssignedTo;

            HistoryOutcome = "Task Completed";
        }

        private void logForTaskChanged_MethodInvoking(object sender, EventArgs e)
        {
            HistoryDescription = "TaskOutcome: " +
                                          TaskAfterProperties.ExtendedProperties["TaskOutcome"].ToString() + ";AssignedTo:" + TaskProperties.AssignedTo;

            HistoryOutcome = "Task Changed";
        }

        private void logActivated_MethodInvoking(object sender, EventArgs e)
        {
            HistoryDescription = "Workflow data: " +
                                 "Approver=seiya";
            HistoryOutcome = "Workflow activated";
        }

        private void logTaskCreated_MethodInvoking(object sender, EventArgs e)
        {
            HistoryDescription = "Task data: " +
                                  "AssignedTo=" + TaskProperties.AssignedTo + "; " +
                                  "TaskStatus=" + TaskProperties.ExtendedProperties["TaskStatus"].ToString() + "; " +
                                  "TaskTitle=" + TaskProperties.Title;
            HistoryOutcome = "Task created";
        }

        private void onWFActivated_Invoked(object sender, ExternalDataEventArgs e)
        {
            try
            {
                workflowId = workflowProperties.WorkflowId;

                assignee = "seiya";
            }
            catch (Exception ex)
            {
                logActivated.HistoryDescription = ex.ToString();
            }
        }
    }
}
