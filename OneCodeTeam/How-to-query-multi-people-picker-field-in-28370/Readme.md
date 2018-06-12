# How to query multi people picker field in SharePoint list using REST query
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* SharePoint
* SharePoint 2013
* SharePoint Development
## Topics
* REST
* code snippets
* Query multi people
## IsPublished
* True
## ModifiedDate
* 2014-04-25 07:55:43
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to query multi people picker field in SharePoint list using REST query</span><a name="_GoBack"></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This code snippet </span>
<span style="font-size:11pt">will </span><span style="font-size:11pt">show </span>
<span style="font-size:11pt">you how t</span><span>o query multi people picker field in SharePoint list using REST query</span><span style="font-size:11pt">.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Code Snippet</span></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Get JSON data of the SharePoint Task Item.</span></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Get the multi people field of the item.
</span></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Use </span>
<span style="font-weight:bold">for </span><span style="font-size:11pt">or </span>
<span style="font-weight:bold">Foreach </span><span style="font-size:11pt">to get every AssignedToId.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span><span class="hidden">js</span>
<pre class="hidden">private static void GetMultiUserByTaskListName(String strTaskName)
        {
            Uri uri = new Uri(&quot;http://&quot; &#43; Environment.MachineName &#43;
    &quot;/_api/web/lists/getByTitle('&quot; &#43; strTaskName &#43; &quot;')/items/&quot;);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Accept = &quot;application/json; odata=verbose&quot;;
            WebResponse response = request.GetResponse();
            Stream streamReceive = response.GetResponseStream();
            Encoding encoding = Encoding.UTF8;
            StreamReader streamReader = new StreamReader(streamReceive, encoding);
            string strResult = streamReader.ReadToEnd();
            // Parse the JSON data.
            JObject dynamicResult = JObject.Parse(strResult);
            JArray jsonArray = null;
            jsonArray = JArray.Parse(dynamicResult[&quot;d&quot;][&quot;results&quot;].ToString());
            foreach (var sample in jsonArray)
            {
                foreach (var assignedId in sample[&quot;AssignedToId&quot;][&quot;results&quot;].ToArray())
                {               
                    //SPUser spUser=new SPSite(&quot;Server&quot;).OpenWeb().AllUsers.GetByID(Convert.ToInt32(assignedId));
                    //Console.WriteLine(spUser.Name);
                    Console.WriteLine(assignedId);
                }
            }
        }
 
</pre>
<pre class="hidden">Private Shared Sub GetMultiUserByTaskListName(strTaskName As [String])
 Dim uri As New Uri(&quot;http://&quot; &#43; Environment.MachineName &amp; &quot;/_api/web/lists/getByTitle('&quot; &amp; Convert.ToString(strTaskName) &amp; &quot;')/items/&quot;)
 Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(uri), HttpWebRequest)
 request.Credentials = CredentialCache.DefaultCredentials
 request.Accept = &quot;application/json; odata=verbose&quot;
 Dim response As WebResponse = request.GetResponse()
 Dim streamReceive As Stream = response.GetResponseStream()
 Dim encoding__1 As Encoding = Encoding.UTF8
 Dim streamReader As New StreamReader(streamReceive, encoding__1)
 Dim strResult As String = streamReader.ReadToEnd()
 ' Parse the JSON data.
 Dim dynamicResult As JObject = JObject.Parse(strResult)
 Dim jsonArray As JArray = Nothing
 jsonArray = JArray.Parse(dynamicResult(&quot;d&quot;)(&quot;results&quot;).ToString())
 For Each sample As var In jsonArray
  For Each assignedId As var In sample(&quot;AssignedToId&quot;)(&quot;results&quot;).ToArray()
   'SPUser spUser=new SPSite(&quot;Server&quot;).OpenWeb().AllUsers.GetByID(Convert.ToInt32(assignedId));
   'Console.WriteLine(spUser.Name);
   Console.WriteLine(assignedId)
  Next
 Next
End Sub
</pre>
<pre class="hidden">$.ajax(
    {
        url: _spPageContextInfo.webServerRelativeUrl &#43;
            &quot;/_api/web/lists/getByTitle('Tasks')/items/getById(1)&quot;,
        method: &quot;GET&quot;,
        headers: {
            &quot;accept&quot;: &quot;application/json;odata=verbose&quot;,
        },
        success: function (data) {
            var assignedTo = data.d.AssignedToId.results;
            for (var i = 0; i &lt; assignedTo.length; i&#43;&#43;) {
                alert(assignedTo[i]);
            }
        },
        error: function (err) {
            alert(JSON.stringify(err));
        }
    }
);
</pre>
<pre class="csharp" id="codePreview">private static void GetMultiUserByTaskListName(String strTaskName)
        {
            Uri uri = new Uri(&quot;http://&quot; &#43; Environment.MachineName &#43;
    &quot;/_api/web/lists/getByTitle('&quot; &#43; strTaskName &#43; &quot;')/items/&quot;);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Accept = &quot;application/json; odata=verbose&quot;;
            WebResponse response = request.GetResponse();
            Stream streamReceive = response.GetResponseStream();
            Encoding encoding = Encoding.UTF8;
            StreamReader streamReader = new StreamReader(streamReceive, encoding);
            string strResult = streamReader.ReadToEnd();
            // Parse the JSON data.
            JObject dynamicResult = JObject.Parse(strResult);
            JArray jsonArray = null;
            jsonArray = JArray.Parse(dynamicResult[&quot;d&quot;][&quot;results&quot;].ToString());
            foreach (var sample in jsonArray)
            {
                foreach (var assignedId in sample[&quot;AssignedToId&quot;][&quot;results&quot;].ToArray())
                {               
                    //SPUser spUser=new SPSite(&quot;Server&quot;).OpenWeb().AllUsers.GetByID(Convert.ToInt32(assignedId));
                    //Console.WriteLine(spUser.Name);
                    Console.WriteLine(assignedId);
                }
            }
        }
 
</pre>
</div>
</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">&nbsp;</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">After get</span><span style="font-size:11pt">ting
</span><span style="font-size:11pt">the JSON data, </span><span style="font-size:11pt">w</span><span style="font-size:11pt">e</span><span> use
</span><span style="font-size:11pt">JSON.NET</span><span> </span><span>library </span>
<span>to </span><span>con</span><span>vert the data to local </span><span>data</span><span>, and t</span><span>hen
</span><span>iteratively</span><span> get the A</span><span>ssignedToId property.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>HttpWebRequest Class</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/windowsphone/develop/system.net.httpwebrequest(v=vs.105).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windowsphone/develop/system.net.httpwebrequest(v=vs.105).aspx</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>HttpWebResponse Class</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/windowsphone/develop/system.net.httpwebresponse(v=vs.105).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windowsphone/develop/system.net.httpwebresponse(v=vs.105).aspx</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>StreamReader Class</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/system.io.streamreader(v=vs.110).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/system.io.streamreader(v=vs.110).aspx</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>HttpWebRequest.Accept Property</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/windowsphone/develop/system.net.httpwebrequest.accept(v=vs.105).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windowsphone/develop/system.net.httpwebrequest.accept(v=vs.105).aspx</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>ListCollection.GetByTitle method</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.client.listcollection.getbytitle(v=office.15).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.client.listcollection.getbytitle(v=office.15).aspx</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>SP.PageContextInfo Class</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/office/ff410593(v=office.14).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/office/ff410593(v=office.14).aspx</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
