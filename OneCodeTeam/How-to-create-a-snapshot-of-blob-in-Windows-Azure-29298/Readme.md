# How to create a snapshot of blob in Windows Azure
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
* 2014-06-15 08:20:56
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to create a snapshot of blob in Windows Azure</span><span style="font-weight:bold; font-size:14pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; margin:0pt">
<span style="font-size:11pt"><span style="color:#000000">&nbsp;</span><span style="color:#000000">This Code Snippet
</span><span style="color:#000000">shows h</span><span style="color:#000000">ow to create a snapshot of blob in Windows Azure.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">For </span><span style="font-size:11pt">developers, the best way to prevent accidental deletion or modification is creating a snapshot of blob.
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">A snapshot is a read-only version of a blob that's taken at a point in time. Once a snapshot has been created, it can be read, copied, or deleted, but not modified. Snapshots provide a way to back up
 a blob as it appears at a moment in time.</span><span style="font-size:11pt"> A snapshot of a blob has the same name as the base blob from which the snapshot is taken, with a&nbsp;</span><span style="font-weight:bold">DateTime</span><span style="font-size:11pt">&nbsp;value
 appended to indicate the time at which the snapshot was taken.&nbsp;</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">A blob may have any number of snapshots. Snapshots persist until they are explicitly deleted. A snapshot cannot outlive its source blob. You can enumerate the snapshots associated with your blob to track
 your current snapshots.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This script can help developers
</span><a name="_GoBack"></a><span>easily </span><span style="font-size:11pt">create</span><span style="font-size:11pt"> a snapshot of a specific blob storage.&nbsp;
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Building the Sample</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>This sample requires Windows Azure Storage Class Libraries. If you haven't install it, please run the following command in the
</span><a href="http://docs.nuget.org/docs/start-here/using-the-package-manager-console" style="text-decoration:none"><span style="color:#0071bc; text-decoration:underline">Package Manager Console</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-weight:bold; color:#ffffff; font-size:14pt; background:black">PM&gt; Install-Package WindowsAzure.Storage</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>The code snippet below shows how to create a snapshot of blob in Windows Azure.
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">class Program
    {
        static CloudStorageAccount account = new CloudStorageAccount(new StorageCredentials(&quot;{Your-Storage-Account}&quot;, &quot; {Your-Storage-Account-Key}&quot;,false);
        static void Main(string[] args)
        {
            string blobName=&quot;{Blob-Name}&quot;;
            var client=account.CreateCloudBlobClient();
            var container = client.GetContainerReference(&quot;Container-Name&quot;);
            var blob = container.GetBlockBlobReference(blobName);
            try
            {
                blob.CreateSnapshot();
                Console.WriteLine(&quot;Successfully create a snapshot of blob {0}.&quot;,blobName);
            }
            catch (StorageException ex)
            {
                Console.WriteLine(&quot;Failed to create a snapshot of blob {0}.&quot;,blobName);
                throw ex;
            }
            Console.ReadLine();
        }
    }
--C# code snippet end

Class Program
 Shared account As New CloudStorageAccount(New StorageCredentials(&quot;{Your-Storage-Account}&quot;, &quot; {Your-Storage-Account-Key}&quot;), False)
 Private Shared Sub Main(args As String())
  Dim blobName As String = &quot;{Blob-Name}&quot;;&quot;
  Dim client = account.CreateCloudBlobClient()
  Dim container = client.GetContainerReference(&quot;{Container-Name}&quot;)
  Dim blob = container.GetBlockBlobReference(blobName)
  Try
   blob.CreateSnapshot()
   Console.WriteLine(&quot;Successfully create a snapshot of blob {0}.&quot;, blobName)
  Catch ex As StorageException
   Console.WriteLine(&quot;Failed to create a snapshot of blob {0}.&quot;, blobName)
   Throw ex
  End Try
  Console.ReadLine()
 End Sub
End Class
</pre>
<pre id="codePreview" class="csharp">class Program
    {
        static CloudStorageAccount account = new CloudStorageAccount(new StorageCredentials(&quot;{Your-Storage-Account}&quot;, &quot; {Your-Storage-Account-Key}&quot;,false);
        static void Main(string[] args)
        {
            string blobName=&quot;{Blob-Name}&quot;;
            var client=account.CreateCloudBlobClient();
            var container = client.GetContainerReference(&quot;Container-Name&quot;);
            var blob = container.GetBlockBlobReference(blobName);
            try
            {
                blob.CreateSnapshot();
                Console.WriteLine(&quot;Successfully create a snapshot of blob {0}.&quot;,blobName);
            }
            catch (StorageException ex)
            {
                Console.WriteLine(&quot;Failed to create a snapshot of blob {0}.&quot;,blobName);
                throw ex;
            }
            Console.ReadLine();
        }
    }
--C# code snippet end

Class Program
 Shared account As New CloudStorageAccount(New StorageCredentials(&quot;{Your-Storage-Account}&quot;, &quot; {Your-Storage-Account-Key}&quot;), False)
 Private Shared Sub Main(args As String())
  Dim blobName As String = &quot;{Blob-Name}&quot;;&quot;
  Dim client = account.CreateCloudBlobClient()
  Dim container = client.GetContainerReference(&quot;{Container-Name}&quot;)
  Dim blob = container.GetBlockBlobReference(blobName)
  Try
   blob.CreateSnapshot()
   Console.WriteLine(&quot;Successfully create a snapshot of blob {0}.&quot;, blobName)
  Catch ex As StorageException
   Console.WriteLine(&quot;Failed to create a snapshot of blob {0}.&quot;, blobName)
   Throw ex
  End Try
  Console.ReadLine()
 End Sub
End Class
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>Note: You need to fill the storage account/ account key value, your blob name, and the container name.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span><br>
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://docs.nuget.org/docs/start-here/using-the-package-manager-consolemsdn.microsoft.com/en-us/library/windowsazure/hh488361.aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">Creating
 a Snapshot of a Blob</span></a></span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
