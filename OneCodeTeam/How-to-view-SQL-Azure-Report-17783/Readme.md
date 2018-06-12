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
* 2013-04-16 10:24:26
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<p class="MsoNormal">This sample should be <span>run with Windows Azure SDK 1.6,
<span class="SpellE">Sql</span> Server 2012 (With Reporting components), <span class="GramE">
ASP.NET</span> MVC 4. </span></p>
<p class="MsoNormal">1. <span>Open the </span><span>CSAzureSQLReportingServices</span><span>.sln file with Visual Studio
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
<p class="MsoNormal"><span><img src="/site/view/file/73958/1/image.png" alt="" width="552" height="529" align="middle">
</span></p>
<p class="MsoNormal">4. <span>Before running the MVC role, you have to replace your information in code-behind file (HomeController.cs):
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">string serviceUri = &quot;Your service server url&quot;; // such as https://xxxx.reporting.windows.net/ReportServer 
string servicePath = &quot;You service folder path&quot;; // such as /testFolder/testReport

</pre>
<pre id="codePreview" class="csharp">string serviceUri = &quot;Your service server url&quot;; // such as https://xxxx.reporting.windows.net/ReportServer 
string servicePath = &quot;You service folder path&quot;; // such as /testFolder/testReport

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span>5</span>. Running the AzureSQLReportingSerivces_MVC4Role application, and view your report data in the below image:</p>
<p class="MsoNormal"><span><img src="/site/view/file/73959/1/image.png" alt="" width="552" height="529" align="middle">
</span></p>
<p class="MsoNormal">6. <span>Validation finished </span></p>
<p class="MsoNormal"><span>1</span>. <span>Create a Windows Azure Application Project in Visual Studio
<span class="GramE">2010,</span> name it as &quot;</span><span>CSAzureSQLReportingServices</span><span>&quot;.
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
</span></span></span><span>Configure your report with folder path and target server
<span class="SpellE"><span class="GramE">url</span></span>. (Here you need provide SQL Azure reporting server
<span class="SpellE">url</span>) </span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Deploy Report Server Project Application </span></p>
<p class="MsoNormal"><span>2. </span>Add a WebRole application and a MVC 4 WebRole in Cloud
<span class="GramE">application,</span> name them as &quot;AzureSQLReportingServices_WebRole&quot; and &quot;AzureSQLReportingSerivces_MVC4Role&quot;. In WebRole application, you need drag and drop a ReportViewer and a ScriptManager on Default.aspx page, create ReportViewerCredentials
 class to send forms credentials to ReportView.</p>
<p class="MsoNormal"><strong><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">The following code is used to send username/password/service url to ReportViewer control</span></strong><strong><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">:
</span></strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">protected void Page_Load(object sender, EventArgs e)
{
    // Get username/password/domain from web.config and send form credential to SQL Azure reporting service.
    if (!this.IsPostBack)
    {
        string user = ConfigurationManager.AppSettings[&quot;sqlAzureRSUser&quot;];
        string password = ConfigurationManager.AppSettings[&quot;sqlAzureRSPassword&quot;];
        string domain = ConfigurationManager.AppSettings[&quot;sqlAzureRSDomain&quot;];
        this.ReportViewer1.ServerReport.ReportServerCredentials = new ReportViewerCredentials(user, password, domain);
        this.ReportViewer1.ServerReport.Refresh();
    }
}

