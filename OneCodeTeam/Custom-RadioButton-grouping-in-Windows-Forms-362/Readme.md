# Custom RadioButton grouping in Windows Forms (VBWinFormGroupRadioButtons)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows Forms
## Topics
* Controls
## IsPublished
* True
## ModifiedDate
* 2011-05-05 08:37:17
## Description

<p style="font-family:Courier New"></p>
<h2>WINDOWS FORMS APPLICATION : VBWinFormGroupRadioButtons Project Overview<br>
<br>
RadioButton Sample<br>
</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
This sample demonstrates how to group the RadioButtons in the different containers.<br>
&nbsp; <br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
When you check one of the 4 RadioButtons the checked one will auto unchecked. In other<br>
words, the 4 RadioButtons are grouped together even they are in the different containers.<br>
<br>
</p>
<h3>Implemention:</h3>
<p style="font-family:Courier New"><br>
1. Let the 4 Radiobuttons in different containers use the radioButton_CheckedChanged
<br>
&nbsp; method to deal with their CheckedChanged event in the MainForm.Designer.vb file.<br>
&nbsp; <br>
2. Use the radTmp Radiobutton to restore the old RadioButton. First, set a RadioButton
<br>
&nbsp; checked and point the radTmp to this RadioButton.<br>
&nbsp; <br>
3. Uncheck the old one, and point the radTmp to the new checked RadioButton when each
<br>
&nbsp; CheckedChanged event occurs.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
1. Windows Forms General FAQ.<br>
&nbsp; <a target="_blank" href="http://social.msdn.microsoft.com/Forums/en-US/winforms/thread/77a66f05-804e-4d58-8214-0c32d8f43191">
http://social.msdn.microsoft.com/Forums/en-US/winforms/thread/77a66f05-804e-4d58-8214-0c32d8f43191</a><br>
&nbsp; <br>
2. Windows Forms RadioButton control<br>
&nbsp; <a target="_blank" href="http://msdn.microsoft.com/en-us/library/f5h102xz.aspx">
http://msdn.microsoft.com/en-us/library/f5h102xz.aspx</a><br>
&nbsp; <br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
