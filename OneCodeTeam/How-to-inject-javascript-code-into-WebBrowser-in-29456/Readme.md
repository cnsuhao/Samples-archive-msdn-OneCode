# How to inject javascript code into WebBrowser in Windows Forms applications
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* Windows Forms
* Internet Explorer
* .NET Development
* Internet Explorer Development
## Topics
* WebBrowser
* code snippets
* inject code
## IsPublished
* True
## ModifiedDate
* 2014-06-24 10:18:49
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to inject JavaScript code into a WebBrowser control in Windows Forms applications
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This is a code snippet project which will show you how to inject JavaScript code into a System.Windows.Forms.Webbrowser control in Windows Forms applications.
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Step1. Create a Windows Forms application in Visual Studio, then drag a WebBrowser control to the default form, and then s</span><span>et its Url property.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Step2. Add a required reference
</span><span style="font-size:11pt">by</span><span style="font-size:11pt"> following
</span><span style="font-size:11pt">the </span><span style="font-size:11pt">steps</span><span style="font-size:11pt"> shown below</span><span style="font-size:11pt">:</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Right-click the project, choose
</span><span style="font-weight:bold">Add reference...</span><span style="font-size:11pt"> -&gt;
</span><span style="font-weight:bold">COM </span><span style="font-size:11pt">-&gt;
</span><span style="font-weight:bold">Type Libraries</span><span style="font-size:11pt">, and then choose &quot;</span><span style="font-weight:bold">Microsoft HTML Object Library</span><span>&quot;.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>Step3. Add a namespace: </span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span><span class="hidden">cplusplus</span>
<pre class="hidden">using mshtml;
</pre>
<pre class="hidden">Imports mshtml
</pre>
<pre class="hidden">using namespace MSHTML;
</pre>
<pre id="codePreview" class="csharp">using mshtml;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>Step4. The following code snippet shows how to inject JavaScript code into the WebBrowser control.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span><span class="hidden">cplusplus</span>
<pre class="hidden">private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
{
    HtmlElement headElement = webBrowser1.Document.GetElementsByTagName(&quot;head&quot;)[0];
    HtmlElement scriptElement = webBrowser1.Document.CreateElement(&quot;script&quot;);
    IHTMLScriptElement element = (IHTMLScriptElement)scriptElement.DomElement;
    element.text = &quot;function sayHello() { alert('hello') }&quot;;
    headElement.AppendChild(scriptElement);
    webBrowser1.Document.InvokeScript(&quot;sayHello&quot;);
}
</pre>
<pre class="hidden">Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
    Dim headElement As HtmlElement = WebBrowser1.Document.GetElementsByTagName(&quot;head&quot;)(0)
    Dim scriptElement As HtmlElement = WebBrowser1.Document.CreateElement(&quot;script&quot;)
    Dim element As IHTMLScriptElement = DirectCast(scriptElement.DomElement, IHTMLScriptElement)
    element.text = &quot;function sayHello() { alert('hello') }&quot;
    headElement.AppendChild(scriptElement)
    WebBrowser1.Document.InvokeScript(&quot;sayHello&quot;)
End Sub
</pre>
<pre class="hidden">System::Void MyForm::webBrowser1_DocumentCompleted(System::Object^  sender, System::Windows::Forms::WebBrowserDocumentCompletedEventArgs^  e) 
{
 HtmlElement^ headElement = webBrowser1-&gt;Document-&gt;GetElementsByTagName(&quot;head&quot;)[0];
 HtmlElement^ scriptElement = webBrowser1-&gt;Document-&gt;CreateElement(&quot;script&quot;); 
 IHTMLScriptElement^ element = (IHTMLScriptElement^)scriptElement-&gt;DomElement; 
 element-&gt;text = &quot;function sayHello() { alert('hello') }&quot;; 
 headElement-&gt;AppendChild(scriptElement);
 webBrowser1-&gt;Document-&gt;InvokeScript(&quot;sayHello&quot;);
}
</pre>
<pre id="codePreview" class="csharp">private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
{
    HtmlElement headElement = webBrowser1.Document.GetElementsByTagName(&quot;head&quot;)[0];
    HtmlElement scriptElement = webBrowser1.Document.CreateElement(&quot;script&quot;);
    IHTMLScriptElement element = (IHTMLScriptElement)scriptElement.DomElement;
    element.text = &quot;function sayHello() { alert('hello') }&quot;;
    headElement.AppendChild(scriptElement);
    webBrowser1.Document.InvokeScript(&quot;sayHello&quot;);
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>Step5. You can build and run the application. If everything is going well, you will see a greeting message:</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/117487/1/image.png" alt="" width="222" height="169" align="middle">
</span><a name="_GoBack"></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">WebBrowser control</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/system.windows.forms.webbrowser(v=vs.110).ASPX" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/system.windows.forms.webbrowser(v=vs.110).ASPX</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">WebBrowser.Document Property</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/system.windows.forms.webbrowser.document(v=vs.110).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/system.windows.forms.webbrowser.document(v=vs.110).aspx</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">HtmlDocument Class</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/system.windows.forms.htmldocument(v=vs.110).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/system.windows.forms.htmldocument(v=vs.110).aspx</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>HtmlDocument.InvokeScript Method</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/system.windows.forms.htmldocument.invokescript(v=vs.110).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/system.windows.forms.htmldocument.invokescript(v=vs.110).aspx</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
