# How to break the locked lease of blob storage in Windows Azure
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
* 2014-06-15 08:20:32
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="color:#000000">How to break the locked lease of blob storage in Windows Azure</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>This code snippet</span><span style="color:#000000"> shows how to break the locked lease of blob storage in Windows Azure.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#000000">Windows Azure provides functionality to acquire lock on blobs to avoid concurrent writes to blobs. Sometimes, if the backup fails due to
</span><a name="OLE_LINK1"></a><a name="OLE_LINK2"></a><span style="color:#000000">prolonged or sustained network connectivity failure</span><span style="color:#000000">, the backup process may not be able
</span><span style="color:#000000">to </span><span style="color:#000000">gain access to the blob and the blob may remain orphaned. This means that the blob cannot be written to or deleted until the lease is released. In this case, you might wa</span><span style="color:#000000">nt
 to break the lease on a blob and</span><span style="color:#000000"> </span><span style="color:#000000">t</span><span style="color:#000000">his code snippet
</span><span style="color:#000000">is to help you in this regard.</span><a name="_GoBack"></a><span style="color:#000000">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Building the Sample</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>This snippet sample requires Windows Azure Storage Class Library. You can install it through NuGet by running the following command in the
</span><a href="http://docs.nuget.org/docs/start-here/using-the-package-manager-console" style="text-decoration:none"><span style="color:#0071bc; text-decoration:underline">Package Manager Console</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-weight:bold; color:#ffffff; font-size:14pt; background:black">&nbsp;</span><span style="font-weight:bold; color:#ffffff; font-size:14pt; background:black">PM&gt; Install-Package
</span><span style="font-weight:bold; color:#ffffff; font-size:14pt; background:black">WindowsAzure.Storage</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">class Program
   {
       static CloudStorageAccount account = new CloudStorageAccount(new StorageCredentials(&quot;{Your-Storage-Account}&quot;, &quot;{Your-Storage-Account-Key}&quot;), false);
       static void Main(string[] args)
       {
           string blobName=&quot;0c844bdf-ae4d-4466-b1eb-ae8fd02232b9&quot;;
           var client=account.CreateCloudBlobClient();
           var container = client.GetContainerReference(&quot;pictures&quot;);
           var blob = container.GetBlockBlobReference(blobName);
           if (blob.Properties.LeaseStatus==Microsoft.WindowsAzure.Storage.Blob.LeaseStatus.Locked)
           {
               try
               {
                   Console.WriteLine(&quot;Breaking leases on {0} blob.&quot;,blobName);
                   blob.BreakLease(new TimeSpan(), null, null, null);
                   Console.WriteLine(&quot;Successfully broken lease on {0} blob.&quot;,blobName);
               }
               catch (StorageException ex )
               {
                   Console.WriteLine(&quot;Failed to break lease on {blobName} blob.&quot;, blobName);
               }
           }
           else
           {
               Console.WriteLine(&quot;The {0} blob's lease status is unlocked.&quot;,blobName);
           }
           Console.ReadLine();
       }
   }
}
</pre>
<pre class="hidden">Class Program
 Shared account As New CloudStorageAccount(New StorageCredentials(&quot;{Your-Storage-Account}&quot;, &quot;{Your-Storage-Account-Key}&quot;), False)
 Private Shared Sub Main(args As String())
  Dim blobName As String = &quot;0c844bdf-ae4d-4466-b1eb-ae8fd02232b9&quot;
  Dim client = account.CreateCloudBlobClient()
  Dim container = client.GetContainerReference(&quot;pictures&quot;)
  Dim blob = container.GetBlockBlobReference(blobName)
  If blob.Properties.LeaseStatus = Microsoft.WindowsAzure.Storage.Blob.LeaseStatus.Locked Then
   Try
    Console.WriteLine(&quot;Breaking leases on {0} blob.&quot;, blobName)
    blob.BreakLease(New TimeSpan(), Nothing, Nothing, Nothing)
    Console.WriteLine(&quot;Successfully broken lease on {0} blob.&quot;, blobName)
   Catch ex As StorageException
    Console.WriteLine(&quot;Failed to break lease on {blobName} blob.&quot;, blobName)
   End Try
  Else
   Console.WriteLine(&quot;The {0} blob's lease status is unlocked.&quot;, blobName)
  End If
  Console.ReadLine()
 End Sub
End Class
</pre>
<pre id="codePreview" class="csharp">class Program
   {
       static CloudStorageAccount account = new CloudStorageAccount(new StorageCredentials(&quot;{Your-Storage-Account}&quot;, &quot;{Your-Storage-Account-Key}&quot;), false);
       static void Main(string[] args)
       {
           string blobName=&quot;0c844bdf-ae4d-4466-b1eb-ae8fd02232b9&quot;;
           var client=account.CreateCloudBlobClient();
           var container = client.GetContainerReference(&quot;pictures&quot;);
           var blob = container.GetBlockBlobReference(blobName);
           if (blob.Properties.LeaseStatus==Microsoft.WindowsAzure.Storage.Blob.LeaseStatus.Locked)
           {
               try
               {
                   Console.WriteLine(&quot;Breaking leases on {0} blob.&quot;,blobName);
                   blob.BreakLease(new TimeSpan(), null, null, null);
                   Console.WriteLine(&quot;Successfully broken lease on {0} blob.&quot;,blobName);
               }
               catch (StorageException ex )
               {
                   Console.WriteLine(&quot;Failed to break lease on {blobName} blob.&quot;, blobName);
               }
           }
           else
           {
               Console.WriteLine(&quot;The {0} blob's lease status is unlocked.&quot;,blobName);
           }
           Console.ReadLine();
       }
   }
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/windowsazure/microsoft.windowsazure.storage.blob.cloudblockblob.breaklease(v=azure.100).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windowsazure/microsoft.windowsazure.storage.blob.cloudblockblob.breaklease(v=azure.100).aspx</span></a></span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
