# How to get remote ip address from host name in Windows Store apps
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows 8
* Windows Store app Development
## Topics
* IP Address
* code snippets
* host name
## IsPublished
* True
## ModifiedDate
* 2014-06-24 01:28:33
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to get remote IP address from host name in Windows Store apps</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This sample will demonstrate how to get
</span><span style="font-size:11pt">the </span><span style="font-size:11pt">remote IP address when you
</span><span style="font-size:11pt">have </span><span style="font-size:11pt">a host name in Windows
</span><span style="font-size:11pt">S</span><span style="font-size:11pt">tore apps.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The </span><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.networking.hostname.aspx#Y1226" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">HostName</span></a><span style="font-size:11pt">
 can be used for a local hostname or a remote hostname used to establish a network connection. We use
</span><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.networking.hostname(v=win.10).aspx?cs-save-lang=1&cs-lang=csharp" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">HostName</span></a><span style="font-size:11pt">
 to initialize a remote hostname</span><span style="font-size:11pt">,</span><span style="font-size:11pt"> then</span><span style="font-size:11pt"> we</span><span style="font-size:11pt"> try to connect to the HostName via
</span><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.networking.sockets.streamsocket.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">StreamSocket</span></a><span style="font-size:11pt">.</span><a name="_GoBack"></a></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>C&#43;&#43;</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">cplusplus</span><span class="hidden">vb</span>
<pre class="hidden">
Windows.Networking.HostName serverHost = new Windows.Networking.HostName(&quot;www.bing.com&quot;);
            var clientSocket = new Windows.Networking.Sockets.StreamSocket();
            // Try to connect to the remote host
            await clientSocket.ConnectAsync(serverHost, &quot;http&quot;);
</pre>
<pre class="hidden">
Windows::Networking::HostName^ serverHost = ref new Windows::Networking::HostName(&quot;www.bing.com&quot;);
 auto clientSocket = ref new Windows::Networking::Sockets::StreamSocket();
 
 // Try to connect to the remote host
 create_task(clientSocket-&gt;ConnectAsync(serverHost, &quot;http&quot;)).then([=](){
  
 });
</pre>
<pre class="hidden">
Dim serverHost As New Windows.Networking.HostName(&quot;www.bing.com&quot;)
Dim clientSocket = New Windows.Networking.Sockets.StreamSocket()
' Try to connect to the remote host
Await clientSocket.ConnectAsync(serverHost, &quot;http&quot;)
</pre>
<pre id="codePreview" class="csharp">
Windows.Networking.HostName serverHost = new Windows.Networking.HostName(&quot;www.bing.com&quot;);
            var clientSocket = new Windows.Networking.Sockets.StreamSocket();
            // Try to connect to the remote host
            await clientSocket.ConnectAsync(serverHost, &quot;http&quot;);
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The </span><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.networking.sockets.streamsocketinformation.remotehostname.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">HostName</span></a><span style="font-size:11pt">
 property represents the remote hostname or IP address for the remote network destination associated with a StreamSocket object. After a connection is established, the
</span><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.networking.sockets.streamsocketinformation.remoteaddress.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">RemoteAddress</span></a><span style="font-size:11pt">
 property contains the IP address and the RemotePort property contains the TCP port number of the remote endpoint for the socket connection.
</span><span style="font-size:11pt">So </span><span style="font-size:11pt">we can get the remote host's
</span><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.networking.hostname.displayname.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">DisplayName</span></a><span style="font-size:11pt"> using
 this StreamSocket which will be a</span><span style="font-size:11pt">n</span><span style="font-size:11pt"> IP address.</span><span style="">
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>C&#43;&#43;</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">cplusplus</span><span class="hidden">vb</span>
<pre class="hidden">
var ipAddress = clientSocket.Information.RemoteAddress.DisplayName;
            textBlock.Text = serverHost.DisplayName &#43; &quot; : &quot; &#43; ipAddress;
</pre>
<pre class="hidden">
auto ipAddress = clientSocket-&gt;Information-&gt;RemoteAddress-&gt;DisplayName;
  textBlock-&gt;Text = serverHost-&gt;DisplayName &#43; &quot; : &quot; &#43; ipAddress;
</pre>
<pre class="hidden">
Dim ipAddress = clientSocket.Information.RemoteAddress.DisplayName
textBlock.Text = serverHost.DisplayName &#43; &quot; : &quot; &#43; ipAddress
</pre>
<pre id="codePreview" class="csharp">
var ipAddress = clientSocket.Information.RemoteAddress.DisplayName;
            textBlock.Text = serverHost.DisplayName &#43; &quot; : &quot; &#43; ipAddress;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.networking.hostname(v=win.10).aspx?cs-save-lang=1&cs-lang=csharp" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">HostName
 class</span></a></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#0563C1; text-decoration:underline"></span><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.networking.hostname.displayname.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">HostName.DispalyName
 property</span></a></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#0563C1; text-decoration:underline"></span><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.networking.sockets.streamsocketinformation.remoteaddress.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">StreamSocketInformation.RemoteAddress</span></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh452976.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">Connecting with sockets (XAML)</span></a></span>
</p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers’ pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers’ frequently asked programming tasks, and allow
 developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
