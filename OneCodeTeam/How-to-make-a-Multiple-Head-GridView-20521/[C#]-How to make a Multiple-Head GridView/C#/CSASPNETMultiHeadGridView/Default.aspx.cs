/****************************** Module Header ******************************\
* Module Name:    Default.aspx.cs
* Project:        CSASPNETMultiHeadGridView
* Copyright (c) Microsoft Corporation
*
* This is the main page of this sample that illustrates how to build
* the Multi-Head GridView
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
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace CSASPNETMultiHeadGridView
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handle the RowCreated event to create Multiple-Headed. 
        /// Create some TableCell's instance and then added to the 
        /// Header Row, and then added to the GridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gdvData_RowCreated(object sender, GridViewRowEventArgs e)
        {
            // To judge whether RowHeader.
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //TableCell for Header Row 1
                TableCell headerCell1 = new TableCell();
                TableCell headerCell2 = new TableCell();

                // The TableCell's definition
                headerCell1.ColumnSpan = 2;
                headerCell1.Text = "Main Header 1";
                headerCell1.BackColor = Color.LightGray;
                headerCell1.HorizontalAlign = HorizontalAlign.Center;

                // The TableCell's definition
                headerCell2.ColumnSpan = 3;
                headerCell2.Text = "Main Header 2";
                headerCell2.BackColor = Color.LightGray;
                headerCell2.HorizontalAlign = HorizontalAlign.Center;

                // Add TableCell to TableRow.Cells and then add tableRow to GridView(gdvData)
                GridViewRow rowHeader1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                rowHeader1.Cells.Add(headerCell1);
                rowHeader1.Cells.Add(headerCell2);
                rowHeader1.ForeColor = Color.Black;
                rowHeader1.Font.Bold = true;
                rowHeader1.Visible = true;
                gdvData.Controls[0].Controls.AddAt(0, rowHeader1);

                //TableCell for Header Row 2
                TableCell headerCell11 = new TableCell();
                TableCell headerCell12 = new TableCell();
                TableCell headerCell13 = new TableCell();

                headerCell11.ColumnSpan = 2;
                headerCell11.Text = "ID and Name";
                headerCell11.BackColor = Color.Maroon;

                headerCell12.ColumnSpan = 1;
                headerCell12.Text = "Age";
                headerCell12.BackColor = Color.Maroon;

                headerCell13.ColumnSpan = 2;
                headerCell13.Text = "Sex";
                headerCell13.BackColor = Color.Maroon;

                // Add TableCell to TableRow.Cells and then add tableRow to GridView(gdvData)
                GridViewRow rowHeader2 = new GridViewRow(1, 1, DataControlRowType.Header, DataControlRowState.Normal);
                rowHeader2.Cells.Add(headerCell11);
                rowHeader2.Cells.Add(headerCell12);
                rowHeader2.Cells.Add(headerCell13);

                rowHeader2.Font.Size = 12;
                rowHeader2.ForeColor = Color.White;
                rowHeader2.HorizontalAlign = HorizontalAlign.Center;
                rowHeader2.Visible = true;
                rowHeader2.Font.Bold = true;
                gdvData.Controls[0].Controls.AddAt(1, rowHeader2);
            }
        }
    }
}