# Track the system CPU usage (VBCpuUsage)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows General
## Topics
* CPU
* PerformanceCounter
## IsPublished
* True
## ModifiedDate
* 2011-07-12 10:03:16
## Description

<p style="font-family:Courier New"></p>
<h2>Windows Application: VBCpuUsage </h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
This sample demonstrates &nbsp;how to use &nbsp;PerformanceCounter to get the CPU Usage with<br>
following features<br>
1. The Total Processor Time.<br>
2. The Processor time of a specific process.<br>
3. Draw the CPU Usage History like Task Manager.<br>
</p>
<h3>Prerequisite</h3>
<p style="font-family:Courier New"><br>
Microsoft Chart Controls for Microsoft .NET Framework 3.5<br>
<a target="_blank" href="http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=14422">http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=14422</a><br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Step1. Open this project in Visual Studio 2008.<br>
<br>
Step2. Build the project and run VBCpuUsage.exe.<br>
<br>
Step3. Check &quot;Display total CPU Usage&quot; and &quot;Display the CPU Usage of a process&quot;. Click the
<br>
&nbsp; &nbsp; &nbsp; ComboBox and select a process (i.e. taskmgr, if Task Manager is running.) to monitor.<br>
<br>
&nbsp; &nbsp; &nbsp; You will see 2 charts on this application that display the CPU usage history.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
A. Design the CpuUsageMonitorBase class that supplies basic fields/events/functions/interfaces
<br>
&nbsp; of the monitors, such as Timer, PerformanceCounter and IDisposable interface.<br>
<br>
&nbsp; This is an abstract class, so CpuUsageMonitorBase class cannot be instantiated. When the<br>
&nbsp; child classes are instantiated, they have to pass the categoryName, counterName and instanceName<br>
&nbsp; to the constructor of CpuUsageMonitorBase class to initialize the performance counter.<br>
&nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; Me._cpuPerformanceCounter =<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;New PerformanceCounter(categoryName, counterName, instanceName)<br>
&nbsp; &nbsp;<br>
&nbsp; The timer is used to get the performance counter value every few seconds, and raise the
<br>
&nbsp; CpuUsageValueArrayChanged event. If there is any exception while reading the performance
<br>
&nbsp; counter value, the ErrorOccurred event will be raised. <br>
&nbsp; &nbsp; <br>
<br>
B. Design the TotalCpuUsageMonitor class that is used to monitor the total CPU usage. It inherits<br>
&nbsp; the CpuUsageMonitorBase class, and defines 3 constants:<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Const _categoryName As String = &quot;Processor&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Const _counterName As String = &quot;% Processor Time&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Const _instanceName As String = &quot;_Total&quot;<br>
<br>
&nbsp; To get the total CPU usage, we can use above constants to initialize a performance counter.<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Sub New(ByVal timerPeriod As Integer, ByVal valueArrayCapacity As Integer)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MyBase.New(timerPeriod, valueArrayCapacity, _categoryName,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; _counterName, _instanceName)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
C. Design the ProcessCpuUsageMonitor class that is used to monitor the CPU usage of a
<br>
&nbsp; specified process. It also inherits the CpuUsageMonitorBase class, and defines 2 constants:<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Const _categoryName As String = &quot;Process&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Const _counterName As String = &quot;% Processor Time&quot;<br>
&nbsp; <br>
&nbsp; To initialize a performance counter, we still need the instance name (a process name). So this
<br>
&nbsp; class also supplies a method to get available processes.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Shared _category As PerformanceCounterCategory<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Shared ReadOnly Property Category() As PerformanceCounterCategory<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If _category Is Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;_category = New PerformanceCounterCategory(_categoryName)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return _category<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Get<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Property<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Shared Function GetAvailableProcesses() As String()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return Category.GetInstanceNames().OrderBy(Function(name) name).ToArray()<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Function<br>
<br>
<br>
D. Design the MainForm that initializes the totalCpuUsageMonitor and processCpuUsageMonitor,<br>
&nbsp; registers the CpuUsageValueArrayChanged and display the CPU usage history in the charts.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Invoke the processCpuUsageMonitor_CpuUsageValueArrayChangedHandler to handle<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' the CpuUsageValueArrayChanged event of processCpuUsageMonitor.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub processCpuUsageMonitor_CpuUsageValueArrayChanged(ByVal sender As Object,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ByVal e As CpuUsageValueArrayChangedEventArg)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.Invoke(New EventHandler(Of CpuUsageValueArrayChangedEventArg)(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddressOf processCpuUsageMonitor_CpuUsageValueArrayChangedHandler), sender, e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub processCpuUsageMonitor_CpuUsageValueArrayChangedHandler(ByVal sender As Object,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
 &nbsp;ByVal e As CpuUsageValueArrayChangedEventArg)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim processCpuUsageSeries = chartProcessCupUsage.Series(&quot;ProcessCpuUsageSeries&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim values = e.Values<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Display the process CPU usage in the chart.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;processCpuUsageSeries.Points.DataBindY(e.Values)<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Invoke the totalCpuUsageMonitor_CpuUsageValueArrayChangedHandler to handle<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' the CpuUsageValueArrayChanged event of processCpuUsageMonitor.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub totalCpuUsageMonitor_CpuUsageValueArrayChanged(ByVal sender As Object,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ByVal e As CpuUsageValueArrayChangedEventArg)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.Invoke(New EventHandler(Of CpuUsageValueArrayChangedEventArg)(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddressOf totalCpuUsageMonitor_CpuUsageValueArrayChangedHandler), sender, e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub totalCpuUsageMonitor_CpuUsageValueArrayChangedHandler(ByVal sender As Object,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ByVal
 e As CpuUsageValueArrayChangedEventArg)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim totalCpuUsageSeries = chartTotalCpuUsage.Series(&quot;TotalCpuUsageSeries&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim values = e.Values<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Display the total CPU usage in the chart.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;totalCpuUsageSeries.Points.DataBindY(e.Values)<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp;If there is any error while reading the performance counter value, the UI will also handle<br>
&nbsp;this event. <br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Invoke the processCpuUsageMonitor_ErrorOccurredHandler to handle<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' the ErrorOccurred event of processCpuUsageMonitor.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub processCpuUsageMonitor_ErrorOccurred(ByVal sender As Object,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ByVal e As ErrorEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.Invoke(New EventHandler(Of ErrorEventArgs)(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddressOf processCpuUsageMonitor_ErrorOccurredHandler), sender, e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub processCpuUsageMonitor_ErrorOccurredHandler(ByVal sender As Object,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ByVal e As ErrorEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If _processCpuUsageMonitor IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;_processCpuUsageMonitor.Dispose()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;_processCpuUsageMonitor = Nothing<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim processCpuUsageSeries = chartProcessCupUsage.Series(&quot;ProcessCpuUsageSeries&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;processCpuUsageSeries.Points.Clear()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MessageBox.Show(e.Error.Message)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; ''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Invoke the totalCpuUsageMonitor_ErrorOccurredHandler to handle<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' the ErrorOccurred event of totalCpuUsageMonitor.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub totalCpuUsageMonitor_ErrorOccurred(ByVal sender As Object,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ByVal e As ErrorEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.Invoke(New EventHandler(Of ErrorEventArgs)(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddressOf totalCpuUsageMonitor_ErrorOccurredHandler), sender, e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub totalCpuUsageMonitor_ErrorOccurredHandler(ByVal sender As Object,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ByVal e As ErrorEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If _totalCpuUsageMonitor IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;_totalCpuUsageMonitor.Dispose()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;_totalCpuUsageMonitor = Nothing<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim totalCpuUsageSeries = chartTotalCpuUsage.Series(&quot;TotalCpuUsageSeries&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;totalCpuUsageSeries.Points.Clear()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MessageBox.Show(e.Error.Message)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
PerformanceCounter Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.diagnostics.performancecounter.aspx">http://msdn.microsoft.com/en-us/library/system.diagnostics.performancecounter.aspx</a><br>
<br>
Chart Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.windows.forms.datavisualization.charting.chart.aspx">http://msdn.microsoft.com/en-us/library/system.windows.forms.datavisualization.charting.chart.aspx</a><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
