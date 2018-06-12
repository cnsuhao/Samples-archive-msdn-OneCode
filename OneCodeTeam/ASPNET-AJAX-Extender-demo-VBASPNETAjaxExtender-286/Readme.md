# ASP.NET AJAX Extender demo (VBASPNETAjaxExtender)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* AJAX
## IsPublished
* True
## ModifiedDate
* 2011-05-05 07:26:40
## Description

<p style="font-family:Courier New"></p>
<h2>ASP.Net APPLICATION : CSASPNETAjaxExtender Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The CSASPNETAjaxExtender sample demonstrates how to create an ASP.Net Ajax <br>
ExtenderControl, which is a TimePicker to allow the user draging the <br>
minute/hour pointer to select a time of a day on a clock.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
Microsoft ASP.Net Ajax Extensions enables you to expand the capabilities of an <br>
ASP.Net Web Application in order to create a rich client user experience. <br>
To encapsulate the client behavior for use by ASP.NET page developers, you can <br>
use an extender control. <br>
An extender control is a Web server control that inherits the ExtenderControl <br>
abstract class in the System.Web.UI namespace. <br>
<br>
1. Creating an Extender Control.<br>
&nbsp; We can create ExtenderControl by using the template &quot;Asp.Net Ajax Server Control Extender&quot;.
<br>
&nbsp; It will present to you a class file, a resource file(Actually, we don't need it in this sample.)
<br>
&nbsp; and a js file as default. We can create the extender in class file and create behavior in js file.<br>
&nbsp; <br>
2. Extender control is used for client script functionality extension of an <br>
&nbsp; existing web control. It can be applied to specific Web server control types.
<br>
&nbsp; You identify the types of Web server controls to which an extender control
<br>
&nbsp; can be applied by using the TargetControlTypeAttribute attribute.<br>
<br>
&nbsp; [TargetControlType(typeof(TextBox))]<br>
&nbsp; public class TimePicker: ExtenderControl<br>
<br>
<br>
3. The following two methods of the ExtenderControl abstract class that you must <br>
&nbsp; implement in an extender control.<br>
<br>
&nbsp; protected override IEnumerable&lt;ScriptDescriptor&gt; <br>
GetScriptDescriptors(Control targetControl)<br>
&nbsp; {<br>
&nbsp; &nbsp; &nbsp;ScriptControlDescriptor descriptor = new ScriptControlDescriptor<br>
(&quot;CSASPNETAjaxExtender.TimePicker&quot;, targetControl.ClientID);<br>
<br>
&nbsp; &nbsp; &nbsp;descriptor.AddElementProperty(&quot;errorSpan&quot;, this.NamingContainer.FindControl<br>
(ErrorPresentControlID).ClientID);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp; &nbsp; &nbsp;descriptor.AddProperty(&quot;timeType&quot;, TimeType);<br>
<br>
&nbsp; &nbsp; &nbsp;descriptor.AddEvent(&quot;showing&quot;, OnClientShowing);<br>
<br>
&nbsp; &nbsp; &nbsp;yield return descriptor;<br>
&nbsp; }<br>
<br>
<br>
&nbsp; protected override IEnumerable&lt;ScriptReference&gt; GetScriptReferences()<br>
&nbsp; {<br>
&nbsp; &nbsp; &nbsp;yield return new ScriptReference(Page.ClientScript.GetWebResourceUrl<br>
(this.GetType(), &quot;CSASPNETAjaxExtender.TimePicker.TimePicker.js&quot;));<br>
&nbsp; }<br>
<br>
4. Embed Css reference in PreRender phase if you have a css style file to decorate the<br>
&nbsp; extender control.<br>
<br>
&nbsp; private void RenderCssReference()<br>
&nbsp; {<br>
&nbsp; &nbsp; &nbsp;string cssUrl = Page.ClientScript.GetWebResourceUrl<br>
(this.GetType(), &quot;CSASPNETAjaxExtender.TimePicker.TimePicker.css&quot;);<br>
<br>
&nbsp; &nbsp; &nbsp;HtmlLink link = new HtmlLink();<br>
&nbsp; &nbsp; &nbsp;link.Href = cssUrl;<br>
&nbsp; &nbsp; &nbsp;link.Attributes.Add(&quot;type&quot;, &quot;text/css&quot;);<br>
&nbsp; &nbsp; &nbsp;link.Attributes.Add(&quot;rel&quot;, &quot;stylesheet&quot;);<br>
&nbsp; &nbsp; &nbsp;Page.Header.Controls.Add(link);<br>
&nbsp; }<br>
&nbsp; <br>
5. Set all resources(contain images, css file and js file) embedded in this extender<br>
&nbsp; control as &quot;Embedded Resource&quot;(property &quot;Build Action&quot;).<br>
<br>
6. The control can derive from other server controls if you want to make it inherit a<br>
&nbsp; server control than ExtenderControl. In this scenario, it should derive from<br>
&nbsp; IExtenderControl interface and a server control class. Meanwhile, we have another<br>
&nbsp; three steps need to do:<br>
&nbsp; 1) Define TargetControl property<br>
&nbsp; 2) Override OnPreRender method. Register the web control as the ExtenerControl in OnPreRender phase.<br>
&nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ScriptManager manager = ScriptManager.GetCurrent(this.Page);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (manager == null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw new InvalidOperationException(&quot;A ScriptManager is required on the page.&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;manager.RegisterExtenderControl&lt;TimePicker&gt;(this);<br>
&nbsp; 3) Override Render method. Register the script descriptor which has been defined.<br>
&nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ScriptManager.GetCurrent(this.Page).RegisterScriptDescriptors(this);<br>
<br>
7. The rest work is on client-side. Register client NameSpace first.<br>
&nbsp; <br>
&nbsp; Type.registerNamespace(&quot;CSASPNETAjaxExtender&quot;);<br>
<br>
8. Build client class. <br>
<br>
&nbsp; CSASPNETAjaxExtender.TimePicker = function(element) {<br>
&nbsp; &nbsp;<br>
&nbsp; }<br>
<br>
&nbsp; CSASPNETAjaxExtender.TimePicker.prototype = {<br>
<br>
&nbsp; }<br>
<br>
9. Register the class that inherits &quot;Sys.UI.Behavior&quot;.<br>
&nbsp; <br>
&nbsp; CSASPNETAjaxExtender.TimePicker.registerClass('CSASPNETAjaxExtender.TimePicker', Sys.UI.Behavior);<br>
<br>
10.Call base method in constructor method<br>
&nbsp; <br>
&nbsp; CSASPNETAjaxExtender.TimePicker.initializeBase(this, [element]);<br>
<br>
11. Implementing the Initialize and Dispose Methods.<br>
<br>
&nbsp; Build &quot;initialize&quot; and &quot;dispose&quot; method in prototype of the class.The initialize
<br>
&nbsp; method is called when an instance of the behavior is created. Use this method to
<br>
&nbsp; set default property values, to create function delegates, and to add delegates
<br>
&nbsp; as event handlers. The dispose method is called when an instance of the behavior
<br>
&nbsp; is no longer used on the page and is removed. Use this method to free any resources
<br>
&nbsp; that are no longer required for the behavior, such as DOM event handlers.<br>
<br>
<br>
&nbsp; initialize: function() {<br>
&nbsp; &nbsp; &nbsp; CSASPNETAjaxExtender.TimePicker.callBaseMethod(this, 'initialize'); &nbsp; &nbsp; &nbsp;
<br>
<br>
&nbsp; },<br>
<br>
&nbsp; dispose: function() { &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; CSASPNETAjaxExtender.TimePicker.callBaseMethod(this, 'dispose');<br>
&nbsp; }<br>
<br>
12. Defining the Property Get and Set Methods.<br>
<br>
&nbsp; Each property identified in the ScriptDescriptor object of the extender control's
<br>
&nbsp; GetScriptDescriptors(Control) method must have corresponding client accessors.
<br>
&nbsp; The client property accessors are defined as get_&lt;property name&gt; and set_&lt;property name&gt;
<br>
&nbsp; methods of the client class prototype.<br>
<br>
<br>
&nbsp; get_timeType: function() {<br>
&nbsp; &nbsp; &nbsp; return this._timeType;<br>
&nbsp; },<br>
<br>
&nbsp; set_timeType: function(val) {<br>
&nbsp; &nbsp; &nbsp; if (this._timeType !== val) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; this._timeType = val;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; this.raisePropertyChanged('timeType');<br>
&nbsp; &nbsp; &nbsp; }<br>
&nbsp; },<br>
<br>
13. Defining the Event Handlers for the DOM Element<br>
&nbsp; 1) Defining the handler in constructor function:<br>
&nbsp; &nbsp; &nbsp; &nbsp;this._element_focusHandler = null;<br>
&nbsp; 2) Associate the handler with the DOM Element event in initailize method:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;this._element_focusHandler = Function.createDelegate(this, this._element_onfocus);<br>
&nbsp; 3) Add the handler in initailize method:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$addHandler(this.get_element(), 'focus', this._element_focusHandler)
<br>
&nbsp; 4) Build callback method about this event:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_element_onfocus:function(){<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
14. Defining the Event Handlers for the behavior<br>
<br>
&nbsp; &nbsp;Each event identified in the ScriptDescriptor object of the extender control's
<br>
&nbsp; &nbsp;GetScriptDescriptors(Control) method must have corresponding client accessors.
<br>
&nbsp; &nbsp;The client event accessors are defined as add_&lt;event name&gt; and remove_&lt;event name&gt;
<br>
&nbsp; &nbsp;methods of the client class prototype. <br>
&nbsp; &nbsp;The method Raise&lt;event name&gt; is defined to trigger the event. &nbsp;<br>
<br>
&nbsp; &nbsp;add_showing: function(handler) {<br>
&nbsp; &nbsp; &nbsp; &nbsp;this.get_events().addHandler(&quot;showing&quot;, handler);<br>
&nbsp; &nbsp;},<br>
&nbsp; &nbsp;remove_showing: function(handler) {<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;this.get_events().removeHandler(&quot;showing&quot;, handler);<br>
&nbsp; &nbsp;},<br>
&nbsp; &nbsp;raiseShowing: function(eventArgs) {<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;var handler = this.get_events().getHandler('showing');<br>
&nbsp; &nbsp; &nbsp; &nbsp;if (handler) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;handler(this, eventArgs);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;},<br>
&nbsp; &nbsp;<br>
15. Use this extender control TimePicker in page.<br>
&nbsp; &nbsp;The usage of the extender control is the same to the custom control. &nbsp; &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;1) Register the assembly in page.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &lt;%@ Register TagPrefix=&quot;CSASPNETAjaxExtender&quot; Assembly=&quot;CSASPNETAjaxExtender&quot;
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; Namespace=&quot;CSASPNETAjaxExtender&quot; %&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;2) Add a ScriptManager control in page, and create TimePicker control to bind on a TextBox.<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &lt;asp:TextBox ID=&quot;TextBox1&quot; Text=&quot;&quot; runat=&quot;server&quot;&gt;&lt;/asp:TextBox&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &lt;CSASPNETAjaxExtender:TimePicker runat=&quot;server&quot; ID=&quot;t1&quot; TargetControlID=&quot;TextBox1&quot; TimeType=&quot;H24&quot; /&gt;<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Creating an Extender Control to Associate a Client Behavior with a Web Server Control<br>
<a target="_blank" href="http://www.asp.net/AJAX/Documentation/Live/tutorials/ExtenderControlTutorial1.aspx">http://www.asp.net/AJAX/Documentation/Live/tutorials/ExtenderControlTutorial1.aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
