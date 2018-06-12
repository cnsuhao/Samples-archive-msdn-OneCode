# Create custom composite activity in WF4 (VBWF4CustomSequenceActivity)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* WF
## Topics
* Sequence Activity
## IsPublished
* True
## ModifiedDate
* 2011-05-05 10:04:38
## Description

<p style="font-family:Courier New"></p>
<h2>WPF/WF4 APPLICATION : VBWF4CustomeSequenceActivity</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
Generally, we use the built in Sequence activity to build a sequence workflow.<br>
Sequence activity is a composite activity. in this sample I demonstrated<br>
creating an customized composite activity: MySequenceActivity. and also <br>
its activity designer so that you can use it in a workflow designer. If you <br>
are going to create your own WF4 activity, you can use this sample as a<br>
reference. <br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
1. Open VBWF4CustomSequenceActivity.sln with Visual Studio 2010<br>
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
1. Create a Workflow Console Application base on .NET Framework 4.0.<br>
<br>
2. Add a new Activity Designer to the project by following actions:<br>
&nbsp; a. Right click the project name and select Add|New Item...<br>
&nbsp; b. Click Workflow|Activity Designer. then name the file MySequenceDesigner.xaml<br>
<br>
3. Open file MySequenceDesigner.xaml.cs and alter its code to:<br>
&lt;sap:ActivityDesigner x:Class=&quot;MySequenceDesigner&quot;<br>
&nbsp; &nbsp;xmlns=&quot;<a target="_blank" href="http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;">http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</a><br>
&nbsp; &nbsp;xmlns:x=&quot;<a target="_blank" href="http://schemas.microsoft.com/winfx/2006/xaml&quot;">http://schemas.microsoft.com/winfx/2006/xaml&quot;</a><br>
&nbsp; &nbsp;xmlns:sap=&quot;clr-namespace:System.Activities.Presentation;assembly=System.Activities.Presentation&quot;<br>
&nbsp; &nbsp;xmlns:sapv=&quot;clr-namespace:System.Activities.Presentation.View;assembly=System.Activities.Presentation&quot;&gt;<br>
&nbsp; &nbsp;&lt;Grid&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;StackPanel&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;sap:WorkflowItemsPresenter HintText=&quot;Drop Activities Here&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Items=&quot;{Binding Path=ModelItem.Branches,Mode=TwoWay}&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;sap:WorkflowItemsPresenter.SpacerTemplate&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;DataTemplate&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Path Margin=&quot;0,15,0,0&quot; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
 &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Stretch=&quot;Fill&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;StrokeMiterLimit=&quot;2.75&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Stroke=&quot;#FFA8B3C2&quot; Fill=&quot;#FFFFFFFF&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Data=&quot;F1 M 675.738,744.979L 665.7,758.492L 655.66,744.979L 675.738,744.979 Z &quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Width=&quot;16&quot; Height=&quot;10&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/DataTemplate&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/sap:WorkflowItemsPresenter.SpacerTemplate&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;sap:WorkflowItemsPresenter.ItemsPanel&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;ItemsPanelTemplate&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;StackPanel Orientation=&quot;Vertical&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/ItemsPanelTemplate&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/sap:WorkflowItemsPresenter.ItemsPanel&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/sap:WorkflowItemsPresenter&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/StackPanel&gt;<br>
&nbsp; &nbsp;&lt;/Grid&gt;<br>
&lt;/sap:ActivityDesigner&gt;<br>
Then, save and build the project.<br>
<br>
4. Add a new code file named MySequenceActivity.vb, fill the file with the <br>
&nbsp; following code:<br>
Imports System.ComponentModel<br>
Imports System.Activities<br>
Imports System.Collections.ObjectModel<br>
<br>
&lt;Designer(GetType(MySequenceDesigner))&gt;<br>
Public Class MySequenceActivity<br>
&nbsp; &nbsp;Inherits NativeActivity<br>
<br>
&nbsp; &nbsp;Public Property Branches() As Collection(Of Activity)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return _Branches<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Get<br>
&nbsp; &nbsp; &nbsp; &nbsp;Set(ByVal value As Collection(Of Activity))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;_Branches = value<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Set<br>
&nbsp; &nbsp;End Property<br>
&nbsp; &nbsp;Private _Branches As Collection(Of Activity)<br>
<br>
&nbsp; &nbsp;Public Property Variables() As Collection(Of Variable)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return _Variables<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Get<br>
&nbsp; &nbsp; &nbsp; &nbsp;Set(ByVal value As Collection(Of Variable))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;_Variables = value<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Set<br>
&nbsp; &nbsp;End Property<br>
&nbsp; &nbsp;Private _Variables As Collection(Of Variable)<br>
<br>
&nbsp; &nbsp;Public Sub New()<br>
&nbsp; &nbsp; &nbsp; &nbsp;Branches = New Collection(Of Activity)()<br>
&nbsp; &nbsp; &nbsp; &nbsp;Variables = New Collection(Of Variable)()<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;Dim activityCounter As Integer<br>
<br>
&nbsp; &nbsp;Protected Overrides Sub CacheMetadata(ByVal metadata As System.Activities.NativeActivityMetadata)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;metadata.SetChildrenCollection(Branches)<br>
&nbsp; &nbsp; &nbsp; &nbsp;metadata.SetVariablesCollection(Variables)<br>
<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;Protected Overrides Sub Execute(ByVal context As System.Activities.NativeActivityContext)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;ScheduleActivities(context)<br>
<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;Protected Sub ScheduleActivities(ByVal context As NativeActivityContext)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;If activityCounter &lt; Branches.Count Then<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;context.ScheduleActivity(Me.Branches(activityCounter), AddressOf OnActivityCompleted)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;activityCounter = activityCounter &#43; 1<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;Protected Sub OnActivityCompleted(ByVal context As NativeActivityContext, ByVal completedInstance As ActivityInstance)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;ScheduleActivities(context)<br>
<br>
&nbsp; &nbsp;End Sub<br>
<br>
End Class<br>
Then, save and build the project. <br>
<br>
5. Open the default created Workflow1.xaml and drag the MySequenceActivity<br>
&nbsp; from the toolbox panel to the workflow designer. and create a simple<br>
&nbsp; workflow to test it.<br>
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
