# How to put a ProgressRing over a WebView
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows 8
* Windows Store app Development
## Topics
* WebView
* ProgressRing
## IsPublished
* True
## ModifiedDate
* 2013-06-13 10:20:42
## Description

<h1>How to <span style="">diplay ProgressRing over WebView</span> <span style="">
(CSWindowsStoreAppProgressRingOverWebView</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">This sample demonstrates how to display ProgressRing over WebView.
</span></p>
<h2>Build the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Start Visual Studio 2012 and select File &gt; Open &gt; Project/Solution.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Go to the directory in which you download the sample. Go to the directory named for the sample, and double-click the Microsoft Visual Studio Solution(.sln) file.</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press F7 or use Build &gt; Build Solution to build the sample.</p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press F5 to run it.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>After the sample is launched, <span style="">the screen will display this.</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/84436/1/image.png" alt="" width="576" height="326" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Please enter a valid url and click 'Load' button to load the page, then enter another url and click 'Load' button again. You will see a ProgressRing over the first page before the second page loaded.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><b style=""><span style="">PS:</span></b><span style=""> When loading the page, it may throw a javascript exception, this not caused by the sample, it is caused by the web page, many web pages have javascript problems,
 even some famous websites. This issue only occurs when debugging. You can get rid of those annoying javascript exceptions through this method:
</span></p>
<p class="MsoListParagraphCxSpMiddle"><a href="http://blogs.msdn.com/b/wsdevsol/archive/2012/10/18/nine-things-you-need-to-know-about-webview.aspx#AN10">http://blogs.msdn.com/b/wsdevsol/archive/2012/10/18/nine-things-you-need-to-know-about-webview.aspx#AN10</a><span style="">
</span></p>
<p class="MsoListParagraphCxSpLast"><span style=""></span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">The code below <span style="">shows the XAML UI. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;Grid&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&lt;WebView Name=&quot;DisplayWebView&quot; LoadCompleted=&quot;DisplayWebView_LoadCompleted&quot;&nbsp; VerticalAlignment=&quot;Stretch&quot; HorizontalAlignment=&quot;Stretch&quot;/&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Rectangle Name=&quot;MaskRectangle&quot;/&gt;
&nbsp;&nbsp;&nbsp; &lt;ProgressRing Name=&quot;LoadingProcessProgressRing&quot; Width=&quot;50&quot; Height=&quot;50&quot; HorizontalAlignment=&quot;Center&quot; VerticalAlignment=&quot;Center&quot;/&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&lt;/Grid&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 

</pre>
<pre id="codePreview" class="xaml">
&lt;Grid&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&lt;WebView Name=&quot;DisplayWebView&quot; LoadCompleted=&quot;DisplayWebView_LoadCompleted&quot;&nbsp; VerticalAlignment=&quot;Stretch&quot; HorizontalAlignment=&quot;Stretch&quot;/&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Rectangle Name=&quot;MaskRectangle&quot;/&gt;
&nbsp;&nbsp;&nbsp; &lt;ProgressRing Name=&quot;LoadingProcessProgressRing&quot; Width=&quot;50&quot; Height=&quot;50&quot; HorizontalAlignment=&quot;Center&quot; VerticalAlignment=&quot;Center&quot;/&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&lt;/Grid&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal"><a name="OLE_LINK2"></a><a name="OLE_LINK1"><span style="">The code below
</span></a><span style=""></span><span style=""></span><span style="">shows how to use WebViewBrush to make the ProgressRing over the WebView.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private void LoadButton_Click(object sender, RoutedEventArgs e)
{
&nbsp;&nbsp;&nbsp; Uri uri = ValidateAndGetUri(UrlTextBox.Text);
&nbsp;&nbsp;&nbsp; if (uri != null)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; LoadingProcessProgressRing.IsActive = true;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WebViewBrush brush = new WebViewBrush();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; brush.SourceName = &quot;DisplayWebView&quot;;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; brush.Redraw();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MaskRectangle.Fill = brush;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DisplayWebView.Navigate(uri);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DisplayWebView.Visibility = Visibility.Collapsed;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; catch (Exception ex)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NotifyUser(ex.ToString());
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }
}

</pre>
<pre id="codePreview" class="csharp">
private void LoadButton_Click(object sender, RoutedEventArgs e)
{
&nbsp;&nbsp;&nbsp; Uri uri = ValidateAndGetUri(UrlTextBox.Text);
&nbsp;&nbsp;&nbsp; if (uri != null)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; LoadingProcessProgressRing.IsActive = true;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WebViewBrush brush = new WebViewBrush();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; brush.SourceName = &quot;DisplayWebView&quot;;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; brush.Redraw();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MaskRectangle.Fill = brush;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DisplayWebView.Navigate(uri);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DisplayWebView.Visibility = Visibility.Collapsed;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; catch (Exception ex)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NotifyUser(ex.ToString());
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><span style=""></span></p>
<h2>More Information<span style=""> </span></h2>
<p class="MsoNormal"><span style="">WebView class </span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.webview.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.webview.aspx</a><span style="">
</span></p>
<p class="MsoNormal"><span style="">WebViewBrush class </span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.webviewbrush.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.webviewbrush.aspx</a><span style="">
</span></p>
<p class="MsoNormal"><span style="">ProgressRing class </span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.progressring.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.progressring.aspx</a><span style="">
</span></p>
<p class="MsoNormal"><span style=""></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
