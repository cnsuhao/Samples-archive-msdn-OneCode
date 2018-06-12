# How to get all snapshots of a blob storage in Windows Azure
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
* 2014-06-15 08:21:43
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to get all snapshots of a blob storage in Azure
</span><span style="font-weight:bold; font-size:14pt">&nbsp;</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; margin:0pt">
<span style="font-size:11pt"><span>This </span><span style="color:#000000">code snippet
</span><span style="color:#000000; font-size:10pt">shows&nbsp;how to get all snapshots of a blob storage in Azure.</span></span></p>
<p style="font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; margin:0pt">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; margin:0pt">
<span style="font-size:11pt"><span style="color:#000000">A snapshot of a blob has the same name as the base blob from which the snapshot is taken, with a DateTime value appended to indicate the time at which the snapshot was taken. For example, if the page
 blob URI is http://storagesample.core.blob.windows.net/mydrives/myvhd, the snapshot URI will be similar to http://storagesample.core.blob.windows.net/mydrives/myvhd?snapshot=!2011-03-09T01:42:34.9360000Z. This value may be used to reference the snapshot for
 further operations. A blob's snapshots share its URI and are distinguished only by this DateTime value. In client library code, the blob's Snapshot property returns a DateTime value that uniquely identifies the snapshot relative to its base blob. You can use
 this value to perform further operations on the snapshot.</span></span></p>
<p style="font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; margin:0pt">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; margin:0pt">
<span style="font-size:11pt"><span style="color:#000000; font-size:10pt">Through the use of the Windows Azure blob snapshotting functionality users can quickly and easily create a backup for any blob storage. This code snippet will help developers list all
 snapshots of a specified blob storage.&nbsp;&nbsp;The result list could help admins to better understand the blob state.</span></span></p>
<p style="font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; margin:0pt">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">To make the following code snippet work, you have to install the Azure storage package. You can install the package through Nuget by running the following command in the
</span><a href="http://docs.nuget.org/docs/start-here/using-the-package-manager-console" style="text-decoration:none"><span style="color:#0071bc; text-decoration:underline">Package Manager Console</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="background-color:#202020; color:#e2e2e2; font-size:14pt">PM&gt;
</span><span style="background-color:#202020; color:#e2e2e2; font-size:14pt">Install-Package WindowsAzure.Storage</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The code </span><span style="font-size:11pt">snippet
</span><a name="_GoBack"></a><span style="font-size:11pt">below shows how to get all snapshots in a blob container.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">CloudStorageAccount account = new CloudStorageAccount(
               new StorageCredentials(&quot;{Account}&quot;, &quot;{Account-Key}&quot;),
               false);
           var client=account.CreateCloudBlobClient();
           Console.WriteLine(&quot;Getting the containder object name {'Container-Name'}&quot;);
           var blobContainder = client.GetContainerReference(&quot;{Container-Name}&quot;);
           Console.WriteLine(&quot;Getting the blob object named {Blob-Name}.&quot;);
           var blob = blobContainder.GetBlockBlobReference(&quot;{Blob-Name}&quot;);
           var listingDetails=BlobListingDetails.Snapshots;
           var snapshots = blob.Container.ListBlobs(null,true,BlobListingDetails.Snapshots,null,null);
</pre>
<pre class="hidden">Dim account As New CloudStorageAccount(New StorageCredentials(&quot;{Account}&quot;, &quot;{Account-Key}&quot;), False)
Dim client = account.CreateCloudBlobClient()
Console.WriteLine(&quot;Getting the containder object name {'Container-Name'}&quot;)
Dim blobContainder = client.GetContainerReference(&quot;{Container-Name}&quot;)
Console.WriteLine(&quot;Getting the blob object named {Blob-Name}.&quot;)
Dim blob = blobContainder.GetBlockBlobReference(&quot;{Blob-Name}&quot;)
Dim listingDetails = BlobListingDetails.Snapshots
Dim snapshots = blob.Container.ListBlobs(Nothing, True, BlobListingDetails.Snapshots, Nothing, Nothing)
</pre>
<pre id="codePreview" class="csharp">CloudStorageAccount account = new CloudStorageAccount(
               new StorageCredentials(&quot;{Account}&quot;, &quot;{Account-Key}&quot;),
               false);
           var client=account.CreateCloudBlobClient();
           Console.WriteLine(&quot;Getting the containder object name {'Container-Name'}&quot;);
           var blobContainder = client.GetContainerReference(&quot;{Container-Name}&quot;);
           Console.WriteLine(&quot;Getting the blob object named {Blob-Name}.&quot;);
           var blob = blobContainder.GetBlockBlobReference(&quot;{Blob-Name}&quot;);
           var listingDetails=BlobListingDetails.Snapshots;
           var snapshots = blob.Container.ListBlobs(null,true,BlobListingDetails.Snapshots,null,null);
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
