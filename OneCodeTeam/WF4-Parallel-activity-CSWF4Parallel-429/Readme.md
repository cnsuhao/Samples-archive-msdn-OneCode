# WF4 Parallel activity (CSWF4Parallel)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* WF
## Topics
* Windows Workflow
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:31:45
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CSWF4Parallel</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
This sample demonstrate the usage of WF4 Parallel activity, ForEach activity<br>
and ParallelForEach activity.<br>
<br>
The Parallal embedded child activities will execute asynchronously, but they<br>
are still in the same thread. <br>
<br>
Child statements of ParallelForEach activity will execute asynchronously,just<br>
like Parallel, statements are running in the same thread.You may notice that<br>
only one Delay activity in the ParallelForEach take effects,while remain Delay<br>
activities seem skipped.as a matter of fact,this is the ParallelForEach by <br>
design feature.Whenever the ParallelForEach's embedded statement goes idle.<br>
the next statement will execute immediately rather than waiting there.<br>
<br>
To run the sample:<br>
1. Open CSWF4Parallel.sln with Visual Studio 2010.<br>
2. Press Ctrl&#43;F5.<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
Step 1.Create a new Workflow Console Application project,name it CSWF4Parallel<br>
<br>
Step 2.Author a workflow in the default created Workflow1.xaml file(See the<br>
&nbsp; &nbsp; &nbsp; workflow exsited in the project.) <br>
<br>
Step 3.Press Ctrl&#43;F5 to build the project and run it without debugging. <br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Parallel Activity Designer<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ee829519.aspx">http://msdn.microsoft.com/en-us/library/ee829519.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
