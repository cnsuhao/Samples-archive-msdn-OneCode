# ASP.NET call web service across domain (CSASPNETAJAXConsumeExternalWebService)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* AJAX
* Web Services
## IsPublished
* True
## ModifiedDate
* 2011-05-05 08:52:45
## Description

<p style="font-family:Courier New"></p>
<h2>CSASPNETAJAXConsumeExternalWebService Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The project illustrates how to consume an external Web Service from a<br>
different domain.<br>
<br>
Demo the Sample. <br>
<br>
Please follow these demonstration steps below.<br>
<br>
Step 1: Open the CSASPNETAJAXConsumeExternalWebService.sln.<br>
<br>
Step 2: Expand the ExternalWebSite and right-click the ExternalWebService.asmx <br>
&nbsp; &nbsp; &nbsp; &nbsp;and click &quot;View in Browser&quot;. This step is very important,
<br>
&nbsp; &nbsp; &nbsp; &nbsp;it impersonates to open an external web service.<br>
<br>
Step 3: Expand the TestWebSite and right-click the default.aspx and click <br>
&nbsp; &nbsp; &nbsp; &nbsp;&quot;View in Browser&quot;.<br>
<br>
Step 4: You will see a black panel and a Button. Click on the button. You will<br>
&nbsp;&nbsp;&nbsp;&nbsp;see &quot;Please wait a moment...&quot; in the Panel, after about one second or
<br>
&nbsp;&nbsp;&nbsp;&nbsp;less time, you will see the datetime returned from the server.<br>
<br>
Step 5: That's all.<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step 1. &nbsp;Create an C# &quot;ASP.NET Empty Web Site&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp; Visual Web Developer 2010. Change the last folder name to ExternalWebSite.<br>
<br>
Step 2. &nbsp;Add a new &quot;Web Service&quot; item. We call it ExternalWebService.asmx.<br>
<br>
Step 3. &nbsp;Open the ExternalWebService.asmx.cs in App_Code.<br>
<br>
Step 4. &nbsp;Un-comment this line above the class name.<br>
&nbsp; &nbsp; &nbsp; &nbsp; [CODE]<br>
&nbsp; &nbsp; &nbsp; &nbsp; [System.Web.Script.Services.ScriptService]<br>
&nbsp; &nbsp; &nbsp; &nbsp; [/CODE]<br>
<br>
Step 5. &nbsp;Write a new web method like below and save the file.<br>
&nbsp; &nbsp; &nbsp; &nbsp; [CODE]<br>
&nbsp; &nbsp; &nbsp; &nbsp; [WebMethod]<br>
&nbsp; &nbsp; &nbsp; &nbsp; public DateTime GetServerTime() {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return DateTime.Now;<br>
&nbsp; &nbsp; &nbsp; &nbsp; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; [/CODE]<br>
<br>
Step 6. &nbsp;Open the ExternalWebService.asmx to view the page in the browser.<br>
&nbsp; &nbsp; &nbsp; &nbsp; Copy the URL address in the navigation bar.<br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
Step 7. &nbsp;Add a new C# &quot;ASP.NET Empty Web Site&quot;. Change the last folder name<br>
&nbsp; &nbsp; &nbsp; &nbsp; to TestWebSite.<br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
Step 8. &nbsp;Click on the new website in the Solution Explorer and look at the menu<br>
&nbsp; &nbsp; &nbsp; &nbsp; bar. Click the WebSite -&gt; Add Web Reference...<br>
<br>
Step 9. &nbsp;Paste the URL address which we get in the step 6 into the &quot;URL&quot; textbox.<br>
&nbsp; &nbsp; &nbsp; &nbsp; Change the &quot;Web Reference Name&quot; to &quot;ExternalWebService&quot;. Click &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &quot;Add Reference&quot;.<br>
<br>
Step 10. Create a new &quot;Web Service&quot; item. Change the name to BridgeWebService.asmx<br>
<br>
Step 11. Open the BridgeWebService.asmx.cs in the App_Code. Do the same thing in<br>
&nbsp; &nbsp; &nbsp; &nbsp; step 4.<br>
<br>
Step 12. Write the code below to call the external web service and save the file.<br>
&nbsp; &nbsp; &nbsp; &nbsp; [CODE]<br>
&nbsp; &nbsp; &nbsp; &nbsp; [WebMethod]<br>
&nbsp; &nbsp; &nbsp; &nbsp; public DateTime GetServerTime()<br>
&nbsp; &nbsp; &nbsp; &nbsp; {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; // Get an instance of the external web service<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ExternalWebService.ExternalWebService ews = new ExternalWebService.ExternalWebService();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; // Return the result from the web service method.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; return ews.GetServerTime();<br>
&nbsp; &nbsp; &nbsp; &nbsp; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; [/CODE]<br>
<br>
Step 13. Create a new &quot;Web Form&quot; item. Chage the name to Default.aspx.<br>
<br>
Step 14. Add a ScriptManager control into the page. And a service reference <br>
&nbsp; &nbsp; &nbsp; &nbsp; which path is the local bridge web service: BridgeWebService.asmx.<br>
<br>
Step 15. Create a DIV for showing the result and a Button to call the service.<br>
&nbsp; &nbsp; &nbsp; &nbsp; [CODE]<br>
&nbsp; &nbsp; &nbsp; &nbsp; &lt;div id=&quot;Result&quot; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;style=&quot;width: 100%; height: 100px; background-color: Black; color: White&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &lt;/div&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &lt;input type=&quot;button&quot; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;value=&quot;Get Server Time From External Web Service&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;onclick=&quot;GetServerDateTime()&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; [/CODE]<br>
<br>
Step 16. Create the Javascript functions to call the web service.<br>
&nbsp; &nbsp; &nbsp; &nbsp; [CODE]<br>
&nbsp; &nbsp; &nbsp; &nbsp; &lt;script type=&quot;text/javascript&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; // This function is used to call the service by Ajax Extension.<br>
&nbsp; &nbsp; &nbsp; &nbsp; function GetServerDateTime() {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; $get(&quot;Result&quot;).innerHTML = &quot;Please wait a moment...&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; BridgeWebService.GetServerTime(onSuccess, onFailed);<br>
&nbsp; &nbsp; &nbsp; &nbsp; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; // This function will be executed when get a response
<br>
&nbsp; &nbsp; &nbsp; &nbsp; // from the service.<br>
&nbsp; &nbsp; &nbsp; &nbsp; function onSuccess(result) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; $get(&quot;Result&quot;).innerHTML = &quot;Server DateTime is : &quot; &#43; result.toLocaleString();<br>
&nbsp; &nbsp; &nbsp; &nbsp; }<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; // This function will be executed when get an exception<br>
&nbsp; &nbsp; &nbsp; &nbsp; // from the service.<br>
&nbsp; &nbsp; &nbsp; &nbsp; function onFailed(args) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; alert(&quot;Server Return Error:\n&quot; &#43;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot;Message:&quot; &#43; args.get_message() &#43; &quot;\n&quot; &#43;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot;Status Code:&quot; &#43; args.get_statusCode() &#43; &quot;\n&quot; &#43;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot;Exception Type:&quot; &#43; args.get_exceptionType());<br>
&nbsp; &nbsp; &nbsp; &nbsp; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; &lt;/script&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; [/CODE]<br>
&nbsp; &nbsp; &nbsp; &nbsp; When we add the ServiceReference of the ScriptManager, we will see<br>
&nbsp; &nbsp; &nbsp; &nbsp; IntelliSense effect.<br>
<br>
Step 17. Test the Default.aspx and we will get the datetime from the server.<br>
<br>
PS<br>
If we want to use an AJAX-enabled WCF service from a different domain with <br>
Service Reference of the ScriptManager, the steps are same as we talked above.<br>
Just create a local AJAX-enabled WCF service to make a bridge to consume the<br>
remote one.</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: ServiceReference Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.servicereference.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.servicereference.aspx</a><br>
<br>
MSDN: ASP.NET Web Services<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/t745kdsh.aspx">http://msdn.microsoft.com/en-us/library/t745kdsh.aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
