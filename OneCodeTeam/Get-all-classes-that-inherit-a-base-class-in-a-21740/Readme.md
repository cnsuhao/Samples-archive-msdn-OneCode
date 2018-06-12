# Get all classes that inherit a base class in a .NET Windows Store app2
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows 8
* Windows Store app Development
## Topics
* Reflection
## IsPublished
* False
## ModifiedDate
* 2013-04-21 06:27:16
## Description
&lt;STYLE id=dynCom type=text/css&gt;&lt;/STYLE&gt;
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:24pt 0pt 0pt; line-height:27.6pt">
<span style="font-size:14pt; font-weight:bold"><span style="font-size:14pt; font-family:Calibri Light; font-weight:bold">&lt;Title&gt; (&lt;Sample Name&gt;)</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:10pt 0pt 0pt; line-height:27.6pt">
<span style="font-size:13pt; font-weight:bold"><span style="font-size:13pt; font-family:Calibri Light; font-weight:bold">Introduction</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">&lt;What programming task does this code sample solve? What specifically does the code sample demonstrate?&gt;</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt">&nbsp;</span> </p>
<table cellspacing="0" style="border-collapse:collapse; margin-left:0pt">
<tbody>
<tr>
<td style="border-top:#000000 0.5pt solid; border-right:#000000 0.5pt solid; vertical-align:top; border-bottom:#000000 0.5pt solid; padding-bottom:0pt; padding-top:0pt; padding-left:5.4pt; border-left:#000000 0.5pt solid; line-height:24pt; padding-right:5.4pt; width:144pt">
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt">&nbsp;</span> </p>
</td>
<td style="border-top:#000000 0.5pt solid; border-right:#000000 0.5pt solid; vertical-align:top; border-bottom:#000000 0.5pt solid; padding-bottom:0pt; padding-top:0pt; padding-left:5.4pt; border-left:#000000 0.5pt solid; line-height:24pt; padding-right:5.4pt; width:144pt">
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-family:Calibri; font-weight:bold">Col1</span></span>
</p>
</td>
<td style="border-top:#000000 0.5pt solid; border-right:#000000 0.5pt solid; vertical-align:top; border-bottom:#000000 0.5pt solid; padding-bottom:0pt; padding-top:0pt; padding-left:5.4pt; border-left:#000000 0.5pt solid; line-height:24pt; padding-right:5.4pt; width:144pt">
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-family:Calibri; font-weight:bold">Col2</span></span>
</p>
</td>
</tr>
<tr>
<td style="border-top:#000000 0.5pt solid; border-right:#000000 0.5pt solid; vertical-align:top; border-bottom:#000000 0.5pt solid; padding-bottom:0pt; padding-top:0pt; padding-left:5.4pt; border-left:#000000 0.5pt solid; line-height:24pt; padding-right:5.4pt; width:144pt">
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-family:Calibri; font-weight:bold">Row1</span></span>
</p>
</td>
<td style="border-top:#000000 0.5pt solid; border-right:#000000 0.5pt solid; vertical-align:top; border-bottom:#000000 0.5pt solid; padding-bottom:0pt; padding-top:0pt; padding-left:5.4pt; border-left:#000000 0.5pt solid; line-height:24pt; padding-right:5.4pt; width:144pt">
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">Data11</span></span>
</p>
</td>
<td style="border-top:#000000 0.5pt solid; border-right:#000000 0.5pt solid; vertical-align:top; border-bottom:#000000 0.5pt solid; padding-bottom:0pt; padding-top:0pt; padding-left:5.4pt; border-left:#000000 0.5pt solid; line-height:24pt; padding-right:5.4pt; width:144pt">
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">Data12</span></span>
</p>
</td>
</tr>
<tr>
<td style="border-top:#000000 0.5pt solid; border-right:#000000 0.5pt solid; vertical-align:top; border-bottom:#000000 0.5pt solid; padding-bottom:0pt; padding-top:0pt; padding-left:5.4pt; border-left:#000000 0.5pt solid; line-height:24pt; padding-right:5.4pt; width:144pt">
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-family:Calibri; font-weight:bold">Row2</span></span>
</p>
</td>
<td style="border-top:#000000 0.5pt solid; border-right:#000000 0.5pt solid; vertical-align:top; border-bottom:#000000 0.5pt solid; padding-bottom:0pt; padding-top:0pt; padding-left:5.4pt; border-left:#000000 0.5pt solid; line-height:24pt; padding-right:5.4pt; width:144pt">
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">Data21</span></span>
</p>
</td>
<td style="border-top:#000000 0.5pt solid; border-right:#000000 0.5pt solid; vertical-align:top; border-bottom:#000000 0.5pt solid; padding-bottom:0pt; padding-top:0pt; padding-left:5.4pt; border-left:#000000 0.5pt solid; line-height:24pt; padding-right:5.4pt; width:144pt">
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">Data22</span></span>
</p>
</td>
</tr>
<tr>
<td style="border-top:medium none; border-right:medium none; border-bottom:medium none; padding-bottom:0px; padding-top:0px; padding-left:0px; margin:0px; border-left:medium none; padding-right:0px; width:144pt">
</td>
<td style="border-top:medium none; border-right:medium none; border-bottom:medium none; padding-bottom:0px; padding-top:0px; padding-left:0px; margin:0px; border-left:medium none; padding-right:0px; width:144pt">
</td>
<td style="border-top:medium none; border-right:medium none; border-bottom:medium none; padding-bottom:0px; padding-top:0px; padding-left:0px; margin:0px; border-left:medium none; padding-right:0px; width:144pt">
</td>
</tr>
</tbody>
</table>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt">&nbsp;</span> </p>
<table cellspacing="0" style="border-collapse:collapse; margin-left:0pt">
<tbody>
<tr>
<td style="border-top:#000000 0.5pt solid; border-right:#000000 0.5pt solid; vertical-align:top; border-bottom:#000000 0.5pt solid; padding-bottom:0pt; padding-top:0pt; padding-left:5.4pt; border-left:#000000 0.5pt solid; line-height:24pt; padding-right:5.4pt; width:432pt">
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:consolas; color:#008000">--HTML code snippet start--</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:consolas">&lt;button&gt;</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:consolas; color:#008000">--HTML code snippet end--</span></span>
</p>
</td>
</tr>
<tr>
<td style="border-top:medium none; border-right:medium none; border-bottom:medium none; padding-bottom:0px; padding-top:0px; padding-left:0px; margin:0px; border-left:medium none; padding-right:0px; width:432pt">
</td>
</tr>
</tbody>
</table>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:10pt 0pt 0pt; line-height:27.6pt">
<span style="font-size:13pt; font-weight:bold"><span style="font-size:13pt; font-family:Calibri Light; font-weight:bold">Building the Sample</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">&lt;This section is optional. If there are special requirements or
</span><span style="font-size:11pt; font-family:Calibri">instructions for building the sample (e.g. the sample requires certain SDKs), please add this section and illustrate the requirements and steps.&gt;</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:10pt 0pt 0pt; line-height:27.6pt">
<span style="font-size:13pt; font-weight:bold"><span style="font-size:13pt; font-family:Calibri Light; font-weight:bold">Running the Sample</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">&lt;Describe the demo steps of the sample with screenshots. If there are special requirements</span><span style="font-size:11pt; font-family:Calibri"> for deploying and running the
 sample (e.g. the sample must be run on Windows 7), please illustrate them in this section too.&gt;</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:10pt 0pt 0pt; line-height:27.6pt">
