# Session continuation from ASP.NET to Silverlight (CSSL4SessionCookie)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Silverlight
## Topics
* Session
* Cookie
## IsPublished
* True
## ModifiedDate
* 2011-06-27 09:29:38
## Description

<p style="font-family:Courier New">&nbsp;</p>
<h2>Sivlerlight APPLICATION: CSSL4SessionCookie Overview</h2>
<p style="font-family:Courier New"><br>
Summary: &nbsp;<br>
<br>
This sample demonstrates a simple technique to preserve ASP.NET session ID <br>
from a web page hosting a Silverlight component making a client WebRequest to <br>
another web page on the same site. &nbsp;Normally, the WebRequest will not by <br>
default preserve session id, and this can be frustrating for a Silverlight <br>
developer. &nbsp;But by appending the Session ID cookie manually to the request, <br>
passing it into the Silverlight component through a parameter on the calling <br>
web page, the session can in fact be preserved.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
To see the sample, run the code and launch CSSL4SessionCookieTestPage.aspx <br>
and VerifySessionMaintained.aspx. It demonstrates preserving ASP.NET session <br>
ID from a web page hosting a Silverlight component making a client WebRequest <br>
to another web page on the same site. &nbsp;<br>
<br>
In MainPage.xaml.cs of CSSL4SessionCookie, commenting out the following line <br>
will demonstrate the session ID being lost in the resulting web client request. &nbsp;<br>
<br>
&nbsp; &nbsp;wr.CookieContainer.Add(new Uri(&quot;<a href="http://localhost:7777" target="_blank">http://localhost:7777&quot;),</a>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;new Cookie(&quot;ASP.NET_SessionID&quot;, session));<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
CSSL4SessionCookieTestPage.aspx simply launches the Silverlight component <br>
which is built into the CSSSLSessionCookie.xap, in the ClientBin directory of <br>
the output, and passes a parameter which includes the ASP.NET Session ID, on <br>
line 83 of CSSL4SessionCookieTestPage.aspx. &nbsp;This originating web page also <br>
displays its current session ID so the user can see and compare to confirm <br>
that indeed, the session ID will match what is reported from the Silverlight <br>
request as well.<br>
<br>
When the Silverlight component launches, the code in MainPage.xaml.cs is <br>
launched, and creates a WebRequest used to load <br>
VerifySessionStateMaintained.aspx, another web page on the web site from <br>
which the original .aspx was loaded. &nbsp;The WebRequest appends a cookie for the
<br>
ASP.NET_SessionID, providing the parameter value that was originally passed <br>
via URL to the Silverlight component.<br>
<br>
Finally, the VerifySessionStateMaintained.aspx page is loaded and returned to <br>
the WebRequest. &nbsp;This page simply returns a line of text confirming the <br>
Session ID of its current session.<br>
<br>
The Silverlight component just outputs the text returned from <br>
VerifySessionStateMaintained.aspx, when it is received, so the user can <br>
compare the session ID of the original web page, alongside that of the page <br>
called from within Silverlight, to verify they are the same.<br>
<br>
<br>
References: &nbsp;<br>
<br>
For more information about Silverlight, go to <br>
<a href="http://www.silverlight.net/." target="_blank">http://www.silverlight.net/.</a> &nbsp;<br>
<br>
For more information about ASP.NET session state, go to <br>
<a href="http://msdn.microsoft.com/en-us/library/ms972429.aspx." target="_blank">http://msdn.microsoft.com/en-us/library/ms972429.aspx.</a><br>
<br>
For more information about using the WebRequest, go to <br>
<a href="http://msdn.microsoft.com/en-us/library/system.net.webrequest.aspx." target="_blank">http://msdn.microsoft.com/en-us/library/system.net.webrequest.aspx.</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
