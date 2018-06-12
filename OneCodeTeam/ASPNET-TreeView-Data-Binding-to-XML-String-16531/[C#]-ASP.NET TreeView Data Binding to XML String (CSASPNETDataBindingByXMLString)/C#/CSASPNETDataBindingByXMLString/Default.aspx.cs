/****************************** Module Header ******************************\
* Module Name: Default.aspx.cs
* Project:     CSASPNETDataBindingByXMLString
* Copyright (c) Microsoft Corporation
*
* This code-sample demonstrates how to bind TreeView by using an XML string
* variable. The web application converts XML string to XML object and binds
* data to TreeView's nodes, the TreeViewBind() method supports binding with
* multilayer structure of XML object via recursion algorithm.
* 
* The Default.aspx page is use to show bind TreeView control by using XML string.
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
using System.Xml;

namespace CSASPNETDataBindingByXMLString
{
    public partial class Default : System.Web.UI.Page
    {
        XmlData data;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.TreeViewBind();
        }

        /// <summary>
        /// TreeViewBind() method, is use to load an XML string via XmlDocument
        /// object, and convert it to XML Object. Binding object to TreeView
        /// data source.
        /// </summary>
        private void TreeViewBind()
        {
            try
            {
                XmlDocument document = new XmlDocument();
                string strXmlString = this.GetXmlStringEvent();
                document.LoadXml(strXmlString);
                XmlNode nodeXml = document.DocumentElement;
                TreeNode nodeTree = null;
                foreach (XmlNode node in nodeXml.ChildNodes)
                {
                    nodeTree = new TreeNode();
                    XmlElement elementXml = (XmlElement)node;
                    nodeTree.Text = elementXml.GetAttribute("name").ToString();
                    this.AddChildNode(nodeTree, node);
                    this.tvwTreeView.Nodes.Add(nodeTree);
                }
            }
            catch (XmlException xmlEx)
            {
                Response.Write("XML string errors, please check your XmlData class.<br />");
                Response.Write(xmlEx.Message);
                tvwTreeView.Nodes.Clear();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                tvwTreeView.Nodes.Clear();
            }
        }


        /// <summary>
        /// This method is use to add child nodes to the TreeView nodes via 
        /// recursion algorithm. 
        /// </summary>
        /// <param name="nodeParent"></param>
        /// <param name="node"></param>
        private void AddChildNode(TreeNode nodeParent, XmlNode node)
        {
            TreeNode nodeTreeChild = null;
            foreach (XmlNode nodeChild in node.ChildNodes)
            {
                if (node.ChildNodes.Count == 0)
                {
                    nodeParent.ChildNodes.Add(nodeTreeChild);
                }
                else
                {
                    nodeTreeChild = new TreeNode();
                    XmlElement elementChild = (XmlElement)nodeChild;
                    nodeTreeChild.Text = elementChild.GetAttribute("name").ToString();
                    this.AddChildNode(nodeTreeChild, nodeChild);
                    nodeParent.ChildNodes.Add(nodeTreeChild);
                }
            }
        }

        /// <summary>
        /// Get XML string.
        /// </summary>
        /// <returns></returns>
        private string GetXmlStringEvent()
        {
            data = new XmlData();
            string strXmlString = data.GetXmlString();
            return strXmlString;
        }
    }
}