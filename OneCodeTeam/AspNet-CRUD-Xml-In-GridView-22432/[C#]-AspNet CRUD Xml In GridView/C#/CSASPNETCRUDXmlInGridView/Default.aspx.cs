/****************************** Module Header ******************************\
* Module Name:    Default.aspx.cs
* Project:        CSASPNETCRUDXmlInGridView
* Copyright (c) Microsoft Corporation
*
* The project shows up how to insert/delete/update a record into the xml file
* by the GridView.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
\***************************************************************************/

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XmlEditInsertDeleteInGridView
{
    public partial class Default : System.Web.UI.Page
    {
        /// <summary>
        /// For the first time when the page loads, load data into DataTable 
        /// with DataSet, and save the DataTable into ViewState for further
        /// usage.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                ds.ReadXml(Request.MapPath("try.xml"));
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                ViewState["dt"] = ds.Tables[0];
            }
        }

        /// <summary>
        /// Handle the Edit event of GridView for assigning the specific row to be 
        /// in the edit mode.
        /// </summary>
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = (DataTable)ViewState["dt"];
            GridView1.DataBind();
        }

        /// <summary>
        /// Update the specific row in the DataTable with the data from GridView,
        /// re-write the data into the xml file and re-databind again.
        /// </summary>
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["dt"];

            for (int i = 1; i < GridView1.Rows[e.RowIndex].Cells.Count; i++)
            {
                dt.Rows[e.RowIndex][i-1] = (GridView1.Rows[e.RowIndex].Cells[i].Controls[0] as TextBox).Text;
            }
            dt.AcceptChanges();
            GridView1.EditIndex = -1;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            dt.WriteXml(Request.MapPath("try.xml"));
        }

        /// <summary>
        /// Cancel edit and set the mode of the GridView to normal viewing mode.
        /// </summary>
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            DataTable dt = (DataTable)ViewState["dt"];
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        /// <summary>
        /// Insert the data into the DataTable, re-write into the xml file and
        /// re-databind to the GridView.
        /// </summary>
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["dt"];
            dt.Rows.Add(tbAuthor.Text, tbTitle.Text, tbGenre.Text, tbPrice.Text, tbPublishDate.Text, tbDescription.Text, tbId.Text);
            dt.AcceptChanges();
            dt.WriteXml(Request.MapPath("try.xml"));
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        /// <summary>
        /// Delete the row from DataTable and write data into xml file,
        /// re-databind to the GridView.
        /// </summary>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["dt"];
            dt.Rows.RemoveAt(e.RowIndex);
            dt.WriteXml(Request.MapPath("try.xml"));
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}