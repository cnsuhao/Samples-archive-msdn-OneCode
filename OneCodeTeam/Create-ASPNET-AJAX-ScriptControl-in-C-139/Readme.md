# Create ASP.NET AJAX ScriptControl in C# (CSASPNETAjaxScriptControl)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* AJAX
## IsPublished
* False
## ModifiedDate
* 2011-04-05 04:39:53
## Description

<h2>ASP.Net APPLICATION : CSASPNETAjaxScriptControl Project Overview</h2>
<h3>Use:</h3>
<p><br>
<span style="font-family:courier new,courier; font-size:small">The CSASPNETAjaxScriptControl sample demonstrates how to create an ASP.Net Ajax
</span><br>
<span style="font-family:courier new,courier; font-size:small">ScriptControl, which is a Schedule to allow the user arrange tasks in calendar.</span><br>
<br>
</p>
<h3>Prerequisite:</h3>
<p><br>
<span style="font-family:courier new,courier; font-size:small">ASP.NET AJAX Control Toolkit</span><br>
<span style="font-family:courier new,courier; font-size:small"><a href="http://www.codeplex.com/AjaxControlToolkit" target="_blank">http://www.codeplex.com/AjaxControlToolkit</a></span><br>
<br>
</p>
<h3>Code Logic:</h3>
<p><br>
<span style="font-family:courier new,courier; font-size:small">Microsoft ASP.Net Ajax Extensions enables you to expand the capabilities of an
</span><br>
<span style="font-family:courier new,courier; font-size:small">ASP.Net Web Application in order to create a rich client user experience. We
</span><br>
<span style="font-family:courier new,courier; font-size:small">can make use of ScriptControl or ExtenderControl to build a rich client behavior
</span><br>
<span style="font-family:courier new,courier; font-size:small">or web control. The difference between ExtenderControl and ScriptControl is that
</span><br>
<span style="font-family:courier new,courier; font-size:small">Extender is used on creating client script capabilities on an existing control,
</span><br>
<span style="font-family:courier new,courier; font-size:small">which is called &quot;TargetControl&quot; for this behavior, whereas ScriptControl is an
</span><br>
<span style="font-family:courier new,courier; font-size:small">absolute web control which contains rich client functionality.For example, when
</span><br>
<span style="font-family:courier new,courier; font-size:small">we'd like to build a ModalPopup which will pop out an existing Panel, show/hide
</span><br>
<span style="font-family:courier new,courier; font-size:small">functionality is the client script application, then we can build it as
</span><br>
<span style="font-family:courier new,courier; font-size:small">ExtenderControl. </span>
<br>
<br>
<span style="font-family:courier new,courier; font-size:small">However, for ScriptControl, for instance, TabContainer which is the entirely
</span><br>
<span style="font-family:courier new,courier; font-size:small">new web control contains the client script functionality, so we can build it
</span><br>
<span style="font-family:courier new,courier; font-size:small">as ScriptControl.</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">1. To build a web server control with rich client experiences by ASP.NET page
</span><br>
<span style="font-family:courier new,courier; font-size:small">developers, you can use an script control.(Create ASP.Net Ajax Server Control
</span><br>
<span style="font-family:courier new,courier; font-size:small">project by File-&gt;New-&gt;Project-&gt;Web-&gt;ASP.Net Ajax Server Control in Visual Studio)
</span><br>
<span style="font-family:courier new,courier; font-size:small">An script control is a web server control that inherits the ScriptControl abstract
</span><br>
<span style="font-family:courier new,courier; font-size:small">class in the System.Web.UI namespace.
</span><br>
<span style="font-family:courier new,courier; font-size:small">Script control is used for establishing a web server control which contains rich
</span><br>
<span style="font-family:courier new,courier; font-size:small">client capability.
</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">public class Schedule : ScriptControl</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">2. The following two methods of the ScriptControl abstract class that you must
</span><br>
<span style="font-family:courier new,courier; font-size:small">implement in an script control.</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp;public IEnumerable&lt;ScriptDescriptor&gt; GetScriptDescriptors()</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp;{</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ScriptControlDescriptor descriptor = new ScriptControlDescriptor</span><br>
<span style="font-family:courier new,courier; font-size:small">(&quot;PainControls.Schedule&quot;, this.ClientID);</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;descriptor.AddElementProperty(&quot;toolContainer&quot;, ToolContainer.ClientID);</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;descriptor.AddElementProperty(&quot;dateTimePicker&quot;,
</span><br>
<span style="font-family:courier new,courier; font-size:small">DateTimePicker.ClientID);</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;descriptor.AddElementProperty(&quot;calendarContainer&quot;,
</span><br>
<span style="font-family:courier new,courier; font-size:small">CalendarContainer.ClientID);</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;descriptor.AddProperty(&quot;calendarCellContentCssClass&quot;,
</span><br>
<span style="font-family:courier new,courier; font-size:small">CalendarCellContentCssClass);</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (string.IsNullOrEmpty(ServicePath))</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw new Exception(&quot;Please set ServicePath property.&quot;);</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;descriptor.AddProperty(&quot;servicePath&quot;, ServicePath);</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (string.IsNullOrEmpty(UpdateServiceMethod))</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw new Exception(&quot;Please set UpdateServiceMethod property.&quot;);</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;descriptor.AddProperty(&quot;updateServiceMethod&quot;, UpdateServiceMethod);</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (string.IsNullOrEmpty(DeleteServiceMethod))</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw new Exception(&quot;Please set DeleteServiceMethod property.&quot;);</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;descriptor.AddProperty(&quot;deleteServiceMethod&quot;, DeleteServiceMethod);</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;List&lt;string&gt; aa = new List&lt;string&gt;();</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;for (int i = 0; i &lt; DropPanelClientIDCollection.Count; i&#43;&#43;)</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string a = DropPanelClientIDCollection[i].ClientID;</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;aa.Add(a);</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp;
</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;descriptor.AddProperty(&quot;dropPanelClientIDCollection&quot;, aa);</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;descriptor.AddProperty(&quot;dateTimeFieldName&quot;, DateTimeFieldName);</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;descriptor.AddProperty(&quot;titleFieldName&quot;, TitleFieldName);</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;descriptor.AddProperty(&quot;descriptionFieldName&quot;, DescriptionFieldName);</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;yield return descriptor;</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp;}</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp;// Generate the script reference</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp;public IEnumerable&lt;ScriptReference&gt; GetScriptReferences()</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp;{</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;yield return new ScriptReference(Page.ClientScript.GetWebResourceUrl</span><br>
<span style="font-family:courier new,courier; font-size:small">(this.GetType(), &quot;PainControls.Schedule.Schedule.js&quot;));</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp;}</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">3. Embed Css reference in PreRender phase.</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">private void RenderCssReference()</span><br>
<span style="font-family:courier new,courier; font-size:small">{</span><br>
<span style="font-family:courier new,courier; font-size:small">string cssUrl = Page.ClientScript.GetWebResourceUrl(this.GetType(),
</span><br>
<span style="font-family:courier new,courier; font-size:small">&quot;PainControls. Schedule. Schedule.css&quot;);</span><br>
<span style="font-family:courier new,courier; font-size:small">HtmlLink link = new HtmlLink();</span><br>
<span style="font-family:courier new,courier; font-size:small">link.Href = cssUrl;</span><br>
<span style="font-family:courier new,courier; font-size:small">link.Attributes.Add(&quot;type&quot;, &quot;text/css&quot;);</span><br>
<span style="font-family:courier new,courier; font-size:small">link.Attributes.Add(&quot;rel&quot;, &quot;stylesheet&quot;);</span><br>
<span style="font-family:courier new,courier; font-size:small">Page.Header.Controls.Add(link);</span><br>
<span style="font-family:courier new,courier; font-size:small">}</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">4. Set all resources(contain images, css file and js file) embedded in this
</span><br>
<span style="font-family:courier new,courier; font-size:small">script control as &quot;Embedded Resource&quot;(property &quot;Build Action&quot;).</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">5. This script control can derive from IScriptControl interface and a server
</span><br>
<span style="font-family:courier new,courier; font-size:small">control, instead of ScriptControl if you'd like to.</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">The control can derive from other server controls if you want to make it inherit
</span><br>
<span style="font-family:courier new,courier; font-size:small">a server control than ScriptControl.
</span><br>
<span style="font-family:courier new,courier; font-size:small">For example: </span>
<br>
<br>
<span style="font-family:courier new,courier; font-size:small">public class Schedule : DataBoundControl, IScriptControl,INamingContainer
</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">In this scenario, it should derive from IScriptControl interface and a server
</span><br>
<span style="font-family:courier new,courier; font-size:small">control class. Meanwhile, we have another three steps need to do:</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">1) Override OnPreRender method. Register the web control as the ScriptControl
</span><br>
<span style="font-family:courier new,courier; font-size:small">in OnPreRender phase.</span><br>
<span style="font-family:courier new,courier; font-size:small">ScriptManager manager = ScriptManager.GetCurrent(this.Page);</span><br>
<span style="font-family:courier new,courier; font-size:small">if (manager == null)</span><br>
<span style="font-family:courier new,courier; font-size:small">{</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;throw new InvalidOperationException(&quot;A ScriptManager is required on the page.&quot;);</span><br>
<span style="font-family:courier new,courier; font-size:small">}</span><br>
<span style="font-family:courier new,courier; font-size:small">manager.RegisterScriptControl&lt;Schedule&gt;(this);</span><br>
<span style="font-family:courier new,courier; font-size:small">2) Override Render method. Register the script descriptor which has been defined.
</span><br>
<span style="font-family:courier new,courier; font-size:small">ScriptManager.GetCurrent(this.Page).RegisterScriptDescriptors(this);</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">6. The rest work is on client-side. Register client NameSpace first.</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">Type.registerNamespace(&quot;PainControls&quot;);</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">7. Build client class.</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">PainControls.Schedule = function(element)
</span><br>
<span style="font-family:courier new,courier; font-size:small">{</span><br>
<span style="font-family:courier new,courier; font-size:small">}</span><br>
<span style="font-family:courier new,courier; font-size:small">PainControls.Schedule.prototype = {</span><br>
<span style="font-family:courier new,courier; font-size:small">}</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">8. Register the class that inherits &quot; Sys.UI.Control&quot;.</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">PainControls.Schedule.registerClass('PainControls. Schedule��, Sys.UI.Control);</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">9. Call base method in constructor method</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">PainControls. Schedule.initializeBase(this, [element]);</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">10. Implementing the Initialize and Dispose Methods.</span><br>
<span style="font-family:courier new,courier; font-size:small">Build &quot;initialize&quot; and &quot;dispose&quot; method in prototype of the class. The
</span><br>
<span style="font-family:courier new,courier; font-size:small">initialize method is called when an instance of the behavior is created.
</span><br>
<span style="font-family:courier new,courier; font-size:small">Use this method to set default property values, to create function delegates,
</span><br>
<span style="font-family:courier new,courier; font-size:small">and to add delegates as event handlers. The dispose method is called when an
</span><br>
<span style="font-family:courier new,courier; font-size:small">instance of the behavior is no longer used on the page and is removed. Use
</span><br>
<span style="font-family:courier new,courier; font-size:small">this method to free any resources that are no longer required for the behavior,
</span><br>
<span style="font-family:courier new,courier; font-size:small">such as DOM event handlers.</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">initialize: function() {</span><br>
<span style="font-family:courier new,courier; font-size:small">PainControls. Schedule.callBaseMethod(this, 'initialize');</span><br>
<span style="font-family:courier new,courier; font-size:small">},</span><br>
<span style="font-family:courier new,courier; font-size:small">dispose: function() {</span><br>
<span style="font-family:courier new,courier; font-size:small">PainControls. Schedule.callBaseMethod(this, 'dispose');</span><br>
<span style="font-family:courier new,courier; font-size:small">}</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">11. Defining the Property Get and Set Methods.</span><br>
<span style="font-family:courier new,courier; font-size:small">Each property identified in the ScriptDescriptor object of the script control's
</span><br>
<span style="font-family:courier new,courier; font-size:small">GetScriptDescriptors() method must have corresponding client accessors. The
</span><br>
<span style="font-family:courier new,courier; font-size:small">client property accessors are defined as get_&lt;:property&gt; and set_&lt;:property&gt;
</span><br>
<span style="font-family:courier new,courier; font-size:small">methods of the client class prototype.</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp;get_titleFieldName: function() {</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp;return this._titleFieldName;</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp;},</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp;set_titleFieldName: function(val) {</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp;if (this._titleFieldName !== val) {</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this._titleFieldName = val;</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.raisePropertyChanged('titleFieldName');</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp; &nbsp; &nbsp;}</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; &nbsp;},</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">12. Defining the Event Handlers for the DOM Element</span><br>
<span style="font-family:courier new,courier; font-size:small">1) Defining the handler in constructor function:</span><br>
<span style="font-family:courier new,courier; font-size:small">this._element_focusHandler = null;</span><br>
<span style="font-family:courier new,courier; font-size:small">2) Associate the handler with the DOM Element event in initailize method:</span><br>
<span style="font-family:courier new,courier; font-size:small">this._element_focusHandler = Function.createDelegate(this, this._element_onfocus);</span><br>
<span style="font-family:courier new,courier; font-size:small">3) Add the handler in initailize method:</span><br>
<span style="font-family:courier new,courier; font-size:small">$addHandler(this.get_element(), 'focus', this._element_focusHandler)</span><br>
<span style="font-family:courier new,courier; font-size:small">4) Build callback method about this event:</span><br>
<span style="font-family:courier new,courier; font-size:small">_element_onfocus:function(){</span><br>
<span style="font-family:courier new,courier; font-size:small">}</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">13. Defining the Event Handlers for the behavior</span><br>
<span style="font-family:courier new,courier; font-size:small">Each event identified in the ScriptDescriptor object of the script control's
</span><br>
<span style="font-family:courier new,courier; font-size:small">GetScriptDescriptors() method must have corresponding client accessors. The
</span><br>
<span style="font-family:courier new,courier; font-size:small">client event accessors are defined as add_&lt;:event&gt; and remove_&lt;:event&gt; methods
</span><br>
<span style="font-family:courier new,courier; font-size:small">of the client class prototype. The method Raise&lt;:event&gt; is defined to trigger
</span><br>
<span style="font-family:courier new,courier; font-size:small">the event.</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">add_showing: function(handler) {</span><br>
<span style="font-family:courier new,courier; font-size:small">this.get_events().addHandler(&quot;showing&quot;, handler);</span><br>
<span style="font-family:courier new,courier; font-size:small">},</span><br>
<span style="font-family:courier new,courier; font-size:small">remove_showing: function(handler) {</span><br>
<span style="font-family:courier new,courier; font-size:small">this.get_events().removeHandler(&quot;showing&quot;, handler);</span><br>
<span style="font-family:courier new,courier; font-size:small">},</span><br>
<span style="font-family:courier new,courier; font-size:small">raiseShowing: function(eventArgs) {</span><br>
<span style="font-family:courier new,courier; font-size:small">var handler = this.get_events().getHandler('showing');</span><br>
<span style="font-family:courier new,courier; font-size:small">if (handler) {</span><br>
<span style="font-family:courier new,courier; font-size:small">handler(this, eventArgs);</span><br>
<span style="font-family:courier new,courier; font-size:small">}</span><br>
<span style="font-family:courier new,courier; font-size:small">},</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">14. Use this script control Schedule in page.</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">1) About Schedule control.</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">1. The schedule is bound on DataSource control. You can select a date in left
</span><br>
<span style="font-family:courier new,courier; font-size:small">clanedar, it will retrieve the data from DataSource, and present the corresponding
</span><br>
<span style="font-family:courier new,courier; font-size:small">task in the right container.</span><br>
<span style="font-family:courier new,courier; font-size:small">2. Each task will be presented in a DropPanel. You can Drag &amp; Drop it to another
</span><br>
<span style="font-family:courier new,courier; font-size:small">cell(day). It will be updated automatically.</span><br>
<span style="font-family:courier new,courier; font-size:small">3. When you mouse move on the droppanel, it will show CloseButton so that you can
</span><br>
<span style="font-family:courier new,courier; font-size:small">remove this task.</span><br>
<span style="font-family:courier new,courier; font-size:small">4. When mouse over the cell of schedule, it will expend itself by design if it has
</span><br>
<span style="font-family:courier new,courier; font-size:small">more task needs to show.</span><br>
<span style="font-family:courier new,courier; font-size:small">5. In the left calendar, it will highlight the date which has tasks.</span><br>
<span style="font-family:courier new,courier; font-size:small">6. Since it is an Ajax ScriptControl, you can use custom css style at will.</span><br>
<span style="font-family:courier new,courier; font-size:small">7. Schedule used the other two script controls ButtonList and DropPanel in this
</span><br>
<span style="font-family:courier new,courier; font-size:small">project.</span><br>
<span style="font-family:courier new,courier; font-size:small">8. You need build and bind a web service file on this control to achieve updating
</span><br>
<span style="font-family:courier new,courier; font-size:small">and deleting function asychronously.</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">2) What capability needs expend</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">It��s a simple schedule here. The following functionality needs to expend and
</span><br>
<span style="font-family:courier new,courier; font-size:small">will be implemented in the next version.</span><br>
<span style="font-family:courier new,courier; font-size:small">1. Besides &quot;Month&quot; display mode, &quot;Day&quot; display mode is needed.</span><br>
<span style="font-family:courier new,courier; font-size:small">2. Recently, you can create a DetailView to insert a new task, since Schedule
</span><br>
<span style="font-family:courier new,courier; font-size:small">is bound on DataSource.
</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; Next time, I'd like to expend the internal insert functionality.</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">3) How to use PainControl Schedule:</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">1.Register the assembly in page.</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">&lt;%@ Register TagPrefix=&quot;PainControls&quot; Assembly=&quot;PainControls&quot;
</span><br>
<span style="font-family:courier new,courier; font-size:small">Namespace=&quot;PainControls&quot; %&gt;</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">2. Use it in the page</span><br>
<span style="font-family:courier new,courier; font-size:small">&lt;asp:ScriptManager ID=&quot;ScriptManager1&quot; runat=&quot;server&quot; /&gt;</span><br>
<span style="font-family:courier new,courier; font-size:small">&lt;Pain:Schedule ID=&quot;Schedule&quot; runat=&quot;server&quot; AutoPostBack=&quot;true&quot;
</span><br>
<span style="font-family:courier new,courier; font-size:small">DataSourceID=&quot;SqlDataSource1&quot;
</span><br>
<span style="font-family:courier new,courier; font-size:small">KeyField=&quot;num&quot; </span>
<br>
<span style="font-family:courier new,courier; font-size:small">DateTimeFieldName=&quot;date_time&quot;
</span><br>
<span style="font-family:courier new,courier; font-size:small">TitleFieldName=&quot;title&quot;
</span><br>
<span style="font-family:courier new,courier; font-size:small">DescriptionFieldName=&quot;description&quot;
</span><br>
<span style="font-family:courier new,courier; font-size:small">ServicePath=&quot;ScheduleWebService.asmx&quot;
</span><br>
<span style="font-family:courier new,courier; font-size:small">UpdateServiceMethod=&quot;UpdateWebService&quot;
</span><br>
<span style="font-family:courier new,courier; font-size:small">DeleteServiceMethod=&quot;DeleteWebService&quot; /&gt;</span><br>
<span style="font-family:courier new,courier; font-size:small">&lt;asp:SqlDataSource ID=&quot;SqlDataSource1&quot; runat=&quot;server&quot;</span><br>
<span style="font-family:courier new,courier; font-size:small">ConnectionString=&quot;&lt;%$ ConnectionStrings:DatabaseConnectionString %&gt;&quot;</span><br>
<span style="font-family:courier new,courier; font-size:small">SelectCommand=&quot;SELECT * FROM [schedule]&quot;&gt;&lt;/asp:SqlDataSource&gt;</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">3. Property</span><br>
<span style="font-family:courier new,courier; font-size:small">DataSourceID ---- Create a DataSource and bind it on Schedule.</span><br>
<span style="font-family:courier new,courier; font-size:small">KeyField ---- The field name of primary key of DataSource.</span><br>
<span style="font-family:courier new,courier; font-size:small">There are three mandatory field you have to create:</span><br>
<span style="font-family:courier new,courier; font-size:small">DateTimeFieldName ---- related field name about the datetime of the task</span><br>
<span style="font-family:courier new,courier; font-size:small">TitleFieldName ---- related field name about the title of the task</span><br>
<span style="font-family:courier new,courier; font-size:small">DescriptionFieldName ---- related field name about the description of the task</span><br>
<span style="font-family:courier new,courier; font-size:small">ServicePath ---- If you have used AjaxControlToolkit, you must be familar with
</span><br>
<span style="font-family:courier new,courier; font-size:small">this property. It means the path of the web service file.</span><br>
<span style="font-family:courier new,courier; font-size:small">UpdateServiceMethod ---- The web method name to execute updating function</span><br>
<span style="font-family:courier new,courier; font-size:small">DeleteServiceMethod ---- The web method name to execute deleting function</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">4. Build a web service bound to achieve updating and deleting function</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">The following demo snippets are the web methods of updating function and delete
</span><br>
<span style="font-family:courier new,courier; font-size:small">function.</span><br>
<span style="font-family:courier new,courier; font-size:small">In the web method of updating function:</span><br>
<span style="font-family:courier new,courier; font-size:small">&quot;key&quot; is the primary key that will be updated.</span><br>
<span style="font-family:courier new,courier; font-size:small">&quot;updateFieldName&quot; is the field name that will be updated.</span><br>
<span style="font-family:courier new,courier; font-size:small">&quot;updateValue&quot; is the related value which it is updated to about &quot;updateFieldName&quot;.</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">In the web method of deleting function,</span><br>
<span style="font-family:courier new,courier; font-size:small">just need &quot;key&quot; that is the primary key that will be deleted.</span><br>
<span style="font-family:courier new,courier; font-size:small">[WebMethod]</span><br>
<span style="font-family:courier new,courier; font-size:small">[System.Web.Script.Services.ScriptMethod]</span><br>
<span style="font-family:courier new,courier; font-size:small">public void UpdateWebService(string key, string updateFieldName, string updateValue)</span><br>
<span style="font-family:courier new,courier; font-size:small">{</span><br>
<span style="font-family:courier new,courier; font-size:small">string constr = </span>
<br>
<span style="font-family:courier new,courier; font-size:small">(string)ConfigurationManager.ConnectionStrings[&quot;DatabaseConnectionString&quot;].ConnectionString;</span><br>
<span style="font-family:courier new,courier; font-size:small">string sql = </span>
<br>
<span style="font-family:courier new,courier; font-size:small">&quot;update schedule set &quot; &#43; updateFieldName &#43; &quot;='&quot; &#43; updateValue&#43;&quot;' where num=&quot;&#43;key;</span><br>
<span style="font-family:courier new,courier; font-size:small">SqlConnection connection = new SqlConnection(constr);</span><br>
<span style="font-family:courier new,courier; font-size:small">SqlCommand sdc = new SqlCommand(sql, connection);</span><br>
<span style="font-family:courier new,courier; font-size:small">sdc.CommandType = CommandType.Text;</span><br>
<span style="font-family:courier new,courier; font-size:small">try</span><br>
<span style="font-family:courier new,courier; font-size:small">{</span><br>
<span style="font-family:courier new,courier; font-size:small">connection.Open();</span><br>
<span style="font-family:courier new,courier; font-size:small">sdc.ExecuteScalar();</span><br>
<span style="font-family:courier new,courier; font-size:small">}</span><br>
<span style="font-family:courier new,courier; font-size:small">catch (SqlException SQLexc)</span><br>
<span style="font-family:courier new,courier; font-size:small">{</span><br>
<span style="font-family:courier new,courier; font-size:small">throw new Exception(SQLexc.Message);</span><br>
<span style="font-family:courier new,courier; font-size:small">}</span><br>
<span style="font-family:courier new,courier; font-size:small">finally</span><br>
<span style="font-family:courier new,courier; font-size:small">{</span><br>
<span style="font-family:courier new,courier; font-size:small">connection.Close();</span><br>
<span style="font-family:courier new,courier; font-size:small">}</span><br>
<span style="font-family:courier new,courier; font-size:small">System.Threading.Thread.Sleep(2000);</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">}</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">[WebMethod]</span><br>
<span style="font-family:courier new,courier; font-size:small">[System.Web.Script.Services.ScriptMethod]</span><br>
<span style="font-family:courier new,courier; font-size:small">public void DeleteWebService(string key)</span><br>
<span style="font-family:courier new,courier; font-size:small">{</span><br>
<br>
<span style="font-family:courier new,courier; font-size:small">string constr = </span>
<br>
<span style="font-family:courier new,courier; font-size:small">(string)ConfigurationManager.ConnectionStrings[&quot;DatabaseConnectionString&quot;].ConnectionString;</span><br>
<span style="font-family:courier new,courier; font-size:small">string sql = &quot;delete from schedule where num=&quot; &#43; key;</span><br>
<span style="font-family:courier new,courier; font-size:small">SqlConnection connection = new SqlConnection(constr);</span><br>
<span style="font-family:courier new,courier; font-size:small">SqlCommand sdc = new SqlCommand(sql, connection);</span><br>
<span style="font-family:courier new,courier; font-size:small">sdc.CommandType = CommandType.Text;</span><br>
<span style="font-family:courier new,courier; font-size:small">try</span><br>
<span style="font-family:courier new,courier; font-size:small">{</span><br>
<span style="font-family:courier new,courier; font-size:small">connection.Open();</span><br>
<span style="font-family:courier new,courier; font-size:small">sdc.ExecuteScalar();</span><br>
<span style="font-family:courier new,courier; font-size:small">}</span><br>
<span style="font-family:courier new,courier; font-size:small">catch (SqlException SQLexc)</span><br>
<span style="font-family:courier new,courier; font-size:small">{</span><br>
<span style="font-family:courier new,courier; font-size:small">throw new Exception(SQLexc.Message);</span><br>
<span style="font-family:courier new,courier; font-size:small">}</span><br>
<span style="font-family:courier new,courier; font-size:small">finally</span><br>
<span style="font-family:courier new,courier; font-size:small">{</span><br>
<span style="font-family:courier new,courier; font-size:small">connection.Close();</span><br>
<span style="font-family:courier new,courier; font-size:small">}</span><br>
<span style="font-family:courier new,courier; font-size:small">System.Threading.Thread.Sleep(2000);</span><br>
<span style="font-family:courier new,courier; font-size:small">}</span><br>
<br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="/site/view/file/274/0/image.png" alt="">
</a></div>
