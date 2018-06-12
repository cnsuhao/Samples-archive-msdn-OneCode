# Disable script after execution in ASP.NET (VBASPNETDisableScriptAfterExecution)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Script
## IsPublished
* True
## ModifiedDate
* 2011-07-12 10:30:04
## Description

<p style="font-family:Courier New"></p>
<h2>VBASPNETDisableScriptAfterExecution Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The sample code illustrates how to register script code at code behind and to <br>
be disabled after execution. Sometimes users who register scripts do not want <br>
them execute again, Actually they with to achieve this either in an automatic<br>
manner or by imitating an action for example, by clicking a link or button. <br>
This maybe due to functional purpose, user experience or security concerns. <br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Please follow these demonstration steps below.<br>
<br>
Step 1: Open the VBASPNETDisableScriptAfterExecution.sln.<br>
<br>
Step 2: Expand the VBASPNETDisableScriptAfterExecution web application and press <br>
&nbsp; &nbsp; &nbsp; &nbsp;Ctrl &#43; F5 to show the Default.aspx.<br>
<br>
Step 3: You will see one button on the page, click it, you can find a dialog <br>
&nbsp; &nbsp; &nbsp; &nbsp;box that tell your this is user's defined logic. In this sample code,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;your web page will move down.<br>
<br>
Step 4: The second step, you can click this button again, the web page will <br>
&nbsp; &nbsp; &nbsp; &nbsp;tell you the JavaScript function has been disabled.<br>
<br>
Step 5: Validation finished.<br>
<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step 1. Create a VB &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp;Visual Web Developer 2010. Name it as &quot;VBASPNETDisableScriptAfterExecution&quot;.<br>
<br>
Step 2. Add one web form in the root directory, name them as &quot;DisableScript.aspx&quot;.<br>
<br>
Step 3. Add a HTML button on the DisableScript page, which have an onclick event.<br>
<br>
Step 4. Register JavaScript functions at DisableScript code behind page, we<br>
&nbsp; &nbsp; &nbsp; &nbsp;need add two functions, &quot;main()&quot; and &quot;callBackFunc()&quot;. The main function
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;includes user logic, call back function is used to return error information.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The VB code as shown below:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Register JavaScript functions at code behind page(Page_Load event).
<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;remarks&gt;&lt;/remarks&gt;<br>
&nbsp; &nbsp;Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim clientManager As ClientScriptManager = Page.ClientScript<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;' JavaScript function part 1, this function is used to execute user's logical<br>
&nbsp; &nbsp; &nbsp; &nbsp;' code with a additional parameter, this parameter is a callback function
<br>
&nbsp; &nbsp; &nbsp; &nbsp;' which is make a condition that if the main function had executed.<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim mainScript As String = vbCr & vbLf & &quot; var flag = true;&quot; & vbCr & vbLf &<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot; var mainFunc = function main(callBack) {&quot; & vbCr & vbLf &<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot; var callBackPara = callBack;&quot; & vbCr & vbLf &<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot; if (flag) {&quot; & vbCr & vbLf &<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot; // User code.&quot; & vbCr & vbLf &<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot; alert('This is user code, in this sample code, your page will move down.');&quot;
 & vbCr & vbLf &<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot; &quot; & vbCr & vbLf &<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot; for (var i = 1; i &lt;= 900; i&#43;&#43;)&quot; & vbCr & vbLf &<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot; {&quot; & vbCr & vbLf &<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot; window.moveBy(0, 1);&quot; & vbCr & vbLf &<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot; }&quot; & vbCr & vbLf &<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot; window.moveBy(0,-750);&quot; & vbCr & vbLf &<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot; &quot; & vbCr & vbLf &<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot; // Disable JS function.&quot; & vbCr & vbLf &<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot; flag = undefined;&quot; & vbCr & vbLf &<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot; }&quot; & vbCr & vbLf &<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot; else {&quot; & vbCr & vbLf &<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot; alert(callBackPara);&quot; & vbCr & vbLf &<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot; }}&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp;clientManager.RegisterClientScriptBlock(Me.[GetType](), &quot;mainScript&quot;, mainScript, True)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;' JavaScript function part 2, the callback function, check if flag variable is undefined.<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim callbackScript As String = &quot; var callFunc = function callBackFunc() {&quot; & vbCr & vbLf &<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot; if (!flag) {&quot; & vbCr & vbLf &<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot; return 'The JavaScript function has been disabled..';&quot; & vbCr & vbLf &<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot; }}&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp;clientManager.RegisterStartupScript(Me.[GetType](), &quot;callBackScript&quot;, callbackScript, True)<br>
<br>
&nbsp; &nbsp;End Sub<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code] &nbsp;<br>
<br>
Step 5. Build the application and you can debug it.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: JavaScript<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms970435.aspx">http://msdn.microsoft.com/en-us/library/ms970435.aspx</a><br>
<br>
MSDN: ClientScriptManager Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.clientscriptmanager(v=vs.80).aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.clientscriptmanager(v=vs.80).aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
