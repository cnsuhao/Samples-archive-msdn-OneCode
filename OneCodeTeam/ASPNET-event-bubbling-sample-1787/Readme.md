# ASP.NET event bubbling sample (VBASPNETUserControlEventExpose)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Bubble event
## IsPublished
* True
## ModifiedDate
* 2011-05-05 07:36:14
## Description

<p style="font-family:Courier New"></p>
<h2>VBASPNETuserControlEventsExpose Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The project illustrates how to bubble an event from Web User Control to the <br>
web page that may display something on Web Page according to which event is <br>
fired in this User control.<br>
<br>
</p>
<h3>Demo</h3>
<p style="font-family:Courier New"><br>
Click the VBASPNETuserControlEventsExpose.sln directly and open the <br>
VBASPNETuserControlEventsExpose website to test the page directly.<br>
<br>
If you want to have a further test, please follow the demonstration steps <br>
below.<br>
<br>
Step 1: View the Default.aspx,you will find some Controls,select the <br>
dropdownlist value.<br>
<br>
Step 2: When click the the button control whose value is 'I am inside User <br>
Control',<br>
<br>
The webpage custom event will fire, display the dropdownlist selected value <br>
and inform user the usercontrol's button click is clicked.<br>
<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step 1. Declare a delagate and a event in the user control code behind,<br>
add one button to this User Control.<br>
<br>
Step 2. Add the following lines of code in the click event of button of <br>
usercontrol.<br>
<br>
&nbsp; &nbsp;RaiseEvent MyEvent(sender, e)<br>
&nbsp; &nbsp;Response.Write(&quot;User Control��s Button Click &lt;BR/&gt;&quot;)<br>
<br>
Step 3. In the Default.aspx.cs file,Load the usercontrol, and subscribe the <br>
event of the user control in the page load event.<br>
<br>
Step 4. Define a suitable event handler to display the dropdownlist selected <br>
value.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Events and Delegates<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/17sde2xt(VS.71).aspx">http://msdn.microsoft.com/en-us/library/17sde2xt(VS.71).aspx</a><br>
<br>
FAQs for Web Forms<br>
<a target="_blank" href="http://forums.asp.net/t/1360420.aspx">http://forums.asp.net/t/1360420.aspx</a><br>
<br>
Catch event from Web User Control in Webpage<br>
<a target="_blank" href="http://devcandy.blogspot.com/2008/06/catch-event-from-web-user-control-in.html">http://devcandy.blogspot.com/2008/06/catch-event-from-web-user-control-in.html</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
