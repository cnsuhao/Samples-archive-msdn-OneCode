# How to use HttpClient to post Json data to WebService in Windows Store apps
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows 8
* Windows Store app Development
## Topics
* JSON
* HttpClient
## IsPublished
* True
## ModifiedDate
* 2014-01-02 08:46:01
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<h1><span style="">How to use <span class="SpellE">HttpClient</span> to post JSON data to
<span class="SpellE">WebService</span> in Windows Store app (<span class="SpellE">CppWindowsStoreAppHttpClientPostJson</span>)
</span></h1>
<h2><span style="">Introduction </span></h2>
<p class="MsoNormal">​The sample demonstrates how to use the <span class="SpellE">
HttpClient</span> and <span class="SpellE">JsonObject</span> class to post JSON data to a web service. It's easy to achieve this in&nbsp;<span class="SpellE">WinJS</span> realm.<span style="">&nbsp;
</span>But there is no example shows how to do this using <span class="SpellE">
HttpClient</span> in C&#43;&#43; language. </p>
<h2><span style="">Build the Sample </span></h2>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Start Visual Studio 2013 and select File &gt; Open &gt; Project/Solution.
</span></p>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Go to the directory in which you download the sample. Go to the directory named for the sample, and double-click the Microsoft Visual Studio Solution (.<span class="SpellE">sln</span>) file.
</span></p>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Press F7 or use Build &gt; Build Solution to build the sample.
</span></p>
<h2><span style="">Running the Sample </span></h2>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Right click &quot;<span class="SpellE">JSONWCFService</span>&quot; project and click &quot;View in Browser (Internet Explorer)&quot; to run JSON Web Service firstly.
</span></p>
<p class="MsoNormal" style="margin-left:9.0pt"><span style=""><img src="/site/view/file/106404/1/image.png" alt="" width="576" height="324" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Click 'Start' button to get result from a web service, you will see below result.
</span></p>
<p class="MsoNormal" style="margin-left:9.0pt"><span style=""><img src="/site/view/file/106405/1/image.png" alt="" width="576" height="325" align="middle">
</span><span style=""></span></p>
<h2><span style="">Using the Code </span></h2>
<p class="MsoNormal"><span style="">1. Create a C&#43;&#43; Windows Store app project by using Visual Studio 2013.
</span></p>
<p class="MsoNormal"><span style="">2. Add WCF Service Application project into the solution
</span></p>
<p class="MsoNormal"><span style="">3. Create a web service. </span></p>
<p class="MsoNormal"><span style="">4. Configure the configuration file of the web service.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;system.serviceModel&gt;
&nbsp;&nbsp;&nbsp; &lt;!--Add Services--&gt;
&nbsp; &lt;services&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;service name=&quot;JSONWCFService.WCFService&quot; behaviorConfiguration=&quot;ServiceBehaviour&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;endpoint name=&quot;JsonEndPoint&quot; contract=&quot;JSONWCFService.IWCFService&quot; binding=&quot;webHttpBinding&quot; behaviorConfiguration=&quot;jsonbehavior&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/service&gt;
&nbsp;&nbsp;&nbsp; &lt;/services&gt;
&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&lt;behaviors&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;serviceBehaviors&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;behavior name=&quot;ServiceBehaviour&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;!-- To avoid disclosing metadata information, set the values below to false before deployment --&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;serviceMetadata httpGetEnabled=&quot;true&quot; httpsGetEnabled=&quot;true&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;!-- To receive exception details in faults for debugging purposes, set the value below to true.&nbsp; Set to false before deployment to avoid disclosing exception information --&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;serviceDebug includeExceptionDetailInFaults=&quot;false&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/behavior&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/serviceBehaviors&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;!--Add EndPoint Behaviors--&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;endpointBehaviors&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;behavior name=&quot;jsonbehavior&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;webHttp defaultBodyStyle=&quot;Wrapped&quot; defaultOutgoingResponseFormat=&quot;Json&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/behavior&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/endpointBehaviors&gt;
&nbsp;&nbsp;&nbsp; &lt;/behaviors&gt;
&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&lt;protocolMapping&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;add binding=&quot;basicHttpsBinding&quot; scheme=&quot;https&quot; /&gt;
&nbsp;&nbsp;&nbsp; &lt;/protocolMapping&gt;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&lt;serviceHostingEnvironment aspNetCompatibilityEnabled=&quot;true&quot; multipleSiteBindingsEnabled=&quot;true&quot; /&gt;
&nbsp; &lt;/system.serviceModel&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;system.serviceModel&gt;
&nbsp;&nbsp;&nbsp; &lt;!--Add Services--&gt;
&nbsp; &lt;services&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;service name=&quot;JSONWCFService.WCFService&quot; behaviorConfiguration=&quot;ServiceBehaviour&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;endpoint name=&quot;JsonEndPoint&quot; contract=&quot;JSONWCFService.IWCFService&quot; binding=&quot;webHttpBinding&quot; behaviorConfiguration=&quot;jsonbehavior&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/service&gt;
&nbsp;&nbsp;&nbsp; &lt;/services&gt;
&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&lt;behaviors&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;serviceBehaviors&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;behavior name=&quot;ServiceBehaviour&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;!-- To avoid disclosing metadata information, set the values below to false before deployment --&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;serviceMetadata httpGetEnabled=&quot;true&quot; httpsGetEnabled=&quot;true&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;!-- To receive exception details in faults for debugging purposes, set the value below to true.&nbsp; Set to false before deployment to avoid disclosing exception information --&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;serviceDebug includeExceptionDetailInFaults=&quot;false&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/behavior&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/serviceBehaviors&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;!--Add EndPoint Behaviors--&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;endpointBehaviors&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;behavior name=&quot;jsonbehavior&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;webHttp defaultBodyStyle=&quot;Wrapped&quot; defaultOutgoingResponseFormat=&quot;Json&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/behavior&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/endpointBehaviors&gt;
&nbsp;&nbsp;&nbsp; &lt;/behaviors&gt;
&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&lt;protocolMapping&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;add binding=&quot;basicHttpsBinding&quot; scheme=&quot;https&quot; /&gt;
&nbsp;&nbsp;&nbsp; &lt;/protocolMapping&gt;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&lt;serviceHostingEnvironment aspNetCompatibilityEnabled=&quot;true&quot; multipleSiteBindingsEnabled=&quot;true&quot; /&gt;
&nbsp; &lt;/system.serviceModel&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">5.<span style="">&nbsp; </span>Use <span class="SpellE">
HttpClient</span> class to post <span class="SpellE">json</span> data to a web service and get the callback result in Windows Store app.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
// Start to Call WCF service
void CppWindowsStoreAppHttpClientPostJson::MainPage::Start_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
&nbsp;&nbsp;&nbsp; m_dispatcher = Windows::UI::Core::CoreWindow::GetForCurrentThread()-&gt;Dispatcher;


