'****************************** Module Header ******************************\
' Module Name:    TaskEditForm.aspx.vb
' Project:        VBSharePointUpdateTaskActivity
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

Imports System.Collections
Imports System.IO
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Xml
Imports System.Xml.Serialization
Imports Microsoft.SharePoint
Imports Microsoft.SharePoint.Utilities
Imports Microsoft.SharePoint.WebControls
Imports Microsoft.SharePoint.Workflow

Namespace MyWorkflow.Layouts.UpdateTaskWF

    Partial Public Class TaskEditForm
        Inherits LayoutsPageBase

        Protected Overrides Sub OnInit(e As EventArgs)
            AddHandler btnApprove.Click, AddressOf btnApprove_Click
            AddHandler btnReject.Click, AddressOf btnReject_Click
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
        End Sub

        ' List Id
        Protected ListId As String

        ' Task List
        Protected TaskList As SPList

        ' Task Item
        Protected TaskItem As SPListItem

        ' WorkflowInstance Id
        Protected WorkflowInstanceId As Guid

        ' Workflow Instance
        Protected WorkflowInstance As SPWorkflow

        ' Item List
        Protected ItemList As SPList

        ' SPListItem
        Protected Item As SPListItem

        ' SPWorkflowTask
        Protected Task As SPWorkflowTask

        Protected TaskName As String

        Protected Overrides Sub OnLoad(e As EventArgs)

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
        Protected Sub btnApprove_Click(sender As Object, e As EventArgs)
            SetApprove("Approved")
            commitPopup()
        End Sub

        ''' <summary>
        ''' Rejected event
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub btnReject_Click(sender As Object, e As EventArgs)
            SetApprove("Rejected")
            commitPopup()
        End Sub

        ''' <summary>
        ''' Cancel
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
            commitPopup()
        End Sub

        ''' <summary>
        ''' Approve operation
        ''' </summary>
        ''' <param name="strFlag"></param>
        Private Sub SetApprove(strFlag As String)
            Dim taskHash As New Hashtable()
            taskHash("TaskStatus") = "Completed"
            taskHash("TaskOutcome") = strFlag
            taskHash("Outcome") = strFlag
            taskHash("ApproverComments") = txtComments.Text

            ' Update specified task with the specified property value
            SPWorkflowTask.AlterTask(TaskItem, taskHash, True)
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
