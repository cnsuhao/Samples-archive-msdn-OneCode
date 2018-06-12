# How to change the content type of Windows Azure blob storage
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Azure
* code snippets
## IsPublished
* True
## ModifiedDate
* 2014-06-15 08:19:54
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to change the content type of Windows Azure blob storage</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; margin:0pt">
<span style="font-size:11pt"><span style="color:#000000">&nbsp;</span><span>This code snippet</span><span style="color:#000000"> shows
</span><span style="color:#000000">how to </span><span style="color:#000000">change the content type of Windows Azure blob storage.</span></span></p>
<p style="font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; margin:0pt">
<span style="font-size:11pt"><span style="color:#000000">&nbsp;</span>&nbsp;</span><span style="color:#000000">In some cases, a lot of media files stored on blob are in different formats - mp4, image file, etc</span><span style="color:#000000">. Sometimes,
 all these files are set as one content type: application/octet-stream, which causes issues in media playback and progress bar. Many users would like to know how to set the appropriate Content-type for files stored on blob (like - video/mp4, video/ogg, video/webm)&mdash;not
 to do it manually for each file through blob interface. This script will help users easily batch change the content type of blob storage. It allows users to&nbsp;change content type of blob storage to any data type</span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Building the Sample</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#333333">&nbsp;</span><span style="font-size:11pt">This snippet sample requires Windows Azure Storage class libraries. You can install through NuGet by running the following command in the
</span><a href="http://docs.nuget.org/docs/start-here/using-the-package-manager-console" style="text-decoration:none"><span style="color:#0071bc; text-decoration:underline">Package Manager Console</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="background-color:#202020; color:#e2e2e2; font-size:14pt">PM&gt; Install-Package Microsoft.WindowsAzure.</span><span style="background-color:#202020; color:#e2e2e2; font-size:14pt">Storage</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Below is the code snippet showing how to achieve that. The default content type is application/octet-stream. We will change it to video/mp4, and also you can change it to video/ogg, video/webm if you
 like.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">static void Main(string[] args)
        {
            ChangeContentType(new Uri(&quot;http://{Your-Account-Key}.blob.core.windows.net/vedios/&quot;), &quot;video/mp4&quot;);
            Console.ReadLine();
        }
        static void ChangeContentType(Uri containerUri, string contentType)
        {
            var container = new CloudBlobContainer(containerUri, new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(&quot;{Your-Storage-Account}&quot;, &quot;{Your-Storage-Account-Key)&quot;));
            var blobs = container.ListBlobs();
            foreach (var blob in blobs)
            {
                ((CloudBlockBlob)blob).Properties.ContentType = contentType;
                ((CloudBlockBlob)blob).SetProperties();
            }
        }
</pre>
<pre class="hidden">Private Shared Sub Main(args As String())
 ChangeContentType(New Uri(&quot;http://{Your-Account-Key}.blob.core.windows.net/vedios/&quot;), &quot;video/mp4&quot;)
 Console.ReadLine()
End Sub
Private Shared Sub ChangeContentType(containerUri As Uri, contentType As String)
 Dim container = New CloudBlobContainer(containerUri, New Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(&quot;{Your-Storage-Account}&quot;, &quot;{Your-Storage-Account-Key)&quot;))
 Dim blobs = container.ListBlobs()
 For Each blob As var In blobs
  DirectCast(blob, CloudBlockBlob).Properties.ContentType = contentType
  DirectCast(blob, CloudBlockBlob).SetProperties()
 Next
End Sub
</pre>
<pre id="codePreview" class="csharp">static void Main(string[] args)
        {
            ChangeContentType(new Uri(&quot;http://{Your-Account-Key}.blob.core.windows.net/vedios/&quot;), &quot;video/mp4&quot;);
            Console.ReadLine();
        }
        static void ChangeContentType(Uri containerUri, string contentType)
        {
            var container = new CloudBlobContainer(containerUri, new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(&quot;{Your-Storage-Account}&quot;, &quot;{Your-Storage-Account-Key)&quot;));
            var blobs = container.ListBlobs();
            foreach (var blob in blobs)
            {
                ((CloudBlockBlob)blob).Properties.ContentType = contentType;
                ((CloudBlockBlob)blob).SetProperties();
            }
        }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
&nbsp;</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/library/azure/hh225342.aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">Set and Retrieve Properties and Metadata</span></a><span style="font-size:11pt">
</span></span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
