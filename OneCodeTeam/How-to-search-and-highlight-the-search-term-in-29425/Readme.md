# How to search and highlight the search term in WebView in universal Windows apps
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
* WebView
* universal app
## IsPublished
* True
## ModifiedDate
* 2014-12-29 11:33:13
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to search and highlight the search term in WebView in universal Windows apps</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>WebView continues to be a hot topic in the Windows Store</span><span> a</span><span>pp forums. The ability to bring in web content and manipulate it as you wish is a strong desire for many developers. This code sample will
 show you </span><span>how to highlight search terms in any page which you load into a WebView by injecting and invoking custom-written JavaScript from your Windows Store app.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-weight:bold">Please note: Th</span><span style="font-weight:bold">e</span><span style="font-weight:bold"> sample</span><span style="font-weight:bold">s were written
</span><span style="font-weight:bold">based on the following blog entry:</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://blogs.msdn.com/b/wsdevsol/archive/2013/05/07/webview-magic-tricks-highlight-a-search-term.aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://blogs.msdn.com/b/wsdevsol/archive/2013/05/07/webview-magic-tricks-highlight-a-search-term.aspx</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">You can build and run the sample</span><span style="font-size:11pt">
</span><span style="font-size:11pt">in V</span><span style="font-size:11pt">isual Studio 2013</span><span style="font-size:11pt">. The following is the screenshot of the running sample.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/117363/1/image.png" alt="" width="479" height="306" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">highlight.js file is responsible for highlighting terms and clearing the highlight.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">var OriginalBody;
function HighlightFunction(SearchTerm) {
    if (OriginalBody == null) { OriginalBody = document.getElementsByTagName('body')[0].innerHTML; }
    var bdy = document.getElementsByTagName('body')[0].innerHTML;
    var re = new RegExp('(\\b' &#43; SearchTerm &#43; '\\b)', 'ig');
    bdy = bdy.replace(re, '<span style="background-color:yellow; font-weight:bold">$1&lt;\/span&gt;');
    var re1 = new RegExp('(&lt;[^&gt;]*?)<span style="background-color:yellow; font-weight:bold">(' &#43; SearchTerm &#43; ')&lt;\/span&gt;(.*?&gt;)', 'ig');
    bdy = bdy.replace(re1, '$1$2$3');
    var re2 = new RegExp('(&lt;script.*?&gt;)<span style="background-color:yellow; font-weight:bold">(' &#43; SearchTerm &#43; ')&lt;\/span&gt;(&lt;\/script&gt;)', 'ig');
    bdy = bdy.replace(re2, '$1$2$3');
    var re3 = new RegExp('(&lt;textarea.*?&gt;)<span style="background-color:yellow; font-weight:bold">(' &#43; SearchTerm &#43; ')&lt;\/span&gt;(&lt;\/textarea&gt;)', 'ig');
    bdy = bdy.replace(re3, '$1$2$3');
    document.getElementsByTagName('body')[0].innerHTML = bdy;
}
function RestoreFunction() {
    document.getElementsByTagName('body')[0].innerHTML = OriginalBody;
}
</span></span></span></span></pre>
<pre id="codePreview" class="js">var OriginalBody;
function HighlightFunction(SearchTerm) {
    if (OriginalBody == null) { OriginalBody = document.getElementsByTagName('body')[0].innerHTML; }
    var bdy = document.getElementsByTagName('body')[0].innerHTML;
    var re = new RegExp('(\\b' &#43; SearchTerm &#43; '\\b)', 'ig');
    bdy = bdy.replace(re, '<span style="background-color:yellow; font-weight:bold">$1&lt;\/span&gt;');
    var re1 = new RegExp('(&lt;[^&gt;]*?)<span style="background-color:yellow; font-weight:bold">(' &#43; SearchTerm &#43; ')&lt;\/span&gt;(.*?&gt;)', 'ig');
    bdy = bdy.replace(re1, '$1$2$3');
    var re2 = new RegExp('(&lt;script.*?&gt;)<span style="background-color:yellow; font-weight:bold">(' &#43; SearchTerm &#43; ')&lt;\/span&gt;(&lt;\/script&gt;)', 'ig');
    bdy = bdy.replace(re2, '$1$2$3');
    var re3 = new RegExp('(&lt;textarea.*?&gt;)<span style="background-color:yellow; font-weight:bold">(' &#43; SearchTerm &#43; ')&lt;\/span&gt;(&lt;\/textarea&gt;)', 'ig');
    bdy = bdy.replace(re3, '$1$2$3');
    document.getElementsByTagName('body')[0].innerHTML = bdy;
}
function RestoreFunction() {
    document.getElementsByTagName('body')[0].innerHTML = OriginalBody;
}
</span></span></span></span></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">In MainPage, first </span>
<span style="font-size:11pt">we</span><span style="font-size:11pt"> </span><span style="font-size:11pt">open and read the highlight.js file.</span><span>
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">cplusplus</span>
<pre class="hidden">protected async override void OnNavigatedTo(NavigationEventArgs e)
{
    StorageFile highlightFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri(&quot;ms-appx:///highlight.js&quot;));
    highlightFunctionJS = await FileIO.ReadTextAsync(highlightFile);
}
</pre>
<pre class="hidden">void MainPage::OnNavigatedTo(NavigationEventArgs^ e)
{
 create_task(StorageFile::GetFileFromApplicationUriAsync(ref new Uri(&quot;ms-appx:///highlight.js&quot;))).then([this](StorageFile^ highlightFile)
 {
  create_task(FileIO::ReadTextAsync(highlightFile)).then([this](String^ s)
  {
   m_highlightFunctionJS = s;
  });
 });
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">protected</span>&nbsp;async&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnNavigatedTo(NavigationEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;StorageFile&nbsp;highlightFile&nbsp;=&nbsp;await&nbsp;StorageFile.GetFileFromApplicationUriAsync(<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;ms-appx:///highlight.js&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;highlightFunctionJS&nbsp;=&nbsp;await&nbsp;FileIO.ReadTextAsync(highlightFile);&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Then implement highlight/clear functions
</span><span style="font-size:11pt">by invoking JavaScript function </span><span>asyn</span><a name="_GoBack"></a><span>chronously.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">cplusplus</span>
<pre class="hidden">private async void HighlightButton_Click(object sender, RoutedEventArgs e)
{
    if(String.IsNullOrWhiteSpace(HighlightTerm.Text) || HighlightTerm.Text == &quot;Term to highlight&quot;)
    {
        HighlightTerm.Text = &quot;Term to highlight&quot;;
        return;
    }
    if (!cleared)
    {
        ClearButton_Click(sender, e);
    }
    await MyWebView.InvokeScriptAsync(&quot;eval&quot;, new string[] { highlightFunctionJS &#43; &quot; HighlightFunction('&quot; &#43; HighlightTerm.Text &#43; &quot;');&quot; });
    
    HighlightTerm.Text = &quot;Term to highlight&quot;;
    cleared = false;
}
private async void ClearButton_Click(object sender, RoutedEventArgs e)
{
    await MyWebView.InvokeScriptAsync(&quot;eval&quot;, new string[] { highlightFunctionJS &#43; &quot; RestoreFunction();&quot; });
    cleared = true;
}
</pre>
<pre class="hidden">void CppWindowsStoreAppWebViewHighlightWords::MainPage::HighlightButton_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
 if (HighlightTerm-&gt;Text == &quot;&quot; || HighlightTerm-&gt;Text == &quot;Term to highlight&quot;)
 {
  HighlightTerm-&gt;Text = &quot;Term to highlight&quot;;
  return;
 }
 if (!m_isCleared)
 {
  ClearButton_Click(sender, e);
 }
 Array&lt;String^&gt;^ argsArray = { m_highlightFunctionJS &#43; &quot; HighlightFunction('&quot; &#43; HighlightTerm-&gt;Text &#43; &quot;');&quot; };
 Platform::Collections::Vector&lt;String^&gt;^ arguments = ref new Platform::Collections::Vector&lt;String^&gt;(argsArray);
 create_task(this-&gt;MyWebView-&gt;InvokeScriptAsync(ref new String(L&quot;eval&quot;), arguments)).then([this](String^ result)
 {
  HighlightTerm-&gt;Text = &quot;Term to highlight&quot;;
  m_isCleared = false;
 });
}
void CppWindowsStoreAppWebViewHighlightWords::MainPage::ClearButton_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
 Array&lt;String^&gt;^ argsArray = { m_highlightFunctionJS &#43; &quot; RestoreFunction();&quot; };
 Platform::Collections::Vector&lt;String^&gt;^ arguments = ref new Platform::Collections::Vector&lt;String^&gt;(argsArray);
 create_task(this-&gt;MyWebView-&gt;InvokeScriptAsync(ref new String(L&quot;eval&quot;), arguments)).then([this](String^ result)
 {
  m_isCleared = true;
 });
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;async&nbsp;<span class="cs__keyword">void</span>&nbsp;HighlightButton_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(String.IsNullOrWhiteSpace(HighlightTerm.Text)&nbsp;||&nbsp;HighlightTerm.Text&nbsp;==&nbsp;<span class="cs__string">&quot;Term&nbsp;to&nbsp;highlight&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HighlightTerm.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Term&nbsp;to&nbsp;highlight&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!cleared)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ClearButton_Click(sender,&nbsp;e);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;MyWebView.InvokeScriptAsync(<span class="cs__string">&quot;eval&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">string</span>[]&nbsp;{&nbsp;highlightFunctionJS&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;HighlightFunction('&quot;</span>&nbsp;&#43;&nbsp;HighlightTerm.Text&nbsp;&#43;&nbsp;<span class="cs__string">&quot;');&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;HighlightTerm.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Term&nbsp;to&nbsp;highlight&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cleared&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
}&nbsp;
<span class="cs__keyword">private</span>&nbsp;async&nbsp;<span class="cs__keyword">void</span>&nbsp;ClearButton_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;MyWebView.InvokeScriptAsync(<span class="cs__string">&quot;eval&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">string</span>[]&nbsp;{&nbsp;highlightFunctionJS&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;RestoreFunction();&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cleared&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">WebView class</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.webview.aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.webview.aspx</span></a></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span>WebView.InvokeScriptAsync method</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.webview.invokescriptasync.aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.webview.invokescriptasync.aspx</span></a></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">WebView Magic Tricks: Highlight a Search Term</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://blogs.msdn.com/b/wsdevsol/archive/2013/05/07/webview-magic-tricks-highlight-a-search-term.aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://blogs.msdn.com/b/wsdevsol/archive/2013/05/07/webview-magic-tricks-highlight-a-search-term.aspx</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
