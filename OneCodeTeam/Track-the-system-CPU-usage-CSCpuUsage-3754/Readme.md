# Track the system CPU usage (CSCpuUsage)
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
* 2011-07-12 09:47:33
## Description

<p style="font-family:Courier New"></p>
<h2>Windows Application: CSCpuUsage </h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
This sample demonstrates how to use PerformanceCounter to get the CPU Usage with<br>
following features<br>
1. The Total Processor Time.<br>
2. The Processor time of a specific process.<br>
3. Draw the CPU Usage History like Task Manager.<br>
</p>
<h3>Prerequisite</h3>
<p style="font-family:Courier New"><br>
Microsoft Chart Controls for Microsoft .NET Framework 3.5<br>
<a target="_blank" href="http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=14422">http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=14422</a><br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Step1. Open this project in Visual Studio 2008.<br>
<br>
Step2. Build the project and run CSCpuUsage.exe.<br>
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
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; this.cpuPerformanceCounter =<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;new PerformanceCounter(categoryName, counterName, instanceName);<br>
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
&nbsp; &nbsp; &nbsp; &nbsp;const string categoryName = &quot;Processor&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp;const string counterName = &quot;% Processor Time&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp;const string instanceName = &quot;_Total&quot;;<br>
<br>
&nbsp; To get the total CPU usage, we can use above constants to initialize a performance counter.<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public TotalCpuUsageMonitor(int timerPeriod, int valueArrayCapacity)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;: base(timerPeriod, valueArrayCapacity, categoryName, counterName, instanceName)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{ }<br>
<br>
C. Design the ProcessCpuUsageMonitor class that is used to monitor the CPU usage of a
<br>
&nbsp; specified process. It also inherits the CpuUsageMonitorBase class, and defines 2 constants:<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;const string categoryName = &quot;Process&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp;const string counterName = &quot;% Processor Time&quot;;<br>
&nbsp; <br>
&nbsp; To initialize a performance counter, we still need the instance name (a process name). So this
<br>
&nbsp; class also supplies a method to get available processes.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;static PerformanceCounterCategory category;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public static PerformanceCounterCategory Category<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (category == null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;category = new PerformanceCounterCategory(categoryName);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return category;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public static string[] GetAvailableProcesses()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{ &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return Category.GetInstanceNames().OrderBy(name =&gt; name).ToArray();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
<br>
<br>
D. Design the MainForm that initializes the totalCpuUsageMonitor and processCpuUsageMonitor,<br>
&nbsp; registers the CpuUsageValueArrayChanged and display the CPU usage history in the charts.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Invoke the processCpuUsageMonitor_CpuUsageValueArrayChangedHandler to handle<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// the CpuUsageValueArrayChanged event of processCpuUsageMonitor.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;void processCpuUsageMonitor_CpuUsageValueArrayChanged(object sender,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CpuUsageValueArrayChangedEventArg e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Invoke(new EventHandler&lt;CpuUsageValueArrayChangedEventArg&gt;(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;processCpuUsageMonitor_CpuUsageValueArrayChangedHandler), sender, e);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;void processCpuUsageMonitor_CpuUsageValueArrayChangedHandler(object sender,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CpuUsageValueArrayChangedEventArg e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var processCpuUsageSeries = chartProcessCupUsage.Series[&quot;ProcessCpuUsageSeries&quot;];<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var values = e.Values;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Display the process CPU usage in the chart.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;processCpuUsageSeries.Points.DataBindY(e.Values);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Invoke the totalCpuUsageMonitor_CpuUsageValueArrayChangedHandler to handle<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// the CpuUsageValueArrayChanged event of totalCpuUsageMonitor.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;void totalCpuUsageMonitor_CpuUsageValueArrayChanged(object sender,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CpuUsageValueArrayChangedEventArg e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Invoke(new EventHandler&lt;CpuUsageValueArrayChangedEventArg&gt;(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;totalCpuUsageMonitor_CpuUsageValueArrayChangedHandler), sender, e);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;void totalCpuUsageMonitor_CpuUsageValueArrayChangedHandler(object sender,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CpuUsageValueArrayChangedEventArg e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var totalCpuUsageSeries = chartTotalCpuUsage.Series[&quot;TotalCpuUsageSeries&quot;];<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var values = e.Values;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Display the total CPU usage in the chart.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;totalCpuUsageSeries.Points.DataBindY(e.Values);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp;If there is any error while reading the performance counter value, the UI will also handle<br>
&nbsp;this event. <br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Invoke the processCpuUsageMonitor_ErrorOccurredHandler to handle<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// the ErrorOccurred event of processCpuUsageMonitor.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;void processCpuUsageMonitor_ErrorOccurred(object sender, ErrorEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Invoke(new EventHandler&lt;ErrorEventArgs&gt;(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;processCpuUsageMonitor_ErrorOccurredHandler), sender, e);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;void processCpuUsageMonitor_ErrorOccurredHandler(object sender, ErrorEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (processCpuUsageMonitor != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;processCpuUsageMonitor.Dispose();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;processCpuUsageMonitor = null;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var processCpuUsageSeries = chartProcessCupUsage.Series[&quot;ProcessCpuUsageSeries&quot;];<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;processCpuUsageSeries.Points.Clear();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MessageBox.Show(e.Error.Message);<br>
&nbsp; &nbsp; &nbsp; &nbsp;} &nbsp; &nbsp; &nbsp; <br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Invoke the totalCpuUsageMonitor_ErrorOccurredHandler to handle<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// the ErrorOccurred event of totalCpuUsageMonitor.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;void totalCpuUsageMonitor_ErrorOccurred(object sender, ErrorEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Invoke(new EventHandler&lt;ErrorEventArgs&gt;(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;totalCpuUsageMonitor_ErrorOccurredHandler),sender,e);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;void totalCpuUsageMonitor_ErrorOccurredHandler(object sender, ErrorEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (totalCpuUsageMonitor != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;totalCpuUsageMonitor.Dispose();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;totalCpuUsageMonitor = null;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MessageBox.Show(e.Error.Message);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
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
