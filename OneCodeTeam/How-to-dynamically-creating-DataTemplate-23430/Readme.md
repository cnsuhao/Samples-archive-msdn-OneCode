# How to dynamically creating DataTemplate
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows 8
* Windows Store app Development
## Topics
* DataTemplate
## IsPublished
* True
## ModifiedDate
* 2013-06-25 11:20:18
## Description

<h1>How to create DataTemplate dynamically in Windows Store app (CSWindowsStoreAppCreateDataTemplateDynamically)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to create DataTemplate dynamically in Windows Store apps. The GridView's ItemTemplate is created in code behind.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:0in; margin-left:.5in; margin-bottom:.0001pt; text-indent:-.25in; line-height:12.75pt">
<span style="color:black">1.</span><span style="font-size:7.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:black">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="color:black">Start Visual Studio 2012 and select File &gt; Open &gt; Project/Solution.
</span></p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:0in; margin-left:.5in; margin-bottom:.0001pt; text-indent:-.25in; line-height:12.75pt">
<span style="color:black">2.</span><span style="font-size:7.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:black">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="color:black">Go to the directory in which you download the sample. Go to the directory
 named for the sample, and double-click the Microsoft Visual Studio Solution (.sln) file.
</span></p>
<p class="MsoNormal" style="margin-left:.5in; text-indent:-.25in; line-height:12.75pt">
<span style="color:black">3.</span><span style="font-size:7.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:black">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="color:black">Press F7 or use Build &gt; Build Solution to build the sample.
</span></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press F5 to debug the app, this screen will display. The GridView's ItemTemplate is created in code behind.<span style="">
</span></p>
<p class="MsoListParagraphCxSpLast"><span style=""><img src="/site/view/file/86563/1/image.png" alt="" width="576" height="328" align="middle">
</span></p>
<p class="MsoNormal"></p>
<h2>Using the Code</h2>
<p class="MsoNormal">The code below shows how to create DataTemplate in code-behind and assign it to GridView control.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
StringBuilder sb = new StringBuilder();


sb.Append(&quot;&lt;DataTemplate xmlns=\&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation\&quot;&gt;&quot;);
sb.Append(&quot;&lt;Grid Width=\&quot;200\&quot; Height=\&quot;100\&quot;&gt;&quot;);
sb.Append(&quot;&lt;StackPanel&gt;&quot;);
sb.Append(&quot;&lt;StackPanel Orientation=\&quot;Horizontal\&quot; Margin=\&quot;3,3,0,3\&quot;&gt;&lt;TextBlock Text=\&quot;Name:\&quot; Style=\&quot;{StaticResource AppBodyTextStyle}\&quot; Margin=\&quot;0,0,5,0\&quot;/&gt;&lt;TextBlock Text=\&quot;{Binding Name}\&quot; Style=\&quot;{StaticResource AppBodyTextStyle}\&quot;/&gt;&lt;/StackPanel&gt;&quot;);
sb.Append(&quot;&lt;StackPanel Orientation=\&quot;Horizontal\&quot; Margin=\&quot;3,3,0,3\&quot;&gt;&lt;TextBlock Text=\&quot;Price:\&quot; Style=\&quot;{StaticResource AppBodyTextStyle}\&quot; Margin=\&quot;0,0,5,0\&quot;/&gt;&lt;TextBlock Text=\&quot;{Binding Price}\&quot; Style=\&quot;{StaticResource AppBodyTextStyle}\&quot;/&gt;&lt;/StackPanel&gt;&quot;);
sb.Append(&quot;&lt;StackPanel Orientation=\&quot;Horizontal\&quot; Margin=\&quot;3,3,0,3\&quot;&gt;&lt;TextBlock Text=\&quot;Author:\&quot; Style=\&quot;{StaticResource AppBodyTextStyle}\&quot; Margin=\&quot;0,0,5,0\&quot;/&gt;&lt;TextBlock Text=\&quot;{Binding Author}\&quot; Style=\&quot;{StaticResource AppBodyTextStyle}\&quot;/&gt;&lt;/StackPanel&gt;&quot;);
sb.Append(&quot;&lt;/StackPanel&gt;&quot;);
sb.Append(&quot;&lt;/Grid&gt;&quot;);
sb.Append(&quot;&lt;/DataTemplate&gt;&quot;);


DataTemplate datatemplate = (DataTemplate)XamlReader.Load(sb.ToString());
BookGridView.ItemTemplate = datatemplate;
BookListView.ItemTemplate = datatemplate;

</pre>
<pre id="codePreview" class="csharp">
StringBuilder sb = new StringBuilder();


