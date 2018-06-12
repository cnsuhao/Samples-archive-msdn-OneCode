# Suppress errors in WebBrowser control (VBWebBrowserSuppressError)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows General
* Internet Explorer
## Topics
* WebBrowser
## IsPublished
* True
## ModifiedDate
* 2011-08-08 02:56:11
## Description

<p style="font-family:Courier New">&nbsp;</p>
<h2>Windows APPLICATION: VBWebBrowserSuppressError Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Summary:</h3>
<p style="font-family:Courier New">The sample demonstrates how to make WebBrowser suppress errors. The errors include<br>
<br>
1. Calling Script Just In Time Debugger.<br>
<br>
&nbsp; function CallDebugger() {<br>
&nbsp; &nbsp; &nbsp; debugger;<br>
&nbsp; }<br>
<br>
&nbsp; This could be disabled by the value of DisableJITDebugger in the key <br>
&nbsp; HKCU\Software\Microsoft\Internet Explorer\Main.<br>
<br>
&nbsp; Notice that to disable JIT debugger, the application has to be restarted. <br>
<br>
2. Html element errors.<br>
<br>
&nbsp; function CreateScriptError() {<br>
&nbsp; &nbsp; &nbsp; throw (&quot;Here is an error! &quot;);<br>
&nbsp; }<br>
<br>
&nbsp; You can register the Document.Window.Error event and handle it.<br>
&nbsp; <br>
&nbsp; Notice that Document.Window.Error event will only take effect when JITDebugger<br>
&nbsp; is disabled.<br>
<br>
3. Navigation error. Like the page does not exist(Http 404 error).<br>
<br>
&nbsp; DWebBrowserEvents2 Interface designates an event sink interface that an application<br>
&nbsp; must implement to receive event notifications from the underlying ActiveX control, &nbsp;<br>
&nbsp; and there is a NavigateError Event in this interface. See<br>
&nbsp; <a href="&lt;a target=" target="_blank">http://msdn.microsoft.com/en-us/library/aa768283(VS.85).aspx</a>'&gt;<a href="http://msdn.microsoft.com/en-us/library/aa768283(VS.85).aspx" target="_blank">http://msdn.microsoft.com/en-us/library/aa768283(VS.85).aspx</a><br>
&nbsp; &nbsp;<br>
4. Other errors, like permission is needed when clipboard is used in Javascript. <br>
<br>
&nbsp; If you want to suppress all errors, you can set ScriptErrorsSuppressed to true. When
<br>
&nbsp; ScriptErrorsSuppressed is set to true, the WebBrowser control hides all its dialog<br>
&nbsp; boxes that originate from the underlying ActiveX control, not just script errors.
<br>
&nbsp; Occasionally you might need to suppress script errors while displaying dialog boxes
<br>
&nbsp; such as those used for browser security settings and user login. In this case, set
<br>
&nbsp; ScriptErrorsSuppressed to false and suppress script errors in a handler for the
<br>
&nbsp; HtmlWindow.Error event.</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Disable JIT Debugger<br>
<br>
Step1. Run VBWebBrowserSuppressError.exe.<br>
<br>
Step2. Uncheck &quot;Suppress JIT Debugger&quot;, and restart this application. <br>
&nbsp; &nbsp; &nbsp; You can skip this step if the checkbox is already unchecked.<br>
<br>
Step3. Make the top textbox empty, and click the button &quot;Go&quot;. This operation will let<br>
&nbsp; &nbsp; &nbsp; WebBrowser navigate to a build-in html with errors.<br>
<br>
Step4. Click &quot;Launch Debugger&quot; in the page, you will see a dialog to launch JIT debugger
<br>
&nbsp; &nbsp; &nbsp; if VS is installed.<br>
<br>
Step5. Check &quot;Suppress JIT Debugger&quot;, and restart this application.<br>
<br>
Step6. Make the top textbox empty, and click the button &quot;Go&quot;.<br>
<br>
Step7. Click &quot;Launch Debugger&quot; in the page, you will not see the &nbsp;dialog to launch JIT
<br>
&nbsp; &nbsp; &nbsp; debugger.<br>
<br>
<br>
Suppress html element errors<br>
<br>
Step1. Run VBWebBrowserSuppressError.exe.<br>
<br>
Step2. Check &quot;Suppress JIT Debugger&quot;, and restart this application.<br>
&nbsp; &nbsp; &nbsp; You can skip this step if the checkbox is already checked.<br>
<br>
Step3. Make the top textbox empty, and click the button &quot;Go&quot;. This operation will let<br>
&nbsp; &nbsp; &nbsp; WebBrowser navigate to a build-in html with errors.<br>
<br>
Step4. Uncheck &quot;Suppress Html Element Errors&quot;. <br>
<br>
Step5. Click &quot;Script Error&quot; in the page, you will see a WebPage error dialog.<br>
<br>
Step6. Check &quot;Suppress Html Element Errors&quot;. <br>
<br>
Step7. Click &quot;Script Error&quot; in the page, you will not see the WebPage error dialog.<br>
&nbsp;&nbsp;&nbsp;&nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp; <br>
<br>
Handle navigation error<br>
<br>
Step1. Run VBWebBrowserSuppressError.exe.<br>
<br>
Step2. Uncheck &quot;Suppress Navigation Error&quot;. <br>
<br>
Step3. Type <a href="&lt;a target=" target="_blank">http://www.microsoft.com/NotExist.html</a>'&gt;<a href="http://www.microsoft.com/NotExist.html" target="_blank">http://www.microsoft.com/NotExist.html</a> the top textbox, and click the button &quot;Go&quot;.<br>
&nbsp; &nbsp; &nbsp; Microsoft.com will tell you that the page is not found.<br>
<br>
Step4. Check &quot;Suppress Navigation Error&quot;. <br>
<br>
Step5. Type <a href="&lt;a target=" target="_blank">http://www.microsoft.com/NotExist.html</a>'&gt;<a href="http://www.microsoft.com/NotExist.html" target="_blank">http://www.microsoft.com/NotExist.html</a> the top textbox, and click the button &quot;Go&quot;.<br>
&nbsp; &nbsp; &nbsp; You will see the build-in HTTP404 html.<br>
<br>
<br>
<br>
Suppress all dialogs&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;<br>
<br>
Step1. Run VBWebBrowserSuppressError.exe.<br>
<br>
Step2. Make the top textbox empty, and click the button &quot;Go&quot;. This operation will let<br>
&nbsp; &nbsp; &nbsp; WebBrowser navigate to a build-in html with errors.<br>
<br>
Step3. Uncheck &quot;Suppress all dialog&quot;. <br>
<br>
Step4. Click &quot;Security Dialog&quot; in the page, you will see a &quot;Windows Security Warning&quot; dialog.<br>
<br>
Step5. Make the top textbox empty, and click the button &quot;Go&quot; again. Or refresh this page in the
<br>
&nbsp; &nbsp; &nbsp; Context menu.<br>
<br>
Step6. Check &quot;Suppress all dialog&quot;. <br>
<br>
Step7. Click &quot;Security Dialog&quot; in the page, you will not see the &quot;Windows Security Warning&quot;<br>
&nbsp; &nbsp; &nbsp; dialog.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. Create html file Error.htm. This web page can create script error, security warning and<br>
launch JIT debugger.<br>
<br>
2. Design a class WebBrowserEx that inherits class System.Windows.Forms.WebBrowser. This
<br>
&nbsp; class supplies following features.<br>
&nbsp; <br>
&nbsp; 2.1. Disable JIT Debugger.<br>
&nbsp; &nbsp; &nbsp; &nbsp;The static property &nbsp;DisableJITDebugger can get or set the value of &quot;Disable Script<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;Debugger&quot; in the key HKCU\Software\Microsoft\Internet Explorer\Main.<br>
<br>
&nbsp; 2.2. Suppress html element errors of document loaded in this browser.<br>
&nbsp; &nbsp; &nbsp; &nbsp;Handle &nbsp;the window error event of document loaded in this browser.<br>
<br>
&nbsp; 2.3. Handle navigation error.<br>
&nbsp; &nbsp; &nbsp; &nbsp;The interface DWebBrowserEvents2 designates an event sink interface that an application<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;must implement to receive event notifications from a WebBrowser control or from the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Windows Internet Explorer application. The event notifications include NavigateError
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;event that will be used in this application.<br>
<br>
&nbsp; 2.4 The class WebBrowser itself also has a Property ScriptErrorsSuppressed to hides all its
<br>
&nbsp; &nbsp; &nbsp; dialog boxes that originate from the underlying ActiveX control, not just script errors.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
3. In the MainForm, handle the checkboxes CheckedChanged event to disable JIT debugger, suppress html
<br>
&nbsp; element errors and suppress all dialog. <br>
&nbsp; <br>
&nbsp; It also registers the NavigateError event of WebBrowserEx. If &quot;Suppress Navigation Error&quot; is<br>
&nbsp; checked and the http status code is 404, then navigate to the build-in 404.htm.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><a href="&lt;a target=" target="_blank">http://msdn.microsoft.com/en-us/library/aa768283(VS.85).aspx</a>'&gt;<a href="http://msdn.microsoft.com/en-us/library/aa768283(VS.85).aspx" target="_blank">http://msdn.microsoft.com/en-us/library/aa768283(VS.85).aspx</a><br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.forms.webbrowser.scripterrorssuppressed.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/system.windows.forms.webbrowser.scripterrorssuppressed.aspx</a><br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.forms.webbrowser.createsink.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/system.windows.forms.webbrowser.createsink.aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
