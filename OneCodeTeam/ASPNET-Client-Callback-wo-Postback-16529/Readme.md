# ASP.NET Client Callback w/o Postback (CSASPNETClientCallbacksWithoutPostback)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* Postback
* Callback
## IsPublished
* True
## ModifiedDate
* 2012-06-11 12:50:09
## Description
========================================================================<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; CSASPNETClientCallbacksWithoutPostback Overview<br>
========================================================================<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Use:<br>
<br>
The web application illustrates how to implement a client postback or partial<br>
postback to raise the server code or update some elements in HTML markup. Such <br>
as TextBox, ListView, GridView. As we know that we can user ASP.NET AJAX control<br>
to call a Asynchronous request to server, but in this sample, we will implement<br>
ICallbackEventHandler interface for achieving this goal by this flexible and <br>
lightweight method.<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Demo the Sample. <br>
<br>
Please follow these demonstration steps below.<br>
<br>
Step 1: Open the CSASPNETClientCallbacksWithoutPostback.sln.<br>
<br>
Step 2: Expand the CSASPNETClientCallbacksWithoutPostback web application and press
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Ctrl &#43; F5 to show the Default.aspx.<br>
<br>
Step 3: You will see a GridView on the page, you can add, update, remove and filter<br>
&nbsp; &nbsp; &nbsp; &nbsp;the records of GridView<br>
<br>
Step 4: Note your page did not refresh any more.<br>
<br>
Step 5: Validation finished.<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Code Logical:<br>
<br>
Step 1. Create a C# &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp;Visual Web Developer 2010. Name it as &quot;CSASPNETClientCallbacksWithoutPostback&quot;.<br>
<br>
Step 2. Add a folder in the root directory Name it as &quot;XmlFile&quot;, add a xml file as<br>
&nbsp; &nbsp; &nbsp; &nbsp;data source. The xml file will be like this:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Root&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Person id=&quot;6e5195bba795402691b96b086b6aeedd&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;ID&gt;6e5195bba795402691b96b086b6aeedd&lt;/ID&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;FirstName&gt;Joe&lt;/FirstName&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;LastName&gt;john&lt;/LastName&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;age&gt;Joe John&lt;/age&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/Person&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/Root&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 3. Add JavaScript functions on Default.aspx page, the Html controls will invoke<br>
&nbsp; &nbsp; &nbsp; &nbsp;these functions directly.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;script type=&quot;text/javascript&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;function FilterSearchGrid() {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var firstName = document.getElementById('tbFirstName').value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var lastName = document.getElementById('tbLastName').value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var age = document.getElementById('tbAge').value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var inputarg = &quot;Filter|&quot; &#43; firstName &#43; &quot;|&quot; &#43; lastName &#43; &quot;|&quot; &#43; age;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;FilterCallServerMethod(inputarg, '');<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;function AddNewName() {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var firstName = document.getElementById('tbFirstName').value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var lastName = document.getElementById('tbLastName').value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var age = document.getElementById('tbAge').value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var inputArg = &quot;Insert|&quot; &#43; firstName &#43; &quot;|&quot; &#43; lastName &#43; &quot;|&quot; &#43; age;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;InsertCallServerMethod(inputArg, '');<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById('tbFirstName').value = &quot;&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById('tbLastName').value = &quot;&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById('tbAge').value = &quot;&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;function UpdateName() {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var firstName = document.getElementById('tbFirstName').value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var lastName = document.getElementById('tbLastName').value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var age = document.getElementById('tbAge').value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var id = document.getElementById(&quot;hidID&quot;).value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var inputArg = &quot;Update|&quot; &#43; id &#43; &quot;|&quot; &#43; firstName &#43; &quot;|&quot; &#43; lastName &#43; &quot;|&quot; &#43; age;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;UpdateCallServerMethod(inputArg, '');<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById('tbFirstName').value = &quot;&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById('tbLastName').value = &quot;&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById('tbAge').value = &quot;&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;function DeleteName(id) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var nameId = id;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var inputarg = &quot;Delete|&quot; &#43; nameId;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;DeleteCallServerMethod(inputarg, '');<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;function GiveValue(id, firstName, lastName, age) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var nameId = id;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var firstName = firstName;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var lastName = lastName;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var age = age;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById(&quot;hidID&quot;).value = nameId;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById(&quot;tbFirstName&quot;).value = firstName;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById(&quot;tbLastName&quot;).value = lastName;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById(&quot;tbAge&quot;).value = age;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById('message').innerHTML = &quot;Please modify your message from the TextBox controls and click Update button for commit them.&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;function FilterGetOutputFromServer(strOutput) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById('id1').innerHTML = strOutput;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById('message').innerHTML = &quot;filter the result from GridView control.&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;function DeleteGetOutputFromServer(strOutput) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById('id1').innerHTML = strOutput;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById('message').innerHTML = &quot;Delete success.&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;function InsertGetOutputFromServer(strOutput) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById('id1').innerHTML = strOutput;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById('message').innerHTML = &quot;Insert success.&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;function UpdateGetOutputFromServer(strOutput) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById('id1').innerHTML = strOutput;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById('message').innerHTML = &quot;Update success.&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;function FilterShowAll() {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById('tbFirstName').value = &quot;&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById('tbLastName').value = &quot;&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById('tbAge').value = &quot;&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;FilterSearchGrid();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/script&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 4. The Default.aspx.cs page need implement ICallbackEventArgs interface for <br>
&nbsp; &nbsp; &nbsp; &nbsp;call back server code.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private string strOutput;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private string xmlPath = AppDomain.CurrentDomain.BaseDirectory &#43; &quot;XmlFile/NameXml.xml&quot;;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Page Load method.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// There we define ClientScriptManager class instances for register JavaScript functions.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// These JS functions are use to invoke RaiseCallbackEvent method, and return string variables
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// to client-side.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// we also need invoke GridViewBind method to display information of xml file.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected void Page_Load(object sender, EventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Filter call back event.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Create ClientManager instance of this page.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ClientScriptManager clientManager = Page.ClientScript;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Create a JS function for invoke WebForm_DoCallback method.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string callBackRef = clientManager.GetCallbackEventReference(this, &quot;arg&quot;, &quot;FilterGetOutputFromServer&quot;, String.Empty);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string callBackScript = &quot;function FilterCallServerMethod(arg, context) {&quot; &#43; callBackRef &#43; &quot;; }&quot;;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Register functions on page.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;clientManager.RegisterClientScriptBlock(this.GetType(), &quot;FilterGetOutputFromServer&quot;, callBackScript, true);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Delete call back event.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ClientScriptManager clientManagerDelete = Page.ClientScript;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string deleteCallBackRef = clientManagerDelete.GetCallbackEventReference(this, &quot;arg&quot;, &quot;DeleteGetOutputFromServer&quot;, String.Empty);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string deleteCallBackScript = &quot;function DeleteCallServerMethod(arg, context){&quot; &#43; deleteCallBackRef &#43; &quot;;}&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;clientManagerDelete.RegisterClientScriptBlock(this.GetType(), &quot;DeleteGetOutputFromServer&quot;, deleteCallBackScript, true);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Insert call back event.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ClientScriptManager clientManagerInsert = Page.ClientScript;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string insertCallBackRef = clientManagerInsert.GetCallbackEventReference(this, &quot;arg&quot;, &quot;InsertGetOutputFromServer&quot;, String.Empty);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string insertCallBackScript = &quot;function InsertCallServerMethod(arg, context){&quot; &#43; insertCallBackRef &#43; &quot;;}&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;clientManagerInsert.RegisterClientScriptBlock(this.GetType(), &quot;InsertGetOutputFromServer&quot;, insertCallBackScript, true);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Update call back event.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ClientScriptManager clientManagerUpdate = Page.ClientScript;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string updateCallBackRef = clientManagerUpdate.GetCallbackEventReference(this, &quot;arg&quot;, &quot;UpdateGetOutputFromServer&quot;, String.Empty);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string updateCallBackScript = &quot;function UpdateCallServerMethod(arg, context){&quot; &#43; updateCallBackRef &#43; &quot;;}&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;clientManagerUpdate.RegisterClientScriptBlock(this.GetType(), &quot;UpdateGetOutputFromServer&quot;, updateCallBackScript, true);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// GridView bind event.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.GridViewBind();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// This method is use to load XML file and convert it to a DataTable variable.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Set this variable as GridView' data source.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void GridViewBind()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlDocument xmlDocument = new XmlDocument();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;xmlDocument.Load(xmlPath);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlNodeList nodeList = xmlDocument.SelectNodes(&quot;Root/Person&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;DataTable tabNodes = new DataTable();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tabNodes.Columns.Add(&quot;ID&quot;, Type.GetType(&quot;System.String&quot;));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tabNodes.Columns.Add(&quot;FirstName&quot;, Type.GetType(&quot;System.String&quot;));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tabNodes.Columns.Add(&quot;LastName&quot;, Type.GetType(&quot;System.String&quot;));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tabNodes.Columns.Add(&quot;Age&quot;, Type.GetType(&quot;System.String&quot;));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;foreach (XmlNode node in nodeList)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;DataRow drTab = tabNodes.NewRow();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;drTab[&quot;ID&quot;] = node[&quot;ID&quot;].InnerText;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;drTab[&quot;FirstName&quot;] = node[&quot;FirstName&quot;].InnerText;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;drTab[&quot;LastName&quot;] = node[&quot;LastName&quot;].InnerText;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;drTab[&quot;Age&quot;] = node[&quot;Age&quot;].InnerText;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tabNodes.Rows.Add(drTab);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.ViewState[&quot;Table&quot;] = tabNodes;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;GvwView.DataSource = null;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;GvwView.DataSource = tabNodes;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;GvwView.DataBind();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// This method is use to render current HtmlTextWriter object.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void Flush()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;using (StringWriter strWriter = new StringWriter())<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;using (HtmlTextWriter htmlWriter = new HtmlTextWriter(strWriter))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;GvwView.RenderControl(htmlWriter);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;htmlWriter.Flush();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strOutput = strWriter.ToString();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// This method is use to filter similar results of your input words.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// and re-bind them with GridView control.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;firstName&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;lastName&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;age&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void FilterGrid(string firstName, string lastName,string age)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;DataTable tabName = (DataTable)this.ViewState[&quot;Table&quot;];<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;DataView tabView = tabName.DefaultView;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tabView.RowFilter = String.Format(&quot;FirstName Like '%{0}%' And LastName Like '%{1}%' And Age Like '%{2}%'&quot;, firstName, lastName, age);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;GvwView.DataSource = tabView;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;GvwView.DataBind();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Flush();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// This method is use to delete xml file's records and render new xml data on page.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;nameId&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void DeleteName(string nameId)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlDocument xmlDocument = new XmlDocument();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;xmlDocument.Load(xmlPath);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlNode nodeList = xmlDocument.SelectSingleNode(&quot;Root&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;for (int i = 0; i &lt; nodeList.ChildNodes.Count; i&#43;&#43;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlElement elXml = (XmlElement)nodeList.ChildNodes[i];<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (nameId == elXml.Attributes[&quot;id&quot;].InnerText)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;nodeList.RemoveChild(nodeList.ChildNodes[i]);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;xmlDocument.Save(xmlPath);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.GridViewBind();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Flush();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// This method is use to insert a new record in xml file.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;firstName&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;lastName&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;age&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void InsertName(string firstName, string lastName, string age)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string uniqueID = Guid.NewGuid().ToString().Replace(&quot;-&quot;, String.Empty);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlDocument xmlDocument = new XmlDocument();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;xmlDocument.Load(xmlPath);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlNode nodeRoot = xmlDocument.SelectSingleNode(&quot;Root&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlElement elePerson = xmlDocument.CreateElement(&quot;Person&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;elePerson.SetAttribute(&quot;id&quot;, uniqueID);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlElement eleFirstName = xmlDocument.CreateElement(&quot;FirstName&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;eleFirstName.InnerText = firstName;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlElement eleLastName = xmlDocument.CreateElement(&quot;LastName&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;eleLastName.InnerText = lastName;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlElement eleAge = xmlDocument.CreateElement(&quot;Age&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;eleAge.InnerText = age;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;elePerson.AppendChild(eleFirstName);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;elePerson.AppendChild(eleLastName);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;elePerson.AppendChild(eleAge);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;nodeRoot.AppendChild(elePerson);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;xmlDocument.Save(xmlPath);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.GridViewBind();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Flush();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// This method is use to update the records of xml file.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;id&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;firstName&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;lastName&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;age&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void UpdateName(string id, string firstName, string lastName, string age)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlDocument xmlDocument = new XmlDocument();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;xmlDocument.Load(xmlPath);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlNodeList nodeList = xmlDocument.SelectNodes(&quot;Root/Person&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;foreach (XmlNode nodeSingle in nodeList)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlElement eleSingle = (XmlElement)nodeSingle;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (nodeSingle.Attributes[&quot;id&quot;].Value == id)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlNode nodeFirstName = nodeSingle.ChildNodes[0];<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlElement eleFirstName = (XmlElement)nodeFirstName;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;eleFirstName.InnerText = firstName;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlNode nodeLastName = nodeSingle.ChildNodes[1];<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlElement eleLastName = (XmlElement)nodeLastName;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;eleLastName.InnerText = lastName;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlNode nodeAge = nodeSingle.ChildNodes[2];<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlElement eleAge = (XmlElement)nodeAge;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;eleAge.InnerText = age;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;xmlDocument.Save(xmlPath);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.GridViewBind();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Flush();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Return a output string variable and display it on page.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;returns&gt;&lt;/returns&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public string GetCallbackResult()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return strOutput; <br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// This method is use to receive arguments from JS functions, and check the header
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// of the string variable for invoke different methods.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;eventArgument&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public void RaiseCallbackEvent(string eventArgument)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string[] str = eventArgument.Split('|');<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (str[0] == &quot;Filter&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.FilterGrid(str[1], str[2], str[3]);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else if (str[0] == &quot;Delete&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.DeleteName(str[1]);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else if (str[0] == &quot;Insert&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.InsertName(str[1],str[2],str[3]);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else if (str[0] == &quot;Update&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.UpdateName(str[1], str[2], str[3], str[4]);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Bind the GridView button controls' onclick events with JavaScript functions.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected void GvwView_RowDataBound(object sender, GridViewRowEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Make sure the current GridViewRow is a data row.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (e.Row.RowType == DataControlRowType.DataRow)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Make sure the current GridViewRow is either
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// in the normal state or an alternate row.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Add client-side onclick events.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string id =((DataControlFieldCell)e.Row.Cells[2]).Text;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string firstName = ((DataControlFieldCell)e.Row.Cells[3]).Text.Replace(&quot;&nbsp;&quot;, &quot;&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string lastName = ((DataControlFieldCell)e.Row.Cells[4]).Text.Replace(&quot;&nbsp;&quot;, &quot;&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string age = ((DataControlFieldCell)e.Row.Cells[5]).Text.Replace(&quot;&nbsp;&quot;, &quot;&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;((LinkButton)e.Row.Cells[1].Controls[0]).Attributes.Add(&quot;onclick&quot;, String.Format(&quot;DeleteName('{0}'); return false;&quot;, id));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;((LinkButton)e.Row.Cells[0].Controls[0]).Attributes.Add(&quot;onclick&quot;, String.Format(&quot;GiveValue('{0}','{1}','{2}','{3}'); return false;&quot;, id, firstName, lastName, age));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 5. Build the application and you can debug it.<br>
/////////////////////////////////////////////////////////////////////////////<br>
References:<br>
<br>
MSDN: ICallbackEventHandler Interface<br>
http://msdn.microsoft.com/en-us/library/system.web.ui.icallbackeventhandler.aspx<br>
<br>
MSDN: ICallbackEventHandler.GetCallbackResult Method <br>
http://msdn.microsoft.com/en-us/library/system.web.ui.icallbackeventhandler.getcallbackresult.aspx<br>
<br>
MSDN: ICallbackEventHandler.RaiseCallbackEvent Method <br>
http://msdn.microsoft.com/en-us/library/system.web.ui.icallbackeventhandler.raisecallbackevent.aspx<br>
<br>
MSDN: ClientScriptManager Class<br>
http://msdn.microsoft.com/en-us/library/system.web.ui.clientscriptmanager.aspx<br>
/////////////////////////////////////////////////////////////////////////////<br>
