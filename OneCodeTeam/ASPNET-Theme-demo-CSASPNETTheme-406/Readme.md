# ASP.NET Theme demo (CSASPNETTheme)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Theme
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:10:00
## Description

<p style="font-family:Courier New"></p>
<h2>ASP.Net APPLICATION : CSASPNETTheme Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The CSASPNETTheme sample demonstrates how to create an ASP.Net with themes, <br>
which can be applied during the page inital progress.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
A theme is a collection of property settings that allow you to define the look <br>
of pages and controls, and then apply the look consistently across pages <br>
in a Web application, across an entire Web application, or across all Web <br>
applications on a server.<br>
<br>
Themes are made up of a set of elements: skins, cascading style sheets (CSS), <br>
images, and other resources. At a minimum, a theme will contain skins. <br>
Themes are defined in special directories in your Web site or on your Web server.<br>
<br>
You can define themes for a single Web application, or as global themes <br>
that can be used by all applications on a Web server. After a theme is defined, <br>
it can be placed on individual pages using the Theme or StyleSheetTheme attribute
<br>
of the @ Page directive, or it can be applied to all pages in an application <br>
by setting the &lt;pages&gt; element in the application configuration file. <br>
If the &lt;pages&gt; element is defined in the Machine.config file, <br>
the theme will apply to all pages in Web applications on the server.<br>
<br>
This sample contain 2 themes, which can be changed during page initial period.<br>
There are 2 buttons on the default page. Once they are clicked, a redirect to <br>
default page happens which including the theme name. While the page is initailizating,<br>
the theme parament will be cought, and new theme will be applied.<br>
<br>
Step 1: Create a C# ASP.NET Web Application Project <br>
&nbsp;&nbsp;&nbsp;&nbsp;in Visual Studio 2010 or Visual Web Developer 2010.<br>
&nbsp;&nbsp;&nbsp;&nbsp;Name it as CSASPNETTheme.<br>
<br>
Step 2: Open Default.aspx, add following controls:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Image ID=&quot;Image1&quot; SkinId=&quot;MainTheme&quot; runat=&quot;server&quot;
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;ImageUrl=&quot;~/images/Blank.jpg&quot; /&gt;<br>
&nbsp; &nbsp;&lt;asp:Button ID=&quot;Button1&quot; SkinId=&quot;BlueTheme&quot; <br>
&nbsp; &nbsp; &nbsp; &nbsp;runat=&quot;server&quot; Text=&quot;Blue&quot; ForeColor=&quot;Blue&quot; BackColor=&quot;Azure&quot;/&gt;<br>
&nbsp; &nbsp;&lt;asp:Button ID=&quot;Button2&quot; SkinId=&quot;PinkTheme&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp;runat=&quot;server&quot; Text=&quot;Pink&quot; ForeColor=&quot;Pink&quot; BackColor=&quot;Red&quot;/&gt;<br>
<br>
Step 3: Right click on project in Solution Explorer, go to Add then Add ASP.Net <br>
&nbsp;&nbsp;&nbsp;&nbsp;Folder, then App_Themes. Right click on App_Theme in Solution Explorer,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;go to Add then Add ASP.Net Folder, then Theme to add a theme.
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Add two themes and rename them as BlueTheme and PinkTheme.<br>
&nbsp;&nbsp;&nbsp;&nbsp;Add a skin file and a CSS file in each theme.<br>
<br>
Step 4: Open skin file in the BlueTheme, copy and paste following codes:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Image runat=&quot;server&quot; SkinId=&quot;MainTheme&quot; ImageUrl=&quot;~/images/Blue.jpg&quot;/&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Button SkinId=&quot;BlueTheme&quot; runat=&quot;server&quot; Visible=&quot;false&quot;/&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Button SkinId=&quot;PinkTheme&quot; runat=&quot;server&quot; Visible=&quot;true&quot;/&gt;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;NOTE: A skin file contains property settings for individual controls.<br>
<br>
Step 5: Open CSS file in the BlueTheme, copy and paste following codes in body:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;background:blue<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;NOTE: Cascading Style Sheets is a simple mechanism for adding style to Web documents.<br>
<br>
Step 6: Add PinkTheme defines similar to Step 3 & 4.<br>
<br>
Step 7: Double click on the Blue button on default.aspx copy and paste following<br>
&nbsp; &nbsp;codes to Button1_Click(object sender, EventArgs e):<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Redirect(&quot;~/default.aspx?theme=Blue&quot;);<br>
<br>
Step 8: Add Pink button actions similar to Step 7.<br>
<br>
Step 9: Open Defult.aspx.cs copy and paste following codes in the partial class:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;protected void Page_PreInit(object sender, EventArgs e)<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;switch (Request.QueryString[&quot;theme&quot;])<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;case &quot;Blue&quot;:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Page.Theme = &quot;BlueTheme&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;break;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;case &quot;Pink&quot;:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Page.Theme = &quot;PinkTheme&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;break;<br>
&nbsp; &nbsp; &nbsp; }<br>
&nbsp; &nbsp;} <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
ASP.NET Themes and Skins<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ykzx33wh.aspx?PHPSESSID=8415f84585668e69ce791db4abfd0c45">http://msdn.microsoft.com/en-us/library/ykzx33wh.aspx?PHPSESSID=8415f84585668e69ce791db4abfd0c45</a><br>
<br>
How to: Define ASP.NET Page Themes<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms247256.aspx?PHPSESSID=8415f84585668e69ce791db4abfd0c45">http://msdn.microsoft.com/en-us/library/ms247256.aspx?PHPSESSID=8415f84585668e69ce791db4abfd0c45</a><br>
<br>
Cascading Style Sheets<br>
<a target="_blank" href="http://www.w3.org/Style/CSS/">http://www.w3.org/Style/CSS/</a><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
