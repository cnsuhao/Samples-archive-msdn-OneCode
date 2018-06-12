# Extended WebBrowser control supporting tabs (VBTabbedWebBrowser)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Windows General
* Internet Explorer
## Topics
* WebBrowser
* Tab
## IsPublished
* True
## ModifiedDate
* 2011-07-12 10:35:44
## Description

<p style="font-family:Courier New"></p>
<h2>Windows APPLICATION: VBTabbedWebBrowser Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The sample demonstrates how to create a tabbed WebBrowser.<br>
<br>
The &quot;Open in new Tab&quot; context command is disabled in WebBorwser by default,
<br>
you can add a value *.exe=1 (* means the process name)to the key <br>
HKCU\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_TABBED_BROWSING.<br>
This menu will only take effect after the application is restarted.<br>
See <a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/ms537636(VS.85).aspx">
http://msdn.microsoft.com/en-us/library/ms537636(VS.85).aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms537636(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms537636(VS.85).aspx</a><br>
<br>
DWebBrowserEvents2 Interface designates an event sink interface that an <br>
application must implement to receive event notifications from the underlying <br>
ActiveX control, and there is a NewWindow3 Event in this interface. See<br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/aa768283(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa768283(VS.85).aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa768283(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa768283(VS.85).aspx</a><br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Step1. Build this project in VS2010. <br>
<br>
Step2. Run VBTabbedWebBrowser.exe.<br>
<br>
Step3. Type <a target="_blank" href="http://1code.codeplex.com/">http://1code.codeplex.com/</a> in the Url, and press Enter.<br>
<br>
Step4. Right click the &quot;Downloads&quot; in the header of the page, and then click
<br>
&nbsp; &nbsp; &nbsp; &quot;Open in new tab&quot;. This application will open the link in a new tab.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; If the &quot;Open in new tab&quot; is disabled, check &quot;Enable Tab&quot; and restart
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; the application.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. Design a class WebBrowserEx that inherits class <br>
&nbsp; System.Windows.Forms.WebBrowser. This class can handle NewWindow3 event.<br>
<br>
&nbsp; The interface DWebBrowserEvents2 designates an event sink interface that <br>
&nbsp; an application must implement to receive event notifications from a <br>
&nbsp; WebBrowser control or from the Windows Internet Explorer application. The <br>
&nbsp; event notifications include NewWindow3 event that will be used in this <br>
&nbsp; application.<br>
<br>
2. Design a class WebBrowserTabPage that inherits the the <br>
&nbsp; System.Windows.Forms.TabPage class and contains a WebBrowserEx property. <br>
&nbsp; An instance of this class could be add to a tab control directly.<br>
&nbsp; &nbsp; &nbsp; <br>
3. Create a UserControl that contains a System.Windows.Forms.TabControl <br>
&nbsp; instance. This UserControl supplies the method to create/close the <br>
&nbsp; WebBrowserTabPage in the TabControl. It also supplies a Property <br>
&nbsp; IsTabEnabled to get or set whether the &quot;Open in new Tab&quot; context menu in
<br>
&nbsp; WebBrowser is enabled.<br>
<br>
4. In the MainForm, it supplies controls to enable/disable tab, create/close <br>
&nbsp; the tab, and make the WebBrowser GoBack, GoForward or Refresh.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/aa768283(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa768283(VS.85).aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa768283(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa768283(VS.85).aspx</a><br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/ms537636(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms537636(VS.85).aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms537636(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms537636(VS.85).aspx</a><br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.windows.forms.webbrowser.createsink.aspx">http://msdn.microsoft.com/en-us/library/system.windows.forms.webbrowser.createsink.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
