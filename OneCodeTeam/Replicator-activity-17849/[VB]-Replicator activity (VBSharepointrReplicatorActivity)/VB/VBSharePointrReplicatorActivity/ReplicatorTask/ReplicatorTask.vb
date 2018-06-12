'****************************** Module Header ******************************\
' Module Name:    ReplicatorTask.vb
' Project:        VBSharePointReplicatorActivity
' Copyright (c) Microsoft Corporation
'
' This is the workflow for demonstration Replicator.
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
Imports System.Xml.Serialization
Imports System.Xml

Public Class ReplicatorTask
    Inherits SequentialWorkflowActivity

    ' workflowProperties
    Public workflowProperties As New SPWorkflowActivationProperties
    ' workflowId
    Public workflowId As Guid = Nothing


    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    ' Handler of OnWorkflowActivated
    Private Sub onWorkflowActivated1_Invoked(ByVal sender As Object, ByVal e As ExternalDataEventArgs)
        workflowId = workflowProperties.WorkflowId
    End Sub

    Private Sub replicatorActivity1_Initialized(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a set of InitialChildData for task.
        ' De-serialize workflowProperties.InitiationData to get the initial form instance.
        Dim serializer As New XmlSerializer(GetType(AssociationData))
        Dim reader As New XmlTextReader(New System.IO.StringReader(workflowProperties.AssociationData))
        Dim wfData As AssociationData = DirectCast(serializer.Deserialize(reader), AssociationData)

        ' Set InitialChild Data
        InitialChildData = New ArrayList()
        For i As Integer = 0 To wfData.Partners.ContactList.Count - 1
            InitialChildData.Add(wfData.Partners.ContactList(i))
        Next

        ' Set data for first task       
        reTasksActivity1.TaskAssignedTo = InitialChildData(InitialChildData.Count - 1).ToString()
        reTasksActivity1.TaskTitle = "Vacation Request Approval"
        reTasksActivity1.TaskDescription = "Approve Vacation"
        reTasksActivity1.TaskDueDate = DateTime.Today.AddDays(7)
    End Sub

    Private Sub rePlicatorActivity_ChildInitialized(ByVal sender As Object, ByVal e As ReplicatorChildEventArgs)
        ' Looping through each assignee   
        reTasksActivity1.TaskAssignedTo = e.InstanceData.ToString()
        reTasksActivity1.TaskTitle = "Vacation Request Approval"
        reTasksActivity1.TaskDescription = "Approve Vacation"
        reTasksActivity1.TaskDueDate = DateTime.Today.AddDays(7)
    End Sub

    Public Shared InitialChildDataProperty As DependencyProperty = DependencyProperty.Register("InitialChildData", GetType(System.Collections.IList), GetType(VBSharePointReplicatorActivity.ReplicatorTask))

    ' InitialChildData
    <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <BrowsableAttribute(True)> _
            <CategoryAttribute("Properties")> _
    Public Property InitialChildData As System.Collections.IList
        Get
            Return CType(MyBase.GetValue(VBSharePointReplicatorActivity.ReplicatorTask.InitialChildDataProperty), System.Collections.IList)

        End Get
        Set(ByVal value As System.Collections.IList)
            MyBase.SetValue(VBSharePointReplicatorActivity.ReplicatorTask.InitialChildDataProperty, value)

        End Set
    End Property
End Class