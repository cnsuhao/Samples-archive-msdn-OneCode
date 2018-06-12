# How to use Windows Azure Mobile Services to operate Azure blob storage from WP
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* Windows Phone
* Windows Phone Development
## Topics
* Mobile Services
## IsPublished
* True
## ModifiedDate
* 2015-02-03 07:11:41
## Description

<h1>
<hr>
<div><a href="http://blogs.msdn.com/b/onecode"><img src="http://bit.ly/onecodesampletopbanner" alt=""></a></div>
</h1>
<h1><strong>How to upload images in Windows Phone to Windows Azure blob storage</strong></h1>
<h2><strong>Introduction</strong></h2>
<p>This demonstrates how to upload your files in <strong>Windows Phone</strong> such as images to the cloud using<strong> Windows Azure Blob Storage</strong>.&nbsp;It will walk you through how to generate a&nbsp;<em>Shared Access Signature</em>&nbsp;using&nbsp;Windows
 Azure Mobile Services&nbsp;and then show how to upload that Blob using the&nbsp;<em>Windows Azure Storage Client Library</em>. In this example we focus on capturing and uploading images. Using the same approach you can upload any binary data to Windows Azure
 Blob Storage.<strong>&nbsp;</strong></p>
<h2><strong>Building the Sample</strong></h2>
<p>Follow these steps to set up the sample.</p>
<ol>
<li>Create a new&nbsp;<strong>Storage Account</strong>&nbsp;from the Windows Azure Management Portal.
</li></ol>
<p>To do this, follow the instructions in&nbsp;<a href="http://www.windowsazure.com/en-us/manage/services/storage/how-to-create-a-storage-account/">How To Create a Storage Account</a>.</p>
<p>Get the&nbsp;<strong>Storage Account Keys</strong>. Browse to your storage account dashboard and click&nbsp;<strong>Manage Access Keys</strong>&nbsp;on the bottom bar.</p>
<p>&nbsp;<img id="132741" src="/site/view/file/132741/1/image001.png" alt="" width="200" height="60"></p>
<p>Copy the&nbsp;<strong>Storage Account Name</strong>&nbsp;and&nbsp;<strong>Primary Access Key</strong>&nbsp;values.</p>
<p>&nbsp;<img id="132742" src="/site/view/file/132742/1/image002.png" alt="" width="551" height="457"></p>
<p><span style="font-size:10px">&nbsp; &nbsp; 2.&nbsp;</span><span style="font-size:10px">Create a new&nbsp;</span><strong style="font-size:10px">Mobile Service</strong><span style="font-size:10px">&nbsp;from the Windows Azure Management Portal.</span></p>
<p>To do this, log in to the&nbsp;<a href="https://manage.windowsazure.com/">Windows Azure Management Portal</a>, navigate to Mobile Services and click&nbsp;<strong>New</strong>.</p>
<p>&nbsp;<img id="132743" src="/site/view/file/132743/1/image003.png" alt="" width="133" height="57"></p>
<p><span lang="EN-US">Expand<span>&nbsp;</span><strong>Compute | Mobile Service</strong>, then click<span>&nbsp;</span><strong>Create</strong>.</span></p>
<p><span lang="EN-US">In the<span>&nbsp;</span><strong>Create a Mobile Service</strong><span>&nbsp;</span>page, type a subdomain name for the new mobile service in the<span>&nbsp;</span><strong>URL</strong><span>&nbsp;</span>textbox (e.g:<em>mypicturesservice</em>)
 and wait for name verification. Once the name verification is completed, select<span>&nbsp;</span><em>Create a new SQL Database</em><span>&nbsp;</span>in the<span>&nbsp;</span><strong>Database</strong><span>&nbsp;</span>dropdown list and click the right arrow
 button to go to the next page.</span></p>
<p>&nbsp;<img id="132744" src="/site/view/file/132744/1/image004.png" alt="" width="680" height="450" style="border:1px solid black"></p>
<p><span lang="EN-US">This displays the<span>&nbsp;</span><strong>Specify database settings</strong><span>&nbsp;</span>page.</span></p>
<p><strong><span lang="EN-US">Note:</span></strong><span><span lang="EN-US">&nbsp;</span></span><span lang="EN-US">As part of this sample, you create a new SQL database instance and server. You can reuse this new database and administer it as you would with
 any other SQL database instance. If you already have a database in the same region as the new mobile service, you can choose<span>&nbsp;</span><em>Use existing Database</em><span>&nbsp;</span>and then select that database. The use of a database in a different
 region is not recommended because of additional bandwidth costs and higher latencies.</span></p>
