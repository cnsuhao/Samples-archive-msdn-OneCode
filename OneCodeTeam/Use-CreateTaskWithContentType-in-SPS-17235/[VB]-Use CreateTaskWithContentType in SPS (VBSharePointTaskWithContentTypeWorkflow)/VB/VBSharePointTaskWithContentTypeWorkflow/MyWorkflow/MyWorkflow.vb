'****************************** Module Header ******************************\
' Module Name:    myWorkflow.vb
' Project:        VBSharePointTaskWithContentTypeWorkflow
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to Use CreateTaskWithContentType in SharePoint Visual Studio Workflow
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

Public Class MyWorkflow
    Inherits SequentialWorkflowActivity

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Public workflowId As Guid = Nothing


    Private Sub createTask1Invoke(sender As Object, e As EventArgs)
        task1Properties = New SPWorkflowTaskProperties()
        task1Properties.Title = String.Format("Please approval:【{0}】", workflowProperties.Item.DisplayName)
        task1Guid = Guid.NewGuid()
        task1ContentTypeId = "0x01080100FFbc98c2529347a5886b8d2576b954e3"
        'This is the Content type which is used by the workFlow
    End Sub

    'ContentTypeId of CreateTaskWithContentType
    Public Shared task1ContentTypeIdProperty As DependencyProperty = DependencyProperty.Register("task1ContentTypeId", GetType(System.String), GetType(MyWorkflow))

    Public Property task1ContentTypeId() As [String]
        Get
            Return DirectCast(MyBase.GetValue(MyWorkflow.task1ContentTypeIdProperty), String)
        End Get
        Set(value As [String])
            MyBase.SetValue(MyWorkflow.task1ContentTypeIdProperty, value)
        End Set
    End Property

    'TaskId of CreateTaskWithContentType
    Public Shared task1GuidProperty As DependencyProperty = DependencyProperty.Register("task1Guid", GetType(System.Guid), GetType(MyWorkflow))

    Public Property task1Guid() As Guid
        Get
            Return CType(MyBase.GetValue(MyWorkflow.task1GuidProperty), System.Guid)
        End Get
        Set(value As Guid)
            MyBase.SetValue(MyWorkflow.task1GuidProperty, value)
        End Set
    End Property

    'TaskProperties of CreateTaskWithContentType
    Public Shared task1PropertiesProperty As DependencyProperty = DependencyProperty.Register("task1Properties", GetType(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), GetType(MyWorkflow))

    Public Property task1Properties() As SPWorkflowTaskProperties
        Get
            Return DirectCast(MyBase.GetValue(MyWorkflow.task1PropertiesProperty), Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)
        End Get
        Set(value As SPWorkflowTaskProperties)
            MyBase.SetValue(MyWorkflow.task1PropertiesProperty, value)
        End Set
    End Property

    'AfterProperties of OnTaskChanged
    Public Shared task1Changed1_AfterPropertiesProperty As DependencyProperty = DependencyProperty.Register("task1Changed1_AfterProperties", GetType(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), GetType(MyWorkflow))

    Public Property task1Changed1_AfterProperties() As SPWorkflowTaskProperties
        Get
            Return DirectCast(MyBase.GetValue(MyWorkflow.task1Changed1_AfterPropertiesProperty), Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)
        End Get
        Set(value As SPWorkflowTaskProperties)
            MyBase.SetValue(MyWorkflow.task1Changed1_AfterPropertiesProperty, value)
        End Set
    End Property

    'BeforeProperties of OnTaskChanged
    Public Shared task1Changed1_BeforePropertiesProperty As DependencyProperty = DependencyProperty.Register("task1Changed1_BeforeProperties", GetType(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), GetType(MyWorkflow))

    Public Property task1Changed1_BeforeProperties() As SPWorkflowTaskProperties
        Get
            Return DirectCast(MyBase.GetValue(MyWorkflow.task1Changed1_BeforePropertiesProperty), Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)
        End Get
        Set(value As SPWorkflowTaskProperties)
            MyBase.SetValue(MyWorkflow.task1Changed1_BeforePropertiesProperty, value)
        End Set
    End Property

    Private isFinished As Boolean = False

    'Handler of OnTaskChanged
    Private Sub task1Changed1Invoke(sender As Object, e As ExternalDataEventArgs)
        'isFinished = task1Changed1_AfterProperties.PercentComplete = 1.0F
        isFinished = ((task1Changed1_AfterProperties.ExtendedProperties(SPBuiltInFieldId.TaskStatus).ToString()) = "Completed")
    End Sub

    Private Sub while1Invoke(sender As Object, e As ConditionalEventArgs)
        e.Result = Not isFinished
    End Sub

    'TaskOutcome of CompleteTask
    Public Shared task1OutcomeProperty As DependencyProperty = DependencyProperty.Register("task1Outcome", GetType(System.String), GetType(MyWorkflow))

    Public Property task1Outcome() As [String]
        Get
            Return DirectCast(MyBase.GetValue(MyWorkflow.task1OutcomeProperty), String)
        End Get
        Set(value As [String])
            MyBase.SetValue(MyWorkflow.task1OutcomeProperty, value)
        End Set
    End Property
    Public Shared workflowPropertiesProperty As DependencyProperty = DependencyProperty.Register("workflowProperties", GetType(Microsoft.SharePoint.Workflow.SPWorkflowActivationProperties), GetType(VBSharePointTaskWithContentTypeWorkflow.MyWorkflow))

    <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <BrowsableAttribute(True)> _
            <CategoryAttribute("Misc")> _
    Public Property workflowProperties As SPWorkflowActivationProperties
        Get
            Return CType(MyBase.GetValue(VBSharePointTaskWithContentTypeWorkflow.MyWorkflow.workflowPropertiesProperty), Microsoft.SharePoint.Workflow.SPWorkflowActivationProperties)

        End Get
        Set(value As SPWorkflowActivationProperties)
            MyBase.SetValue(VBSharePointTaskWithContentTypeWorkflow.MyWorkflow.workflowPropertiesProperty, value)

        End Set
    End Property
End Class