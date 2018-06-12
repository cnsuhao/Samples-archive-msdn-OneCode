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
    public sealed partial class ReTasksActivity
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
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind6 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind7 = new System.Workflow.ComponentModel.ActivityBind();
            this.onTaskChanged1 = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.completeTask1 = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.whileActivity1 = new System.Workflow.Activities.WhileActivity();
            this.createTask1 = new Microsoft.SharePoint.WorkflowActions.CreateTask();
            // 
            // onTaskChanged1
            // 
            activitybind1.Name = "ReTasksActivity";
            activitybind1.Path = "AfterProperties";
            activitybind2.Name = "ReTasksActivity";
            activitybind2.Path = "BeforeProperties";
            correlationtoken1.Name = "taskToken";
            correlationtoken1.OwnerActivityName = "ReTasksActivity";
            this.onTaskChanged1.CorrelationToken = correlationtoken1;
            this.onTaskChanged1.Executor = null;
            this.onTaskChanged1.Name = "onTaskChanged1";
            activitybind3.Name = "ReTasksActivity";
            activitybind3.Path = "TaskId";
            this.onTaskChanged1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskChanged1_Invoked);
            this.onTaskChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.onTaskChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.AfterPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.onTaskChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.BeforePropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            // 
            // completeTask1
            // 
            this.completeTask1.CorrelationToken = correlationtoken1;
            this.completeTask1.Name = "completeTask1";
            activitybind4.Name = "ReTasksActivity";
            activitybind4.Path = "TaskId";
            activitybind5.Name = "ReTasksActivity";
            activitybind5.Path = "TaskOutcome";
            this.completeTask1.MethodInvoking += new System.EventHandler(this.completeTask1_MethodInvoking);
            this.completeTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.completeTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            // 
            // whileActivity1
            // 
            this.whileActivity1.Activities.Add(this.onTaskChanged1);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.while1Invoke);
            this.whileActivity1.Condition = codecondition1;
            this.whileActivity1.Name = "whileActivity1";
            // 
            // createTask1
            // 
            this.createTask1.CorrelationToken = correlationtoken1;
            this.createTask1.ListItemId = -1;
            this.createTask1.Name = "createTask1";
            this.createTask1.SpecialPermissions = null;
            activitybind6.Name = "ReTasksActivity";
            activitybind6.Path = "TaskId";
            activitybind7.Name = "ReTasksActivity";
            activitybind7.Path = "TaskProperties";
            this.createTask1.MethodInvoking += new System.EventHandler(this.createTask1_MethodInvoking);
            this.createTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            this.createTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            // 
            // ReTasksActivity
            // 
            this.Activities.Add(this.createTask1);
            this.Activities.Add(this.whileActivity1);
            this.Activities.Add(this.completeTask1);
            this.Name = "ReTasksActivity";
            this.CanModifyActivities = false;

        }

        #endregion

        private WhileActivity whileActivity1;

        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeTask1;

        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged1;

        private Microsoft.SharePoint.WorkflowActions.CreateTask createTask1;


















    }
}
