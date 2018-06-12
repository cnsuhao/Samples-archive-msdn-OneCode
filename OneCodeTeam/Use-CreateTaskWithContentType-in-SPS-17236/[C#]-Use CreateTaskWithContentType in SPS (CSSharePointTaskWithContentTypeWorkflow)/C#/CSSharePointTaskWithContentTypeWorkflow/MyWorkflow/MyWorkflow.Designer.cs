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
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind6 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind7 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind8 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind10 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken2 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind9 = new System.Workflow.ComponentModel.ActivityBind();
            this.onTaskChanged1 = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
            this.completeTask1 = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.whileActivity1 = new System.Workflow.Activities.WhileActivity();
            this.createTaskWithContentType1 = new Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType();
            this.onWorkflowActivated1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
            // 
            // onTaskChanged1
            // 
            activitybind1.Name = "myWorkflow";
            activitybind1.Path = "task1Changed1_AfterProperties";
            activitybind2.Name = "myWorkflow";
            activitybind2.Path = "task1Changed1_BeforeProperties";
            correlationtoken1.Name = "task1";
            correlationtoken1.OwnerActivityName = "myWorkflow";
            this.onTaskChanged1.CorrelationToken = correlationtoken1;
            this.onTaskChanged1.Executor = null;
            this.onTaskChanged1.Name = "onTaskChanged1";
            activitybind3.Name = "myWorkflow";
            activitybind3.Path = "task1Guid";
            this.onTaskChanged1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.task1Changed1Invoke);
            this.onTaskChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.AfterPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.onTaskChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.BeforePropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.onTaskChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            // 
            // sequenceActivity1
            // 
            this.sequenceActivity1.Activities.Add(this.onTaskChanged1);
            this.sequenceActivity1.Name = "sequenceActivity1";
            // 
            // completeTask1
            // 
            this.completeTask1.CorrelationToken = correlationtoken1;
            this.completeTask1.Name = "completeTask1";
            activitybind4.Name = "myWorkflow";
            activitybind4.Path = "task1Guid";
            activitybind5.Name = "myWorkflow";
            activitybind5.Path = "task1Outcome";        
            this.completeTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.completeTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            // 
            // whileActivity1
            // 
            this.whileActivity1.Activities.Add(this.sequenceActivity1);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.while1Invoke);
            this.whileActivity1.Condition = codecondition1;
            this.whileActivity1.Name = "whileActivity1";
            // 
            // createTaskWithContentType1
            // 
            activitybind6.Name = "myWorkflow";
            activitybind6.Path = "task1ContentTypeId";
            this.createTaskWithContentType1.CorrelationToken = correlationtoken1;
            this.createTaskWithContentType1.ListItemId = -1;
            this.createTaskWithContentType1.Name = "createTaskWithContentType1";
            this.createTaskWithContentType1.SpecialPermissions = null;
            activitybind7.Name = "myWorkflow";
            activitybind7.Path = "task1Guid";
            activitybind8.Name = "myWorkflow";
            activitybind8.Path = "task1Properties";
            this.createTaskWithContentType1.MethodInvoking += new System.EventHandler(this.createTask1Invoke);
            this.createTaskWithContentType1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            this.createTaskWithContentType1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            this.createTaskWithContentType1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            activitybind10.Name = "myWorkflow";
            activitybind10.Path = "workflowId";
            // 
            // onWorkflowActivated1
            // 
            correlationtoken2.Name = "workflowToken";
            correlationtoken2.OwnerActivityName = "myWorkflow";
            this.onWorkflowActivated1.CorrelationToken = correlationtoken2;
            this.onWorkflowActivated1.EventName = "OnWorkflowActivated";
            this.onWorkflowActivated1.Name = "onWorkflowActivated1";
            activitybind9.Name = "myWorkflow";
            activitybind9.Path = "workflowProperties";
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            // 
            // myWorkflow
            // 
            this.Activities.Add(this.onWorkflowActivated1);
            this.Activities.Add(this.createTaskWithContentType1);
            this.Activities.Add(this.whileActivity1);
            this.Activities.Add(this.completeTask1);
            this.Name = "myWorkflow";
            this.CanModifyActivities = false;

        }

        #endregion

        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeTask1;

        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged1;

        private SequenceActivity sequenceActivity1;

        private WhileActivity whileActivity1;

        private Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType createTaskWithContentType1;

        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWorkflowActivated1;
























    }
}
