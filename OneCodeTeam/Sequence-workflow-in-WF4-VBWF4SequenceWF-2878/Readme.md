# Sequence workflow in WF4 (VBWF4SequenceWF)
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
* 2011-05-05 10:05:48
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : VBWF4SequenceWF</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
This sample demonstrates the usage of WF4 Sequence workflow in a Guess Number<br>
Game workflow. this sample will also involve the usage of Variable, IFElse <br>
Activity, DoWhile Activity and Customized Activity. <br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
1. Open VBWF4SequenceWF.sln with Visual Studio 2010<br>
2. Press Ctrl&#43;F5.<br>
<br>
</p>
<h3>Prerequisite</h3>
<p style="font-family:Courier New"><br>
1. Visual Studio 2010<br>
2. .NET Framework 4.0<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
1.Create A Workflow Console Application, name it VBWF4SequenceWF;<br>
2.Create a CodeActivity name it ReadNumberActivity.vb, fill the file with code:<br>
<br>
Imports System.Activities<br>
<br>
Namespace VBWF4SequenceWF<br>
<br>
&nbsp; &nbsp;Public NotInheritable Class ReadNumberActivity<br>
&nbsp; &nbsp; &nbsp; &nbsp;Inherits CodeActivity<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;' Define an activity out argument of type int<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Property playerInputNumber() As OutArgument(Of Int32)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return _playerInputNumber<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Set(ByVal value As OutArgument(Of Integer))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;_playerInputNumber = value<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Set<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Property<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private _playerInputNumber As OutArgument(Of Integer)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Protected Overrides Sub Execute(ByVal context As CodeActivityContext)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;playerInputNumber.Set(context, Int32.Parse(Console.ReadLine()))<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp;End Class<br>
<br>
End Namespace<br>
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
