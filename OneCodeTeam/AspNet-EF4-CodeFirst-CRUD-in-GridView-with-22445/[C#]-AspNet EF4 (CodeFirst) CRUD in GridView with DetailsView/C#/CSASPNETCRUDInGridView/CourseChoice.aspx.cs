/****************************** Module Header ******************************\
* Module Name:    CourseChooice.cs
* Project:        CSASPNETCodeFirstCRUDInGridViewWithDetailsView
* Copyright (c) Microsoft Corporation
*
* This page offers a UI for us to create, delete or update a course choice
* information.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNETCodeFirstCRUDInGridView
{
    public partial class CourseChooice : System.Web.UI.Page
    {
        /// <summary>
        /// Rebind the Rest Courses' Dropdownlist and decide whether to show
        /// error message and enable the "Add" button.
        /// </summary>
        private void ReBind()
        {
            ddrRestCourses.DataBind();
            btnAdd.Enabled = (ddrRestCourses.Items.Count > 0);
            lbmsg.Visible = (ddrRestCourses.Items.Count == 0);

        }

        /// <summary>
        /// first time when loading to check.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReBind();
            }
        }

        /// <summary>
        /// After adding a course choice, refresh the dropdownlist.
        /// </summary>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Student_CourseDataSource.InsertParameters["sid"].DefaultValue = ddrStudents.SelectedValue;
            Student_CourseDataSource.InsertParameters["cid"].DefaultValue = ddrRestCourses.SelectedValue;
            Student_CourseDataSource.InsertParameters["score"].DefaultValue = tbScore.Text;
            Student_CourseDataSource.Insert();
            GridView1.DataBind();
            ddrRestCourses.DataBind();
            ReBind();
        }

        /// <summary>
        /// After deleting a course choice, refresh the dropdownlist.
        /// </summary>
        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            ReBind();
        }

        /// <summary>
        /// After selecting a course choice, refresh the dropdownlist.
        /// </summary>
        protected void ddrStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReBind();
        }
    }
}