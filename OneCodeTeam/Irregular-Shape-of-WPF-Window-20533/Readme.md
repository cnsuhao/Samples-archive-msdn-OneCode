# Irregular Shape of WPF Window
## Requires
* Visual Studio 2012
## License
* MS-LPL
## Technologies
* WPF
## Topics
* Window
## IsPublished
* True
## ModifiedDate
* 2013-01-22 08:13:50
## Description

<h1>How to create an irregularly shaped windows for WPF UI (CSWPFIrregularShapeWindow)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The sample demonstrates how to create an irregularly shaped windows for WPF UI. The sample includes irregularly shaped windows such as: rectangles, circles, triangles or picture-based form shapes, etc. In each WPF form we can right-click
 the mouse and click the popup menu to enlarge, reduce, and close the operation. </p>
<p class="MsoNormal">In addition, adding these irregularly shaped actions to be dragged. The sample has two output paths setting. If you are running different CPU platform, you should update the configuration manager to align with their real environment</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Step1. Build this project in VS2012. </p>
<p class="MsoNormal">Step2. Using PNG format image files replace the images' list of transparentPic. PNG formats.
</p>
<p class="MsoNormal">Step3. Run CSWPFIrregularShapeWindow.exe. </p>
<p class="MsoNormal">Step4. Separately click &quot;Ellipse Window&quot;, &quot;Rounded Corners Window&quot;, &quot;Popup Corners Window&quot;, &quot;Triangle Corners Window&quot;, &quot;Picture Based Window&quot;<span style="">&nbsp;
</span>and they show differently shaped windows with effects.</p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step1. Each irregular window has a CommandBinding class which binds a RountedCommand to the event handlers that implement the command.
</p>
<p class="MsoNormal">Step2. We can use ScaleTransform to enlarge and reduce the size of objects. And these are two opposite actions, so when different commands are in effect the objects are light or dark.
</p>
<p class="MsoNormal">Step3. If you use a menu item to influence an object, you should set examples from the menu item, Commandtarget method and button, otherwise menu item object will be invalid.
</p>
<p class="MsoNormal">Step4. This sample provides a ready-made examples of ways to judge whether the CommandBinding object such as canExecute method to receive results which are true or false.
</p>
<p class="MsoNormal">Step5. This sample uses EventTriggers and Storyboards such as
<a href="http://msdn.microsoft.com/en-us/library/ms745683.aspx#Y3189">http://msdn.microsoft.com/en-us/library/ms745683.aspx#Y3189</a>. If you have scanned the article mentioned above, you can find another type of trigger is the EventTrigger, which starts a
 set of actions based on the occurrence of an event. For example, the EventTrigger objects specify that when the mouse pointer enters the Button, Path, Ellipse and Image, the Height property animates to a value of 260 over a 0.2 second period. When the mouse
 moves away from the item, the property returns to the original value over a period of 1 second. Note how it is not necessary to specify a to value for the MouseLeave animation. This is because the animation is able to keep track of the original value. You
 only use the code as shown below and replace TargetType property into Button, Path, Ellipse or Image.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;Window.Resources&gt;
        &lt;Style TargetType=&quot;Button&quot;&gt;
            &lt;Setter Property=&quot;Opacity&quot; Value=&quot;0.5&quot; /&gt;
            &lt;Style.Triggers&gt;


                &lt;EventTrigger RoutedEvent=&quot;Mouse.MouseEnter&quot;&gt;
                    &lt;EventTrigger.Actions&gt;
                        &lt;BeginStoryboard&gt;
                            &lt;Storyboard&gt;
                                &lt;DoubleAnimation
                  Duration=&quot;0:0:0.2&quot;
                  Storyboard.TargetProperty=&quot;Height&quot;
                  To=&quot;80&quot;  /&gt;
                            &lt;/Storyboard&gt;
                        &lt;/BeginStoryboard&gt;
                    &lt;/EventTrigger.Actions&gt;
                &lt;/EventTrigger&gt;
                &lt;EventTrigger RoutedEvent=&quot;Mouse.MouseLeave&quot;&gt;
                    &lt;EventTrigger.Actions&gt;
                        &lt;BeginStoryboard&gt;
                            &lt;Storyboard&gt;
                                &lt;DoubleAnimation
                  Duration=&quot;0:0:1&quot;
                  Storyboard.TargetProperty=&quot;Height&quot;  /&gt;
                            &lt;/Storyboard&gt;
                        &lt;/BeginStoryboard&gt;
                    &lt;/EventTrigger.Actions&gt;
                &lt;/EventTrigger&gt;
            &lt;/Style.Triggers&gt;


        &lt;/Style&gt;


    &lt;/Window.Resources&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;Window.Resources&gt;
        &lt;Style TargetType=&quot;Button&quot;&gt;
            &lt;Setter Property=&quot;Opacity&quot; Value=&quot;0.5&quot; /&gt;
            &lt;Style.Triggers&gt;


                &lt;EventTrigger RoutedEvent=&quot;Mouse.MouseEnter&quot;&gt;
                    &lt;EventTrigger.Actions&gt;
                        &lt;BeginStoryboard&gt;
                            &lt;Storyboard&gt;
                                &lt;DoubleAnimation
                  Duration=&quot;0:0:0.2&quot;
                  Storyboard.TargetProperty=&quot;Height&quot;
                  To=&quot;80&quot;  /&gt;
                            &lt;/Storyboard&gt;
                        &lt;/BeginStoryboard&gt;
                    &lt;/EventTrigger.Actions&gt;
                &lt;/EventTrigger&gt;
                &lt;EventTrigger RoutedEvent=&quot;Mouse.MouseLeave&quot;&gt;
                    &lt;EventTrigger.Actions&gt;
                        &lt;BeginStoryboard&gt;
                            &lt;Storyboard&gt;
                                &lt;DoubleAnimation
                  Duration=&quot;0:0:1&quot;
                  Storyboard.TargetProperty=&quot;Height&quot;  /&gt;
                            &lt;/Storyboard&gt;
                        &lt;/BeginStoryboard&gt;
                    &lt;/EventTrigger.Actions&gt;
                &lt;/EventTrigger&gt;
            &lt;/Style.Triggers&gt;


        &lt;/Style&gt;


    &lt;/Window.Resources&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Certainly, you should add Height property and set its value for the Button, Path, Ellipse or Image such as:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;Path Height=&quot;250&quot; Name=&quot;Triangle&quot; Stroke=&quot;Black&quot; StrokeThickness=&quot;2&quot; Grid.ColumnSpan=&quot;10&quot; Grid.RowSpan=&quot;4&quot;&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;Path Height=&quot;250&quot; Name=&quot;Triangle&quot; Stroke=&quot;Black&quot; StrokeThickness=&quot;2&quot; Grid.ColumnSpan=&quot;10&quot; Grid.RowSpan=&quot;4&quot;&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step6. In order to make child windows not to overlap the main windows, the sample uses codes listed below to singly display child windows</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