<p><span lang="EN-US">In<span>&nbsp;</span><strong>Name</strong>, type the name of the new database. In<span>&nbsp;</span><strong>Server Login Name</strong>, specify the administrator login name for the new SQL database server, type and confirm the password,
 and click the check button to complete the process.</span></p>
<p>&nbsp;<img id="132745" src="/site/view/file/132745/1/image005.png" alt="" width="680" height="450" style="border:1px solid black"></p>
<p>You have now created a new mobile service that can be used by your mobile apps.</p>
<p><span style="font-size:10px">&nbsp; &nbsp; 3.&nbsp;</span><span style="font-size:10px">Import your Windows Azure subscription to Visual Studio.</span></p>
<p><strong>Note:</strong>&nbsp;If you already imported the subscription to Visual Studio you can skip this step.</p>
<p>In&nbsp;<strong>Server Explorer</strong>, right click on the&nbsp;<strong>Windows Azure</strong>&nbsp;node and select&nbsp;<strong>Import Subscriptions...</strong>.</p>
<p>&nbsp;<img id="132747" src="/site/view/file/132747/1/image007.png" alt="" width="383" height="262"></p>
<p>Click on&nbsp;<strong>Download subscription file</strong>, log in to your windows Azure account (if required) and click
<strong>Save</strong> when your browser requests to save the file.</p>
<p>&nbsp;<img id="132748" src="/site/view/file/132748/1/image008.png" alt="" width="550" height="206"></p>
<p><strong><span lang="EN-US">Note:</span></strong><span><span lang="EN-US">&nbsp;</span></span><span lang="EN-US">The login window is displayed in the browser, which may be behind your Visual Studio window. Remember to make a note of where you saved the downloaded
 .publishsettings file.</span></p>
<p><span lang="EN-US">Click<span>&nbsp;</span><strong>Browse</strong>, navigate to the location where you saved the .publishsettings file, select the file, then click<span>&nbsp;</span><strong>Open</strong><span>&nbsp;</span>and then
<strong>Import</strong>. Visual Studio imports the data needed to connect to your Windows Azure subscription.</span></p>
<p>&nbsp;<img id="132749" src="/site/view/file/132749/1/image009.png" alt="" width="550" height="206"></p>
<p><strong><span lang="EN-US">Security Note:</span></strong><span><span lang="EN-US">&nbsp;</span></span><span lang="EN-US">After importing the publish settings, consider deleting the downloaded .publishsettings file as it contains information that can be used
 by others to access your account. Secure the file if you plan to keep it for use in other connected app projects.</span></p>
<p><span style="font-size:10px">&nbsp; &nbsp; 4. Create a table named&nbsp;</span><strong style="font-size:10px">Picture</strong><span style="font-size:10px">.</span></p>
<p>Go to Visual Studio. Open Server Explorer, expand&nbsp;<strong>Mobile Services</strong>&nbsp;under&nbsp;<strong>Windows Azure</strong>, right-click your mobile service and select&nbsp;<strong>Create Table...</strong>.</p>
<p>&nbsp;<img id="132750" src="/site/view/file/132750/1/image010.png" alt="" width="447" height="218"></p>
<p>Create a new table named&nbsp;<strong>Picture</strong>&nbsp;and set the permissions for Insert, Update, Delete, and Read to&nbsp;<strong>&quot;Anybody with the application key&quot;</strong>.</p>
<p><span style="font-size:10px">&nbsp; &nbsp; 5. Expand the&nbsp;</span><strong style="font-size:10px">Picture</strong><span style="font-size:10px">&nbsp;table you just created. Then right-click the&nbsp;</span><strong style="font-size:10px">insert.js</strong><span style="font-size:10px">&nbsp;script
 file and select&nbsp;</span><strong style="font-size:10px">Edit script</strong><span style="font-size:10px">.</span></p>
<p>&nbsp;<img id="132751" src="/site/view/file/132751/1/image011.png" alt="" width="320" height="179"></p>
<p><span lang="EN-US">The script opens in an editor window. Here you can insert a JavaScript function that is going to be invoked whenever someone performs an insert (the item to be inserted is passed as a parameter).</span></p>
<p><span lang="EN-US">Update the content of the file with the code below in order to obtain the Shared Access Signature (SAS) for the pictures you will upload later. Replace the<span>&nbsp;</span><strong>storage account name</strong><span>&nbsp;</span>and<span>&nbsp;</span><strong>key</strong><span>&nbsp;</span>placeholders
 with your<span>&nbsp;</span><strong>Windows Azure Storage Account</strong><span>&nbsp;</span>credentials.</span></p>
