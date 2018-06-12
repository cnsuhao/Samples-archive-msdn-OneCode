# VB app automates PowerPoint (VBAutomatePowerPoint)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Office
## Topics
* Automation
* PowerPoint
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:27:30
## Description

<h1><span style="font-family:������">CONSOLE APPLICATION</span> (<span style="font-family:������">VBAutomatePowerPoint</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The <span style="">VB</span>AutomatePowerPoint example demonstrates the use of
<span style="">VB.NET</span> codes to create a Microsoft PowerPoint instance, add a new presentation, insert a new slide, add some texts to the slide, save the presentation, quit PowerPoint and then clean up unmanaged COM resources.<span style="">
</span>Office automation is based on Component Object Model (COM). When you call a COM object of Office from managed code, a Runtime Callable Wrapper (RCW) is automatically created. The RCW marshals calls between the .NET application and the COM object. The
 RCW keeps a reference count on the COM object. If all references have not been released on the RCW, the COM object of Office does not quit and may cause the Office application not to quit after your automation. In order to make sure that the Office application
 quits cleanly, the sample demonstrates two solutions.</p>
<p class="MsoNormal">Solution1.AutomatePowerPoint demonstrates automating Microsoft PowerPoint application by using Microsoft PowerPoint Primary Interop Assembly (PIA) and explicitly assigning each COM accessor object to a new variable that you would explicitly
 call Marshal.FinalReleaseComObject to release it at the end.</p>
<p class="MsoNormal">Solution2.AutomatePowerPoint demonstrates automating Microsoft PowerPoint application by using Microsoft PowerPoint PIA and forcing a garbage collection as soon as the automation function is off the stack (at which point the RCW objects
 are no longer rooted) to clean up RCWs and release COM objects.<span style="">&nbsp;
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal">The following steps walk through a demonstration of the PowerPoint automation sample that starts a Microsoft PowerPoint instance, adds a new presentation, inserts a slide, adds some texts to the slide, saves the presentation, quits PowerPoint
 and then cleans up unmanaged COM resources.</p>
<p class="MsoNormal">Step1. After you successfully build the sample project in Visual Studio 2010, you will get the application: VBAutomatePowerPoint.exe.</p>
<p class="MsoNormal">Step2. Open Windows Task Manager (Ctrl&#43;Shift&#43;Esc) to confirm that no powerpnt.exe is running.
</p>
<p class="MsoNormal">Step3. Run the application. It should print the following content in the console window if no error is thrown.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53053/1/image.png" alt="" width="576" height="376" align="middle">
</span></p>
<p class="MsoNormal">Then, you will see two new presentations in the directory of the application:</p>
<p class="MsoNormal">Sample1.pptx and Sample2.pptx. Both presentations contain only one slide with the following title.</p>
<p class="MsoNormal"><span style="">&nbsp; </span><span style=""><img src="/site/view/file/53054/1/image.png" alt="" width="576" height="242" align="middle">
</span></p>
<p class="MsoNormal">Step4. In Windows Task Manager, confirm that the powerpnt.exe process does not exist, i.e. the Microsoft PowerPoint intance was closed and cleaned up
</p>
<p class="MsoNormal">properly.</p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step1. Create a Console application and reference the PowerPoint Primary<span style="">&nbsp;
</span>Interop Assembly (PIA) and Office 12. To reference the PowerPoint PIA and Office 12, right-click the project file and click the &quot;Add Reference...&quot; button. In the Add Reference dialog, navigate to the .NET tab, find Microsoft.Office.Interop.PowerPoint
 12.0.0.0 and Office 12.0.0.0 and click OK.</p>
<p class="MsoNormal">Step2. Import and rename the Excel interop and the Office namepaces:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Imports Office = Microsoft.Office.Core
Imports PowerPoint = Microsoft.Office.Interop.PowerPoint

</pre>
<pre id="codePreview" class="vb">
Imports Office = Microsoft.Office.Core
Imports PowerPoint = Microsoft.Office.Interop.PowerPoint

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step3. Start up a PowerPoint application by creating a PowerPoint.Application object.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
oPowerPoint = New PowerPoint.Application()

</pre>
<pre id="codePreview" class="vb">
oPowerPoint = New PowerPoint.Application()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">By default PowerPoint is invisible, till you make it visible.<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Make the PowerPoint instance invisible
oPowerPoint.Visible = Office.MsoTriState.msoFalse
' Or make the PowerPoint instance visible
oPowerPoint.Visible = Office.MsoTriState.msoTrue

</pre>
<pre id="codePreview" class="vb">
' Make the PowerPoint instance invisible
oPowerPoint.Visible = Office.MsoTriState.msoFalse
' Or make the PowerPoint instance visible
oPowerPoint.Visible = Office.MsoTriState.msoTrue

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step4. Get the Presentations collection from Application.Presentations and call its Add function to add a new presentation. The Add function returns a Presentation object.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
oPres = oPowerPoint.Presentations
oPre = oPres.Add()

</pre>
<pre id="codePreview" class="vb">
oPres = oPowerPoint.Presentations
oPre = oPres.Add()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step5. Insert a slide by calling the Add method on the Presentation.Slides collection, and add some texts to the slide.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
oSlides = oPre.Slides
oSlide = oSlides.Add(1, PowerPoint.PpSlideLayout.ppLayoutText)


oShapes = oSlide.Shapes
oShape = oShapes(1)
oTxtFrame = oShape.TextFrame
oTxtRange = oTxtFrame.TextRange
oTxtRange.Text = &quot;All-In-One Code Framework&quot;

</pre>
<pre id="codePreview" class="vb">
oSlides = oPre.Slides
oSlide = oSlides.Add(1, PowerPoint.PpSlideLayout.ppLayoutText)


oShapes = oSlide.Shapes
oShape = oShapes(1)
oTxtFrame = oShape.TextFrame
oTxtRange = oTxtFrame.TextRange
oTxtRange.Text = &quot;All-In-One Code Framework&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step6. Save the presentation as a pptx file and close it.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
    Dim fileName As String = Path.GetDirectoryName( _
    Assembly.GetExecutingAssembly().Location) &#43; &quot;\\Sample1.pptx&quot;
    oPre.SaveAs(fileName, PowerPoint.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, _
            Office.MsoTriState.msoTriStateMixed)
    oPre.Close()

</pre>
<pre id="codePreview" class="vb">
    Dim fileName As String = Path.GetDirectoryName( _
    Assembly.GetExecutingAssembly().Location) &#43; &quot;\\Sample1.pptx&quot;
    oPre.SaveAs(fileName, PowerPoint.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, _
            Office.MsoTriState.msoTriStateMixed)
    oPre.Close()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step7. Quit the PowerPoint application.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
oPowerPoint.Quit()

</pre>
<pre id="codePreview" class="vb">
oPowerPoint.Quit()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step8. Clean up the unmanaged COM resource. To get PowerPoint terminated rightly, we need to call Marshal.FinalReleaseComObject() on each COM object we used. We can either explicitly call Marshal.FinalReleaseComObject on all accessor
 objects:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' See Solution1.AutomatePowerPoint
    If Not oTxtRange Is Nothing Then
        Marshal.FinalReleaseComObject(oTxtRange)
        oTxtRange = Nothing
    End If
    If Not oTxtFrame Is Nothing Then
        Marshal.FinalReleaseComObject(oTxtFrame)
        oTxtFrame = Nothing
    End If
    If Not oShape Is Nothing Then
        Marshal.FinalReleaseComObject(oShape)
        oShape = Nothing
    End If
    If Not oShapes Is Nothing Then
        Marshal.FinalReleaseComObject(oShapes)
        oShapes = Nothing
    End If
    If Not oSlide Is Nothing Then
        Marshal.FinalReleaseComObject(oSlide)
        oSlide = Nothing
    End If
    If Not oSlides Is Nothing Then
        Marshal.FinalReleaseComObject(oSlides)
        oSlides = Nothing
    End If
    If Not oPre Is Nothing Then
        Marshal.FinalReleaseComObject(oPre)
        oPre = Nothing
    End If
    If Not oPres Is Nothing Then
        Marshal.FinalReleaseComObject(oPres)
        oPres = Nothing
    End If
    If Not oPowerPoint Is Nothing Then
        Marshal.FinalReleaseComObject(oPowerPoint)
        oPowerPoint = Nothing
    End If

</pre>
<pre id="codePreview" class="vb">
' See Solution1.AutomatePowerPoint
    If Not oTxtRange Is Nothing Then
        Marshal.FinalReleaseComObject(oTxtRange)
        oTxtRange = Nothing
    End If
    If Not oTxtFrame Is Nothing Then
        Marshal.FinalReleaseComObject(oTxtFrame)
        oTxtFrame = Nothing
    End If
    If Not oShape Is Nothing Then
        Marshal.FinalReleaseComObject(oShape)
        oShape = Nothing
    End If
    If Not oShapes Is Nothing Then
        Marshal.FinalReleaseComObject(oShapes)
        oShapes = Nothing
    End If
    If Not oSlide Is Nothing Then
        Marshal.FinalReleaseComObject(oSlide)
        oSlide = Nothing
    End If
    If Not oSlides Is Nothing Then
        Marshal.FinalReleaseComObject(oSlides)
        oSlides = Nothing
    End If
    If Not oPre Is Nothing Then
        Marshal.FinalReleaseComObject(oPre)
        oPre = Nothing
    End If
    If Not oPres Is Nothing Then
        Marshal.FinalReleaseComObject(oPres)
        oPres = Nothing
    End If
    If Not oPowerPoint Is Nothing Then
        Marshal.FinalReleaseComObject(oPowerPoint)
        oPowerPoint = Nothing
    End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">and/or force a garbage collection as soon as the calling function is off the stack (at which point these objects are no longer rooted) and then call GC.WaitForPendingFinalizers.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
GC.Collect()
GC.WaitForPendingFinalizers()
' GC needs to be called twice in order to get the Finalizers called 
' - the first time in, it simply makes a list of what is to be 
' finalized, the second time in, it actually the finalizing. Only 
' then will the object do its automatic ReleaseComObject.
GC.Collect()
GC.WaitForPendingFinalizers()

</pre>
<pre id="codePreview" class="vb">
GC.Collect()
GC.WaitForPendingFinalizers()
' GC needs to be called twice in order to get the Finalizers called 
' - the first time in, it simply makes a list of what is to be 
' finalized, the second time in, it actually the finalizing. Only 
' then will the object do its automatic ReleaseComObject.
GC.Collect()
GC.WaitForPendingFinalizers()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information<span style=""> </span></h2>
<p class="MsoListParagraph" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/bb265982.aspx">MSDN: PowerPoint 2007 Developer Reference</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
