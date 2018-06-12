# Use MEF in Silverlight 4 (CSSL4MEF)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Silverlight
## Topics
* MEF
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:27:25
## Description

<p style="font-family:Courier New"></p>
<h2>SILVERLIGHT APPLICATION : CSSL4MEF Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
Managed Extensibility Framework (MEF) is a framework which could assist <br>
developers to design extensible application. It's supported by Silverlight 4. <br>
This sample uses MEF to create a simple text formater. By using the <br>
predefined contract, users can create components to enhance the formater's <br>
functionality. The components can be loaded at runtime.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
To test this sample:<br>
1. Open CSSL4MEF solution and build the solution.<br>
2. Right click CSSL4MEFTestPage.aspx file, select &quot;View in Browser&quot;.<br>
3. In opened page, you may find a Silverlight application.<br>
&nbsp;&nbsp;&nbsp;&nbsp;a. In right area of Silverlight, there are some controls which cloud change<br>
&nbsp;&nbsp;&nbsp;&nbsp;the state of text shown on left side. For each controls in right area, it's<br>
&nbsp;&nbsp;&nbsp;&nbsp;composed with application by MEF.<br>
&nbsp;&nbsp;&nbsp;&nbsp;b. By Clicking the &quot;Click to load color config control&quot; button, MEF would load<br>
&nbsp;&nbsp;&nbsp;&nbsp;extension component and recompose the config panel dynamicly.<br>
<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
Silverlight 4 Tools for Visual Studio 2010<br>
<a target="_blank" href="&lt;a target=" href="http://www.silverlight.net/getstarted/">http://www.silverlight.net/getstarted/</a>'&gt;<a target="_blank" href="http://www.silverlight.net/getstarted/">http://www.silverlight.net/getstarted/</a><br>
<br>
Silverilght 4 runtime<br>
<a target="_blank" href="&lt;a target=" href="http://www.silverlight.net/getstarted/">http://www.silverlight.net/getstarted/</a>'&gt;<a target="_blank" href="http://www.silverlight.net/getstarted/">http://www.silverlight.net/getstarted/</a><br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. How to use MEF to build an extensible Silverlight Application?<br>
&nbsp;&nbsp;&nbsp;&nbsp;It's a long story, I recommend CodeBetter's blog MEF series<br>
&nbsp;&nbsp;&nbsp;&nbsp;<a target="_blank" href="http://codebetter.com/blogs/glenn.block/archive/2009/11/30/building-the-hello-mef-dashboard-in-silverlight-4-part-i.aspx">http://codebetter.com/blogs/glenn.block/archive/2009/11/30/building-the-hello-mef-dashboard-in-silverlight-4-part-i.aspx</a><br>
<br>
2. What's the solution structure?<br>
&nbsp;&nbsp;&nbsp;&nbsp;CSSL4MEF project utilized MEF to implement the ConfigPanel control, which cloud<br>
&nbsp;&nbsp;&nbsp;&nbsp;download plugin xap and extend functionality at runtime.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;CSSL4MEF.Web project is CSSL4MEF silverlight application's host web application.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;ConfigControl.Contract project defines the contract as the ConfigPanel's extension<br>
&nbsp;&nbsp;&nbsp;&nbsp;interface.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;ConfigControl.Extension project implement configpanel's extension interface, create<br>
&nbsp;&nbsp;&nbsp;&nbsp;a components &quot;ColorPicker&quot;.<br>
<br>
3. How does MEF work in this project?<br>
&nbsp;&nbsp;&nbsp;&nbsp;When running the application, you may see there are mainly two regions on<br>
&nbsp;&nbsp;&nbsp;&nbsp;view. The left side shows a short text, and the right side has certain<br>
&nbsp;&nbsp;&nbsp;&nbsp;controls which could change text style. Actually, these controls are binded to a<br>
&nbsp;&nbsp;&nbsp;&nbsp;predefined DataModel. Those styled text has no magical, just bind UI property<br>
&nbsp;&nbsp;&nbsp;&nbsp;to datamodel and utilize INotifiyPropertyChanged to update UI in realtime.<br>
&nbsp;&nbsp;&nbsp;&nbsp;For right side, it is a Silverlight control &quot;ConfigPanel&quot;. It could
<br>
&nbsp;&nbsp;&nbsp;&nbsp;bind to datamodel by &quot;ConfigData&quot; property, and generate config controls<br>
&nbsp;&nbsp;&nbsp;&nbsp;automaticly.<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;Because the datamodel's property can be any type and has various requirement,<br>
&nbsp;&nbsp;&nbsp;&nbsp;To make the ConfigPanel be able to generate appropriate controls for any<br>
&nbsp;&nbsp;&nbsp;&nbsp;datamodels, we need to let the ConfigPanel be extensible. In this scenario,<br>
&nbsp;&nbsp;&nbsp;&nbsp;MEF could help to meet this desgin task.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;We defined an interface called &quot;IConfigControl&quot;, which should be able to
<br>
&nbsp;&nbsp;&nbsp;&nbsp;return an edit control binded to the given property field. The ConfigPanel<br>
&nbsp;&nbsp;&nbsp;&nbsp;utilze MEF to hold a list of IConfigControl, by calling <br>
&nbsp;&nbsp;&nbsp;&nbsp;IConfigControl.MatchTest method, configPanel would find most suitable<br>
&nbsp;&nbsp;&nbsp;&nbsp;configControl for each property and add&nbsp;&nbsp;&nbsp;&nbsp;control to config panel.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Suppose we have a datamodel, which has Color type property, to extend<br>
&nbsp;&nbsp;&nbsp;&nbsp;the ConfigPanel to support Color type, we would create a new silverlight<br>
&nbsp;&nbsp;&nbsp;&nbsp;project, implementing IConfigControl and mark with Export attribute to<br>
&nbsp;&nbsp;&nbsp;&nbsp;make it discoverable. Then, by using &quot;DeploymentCatalogService&quot;, we could<br>
&nbsp;&nbsp;&nbsp;&nbsp;dynamicly load the extension config control, once the calagory changed,<br>
&nbsp;&nbsp;&nbsp;&nbsp;configPanel get notificaton and recompose UI for datamodel.<br>
&nbsp; &nbsp;<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MEF community site<br>
<a target="_blank" href="http://mef.codeplex.com/">http://mef.codeplex.com/</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
