'****************************** Module Header ******************************\
' Module Name:    MyAlertTaskWF.vb
' Project:        VBSharePointAlertTask
' Copyright (c) Microsoft Corporation
'
' This sample code will demo how to use AlertTask method to deal with a workflow task.
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
Imports System.Drawing
Imports System.Workflow.ComponentModel.Compiler
Imports System.Workflow.ComponentModel.Serialization
Imports System.Workflow.ComponentModel
Imports System.Workflow.ComponentModel.Design
Imports System.Workflow.Runtime
Imports System.Workflow.Activities
Imports System.Workflow.Activities.Rules
Imports Microsoft.SharePoint.Workflow
Imports Microsoft.SharePoint.WorkflowActions

Public Class MyAlertTaskWF
    Inherits SequentialWorkflowActivity

    Public workflowProperties As New SPWorkflowActivationProperties

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    ' workflow Id
    Public workflowId As New Guid

#Region "Properties"

    ' reassignee
    Private strReassignee As String = String.Empty
    ' flag for reassign
    Private isReassign As Boolean = False
    ' assignee
    Private assignee As String = Nothing
    ' init taskStatus
    Private strTaskStatus As String = "Pending Approval"

    'Flag for while.
    Private isFinished As Boolean = False
#End Region

    ''' <summary>
    ''' CreateTask Created
    ''' </summary>
    Private Sub createTask1_MethodInvoking(ByVal sender As Object, ByVal e As EventArgs)
        ' Generate new GUID used to initialize task correlation token 
        TaskId = Guid.NewGuid()

        If strReassignee IsNot Nothing AndAlso isReassign = True Then
            TaskProperties.AssignedTo = strReassignee
            TaskProperties.Title = String.Format("Review 2:【{0}】", Me.workflowProperties.Item.DisplayName)
        Else
            TaskProperties = New SPWorkflowTaskProperties()
            ' Assign initial properties prior to task creation 
            TaskProperties.Title = String.Format("Review:【{0}】", Me.workflowProperties.Item.DisplayName)
            TaskProperties.PercentComplete = 0
            TaskProperties.StartDate = DateTime.Today
            TaskProperties.DueDate = DateTime.Today.AddDays(3)
            TaskProperties.ExtendedProperties("TaskStatus") = strTaskStatus
            TaskProperties.AssignedTo = assignee
        End If

    End Sub

    'Condition of while
    Private Sub while1Invoke(ByVal sender As Object, ByVal e As ConditionalEventArgs)
        e.Result = Not isFinished
    End Sub

    ' Handler of OnTaskChanged
    Private Sub onTaskChanged_Invoked(ByVal sender As Object, ByVal e As ExternalDataEventArgs)
        Try
            isReassign = Boolean.Parse(TaskAfterProperties.ExtendedProperties("isReassign").ToString())
            If isReassign = True Then
                strReassignee = TaskAfterProperties.ExtendedProperties("ReAssignedTo").ToString()
                isFinished = False
            Else
                If TaskAfterProperties.ExtendedProperties("TaskStatus").ToString() = "Canceled" Then
                    isFinished = False
                Else
                    isFinished = (TaskAfterProperties.ExtendedProperties("TaskStatus").ToString() = "Completed")
                End If
            End If
        Catch ex As Exception

            logForTaskChanged.HistoryDescription = ex.ToString()
        End Try

    End Sub

    Private Sub logTaskComplete_MethodInvoking(ByVal sender As Object, ByVal e As EventArgs)
        HistoryDescription = "TaskOutcome: " & TaskAfterProperties.ExtendedProperties("TaskOutcome").ToString() & ";AssignedTo:" & Convert.ToString(TaskProperties.AssignedTo)

        HistoryOutcome = "Task Completed"
    End Sub

    Private Sub logForTaskChanged_MethodInvoking(ByVal sender As Object, ByVal e As EventArgs)
        HistoryDescription = "TaskOutcome: " & TaskAfterProperties.ExtendedProperties("TaskOutcome").ToString() & ";AssignedTo:" & Convert.ToString(TaskProperties.AssignedTo)

        HistoryOutcome = "Task Changed"
    End Sub

    Private Sub logActivated_MethodInvoking(ByVal sender As Object, ByVal e As EventArgs)
        HistoryDescription = "Workflow data: " & "Approver=seiya"
        HistoryOutcome = "Workflow activated"
    End Sub

    Private Sub logTaskCreated_MethodInvoking(ByVal sender As Object, ByVal e As EventArgs)
        HistoryDescription = "Task data: " & "AssignedTo=" & Convert.ToString(TaskProperties.AssignedTo) & "; " & "TaskStatus=" & TaskProperties.ExtendedProperties("TaskStatus").ToString() & "; " & "TaskTitle=" & Convert.ToString(TaskProperties.Title)
        HistoryOutcome = "Task created"
    End Sub

    Private Sub onWFActivated_Invoked(ByVal sender As Object, ByVal e As ExternalDataEventArgs)
        Try
            workflowId = workflowProperties.WorkflowId

            assignee = "seiya"
        Catch ex As Exception
            logActivated.HistoryDescription = ex.ToString()
        End Try
    End Sub
    Public Shared HistoryDescriptionProperty As DependencyProperty = DependencyProperty.Register("HistoryDescription", GetType(System.String), GetType(VBSharePointAlertTask.MyAlertTaskWF))

    <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <BrowsableAttribute(True)> _
            <CategoryAttribute("Misc")> _
    Public Property HistoryDescription As System.String
        Get
            Return CType(MyBase.GetValue(VBSharePointAlertTask.MyAlertTaskWF.HistoryDescriptionProperty), String)

        End Get
        Set(ByVal value As System.String)
            MyBase.SetValue(VBSharePointAlertTask.MyAlertTaskWF.HistoryDescriptionProperty, value)

        End Set
    End Property
    Public Shared HistoryOutcomeProperty As DependencyProperty = DependencyProperty.Register("HistoryOutcome", GetType(System.String), GetType(VBSharePointAlertTask.MyAlertTaskWF))

    <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <BrowsableAttribute(True)> _
            <CategoryAttribute("Misc")> _
    Public Property HistoryOutcome As System.String
        Get
            Return CType(MyBase.GetValue(VBSharePointAlertTask.MyAlertTaskWF.HistoryOutcomeProperty), String)

        End Get
        Set(ByVal value As System.String)
            MyBase.SetValue(VBSharePointAlertTask.MyAlertTaskWF.HistoryOutcomeProperty, value)

        End Set
    End Property
    Public Shared TaskIdProperty As DependencyProperty = DependencyProperty.Register("TaskId", GetType(System.Guid), GetType(VBSharePointAlertTask.MyAlertTaskWF))

    <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <BrowsableAttribute(True)> _
            <CategoryAttribute("Misc")> _
    Public Property TaskId As System.Guid
        Get
            Return CType(MyBase.GetValue(VBSharePointAlertTask.MyAlertTaskWF.TaskIdProperty), System.Guid)

        End Get
        Set(ByVal value As System.Guid)
            MyBase.SetValue(VBSharePointAlertTask.MyAlertTaskWF.TaskIdProperty, value)

        End Set
    End Property
    Public Shared TaskPropertiesProperty As DependencyProperty = DependencyProperty.Register("TaskProperties", GetType(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), GetType(VBSharePointAlertTask.MyAlertTaskWF))

    <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <BrowsableAttribute(True)> _
            <CategoryAttribute("Misc")> _
    Public Property TaskProperties As SPWorkflowTaskProperties
        Get
            Return CType(MyBase.GetValue(VBSharePointAlertTask.MyAlertTaskWF.TaskPropertiesProperty), Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)

        End Get
        Set(ByVal value As SPWorkflowTaskProperties)
            MyBase.SetValue(VBSharePointAlertTask.MyAlertTaskWF.TaskPropertiesProperty, value)

        End Set
    End Property
    Public Shared TaskAfterPropertiesProperty As DependencyProperty = DependencyProperty.Register("TaskAfterProperties", GetType(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), GetType(VBSharePointAlertTask.MyAlertTaskWF))

    <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <BrowsableAttribute(True)> _
            <CategoryAttribute("Misc")> _
    Public Property TaskAfterProperties As SPWorkflowTaskProperties
        Get
            Return CType(MyBase.GetValue(VBSharePointAlertTask.MyAlertTaskWF.TaskAfterPropertiesProperty), Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)

        End Get
        Set(ByVal value As SPWorkflowTaskProperties)
            MyBase.SetValue(VBSharePointAlertTask.MyAlertTaskWF.TaskAfterPropertiesProperty, value)

        End Set
    End Property
End Class