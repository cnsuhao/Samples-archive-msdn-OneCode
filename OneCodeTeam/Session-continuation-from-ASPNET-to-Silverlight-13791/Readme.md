# Session continuation from ASP.NET to Silverlight (VBSL4SessionCookie)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Silverlight
## Topics
* Session
* Cookie
## IsPublished
* True
## ModifiedDate
* 2011-10-27 10:25:35
## Description

<h2>Sivlerlight APPLICATION: VBSL4SessionCookie Overview</h2>
<div style="font-family:Courier New"><span style="font-size:medium"><strong>Summary:</strong></span></div>
<div style="font-family:Courier New">This sample demonstrates a simple technique to preserve ASP.NET session ID from a web page hosting a Silverlight component making a client WebRequest to another web page on the same site.&nbsp; Normally, the WebRequest will
 not by default preserve session id, and this can be frustrating for a Silverlight developer.&nbsp; But by appending the Session ID cookie manually to the request, passing it into the Silverlight component through a parameter on the calling web page, the session
 can in fact be preserved.</div>
<h3>Demo:</h3>
<div style="font-family:Courier New">To see the sample, run the code and launch VBSL4SessionCookieTestPage.aspx and VerifySessionMaintained.aspx. It demonstrates preserving ASP.NET session ID from a web page hosting a Silverlight component making a client WebRequest
 to another web page on the same site.</div>
