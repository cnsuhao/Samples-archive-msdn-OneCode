# How to create a splash screen window for the VSTO Application
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* Office
* VSTO
* Office Development
## Topics
* Splash Screen
* code snippets
* VSTO Application
## IsPublished
* True
## ModifiedDate
* 2014-05-13 10:46:11
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to create a splash screen window</span><span style="font-weight:bold; font-size:14pt">
</span><span style="font-weight:bold; font-size:14pt">for the VSTO Application</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="direction:ltr; unicode-bidi:normal"><span><span>Some customers want to create a splash screen window for the VSTO application, but there is no code snippet in MSDN</span><span> covering this topic</span><span>.</span><span>
</span><span>T</span><span>he </span><span>following </span><span>code snippet </span>
<span>demonstrates how to create a splash screen for the Word Add-in</span><span> Application</span><span>.
</span></span></p>
<p style="direction:ltr; unicode-bidi:normal"><span><span>The full code snippet as
</span><span>shown </span><span>below:</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word; 
public delegate void InvokeClose();
public partial class ThisAddIn
{
Form splashScreen = new Form();
private void ThisAddIn_Startup(object sender, System.EventArgs e)
{
// Add a Paragraphs
Paragraph p =Application.ActiveDocument.Paragraphs.Add();
// Get window Handle of Word Apllication
IntPtr hwndWord = Process.GetProcessesByName(&quot;winword&quot;)[0].MainWindowHandle;
NativeWindow owner = new NativeWindow();
// Assign a handle to this window
owner.AssignHandle(hwndWord);
try
{
// Create and start the splash thread
Thread splashThread = new Thread(new ParameterizedThreadStart(ShowSplashScreen));
splashThread.Start(owner);
// Do some long operation.
for (int i = 1; i &lt; 5000; i&#43;&#43;)
{
p.Range.Text = i.ToString();
}
// Close the Splash screen
InvokeClose invokeClose = new InvokeClose(splashScreen.Close);
splashScreen.Invoke(invokeClose);
}
finally
{
// Release the handle 
owner.ReleaseHandle();
}
}
// Display the splash screen
private void ShowSplashScreen (object param)
{ 
IWin32Window owner = (IWin32Window)param;
// show the splash form with the specified owner form.
splashScreen.ShowDialog(owner);
}
private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
{
}
}
</pre>
<pre class="hidden">Imports System.Windows.Forms
Imports System.Threading
Imports System.Diagnostics
Public Delegate Sub InvokeClose()
Public Class ThisAddIn
Private splashScreen As New Form()
Private Sub ThisAddIn_Startup() Handles Me.Startup
' Add a Paragraphs
Dim p As Word.Paragraph = Application.ActiveDocument.Paragraphs.Add()
' Get window Handle of Word Apllication
Dim hwndWord As IntPtr = Process.GetProcessesByName(&quot;winword&quot;)(0).MainWindowHandle
Dim owner As New NativeWindow()
' Assign a handle to this window
owner.AssignHandle(hwndWord)
Try
' Create and start the splash thread
Dim splashThread As New Thread(New ParameterizedThreadStart(AddressOf ShowSplashScreen))
splashThread.Start(owner)
' Do some long operation.
For i As Integer = 1 To 4999
p.Range.Text = i.ToString()
Next
' Close the Splash screen
Dim invokeClose As New InvokeClose(AddressOf splashScreen.Close)
splashScreen.Invoke(invokeClose)
Finally
' Release the handle 
owner.ReleaseHandle()
End Try
End Sub
' Display the splash screen
Private Sub ShowSplashScreen(param As Object)
Dim owner As IWin32Window = DirectCast(param, IWin32Window)
' show the splash form with the specified owner form.
splashScreen.ShowDialog(owner)
End Sub
Private Sub ThisAddIn_Shutdown() Handles Me.Shutdown
End Sub
End Class
</pre>
<pre id="codePreview" class="csharp">using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word; 
public delegate void InvokeClose();
public partial class ThisAddIn
{
Form splashScreen = new Form();
private void ThisAddIn_Startup(object sender, System.EventArgs e)
{
// Add a Paragraphs
Paragraph p =Application.ActiveDocument.Paragraphs.Add();
// Get window Handle of Word Apllication
IntPtr hwndWord = Process.GetProcessesByName(&quot;winword&quot;)[0].MainWindowHandle;
NativeWindow owner = new NativeWindow();
// Assign a handle to this window
owner.AssignHandle(hwndWord);
try
{
// Create and start the splash thread
Thread splashThread = new Thread(new ParameterizedThreadStart(ShowSplashScreen));
splashThread.Start(owner);
// Do some long operation.
for (int i = 1; i &lt; 5000; i&#43;&#43;)
{
p.Range.Text = i.ToString();
}
// Close the Splash screen
InvokeClose invokeClose = new InvokeClose(splashScreen.Close);
splashScreen.Invoke(invokeClose);
}
finally
{
// Release the handle 
owner.ReleaseHandle();
}
}
// Display the splash screen
private void ShowSplashScreen (object param)
{ 
IWin32Window owner = (IWin32Window)param;
// show the splash form with the specified owner form.
splashScreen.ShowDialog(owner);
}
private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
{
}
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="direction:ltr; unicode-bidi:normal"><span><span>First, create word Add-in project by using the Visual studio and add the necessary namespace.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word; 
</pre>
<pre class="hidden">Imports System.Windows.Forms
Imports System.Threading
Imports System.Diagnostics
</pre>
<pre id="codePreview" class="csharp">using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word; 
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="direction:ltr; unicode-bidi:normal"><span>&nbsp;</span></p>
<p style="direction:ltr; unicode-bidi:normal"><span><span>Then show the splash form in background thread.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">// Create and start the splash thread
Thread splashThread = new Thread(new ParameterizedThreadStart(SplashScreen));
splashThread.Start(owner);
// Display the splash screen
private void SplashScreen(object param)
{ 
IWin32Window owner = (IWin32Window)param;
// show the splash form with the specified owner form.
splashScreen.ShowDialog(owner);
}
</pre>
<pre class="hidden">' Create and start the splash thread
Dim splashThread As New Thread(New ParameterizedThreadStart(AddressOf ShowSplashScreen))
splashThread.Start(owner)
' Display the splash screen
Private Sub ShowSplashScreen(param As Object)
Dim owner As IWin32Window = DirectCast(param, IWin32Window)
' show the splash form with the specified owner form.
splashScreen.ShowDialog(owner)
End Sub
</pre>
<pre id="codePreview" class="csharp">// Create and start the splash thread
Thread splashThread = new Thread(new ParameterizedThreadStart(SplashScreen));
splashThread.Start(owner);
// Display the splash screen
private void SplashScreen(object param)
{ 
IWin32Window owner = (IWin32Window)param;
// show the splash form with the specified owner form.
splashScreen.ShowDialog(owner);
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="direction:ltr; unicode-bidi:normal"><span>&nbsp;</span></p>
<p style="direction:ltr; unicode-bidi:normal"><span><span>At last, close the splash form.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">// Do some long operation.
for (int i = 1; i &lt; 5000; i&#43;&#43;)
{
p.Range.Text = i.ToString();
}
// Close the Splash screen
InvokeClose invokeClose = new InvokeClose(splashScreen.Close);
splashScreen.Invoke(invokeClose);
</pre>
<pre class="hidden">' Do some long operation.
For i As Integer = 1 To 4999
p.Range.Text = i.ToString()
Next
' Close the Splash screen
Dim invokeClose As New InvokeClose(AddressOf splashScreen.Close)
splashScreen.Invoke(invokeClose)
</pre>
<pre id="codePreview" class="csharp">// Do some long operation.
for (int i = 1; i &lt; 5000; i&#43;&#43;)
{
p.Range.Text = i.ToString();
}
// Close the Splash screen
InvokeClose invokeClose = new InvokeClose(splashScreen.Close);
splashScreen.Invoke(invokeClose);
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="direction:ltr; unicode-bidi:normal"><span>&nbsp;</span></p>
<p style="direction:ltr; unicode-bidi:normal"><span><span>First you can get the </span>
<span>following </span><span>result:</span></span></p>
<p style="direction:ltr; unicode-bidi:normal"><span><span><img src="/site/view/file/113554/1/image.png" alt="" width="479" height="379" align="middle">
</span></span></p>
<p style="direction:ltr; unicode-bidi:normal"><span><span>After a while, the splash form will close, you can only see word form as
</span><span>follows</span><span>:</span></span></p>
<p style="direction:ltr; unicode-bidi:normal"><span><span><img src="/site/view/file/113555/1/image.png" alt="" width="479" height="307" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="direction:ltr; unicode-bidi:normal"><span><span>NativeWindow Class:</span></span></p>
<p style="direction:ltr; unicode-bidi:normal"><span><a href="http://msdn.microsoft.com/en-us/library/system.windows.forms.nativewindow(v=vs.110).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/system.windows.forms.nativewindow(v=vs.110).aspx</span></a><span>
</span></span></p>
<p style="direction:ltr; unicode-bidi:normal"><span>&nbsp;</span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