<span style="font-size:13pt; font-weight:bold"><span style="font-size:13pt; font-family:Calibri Light; font-weight:bold">Using the Code</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:consolas">---------------------------------------------------------</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:consolas; font-weight:bold; color:#008000"></span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span><span>C&#43;&#43;</span><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span><span class="hidden">cplusplus</span><span class="hidden">js</span>
<pre class="hidden"> 
int a = 0; 
int b = 11; 
</pre>
<pre class="hidden"> 
dim c = 3 
</pre>
<pre class="hidden"> 
int d = 14; 
</pre>
<pre class="hidden"> 
var btn = $(&quot;#btnSave&quot;); 
</pre>
<pre id="codePreview" class="csharp"> 
int a = 0; 
int b = 11; 
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:consolas">---------------------------------------------------------</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><a name="_GoBack"></a><span style="font-family:Segoe UI; color:#676767"><img src="/site/view/file/80345/1/image.png" alt="" width="651" height="127" align="middle">
</span></span></p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:10pt 0pt 0pt; line-height:27.6pt">
<span style="font-size:13pt; font-weight:bold"><span style="font-size:13pt; font-family:Calibri Light; font-weight:bold">More Information</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">&lt;For more information on X, see ...?&gt;</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">&lt;Describe the demo steps of the sample with screenshots. If there are special requirements</span><span style="font-size:11pt; font-family:Calibri"> for deploying and running the
 sample (e.g. the sample must be run on Windows 7), please illustrate them in this section too.&gt;</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">&lt;Describe the demo steps of the sample with screenshots. If there are special requirements</span><span style="font-size:11pt; font-family:Calibri"> for deploying and running the
 sample (e.g. the sample must be run on Windows 7), please illustrate them in this section too.&gt;</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">&lt;Describe the demo steps of the sample with screenshots. If there are special requirements</span><span style="font-size:11pt; font-family:Calibri"> for deploying and running the
 sample (e.g. the sample must be run on Windows 7), please illustrate them in this section too.&gt;</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">&lt;Describe the demo steps of the sample with screenshots. If there are special requirements</span><span style="font-size:11pt; font-family:Calibri"> for deploying and running the
 sample (e.g. the sample must be run on Windows 7), please illustrate them in this section too.&gt;</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">&lt;Describe the demo steps of the sample with screenshots. If there are special requirements</span><span style="font-size:11pt; font-family:Calibri"> for deploying and running the
 sample (e.g. the sample must be run on Windows 7), please illustrate them in this section too.&gt;</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">&lt;Describe the demo steps of the sample with screenshots. If there are special requirements</span><span style="font-size:11pt; font-family:Calibri"> for deploying and running the
 sample (e.g. the sample must be run on Windows 7), please illustrate them in this section too.&gt;</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">&lt;Describe the demo steps of the sample with screenshots. If there are special requirements</span><span style="font-size:11pt; font-family:Calibri"> for deploying and running the
 sample (e.g. the sample must be run on Windows 7), please illustrate them in this section too.&gt;</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">&lt;Describe the demo steps of the sample with screenshots. If there are special requirements</span><span style="font-size:11pt; font-family:Calibri"> for deploying and running the
 sample (e.g. the sample must be run on Windows 7), please illustrate them in this section too.&gt;</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">&lt;Describe the demo steps of the sample with screenshots. If there are special requirements</span><span style="font-size:11pt; font-family:Calibri"> for deploying and running the
 sample (e.g. the sample must be run on Windows 7), please illustrate them in this section too.&gt;</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">&lt;Describe the demo steps of the sample with screenshots. If there are special requirements</span><span style="font-size:11pt; font-family:Calibri"> for deploying and running the
 sample (e.g. the sample must be run on Windows 7), please illustrate them in this section too.&gt;</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">&lt;Describe the demo steps of the sample with screenshots. If there are special requirements</span><span style="font-size:11pt; font-family:Calibri"> for deploying and running the
 sample (e.g. the sample must be run on Windows 7), please illustrate them in this section too.&gt;</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">&lt;Describe the demo steps of the sample with screenshots. If there are special requirements</span><span style="font-size:11pt; font-family:Calibri"> for deploying and running the
 sample (e.g. the sample must be run on Windows 7), please illustrate them in this section too.&gt;</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">&lt;Describe the demo steps of the sample with screenshots. If there are special requirements</span><span style="font-size:11pt; font-family:Calibri"> for deploying and running the
 sample (e.g. the sample must be run on Windows 7), please illustrate them in this section too.&gt;</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">&lt;Describe the demo steps of the sample with screenshots. If there are special requirements</span><span style="font-size:11pt; font-family:Calibri"> for deploying and running the
 sample (e.g. the sample must be run on Windows 7), please illustrate them in this section too.&gt;</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">&lt;Describe the demo steps of the sample with screenshots. If there are special requirements</span><span style="font-size:11pt; font-family:Calibri"> for deploying and running the
 sample (e.g. the sample must be run on Windows 7), please illustrate them in this section too.&gt;</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">&lt;Describe the demo steps of the sample with screenshots. If there are special requirements</span><span style="font-size:11pt; font-family:Calibri"> for deploying and running the
 sample (e.g. the sample must be run on Windows 7), please illustrate them in this section too.&gt;</span></span>
</p>
<p style="font-size:10pt; font-family:'Times New Roman'; unicode-bidi:normal; direction:ltr; margin:0pt 0pt 10pt; line-height:27.6pt">
<span style="font-size:11pt"><span style="font-size:11pt; font-family:Calibri">&lt;Describe the demo steps of the sample with screenshots. If there are special requirements</span><span style="font-size:11pt; font-family:Calibri"> for deploying and running the
 sample (e.g. the sample must be run on Windows 7), please illustrate them in this section too.&gt;</span></span>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
