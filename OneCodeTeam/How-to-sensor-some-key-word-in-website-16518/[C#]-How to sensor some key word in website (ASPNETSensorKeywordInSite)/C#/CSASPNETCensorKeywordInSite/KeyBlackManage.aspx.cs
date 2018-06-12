/****************************** Module Header ******************************\
* Module Name:    KeyBlackManage.aspx.cs
* Project:        CSASPNETCensorKeywordInSite
* Copyright (c) Microsoft Corporation
*
* The page is used to manage blacklist. 
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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CSASPNETCensorKeywordInSite
{
    public partial class KeyBlackManage : System.Web.UI.Page
    {
        // Sql connection.
        static string connetionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connetionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        /// <summary>
        /// Bind datatable to GridView
        /// </summary>
        private void BindGrid()
        {
            // Query string
            string queryString = "SELECT [Id], [Name] FROM [WordBlack]";
            SqlDataAdapter adapter = new SqlDataAdapter();

            // Set query string
            adapter.SelectCommand = new SqlCommand(queryString, connection);

            // Open connection
            connection.Open();

            // Sql data is stored in DataSet.                 
            DataSet sqlData = new DataSet();
            adapter.Fill(sqlData, "WordBlack");

            // Close connection
            connection.Close();

            // Bind datatable to GridView
            gdvKeyword.DataSource = sqlData.Tables[0];
            gdvKeyword.DataBind();
        }

        // database operation
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {               
                string queryString = "Insert into [WordBlack](Name)values(@Keyword)";
                SqlParameter para = new SqlParameter("Keyword", tbKey.Text.Trim());
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(para);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                BindGrid();
            }
        }
    }

}
