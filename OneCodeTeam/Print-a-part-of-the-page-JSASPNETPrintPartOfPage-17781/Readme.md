# Print a part of the page (JSASPNETPrintPartOfPage)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* Printing
* Webpage
## IsPublished
* True
## ModifiedDate
* 2012-07-22 06:47:03
## Description
========================================================================<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;JSASPNETPrintPartOfPage Overview<br>
========================================================================<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Use:<br>
<br>
The project illustrates how to print a specific part of a page.<br>
A web form page will contain many parts and some of them need not <br>
print for a page, such as button controls, you can not click them<br>
in print page, So this sample provide a method to avoid print<br>
needless part of page.This sample use javascript print part of page <br>
and do not need execute postback event.<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Demo the Sample. <br>
<br>
Please follow these demonstration steps below.<br>
<br>
Step 1: Open the JSASPNETPrintPartOfPage.sln.<br>
<br>
Step 2: Expand the JSASPNETPrintPartOfPage web application and press <br>
&nbsp; &nbsp; &nbsp; &nbsp;Ctrl &#43; F5 to show the Default.aspx.<br>
<br>
Step 3: You will see many part of Default.aspx page, There are some<br>
&nbsp; &nbsp; &nbsp; &nbsp;print buttons at the upper-right corner of panels.<br>
<br>
Step 4: Click one of print buttons to print current page. If you do <br>
&nbsp; &nbsp; &nbsp; &nbsp;not have an available printer, Choose the MicroSoft XPS DocumentD:\Program\Sample-code\ASPNETPrintPartOfPage\JSASPNETPrintPartOfPage\JSASPNETPrintPartOfPage\Default.aspx<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;Writer to test this sample. You can see the part of page
<br>
&nbsp; &nbsp; &nbsp; &nbsp;print with .xps file, except for the title of web page.<br>
<br>
Step 5: Validation finished.<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Code Logical:<br>
<br>
Step 1. Create a C# &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp;Visual Web Developer 2010. Name it as &quot;JSASPNETPrintPartOfPage&quot;.<br>
<br>
Step 2. Add a web form in the root direcory, named it as &quot;Default.aspx&quot;.<br>
<br>
Step 3. Add a &quot;image&quot; folder in the root direcory, add a picture you want <br>
&nbsp; &nbsp; &nbsp; &nbsp;display in page.<br>
<br>
Step 4. Create some panels and tables in Default.aspx, and you can fill them<br>
&nbsp; &nbsp; &nbsp; &nbsp;with html elements such as image, text, control, etc. <br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
Step 5. Use JavaScript code to print part of current page, assign <br>
&nbsp; &nbsp; &nbsp; &nbsp;JavaScript function to print button's onclick event.The css and js<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;code, there only shows one:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;style type=&quot;text/css&quot; media=&quot;print&quot;&gt; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;.a<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; text-align:right;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/style&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;script type=&quot;text/javascript&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;function btnImagePrint()<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; pnlImageDiv.style.display = &quot;block&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; pnlListDiv.style.display = &quot;none&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; pnlSearchDiv.style.display = &quot;none&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; window.print();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; pnlListDiv.style.display = &quot;block&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; pnlSearchDiv.style.display = &quot;block&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/script&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 6. Build the application and you can debug it.<br>
/////////////////////////////////////////////////////////////////////////////<br>
References:<br>
<br>
MSDN: window.print function<br>
http://msdn.microsoft.com/en-us/library/ms536672(VS.85).aspx<br>
<br>
MSDN: CSS Reference<br>
http://msdn.microsoft.com/en-us/library/ms531209(VS.85).aspx<br>
/////////////////////////////////////////////////////////////////////////////<br>
