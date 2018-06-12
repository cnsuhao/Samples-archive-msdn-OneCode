# Extended WebBrowser control supporting tabs (CSTabbedWebBrowser)
## Requires
* Visual Studio 2008
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
* 2011-07-12 09:54:51
## Description

<p style="font-family:Courier New"></p>
<h2>Windows APPLICATION: CSTabbedWebBrowser Overview </h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New">The sample demonstrates how to create a tabbed WebBrowser.<br>
<br>
The &quot;Open in new Tab&quot; context command is disabled in WebBorwser by default, you can add
<br>
a value *.exe=1 (* means the process name)to the key <br>
HKCU\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_TABBED_BROWSING.<br>
This menu will only take effect after the application is restarted.<br>
See <a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/ms537636(VS.85).aspx">
http://msdn.microsoft.com/en-us/library/ms537636(VS.85).aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms537636(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms537636(VS.85).aspx</a><br>
<br>
DWebBrowserEvents2 Interface designates an event sink interface that an application<br>
must implement to receive event notifications from the underlying ActiveX control, &nbsp;<br>
and there is a NewWindow3 Event in this interface. See<br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/aa768283(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa768283(VS.85).aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa768283(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa768283(VS.85).aspx</a><br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Step1. Build this project in Visual Studio 2008.<br>
<br>
Step2. Run CSTabbedWebBrowser.exe.<br>
<br>
Step3. Type <a target="_blank" href="http://1code.codeplex.com/">http://1code.codeplex.com/</a> in the Url, and press Enter.<br>
<br>
Step4. Right click the &quot;Downloads&quot; in the header of the page, and then click
<br>
&nbsp; &nbsp; &nbsp; &quot;Open in new tab&quot;. This application will open the link in a new tab.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; If the &quot;Open in new tab&quot; is disabled, check &quot;Enable Tab&quot; and restart the application.<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. Design a class WebBrowserEx that inherits class System.Windows.Forms.WebBrowser. This
<br>
&nbsp; class can handle NewWindow3 event.<br>
<br>
&nbsp; The interface DWebBrowserEvents2 designates an event sink interface that an application<br>
&nbsp; must implement to receive event notifications from a WebBrowser control or from the
<br>
&nbsp; Windows Internet Explorer application. The event notifications include NewWindow3 event
<br>
&nbsp; that will be used in this application.<br>
<br>
2. Design a class WebBrowserTabPage that inherits the the System.Windows.Forms.TabPage class
<br>
&nbsp; and contains a WebBrowserEx property. An instance of this class could be add to a tab
<br>
&nbsp; control directly.<br>
&nbsp; &nbsp; &nbsp; <br>
3. Create a UserControl that contains a System.Windows.Forms.TabControl instance. This
<br>
&nbsp; UserControl supplies the method to create/close the WebBrowserTabPage in the TabControl.
<br>
&nbsp; It also supplies a Property IsTabEnabled to get or set whether the &quot;Open in new Tab&quot;
<br>
&nbsp; context menu in WebBrowser is enabled.<br>
<br>
4. In the MainForm, it supplies controls to enable/disable tab, create/close the tab, and
<br>
&nbsp; make the WebBrowser GoBack, GoForward or Refresh.<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/aa768283(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa768283(VS.85).aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa768283(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa768283(VS.85).aspx</a><br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/ms537636(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms537636(VS.85).aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms537636(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms537636(VS.85).aspx</a><br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.windows.forms.webbrowser.createsink.aspx">http://msdn.microsoft.com/en-us/library/system.windows.forms.webbrowser.createsink.aspx</a><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
