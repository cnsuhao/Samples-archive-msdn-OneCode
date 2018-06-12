/****************************** Module Header ******************************\
* Module Name:    MultiFiltering.ascx.cs
* Project:        CSASPNETMultiFiltering
* Copyright (c) Microsoft Corporation
*
* This is a user-based control that is used to do a filtering with SqlDataSource.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
\*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace CSASPNETMultiFiltering
{
    public partial class MultiFiltering : System.Web.UI.UserControl
    {
        /// <summary>
        /// Handling an event when loading
        /// </summary>
        public MultiFiltering()
        {
            this.GetSqlDatasourceEvent += 
                new Action<SqlDataSource>(MultiFiltering_GetSqlDatasourceEvent);
        }

        /// <summary>
        /// The DataSource gotten from outside
        /// </summary>
        private SqlDataSource source = null;

        /// <summary>
        /// This will save the DataTable for futher columns'mapping
        /// </summary>
        private DataTable TableColumnsMapping
        {
            get
            {
                return (ViewState["columns"] as DataTable);
            }
            set
            {

                ViewState["columns"] = value;
            }
        }

        /// <summary>
        /// This event happens when you set a SqlDataSourceId
        /// </summary>
        private event Action<SqlDataSource> GetSqlDatasourceEvent;

        /// <summary>
        /// This property is used to store filtering records
        /// </summary>
        private List<Structure> FilteringData
        {
            get
            {
                return ViewState["Data"] as List<Structure>;
            }
            set
            {
                ViewState["Data"] = value;
            }
        }

        /// <summary>
        /// Keep the FilterExpression for paging
        /// </summary>
        public string FilterExpression
        {
            get
            {
                return ViewState["filterexp"]
                    == null ?  " " : ViewState["filterexp"].ToString();
            }
            set
            {
                ViewState["filterexp"] = value;
            }
        }

        /// <summary>
        /// This is a public property for you to set
        /// a SqlDataSourceId to the control. This property
        /// can only support set.
        /// </summary>
        [Browsable(true)]
        [Category("Data")]
        [Description("A SqlDataSourceId on the page")]
        public string BindingSqlDataSourceId
        {
            // Here you don't need to see what you've assigned
            // So set it private
            private get
            {
                return ViewState["SqlId"].ToString();
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("BindingSqlId cannot be null!");
                }
                else
                {
                    source = Page.FindControl(value) as SqlDataSource;
                    if (source == null)
                    {
                        throw new Exception("Cannot find a SqlDataSource named: " + value);
                    }
                    else
                    {
                        // If SqlDataSourceID isn't the same as before,re-analyse it.
                        if (!value.Equals(ViewState["SqlId"]))
                        {
                            ViewState["SqlId"] = value;
                            GetSqlDatasourceEvent(source);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// When column name changes, it will detect the type and cascade to dropdown other dropdownlists
        /// </summary>
        protected void ddrColumnNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            //When a column's name changed, set proper operation
            DropDownList ddrColumnName = (DropDownList)sender;
            RepeaterItem item = (RepeaterItem)ddrColumnName.NamingContainer;
            AllColumns = TableColumnsMapping;
            FilteringData[item.ItemIndex].ColumnIndex = ddrColumnName.SelectedIndex;
            FilteringData[item.ItemIndex].OperationIndex = (item.FindControl("ddrOperation") as DropDownList).SelectedIndex;
            FilteringData[item.ItemIndex].RelationIndex = (item.FindControl("ddrRelation") as DropDownList).SelectedIndex;
            FilteringData[item.ItemIndex] = SetSpecificFieldType(FilteringData[item.ItemIndex]);
            Repeater1.DataSource = FilteringData;
            Repeater1.DataBind();
            AutoShow();
        }


        /// <summary>
        /// This event result will analyse the SqlDataSource, and
        /// use its FilterExpression
        /// </summary>
        void MultiFiltering_GetSqlDatasourceEvent(SqlDataSource result)
        {
            DataTable dt = null;
            dt = (result.Select(DataSourceSelectArguments.Empty) as DataView).Table;
            dt.Clear();
            TableColumnsMapping = dt;
            AllColumns = TableColumnsMapping;
            FilteringData = AddStruct(FilteringData);
            Repeater1.DataSource = FilteringData;
            Repeater1.DataBind();
        }

        /// <summary>
        /// When clicking the Remove button, remove the current filter record and rebind.
        /// </summary>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                if (FilteringData.Count > 1)
                {
                    Control c = e.CommandSource as Control;
                    int index = (c.NamingContainer as RepeaterItem).ItemIndex;
                    AutoBind();
                    FilteringData.RemoveAt(index);
                    Repeater1.DataSource = FilteringData;
                    Repeater1.DataBind();
                    AutoShow();
                }
            }
        }

        /// <summary>
        /// Add a new filter record
        /// </summary>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AutoBind();
            FilteringData = AddStruct(FilteringData);
            Repeater1.DataSource = FilteringData;
            Repeater1.DataBind();
            AutoShow();
        }

        /// <summary>
        /// This method is binding data contents, it's called when any data contents are changed.
        /// </summary>
        private void AutoBind()
        {
            DropDownList ddrColumn = null;
            DropDownList ddrOperation = null;
            DropDownList ddrRelation = null;

            for (int i = 0; i < Repeater1.Items.Count; ++i)
            {

                ddrColumn = Repeater1.Items[i].FindControl("ddrFields") as DropDownList;
                ddrOperation = Repeater1.Items[i].FindControl("ddrOperation") as DropDownList;
                ddrRelation = Repeater1.Items[i].FindControl("ddrRelation") as DropDownList;

                FilteringData[i].EqualValue = (Repeater1.Items[i].FindControl("txtBox") as TextBox).Text;
                FilteringData[i].ColumnIndex = ddrColumn.SelectedIndex;
                FilteringData[i].RelationIndex = ddrRelation.SelectedIndex;
                FilteringData[i].OperationIndex = ddrOperation.SelectedIndex;

            }
        }

        /// <summary>
        /// This will retrieve all the data contents onto the UI.
        /// </summary>
        private void AutoShow()
        {
            DropDownList ddrColumn = null;
            DropDownList ddrOperation = null;
            DropDownList ddrRelation = null;

            for (int i = 0; i < Repeater1.Items.Count; ++i)
            {
                ddrColumn = Repeater1.Items[i].FindControl("ddrFields") as DropDownList;
                ddrOperation = Repeater1.Items[i].FindControl("ddrOperation") as DropDownList;
                ddrRelation = Repeater1.Items[i].FindControl("ddrRelation") as DropDownList;

                ddrColumn.SelectedIndex = FilteringData[i].ColumnIndex;
                ddrOperation.SelectedIndex = FilteringData[i].OperationIndex;
                ddrRelation.SelectedIndex = FilteringData[i].RelationIndex;
            }
        }

        /// <summary>
        /// When the button is clicked, generate a complete filtering statement and do filtering.
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlDataSource datasource = (SqlDataSource)Page.FindControl(BindingSqlDataSourceId);

            AutoBind();


            // Show All
            if (chkAll.Checked)
            {
                FilterExpression = " ";
                datasource.FilterExpression = FilterExpression;
            }
            else
            {
                // Loop the FilterData to get the values
                StringBuilder sbu = new StringBuilder();
                string s = null;

                for (int i = 0; i < FilteringData.Count; ++i)
                {
                    string tempop = FilteringData[i].Operations[FilteringData[i].OperationIndex];
                    string columnname = FilteringData[i].ColumnNames[FilteringData[i].ColumnIndex];

                    s = "'" + FilteringData[i].EqualValue + "')";

                    if (tempop.Equals("Like"))
                    {
                        s = "'%" + FilteringData[i].EqualValue + "%')";
                    }
                    else if (FilteringData[i].DataType == typeof(DateTime))
                    {
                        // DateTime has milliseconds, so "=" means between 00:00:00 and 23:59:59

                        if (tempop.Equals("="))
                        {
                            string ts = FilteringData[i].EqualValue + " 00:00:00";
                            string ts2 = FilteringData[i].EqualValue + " 23:59:59";
                            tempop = ">=";
                            s = "'" + ts + "' and "
                                + columnname + "<='"
                                + ts2 + "')";
                        }

                        // "<>" means not between 00:00:00 and 23:59:59
                        else if (tempop.Equals("<>"))
                        {
                            string ts = FilteringData[i].EqualValue + " 00:00:00";
                            string ts2 = FilteringData[i].EqualValue + " 23:59:59";
                            tempop = "<";
                            s = "'" + ts + "' or "
                                + columnname + ">'"
                                + ts2 + "')";
                        }
                        else if (tempop.Equals(">"))
                        {
                            s = "'" + FilteringData[i].EqualValue + " 23:59:59')";
                        }

                        // ">=" means combining the two together
                        else if (tempop.Equals(">="))
                        {
                            string ts = FilteringData[i].EqualValue + " 00:00:00";
                            string ts2 = FilteringData[i].EqualValue + " 23:59:59";
                            tempop = ">=";
                            s = "'" + ts + "' and "
                                + columnname + "<='"
                                + ts2 + "' or " + columnname + " >'" + ts2 + "')";
                        }
                        else if (tempop.Equals("<"))
                        {
                            s = "'" + FilteringData[i].EqualValue + " 00:00:00')";
                        }
                        else if (tempop.Equals("<="))
                        {
                            string ts = FilteringData[i].EqualValue + " 00:00:00";
                            string ts2 = FilteringData[i].EqualValue + " 23:59:59";
                            tempop = ">=";
                            s = "'" + ts + "' and "
                                + columnname + "<='"
                                + ts2 + "' or " + columnname + " <'" + ts2 + "')";
                        }
                    }

                    sbu.Append(
                        "("
                        + FilteringData[i].ColumnNames[FilteringData[i].ColumnIndex]
                        + " "
                        + tempop
                        + " "
                        + s
                        + FilteringData[i].Relations[FilteringData[i].RelationIndex]);
                }

                // Remove the last relation symbol "And" or "Or"
                s = sbu.ToString().Substring(sbu.ToString().LastIndexOf(')') + 1);
                sbu = sbu.Remove(sbu.ToString().LastIndexOf(s), s.Length);

                try
                {
                    // Use this to check whether it will raise an error
                    (datasource.Select(DataSourceSelectArguments.Empty) as DataView).RowFilter = sbu.ToString();
                    datasource.FilterExpression = sbu.ToString();
                    FilterExpression = datasource.FilterExpression;
                    lbError.Text = "";
                }
                catch
                {
                    lbError.Text = "Please check whether your value fits the type.";
                }
                finally
                {
                    sbu = null;
                }
            }
        }
    }
}