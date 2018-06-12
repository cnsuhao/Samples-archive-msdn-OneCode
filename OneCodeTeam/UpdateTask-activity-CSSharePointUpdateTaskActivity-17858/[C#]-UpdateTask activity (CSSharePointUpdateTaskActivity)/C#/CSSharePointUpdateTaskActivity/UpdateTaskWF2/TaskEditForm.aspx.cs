/****************************** Module Header ******************************\
* Module Name:    TaskEditForm.aspx.cs
* Project:        CSSharePointUpdateTaskActivity
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
using System.Collections;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Workflow;

namespace MyWorkflow.Layouts.UpdateTaskWF2
{
    public partial class TaskEditForm : LayoutsPageBase
    {

        protected override void OnInit(EventArgs e)
        {
            btnApprove.Click += new EventHandler(btnApprove_Click);
            btnReject.Click += new EventHandler(btnReject_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        protected string ListId;    // List Id
        protected SPList TaskList;  // Task List
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
            SetApprove("Approved");
            commitPopup();
        }

        /// <summary>
        /// Rejected event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReject_Click(object sender, EventArgs e)
        {
            SetApprove("Rejected");
            commitPopup();
        }

        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            commitPopup();
        }

        /// <summary>
        /// Approve operation
        /// </summary>
        /// <param name="strFlag"></param>
        private void SetApprove(string strFlag)
        {
            Hashtable taskHash = new Hashtable();
            taskHash["TaskStatus"] = "Completed";
            taskHash["TaskOutcome"] = strFlag;
            taskHash["Outcome"] = strFlag;
            taskHash["ApproverComments"] = txtComments.Text;

            // Update specified task with the specified property value
            SPWorkflowTask.AlterTask(TaskItem, taskHash, true);
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
