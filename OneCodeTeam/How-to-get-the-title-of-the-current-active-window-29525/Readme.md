# How to get the title of the current active window in Windows
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* .NET
* Windows Forms
* Windows
* Windows Desktop App Development
## Topics
* code snippets
* Get Windows Title
## IsPublished
* True
## ModifiedDate
* 2014-06-25 08:16:12
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to get the title of
</span><span style="font-weight:bold; font-size:14pt">the </span><span style="font-weight:bold; font-size:14pt">current active window</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This is a code snippet</span><span style="">.</span><span style="font-size:11pt">
</span><span style="font-size:11pt">I</span><span style="font-size:11pt">t will show you how to get the title of
</span><span style="font-size:11pt">the </span><span style="font-size:11pt">current active window.
</span><span style="">We use </span><span style="font-weight:bold">GetForegroundWindow</span><span style=""> method
</span><span style="">to get a handle to the window </span><span style="">that </span>
<span style="">the user is us</span><span style="">ing and then use </span><span style="font-weight:bold">GetWindowText</span><span style=""> method</span><span style=""> to get the title.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Code Snippet</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">To use the
</span><span style="font-weight:bold">GetForegroundWindow</span><span style="font-size:11pt"> and
</span><span style="font-weight:bold">GetWindowText</span><span style="font-size:11pt">, we must declare the API functions first.
</span><span style="">Add the following code lines to declare API functions; to get the Windows API functions we will have to import &quot;</span><span style="font-weight:bold">user32.dll</span><span style="">&quot; DLL.
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
[DllImport(&quot;user32.dll&quot;, CharSet = CharSet.Auto, SetLastError = true)] 
static extern IntPtr GetForegroundWindow(); 
[DllImport(&quot;user32.dll&quot;, CharSet = CharSet.Auto, SetLastError = true)] 
static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count); 
[DllImport(&quot;user32.dll&quot;, CharSet = CharSet.Auto, SetLastError = true)] 
static extern int GetWindowTextLength(IntPtr hWnd); 
</pre>
<pre class="hidden">
&lt;DllImport(&quot;user32.dll&quot;, CharSet := CharSet.Auto, SetLastError := True)&gt; _ 
Private Shared Function GetForegroundWindow() As IntPtr 
End Function 
&lt;DllImport(&quot;user32.dll&quot;, CharSet := CharSet.Auto, SetLastError := True)&gt; _ 
Private Shared Function GetWindowText(hWnd As IntPtr, text As StringBuilder, count As Integer) As Integer 
End Function 
&lt;DllImport(&quot;user32.dll&quot;, CharSet := CharSet.Auto, SetLastError := True)&gt; _ 
Private Shared Function GetWindowTextLength(hWnd As IntPtr) As Integer 
End Function 
</pre>
<pre id="codePreview" class="csharp">
[DllImport(&quot;user32.dll&quot;, CharSet = CharSet.Auto, SetLastError = true)] 
static extern IntPtr GetForegroundWindow(); 
[DllImport(&quot;user32.dll&quot;, CharSet = CharSet.Auto, SetLastError = true)] 
static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count); 
[DllImport(&quot;user32.dll&quot;, CharSet = CharSet.Auto, SetLastError = true)] 
static extern int GetWindowTextLength(IntPtr hWnd); 
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">In order to facilitate calls, we enclose a
</span><span style="font-weight:bold">GetCaptionOfActiveWindow</span><span style="font-size:11pt"> method. After getting the current active window by
</span><span style="font-weight:bold">GetForegroundWindow</span><span style="font-size:11pt"> method, we
</span><span style="">should use </span><span style="font-weight:bold">GetWindowTextLength</span><span style=""> to obtain the length of the text in the window.
</span><a name="_GoBack"></a><span style="">Create a temporary </span><span style="font-weight:bold">StringBuilder</span><span style=""> instance to store the returned window text.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
private string GetCaptionOfActiveWindow() 
        { 
            string strTitle = string.Empty; 
            IntPtr handle = GetForegroundWindow(); 
            // Obtain the length of the text  
            int intLength = GetWindowTextLength(handle) &#43; 1; 
            StringBuilder stringBuilder = new StringBuilder(intLength); 
            if (GetWindowText(handle, stringBuilder, intLength) &gt; 0) 
            { 
                strTitle = stringBuilder.ToString(); 
            } 
            return strTitle; 
        } 
