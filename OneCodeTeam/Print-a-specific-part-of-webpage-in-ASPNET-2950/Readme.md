# Print a specific part of webpage in ASP.NET (CSASPNETPrintPartOfPage)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Printing
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:05:36
## Description

<p style="font-family:Courier New"></p>
<h2>CSASPNETPrintPartOfPage Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The project illustrates how to print a specific part of a page.<br>
A web form page will contain many parts and some of them need not <br>
print for a page, such as button controls, you can not click them<br>
in print page, So this sample provides a method to avoid print<br>
needless part of page.<br>
<br>
Demo the Sample. <br>
<br>
Please follow these demonstration steps below.<br>
<br>
Step 1: Open the CSASPNETPrintPartOfPage.sln.<br>
<br>
Step 2: Expand the CSASPNETPrintPartOfPage web application and press <br>
&nbsp; &nbsp; &nbsp; &nbsp;Ctrl &#43; F5 to show the Default.aspx.<br>
<br>
Step 3: You will see many parts of Default.aspx page, There are one &quot;print this<br>
&nbsp; &nbsp; &nbsp; &nbsp;page&quot; button and four CheckBoxes in the middle of page.<br>
<br>
Step 4: Choose the CheckBox to select which part of the page you want to print<br>
&nbsp; &nbsp; &nbsp; &nbsp;, then click the Button control to print current page. If you do not<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;have an available printer, Choose the MicroSoft XPS Document Writer to
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;test this sample. You can see the part of page print with .xps<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;file, except for the title of web page.<br>
<br>
Step 5: Validation finished.<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step 1. Create a C# &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp;Visual Web Developer 2010. Name it as &quot;CSASPNETPrintPartOfPage&quot;.<br>
<br>
Step 2. Add a web form in the root direcory, named it as &quot;Default.aspx&quot;.<br>
<br>
Step 3. Add a &quot;image&quot; folder in the root direcory, add a picture you want
<br>
&nbsp; &nbsp; &nbsp; &nbsp;display in page.<br>
<br>
Step 4. Create some tables in Default.aspx,and you can fill them with html<br>
&nbsp; &nbsp; &nbsp; &nbsp;elements such as image, text, control , etc. <br>
<br>
Step 5. Define some public strings to store html tag and deposite them in<br>
&nbsp; &nbsp; &nbsp; &nbsp;Default.aspx page. <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;//define some stirngs,use to cut of part html code<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;public string printImageBegin, printImageEnd;
<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;//check the status of CheckBox,set div elements.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (CheckBox2.Checked)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{ printImageBegin = string.Empty; printImageEnd = string.Empty; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{ printImageBegin = enablePirnt; printImageEnd = endDiv; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
Step 6. Use JavaScript code to print currently page depend on the status of<br>
&nbsp; &nbsp; &nbsp; &nbsp;CheckBox, assign JavaScript function to button's onclick event.The<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;css and js code:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;style type=&quot;text/css&quot; media=&quot;print&quot;&gt; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;.nonPrintable<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; display: none;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/style&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;script type=&quot;text/javascript&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;function print_page() {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; window.print();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/script&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 7. Build the application and you can debug it.</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: window.print function<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms536672(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms536672(VS.85).aspx</a><br>
<br>
MSDN: CSS Reference<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms531209(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms531209(VS.85).aspx</a><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
