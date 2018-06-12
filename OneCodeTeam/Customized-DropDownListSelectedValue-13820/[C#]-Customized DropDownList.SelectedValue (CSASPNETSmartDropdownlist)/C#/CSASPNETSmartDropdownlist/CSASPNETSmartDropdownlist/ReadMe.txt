========================================================================
                  CSASPNETSmartDropdownlist Overview
========================================================================

/////////////////////////////////////////////////////////////////////////////
Summary:

The code sample customizes the SelectedValue property of ASP.NET DropDownList 
control so that it handles the situation more nicely when the SelectedValue 
property is set to a value that does not exist in the DropDownList value 
collection.  By default, an ArguementOutOfRangeException exception is thrown 
when SelectedValue is set invalidly.  With the customization, the DropDownList
will select a "None" item when the SelectedValue is invalid. 


/////////////////////////////////////////////////////////////////////////////
Demo the Sample. 

Please follow these demonstration steps below.

Step 1: Open the CSASPNETSmartDropdownlist.sln.

Step 2: Right click TestObjectDataSource.aspx.aspx and choose "View in Browser".

Step 3: You will see a DropDownList and a GridView in the page, note the 
        DropDwonList has four valid items while the GridView has six.

Step 4: If you click the "Select DropDownList option" button you may notice that 
		the selected item of DropDownList will change accordingly to the related one. 
		If the item which you selected by clicking button is not contained in 
		DropDownList control, the selected item of DropDownList will be "None".

Step 5: You can also change the selectedValue in page_load event.

Step 6: View and test the TestSqlDataSource.aspx.aspx page as the forward one.
        [Note]
		The two test page are ues Sql data source and Object data source to test
		this smart DropDownList control, the Sql data source is not means SqlDataSource
		control, it means generiec data source, we can convert it to DataTable variable,
		and object data source can convert to IEnumerable object variable.
		[/Note]

Step 7: Validation finished.

/////////////////////////////////////////////////////////////////////////////
Code Logical:

Step 1. Create a C# "ASP.NET Server Control" in Visual Studio 2010 or
        Visual Web Developer 2010. Name it as "CSASPNETSmartDropdownlist".

Step 2. Add a Server control and name it as "CustomizedDropDownList.cs".

Step 3. Remove the Text property and override RenderContent method. Override the
        Render method, the C# code as shown below:
		[code]
		protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
        }
		[/code]

Step 4. Override the SelectedValue property.
		The code as shown below:
		[code]
		/// <summary>
        /// Override SelectedValue property.
        /// For testing purpose, here we only provide three types of data field,
        /// Int, Long and String.
        /// </summary>
        public override string SelectedValue
        {
            get
            {
                return base.SelectedValue;
            }
            set
            {
                // If data source is SqlDataSource.
                if (DataSource is DataView)
                {
                    DataView dataView = DataSource as DataView;
                    DataTable tabView = dataView.Table;
                    Type typeColumns = tabView.Columns[DataValueField].DataType;
                    string rowFilter = string.Empty;
                    if (typeColumns.Equals(Type.GetType("System.String")))
                    {
                        rowFilter = string.Format("{0}='{1}'", DataValueField, value);
                    }
                    else if (typeColumns.Equals(Type.GetType("System.Int32")) || typeColumns.Equals(Type.GetType("System.Int64")))
                    {
                        rowFilter = string.Format("{0}={1}", DataValueField, value);
                    }
                    else
                    {
                        throw new NotImplementedException("unsupported type");
                    }

                    dataView.RowFilter = rowFilter;
                    if (dataView.Count != 0)
                    {
                        dataView.RowFilter = string.Empty;
                        base.SelectedValue = value;
                    }
                    else
                    {
                        dataView.RowFilter = string.Empty;
                        base.SelectedValue = Items[0].Value;
                    }
                }
                // If data source is ObjectDataSource
                else if (DataSource is IEnumerable)
                {
                    bool bolFlag = false;
                    foreach (object obj in DataSource as IEnumerable)
                    {
                        Type type = obj.GetType();
                        //if (!type.Equals(Type.GetType("System.String")) && !type.Equals(Type.GetType("System.Int32"))
                        //    && !type.Equals(Type.GetType("System.Int64")) && !type.ToString().Equals("TestPage.DataEntity"))
                        //{
                        //    throw new NotImplementedException("unsupported type");
                        //}
                        PropertyInfo info = type.GetProperty(DataValueField);
                        string valueProperty = info.GetValue(obj,null).ToString();
                        if (valueProperty.Equals(value))
                        {
                            bolFlag = true;
                            break;
                        }
                    }

                    if (bolFlag)
                    {
                        base.SelectedValue = value;
                    }
                    else
                    {
                        base.SelectedValue = Items[0].Value;
                    }
                }

                // If user change the selected value after postback.
                if(DataSource == null)
                {
                    bool bolFlag = false;
                    for (int i = 0; i < Items.Count; i++)
                    {
                        if (Items[i].Value.Equals(value))
                        {
                            bolFlag = true;
                            break;
                        }
                    }
                    if (bolFlag)
                    {
                        base.SelectedValue = value;
                    }
                    else
                    {
                        base.SelectedValue = Items[0].Value;
                    }                        
                }
            }
        }
		[/code]
		
Step 5. Add an "ASP.NET Empty Web Application" in solution, the project is used to test
        the customized DropDownList we've created. Add two web form pages and named them
		as "TestSqlDataSource.aspx.aspx", "TestObjectDataSource.aspx.aspx". 

Step 6. Add a GridView and a DropDownList control on TestDropDownList page, and add code
        like this:
		[code]
        public partial class TestSqlDataSource.aspx : System.Web.UI.Page
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
	    [/code] 

Step 7. Add a GridView and a DropDownList control on TestObjectDataSource.aspx page, and add code
        like this:
		[code]
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
		[/code]

Step 8. Build the application and you can debug it.


/////////////////////////////////////////////////////////////////////////////
References:

MSDN: ASP.NET server controls overview
http://support.microsoft.com/kb/306459

MSDN: ListControl.SelectedValue Property 
http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.listcontrol.selectedvalue.aspx

MSDN: DataView Class
http://msdn.microsoft.com/en-us/library/system.data.dataview.aspx

MSDN: IEnumerable Interface
http://msdn.microsoft.com/en-us/library/system.collections.ienumerable.aspx
/////////////////////////////////////////////////////////////////////////////