# Sequence workflow in WF4 (CSWF4SequenceWF)
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
* 2011-05-05 09:32:05
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CSWF4SequenceWF</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
This sample demonstrate the use of Workflow Foundation 4 Sequence in a Guess <br>
Number game. The sample also involves the use of Variable, IFElse Activity, <br>
DoWhile Activity and Cutomized Activity. <br>
<br>
To run the code sample:<br>
1. Open CSWF4SequenceWF.sln with Visual Studio 2010<br>
2. Press Ctrl&#43;F5.<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
1.Create A Workflow Console Application, name it CSWF4SequenceWF;<br>
<br>
2.Create a CodeActivity name it ReadNumberActivity.cs. Fill the file with code:<br>
<br>
&nbsp;using System;<br>
&nbsp;using System.Activities;<br>
<br>
&nbsp;namespace CSWF4SequenceWF<br>
&nbsp;{<br>
&nbsp; &nbsp; &nbsp;public sealed class ReadNumberActivity : CodeActivity<br>
&nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Define an activity out argument of type int<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;public OutArgument&lt;int&gt; playerInputNumber { get; set; }<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;protected override void Execute(CodeActivityContext context)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;playerInputNumber.Set(context,Int32.Parse(Console.ReadLine()));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp;}<br>
&nbsp;}<br>
<br>
3.Delete the default created Workflow1.xaml and create a new Activity <br>
&nbsp;GuessNumberGameSequenceWF.xaml. Author this workflow just like the one <br>
&nbsp;already existed in the project. <br>
<br>
4.Open Prgram.cs file, chage the code as follows:<br>
<br>
&nbsp;using System.Activities;<br>
&nbsp;namespace CSWF4SequenceWF<br>
&nbsp;{<br>
&nbsp; &nbsp; &nbsp;class Program<br>
&nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;static void Main(string[] args)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;WorkflowInvoker.Invoke(new GuessNumberGameSequenceWF() );<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp;}<br>
&nbsp;}<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Windows Workflow Tutorial: Introduction to Sequential Workflows<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd692925.aspx">http://msdn.microsoft.com/en-us/library/dd692925.aspx</a><br>
<br>
A Developer's Introduction to Windows Workflow Foundation (WF) in .NET 4<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ee342461.aspx">http://msdn.microsoft.com/en-us/library/ee342461.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
