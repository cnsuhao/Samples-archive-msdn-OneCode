# Pass values between windows forms (VBWinFormPassValueBetweenForms)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows Forms
## Topics
* Windows Forms
## IsPublished
* True
## ModifiedDate
* 2011-05-05 08:38:47
## Description

<p style="font-family:Courier New"></p>
<h2>WINDOWS FORMS APPLICATION : VBWinFormPassValueBetweenForms Project Overview<br>
<br>
Pass Value Between Forms Sample<br>
</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The Pass Value Between Forms sample demonstrates how to pass value between forms.<br>
<br>
There're two common ways to pass value between forms:<br>
<br>
1. Use a property.<br>
<br>
&nbsp; Create a public property on the target form class, then we can pass value <br>
&nbsp; to the target form by setting value for the property.<br>
<br>
2. Use a method.<br>
<br>
&nbsp; Create a public method on the target form class, then we can pass value to
<br>
&nbsp; the target form by passing the value as parameter to the method.<br>
&nbsp; <br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
&nbsp; 1. Create two forms named FrmPassValueBetweenForms and <br>
&nbsp; &nbsp; &nbsp;FrmPassValueBetweenForms2 respectively;<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; 2. Create a public property named ValueToPassBetweenForms in the <br>
&nbsp; &nbsp; &nbsp;FrmPassValueBetweenForms2 class;<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp;private _valueToPassBetweenForms As String;<br>
<br>
&nbsp; &nbsp; &nbsp;Public Property ValueToPassBetweenForms() As String<br>
&nbsp; &nbsp; &nbsp; &nbsp;Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return Me._valueToPassBetweenForms<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Get<br>
&nbsp; &nbsp; &nbsp; &nbsp;Set(ByVal value As String)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me._valueToPassBetweenForms = value<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Set<br>
&nbsp; &nbsp; &nbsp;End Property<br>
<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; 3. Create a public method named SetValueFromAnotherForm in the <br>
&nbsp; &nbsp; &nbsp;FrmPassValueBetweenForms2 class;<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp;Public Sub SetValueFromAnotherForm(ByVal val As String)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Me._valueToPassBetweenForms = val<br>
&nbsp; &nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; 4. On the FrmPassValueBetweenForms form, handle the Click event of the buttons.<br>
&nbsp; &nbsp; &nbsp;In the Click event handler of button1, set the SetValueFromAnotherForm
<br>
&nbsp; &nbsp; &nbsp;property for the FrmPassValueBetweenForms2 to pass the text value from
<br>
&nbsp; &nbsp; &nbsp;FrmPassValueBetweenForms to FrmPassValueBetweenForms2.<br>
&nbsp; &nbsp; &nbsp;In the Click event handler of button2, call the SetValueFromAnotherForm
<br>
&nbsp; &nbsp; &nbsp;method and pass the text value as parameter to the FrmPassValueBetweenForms2.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New">&nbsp; <br>
1. Windows Forms General FAQ.<br>
&nbsp; <a target="_blank" href="http://social.msdn.microsoft.com/Forums/en-US/winforms/thread/77a66f05-804e-4d58-8214-0c32d8f43191">
http://social.msdn.microsoft.com/Forums/en-US/winforms/thread/77a66f05-804e-4d58-8214-0c32d8f43191</a><br>
&nbsp; <br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
