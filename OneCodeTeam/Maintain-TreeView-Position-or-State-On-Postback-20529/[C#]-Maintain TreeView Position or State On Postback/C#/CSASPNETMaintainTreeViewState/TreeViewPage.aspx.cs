/****************************** Module Header ******************************\
* Module Name: TreeViewPage.aspx.cs
* Project:     CSASPNETStripHtmlCode
* Copyright (c) Microsoft Corporation
*
* The code-sample illustrates how to maintain TreeView's state across postbacks.
* The web application use session store the TreeView node's status and restore
* them in the next postback event.
* 
* This page is used to maintain the state of TreeView control.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System;
using System.Web;

namespace CSASPNETMaintainTreeViewState
{
    public partial class TreeViewPage : System.Web.UI.Page
    {
        TreeViewState state;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Instantiate the TreeViewState class. This class is used to maintain TreeView node's
            // state and check if the state is saved.
            state = new TreeViewState("TreeViewState");
            if (!IsPostBack)
            {
                this.TreeViewBind();
            }
        }

        /// <summary>
        /// Restore TreeView.
        /// </summary>
        private void TreeViewBind()
        {
            if (state.IsSaved)
            {
                state.RestoreTreeView(tvwNodes, "TreeViewState", HttpContext.Current);
            }
        }

        /// <summary>
        /// Save TreeView's state 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveTreeViewState_Click(object sender, EventArgs e)
        {
            state.SaveTreeView(tvwNodes, "TreeViewState", HttpContext.Current);
        }

        /// <summary>
        /// Refresh the page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TreeViewPage.aspx");
        }
    }
}