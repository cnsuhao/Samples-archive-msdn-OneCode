# Programmatically create minidump for unhandled exception (VBCreateMiniDump)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Windows General
## Topics
* minidump
* MiniDumpWriteDump
## IsPublished
* False
## ModifiedDate
* 2011-05-26 02:13:05
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : VBCreateMiniDump Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The code sample demonstrates how to programmatically create a minidump when a <br>
.NET application has an unhandled exception and is about to crash.<br>
<br>
When an application runs, it will launch a Watchdog process that can debug the application<br>
and subscribe the OnException event of the application. If there is an unhandled exception,<br>
the Watchdog process will create a minidump for the application.<br>
<br>
The reason why we need a watch dog process is that MiniDumpWriteDump should be called
<br>
from a separate process if at all possible, rather than from within the target process<br>
being dumped. This is especially true when the target process is already not stable.
<br>
For example, if it just crashed. A loader deadlock is one of many potential side effects
<br>
of calling MiniDumpWriteDump from within the target process. For more detailed information,
<br>
see <a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms680360(VS.85).aspx.">
http://msdn.microsoft.com/en-us/library/ms680360(VS.85).aspx.</a><br>
<br>
NOTE: <br>
1. This sample works for managed processes only, because it uses MDbg to debug the target<br>
&nbsp; process.<br>
2. The watch dog process must be built with the same platform as the main application.
<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Step 1. Build this solution in Visual Studio 2010, and you will get VBApplicationToCrash.exe<br>
&nbsp; &nbsp; &nbsp; &nbsp;and VBCreateMiniDump.exe in the output folder.<br>
<br>
Step 2. Run the application VBApplicationToCrash.exe. It will launch a Watchdog process<br>
&nbsp; &nbsp; &nbsp; &nbsp;VBCreateMiniDump.exe, and then show following message:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&quot;Press ENTER to throw an unhandled exception...&quot;<br>
<br>
Step 3. Press &lt;Enter&gt; in the VBApplicationToCrash, and then you will get following
<br>
&nbsp; &nbsp; &nbsp; &nbsp;notification in the VBCreateMiniDump.exe:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Start to handle exception...<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Getting exception information...<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Creating Minidump...<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; The minidump file is &nbsp;&lt;dump file path&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Done...<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Press ENTER to continue...<br>
<br>
Step 4. Press &lt;Enter&gt; in the VBCreateMiniDump.exe and VBApplicationToCrash.exe. Both
<br>
&nbsp; &nbsp; &nbsp; &nbsp;VBApplicationToCrash.exe and VBCreateMiniDump.exe will shut down, and then you
<br>
&nbsp; &nbsp; &nbsp; &nbsp;will get a minidump named VBApplicationToCrash_&lt;TimeStamp&gt;.dmp in the same folder<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;as VBApplicationToCrash.exe. <br>
<br>
Step 5. Open the .dmp file in VS2010, and debug with Mixed. Then you can get the call stack<br>
&nbsp; &nbsp; &nbsp; &nbsp;and other information when the minidump was created.<br>
</p>
<h3>Code logic</h3>
<p style="font-family:Courier New"><br>
1. Create an application VBApplicationToCrash.exe that could crash itself. When it runs, it<br>
&nbsp; will launch a Watchdog process VBCreateMiniDump.exe.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Sub Main()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim demoProcess As Process = Process.GetCurrentProcess()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Console.WriteLine(&quot;The ID of this Demo Process is &quot; & demoProcess.Id)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;LaunchWatchdog(demoProcess)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;For i As Integer = 1 To 10<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Console.WriteLine(i)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;System.Threading.Thread.Sleep(1000)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Next i<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Rethrow the exception, will cause an unhandled exception.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim zero As Integer = 0<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Console.WriteLine(1 \ zero)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Catch<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Throw<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
<br>
2. Create VBCreateMiniDump.exe that could create minidump.<br>
<br>
&nbsp; 2.1 Wrap the MiniDumpWriteDump function in the dbghelp.dll, and design MiniDumpCreator<br>
&nbsp; &nbsp; &nbsp; class that could create a minidump for a given process.<br>
&nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;DllImport(&quot;dbghelp.dll&quot;, CharSet:=CharSet.Auto, SetLastError:=True)&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Public Shared Function MiniDumpWriteDump(ByVal hProcess As IntPtr,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ByVal processId As Integer,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ByVal hFile As SafeFileHandle,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ByVal dumpType As MINIDUMP_TYPE,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ByVal exceptionParam As IntPtr,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ByVal userStreamParam As IntPtr,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ByVal callbackParam As IntPtr) As Boolean<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End Function<br>
&nbsp; <br>
&nbsp; 2.2 Design ManagedProcess class that represents a managed process. It could attach<br>
&nbsp; &nbsp; &nbsp; a debugger to the managed process and subscribe the PostDebugEvent event of the process.<br>
&nbsp; <br>
&nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Private Sub AttachDebuggerToProcess()<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Dim version As String = MdbgVersionPolicy.GetDefaultAttachVersion(Me.DiagnosticsProcess.Id)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; If String.IsNullOrEmpty(version) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Throw New ApplicationException(&quot;Can't determine what version of the CLR to &quot; _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; & &quot;attach to the process.&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Me.MdbgProcess = Me.Debugger.Attach(Me.DiagnosticsProcess.Id, Nothing, version)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Dim result As Boolean = Me.MdbgProcess.Go.WaitOne()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; If Not result Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Throw New ApplicationException(String.Format(&quot;The process with an ID {0} could not be &quot; _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;& &quot;attached. Operation
 time out.&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.DiagnosticsProcess.Id))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; AddHandler MdbgProcess.PostDebugEvent, AddressOf MDbgProcess_PostDebugEvent<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End Sub<br>
