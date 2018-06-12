/****************************** Module Header ******************************\
* Module Name: TreeViewPage.aspx.cs
* Project:     CSASPNETStripHtmlCode
* Copyright (c) Microsoft Corporation
*
* The code-sample illustrates how to maintain TreeView's state across postbacks.
* The web application use session store the TreeView nodes' status and restore
* them in the next postback event. This interesting function can be used as the
* signs of the navigator bar. 
* 
* This page use to maintain the state of TreeView control.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/



using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSASPNETMaintainTreeViewState
{
    public partial class TreeViewPage : System.Web.UI.Page
    {
        TreeViewState state;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Instantiate the TreeViewState class. This class use to maintain TreeView's nodes
            // state and check if the state was saved.
            state = new TreeViewState("TreeViewState");
            if (!IsPostBack)
            {
                this.TreeViewBind();
            }
        }

        /// <summary>
        /// The method use to bind TreeView with node's last save state across postback.
        /// </summary>
        private void TreeViewBind()
        {
            if (state.IsSaved)
            {
                state.RestoreTreeView(tvwNodes, "TreeViewState", HttpContext.Current);
            }
        }

        /// <summary>
        /// The button click event use to save TreeView's state 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveTreeViewState_Click(object sender, EventArgs e)
        {
            state.SaveTreeView(tvwNodes, "TreeViewState", HttpContext.Current);
        }

        /// <summary>
        /// Refresh this page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TreeViewPage.aspx");
        }
    }
}