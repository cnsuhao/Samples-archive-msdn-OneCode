# Save a DIB on the Clipboard to a File using Silverlight (CSSL5DIBFromClipboard)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Silverlight
* Silverlight 5
## Topics
* Clipboard
* DIB
## IsPublished
* True
## ModifiedDate
* 2012-02-22 12:22:32
## Description

<div class="WordSection1">
<h1>How to save a DIB on the Clipboard to a File using Silverlight (CSSL5DIBFromClipboard)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This code sample demonstrates accessing the Windows Clipboard and retrieving a Device Independent Bitmap (DIB) and saving the DIB to a file.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">This Sample requires <a href="http://go.microsoft.com/fwlink/?LinkId=229318">
Silverlight 5 Tools for Visual Studio 2010 SP1</a>.&nbsp;</p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Set CSSL5DIBFromClipboard.Web to the startup project.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Set CSSL5DIBFromClipboardTestPage.html as the Start Page.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Build and Run the solution</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press &quot;PrtScn&quot; or copy a Bitmap to the clipboard using other means such as MSPaint</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press the &quot;Save Bitmap on Clipboard to File&quot; button</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span><span>6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Use the SaveFileDialog to save the Bitmap to disk.</p>
<p class="MsoNormal"><span><img src="/site/view/file/50553/1/image001.png" alt="" width="665" height="337"></span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">You can reuse this code if your application needs to attach bitmap data from the clipboard.</p>
<p class="MsoNormal">&nbsp;The following code snippet shows the wrapper class.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static class NativeMethods
{
    [DllImport(&quot;user32.dll&quot;, EntryPoint = &quot;OpenClipboard&quot;, CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool OpenClipboard(IntPtr hWndNewOwner);
 
    [DllImport(&quot;user32.dll&quot;, EntryPoint = &quot;CloseClipboard&quot;, CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool CloseClipboard();
 
    [DllImport(&quot;user32.dll&quot;, EntryPoint = &quot;IsClipboardFormatAvailable&quot;, CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool IsClipboardFormatAvailable(uint fmt);
 
    [DllImport(&quot;user32.dll&quot;, EntryPoint = &quot;GetClipboardData&quot;, CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr GetClipboardData(uint fmt);
 
    [DllImport(&quot;kernel32.dll&quot;, CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool CloseHandle(IntPtr hObject);
 
    [DllImport(&quot;kernel32.dll&quot;, CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr GlobalLock(IntPtr hObject);
 
    [DllImport(&quot;kernel32.dll&quot;, CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int GlobalSize(IntPtr hGlobal);
 
    [DllImport(&quot;kernel32.dll&quot;, CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool GlobalUnlock(IntPtr hObject);
 
    // See http://msdn.microsoft.com/en-us/library/windows/desktop/ff729168(v=vs.85).aspx for clipboard formats
    public const uint CF_DIB = 8;
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;NativeMethods&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DllImport(<span class="cs__string">&quot;user32.dll&quot;</span>,&nbsp;EntryPoint&nbsp;=&nbsp;<span class="cs__string">&quot;OpenClipboard&quot;</span>,&nbsp;CharSet&nbsp;=&nbsp;CharSet.Auto,&nbsp;SetLastError&nbsp;=&nbsp;<span class="cs__keyword">true</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">extern</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;OpenClipboard(IntPtr&nbsp;hWndNewOwner);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DllImport(<span class="cs__string">&quot;user32.dll&quot;</span>,&nbsp;EntryPoint&nbsp;=&nbsp;<span class="cs__string">&quot;CloseClipboard&quot;</span>,&nbsp;CharSet&nbsp;=&nbsp;CharSet.Auto,&nbsp;SetLastError&nbsp;=&nbsp;<span class="cs__keyword">true</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">extern</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;CloseClipboard();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DllImport(<span class="cs__string">&quot;user32.dll&quot;</span>,&nbsp;EntryPoint&nbsp;=&nbsp;<span class="cs__string">&quot;IsClipboardFormatAvailable&quot;</span>,&nbsp;CharSet&nbsp;=&nbsp;CharSet.Auto,&nbsp;SetLastError&nbsp;=&nbsp;<span class="cs__keyword">true</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">extern</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsClipboardFormatAvailable(<span class="cs__keyword">uint</span>&nbsp;fmt);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DllImport(<span class="cs__string">&quot;user32.dll&quot;</span>,&nbsp;EntryPoint&nbsp;=&nbsp;<span class="cs__string">&quot;GetClipboardData&quot;</span>,&nbsp;CharSet&nbsp;=&nbsp;CharSet.Auto,&nbsp;SetLastError&nbsp;=&nbsp;<span class="cs__keyword">true</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">extern</span>&nbsp;IntPtr&nbsp;GetClipboardData(<span class="cs__keyword">uint</span>&nbsp;fmt);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DllImport(<span class="cs__string">&quot;kernel32.dll&quot;</span>,&nbsp;CharSet&nbsp;=&nbsp;CharSet.Auto,&nbsp;SetLastError&nbsp;=&nbsp;<span class="cs__keyword">true</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="cs__keyword">return</span>:&nbsp;MarshalAs(UnmanagedType.Bool)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">extern</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;CloseHandle(IntPtr&nbsp;hObject);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DllImport(<span class="cs__string">&quot;kernel32.dll&quot;</span>,&nbsp;CharSet&nbsp;=&nbsp;CharSet.Auto,&nbsp;SetLastError&nbsp;=&nbsp;<span class="cs__keyword">true</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">extern</span>&nbsp;IntPtr&nbsp;GlobalLock(IntPtr&nbsp;hObject);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DllImport(<span class="cs__string">&quot;kernel32.dll&quot;</span>,&nbsp;CharSet&nbsp;=&nbsp;CharSet.Auto,&nbsp;SetLastError&nbsp;=&nbsp;<span class="cs__keyword">true</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">extern</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;GlobalSize(IntPtr&nbsp;hGlobal);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DllImport(<span class="cs__string">&quot;kernel32.dll&quot;</span>,&nbsp;CharSet&nbsp;=&nbsp;CharSet.Auto,&nbsp;SetLastError&nbsp;=&nbsp;<span class="cs__keyword">true</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">extern</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;GlobalUnlock(IntPtr&nbsp;hObject);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;See&nbsp;http://msdn.microsoft.com/en-us/library/windows/desktop/ff729168(v=vs.85).aspx&nbsp;for&nbsp;clipboard&nbsp;formats</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">uint</span>&nbsp;CF_DIB&nbsp;=&nbsp;<span class="cs__number">8</span>;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">The following code snippet shows the key point of this code sample.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void SaveDIBOnClipboardToFile()
{
    // Check to see if we've got trust
    // http://msdn.microsoft.com/en-us/library/system.windows.application.haselevatedpermissions(v=vs.95).aspx
    if (true == Application.Current.HasElevatedPermissions)
    {
        // Get Data off the Clipboard
        bool res = NativeMethods.OpenClipboard(IntPtr.Zero);
        if (NativeMethods.IsClipboardFormatAvailable(NativeMethods.CF_DIB))
        {
            // Save the clipboard data to this stream,
            // the stream could also come from HttpWebRequest, File, or other source. 
            IntPtr clipboardDataHandle = NativeMethods.GetClipboardData(NativeMethods.CF_DIB);
            IntPtr ptr = NativeMethods.GlobalLock(clipboardDataHandle);
            byte[] buffer = HGlobalToByteArray(ptr);
            NativeMethods.GlobalUnlock(clipboardDataHandle);
            NativeMethods.CloseClipboard();
 
            // Pick someplace to Save the File
            SaveFileDialog sfd = new SaveFileDialog();
            if (true == sfd.ShowDialog())
            {
                Stream fs = sfd.OpenFile();
 
                WriteBitmapFileToStream(buffer, fs);
 
                fs.Close();
                fs.Dispose();
            }
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;SaveDIBOnClipboardToFile()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Check&nbsp;to&nbsp;see&nbsp;if&nbsp;we've&nbsp;got&nbsp;trust</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;http://msdn.microsoft.com/en-us/library/system.windows.application.haselevatedpermissions(v=vs.95).aspx</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">true</span>&nbsp;==&nbsp;Application.Current.HasElevatedPermissions)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Get&nbsp;Data&nbsp;off&nbsp;the&nbsp;Clipboard</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;res&nbsp;=&nbsp;NativeMethods.OpenClipboard(IntPtr.Zero);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(NativeMethods.IsClipboardFormatAvailable(NativeMethods.CF_DIB))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Save&nbsp;the&nbsp;clipboard&nbsp;data&nbsp;to&nbsp;this&nbsp;stream,</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;the&nbsp;stream&nbsp;could&nbsp;also&nbsp;come&nbsp;from&nbsp;HttpWebRequest,&nbsp;File,&nbsp;or&nbsp;other&nbsp;source.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IntPtr&nbsp;clipboardDataHandle&nbsp;=&nbsp;NativeMethods.GetClipboardData(NativeMethods.CF_DIB);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IntPtr&nbsp;ptr&nbsp;=&nbsp;NativeMethods.GlobalLock(clipboardDataHandle);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;buffer&nbsp;=&nbsp;HGlobalToByteArray(ptr);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NativeMethods.GlobalUnlock(clipboardDataHandle);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NativeMethods.CloseClipboard();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Pick&nbsp;someplace&nbsp;to&nbsp;Save&nbsp;the&nbsp;File</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SaveFileDialog&nbsp;sfd&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SaveFileDialog();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">true</span>&nbsp;==&nbsp;sfd.ShowDialog())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Stream&nbsp;fs&nbsp;=&nbsp;sfd.OpenFile();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WriteBitmapFileToStream(buffer,&nbsp;fs);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fs.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fs.Dispose();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</div>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>For more information please see the Trusted Applications topic for Silverlight in MSDN<br>
<a href="http://msdn.microsoft.com/en-us/library/ee721083(v=VS.95).aspx">http://msdn.microsoft.com/en-us/library/ee721083(v=VS.95).aspx</a></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Using the Clipboard<br>
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms649016(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/ms649016(v=vs.85).aspx</a></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Storing an Image<br>
<a href="http://msdn.microsoft.com/en-us/library/dd145119(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/dd145119(v=vs.85).aspx</a></p>
<p class="MsoListParagraphCxSpLast">&nbsp;</p>
<p class="MsoListParagraphCxSpLast">&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
<p>&nbsp;</p>
<p class="MsoNormal">&nbsp;</p>
</div>
