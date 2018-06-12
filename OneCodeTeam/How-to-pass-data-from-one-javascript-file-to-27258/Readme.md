# How to pass data from one javascript file to another in windows 8 store app
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows 8
* Windows Store app Development
## Topics
* pass data
* between js file
* Widnwos store app
## IsPublished
* True
## ModifiedDate
* 2014-02-16 08:18:24
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<h1>How to share data between Javascript fils in Windows Store app (JSWindowsStoreAppBindingLocalXml)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to share data between Javascript files.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:.5in; text-indent:-.25in; line-height:12.75pt">
<span style="color:black">1.</span><span style="font-size:7.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:black">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="color:black">Start Visual Studio 2013 and select File &gt; Open &gt; Project/Solution.
</span></p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:.5in; text-indent:-.25in; line-height:12.75pt">
<span style="color:black">2.</span><span style="font-size:7.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:black">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="color:black">Go to the directory in which you download the sample. Go to the directory
 named for<span>&nbsp;&nbsp; </span>the sample, and double-click the Microsoft Visual Studio Solution (.sln) file.
</span></p>
<p class="MsoNormal" style="margin-left:.5in; text-indent:-.25in; line-height:12.75pt">
<span style="color:black">3.</span><span style="font-size:7.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:black">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="color:black">Press F7 or use Build &gt; Build Solution to build the sample.
</span></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press F5 to debug the app, this screen will display.</p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/108776/1/image.png" alt="" width="576" height="329" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>Data in the WinJS.UI.ListView are come from another javascript file.
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">The code below shows how to expose data to public for other Javascript files to use.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">(function () {
&nbsp;&nbsp;&nbsp; &quot;use steict&quot;


&nbsp;&nbsp;&nbsp; // Define array variable
&nbsp;&nbsp;&nbsp; var sampledataarray = [
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; { name: &quot;Tommy&quot;, age: &quot;24&quot;, sex: &quot;male&quot; },
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; { name: &quot;Lily&quot;, age: &quot;22&quot;, sex: &quot;female&quot; },
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; { name: &quot;Jone&quot;, age: &quot;29&quot;, sex: &quot;male&quot; },
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; { name: &quot;Jack&quot;, age: &quot;32&quot;, sex: &quot;male&quot; },
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; { name: &quot;Allen&quot;, age: &quot;25&quot;, sex: &quot;male&quot; },
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; { name: &quot;Lisa&quot;, age: &quot;21&quot;, sex: &quot;female&quot; },
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; { name: &quot;Jones&quot;, age: &quot;22&quot;, sex: &quot;female&quot; },
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; { name: &quot;Carter&quot;, age: &quot;26&quot;, sex: &quot;male&quot; }&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;];
&nbsp;&nbsp;&nbsp; var datalist = new WinJS.Binding.List(sampledataarray);


&nbsp;&nbsp;&nbsp; var publicMembers =
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; itemList: datalist
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; };
&nbsp;&nbsp;&nbsp; WinJS.Namespace.define(&quot;JSWindowsStoreAppShareDataBetweenJsFiles&quot;, publicMembers);
})();

</pre>
<pre class="js" id="codePreview">(function () {
&nbsp;&nbsp;&nbsp; &quot;use steict&quot;


&nbsp;&nbsp;&nbsp; // Define array variable
&nbsp;&nbsp;&nbsp; var sampledataarray = [
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; { name: &quot;Tommy&quot;, age: &quot;24&quot;, sex: &quot;male&quot; },
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; { name: &quot;Lily&quot;, age: &quot;22&quot;, sex: &quot;female&quot; },
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; { name: &quot;Jone&quot;, age: &quot;29&quot;, sex: &quot;male&quot; },
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; { name: &quot;Jack&quot;, age: &quot;32&quot;, sex: &quot;male&quot; },
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; { name: &quot;Allen&quot;, age: &quot;25&quot;, sex: &quot;male&quot; },
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; { name: &quot;Lisa&quot;, age: &quot;21&quot;, sex: &quot;female&quot; },
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; { name: &quot;Jones&quot;, age: &quot;22&quot;, sex: &quot;female&quot; },
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; { name: &quot;Carter&quot;, age: &quot;26&quot;, sex: &quot;male&quot; }&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;];
&nbsp;&nbsp;&nbsp; var datalist = new WinJS.Binding.List(sampledataarray);


&nbsp;&nbsp;&nbsp; var publicMembers =
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; itemList: datalist
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; };
&nbsp;&nbsp;&nbsp; WinJS.Namespace.define(&quot;JSWindowsStoreAppShareDataBetweenJsFiles&quot;, publicMembers);
})();