ellipseWindow.Left = this.Left &#43; this.Width&#43;width;
ellipseWindow.Top = this.Top &#43;this.Height&#43;height;

</pre>
<pre id="codePreview" class="csharp">
ellipseWindow.Left = this.Left &#43; this.Width&#43;width;
ellipseWindow.Top = this.Top &#43;this.Height&#43;height;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">CommandBinding Class
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"><a href="http://msdn.microsoft.com/en-us/library/system.windows.input.commandbinding.aspx">http://msdn.microsoft.com/en-us/library/system.windows.input.commandbinding.aspx</a>
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">RoutedUICommand Class
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"><a href="http://msdn.microsoft.com/en-us/library/system.windows.input.routeduicommand.aspx">http://msdn.microsoft.com/en-us/library/system.windows.input.routeduicommand.aspx</a>
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">ScaleTransform Class
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"><a href="http://msdn.microsoft.com/en-us/library/system.windows.media.scaletransform.aspx">http://msdn.microsoft.com/en-us/library/system.windows.media.scaletransform.aspx</a>
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">Window.WindowState Property<span style="">&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"><a href="http://msdn.microsoft.com/en-us/library/system.windows.window.windowstate.aspx">http://msdn.microsoft.com/en-us/library/system.windows.window.windowstate.aspx</a>
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">Styling and Templating
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"><a href="http://msdn.microsoft.com/en-us/library/ms745683.aspx#Y3189">http://msdn.microsoft.com/en-us/library/ms745683.aspx#Y3189</a>
</span></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
