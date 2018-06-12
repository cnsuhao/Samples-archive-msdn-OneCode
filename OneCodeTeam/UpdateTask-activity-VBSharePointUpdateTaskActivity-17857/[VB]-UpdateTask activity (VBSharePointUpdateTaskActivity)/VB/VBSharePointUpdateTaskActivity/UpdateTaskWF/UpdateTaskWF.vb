'****************************** Module Header ******************************\
' Module Name:    UpdateTaskWF.vb
' Project:        VBSharePointUpdateTaskActivity
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to Use UpdateTask activity in SharePoint Visual Studio Workflow.
' In this sample, we assume that the approval requires two steps, 
' the first person (the Approver) completes the first step in the approval,
' and then we will re-register the workflow to the second person.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Workflow.ComponentModel.Compiler
Imports System.Workflow.ComponentModel.Serialization
Imports System.Workflow.ComponentModel
Imports System.Workflow.ComponentModel.Design
Imports System.Workflow.Runtime
Imports System.Workflow.Activities
Imports System.Workflow.Activities.Rules
Imports Microsoft.SharePoint.Workflow
Imports Microsoft.SharePoint.WorkflowActions
Imports System.Collections.Specialized

Public Class UpdateTaskWF
    Inherits SequentialWorkflowActivity

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    ' workflow Id
    Public workflowId As New Guid

    ' Approver 
    Public Approver As [String] = String.Empty

    ' TaskStatus
    Private TaskStatus As String = "Pending Approval"

    ' Flag for while.
    Private isFinished As Boolean = False

#Region "Properties"
    Public workflowProperties As New SPWorkflowActivationProperties

    ''' <summary>
    ''' SpecialPermissions
    ''' </summary>
    Public ReadOnly Property SpecialPermissions() As HybridDictionary
        Get
            Dim taskPermissions As New HybridDictionary()
            taskPermissions(TaskProperties.AssignedTo) = SPRoleType.Contributor
            Return taskPermissions
        End Get
    End Property

    Public Shared HistoryDescriptionProperty As DependencyProperty = DependencyProperty.Register("HistoryDescription", GetType(System.String), GetType(VBSharePointUpdateTaskActivity.UpdateTaskWF))

    <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <BrowsableAttribute(True)> _
            <CategoryAttribute("Misc")> _
    Public Property HistoryDescription As System.String
        Get
            Return CType(MyBase.GetValue(VBSharePointUpdateTaskActivity.UpdateTaskWF.HistoryDescriptionProperty), String)

        End Get
        Set(value As System.String)
            MyBase.SetValue(VBSharePointUpdateTaskActivity.UpdateTaskWF.HistoryDescriptionProperty, value)

        End Set
    End Property
    Public Shared HistoryOutcomeProperty As DependencyProperty = DependencyProperty.Register("HistoryOutcome", GetType(System.String), GetType(VBSharePointUpdateTaskActivity.UpdateTaskWF))

    <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <BrowsableAttribute(True)> _
            <CategoryAttribute("Misc")> _
    Public Property HistoryOutcome As System.String
        Get
            Return CType(MyBase.GetValue(VBSharePointUpdateTaskActivity.UpdateTaskWF.HistoryOutcomeProperty), String)

        End Get
        Set(value As System.String)
            MyBase.SetValue(VBSharePointUpdateTaskActivity.UpdateTaskWF.HistoryOutcomeProperty, value)

        End Set
    End Property
    Public Shared TaskIdProperty As DependencyProperty = DependencyProperty.Register("TaskId", GetType(System.Guid), GetType(VBSharePointUpdateTaskActivity.UpdateTaskWF))

    <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <BrowsableAttribute(True)> _
            <CategoryAttribute("Misc")> _
    Public Property TaskId As System.Guid
        Get
            Return CType(MyBase.GetValue(VBSharePointUpdateTaskActivity.UpdateTaskWF.TaskIdProperty), System.Guid)

        End Get
        Set(value As System.Guid)
            MyBase.SetValue(VBSharePointUpdateTaskActivity.UpdateTaskWF.TaskIdProperty, value)

        End Set
    End Property

    Public Shared TaskPropertiesProperty As DependencyProperty = DependencyProperty.Register("TaskProperties", GetType(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), GetType(VBSharePointUpdateTaskActivity.UpdateTaskWF))

    <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <BrowsableAttribute(True)> _
            <CategoryAttribute("Misc")> _
    Public Property TaskProperties As SPWorkflowTaskProperties
        Get
            Return CType(MyBase.GetValue(VBSharePointUpdateTaskActivity.UpdateTaskWF.TaskPropertiesProperty), Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)

        End Get
        Set(value As SPWorkflowTaskProperties)
            MyBase.SetValue(VBSharePointUpdateTaskActivity.UpdateTaskWF.TaskPropertiesProperty, value)

        End Set
    End Property

    Public Shared TaskAfterPropertiesProperty As DependencyProperty = DependencyProperty.Register("TaskAfterProperties", GetType(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), GetType(VBSharePointUpdateTaskActivity.UpdateTaskWF))

    <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <BrowsableAttribute(True)> _
            <CategoryAttribute("Misc")> _
    Public Property TaskAfterProperties As SPWorkflowTaskProperties
        Get
            Return CType(MyBase.GetValue(VBSharePointUpdateTaskActivity.UpdateTaskWF.TaskAfterPropertiesProperty), Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)

        End Get
        Set(value As SPWorkflowTaskProperties)
            MyBase.SetValue(VBSharePointUpdateTaskActivity.UpdateTaskWF.TaskAfterPropertiesProperty, value)

        End Set
    End Property
#End Region

#Region "Log to History list"
    ''' <summary>
    ''' Log for Activate
    ''' </summary>
    Private Sub logActivated_MethodInvoking(sender As Object, e As EventArgs)
        HistoryDescription = "Workflow data: " & "Approver=" & Approver & "; "
        HistoryOutcome = "Workflow activated"
    End Sub

    ''' <summary>
    ''' Log for TaskCreated
    ''' </summary>
    Private Sub logTaskCreated_MethodInvoking(sender As Object, e As EventArgs)
        HistoryDescription += ("Task data: " & "AssignedTo=" & TaskProperties.AssignedTo & "; " & "TaskStatus=" & TaskProperties.ExtendedProperties("TaskStatus").ToString() & "; " & "TaskTitle=") + TaskProperties.Title
        HistoryOutcome = "Task created"
    End Sub

    ''' <summary>
    ''' Log for OnTaskChanged
    ''' </summary>
    Private Sub logTaskUpdated_MethodInvoking(sender As Object, e As EventArgs)
        HistoryOutcome = "Task updated"
        HistoryDescription = "TaskStatus: " & TaskAfterProperties.ExtendedProperties("TaskStatus").ToString() & "; " & "AssignedTo=" & TaskProperties.AssignedTo & "; " & "ApproverComments: " & TaskAfterProperties.ExtendedProperties("ApproverComments").ToString()
    End Sub

    ''' <summary>
    ''' Log for UpdateTask activity
    ''' </summary>
    Private Sub logUpdateTask_MethodInvoking(sender As Object, e As EventArgs)

        HistoryDescription = ("TaskStatus: " & TaskAfterProperties.ExtendedProperties("TaskStatus").ToString() & "; " & "TaskOutcome: " & TaskAfterProperties.ExtendedProperties("TaskOutcome").ToString() & ";AssignedTo:") + TaskProperties.AssignedTo & ";isFinished=" & isFinished

        HistoryOutcome = "Update Task"

    End Sub

    ''' <summary>
    ''' Log for TaskComplete
    ''' </summary>
    Private Sub logTaskComplete_MethodInvoking(sender As Object, e As EventArgs)
        HistoryDescription = ("TaskOutcome: " & TaskAfterProperties.ExtendedProperties("TaskOutcome").ToString() & ";AssignedTo:") + TaskProperties.AssignedTo

        HistoryOutcome = "Task Completed"
    End Sub
