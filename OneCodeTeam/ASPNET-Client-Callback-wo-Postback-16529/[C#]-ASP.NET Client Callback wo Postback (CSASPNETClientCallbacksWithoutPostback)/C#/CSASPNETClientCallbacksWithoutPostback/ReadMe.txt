========================================================================
             CSASPNETClientCallbacksWithoutPostback Overview
========================================================================

/////////////////////////////////////////////////////////////////////////////
Use:

The web application illustrates how to implement a client postback or partial
postback to raise the server code or update some elements in HTML markup. Such 
as TextBox, ListView, GridView. As we know that we can user ASP.NET AJAX control
to call a Asynchronous request to server, but in this sample, we will implement
ICallbackEventHandler interface for achieving this goal by this flexible and 
lightweight method.

/////////////////////////////////////////////////////////////////////////////
Demo the Sample. 

Please follow these demonstration steps below.

Step 1: Open the CSASPNETClientCallbacksWithoutPostback.sln.

Step 2: Expand the CSASPNETClientCallbacksWithoutPostback web application and press 
        Ctrl + F5 to show the Default.aspx.

Step 3: You will see a GridView on the page, you can add, update, remove and filter
        the records of GridView

Step 4: Note your page did not refresh any more.

Step 5: Validation finished.

/////////////////////////////////////////////////////////////////////////////
Code Logical:

Step 1. Create a C# "ASP.NET Empty Web Application" in Visual Studio 2010 or
        Visual Web Developer 2010. Name it as "CSASPNETClientCallbacksWithoutPostback".

Step 2. Add a folder in the root directory Name it as "XmlFile", add a xml file as
        data source. The xml file will be like this:
		[code]
		<Root>
          <Person id="6e5195bba795402691b96b086b6aeedd">
            <ID>6e5195bba795402691b96b086b6aeedd</ID>
            <FirstName>Joe</FirstName>
            <LastName>john</LastName>
            <age>Joe John</age>
        </Person>
        </Root>
		[/code]

Step 3. Add JavaScript functions on Default.aspx page, the Html controls will invoke
        these functions directly.
		[code]
		<script type="text/javascript">
        function FilterSearchGrid() {
            var firstName = document.getElementById('tbFirstName').value;
            var lastName = document.getElementById('tbLastName').value;
            var age = document.getElementById('tbAge').value;
            var inputarg = "Filter|" + firstName + "|" + lastName + "|" + age;
            FilterCallServerMethod(inputarg, '');
        }

        function AddNewName() {
            var firstName = document.getElementById('tbFirstName').value;
            var lastName = document.getElementById('tbLastName').value;
            var age = document.getElementById('tbAge').value;
            var inputArg = "Insert|" + firstName + "|" + lastName + "|" + age;
            InsertCallServerMethod(inputArg, '');
            document.getElementById('tbFirstName').value = "";
            document.getElementById('tbLastName').value = "";
            document.getElementById('tbAge').value = "";
        }

        function UpdateName() {
            var firstName = document.getElementById('tbFirstName').value;
            var lastName = document.getElementById('tbLastName').value;
            var age = document.getElementById('tbAge').value;
            var id = document.getElementById("hidID").value;
            var inputArg = "Update|" + id + "|" + firstName + "|" + lastName + "|" + age;
            UpdateCallServerMethod(inputArg, '');
            document.getElementById('tbFirstName').value = "";
            document.getElementById('tbLastName').value = "";
            document.getElementById('tbAge').value = "";
        }

        function DeleteName(id) {
            var nameId = id;
            var inputarg = "Delete|" + nameId;
            DeleteCallServerMethod(inputarg, '');
        }

        function GiveValue(id, firstName, lastName, age) {
            var nameId = id;
            var firstName = firstName;
            var lastName = lastName;
            var age = age;
            document.getElementById("hidID").value = nameId;
            document.getElementById("tbFirstName").value = firstName;
            document.getElementById("tbLastName").value = lastName;
            document.getElementById("tbAge").value = age;
            document.getElementById('message').innerHTML = "Please modify your message from the TextBox controls and click Update button for commit them."
        }

        function FilterGetOutputFromServer(strOutput) {
            document.getElementById('id1').innerHTML = strOutput;
            document.getElementById('message').innerHTML = "filter the result from GridView control."
        }

        function DeleteGetOutputFromServer(strOutput) {
            document.getElementById('id1').innerHTML = strOutput;
            document.getElementById('message').innerHTML = "Delete success."
        }

        function InsertGetOutputFromServer(strOutput) {
            document.getElementById('id1').innerHTML = strOutput;
            document.getElementById('message').innerHTML = "Insert success."
        }

        function UpdateGetOutputFromServer(strOutput) {
            document.getElementById('id1').innerHTML = strOutput;
            document.getElementById('message').innerHTML = "Update success."
        }

        function FilterShowAll() {
            document.getElementById('tbFirstName').value = "";
            document.getElementById('tbLastName').value = "";
            document.getElementById('tbAge').value = "";
            FilterSearchGrid();
        }
        </script>
		[/code]

Step 4. The Default.aspx.cs page need implement ICallbackEventArgs interface for 
        call back server code.
		[code]
		private string strOutput;
        private string xmlPath = AppDomain.CurrentDomain.BaseDirectory + "XmlFile/NameXml.xml";

        /// <summary>
        /// Page Load method.
        /// There we define ClientScriptManager class instances for register JavaScript functions.
        /// These JS functions are use to invoke RaiseCallbackEvent method, and return string variables 
        /// to client-side.
        /// we also need invoke GridViewBind method to display information of xml file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Filter call back event.
            // Create ClientManager instance of this page.
            ClientScriptManager clientManager = Page.ClientScript;

            // Create a JS function for invoke WebForm_DoCallback method.
            string callBackRef = clientManager.GetCallbackEventReference(this, "arg", "FilterGetOutputFromServer", String.Empty);
            string callBackScript = "function FilterCallServerMethod(arg, context) {" + callBackRef + "; }";

            // Register functions on page.
            clientManager.RegisterClientScriptBlock(this.GetType(), "FilterGetOutputFromServer", callBackScript, true);

            // Delete call back event.
            ClientScriptManager clientManagerDelete = Page.ClientScript;
            string deleteCallBackRef = clientManagerDelete.GetCallbackEventReference(this, "arg", "DeleteGetOutputFromServer", String.Empty);
            string deleteCallBackScript = "function DeleteCallServerMethod(arg, context){" + deleteCallBackRef + ";}";
            clientManagerDelete.RegisterClientScriptBlock(this.GetType(), "DeleteGetOutputFromServer", deleteCallBackScript, true);

            // Insert call back event.
            ClientScriptManager clientManagerInsert = Page.ClientScript;
            string insertCallBackRef = clientManagerInsert.GetCallbackEventReference(this, "arg", "InsertGetOutputFromServer", String.Empty);
            string insertCallBackScript = "function InsertCallServerMethod(arg, context){" + insertCallBackRef + ";}";
            clientManagerInsert.RegisterClientScriptBlock(this.GetType(), "InsertGetOutputFromServer", insertCallBackScript, true);

            // Update call back event.
            ClientScriptManager clientManagerUpdate = Page.ClientScript;
            string updateCallBackRef = clientManagerUpdate.GetCallbackEventReference(this, "arg", "UpdateGetOutputFromServer", String.Empty);
            string updateCallBackScript = "function UpdateCallServerMethod(arg, context){" + updateCallBackRef + ";}";
            clientManagerUpdate.RegisterClientScriptBlock(this.GetType(), "UpdateGetOutputFromServer", updateCallBackScript, true);

            // GridView bind event.
            this.GridViewBind();
        }

        /// <summary>
        /// This method is use to load XML file and convert it to a DataTable variable.
        /// Set this variable as GridView' data source.
        /// </summary>
        private void GridViewBind()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlPath);
            XmlNodeList nodeList = xmlDocument.SelectNodes("Root/Person");
            DataTable tabNodes = new DataTable();
            tabNodes.Columns.Add("ID", Type.GetType("System.String"));
            tabNodes.Columns.Add("FirstName", Type.GetType("System.String"));
            tabNodes.Columns.Add("LastName", Type.GetType("System.String"));
            tabNodes.Columns.Add("Age", Type.GetType("System.String"));
            foreach (XmlNode node in nodeList)
            {
                DataRow drTab = tabNodes.NewRow();
                drTab["ID"] = node["ID"].InnerText;
                drTab["FirstName"] = node["FirstName"].InnerText;
                drTab["LastName"] = node["LastName"].InnerText;
                drTab["Age"] = node["Age"].InnerText;
                tabNodes.Rows.Add(drTab);
            }
            this.ViewState["Table"] = tabNodes;
            GvwView.DataSource = null;
            GvwView.DataSource = tabNodes;
            GvwView.DataBind();
        }


        /// <summary>
        /// This method is use to render current HtmlTextWriter object.
        /// </summary>
        private void Flush()
        {
            using (StringWriter strWriter = new StringWriter())
            {
                using (HtmlTextWriter htmlWriter = new HtmlTextWriter(strWriter))
                {
                    GvwView.RenderControl(htmlWriter);
                    htmlWriter.Flush();
                    strOutput = strWriter.ToString();
                }
            }
        }

        /// <summary>
        /// This method is use to filter similar results of your input words.
        /// and re-bind them with GridView control.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        private void FilterGrid(string firstName, string lastName,string age)
        {
            DataTable tabName = (DataTable)this.ViewState["Table"];
            DataView tabView = tabName.DefaultView;
            tabView.RowFilter = String.Format("FirstName Like '%{0}%' And LastName Like '%{1}%' And Age Like '%{2}%'", firstName, lastName, age);
            GvwView.DataSource = tabView;
            GvwView.DataBind();
            this.Flush();
        }

        /// <summary>
        /// This method is use to delete xml file's records and render new xml data on page.
        /// </summary>
        /// <param name="nameId"></param>
        private void DeleteName(string nameId)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlPath);
            XmlNode nodeList = xmlDocument.SelectSingleNode("Root");
            for (int i = 0; i < nodeList.ChildNodes.Count; i++)
            {
                XmlElement elXml = (XmlElement)nodeList.ChildNodes[i];
                if (nameId == elXml.Attributes["id"].InnerText)
                {
                    nodeList.RemoveChild(nodeList.ChildNodes[i]);
                }
            }
            xmlDocument.Save(xmlPath);
            this.GridViewBind();
            this.Flush();
        }

        /// <summary>
        /// This method is use to insert a new record in xml file.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        private void InsertName(string firstName, string lastName, string age)
        {
            string uniqueID = Guid.NewGuid().ToString().Replace("-", String.Empty);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlPath);
            XmlNode nodeRoot = xmlDocument.SelectSingleNode("Root");
            XmlElement elePerson = xmlDocument.CreateElement("Person");
            elePerson.SetAttribute("id", uniqueID);
            XmlElement eleFirstName = xmlDocument.CreateElement("FirstName");
            eleFirstName.InnerText = firstName;
            XmlElement eleLastName = xmlDocument.CreateElement("LastName");
            eleLastName.InnerText = lastName;
            XmlElement eleAge = xmlDocument.CreateElement("Age");
            eleAge.InnerText = age;
            elePerson.AppendChild(eleFirstName);
            elePerson.AppendChild(eleLastName);
            elePerson.AppendChild(eleAge);
            nodeRoot.AppendChild(elePerson);
            xmlDocument.Save(xmlPath);
            this.GridViewBind();
            this.Flush();
        }

        /// <summary>
        /// This method is use to update the records of xml file.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        private void UpdateName(string id, string firstName, string lastName, string age)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlPath);
            XmlNodeList nodeList = xmlDocument.SelectNodes("Root/Person");
            foreach (XmlNode nodeSingle in nodeList)
            {
                XmlElement eleSingle = (XmlElement)nodeSingle;
                if (nodeSingle.Attributes["id"].Value == id)
                {
                    XmlNode nodeFirstName = nodeSingle.ChildNodes[0];
                    XmlElement eleFirstName = (XmlElement)nodeFirstName;
                    eleFirstName.InnerText = firstName;
                    XmlNode nodeLastName = nodeSingle.ChildNodes[1];
                    XmlElement eleLastName = (XmlElement)nodeLastName;
                    eleLastName.InnerText = lastName;
                    XmlNode nodeAge = nodeSingle.ChildNodes[2];
                    XmlElement eleAge = (XmlElement)nodeAge;
                    eleAge.InnerText = age;
                }
            }
            xmlDocument.Save(xmlPath);
            this.GridViewBind();
            this.Flush();
        }

        /// <summary>
        /// Return a output string variable and display it on page.
        /// </summary>
        /// <returns></returns>
        public string GetCallbackResult()
        {
            return strOutput; 
        }

        /// <summary>
        /// This method is use to receive arguments from JS functions, and check the header 
        /// of the string variable for invoke different methods.
        /// </summary>
        /// <param name="eventArgument"></param>
        public void RaiseCallbackEvent(string eventArgument)
        {
            string[] str = eventArgument.Split('|');
            if (str[0] == "Filter")
            {
                this.FilterGrid(str[1], str[2], str[3]);
            }
            else if (str[0] == "Delete")
            {
                this.DeleteName(str[1]);
            }
            else if (str[0] == "Insert")
            {
                this.InsertName(str[1],str[2],str[3]);
            }
            else if (str[0] == "Update")
            {
                this.UpdateName(str[1], str[2], str[3], str[4]);
            }
            else
            {
 
            }
        }

        /// <summary>
        /// Bind the GridView button controls' onclick events with JavaScript functions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GvwView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Make sure the current GridViewRow is a data row.
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Make sure the current GridViewRow is either 
                // in the normal state or an alternate row.
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    // Add client-side onclick events.
                    string id =((DataControlFieldCell)e.Row.Cells[2]).Text;
                    string firstName = ((DataControlFieldCell)e.Row.Cells[3]).Text.Replace("&nbsp;", "");
                    string lastName = ((DataControlFieldCell)e.Row.Cells[4]).Text.Replace("&nbsp;", "");
                    string age = ((DataControlFieldCell)e.Row.Cells[5]).Text.Replace("&nbsp;", "");
                    ((LinkButton)e.Row.Cells[1].Controls[0]).Attributes.Add("onclick", String.Format("DeleteName('{0}'); return false;", id));
                    ((LinkButton)e.Row.Cells[0].Controls[0]).Attributes.Add("onclick", String.Format("GiveValue('{0}','{1}','{2}','{3}'); return false;", id, firstName, lastName, age));
                }
            }
        }
		[/code]

Step 5. Build the application and you can debug it.
/////////////////////////////////////////////////////////////////////////////
References:

MSDN: ICallbackEventHandler Interface
http://msdn.microsoft.com/en-us/library/system.web.ui.icallbackeventhandler.aspx

MSDN: ICallbackEventHandler.GetCallbackResult Method 
http://msdn.microsoft.com/en-us/library/system.web.ui.icallbackeventhandler.getcallbackresult.aspx

MSDN: ICallbackEventHandler.RaiseCallbackEvent Method 
http://msdn.microsoft.com/en-us/library/system.web.ui.icallbackeventhandler.raisecallbackevent.aspx

MSDN: ClientScriptManager Class
http://msdn.microsoft.com/en-us/library/system.web.ui.clientscriptmanager.aspx
/////////////////////////////////////////////////////////////////////////////