<pre><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>JavaScript</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">js</span><pre class="hidden">var azure = require('azure');
var qs = require('querystring');
 
function insert(item, user, request) {
    var accountName = '&lt;replace with your storage account name&gt;';
    var accountKey = '&lt;replace with your storage account key&gt;';
 
    var host = accountName &#43; '.blob.core.windows.net';
    var containerName = 'mypictures';
    var pictureRelativePath = '/' &#43; containerName &#43; '/' &#43; item.fileName;
    var pictureThumbnailRelativePath = '/' &#43; containerName &#43; '/' &#43; item.thumbnailFileName;
 
    // Create the container if it does not exist
    // Use public read access for the blobs, and the SAS to upload        
    var blobService = azure.createBlobService(accountName, accountKey, host);
    blobService.createContainerIfNotExists(containerName, { publicAccessLevel: 'blob' }, function (error) {
        if (!error) {
            // Container exists now define a policy for write access
            // that starts immediately and expires in 5 mins
            var sharedAccessPolicy = createAccessPolicy();
 
            // Create the blobs urls with the SAS
            item.imageurl = createResourceURLWithSAS(accountName, accountKey, pictureRelativePath, sharedAccessPolicy, host);
            item.thumbnailurl = createResourceURLWithSAS(accountName, accountKey, pictureThumbnailRelativePath, sharedAccessPolicy, host);
        }
        else {
            console.error(error);
        }
 
        request.execute();
    });
}
 
function createResourceURLWithSAS(accountName, accountKey, blobRelativePath, sharedAccessPolicy, host) {
    // Generate the SAS for your BLOB
    var sasQueryString = getSAS(accountName,
                        accountKey,
                        blobRelativePath,
                        azure.Constants.BlobConstants.ResourceTypes.BLOB,
                        sharedAccessPolicy);
 
    // Full path for resource with SAS
    return 'https://' &#43; host &#43; blobRelativePath &#43; '?' &#43; sasQueryString;
}
 
