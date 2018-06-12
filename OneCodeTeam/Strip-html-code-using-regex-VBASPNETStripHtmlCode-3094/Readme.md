# Strip html code using regex (VBASPNETStripHtmlCode)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* HTML
* Regular Expression
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:47:26
## Description

<p style="font-family:Courier New"></p>
<h2>VBASPNETStripHtmlCode Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The project illustrates how to strip and parse Html code.<br>
As the web pages are always include much useful information such as title, <br>
text, images, links, tables, etc. Sometimes we need strip the key words or <br>
resources from a web page, so this code-sample can help us finish the work<br>
in regular expression.<br>
<br>
Demo the Sample. <br>
<br>
Please follow these demonstration steps below.<br>
<br>
Step 1: Open the VBASPNETStripHtmlCode.sln.<br>
<br>
Step 2: Expand the VBASPNETStripHtmlCode web application and press <br>
&nbsp; &nbsp; &nbsp; &nbsp;Ctrl &#43; F5 to show the Default.aspx.<br>
<br>
Step 3: You will see one MultiLine TextBox and some Button controls on the page.<br>
&nbsp; &nbsp; &nbsp; &nbsp;Click these Buttons in turn.<br>
<br>
Step 4: The striped information displaying in the TextBox, you can find the <br>
&nbsp; &nbsp; &nbsp; &nbsp;entire html code, script code, pure text, images and links.<br>
<br>
Step 5: Validation finished.<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step 1. Create a VB &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp;Visual Web Developer 2010. Name it as &quot;VBASPNETStripHtmlCode&quot;.<br>
<br>
Step 2. Add two web forms in the root directory, name them as &quot;Default.aspx&quot;,
<br>
&nbsp; &nbsp; &nbsp; &nbsp;&quot;SourcePage.aspx&quot;.<br>
<br>
Step 3. Add script code, some links, some images and text on the Source<br>
&nbsp; &nbsp; &nbsp; &nbsp;page. We will strip the useful message from it.<br>
<br>
Step 4. Add one MultiLine TextBox control and five Button controls on Default<br>
&nbsp; &nbsp; &nbsp; &nbsp;page, this web form used to retrieve the message of Source page<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
Step 5 &nbsp;Add some VB code like this below, retrieve entire Html code: <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' Retrieve the entire html code from SourcePage.aspx with WebRequest and<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' WebRespond. We're transfer the format of html code to uft-8.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;url&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;returns&gt;&lt;/returns&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Public Function GetWholeHtmlCode(ByVal url As String) As String<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim strHtml As String = String.Empty<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim strReader As StreamReader = Nothing<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim wrpContent As WebResponse = Nothing<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim wrqContent As WebRequest = WebRequest.Create(url)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;wrqContent.Timeout = 300000<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;wrpContent = wrqContent.GetResponse()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If wrpContent IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strReader = New StreamReader(wrpContent.GetResponseStream(),<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;Encoding.GetEncoding(&quot;utf-8&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strHtml = strReader.ReadToEnd()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Catch e As Exception<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strHtml = e.Message<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Finally<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If strReader IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strReader.Close()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If wrpContent IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;wrpContent.Close()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return strHtml<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Function<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[/code]<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;Use regular expression to strip and parse specifically part of entire Html<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;code, for example, strip pure text button, the VB code like this:<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;Dim strRegexScript As String = &quot;(?m)&lt;body[^&gt;]*&gt;(\w|\W)*?&lt;/body[^&gt;]*&gt;&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim strRegex As String = &quot;&lt;[^&gt;]*&gt;&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim strMatchScript As String = String.Empty<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim matchText As Match = Regex.Match(strWholeHtml, strRegexScript,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;RegexOptions.IgnoreCase)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;strMatchScript = matchText.Groups(0).Value<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim strPureText As String = Regex.Replace(strMatchScript,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;strRegex, String.Empty, RegexOptions.IgnoreCase)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tbResult.Text = String.Empty<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tbResult.Text = strPureText<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[/code] <br>
<br>
Step 5. Add other Button control's click event with VB code like this sample's <br>
&nbsp; &nbsp; &nbsp; &nbsp;&quot;Default.aspx.vb&quot; file.<br>
<br>
Step 6. Build the application and you can debug it.</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: .NET Framework Regular Expressions<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/hs600312.aspx">http://msdn.microsoft.com/en-us/library/hs600312.aspx</a><br>
<br>
MSDN: Regex Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.aspx">http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.aspx</a><br>
<br>
MSDN: WebRequest Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.net.webrequest.aspx">http://msdn.microsoft.com/en-us/library/system.net.webrequest.aspx</a><br>
<br>
MSDN: WebResponse Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.net.webresponse.aspx">http://msdn.microsoft.com/en-us/library/system.net.webresponse.aspx</a><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
