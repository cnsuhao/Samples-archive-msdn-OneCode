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
* 2013-06-13 09:54:53
## Description
========================================================================<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;VBASPNETModifySessionStateSection Overview<br>
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
Step 1: Open the VBASPNETModifySessionStateSection.sln.<br>
<br>
Step 2: Expand the VBASPNETModifySessionStateSection web application and press <br>
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
Step 1. Create a VB &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp;Visual Web Developer 2010. Name it as &quot;VBASPNETModifySessionStateSection&quot;.<br>
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
&nbsp; &nbsp;'' Define common variables, public string, web.config file path and XmlDocument instance.<br>
&nbsp; &nbsp;Public strDisplay As String = String.Empty<br>
&nbsp; &nbsp;Protected configPath As String = AppDomain.CurrentDomain.BaseDirectory &#43; &quot;\Web.Config&quot;<br>
&nbsp; &nbsp;Private document As New XmlDocument()<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Load current web.config information.<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;remarks&gt;&lt;/remarks&gt;<br>
&nbsp; &nbsp;Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load<br>
&nbsp; &nbsp; &nbsp; &nbsp;If Not Page.IsPostBack Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.Load(configPath)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim nodeSession As XmlNode = document.SelectSingleNode(&quot;/configuration/system.web/sessionState&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim elementSession As XmlElement = DirectCast(nodeSession, XmlElement)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim strTimeOut As String = elementSession.Attributes(&quot;timeout&quot;).Value<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim value As Integer = 0<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If Integer.TryParse(strTimeOut, value) AndAlso value &gt; 0 Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tbCookieTimeOut.Text = strTimeOut<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbError.Text = &quot;Session Timeout value is incorrect.&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim strCookieName As String = elementSession.Attributes(&quot;cookieName&quot;).Value<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If strCookieName &lt;&gt; String.Empty Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tbCookieName.Text = strCookieName<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbError.Text = &quot;Session Name value is empty.&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Use XmlDocument instance to modify Session properties.<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;remarks&gt;&lt;/remarks&gt;<br>
&nbsp; &nbsp;Protected Sub btnModifyByXml_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnModifyByXml.Click<br>
&nbsp; &nbsp; &nbsp; &nbsp;Try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim strbDisplay As New StringBuilder()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.Load(configPath)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim nodeSession As XmlNode = document.SelectSingleNode(&quot;/configuration/system.web/sessionState&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim elementSession As XmlElement = DirectCast(nodeSession, XmlElement)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(&quot;Forward Settings:<br>
&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(&quot;Session TimeOut: &quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(elementSession.Attributes(&quot;timeout&quot;).Value)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(&quot;<br>
&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(&quot;Session cookieName: &quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(elementSession.Attributes(&quot;cookieName&quot;).Value)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strDisplay = strbDisplay.ToString()<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim strMin As String = tbCookieTimeOut.Text.Trim()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim strName As String = tbCookieName.Text.Trim()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If strName = String.Empty Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strDisplay = String.Empty<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbError.Text = &quot;Cookie Name is null.&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim intMin As Integer<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If Integer.TryParse(strMin, intMin) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;elementSession.Attributes(&quot;cookieName&quot;).Value = strName<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;elementSession.Attributes(&quot;timeout&quot;).Value = intMin.ToString()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.Save(configPath)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbError.Text = &quot;Save Web config file success, please can open web.config file for value checking.&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strDisplay = String.Empty<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbError.Text = &quot;Session Timeout value must be an integer number.&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;Catch ex As Exception<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Response.Write(ex.Message)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strDisplay = String.Empty<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Try<br>
&nbsp; &nbsp;End Sub<br>
<br>
Step 6. In Default2.aspx page, we use WebConfigurationManager class to read and reset<br>
&nbsp; &nbsp; &nbsp; &nbsp;configuration file, the code as shown below: <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp;Public strDisplay As String = String.Empty<br>
&nbsp; &nbsp;' Define common variables, public string and Configuration instance.<br>
&nbsp; &nbsp;Private manager As Configuration<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Load current web.config information.<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;remarks&gt;&lt;/remarks&gt;<br>
&nbsp; &nbsp;Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load<br>
&nbsp; &nbsp; &nbsp; &nbsp;If Not Page.IsPostBack Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;manager = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim sections As SystemWebSectionGroup = TryCast(manager.GetSectionGroup(&quot;system.web&quot;), SystemWebSectionGroup)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim cookieName As String = sections.SessionState.CookieName<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If Not cookieName.Equals(String.Empty) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tbCookieName.Text = cookieName<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbError.Text = &quot;Session Name value is empty.&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim timeout As TimeSpan = sections.SessionState.Timeout<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim minutes As Double = timeout.TotalMinutes<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If Not timeout.Equals(String.Empty) AndAlso minutes &gt; 0 Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tbCookieTimeOut.Text = minutes.ToString()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbError.Text = &quot;Session Timeout value is incorrect.&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Use WebConfigurationManager instance to get and set session state properties.<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;remarks&gt;&lt;/remarks&gt;<br>
&nbsp; &nbsp;Protected Sub btnModifyByXml_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnModifyByXml.Click<br>
&nbsp; &nbsp; &nbsp; &nbsp;Try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;manager = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim sections As SystemWebSectionGroup = TryCast(manager.GetSectionGroup(&quot;system.web&quot;), SystemWebSectionGroup)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim strbDisplay As New StringBuilder()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(&quot;Forward Settings:<br>
&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(&quot;Session TimeOut: &quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(sections.SessionState.Timeout.TotalMinutes.ToString())<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(&quot;(m) <br>
&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(&quot;Session cookieName: &quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbDisplay.Append(sections.SessionState.CookieName)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strDisplay = strbDisplay.ToString()<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim strMin As String = tbCookieTimeOut.Text.Trim()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim strName As String = tbCookieName.Text.Trim()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If strName = String.Empty Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strDisplay = String.Empty<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbError.Text = &quot;Cookie Name is null.&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim intMin As Double<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If Double.TryParse(strMin, intMin) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;sections.SessionState.CookieName = strName<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;sections.SessionState.Timeout = TimeSpan.FromMinutes(intMin)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;manager.Save()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbError.Text = &quot;Save Web config file success, please can open web.config file for value checking.&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strDisplay = String.Empty<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbError.Text = &quot;Session Timeout value must be an integer number.&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;Catch ex As Exception<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strDisplay = String.Empty<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Response.Write(ex.Message)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Try<br>
&nbsp; &nbsp;End Sub<br>
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