</pre>
</div>
</div>
<p class="MsoNormal">The code below shows how to define the layout in html file.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">&lt;div id=&quot;contentGrid&quot;&gt;
    &lt;div id=&quot;mediumListTextTemplate&quot; data-win-control=&quot;WinJS.Binding.Template&quot;&gt;
        &lt;div class=&quot;mediumListTextItem&quot;&gt;
            &lt;div class=&quot;mediumListTextItem-Detail&quot;&gt;
                &lt;h2 data-win-bind=&quot;innerText: name&quot;&gt;&lt;/h2&gt;
                &lt;h2 data-win-bind=&quot;innerText: age&quot;&gt;&lt;/h2&gt;
                &lt;h2 data-win-bind=&quot;innerText: sex&quot;&gt;&lt;/h2&gt;
            &lt;/div&gt;
        &lt;/div&gt;
    &lt;/div&gt;
    &lt;div id=&quot;basicListView&quot;
        class=&quot;win-selectionstylefilled&quot;
        data-win-control=&quot;WinJS.UI.ListView&quot;
        data-win-options=&quot;{                 
    itemTemplate: mediumListTextTemplate, 
    selectionMode: 'none', 
    tapBehavior: 'none', 
    swipeBehavior: 'none', 
    layout: { type: WinJS.UI.GridLayout } 
}&quot; /&gt;
&lt;/div&gt;
</pre>
<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;contentGrid&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;mediumListTextTemplate&quot;</span>&nbsp;<span class="html__attr_name">data-win-control</span>=<span class="html__attr_value">&quot;WinJS.Binding.Template&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;mediumListTextItem&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;mediumListTextItem-Detail&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;h2</span>&nbsp;<span class="html__attr_name">data-win-bind</span>=<span class="html__attr_value">&quot;innerText:&nbsp;name&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/h2&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;h2</span>&nbsp;<span class="html__attr_name">data-win-bind</span>=<span class="html__attr_value">&quot;innerText:&nbsp;age&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/h2&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;h2</span>&nbsp;<span class="html__attr_name">data-win-bind</span>=<span class="html__attr_value">&quot;innerText:&nbsp;sex&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/h2&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;basicListView&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;win-selectionstylefilled&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__attr_name">data-win-control</span>=<span class="html__attr_value">&quot;WinJS.UI.ListView&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__attr_name">data-win-options</span>=<span class="html__attr_value">&quot;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;itemTemplate:&nbsp;mediumListTextTemplate,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;selectionMode:&nbsp;'none',&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;tapBehavior:&nbsp;'none',&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;swipeBehavior:&nbsp;'none',&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;layout:&nbsp;{&nbsp;type:&nbsp;WinJS.UI.GridLayout&nbsp;}&nbsp;&nbsp;
}&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<h2>More Information</h2>
<p class="MsoNormal">WinJS.UI.ListView object</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/br211837.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/br211837.aspx</a></p>
<p class="MsoNormal">ListView.itemDataSource property</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/hh700703.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/hh700703.aspx</a></p>
<p class="MsoNormal">WinJS.Binding.List object</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/hh700774.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/hh700774.aspx</a></p>
<p class="MsoNormal">WinJS.Namespace.define function</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/br212667.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/br212667.aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
