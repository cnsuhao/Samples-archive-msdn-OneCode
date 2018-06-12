# Strip html code using regex
## Requires
* Visual Studio 2012
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* HTML
## IsPublished
* True
## ModifiedDate
* 2013-01-13 06:59:07
## Description

<h1>Strip/parse HTML code (VBASPNETStripHtmlCode)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The project illustrates how to strip and parse Html code. As the web pages are always include much useful information such as title, text, images, links, tables, etc. Sometimes we need to strip the key words or resources from a web page,
 so this code-sample can help us finish the work in regular expression.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Step 1: Open the VBASPNETStripHtmlCode.sln.<br>
Step 2: Expand the VBASPNETStripHtmlCode web application and press Ctrl &#43; F5 to show the Default.aspx.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/74560/1/image.png" alt="" width="672" height="506" align="middle">
</span><br>
Step 3: You will see one MultiLine TextBox and some Button controls on the page. Click these Buttons in turn.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/74561/1/image.png" alt="" width="683" height="499" align="middle">
</span><br>
Step 4: The striped information will&nbsp;be displayed in the TextBox, you can find the entire html code, script code, pure text, images and links.<br>
Step 5: Validation is finished.</p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step 1. Create a VB &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2012 or Visual Web Developer 2012. Name it as &quot;VBASPNETStripHtmlCode&quot;.<br>
Step 2. Add two web forms in the root directory, name them as &quot;Default.aspx&quot;, &quot;SourcePage.aspx&quot;.<br>
Step 3. Add script code, some links, some images and text on the Source page. We will strip the useful message from it.<br>
Step 4. Add one MultiLine TextBox control and five Button controls on Default page, this web form is used to retrieve the message of Source page.<br>
Step 5. Add some VB code as follows, retrieve entire Html code: </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' Retrieve the entire html code from SourcePage.aspx with WebRequest and
&nbsp;&nbsp;&nbsp; ''' WebRespond. We transfer the format of html code to uft-8.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;url&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;returns&gt;&lt;/returns&gt;
&nbsp;&nbsp;&nbsp; Public Function GetWholeHtmlCode(ByVal url As String) As String
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim strHtml As String = String.Empty
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim strReader As StreamReader = Nothing
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim wrpContent As HttpWebResponse = Nothing
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim wrqContent As HttpWebRequest = DirectCast(WebRequest.Create(strUrl), HttpWebRequest)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; wrqContent.Timeout = 300000
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; wrpContent = DirectCast(wrqContent.GetResponse(), HttpWebResponse)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If wrpContent.StatusCode &lt;&gt; HttpStatusCode.OK Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; flgPageRetrieved = False
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strHtml = MsgPageRetrieveFailed
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If wrpContent IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strReader = New StreamReader(wrpContent.GetResponseStream(), Encoding.GetEncoding(&quot;utf-8&quot;))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strHtml = strReader.ReadToEnd()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch e As Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; flgPageRetrieved = False
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strHtml = e.Message
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Finally
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If strReader IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strReader.Close()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If wrpContent IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; wrpContent.Close()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return strHtml
&nbsp;&nbsp;&nbsp; End Function

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' Retrieve the entire html code from SourcePage.aspx with WebRequest and
&nbsp;&nbsp;&nbsp; ''' WebRespond. We transfer the format of html code to uft-8.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;url&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;returns&gt;&lt;/returns&gt;
&nbsp;&nbsp;&nbsp; Public Function GetWholeHtmlCode(ByVal url As String) As String
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim strHtml As String = String.Empty
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim strReader As StreamReader = Nothing
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim wrpContent As HttpWebResponse = Nothing
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim wrqContent As HttpWebRequest = DirectCast(WebRequest.Create(strUrl), HttpWebRequest)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; wrqContent.Timeout = 300000
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; wrpContent = DirectCast(wrqContent.GetResponse(), HttpWebResponse)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If wrpContent.StatusCode &lt;&gt; HttpStatusCode.OK Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; flgPageRetrieved = False
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strHtml = MsgPageRetrieveFailed
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If wrpContent IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strReader = New StreamReader(wrpContent.GetResponseStream(), Encoding.GetEncoding(&quot;utf-8&quot;))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strHtml = strReader.ReadToEnd()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch e As Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; flgPageRetrieved = False
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strHtml = e.Message
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Finally
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If strReader IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strReader.Close()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If wrpContent IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; wrpContent.Close()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return strHtml
&nbsp;&nbsp;&nbsp; End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">We can use regular expression to strip and parse the specified part of entire Html code, for example, we can strip pure text from it, the VB code like this:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim strRegexScript As String = &quot;(?m)&lt;body[^&gt;]*&gt;(\w|\W)*?&lt;/body[^&gt;]*&gt;&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim strRegex As String = &quot;&lt;[^&gt;]*&gt;&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim strMatchScript As String = String.Empty
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim matchText As Match = Regex.Match(strWholeHtml, strRegexScript, RegexOptions.IgnoreCase)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strMatchScript = matchText.Groups(0).Value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim strPureText As String = Regex.Replace(strMatchScript, strRegex, String.Empty, RegexOptions.IgnoreCase)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;tbResult.Text = strPureText

</pre>
<pre id="codePreview" class="vb">
Dim strRegexScript As String = &quot;(?m)&lt;body[^&gt;]*&gt;(\w|\W)*?&lt;/body[^&gt;]*&gt;&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim strRegex As String = &quot;&lt;[^&gt;]*&gt;&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim strMatchScript As String = String.Empty
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim matchText As Match = Regex.Match(strWholeHtml, strRegexScript, RegexOptions.IgnoreCase)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strMatchScript = matchText.Groups(0).Value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim strPureText As String = Regex.Replace(strMatchScript, strRegex, String.Empty, RegexOptions.IgnoreCase)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;tbResult.Text = strPureText

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step 5. Add other Button control's click event with VB code like the &quot;Default.aspx.vb&quot; file.<br>
Step 6. Build the application and you can debug it.</p>
<h2>More Information</h2>
<p class="MsoNormal">MSDN: .NET Framework Regular Expressions<br>
<a href="http://msdn.microsoft.com/en-us/library/hs600312.aspx">http://msdn.microsoft.com/en-us/library/hs600312.aspx</a><br>
MSDN: Regex Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.aspx">http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.aspx</a><br>
MSDN: WebRequest Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.net.webrequest.aspx">http://msdn.microsoft.com/en-us/library/system.net.webrequest.aspx</a><br>
MSDN: WebResponse Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.net.webresponse.aspx">http://msdn.microsoft.com/en-us/library/system.net.webresponse.aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
