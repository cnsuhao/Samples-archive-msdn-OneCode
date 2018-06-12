# How to create a site with AJAX enabled in MVC framework.
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
* ASP.NET MVC 4
## Topics
* AJAX
## IsPublished
* True
## ModifiedDate
* 2013-06-14 12:39:03
## Description
========================================================================<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CSASPNETMVC3AjaxEnabled Overview<br>
========================================================================<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Use:<br>
<br>
The Project illustrates how to create a web site with AJAX enabled in MVC<br>
framework. In fact, more site owners wants to shift their sites to MVC, it<br>
turns to be a problem. This sample shows how to use AJAX by XmlHttpRequest,<br>
Ajax helper class and JQuery.<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Demo the Sample. <br>
<br>
Please follow these demonstration steps below.<br>
<br>
Step 1: Open the CSASPNETMVC3AjaxEnabled.sln.<br>
<br>
Step 2: Expand the CSASPNETMVC3AjaxEnabled web application and press <br>
&nbsp; &nbsp; &nbsp; &nbsp;Ctrl &#43; F5 to show the AjaxComment view.<br>
<br>
Step 3: In this page, you will find a Textbox and a Click Me link. Please <br>
&nbsp; &nbsp; &nbsp; &nbsp;input some text in TextBox and click the link, the input text will<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;show below. If you look carefully, the output text contains &quot;Target<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;page return:&quot;, it because the page create a XmlHttpRequest and
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connect to AjaxTarget action. &nbsp;<br>
<br>
Step 4: The you need modify Global.asax file to reset startup action for testing<br>
&nbsp; &nbsp; &nbsp; &nbsp;other views. For example:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public static void RegisterRoutes(RouteCollection routes)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;routes.IgnoreRoute(&quot;{resource}.axd/{*pathInfo}&quot;);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;routes.MapRoute(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&quot;Default&quot;, // Route name<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&quot;{controller}/{action}/{id}&quot;, // URL with parameters<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;new { controller = &quot;Ajax&quot;, action = &quot;AjaxComment&quot;, id = UrlParameter.Optional } // Parameter defaults<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;You need replace &quot;AjaxComment&quot; to &quot;AjaxHelper&quot;, then you can<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;press ctrl &#43; F5 to show AjaxHelper view.
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;By the way, you can modify the url address for changing to correct view,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;such as &quot;your local address/Ajax/AjaxHelp&quot;.<br>
<br>
Step 5: In AjaxHelper view, you will find some TextBox controls, input your name,<br>
&nbsp; &nbsp; &nbsp; &nbsp;age, telephone number and private comments, click submit button, and<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;you can find your information below, in a unordered list.<br>
<br>
Step 6: Modify action name to &quot;JQueryHelper&quot; follow step 4.<br>
<br>
Step 7: Input your messages and click submit button follow step 5<br>
<br>
Step 8: Validation finished.<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Code Logical:<br>
<br>
Step 1. Create a C# &quot;ASP.NET MVC 3 Web Application&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp;Visual Web Developer 2010. Name it as &quot;CSASPNETMVC3AjaxEnabled&quot;.<br>
<br>
Step 2. Please select empty project template.<br>
<br>
Step 3. Add a model class in Models folder, the model class is used to manage <br>
&nbsp; &nbsp; &nbsp; &nbsp;data for our application, name it as &quot;Person.cs&quot;.<br>
<br>
Step 4. The model class code as shown below:<br>
&nbsp; &nbsp; &nbsp; &nbsp;[code]<br>
&nbsp; &nbsp;public class Person<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;private string name;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private int age;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private string telephone;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private string comment;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public string Name<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return name;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;set<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;name = value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public int Age<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return age;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;set<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;age = value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public string Telephone<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return telephone;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;set<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;telephone = value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public string Comment<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return comment;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;set<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;comment = value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 5. Add an controller class under the Controllers folder, name it as &quot;AjaxController.cs&quot;.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
Step 6 &nbsp;The AjaxController class contains all actions of this sample, The <br>
&nbsp; &nbsp; &nbsp; &nbsp;code as shown below<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp; &nbsp; &nbsp;//<br>
&nbsp; &nbsp; &nbsp; &nbsp;// GET: /Ajax/<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public ActionResult Index()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return View();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public ActionResult AjaxComment()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return View();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public ActionResult AjaxTarget()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return Content(&quot;Target page return :&quot; &#43; Request[&quot;resource&quot;]);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public ActionResult AjaxHelper()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return View();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;[HttpPost]<br>
&nbsp; &nbsp; &nbsp; &nbsp;public ActionResult DisplayPerson()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string name = Request[&quot;Name&quot;].ToString();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string age = Request[&quot;Age&quot;].ToString();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string telephone = Request[&quot;Telephone&quot;].ToString();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string comment = Request[&quot;Comment&quot;].ToString();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;int intAge;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Person p = new Person();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (name != string.Empty && age != string.Empty && telephone != string.Empty && comment != string.Empty)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (!int.TryParse(age, out intAge))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return Content(&quot;
<li>Age must be a integer number&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;p.Name = name;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;p.Age = Convert.ToInt32(age);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;p.Comment = comment;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;p.Telephone = telephone;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;StringBuilder strbComment = new StringBuilder();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbComment.Append(String.Format(&quot;</li><li>Name:{0}&quot;, Request[&quot;Name&quot;].ToString()));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbComment.Append(String.Format(&quot;</li><li>Age:{0}&quot;, Request[&quot;Age&quot;].ToString()));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbComment.Append(String.Format(&quot;</li><li>Telephone:{0}&quot;, Request[&quot;Telephone&quot;].ToString()));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strbComment.Append(String.Format(&quot;</li><li>Comment:{0}&quot;, Request[&quot;Comment&quot;].ToString()));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return Content(string.Join(&quot;\n&quot;, strbComment.ToString()));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return Content(&quot;</li><li>Information incomplete&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public ActionResult JQueryHelper()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return View();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[/code] <br>
<br>
Step 7. Add action views form controller class, the AjaxComment view use to handle XmlHttpRequest<br>
&nbsp; &nbsp; &nbsp; &nbsp;and send data to AjaxTarget action.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AjaxComment.cshtml<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp;&lt;script type=&quot;text/javascript&quot;&gt;<br>
&nbsp; &nbsp;var xmlHttpRequest;<br>
&nbsp; &nbsp;function Ajax() {<br>
&nbsp; &nbsp; &nbsp; &nbsp;if (window.ActiveXObject) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;xmlHttpRequest = new ActiveXObject(&quot;Microsoft.XMLHTTP&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;else if (window.XMLHttpRequest) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;xmlHttpRequest = new XMLHttpRequest();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;else {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById(&quot;output&quot;).innerHTML = &quot;Do not support Ajax.&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;var targetUrl = &quot;Ajax/AjaxTarget?resource=&quot; &#43; document.getElementById(&quot;tbInput&quot;).value;<br>
&nbsp; &nbsp; &nbsp; &nbsp;xmlHttpRequest.open(&quot;GET&quot;, targetUrl, true);<br>
&nbsp; &nbsp; &nbsp; &nbsp;xmlHttpRequest.onreadystatechange = Success;<br>
&nbsp; &nbsp; &nbsp; &nbsp;xmlHttpRequest.send(null);<br>
&nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp;function Success() {<br>
&nbsp; &nbsp; &nbsp; &nbsp;if (xmlHttpRequest.readyState == 4) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (xmlHttpRequest.status == 200) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById(&quot;output&quot;).innerHTML &#43;= xmlHttpRequest.responseText&#43;&quot;<br>
&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
&nbsp; &nbsp;&lt;/script&gt;<br>
&nbsp; &nbsp;&lt;input type=&quot;text&quot; id=&quot;tbInput&quot; /&gt;<br>
&nbsp; &nbsp;
<div id="output"><br>
&nbsp; &nbsp;</div>
<br>
&nbsp; &nbsp;<a href="">Click me</a><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 8. AjaxHelper.cshtml use Ajax.BeginForm method to connect DisplayPerson<br>
&nbsp; &nbsp; &nbsp; &nbsp;action, and this action can validate input messages and send relative<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;messages back.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;@model CSASPNETMVC3AjaxEnabled.Models.Person<br>
&nbsp; &nbsp;@{<br>
&nbsp; &nbsp; &nbsp; &nbsp;ViewBag.Title = &quot;AjaxHelper&quot;;<br>
&nbsp; &nbsp;}<br>
&nbsp; &nbsp;&lt;script src=&quot;../../Scripts/MicrosoftAjax.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;<br>
&nbsp; &nbsp;&lt;script src=&quot;../../Scripts/MicrosoftMvcAjax.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;<br>
&nbsp; &nbsp;&lt;script src=&quot;../../Scripts/jquery.unobtrusive-ajax.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;<br>
&nbsp; &nbsp;
<h2>AjaxHelper</h2>
<br>
<br>
&nbsp; &nbsp;@using (Ajax.BeginForm(&quot;DisplayPerson&quot;, new AjaxOptions { UpdateTargetId = &quot;ajaxResult&quot;,<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; LoadingElementId = &quot;loading&quot;, InsertionMode = InsertionMode.Replace }))<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;
<p>Name:</p>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;@Html.TextBox(&quot;Name&quot;, string.Empty, new { style = &quot;width=120px&quot; })<br>
&nbsp; &nbsp; &nbsp; &nbsp;
<p>Age:</p>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;@Html.TextBox(&quot;Age&quot;, string.Empty, new { style = &quot;width=120px&quot; })<br>
&nbsp; &nbsp; &nbsp; &nbsp;
<p>Telephone:</p>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;@Html.TextBox(&quot;Telephone&quot;, string.Empty, new { style = &quot;width=120px&quot; })<br>
&nbsp; &nbsp; &nbsp; &nbsp;
<p>Comment:</p>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;@Html.TextBox(&quot;Comment&quot;, string.Empty, new { style = &quot;width=120px&quot; })<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;input type=&quot;submit&quot; value=&quot;Submit&quot; /&gt;<br>
&nbsp; &nbsp;}<br>
&nbsp; &nbsp;
<ul id="ajaxResult">
</ul>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 9. The JQuery.cshtml html code as shown below:<br>
&nbsp; &nbsp; &nbsp; &nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;
<h2>JQueryHelper</h2>
<br>
&nbsp; &nbsp;&lt;script type=&quot;text/javascript&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;function GetJQuery() {<br>
&nbsp; &nbsp; &nbsp; &nbsp;$.ajax({<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;type: &quot;POST&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;url: &quot;/Ajax/DisplayPerson&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;data: &quot;Name=&quot; &#43; $('#Name').attr(&quot;value&quot;) &#43; &quot;&Age=&quot; &#43; $('#Age').attr(&quot;value&quot;) &#43;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&quot;&Telephone=&quot; &#43; $('#Telephone').attr(&quot;value&quot;) &#43; &quot;&Comment=&quot; &#43; $('#Comment').attr(&quot;value&quot;),<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;success: function (msg) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;$(&quot;#JqueryResult&quot;).Replace(msg);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;});<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;&lt;/script&gt;<br>
<br>
<br>
&nbsp; &nbsp;
<p>Name:</p>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;@Html.TextBox(&quot;Name&quot;, string.Empty, new { style = &quot;width=120px&quot; })<br>
&nbsp; &nbsp;
<p>Age:</p>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;@Html.TextBox(&quot;Age&quot;, string.Empty, new { style = &quot;width=120px&quot; })<br>
&nbsp; &nbsp;
<p>Telephone:</p>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;@Html.TextBox(&quot;Telephone&quot;, string.Empty, new { style = &quot;width=120px&quot; })<br>
&nbsp; &nbsp;
<p>Comment:</p>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;@Html.TextBox(&quot;Comment&quot;, string.Empty, new { style = &quot;width=120px&quot; })<br>
&nbsp; &nbsp;<br>
<br>
&nbsp; &nbsp;&lt;input type=&quot;button&quot; value=&quot;Submit&quot; onclick=&quot;GetJQuery()&quot; &nbsp;/&gt;<br>
&nbsp; &nbsp;<br>
<br>
&nbsp; &nbsp;<br>
<br>
&nbsp; &nbsp;
<ul id="JqueryResult">
</ul>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code] <br>
<br>
Step 10. Build the application and you can debug it.<br>
/////////////////////////////////////////////////////////////////////////////<br>
References:<br>
<br>
MSDN: Controller Class<br>
http://msdn.microsoft.com/en-us/library/system.web.mvc.controller.aspx<br>
<br>
MSDN: Models and Validation in ASP.NET MVC<br>
http://msdn.microsoft.com/en-us/library/dd410405.aspx<br>
/////////////////////////////////////////////////////////////////////////////<br>
</li>