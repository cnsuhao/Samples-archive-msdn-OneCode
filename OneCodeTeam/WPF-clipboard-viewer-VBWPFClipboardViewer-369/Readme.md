# WPF clipboard viewer (VBWPFClipboardViewer)
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
* 2012-07-22 06:56:16
## Description

<h1><span style="">WPF clipboard viewer (VBWPFClipboardViewer) </span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><br>
This Sample demonstrates how to monitor Windows clipboard changes in a WPF application. In order to be notified by the system when the clipboard content changes, an application must use the SetClipboardViewer function (user32.dll) to add its window into the
 chain of clipboard viewers. Clipboard viewer windows receive a WM_DRAWCLIPBOARD message whenever the content of the clipboard changes. And the WM_CHANGECBCHAIN message is sent to the first window in the clipboard viewer chain when a window is being removed
 from the chain. In a WPF application, we use HwndSource class to register a Win32 window message handler to process the messages. This sample also shows a workaround for a known issue in WPF Clipboard.GetImage() method.</p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoNormal"><span style="">Press F5 to run this application, you will see following result.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/61541/1/image.png" alt="" width="641" height="480" align="middle">
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
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub InitCBViewer()
牋?Dim wih As New WindowInteropHelper(Me)
牋?hWndSource = HwndSource.FromHwnd(wih.Handle)


牋?hWndSource.AddHook(AddressOf WinProc)牋 ' start processing window messages
牋?hWndNextViewer = Win32.SetClipboardViewer(hWndSource.Handle)牋?' set this window as a viewer
牋?isViewing = True
End Sub


Private Function WinProc(ByVal hwnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr, ByRef handled As Boolean) As IntPtr
牋?Select Case msg
牋牋牋?Case Win32.WM_CHANGECBCHAIN
牋牋牋牋牋?If wParam = hWndNextViewer Then
牋牋牋牋牋牋牋?' clipboard viewer chain changed, need to fix it.
牋牋牋牋牋牋牋?hWndNextViewer = lParam


牋牋牋牋牋?ElseIf hWndNextViewer &lt;&gt; IntPtr.Zero Then
牋牋牋牋牋牋牋?' pass the message to the next viewer
牋牋牋牋牋牋牋?Win32.SendMessage(hWndNextViewer, msg, wParam, lParam)
牋牋牋牋牋?End If


牋牋牋?Case Win32.WM_DRAWCLIPBOARD
牋牋牋牋牋?' clipboard content changed
牋牋牋牋 牋?/span&gt;Me.DrawContent()
牋牋牋牋牋?' pass the message to the next viewer
牋牋牋牋牋?Win32.SendMessage(hWndNextViewer, msg, wParam, lParam)


牋?End Select


牋?Return IntPtr.Zero
End Function

</pre>
<pre id="codePreview" class="vb">
Private Sub InitCBViewer()
牋?Dim wih As New WindowInteropHelper(Me)
牋?hWndSource = HwndSource.FromHwnd(wih.Handle)


牋?hWndSource.AddHook(AddressOf WinProc)牋 ' start processing window messages
牋?hWndNextViewer = Win32.SetClipboardViewer(hWndSource.Handle)牋?' set this window as a viewer
牋?isViewing = True
End Sub


Private Function WinProc(ByVal hwnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr, ByRef handled As Boolean) As IntPtr
牋?Select Case msg
牋牋牋?Case Win32.WM_CHANGECBCHAIN
牋牋牋牋牋?If wParam = hWndNextViewer Then
牋牋牋牋牋牋牋?' clipboard viewer chain changed, need to fix it.
牋牋牋牋牋牋牋?hWndNextViewer = lParam


牋牋牋牋牋?ElseIf hWndNextViewer &lt;&gt; IntPtr.Zero Then
牋牋牋牋牋牋牋?' pass the message to the next viewer
牋牋牋牋牋牋牋?Win32.SendMessage(hWndNextViewer, msg, wParam, lParam)
牋牋牋牋牋?End If


牋牋牋?Case Win32.WM_DRAWCLIPBOARD
牋牋牋牋牋?' clipboard content changed
牋牋牋牋 牋?/span&gt;Me.DrawContent()
牋牋牋牋牋?' pass the message to the next viewer
牋牋牋牋牋?Win32.SendMessage(hWndNextViewer, msg, wParam, lParam)


牋?End Select


牋?Return IntPtr.Zero
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Draw content in the window </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub DrawContent()
牋?pnlContent.Children.Clear()


