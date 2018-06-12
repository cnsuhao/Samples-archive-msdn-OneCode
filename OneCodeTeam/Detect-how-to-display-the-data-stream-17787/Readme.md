# Detect how to display the data stream
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Stream
## IsPublished
* True
## ModifiedDate
* 2013-07-05 02:43:36
## Description
========================================================================<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;VBASPNETDisplayDataStreamResource Overview<br>
========================================================================<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Use:<br>
<br>
The project illustrates how to display the data stream from Internet resource<br>
and site resource in a web page. Customers want to know how to display the <br>
title, content or other information of web pages. Thus, the sample can search<br>
the target web page which you input url address in TextBox control and get all<br>
relative link resources of it. <br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Demo the Sample. <br>
<br>
Please follow these demonstration steps below.<br>
<br>
Step 1: Open the VBASPNETDisplayDataStreamResource.sln.<br>
<br>
Step 2: Expand the VBASPNETDisplayDataStreamResource web application and press <br>
&nbsp; &nbsp; &nbsp; &nbsp;Ctrl &#43; F5 to show the DisplayResource.aspx.<br>
<br>
Step 3: You will see a TextBox and a Button on SearchEngine.aspx page. The TextBox<br>
&nbsp; &nbsp; &nbsp; &nbsp;is used to input target page's url address and find the link resources of<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;web page.<br>
<br>
Step 4: If the url links like &quot;#&quot;, the application replace it as source page url,
<br>
&nbsp; &nbsp; &nbsp; &nbsp;and url routing links, such as &quot;/duty/&quot;, web application can combine source
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;page url and url routing name to a complete url automatically.<br>
<br>
Step 5: Validation finished.<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Code Logical:<br>
<br>
Step 1. Create a VB &quot;ASP.NET Empty Application&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp;Visual Web Developer 2010. Name it as &quot;VBASPNETDisplayDataStreamResource&quot;.<br>
<br>
Step 2. Add an ASP.NET folder named &quot;App_Code&quot;, and this folder is used to store class<br>
&nbsp; &nbsp; &nbsp; &nbsp;files. In this sample code, we create two class files in it, one of them is
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;RegexMethod&quot;, the other is &quot;WebPageEntity&quot;.<br>
<br>
Step 3. Add a web form page named &quot;DisplayResource.aspx&quot;, this page is used to retrieve<br>
&nbsp; &nbsp; &nbsp; &nbsp;page resource and find relative page by key words. The main VB code will be<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;like this:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp;Private webResources As WebPageEntity<br>
&nbsp; &nbsp;Public publicTable As String = String.Empty<br>
<br>
&nbsp; &nbsp;Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load<br>
<br>
&nbsp; &nbsp;End Sub<br>
<br>
''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' The method is used to load resource by specific web pages.<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;Public Sub LoadLink(ByVal url As String)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim method As New RegexMethod()<br>
&nbsp; &nbsp; &nbsp; &nbsp;webResources = New WebPageEntity()<br>
&nbsp; &nbsp; &nbsp; &nbsp;SyncLock Me<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim result As String = Me.LoadResource(url)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim webEntity As New WebPageEntity()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webEntity.Name = Path.GetFileName(url)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webEntity.Link = method.GetLinks(result, url)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webEntity.Content = result<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webResources = webEntity<br>
&nbsp; &nbsp; &nbsp; &nbsp;End SyncLock<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim builder As New StringBuilder()<br>
&nbsp; &nbsp; &nbsp; &nbsp;builder.Append(&quot;
<table>
&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp;For i As Integer = 0 To webResources.Link.Count - 1<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;builder.Append(&quot;
<tbody>
<tr>
<td><a href="&quot; & webResources.Link(i).ToString() & &quot;">&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;builder.Append(webResources.Link(i).ToString())<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;builder.Append(&quot;</a></td>
</tr>
&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Next<br>
&nbsp; &nbsp; &nbsp; &nbsp;builder.Append(&quot;
</tbody>
</table>
&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp;publicTable = builder.ToString()<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Use HttpWebRequest, HttpWebResponse, StreamReader for retrieving<br>
&nbsp; &nbsp;''' information of pages, and calling Regex methods to get useful <br>
&nbsp; &nbsp;''' information.<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;url&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;returns&gt;&lt;/returns&gt;<br>
&nbsp; &nbsp;Public Function LoadResource(ByVal url As String) As String<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim webResponse As HttpWebResponse = Nothing<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim reader As StreamReader = Nothing<br>
&nbsp; &nbsp; &nbsp; &nbsp;Try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim webRequest__1 As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webRequest__1.Timeout = 30000<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webResponse = DirectCast(webRequest__1.GetResponse(), HttpWebResponse)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim resource As String = [String].Empty<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If webResponse Is Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return String.Empty<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ElseIf webResponse.StatusCode &lt;&gt; HttpStatusCode.OK Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return String.Empty<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;reader = New StreamReader(webResponse.GetResponseStream(), Encoding.GetEncoding(&quot;utf-8&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;resource = reader.ReadToEnd()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return resource<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;Catch ex As Exception<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return ex.Message<br>
&nbsp; &nbsp; &nbsp; &nbsp;Finally<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If webResponse IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webResponse.Close()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If reader IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;reader.Close()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Try<br>
&nbsp; &nbsp;End Function<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' The search button click event is used to compare key words and <br>
&nbsp; &nbsp;''' page resources for selecting relative pages. <br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp;Protected Sub btnSearchPage_Click(ByVal sender As Object, ByVal e As EventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp;If tbKeyWord.Text.Trim() &lt;&gt; String.Empty Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If RegexMethod.IsUrl(tbKeyWord.Text.Trim()) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.LoadLink(tbKeyWord.Text.Trim())<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Response.Write(&quot;Url address is not valid&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Response.Write(&quot;Url address can not be null.&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; [/code]<br>
<br>
Step 5. The RegexMethod class provides two methods to extract specific information<br>
&nbsp; &nbsp; &nbsp; &nbsp;from pages.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; [code]<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim links As New List(Of String)()<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim strRegexLink As String = &quot;(?is)<a>&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim matchList As MatchCollection = Regex.Matches(htmlCode, strRegexLink, RegexOptions.IgnoreCase)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim strbLinkList As New StringBuilder()<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;For Each matchSingleLink As Match In matchList<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim matchLink As String = &quot;]*?href=(['&quot;&quot;\s]?)([^'&quot;&quot;\s]&#43;)\1[^&gt;]*?&gt;&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim match As Match = Regex.Match(matchSingleLink.Value, matchLink, RegexOptions.IgnoreCase)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If match.Groups(2).Value = &quot;#&quot; Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;links.Add(url)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ElseIf Not match.Groups(2).Value.ToLower().Contains(&quot;http://&quot;) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;links.Add(url &#43; match.Groups(2).Value)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;links.Add(match.Groups(2).Value)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;Next<br>
&nbsp; &nbsp; &nbsp; &nbsp;Return links<br>
&nbsp; &nbsp;End Function<br>
<br>
&nbsp; &nbsp;Public Shared Function IsUrl(ByVal source As String) As Boolean<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Return Regex.IsMatch(source, &quot;^(((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)|<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(www\.))&#43;(([a-zA-Z0-9\._-]&#43;\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(/[a-zA-Z0-9\&amp;%_\./-~-]*)?$&quot;, RegexOptions.IgnoreCase)<br>
&nbsp; &nbsp;End Function<br>
&nbsp; &nbsp; &nbsp; [/code] &nbsp;<br>
<br>
Step 6. The WebPageEntity class file is used to store web page resource, <br>
&nbsp; &nbsp; &nbsp; &nbsp;and binding them as the data source of GridView control.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; [code]<br>
&nbsp; &nbsp;&lt;Serializable()&gt; _<br>
&nbsp; &nbsp;Public Class WebPageEntity<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' web page entity class, contain page's basic information,<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' such as name, content, link, title, body text.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Property Name As String<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Property Content As String<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Property Link As List(Of String)<br>
&nbsp; &nbsp;End Class<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; [/code]<br>
<br>
Step 7. Build the application and you can debug it.<br>
/////////////////////////////////////////////////////////////////////////////<br>
References:<br>
<br>
MSDN: HttpWebRequest Class<br>
http://msdn.microsoft.com/en-us/library/system.net.httpwebrequest.aspx<br>
<br>
MSDN: HttpWebResponse Class<br>
http://msdn.microsoft.com/en-us/library/system.net.httpwebresponse.aspx<br>
<br>
MSDN: .NET Framework Regular Expressions<br>
http://msdn.microsoft.com/en-us/library/hs600312.aspx<br>
<br>
MSDN: StreamReader Class<br>
http://msdn.microsoft.com/en-us/library/system.io.streamreader.aspx<br>
<br>
MSDN: List&lt;T&gt;.Contains Method <br>
http://msdn.microsoft.com/en-us/library/bhkz42b3.aspx<br>
/////////////////////////////////////////////////////////////////////////////<br>
</a>