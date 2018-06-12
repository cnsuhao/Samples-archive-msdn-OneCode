# Dynamic TableServiceEntity for Azure Table storage
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Azure
## IsPublished
* True
## ModifiedDate
* 2013-06-13 10:26:32
## Description

<h1><span lang="EN-US">Define Azure table properties at the run time <span style="">
&nbsp;</span>(CSAzureDynamicTableEntity)</span></h1>
<h2><span lang="EN-US">Introduction</span></h2>
<h2><span lang="EN-US">Building the Sample</span></h2>
<p class="Normal"><span lang="EN-US">This sample requires you install the Azure storage package on Nuget</span></p>
<p class="Normal"><span lang="EN-US">.</span></p>
<p class="Normal"><span lang="EN" style="font-size:15.0pt; line-height:115%; font-family:&quot;Lucida Console&quot;; color:#E2E2E2; border:solid silver 3.0pt; padding:11.0pt; background:#202020">PM&gt; Install-Package WindowsAzure.Storage</span></p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><span lang="EN-US">And change the connectionString to your own.</span></p>
<h2><span lang="EN-US">Running the Sample</span></h2>
<p class="Normal"><span lang="EN-US">Press Ctrl&#43;F5 to run the sample.</span></p>
<p class="Normal"><span lang="EN-US">You will get this:</span></p>
<p class="Normal"><span lang="EN-US"><span style=""><img src="/site/view/file/84456/1/image.png" alt="" width="576" height="380" align="middle">
</span></span></p>
<p class="Normal"><span lang="EN-US">Then you can open your Table storage and you will see:</span></p>
<p class="Normal"><span lang="EN-US" style=""><img src="/site/view/file/84457/1/image.png" alt="" width="576" height="37" align="middle">
</span></p>
<p class="Normal"><i style=""><span lang="EN-US">Please notice that, we don&#39;t declare Id and IsRead properties in this project, but no error happens. This is because table storage is a flexible storage. If we want to use it more flexibly, define the property
 at the run time is a good choice. </span></i></p>
<h2><span lang="EN-US">Using the Code</span></h2>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt"><span lang="EN-US" style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Create a console application, name it CSAzureDynamicTalbeEntity.</span></p>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt"><span lang="EN-US" style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Manage the nugget to get the latest Azure.Storage package.</span></p>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt"><span lang="EN-US" style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Create a new class: DynamicObjectTalbeEntity.cs. This entity inherits DynamicObject class and implements ITalbeEntity interface. So you can use it as an Azure table entity, and add properties at the run time.</span></p>
<h3><span lang="EN-US">The following code snippet implements the ITableEntity</span></h3>
<h3><span lang="EN-US">The following code snippet overrides DynamicObject's Class.</span></h3>
<p class="Normal" style="margin-left:18.0pt"><span lang="EN-US"></span></p>
<p class="MsoNormal"><span lang="EN-US"></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
