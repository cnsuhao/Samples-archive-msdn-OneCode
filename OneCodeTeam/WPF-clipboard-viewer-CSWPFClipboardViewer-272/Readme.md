# WPF clipboard viewer (CSWPFClipboardViewer)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* WPF
## Topics
* Clipboard
## IsPublished
* True
## ModifiedDate
* 2012-07-22 06:56:47
## Description

<h1><span style="">WPF clipboard viewer (CSWPFClipboardViewer) </span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><br>
This Sample demonstrates how to monitor Windows clipboard changes in a WPF application. In order to be notified by the system when the clipboard content changes, an application must use the SetClipboardViewer function (user32.dll) to add its window into the
 chain of clipboard viewers. Clipboard viewer windows receive a WM_DRAWCLIPBOARD message whenever the content of the clipboard changes. And the WM_CHANGECBCHAIN message is sent to the first window in the clipboard viewer chain when a window is being removed
 from the chain. In a WPF application, we use HwndSource class to register a Win32 window message handler to process the messages. This sample also shows a workaround for a known issue in WPF Clipboard.GetImage() method.</p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoNormal"><span style="">Press F5 to run this application, you will see following result.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/61544/1/image.png" alt="" width="641" height="480" align="middle">
</span><span style=""></span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Gets the window handle for a Windows Presentation Foundation (WPF).
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Adds an event handler to handle the clipboard message.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private void InitCBViewer()
{
牋?WindowInteropHelper wih = new WindowInteropHelper(this);
牋?hWndSource = HwndSource.FromHwnd(wih.Handle);


牋?hWndSource.AddHook(this.WinProc);牋 // start processing window messages
牋?hWndNextViewer = Win32.SetClipboardViewer(hWndSource.Handle);牋 // set this window as a viewer
牋?isViewing = true;
}


private IntPtr WinProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
{
牋?switch (msg)
牋?{
牋牋牋?case Win32.WM_CHANGECBCHAIN:
牋牋牋牋牋?if (wParam == hWndNextViewer)
牋牋牋牋牋?{
牋牋牋牋牋牋牋?// clipboard viewer chain changed, need to fix it.
牋牋牋牋牋牋牋?hWndNextViewer = lParam;
牋牋牋牋牋?}
牋牋牋牋牋?else if (hWndNextViewer != IntPtr.Zero)
牋牋牋 牋牋?/span&gt;{
牋牋牋牋牋牋牋?// pass the message to the next viewer.
牋牋牋牋牋牋牋?Win32.SendMessage(hWndNextViewer, msg, wParam, lParam);
牋牋牋牋牋?}
牋牋牋牋牋?break;


牋牋牋?case Win32.WM_DRAWCLIPBOARD:
牋牋牋牋牋?// clipboard content changed
牋牋牋牋 牋?/span&gt;this.DrawContent();
牋牋牋牋牋?// pass the message to the next viewer.
牋牋牋牋牋?Win32.SendMessage(hWndNextViewer, msg, wParam, lParam);
牋牋牋牋牋?break;
牋?}


牋?return IntPtr.Zero;
}

</pre>
<pre id="codePreview" class="csharp">
private void InitCBViewer()
{
牋?WindowInteropHelper wih = new WindowInteropHelper(this);
牋?hWndSource = HwndSource.FromHwnd(wih.Handle);


牋?hWndSource.AddHook(this.WinProc);牋 // start processing window messages
牋?hWndNextViewer = Win32.SetClipboardViewer(hWndSource.Handle);牋 // set this window as a viewer
牋?isViewing = true;
}


