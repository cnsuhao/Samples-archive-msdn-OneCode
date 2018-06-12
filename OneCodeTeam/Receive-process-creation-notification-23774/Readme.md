# Receive process creation notification
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* WMI
* System Administration
* Windows Desktop App Development
## Topics
* process
## IsPublished
* True
## ModifiedDate
* 2013-07-08 09:23:12
## Description

<h1>Receive process creation notification (VBProcessWatcher)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The project illustrates how to watch the process creation/modify/shutdown events by using the Windows Management Instrumentation (WMI).</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Please follow these demonstration steps below.</p>
<p class="MsoNormal">Step1. Run VBProcessWatcher.exe in a command prompt. The command 'VBProcessWatcher.exe &lt;ProcessName&gt;' means VBProcessWatcher.exe will watch the events of the &lt;ProcessName&gt;. Here, the &lt;ProcessName&gt; is the name of the
 process which you want to watch. If you run VBProcessWatcher.exe directly without any command argument, the default &lt;ProcessName&gt; will be &quot;notepad.exe&quot;.</p>
<p class="MsoNormal">Step2. Launch the process which you want to watch. Observe the output information from the VBProcesswatcher.exe.
</p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step1.<span style="">&nbsp; </span>Create a Visual C# Console Application, name it &quot;VBProcessWatcher&quot;.</p>
<p class="MsoNormal">Step2.<span style="">&nbsp; </span>Right click the References, choose &quot;Add Reference ...&quot;, then select .NET reference &quot;System.Management&quot;, click &quot;OK&quot;.</p>
<p class="MsoNormal">Step3. Open the Visual studio command prompt, navigate to your current project folder and enter the command: mgmtclassgen Win32_Process /n root\cimv2 /o WMI.Win32. You will get the Process.vb file. Add it into this project.<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal">Step4.<span style="">&nbsp; </span>Add a new class 'ProcessWatcher'. Make it derives from System.Management.ManagementEventWatcher. Add three events for this class: ProcessCreated, ProcessDeleted, ProcessModified.
</p>
<p class="MsoNormal">In the constructor of class ProcessWatcher, we need to subscribe to temporary event notifications based on a specified event query.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub Init(ByVal processName As String)
          Me.Query.QueryLanguage = &quot;WQL&quot;
          Me.Query.QueryString = String.Format(WMI_OPER_EVENT_QUERY, processName)
          AddHandler Me.EventArrived, AddressOf Me.watcher_EventArrived
      End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub Init(ByVal processName As String)
          Me.Query.QueryLanguage = &quot;WQL&quot;
          Me.Query.QueryString = String.Format(WMI_OPER_EVENT_QUERY, processName)
          AddHandler Me.EventArrived, AddressOf Me.watcher_EventArrived
      End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;Meanwhile, when we received an event notification, according to the event type, we should raise the corresponding event.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub watcher_EventArrived(ByVal sender As Object, ByVal e As EventArrivedEventArgs)


            Dim eventType As String = e.NewEvent.ClassPath.ClassName
            Dim proc As New Win32.Process(TryCast(e.NewEvent(&quot;TargetInstance&quot;), ManagementBaseObject))


            Select Case eventType
                Case &quot;__InstanceCreationEvent&quot;
                    RaiseEvent ProcessCreated(proc)
                    Exit Select


                Case &quot;__InstanceDeletionEvent&quot;
                    RaiseEvent ProcessDeleted(proc)
                    Exit Select


                Case &quot;__InstanceModificationEvent&quot;
                    RaiseEvent ProcessModified(proc)
                    Exit Select
            End Select
        End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub watcher_EventArrived(ByVal sender As Object, ByVal e As EventArrivedEventArgs)


            Dim eventType As String = e.NewEvent.ClassPath.ClassName
            Dim proc As New Win32.Process(TryCast(e.NewEvent(&quot;TargetInstance&quot;), ManagementBaseObject))


            Select Case eventType
                Case &quot;__InstanceCreationEvent&quot;
                    RaiseEvent ProcessCreated(proc)
                    Exit Select


                Case &quot;__InstanceDeletionEvent&quot;
                    RaiseEvent ProcessDeleted(proc)
                    Exit Select


                Case &quot;__InstanceModificationEvent&quot;
                    RaiseEvent ProcessModified(proc)
                    Exit Select
            End Select
        End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal">WQL (SQL for WMI)</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/aa394606(v=VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa394606(v=VS.85).aspx</a>
</p>
<p class="MsoNormal">Win32_Process Class</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/aa394372(v=VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa394372(v=VS.85).aspx</a>
</p>
<p class="MsoNormal">__InstanceOperationEvent Class</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/aa394652(v=VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa394652(v=VS.85).aspx</a>
</p>
<p class="MsoNormal">Receiving a WMI Event</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/aa393013(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa393013(VS.85).aspx</a>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
