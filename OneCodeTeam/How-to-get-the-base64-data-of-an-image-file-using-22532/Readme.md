# How to get the base64 data of an image file using JavaScript in Windows store ap
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows 8
* Windows Store app Development
## Topics
* Image
* base64
## IsPublished
* True
## ModifiedDate
* 2013-06-11 01:17:48
## Description

<h1>How to convert image to Base64 string in Windows Store app (JSWindowsStoreAppConvertImageToBase64)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to convert image to base64 string in Windows Store apps.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:0in; margin-left:.5in; margin-bottom:.0001pt; text-indent:-.25in; line-height:12.75pt">
<span style="color:black">1.</span><span style="font-size:7.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:black">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="color:black">Start Visual Studio 2012 and select File &gt; Open &gt; Project/Solution.
</span></p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:0in; margin-left:.5in; margin-bottom:.0001pt; text-indent:-.25in; line-height:12.75pt">
<span style="color:black">2.</span><span style="font-size:7.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:black">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="color:black">Go to the directory in which you download the sample. Go to the directory
 named for<span style="">&nbsp;&nbsp; </span>the sample, and double-click the Microsoft Visual Studio Solution (.sln) file.
</span></p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:0in; margin-left:.5in; margin-bottom:.0001pt; text-indent:-.25in; line-height:12.75pt">
<span style="color:black">3.<span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span>Please make sure the 'Build Action' property of your text file and image file is 'Embedded Resource'.
</span></p>
<p class="MsoNormal" style="margin-left:.5in; text-indent:-.25in; line-height:12.75pt">
<span style="color:black">4.</span><span style="font-size:7.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:black">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="color:black">Press F7 or use Build &gt; Build Solution to build the sample.
</span></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press F5 to debug the app, this screen will display. The left part is the image, and the right part is the converted base64 string.</p>
<p class="MsoListParagraphCxSpMiddle"></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/84029/1/image.png" alt="" width="576" height="329" align="middle">
</span></p>
<p class="MsoListParagraphCxSpLast"><span style=""></span></p>
<p class="MsoNormal"></p>
<h2>Using the Code</h2>
<p class="MsoNormal">The code below shows how to convert image to base64 string.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
var uri = new Windows.Foundation.Uri('ms-appx:///images/SampleBrowser.png');
var file = Windows.Storage.StorageFile.getFileFromApplicationUriAsync(uri).done(function(file)
{
&nbsp;&nbsp;&nbsp; file.openAsync(Windows.Storage.FileAccessMode.read).then(function(stream)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var inputStream = stream.getInputStreamAt(0);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var reader = new Windows.Storage.Streams.DataReader(inputStream);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var size = stream.size;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if(size&gt;0)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; reader.loadAsync(size).then(function()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var buffer = reader.readBuffer(size);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var base64 = Windows.Security.Cryptography.CryptographicBuffer.encodeToBase64String(buffer);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var base64Div = document.getElementById(&quot;base64Div&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; base64Div.textContent = base64;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; })
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;});
})

</pre>
<pre id="codePreview" class="js">
var uri = new Windows.Foundation.Uri('ms-appx:///images/SampleBrowser.png');
var file = Windows.Storage.StorageFile.getFileFromApplicationUriAsync(uri).done(function(file)
{
&nbsp;&nbsp;&nbsp; file.openAsync(Windows.Storage.FileAccessMode.read).then(function(stream)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var inputStream = stream.getInputStreamAt(0);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var reader = new Windows.Storage.Streams.DataReader(inputStream);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var size = stream.size;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if(size&gt;0)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; reader.loadAsync(size).then(function()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var buffer = reader.readBuffer(size);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var base64 = Windows.Security.Cryptography.CryptographicBuffer.encodeToBase64String(buffer);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var base64Div = document.getElementById(&quot;base64Div&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; base64Div.textContent = base64;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; })
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;});
})

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal"><span class="SpellE">RandomAccessStreamOverStream.GetInputStreamAt|getInputStreamAt</span> method</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.streams.randomaccessstreamoverstream.getinputstreamat">http://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.streams.randomaccessstreamoverstream.getinputstreamat</a></p>
<p class="MsoNormal"><span class="SpellE">DataReader</span> Class</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/library/windows/apps/BR208119">http://msdn.microsoft.com/library/windows/apps/BR208119</a></p>
<p class="MsoNormal">CryptographicBuffer.EncodeToBase64String | encodeToBase64String method</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.security.cryptography.cryptographicbuffer.encodetobase64string">http://msdn.microsoft.com/en-us/library/windows/apps/windows.security.cryptography.cryptographicbuffer.encodetobase64string</a></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
