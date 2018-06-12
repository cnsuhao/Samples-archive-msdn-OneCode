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

namespace MyWorkflow.Workflow
{
    public sealed partial class myWorkflow
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
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            this.reTasksActivity1 = new MyWorkflow.Workflow.ReTasksActivity();
            this.replicatorActivity1 = new System.Workflow.Activities.ReplicatorActivity();
            this.onWorkflowActivated1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
            // 
            // reTasksActivity1
            // 
            this.reTasksActivity1.AfterProperties = null;
            this.reTasksActivity1.BeforeProperties = null;
            this.reTasksActivity1.Name = "reTasksActivity1";
            this.reTasksActivity1.TaskAssignedTo = null;
            this.reTasksActivity1.TaskDescription = null;
            this.reTasksActivity1.TaskDueDate = new System.DateTime(((long)(0)));
            this.reTasksActivity1.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.reTasksActivity1.TaskOutcome = null;
            this.reTasksActivity1.TaskProperties = null;
            this.reTasksActivity1.TaskTitle = null;
            activitybind1.Name = "myWorkflow";
            activitybind1.Path = "InitialChildData";
            // 
            // replicatorActivity1
            // 
            this.replicatorActivity1.Activities.Add(this.reTasksActivity1);
            this.replicatorActivity1.ExecutionType = System.Workflow.Activities.ExecutionType.Parallel;
            this.replicatorActivity1.Name = "replicatorActivity1";
            this.replicatorActivity1.ChildInitialized += new System.EventHandler<System.Workflow.Activities.ReplicatorChildEventArgs>(this.rePlicatorActivity_ChildInitialized);
            this.replicatorActivity1.Initialized += new System.EventHandler(this.replicatorActivity1_Initialized);
            this.replicatorActivity1.SetBinding(System.Workflow.Activities.ReplicatorActivity.InitialChildDataProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            activitybind3.Name = "myWorkflow";
            activitybind3.Path = "workflowId";
            // 
            // onWorkflowActivated1
            // 
            correlationtoken1.Name = "workflowToken";
            correlationtoken1.OwnerActivityName = "myWorkflow";
            this.onWorkflowActivated1.CorrelationToken = correlationtoken1;
            this.onWorkflowActivated1.EventName = "OnWorkflowActivated";
            this.onWorkflowActivated1.Name = "onWorkflowActivated1";
            activitybind2.Name = "myWorkflow";
            activitybind2.Path = "workflowProperties";
            this.onWorkflowActivated1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onWorkflowActivated1_Invoked);
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            // 
            // myWorkflow
            // 
            this.Activities.Add(this.onWorkflowActivated1);
            this.Activities.Add(this.replicatorActivity1);
            this.Name = "myWorkflow";
            this.CanModifyActivities = false;

        }

        #endregion

        private ReTasksActivity reTasksActivity1;

        private ReplicatorActivity replicatorActivity1;

        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWorkflowActivated1;













































































    }
}