function createAccessPolicy() {
    return {
        AccessPolicy: {
            Permissions: azure.Constants.BlobConstants.SharedAccessPermissions.WRITE,
            // Start: use for start time in future, beware of server time skew 
            Expiry: formatDate(new Date(new Date().getTime() &#43; 5 * 60 * 1000)) // 5 minutes from now
        }
    };
}
 
function getSAS(accountName, accountKey, path, resourceType, sharedAccessPolicy) {
    return qs.encode(new azure.SharedAccessSignature(accountName, accountKey)
                                    .generateSignedQueryString(path, {}, resourceType, sharedAccessPolicy));
}
 
function formatDate(date) {
    var raw = date.toJSON();
    // Blob service does not like milliseconds on the end of the time so strip
    return raw.substr(0, raw.lastIndexOf('.')) &#43; 'Z';
}</pre>
<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;azure&nbsp;=&nbsp;require(<span class="js__string">'azure'</span>);&nbsp;
<span class="js__statement">var</span>&nbsp;qs&nbsp;=&nbsp;require(<span class="js__string">'querystring'</span>);&nbsp;
&nbsp;&nbsp;
<span class="js__operator">function</span>&nbsp;insert(item,&nbsp;user,&nbsp;request)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;accountName&nbsp;=&nbsp;<span class="js__string">'&lt;replace&nbsp;with&nbsp;your&nbsp;storage&nbsp;account&nbsp;name&gt;'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;accountKey&nbsp;=&nbsp;<span class="js__string">'&lt;replace&nbsp;with&nbsp;your&nbsp;storage&nbsp;account&nbsp;key&gt;'</span>;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;host&nbsp;=&nbsp;accountName&nbsp;&#43;&nbsp;<span class="js__string">'.blob.core.windows.net'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;containerName&nbsp;=&nbsp;<span class="js__string">'mypictures'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;pictureRelativePath&nbsp;=&nbsp;<span class="js__string">'/'</span>&nbsp;&#43;&nbsp;containerName&nbsp;&#43;&nbsp;<span class="js__string">'/'</span>&nbsp;&#43;&nbsp;item.fileName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;pictureThumbnailRelativePath&nbsp;=&nbsp;<span class="js__string">'/'</span>&nbsp;&#43;&nbsp;containerName&nbsp;&#43;&nbsp;<span class="js__string">'/'</span>&nbsp;&#43;&nbsp;item.thumbnailFileName;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Create&nbsp;the&nbsp;container&nbsp;if&nbsp;it&nbsp;does&nbsp;not&nbsp;exist</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Use&nbsp;public&nbsp;read&nbsp;access&nbsp;for&nbsp;the&nbsp;blobs,&nbsp;and&nbsp;the&nbsp;SAS&nbsp;to&nbsp;upload&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;blobService&nbsp;=&nbsp;azure.createBlobService(accountName,&nbsp;accountKey,&nbsp;host);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;blobService.createContainerIfNotExists(containerName,&nbsp;<span class="js__brace">{</span>&nbsp;publicAccessLevel:&nbsp;<span class="js__string">'blob'</span>&nbsp;<span class="js__brace">}</span>,&nbsp;<span class="js__operator">function</span>&nbsp;(error)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!error)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Container&nbsp;exists&nbsp;now&nbsp;define&nbsp;a&nbsp;policy&nbsp;for&nbsp;write&nbsp;access</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;that&nbsp;starts&nbsp;immediately&nbsp;and&nbsp;expires&nbsp;in&nbsp;5&nbsp;mins</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;sharedAccessPolicy&nbsp;=&nbsp;createAccessPolicy();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Create&nbsp;the&nbsp;blobs&nbsp;urls&nbsp;with&nbsp;the&nbsp;SAS</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;item.imageurl&nbsp;=&nbsp;createResourceURLWithSAS(accountName,&nbsp;accountKey,&nbsp;pictureRelativePath,&nbsp;sharedAccessPolicy,&nbsp;host);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;item.thumbnailurl&nbsp;=&nbsp;createResourceURLWithSAS(accountName,&nbsp;accountKey,&nbsp;pictureThumbnailRelativePath,&nbsp;sharedAccessPolicy,&nbsp;host);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;console.error(error);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.execute();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
<span class="js__operator">function</span>&nbsp;createResourceURLWithSAS(accountName,&nbsp;accountKey,&nbsp;blobRelativePath,&nbsp;sharedAccessPolicy,&nbsp;host)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Generate&nbsp;the&nbsp;SAS&nbsp;for&nbsp;your&nbsp;BLOB</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;sasQueryString&nbsp;=&nbsp;getSAS(accountName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;accountKey,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blobRelativePath,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;azure.Constants.BlobConstants.ResourceTypes.BLOB,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sharedAccessPolicy);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Full&nbsp;path&nbsp;for&nbsp;resource&nbsp;with&nbsp;SAS</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__string">'https://'</span>&nbsp;&#43;&nbsp;host&nbsp;&#43;&nbsp;blobRelativePath&nbsp;&#43;&nbsp;<span class="js__string">'?'</span>&nbsp;&#43;&nbsp;sasQueryString;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
<span class="js__operator">function</span>&nbsp;createAccessPolicy()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AccessPolicy:&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Permissions:&nbsp;azure.Constants.BlobConstants.SharedAccessPermissions.WRITE,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Start:&nbsp;use&nbsp;for&nbsp;start&nbsp;time&nbsp;in&nbsp;future,&nbsp;beware&nbsp;of&nbsp;server&nbsp;time&nbsp;skew&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Expiry:&nbsp;formatDate(<span class="js__operator">new</span>&nbsp;<span class="js__object">Date</span>(<span class="js__operator">new</span>&nbsp;<span class="js__object">Date</span>().getTime()&nbsp;&#43;&nbsp;<span class="js__num">5</span>&nbsp;*&nbsp;<span class="js__num">60</span>&nbsp;*&nbsp;<span class="js__num">1000</span>))&nbsp;<span class="js__sl_comment">//&nbsp;5&nbsp;minutes&nbsp;from&nbsp;now</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
<span class="js__operator">function</span>&nbsp;getSAS(accountName,&nbsp;accountKey,&nbsp;path,&nbsp;resourceType,&nbsp;sharedAccessPolicy)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;qs.encode(<span class="js__operator">new</span>&nbsp;azure.SharedAccessSignature(accountName,&nbsp;accountKey)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.generateSignedQueryString(path,&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>,&nbsp;resourceType,&nbsp;sharedAccessPolicy));&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
<span class="js__operator">function</span>&nbsp;formatDate(date)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;raw&nbsp;=&nbsp;date.toJSON();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Blob&nbsp;service&nbsp;does&nbsp;not&nbsp;like&nbsp;milliseconds&nbsp;on&nbsp;the&nbsp;end&nbsp;of&nbsp;the&nbsp;time&nbsp;so&nbsp;strip</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;raw.substr(<span class="js__num">0</span>,&nbsp;raw.lastIndexOf(<span class="js__string">'.'</span>))&nbsp;&#43;&nbsp;<span class="js__string">'Z'</span>;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode"><span style="font-size:10px"> 6. Connect the Windows phone to Mobile Services.</span></div>
</pre>
<p>Get the&nbsp;<strong>Mobile Service URL</strong>&nbsp;and&nbsp;<strong>Mobile Service Key</strong>&nbsp;values. Browse to your Mobile Service dashboard, copy the service URL and click&nbsp;<strong>Manage Keys</strong>&nbsp;on the bottom bar.</p>
<p>&nbsp;<img id="132752" src="/site/view/file/132752/1/image012.png" alt="" width="945" height="616" style="border:1px solid black"></p>
<p>Now copy the&nbsp;<strong>Application Key</strong>&nbsp;value.</p>
<p>&nbsp;<img id="132753" src="/site/view/file/132753/1/image013.png" alt="" width="500" height="349" style="border:1px solid black"></p>
<p>In Visual Studio, open the&nbsp;<strong>Windows Store</strong>&nbsp;app provided in this sample, open the&nbsp;<strong>App.xaml.cs</strong>&nbsp;file in the solution and replace the placeholders&nbsp;<strong>{mobile-service-url}</strong>&nbsp;and&nbsp;<strong>{mobile-service-key}</strong>&nbsp;with
 the values obtained in the previous steps.</p>
<p><span style="font-size:10px">&nbsp; &nbsp; 7. Use the Windows Azure Storage Client Library to upload blobs.</span></p>
<p>In Visual Studio, install the&nbsp;<a href="http://www.nuget.org/packages/WindowsAzure.Storage-Preview">WindowsAzure.Storage-Preview</a>&nbsp;NuGet package in the project using the Package Manage Console directly within Visual Studio</p>
<div>
<pre>Install-Package&nbsp;WindowsAzure.Storage-Preview&nbsp;-Pre</pre>
</div>
<h2><strong>Running the Sample</strong></h2>
<p><strong>&nbsp;</strong><span style="font-size:10px">&nbsp; &nbsp; 1. In Visual Studio, press&nbsp;</span><strong style="font-size:10px">F5</strong><span style="font-size:10px">&nbsp;to launch the application.</span></p>
<p><strong>Note:</strong>&nbsp;If this is the first time you run the app, you may get an error message saying that the build restored the NuGet packages. If that is the case, run the app one more time to include those packages in the build (for more information,
 see&nbsp;<a href="http://go.microsoft.com/fwlink/?LinkID=317568">http://go.microsoft.com/fwlink/?LinkID=317568</a>).</p>
<p><span style="font-size:10px">&nbsp; &nbsp; 2. In the main page, click the&nbsp;</span><strong style="font-size:10px">Upload
</strong><strong style="font-size:10px">button</strong><span style="font-size:10px">.</span></p>
<p><span style="font-size:10px">&nbsp; &nbsp; 3. In the upload page, select an image and provide the required information. Then, click or tap the&nbsp;</span><strong style="font-size:10px">Upload
</strong><span style="font-size:10px">button.</span></p>
<p>&nbsp;<img id="132754" src="/site/view/file/132754/1/image014.png" alt="" width="46" height="42"></p>
<p>&nbsp; &nbsp; 4.&nbsp; In the upload page select a page and provide the required information. Then, click or tap the&nbsp;<strong>Upload
</strong>button.</p>
<p>&nbsp;<img id="132755" src="/site/view/file/132755/1/image015.jpg" alt="" width="332" height="599"></p>
<p>&nbsp;</p>
<p>Now you can find your Picture is shown in the Main Page.</p>
<p>&nbsp;<img id="132756" src="/site/view/file/132756/1/image016.png" alt="" width="273" height="79"></p>
<p><span style="font-size:10px">&nbsp; &nbsp; 5. Switch to the Windows Azure Management Portal, and select the storage account created for this sample. In the container tab you can find this blob, copy the URL, you can download it from blob storage now.</span></p>
<p>&nbsp;<img id="132758" src="/site/view/file/132758/1/image018.jpg" alt="" width="576" height="95"></p>
