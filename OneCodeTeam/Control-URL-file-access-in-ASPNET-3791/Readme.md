# Control URL file access in ASP.NET (VBASPNETControlPermissionForFiles)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Application_BeginRequest
## IsPublished
* True
## ModifiedDate
* 2011-07-12 10:29:19
## Description

<p style="font-family:Courier New"></p>
<h2>VBASPNETControlPermissionForFiles Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The project illustrates how to control the permission for project files and <br>
folders on server, and protect them from being downloaded. Here we give a <br>
solution that when the web application receive a URL request, we will make a <br>
judgment that if the request file's extension name is not .jpg file then <br>
redirect to NoPermissionPage page. Also, user can not access the image file <br>
via copy URL. <br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Please follow these demonstration steps below.<br>
<br>
Step 1: Open the VBASPNETControlPermissionForFiles.sln.<br>
<br>
Step 2: Expand the VBASPNETControlPermissionForFiles web application and press <br>
&nbsp; &nbsp; &nbsp; &nbsp;Ctrl &#43; F5 to show the Default.aspx.<br>
<br>
Step 3: You will a ListView control on the page, you can visit the specifically<br>
&nbsp; &nbsp; &nbsp; &nbsp;image by click these links.<br>
<br>
Step 4: If you click the txt file or copy the URL of image file for visiting.<br>
&nbsp; &nbsp; &nbsp; &nbsp;The Browser will redirect to NoPermissionPage.aspx page.
<br>
<br>
Step 5: Validation finished.<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
Step 1. Create a VB &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp;Visual Web Developer 2010. Name it as &quot;VBASPNETControlPermissionForFiles&quot;.<br>
<br>
Step 2. Add two web forms in the root directory, name them as &quot;Default.aspx&quot;,
<br>
&nbsp; &nbsp; &nbsp; &nbsp;&quot;NoPermissionPage.aspx&quot;.<br>
<br>
Step 3. Add two folders, and named them as &quot;Files&quot;, and &quot;XmlFile&quot;, put image files<br>
&nbsp; &nbsp; &nbsp; &nbsp;and text file in &quot;Files&quot; folder, Xml file in &quot;XmlFile&quot; folder.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The XML file will like this:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;Root&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;File&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Name&gt;My Picture MSDN&lt;/Name&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;ID&gt;1&lt;/ID&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;FilePath&gt;Files/Image1.jpg&lt;/FilePath&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/File&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;File&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Name&gt;My Picture Developers&lt;/Name&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;ID&gt;2&lt;/ID&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;FilePath&gt;Files/Image2.jpg&lt;/FilePath&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/File&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;File&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Name&gt;My Picture ASP.NET&lt;/Name&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;ID&gt;3&lt;/ID&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;FilePath&gt;Files/Image3.jpg&lt;/FilePath&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/File&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;File&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Name&gt;My Picture Microsoft&lt;/Name&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;ID&gt;4&lt;/ID&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;FilePath&gt;Files/Image4.jpg&lt;/FilePath&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/File&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;File&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Name&gt;My Picture Bing&lt;/Name&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;ID&gt;5&lt;/ID&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;FilePath&gt;Files/Image5.jpg&lt;/FilePath&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/File&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;File&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Name&gt;My Text File&lt;/Name&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;ID&gt;6&lt;/ID&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;FilePath&gt;Files/Text.txt&lt;/FilePath&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/File&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/Root&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 4. The NoPermissionPage.aspx page is used to show the error message to users.<br>
&nbsp; &nbsp; &nbsp; &nbsp;So you needn't add any code in this page, just add message in aspx page,
<br>
<br>
Step 5. The Default.aspx page is used to show the data of XML file. we need add<br>
&nbsp; &nbsp; &nbsp; &nbsp;a ListView control as data control, The code as shown below:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Binding ListView control with XML files.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;remarks&gt;&lt;/remarks&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim xmlDocument As New XmlDocument()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;xmlDocument.Load(AppDomain.CurrentDomain.BaseDirectory &#43; &quot;XmlFile/PermissionFilesXml.xml&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim nodeList As XmlNodeList = xmlDocument.SelectNodes(&quot;Root/File&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim tabNodes As New DataTable()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tabNodes.Columns.Add(&quot;ID&quot;, Type.[GetType](&quot;System.Int32&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tabNodes.Columns.Add(&quot;Name&quot;, Type.[GetType](&quot;System.String&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tabNodes.Columns.Add(&quot;Path&quot;, Type.[GetType](&quot;System.String&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;For Each node As XmlNode In nodeList<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim drTab As DataRow = tabNodes.NewRow()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;drTab(&quot;ID&quot;) = node(&quot;ID&quot;).InnerText<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;drTab(&quot;Name&quot;) = node(&quot;Name&quot;).InnerText<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;drTab(&quot;Path&quot;) = node(&quot;FilePath&quot;).InnerText<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tabNodes.Rows.Add(drTab)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Next<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ListView1.DataSource = tabNodes<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ListView1.DataBind()<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
Step 6 &nbsp;Add a Global.asax file and re-write Application_BeginRequest method.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' The Application_BeginRequest method is used to make a judgment whether the request file
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' is a jpg file, and throw illegal request to NoPermissionPage.aspx page.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;remarks&gt;&lt;/remarks&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Fires at the beginning of each request<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim path As String = HttpContext.Current.Request.Path<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim pathElements As String() = path.Split(&quot;.&quot;c)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim extenseName As String = pathElements(pathElements.Length - 1)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If Not extenseName.Equals(&quot;aspx&quot;, StringComparison.OrdinalIgnoreCase) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; If Not extenseName.Equals(&quot;jpg&quot;, StringComparison.OrdinalIgnoreCase) OrElse Not IsUrl() Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; HttpContext.Current.Response.Redirect(&quot;~/NoPermissionPage.aspx&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' The method is used to check whether the page is opened by typing the URL in browser &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;returns&gt;&lt;/returns&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Protected Function IsUrl() As Boolean<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim httpReferer As String = System.Web.HttpContext.Current.Request.ServerVariables(&quot;HTTP_REFERER&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim serverName As String = System.Web.HttpContext.Current.Request.ServerVariables(&quot;SERVER_NAME&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If (httpReferer IsNot Nothing) AndAlso (httpReferer.IndexOf(serverName) = 7) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return True<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return False<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Function<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[/code] <br>
<br>
Step 7. Build the application and you can debug it.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Global.Application_BeginRequest Method<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ee255086(BTS.10).aspx">http://msdn.microsoft.com/en-us/library/ee255086(BTS.10).aspx</a><br>
<br>
MSDN: HttpRequest.ServerVariables Property <br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.httprequest.servervariables.aspx">http://msdn.microsoft.com/en-us/library/system.web.httprequest.servervariables.aspx</a><br>
<br>
MSDN: XmlDocument Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.xml.xmldocument.aspx">http://msdn.microsoft.com/en-us/library/system.xml.xmldocument.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
