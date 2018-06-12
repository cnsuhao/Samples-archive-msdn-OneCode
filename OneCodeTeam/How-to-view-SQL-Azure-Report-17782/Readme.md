# How to view SQL Azure Report Services
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* SQL Azure
## Topics
* Reporting Services
* Report Viewer
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:28:33
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<p class="MsoNormal">This sample should be <span>run with Windows Azure SDK 1.6, Sql Server 2012 (With Reporting components), ASP.NET MVC 4.
</span></p>
<p class="MsoNormal">1. <span>Open the </span><span>VBAzureSQLReportingServices</span><span>.sln file with Visual Studio
</span>in elevated (administrator) mode<span>.</span><em><span> </span></em></p>
<p class="MsoNormal">2.<span> Before running the sample, try to replace your SQL Azure service in Web.config file, you need input your SQL Azure report username, password and service url:</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;appSettings&gt;
  &lt;add key=&quot;sqlAzureRSUser&quot; value=&quot;Your username&quot;/&gt;
  &lt;add key=&quot;sqlAzureRSPassword&quot; value=&quot;Your password&quot;/&gt;
  &lt;add key=&quot;sqlAzureRSDomain&quot; value=&quot;Your report url&quot;/&gt;
  &lt;!--https://xxxx.reporting.windows.net/reportserver/xxx folder/xx report--&gt;
&lt;/appSettings&gt;

</pre>
<pre id="codePreview" class="xml">&lt;appSettings&gt;
  &lt;add key=&quot;sqlAzureRSUser&quot; value=&quot;Your username&quot;/&gt;
  &lt;add key=&quot;sqlAzureRSPassword&quot; value=&quot;Your password&quot;/&gt;
  &lt;add key=&quot;sqlAzureRSDomain&quot; value=&quot;Your report url&quot;/&gt;
  &lt;!--https://xxxx.reporting.windows.net/reportserver/xxx folder/xx report--&gt;
&lt;/appSettings&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">3. Running the AzureSQLReportingServices_WebRole application, and view your report data in the below image:</p>
<p class="MsoNormal"><span><img src="/site/view/file/73956/1/image.png" alt="" width="552" height="529" align="middle">
</span></p>
<p class="MsoNormal">4. <span>Before running the MVC role, you have to replace your information in code-behind file (HomeController.vb):
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Dim serviceUri As String = &quot;Your service server url&quot;
' such as https://xxxx.reporting.windows.net/ReportServer 
Dim servicePath As String = &quot;You service folder path&quot;
' such as /testFolder/testReport

</pre>
<pre id="codePreview" class="vb">Dim serviceUri As String = &quot;Your service server url&quot;
' such as https://xxxx.reporting.windows.net/ReportServer 
Dim servicePath As String = &quot;You service folder path&quot;
' such as /testFolder/testReport

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span>5</span>. Running the AzureSQLReportingSerivces_MVC4Role application, and view your report data in the below image:</p>
<p class="MsoNormal"><span><img src="/site/view/file/73957/1/image.png" alt="" width="552" height="529" align="middle">
</span></p>
<p class="MsoNormal">6. <span>Validation finished </span></p>
<p class="MsoNormal"><span>1</span>. <span>Create a Windows Azure Application Project in Visual Studio 2010, name it as &quot;</span><span>VBAzureSQLReportingServices</span><span>&quot;.
</span></p>
<p class="MsoNormal"><strong><span>Before we begin to write sample, we need to create a SQL Azure Reporting service on SQL Azure Portal, please following these step to create a simple SQL Azure Reporting Service</span></strong><span>:
</span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Apply a SQL Azure subscription. (If you have one, ignore this step)
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Create DB (include table) in SQL Azure Portal with you subscription.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Install SQL Server 2012 Express. (Remember install Reporting service component)
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Create a Report Server Project application in Visual Studio.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Create a custom report under the project &quot;Reports&quot; folder with your server name, user name and password of SQL Azure DB.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Configure your report with folder path and target server url. (Here you need provide SQL Azure reporting server url)
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Deploy Report Server Project Application </span></p>
<p class="MsoNormal"><span>2. </span>Add a WebRole application and a MVC 4 WebRole in Cloud application, name them as &quot;AzureSQLReportingServices_WebRole&quot; and &quot;AzureSQLReportingSerivces_MVC4Role&quot;. In WebRole application, you need drag and drop a ReportViewer
 and a ScriptManager on Default.aspx page, create ReportViewerCredentials class to send forms credentials to ReportView.</p>
