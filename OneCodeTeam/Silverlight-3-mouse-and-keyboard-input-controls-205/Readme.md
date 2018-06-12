# Silverlight 3 mouse and keyboard input controls (CSSL3Input)
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
* 2011-05-05 06:10:27
## Description

<p style="font-family:Courier New"></p>
<h2>SILVERLIGHT APPLICATION : CSSL3Input Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This example demonstrates how to handle mouse and keyboard event in <br>
Silverlight 3. It demonstrate following functionalities:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Handle mouse/keyboard event<br>
&nbsp;&nbsp;&nbsp;&nbsp;Implement mouse drag function<br>
<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
Silverlight 3 Tools for Visual Studio 2008 SP1<br>
<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a-88f3-5e7b5409e9dd&displaylang=en">http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a-88f3-5e7b5409e9dd&displaylang=en</a><br>
<br>
Silverilght 3 runtime:<br>
<a target="_blank" href="http://silverlight.net/getstarted/">http://silverlight.net/getstarted/</a><br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1.To Handle mouse/keyboard event. The normal way is creating an event handler <br>
and register handler on target control.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Canvas Margin=&quot;20&quot; Background=&quot;AliceBlue&quot; MouseEnter=&quot;Canvas_MouseEnter&quot;&gt;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;private void Canvas_MouseEnter(object sender, MouseEventArgs e)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//handle event<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
Another way to handle control event, is using AddHandler method. The API <br>
AddHandler provides a technique whereby you can attach a handler that will <br>
always be invoked for the route, even if some other handler earlier in the <br>
route has set Handled to true. For example, handling Button's <br>
MouseLeftButtonDown / MouseLeftButtonUp event<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;((Button)sender).AddHandler(Button.MouseLeftButtonUpEvent,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;new MouseButtonEventHandler(Button_MouseLeftButtonUp),true);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//handle event<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
2.To implement mouse drag function, we need combine the usage of <br>
MouseLeftButtonDown, MouseLeftButtonUp and MouseMove event.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;void Button_MouseMove(object sender, MouseEventArgs e)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if (isMouseCaptured)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var item= ((Button)sender);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Calculate the current position of the object.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;double deltaV = e.GetPosition(null).Y - mouseVerticalPosition;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;double deltaH = e.GetPosition(null).X - mouseHorizontalPosition;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;double newTop = deltaV &#43; (double)item.GetValue(Canvas.TopProperty);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;double newLeft = deltaH &#43; (double)item.GetValue(Canvas.LeftProperty);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Set new position of object.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;item.SetValue(Canvas.TopProperty, newTop);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;item.SetValue(Canvas.LeftProperty, newLeft);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Update position global variables.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mouseVerticalPosition = e.GetPosition(null).Y;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mouseHorizontalPosition = e.GetPosition(null).X;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isMouseCaptured = true;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mouseVerticalPosition = e.GetPosition(null).Y;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mouseHorizontalPosition = e.GetPosition(null).X;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;((Button)sender).CaptureMouse();<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;private void Button_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isMouseCaptured = false;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;((Button)sender).ReleaseMouseCapture();<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
3.To put UserControl in another UserControl, first we need register the <br>
usercontrol's namespace, then use usercontrol with this name <br>
&quot;prefix_name:usercontrol_name&quot;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;cssinput:KeyboardSupport &nbsp;xmlns:cssinput=&quot;clr-namespace:CSSL3Input&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
4.To bind list to listbox, first set ListBox.ItemsSource to list, then set <br>
databinding on ListBox.ItemTemplate. For details, please check out<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc265158(VS.95).aspx.">http://msdn.microsoft.com/en-us/library/cc265158(VS.95).aspx.</a><br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Mouse Support<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc189029(VS.95).aspx">http://msdn.microsoft.com/en-us/library/cc189029(VS.95).aspx</a><br>
<br>
Keyboard Support<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc189015(VS.95).aspx">http://msdn.microsoft.com/en-us/library/cc189015(VS.95).aspx</a><br>
<br>
How to: Drag and Drop Objects in UI Layout<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc189066(VS.95).aspx">http://msdn.microsoft.com/en-us/library/cc189066(VS.95).aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
