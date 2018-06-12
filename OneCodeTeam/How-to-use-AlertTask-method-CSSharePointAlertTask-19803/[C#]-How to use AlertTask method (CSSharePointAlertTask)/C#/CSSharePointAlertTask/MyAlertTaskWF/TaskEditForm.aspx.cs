/****************************** Module Header ******************************\
* Module Name:    TaskEditForm.aspx.cs
* Project:        CSSharePointAlertTask
* Copyright (c) Microsoft Corporation
*
* This is the custom approve page
* 
*' This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
******************************************************************************/

using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Collections;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Utilities;
using System.Web;

namespace CSSharePointAlertTask.Layouts.CSSharePointAlertTask
{
    public partial class TaskEditForm : LayoutsPageBase
    {

        protected override void OnInit(EventArgs e)
        {
            btnApprove.Click += new EventHandler(btnApprove_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        protected string ListId; // List Id
        protected SPList TaskList; // Task List
        protected SPListItem TaskItem;  // Task Item
        protected Guid WorkflowInstanceId;  // WorkflowInstance Id
        protected SPWorkflow WorkflowInstance;  // Workflow Instance
        protected SPList ItemList;  // Item List
        protected SPListItem Item;  // SPListItem
        protected SPWorkflowTask Task;  // SPWorkflowTask
        protected string TaskName;

        protected override void OnLoad(EventArgs e)
        {

            ListId = Request.QueryString["List"];
            TaskList = Web.Lists[new Guid(ListId)];
            TaskItem = TaskList.GetItemById(Convert.ToInt32(Request.Params["ID"]));
            WorkflowInstanceId = new Guid((string)TaskItem["WorkflowInstanceID"]);
            WorkflowInstance = new SPWorkflow(Web, WorkflowInstanceId);
            Task = WorkflowInstance.Tasks[0];
            ItemList = WorkflowInstance.ParentList;
            Item = ItemList.GetItemById(WorkflowInstance.ItemId);
            TaskName = TaskItem["Title"].ToString();

            // Url of the Item
            string UrlToItem = Web.Site.MakeFullUrl(ItemList.RootFolder.Url +
                                                    @"\DispForm.aspx?ID=" +
                                                    Item.ID.ToString());
            string ItemName;
            if (Item.File != null)
            {
                ItemName = Item.File.Name;
            }
            else
            {
                ItemName = Item.Title;
            }

            // Bind value to control
            lnkItem.Text = ItemName;
            lnkItem.NavigateUrl = UrlToItem;
            lblListName.Text = ItemList.Title;
            lblSiteUrl.Text = Web.Url;
        }

        /// <summary>
        /// Approve event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            Hashtable hashTable = new Hashtable();
            SetApprove("Approved", "Completed", hashTable, false);
            commitPopup();
        }

        /// <summary>
        /// Cancel the operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            commitPopup();
        }



        /// <summary>
        /// Operating task.
        /// </summary>
        /// <param name="strFlag">TaskOutcome</param>
        /// <param name="strTaskStatus">TaskStatus</param>
        /// <param name="taskHashs">task Hashes</param>
        /// <param name="isReassign">flag for reassign</param>
        private void SetApprove(string strFlag, string strTaskStatus, Hashtable taskHashs, bool isReassign)
        {
            Hashtable taskHash = taskHashs;
            if (taskHash.Count == 0)
            {
                taskHash = new Hashtable();
                taskHash["TaskStatus"] = strTaskStatus;
            }

            taskHash["TaskOutcome"] = strFlag;
            taskHash["Outcome"] = strFlag;
            taskHash["ApproverComments"] = txtComments.Text;
            taskHash.Add("isReassign", isReassign);

            // Update specified task with the specified property value
            SPWorkflowTask.AlterTask(TaskItem, taskHash, true);
        }

        protected void btnReassign_Click(object sender, EventArgs e)
        {
            Hashtable taskHash = new Hashtable();
            taskHash["TaskStatus"] = "Inprogress";

            taskHash.Add("ReAssignedTo", "administrator");

            SetApprove("Reassign", "in process", taskHash, true);
            commitPopup();
        }

        /// <summary>
        /// Cancel the Workflow and task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancelTask_Click(object sender, EventArgs e)
        {
            // Cancel the task
            Hashtable taskHash = new Hashtable();
            taskHash["TaskStatus"] = "Canceled";
            taskHash.Add(SPBuiltInFieldId.Outcome, "Canceled");

            SetApprove("CancelTask", "Canceled", taskHash, false);

            // Cancel the Workflow
            // SPWorkflowManager.CancelWorkflow(WorkflowInstance);

            //Close the popup
            commitPopup();

        }

        /// <summary>
        /// Close popup
        /// </summary>
        private void commitPopup()
        {
            if (Request["IsDlg"] == "1")
            {
                Context.Response.Write("<script type='text/javascript'>window.frameElement.commitPopup();</script>");
                Context.Response.Flush();
                Context.Response.End();
            }
            else
            {
                SPUtility.Redirect(ItemList.DefaultViewUrl, SPRedirectFlags.UseSource, HttpContext.Current);
            }
        }
    }
}