&nbsp;&nbsp;&nbsp; // Clear text of Output textbox
&nbsp;&nbsp;&nbsp; this-&gt;OutputField-&gt;Text = &quot;&quot;;
&nbsp;&nbsp;&nbsp; this-&gt;StatusBlock-&gt;Text = &quot;&quot;;
&nbsp;&nbsp;&nbsp; int age = _wtoi(this-&gt;Agetxt-&gt;Text-&gt;Data());
&nbsp;&nbsp;&nbsp; if (age == 0)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NotifyUser(&quot;Age Must input number&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return;
&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; if (age&gt;120 || age&lt;0)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NotifyUser(L&quot;Age must be between 0 and 120&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return;
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; this-&gt;StartButton-&gt;IsEnabled = false;
&nbsp;&nbsp;&nbsp; HttpClient^ httpClient =ref new HttpClient();
&nbsp;&nbsp;&nbsp; Uri^ uri = ref new Uri(&quot;http://localhost:28539/WCFService.svc/GetData&quot;);
&nbsp;&nbsp;&nbsp; Person^ p = ref new Person();
&nbsp;&nbsp;&nbsp; p-&gt;Name = this-&gt;Nametxt-&gt;Text;
&nbsp;&nbsp;&nbsp; p-&gt;Age = age;


&nbsp;&nbsp;&nbsp; JsonObject^ postData =ref new JsonObject();
&nbsp;&nbsp;&nbsp; postData-&gt;SetNamedValue(&quot;Name&quot;, JsonValue::CreateStringValue(p-&gt;Name));
&nbsp;&nbsp;&nbsp; postData-&gt;SetNamedValue(&quot;Age&quot;,JsonValue::CreateStringValue(p-&gt;Age.ToString()));
&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;// async send &quot;get&quot; request to get response string form service
&nbsp;&nbsp;&nbsp; IAsyncOperationWithProgress&lt;HttpResponseMessage^, HttpProgress&gt; ^accessSQLOp = httpClient-&gt;PostAsync(uri, ref new HttpStringContent(postData-&gt;Stringify(), UnicodeEncoding::Utf8,&quot;application/json&quot;));
&nbsp;&nbsp;&nbsp; auto operationTask = create_task(accessSQLOp);
&nbsp;&nbsp;&nbsp; operationTask.then([this](HttpResponseMessage^ response){
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (response-&gt;StatusCode == HttpStatusCode::Ok)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; auto asyncOperationWithProgress = response-&gt;Content-&gt;ReadAsStringAsync();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; create_task(asyncOperationWithProgress).then([this](Platform::String^ responJsonText)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; result = GetJsonValue(responJsonText);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_dispatcher-&gt;RunAsync(Windows::UI::Core::CoreDispatcherPriority::Normal,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ref new Windows::UI::Core::DispatchedHandler([this]()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; this-&gt;OutputField-&gt;Text = result;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; this-&gt;StartButton-&gt;IsEnabled = true;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; catch (Exception^ ex)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NotifyUser(ex-&gt;Message);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; this-&gt;StartButton-&gt;IsEnabled = true;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; });
}

</pre>
<pre id="codePreview" class="cplusplus">
// Start to Call WCF service
void CppWindowsStoreAppHttpClientPostJson::MainPage::Start_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
&nbsp;&nbsp;&nbsp; m_dispatcher = Windows::UI::Core::CoreWindow::GetForCurrentThread()-&gt;Dispatcher;


&nbsp;&nbsp;&nbsp; // Clear text of Output textbox
&nbsp;&nbsp;&nbsp; this-&gt;OutputField-&gt;Text = &quot;&quot;;
&nbsp;&nbsp;&nbsp; this-&gt;StatusBlock-&gt;Text = &quot;&quot;;
&nbsp;&nbsp;&nbsp; int age = _wtoi(this-&gt;Agetxt-&gt;Text-&gt;Data());
&nbsp;&nbsp;&nbsp; if (age == 0)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NotifyUser(&quot;Age Must input number&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return;
&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; if (age&gt;120 || age&lt;0)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NotifyUser(L&quot;Age must be between 0 and 120&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return;
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; this-&gt;StartButton-&gt;IsEnabled = false;
&nbsp;&nbsp;&nbsp; HttpClient^ httpClient =ref new HttpClient();
&nbsp;&nbsp;&nbsp; Uri^ uri = ref new Uri(&quot;http://localhost:28539/WCFService.svc/GetData&quot;);
&nbsp;&nbsp;&nbsp; Person^ p = ref new Person();
&nbsp;&nbsp;&nbsp; p-&gt;Name = this-&gt;Nametxt-&gt;Text;
&nbsp;&nbsp;&nbsp; p-&gt;Age = age;


&nbsp;&nbsp;&nbsp; JsonObject^ postData =ref new JsonObject();
&nbsp;&nbsp;&nbsp; postData-&gt;SetNamedValue(&quot;Name&quot;, JsonValue::CreateStringValue(p-&gt;Name));
&nbsp;&nbsp;&nbsp; postData-&gt;SetNamedValue(&quot;Age&quot;,JsonValue::CreateStringValue(p-&gt;Age.ToString()));
&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;// async send &quot;get&quot; request to get response string form service
&nbsp;&nbsp;&nbsp; IAsyncOperationWithProgress&lt;HttpResponseMessage^, HttpProgress&gt; ^accessSQLOp = httpClient-&gt;PostAsync(uri, ref new HttpStringContent(postData-&gt;Stringify(), UnicodeEncoding::Utf8,&quot;application/json&quot;));
&nbsp;&nbsp;&nbsp; auto operationTask = create_task(accessSQLOp);
&nbsp;&nbsp;&nbsp; operationTask.then([this](HttpResponseMessage^ response){
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (response-&gt;StatusCode == HttpStatusCode::Ok)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; auto asyncOperationWithProgress = response-&gt;Content-&gt;ReadAsStringAsync();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; create_task(asyncOperationWithProgress).then([this](Platform::String^ responJsonText)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; result = GetJsonValue(responJsonText);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_dispatcher-&gt;RunAsync(Windows::UI::Core::CoreDispatcherPriority::Normal,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ref new Windows::UI::Core::DispatchedHandler([this]()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; this-&gt;OutputField-&gt;Text = result;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; this-&gt;StartButton-&gt;IsEnabled = true;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; catch (Exception^ ex)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NotifyUser(ex-&gt;Message);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; this-&gt;StartButton-&gt;IsEnabled = true;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; });
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2><span style="">More Information </span></h2>
<p class="MsoNormal"><span class="SpellE"><span style="">HttpClient</span></span><span style=""> Class
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.web.http.httpclient.aspx?cs-save-lang=1&cs-lang=cpp#code-snippet-1">http://msdn.microsoft.com/en-us/library/windows/apps/windows.web.http.httpclient.aspx?cs-save-lang=1&amp;cs-lang=cpp#code-snippet-1</a></p>
<p class="MsoNormal"><span class="SpellE"><span style="">JsonObject</span></span><span style=""> class
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.data.json.jsonobject.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/windows.data.json.jsonobject.aspx</a>
<span style=""></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
