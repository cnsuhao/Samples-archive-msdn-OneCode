'****************************** Module Header ******************************\
' Module Name:    TaskEditForm.aspx.vb
' Project:        VBSharePointAlertTask
' Copyright (c) Microsoft Corporation
'
' This is the custom approve page
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports System
Imports Microsoft.SharePoint
Imports Microsoft.SharePoint.WebControls
Imports Microsoft.SharePoint.Utilities
Imports System.Web
Imports Microsoft.SharePoint.Workflow

Namespace Layouts.VBSharePointAlertTask

    Partial Public Class TaskEditForm
        Inherits LayoutsPageBase

        Protected Overrides Sub OnInit(ByVal e As EventArgs)
            AddHandler btnApprove.Click, AddressOf btnApprove_Click
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
        End Sub

        Protected ListId As String
        ' List Id
        Protected TaskList As SPList
        ' Task List
        Protected TaskItem As SPListItem
        ' Task Item
        Protected WorkflowInstanceId As Guid
        ' WorkflowInstance Id
        Protected WorkflowInstance As SPWorkflow
        ' Workflow Instance
        Protected ItemList As SPList
        ' Item List
        Protected Item As SPListItem
        ' SPListItem
        Protected Task As SPWorkflowTask
        ' SPWorkflowTask
        Protected TaskName As String

        Protected Overrides Sub OnLoad(ByVal e As EventArgs)

            ListId = Request.QueryString("List")
            TaskList = Web.Lists(New Guid(ListId))
            TaskItem = TaskList.GetItemById(Convert.ToInt32(Request.Params("ID")))
            WorkflowInstanceId = New Guid(DirectCast(TaskItem("WorkflowInstanceID"), String))
            WorkflowInstance = New SPWorkflow(Web, WorkflowInstanceId)
            Task = WorkflowInstance.Tasks(0)
            ItemList = WorkflowInstance.ParentList
            Item = ItemList.GetItemById(WorkflowInstance.ItemId)
            TaskName = TaskItem("Title").ToString()

            ' Url of the Item
            Dim UrlToItem As String = Web.Site.MakeFullUrl(Convert.ToString(ItemList.RootFolder.Url) & "\DispForm.aspx?ID=" & Item.ID.ToString())
            Dim ItemName As String
            If Item.File IsNot Nothing Then
                ItemName = Item.File.Name
            Else
                ItemName = Item.Title
            End If

            ' Bind value to control
            lnkItem.Text = ItemName
            lnkItem.NavigateUrl = UrlToItem
            lblListName.Text = ItemList.Title
            lblSiteUrl.Text = Web.Url
        End Sub

        ''' <summary>
        ''' Approve event
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub btnApprove_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim hashTable As New Hashtable()
            SetApprove("Approved", "Completed", hashTable, False)
            commitPopup()
        End Sub

        ''' <summary>
        ''' Cancel the operation
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
            commitPopup()
        End Sub



        ''' <summary>
        ''' Operating task.
        ''' </summary>
        ''' <param name="strFlag">TaskOutcome</param>
        ''' <param name="strTaskStatus">TaskStatus</param>
        ''' <param name="taskHashs">task Hashs</param>
        ''' <param name="isReassign">flag for reassign</param>
        Private Sub SetApprove(ByVal strFlag As String, ByVal strTaskStatus As String, ByVal taskHashs As Hashtable, ByVal isReassign As Boolean)
            Dim taskHash As Hashtable = taskHashs
            If taskHash.Count = 0 Then
                taskHash = New Hashtable()
                taskHash("TaskStatus") = strTaskStatus
            End If

            taskHash("TaskOutcome") = strFlag
            taskHash("Outcome") = strFlag
            taskHash("ApproverComments") = txtComments.Text
            taskHash.Add("isReassign", isReassign)

            ' Update specified task with the specified property value
            SPWorkflowTask.AlterTask(TaskItem, taskHash, True)
        End Sub

        Protected Sub btnReassign_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim taskHash As New Hashtable()
            taskHash("TaskStatus") = "Inprogress"

            taskHash.Add("ReAssignedTo", "administrator")

            SetApprove("Reassign", "in process", taskHash, True)
            commitPopup()
        End Sub

        ''' <summary>
        ''' Cancel the Workflow and task
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub btnCancelTask_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' cancel the task
            Dim taskHash As New Hashtable()
            taskHash("TaskStatus") = "Canceled"
            taskHash("Status") = "Canceled"
            SetApprove("CancelTask", "Canceled", taskHash, False)

            ' Cancel the Workflow
            ' SPWorkflowManager.CancelWorkflow(WorkflowInstance);

            ' Close the popup
            commitPopup()

        End Sub

        ''' <summary>
        ''' Close popup
        ''' </summary>
        Private Sub commitPopup()
            If Request("IsDlg") = "1" Then
                Context.Response.Write("<script type='text/javascript'>window.frameElement.commitPopup();</script>")
                Context.Response.Flush()
                Context.Response.[End]()
            Else
                SPUtility.Redirect(ItemList.DefaultViewUrl, SPRedirectFlags.UseSource, HttpContext.Current)
            End If
        End Sub

    End Class

End Namespace
