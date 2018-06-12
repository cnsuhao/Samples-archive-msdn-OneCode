# Set proxy in the WebBrowser control (VBWebBrowserWithProxy)
## Requires
* Visual Studio 2010
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
* 2011-07-12 10:37:37
## Description

<p style="font-family:Courier New"></p>
<h2>Windows APPLICATION: VBWebBrowserWithProxy Overview </h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The sample demonstrates how to make WebBrowser use a proxy server.<br>
<br>
The WebBrowser control is a managed wrapper for the ActiveX WebBrowser control, <br>
and uses whichever version of the control is installed on the user's computer. This<br>
means that WebBrowser is just an IE instance, so that it uses the proxy settings of
<br>
IE. <br>
<br>
In Internet Explorer 5 and later, Internet options can be set for on a specific <br>
connection and process, for example, LAN connection or ADSL connection. Wininet.dll
<br>
contains 4 extern methods (InternetOpen, InternetCloseHandle, InternetSetOption <br>
and InternetQueryOption) to set and retrieve internet settings.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Step1. Build this project in VS2010. <br>
<br>
Step2. Set the proxy servers in ProxyList.xml.<br>
&nbsp; &nbsp; &nbsp; The schema is like &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &lt;ProxyList&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Proxy&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ProxyName&gt;Proxy Name&lt;/ProxyName&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Address&gt;Proxy url&lt;/Address&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;UserName&gt;&lt;/UserName&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Password&gt;&lt;/Password&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Proxy&gt;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ProxyList&gt; <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If the proxy server needs credential, UserName and Password should be specified.<br>
<br>
Step3. Run VBWebBrowserWithProxy.exe.<br>
<br>
Step4. Type <a target="_blank" href="http://www.whatsmyip.us/">http://www.whatsmyip.us/</a> in the top text box, or any web page that could display<br>
&nbsp; &nbsp; &nbsp; your IP.<br>
<br>
Step5. Check &quot;No Proxy&quot; and click Go. The browser shows your real IP.<br>
<br>
Step6. Check &quot;Proxy Server&quot;, choose a Proxy Server in the combo box and click Go. The browser
<br>
&nbsp; &nbsp; &nbsp; shows your IP through the Proxy.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. Wrap 4 extern methods (InternetOpen, InternetCloseHandle, <br>
&nbsp; InternetSetOption and InternetQueryOption) of wininet.dll, design the <br>
&nbsp; structure and initialize the constants used by them.<br>
<br>
2. Use class WinINet to set proxy, or restore to system internet options.<br>
&nbsp; &nbsp; &nbsp; <br>
3. The class WebBrowserControl inherits WebBrowser class and has a feature to <br>
&nbsp; set proxy server. &nbsp;If the Proxy property is changed, it will call methods
<br>
&nbsp; of the WinINet class to set the new proxy.<br>
<br>
4. Initializes the proxy servers in ProxyList.xml when this application <br>
&nbsp; starts. <br>
<br>
5. Set the proxy of the web browser when the &quot;Go&quot; button was clicked and
<br>
&nbsp; navigate to the URL.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
InternetOpen Function<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa385096(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa385096(VS.85).aspx</a><br>
<br>
InternetCloseHandle Function<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa384350(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa384350(VS.85).aspx</a><br>
<br>
InternetSetOption Function<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa385114(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa385114(VS.85).aspx</a><br>
<br>
InternetQueryOption Function<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa385101(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa385101(VS.85).aspx</a><br>
<br>
Setting and Retrieving Internet Options<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa385384(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa385384(VS.85).aspx</a><br>
<br>
How To: Set the proxy for the WebBrowser control in .NET<br>
<a target="_blank" href="http://blogs.msdn.com/b/jpsanders/archive/2011/04/26/how-to-set-the-proxy-for-the-webbrowser-control-in-net.aspx">http://blogs.msdn.com/b/jpsanders/archive/2011/04/26/how-to-set-the-proxy-for-the-webbrowser-control-in-net.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
