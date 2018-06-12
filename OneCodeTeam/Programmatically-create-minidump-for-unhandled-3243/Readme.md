# Programmatically create minidump for unhandled exception (CSCreateMiniDump)
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
* 2011-05-26 02:05:38
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CSCreateMiniDump Project Overview</h2>
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
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Step 1. Build this solution in Visual Studio 2010, and you will get CSApplicationToCrash.exe<br>
&nbsp; &nbsp; &nbsp; &nbsp;and CSCreateMiniDump.exe in the output folder.<br>
<br>
Step 2. Run the application CSApplicationToCrash.exe. It will launch a Watchdog process<br>
&nbsp; &nbsp; &nbsp; &nbsp;CSCreateMiniDump.exe, and then show following message:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&quot;Press ENTER to throw an unhandled exception...&quot;<br>
<br>
Step 3. Press &lt;Enter&gt; in the CSApplicationToCrash, and then you will get following
<br>
&nbsp; &nbsp; &nbsp; &nbsp;notification in the CSCreateMiniDump.exe:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Start to handle exception...<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Getting exception information...<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Creating Minidump...<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; The minidump file is &nbsp;&lt;dump file path&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Done...<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Press ENTER to continue...<br>
<br>
Step 4. Press &lt;Enter&gt; in the CSCreateMiniDump.exe and CSApplicationToCrash.exe. Both
<br>
&nbsp; &nbsp; &nbsp; &nbsp;CSApplicationToCrash.exe and CSCreateMiniDump.exe will shut down, and then you
<br>
&nbsp; &nbsp; &nbsp; &nbsp;will get a minidump named CSApplicationToCrash_&lt;TimeStamp&gt;.dmp in the same folder<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;as CSApplicationToCrash.exe. <br>
<br>
Step 5. Open the .dmp file in VS2010, and debug with Mixed. Then you can get the call stack<br>
&nbsp; &nbsp; &nbsp; &nbsp;and other information when the minidump was created.<br>
</p>
<h3>Code logic</h3>
<p style="font-family:Courier New"><br>
1 Create an application CSApplicationToCrash.exe that could crash itself. When it runs, it<br>
&nbsp;will launch a Watchdog process CSCreateMiniDump.exe.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;static void Main(string[] args)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Process demoProcess = Process.GetCurrentProcess();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Console.WriteLine(&quot;The ID of this Demo Process is &quot; &#43; demoProcess.Id);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;LaunchWatchdog(demoProcess);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;for (int i = 1; i &lt; 10; i&#43;&#43;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Console.WriteLine(i);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;System.Threading.Thread.Sleep(1000);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Rethrow the exception, will cause an unhandled exception.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;int zero = 0;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Console.WriteLine(1 / zero);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;catch<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{ &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
<br>
<br>
2 Create CSCreateMiniDump.exe that could create minidump.<br>
<br>
&nbsp;2.1 Wrap the MiniDumpWriteDump function in the dbghelp.dll, and design MiniDumpCreator<br>
&nbsp; &nbsp; &nbsp;class that could create a minidump for a given process.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; [DllImport(&quot;dbghelp.dll&quot;, CharSet = CharSet.Auto, SetLastError = true)]<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; public &nbsp;static extern bool MiniDumpWriteDump(IntPtr hProcess,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; int processId,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; SafeFileHandle hFile,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MINIDUMP_TYPE dumpType,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; IntPtr exceptionParam,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; IntPtr userStreamParam,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; IntPtr callbackParam);<br>
<br>
&nbsp;2.2 Design ManagedProcess class that represents a managed process. It could attach<br>
&nbsp; &nbsp; &nbsp;a debugger to the managed process and subscribe the PostDebugEvent event of the process.<br>
<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;void AttachDebuggerToProcess()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string version =<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MdbgVersionPolicy.GetDefaultAttachVersion(this.DiagnosticsProcess.Id); &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (string.IsNullOrEmpty(version))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw new ApplicationException (&quot;Can't determine what version of the CLR to &quot; &#43;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&quot;attach to the process.&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.MDbgProcess = this.Debugger.Attach(this.DiagnosticsProcess.Id, null, version);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;bool result = this.MDbgProcess.Go().WaitOne();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (!result)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw new ApplicationException(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string.Format(@&quot;The process with an ID {0} could not be &quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&#43; &quot;attached. Operation time out.&quot;, this.DiagnosticsProcess.Id));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.MDbgProcess.PostDebugEvent &#43;=
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;new PostCallbackEventHandler(MDbgProcess_PostDebugEvent);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp;And then start to watch the target process. If the target application stops with an unhandled<br>
&nbsp; &nbsp; &nbsp;exception, raise an UnhandledExceptionOccurred event.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;public void StartWatch()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;while (true)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{ &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.MDbgProcess.Go().WaitOne();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (this.stopReason == ManagedCallbackType.OnException<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&& this.isExceptionUnhandled)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.HandleException();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;break;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else if (this.stopReason == ManagedCallbackType.OnProcessExit)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;break;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;private void HandleException()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MDbgValue ex = this.MDbgProcess.Threads.Active.CurrentException;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (ex.IsNull)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// No current exception is available. &nbsp;Perhaps the user switched to a different<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// thread which was not throwing an exception.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Console.WriteLine(&quot;Exception=&quot; &#43; ex.GetStringValue(0));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;IntPtr exceptionPointers = IntPtr.Zero;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;foreach (MDbgValue f in ex.GetFields())<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (f.Name == &quot;_xptrs&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string outputValue = f.GetStringValue(0);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;exceptionPointers = (IntPtr)int.Parse(outputValue);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (exceptionPointers == IntPtr.Zero)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Get the Exception Pointer in the target process<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MDbgValue value = FunctionEval(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&quot;System.Runtime.InteropServices.Marshal.GetExceptionPointers&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (value != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;exceptionPointers = (IntPtr)int.Parse(value.GetStringValue(1));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.OnUnhandledExceptionOccurred(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;new ManagedProcessUnhandledExceptionOccurredEventArgs<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ProcessID = this.MDbgProcess.CorProcess.Id,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ThreadID = this.MDbgProcess.Threads.Active.Id,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ExceptionPointers = exceptionPointers<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;});<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp;<br>
&nbsp;2.3 When CSCreateMiniDump.exe is launched, attach the debugger to CSApplicationToCrash.exe, and
<br>
&nbsp; &nbsp; &nbsp;create a minidump for the application CSApplicationToCrash.exe if it encounters an unhandled<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;exception.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;static void process_UnhandledExceptionOccurred(object sender,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ManagedProcessUnhandledExceptionOccurredEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Console.WriteLine(&quot;Creating Minidump...&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MiniDump.MiniDumpCreator.CreateMiniDump(e.ProcessID,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; e.ThreadID, e.ExceptionPointers);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Console.WriteLine(&quot;Done...&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; } &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
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
