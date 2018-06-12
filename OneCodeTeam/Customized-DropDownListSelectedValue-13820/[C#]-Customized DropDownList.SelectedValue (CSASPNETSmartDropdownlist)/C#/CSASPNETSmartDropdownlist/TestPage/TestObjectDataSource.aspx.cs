/****************************** Module Header ******************************\
* Module Name: TestObjectDataSource.aspx.cs
* Project:     TestPage
* Copyright (c) Microsoft Corporation
*
* The "SelectedValue" is a value from DropDownList that will be saved into the
* field bound to the data table. However, if the field value does not belong 
* to any element of the collection of the DropDownList itself, it will throw 
* an ArguementOutOfRangeException exception. This sample creates a customized 
* DropDownList that will fix this problem. 
* 
* The TestDropDownList2 page will load an XML file as data source of GridView and
* customized DropDownList. The data source is ObjectDataSource.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
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
using System.Xml.Linq;
using System.Collections;

namespace TestPage
{
    public partial class TestObjectDataSource : System.Web.UI.Page
    {
        /// <summary>
        /// IEnumberable<T> types as the ObjectDataSource.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Load Xml file and convert it to List<T> variable.
            if (!IsPostBack)
            {
                XDocument xmlDoc = XDocument.Load(Server.MapPath("~/Data.xml"));
                List<DataEntity> entities = (from result in xmlDoc.Descendants("Person")
                                             select new DataEntity
                                             {
                                                 ID = Convert.ToInt32(result.Element("ID").Value),
                                                 Name = result.Element("Name").Value,
                                                 Age = Convert.ToInt32(result.Element("Age").Value),
                                                 Telephone = result.Element("Telephone").Value,
                                                 Comment = result.Element("Comment").Value
                                             }).ToList<DataEntity>();

                // Customized DropDownList control data binding by IEnumberable.
                customizedDropDownList.DataSource = entities as IEnumerable<DataEntity>;
                customizedDropDownList.DataTextField = "Name";
                customizedDropDownList.DataValueField = "ID";
                customizedDropDownList.DataBind();
                customizedDropDownList.Items.Insert(0, new ListItem("None", "0"));
                customizedDropDownList.SelectedValue = "12";

                // GridView control data binding by IEnumberable.
                List<DataEntity> list = entities as List<DataEntity>;
                DataEntity entitySingle = new DataEntity();
                entitySingle.ID = 1000;
                entitySingle.Name = "Ann Anna";
                entitySingle.Age = 21;
                entitySingle.Telephone = "111111";
                entitySingle.Comment = "None";
                list.Add(entitySingle);
                DataEntity entitySingle2 = new DataEntity();
                entitySingle2.ID = 1001;
                entitySingle2.Name = "Bill Brand";
                entitySingle2.Age = 41;
                entitySingle2.Telephone = "111112";
                entitySingle2.Comment = "None";
                list.Add(entitySingle2);

                gvwDropDownListSource.DataSource = entities as IEnumerable<DataEntity>;
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
                    int num = gvwDropDownListSource.Rows.Count;
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