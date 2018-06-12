# Display time on ASP.NET server side (VBASPNETServerClock)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Server clock
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:46:29
## Description

<p style="font-family:Courier New"></p>
<h2>VBASPNETServerClock Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This project illustrates how to get the time of the server side and show <br>
it to the client page. Sometimes a website need to show an unified clock <br>
on pages to all the visitors. However, if we use JavaScript to handle this<br>
target, the time will be different from each client. So we need the server<br>
to return the server time and refresh the clock per second via AJAX. <br>
<br>
<br>
Demo the Sample.<br>
<br>
It is better to demo this sample with two computers. One is as the client<br>
side and the other is working as the server side.<br>
<br>
Step1: Publish this sample site to one of the computers to make the other<br>
one can visit it from the browser.<br>
<br>
Step2: Open the browser to view the Default.aspx page from the computer as <br>
the client side. You will find there is a clock on the page which displays <br>
the time.<br>
<br>
Step3: Change the time of the client side computer. And open the browser<br>
to view the Default.aspx page again. You can find that the time on the page<br>
is different from the clock of the computer itself. This shows that the <br>
time there is not based on the client side's time, but the time from the <br>
server side.<br>
<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step1: Create a VB.NET ASP.NET Empty Web Application in Visual Studio 2010.<br>
<br>
Step2: Add a new ASP.NET page to the application and named it as Clock.aspx. <br>
Write the code below to it Page_Load event.<br>
<br>
&nbsp; &nbsp;Protected Sub Page_Load(ByVal sender As Object, <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;ByVal e As System.EventArgs)
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Handles Me.Load<br>
&nbsp; &nbsp; &nbsp; &nbsp;Response.Expires = -1<br>
&nbsp; &nbsp; &nbsp; &nbsp;Response.Write(DateTime.Now.ToString())<br>
&nbsp; &nbsp;End Sub<br>
<br>
Step3: Add a Default.aspx ASP.NET page to the application. Design the HTML<br>
code as follows.<br>
<br>
&nbsp; &nbsp;&lt;form id=&quot;form1&quot; runat=&quot;server&quot;&gt;<br>
&nbsp; &nbsp;&lt;div&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;The server time is now：&lt;span id=&quot;time&quot; /&gt;<br>
&nbsp; &nbsp;&lt;/div&gt;<br>
&nbsp; &nbsp;&lt;/form&gt;<br>
<br>
Step4: Add the JavaScript function to get the time from the server side.<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;function doing() {<br>
&nbsp; &nbsp; &nbsp; &nbsp;var xmlHttp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;try {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;xmlHttp = new XMLHttpRequest();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;catch (e) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;try {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;xmlHttp = new ActiveXObject(&quot;Msxml2.XMLHTTP&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;catch (e) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;try {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;xmlHttp = new ActiveXObject(&quot;Microsoft.XMLHTTP&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;catch (e) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;alert(&quot;Error&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return false;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;xmlHttp.onreadystatechange = function () {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (xmlHttp.readyState == 4) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var strResult = xmlHttp.responseText;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById(&quot;time&quot;).innerText = strResult;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;xmlHttp.open(&quot;GET&quot;, &quot;Clock.aspx&quot;, true);<br>
&nbsp; &nbsp; &nbsp; &nbsp;xmlHttp.send(null);<br>
&nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp;function gettingTime() {<br>
&nbsp; &nbsp; &nbsp; &nbsp;setInterval(doing, 1000);<br>
&nbsp; &nbsp;} <br>
&nbsp; &nbsp;<br>
Step5: Set the onload event of the body element to call the gettingTime() <br>
function.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;body onload=&quot;gettingTime();&quot;&gt;<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
# MSDN: Calling Web Services from Client Script<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb398995.aspx">http://msdn.microsoft.com/en-us/library/bb398995.aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
