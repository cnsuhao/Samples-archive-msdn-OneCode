# Stop postback in javascript (CSASPNETStopPostbackInJS)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* Postback
## IsPublished
* True
## ModifiedDate
* 2012-04-20 03:34:04
## Description
======================================================================== CSASPNETStopPostbackInJS Overview ======================================================================== /////////////////////////////////////////////////////////////////////////////
 Use: The project illustrates how to stop postbacks event in JavaScript. Basically many threads mentions this kind of questions, people wants to know how to stop auto-postbacks event by use Asp.net server control, such as Button. That's the reason why we need
 this sample, here we give a CheckBox control in page, people can decide execute postbacks event or not by a convenient way. ///////////////////////////////////////////////////////////////////////////// Demo the Sample. Please follow these demonstration steps
 below. Step 1: Open the CSASPNETStopPostbackInJS.sln. Step 2: Expand the CSASPNETStopPostbackInJS web application and press Ctrl &#43; F5 to show the Default.aspx. Step 3: In Default.aspx page, there are two links. Click one of them, please. Step 4: Click the
 button of StopPostBack1.aspx page, and you can find some text in TextBox. If you not select the CheckBox that means allow application execute postbacks event, the TextBox will show &quot;This is a client click. This is a server click&quot;. Step 5: Select CheckBox and
 click Button again, and the TextBox will only display &quot;This is a client click&quot;. The application had stop postbacks event already. Step 6: Return to Default.aspx page and select another link for testing. Step 7: Validation finished. /////////////////////////////////////////////////////////////////////////////
 Code Logical: Step 1. Create a C# &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or Visual Web Developer 2010. Name it as &quot;CSASPNETStopPostbackInJS&quot;. Step 2. Add three web forms in the root directory, name them as &quot;Default.aspx&quot;, &quot;StopPostBack1.aspx&quot;,
 &quot;StopPostBack2.aspx&quot;. Step 3. Add two links in Default.aspx page, assign to StopPostBack1.aspx and StopPostBack2.aspx. Step 4. Create a html table in StopPostBack1.aspx page and fill it with some labels, checkboxes, buttons and a html textbox, add button's
 onClientClick and onClick events. Coding JavaScript function like this: [code] function onClientClickEvent() { var text = document.getElementById('textDisplay'); var checkbox = document.getElementById('chkStopPostback'); text.value = &quot;This is a client click&quot;;
 if (checkbox.checked == true) { return false; } else { return true; } } [/code] Use button's onClientClick event to invoke this function. It will check the status of checkbox to decide execute postbacks event or not, the button will not execute server-side
 code when js function return false. Add following code in function btnCausePostback_Click: [code] textDisplay.Value &#43;= &quot; This is a server click&quot;; [/code] Step 5. StopPostBack2.aspx's layout is similar to StopPostBack2.aspx, you need to add a new html button
 control and change server button to a hidden button control. Step 6. Use html button's onClick event call js function. Step 7. Build the application and you can debug it. ///////////////////////////////////////////////////////////////////////////// References:
 MSDN: postbacks Event http://msdn.microsoft.com/en-us/library/aa720416(VS.71).aspx /////////////////////////////////////////////////////////////////////////////
