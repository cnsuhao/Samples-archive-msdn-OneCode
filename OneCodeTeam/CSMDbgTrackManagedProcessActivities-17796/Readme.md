# CSMDbgTrackManagedProcessActivities
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* CLR
## Topics
* MDbg
## IsPublished
* False
## ModifiedDate
* 2012-07-22 06:39:58
## Description
================================================================================<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Windows APPLICATION: CSMDbgTrackManagedProcessActivities &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
===============================================================================<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Summary:<br>
The sample demonstrates how to track a managed process activities. The activities<br>
include<br>
1. A thread is created or a thread exits.<br>
2. An AppDomain is created or an AppDomain is unloaded.<br>
3. An exception is thrown. <br>
4. Other output information like Debugger.Log()<br>
<br>
&nbsp; <br>
////////////////////////////////////////////////////////////////////////////////<br>
Demo:<br>
Step1. Build the sample project in Visual Studio 2010.<br>
<br>
Step2. Run CSMDbgTrackManagedProcessActivities.exe. <br>
<br>
Step3. In the ProcessSelector dialog, check &quot;Launch an application to debug&quot; and <br>
&nbsp; &nbsp; &nbsp; browse the CSMDbgTargetApp.exe. Click OK.<br>
<br>
&nbsp; &nbsp; &nbsp; You will see the MainForm of the application, and the CSMDbgTargetApp.exe<br>
&nbsp; &nbsp; &nbsp; is running now.<br>
<br>
Step4. In CSMDbgTargetApp.exe, type &quot;t&quot;. This command is to create a thread, and &nbsp;<br>
&nbsp; &nbsp; &nbsp; it will exit in 5 seconds. You will see following message in the
<br>
&nbsp; &nbsp; &nbsp; CSMDbgTrackManagedProcessActivities.exe.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;Time&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Create Thread. ThreadID: &lt;ThreadID&gt;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;Time&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Thread Exit. ThreadID: &lt;ThreadID&gt;<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; You can also type &quot;t -list&quot; to list all threads in CSMDbgTargetApp.exe.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
<br>
Step5. In CSMDbgTargetApp.exe, type &quot;ad hello world&quot;. This command is to create an<br>
&nbsp; &nbsp; &nbsp; AppDomain, whose FriendlyName is &quot;hello world&quot;. You will see following
<br>
&nbsp; &nbsp; &nbsp; message in the CSMDbgTrackManagedProcessActivities.exe.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;Time&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Create AppDomain. DomainID: &lt;DomainID&gt; DomainName: Domain &lt;DomainID&gt;<br>
<br>
&nbsp; &nbsp; &nbsp; You may find that the DomainName is not &quot;hello world&quot;, this is because that<br>
&nbsp; &nbsp; &nbsp; the AppDomain.CreateDomain method will create the domain with the default name<br>
&nbsp; &nbsp; &nbsp; &quot;Domain &lt;DomainID&gt;&quot; first, and then set the FriendlyName. The debugger will be
<br>
&nbsp; &nbsp; &nbsp; notified just after the AppDomain is created.<br>
&nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; You can also type &quot;ad -list&quot; to list all AppDomains in CSMDbgTargetApp.exe.<br>
<br>
Step6. In CSMDbgTargetApp.exe, type &quot;uad hello world&quot;. This command is to unload the
<br>
&nbsp; &nbsp; &nbsp; AppDomain, whose FriendlyName is &quot;hello world&quot;. You will see following
<br>
&nbsp; &nbsp; &nbsp; message in the CSMDbgTrackManagedProcessActivities.exe.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;Time&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Create Thread. ThreadID: &lt;ThreadID1&gt;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;Time&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; AppDomain Exit. DomainID: &lt;DomainID&gt; DomainName: &nbsp;hello world<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;Time&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Create Thread. ThreadID: &lt;ThreadID2&gt;<br>
<br>
&nbsp; &nbsp; &nbsp; You may find that there are 2 threads are created, this is because that<br>
&nbsp; &nbsp; &nbsp; 1. In the .NET Framework version 2.0 there is a thread dedicated to unloading<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;application domains. When you unload an AppDomain for the first time, CLR<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;will create a new thread.<br>
&nbsp; &nbsp; &nbsp; 2. After the AppDomain is unloaded, CLR will create a new thread to call the
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;internal static DomainUnloaded method of the <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;System.Runtime.Remoting.RemotingServices class.<br>
<br>
Step7. In CSMDbgTargetApp.exe, type &quot;err hello world&quot;. This command is to throw an<br>
&nbsp; &nbsp; &nbsp; exception, whose Message is &quot;hello world&quot;. You will see following message
<br>
&nbsp; &nbsp; &nbsp; in the CSMDbgTrackManagedProcessActivities.exe.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;Time&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Event Type: DEBUG_EXCEPTION_FIRST_CHANCE <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;System.Exception:&quot;hello world&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;Time&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Event Type: DEBUG_EXCEPTION_CATCH_HANDLER_FOUND
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;System.Exception:&quot;hello world&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp;Check this link to see the detailed information of event type:<br>
&nbsp; &nbsp; &nbsp;http://msdn.microsoft.com/en-us/library/ms231391.aspx<br>
<br>
Step7. In CSMDbgTargetApp.exe, type &quot;log hello world&quot;. This command is to log a <br>
&nbsp; &nbsp; &nbsp; message in the debugger. You will see following message in the
<br>
&nbsp; &nbsp; &nbsp; CSMDbgTrackManagedProcessActivities.exe.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;Time&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Log Message: hello world<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Code Logic:<br>
<br>
1. Check whether a running process is managed, and whether an executable file is<br>
&nbsp; managed.<br>
&nbsp; <br>
&nbsp; To determine whether a running process is managed, we could check the loaded<br>
&nbsp; runtime.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public static bool IsManagedProcess(int processID)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CLRMetaHost host = new CLRMetaHost();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;IEnumerable&lt;CLRRuntimeInfo&gt; enumerable =
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;host.EnumerateLoadedRuntimes(processID);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return enumerable.Count() &gt; 0;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; To determine whether an executable file is managed, we could check it has default<br>
&nbsp; runtime version.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public static bool IsManagedExecutableFile(string applicationPath,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;out string version)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;version = MdbgVersionPolicy.GetDefaultRuntimeForFile(applicationPath);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return !string.IsNullOrEmpty(version);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
2. Attach a debugger to the target process, or launch an application to debug.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public MDbgEngine Debugger<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (debugger == null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;debugger = new MDbgEngine();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return debugger;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public ManagedProcess AttachTo(int processID)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;...<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string version = MdbgVersionPolicy.GetDefaultAttachVersion(processID<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var mdbgProcess = this.Debugger.Attach(processID, version);<br>
&nbsp; &nbsp; &nbsp; &nbsp;...<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public ManagedProcess CreateProcess(string applicationPath)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;...<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; var mdbgProcess = this.Debugger.CreateProcess(applicationPath,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string.Empty, DebugModeFlag.Debug, version);<br>
&nbsp; &nbsp; &nbsp; &nbsp;...<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
3. Register the PostDebugEvent of the MDbgProcess.<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; this.MDbgProcess.PostDebugEvent &#43;= MDbgProcess_PostDebugEvent;<br>
<br>
&nbsp; In the handler, we will monitor following events.<br>
&nbsp; a. A thread is created or a thread exits.<br>
&nbsp; b. An AppDomain is created or an AppDomain is unloaded.<br>
&nbsp; c. An exception is thrown. <br>
&nbsp; d. Other output information like Debugger.Log() <br>
&nbsp; e. The process exits. <br>
<br>
&nbsp; If there is an unhandled exception in the debuggee, the OperationErrorOccurred event<br>
&nbsp; will be raised.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void MDbgProcess_PostDebugEvent(object sender, CustomPostCallbackEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;switch (e.CallbackType)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;case ManagedCallbackType.OnProcessExit:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.OnProcessExit();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;break;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;case ManagedCallbackType.OnException2:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var exceptionEventArgs = e.CallbackArgs as CorException2EventArgs;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (exceptionEventArgs != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MDbgValue exceptionValue = new MDbgValue(this.MDbgProcess,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; exceptionEventArgs.Thread.CurrentException);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string exceptionType = exceptionValue.GetStringValue(false);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string exceptionMessage = exceptionValue.GetField(&quot;_message&quot;).GetStringValue(true);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (exceptionEventArgs.EventType == CorDebugExceptionCallbackType.DEBUG_EXCEPTION_UNHANDLED)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.OnOperationErrorOccurred(new ErrorEventArgs<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Message = &quot;Unhandled exception occurred in the debuggee.&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Error = new ApplicationException(string.Format(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&quot;Unhandled exception occurred in the debuggee.{2}Type:{0}{2}Message:{1}&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;exceptionType, exceptionMessage, Environment.NewLine)),<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Ignorable = true<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;});<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddActivity(&quot;Event Type: {0} {3} {1}:{2}&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;exceptionEventArgs.EventType, exceptionType,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;exceptionMessage, Environment.NewLine);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;exceptionEventArgs.Continue = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;break;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;case ManagedCallbackType.OnCreateThread:<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var createThreadEventArgs = e.CallbackArgs as CorThreadEventArgs;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (createThreadEventArgs != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddActivity(&quot;Create Thread. ThreadID: {0}&quot;, createThreadEventArgs.Thread.Id);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;break;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;case ManagedCallbackType.OnThreadExit:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CorThreadEventArgs threadExitEventArgs = e.CallbackArgs as CorThreadEventArgs;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (threadExitEventArgs != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddActivity(&quot;Thread Exit. ThreadID: {0}&quot;, threadExitEventArgs.Thread.Id);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;break;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;case ManagedCallbackType.OnCreateAppDomain:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var createAppDomainEventArgs = e.CallbackArgs as CorAppDomainEventArgs;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (createAppDomainEventArgs != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddActivity(&quot;Create AppDomain. DomainID: {0} DomainName: {1}&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;createAppDomainEventArgs.AppDomain.Id,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;createAppDomainEventArgs.AppDomain.Name);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;break;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;case ManagedCallbackType.OnAppDomainExit:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var appDomainExitEventArgs = e.CallbackArgs as CorAppDomainEventArgs;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (appDomainExitEventArgs != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddActivity(&quot;AppDomain Exit. DomainID: {0} DomainName: {1}&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;appDomainExitEventArgs.AppDomain.Id,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;appDomainExitEventArgs.AppDomain.Name);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;break;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;case ManagedCallbackType.OnLogMessage:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var logMessageEventArgs = e.CallbackArgs as CorLogMessageEventArgs;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (logMessageEventArgs != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddActivity(&quot;Log Message: {0}&quot;, logMessageEventArgs.Message);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;break;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;default:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;break;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;catch { }<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;void AddActivity(string format, params object[] arguments)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{ &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string msg = string.Format(format, arguments);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddActivity(msg);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;void AddActivity(string msg)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.OnPostEvent(new PostEventArgs<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;EventMessage = msg<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;});<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected virtual void OnPostEvent(PostEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (this.PostEvent != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.PostEvent(this, e);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
4. Design the MainForm as the UI.<br>
&nbsp; <br>
&nbsp; Because the main thread of WinForm Application is STAThread, but the debugger needs MTAThread,<br>
&nbsp; design the MTAThreadHelper class to call the debugging methods in a MTAThread.<br>
<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
References:<br>
<br>
Debugging (Unmanaged API Reference)<br>
http://msdn.microsoft.com/en-us/library/ms404520.aspx<br>
<br>
MDbg.exe (.NET Framework Command-Line Debugger)<br>
http://msdn.microsoft.com/en-us/library/ms229861.aspx<br>
<br>
MTAThreadAttribute Class<br>
http://msdn.microsoft.com/en-us/library/system.mtathreadattribute.aspx<br>
/////////////////////////////////////////////////////////////////////////////<br>