<p class="MsoNormal"><strong><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">The following code is used to send username/password/service url to ReportViewer control</span></strong><strong><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">:
</span></strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not Me.IsPostBack Then
        Dim user As String = ConfigurationManager.AppSettings(&quot;sqlAzureRSUser&quot;)
        Dim password As String = ConfigurationManager.AppSettings(&quot;sqlAzureRSPassword&quot;)
        Dim domain As String = ConfigurationManager.AppSettings(&quot;sqlAzureRSDomain&quot;)
        Me.ReportViewer1.ServerReport.ReportServerCredentials = New ReportViewerCredentials(user, password, domain)
        Me.ReportViewer1.ServerReport.Refresh()
    End If
End Sub

</pre>
<pre id="codePreview" class="vb">Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not Me.IsPostBack Then
        Dim user As String = ConfigurationManager.AppSettings(&quot;sqlAzureRSUser&quot;)
        Dim password As String = ConfigurationManager.AppSettings(&quot;sqlAzureRSPassword&quot;)
        Dim domain As String = ConfigurationManager.AppSettings(&quot;sqlAzureRSDomain&quot;)
        Me.ReportViewer1.ServerReport.ReportServerCredentials = New ReportViewerCredentials(user, password, domain)
        Me.ReportViewer1.ServerReport.Refresh()
    End If
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">3. The MVC WebRole has not ReportView control, so we need to write code to send web request to SQL Azure Server, and get ViewState, EventValidation from logon page, then we can get XML data of SQL Azure reporting service.</p>
<p class="MsoNormal"><strong><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">The following code is used to get XML data of SQL Azure reporting service by MVC Role</span></strong><strong><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">:
</span></strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Function Index() As ActionResult
    ViewBag.Message = &quot;VBAzureSQLReportingServices&quot;


    Dim request As HttpWebRequest = Nothing
    Dim response As HttpWebResponse = Nothing
    Dim sr As StreamReader = Nothing
    Dim serviceUri As String = &quot;Your service server url&quot; ' such as https://xxxx.reporting.windows.net/ReportServer 
    Dim servicePath As String = &quot;You service folder path&quot; ' such as /testFolder/testReport
    Dim logonPath As String = &quot;/logon.aspx&quot;
    Dim commandParameter As String = &quot;rs:Command=GetSharedDatasetDefinition&quot;
    Dim formatParameter As String = &quot;rs:Format=XML&quot;
    Dim reportServiceUrl As String = String.Format(&quot;{0}?{1}&amp;{2}&amp;{3}&quot;, serviceUri, servicePath, commandParameter, formatParameter)
    Dim loginUrl As String = String.Format(&quot;{0}{1}&quot;, serviceUri, logonPath)


    ' Request page protected by forms authentication.
    ' This request will get a 302 to login page
    request = DirectCast(WebRequest.Create(loginUrl), HttpWebRequest)
    request.AllowAutoRedirect = False
    Dim cookieContainer = New CookieContainer()
    request.CookieContainer = cookieContainer


    response = DirectCast(request.GetResponse(), HttpWebResponse)
    If response.StatusCode = HttpStatusCode.Found Then
        ViewBag.Status = &quot;Response: 302 &quot; &amp; response.StatusCode
    Else
        ViewBag.Status = &quot;Response status is &quot; &amp; response.StatusCode &amp; &quot;. Expected was Found&quot;
    End If


    ' Get the url of login page from location header
    Dim locationHeader As String = response.GetResponseHeader(&quot;Location&quot;)


    ' Request login page
    request = DirectCast(WebRequest.Create(loginUrl), HttpWebRequest)
    request.AllowAutoRedirect = False
    request.CookieContainer = cookieContainer


    response = DirectCast(request.GetResponse(), HttpWebResponse)
    If response.StatusCode = HttpStatusCode.OK Then
        ViewBag.Status = &quot;Response: &quot; &amp; response.StatusCode
    Else
        ViewBag.Status = &quot;Response status is &quot; &amp; response.StatusCode &amp; &quot;. Expected was OK&quot;
    End If




    sr = New StreamReader(response.GetResponseStream())
    Dim loginResponse As String = sr.ReadToEnd()
    sr.Close()


    ' Get SQL Azure Reporting service xml.
    Dim viewStateVar As String = &quot;__VIEWSTATE=&quot;
    Dim viewStateSearchString As String = &quot;name=&quot;&quot;__VIEWSTATE&quot;&quot; id=&quot;&quot;__VIEWSTATE&quot;&quot; value=&quot;&quot;&quot;
    Dim viewStateStartIndex As Integer = loginResponse.IndexOf(viewStateSearchString)


    loginResponse = loginResponse.Substring(viewStateStartIndex &#43; viewStateSearchString.Length)
    Dim viewStateValue As String = Uri.EscapeDataString(loginResponse.Substring(0, loginResponse.IndexOf(&quot;&quot;&quot; /&gt;&quot;)))
    loginResponse = loginResponse.Substring(loginResponse.IndexOf(&quot;&quot;&quot; /&gt;&quot;))


    Dim userNameVar As String = &quot;TxtUser=&quot;
    Dim userNameValue As String = &quot;arwindgao&quot;
    Dim passwordVar As String = &quot;TxtPwd=&quot;
    Dim passwordValue As String = &quot;Password0~&quot;
    Dim loginButtonVar As String = &quot;BtnLogon=&quot;
    Dim loginButtonValue As String = &quot;Log&#43;In&quot;
    Dim eventValidationVar As String = &quot;__EVENTVALIDATION=&quot;
    Dim eventValSearchString As String = &quot;name=&quot;&quot;__EVENTVALIDATION&quot;&quot; id=&quot;&quot;__EVENTVALIDATION&quot;&quot; value=&quot;&quot;&quot;
    Dim eventValStartIndex As Integer = loginResponse.IndexOf(eventValSearchString)
    loginResponse = loginResponse.Substring(eventValStartIndex &#43; eventValSearchString.Length)
    Dim eventValidationValue As String = Uri.EscapeDataString(loginResponse.Substring(0, loginResponse.IndexOf(&quot;&quot;&quot; /&gt;&quot;)))
    Dim postString As String = viewStateVar &amp; viewStateValue &amp; &quot;&amp;&quot; &amp; userNameVar &amp; userNameValue &amp; &quot;&amp;&quot; &amp; passwordVar &amp; passwordValue &amp; &quot;&amp;&quot; &amp; loginButtonVar &amp; loginButtonValue &amp; &quot;&amp;&quot; &amp; eventValidationVar &amp; eventValidationValue


    ' Do a POST to login.aspx now
    ' This should result in 302 with Set-Cookie header
    request = DirectCast(WebRequest.Create(loginUrl), HttpWebRequest)
    request.AllowAutoRedirect = False
    request.CookieContainer = cookieContainer
    request.Method = &quot;POST&quot;
    request.ContentType = &quot;application/x-www-form-urlencoded&quot;


    Dim encoding As New System.Text.ASCIIEncoding()
    Dim requestData As Byte() = encoding.GetBytes(postString)
    request.ContentLength = requestData.Length
    Dim requestStream As Stream = request.GetRequestStream()
    requestStream.Write(requestData, 0, requestData.Length)
    requestStream.Close()
    response = DirectCast(request.GetResponse(), HttpWebResponse)


    request = DirectCast(WebRequest.Create(reportServiceUrl), HttpWebRequest)
    request.AllowAutoRedirect = False
    request.CookieContainer = cookieContainer


    response = DirectCast(request.GetResponse(), HttpWebResponse)
    If response.StatusCode = HttpStatusCode.OK Then
        ViewBag.Status = &quot;Response: &quot; &amp; response.StatusCode
    Else
        ViewBag.Status = &quot;Response status is &quot; &amp; response.StatusCode &amp; &quot;. Expected was OK&quot;
    End If


    sr = New StreamReader(response.GetResponseStream())
    Dim strXML As String = sr.ReadToEnd()
    sr.Close()


    Dim document As XDocument = XDocument.Parse(strXML)
    Dim personList As New List(Of Person)()
    Dim list = From node In document.Descendants(XName.[Get](&quot;Detail&quot;, &quot;testReport&quot;))
               Select node
    For Each node In list
        Dim person As New Person()
        Dim id As Integer
        If Integer.TryParse(node.Attribute(&quot;ID&quot;).Value, id) Then
            person.Name = node.Attribute(&quot;Name&quot;).Value
            person.ID = id
            person.Comments = node.Attribute(&quot;Comments&quot;).Value
            personList.Add(person)
        End If
    Next


    ViewBag.NumTimes = personList.Count
    ViewBag.List = personList


    Return View()
End Function

</pre>
<pre id="codePreview" class="vb">Function Index() As ActionResult
    ViewBag.Message = &quot;VBAzureSQLReportingServices&quot;


    Dim request As HttpWebRequest = Nothing
    Dim response As HttpWebResponse = Nothing
    Dim sr As StreamReader = Nothing
    Dim serviceUri As String = &quot;Your service server url&quot; ' such as https://xxxx.reporting.windows.net/ReportServer 
    Dim servicePath As String = &quot;You service folder path&quot; ' such as /testFolder/testReport
    Dim logonPath As String = &quot;/logon.aspx&quot;
    Dim commandParameter As String = &quot;rs:Command=GetSharedDatasetDefinition&quot;
    Dim formatParameter As String = &quot;rs:Format=XML&quot;
    Dim reportServiceUrl As String = String.Format(&quot;{0}?{1}&amp;{2}&amp;{3}&quot;, serviceUri, servicePath, commandParameter, formatParameter)
    Dim loginUrl As String = String.Format(&quot;{0}{1}&quot;, serviceUri, logonPath)


    ' Request page protected by forms authentication.
    ' This request will get a 302 to login page
    request = DirectCast(WebRequest.Create(loginUrl), HttpWebRequest)
    request.AllowAutoRedirect = False
    Dim cookieContainer = New CookieContainer()
    request.CookieContainer = cookieContainer


    response = DirectCast(request.GetResponse(), HttpWebResponse)
    If response.StatusCode = HttpStatusCode.Found Then
        ViewBag.Status = &quot;Response: 302 &quot; &amp; response.StatusCode
    Else
        ViewBag.Status = &quot;Response status is &quot; &amp; response.StatusCode &amp; &quot;. Expected was Found&quot;
    End If


    ' Get the url of login page from location header
    Dim locationHeader As String = response.GetResponseHeader(&quot;Location&quot;)


    ' Request login page
    request = DirectCast(WebRequest.Create(loginUrl), HttpWebRequest)
    request.AllowAutoRedirect = False
    request.CookieContainer = cookieContainer


    response = DirectCast(request.GetResponse(), HttpWebResponse)
    If response.StatusCode = HttpStatusCode.OK Then
        ViewBag.Status = &quot;Response: &quot; &amp; response.StatusCode
    Else
        ViewBag.Status = &quot;Response status is &quot; &amp; response.StatusCode &amp; &quot;. Expected was OK&quot;
    End If




    sr = New StreamReader(response.GetResponseStream())
    Dim loginResponse As String = sr.ReadToEnd()
    sr.Close()


    ' Get SQL Azure Reporting service xml.
    Dim viewStateVar As String = &quot;__VIEWSTATE=&quot;
    Dim viewStateSearchString As String = &quot;name=&quot;&quot;__VIEWSTATE&quot;&quot; id=&quot;&quot;__VIEWSTATE&quot;&quot; value=&quot;&quot;&quot;
    Dim viewStateStartIndex As Integer = loginResponse.IndexOf(viewStateSearchString)


    loginResponse = loginResponse.Substring(viewStateStartIndex &#43; viewStateSearchString.Length)
    Dim viewStateValue As String = Uri.EscapeDataString(loginResponse.Substring(0, loginResponse.IndexOf(&quot;&quot;&quot; /&gt;&quot;)))
    loginResponse = loginResponse.Substring(loginResponse.IndexOf(&quot;&quot;&quot; /&gt;&quot;))


    Dim userNameVar As String = &quot;TxtUser=&quot;
    Dim userNameValue As String = &quot;arwindgao&quot;
    Dim passwordVar As String = &quot;TxtPwd=&quot;
    Dim passwordValue As String = &quot;Password0~&quot;
    Dim loginButtonVar As String = &quot;BtnLogon=&quot;
    Dim loginButtonValue As String = &quot;Log&#43;In&quot;
    Dim eventValidationVar As String = &quot;__EVENTVALIDATION=&quot;
    Dim eventValSearchString As String = &quot;name=&quot;&quot;__EVENTVALIDATION&quot;&quot; id=&quot;&quot;__EVENTVALIDATION&quot;&quot; value=&quot;&quot;&quot;
    Dim eventValStartIndex As Integer = loginResponse.IndexOf(eventValSearchString)
    loginResponse = loginResponse.Substring(eventValStartIndex &#43; eventValSearchString.Length)
    Dim eventValidationValue As String = Uri.EscapeDataString(loginResponse.Substring(0, loginResponse.IndexOf(&quot;&quot;&quot; /&gt;&quot;)))
    Dim postString As String = viewStateVar &amp; viewStateValue &amp; &quot;&amp;&quot; &amp; userNameVar &amp; userNameValue &amp; &quot;&amp;&quot; &amp; passwordVar &amp; passwordValue &amp; &quot;&amp;&quot; &amp; loginButtonVar &amp; loginButtonValue &amp; &quot;&amp;&quot; &amp; eventValidationVar &amp; eventValidationValue


    ' Do a POST to login.aspx now
    ' This should result in 302 with Set-Cookie header
    request = DirectCast(WebRequest.Create(loginUrl), HttpWebRequest)
    request.AllowAutoRedirect = False
    request.CookieContainer = cookieContainer
    request.Method = &quot;POST&quot;
    request.ContentType = &quot;application/x-www-form-urlencoded&quot;


    Dim encoding As New System.Text.ASCIIEncoding()
    Dim requestData As Byte() = encoding.GetBytes(postString)
    request.ContentLength = requestData.Length
    Dim requestStream As Stream = request.GetRequestStream()
    requestStream.Write(requestData, 0, requestData.Length)
    requestStream.Close()
    response = DirectCast(request.GetResponse(), HttpWebResponse)


    request = DirectCast(WebRequest.Create(reportServiceUrl), HttpWebRequest)
    request.AllowAutoRedirect = False
    request.CookieContainer = cookieContainer


    response = DirectCast(request.GetResponse(), HttpWebResponse)
    If response.StatusCode = HttpStatusCode.OK Then
        ViewBag.Status = &quot;Response: &quot; &amp; response.StatusCode
    Else
        ViewBag.Status = &quot;Response status is &quot; &amp; response.StatusCode &amp; &quot;. Expected was OK&quot;
    End If


    sr = New StreamReader(response.GetResponseStream())
    Dim strXML As String = sr.ReadToEnd()
    sr.Close()


    Dim document As XDocument = XDocument.Parse(strXML)
    Dim personList As New List(Of Person)()
    Dim list = From node In document.Descendants(XName.[Get](&quot;Detail&quot;, &quot;testReport&quot;))
               Select node
    For Each node In list
        Dim person As New Person()
        Dim id As Integer
        If Integer.TryParse(node.Attribute(&quot;ID&quot;).Value, id) Then
            person.Name = node.Attribute(&quot;Name&quot;).Value
            person.ID = id
            person.Comments = node.Attribute(&quot;Comments&quot;).Value
            personList.Add(person)
        End If
    Next


    ViewBag.NumTimes = personList.Count
    ViewBag.List = personList


    Return View()
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">4. Build the application and you can debug it now.</p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span><a href="http://msdn.microsoft.com/en-us/library/ms167559.aspx">Lesson 1: Creating a Report Server Project (Reporting Services)</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span><a href="http://msdn.microsoft.com/en-us/library/ms251671(v=VS.80).aspx">ReportViewer Controls (Visual Studio)</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/windowsazure/gg430130.aspx">SQL Azure Reporting Preview</a><span>
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span><a href="http://msdn.microsoft.com/en-us/library/system.net.httpwebrequest.aspx">HttpWebRequest Class</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
