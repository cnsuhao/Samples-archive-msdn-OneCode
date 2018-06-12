
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateTaskWF

    'NOTE: The following procedure is required by the Workflow Designer
    'It can be modified using the Workflow Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Private Sub InitializeComponent()
        Me.CanModifyActivities = True
        Dim activitybind1 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind2 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind3 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim correlationtoken1 As System.Workflow.Runtime.CorrelationToken = New System.Workflow.Runtime.CorrelationToken()
        Dim activitybind4 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind5 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind6 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind7 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind8 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind9 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim correlationtoken2 As System.Workflow.Runtime.CorrelationToken = New System.Workflow.Runtime.CorrelationToken()
        Dim activitybind10 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind11 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind12 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind13 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim correlationtoken3 As System.Workflow.Runtime.CorrelationToken = New System.Workflow.Runtime.CorrelationToken()
        Dim activitybind14 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim codecondition1 As System.Workflow.Activities.CodeCondition = New System.Workflow.Activities.CodeCondition()
        Dim activitybind15 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind16 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind17 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim correlationtoken4 As System.Workflow.Runtime.CorrelationToken = New System.Workflow.Runtime.CorrelationToken()
        Dim activitybind18 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind19 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind20 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind21 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind22 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim correlationtoken5 As System.Workflow.Runtime.CorrelationToken = New System.Workflow.Runtime.CorrelationToken()
        Dim activitybind23 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Me.logUpdateTask = New Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity()
        Me.updateTask1 = New Microsoft.SharePoint.WorkflowActions.UpdateTask()
        Me.logTaskUpdated = New Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity()
        Me.onTaskChanged = New Microsoft.SharePoint.WorkflowActions.OnTaskChanged()
        Me.sequenceActivity1 = New System.Workflow.Activities.SequenceActivity()
        Me.logTaskComplete = New Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity()
        Me.completeTask = New Microsoft.SharePoint.WorkflowActions.CompleteTask()
        Me.whileActivity1 = New System.Workflow.Activities.WhileActivity()
        Me.logTaskCreated = New Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity()
        Me.createApprovalTask = New Microsoft.SharePoint.WorkflowActions.CreateTask()
        Me.logActivated = New Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity()
        Me.onWorkflowActivated1 = New Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated()
        '
        'logUpdateTask
        '
        Me.logUpdateTask.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808")
        Me.logUpdateTask.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment
        activitybind1.Name = "UpdateTaskWF"
        activitybind1.Path = "HistoryDescription"
        activitybind2.Name = "UpdateTaskWF"
        activitybind2.Path = "HistoryOutcome"
        Me.logUpdateTask.Name = "logUpdateTask"
        Me.logUpdateTask.OtherData = ""
        activitybind3.Name = "UpdateTaskWF"
        activitybind3.Path = "workflowProperties.OriginatorUser.ID"
        AddHandler Me.logUpdateTask.MethodInvoking, AddressOf Me.logUpdateTask_MethodInvoking
        Me.logUpdateTask.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, CType(activitybind1, System.Workflow.ComponentModel.ActivityBind))
        Me.logUpdateTask.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, CType(activitybind2, System.Workflow.ComponentModel.ActivityBind))
        Me.logUpdateTask.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.UserIdProperty, CType(activitybind3, System.Workflow.ComponentModel.ActivityBind))
        '
        'updateTask1
        '
        correlationtoken1.Name = "taskToken"
        correlationtoken1.OwnerActivityName = "UpdateTaskWF"
        Me.updateTask1.CorrelationToken = correlationtoken1
        Me.updateTask1.Name = "updateTask1"
        activitybind4.Name = "UpdateTaskWF"
        activitybind4.Path = "TaskId"
        activitybind5.Name = "UpdateTaskWF"
        activitybind5.Path = "TaskProperties"
        AddHandler Me.updateTask1.MethodInvoking, AddressOf Me.updateTask1_MethodInvoking
        Me.updateTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateTask.TaskPropertiesProperty, CType(activitybind5, System.Workflow.ComponentModel.ActivityBind))
        Me.updateTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateTask.TaskIdProperty, CType(activitybind4, System.Workflow.ComponentModel.ActivityBind))
        '
        'logTaskUpdated
        '
        Me.logTaskUpdated.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808")
        Me.logTaskUpdated.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment
        activitybind6.Name = "UpdateTaskWF"
        activitybind6.Path = "HistoryDescription"
        activitybind7.Name = "UpdateTaskWF"
        activitybind7.Path = "HistoryOutcome"
        Me.logTaskUpdated.Name = "logTaskUpdated"
        Me.logTaskUpdated.OtherData = ""
        activitybind8.Name = "UpdateTaskWF"
        activitybind8.Path = "workflowProperties.OriginatorUser.ID"
        AddHandler Me.logTaskUpdated.MethodInvoking, AddressOf Me.logTaskUpdated_MethodInvoking
        Me.logTaskUpdated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, CType(activitybind6, System.Workflow.ComponentModel.ActivityBind))
        Me.logTaskUpdated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, CType(activitybind7, System.Workflow.ComponentModel.ActivityBind))
        Me.logTaskUpdated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.UserIdProperty, CType(activitybind8, System.Workflow.ComponentModel.ActivityBind))
        '
        'onTaskChanged
        '
        activitybind9.Name = "UpdateTaskWF"
        activitybind9.Path = "TaskAfterProperties"
        Me.onTaskChanged.BeforeProperties = Nothing
        correlationtoken2.Name = "taskToken"
        correlationtoken2.OwnerActivityName = "UpdateTaskWF"
        Me.onTaskChanged.CorrelationToken = correlationtoken2
        Me.onTaskChanged.Executor = Nothing
        Me.onTaskChanged.Name = "onTaskChanged"
        activitybind10.Name = "UpdateTaskWF"
        activitybind10.Path = "TaskId"
        AddHandler Me.onTaskChanged.Invoked, AddressOf Me.onTaskChanged_Invoked
        Me.onTaskChanged.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.TaskIdProperty, CType(activitybind10, System.Workflow.ComponentModel.ActivityBind))
        Me.onTaskChanged.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.AfterPropertiesProperty, CType(activitybind9, System.Workflow.ComponentModel.ActivityBind))
        '
        'sequenceActivity1
        '
        Me.sequenceActivity1.Activities.Add(Me.onTaskChanged)
        Me.sequenceActivity1.Activities.Add(Me.logTaskUpdated)
        Me.sequenceActivity1.Activities.Add(Me.updateTask1)
        Me.sequenceActivity1.Activities.Add(Me.logUpdateTask)
        Me.sequenceActivity1.Name = "sequenceActivity1"
        '
        'logTaskComplete
        '
        Me.logTaskComplete.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808")
        Me.logTaskComplete.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment
        activitybind11.Name = "UpdateTaskWF"
        activitybind11.Path = "HistoryDescription"
        activitybind12.Name = "UpdateTaskWF"
        activitybind12.Path = "HistoryOutcome"
        Me.logTaskComplete.Name = "logTaskComplete"
        Me.logTaskComplete.OtherData = ""
        activitybind13.Name = "UpdateTaskWF"
        activitybind13.Path = "workflowProperties.OriginatorUser.ID"
        AddHandler Me.logTaskComplete.MethodInvoking, AddressOf Me.logTaskComplete_MethodInvoking
        Me.logTaskComplete.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, CType(activitybind11, System.Workflow.ComponentModel.ActivityBind))
        Me.logTaskComplete.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, CType(activitybind12, System.Workflow.ComponentModel.ActivityBind))
        Me.logTaskComplete.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.UserIdProperty, CType(activitybind13, System.Workflow.ComponentModel.ActivityBind))
        '
        'completeTask
        '
        correlationtoken3.Name = "taskToken"
        correlationtoken3.OwnerActivityName = "UpdateTaskWF"
        Me.completeTask.CorrelationToken = correlationtoken3
        Me.completeTask.Name = "completeTask"
        activitybind14.Name = "UpdateTaskWF"
        activitybind14.Path = "TaskId"
        Me.completeTask.TaskOutcome = ""
        Me.completeTask.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskIdProperty, CType(activitybind14, System.Workflow.ComponentModel.ActivityBind))
        '
        'whileActivity1
        '
        Me.whileActivity1.Activities.Add(Me.sequenceActivity1)
        AddHandler codecondition1.Condition, AddressOf Me.while1Invoke
        Me.whileActivity1.Condition = codecondition1
        Me.whileActivity1.Name = "whileActivity1"
        '
        'logTaskCreated
        '
        Me.logTaskCreated.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808")
        Me.logTaskCreated.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment
        activitybind15.Name = "UpdateTaskWF"
        activitybind15.Path = "HistoryDescription"
        activitybind16.Name = "UpdateTaskWF"
        activitybind16.Path = "HistoryOutcome"
        Me.logTaskCreated.Name = "logTaskCreated"
        Me.logTaskCreated.OtherData = ""
        activitybind17.Name = "UpdateTaskWF"
        activitybind17.Path = "workflowProperties.OriginatorUser.ID"
        AddHandler Me.logTaskCreated.MethodInvoking, AddressOf Me.logTaskCreated_MethodInvoking
        Me.logTaskCreated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, CType(activitybind15, System.Workflow.ComponentModel.ActivityBind))
        Me.logTaskCreated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, CType(activitybind16, System.Workflow.ComponentModel.ActivityBind))
        Me.logTaskCreated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.UserIdProperty, CType(activitybind17, System.Workflow.ComponentModel.ActivityBind))
        '
        'createApprovalTask
        '
        correlationtoken4.Name = "taskToken"
        correlationtoken4.OwnerActivityName = "UpdateTaskWF"
        Me.createApprovalTask.CorrelationToken = correlationtoken4
        Me.createApprovalTask.ListItemId = -1
        Me.createApprovalTask.Name = "createApprovalTask"
        Me.createApprovalTask.SpecialPermissions = Nothing
        activitybind18.Name = "UpdateTaskWF"
        activitybind18.Path = "TaskId"
        activitybind19.Name = "UpdateTaskWF"
        activitybind19.Path = "TaskProperties"
        AddHandler Me.createApprovalTask.MethodInvoking, AddressOf Me.createTask1_MethodInvoking
        Me.createApprovalTask.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, CType(activitybind19, System.Workflow.ComponentModel.ActivityBind))
        Me.createApprovalTask.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, CType(activitybind18, System.Workflow.ComponentModel.ActivityBind))
        '
        'logActivated
        '
        Me.logActivated.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808")
        Me.logActivated.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment
        activitybind20.Name = "UpdateTaskWF"
        activitybind20.Path = "HistoryDescription"
        activitybind21.Name = "UpdateTaskWF"
        activitybind21.Path = "HistoryOutcome"
        Me.logActivated.Name = "logActivated"
        Me.logActivated.OtherData = ""
        activitybind22.Name = "UpdateTaskWF"
        activitybind22.Path = "workflowProperties.OriginatorUser.ID"
        AddHandler Me.logActivated.MethodInvoking, AddressOf Me.logActivated_MethodInvoking
        Me.logActivated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, CType(activitybind20, System.Workflow.ComponentModel.ActivityBind))
        Me.logActivated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, CType(activitybind21, System.Workflow.ComponentModel.ActivityBind))
        Me.logActivated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.UserIdProperty, CType(activitybind22, System.Workflow.ComponentModel.ActivityBind))
        '
        'onWorkflowActivated1
        '
        correlationtoken5.Name = "workflowToken"
        correlationtoken5.OwnerActivityName = "UpdateTaskWF"
        Me.onWorkflowActivated1.CorrelationToken = correlationtoken5
        Me.onWorkflowActivated1.EventName = "OnWorkflowActivated"
        Me.onWorkflowActivated1.Name = "onWorkflowActivated1"
        activitybind23.Name = "UpdateTaskWF"
        activitybind23.Path = "workflowProperties"
        AddHandler Me.onWorkflowActivated1.Invoked, AddressOf Me.onWorkflowActivated1_Invoked
        Me.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, CType(activitybind23, System.Workflow.ComponentModel.ActivityBind))
        '
        'UpdateTaskWF
        '
        Me.Activities.Add(Me.onWorkflowActivated1)
        Me.Activities.Add(Me.logActivated)
        Me.Activities.Add(Me.createApprovalTask)
        Me.Activities.Add(Me.logTaskCreated)
        Me.Activities.Add(Me.whileActivity1)
        Me.Activities.Add(Me.completeTask)
        Me.Activities.Add(Me.logTaskComplete)
        Me.Name = "UpdateTaskWF"
        Me.CanModifyActivities = False

    End Sub
    Private logUpdateTask As Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity
    Private updateTask1 As Microsoft.SharePoint.WorkflowActions.UpdateTask
    Private logTaskUpdated As Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity
    Private onTaskChanged As Microsoft.SharePoint.WorkflowActions.OnTaskChanged
    Private sequenceActivity1 As System.Workflow.Activities.SequenceActivity
    Private logTaskComplete As Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity
    Private completeTask As Microsoft.SharePoint.WorkflowActions.CompleteTask
    Private whileActivity1 As System.Workflow.Activities.WhileActivity
    Private logTaskCreated As Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity
    Private createApprovalTask As Microsoft.SharePoint.WorkflowActions.CreateTask
    Private logActivated As Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity
    Private onWorkflowActivated1 As Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated


End Class
