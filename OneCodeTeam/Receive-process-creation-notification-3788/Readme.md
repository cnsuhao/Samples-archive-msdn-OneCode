# Receive process creation notification (CSProcessWatcher)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* WMI
* Windows General
## Topics
* Process Events
## IsPublished
* True
## ModifiedDate
* 2011-07-12 10:24:44
## Description

<p style="font-family:Courier New"></p>
<h2>Console Application: CSProcessWatcher Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The project illustrates how to watch the process creation/modify/shutdown events<br>
by using the Windows Management Instrumentation(WMI).<br>
</p>
<h3>Demo: </h3>
<p style="font-family:Courier New"><br>
Please follow these demonstration steps below.<br>
<br>
Step 1. Run CSProcessWatcher.exe in a command prompt. The command<br>
&nbsp; &nbsp; &nbsp; &nbsp;'CSProcessWatcher.exe &lt;ProcessName&gt;' means CSProcessWatcher.exe will watch<br>
&nbsp; &nbsp; &nbsp; &nbsp;the events of the &lt;ProcessName&gt;. Here, the &lt;ProcessName&gt; is the name of the<br>
&nbsp; &nbsp; &nbsp; &nbsp;process which you want to watch. If you run CSProcessWatcher.exe directly<br>
&nbsp; &nbsp; &nbsp; &nbsp;without any command argument, the default &lt;ProcessName&gt; will be &quot;notepad.exe&quot;.<br>
<br>
Step 2. Launch the process which you want to watch. Observe the output information
<br>
&nbsp; &nbsp; &nbsp; &nbsp;from the CSProcesswatcher.exe. <br>
<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step 1. &nbsp;Create a Visual C# Console Application, name it &quot;CSProcessWatcher&quot;.<br>
<br>
Step 2. &nbsp;Right click the References, choose &quot;Add Reference ...&quot;, then select<br>
&nbsp; &nbsp; &nbsp; &nbsp; .NET reference &quot;System.Management&quot;, click &quot;OK&quot;.<br>
<br>
Step 3. Open the Visual studio 2010 command prompt, navigate to <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;your current project folder and enter the command: &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mgmtclassgen Win32_Process /n root\cimv2 /o WMI.Win32<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;You will get the Process.CS file. Add it into this project.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
Step 4. &nbsp;Add a new class 'ProcessWatcher'. Make it derive from <br>
&nbsp; &nbsp; &nbsp; &nbsp; System.Management.ManagementEventWatcher. Add three events for this class:<br>
&nbsp; &nbsp; &nbsp; &nbsp; ProcessCreated, ProcessDeleted, ProcessModified.<br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; In the constructor of class ProcessWatcher, we need to subscribe to temporary<br>
&nbsp; &nbsp; &nbsp; &nbsp; event notifications based on a specified event query.<br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp;private void Init(string processName)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Query.QueryLanguage = &quot;WQL&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Query.QueryString = string.Format(processEventQuery, processName);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.EventArrived &#43;= new EventArrivedEventHandler(watcher_EventArrived);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; Meanwhile, when we received an event notification, according to &nbsp;the event<br>
&nbsp; &nbsp; &nbsp; &nbsp; type, we should raise the corresponding event. <br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void watcher_EventArrived(object sender, EventArrivedEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string eventType = e.NewEvent.ClassPath.ClassName;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;WMI.Win32.Process proc = new WMI.Win32.Process(e.NewEvent[&quot;TargetInstance&quot;] as ManagementBaseObject);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;switch (eventType)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;case &quot;__InstanceCreationEvent&quot;:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (ProcessCreated != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ProcessCreated(proc);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;break;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;case &quot;__InstanceDeletionEvent&quot;:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (ProcessDeleted != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ProcessDeleted(proc);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;break;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;case &quot;__InstanceModificationEvent&quot;:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (ProcessModified != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ProcessModified(proc);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;break;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
WQL (SQL for WMI)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa394606(v=VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa394606(v=VS.85).aspx</a><br>
<br>
Win32_Process Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa394372(v=VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa394372(v=VS.85).aspx</a><br>
<br>
__InstanceOperationEvent Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa394652(v=VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa394652(v=VS.85).aspx</a><br>
<br>
Receiving a WMI Event<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa393013(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa393013(VS.85).aspx</a><br>
<br>
</p>
<h3></h3>
<p style="font-family:Courier New"><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
