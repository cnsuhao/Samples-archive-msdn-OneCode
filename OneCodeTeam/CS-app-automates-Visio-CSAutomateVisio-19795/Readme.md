# CS app automates Visio (CSAutomateVisio)
## Requires
* Visual Studio 2012
## License
* MS-LPL
## Technologies
* Office
## Topics
* Automation
* Visio
## IsPublished
* True
## ModifiedDate
* 2012-12-03 11:16:48
## Description

<h1><span style="">Office Automation</span> (<span style="">CSAutomateVisio</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The CSAutomateVisio provides the examples on how to automate Office Visio 20<span style="">13</span> via Visio Object Model.
<span style=""></span></p>
<p class="MsoNormal">The <span style="">CS</span>AutomateVisio example demonstrates the use of
<span style="">C#</span> codes to create a Microsoft Visio<span style=""> </span>
instance, create a new document, <span style="">draw a rectangle and an oval on the</span>
<span style="">first page. Save the document as a vsd file and close it. </span><span style="">&nbsp;</span><span style="">Quite</span> the Microsoft
<span style="">Visio</span> application and then clean up unmanaged COM resources.</p>
<p class="MsoNormal">Office automation is based on Component Object Model (COM). When you call a COM object of Office from managed code, a Runtime Callable Wrapper (RCW) is automatically created. The RCW marshals calls between the .NET application and the
 COM object. The RCW keeps a reference count on the COM object. If all references have not been released on the RCW, the COM object of Office does not quit and may cause the Office application not to quit after your automation. In order to make sure that the
 Office application quits cleanly, the sample demonstrates two solutions.</p>
<p class="MsoNormal">Solution1.Automate<span style="">Visio</span> demonstrates automating Microsoft
<span style="">Visio</span> application by using Microsoft <span style="">Visio</span> Primary Interop Assembly (PIA) and explicitly assigning each COM accessor object to a new variable that you would explicitly call Marshal.FinalReleaseComObject to release
 it at the end.</p>
<p class="MsoNormal">&nbsp;Solution2.Automate<span style="">Visio</span> demonstrates automating Microsoft
<span style="">Visio</span> application by using Microsoft <span style="">Visio</span> PIA and forcing a garbage collection as soon as the automation function is off the stack (at which point the RCW objects are no longer rooted) to clean up RCWs and release
 COM objects<span style="">. </span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal">You must run this code <span style="">on a computer that has Microsoft Office Visio2013 installed.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/71847/1/image.png" alt="" width="490" height="328" align="middle">
</span><span style=""></span></p>
<h2>Using the Code<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span></h2>
<p class="MsoNormal">1. Add Reference to Microsoft Visio 1<span style="">5</span>.0 Type Library<span style="">.
</span></p>
<p class="MsoNormal">2. Get Visio Application object via Marshal.GetActiveObject or by creating<span style="">
</span><span style="">&nbsp;</span>a new Visio application instance.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
oVisio = new Visio.Application();

</pre>
<pre id="codePreview" class="csharp">
oVisio = new Visio.Application();

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">3. Add a new document and insert some drawing into it.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
         oDocs = oVisio.Documents;
       oDoc = oDocs.Add(&quot;&quot;);
       Console.WriteLine(&quot;A new document is created&quot;);


       // Draw a rectangle and an oval on the first page.


       Console.WriteLine(&quot;Draw a rectangle and a oval&quot;);


       oPages = oDoc.Pages;
       oPage = oPages[1];
       oRectShape = oPage.DrawRectangle(0.5, 10.25, 6.25, 7.375);
       oOvalShape = oPage.DrawOval(1.125, 6, 6.875, 2.125);

</pre>
<pre id="codePreview" class="csharp">
         oDocs = oVisio.Documents;
       oDoc = oDocs.Add(&quot;&quot;);
       Console.WriteLine(&quot;A new document is created&quot;);


       // Draw a rectangle and an oval on the first page.


       Console.WriteLine(&quot;Draw a rectangle and a oval&quot;);


       oPages = oDoc.Pages;
       oPage = oPages[1];
       oRectShape = oPage.DrawRectangle(0.5, 10.25, 6.25, 7.375);
       oOvalShape = oPage.DrawOval(1.125, 6, 6.875, 2.125);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">4. Save new added document according to user's input.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
string fileName = Path.GetDirectoryName(
    Assembly.GetExecutingAssembly().Location) &#43; &quot;\\Sample1.vsd&quot;;
oDoc.SaveAs(fileName);

</pre>
<pre id="codePreview" class="csharp">
string fileName = Path.GetDirectoryName(
    Assembly.GetExecutingAssembly().Location) &#43; &quot;\\Sample1.vsd&quot;;
oDoc.SaveAs(fileName);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">5. Release the COM objects.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
if (oOvalShape != null)
               {
                   Marshal.FinalReleaseComObject(oOvalShape);
                   oOvalShape = null;
               }
               if (oRectShape != null)
               {
                   Marshal.FinalReleaseComObject(oRectShape);
                   oRectShape = null;
               }
               if (oPage != null)
               {
                   Marshal.FinalReleaseComObject(oPage);
                   oPage = null;
               }
               if (oPages != null)
               {
                   Marshal.FinalReleaseComObject(oPages);
                   oPages = null;
               }
               if (oDoc != null)
               {
                   Marshal.FinalReleaseComObject(oDoc);
                   oDoc = null;
               }
               if (oDocs != null)
               {
                   Marshal.FinalReleaseComObject(oDocs);
                   oDocs = null;
               }
               if (oVisio != null)
               {
                   Marshal.FinalReleaseComObject(oVisio);
                   oVisio = null;
               }

</pre>
<pre id="codePreview" class="csharp">
if (oOvalShape != null)
               {
                   Marshal.FinalReleaseComObject(oOvalShape);
                   oOvalShape = null;
               }
               if (oRectShape != null)
               {
                   Marshal.FinalReleaseComObject(oRectShape);
                   oRectShape = null;
               }
               if (oPage != null)
               {
                   Marshal.FinalReleaseComObject(oPage);
                   oPage = null;
               }
               if (oPages != null)
               {
                   Marshal.FinalReleaseComObject(oPages);
                   oPages = null;
               }
               if (oDoc != null)
               {
                   Marshal.FinalReleaseComObject(oDoc);
                   oDoc = null;
               }
               if (oDocs != null)
               {
                   Marshal.FinalReleaseComObject(oDocs);
                   oDocs = null;
               }
               if (oVisio != null)
               {
                   Marshal.FinalReleaseComObject(oVisio);
                   oVisio = null;
               }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information<span style=""> </span></h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/cc160740.aspx">Visio Object Model Overveiw</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
