# ASP.NET localization demo (VBASPNETLocalization)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Globalization and Localization
## IsPublished
* True
## ModifiedDate
* 2011-05-05 07:33:10
## Description

<p style="font-family:Courier New"></p>
<h2>ASP.NET APPLICATION : VBASPNETLocalization Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
&nbsp;The project illustrates how to build a multi-lingual website with ASP.NET<br>
&nbsp;Localization. ASP.NET enables pages obtain content and other data based<br>
&nbsp;on the preferred language setting of the browser or based on the user's <br>
&nbsp;explicit choice of language. If controls are configured to get property<br>
&nbsp;values from resources, at run time, the resource expressions are replaced<br>
&nbsp;by resources from the appropriate resource file. &nbsp;<br>
<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step1. Create a Visual Basic ASP.NET Web Application in Visual Studio 2008 <br>
or Visual Web Developer. Then rename the defualt page from Defualt.aspx to<br>
LocalResources.aspx<br>
<br>
Step2. Right click the project's name and select contect menu item follow <br>
this order: &quot;Add&quot; -&gt; &quot;Add ASP.NET forlder&quot; -&gt; &quot;App_LocalResources&quot;.<br>
<br>
Step3: Add four new Resources files in this App_LocalResources folder and <br>
name them as follows:<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;LocalResources.aspx.de.resx<br>
&nbsp; &nbsp;LocalResources.aspx.en.resx<br>
&nbsp; &nbsp;LocalResources.aspx.fr.resx<br>
&nbsp; &nbsp;LocalResources.aspx.resx<br>
<br>
[NOTE] In App_LocalResources folder, the Resources is one on one related to <br>
ASP.NET page by its name. For example, if the Resources file is working for<br>
Default.aspx, then its name should be Default.aspx.[CultureInfo].resx. Here,<br>
our page's name is LocalResources.aspx, so the Resources files need to be<br>
renamed as LocalResources.aspx.[CultureInfo].resx. The [CultureInfo] is an <br>
abbreviation to tell with which culture the Resources file is used. Please <br>
refer to this list for brief information on culture names and corresponding <br>
abbreviations.<br>
<br>
Arabic &nbsp; &nbsp; &nbsp;ar<br>
German &nbsp; &nbsp; &nbsp;de<br>
Greece &nbsp; &nbsp; &nbsp;el<br>
English &nbsp; &nbsp; en<br>
Spanish &nbsp; &nbsp; es<br>
French &nbsp; &nbsp; &nbsp;fr<br>
Italian &nbsp; &nbsp; it<br>
Japanese &nbsp; &nbsp;ja<br>
Korean &nbsp; &nbsp; &nbsp;ko<br>
Chinese &nbsp; &nbsp; zh<br>
<br>
Step4: Edit these four Resources files according to the culture to set keys <br>
and corresponding values. For example, if we need lblLocal.Text to display <br>
&quot;Hello World&quot; in french, so we add the key &quot;lblHelloWorld.Text&quot; and the value
<br>
&quot;Bonjour tout le monde&quot; to LocalResources.aspx.fr.resx file.<br>
<br>
[NOTE] The LocalResources.aspx.resx is the file for an invariant culture. No <br>
culture is assigned to it. If no culture can be determined, the file is then <br>
utilized. In the demo, we set LocalResources.aspx.resx as the same to the one<br>
in English.<br>
<br>
Step5: Add a DropDownList to the page to let users select the language they <br>
want to read with. Edit the items' Text as the language name and the value as <br>
the appropriate abbreviations according to the table above.<br>
<br>
Step6: Add InitializeCulture() event handler into Code-Behind page and over-<br>
rides this handler to set the CurrentUICulture and CurrentCulture according <br>
to the DropDownList's value. <br>
<br>
&nbsp; &nbsp;Protected Overrides Sub InitializeCulture()<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim strLanguageInfo As String = Request.Form(&quot;ddlLanguage&quot;)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;If Not strLanguageInfo Is Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;'Thread.CurrentThread.CurrentUICulture = ...<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;'Thread.CurrentThread.CurrentCulture = ...<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp;End Sub<br>
<br>
[NOTE] The reason why here we don't use ddlLanguage.SelectedValue is all the <br>
page controls, including ddlLanguage is unavailable in this event.<br>
<br>
Step6: Add a Label control to LocalResources.aspx and rename it to lblLocal.<br>
<br>
Step7: Edit the HTML tags of the Label to add meta:resourceKey attribute and <br>
point this attribute to the key name in the Resources files.<br>
<br>
&nbsp; &nbsp;&lt;asp:Label ID=&quot;lblHelloWorld&quot; &nbsp;runat=&quot;server&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; meta:resourceKey=&quot;lblLocal&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
[NOTE] In the figure, the properties of the controls are defined in Local<br>
Resource files. For example, the Label control has its Text property exposed <br>
as lblLocal.Text. ASP.NET then sets this property value to Label based on <br>
the culture selection.<br>
<br>
[NOTE] All the steps we did above is to show how to use Local Resources <br>
localize pages. However, all these changes only works in the single page <br>
and if we goto another page, they will be lost. To handle this issue, <br>
please continue the following steps to learn how to use Global Resources.<br>
<br>
Step8: Right click the project's name and select contect menu item follow <br>
this order: &quot;Add&quot; -&gt; &quot;Add ASP.NET forlder&quot; -&gt; &quot;App_GlobalResources&quot;.<br>
<br>
Step9: Add four new Resources files in this App_GlobalResources folder. Then<br>
rename them and edit them to meet culture data of different languages.<br>
<br>
[NOTE] When using Global Resources files, the file's name doesn't need to be<br>
the same as any page's name. We can simply call them like GlobalResources. <br>
<br>
Step10: Add a new ASP.NET page and name it as GlobalResources.aspx. Also, add<br>
a Button control to LocalResources.aspx to do the navigation to the page using<br>
Global Resources via PostBackUrl property<br>
<br>
[NOTE] Please don't use a HyperLink or write Response.Redirect to transfer<br>
the page. This is because we need to pass the value in the DropDownList to<br>
the new page.<br>
<br>
Step11: Add a new Label to the page and rename it to lblGlobal. Then set the<br>
Text property and the BackColor property of this Label as an Expression Text <br>
within &lt;%$ ... %&gt;.<br>
<br>
&nbsp; &nbsp;&lt;asp:Label ID=&quot;lblGlobal&quot; runat=&quot;server&quot; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; BackColor=&quot;&lt;%$ Resources:GlobalResources, lblGlobalBackColor%&gt;&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Text=&quot;&lt;%$ Resources:GlobalResources, lblGlobalText%&gt;&quot;&gt;<br>
&nbsp; &nbsp;&lt;/asp:Label&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
[NOTE] This is the way Global Resources works. An Expression is set to the<br>
property we need to change based on different cultures. We start it with <br>
&quot;Resources&quot; to declare this is resources field. Then, append the name of a
<br>
certain Global Resources file and the key name in it with a comma to split <br>
these two parameters. By this way, the resouces data, like lblGlobalText is<br>
able to be accessed from entire website.<br>
<br>
Step12: Copy both the HTML source code and the Visual Basic behind code from<br>
LocalResources.aspx to GlobalResources.aspx and edit the btnNavigate Button <br>
to give a back link.<br>
<br>
[NOTE] Run the application from LocalResources.aspx and select a language.<br>
We can see the two Labels in the page are both changed based on the value in <br>
DropDownList. However, if we redirect to GlobalResources.aspx via the Button, <br>
we find only lblGlobal is changed. Because only this Label is localized by <br>
Global Resources feature.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: ASP.NET Globalization and Localization<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/c6zyy3s9.aspx">http://msdn.microsoft.com/en-us/library/c6zyy3s9.aspx</a><br>
<br>
MSDN: Resources and Localization in ASP.NET 2.0<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/magazine/cc163566.aspx">http://msdn.microsoft.com/en-us/magazine/cc163566.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
