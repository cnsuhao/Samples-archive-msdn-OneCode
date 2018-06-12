'****************************** Module Header ******************************\
' Module Name:    ReTasksActivity.vb
' Project:        VBSharePointReplicatorActivity
' Copyright (c) Microsoft Corporation
'
' This is the custom reusable activity. 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
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

Public Class ReTasksActivity
    Inherits SequenceActivity

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

#Region "TaskProperties"
    Public Property TaskTitle() As String
        Get
            Return m_TaskTitle
        End Get
        Set(ByVal value As String)
            m_TaskTitle = value
        End Set
    End Property
    Private m_TaskTitle As String
    Public Property TaskDescription() As String
        Get
            Return m_TaskDescription
        End Get
        Set(ByVal value As String)
            m_TaskDescription = value
        End Set
    End Property
    Private m_TaskDescription As String
    Public Property TaskAssignedTo() As String
        Get
            Return m_TaskAssignedTo
        End Get
        Set(ByVal value As String)
            m_TaskAssignedTo = value
        End Set
    End Property
    Private m_TaskAssignedTo As String
    Public Property TaskDueDate() As DateTime
        Get
            Return m_TaskDueDate
        End Get
        Set(ByVal value As DateTime)
            m_TaskDueDate = value
        End Set
    End Property
    Private m_TaskDueDate As DateTime
    Public TaskStatusFieldId As New Guid("c15b34c3-ce7d-490a-b133-3f4de8801b76")

#End Region

    ' Flag for while Condition
    Private isFinished As Boolean

    Private Sub createTask1_MethodInvoking(ByVal sender As Object, ByVal e As EventArgs)
        ' Create Task
        TaskId = Guid.NewGuid()

        ' Initialize an instance of SPWorkflowTaskProperties and set value.
        TaskProperties = New SPWorkflowTaskProperties()
        TaskProperties.Title = TaskTitle
        TaskProperties.Description = TaskDescription
        TaskProperties.AssignedTo = TaskAssignedTo
        TaskProperties.PercentComplete = 0
        TaskProperties.StartDate = DateTime.Today
        TaskProperties.DueDate = TaskDueDate
    End Sub

    ''' <summary>
    '''  Handler of OnTaskChanged.
    '''  Set the value of the loop condition flag according to the taskStatus.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>  
    Private Sub onTaskChanged1_Invoked(ByVal sender As Object, ByVal e As ExternalDataEventArgs)
        Dim taskStatus As String = AfterProperties.ExtendedProperties(TaskStatusFieldId).ToString()
        If taskStatus.Equals("Completed") Then
            isFinished = True
        End If
    End Sub

    ' Condition of while
    Private Sub while1Invoke(ByVal sender As Object, ByVal e As ConditionalEventArgs)
        e.Result = Not isFinished
    End Sub

    ' Handler of CompleteTask
    Private Sub completeTask1_MethodInvoking(ByVal sender As Object, ByVal e As EventArgs)
        TaskOutcome = "Task Complete"
    End Sub

    Public Shared TaskIdProperty As DependencyProperty = DependencyProperty.Register("TaskId", GetType(System.Guid), GetType(VBSharePointReplicatorActivity.ReTasksActivity))

    <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <BrowsableAttribute(True)> _
            <CategoryAttribute("Misc")> _
    Public Property TaskId As System.Guid
        Get
            Return CType(MyBase.GetValue(VBSharePointReplicatorActivity.ReTasksActivity.TaskIdProperty), System.Guid)

        End Get
        Set(ByVal value As System.Guid)
            MyBase.SetValue(VBSharePointReplicatorActivity.ReTasksActivity.TaskIdProperty, value)

        End Set
    End Property
    Public Shared TaskPropertiesProperty As DependencyProperty = DependencyProperty.Register("TaskProperties", GetType(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), GetType(VBSharePointReplicatorActivity.ReTasksActivity))

    <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <BrowsableAttribute(True)> _
            <CategoryAttribute("Misc")> _
    Public Property TaskProperties As SPWorkflowTaskProperties
        Get
            Return CType(MyBase.GetValue(VBSharePointReplicatorActivity.ReTasksActivity.TaskPropertiesProperty), Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)

        End Get
        Set(ByVal value As SPWorkflowTaskProperties)
            MyBase.SetValue(VBSharePointReplicatorActivity.ReTasksActivity.TaskPropertiesProperty, value)

        End Set
    End Property
    Public Shared TaskOutcomeProperty As DependencyProperty = DependencyProperty.Register("TaskOutcome", GetType(System.String), GetType(VBSharePointReplicatorActivity.ReTasksActivity))

    <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <BrowsableAttribute(True)> _
            <CategoryAttribute("Misc")> _
    Public Property TaskOutcome As System.String
        Get
            Return CType(MyBase.GetValue(VBSharePointReplicatorActivity.ReTasksActivity.TaskOutcomeProperty), String)

        End Get
        Set(ByVal value As System.String)
            MyBase.SetValue(VBSharePointReplicatorActivity.ReTasksActivity.TaskOutcomeProperty, value)

        End Set
    End Property
    Public Shared AfterPropertiesProperty As DependencyProperty = DependencyProperty.Register("AfterProperties", GetType(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), GetType(VBSharePointReplicatorActivity.ReTasksActivity))

    <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <BrowsableAttribute(True)> _
            <CategoryAttribute("Misc")> _
    Public Property AfterProperties As SPWorkflowTaskProperties
        Get
            Return CType(MyBase.GetValue(VBSharePointReplicatorActivity.ReTasksActivity.AfterPropertiesProperty), Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)

        End Get
        Set(ByVal value As SPWorkflowTaskProperties)
            MyBase.SetValue(VBSharePointReplicatorActivity.ReTasksActivity.AfterPropertiesProperty, value)

        End Set
    End Property
    Public Shared BeforePropertiesProperty As DependencyProperty = DependencyProperty.Register("BeforeProperties", GetType(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), GetType(VBSharePointReplicatorActivity.ReTasksActivity))

    <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <BrowsableAttribute(True)> _
            <CategoryAttribute("Misc")> _
    Public Property BeforeProperties As SPWorkflowTaskProperties
        Get
            Return CType(MyBase.GetValue(VBSharePointReplicatorActivity.ReTasksActivity.BeforePropertiesProperty), Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)

        End Get
        Set(ByVal value As SPWorkflowTaskProperties)
            MyBase.SetValue(VBSharePointReplicatorActivity.ReTasksActivity.BeforePropertiesProperty, value)

        End Set
    End Property
End Class