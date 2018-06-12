# How to use blob snapshots to restore a blob storage in Windows Azure
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
* 2014-09-17 11:43:50
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-size:14pt">&nbsp;</span><span style="font-size:14pt">How to use blob snapshots to restore a blob storage in Windows Azure</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; margin:0pt">
<span style="font-size:11pt"><span style="color:#000000">&nbsp;</span><span style="color:#000000">A snapshot of a blob has the same name as the base blob from which the snapshot is taken, with a Date Time value appended to indicate the time at which the snapshot
 was taken. For example, if the page blob URI is http://storagesample.core.blob.windows.net/mydrives/myvhd, the snapshot URI will be similar to http://storagesample.core.blob.windows.net/mydrives/myvhd?snapshot=!2011-03-09T01:42:34.9360000Z. This value may
 be used to reference the snapshot for further operations. A blob's snapshots share its URI and are distinguished only by this Date Time value. In client library code, the blob's Snapshot property returns a Date Time value that uniquely identifies the snapshot
 relative to its base blob. You can use this value to perform further operations on the snapshot.</span></span></p>
<p style="font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; margin:0pt">
<span style="font-size:11pt"><span style="color:#000000">Once a snapshot has been created, it can be read, copied, or deleted, but not modified. Snapshots provide a way to back up a blob as it appears at a moment in time.</span></span></p>
<p style="font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; margin:0pt">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; margin:0pt">
<span style="font-size:11pt"><a name="_GoBack"></a><span style="color:#000000">This code snippet
</span><span style="color:#000000">shows </span><span style="color:#000000">how to use a snapshot of blob to restore a blob storage.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a name="OLE_LINK12"></a><a name="OLE_LINK11"></a><span style="font-size:11pt">The snippet sample requires Azure storage package. You can install it through
</span><span style="font-size:11pt">Nuget</span><span style="font-size:11pt"> by</span><span style="font-size:11pt"> running
</span><span style="font-size:11pt">the</span><span style="font-size:11pt"> following command in the
</span><a href="http://docs.nuget.org/docs/start-here/using-the-package-manager-console" style="text-decoration:none"><span style="color:#0071bc; text-decoration:underline">Package Manager Console</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="background-color:#202020; color:#e2e2e2; font-size:14pt">PM&gt; Install-Package
</span><span style="background-color:#202020; color:#e2e2e2; font-size:14pt">WindowsAzure.Storage</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The code below shows how to achieve that.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">var snapshots = blob.Container.ListBlobs(null, true, BlobListingDetails.Snapshots, null, null);

            var snapshot = snapshots.Where(snap =&gt;
            {
                CloudBlockBlob lists = snap as CloudBlockBlob;
                if (lists != null &amp;&amp; lists.Name == blob.Name &amp;&amp; lists.SnapshotTime != null)
                    return true;
                else
                    return false;
            }).First();

            Blob.CopyFromBlob((CloudBlockBlob)snapshot);

</pre>
<pre class="hidden">Dim snapshots = blob.Container.ListBlobs(Nothing, True, BlobListingDetails.Snapshots, Nothing, Nothing)

Dim snapshot = snapshots.Where(Function(snap) 
Dim lists As CloudBlockBlob = TryCast(snap, CloudBlockBlob)
If lists IsNot Nothing AndAlso lists.Name = blob.Name AndAlso lists.SnapshotTime IsNot Nothing Then
	Return True
Else
	Return False
End If

End Function).First()

Blob.CopyFromBlob(DirectCast(snapshot, CloudBlockBlob))</pre>
<div class="preview">
<pre class="csharp">var&nbsp;snapshots&nbsp;=&nbsp;blob.Container.ListBlobs(<span class="cs__keyword">null</span>,&nbsp;<span class="cs__keyword">true</span>,&nbsp;BlobListingDetails.Snapshots,&nbsp;<span class="cs__keyword">null</span>,&nbsp;<span class="cs__keyword">null</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;snapshot&nbsp;=&nbsp;snapshots.Where(snap&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloudBlockBlob&nbsp;lists&nbsp;=&nbsp;snap&nbsp;<span class="cs__keyword">as</span>&nbsp;CloudBlockBlob;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(lists&nbsp;!=&nbsp;<span class="cs__keyword">null</span>&nbsp;&amp;&amp;&nbsp;lists.Name&nbsp;==&nbsp;blob.Name&nbsp;&amp;&amp;&nbsp;lists.SnapshotTime&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).First();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Blob.CopyFromBlob((CloudBlockBlob)snapshot);&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
&nbsp;</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">MSDN:</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>http://msdn.microsoft.com/en-us/library/hh488361.aspx</span></span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
