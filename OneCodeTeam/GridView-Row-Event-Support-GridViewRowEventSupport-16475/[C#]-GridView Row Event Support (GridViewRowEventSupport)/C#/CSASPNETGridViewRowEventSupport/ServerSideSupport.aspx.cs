/****************************** Module Header ******************************\
* Module Name:    ServerSideSupport.aspx.cs
* Project:        CSASPNETGridViewRowEventSupport
* Copyright (c) Microsoft Corporation
*
* The page shows how to add GridView RowEvent Support on ServerSide.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSASPNETGridViewRowEventSupport
{
    public partial class ServerSideSupport : System.Web.UI.Page
    {
        /// <summary>
        /// Register the postback or callback data for validation. 
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            for (int i = 0; i < gvCustomer.Rows.Count; i++)
                ClientScript.RegisterForEventValidation(gvCustomer.UniqueID, "Edit$" + i);
            base.Render(writer);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvCustomer_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Returns a string that can be used in a client event to cause postback to the server
                e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference((Control)sender, "Edit$" + e.Row.RowIndex.ToString()));
            }
        }

        protected void gvCustomer_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set the edit index.
            gvCustomer.EditIndex = e.NewEditIndex;
        }
    }
}
