
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReplicatorTask

    'NOTE: The following procedure is required by the Workflow Designer
    'It can be modified using the Workflow Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Private Sub InitializeComponent()
        Me.CanModifyActivities = True
        Dim activitybind1 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim correlationtoken1 As System.Workflow.Runtime.CorrelationToken = New System.Workflow.Runtime.CorrelationToken()
        Dim activitybind2 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Me.reTasksActivity1 = New VBSharePointReplicatorActivity.ReTasksActivity()
        Me.replicatorActivity1 = New System.Workflow.Activities.ReplicatorActivity()
        Me.onWorkflowActivated1 = New Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated()
        '
        'reTasksActivity1
        '
        Me.reTasksActivity1.AfterProperties = Nothing
        Me.reTasksActivity1.BeforeProperties = Nothing
        Me.reTasksActivity1.Name = "reTasksActivity1"
        Me.reTasksActivity1.TaskAssignedTo = Nothing
        Me.reTasksActivity1.TaskDescription = Nothing
        Me.reTasksActivity1.TaskDueDate = New Date(CType(0, Long))
        Me.reTasksActivity1.TaskId = New System.Guid("00000000-0000-0000-0000-000000000000")
        Me.reTasksActivity1.TaskOutcome = Nothing
        Me.reTasksActivity1.TaskProperties = Nothing
        Me.reTasksActivity1.TaskTitle = Nothing
        activitybind1.Name = "ReplicatorTask"
        activitybind1.Path = "InitialChildData"
        '
        'replicatorActivity1
        '
        Me.replicatorActivity1.Activities.Add(Me.reTasksActivity1)
        Me.replicatorActivity1.ExecutionType = System.Workflow.Activities.ExecutionType.Parallel
        Me.replicatorActivity1.Name = "replicatorActivity1"
        AddHandler Me.replicatorActivity1.ChildInitialized, AddressOf Me.rePlicatorActivity_ChildInitialized
        AddHandler Me.replicatorActivity1.Initialized, AddressOf Me.replicatorActivity1_Initialized
        Me.replicatorActivity1.SetBinding(System.Workflow.Activities.ReplicatorActivity.InitialChildDataProperty, CType(activitybind1, System.Workflow.ComponentModel.ActivityBind))
        '
        'onWorkflowActivated1
        '
        correlationtoken1.Name = "workflowToken"
        correlationtoken1.OwnerActivityName = "ReplicatorTask"
        Me.onWorkflowActivated1.CorrelationToken = correlationtoken1
        Me.onWorkflowActivated1.EventName = "OnWorkflowActivated"
        Me.onWorkflowActivated1.Name = "onWorkflowActivated1"
        activitybind2.Name = "ReplicatorTask"
        activitybind2.Path = "workflowProperties"
        AddHandler Me.onWorkflowActivated1.Invoked, AddressOf Me.onWorkflowActivated1_Invoked
        Me.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, CType(activitybind2, System.Workflow.ComponentModel.ActivityBind))
        '
        'ReplicatorTask
        '
        Me.Activities.Add(Me.onWorkflowActivated1)
        Me.Activities.Add(Me.replicatorActivity1)
        Me.Name = "ReplicatorTask"
        Me.CanModifyActivities = False

    End Sub
    Private reTasksActivity1 As VBSharePointReplicatorActivity.ReTasksActivity
    Private replicatorActivity1 As System.Workflow.Activities.ReplicatorActivity
    Private onWorkflowActivated1 As Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated


End Class
