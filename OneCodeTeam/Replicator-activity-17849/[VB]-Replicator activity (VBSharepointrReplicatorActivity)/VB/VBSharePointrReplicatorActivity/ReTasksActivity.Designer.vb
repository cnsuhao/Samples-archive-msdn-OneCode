
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReTasksActivity

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
        Dim correlationtoken2 As System.Workflow.Runtime.CorrelationToken = New System.Workflow.Runtime.CorrelationToken()
        Dim activitybind4 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind5 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim codecondition1 As System.Workflow.Activities.CodeCondition = New System.Workflow.Activities.CodeCondition()
        Dim correlationtoken3 As System.Workflow.Runtime.CorrelationToken = New System.Workflow.Runtime.CorrelationToken()
        Dim activitybind6 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind7 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Me.onTaskChanged1 = New Microsoft.SharePoint.WorkflowActions.OnTaskChanged()
        Me.completeTask1 = New Microsoft.SharePoint.WorkflowActions.CompleteTask()
        Me.whileActivity1 = New System.Workflow.Activities.WhileActivity()
        Me.createTask1 = New Microsoft.SharePoint.WorkflowActions.CreateTask()
        '
        'onTaskChanged1
        '
        activitybind1.Name = "ReTasksActivity"
        activitybind1.Path = "AfterProperties"
        activitybind2.Name = "ReTasksActivity"
        activitybind2.Path = "BeforeProperties"
        correlationtoken1.Name = "taskToken"
        correlationtoken1.OwnerActivityName = "ReTasksActivity"
        Me.onTaskChanged1.CorrelationToken = correlationtoken1
        Me.onTaskChanged1.Executor = Nothing
        Me.onTaskChanged1.Name = "onTaskChanged1"
        activitybind3.Name = "ReTasksActivity"
        activitybind3.Path = "TaskId"
        AddHandler Me.onTaskChanged1.Invoked, AddressOf Me.onTaskChanged1_Invoked
        Me.onTaskChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.BeforePropertiesProperty, CType(activitybind2, System.Workflow.ComponentModel.ActivityBind))
        Me.onTaskChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.TaskIdProperty, CType(activitybind3, System.Workflow.ComponentModel.ActivityBind))
        Me.onTaskChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.AfterPropertiesProperty, CType(activitybind1, System.Workflow.ComponentModel.ActivityBind))
        '
        'completeTask1
        '
        correlationtoken2.Name = "taskToken"
        correlationtoken2.OwnerActivityName = "ReTasksActivity"
        Me.completeTask1.CorrelationToken = correlationtoken2
        Me.completeTask1.Name = "completeTask1"
        activitybind4.Name = "ReTasksActivity"
        activitybind4.Path = "TaskId"
        activitybind5.Name = "ReTasksActivity"
        activitybind5.Path = "TaskOutcome"
        AddHandler Me.completeTask1.MethodInvoking, AddressOf Me.completeTask1_MethodInvoking
        Me.completeTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskOutcomeProperty, CType(activitybind5, System.Workflow.ComponentModel.ActivityBind))
        Me.completeTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskIdProperty, CType(activitybind4, System.Workflow.ComponentModel.ActivityBind))
        '
        'whileActivity1
        '
        Me.whileActivity1.Activities.Add(Me.onTaskChanged1)
        AddHandler codecondition1.Condition, AddressOf Me.while1Invoke
        Me.whileActivity1.Condition = codecondition1
        Me.whileActivity1.Name = "whileActivity1"
        '
        'createTask1
        '
        correlationtoken3.Name = "taskToken"
        correlationtoken3.OwnerActivityName = "ReTasksActivity"
        Me.createTask1.CorrelationToken = correlationtoken3
        Me.createTask1.ListItemId = -1
        Me.createTask1.Name = "createTask1"
        Me.createTask1.SpecialPermissions = Nothing
        activitybind6.Name = "ReTasksActivity"
        activitybind6.Path = "TaskId"
        activitybind7.Name = "ReTasksActivity"
        activitybind7.Path = "TaskProperties"
        AddHandler Me.createTask1.MethodInvoking, AddressOf Me.createTask1_MethodInvoking
        Me.createTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, CType(activitybind7, System.Workflow.ComponentModel.ActivityBind))
        Me.createTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, CType(activitybind6, System.Workflow.ComponentModel.ActivityBind))
        '
        'ReTasksActivity
        '
        Me.Activities.Add(Me.createTask1)
        Me.Activities.Add(Me.whileActivity1)
        Me.Activities.Add(Me.completeTask1)
        Me.Name = "ReTasksActivity"
        Me.CanModifyActivities = False

    End Sub
    Private onTaskChanged1 As Microsoft.SharePoint.WorkflowActions.OnTaskChanged
    Private completeTask1 As Microsoft.SharePoint.WorkflowActions.CompleteTask
    Private whileActivity1 As System.Workflow.Activities.WhileActivity
    Private createTask1 As Microsoft.SharePoint.WorkflowActions.CreateTask


End Class
