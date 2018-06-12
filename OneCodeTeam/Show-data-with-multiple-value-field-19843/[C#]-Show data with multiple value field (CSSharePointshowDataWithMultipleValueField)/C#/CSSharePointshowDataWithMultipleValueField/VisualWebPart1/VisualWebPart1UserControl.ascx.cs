/****************************** Module Header ******************************\
* Module Name:    VisualWebPart1UserControl.ascx.cs
* Project:        CSSharePointshowDataWithMultipleValueField
* Copyright (c) Microsoft Corporation
*
* This demo will show how to get data with multiple value field in a site collection.
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
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data;
using Microsoft.SharePoint;
using Microsoft.Office.Server.Search.Query;
using System.Collections.Generic;
using Microsoft.SharePoint.WebControls;

namespace CSSharePointshowDataWithMultipleValueField.VisualWebPart1
{
    public partial class VisualWebPart1UserControl : UserControl
    {
        /// <summary>
        /// Page_Load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {          
            // Bind data to GridView
            MyGridView.DataSource = GetFTSQueryItems();
            MyGridView.DataBind();
        }

        /// <summary>
        /// Using FullTextSqlQuery to get Items
        /// </summary>
        /// <returns></returns>
        public static DataTable GetFTSQueryItems()
        {
            // Create a DataTable to store data
            DataTable results = new DataTable();

            // The web site's URL
            string url = SPContext.Current.Web.Url;

            // Query text
            string queryText = "SELECT Title,AssignedTo,LastModifiedTime FROM SCOPE()";

            // Open the site
            using (SPSite site = new SPSite(url))
            {
                // Create a new FullTextSqlQuery class - use property initializers to set query
                FullTextSqlQuery fts = new FullTextSqlQuery(site);
                fts.QueryText = queryText;
                fts.ResultTypes = ResultType.RelevantResults;
                fts.RowLimit = 300;

                // Execute the query and load the results into the datatable
                ResultTableCollection rtc = fts.Execute();
                if (rtc.Count > 0)
                {
                    using (ResultTable relevantResults = rtc[ResultType.RelevantResults])
                        results.Load(relevantResults, LoadOption.OverwriteChanges);
                }

                return results;
            }
        }

        /// <summary>
        /// Bind the value of multiple value field (user-multi field in this sample) to SPGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SPGridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // The control will be used to show the multiple value field's value
                SPGridView gdvPeople = e.Row.Cells[1].FindControl("gdvPeople") as SPGridView;

                // A string array to store the multiple value field
                string[] userName = null;

                // Handle while the multiple value field's value is not null. 
                if (!((DataBinder.Eval(e.Row.DataItem, "AssignedTo")) is DBNull))
                {
                    userName = (string[])(DataBinder.Eval(e.Row.DataItem, "AssignedTo"));
                }

                // Create a table to store the multiple value field's value 
                DataTable tblUserName = new DataTable();
                tblUserName.Columns.Add("Uname");
               
                if (userName != null)
                {
                    string url = SPContext.Current.Web.Url;

                    using (SPSite site = new SPSite(url))
                    {
                        // Deal with the multiple value field's value
                        foreach (string item in userName)
                        {
                            if (item.Contains("#"))
                            {
                                string[] arrayUser = item.Split(';');

                                for (int i = 0; i < arrayUser.Length; i = i + 2)
                                {
                                    tblUserName.Rows.Add(arrayUser[i].Replace('#', ' ').Trim());
                                }
                            }
                            else
                            {
                                // add username to datatable
                                tblUserName.Rows.Add(item);
                            }
                        }
                    }

                    if (tblUserName.Rows.Count > 0)
                    {
                        gdvPeople.DataSource = tblUserName;
                    }
                    else
                    {
                        SetVisible(gdvPeople);
                    }                 
                }
                else
                {
                    SetVisible(gdvPeople);
                }

                gdvPeople.DataBind();
            }
        }

        /// <summary>
        /// Sets a value that indicates whether the SPGridView is rendered
        /// </summary>
        /// <param name="gdvPeople"></param>
        private static void SetVisible(SPGridView gdvPeople)
        {
            gdvPeople.DataSource = null;
            gdvPeople.Visible = false;
        }
    }
}
