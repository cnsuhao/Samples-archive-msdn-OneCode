/****************************** Module Header ******************************\
* Module Name:    Students.aspx.cs
* Project:        CSASPNETCodeFirstCRUDInGridViewWithDetailsView
* Copyright (c) Microsoft Corporation
*
* The whole file offers several CRUDs for Students page, Courses page as well
* as CourseChoice page.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
\***************************************************************************/

using System;
using System.Web;

namespace ASPNETCodeFirstCRUDInGridView
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        /// <summary>
        /// Do inserting of Student and rebind to show the latest data.
        /// </summary>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            StudentDataSource.InsertParameters["StudentName"].DefaultValue = tbStudentName.Text;
            StudentDataSource.Insert();
            GridView1.DataBind();
            tbStudentName.Text = "";
        }
    }
}