牋?If Clipboard.ContainsText() Then
牋牋牋?' we have some text in the clipboard
牋牋牋?Dim tb As New TextBox
牋牋牋?tb.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto
牋牋牋?tb.VerticalScrollBarVisibility = ScrollBarVisibility.Auto
牋牋牋?tb.Text = Clipboard.GetText()
牋牋牋?tb.IsReadOnly = True
牋牋牋?tb.TextWrapping = TextWrapping.NoWrap
牋牋牋?pnlContent.Children.Add(tb)


牋?ElseIf Clipboard.ContainsFileDropList() Then
牋牋牋?' we have a file drop list in the clipboard
牋牋牋?Dim lb As New ListBox
牋牋牋?lb.ItemsSource = Clipboard.GetFileDropList()
牋牋牋?pnlContent.Children.Add(lb)


牋?ElseIf Clipboard.ContainsImage() Then
牋牋牋?' Because of a known issue in WPF,
牋牋牋?' we have to use a workaround to get correct
牋牋牋?' image that can be displayed.
牋牋牋?' The image have to be saved to a stream and then 
牋牋牋牋' read out to workaround the issue.
牋牋牋?Dim ms As New MemoryStream
牋牋牋?Dim enc As New BmpBitmapEncoder
牋牋牋?enc.Frames.Add(BitmapFrame.Create(Clipboard.GetImage()))
牋牋牋?enc.Save(ms)
牋牋牋?ms.Seek(0, SeekOrigin.Begin)


牋牋牋?Dim dec As New BmpBitmapDecoder(ms, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default)
牋牋牋?Dim img As New Image
牋牋牋?img.Stretch = Stretch.Uniform
牋牋牋?img.Source = dec.Frames(0)
牋牋牋?pnlContent.Children.Add(img)


牋?Else
牋牋牋?Dim lb As New Label
牋牋牋?lb.Content = &quot;The type of the data in the clipboard is not supported by this sample.&quot;
牋牋牋?pnlContent.Children.Add(lb)
牋?End If
End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub DrawContent()
牋?pnlContent.Children.Clear()


牋?If Clipboard.ContainsText() Then
牋牋牋?' we have some text in the clipboard
牋牋牋?Dim tb As New TextBox
牋牋牋?tb.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto
牋牋牋?tb.VerticalScrollBarVisibility = ScrollBarVisibility.Auto
牋牋牋?tb.Text = Clipboard.GetText()
牋牋牋?tb.IsReadOnly = True
牋牋牋?tb.TextWrapping = TextWrapping.NoWrap
牋牋牋?pnlContent.Children.Add(tb)


牋?ElseIf Clipboard.ContainsFileDropList() Then
牋牋牋?' we have a file drop list in the clipboard
牋牋牋?Dim lb As New ListBox
牋牋牋?lb.ItemsSource = Clipboard.GetFileDropList()
牋牋牋?pnlContent.Children.Add(lb)


牋?ElseIf Clipboard.ContainsImage() Then
牋牋牋?' Because of a known issue in WPF,
牋牋牋?' we have to use a workaround to get correct
牋牋牋?' image that can be displayed.
牋牋牋?' The image have to be saved to a stream and then 
牋牋牋牋' read out to workaround the issue.
牋牋牋?Dim ms As New MemoryStream
牋牋牋?Dim enc As New BmpBitmapEncoder
牋牋牋?enc.Frames.Add(BitmapFrame.Create(Clipboard.GetImage()))
牋牋牋?enc.Save(ms)
牋牋牋?ms.Seek(0, SeekOrigin.Begin)


牋牋牋?Dim dec As New BmpBitmapDecoder(ms, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default)
牋牋牋?Dim img As New Image
牋牋牋?img.Stretch = Stretch.Uniform
牋牋牋?img.Source = dec.Frames(0)
牋牋牋?pnlContent.Children.Add(img)


牋?Else
牋牋牋?Dim lb As New Label
牋牋牋?lb.Content = &quot;The type of the data in the clipboard is not supported by this sample.&quot;
牋牋牋?pnlContent.Children.Add(lb)
牋?End If
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style=""><span style=""></span></p>
<p class="MsoNormal"></p>
<p class="MsoNormal" style="">Clipboard</p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/ms648709(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms648709(VS.85).aspx</a></p>
<p class="MsoNormal" style="">Clipboard Class (<span class="SpellE">System.Windows</span>)</p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/system.windows.clipboard.aspx">http://msdn.microsoft.com/en-us/library/system.windows.clipboard.aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
