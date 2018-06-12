/****************************** Module Header ******************************\
Module Name:  TableMessageViewer.aspx.cs
Project:      CSAzureRetrieveDiagnosticsMessages
Copyright (c) Microsoft Corporation.
 
This programe will show you how to retrieve diagnostics message and transfer them 
to Azure storage. And also it will show you how to view both logs in Table and logs
in blob.
 
 
This page will show all the message in WADLogsTable.
If you want to view other tables, please add the table entity to this project.
  
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Data.Services.Client;
using Microsoft.WindowsAzure;

namespace CSAzureRetrieveDiagnosticsMessages_WebRole
{
    public partial class Table : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // This page will show all the message in WADLogsTable.
            // If you want to view other tables, please add the table entity to this project.

            if (Request.QueryString["TableName"] == "WADLogsTable")
            {
                var statusMessage = string.Empty;
                try
                {
                    var account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
                    var context = new WADLogsTableDataServiceContext(account.TableEndpoint.ToString(), account.Credentials);

                    this.gdvMessageList.DataSource = context.WADLogs;
                    this.gdvMessageList.DataBind();
                }
                catch (DataServiceRequestException ex)
                {
                    statusMessage = "Unable to connect to the table storage server. Please check that the service is running.<br>"
                                     + ex.Message;
                }

                lbStatus.Text = statusMessage;
            }
            else
            {
                lbStatus.Text = "This example only support WADLogsTable table.";
            }
           
        }
        
    }
}