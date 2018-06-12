# WF4 Parallel activity (VBWF4Parallel)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* WF
## Topics
* Workflow
## IsPublished
* True
## ModifiedDate
* 2011-05-05 10:05:27
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : VBWF4Parallel</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
This sample demonstrates the usage of WF4 Parallel activity, ForEach activity<br>
and ParallelForEach activity.<br>
<br>
The Parallel embedded child activities will execute asynchronously, but they<br>
still in the same thread. <br>
<br>
Child statements of ParallelForEach activity will execute asynchronously,just<br>
like Parallel, statements are running in the same thread. You may notice that<br>
only one Delay activity in the ParallelForEach take effects, while remain Delay<br>
activities seem skipped. As a matter of fact, this is the ParallelForEach by <br>
design feature. Whenever the ParallelForEach's embedded statement goes idle.<br>
the next statement will execute immediately rather than waiting there.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
1. Open VBWF4Parallel.sln with Visual Studio 2010.<br>
2. Press Ctrl&#43;F5.<br>
<br>
</p>
<h3>Prerequisite:</h3>
<p style="font-family:Courier New"><br>
1. Visual Studio 2010<br>
2. .NET Framework 4.0<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
Step 1.Create a new Workflow Console Application project, name it VBWF4Parallel<br>
Step 2.Author a workflow in the default created Workflow1.xaml file(See the<br>
&nbsp; &nbsp; &nbsp; workflow existed in the project.) <br>
Step 3.Press Ctrl&#43;F5 to build the project and run it without debugging. <br>
<br>
</p>
<h3>Reference:</h3>
<p style="font-family:Courier New"><br>
A Developer's Introduction to Windows Workflow Foundation (WF) in .NET 4<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ee342461.aspx">http://msdn.microsoft.com/en-us/library/ee342461.aspx</a><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
