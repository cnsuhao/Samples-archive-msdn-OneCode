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
* 2013-07-05 02:43:07
## Description
========================================================================<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CSASPNETDisplayDataStreamResource Overview<br>
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
Step 1: Open the CSASPNETDisplayDataStreamResource.sln.<br>
<br>
Step 2: Expand the CSASPNETDisplayDataStreamResource web application and press <br>
&nbsp; &nbsp; &nbsp; &nbsp;Ctrl &#43; F5 to show the SearchEngine.aspx.<br>
<br>
Step 3: You will see a TextBox and a Button on DisplayResource.aspx page. The TextBox<br>
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
Step 1. Create a C# &quot;ASP.NET Empty Application&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp;Visual Web Developer 2010. Name it as &quot;CSASPNETDisplayDataStreamResource&quot;.<br>
<br>
Step 2. Add an ASP.NET folder named &quot;App_Code&quot;, and this folder is used to store class<br>
&nbsp; &nbsp; &nbsp; &nbsp;files. In this sample code, we create two class files in it, one of them is
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;RegexMethod&quot;, and the other is &quot;WebPageEntity&quot;.<br>
<br>
Step 3. Add a web form page named &quot;DisplayResource.aspx&quot;, this page is used to retrieve<br>
&nbsp; &nbsp; &nbsp; &nbsp;page resource and find relative page by key words. The main C# code will be<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;like this:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp;public partial class DisplayResource : System.Web.UI.Page<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;private WebPageEntity webResources;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public string publicTable = string.Empty;<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected void Page_Load(object sender, EventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// The method is used to load resource by specific web pages.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public void LoadLink(string url)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RegexMethod method = new RegexMethod();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webResources = new WebPageEntity();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lock (this)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string result = this.LoadResource(url);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;WebPageEntity webEntity = new WebPageEntity();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webEntity.Name = Path.GetFileName(url);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webEntity.Uri=url;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webEntity.Link = method.GetLinks(result, url);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webEntity.Content = result;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webResources = webEntity;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;StringBuilder builder = new StringBuilder();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;builder.Append(&quot;
<table>
&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;for (int i = 0; i &lt; webResources.Link.Count; i&#43;&#43;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;builder.Append(&quot;
<tbody>
<tr>
<td><a href="&quot;&#43;webResources.Link[i].ToString()&#43;&quot;">&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;builder.Append(webResources.Link[i].ToString());<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;builder.Append(&quot;</a></td>
</tr>
&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;builder.Append(&quot;
</tbody>
</table>
&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;publicTable = builder.ToString();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Use HttpWebRequest, HttpWebResponse, StreamReader for retrieving<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// information of pages, and calling Regex methods to get useful
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// information.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;url&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;returns&gt;&lt;/returns&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public string LoadResource(string url)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HttpWebResponse webResponse = null;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;StreamReader reader = null;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webRequest.Timeout = 30000;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webResponse = (HttpWebResponse)webRequest.GetResponse();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string resource = String.Empty;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (webResponse == null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return string.Empty;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else if (webResponse.StatusCode != HttpStatusCode.OK)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return string.Empty;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;reader = new StreamReader(webResponse.GetResponseStream(), Encoding.GetEncoding(&quot;utf-8&quot;));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;resource = reader.ReadToEnd();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return resource;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;catch (Exception ex)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return ex.Message;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;finally<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (webResponse != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webResponse.Close();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (reader != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;reader.Close();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// The search button click event is used to compare key words and
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// page resources for selecting relative pages. <br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected void btnSearchPage_Click(object sender, EventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (tbKeyWord.Text.Trim() != string.Empty)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (RegexMethod.IsUrl(tbKeyWord.Text.Trim()))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.LoadLink(tbKeyWord.Text.Trim());<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Response.Write(&quot;Url address is not valid&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Response.Write(&quot;Url address can not be null.&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[/code]<br>
<br>
Step 5. The RegexMethod class provides two methods to extract specific information<br>
&nbsp; &nbsp; &nbsp; &nbsp;from pages.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[code]<br>
&nbsp; &nbsp; &nbsp; &nbsp;public List&lt;string&gt; GetLinks(string htmlCode,string url)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;List&lt;string&gt; links=new List&lt;string&gt;();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string strRegexLink = @&quot;(?is)<a>&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MatchCollection matchList = Regex.Matches(htmlCode, strRegexLink, RegexOptions.IgnoreCase);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;StringBuilder strbLinkList = new StringBuilder();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;foreach (Match matchSingleLink in matchList)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string matchLink = @&quot;]*?href=(['&quot;&quot;\s]?)([^'&quot;&quot;\s]&#43;)\1[^&gt;]*?&gt;&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Match match = Regex.Match(matchSingleLink.Value, matchLink, RegexOptions.IgnoreCase);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (match.Groups[2].Value == &quot;#&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;links.Add(url);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else if (!match.Groups[2].Value.ToLower().Contains(&quot;http://&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;links.Add(url &#43; match.Groups[2].Value);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;links.Add(match.Groups[2].Value);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return links;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public static bool IsUrl(string source)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return Regex.IsMatch(source, @&quot;^(((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp):<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//)|(www\.))&#43;(([a-zA-Z0-9\._-]&#43;\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{1,3}))(/[a-zA-Z0-9\&amp;%_\./-~-]*)?$&quot;, RegexOptions.IgnoreCase);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;[/code] &nbsp;<br>
<br>
Step 6. The WebPageEntity class file is used to store web page resource, <br>
&nbsp; &nbsp; &nbsp; &nbsp;and binding them as the data source of GridView control.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp;/// web page entity class, contain page's basic information,<br>
&nbsp; &nbsp;/// such as name, content, link, title, body text.<br>
&nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp;[Serializable]<br>
&nbsp; &nbsp;public class WebPageEntity<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;private string name;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private string content;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private string uri;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private List&lt;string&gt; link;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public string Name<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return name;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;set<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;name = value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public string Content<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return content;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;set<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;content = value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public string Uri<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return uri;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;set<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;uri = value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public List&lt;string&gt; Link<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return link;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;set<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;link = value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[/code]<br>
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