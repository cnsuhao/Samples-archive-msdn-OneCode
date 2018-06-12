# ASP.NET Validator controls demo (CSASPNETPageValidation)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Input Validation
## IsPublished
* True
## ModifiedDate
* 2011-05-05 05:08:26
## Description

<p style="font-family:Courier New"></p>
<h2>Web APPLICATION : CSASPNETPageValidation Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The sample demonstrates how to use ASP.NET validation control. <br>
There are two ways to use ASP.NET validation controls: Server-side or <br>
Client-side. The client side validation has greater performance, because it <br>
does not do some postback. If clients do not support client-side validation, <br>
we can use the server side validation instead.<br>
<br>
</p>
<h3>Validator Control Basics</h3>
<p style="font-family:Courier New"><br>
RequiredFieldValidator<br>
Ensures that the user does not skip a form entry field. <br>
The property setting:<br>
&nbsp;&nbsp;&nbsp;&nbsp;ControlToValidate - to which control the validator is applied.<br>
&nbsp;&nbsp;&nbsp;&nbsp;ErrorMessage - the error message that will be displayed in the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;validation summary.<br>
<br>
CompareValidator<br>
Allows for comparisons between the user's input and another item using a <br>
comparison operator.<br>
The property setting:<br>
&nbsp;&nbsp;&nbsp;&nbsp;ControlToValidate - to which control the validator is applied.<br>
&nbsp;&nbsp;&nbsp;&nbsp;ErrorMessage - the error message that will be displayed in the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;validation summary.<br>
&nbsp;&nbsp;&nbsp;&nbsp;ControlToCompare - gets or sets the input control to compare with the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;input control being validated. <br>
<br>
RegularExpressionValidator<br>
Checks that the user��s entry matches a pattern defined by a regular <br>
expression.<br>
The property setting:<br>
&nbsp;&nbsp;&nbsp;&nbsp;ControlToValidate - to which control the validator is applied.<br>
&nbsp;&nbsp;&nbsp;&nbsp;ErrorMessage - the error message that will be displayed in the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;validation summary.<br>
&nbsp;&nbsp;&nbsp;&nbsp;ValidationExpression - determines the pattern used to validate a field.<br>
<br>
CustomValidator<br>
Checks the user's entry using custom-coded validation logic. <br>
The property setting:<br>
&nbsp;&nbsp;&nbsp;&nbsp;ControlToValidate - to which control the validator is applied.<br>
&nbsp;&nbsp;&nbsp;&nbsp;ErrorMessage - the error message that will be displayed in the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;validation summary.<br>
&nbsp;&nbsp;&nbsp;&nbsp;ClientValidationFunction - determines client-side script function used
<br>
&nbsp;&nbsp;&nbsp;&nbsp;for validation.<br>
<br>
ValidationSummary<br>
Displays all the error messages from the validators in one specific spot on <br>
the page.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Validating ASP.NET Server Controls<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa479013.aspx">http://msdn.microsoft.com/en-us/library/aa479013.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