</pre>
<pre id="codePreview" class="csharp">protected void Page_Load(object sender, EventArgs e)
{
    // Get username/password/domain from web.config and send form credential to SQL Azure reporting service.
    if (!this.IsPostBack)
    {
        string user = ConfigurationManager.AppSettings[&quot;sqlAzureRSUser&quot;];
        string password = ConfigurationManager.AppSettings[&quot;sqlAzureRSPassword&quot;];
        string domain = ConfigurationManager.AppSettings[&quot;sqlAzureRSDomain&quot;];
        this.ReportViewer1.ServerReport.ReportServerCredentials = new ReportViewerCredentials(user, password, domain);
        this.ReportViewer1.ServerReport.Refresh();
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">3. The MVC WebRole has not ReportView control, so we need to write code to send web request to SQL Azure Server, and get ViewState, EventValidation from logon page, then we can get XML data of SQL Azure reporting service.</p>
<p class="MsoNormal"><strong><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">The following code is used to get XML data of SQL Azure reporting service by MVC Role</span></strong><strong><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">:
</span></strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public ActionResult Index()
{
    ViewBag.Message = &quot;CSAzureSQLReportingServices&quot;;


    HttpWebRequest request = null;
    HttpWebResponse response = null;
    StreamReader sr = null;
    string serviceUri = &quot;Your service server url&quot;; // such as https://xxxx.reporting.windows.net/ReportServer 
    string servicePath = &quot;You service folder path&quot;; // such as /testFolder/testReport
    string logonPath = &quot;/logon.aspx&quot;;
    string commandParameter = &quot;rs:Command=GetSharedDatasetDefinition&quot;;
    string formatParameter = &quot;rs:Format=XML&quot;;
    string reportServiceUrl = string.Format(&quot;{0}?{1}&amp;{2}&amp;{3}&quot;, serviceUri, servicePath, commandParameter, formatParameter);
    string loginUrl = string.Format(&quot;{0}{1}&quot;, serviceUri, logonPath);


    // Request page protected by forms authentication.
    // This request will get a 302 to login page
    request = (HttpWebRequest)WebRequest.Create(loginUrl);
    request.AllowAutoRedirect = false;
    var cookieContainer = new CookieContainer();
    request.CookieContainer = cookieContainer;


    response = (HttpWebResponse)request.GetResponse();
    if (response.StatusCode == HttpStatusCode.Found)
    {
        ViewBag.Status = &quot;Response: 302 &quot;;
        ViewBag.Status &#43;= response.StatusCode;
    }
    else
    {
        ViewBag.Status = &quot;Response status is &quot; &#43; response.StatusCode &#43; &quot;. Expected was Found&quot;;
    }


    // Get the url of login page from location header
    string locationHeader = response.GetResponseHeader(&quot;Location&quot;);


    // Request login page
    request = (HttpWebRequest)WebRequest.Create(loginUrl);
    request.AllowAutoRedirect = false;
    request.CookieContainer = cookieContainer;


    response = (HttpWebResponse)request.GetResponse();
    if (response.StatusCode == HttpStatusCode.OK)
    {
         ViewBag.Status = &quot;Response: 200 &quot;;
         ViewBag.Status &#43;= response.StatusCode;
    }
    else
    {
         ViewBag.Status = &quot;Response status is &quot; &#43; response.StatusCode &#43; &quot;. Expected was OK&quot;;
    }




    sr = new StreamReader(response.GetResponseStream());
    string loginResponse = sr.ReadToEnd();
    sr.Close();


    // Get SQL Azure Reporting service xml.
    string viewStateVar = &quot;__VIEWSTATE=&quot;;
    string viewStateSearchString = &quot;name=\&quot;__VIEWSTATE\&quot; id=\&quot;__VIEWSTATE\&quot; value=\&quot;&quot;;
    int viewStateStartIndex = loginResponse.IndexOf(viewStateSearchString);


    loginResponse = loginResponse.Substring(viewStateStartIndex &#43; viewStateSearchString.Length);
    string viewStateValue = Uri.EscapeDataString(loginResponse.Substring(0, loginResponse.IndexOf(&quot;\&quot; /&gt;&quot;)));
    loginResponse = loginResponse.Substring(loginResponse.IndexOf(&quot;\&quot; /&gt;&quot;));


    string userNameVar = &quot;TxtUser=&quot;;
    string userNameValue = &quot;arwindgao&quot;;
    string passwordVar = &quot;TxtPwd=&quot;;
    string passwordValue = &quot;Password0~&quot;;
    string loginButtonVar = &quot;BtnLogon=&quot;;
    string loginButtonValue = &quot;Log&#43;In&quot;;
    string eventValidationVar = &quot;__EVENTVALIDATION=&quot;;
    string eventValSearchString = &quot;name=\&quot;__EVENTVALIDATION\&quot; id=\&quot;__EVENTVALIDATION\&quot; value=\&quot;&quot;;
    int eventValStartIndex = loginResponse.IndexOf(eventValSearchString);
    loginResponse = loginResponse.Substring(eventValStartIndex &#43; eventValSearchString.Length);
    string eventValidationValue =
        Uri.EscapeDataString(
            loginResponse.Substring(0, loginResponse.IndexOf(&quot;\&quot; /&gt;&quot;))
        );
    string postString = viewStateVar &#43; viewStateValue;
    postString &#43;= &quot;&amp;&quot; &#43; userNameVar &#43; userNameValue;
    postString &#43;= &quot;&amp;&quot; &#43; passwordVar &#43; passwordValue;
    postString &#43;= &quot;&amp;&quot; &#43; loginButtonVar &#43; loginButtonValue;
    postString &#43;= &quot;&amp;&quot; &#43; eventValidationVar &#43; eventValidationValue;


    // Do a POST to login.aspx now
    // This should result in 302 with Set-Cookie header
    request = (HttpWebRequest)WebRequest.Create(loginUrl);
    request.AllowAutoRedirect = false;
    request.CookieContainer = cookieContainer;
    request.Method = &quot;POST&quot;;
    request.ContentType = &quot;application/x-www-form-urlencoded&quot;;


    System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
    byte[] requestData = encoding.GetBytes(postString);
    request.ContentLength = requestData.Length;
    Stream requestStream = request.GetRequestStream();
    requestStream.Write(requestData, 0, requestData.Length);
    requestStream.Close();
    response = (HttpWebResponse)request.GetResponse();


    request = (HttpWebRequest)WebRequest.Create(reportServiceUrl);
    request.AllowAutoRedirect = false;
    request.CookieContainer = cookieContainer;


    response = (HttpWebResponse)request.GetResponse();
    if (response.StatusCode == HttpStatusCode.OK)
    {
        ViewBag.Status = &quot;Response: 200 &quot;;
        ViewBag.Status &#43;= response.StatusCode;
    }
    else
    {
         ViewBag.Status = &quot;Response status is &quot; &#43; response.StatusCode &#43; &quot;. Expected was OK&quot;;
    }


    sr = new StreamReader(response.GetResponseStream());
    string strXML = sr.ReadToEnd();
    sr.Close();


    XDocument document = XDocument.Parse(strXML);
    List&lt;Person&gt; personList = new List&lt;Person&gt;();
    var list = from node in document.Descendants(XName.Get(&quot;Detail&quot;, &quot;testReport&quot;))
               select node;
    foreach (var node in list)
    {
        Person person = new Person();
        int id;
        if (int.TryParse(node.Attribute(&quot;ID&quot;).Value, out id))
        {
            person.Name = node.Attribute(&quot;Name&quot;).Value;
            person.ID = id;
            person.Comments = node.Attribute(&quot;Comments&quot;).Value;
            personList.Add(person);
        }
    }


    ViewBag.NumTimes = personList.Count;
    ViewBag.List = personList;


    return View();
}

</pre>
<pre id="codePreview" class="csharp">public ActionResult Index()
{
    ViewBag.Message = &quot;CSAzureSQLReportingServices&quot;;


    HttpWebRequest request = null;
    HttpWebResponse response = null;
    StreamReader sr = null;
    string serviceUri = &quot;Your service server url&quot;; // such as https://xxxx.reporting.windows.net/ReportServer 
    string servicePath = &quot;You service folder path&quot;; // such as /testFolder/testReport
    string logonPath = &quot;/logon.aspx&quot;;
    string commandParameter = &quot;rs:Command=GetSharedDatasetDefinition&quot;;
    string formatParameter = &quot;rs:Format=XML&quot;;
    string reportServiceUrl = string.Format(&quot;{0}?{1}&amp;{2}&amp;{3}&quot;, serviceUri, servicePath, commandParameter, formatParameter);
    string loginUrl = string.Format(&quot;{0}{1}&quot;, serviceUri, logonPath);


    // Request page protected by forms authentication.
    // This request will get a 302 to login page
    request = (HttpWebRequest)WebRequest.Create(loginUrl);
    request.AllowAutoRedirect = false;
    var cookieContainer = new CookieContainer();
    request.CookieContainer = cookieContainer;


    response = (HttpWebResponse)request.GetResponse();
    if (response.StatusCode == HttpStatusCode.Found)
    {
        ViewBag.Status = &quot;Response: 302 &quot;;
        ViewBag.Status &#43;= response.StatusCode;
    }
    else
    {
        ViewBag.Status = &quot;Response status is &quot; &#43; response.StatusCode &#43; &quot;. Expected was Found&quot;;
    }


    // Get the url of login page from location header
    string locationHeader = response.GetResponseHeader(&quot;Location&quot;);


    // Request login page
    request = (HttpWebRequest)WebRequest.Create(loginUrl);
    request.AllowAutoRedirect = false;
    request.CookieContainer = cookieContainer;


    response = (HttpWebResponse)request.GetResponse();
    if (response.StatusCode == HttpStatusCode.OK)
    {
         ViewBag.Status = &quot;Response: 200 &quot;;
         ViewBag.Status &#43;= response.StatusCode;
    }
    else
    {
         ViewBag.Status = &quot;Response status is &quot; &#43; response.StatusCode &#43; &quot;. Expected was OK&quot;;
    }




    sr = new StreamReader(response.GetResponseStream());
    string loginResponse = sr.ReadToEnd();
    sr.Close();


    // Get SQL Azure Reporting service xml.
    string viewStateVar = &quot;__VIEWSTATE=&quot;;
    string viewStateSearchString = &quot;name=\&quot;__VIEWSTATE\&quot; id=\&quot;__VIEWSTATE\&quot; value=\&quot;&quot;;
    int viewStateStartIndex = loginResponse.IndexOf(viewStateSearchString);


    loginResponse = loginResponse.Substring(viewStateStartIndex &#43; viewStateSearchString.Length);
    string viewStateValue = Uri.EscapeDataString(loginResponse.Substring(0, loginResponse.IndexOf(&quot;\&quot; /&gt;&quot;)));
    loginResponse = loginResponse.Substring(loginResponse.IndexOf(&quot;\&quot; /&gt;&quot;));


    string userNameVar = &quot;TxtUser=&quot;;
    string userNameValue = &quot;arwindgao&quot;;
    string passwordVar = &quot;TxtPwd=&quot;;
    string passwordValue = &quot;Password0~&quot;;
    string loginButtonVar = &quot;BtnLogon=&quot;;
    string loginButtonValue = &quot;Log&#43;In&quot;;
    string eventValidationVar = &quot;__EVENTVALIDATION=&quot;;
    string eventValSearchString = &quot;name=\&quot;__EVENTVALIDATION\&quot; id=\&quot;__EVENTVALIDATION\&quot; value=\&quot;&quot;;
    int eventValStartIndex = loginResponse.IndexOf(eventValSearchString);
    loginResponse = loginResponse.Substring(eventValStartIndex &#43; eventValSearchString.Length);
    string eventValidationValue =
        Uri.EscapeDataString(
            loginResponse.Substring(0, loginResponse.IndexOf(&quot;\&quot; /&gt;&quot;))
        );
    string postString = viewStateVar &#43; viewStateValue;
    postString &#43;= &quot;&amp;&quot; &#43; userNameVar &#43; userNameValue;
    postString &#43;= &quot;&amp;&quot; &#43; passwordVar &#43; passwordValue;
    postString &#43;= &quot;&amp;&quot; &#43; loginButtonVar &#43; loginButtonValue;
    postString &#43;= &quot;&amp;&quot; &#43; eventValidationVar &#43; eventValidationValue;


    // Do a POST to login.aspx now
    // This should result in 302 with Set-Cookie header
    request = (HttpWebRequest)WebRequest.Create(loginUrl);
    request.AllowAutoRedirect = false;
    request.CookieContainer = cookieContainer;
    request.Method = &quot;POST&quot;;
    request.ContentType = &quot;application/x-www-form-urlencoded&quot;;


    System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
    byte[] requestData = encoding.GetBytes(postString);
    request.ContentLength = requestData.Length;
    Stream requestStream = request.GetRequestStream();
    requestStream.Write(requestData, 0, requestData.Length);
    requestStream.Close();
    response = (HttpWebResponse)request.GetResponse();


    request = (HttpWebRequest)WebRequest.Create(reportServiceUrl);
    request.AllowAutoRedirect = false;
    request.CookieContainer = cookieContainer;


    response = (HttpWebResponse)request.GetResponse();
    if (response.StatusCode == HttpStatusCode.OK)
    {
        ViewBag.Status = &quot;Response: 200 &quot;;
        ViewBag.Status &#43;= response.StatusCode;
    }
    else
    {
         ViewBag.Status = &quot;Response status is &quot; &#43; response.StatusCode &#43; &quot;. Expected was OK&quot;;
    }


    sr = new StreamReader(response.GetResponseStream());
    string strXML = sr.ReadToEnd();
    sr.Close();


    XDocument document = XDocument.Parse(strXML);
    List&lt;Person&gt; personList = new List&lt;Person&gt;();
    var list = from node in document.Descendants(XName.Get(&quot;Detail&quot;, &quot;testReport&quot;))
               select node;
    foreach (var node in list)
    {
        Person person = new Person();
        int id;
        if (int.TryParse(node.Attribute(&quot;ID&quot;).Value, out id))
        {
            person.Name = node.Attribute(&quot;Name&quot;).Value;
            person.ID = id;
            person.Comments = node.Attribute(&quot;Comments&quot;).Value;
            personList.Add(person);
        }
    }


    ViewBag.NumTimes = personList.Count;
    ViewBag.List = personList;


    return View();
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">4. Build the application and you can debug it now.</p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span><a href="http://msdn.microsoft.com/en-us/library/ms167559.aspx">Lesson 1: Creating a Report Server Project (Reporting Services)</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span><a href="http://msdn.microsoft.com/en-us/library/ms251671(v=VS.80).aspx"><span class="SpellE">ReportViewer</span> Controls (Visual Studio)</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/windowsazure/gg430130.aspx">SQL Azure Reporting Preview</a><span>
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span><a href="http://msdn.microsoft.com/en-us/library/system.net.httpwebrequest.aspx"><span class="SpellE">HttpWebRequest</span> Class</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
