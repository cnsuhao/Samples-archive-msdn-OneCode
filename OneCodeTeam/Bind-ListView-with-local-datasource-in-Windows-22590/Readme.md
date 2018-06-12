# Bind ListView with local datasource in Windows Store apps
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows 8
* Windows Store app Development
## Topics
* listview databind
## IsPublished
* True
## ModifiedDate
* 2013-06-13 09:53:52
## Description

<h1>How to <span style="font-family:宋体">bind</span> local Xml file data to ListView in Windows Store app (JSWindowsStoreAppBindingLocalXml)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to bind local xml file data to WinJS.UI.ListView.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:0in; margin-left:.5in; margin-bottom:.0001pt; text-indent:-.25in; line-height:12.75pt">
<span style="color:black">1.</span><span style="font-size:7.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:black">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="color:black">Start Visual Studio 2012 and select File &gt; Open &gt; Project/Solution.
</span></p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:0in; margin-left:.5in; margin-bottom:.0001pt; text-indent:-.25in; line-height:12.75pt">
<span style="color:black">2.</span><span style="font-size:7.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:black">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="color:black">Go to the directory in which you download the sample. Go to the directory
 named for<span style="">&nbsp;&nbsp; </span>the sample, and double-click the Microsoft Visual Studio Solution (.sln) file.
</span></p>
<p class="MsoNormal" style="margin-left:.5in; text-indent:-.25in; line-height:12.75pt">
<span style="color:black">3.</span><span style="font-size:7.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:black">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="color:black">Press F7 or use Build &gt; Build Solution to build the sample.
</span></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press F5 to debug the app, this screen will display.</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/84226/1/image.png" alt="" width="576" height="327" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">Data in the WinJS.UI.ListView are come from a local xml file.
</span></p>
<p class="MsoListParagraphCxSpLast"></p>
<p class="MsoNormal"></p>
<h2>Using the Code</h2>
<p class="MsoNormal">The code below shows how to get the data from xml file with Javascript.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
var uri = new Windows.Foundation.Uri(&quot;ms-appx:///data.xml&quot;)
Windows.Storage.StorageFile.getFileFromApplicationUriAsync(uri).then(function (file) {
&nbsp;&nbsp;&nbsp; return Windows.Storage.FileIO.readTextAsync(file);
}).done(function (text) {
&nbsp;&nbsp;&nbsp; var xmlDoc = new Windows.Data.Xml.Dom.XmlDocument();
&nbsp;&nbsp;&nbsp; xmlDoc.loadXml(text);


&nbsp;&nbsp;&nbsp; var nodes = xmlDoc.selectNodes(&quot;//book&quot;);


&nbsp;&nbsp;&nbsp; var items = new Array();


&nbsp;&nbsp;&nbsp; nodes.forEach(function (val, idx, travObj) {


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var title = val.selectSingleNode(&quot;title&quot;).innerText;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var price = val.selectSingleNode(&quot;price&quot;).innerText;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var author = val.selectSingleNode(&quot;author&quot;).innerText;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var newItem = {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; title: &quot;Title: &quot; &#43; title,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; price: &quot;Price: &quot; &#43; price,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;author: &quot;Author: &quot; &#43; author
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; };
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; items.push(newItem);
&nbsp;&nbsp;&nbsp; });
&nbsp;&nbsp;&nbsp; var dataList = new WinJS.Binding.List(items);
&nbsp;&nbsp;&nbsp; basicListView.winControl.itemDataSource = dataList.dataSource;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
});

</pre>
<pre id="codePreview" class="js">
var uri = new Windows.Foundation.Uri(&quot;ms-appx:///data.xml&quot;)
Windows.Storage.StorageFile.getFileFromApplicationUriAsync(uri).then(function (file) {
&nbsp;&nbsp;&nbsp; return Windows.Storage.FileIO.readTextAsync(file);
}).done(function (text) {
&nbsp;&nbsp;&nbsp; var xmlDoc = new Windows.Data.Xml.Dom.XmlDocument();
&nbsp;&nbsp;&nbsp; xmlDoc.loadXml(text);


&nbsp;&nbsp;&nbsp; var nodes = xmlDoc.selectNodes(&quot;//book&quot;);


&nbsp;&nbsp;&nbsp; var items = new Array();


&nbsp;&nbsp;&nbsp; nodes.forEach(function (val, idx, travObj) {


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var title = val.selectSingleNode(&quot;title&quot;).innerText;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var price = val.selectSingleNode(&quot;price&quot;).innerText;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var author = val.selectSingleNode(&quot;author&quot;).innerText;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var newItem = {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; title: &quot;Title: &quot; &#43; title,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; price: &quot;Price: &quot; &#43; price,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;author: &quot;Author: &quot; &#43; author
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; };
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; items.push(newItem);
&nbsp;&nbsp;&nbsp; });
&nbsp;&nbsp;&nbsp; var dataList = new WinJS.Binding.List(items);
&nbsp;&nbsp;&nbsp; basicListView.winControl.itemDataSource = dataList.dataSource;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
});

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">The code below shows how to define the layout in html file.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
<div id="mediumListTextTemplate" style="">
&nbsp;&nbsp;&nbsp; <div class="mediumListTextItem">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <div class="mediumListTextItem-Detail">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <h2></h2>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <h2></h2>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <h2></h2>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </div>
&nbsp;&nbsp;&nbsp; </div>
</div>


<div id="basicListView"></div>

</pre>
<pre id="codePreview" class="html">
<div id="mediumListTextTemplate" style="">
&nbsp;&nbsp;&nbsp; <div class="mediumListTextItem">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <div class="mediumListTextItem-Detail">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <h2></h2>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <h2></h2>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <h2></h2>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </div>
&nbsp;&nbsp;&nbsp; </div>
</div>


<div id="basicListView"></div>

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal"><span class="SpellE">WinJS.UI.ListView</span> object</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/br211837.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/br211837.aspx</a></p>
<p class="MsoNormal"><span class="SpellE">ListView.itemDataSource</span> property</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/hh700703.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/hh700703.aspx</a></p>
<p class="MsoNormal"><span class="SpellE">WinJS.Binding.List</span> object</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/hh700774.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/hh700774.aspx</a></p>
<p class="MsoNormal"><span class="SpellE">StorageFile.GetFileFromApplicationUriAsync</span> |
<span class="SpellE">getFileFromApplicationUriAsync</span> method</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.storagefile.getfilefromapplicationuriasync.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.storagefile.getfilefromapplicationuriasync.aspx</a>
</p>
<p class="MsoNormal"></p>
<p class="MsoNormal"></p>
<p class="MsoNormal"></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
