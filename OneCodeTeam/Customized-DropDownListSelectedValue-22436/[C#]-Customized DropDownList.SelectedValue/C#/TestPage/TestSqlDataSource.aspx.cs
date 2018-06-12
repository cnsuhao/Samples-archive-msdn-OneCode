/****************************** Module Header ******************************\
* Module Name: TestSqlDataSource.aspx.cs
* Project:     TestPage
* Copyright (c) Microsoft Corporation
*
* The "SelectedValue" is a value from DropDownList that will be saved into the
* field bound to the data table. However, if the field value does not belong 
* to any element of the collection of the DropDownList itself, it will throw 
* an ArguementOutOfRangeException exception. This sample creates a customized 
* DropDownList that will fix this problem. 
* 
* The TestDropDownList page will load an XML file as data source of GridView and
* customized DropDownList. The data source is SqlDataSource.
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
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Data;

namespace TestPage
{
    public partial class TestSqlDataSource : System.Web.UI.Page
    {
        /// <summary>
        /// Normal SqlDataSource.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load the xml file and convert it to DataTable variable.
                XDocument xmlDoc = XDocument.Load(Server.MapPath("~/Data.xml"));
                var results = from result in xmlDoc.Element("Root").Elements()
                              select result;
                DataTable tabXml = new DataTable();
                tabXml.Columns.Add("ID", Type.GetType("System.Int32"));
                tabXml.Columns.Add("Name", Type.GetType("System.String"));
                tabXml.Columns.Add("Age", Type.GetType("System.Int32"));
                tabXml.Columns.Add("Telephone", Type.GetType("System.String"));
                tabXml.Columns.Add("Comment", Type.GetType("System.String"));
                DataRow row = tabXml.NewRow();
                row["ID"] = 0;
                row["Name"] = "None";
                row["Age"] = 0;
                row["Telephone"] = "None";
                row["Comment"] = "None";
                tabXml.Rows.Add(row);
                foreach (var result in results)
                {
                    DataRow tabRow = tabXml.NewRow();
                    tabRow["ID"] = Convert.ToInt32(result.Element("ID").Value);
                    tabRow["Name"] = result.Element("Name").Value;
                    tabRow["Age"] = Convert.ToInt32(result.Element("Age").Value);
                    tabRow["Telephone"] = result.Element("Telephone").Value;
                    tabRow["Comment"] = result.Element("Comment").Value;
                    tabXml.Rows.Add(tabRow);
                }

                // Customized DropDownList control data binding by DataTable.
                customizedDropDownList.DataSource = tabXml.AsDataView();
                customizedDropDownList.DataTextField = "Name";
                customizedDropDownList.DataValueField = "ID";
                customizedDropDownList.DataBind();
                customizedDropDownList.SelectedValue = "13";

                // GridView control data binding by DataTable.
                DataRow rowGridView = tabXml.NewRow();
                rowGridView["ID"] = 1000;
                rowGridView["Name"] = "Ann Anna";
                rowGridView["Age"] = 21;
                rowGridView["Telephone"] = "111111";
                rowGridView["Comment"] = "None";
                tabXml.Rows.Add(rowGridView);
                DataRow rowGridView2 = tabXml.NewRow();
                rowGridView2["ID"] = 1001;
                rowGridView2["Name"] = "Bill Brand";
                rowGridView2["Age"] = 41;
                rowGridView2["Telephone"] = "111112";
                rowGridView2["Comment"] = "None";
                tabXml.Rows.Add(rowGridView2);
                tabXml.Rows.Remove(row);
                gvwDropDownListSource.DataSource = tabXml;
                gvwDropDownListSource.DataBind();
            }
        }

        /// <summary>
        /// Change DropDownList selected value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvwDropDownListSource_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex;
                bool convertFlag = int.TryParse(e.CommandArgument.ToString(), out rowIndex);
                if (convertFlag)
                {
                    customizedDropDownList.SelectedValue = gvwDropDownListSource.Rows[rowIndex].Cells[0].Text;
                }
                else
                {
                    Response.Write("The row index is not correct.");
                }
            }
        }

    }
}