private IntPtr WinProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
{
牋?switch (msg)
牋?{
牋牋牋?case Win32.WM_CHANGECBCHAIN:
牋牋牋牋牋?if (wParam == hWndNextViewer)
牋牋牋牋牋?{
牋牋牋牋牋牋牋?// clipboard viewer chain changed, need to fix it.
牋牋牋牋牋牋牋?hWndNextViewer = lParam;
牋牋牋牋牋?}
牋牋牋牋牋?else if (hWndNextViewer != IntPtr.Zero)
牋牋牋 牋牋?/span&gt;{
牋牋牋牋牋牋牋?// pass the message to the next viewer.
牋牋牋牋牋牋牋?Win32.SendMessage(hWndNextViewer, msg, wParam, lParam);
牋牋牋牋牋?}
牋牋牋牋牋?break;


牋牋牋?case Win32.WM_DRAWCLIPBOARD:
牋牋牋牋牋?// clipboard content changed
牋牋牋牋 牋?/span&gt;this.DrawContent();
牋牋牋牋牋?// pass the message to the next viewer.
牋牋牋牋牋?Win32.SendMessage(hWndNextViewer, msg, wParam, lParam);
牋牋牋牋牋?break;
牋?}


牋?return IntPtr.Zero;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Draw content in the window </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private void DrawContent()
{
牋?pnlContent.Children.Clear();


牋?if (Clipboard.ContainsText())
牋?{
牋牋牋?// we have some text in the clipboard.
牋牋牋?TextBox tb = new TextBox();
牋牋牋?tb.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
牋牋牋?tb.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
牋牋牋?tb.Text = Clipboard.GetText();
牋牋牋?tb.IsReadOnly = true;
牋牋牋?tb.TextWrapping = TextWrapping.NoWrap;
牋牋牋?pnlContent.Children.Add(tb);
牋?}
牋?else if (Clipboard.ContainsFileDropList())
牋?{
牋牋牋?// we have a file drop list in the clipboard
牋牋牋?ListBox lb = new ListBox();
牋牋牋?lb.ItemsSource = Clipboard.GetFileDropList();
牋牋牋?pnlContent.Children.Add(lb);
牋?}
牋?else if (Clipboard.ContainsImage())
牋?{
牋牋牋?// Because of a known issue in WPF,
牋牋牋?// we have to use a workaround to get correct
牋牋牋?// image that can be displayed.
牋牋牋?// The image have to be saved to a stream and then 
牋牋牋牋// read out to workaround the issue.
牋牋牋?MemoryStream ms = new MemoryStream();
牋牋牋?BmpBitmapEncoder enc = new BmpBitmapEncoder();
牋牋牋?enc.Frames.Add(BitmapFrame.Create(Clipboard.GetImage()));
牋牋牋?enc.Save(ms);
牋牋牋?ms.Seek(0, SeekOrigin.Begin);


牋牋牋?BmpBitmapDecoder dec = new BmpBitmapDecoder(ms,
牋牋牋牋牋?BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);


牋牋牋?Image img = new Image();
牋牋牋?img.Stretch = Stretch.Uniform;
牋牋牋?img.Source = dec.Frames[0];
牋牋牋?pnlContent.Children.Add(img);
牋?}
牋?else
牋?{
牋牋牋?Label lb = new Label();
牋牋牋?lb.Content = &quot;The type of the data in the clipboard is not supported by this sample.&quot;;
牋牋牋?pnlContent.Children.Add(lb);
牋?}
}

</pre>
<pre id="codePreview" class="csharp">
private void DrawContent()
{
牋?pnlContent.Children.Clear();


牋?if (Clipboard.ContainsText())
牋?{
牋牋牋?// we have some text in the clipboard.
牋牋牋?TextBox tb = new TextBox();
牋牋牋?tb.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
牋牋牋?tb.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
牋牋牋?tb.Text = Clipboard.GetText();
牋牋牋?tb.IsReadOnly = true;
牋牋牋?tb.TextWrapping = TextWrapping.NoWrap;
牋牋牋?pnlContent.Children.Add(tb);
牋?}
牋?else if (Clipboard.ContainsFileDropList())
牋?{
牋牋牋?// we have a file drop list in the clipboard
牋牋牋?ListBox lb = new ListBox();
牋牋牋?lb.ItemsSource = Clipboard.GetFileDropList();
牋牋牋?pnlContent.Children.Add(lb);
牋?}
牋?else if (Clipboard.ContainsImage())
牋?{
牋牋牋?// Because of a known issue in WPF,
牋牋牋?// we have to use a workaround to get correct
牋牋牋?// image that can be displayed.
牋牋牋?// The image have to be saved to a stream and then 
牋牋牋牋// read out to workaround the issue.
牋牋牋?MemoryStream ms = new MemoryStream();
牋牋牋?BmpBitmapEncoder enc = new BmpBitmapEncoder();
牋牋牋?enc.Frames.Add(BitmapFrame.Create(Clipboard.GetImage()));
牋牋牋?enc.Save(ms);
牋牋牋?ms.Seek(0, SeekOrigin.Begin);


牋牋牋?BmpBitmapDecoder dec = new BmpBitmapDecoder(ms,
牋牋牋牋牋?BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);


牋牋牋?Image img = new Image();
牋牋牋?img.Stretch = Stretch.Uniform;
牋牋牋?img.Source = dec.Frames[0];
牋牋牋?pnlContent.Children.Add(img);
牋?}
牋?else
牋?{
牋牋牋?Label lb = new Label();
牋牋牋?lb.Content = &quot;The type of the data in the clipboard is not supported by this sample.&quot;;
牋牋牋?pnlContent.Children.Add(lb);
牋?}
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style=""><span style=""></span></p>
<p class="MsoNormal" style=""></p>
<p class="MsoNormal" style="">Clipboard</p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/ms648709(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms648709(VS.85).aspx</a></p>
<p class="MsoNormal" style="">Clipboard Class (<span class="SpellE">System.Windows</span>)</p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/system.windows.clipboard.aspx">http://msdn.microsoft.com/en-us/library/system.windows.clipboard.aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
