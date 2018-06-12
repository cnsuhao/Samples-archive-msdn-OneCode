/****************************** Module Header ******************************\
* Module Name:    PaginationWebPartUserControl.ascx.cs
* Project:        CSSharePointPaginationWebPart
* Copyright (c) Microsoft Corporation
*
* This sample code demonstrates how to implement Pagination through SPquery.
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
using Microsoft.SharePoint;

namespace CSSharePointPaginationWebPart.PaginationWebPart
{
    public partial class PaginationWebPartUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get the default page data
                BindData(null);
            }
        }

        /// <summary>
        /// Change the page no by the flag and then query the data based on the current page no
        /// and binding. 
        /// </summary>
        /// <param name="strOperation">The flag for changing page:Pre=Pervious page,Next=next Page,
        /// null=Default page
        /// </param>
        private void BindData(string strOperation)
        {
            // Current Page No
            int intCurrentPageNo = 1;

            if (!string.IsNullOrEmpty(strOperation))
            {
                // The Page count
                int iPageCount = 0;

                // Store the PageNo and PageCount by ViewState.
                if (ViewState["CurrentPageNo"] != null)
                {
                    intCurrentPageNo = Convert.ToInt32(ViewState["CurrentPageNo"]);
                }
                if (ViewState["PageCount"] != null)
                {
                    iPageCount = Convert.ToInt32(ViewState["PageCount"]);
                    ViewState["PageCount"] = iPageCount;
                }

                // If the current page number is not greater than the total number of pages.
                if (intCurrentPageNo <= iPageCount)
                {
                    switch (strOperation)
                    {
                        case "Pre":// Pervious Page
                            if (intCurrentPageNo > 1)
                            {
                                intCurrentPageNo = intCurrentPageNo - 1;
                            }
                            break;
                        case "Next":// Next Page
                            intCurrentPageNo = intCurrentPageNo + 1;
                            break;
                        default:
                            break;
                    }
                }
            }

            ViewState["CurrentPageNo"] = intCurrentPageNo;

            // Get current page's data and then bind to SPGridView
            SPListItemCollection items = GetListItems(5, intCurrentPageNo);
            GridView2.DataSource = items;
            GridView2.DataBind();
        }

        /// <summary>
        /// Get data by SPQuery
        /// </summary>
        /// <param name="rowlimit"></param>
        /// <param name="pageNo">Current PageNO</param>
        /// <returns></returns>
        SPListItemCollection GetListItems(int rowlimit, int pageNo)
        {
            // Your siteurl
            string SiteCollectionUrl = "http://localhost:7947";

            // Connect to Sharepoint Site
            using (SPSite site = new SPSite(SiteCollectionUrl))
            {
                // Open Sharepoint Site
                using (SPWeb oWebsiteRoot = site.OpenWeb())
                {
                    // Get the list by list name
                    SPList oList = oWebsiteRoot.Lists["test1"]; // list_name

                    // Get the number of the items in the list
                    int TotalListItems = oList.ItemCount;

                    // Get the count of the page
                    int iPageCount = (int)Math.Ceiling(TotalListItems / (decimal)rowlimit);

                    ViewState["PageCount"] = iPageCount;

                    // SPQuery
                    SPQuery query = new SPQuery();
                    query.RowLimit = (uint)rowlimit;                    
                    query.Query = "<OrderBy Override=\"TRUE\"><FieldRef Name=\"FileLeafRef\" /></OrderBy>";

                    int index = 1;
                    SPListItemCollection items;

                    do
                    {
                        items = oList.GetItems(query);
                        if (index == pageNo)
                            break;
                        query.ListItemCollectionPosition = items.ListItemCollectionPosition;
                        index++;
                    }
                    while (query.ListItemCollectionPosition != null);

                    return items;
                }
            }
        }

        /// <summary>
        /// Previous Page
        /// </summary>
        /// <param name="sender">btnPre button</param>
        /// <param name="e">Click</param>
        protected void btnPre_Click(object sender, EventArgs e)
        {
            BindData("Pre");
        }

        /// <summary>
        /// Next page
        /// </summary>
        /// <param name="sender">btnNext button</param>
        /// <param name="e">Click</param>
        protected void btnNext_Click(object sender, EventArgs e)
        {
            BindData("Next");
        }
    }
}
