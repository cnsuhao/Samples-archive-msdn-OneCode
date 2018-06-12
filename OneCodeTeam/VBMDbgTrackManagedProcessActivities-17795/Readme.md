# VBMDbgTrackManagedProcessActivities
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
* 2012-07-22 06:39:46
## Description
================================================================================<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Windows APPLICATION: VBMDbgTrackManagedProcessActivities &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
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
Step2. Run VBMDbgTrackManagedProcessActivities.exe. <br>
<br>
Step3. In the ProcessSelector dialog, check &quot;Launch an application to debug&quot; and <br>
&nbsp; &nbsp; &nbsp; browse the VBMDbgTargetApp.exe. Click OK.<br>
<br>
&nbsp; &nbsp; &nbsp; You will see the MainForm of the application, and the VBMDbgTargetApp.exe<br>
&nbsp; &nbsp; &nbsp; is running now.<br>
<br>
Step4. In VBMDbgTargetApp.exe, type &quot;t&quot;. This command is to create a thread, and &nbsp;<br>
&nbsp; &nbsp; &nbsp; it will exit in 5 seconds. You will see following message in the
<br>
&nbsp; &nbsp; &nbsp; VBMDbgTrackManagedProcessActivities.exe.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;Time&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Create Thread. ThreadID: &lt;ThreadID&gt;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;Time&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Thread Exit. ThreadID: &lt;ThreadID&gt;<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; You can also type &quot;t -list&quot; to list all threads in VBMDbgTargetApp.exe.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
<br>
Step5. In VBMDbgTargetApp.exe, type &quot;ad hello world&quot;. This command is to create an<br>
&nbsp; &nbsp; &nbsp; AppDomain, whose FriendlyName is &quot;hello world&quot;. You will see following
<br>
&nbsp; &nbsp; &nbsp; message in the VBMDbgTrackManagedProcessActivities.exe.<br>
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
&nbsp; &nbsp; &nbsp; You can also type &quot;ad -list&quot; to list all AppDomains in VBMDbgTargetApp.exe.<br>
<br>
Step6. In VBMDbgTargetApp.exe, type &quot;uad hello world&quot;. This command is to unload the
<br>
&nbsp; &nbsp; &nbsp; AppDomain, whose FriendlyName is &quot;hello world&quot;. You will see following
<br>
&nbsp; &nbsp; &nbsp; message in the VBMDbgTrackManagedProcessActivities.exe.<br>
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
Step7. In VBMDbgTargetApp.exe, type &quot;err hello world&quot;. This command is to throw an<br>
&nbsp; &nbsp; &nbsp; exception, whose Message is &quot;hello world&quot;. You will see following message
<br>
&nbsp; &nbsp; &nbsp; in the VBMDbgTrackManagedProcessActivities.exe.<br>
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
Step7. In VBMDbgTargetApp.exe, type &quot;log hello world&quot;. This command is to log a <br>
&nbsp; &nbsp; &nbsp; message in the debugger. You will see following message in the
<br>
&nbsp; &nbsp; &nbsp; VBMDbgTrackManagedProcessActivities.exe.<br>
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
&nbsp; &nbsp; &nbsp; &nbsp; Public Shared Function IsManagedProcess(ByVal processID As Integer) As Boolean<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Dim host As New CLRMetaHost()<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Dim enumerable As IEnumerable(Of CLRRuntimeInfo) =<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; host.EnumerateLoadedRuntimes(processID)<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Return enumerable.Count() &gt; 0<br>
&nbsp; &nbsp; &nbsp; &nbsp; End Function<br>
<br>
&nbsp; To determine whether an executable file is managed, we could check it has default<br>
&nbsp; runtime version.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Shared Function IsManagedExecutableFile(ByVal applicationPath As String,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;Out()&gt; ByRef version As String) As Boolean<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;version = MdbgVersionPolicy.GetDefaultRuntimeForFile(applicationPath)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return Not String.IsNullOrEmpty(version)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Function<br>
<br>
2. Attach a debugger to the target process, or launch an application to debug.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public ReadOnly Property Debugger() As MDbgEngine<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If _debugger Is Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;_debugger = New MDbgEngine()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return _debugger<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Get<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Property<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Function AttachTo(ByVal processID As Integer) As ManagedProcess<br>
&nbsp; &nbsp; &nbsp; &nbsp;...<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim version As String = MdbgVersionPolicy.GetDefaultAttachVersion(processID<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim mdbgProcess = Me.Debugger.Attach(processID, version)<br>
&nbsp; &nbsp; &nbsp; &nbsp;...<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Function<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Function CreateProcess(ByVal applicationPath As String) As ManagedProcess<br>
&nbsp; &nbsp; &nbsp; &nbsp;...<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim mdbgProcess = Me.Debugger.CreateProcess(applicationPath, String.Empty, DebugModeFlag.Debug, version)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim managedProcess = New ManagedProcess(mdbgProcess)<br>
&nbsp; &nbsp; &nbsp; &nbsp;...<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Function<br>
<br>
3. Register the PostDebugEvent of the MDbgProcess.<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; AddHandler Me.MDbgProcess.PostDebugEvent, AddressOf MDbgProcess_PostDebugEvent<br>
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
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub MDbgProcess_PostDebugEvent(ByVal sender As Object,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ByVal e As CustomPostCallbackEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Select Case e.CallbackType<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Case ManagedCallbackType.OnProcessExit<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.OnProcessExit()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Case ManagedCallbackType.OnException2<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim exceptionEventArgs = TryCast(e.CallbackArgs, CorException2EventArgs)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If exceptionEventArgs IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim exceptionValue As New MDbgValue(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.MDbgProcess, exceptionEventArgs.Thread.CurrentException)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim exceptionType As String = exceptionValue.GetStringValue(False)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim exceptionMessage As String = exceptionValue.GetField(&quot;_message&quot;).GetStringValue(True)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' If there is an unhandled exception in the debuggee.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If exceptionEventArgs.EventType = CorDebugExceptionCallbackType.DEBUG_EXCEPTION_UNHANDLED Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.OnOperationErrorOccurred(New ErrorEventArgs With<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{.Message = &quot;Unhandled exception occurred in the
 debuggee.&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; .Error = New ApplicationException(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; String.Format(&quot;Unhandled exception
 occurred in the debuggee.{2}Type:{0}{2}Message:{1}&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
 &nbsp; &nbsp; exceptionType, exceptionMessage, Environment.NewLine)),<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; .Ignorable = True})<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddActivity(&quot;Event Type: {0} {3} {1}:{2}&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;exceptionEventArgs.EventType,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;exceptionType,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;exceptionMessage,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Environment.NewLine)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Make the process continue.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;exceptionEventArgs.Continue = True<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Case ManagedCallbackType.OnCreateThread<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim createThreadEventArgs = TryCast(e.CallbackArgs, CorThreadEventArgs)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If createThreadEventArgs IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddActivity(&quot;Create Thread. ThreadID: {0}&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;createThreadEventArgs.Thread.Id)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Case ManagedCallbackType.OnThreadExit<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim threadExitEventArgs As CorThreadEventArgs = TryCast(e.CallbackArgs, CorThreadEventArgs)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If threadExitEventArgs IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddActivity(&quot;Thread Exit. ThreadID: {0}&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;threadExitEventArgs.Thread.Id)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Case ManagedCallbackType.OnCreateAppDomain<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim createAppDomainEventArgs = TryCast(e.CallbackArgs, CorAppDomainEventArgs)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If createAppDomainEventArgs IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddActivity(&quot;Create AppDomain. DomainID: {0} DomainName: {1}&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;createAppDomainEventArgs.AppDomain.Id,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;createAppDomainEventArgs.AppDomain.Name)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Case ManagedCallbackType.OnAppDomainExit<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim appDomainExitEventArgs = TryCast(e.CallbackArgs, CorAppDomainEventArgs)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If appDomainExitEventArgs IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddActivity(&quot;AppDomain Exit. DomainID: {0} DomainName: {1}&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;appDomainExitEventArgs.AppDomain.Id,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;appDomainExitEventArgs.AppDomain.Name)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Case ManagedCallbackType.OnLogMessage<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim logMessageEventArgs = TryCast(e.CallbackArgs, CorLogMessageEventArgs)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If logMessageEventArgs IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddActivity(&quot;Log Message: {0}&quot;, logMessageEventArgs.Message)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Case Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Select<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Catch<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Try<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Log the activity.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub AddActivity(ByVal format As String, ByVal ParamArray arguments() As Object)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim msg As String = String.Format(format, arguments)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddActivity(msg)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Log the activity.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub AddActivity(ByVal msg As String)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.OnPostEvent(New PostEventArgs With {.EventMessage = msg})<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Raise the PostEvent event.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Protected Overridable Sub OnPostEvent(ByVal e As PostEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RaiseEvent PostEvent(Me, e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Raise the ProcessExit event.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Protected Overridable Sub OnProcessExit()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RaiseEvent ProcessExit(Me, EventArgs.Empty)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Raise the OperationErrorOccurred event.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Protected Overridable Sub OnOperationErrorOccurred(ByVal e As ErrorEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RaiseEvent OperationErrorOccurred(Me, e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
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