sb.Append(&quot;&lt;DataTemplate xmlns=\&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation\&quot;&gt;&quot;);
sb.Append(&quot;&lt;Grid Width=\&quot;200\&quot; Height=\&quot;100\&quot;&gt;&quot;);
sb.Append(&quot;&lt;StackPanel&gt;&quot;);
sb.Append(&quot;&lt;StackPanel Orientation=\&quot;Horizontal\&quot; Margin=\&quot;3,3,0,3\&quot;&gt;&lt;TextBlock Text=\&quot;Name:\&quot; Style=\&quot;{StaticResource AppBodyTextStyle}\&quot; Margin=\&quot;0,0,5,0\&quot;/&gt;&lt;TextBlock Text=\&quot;{Binding Name}\&quot; Style=\&quot;{StaticResource AppBodyTextStyle}\&quot;/&gt;&lt;/StackPanel&gt;&quot;);
sb.Append(&quot;&lt;StackPanel Orientation=\&quot;Horizontal\&quot; Margin=\&quot;3,3,0,3\&quot;&gt;&lt;TextBlock Text=\&quot;Price:\&quot; Style=\&quot;{StaticResource AppBodyTextStyle}\&quot; Margin=\&quot;0,0,5,0\&quot;/&gt;&lt;TextBlock Text=\&quot;{Binding Price}\&quot; Style=\&quot;{StaticResource AppBodyTextStyle}\&quot;/&gt;&lt;/StackPanel&gt;&quot;);
sb.Append(&quot;&lt;StackPanel Orientation=\&quot;Horizontal\&quot; Margin=\&quot;3,3,0,3\&quot;&gt;&lt;TextBlock Text=\&quot;Author:\&quot; Style=\&quot;{StaticResource AppBodyTextStyle}\&quot; Margin=\&quot;0,0,5,0\&quot;/&gt;&lt;TextBlock Text=\&quot;{Binding Author}\&quot; Style=\&quot;{StaticResource AppBodyTextStyle}\&quot;/&gt;&lt;/StackPanel&gt;&quot;);
sb.Append(&quot;&lt;/StackPanel&gt;&quot;);
sb.Append(&quot;&lt;/Grid&gt;&quot;);
sb.Append(&quot;&lt;/DataTemplate&gt;&quot;);


DataTemplate datatemplate = (DataTemplate)XamlReader.Load(sb.ToString());
BookGridView.ItemTemplate = datatemplate;
BookListView.ItemTemplate = datatemplate;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:0in; margin-left:.5in; margin-bottom:.0001pt; text-indent:-.25in; line-height:12.75pt">
<span style="color:black">XamlReader class </span></p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:0in; margin-left:.5in; margin-bottom:.0001pt; text-indent:-.25in; line-height:12.75pt">
<a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.markup.xamlreader">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.markup.xamlreader</a></p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:0in; margin-left:.5in; margin-bottom:.0001pt; text-indent:-.25in; line-height:12.75pt">
</p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:0in; margin-left:.5in; margin-bottom:.0001pt; text-indent:-.25in; line-height:12.75pt">
<span style="color:black">XamlReader.Load method </span></p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:0in; margin-left:.5in; margin-bottom:.0001pt; text-indent:-.25in; line-height:12.75pt">
<a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.markup.xamlreader.load">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.markup.xamlreader.load</a></p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:0in; margin-left:.5in; margin-bottom:.0001pt; text-indent:-.25in; line-height:12.75pt">
</p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:0in; margin-left:.5in; margin-bottom:.0001pt; text-indent:-.25in; line-height:12.75pt">
<span style="color:black">DataTemplate class </span></p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:0in; margin-left:.5in; margin-bottom:.0001pt; text-indent:-.25in; line-height:12.75pt">
<a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.datatemplate">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.datatemplate</a></p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:0in; margin-left:.5in; margin-bottom:.0001pt; text-indent:-.25in; line-height:12.75pt">
</p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:0in; margin-left:.5in; margin-bottom:.0001pt; text-indent:-.25in; line-height:12.75pt">
<span style="color:black">GridView class </span></p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:0in; margin-left:.5in; margin-bottom:.0001pt; text-indent:-.25in; line-height:12.75pt">
<a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.gridview.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.gridview.aspx</a><span style="color:black">
</span></p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:0in; margin-left:.5in; margin-bottom:.0001pt; text-indent:-.25in; line-height:12.75pt">
<span style="color:black"></span></p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:0in; margin-left:.5in; margin-bottom:.0001pt; text-indent:-.25in; line-height:12.75pt">
<span style="color:black"></span></p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:0in; margin-left:.5in; margin-bottom:.0001pt; text-indent:-.25in; line-height:12.75pt">
<span style="color:black"></span></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
