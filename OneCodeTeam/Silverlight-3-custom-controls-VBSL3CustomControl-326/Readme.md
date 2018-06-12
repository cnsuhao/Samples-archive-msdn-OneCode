# Silverlight 3 custom controls (VBSL3CustomControl)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Silverlight
## Topics
* Controls
## IsPublished
* True
## ModifiedDate
* 2011-05-05 08:10:29
## Description

<p style="font-family:Courier New"></p>
<h2>SILVERLIGHT APPLICATION : VBSL3CustomControl Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This example demonstrates how to Create custom control HighLightTextBlock in<br>
silverlight 3. HighLightTextBlock enhanced TextBlock, providing HighLight() <br>
method and IsHighLighted property. By calling HighLight() or setting <br>
IsHighLighted=true, text appearance would be changed to attract user’s attention.<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
Silverlight 3 Tools for Visual Studio 2008 SP1<br>
<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a-88f3-5e7b5409e9dd&displaylang=en">http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a-88f3-5e7b5409e9dd&displaylang=en</a><br>
<br>
Silverilght 3 runtime:<br>
<a target="_blank" href="http://silverlight.net/getstarted/">http://silverlight.net/getstarted/</a><br>
</p>
<h3>Project Relation:</h3>
<p style="font-family:Courier New"><br>
VBSL3CustomControl -&gt; XAMLSL3StyleControlTemplate<br>
<br>
VBSL3CustomControl demonstrates how to create a Custom Control.<br>
XAMLSL3StyleControlTemplate demonstrates how to customize the style<br>
and template of both built-in Controls and Custom Controls.<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. How to create custom control<br>
&nbsp; &nbsp;1. Create class derived from System.Windows.Controls.Control.<br>
&nbsp; &nbsp;2. In constructor, set DefaultStyleKey to typeof custom control.<br>
&nbsp; &nbsp;3. Create ResourceDictionary file named generic.xaml and place at Themes folder.<br>
&nbsp; &nbsp;4. in generic.xaml, create default template for custom control<br>
&nbsp; &nbsp;<br>
2. How to manipulate controls which are in custom control's template<br>
&nbsp; &nbsp;1. In controltemplate, set Name to target control.<br>
&nbsp; &nbsp;2. In custom control class, we could use GetTemplateChild(&quot;[controlname]&quot;)<br>
&nbsp; &nbsp;method to get reference to target control.<br>
<br>
3. How to use VisualState in custom control?<br>
&nbsp; &nbsp;1. Define VisualStateGroup and VisualState in xaml<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;VisualStateManager.VisualStateGroups&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;VisualStateGroup x:Name=&quot;HightLightStates&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;VisualState x:Name=&quot;HighLight&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Storyboard&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;//animate the control<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/Storyboard&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/VisualState&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;VisualState x:Name=&quot;NonHighLight&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/VisualStateGroup&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/VisualStateManager.VisualStateGroups&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp;2. Change VisualState in custom control code<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;VisualStateManager.GoToState(this, &quot;[visualstate name]&quot;, true);<br>
<br>
4. How to use Timer in silverlight?<br>
&nbsp; &nbsp;In silverlight, you could use System.Windows.Threading.DispatcherTimer.<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;Private WithEvents counterPanel As Panel<br>
&nbsp; &nbsp;Private WithEvents timer As DispatcherTimer = New DispatcherTimer()<br>
&nbsp; &nbsp;Private counter As Integer = 0<br>
<br>
&nbsp; &nbsp;Private Sub PanelClick(ByVal sender As System.Object, _<br>
&nbsp; &nbsp; &nbsp; &nbsp;ByVal e As System.Windows.Input.MouseButtonEventArgs) _<br>
&nbsp; &nbsp; &nbsp; &nbsp;Handles counterPanel.MouseLeftButtonDown<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;If timer.IsEnabled Then timer.Stop() Else timer.Start()<br>
<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;Private Sub TimerClick(ByVal sender As System.Object, _<br>
&nbsp; &nbsp; &nbsp; &nbsp;ByVal e As EventArgs) Handles timer.Tick<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;counter &#43;= 1<br>
&nbsp; &nbsp; &nbsp; &nbsp;counterPanel.Children.Clear()<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim t As New TextBlock<br>
&nbsp; &nbsp; &nbsp; &nbsp;t.Text = counter.ToString<br>
&nbsp; &nbsp; &nbsp; &nbsp;counterPanel.Children.Add(t)<br>
<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;Private Sub TestDispatcherTimer(ByVal p As Panel)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Me.counterPanel = p<br>
&nbsp; &nbsp; &nbsp; &nbsp;timer.Interval = New TimeSpan(0, 0, 1)<br>
&nbsp; &nbsp; &nbsp; &nbsp;timer.Start()<br>
<br>
&nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;You could get detail about DispatcherTimer at<br>
&nbsp; &nbsp;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatchertimer(VS.95).aspx">http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatchertimer(VS.95).aspx</a><br>
&nbsp;<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Creating a New Control by Creating a ControlTemplate<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc278064(VS.95).aspx">http://msdn.microsoft.com/en-us/library/cc278064(VS.95).aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
