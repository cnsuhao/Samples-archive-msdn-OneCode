using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace MyWorkflow.UpdateTaskWF2
{
    public sealed partial class UpdateTaskWF2
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
            System.Workflow.ComponentModel.ActivityBind activitybind8 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind9 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken2 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind10 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind11 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind12 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind13 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken3 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind14 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind15 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind16 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind17 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind18 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind19 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind20 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind21 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind22 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind24 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken4 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind23 = new System.Workflow.ComponentModel.ActivityBind();
            this.logUpdateTask = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.updateTask1 = new Microsoft.SharePoint.WorkflowActions.UpdateTask();
            this.logTaskUpdated = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.onTaskChanged = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
            this.cancellationHandlerActivity1 = new System.Workflow.ComponentModel.CancellationHandlerActivity();
            this.logTaskComplete = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.completeTask = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.whileActivity1 = new System.Workflow.Activities.WhileActivity();
            this.logTaskCreated = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.createApprovalTask = new Microsoft.SharePoint.WorkflowActions.CreateTask();
            this.logActivated = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.onWFActivated = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
            // 
            // logUpdateTask
            // 
            this.logUpdateTask.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logUpdateTask.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind1.Name = "UpdateTaskWF2";
            activitybind1.Path = "HistoryDescription";
            activitybind2.Name = "UpdateTaskWF2";
            activitybind2.Path = "HistoryOutcome";
            this.logUpdateTask.Name = "logUpdateTask";
            this.logUpdateTask.OtherData = "";
            activitybind3.Name = "UpdateTaskWF2";
            activitybind3.Path = "workflowProperties.OriginatorUser.ID";
            this.logUpdateTask.MethodInvoking += new System.EventHandler(this.logUpdateTask_MethodInvoking);
            this.logUpdateTask.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.logUpdateTask.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.logUpdateTask.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.UserIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            // 
            // updateTask1
            // 
            correlationtoken1.Name = "taskToken";
            correlationtoken1.OwnerActivityName = "UpdateTaskWF2";
            this.updateTask1.CorrelationToken = correlationtoken1;
            this.updateTask1.Name = "updateTask1";
            activitybind4.Name = "UpdateTaskWF2";
            activitybind4.Path = "TaskId";
            activitybind5.Name = "UpdateTaskWF2";
            activitybind5.Path = "TaskProperties";
            this.updateTask1.MethodInvoking += new System.EventHandler(this.updateTask1_MethodInvoking);
            this.updateTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateTask.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            this.updateTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            // 
            // logTaskUpdated
            // 
            this.logTaskUpdated.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logTaskUpdated.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind6.Name = "UpdateTaskWF2";
            activitybind6.Path = "HistoryDescription";
            activitybind7.Name = "UpdateTaskWF2";
            activitybind7.Path = "HistoryOutcome";
            this.logTaskUpdated.Name = "logTaskUpdated";
            this.logTaskUpdated.OtherData = "";
            activitybind8.Name = "UpdateTaskWF2";
            activitybind8.Path = "workflowProperties.OriginatorUser.ID";
            this.logTaskUpdated.MethodInvoking += new System.EventHandler(this.logTaskUpdated_MethodInvoking);
            this.logTaskUpdated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            this.logTaskUpdated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            this.logTaskUpdated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.UserIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            // 
            // onTaskChanged
            // 
            activitybind9.Name = "UpdateTaskWF2";
            activitybind9.Path = "TaskAfterProperties";
            this.onTaskChanged.BeforeProperties = null;
            correlationtoken2.Name = "taskToken";
            correlationtoken2.OwnerActivityName = "UpdateTaskWF2";
            this.onTaskChanged.CorrelationToken = correlationtoken2;
            this.onTaskChanged.Executor = null;
            this.onTaskChanged.Name = "onTaskChanged";
            activitybind10.Name = "UpdateTaskWF2";
            activitybind10.Path = "TaskId";
            this.onTaskChanged.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskChanged_Invoked);
            this.onTaskChanged.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            this.onTaskChanged.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.AfterPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            // 
            // sequenceActivity1
            // 
            this.sequenceActivity1.Activities.Add(this.onTaskChanged);
            this.sequenceActivity1.Activities.Add(this.logTaskUpdated);
            this.sequenceActivity1.Activities.Add(this.updateTask1);
            this.sequenceActivity1.Activities.Add(this.logUpdateTask);
            this.sequenceActivity1.Name = "sequenceActivity1";
            // 
            // cancellationHandlerActivity1
            // 
            this.cancellationHandlerActivity1.Enabled = false;
            this.cancellationHandlerActivity1.Name = "cancellationHandlerActivity1";
            // 
            // logTaskComplete
            // 
            this.logTaskComplete.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logTaskComplete.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind11.Name = "UpdateTaskWF2";
            activitybind11.Path = "HistoryDescription";
            activitybind12.Name = "UpdateTaskWF2";
            activitybind12.Path = "HistoryOutcome";
            this.logTaskComplete.Name = "logTaskComplete";
            this.logTaskComplete.OtherData = "";
            activitybind13.Name = "UpdateTaskWF2";
            activitybind13.Path = "workflowProperties.OriginatorUser.ID";
            this.logTaskComplete.MethodInvoking += new System.EventHandler(this.logTaskComplete_MethodInvoking);
            this.logTaskComplete.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind11)));
            this.logTaskComplete.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind12)));
            this.logTaskComplete.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.UserIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind13)));
            // 
            // completeTask
            // 
            correlationtoken3.Name = "taskToken";
            correlationtoken3.OwnerActivityName = "UpdateTaskWF2";
            this.completeTask.CorrelationToken = correlationtoken3;
            this.completeTask.Name = "completeTask";
            activitybind14.Name = "UpdateTaskWF2";
            activitybind14.Path = "TaskId";
            this.completeTask.TaskOutcome = "";
            this.completeTask.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind14)));
            // 
            // whileActivity1
            // 
            this.whileActivity1.Activities.Add(this.sequenceActivity1);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.while1Invoke);
            this.whileActivity1.Condition = codecondition1;
            this.whileActivity1.Name = "whileActivity1";
            // 
            // logTaskCreated
            // 
            this.logTaskCreated.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logTaskCreated.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind15.Name = "UpdateTaskWF2";
            activitybind15.Path = "HistoryDescription";
            activitybind16.Name = "UpdateTaskWF2";
            activitybind16.Path = "HistoryOutcome";
            this.logTaskCreated.Name = "logTaskCreated";
            this.logTaskCreated.OtherData = "";
            activitybind17.Name = "UpdateTaskWF2";
            activitybind17.Path = "workflowProperties.OriginatorUser.ID";
            this.logTaskCreated.MethodInvoking += new System.EventHandler(this.logTaskCreated_MethodInvoking);
            this.logTaskCreated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind15)));
            this.logTaskCreated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind16)));
            this.logTaskCreated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.UserIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind17)));
            // 
            // createApprovalTask
            // 
            this.createApprovalTask.CorrelationToken = correlationtoken3;
            this.createApprovalTask.ListItemId = -1;
            this.createApprovalTask.Name = "createApprovalTask";
            this.createApprovalTask.SpecialPermissions = null;
            activitybind18.Name = "UpdateTaskWF2";
            activitybind18.Path = "TaskId";
            activitybind19.Name = "UpdateTaskWF2";
            activitybind19.Path = "TaskProperties";
            this.createApprovalTask.MethodInvoking += new System.EventHandler(this.createTask1_MethodInvoking);
            this.createApprovalTask.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind18)));
            this.createApprovalTask.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind19)));
            // 
            // logActivated
            // 
            this.logActivated.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logActivated.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind20.Name = "UpdateTaskWF2";
            activitybind20.Path = "HistoryDescription";
            activitybind21.Name = "UpdateTaskWF2";
            activitybind21.Path = "HistoryOutcome";
            this.logActivated.Name = "logActivated";
            this.logActivated.OtherData = "";
            activitybind22.Name = "UpdateTaskWF2";
            activitybind22.Path = "workflowProperties.OriginatorUser.ID";
            this.logActivated.MethodInvoking += new System.EventHandler(this.logActivated_MethodInvoking);
            this.logActivated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind20)));
            this.logActivated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind21)));
            this.logActivated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.UserIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind22)));
            activitybind24.Name = "UpdateTaskWF2";
            activitybind24.Path = "workflowId";
            // 
            // onWFActivated
            // 
            correlationtoken4.Name = "workflowToken";
            correlationtoken4.OwnerActivityName = "UpdateTaskWF2";
            this.onWFActivated.CorrelationToken = correlationtoken4;
            this.onWFActivated.EventName = "OnWorkflowActivated";
            this.onWFActivated.Name = "onWFActivated";
            activitybind23.Name = "UpdateTaskWF2";
            activitybind23.Path = "workflowProperties";
            this.onWFActivated.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onWorkflowActivated1_Invoked);
            this.onWFActivated.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind24)));
            this.onWFActivated.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind23)));
            // 
            // UpdateTaskWF2
            // 
            this.Activities.Add(this.onWFActivated);
            this.Activities.Add(this.logActivated);
            this.Activities.Add(this.createApprovalTask);
            this.Activities.Add(this.logTaskCreated);
            this.Activities.Add(this.whileActivity1);
            this.Activities.Add(this.completeTask);
            this.Activities.Add(this.logTaskComplete);
            this.Activities.Add(this.cancellationHandlerActivity1);
            this.Name = "UpdateTaskWF2";
            this.CanModifyActivities = false;

        }

        #endregion

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logUpdateTask;

        private Microsoft.SharePoint.WorkflowActions.UpdateTask updateTask1;

        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged;

        private SequenceActivity sequenceActivity1;

        private WhileActivity whileActivity1;

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logTaskUpdated;

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logTaskComplete;

        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeTask;

        private Microsoft.SharePoint.WorkflowActions.CreateTask createApprovalTask;

        private CancellationHandlerActivity cancellationHandlerActivity1;

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logTaskCreated;

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logActivated;

        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWFActivated;

    }
}