<div style="font-family:Courier New">In MainPage.xaml.vb of VBSL4SessionCookie, commenting out the following line will demonstrate the session ID being lost in the resulting web client request.<br>
[Note]<br>
&nbsp;&nbsp;&nbsp; This sample can only preserve Asp.net session ID when cookie is enabled, So please persist cookieLess property value is false.<br>
[/Note]</div>
<div style="font-family:Courier New"></div>
<div style="font-family:Courier New">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">wr.CookieContainer.Add(New Uri(&quot;http://localhost:7777&quot;), New Cookie(&quot;ASP.NET_SessionID&quot;, session))</pre>
<div class="preview">
<pre class="vb">wr.CookieContainer.Add(<span class="visualBasic__keyword">New</span>&nbsp;Uri(<span class="visualBasic__string">&quot;http://localhost:7777&quot;</span>),&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Cookie(<span class="visualBasic__string">&quot;ASP.NET_SessionID&quot;</span>,&nbsp;session))</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<h3>Implementation:</h3>
<div style="font-family:Courier New">
<div>VBSL4SessionCookieTestPage.aspx simply launches the Silverlight component which is built into the VBSL4SessionCookie.xap, in the ClientBin directory of the output, and passes a parameter which includes the ASP.NET Session ID, on line 83 of VBSL4SessionCookieTestPage.aspx.&nbsp;
 This originating web page also displays its current session ID so the user can see and compare to confirm that indeed, the session ID will match what is reported from the Silverlight request as well.</div>
<div></div>
<div>When the Silverlight component start, the code in MainPage.xaml.vb is invoked, and creates a WebRequest used to load VerifySessionStateMaintained.aspx, another web page on the web site from<br>
which the original .aspx was loaded.&nbsp; The WebRequest appends a cookie for the ASP.NET_SessionID, providing the parameter value that was originally passed via URL to the Silverlight component.</div>
<div>Finally, the VerifySessionStateMaintained.aspx page is loaded and returned to the WebRequest.&nbsp; This page simply returns a line of text confirming the Session ID of its current session.</div>
<div></div>
<div>The Silverlight component just outputs the text returned from VerifySessionStateMaintained.aspx, when it is received, so the user can compare the session ID of the original web page, alongside that of the page called from within Silverlight, to verify
 they are the same.</div>
<div></div>
<div>Following steps below for creating this sample:</div>
<div>Step 1. Create a C# &quot;Silverlight Application&quot; in Visual Studio 2010 or<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Visual Web Developer 2010. Name it as &quot;CSSL4SessionCookie&quot;.<br>
&nbsp; Please also create a Web application.</div>
<div>Step 2. Create a VerifyManintained page in &quot;CSSL4SessionCookie.Web&quot; application,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; and output session ID on the page.</div>
<div>Step 3. Add a TextBlock control on MainPage.xaml, we need create HttpWebRequest<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; instance for getting session ID from web request.<br>
&nbsp; The code as shown below:</div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Partial Public Class MainPage 
    Inherits UserControl 
    Private wr As HttpWebRequest 
    Private output As String 
  
    Public Sub New() 
        InitializeComponent() 
        Dim url As String = Application.Current.Host.Source.OriginalString 
  
        ' In this case, we simply pass one parameter into Silverlight with  
        ' no other text, so we retrieve the whole query string after the '?'  
        ' to obtain the session ID passed in. 
        Dim session As String = url.Substring(url.IndexOf(&quot;?&quot;) &#43; 1) 
  
        ' This sample just calls a simple .aspx page that returns only a  
        ' message with the session ID. In order to avoid webpage caching,  
        ' a time ticks string is appended to the URL query string. 
        ' The same technique can be used for any web service call, though. 
        wr = WebRequest.CreateHttp(&quot;http://localhost:64024/VerifySessionMaintained.aspx&quot; &amp; &quot;?&quot; &amp; DateTime.Now.Ticks) 
  
        ' Set up a cookie container we will use to store the session cookie. 
        wr.CookieContainer = New CookieContainer() 
  
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 
        ' Commenting out the following line will demonstrate the session ID '' 
        '   being lost in the resulting web client request.                 '' 
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 
        wr.CookieContainer.Add(New Uri(&quot;http://localhost:64024&quot;), New Cookie(&quot;ASP.NET_SessionID&quot;, session)) 
  
 
        wr.BeginGetResponse(New AsyncCallback(AddressOf Callback), Nothing) 
    End Sub 
  
    Public Sub Callback(ByVal res As IAsyncResult) 
        ' Retrieve the response from the server. 
        Dim wres As WebResponse = wr.EndGetResponse(res) 
        Dim buffer As Byte() = New Byte(wres.ContentLength - 1) {} 
        wres.GetResponseStream().Read(buffer, 0, buffer.Length) 
        output = UTF8Encoding.UTF8.GetString(buffer, 0, buffer.Length) 
  
        ' Dispatch a call to the UI thread to update the textbox content with our response. 
        Dispatcher.BeginInvoke(New Action(AddressOf UpdateTextbox)) 
    End Sub 
  
    Private Sub UpdateTextbox() 
        SampleTextBlock.Text = output 
    End Sub 
End Class</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Partial</span>&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;MainPage&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Inherits</span>&nbsp;UserControl&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;wr&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;HttpWebRequest&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;output&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;<span class="visualBasic__keyword">New</span>()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;url&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;Application.Current.Host.Source.OriginalString&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;In&nbsp;this&nbsp;case,&nbsp;we&nbsp;simply&nbsp;pass&nbsp;one&nbsp;parameter&nbsp;into&nbsp;Silverlight&nbsp;with&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;no&nbsp;other&nbsp;text,&nbsp;so&nbsp;we&nbsp;retrieve&nbsp;the&nbsp;whole&nbsp;query&nbsp;string&nbsp;after&nbsp;the&nbsp;'?'&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;to&nbsp;obtain&nbsp;the&nbsp;session&nbsp;ID&nbsp;passed&nbsp;in.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;session&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;url.Substring(url.IndexOf(<span class="visualBasic__string">&quot;?&quot;</span>)&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;This&nbsp;sample&nbsp;just&nbsp;calls&nbsp;a&nbsp;simple&nbsp;.aspx&nbsp;page&nbsp;that&nbsp;returns&nbsp;only&nbsp;a&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;message&nbsp;with&nbsp;the&nbsp;session&nbsp;ID.&nbsp;In&nbsp;order&nbsp;to&nbsp;avoid&nbsp;webpage&nbsp;caching,&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;a&nbsp;time&nbsp;ticks&nbsp;string&nbsp;is&nbsp;appended&nbsp;to&nbsp;the&nbsp;URL&nbsp;query&nbsp;string.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;The&nbsp;same&nbsp;technique&nbsp;can&nbsp;be&nbsp;used&nbsp;for&nbsp;any&nbsp;web&nbsp;service&nbsp;call,&nbsp;though.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wr&nbsp;=&nbsp;WebRequest.CreateHttp(<span class="visualBasic__string">&quot;http://localhost:64024/VerifySessionMaintained.aspx&quot;</span>&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;?&quot;</span>&nbsp;&amp;&nbsp;DateTime.Now.Ticks)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Set&nbsp;up&nbsp;a&nbsp;cookie&nbsp;container&nbsp;we&nbsp;will&nbsp;use&nbsp;to&nbsp;store&nbsp;the&nbsp;session&nbsp;cookie.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wr.CookieContainer&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;CookieContainer()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Commenting&nbsp;out&nbsp;the&nbsp;following&nbsp;line&nbsp;will&nbsp;demonstrate&nbsp;the&nbsp;session&nbsp;ID&nbsp;''&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;&nbsp;&nbsp;being&nbsp;lost&nbsp;in&nbsp;the&nbsp;resulting&nbsp;web&nbsp;client&nbsp;request.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;''&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wr.CookieContainer.Add(<span class="visualBasic__keyword">New</span>&nbsp;Uri(<span class="visualBasic__string">&quot;http://localhost:64024&quot;</span>),&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Cookie(<span class="visualBasic__string">&quot;ASP.NET_SessionID&quot;</span>,&nbsp;session))&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wr.BeginGetResponse(<span class="visualBasic__keyword">New</span>&nbsp;AsyncCallback(<span class="visualBasic__keyword">AddressOf</span>&nbsp;Callback),&nbsp;<span class="visualBasic__keyword">Nothing</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Callback(<span class="visualBasic__keyword">ByVal</span>&nbsp;res&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IAsyncResult)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Retrieve&nbsp;the&nbsp;response&nbsp;from&nbsp;the&nbsp;server.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;wres&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;WebResponse&nbsp;=&nbsp;wr.EndGetResponse(res)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;buffer&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Byte</span>()&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">Byte</span>(wres.ContentLength&nbsp;-&nbsp;<span class="visualBasic__number">1</span>)&nbsp;{}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wres.GetResponseStream().Read(buffer,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;buffer.Length)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;output&nbsp;=&nbsp;UTF8Encoding.UTF8.GetString(buffer,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;buffer.Length)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Dispatch&nbsp;a&nbsp;call&nbsp;to&nbsp;the&nbsp;UI&nbsp;thread&nbsp;to&nbsp;update&nbsp;the&nbsp;textbox&nbsp;content&nbsp;with&nbsp;our&nbsp;response.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dispatcher.BeginInvoke(<span class="visualBasic__keyword">New</span>&nbsp;Action(<span class="visualBasic__keyword">AddressOf</span>&nbsp;UpdateTextbox))&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;UpdateTextbox()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SampleTextBlock.Text&nbsp;=&nbsp;output&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<br>
<span style="font-size:small"><strong>References:&nbsp; </strong></span></div>
<div>
<div class="endscriptcode"><br>
For more information about Silverlight, go to <br>
<a href="http://www.silverlight.net/." target="_blank">http://www.silverlight.net/.</a>
<br>
<br>
For more information about ASP.NET session state, go to <br>
<a href="http://msdn.microsoft.com/en-us/library/ms972429.aspx." target="_blank">http://msdn.microsoft.com/en-us/library/ms972429.aspx.</a><br>
<br>
For more information about using the WebRequest, go to <br>
<a href="http://msdn.microsoft.com/en-us/library/system.net.webrequest.aspx." target="_blank">http://msdn.microsoft.com/en-us/library/system.net.webrequest.aspx.</a><br>
<br>
<br>
</div>
</div>
</div>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
