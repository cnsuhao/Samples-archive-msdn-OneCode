/****************************** Module Header ******************************\
Module Name:  SCForm.cs
Project:      CSWinformTFSTreeView
Copyright (c) Microsoft Corporation.
	 
SCForm Code Behind.
	 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx.
All other rights reserved.
	 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.OneCode.Utilities;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;
using CSWinformTFSTreeView.Properties;

namespace CSWinformTFSTreeView
{
    /// <summary>
    /// Source Control Form
    /// </summary>
    public partial class SCForm : Form
    {
        /// <summary>
        /// TFSContext to handle the tfs operations.
        /// </summary>
        private TfsContext tfsContext;

        public SCForm()
        {
            InitializeComponent();
        }

        #region Private Methods

        /// <summary>
        /// Initialize the Source Control TreeView.
        /// </summary>
        private void InitializeSourceControlBrowser()
        {
            tvwSourceBrowser.BeginUpdate();

            tvwSourceBrowser.ImageList = imageList;
            if (tfsContext == null)
            {
                return;
            }

            // Initialize the root TreeNode
            tvwSourceBrowser.Nodes.Clear();
            int rootImageIndex = 
                imageList.GetImageListIndex(Resources.FolderExtensionName);
            var rootTreeNode =
                new TreeNode(tfsContext.RootName, rootImageIndex, rootImageIndex)
                    {
                        Tag = "$/"
                    };
            rootTreeNode.Nodes.Add("");
            tvwSourceBrowser.Nodes.Add(rootTreeNode);

            tvwSourceBrowser.EndUpdate();
        }

        /// <summary>
        /// Create connection via TFSContext class
        /// </summary>
        /// <param name="tfsTeamProjectCollection">Team Foundation Server Team Project Collection</param>
        /// <returns></returns>
        private bool ConnectToTfs(TfsTeamProjectCollection tfsTeamProjectCollection)
        {
            if (tfsTeamProjectCollection != null && 
                tfsTeamProjectCollection.Uri != null &&
                tfsTeamProjectCollection.Name != null)
            {
                tfsContext = new TfsContext(tfsTeamProjectCollection.Uri, tfsTeamProjectCollection.Name);

                if (tfsContext.Connect())
                {
                    // Save Team Foundation Server Collection Uri, TreeView root node name
                    // to the configuration
                    DefaultSettingsProvider.SaveSettings(tfsTeamProjectCollection);
                    return true;
                }
            }
            
            return false;
        }

        /// <summary>
        /// Generate children TFSNode per the parentNode server path.
        /// </summary>
        /// <param name="parentNode">parent TreeNode</param>
        private void GenerateChildrenTfsTreeNode(TreeNode parentNode)
        {
            var currentNodeServerPath = parentNode.Tag as String;

            if (!String.IsNullOrEmpty(currentNodeServerPath))
            {
                parentNode.Nodes.Clear();

                ItemSet items = tfsContext.GetChildLevelTfsVcsItems(currentNodeServerPath);
                if (items != null && items.Items != null)
                {
                    // Filter the first item which is the self item.
                    for (int i = 1; i <= items.Items.Count() - 1; i++)
                    {
                        TreeNode tfsTreeNode =
                            CreateTfsTreeNode(items.Items[i].ServerItem, items.Items[i].ItemType);

                        if (tfsTreeNode != null)
                        {
                            parentNode.Nodes.Add(tfsTreeNode);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Create TreeNode per the tfs server item type
        /// If it's a folder type, use Folder icon for the node;
        /// If it's a file type, get the file type associated icon for the node.
        /// </summary>
        /// <param name="tfsServerItem">TFS Server item full path</param>
        /// <param name="tfsItemType">TFS Server item type</param>
        /// <returns>TreeNode for a tfs server item</returns>
        private TreeNode CreateTfsTreeNode(string tfsServerItem, ItemType tfsItemType)
        {
            TreeNode treeNode = null;
            if (!String.IsNullOrEmpty(tfsServerItem))
            {
                string nodeName = Path.GetFileName(tfsServerItem);
                if (!String.IsNullOrEmpty(nodeName))
                {
                    int imageIndex = 0;

                    treeNode = new TreeNode(nodeName);
                    switch (tfsItemType)
                    {
                        case ItemType.Folder:
                            imageIndex = imageList.GetImageListIndex(
                                Resources.FolderExtensionName);
                            treeNode.Nodes.Add(Resources.WaitingTreeNodeName);
                            break;
                        case ItemType.File:
                            string nodeExtension = Path.GetExtension(nodeName);
                            imageIndex = imageList.GetImageListIndex(nodeExtension);
                            break;
                    }

                    treeNode.ImageIndex = imageIndex;
                    treeNode.SelectedImageIndex = imageIndex;
                    treeNode.Tag = tfsServerItem;
                }
            }

            return treeNode;
        }

        #endregion


        #region Event Handler

        /// <summary>
        /// Click Event handler for button "Connect"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConnectClick(object sender, EventArgs e)
        {
            using (var tpp = new TeamProjectPicker(TeamProjectPickerMode.NoProject, false))
            {
                var defaultSelectionProvider = new DefaultSettingsProvider();
                tpp.SetDefaultSelectionProvider(defaultSelectionProvider);

                DialogResult result = tpp.ShowDialog();
                if (result == DialogResult.OK)
                {
                    bool isConnected = ConnectToTfs(tpp.SelectedTeamProjectCollection);

                    if (isConnected)
                    {
                        InitializeSourceControlBrowser();
                    }
                }
            }
        }

        /// <summary>
        /// Event handler for tree view browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TvwSourceBrowserBeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e != null && e.Node != null)
            {
                var currentNode = e.Node;

                var currentNodeServerPath = currentNode.Tag as String;

                if (!String.IsNullOrEmpty(currentNodeServerPath))
                {
                    IAsyncResult asyncResult = tvwSourceBrowser.BeginInvoke(
                            new Action<TreeNode>(GenerateChildrenTfsTreeNode),
                            currentNode);
                    tvwSourceBrowser.EndInvoke(asyncResult);
                }
            }
        }

        #endregion
    }
}
