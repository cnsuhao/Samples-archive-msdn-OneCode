# Using Direct2D for Server-Side Rendering with ASP.NET (CSD2DServerSideRendering)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Direct2D
* ASP.NET
## Topics
* Drawing
## IsPublished
* False
## ModifiedDate
* 2012-02-21 09:44:26
## Description

<div class="WordSection1">
<div class="MsoNormalCxSpFirst" style="margin-top:24.0pt; margin-right:0cm; margin-bottom:.0001pt; margin-left:0cm">
<strong><span style="font-size:14.0pt; line-height:115%">Using Direct2D for Server-Side Rendering with ASP.NET (CSD2DServerSideRendering)</span></strong></div>
<div class="MsoNormal" style="margin-top:10.0pt; margin-right:0cm; margin-bottom:.0001pt; margin-left:0cm">
<strong><span style="font-size:13.0pt; line-height:115%">Introduction</span></strong></div>
<div class="MsoNormal" style="margin-top:10.0pt; margin-right:0cm; margin-bottom:.0001pt; margin-left:0cm">
Some server applications need to render images and send back the generated bitmaps to users connected through web clients.<span>&nbsp;
</span>GDI&#43; and <span class="SpellE">System.Drawing</span> are not supported in a service or web application.<span>&nbsp;
</span>Direct2D is the appropriate technology for rendering images to a bitmap on disk in a service context.<span>&nbsp;
</span>Direct2D is completely supported in the context of a service.<span>&nbsp; </span>
This is a C# ASP.NET sample which demonstrates how to render a Direct2D scene to an image file on disk.<span>&nbsp;
</span>It demonstrates how to create a Direct2D bitmap based on image data in memory, draw Direct2D objects, such as an Ellipse and a Rectangle, and it also demonstrates how to use
<span class="SpellE">DirectWrite</span> to render text.<span>&nbsp; </span>The sample uses the Direct2D and
<span class="SpellE">DirectWrite</span> assemblies from the Windows API Code Pack for Microsoft .NET Framework.<span>&nbsp;
</span>These provide <span class="GramE">developers</span> access to Direct2D and
<span class="SpellE">DirectWrite</span> from managed code.</div>
<h1 class="MsoNormal" style="margin-top:10.0pt; margin-right:0cm; margin-bottom:.0001pt; margin-left:0cm">
Run-time requirements</h1>
<div class="MsoNormal" style="margin-top:10.0pt; margin-right:0cm; margin-bottom:.0001pt; margin-left:0cm">
Windows 7 or Windows Vista with Service Pack 2 (SP2) and Platform Update for Windows Vista<br>
Windows Server 2008 R2 or Windows Server 2008 with Service Pack 2 (SP2) and Platform Update for Windows Server 2008&nbsp;&nbsp;</div>
<div class="MsoNormal" style="margin-top:10.0pt; margin-right:0cm; margin-bottom:.0001pt; margin-left:0cm">
<strong><span style="font-size:13.0pt; line-height:115%">Running the Sample</span></strong></div>
<div class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
This code demonstrates how to use Direct2D to render 2D objects and text to an image file on disk.<span>&nbsp;
</span>You will need to grant permission to the &quot;Network Service&quot; user account for the folder on the server that you wish to save the image file to.<span>&nbsp;
</span>You can set that location in this portion of the code:</div>
<div class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">wicBitmap.SaveToFile(wicFactory, ContainerFormats.Png, &quot;c:\\SampleFiles\\Images\\test.png&quot;);</pre>
<div class="preview">
<pre class="csharp">wicBitmap.SaveToFile(wicFactory,&nbsp;ContainerFormats.Png,&nbsp;<span class="cs__string">&quot;c:\\SampleFiles\\Images\\test.png&quot;</span>);</pre>
</div>
</div>
</div>
</div>
<div class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Execute the sample and then press the &ldquo;<strong>Create Image File</strong>&rdquo; button.<span>&nbsp;
</span>You will now see your Direct2D scene rendered to the PNG file on disk (at the server where the code is executed):</div>
<div class="MsoNormal"><span><img src="/site/view/file/47054/1/image001.png" alt="" width="434" height="433"></span></div>
<div class="MsoNormal">&nbsp;</div>
<div class="MsoNormal" style="margin-top:10.0pt; margin-right:0cm; margin-bottom:.0001pt; margin-left:0cm">
<strong><span style="font-size:13.0pt; line-height:115%">Using the Code</span></strong></div>
<div class="MsoNormal">Server side applications often need to render images and send back the generated bitmaps to users connected through web clients. The problem is that GDI&#43; and
<span class="SpellE">System.Drawing</span> are not supported in a service or web application.<span>&nbsp;
</span>Direct2D is supported but there are few samples which demonstrate how to use Direct2D from C# and also create a bitmap file on disk of a Direct2D scene.<span>&nbsp;
</span>My hope is that many web developers will be able to use this sample to convert their (problematic)
<span class="SpellE">System.Drawing</span> code to Direct2D.<span>&nbsp; </span>
One example would be a shipping label that is generated server side and then sent to the client for use.<span>&nbsp;
</span>You can call <span class="SpellE"><span class="GramE">DrawText</span></span><span class="GramE">(</span>) as follows to render text on the shipping label:</div>
<div class="MsoNormal">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">wicRenderTarget.DrawText(&quot;This is a test&quot;, textFormat_Value, renderText_Value, blackSolidColorBrush);</pre>
<div class="preview">
<pre class="csharp">wicRenderTarget.DrawText(<span class="cs__string">&quot;This&nbsp;is&nbsp;a&nbsp;test&quot;</span>,&nbsp;textFormat_Value,&nbsp;renderText_Value,&nbsp;blackSolidColorBrush);</pre>
</div>
</div>
</div>
</div>
<div class="MsoNormal" style="margin-top:10.0pt; margin-right:0cm; margin-bottom:.0001pt; margin-left:0cm">
Look at the <span class="SpellE"><span class="GramE"><strong>CreateBitmap</strong></span></span><span class="GramE">(</span>) method to see how I create a Direct2D bitmap based on image data in memory.<span>&nbsp;
</span>This creates a Bitmap which you can render to your Direct2D scene, such as a barcode, for example.<span>&nbsp;
</span>You can draw this barcode Bitmap on the shipping label with the following code:</div>
<div class="MsoNormal" style="margin-top:10.0pt; margin-right:0cm; margin-bottom:.0001pt; margin-left:0cm">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">RectF DrawBitmap_Rect;
DrawBitmap_Rect = new RectF(10, 275, 180, 350);
wicRenderTarget.DrawBitmap(d2dBitmapBarcode, 1.0f, BitmapInterpolationMode.NearestNeighbor, DrawBitmap_Rect);</pre>
<div class="preview">
<pre class="csharp">RectF&nbsp;DrawBitmap_Rect;&nbsp;
DrawBitmap_Rect&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RectF(<span class="cs__number">10</span>,&nbsp;<span class="cs__number">275</span>,&nbsp;<span class="cs__number">180</span>,&nbsp;<span class="cs__number">350</span>);&nbsp;
wicRenderTarget.DrawBitmap(d2dBitmapBarcode,&nbsp;<span class="cs__number">1</span>.0f,&nbsp;BitmapInterpolationMode.NearestNeighbor,&nbsp;DrawBitmap_Rect);</pre>
</div>
</div>
</div>
<div class="endscriptcode">Once you have finished rendering your Direct2D objects to memory, then you can call the following method to save the image to a file on disk:</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">wicBitmap.SaveToFile(wicFactory, ContainerFormats.Png, &quot;c:\\SampleFiles\\Images\\test.png&quot;);</pre>
<div class="preview">
<pre class="csharp">wicBitmap.SaveToFile(wicFactory,&nbsp;ContainerFormats.Png,&nbsp;<span class="cs__string">&quot;c:\\SampleFiles\\Images\\test.png&quot;</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<div class="MsoNormal" style="margin-top:10.0pt; margin-right:0cm; margin-bottom:.0001pt; margin-left:0cm">
<strong><span style="font-size:13.0pt; line-height:115%">More Information</span></strong></div>
<span style="font-family:Symbol"><span>&nbsp;</span></span>For more information on
<span class="SpellE">DirectWrite</span>, see the MSDN <span class="SpellE">DirectWrite</span> documentation:&nbsp;<br>
<span>&nbsp;</span><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/dd368038(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/dd368038(v=vs.85).aspx</a></div>
<div class="WordSection1"></div>
<div class="WordSection1">For more information on DirectWrite, see the MSDN DirectWrite documentation:
<br>
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/dd368038(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/dd368038(v=vs.85).aspx</a></div>
<div class="WordSection1"></div>
<div class="WordSection1">For more information on the Windows API Code Pack for Microsoft .NET Framework, see:</div>
<div class="WordSection1"><a href="http://archive.msdn.microsoft.com/WindowsAPICodePack">http://archive.msdn.microsoft.com/WindowsAPICodePack</a></div>
<div class="WordSection1"></div>
<div class="WordSection1"></div>
<div class="WordSection1">
<p>&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
&nbsp;</div>
