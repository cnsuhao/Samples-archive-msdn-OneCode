# Windows Forms Graphics demo (VBWinFormGraphics)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows Forms
## Topics
* Graphics
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:39:34
## Description

<h1><span style="font-family:������">WINDOWS FORMS APPLICATION</span>(<span style="font-family:������">VBWinFormGraphics</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The Graphics sample demonstrates the fundamentals of GDI&#43; programming. GDI&#43; allows you to create graphics, draw text, and manipulate graphical images as objects. GDI&#43; is designed to offer performance as well as ease of use. You can use
 GDI&#43; to render graphical images on Windows Forms and controls. GDI&#43; has fully replaced GDI, and is now the only way to render graphics programmatically
</p>
<p class="MsoNormal">in Windows Forms applications.</p>
<p class="MsoNormal">In this sample, there're 5 examples:</p>
<p class="MsoNormal">1. Draw A Line.</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>Demonstrates how to draw a solid/dash/dot line.</p>
<p class="MsoNormal">2. Draw A Curve.</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>Demonstrates how to draw a curve, and the difference between antialiasing rendering mode and no antialiasing rendering mode.</p>
<p class="MsoNormal">3. Draw An Arrow.</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>Demonstrates how to draw an arrow.</p>
<p class="MsoNormal">4. Draw A Vertical String.</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>Demonstrates how to draw a vertical string.</p>
<p class="MsoNormal">5. Draw A Ellipse With Gradient Brush.</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>Demonstrates how to draw a shape with gradient effect.<span style="">
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53191/1/image.png" alt="" width="576" height="408" align="middle">
</span><span style="">&nbsp;</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal"><span style="">1. Example 1: &quot;Draw A Line&quot;. </span>
</p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>1). Use Graphics.DrawLine method with a normal pen to draw a normal line;
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Draw a solid line starts at point(40,90) and ends at point(240,90).
e.Graphics.DrawLine(p, 40, 90, 240, 90)

</pre>
<pre id="codePreview" class="vb">
' Draw a solid line starts at point(40,90) and ends at point(240,90).
e.Graphics.DrawLine(p, 40, 90, 240, 90)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>2). Use Graphics.DrawLine method with a dash pen to draw a dashed line;
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Draw a dash line starts at point(40,110) and ends at point(240,110).
p.DashStyle = DashStyle.Dash
e.Graphics.DrawLine(p, 40, 110, 240, 110)

</pre>
<pre id="codePreview" class="vb">
' Draw a dash line starts at point(40,110) and ends at point(240,110).
p.DashStyle = DashStyle.Dash
e.Graphics.DrawLine(p, 40, 110, 240, 110)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>3). Use Graphics.DrawLine method with a dot pen to draw a dotted line;
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Draw a dot line starts at point(40,130) and ends at point(240,130).
p.DashStyle = DashStyle.Dot
e.Graphics.DrawLine(p, 40, 130, 240, 130)

</pre>
<pre id="codePreview" class="vb">
' Draw a dot line starts at point(40,130) and ends at point(240,130).
p.DashStyle = DashStyle.Dot
e.Graphics.DrawLine(p, 40, 130, 240, 130)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">2. Example 2: &quot;Draw A Curve&quot;. </span>
</p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>1). Create a collection of points for the curve;
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Specify a collection of points for the curve.
Dim ps As Point() = New Point() {New Point(40, 250), _
                            New Point(80, 300), New Point(120, 200)}


' Specify a collection of points for the curve.
Dim ps2 As Point() = New Point() {New Point(150, 250), _
                            New Point(190, 300), New Point(230, 200)}

</pre>
<pre id="codePreview" class="vb">
' Specify a collection of points for the curve.
Dim ps As Point() = New Point() {New Point(40, 250), _
                            New Point(80, 300), New Point(120, 200)}


' Specify a collection of points for the curve.
Dim ps2 As Point() = New Point() {New Point(150, 250), _
                            New Point(190, 300), New Point(230, 200)}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>2). Draw a curve without antialiasing rendering mode.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Draw a curve with default rendering mode. (No antialiasing.)
