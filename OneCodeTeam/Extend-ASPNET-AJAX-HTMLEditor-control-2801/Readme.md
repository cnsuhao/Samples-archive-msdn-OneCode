# Extend ASP.NET AJAX HTMLEditor control (CSASPNETAJAXHTMLEditorExtender)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* AJAX
## IsPublished
* False
## ModifiedDate
* 2011-05-05 08:55:09
## Description

<p style="font-family:Courier New"></p>
<h2>CSASPNETHTMLEditorExtender Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The project illustrates how to add a custom button to the toolbar of a <br>
HTMLEditor in the Ajax Control Toolkit 4.1.40412.0.<br>
<br>
Demo the Sample. <br>
<br>
Please follow these demonstration steps below.<br>
<br>
Step 1: Open the CSASPNETHTMLEditorExtender.sln.<br>
<br>
Step 2: [This step is very important!]Rebuild the solution.<br>
<br>
Step 3: Expand the TestWebSite and right-click the Default.aspx &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;and click &quot;View in Browser&quot;. <br>
<br>
Step 4: Input some text into the Editor.<br>
<br>
Step 5: Select some text from your input.<br>
<br>
Step 6: Click the last &quot;H1&quot; button form the top toolbar.<br>
<br>
Step 7: You will see the selected text has been formatted to the style of H1.<br>
&nbsp; &nbsp; &nbsp; &nbsp;If you click the second button from the bottom toolbar, you will see<br>
&nbsp; &nbsp; &nbsp; &nbsp;that the selected text has been surrounded with tag &lt;H1&gt;.<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step 1: Download the AjaxControlToolkit from this link:<br>
&nbsp; &nbsp; &nbsp; &nbsp;<a target="_blank" href="http://www.asp.net/ajaxlibrary/act.ashx">http://www.asp.net/ajaxlibrary/act.ashx</a><br>
<br>
Step 2. &nbsp;Create a C# &quot;Class Library&quot; project in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp; Visual Web Developer 2010. Change the name to HTMLEditorExtender.<br>
<br>
Step 3. &nbsp;Add references in the list below:<br>
&nbsp; &nbsp; &nbsp; &nbsp; AjaxControlToolkit (version 4.1.40412.0)<br>
&nbsp; &nbsp; &nbsp; &nbsp; System.Web <br>
&nbsp; &nbsp; &nbsp; &nbsp; System.Web.Extensions<br>
<br>
Step 4. &nbsp;Create two new folders, call them Images and ToolBar_buttons.<br>
<br>
Step 5. &nbsp;we need two icons for the button, one for the actived button and one
<br>
&nbsp; &nbsp; &nbsp; &nbsp; for the un-actived button. I create two images, <br>
&nbsp; &nbsp; &nbsp; &nbsp; one called ed_format_h1_a.gif and another is ed_format_h1_n.gif.
<br>
&nbsp; &nbsp; &nbsp; &nbsp; Add the two images into the folder Images.<br>
<br>
Step 6. &nbsp;Select the two images in the Solution Explorer of the VS.<br>
&nbsp; &nbsp; &nbsp; &nbsp; Right-click them and select Properties. <br>
&nbsp; &nbsp; &nbsp; &nbsp; You can find Build Action, <br>
&nbsp; &nbsp; &nbsp; &nbsp; set the Build Action to Embedded Resource.<br>
<br>
<br>
Step 7. &nbsp;In the folder ToolBar_buttons, create a js file, I named it H1.pre.js.<br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
Step 8. &nbsp;Write the JavaScript functions in H1.pre.js to register <br>
&nbsp; &nbsp; &nbsp; &nbsp; the client features for the H1 button. We can get the full functions in<br>
&nbsp; &nbsp; &nbsp; &nbsp; the sample file H1.pre.js.<br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
Step 9. &nbsp;Do the same thing in Step 5, make the Build Action to Embedded Resource
<br>
&nbsp; &nbsp; &nbsp; &nbsp; for the H1.pre.js<br>
<br>
Step 10. &nbsp;Create a new class file, I call it H1.cs, in the &nbsp;ToolBar_buttons folder.<br>
<br>
Step 11. Write the codes to register server side class for the button. Refer to <br>
&nbsp; &nbsp; &nbsp; &nbsp; sample file H1.cs.<br>
<br>
Step 12. Create a new class in the root of the project, I call it MyEditor.cs.<br>
&nbsp; &nbsp; &nbsp; &nbsp; Write the code like below to make an extender Editor.<br>
&nbsp; &nbsp; &nbsp; &nbsp; [CODE]<br>
&nbsp; &nbsp; &nbsp; &nbsp; namespace HTMLEditorExtender &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; { &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; public class MyEditor : Editor &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; { &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; protected override void FillTopToolbar() &nbsp;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; { &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; base.FillTopToolbar(); &nbsp;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; TopToolbar.Buttons.Add(new H1()); &nbsp;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; } &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; } &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; } &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; [/CODE]<br>
<br>
Step 13. Build the project.<br>
<br>
Step 14. Create a new C# &quot;Web Site&quot;, change the last folder name to TestWebSite.<br>
<br>
Step 15. Add reference of the class project, HTMLEditorExtender.<br>
<br>
Step 16. Create a test page. And add two Register declaration like below.<br>
&nbsp; &nbsp; &nbsp; &nbsp; [CODE]<br>
&nbsp; &nbsp; &nbsp; &nbsp; &lt;%@ Register Assembly=&quot;AjaxControlToolkit&quot; Namespace=&quot;AjaxControlToolkit&quot; TagPrefix=&quot;asp&quot; %&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &lt;%@ Register Assembly=&quot;HTMLEditorExtender&quot; Namespace=&quot;HTMLEditorExtender&quot; TagPrefix=&quot;asp&quot; %&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; [/CODE]<br>
<br>
Step 17. Create a ToolScriptManager and a MyEditor to the page.<br>
&nbsp; &nbsp; &nbsp; &nbsp; [CODE]<br>
&nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:ToolkitScriptManager runat=&quot;server&quot; ID=&quot;ToolkitScriptManager1&quot;&gt;&lt;/asp:ToolkitScriptManager&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &lt;asp:MyEditor runat=&quot;server&quot; ID=&quot;MyEditor1&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; [/CODE]<br>
<br>
Step 18. Test the Default.aspx.<br>
</p>
<h3>Reference:</h3>
<p style="font-family:Courier New"><br>
HTMLEditor Tutorials<br>
<a target="_blank" href="http://www.asp.net/ajaxlibrary/act_HTMLEditor.ashx">http://www.asp.net/ajaxlibrary/act_HTMLEditor.ashx</a><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
