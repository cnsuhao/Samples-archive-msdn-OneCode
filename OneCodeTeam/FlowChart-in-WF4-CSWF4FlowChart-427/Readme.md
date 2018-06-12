# FlowChart in WF4 (CSWF4FlowChart)
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
* 2011-05-05 09:31:06
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CSWF4FlowChart</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
A new control flow activity called Flowchart has been added to make it <br>
possible for developers to use the Flowchart model to define a workflow. The <br>
Flowchart more closely resembles the concepts and thought processes that <br>
many analysts and developers go through when creating solutions or designing <br>
business processes. &nbsp;Therefore, it made sense to provide an activity to make
<br>
it easy to model the conceptual thinking and planning that had already been <br>
done. &nbsp;The Flowchart enables concepts such as returning to previous steps and
<br>
splitting logic based on a single condition, or a Switch / Case logic. &nbsp;<br>
<br>
This code sample demonstrate the use of Workflow Foundation 4 Flowchart in a <br>
Guess Number game. <br>
<br>
To run the sample:<br>
1. Open CSWF4FlowChart.sln with Visual Studio 2010.<br>
2. Press Ctrl&#43;F5.<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
1. Create a new Workflow Console Workflow named it CSWF4FlowChart;<br>
<br>
2. Create a new code file and name it ReadNumberActivity.cs. Fill the file <br>
&nbsp; with the following code:<br>
<br>
&nbsp; using System;<br>
&nbsp; using System.Activities;<br>
<br>
&nbsp; namespace CS_WF4_SequenceWF<br>
&nbsp; {<br>
&nbsp; &nbsp; &nbsp; public sealed class ReadNumberActivity : CodeActivity<br>
&nbsp; &nbsp; &nbsp; {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; // Define an activity out argument of type int<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; public OutArgument&lt;int&gt; playerInputNumber { get; set; }<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; protected override void Execute(CodeActivityContext context)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; playerInputNumber.Set(context,Int32.Parse(Console.ReadLine()));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; }<br>
&nbsp; &nbsp; &nbsp; }<br>
&nbsp; }<br>
<br>
3. Delete the default created Workflow1.xaml and create a new Activity <br>
&nbsp; GuessNumberGameInFlowChart.xaml. Author this workflow just like the one <br>
&nbsp; already existed in the project. <br>
<br>
4. Open Program.cs file, change the code as follows:<br>
<br>
&nbsp; using System.Activities;<br>
&nbsp; using System.Activities.Statements;<br>
<br>
&nbsp; namespace CSWF4FlowChart<br>
&nbsp; {<br>
&nbsp; &nbsp; &nbsp; class Program<br>
&nbsp; &nbsp; &nbsp; {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; static void Main(string[] args)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; WorkflowInvoker.Invoke(new GuessNumberGameInFlowChart());<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; }<br>
&nbsp; &nbsp; &nbsp; }<br>
&nbsp; }<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Flowchart Workflows<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd489448.aspx">http://msdn.microsoft.com/en-us/library/dd489448.aspx</a><br>
<br>
A Developer's Introduction to Windows Workflow Foundation (WF) in .NET 4<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ee342461.aspx">http://msdn.microsoft.com/en-us/library/ee342461.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
