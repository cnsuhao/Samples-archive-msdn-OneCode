/****************************** Module Header ******************************\
* Module Name:    Default.aspx.cs
* Project:        CSASPNETGridViewSingleChoiceByRadioButton 
* Copyright (c) Microsoft Corporation
*
* This page shows how to make a GridView "single selectable" by clicking the 
* radio button each time.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CSASPNETGridViewSingleChoiceByRadioButton 
{
    public partial class Default : System.Web.UI.Page
    {
        /// <summary>
        /// Create a dynamic datatable and store it into ViewState 
        /// for further use.
        /// </summary>
        private void MyDataBind()
        {
            if (ViewState["dt"] == null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(int));

                for (int i = 1; i < 21; ++i)
                {
                    dt.Rows.Add(i);
                }
                ViewState["dt"] = dt;
            }
            GridView1.DataSource = ViewState["dt"] as DataTable;
            GridView1.DataBind();
        }

        /// <summary>
        /// Initializing to bind with the generated data table.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MyDataBind();
            }
        }

        /// <summary>
        /// Change the current GridView's PageIndex
        /// </summary>
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }

        /// <summary>
        /// After changing the current GridView's PageIndex, rebind to the GridView.
        /// </summary>
        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            MyDataBind();
            GridView1.SelectedIndex = -1;
        }

        /// <summary>
        /// When choosing a radio button, get the selected row's primary key's value. 
        /// And make this row selected to change its background color.
        /// </summary>
        protected void radChoice_CheckedChanged(object sender, EventArgs e)
        {
            GridViewRow gr = ((Control)sender).NamingContainer as GridViewRow;
            lbId.Text = "The current selected row's primary key's value is：" +
                GridView1.DataKeys[gr.RowIndex].Value.ToString();
            GridView1.SelectedIndex = Convert.ToInt32(hidSelectedRowIndex.Value);
        }
    }
}