e.Graphics.DrawCurve(p, ps)

</pre>
<pre id="codePreview" class="vb">
' Draw a curve with default rendering mode. (No antialiasing.)
e.Graphics.DrawCurve(p, ps)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>3). Draw a curve with antialiasing rendering mode.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Draw a curve with antialiasing rendering mode.
e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
e.Graphics.DrawCurve(p, ps2)

</pre>
<pre id="codePreview" class="vb">
' Draw a curve with antialiasing rendering mode.
e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
e.Graphics.DrawCurve(p, ps2)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">3. Example 3: &quot;Draw An Arrow&quot;.<span style="">&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>1). Create a pen with EndCap property set to ArrowAnchor;
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>2). Use the pen created at step #1 to draw the line;
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' To draw an arrow, set the EndCap property to LineCap.ArrowAnchor for the pen.
p.EndCap = LineCap.ArrowAnchor
p.Width = 5.0!
e.Graphics.DrawLine(p, 40, 400, 240, 400)

</pre>
<pre id="codePreview" class="vb">
' To draw an arrow, set the EndCap property to LineCap.ArrowAnchor for the pen.
p.EndCap = LineCap.ArrowAnchor
p.Width = 5.0!
e.Graphics.DrawLine(p, 40, 400, 240, 400)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">4. Example 4: &quot;Draw A Vertical String&quot;.<span style="">&nbsp;
</span></span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>1). Create a StringFormat object with FormatFlags property set to StringFormatFlags.DirectionVertical;
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>2). Pass the StringFormat object create at step #1 to the Graphics.DrawString method to draw vertical string.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Using br As SolidBrush = New SolidBrush(Color.Red)
    Dim sf As New StringFormat
    sf.FormatFlags = StringFormatFlags.DirectionVertical
    e.Graphics.DrawString(&quot;This is a vertical text.&quot;, Me.Font, _
                          br, 450.0!, 90.0!, sf)
End Using

</pre>
<pre id="codePreview" class="vb">
Using br As SolidBrush = New SolidBrush(Color.Red)
    Dim sf As New StringFormat
    sf.FormatFlags = StringFormatFlags.DirectionVertical
    e.Graphics.DrawString(&quot;This is a vertical text.&quot;, Me.Font, _
                          br, 450.0!, 90.0!, sf)
End Using

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">5. Example 5: &quot;Draw A Ellipse With Gradient Brush&quot;.
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>1). Create a LinearGradientBrush object;
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>2). Pass the LinearGradientBrush object create at step #1 to the<span style="">&nbsp;
</span>Graphics.FillEllipse method to draw a ellipse with gradient color effect. </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Specify a bound for the ellipse.
Dim r As New Rectangle(350, 280, 280, 150)
' Use a LinearGradientBrush to draw the ellipse.
Using br As LinearGradientBrush = New LinearGradientBrush(r, Color.Silver, _
                                    Color.Black, LinearGradientMode.Vertical)
    e.Graphics.FillEllipse(br, r)
End Using

</pre>
<pre id="codePreview" class="vb">
' Specify a bound for the ellipse.
Dim r As New Rectangle(350, 280, 280, 150)
' Use a LinearGradientBrush to draw the ellipse.
Using br As LinearGradientBrush = New LinearGradientBrush(r, Color.Silver, _
                                    Color.Black, LinearGradientMode.Vertical)
    e.Graphics.FillEllipse(br, r)
End Using

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:������"><a href="http://msdn.microsoft.com/en-us/library/aa984108(VS.71).aspx">GDI&#43; Graphics</a><span style="">&nbsp;&nbsp;
</span></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:������"><a href="http://social.msdn.microsoft.com/Forums/en-US/winforms/thread/77a66f05-804e-4d58-8214-0c32d8f43191">Windows Forms General FAQ.</a>
</span></p>
<p class="MsoListParagraphCxSpLast"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
