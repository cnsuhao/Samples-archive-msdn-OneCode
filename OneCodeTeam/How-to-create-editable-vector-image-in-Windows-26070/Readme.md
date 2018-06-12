# How to create editable vector image in Windows Store apps
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
## IsPublished
* True
## ModifiedDate
* 2013-11-20 09:33:25
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<h1><span style="">How to create editable vector in Windows Store apps (CSWindowsStoreAppDynamicFontsize)
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to create an editable vector in Windows Store apps.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal"></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Start Visual Studio Express&nbsp;2012 for Windows&nbsp;8 and select&nbsp;File&nbsp;&gt;&nbsp;Open&nbsp;&gt;&nbsp;Project/Solution.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Go to the directory in which you unzipped the sample. Go to the directory named for the sample, and double-click the Visual Studio Express&nbsp;2012 for Windows&nbsp;8 Solution (.sln) file.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press F6 or use&nbsp;Build&nbsp;&gt;&nbsp;Build Solution&nbsp;to build the sample.</p>
<p class="MsoListParagraphCxSpLast"></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>After the sample is launched, this screen will be displayed. Please drag any vertex of the triangle and move it. The vector will transform as you edit it.</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/101530/1/image.png" alt="" width="576" height="330" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle"></p>
<p class="MsoListParagraphCxSpMiddle"></p>
<p class="MsoListParagraphCxSpLast"></p>
<h2>Using the Code</h2>
<p class="MsoNormal">The code below shows how to change the vector based on user's operation.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private void Rectangle_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
{
    var r = sender as Rectangle;
    var x = (double)r.GetValue(Canvas.LeftProperty) &#43; e.Delta.Translation.X;
    var y = (double)r.GetValue(Canvas.TopProperty) &#43; e.Delta.Translation.Y;


    if (x &gt; VectorContainer.Width)
    {
        x = VectorContainer.Width;
    }
    else if (x &lt; -5)
    {
        x = -5;
    }


    if (y &gt; VectorContainer.Height)
    {
        y = VectorContainer.Height;
    }
    else if (y &lt; -5)
    {
        y = -5;
    }
    r.SetValue(Canvas.LeftProperty, x);
    r.SetValue(Canvas.TopProperty, y);
    int k = Convert.ToInt32(r.Tag);
    EditablePolygon.Points[k] = new Point(x &#43; 5, y &#43; 5);
}

</pre>
<pre id="codePreview" class="csharp">
private void Rectangle_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
{
    var r = sender as Rectangle;
    var x = (double)r.GetValue(Canvas.LeftProperty) &#43; e.Delta.Translation.X;
    var y = (double)r.GetValue(Canvas.TopProperty) &#43; e.Delta.Translation.Y;


    if (x &gt; VectorContainer.Width)
    {
        x = VectorContainer.Width;
    }
    else if (x &lt; -5)
    {
        x = -5;
    }


    if (y &gt; VectorContainer.Height)
    {
        y = VectorContainer.Height;
    }
    else if (y &lt; -5)
    {
        y = -5;
    }
    r.SetValue(Canvas.LeftProperty, x);
    r.SetValue(Canvas.TopProperty, y);
    int k = Convert.ToInt32(r.Tag);
    EditablePolygon.Points[k] = new Point(x &#43; 5, y &#43; 5);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">The code below is the UI code of the vector.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;Canvas x:Name=&quot;VectorContainer&quot; HorizontalAlignment=&quot;Center&quot; VerticalAlignment=&quot;Center&quot; Width=&quot;800&quot; Height=&quot;400&quot;&gt;
                   &lt;Polygon x:Name=&quot;EditablePolygon&quot; Points=&quot;0,0,100,100,500,40&quot; Fill=&quot;Blue&quot;/&gt;
                   &lt;Rectangle Width=&quot;10&quot; Height=&quot;10&quot; Canvas.Left=&quot;-5&quot; Canvas.Top=&quot;-5&quot; ManipulationDelta=&quot;Rectangle_ManipulationDelta&quot; ManipulationMode=&quot;All&quot; Fill=&quot;Black&quot; Tag=&quot;0&quot; /&gt;
                   &lt;Rectangle Width=&quot;10&quot; Height=&quot;10&quot; Canvas.Left=&quot;95&quot; Canvas.Top=&quot;95&quot; ManipulationDelta=&quot;Rectangle_ManipulationDelta&quot; ManipulationMode=&quot;All&quot; Fill=&quot;Black&quot; Tag=&quot;1&quot; /&gt;
                   &lt;Rectangle Width=&quot;10&quot; Height=&quot;10&quot; Canvas.Left=&quot;495&quot; Canvas.Top=&quot;35&quot; ManipulationDelta=&quot;Rectangle_ManipulationDelta&quot; ManipulationMode=&quot;All&quot; Fill=&quot;Black&quot; Tag=&quot;2&quot; /&gt;
               &lt;/Canvas&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;Canvas x:Name=&quot;VectorContainer&quot; HorizontalAlignment=&quot;Center&quot; VerticalAlignment=&quot;Center&quot; Width=&quot;800&quot; Height=&quot;400&quot;&gt;
                   &lt;Polygon x:Name=&quot;EditablePolygon&quot; Points=&quot;0,0,100,100,500,40&quot; Fill=&quot;Blue&quot;/&gt;
                   &lt;Rectangle Width=&quot;10&quot; Height=&quot;10&quot; Canvas.Left=&quot;-5&quot; Canvas.Top=&quot;-5&quot; ManipulationDelta=&quot;Rectangle_ManipulationDelta&quot; ManipulationMode=&quot;All&quot; Fill=&quot;Black&quot; Tag=&quot;0&quot; /&gt;
                   &lt;Rectangle Width=&quot;10&quot; Height=&quot;10&quot; Canvas.Left=&quot;95&quot; Canvas.Top=&quot;95&quot; ManipulationDelta=&quot;Rectangle_ManipulationDelta&quot; ManipulationMode=&quot;All&quot; Fill=&quot;Black&quot; Tag=&quot;1&quot; /&gt;
                   &lt;Rectangle Width=&quot;10&quot; Height=&quot;10&quot; Canvas.Left=&quot;495&quot; Canvas.Top=&quot;35&quot; ManipulationDelta=&quot;Rectangle_ManipulationDelta&quot; ManipulationMode=&quot;All&quot; Fill=&quot;Black&quot; Tag=&quot;2&quot; /&gt;
               &lt;/Canvas&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal">Canvas class</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.canvas">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.canvas</a></p>
<p class="MsoNormal">UIElement.ManipulationDelta event</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.uielement.manipulationdelta">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.uielement.manipulationdelta</a></p>
<p class="MsoNormal">Gestures, manipulations, and interactions (Windows Store apps)</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/hh761498.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/hh761498.aspx</a>
</p>
<p class="MsoNormal"></p>
<p class="MsoNormal"></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
