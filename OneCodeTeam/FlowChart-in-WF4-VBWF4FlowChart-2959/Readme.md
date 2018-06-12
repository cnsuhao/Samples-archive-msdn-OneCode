# FlowChart in WF4 (VBWF4FlowChart)
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
* 2011-05-05 10:05:06
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : VBWF4FlowChart</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
This sample demonstrate the usage of WF4 Sequence workflow in a Guess Number<br>
Game workflow. this sample will also involve the usage of Variable, IFElse <br>
Activity, DoWhile Activity and Cutomized Activity. <br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
1. Open VBWF4FlowChart.sln with Visual Studio 2010.<br>
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
1. Create a new Workflow Console Workflow named it VBWF4FlowChart;<br>
<br>
2. Create a new code file name it ReadNumberActivity.vb, file the file with <br>
&nbsp; the following code:<br>
<br>
Imports System<br>
Imports System.Activities<br>
<br>
Public Class ReadNumberActivity<br>
&nbsp; &nbsp;Inherits CodeActivity<br>
<br>
&nbsp; &nbsp;Public Property playerInputNumber() As OutArgument(Of Integer)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return _playerInputNumber<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Get<br>
&nbsp; &nbsp; &nbsp; &nbsp;Set(ByVal value As OutArgument(Of Integer))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;_playerInputNumber = value<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Set<br>
&nbsp; &nbsp;End Property<br>
&nbsp; &nbsp;Private _playerInputNumber As OutArgument(Of Integer)<br>
<br>
<br>
&nbsp; &nbsp;Protected Overrides Sub Execute(ByVal context As System.Activities.CodeActivityContext)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;playerInputNumber.Set(context, Integer.Parse(Console.ReadLine()))<br>
<br>
&nbsp; &nbsp;End Sub<br>
End Class<br>
<br>
3. Delete the default created Workflow1.xaml file thenc reate a new Activity name
<br>
&nbsp; it GuessNumberGameInflowChart.xaml;author the workflow just like the one exsited
<br>
&nbsp; in the project. <br>
<br>
4. Open MainModule.vb file, change the code as follow:<br>
<br>
Imports System.Activities<br>
Imports System.Activities.Statements<br>
<br>
Module MainModule<br>
<br>
&nbsp; &nbsp;Dim s As Sequence<br>
<br>
&nbsp; &nbsp;Sub Main()<br>
&nbsp; &nbsp; &nbsp; &nbsp;WorkflowInvoker.Invoke(New GuessNumberGameInFlowChart())<br>
&nbsp; &nbsp;End Sub<br>
<br>
End Module<br>
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
