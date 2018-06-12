# Silverlight 3 mouse and keyboard input controls (VBSL3Input)
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
* 2011-05-05 08:13:59
## Description

<p style="font-family:Courier New"></p>
<h2>SILVERLIGHT APPLICATION : VBSL3Input Project Overview</h2>
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
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;Private Sub Canvas_MouseEnter(ByVal sender As Object, ByVal e As MouseEventArgs)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Me._eventlist.Insert(0, (DateTime.Now.ToLongTimeString & &quot;: Mouse entered&quot;))<br>
&nbsp;&nbsp;&nbsp;&nbsp;End Sub<br>
<br>
Another way to handle control event, is using AddHandler method. The API <br>
AddHandler provides a technique whereby you can attach a handler that will <br>
always be invoked for the route, even if some other handler earlier in the <br>
route has set Handled to true. For example, handling Button's <br>
MouseLeftButtonDown/MouseLeftButtonUp event<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;DirectCast(sender, Button).AddHandler(UIElement.MouseLeftButtonUpEvent,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;New MouseButtonEventHandler(AddressOf Me.Button_MouseLeftButtonUp), True)<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Private Sub Button_MouseLeftButtonUp(ByVal sender As Object, _<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ByVal e As MouseButtonEventArgs)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'handle event<br>
&nbsp;&nbsp;&nbsp;&nbsp;End Sub<br>
<br>
2.To implement mouse drag function, we need combine the usage of <br>
MouseLeftButtonDown, MouseLeftButtonUp and MouseMove event.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Private Sub Button_MouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Me.isMouseCaptured = True<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Me.mouseVerticalPosition = e.GetPosition(Nothing).Y<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Me.mouseHorizontalPosition = e.GetPosition(Nothing).X<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DirectCast(sender, Button).CaptureMouse()<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Me._eventlist.Insert(0, (DateTime.Now.ToLongTimeString & &quot;: (Button)Mouse left button down&quot;))<br>
&nbsp;&nbsp;&nbsp;&nbsp;End Sub<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Private Sub Button_MouseLeftButtonUp(ByVal sender As Object, ByVal e As MouseButtonEventArgs)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Me.isMouseCaptured = False<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DirectCast(sender, Button).ReleaseMouseCapture()<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Me._eventlist.Insert(0, (DateTime.Now.ToLongTimeString & &quot;: (Button)Mouse left button up&quot;))<br>
&nbsp;&nbsp;&nbsp;&nbsp;End Sub<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Private Sub Button_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If Me.isMouseCaptured Then<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim item As Button = DirectCast(sender, Button)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim deltaV As Double = (e.GetPosition(Nothing).Y - Me.mouseVerticalPosition)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim deltaH As Double = (e.GetPosition(Nothing).X - Me.mouseHorizontalPosition)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim newTop As Double = (deltaV &#43; CDbl(item.GetValue(Canvas.TopProperty)))<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim newLeft As Double = (deltaH &#43; CDbl(item.GetValue(Canvas.LeftProperty)))<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;item.SetValue(Canvas.TopProperty, newTop)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;item.SetValue(Canvas.LeftProperty, newLeft)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Me.mouseVerticalPosition = e.GetPosition(Nothing).Y<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Me.mouseHorizontalPosition = e.GetPosition(Nothing).X<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End If<br>
&nbsp;&nbsp;&nbsp;&nbsp;End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
3.To put UserControl in another UserControl, first we need register the <br>
usercontrol's namespace, then use usercontrol with this name <br>
&quot;prefix_name:usercontrol_name&quot;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;cssinput:KeyboardSupport &nbsp;xmlns:cssinput=&quot;clr-namespace:CSSL3Input&quot; /&gt;<br>
<br>
4.To bind list to listbox, first set ListBox.ItemsSource to list, then set <br>
databinding on ListBox.ItemTemplate. For details, please check out<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc265158(VS.95).aspx">http://msdn.microsoft.com/en-us/library/cc265158(VS.95).aspx</a><br>
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
