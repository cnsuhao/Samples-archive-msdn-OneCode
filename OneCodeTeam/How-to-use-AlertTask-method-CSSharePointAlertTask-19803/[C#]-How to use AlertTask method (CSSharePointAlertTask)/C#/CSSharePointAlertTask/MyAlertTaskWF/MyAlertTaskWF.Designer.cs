using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace CSSharePointAlertTask.MyAlertTaskWF
{
    public sealed partial class MyAlertTaskWF
    {
        #region Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind6 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind7 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken2 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind8 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind9 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind10 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind11 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken3 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind12 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind13 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind14 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind15 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind16 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken4 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind17 = new System.Workflow.ComponentModel.ActivityBind();
            this.logTaskComplete = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.completeTask = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.logForTaskChanged = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.onTaskChanged = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.logTaskCreated = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.createApprovalTask = new Microsoft.SharePoint.WorkflowActions.CreateTask();
            this.sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
            this.whileActivity1 = new System.Workflow.Activities.WhileActivity();
            this.logActivated = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.onWFActivated = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
            // 
            // logTaskComplete
            // 
            this.logTaskComplete.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logTaskComplete.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind1.Name = "MyAlertTaskWF";
            activitybind1.Path = "HistoryDescription";
            activitybind2.Name = "MyAlertTaskWF";
            activitybind2.Path = "HistoryOutcome";
            this.logTaskComplete.Name = "logTaskComplete";
            this.logTaskComplete.OtherData = "";
            activitybind3.Name = "MyAlertTaskWF";
            activitybind3.Path = "workflowProperties.OriginatorUser.ID";
            this.logTaskComplete.MethodInvoking += new System.EventHandler(this.logTaskComplete_MethodInvoking);
            this.logTaskComplete.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.logTaskComplete.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.logTaskComplete.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.UserIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            // 
            // completeTask
            // 
            correlationtoken1.Name = "taskToken";
            correlationtoken1.OwnerActivityName = "sequenceActivity1";
            this.completeTask.CorrelationToken = correlationtoken1;
            this.completeTask.Name = "completeTask";
            activitybind4.Name = "MyAlertTaskWF";
            activitybind4.Path = "TaskId";
            this.completeTask.TaskOutcome = "";
            this.completeTask.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            // 
            // logForTaskChanged
            // 
            this.logForTaskChanged.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logForTaskChanged.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind5.Name = "MyAlertTaskWF";
            activitybind5.Path = "HistoryDescription";
            activitybind6.Name = "MyAlertTaskWF";
            activitybind6.Path = "HistoryOutcome";
            this.logForTaskChanged.Name = "logForTaskChanged";
            this.logForTaskChanged.OtherData = "";
            this.logForTaskChanged.UserId = -1;
            this.logForTaskChanged.MethodInvoking += new System.EventHandler(this.logForTaskChanged_MethodInvoking);
            this.logForTaskChanged.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            this.logForTaskChanged.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            // 
            // onTaskChanged
            // 
            activitybind7.Name = "MyAlertTaskWF";
            activitybind7.Path = "TaskAfterProperties";
            this.onTaskChanged.BeforeProperties = null;
            correlationtoken2.Name = "taskToken";
            correlationtoken2.OwnerActivityName = "sequenceActivity1";
            this.onTaskChanged.CorrelationToken = correlationtoken2;
            this.onTaskChanged.Executor = null;
            this.onTaskChanged.Name = "onTaskChanged";
            activitybind8.Name = "MyAlertTaskWF";
            activitybind8.Path = "TaskId";
            this.onTaskChanged.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskChanged_Invoked);
            this.onTaskChanged.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            this.onTaskChanged.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.AfterPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            // 
            // logTaskCreated
            // 
            this.logTaskCreated.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logTaskCreated.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind9.Name = "MyAlertTaskWF";
            activitybind9.Path = "HistoryOutcome";
            activitybind10.Name = "MyAlertTaskWF";
            activitybind10.Path = "HistoryDescription";
            this.logTaskCreated.Name = "logTaskCreated";
            this.logTaskCreated.OtherData = "";
            activitybind11.Name = "MyAlertTaskWF";
            activitybind11.Path = "workflowProperties.OriginatorUser.ID";
            this.logTaskCreated.MethodInvoking += new System.EventHandler(this.logTaskCreated_MethodInvoking);
            this.logTaskCreated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            this.logTaskCreated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            this.logTaskCreated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.UserIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind11)));
            // 
            // createApprovalTask
            // 
            correlationtoken3.Name = "taskToken";
            correlationtoken3.OwnerActivityName = "sequenceActivity1";
            this.createApprovalTask.CorrelationToken = correlationtoken3;
            this.createApprovalTask.ListItemId = -1;
            this.createApprovalTask.Name = "createApprovalTask";
            this.createApprovalTask.SpecialPermissions = null;
            activitybind12.Name = "MyAlertTaskWF";
            activitybind12.Path = "TaskId";
            activitybind13.Name = "MyAlertTaskWF";
            activitybind13.Path = "TaskProperties";
            this.createApprovalTask.MethodInvoking += new System.EventHandler(this.createTask1_MethodInvoking);
            this.createApprovalTask.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind13)));
            this.createApprovalTask.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind12)));
            // 
            // sequenceActivity1
            // 
            this.sequenceActivity1.Activities.Add(this.createApprovalTask);
            this.sequenceActivity1.Activities.Add(this.logTaskCreated);
            this.sequenceActivity1.Activities.Add(this.onTaskChanged);
            this.sequenceActivity1.Activities.Add(this.logForTaskChanged);
            this.sequenceActivity1.Activities.Add(this.completeTask);
            this.sequenceActivity1.Activities.Add(this.logTaskComplete);
            this.sequenceActivity1.Name = "sequenceActivity1";
            // 
            // whileActivity1
            // 
            this.whileActivity1.Activities.Add(this.sequenceActivity1);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.while1Invoke);
            this.whileActivity1.Condition = codecondition1;
            this.whileActivity1.Name = "whileActivity1";
            // 
            // logActivated
            // 
            this.logActivated.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logActivated.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind14.Name = "MyAlertTaskWF";
            activitybind14.Path = "HistoryDescription";
            activitybind15.Name = "MyAlertTaskWF";
            activitybind15.Path = "HistoryOutcome";
            this.logActivated.Name = "logActivated";
            this.logActivated.OtherData = "";
            activitybind16.Name = "MyAlertTaskWF";
            activitybind16.Path = "workflowProperties.OriginatorUser.ID";
            this.logActivated.MethodInvoking += new System.EventHandler(this.logActivated_MethodInvoking);
            this.logActivated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind14)));
            this.logActivated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind15)));
            this.logActivated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.UserIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind16)));
            // 
            // onWFActivated
            // 
            correlationtoken4.Name = "workflowToken";
            correlationtoken4.OwnerActivityName = "MyAlertTaskWF";
            this.onWFActivated.CorrelationToken = correlationtoken4;
            this.onWFActivated.EventName = "OnWorkflowActivated";
            this.onWFActivated.Name = "onWFActivated";
            activitybind17.Name = "MyAlertTaskWF";
            activitybind17.Path = "workflowProperties";
            this.onWFActivated.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onWFActivated_Invoked);
            this.onWFActivated.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind17)));
            // 
            // MyAlertTaskWF
            // 
            this.Activities.Add(this.onWFActivated);
            this.Activities.Add(this.logActivated);
            this.Activities.Add(this.whileActivity1);
            this.Name = "MyAlertTaskWF";
            this.CanModifyActivities = false;

        }

        #endregion

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logTaskComplete;

        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeTask;

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logTaskCreated;

        private Microsoft.SharePoint.WorkflowActions.CreateTask createApprovalTask;

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logActivated;

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logForTaskChanged;

        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged;

        private SequenceActivity sequenceActivity1;

        private WhileActivity whileActivity1;

        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWFActivated;































    }
}