&nbsp; <br>
&nbsp; &nbsp; &nbsp; And then start to watch the target process. If the target application stops with an unhandled<br>
&nbsp; &nbsp; &nbsp; exception, raise an UnhandledExceptionOccurred event.<br>
&nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Public Sub StartWatch()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Do<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Dim result As Boolean = Me.MdbgProcess.Go.WaitOne<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; If Me._stopReason = ManagedCallbackType.OnException _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; AndAlso Me._isExceptionUnhandled Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Me.HandleException()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Exit Do<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ElseIf Me._stopReason = ManagedCallbackType.OnProcessExit Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Exit Do<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Loop<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Private Sub HandleException()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Dim ex As MDbgValue = Me.MdbgProcess.Threads.Active.CurrentException<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; If ex.IsNull Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ' No current exception is available. &nbsp;Perhaps the user switched to a different<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ' thread which was not throwing an exception.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Return<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Console.WriteLine(&quot;Exception=&quot; & ex.GetStringValue(0))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Dim exceptionPointers As IntPtr = IntPtr.Zero<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; For Each f As MDbgValue In ex.GetFields()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; If f.Name = &quot;_xptrs&quot; Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Dim outputValue As String = f.GetStringValue(0)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; exceptionPointers = CType(Integer.Parse(outputValue), IntPtr)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Next f<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; If exceptionPointers = IntPtr.Zero Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ' Get the Exception Pointer in the target process<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Dim value As MDbgValue = FunctionEval(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot;System.Runtime.InteropServices.Marshal.GetExceptionPointers&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; If value IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; exceptionPointers = CType(Integer.Parse(value.GetStringValue(1)), IntPtr)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Me.OnUnhandledExceptionOccurred(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; New ManagedProcessUnhandledExceptionOccurredEventArgs With _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {.ProcessID = Me.MdbgProcess.CorProcess.Id,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;.ThreadID = Me.MdbgProcess.Threads.Active.Id,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;.ExceptionPointers = exceptionPointers})<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; <br>
&nbsp; 2.3 When VBCreateMiniDump.exe is launched, attach the debugger to VBApplicationToCrash.exe, and
<br>
&nbsp; &nbsp; &nbsp; create a minidump for the application VBApplicationToCrash.exe if it encounters an unhandled<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; exception.<br>
&nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Private Sub process_UnhandledExceptionOccurred(ByVal sender As Object,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ByVal e As ManagedProcessUnhandledExceptionOccurredEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Console.WriteLine(&quot;Creating Minidump...&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MiniDump.MiniDumpCreator.CreateMiniDump(e.ProcessID, e.ThreadID, e.ExceptionPointers)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Console.WriteLine(&quot;Done...&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End Sub<br>
<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MINIDUMP_CALLBACK_INPUT Structure:<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms680362(v=VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms680362(v=VS.85).aspx</a><br>
<br>
<br>
MINIDUMP_CALLBACK_TYPE Enumeration:<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms680364(v=VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms680364(v=VS.85).aspx</a><br>
<br>
MINIDUMP_CALLBACK_OUTPUT Structure:<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms680363(v=VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms680363(v=VS.85).aspx</a><br>
<br>
Effective MiniDumps:<br>
<a target="_blank" href="http://www.debuginfo.com/articles/effminidumps.html">http://www.debuginfo.com/articles/effminidumps.html</a><br>
<br>
MSDN try-except statement:<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/s58ftw19(VS.80).aspx">http://msdn.microsoft.com/en-us/library/s58ftw19(VS.80).aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
