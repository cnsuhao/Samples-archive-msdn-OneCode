/****************************** Module Header ******************************\
* Module Name:    Default.aspx.cs
* Project:        CSASPNETCompareAndMergeData
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to compare and merge data which from different 
* datasources. In this sample, we store some data in xml file and SQL Server 
* database respectively. We need to compare the data from different datasources 
* and display the columns with one GridView Control. If the records ID are equal 
* we need to set the status column as "ok". Otherwise the status column should 
* be set as "null". When we display the columns from different datasources we 
* may need to merge the datasets in order to bind to GridView Control.
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
using System.Data.SqlClient;

namespace CSASPNETCompareAndMergeData
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Sql connection
            string connString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Books.mdf;Integrated Security=True;User Instance=True";
            // Path of xml.
            string filePath = Server.MapPath("Book.xml");

            #region Sql DataSource 
            SqlConnection connection = new SqlConnection(connString);
            string queryString = "select * from bookData";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(queryString, connection);

            // Open connection
            connection.Open();

            // Fill Sql data in DataSet.
            DataSet sqlData = new DataSet();
            adapter.FillSchema(sqlData, SchemaType.Source, "BookData");
            adapter.Fill(sqlData, "BookData");

            // Close connection
            connection.Close();
            #endregion

            // Fill Xml data in DataSet.
            DataSet xmlData = new DataSet();
            xmlData.ReadXml(filePath);
            xmlData.AcceptChanges();

            // A column is used to store compare state.
            xmlData.Tables[0].Columns.Add("CompareState");

            // Declare a table to hold Xml data.
            DataTable dtXml = xmlData.Tables[0];

            // Declare a table to hold Sql data.
            DataTable dtSql = sqlData.Tables[0];

            // The table is used to store Merged data.
            DataTable dtXmlTemp = dtXml.Clone();

            // Copy dtXml data to dtXmlTemp.
            foreach (DataRow row in dtXml.Rows)
            {
                dtXmlTemp.ImportRow(row);
            }

            #region Compare and merge operations
            // Loop all rows of the sql table and xml table.
            // If the ISBN in the dtXml is equal to the ISBN in dtSql we can merge the two records and 
            // set CompareState as "OK", Otherwise we can add the null value to the records in dtXml. 
            foreach (DataRow dr1 in dtXml.Rows)
            {
                foreach (DataRow dr2 in dtSql.Rows)
                {
                    if (dr1[0].ToString().Equals(dr2[0].ToString())) // Compare the ISBN
                    {
                        // Get the index of current row, then update the CompareState in the copy of dtXml(dtXmlTemp).
                        int intIndex = dtXml.Rows.IndexOf(dr1);
                        dtXmlTemp.Rows[intIndex][5] = "OK"; // Set CompareState value
                    }
                    else
                    {
                        // Add record to dtXmlTemp and add a "null" flag.
                        DataRow drNew = dtXmlTemp.NewRow();
                        drNew["ISBN"] = dr2["ISBN"];
                        drNew["CompareState"] = "null";

                        // Add a new row if the table does not has duplicate rows.
                        if (IsNotExist(drNew, dtXmlTemp))
                        {
                            dtXmlTemp.Rows.Add(drNew);
                        }
                    }
                }
            }
            #endregion

            // This is a merger in the system
            // sqlData.Merge(xmlData, true, MissingSchemaAction.AddWithKey);

            // Bind datatable to GridView
            gdvData.DataSource = dtXmlTemp;
            gdvData.DataBind();
        }

        /// <summary>
        /// Loop all rows of the specified table to determine whether the row exists, remove duplicate rows.
        /// </summary>
        /// <param name="drNew">The row to be determined.</param>
        /// <param name="dtXmlTemp">The specified table</param>
        /// <returns>true means does not exist</returns>
        private bool IsNotExist(DataRow drNew, DataTable dtXmlTemp)
        {
            bool isNotExist = true;

            foreach (DataRow dr in dtXmlTemp.Rows)
            {
                if (dr[0].ToString().Equals(drNew[0].ToString()))
                {
                    isNotExist = false;
                    break;
                }
            }
            return isNotExist;
        }
    }
}
