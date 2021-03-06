# Detect how to modify sessionState section
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Session
## IsPublished
* True
## ModifiedDate
* 2013-06-13 09:55:08
## Description
========================================================================<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CSASPNETModifySessionStateSection Overview<br>
========================================================================<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Use:<br>
<br>
The project illustrates how to modify sessionState section in the Web.Config<br>
file at run time. Customers always wants to know how to modify web.config in<br>
code-behind page, thus, we provide two methods in this sample code to access<br>
configuration file of web application. Remember if you change the Web.Config file,<br>
the Asp.net application will restart, so please use it carefully.<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Demo the Sample. <br>
<br>
Please follow these demonstration steps below.<br>
<br>
Step 1: Open the CSASPNETModifySessionStateSection.sln.<br>
<br>
Step 2: Expand the CSASPNETModifySessionStateSection web application and press <br>
&nbsp; &nbsp; &nbsp; &nbsp;Ctrl &#43; F5 to show the Default.aspx or Default2.aspx.<br>
<br>
Step 3: The users can find two TextBox controls and one Button on the page, <br>
&nbsp; &nbsp; &nbsp; &nbsp;the current web.config settings displayed in controls.<br>
<br>
Step 4: Change the value of controls and click button to modify configuration <br>
&nbsp; &nbsp; &nbsp; &nbsp;file, after input correct value, you will receive the success messages,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;and view the forward messages in web.config file.<br>
<br>
Step 5: Please open web.config file for value checking. After that, please test<br>
&nbsp; &nbsp; &nbsp; &nbsp;another web pages as the above steps.<br>
<br>
Step 6: Validation finished.<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Code Logical:<br>
<br>
Step 1. Create a C# &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp;Visual Web Developer 2010. Name it as &quot;CSASPNETModifySessionStateSection&quot;.<br>
<br>
Step 2. Add two web forms in the root directory, name them as &quot;Default.aspx&quot;, <br>
&nbsp; &nbsp; &nbsp; &nbsp;&quot;Default2.aspx&quot;.<br>
<br>
Step 3. Add two labels, two Textboxes, one button on Default.aspx and Default2.aspx.<br>
&nbsp; &nbsp; &nbsp; &nbsp;And you need define a public string variable and embed it in UI layer.<br>
<br>
Step 4. Add web.config file with Session settings, such as:<br>
&nbsp; &nbsp; &nbsp; &nbsp;[code]<br>
&nbsp; &nbsp;&lt;system.web&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;sessionState mode=&quot;InProc&quot; cookieless=&quot;false&quot; cookieName=&quot;MyCookie&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;timeout=&quot;1&quot; /&gt;<br>
&nbsp; &nbsp;&lt;/system.web&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
Step 5 &nbsp;In Default.aspx page, we use XmlDocument class to read and reset<br>
&nbsp; &nbsp; &nbsp; &nbsp;configuration file, the code as shown below: <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Define common variables, public string, web.config file path and XmlDocument instance.<br>
&nbsp; &nbsp; &nbsp; &nbsp;public string strDisplay = string.Empty;<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected string configPath = AppDomain.CurrentDomain.BaseDirectory &#43; @&quot;\Web.Config&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp;XmlDocument document = new XmlDocument();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Load current web.config information.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected void Page_Load(object sender, EventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (!Page.IsPostBack)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.Load(configPath);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlNode nodeSession = document.SelectSingleNode(&quot;/configuration/system.web/sessionState&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlElement elementSession = (XmlElement)nodeSession;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string strTimeOut = elementSession.Attributes[&quot;timeout&quot;].Value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;int value=0;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (int.TryParse(strTimeOut, out value) && value &gt; 0)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tbCookieTimeOut.Text = strTimeOut;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbError.Text = &quot;Session Timeout value is incorrect.&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string strCookieName = elementSession.Attributes[&quot;cookieName&quot;].Value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (strCookieName != string.Empty)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tbCookieName.Text = strCookieName;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbError.Text = &quot;Session Name value is empty.&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Use XmlDocument instance to modify Session properties.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected void btnModifyByXml_Click(object sender, EventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;StringBuilder strbDisplay = new StringBuilder();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.Load(configPath);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlNode nodeSession = document.SelectSingleNode(&quot;/configuration/system.web/sessionState&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XmlElement elementSession = (XmlElement)nodeSession;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(&quot;Forward Settings:<br>
&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(&quot;Session TimeOut: &quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(elementSession.Attributes[&quot;timeout&quot;].Value);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(&quot;<br>
&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(&quot;Session cookieName: &quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(elementSession.Attributes[&quot;cookieName&quot;].Value);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strDisplay = strbDisplay.ToString();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string strMin = tbCookieTimeOut.Text.Trim();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string strName = tbCookieName.Text.Trim();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (strName == string.Empty)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbError.Text = &quot;Cookie Name is null.&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;int intMin;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (int.TryParse(strMin, out intMin))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;elementSession.Attributes[&quot;cookieName&quot;].Value = strName;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;elementSession.Attributes[&quot;timeout&quot;].Value = intMin.ToString();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.Save(configPath);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbError.Text = &quot;Save Web config file success, please can open web.config file for value checking.&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbError.Text = &quot;Session Timeout value must be an integer number.&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;catch (Exception ex)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Response.Write(ex.Message);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[/code]<br>
<br>
Step 6. In Default2.aspx page, we use WebConfigurationManager class to read and reset<br>
&nbsp; &nbsp; &nbsp; &nbsp;configuration file, the code as shown below: <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Define common variables, public string and Configuration instance.<br>
&nbsp; &nbsp; &nbsp; &nbsp;public string strDisplay = string.Empty;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Configuration manager;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Load current web.config information.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected void Page_Load(object sender, EventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (!Page.IsPostBack)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;manager = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SystemWebSectionGroup sections = manager.GetSectionGroup(&quot;system.web&quot;) as SystemWebSectionGroup;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string cookieName = sections.SessionState.CookieName;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (!cookieName.Equals(string.Empty))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tbCookieName.Text = cookieName;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbError.Text = &quot;Session Name value is empty.&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TimeSpan timeout = sections.SessionState.Timeout;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;double minutes = timeout.TotalMinutes;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (!timeout.Equals(string.Empty) && minutes &gt; 0)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tbCookieTimeOut.Text = minutes.ToString();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbError.Text = &quot;Session Timeout value is incorrect.&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Use WebConfigurationManager instance to get and set session state properties.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected void btnModifyByXml_Click(object sender, EventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;manager = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SystemWebSectionGroup sections = manager.GetSectionGroup(&quot;system.web&quot;) as SystemWebSectionGroup;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;StringBuilder strbDisplay = new StringBuilder();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(&quot;Forward Settings:<br>
&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(&quot;Session TimeOut: &quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(sections.SessionState.Timeout.TotalMinutes.ToString());<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(&quot;(m) <br>
&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(&quot;Session cookieName: &quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(sections.SessionState.CookieName);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strDisplay = strbDisplay.ToString();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string strMin = tbCookieTimeOut.Text.Trim();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string strName = tbCookieName.Text.Trim();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (strName == string.Empty)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbError.Text = &quot;Cookie Name is null.&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;double intMin;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (double.TryParse(strMin, out intMin))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;sections.SessionState.CookieName = strName;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;sections.SessionState.Timeout = TimeSpan.FromMinutes(intMin);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;manager.Save();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbError.Text = &quot;Save Web config file success, please can open web.config file for value checking.&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbError.Text = &quot;Session Timeout value must be an integer number.&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;catch (Exception ex)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Response.Write(ex.Message);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 7. Build the application and you can debug it.<br>
/////////////////////////////////////////////////////////////////////////////<br>
References:<br>
<br>
MSDN: Web.config<br>
http://msdn.microsoft.com/en-us/library/aa306178.aspx<br>
<br>
MSDN: WebConfigurationManager Class<br>
http://msdn.microsoft.com/en-us/library/system.web.configuration.webconfigurationmanager.aspx<br>
<br>
MSDN: XmlDocument Class<br>
http://msdn.microsoft.com/en-us/library/system.xml.xmldocument.aspx<br>
/////////////////////////////////////////////////////////////////////////////<br>
