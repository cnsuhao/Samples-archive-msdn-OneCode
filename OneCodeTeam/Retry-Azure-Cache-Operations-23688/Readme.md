# Retry Azure Cache Operations
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* AppFabric
* Cache
## IsPublished
* True
## ModifiedDate
* 2013-07-03 11:21:52
## Description

<h1><span lang="EN-US">Retry Azure Cache Operations (<span class="SpellE">CSAzureRetryCache</span>)</span></h1>
<h2><span lang="EN-US">Introduction</span></h2>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span lang="EN-US" style="color:black">When using cloud based services, it is very common to receive exceptions similar to below while performing cache operations such as get, put. These are called transient errors.<span style="">&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span lang="EN-US" style="color:black">Developer is required to implement retry logic to successfully complete their cache operations.
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span lang="EN-US" style="color:black"></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span class="SpellE"><i><span lang="EN-US" style="color:black">ErrorCode</span></i></span><i><span lang="EN-US" style="color:black">&lt;ERRCA0017&gt;<span class="GramE">:<span class="SpellE">SubStatus</span></span>&lt;ES0006&gt;:There is a temporary failure.
 Please retry later. (One or more specified cache servers are unavailable, which could be caused by busy network or servers. For on-premises cache clusters, also verify the following conditions. Ensure that security permission has been granted for this client
 account, and check that the <span class="SpellE">AppFabric</span> Caching Service is allowed through the firewall on all cache hosts. Also the
<span class="SpellE">MaxBufferSize</span> on the server must be greater than or equal to the serialized object size sent from the client.)
</span></i></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span lang="EN-US" style="color:black"><span style="">&nbsp;</span> </span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span lang="EN-US" style="color:black">This sample implements retry logic to protect the application from crashing in the event of transient errors. This sample uses Transient Fault Handling Application Block to implement retry mechanism
</span></p>
<h2><span lang="EN-US">Building the Sample</span></h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span lang="EN-US" style=""><span style="">1)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Ensure Windows Azure SDK 2.0 is installed on the machine.
<a href="http://www.windowsazure.com/en-us/develop/downloads/">Download Link</a></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span lang="EN-US" style=""><span style="">2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Modify the highlighted <span class="SpellE">
cachenamespace</span>, <span class="SpellE">autherizataionInfo</span> attributes under
<span class="SpellE">DataCacheClient</span> section of <span class="SpellE">web.config</span> and provide values of your own cache namespace and Authentication Token. Steps to obtain the value of authentication token, cache namespace value can be found
<a href="http://msdn.microsoft.com/en-us/library/windowsazure/gg278346.aspx">here</a></span></p>
<h2><span lang="EN-US">Running the Sample</span></h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span lang="EN-US" style="font-family:Symbol; color:black"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="color:black">Open the Project in VS 2012 and run it in debug or release mode
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; text-indent:5.0pt; line-height:normal; text-autospace:none">
<span lang="EN-US" style="font-family:Symbol; color:black"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="color:black">Click on &quot;Add <span class="GramE">
To</span> Cache&quot; button to add a string object to Azure cache. Up on successful operation, &quot;</span><span lang="EN-US" style="color:black">String object added to cache!</span><span lang="EN-US" style="color:black">&quot; message will be printed on
 the webpage</span><span lang="EN-US" style="color:black"> </span></p>
<p class="MsoListParagraphCxSpLast" style="margin-bottom:0cm; margin-bottom:.0001pt; text-indent:5.0pt; line-height:normal; text-autospace:none">
<span lang="EN-US" style="font-family:Symbol; color:black"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="color:black">Click on &quot;Read <span class="GramE">
From</span> Cache&quot; button to read the string object from Azure Cache. Up on successful operation, value of the string object stored in Azure cache will be printed on the webpage. By default it will be &quot;</span><span lang="EN-US" style="color:black">My
 Cache</span><span lang="EN-US" style="color:black">&quot; (if no changes are made to code)</span><span lang="EN-US" style="color:black">
</span></p>
<h2><span lang="EN-US">Using the Code</span></h2>
<p class="MsoListParagraph" style="text-indent:5.0pt"><span lang="EN-US" style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="">Define required objects globally, so that they are available for all code paths with in the module.
</span></p>
<p class="MsoListParagraph" style="text-indent:5.0pt"><span lang="EN-US" style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="">This method configures strategies, policies, actions required for performing retries.
</span></p>
<p class="MsoListParagraph" style="text-indent:5.0pt"><span lang="EN-US" style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="">Create the Cache Object using the
<span class="SpellE">DataCacheClient</span> configuration specified in <span class="SpellE">
web.config</span> and perform initial setup required for Azure cache retries </span>
</p>
<p class="MsoListParagraph" style="text-indent:5.0pt"><span lang="EN-US" style="font-family:&quot;Cambria&quot;,&quot;serif&quot;"><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Add string object to Cache on a button click event and perform retries in case of transient failures</span><span lang="EN-US" style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">
</span></p>
<p class="MsoListParagraph" style="text-indent:5.0pt"><span lang="EN-US" style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Read the value of string object stored in Azure Cache on a button click event and perform retries in case of transient failures</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span lang="EN-US" style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span> </span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span lang="EN-US" style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<h2><span lang="EN-US">More Information</span></h2>
<p class="MsoNormal"><span lang="EN-US">Refer to below blog entry for more information</span></p>
<p class="MsoNormal"><span lang="EN-US"><a href="http://blogs.msdn.com/b/narahari/archive/2011/12/29/implementing-retry-logic-for-azure-caching-applications-made-easy.aspx">http://blogs.msdn.com/b/narahari/archive/2011/12/29/implementing-retry-logic-for-azure-caching-applications-made-easy.aspx</a></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