#End Region

#Region "Invoke"
    Private Sub onWorkflowActivated1_Invoked(sender As System.Object, e As System.Workflow.Activities.ExternalDataEventArgs)
        Approver = "v-seiyas"
    End Sub

    ''' <summary>
    ''' CreateTask Created
    ''' </summary>
    Private Sub createTask1_MethodInvoking(sender As System.Object, e As System.EventArgs)
        Try
            ' Generate a new GUID, it's used to initialize task correlation token. 
            TaskId = Guid.NewGuid()

            ' Assign initial properties prior to task creation 
            TaskProperties = New Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties
            TaskProperties.Title = String.Format("Review:【{0}】", workflowProperties.Item.DisplayName)
            TaskProperties.PercentComplete = 0
            TaskProperties.StartDate = DateTime.Today
            TaskProperties.DueDate = DateTime.Today.AddDays(3)
            TaskProperties.ExtendedProperties("TaskStatus") = TaskStatus
            TaskProperties.AssignedTo = Approver

            createApprovalTask.SpecialPermissions = SpecialPermissions
        Catch ex As Exception
            HistoryDescription = ex.Message
        End Try
    End Sub

    ' Condition of while
    Private Sub while1Invoke(sender As Object, e As ConditionalEventArgs)
        e.Result = Not isFinished
    End Sub

    ''' <summary>
    ''' Handler of onTaskChanged
    ''' </summary>
    Private Sub onTaskChanged_Invoked(sender As System.Object, e As System.Workflow.Activities.ExternalDataEventArgs)
        ' If this is the second approval, complete the workflow.
        If Not TaskProperties.AssignedTo.Equals(Approver) Then
            isFinished = (TaskAfterProperties.ExtendedProperties("TaskStatus").ToString() = "Completed")
        End If
    End Sub

    ''' <summary>
    ''' Handler of UpdateTask
    ''' </summary>
    Private Sub updateTask1_MethodInvoking(sender As System.Object, e As System.EventArgs)
        ' If this is the first approval, re-register the workflow to the second person.
        If TaskProperties.AssignedTo.Equals(Approver) Then
            Dim itemId As Integer = TaskAfterProperties.TaskItemId
            updateTask1.TaskProperties.TaskItemId = itemId
            updateTask1.TaskProperties.AssignedTo = "Seiya-MSFT\Seiya"
            updateTask1.TaskProperties.Title = String.Format("【{0}】", Me.workflowProperties.Item.DisplayName)
            updateTask1.TaskProperties.DueDate = DateTime.Today.AddDays(5)
        End If
    End Sub
#End Region
End Class