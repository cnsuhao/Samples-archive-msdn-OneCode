/****************************** Module Header ******************************\
* Module Name:    Default.aspx.cs
* Project:        CSASPNETGetSelectedValueOfAutoCompleteExtender
* Copyright (c) Microsoft Corporation
*
* This demo shows how you can get selected item when you select an item from 
* list populated by AutoCompleteExtender at code behind.
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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CSASPNETGetSelectedValueOfAutoCompleteExtender
{
    public partial class _Default : System.Web.UI.Page
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
            string queryString = "SELECT [Id], [Keywords], [Count] FROM [KeywordsStatistics]";
            SqlDataAdapter adapter = new SqlDataAdapter();

            // Set query string
            adapter.SelectCommand = new SqlCommand(queryString, connection);

            // Open connection
            connection.Open();

            // Sql data is stored DataSet.                 
            DataSet sqlData = new DataSet();
            adapter.Fill(sqlData, "KeywordsStatistics");

            // Close connection
            connection.Close();

            // Bind datatable to GridView
            gdvKeyword.DataSource = sqlData.Tables[0];
            gdvKeyword.DataBind();
        }

        // database operation
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            // Get the selected value of the AutoCompleteExtender
            string hifvalue = hf1.Value;

            string queryString = "SELECT id FROM [KeywordsStatistics] where Keywords=@Keyword";
            SqlParameter para = new SqlParameter("Keyword", hifvalue);
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.Add(para);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            // If there is a corresponding search record, update the statistics. Otherwise, add a new record.
            if (reader.HasRows)
            {
                // Update the statistics.
                queryString = "update KeywordsStatistics set Count=count+1 where Keywords=@Keyword";
            }
            else
            {
                // Add a new record.
                queryString = "Insert into [KeywordsStatistics](Keywords, Count)values(@Keyword,1)";
            }
            reader.Close();
            command.CommandText = queryString;
            command.ExecuteNonQuery();
            connection.Close();

            BindGrid();
        }
    }
}
