# Receive process creation notification (VBProcessWatcher)
## Requires
* Visual Studio 2008
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
* 2011-05-05 08:03:48
## Description

<p style="font-family:Courier New"></p>
<h2>Console Application: VBProcessWatcher Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The project illustrates how to watch the process creation/modify/shutdown events<br>
by using the Windows Management Instrumentation(WMI).<br>
</p>
<h3>Demo: </h3>
<p style="font-family:Courier New"><br>
Please follow these demonstration steps below.<br>
<br>
Step 1. Run VBProcessWatcher.exe in a command prompt. The command<br>
&nbsp; &nbsp; &nbsp; &nbsp;'VBProcessWatcher.exe &lt;ProcessName&gt;' means VBProcessWatcher.exe will watch<br>
&nbsp; &nbsp; &nbsp; &nbsp;the events of the &lt;ProcessName&gt;. Here, the &lt;ProcessName&gt; is the name of the<br>
&nbsp; &nbsp; &nbsp; &nbsp;process which you want to watch. If you run VBProcessWatcher.exe directly<br>
&nbsp; &nbsp; &nbsp; &nbsp;without any command argument, the default &lt;ProcessName&gt; will be &quot;notepad.exe&quot;.<br>
<br>
Step 2. Launch the process which you want to watch. Observe the output information
<br>
&nbsp; &nbsp; &nbsp; &nbsp;from the VBProcesswatcher.exe. <br>
<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step 1. &nbsp;Create a Visual Basic Console Application, name it &quot;VBProcessWatcher&quot;.<br>
<br>
Step 2. &nbsp;Right click the Project name, choose &quot;Add Reference ...&quot;, then select<br>
&nbsp; &nbsp; &nbsp; &nbsp; .NET reference &quot;System.Management&quot;, click &quot;OK&quot;.<br>
<br>
Step 3. Open the Visual studio 2008 command prompt, navigate to <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;your current project folder and enter the command: &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mgmtclassgen Win32_Process /n root\cimv2 /o WMI.Win32 /l VB<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;You will get the Process.VB file. Add it into this project.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
Step 4. &nbsp;Add a new class 'ProcessWatcher'. Make it derive from <br>
&nbsp; &nbsp; &nbsp; &nbsp; System.Management.ManagementEventWatcher. Add three events for this class:<br>
&nbsp; &nbsp; &nbsp; &nbsp; ProcessCreated, ProcessDeleted, ProcessModified.<br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; In the constructor of class ProcessWatcher, we need to subscribe to temporary<br>
&nbsp; &nbsp; &nbsp; &nbsp; event notifications based on a specified event query.<br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; Private Sub Init(ByVal processName As String)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Me.Query.QueryLanguage = &quot;WQL&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Me.Query.QueryString = String.Format(WMI_OPER_EVENT_QUERY, processName)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; AddHandler Me.EventArrived, AddressOf Me.watcher_EventArrived<br>
&nbsp; &nbsp; &nbsp; &nbsp; End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; Meanwhile, when we received an event notification, according to &nbsp;the event<br>
&nbsp; &nbsp; &nbsp; &nbsp; type, we should raise the corresponding event. <br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; Private Sub watcher_EventArrived(ByVal sender As Object, ByVal e As EventArrivedEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim eventType As String = e.NewEvent.ClassPath.ClassName<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim proc As New Win32.Process(TryCast(e.NewEvent(&quot;TargetInstance&quot;), ManagementBaseObject))<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Select Case eventType<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Case &quot;__InstanceCreationEvent&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RaiseEvent ProcessCreated(proc)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Exit Select<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Case &quot;__InstanceDeletionEvent&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RaiseEvent ProcessDeleted(proc)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Exit Select<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Case &quot;__InstanceModificationEvent&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RaiseEvent ProcessModified(proc)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Exit Select<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Select<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;</p>
<h3></h3>
<p style="font-family:Courier New">References:<br>
<br>
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
</p>
<h3></h3>
<p style="font-family:Courier New"><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
