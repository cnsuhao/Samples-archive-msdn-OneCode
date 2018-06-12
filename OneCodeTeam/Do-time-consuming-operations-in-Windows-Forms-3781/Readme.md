# Do time-consuming operations in Windows Forms (VBWinFormTimeConsumingOpr)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows Forms
## Topics
* Multithreading
## IsPublished
* True
## ModifiedDate
* 2011-07-28 02:47:16
## Description

<p style="font-family:Courier New">&nbsp;</p>
<h2>WINDOWS FORMS APPLICATION : VBWinFormTimeConsumingOpr Project Overview<br>
<br>
Time-consuming Operation Sample</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The Time-consuming Operation sample demonstrates how to use the BackgroundWorker <br>
component to execute a time-consuming operation in the background.<br>
&nbsp; <br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
To execute a time-consuming operation in the background, create a BackgroundWorker
<br>
and listen for events that report the progress of your operation and signal when <br>
your operation is finished. You can create the BackgroundWorker programmatically <br>
or you can drag it onto your form from the Components tab of the Toolbox. <br>
If you create the BackgroundWorker in the Windows Forms Designer, it will appear <br>
in the Component Tray, and its properties will be displayed in the Properties window.<br>
<br>
To set up for a background operation, add an event handler for the DoWork event. <br>
Call your time-consuming operation in this event handler. To start the operation,
<br>
call RunWorkerAsync. To receive notifications of progress updates, <br>
handle the ProgressChanged event. To receive a notification when the operation <br>
is completed, handle the RunWorkerCompleted event. <br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
1. BackgroundWorker Class<br>
&nbsp; <a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.backgroundworker.aspx" target="_blank">
http://msdn.microsoft.com/en-us/library/system.componentmodel.backgroundworker.aspx</a><br>
&nbsp; <br>
2. Windows Forms General FAQ.<br>
&nbsp; <a href="http://social.msdn.microsoft.com/Forums/en-US/winforms/thread/77a66f05-804e-4d58-8214-0c32d8f43191" target="_blank">
http://social.msdn.microsoft.com/Forums/en-US/winforms/thread/77a66f05-804e-4d58-8214-0c32d8f43191</a><br>
&nbsp; <br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
