========================================================================
                  JSASPNETPrintPartOfPage Overview
========================================================================

/////////////////////////////////////////////////////////////////////////////
Use:

The project illustrates how to print a specific part of a page.
A web form page will contain many parts and some of them need not 
print for a page, such as button controls, you can not click them
in print page, So this sample provide a method to avoid print
needless part of page.This sample use javascript print part of page 
and do not need execute postback event.

/////////////////////////////////////////////////////////////////////////////
Demo the Sample. 

Please follow these demonstration steps below.

Step 1: Open the JSASPNETPrintPartOfPage.sln.

Step 2: Expand the JSASPNETPrintPartOfPage web application and press 
        Ctrl + F5 to show the Default.aspx.

Step 3: You will see many part of Default.aspx page, There are some
        print buttons at the upper-right corner of panels.

Step 4: Click one of print buttons to print current page. If you do 
        not have an available printer, Choose the MicroSoft XPS DocumentD:\Program\Sample-code\ASPNETPrintPartOfPage\JSASPNETPrintPartOfPage\JSASPNETPrintPartOfPage\Default.aspx
	    Writer to test this sample. You can see the part of page 
        print with .xps file, except for the title of web page.

Step 5: Validation finished.

/////////////////////////////////////////////////////////////////////////////
Code Logical:

Step 1. Create a C# "ASP.NET Empty Web Application" in Visual Studio 2010 or
        Visual Web Developer 2010. Name it as "JSASPNETPrintPartOfPage".

Step 2. Add a web form in the root direcory, named it as "Default.aspx".

Step 3. Add a "image" folder in the root direcory, add a picture you want 
        display in page.

Step 4. Create some panels and tables in Default.aspx, and you can fill them
        with html elements such as image, text, control, etc. 
         
Step 5. Use JavaScript code to print part of current page, assign 
        JavaScript function to print button's onclick event.The css and js
	    code, there only shows one:
		[code]
		<style type="text/css" media="print">  
            .a
            {
               text-align:right;
            }
        </style>
        <script type="text/javascript">
            function btnImagePrint()
		    {
               pnlImageDiv.style.display = "block";
               pnlListDiv.style.display = "none";
               pnlSearchDiv.style.display = "none";
               window.print();
               pnlListDiv.style.display = "block";
               pnlSearchDiv.style.display = "block";
            }
        </script>
		[/code]

Step 6. Build the application and you can debug it.
/////////////////////////////////////////////////////////////////////////////
References:

MSDN: window.print function
http://msdn.microsoft.com/en-us/library/ms536672(VS.85).aspx

MSDN: CSS Reference
http://msdn.microsoft.com/en-us/library/ms531209(VS.85).aspx
/////////////////////////////////////////////////////////////////////////////