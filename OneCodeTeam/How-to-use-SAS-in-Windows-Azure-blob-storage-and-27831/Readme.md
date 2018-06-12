# How to use SAS in Windows Azure blob storage and extend its expiration
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* Windows Azure Storage
## Topics
* SAS
## IsPublished
* True
## ModifiedDate
* 2014-03-25 10:12:19
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<h1><span lang="EN-US">Provide Windows Azure Table Storage SAS token by Web API (CSAzureProvideSAS)</span></h1>
<h2><span lang="EN-US">Introduction</span></h2>
<p>Using a shared access signature (SAS) is a powerful way to grant limited access to blobs, tables, and queues in your storage account to other clients, without having to expose your account key. You can use a SAS when you want to provide access to resources
 in your storage account to a client that can't be trusted with the account key. Your storage account keys include both a primary and secondary key, both of which grant administrative access to your account and all of the resources in it. Exposing either of
 your account keys opens your account to the possibility of malicious or negligent use. Shared access signatures provide a safe alternative that allows other clients to read, write, and delete data in your storage account according to the permissions you've
 granted, and without need for the account key.</p>
<p>This sample will demonstrate how to generate SAS with Web API, and get the SAS from client. You can find the answers for all the following questions in the code sample:</p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span lang="EN-US" style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">How to generate SAS from server side and extend its expiry time.</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span lang="EN-US" style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">How to get SAS from client.</span></p>
<h2><span lang="EN-US">Running the Sample</span></h2>
<p class="MsoNormal"><span lang="EN-US">You should first press the Ctrl&#43;F5 run the web project.</span></p>
<p class="MsoNormal"><span lang="EN-US">Then right click the client project, choose debug-&gt;start new instance.</span></p>
<h2><span lang="EN-US">Using the Code</span></h2>
<p class="MsoNormal"><span lang="EN-US">The code sample provides the following reusable functions.</span></p>
<p class="MsoNormal"><span lang="EN-US">The following function gets the partition key from the client side, then requires the specific permission SAS based on the partition and extends the SAS expiry time.</span></p>
<h3><span lang="EN-US">How to generate SAS from server side and extend its expiry time?</span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class SASGeneraterController : ApiController
    {
 
        string storageAccountName = &quot;&lt;Storage Account&gt;&quot;;
        string storageAccountKey = &quot;&lt;Storage Key&gt;&quot;;
        string tableName = &quot;&lt;Storage Table Name&gt;&quot;;

        // Post api/SASGenerater/PatitionKey
        public string Post([FromBody] string partitionKey)
        {
            StorageCredentials credentials = new StorageCredentials(storageAccountName, storageAccountKey);
            CloudStorageAccount account = new CloudStorageAccount(credentials, true);
            var client = account.CreateCloudTableClient();
            var table = client.GetTableReference(tableName);

            SharedAccessTablePolicy policy = new SharedAccessTablePolicy()
            {

                SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(
                300.00),
                Permissions = SharedAccessTablePermissions.Add
                    | SharedAccessTablePermissions.Query
                    | SharedAccessTablePermissions.Update
                    | SharedAccessTablePermissions.Delete
            };

            string sasToken = table.GetSharedAccessSignature(policy, null, partitionKey, null, partitionKey, null);
            return sasToken;         
        }
    }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;SASGeneraterController&nbsp;:&nbsp;ApiController&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;storageAccountName&nbsp;=&nbsp;<span class="cs__string">&quot;&lt;Storage&nbsp;Account&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;storageAccountKey&nbsp;=&nbsp;<span class="cs__string">&quot;&lt;Storage&nbsp;Key&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;tableName&nbsp;=&nbsp;<span class="cs__string">&quot;&lt;Storage&nbsp;Table&nbsp;Name&gt;&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Post&nbsp;api/SASGenerater/PatitionKey</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Post([FromBody]&nbsp;<span class="cs__keyword">string</span>&nbsp;partitionKey)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StorageCredentials&nbsp;credentials&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StorageCredentials(storageAccountName,&nbsp;storageAccountKey);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloudStorageAccount&nbsp;account&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CloudStorageAccount(credentials,&nbsp;<span class="cs__keyword">true</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;client&nbsp;=&nbsp;account.CreateCloudTableClient();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;table&nbsp;=&nbsp;client.GetTableReference(tableName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SharedAccessTablePolicy&nbsp;policy&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SharedAccessTablePolicy()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SharedAccessExpiryTime&nbsp;=&nbsp;DateTime.UtcNow.AddMinutes(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">300.00</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Permissions&nbsp;=&nbsp;SharedAccessTablePermissions.Add&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;SharedAccessTablePermissions.Query&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;SharedAccessTablePermissions.Update&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;SharedAccessTablePermissions.Delete&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;sasToken&nbsp;=&nbsp;table.GetSharedAccessSignature(policy,&nbsp;<span class="cs__keyword">null</span>,&nbsp;partitionKey,&nbsp;<span class="cs__keyword">null</span>,&nbsp;partitionKey,&nbsp;<span class="cs__keyword">null</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;sasToken;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
<h3><span lang="EN-US">How to get SAS from client?</span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">static void Main(string[] args)
        {

            string partitionKey = &quot;&lt;Partition Key&gt;&quot;;
            

            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = &quot;application/x-www-form-urlencoded&quot;;
                var data = &quot;=&quot;&#43;partitionKey;
                var result = client.UploadString(&quot;http://localhost:32618/api/SASGenerater&quot;, &quot;POST&quot;, data);
                Console.WriteLine(string.Format(&quot;Your SAS token is:{0}&quot;,result));
            }
            Console.ReadLine();

        }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;partitionKey&nbsp;=&nbsp;<span class="cs__string">&quot;&lt;Partition&nbsp;Key&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;WebClient())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;client.Headers[HttpRequestHeader.ContentType]&nbsp;=&nbsp;<span class="cs__string">&quot;application/x-www-form-urlencoded&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;data&nbsp;=&nbsp;<span class="cs__string">&quot;=&quot;</span>&#43;partitionKey;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;result&nbsp;=&nbsp;client.UploadString(<span class="cs__string">&quot;http://localhost:32618/api/SASGenerater&quot;</span>,&nbsp;<span class="cs__string">&quot;POST&quot;</span>,&nbsp;data);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;Your&nbsp;SAS&nbsp;token&nbsp;is:{0}&quot;</span>,result));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h2><span lang="EN-US">More Information</span></h2>
<p class="MsoListParagraph" style="text-indent:5.0pt"><span lang="EN-US" style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US"><a href="http://blogs.msdn.com/b/windowsazurestorage/archive/2012/06/12/introducing-table-sas-shared-access-signature-queue-sas-and-update-to-blob-sas.aspx">Introducing Table SAS (Shared Access Signature), Queue SAS and
 update to Blob SAS</a></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
