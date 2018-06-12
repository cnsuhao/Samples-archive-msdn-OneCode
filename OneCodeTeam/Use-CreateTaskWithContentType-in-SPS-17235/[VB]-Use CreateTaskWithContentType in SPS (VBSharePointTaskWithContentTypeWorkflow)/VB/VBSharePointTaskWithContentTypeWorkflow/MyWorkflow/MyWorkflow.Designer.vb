
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyWorkflow

    'NOTE: The following procedure is required by the Workflow Designer
    'It can be modified using the Workflow Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Private Sub InitializeComponent()
        Me.CanModifyActivities = True
        Dim activitybind1 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind2 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim correlationtoken1 As System.Workflow.Runtime.CorrelationToken = New System.Workflow.Runtime.CorrelationToken()
        Dim activitybind3 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind4 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind5 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim codecondition1 As System.Workflow.Activities.CodeCondition = New System.Workflow.Activities.CodeCondition()
        Dim activitybind6 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind7 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind8 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim correlationtoken2 As System.Workflow.Runtime.CorrelationToken = New System.Workflow.Runtime.CorrelationToken()
        Dim activitybind9 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Me.onTaskChanged1 = New Microsoft.SharePoint.WorkflowActions.OnTaskChanged()
        Me.sequenceActivity1 = New System.Workflow.Activities.SequenceActivity()
        Me.completeTask1 = New Microsoft.SharePoint.WorkflowActions.CompleteTask()
        Me.whileActivity1 = New System.Workflow.Activities.WhileActivity()
        Me.createTaskWithContentType1 = New Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType()
        Me.onWorkflowActivated1 = New Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated()
        '
        'onTaskChanged1
        '
        activitybind1.Name = "MyWorkflow"
        activitybind1.Path = "task1Changed1_AfterProperties"
        activitybind2.Name = "MyWorkflow"
        activitybind2.Path = "task1Changed1_BeforeProperties"
        correlationtoken1.Name = "task1"
        correlationtoken1.OwnerActivityName = "MyWorkflow"
        Me.onTaskChanged1.CorrelationToken = correlationtoken1
        Me.onTaskChanged1.Executor = Nothing
        Me.onTaskChanged1.Name = "onTaskChanged1"
        activitybind3.Name = "MyWorkflow"
        activitybind3.Path = "task1Guid"
        AddHandler Me.onTaskChanged1.Invoked, AddressOf Me.task1Changed1Invoke
        Me.onTaskChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.AfterPropertiesProperty, CType(activitybind1, System.Workflow.ComponentModel.ActivityBind))
        Me.onTaskChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.BeforePropertiesProperty, CType(activitybind2, System.Workflow.ComponentModel.ActivityBind))
        Me.onTaskChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.TaskIdProperty, CType(activitybind3, System.Workflow.ComponentModel.ActivityBind))
        '
        'sequenceActivity1
        '
        Me.sequenceActivity1.Activities.Add(Me.onTaskChanged1)
        Me.sequenceActivity1.Name = "sequenceActivity1"
        '
        'completeTask1
        '
        Me.completeTask1.CorrelationToken = correlationtoken1
        Me.completeTask1.Name = "completeTask1"
        activitybind4.Name = "MyWorkflow"
        activitybind4.Path = "task1Guid"
        activitybind5.Name = "MyWorkflow"
        activitybind5.Path = "task1Outcome"
        Me.completeTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskIdProperty, CType(activitybind4, System.Workflow.ComponentModel.ActivityBind))
        Me.completeTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskOutcomeProperty, CType(activitybind5, System.Workflow.ComponentModel.ActivityBind))
        '
        'whileActivity1
        '
        Me.whileActivity1.Activities.Add(Me.sequenceActivity1)
        AddHandler codecondition1.Condition, AddressOf Me.while1Invoke
        Me.whileActivity1.Condition = codecondition1
        Me.whileActivity1.Name = "whileActivity1"
        '
        'createTaskWithContentType1
        '
        activitybind6.Name = "MyWorkflow"
        activitybind6.Path = "task1ContentTypeId"
        Me.createTaskWithContentType1.CorrelationToken = correlationtoken1
        Me.createTaskWithContentType1.ListItemId = -1
        Me.createTaskWithContentType1.Name = "createTaskWithContentType1"
        Me.createTaskWithContentType1.SpecialPermissions = Nothing
        activitybind7.Name = "MyWorkflow"
        activitybind7.Path = "task1Guid"
        activitybind8.Name = "MyWorkflow"
        activitybind8.Path = "task1Properties"
        AddHandler Me.createTaskWithContentType1.MethodInvoking, AddressOf Me.createTask1Invoke
        Me.createTaskWithContentType1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType.TaskIdProperty, CType(activitybind7, System.Workflow.ComponentModel.ActivityBind))
        Me.createTaskWithContentType1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType.TaskPropertiesProperty, CType(activitybind8, System.Workflow.ComponentModel.ActivityBind))
        Me.createTaskWithContentType1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType.ContentTypeIdProperty, CType(activitybind6, System.Workflow.ComponentModel.ActivityBind))
        '
        'onWorkflowActivated1
        '
        correlationtoken2.Name = "workflowToken"
        correlationtoken2.OwnerActivityName = "MyWorkflow"
        Me.onWorkflowActivated1.CorrelationToken = correlationtoken2
        Me.onWorkflowActivated1.EventName = "OnWorkflowActivated"
        Me.onWorkflowActivated1.Name = "onWorkflowActivated1"
        activitybind9.Name = "MyWorkflow"
        activitybind9.Path = "workflowProperties"
        Me.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, CType(activitybind9, System.Workflow.ComponentModel.ActivityBind))
        '
        'MyWorkflow
        '
        Me.Activities.Add(Me.onWorkflowActivated1)
        Me.Activities.Add(Me.createTaskWithContentType1)
        Me.Activities.Add(Me.whileActivity1)
        Me.Activities.Add(Me.completeTask1)
        Me.Name = "MyWorkflow"
        Me.CanModifyActivities = False

    End Sub
    Private onTaskChanged1 As Microsoft.SharePoint.WorkflowActions.OnTaskChanged
    Private sequenceActivity1 As System.Workflow.Activities.SequenceActivity
    Private completeTask1 As Microsoft.SharePoint.WorkflowActions.CompleteTask
    Private whileActivity1 As System.Workflow.Activities.WhileActivity
    Private createTaskWithContentType1 As Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType
    Private onWorkflowActivated1 As Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated


End Class
