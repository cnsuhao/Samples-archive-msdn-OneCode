
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyAlertTaskWF

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
        Dim correlationtoken2 As System.Workflow.Runtime.CorrelationToken = New System.Workflow.Runtime.CorrelationToken()
        Dim activitybind8 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind9 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind10 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind11 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim correlationtoken3 As System.Workflow.Runtime.CorrelationToken = New System.Workflow.Runtime.CorrelationToken()
        Dim activitybind12 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind13 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim codecondition1 As System.Workflow.Activities.CodeCondition = New System.Workflow.Activities.CodeCondition()
        Dim activitybind14 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind15 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim activitybind16 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Dim correlationtoken4 As System.Workflow.Runtime.CorrelationToken = New System.Workflow.Runtime.CorrelationToken()
        Dim activitybind17 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind()
        Me.logTaskComplete = New Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity()
        Me.completeTask = New Microsoft.SharePoint.WorkflowActions.CompleteTask()
        Me.logForTaskChanged = New Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity()
        Me.onTaskChanged = New Microsoft.SharePoint.WorkflowActions.OnTaskChanged()
        Me.logTaskCreated = New Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity()
        Me.createApprovalTask = New Microsoft.SharePoint.WorkflowActions.CreateTask()
        Me.sequenceActivity1 = New System.Workflow.Activities.SequenceActivity()
        Me.whileActivity1 = New System.Workflow.Activities.WhileActivity()
        Me.logActivated = New Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity()
        Me.onWFActivated = New Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated()
        '
        'logTaskComplete
        '
        Me.logTaskComplete.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808")
        Me.logTaskComplete.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment
        activitybind1.Name = "MyAlertTaskWF"
        activitybind1.Path = "HistoryDescription"
        activitybind2.Name = "MyAlertTaskWF"
        activitybind2.Path = "HistoryOutcome"
        Me.logTaskComplete.Name = "logTaskComplete"
        Me.logTaskComplete.OtherData = ""
        activitybind3.Name = "MyAlertTaskWF"
        activitybind3.Path = "workflowProperties.OriginatorUser.ID"
        AddHandler Me.logTaskComplete.MethodInvoking, AddressOf Me.logTaskComplete_MethodInvoking
        Me.logTaskComplete.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, CType(activitybind1, System.Workflow.ComponentModel.ActivityBind))
        Me.logTaskComplete.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, CType(activitybind2, System.Workflow.ComponentModel.ActivityBind))
        Me.logTaskComplete.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.UserIdProperty, CType(activitybind3, System.Workflow.ComponentModel.ActivityBind))
        '
        'completeTask
        '
        correlationtoken1.Name = "taskToken"
        correlationtoken1.OwnerActivityName = "sequenceActivity1"
        Me.completeTask.CorrelationToken = correlationtoken1
        Me.completeTask.Name = "completeTask"
        activitybind4.Name = "MyAlertTaskWF"
        activitybind4.Path = "TaskId"
        Me.completeTask.TaskOutcome = ""
        Me.completeTask.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskIdProperty, CType(activitybind4, System.Workflow.ComponentModel.ActivityBind))
        '
        'logForTaskChanged
        '
        Me.logForTaskChanged.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808")
        Me.logForTaskChanged.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment
        activitybind5.Name = "MyAlertTaskWF"
        activitybind5.Path = "HistoryDescription"
        activitybind6.Name = "MyAlertTaskWF"
        activitybind6.Path = "HistoryOutcome"
        Me.logForTaskChanged.Name = "logForTaskChanged"
        Me.logForTaskChanged.OtherData = ""
        Me.logForTaskChanged.UserId = -1
        Me.logForTaskChanged.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, CType(activitybind5, System.Workflow.ComponentModel.ActivityBind))
        Me.logForTaskChanged.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, CType(activitybind6, System.Workflow.ComponentModel.ActivityBind))
        '
        'onTaskChanged
        '
        activitybind7.Name = "MyAlertTaskWF"
        activitybind7.Path = "TaskAfterProperties"
        Me.onTaskChanged.BeforeProperties = Nothing
        correlationtoken2.Name = "taskToken"
        correlationtoken2.OwnerActivityName = "sequenceActivity1"
        Me.onTaskChanged.CorrelationToken = correlationtoken2
        Me.onTaskChanged.Executor = Nothing
        Me.onTaskChanged.Name = "onTaskChanged"
        activitybind8.Name = "MyAlertTaskWF"
        activitybind8.Path = "TaskId"
        AddHandler Me.onTaskChanged.Invoked, AddressOf Me.onTaskChanged_Invoked
        Me.onTaskChanged.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.TaskIdProperty, CType(activitybind8, System.Workflow.ComponentModel.ActivityBind))
        Me.onTaskChanged.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.AfterPropertiesProperty, CType(activitybind7, System.Workflow.ComponentModel.ActivityBind))
        '
        'logTaskCreated
        '
        Me.logTaskCreated.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808")
        Me.logTaskCreated.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment
        activitybind9.Name = "MyAlertTaskWF"
        activitybind9.Path = "HistoryOutcome"
        activitybind10.Name = "MyAlertTaskWF"
        activitybind10.Path = "HistoryDescription"
        Me.logTaskCreated.Name = "logTaskCreated"
        Me.logTaskCreated.OtherData = ""
        activitybind11.Name = "MyAlertTaskWF"
        activitybind11.Path = "workflowProperties.OriginatorUser.ID"
        AddHandler Me.logTaskCreated.MethodInvoking, AddressOf Me.logTaskCreated_MethodInvoking
        Me.logTaskCreated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, CType(activitybind9, System.Workflow.ComponentModel.ActivityBind))
        Me.logTaskCreated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, CType(activitybind10, System.Workflow.ComponentModel.ActivityBind))
        Me.logTaskCreated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.UserIdProperty, CType(activitybind11, System.Workflow.ComponentModel.ActivityBind))
        '
        'createApprovalTask
        '
        correlationtoken3.Name = "taskToken"
        correlationtoken3.OwnerActivityName = "sequenceActivity1"
        Me.createApprovalTask.CorrelationToken = correlationtoken3
        Me.createApprovalTask.ListItemId = -1
        Me.createApprovalTask.Name = "createApprovalTask"
        Me.createApprovalTask.SpecialPermissions = Nothing
        activitybind12.Name = "MyAlertTaskWF"
        activitybind12.Path = "TaskId"
        activitybind13.Name = "MyAlertTaskWF"
        activitybind13.Path = "TaskProperties"
        AddHandler Me.createApprovalTask.MethodInvoking, AddressOf Me.createTask1_MethodInvoking
        Me.createApprovalTask.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, CType(activitybind13, System.Workflow.ComponentModel.ActivityBind))
        Me.createApprovalTask.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, CType(activitybind12, System.Workflow.ComponentModel.ActivityBind))
        '
        'sequenceActivity1
        '
        Me.sequenceActivity1.Activities.Add(Me.createApprovalTask)
        Me.sequenceActivity1.Activities.Add(Me.logTaskCreated)
        Me.sequenceActivity1.Activities.Add(Me.onTaskChanged)
        Me.sequenceActivity1.Activities.Add(Me.logForTaskChanged)
        Me.sequenceActivity1.Activities.Add(Me.completeTask)
        Me.sequenceActivity1.Activities.Add(Me.logTaskComplete)
        Me.sequenceActivity1.Name = "sequenceActivity1"
        '
        'whileActivity1
        '
        Me.whileActivity1.Activities.Add(Me.sequenceActivity1)
        AddHandler codecondition1.Condition, AddressOf Me.while1Invoke
        Me.whileActivity1.Condition = codecondition1
        Me.whileActivity1.Name = "whileActivity1"
        '
        'logActivated
        '
        Me.logActivated.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808")
        Me.logActivated.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment
        activitybind14.Name = "MyAlertTaskWF"
        activitybind14.Path = "HistoryDescription"
        activitybind15.Name = "MyAlertTaskWF"
        activitybind15.Path = "HistoryOutcome"
        Me.logActivated.Name = "logActivated"
        Me.logActivated.OtherData = ""
        activitybind16.Name = "MyAlertTaskWF"
        activitybind16.Path = "workflowProperties.OriginatorUser.ID"
        AddHandler Me.logActivated.MethodInvoking, AddressOf Me.logActivated_MethodInvoking
        Me.logActivated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, CType(activitybind14, System.Workflow.ComponentModel.ActivityBind))
        Me.logActivated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, CType(activitybind15, System.Workflow.ComponentModel.ActivityBind))
        Me.logActivated.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.UserIdProperty, CType(activitybind16, System.Workflow.ComponentModel.ActivityBind))
        '
        'onWFActivated
        '
        correlationtoken4.Name = "workflowToken"
        correlationtoken4.OwnerActivityName = "MyAlertTaskWF"
        Me.onWFActivated.CorrelationToken = correlationtoken4
        Me.onWFActivated.EventName = "OnWorkflowActivated"
        Me.onWFActivated.Name = "onWFActivated"
        activitybind17.Name = "MyAlertTaskWF"
        activitybind17.Path = "workflowProperties"
        Me.onWFActivated.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, CType(activitybind17, System.Workflow.ComponentModel.ActivityBind))
        '
        'MyAlertTaskWF
        '
        Me.Activities.Add(Me.onWFActivated)
        Me.Activities.Add(Me.logActivated)
        Me.Activities.Add(Me.whileActivity1)
        Me.Name = "MyAlertTaskWF"
        Me.CanModifyActivities = False

    End Sub
    Private logTaskComplete As Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity
    Private completeTask As Microsoft.SharePoint.WorkflowActions.CompleteTask
    Private logForTaskChanged As Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity
    Private onTaskChanged As Microsoft.SharePoint.WorkflowActions.OnTaskChanged
    Private logTaskCreated As Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity
    Private createApprovalTask As Microsoft.SharePoint.WorkflowActions.CreateTask
    Private sequenceActivity1 As System.Workflow.Activities.SequenceActivity
    Private whileActivity1 As System.Workflow.Activities.WhileActivity
    Private logActivated As Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity
    Private onWFActivated As Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated


End Class
