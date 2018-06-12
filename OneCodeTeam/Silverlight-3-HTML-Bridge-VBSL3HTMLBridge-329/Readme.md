# Silverlight 3 HTML Bridge (VBSL3HTMLBridge)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Silverlight
## Topics
* HTML Bridge
## IsPublished
* True
## ModifiedDate
* 2011-05-05 08:13:36
## Description

<p style="font-family:Courier New"></p>
<h2>SILVERLIGHT APPLICATION : VBSL3HTMLBridge Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This project create a group of samples demonstrating the interactivity between<br>
silverlight application and javascript. The sample includes:<br>
&nbsp; &nbsp;Call Javascript method from managed code<br>
&nbsp; &nbsp;Handle Html event from managed code<br>
&nbsp; &nbsp;Call managed code method from javascript<br>
&nbsp; &nbsp;Handle managed code event from javascript<br>
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
Sample 1: Call Javascript method from managed code<br>
&nbsp; &nbsp;1. Write javascript method and put in header of silverlight hosted page.<br>
&nbsp; &nbsp; &nbsp; &nbsp;function changetext(name) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById('Text1').value = name;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp;2. Invoke javascript method in managed code.<br>
&nbsp; &nbsp; &nbsp; &nbsp;HtmlPage.Window.Invoke(&quot;changetext&quot;, tb1.Text)<br>
<br>
Sample 2: Handle Html event from managed code<br>
&nbsp; &nbsp;1. Attach html event in MainPage Loaded event handler.<br>
&nbsp; &nbsp; &nbsp; &nbsp;HtmlPage.Document.GetElementById(&quot;Text2&quot;).AttachEvent(&quot;onkeyup&quot;, New EventHandler(AddressOf HtmlKeyUp))<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;2. Write handler method &quot;HtmlKeyUp&quot;.<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub HtmlKeyUp(ByVal sender As Object, ByVal e As EventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.tb2.Text = DirectCast(sender, HtmlElement).GetProperty(&quot;value&quot;).ToString()<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
Sample 3: Call managed code method from javascript<br>
&nbsp; &nbsp;1. Write method in MainPage code behind and apply ScriptableMember attribute<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;ScriptableMember()&gt; _<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Sub ChangeTB3Text(ByVal text As String)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tb3.Text = text<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp;2. Register ScriptableObject instance in MainPage Loaded event.<br>
&nbsp; &nbsp; &nbsp; &nbsp;HtmlPage.RegisterScriptableObject(&quot;silverlightPage&quot;, Me)<br>
<br>
&nbsp; &nbsp;3. Write javascript event handler for html textbox onchanged event. In handler function, call managed code.<br>
&nbsp; &nbsp; &nbsp; &nbsp;function ontext3keydown() {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var text = document.getElementById('Text3').value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// calling managed code method<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var silverlight1 = document.getElementById('silverlight1');<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;silverlight1.Content.silverlightPage.ChangeTB3Text(text);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;<br>
Sample 4: Handle managed code event from javascript<br>
&nbsp; &nbsp;1. Write custom EventArgs for transmitting TextBox.Text value.<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Class TextEventArgs<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Inherits EventArgs<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Private _text As String<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;ScriptableMember()&gt; _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Public Property [Text]() As String<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return _text<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Set(ByVal value As String)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;_text = value<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Set<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Property<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Class<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp;2. Write Event in MainPage code behind.<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;ScriptableMember()&gt; _<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Event TextChanged As EventHandler(Of TextEventArgs)<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;3. Fire event when silverlight TextBox.Text changed.<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub tb4_TextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim myargs = New TextEventArgs()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;myargs.Text = tb4.Text<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RaiseEvent TextChanged(Me, myargs)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp;4. Register ScriptableObject instance in MainPage Loaded event.<br>
&nbsp; &nbsp; &nbsp; &nbsp;HtmlPage.RegisterScriptableObject(&quot;silverlightPage&quot;, Me)<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp;5. In silverlight hosted html page, attaching Silverlight loaded event.<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;param name=&quot;onLoad&quot; value=&quot;onSilverlightLoaded&quot; /&gt;<br>
<br>
&nbsp; &nbsp;6. In silverlight loaded eventhandler, handle managed code event.<br>
&nbsp; &nbsp; &nbsp; &nbsp;function onSilverlightLoaded() {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var silverlight1 = document.getElementById('silverlight1');<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;silverlight1.Content.silverlightPage.TextChanged = function(sender, e) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;document.getElementById('Text4').value = e.Text;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;} &nbsp; &nbsp; &nbsp; &nbsp;<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
HTML Bridge: Interaction Between HTML and Managed Code<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc645076(VS.95).aspx">http://msdn.microsoft.com/en-us/library/cc645076(VS.95).aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
