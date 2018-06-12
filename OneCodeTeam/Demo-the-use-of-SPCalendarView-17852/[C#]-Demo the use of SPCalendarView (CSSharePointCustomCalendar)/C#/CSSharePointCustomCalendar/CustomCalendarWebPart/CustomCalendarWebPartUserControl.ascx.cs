/****************************** Module Header ******************************\
* Module Name:    CustomCalendarWebPartUserControl.ascx.cs
* Project:        CSSharePointCustomCalendar
* Copyright (c) Microsoft Corporation
*
* This sample demonstrates how to use SPCalendarView to develop a custom calendar
* in a visual web part.This is the UserControl. 
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
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint;
using System.Text;
using System.Data;

namespace CSSharePointCustomCalendar.CustomCalendarWebPart
{
    public partial class CustomCalendarWebPartUserControl : UserControl
    { 
        // SPCalendarView Control
        protected SPCalendarView spCalendarView;

        // Specifies the calendar for the add event. 
        static string strListName = "calendar";
        
        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            // Current web
            SPWeb web = SPContext.Current.Web;

            // List data
            DataTable results = GetQueryData(web);

            // Calendar Item Collection
            SPCalendarItemCollection items = GetCalendarItems(web, results);          

            spCalendarView.EnableViewState = true;

            // Calendar Type
            if (!string.IsNullOrEmpty(Page.Request["CalendarPeriod"]))
            {
                spCalendarView.ViewType = GetCalendarType(Page.Request["CalendarPeriod"]);
            }

            // Bind the datasource to the SPCalendarView
            spCalendarView.DataSource = items;
            spCalendarView.DataBind();         

            SPSecurity.RunWithElevatedPrivileges(
               delegate()
               {
                   // Check if current user can add events:
                   bool blnCanAddEvents = false;

                   using (web = SPContext.Current.Site.OpenWeb())
                   {
                       try
                       {
                           bool isHavePermissions = web.DoesUserHavePermissions(SPBasePermissions.AddListItems);

                           if (isHavePermissions)
                           {
                               blnCanAddEvents = true;
                           }
                       }
                       catch
                       {
                       }
                   }

                   // Render header firstly:
                   StringBuilder sbHeader = new StringBuilder();
                   sbHeader.AppendLine("<table align='center' width='100%' border='1' cellpadding='2' cellspacing='2'>");
                   sbHeader.AppendLine("<tr><th align='center'>");
                   sbHeader.AppendLine("<font color='#05C4D8' size='4'>My Custom Calendar</font>");
                   sbHeader.AppendLine("</th></table>");
                   Controls.Add(new LiteralControl(sbHeader.ToString()));

                   //Render calendar secondly:     
                   Controls.Add(spCalendarView);

                   // Append Operation legend:
                   StringBuilder sbLegend = new StringBuilder();
                   sbLegend.AppendLine("<table align='center' width='100%' border='0'>");
                   sbLegend.AppendLine("<td width='50%' align='left' valign='top'>");
                   sbLegend.AppendLine("<b><u>Operation:</u></b><br /><br />");
                   if (blnCanAddEvents)
                       sbLegend.AppendLine(String.Format("<li><a href=\"/Lists/{0}/NewForm.aspx\">Add New Event</a></li>", strListName));
                   sbLegend.AppendLine(String.Format("<li><a href=\"/Lists/{0}/\">View the Full Calendar</a></li>", strListName));
                   sbLegend.AppendLine("</td></table>");

                   Controls.Add(new LiteralControl(sbLegend.ToString()));
               });

        }

        /// <summary>
        /// Gets the type of the calendar view.
        /// </summary>
        /// <param name="type">The type to be checked.</param>
        /// <returns>Correct view type of calendar.</returns>
        protected static string GetCalendarType(string type)
        {
            if (type == null)
                type = string.Empty;
            switch (type.ToLower())
            {
                case "day":
                    return "day";
                case "week":
                    return "week";
                case "timeline":
                    return "timeline";
                default:
                    return "month";
            }
        }

        /// <summary>
        /// Executes the query against the web and returns 
        /// results as DataTable.
        /// </summary>
        /// <param name="web">The web that is queried.</param>
        /// <returns>Query results as DataTable.</returns>
        private DataTable GetQueryData(SPWeb web)
        {
            var query = new SPSiteDataQuery();

            query.Lists = @"<Lists>
                        <List ID='{080BA3CB-9D7F-4E6B-AE02-2E5BFB79EF91}' />
                        <List ID='{B65A63B6-B857-423A-AE22-AA7957E78157}' />
                    </Lists>";

            query.Query = @"<Where>
                        <Gt>
                            <FieldRef Name='ID' />
                            <Value Type='Number'>0</Value>
                        </Gt>
                    </Where>";

            query.Webs = "<Webs Scope='SiteCollection' />";
            query.ViewFields = "<FieldRef Name='Title' />";
            query.ViewFields += "<FieldRef Name='ID' />";
            query.ViewFields += "<FieldRef Name='EventDate' />";
            query.ViewFields += "<FieldRef Name='EndDate' />";
            query.ViewFields += "<FieldRef Name='Location' />";
            query.ViewFields += "<FieldRef Name='Description' />";
            query.ViewFields += "<FieldRef Name='fAllDayEvent' />";
            query.ViewFields += "<FieldRef Name='fRecurrence' />";
            query.RowLimit = 100;

            return web.GetSiteData(query);
        }

        /// <summary> 
        /// Gets the collection of calendar items based on site 
        /// data query results.
        /// </summary>
        /// <param name="web">The web that was queried.</param>
        /// <param name="results">The results of query.</param>
        /// <returns>Collection of calendar items accepted by 
        /// calendar component</returns>        
        private SPCalendarItemCollection GetCalendarItems(SPWeb web, DataTable results)
        {
            // Create a new collection for the calendar items
            var items = new SPCalendarItemCollection();

            // SPCalendar Item
            SPCalendarItem item = null;

            #region Calendar Items which are got from the results
            // Loop results to get Calendar Item Information
            foreach (DataRow row in results.Rows)
            {
                // List Guid
                var listGuid = new Guid(row["ListId"] as string);

                // List
                var list = web.Lists[listGuid];

                item = new SPCalendarItem();

                foreach (SPForm form in list.Forms)
                {
                    // Display Form Url
                    if (form.Type == PAGETYPE.PAGE_DISPLAYFORM)
                    {
                        item.DisplayFormUrl = form.ServerRelativeUrl;
                        break;
                    }
                }

                item.ItemID = row["ID"] as string;
                item.StartDate = DateTime.Parse(row["EventDate"] as string);
                item.EndDate = DateTime.Parse(row["EndDate"] as string);
                item.hasEndDate = true;
                item.Title = row["Title"] as string;
                item.Location = row["Location"] as string;
                item.Description = row["Description"] as string;
                item.IsAllDayEvent = (int.Parse(row["fAllDayEvent"] as string) != 0);
                item.IsRecurrence = (int.Parse(row["fRecurrence"] as string) != 0);
                item.CalendarType = Convert.ToInt32(SPCalendarType.Gregorian);

                items.Add(item);
            }
            #endregion
            #region Custom Calendar Item
            // This is an item with a start and end date. 
            // Add the first dummy item
            item = new SPCalendarItem();

            item.ItemID = "Select";
            item.Title = "First calendar item";
            item.StartDate = DateTime.Now;
            item.EndDate = DateTime.Now.AddHours(1);
            item.hasEndDate = true;
            item.DisplayFormUrl = "/News";
            item.Location = "USA";
            item.Description = "This is the first test item in the calendar rollup";
            item.IsAllDayEvent = false;
            item.IsRecurrence = false;
            item.CalendarType = Convert.ToInt32(SPCalendarType.Gregorian);
            items.Add(item);

            // Add the second item. This is an all day event.
            item = new SPCalendarItem();

            item.StartDate = DateTime.Now.AddDays(-1);
            item.hasEndDate = true;
            item.Title = "Second calendar item";
            item.DisplayFormUrl = "/News";
            item.Location = "India";
            item.Description = "This is the second test item in the calendar rollup";
            item.IsAllDayEvent = true;
            item.IsRecurrence = false;
            item.CalendarType = Convert.ToInt32(SPCalendarType.Gregorian);
            items.Add(item);
            #endregion

            return items;
        }
    }
}