# ASP.NET AJAX image preview extender (CSASPNETAJAXImagePreviewExtender)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* AJAX
## IsPublished
* True
## ModifiedDate
* 2011-05-05 08:54:54
## Description

<p style="font-family:Courier New"></p>
<h2>CSASPNETImagePreviewExtender Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The project illustrates how to design an AJAX Control Extender. <br>
In this sample, it is one extender for images.<br>
The images which use the extender control will be shown in a thumbnail mode at<br>
first, if user click the image, a big picture will be popped up and show the<br>
true size of the image.<br>
<br>
Demo the Sample. <br>
<br>
Open the CSASPNETImagePreviewExtender.sln directly and open the <br>
ImagePreviewExtenderTest website to test the page extender directly.<br>
<br>
If you want to have a further test, please follow the demonstration step below.<br>
<br>
Step 1: View the Default.aspx in your browser. You will find some pictures.<br>
<br>
Step 2: When the page is loaded, the pictures are all in thumbnail mode, it <br>
looks small. Click on the first image.<br>
<br>
Step 3: When click on the image which using the extender, you will see a big<br>
popup image with the whole size and the position of the picture will be auto-<br>
fitted.<br>
<br>
Step 4: Click the CLOSE button at the left-top of the big image.<br>
<br>
Step 5: If we put the image into a Panel and the Panel has been extended by <br>
ImagePreviewExtender, you will find all the images in this panel will get the<br>
same feature.<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step 1. &nbsp;Create a C# &quot;ASP.NET AJAX Server Control Extender&quot; Project
<br>
&nbsp;&nbsp;&nbsp;&nbsp;in Visual Studio 2010 or Visual Web Developer 2010.<br>
&nbsp;&nbsp;&nbsp;&nbsp;Name it as ImagePreviewExtender.<br>
<br>
Step 2. We can see three files created. one .JS file, one .CS and <br>
&nbsp;&nbsp;&nbsp;&nbsp;one .RESX file. Delete the .RESX file, we don't need that here.<br>
&nbsp;&nbsp;&nbsp;&nbsp;Rename the js file to ImagePreviewBehavior.js.<br>
&nbsp;&nbsp;&nbsp;&nbsp;Rename the cs file to ImagePreviewControl.cs.<br>
<br>
Step 3. &nbsp;Open the ImagePreviewControl.cs.<br>
&nbsp;&nbsp;&nbsp;&nbsp;Add a property called &quot;ThumbnailCssClass&quot;.<br>
&nbsp;&nbsp;&nbsp;&nbsp;In the overrides function GetScriptDescriptors, use code like below to<br>
&nbsp;&nbsp;&nbsp;&nbsp;add the property to the descriptor.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;[Code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;ScriptBehaviorDescriptor descriptor = new ScriptBehaviorDescriptor(<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;ImagePreviewExtender.ImagePreviewBehavior&quot;,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;targetControl.ClientID);<br>
&nbsp; &nbsp; &nbsp; &nbsp;descriptor.AddProperty(&quot;ThumbnailCssClass&quot;, ThumbnailCssClass);<br>
&nbsp;&nbsp;&nbsp;&nbsp;[/Code]<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Modify the name of the ScriptReference in the function of
<br>
&nbsp;&nbsp;&nbsp;&nbsp;GetScriptReferences.<br>
<br>
Step 4. &nbsp;Open the ImagePreviewBehavior.js. Write the javascript according to
<br>
&nbsp;&nbsp;&nbsp;&nbsp;the description in the sample file with the same file name.<br>
<br>
Step 5. &nbsp;Open the AssemblyInfo.cs in the folder of &quot;Properties&quot;. At the bottom
<br>
&nbsp;&nbsp;&nbsp;&nbsp;of the file, create two web resource defination. We can download a close<br>
&nbsp;&nbsp;&nbsp;&nbsp;icon and copy the file to the root directory.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;[Code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;[Assembly: WebResource(&quot;ImagePreviewExtender.ImagePreviewBehavior.js&quot;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;text/javascript&quot;)]
<br>
&nbsp;&nbsp;&nbsp;&nbsp;[Assembly: WebResource(&quot;ImagePreviewExtender.Close.png&quot;,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;image/png&quot;)]<br>
&nbsp;&nbsp;&nbsp;&nbsp;[/Code]<br>
<br>
Step 6. &nbsp;The extender is ready. Create a ASP.NET WebSite or ASP.NET Web Application<br>
&nbsp;&nbsp;&nbsp;&nbsp;to test the extender. Reference the project at first and then use the control<br>
&nbsp;&nbsp;&nbsp;&nbsp;just like we use one in the AJAXControlToolKit. <br>
<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Microsoft Ajax Extender Controls Overview<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb470384.aspx">http://msdn.microsoft.com/en-us/library/bb470384.aspx</a><br>
<br>
MSDN: Walkthrough: Microsoft Ajax Extender Controls<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb470455.aspx">http://msdn.microsoft.com/en-us/library/bb470455.aspx</a><br>
<br>
MSDN: Creating an Extender Control to Associate a Client Behavior with a Web Server Control<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb386403.aspx">http://msdn.microsoft.com/en-us/library/bb386403.aspx</a><br>
<br>
MSDN: ExtenderControl Members<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.extendercontrol_members.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.extendercontrol_members.aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
