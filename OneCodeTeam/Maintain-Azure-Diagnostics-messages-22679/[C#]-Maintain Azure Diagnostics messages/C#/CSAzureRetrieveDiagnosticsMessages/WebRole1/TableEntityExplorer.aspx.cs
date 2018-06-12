/****************************** Module Header ******************************\
Module Name:  TableEntityExplorer.aspx.cs
Project:      CSAzureRetrieveDiagnosticsMessages
Copyright (c) Microsoft Corporation.
 
This programe will show you how to retrieve diagnostics message and transfer them 
to Azure storage. And also it will show you how to view both logs in Table and logs
in blob.
 
 
Show the table list in Azure storage.
  
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace CSAzureRetrieveDiagnosticsMessages_WebRole
{
    public partial class TableEntityExplorer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    var account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
                    CloudTableClient tableClient = new CloudTableClient(account.TableEndpoint.ToString(),
                        account.Credentials);
                    var result = tableClient.ListTables();
                    List<string> tableNameList = result.ToList();

                    TreeNode node = new TreeNode("");


                    foreach (var item in tableNameList)
                    {
                        TreeNode tableNode = new TreeNode(item);

                        tableNode.NavigateUrl = "~/TableMessageViewer.aspx?TableName=" + item;
                        tableNode.Value = item;
                        node.ChildNodes.Add(tableNode);
                    }
                    this.tvTableDirectory.Nodes.Add(node);

                }
                catch
                {
                }  
            }
            
        }
    }
}