</pre>
<pre class="hidden">
Private Function GetCaptionOfActiveWindow() As String 
 Dim strTitle As String = String.Empty 
 Dim handle As IntPtr = GetForegroundWindow() 
 ' Obtain the length of the text  
 Dim intLength As Integer = GetWindowTextLength(handle) &#43; 1 
 Dim stringBuilder As New StringBuilder(intLength) 
 If GetWindowText(handle, stringBuilder, intLength) &gt; 0 Then 
  strTitle = stringBuilder.ToString() 
 End If 
 Return strTitle 
End Function 
</pre>
<pre id="codePreview" class="csharp">
private string GetCaptionOfActiveWindow() 
        { 
            string strTitle = string.Empty; 
            IntPtr handle = GetForegroundWindow(); 
            // Obtain the length of the text  
            int intLength = GetWindowTextLength(handle) &#43; 1; 
            StringBuilder stringBuilder = new StringBuilder(intLength); 
            if (GetWindowText(handle, stringBuilder, intLength) &gt; 0) 
            { 
                strTitle = stringBuilder.ToString(); 
            } 
            return strTitle; 
        } 
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">To use the custom GetCaptionOfActiveWindow method, we a</span><span style="">dd a Timer control to the windows, and then invoke GetActiveWindow method in the Timer control's Tick event.
 You will see the following result: </span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
private void timer1_Tick(object sender, System.EventArgs e)
       {
           GetCaptionOfActiveWindow();
       }
</pre>
<pre class="hidden">
Private Sub timer1_Tick(sender As Object, e As System.EventArgs)
 GetCaptionOfActiveWindow()
End Sub
</pre>
<pre id="codePreview" class="csharp">
private void timer1_Tick(object sender, System.EventArgs e)
       {
           GetCaptionOfActiveWindow();
       }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Windows Functions</span><span style="font-size:11pt">
<br clear="all">
</span><a href="http://msdn.microsoft.com/en-us/library/aa932689.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/aa932689.aspx</span></a><span style="font-size:11pt">
<br clear="all">
</span><span style="font-size:11pt">GetForegroundWindow</span><span style="font-size:11pt">
<br clear="all">
</span><a href="http://msdn.microsoft.com/en-us/library/aa932991.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/aa932991.aspx</span></a><span style="font-size:11pt">
<br clear="all">
</span><span style="font-size:11pt">GetWindowText</span><span style="font-size:11pt">
<br clear="all">
</span><a href="http://msdn.microsoft.com/en-us/library/aa928060.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/aa928060.aspx</span></a><span style="font-size:11pt">
<br clear="all">
</span><span style="font-size:11pt">GetWindowTextLength</span><span style="font-size:11pt">
<br clear="all">
</span><a href="http://msdn.microsoft.com/en-us/library/aa923056.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/aa923056.aspx</span></a><span style="font-size:11pt">
<br clear="all">
</span><span style="font-size:11pt">Platform Invoke Tutorial</span><span style="font-size:11pt">
<br clear="all">
</span><a href="http://msdn.microsoft.com/en-us/library/aa288468(v=vs.71).aspx#pinvoke_callingdllexport" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/aa288468(v=vs.71).aspx#pinvoke_callingdllexport</span></a><span style="font-size:11pt">
<br clear="all">
</span><span style="font-size:11pt"><br clear="all">
</span><span style="font-size:11pt"><br clear="all">
</span></span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers’ pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers’ frequently asked programming tasks, and allow
 developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
