/****************************** Module Header ******************************\
* Module Name: TreeViewState.cs
* Project:     CSASPNETStripHtmlCode
* Copyright (c) Microsoft Corporation
*
* The code-sample illustrates how to maintain TreeView's state across postbacks.
* The web application use session store the TreeView nodes' status and restore
* them in the next postback event. This interesting function can be used as the
* signs of the navigator bar. 
* 
* This class provide the TreeView state handler methods.
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
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

namespace CSASPNETMaintainTreeViewState
{
    public class TreeViewState
    {
        /// <summary>
        /// The isSaved field use to check TreeView state was saved.
        /// </summary>
        private bool isSaved;
        public bool IsSaved
        {
            get
            {
                return isSaved;
            }
            set
            {
                isSaved = value;
            }
        }

        /// <summary>
        /// The class constructor method.
        /// </summary>
        /// <param name="key"></param>
        public TreeViewState(string key)
        {
            if (null == System.Web.HttpContext.Current.Session["TreeViewState"])
            {
                isSaved = false;
            }
            else
            {
                isSaved = true;
            }
        }

        /// <summary>
        /// Store TreeView's state in a session.
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="key"></param>
        /// <param name="context"></param>
        public void SaveTreeView(TreeView treeView, string key,HttpContext context)
        {
            context.Session[key] = treeView.Nodes;
        }

        /// <summary>
        /// Restore TreeView's state from session variable, and invoke SaveTreeView method.
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="key"></param>
        /// <param name="context"></param>
        public void RestoreTreeView(TreeView treeView, string key, HttpContext context)
        {
            if (new TreeViewState(key).IsSaved)
            {
                treeView.Nodes.Clear();

                TreeNodeCollection nodes = (TreeNodeCollection)context.Session[key];
                for (int index = nodes.Count - 1; index >= 0; index--)
                {
                    treeView.Nodes.AddAt(0, nodes[index]);
                }
                this.SaveTreeView(treeView, key, context);
            }
            
        }
    }
}