# How to Create Master-Detail ListBox in a universal Windows app
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows Phone
* Windows 8
* Windows Phone 8
* Windows Store app Development
* Windows Phone Development
* Windows 8.1
* Windows Phone 8.1
## Topics
* DataBinding
* ListBox
* windows8
* universal app
## IsPublished
* True
## ModifiedDate
* 2015-02-08 10:39:05
## Description

<h1>How to Create Master-Detail ListBox in a universal Windows app</h1>
<h2>Introduction</h2>
<p>This sample demonstrates how to create master-detail ListBox in a universal Windows app.</p>
<h2>Video</h2>
<p><a href="http://channel9.msdn.com/Blogs/OneCode/How-to-create-a-master-detail-ListBox-in-universal-Windows-apps" target="_blank"><img id="133569" src="https://i1.code.msdn.s-msft.com/how-to-create-detail-b87a60fa/image/file/133569/1/how%20to%20create%20a%20master%20detail%20listbox%20in%20universal%20windows%20apps%20%20%20channel%209.png" alt="" width="640" height="360" style="border:1px solid black"></a></p>
<h2>Building the Sample</h2>
<ol>
<li>Start Visual Studio 2013 and select File &gt; Open &gt; Project/Solution. </li><li>Go to the directory in which you download the sample. Go to the directory named for the sample, and double-click the Microsoft Visual Studio Solution (.sln) file.
</li><li>Press F7 or use Build &gt; Build Solution to build the sample. </li><li>Press F5 to run it. </li><li>After the sample is launched, you can change the selection in each ListBox. The detail ListBox&rsquo;s items will change based on the selected item in master ListBox.
</li></ol>
<h2>Using the Code</h2>
<p>The code below shows how to connect the data sources of each ListBox through CollectionViewSource.</p>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Page.Resources&gt; 
    &lt;sampledata:Data x:Key=&quot;CountryList&quot;/&gt; 
    &lt;CollectionViewSource x:Name=&quot;Countries&quot; Source=&quot;{StaticResource CountryList}&quot;/&gt; 
    &lt;CollectionViewSource x:Name=&quot;Provinces&quot; Source=&quot;{Binding Provinces,Source={StaticResource Countries}}&quot;/&gt; 
    &lt;CollectionViewSource x:Name=&quot;Cities&quot; Source=&quot;{Binding Cities,Source={StaticResource Provinces}}&quot;/&gt; 
&lt;/Page.Resources&gt;
</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Page</span>.Resources<span class="xaml__tag_start">&gt;&nbsp;</span><span class="xaml__tag_start">&lt;sampledata</span>:Data&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;CountryList&quot;</span><span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_start">&lt;CollectionViewSource</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;Countries&quot;</span><span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;CountryList}&quot;</span><span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_start">&lt;CollectionViewSource</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;Provinces&quot;</span><span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Provinces,Source={StaticResource&nbsp;Countries}}&quot;</span><span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_start">&lt;CollectionViewSource</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;Cities&quot;</span><span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Cities,Source={StaticResource&nbsp;Provinces}}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;
&lt;/Page.Resources&gt;&nbsp;
</pre>
</div>
</div>
</div>
</h1>
<p>The code below shows how to bind the CollectionViewSource to ListBox control</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;StackPanel Orientation=&quot;Vertical&quot; Margin=&quot;30&quot;&gt; 
   &lt;StackPanel Orientation=&quot;Horizontal&quot; Margin=&quot;10&quot;&gt; 
       &lt;StackPanel Orientation=&quot;Vertical&quot; Margin=&quot;5&quot;&gt; 
           &lt;TextBlock Text=&quot;Countries&quot; Margin=&quot;5&quot;/&gt; 
           &lt;ListBox ItemsSource=&quot;{Binding Source={StaticResource Countries}}&quot; DisplayMemberPath=&quot;Name&quot;/&gt; 
       &lt;/StackPanel&gt; 
       &lt;StackPanel Orientation=&quot;Vertical&quot; Margin=&quot;5&quot;&gt; 
           &lt;TextBlock Text=&quot;{Binding Name,Source={StaticResource Countries}}&quot; Margin=&quot;5&quot;/&gt; 
           &lt;ListBox ItemsSource=&quot;{Binding Source={StaticResource Provinces}}&quot; DisplayMemberPath=&quot;Name&quot;/&gt; 
       &lt;/StackPanel&gt; 
       &lt;StackPanel Orientation=&quot;Vertical&quot; Margin=&quot;5&quot;&gt; 
           &lt;TextBlock Text=&quot;{Binding Name,Source={StaticResource Provinces}}&quot; Margin=&quot;5&quot;/&gt; 
           &lt;ListBox ItemsSource=&quot;{Binding Source={StaticResource Cities}}&quot; DisplayMemberPath=&quot;Name&quot;/&gt; 
       &lt;/StackPanel&gt; 
   &lt;/StackPanel&gt;
</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Vertical&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;30&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Horizontal&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;10&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Vertical&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;5&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Countries&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;5&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListBox</span>&nbsp;<span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Source={StaticResource&nbsp;Countries}}&quot;</span>&nbsp;<span class="xaml__attr_name">DisplayMemberPath</span>=<span class="xaml__attr_value">&quot;Name&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Vertical&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;5&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Name,Source={StaticResource&nbsp;Countries}}&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;5&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListBox</span>&nbsp;<span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Source={StaticResource&nbsp;Provinces}}&quot;</span>&nbsp;<span class="xaml__attr_name">DisplayMemberPath</span>=<span class="xaml__attr_value">&quot;Name&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Vertical&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;5&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Name,Source={StaticResource&nbsp;Provinces}}&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;5&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListBox</span>&nbsp;<span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Source={StaticResource&nbsp;Cities}}&quot;</span>&nbsp;<span class="xaml__attr_name">DisplayMemberPath</span>=<span class="xaml__attr_value">&quot;Name&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:10px">&nbsp;</span></div>
<h2>More Information</h2>
<p>CollectionViewSource class (Windows)</p>
<p><a href="http://msdn.microsoft.com/library/windows/apps/BR209833">http://msdn.microsoft.com/library/windows/apps/BR209833</a></p>
<p>ListBox class (Windows)</p>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.listbox.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.listbox.aspx</a></p>
<p>How to bind to hierarchical data and create a master/details view (Windows Store apps using C#/VB/C&#43;&#43; and XAML) (Windows)</p>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh758322.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh758322.aspx</a></p>
<p class="MsoNormal"><span>Create your first Windows Store app using JavaScript
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/br211385.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/br211385.aspx</a></p>
<p class="MsoNormal"><span>Layout and views (Windows Store apps using JavaScript and HTML)
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/jj841108.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/jj841108.aspx</a></p>
<p class="MsoNormal"><span>Manage app lifecycle and state (Windows Store apps using JavaScript and HTML)
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/hh986966.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/hh986966.aspx</a><span>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
