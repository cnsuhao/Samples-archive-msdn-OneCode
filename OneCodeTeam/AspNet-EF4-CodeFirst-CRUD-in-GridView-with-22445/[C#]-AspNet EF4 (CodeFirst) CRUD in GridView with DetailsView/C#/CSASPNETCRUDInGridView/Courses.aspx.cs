/****************************** Module Header ******************************\
* Module Name:    Courses.cs
* Project:        CSASPNETCodeFirstCRUDInGridViewWithDetailsView
* Copyright (c) Microsoft Corporation
*
* The Courses.aspx page has a GridView to list all the courses and a DetailsView
* for inserting, deleting and updating a course.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
\***************************************************************************/

using System;
using System.Web;
using System.Web.UI.WebControls;

namespace ASPNETCodeFirstCRUDInGridView
{
    public partial class Courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// After updating, reset the DetailsView and rebind GridView, DetailsView
        /// to show the latest data contents.
        /// </summary>
        protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            GridView1.DataBind();
            DetailsView1.DataBind();
            DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
            DetailsView1.DefaultMode = DetailsViewMode.ReadOnly;
        }

        /// <summary>
        /// After Selecting a specific data, set DetailsView to Edit mode for editing.
        /// </summary>
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DetailsView1.ChangeMode(DetailsViewMode.Edit);
            DetailsView1.DefaultMode = DetailsViewMode.Edit;
        }

        /// <summary>
        /// After inserted successfully, rebind GridView, DetailsView
        /// to show the latest data contents.
        /// </summary>
        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            GridView1.DataBind();
            DetailsView1.DataBind();
        }

        /// <summary>
        /// Check whether CourseName is empty or not when inserting.
        /// </summary>
        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            RequiredFieldValidator rv = DetailsView1.Rows[1].FindControl("RequiredFieldValidator2") as RequiredFieldValidator;
            rv.Validate();
            e.Cancel=!rv.IsValid;
        }

        /// <summary>
        /// Check whether CourseName is empty or not when updating
        /// </summary>
        protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            RequiredFieldValidator rv = DetailsView1.Rows[1].FindControl("RequiredFieldValidator1") as RequiredFieldValidator;
            rv.Validate();
            e.Cancel = !rv.IsValid;
        }

        /// <summary>
        /// Reset the DetailsView when clicking Cancel button.
        /// </summary>
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
            DetailsView1.DefaultMode = DetailsViewMode.ReadOnly;
        }
    }
}