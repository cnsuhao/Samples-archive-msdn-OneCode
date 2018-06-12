================================================================================
	            Windows APPLICATION: VBMDbgTrackManagedProcessActivities                        
===============================================================================

/////////////////////////////////////////////////////////////////////////////
Summary:
The sample demonstrates how to track a managed process activities. The activities
include
1. A thread is created or a thread exits.
2. An AppDomain is created or an AppDomain is unloaded.
3. An exception is thrown. 
4. Other output information like Debugger.Log()

   
////////////////////////////////////////////////////////////////////////////////
Demo:
Step1. Build the sample project in Visual Studio 2010.

Step2. Run VBMDbgTrackManagedProcessActivities.exe. 

Step3. In the ProcessSelector dialog, check "Launch an application to debug" and 
       browse the VBMDbgTargetApp.exe. Click OK.

       You will see the MainForm of the application, and the VBMDbgTargetApp.exe
       is running now.

Step4. In VBMDbgTargetApp.exe, type "t". This command is to create a thread, and  
       it will exit in 5 seconds. You will see following message in the 
       VBMDbgTrackManagedProcessActivities.exe.

           <Time>
           Create Thread. ThreadID: <ThreadID>

           <Time>
           Thread Exit. ThreadID: <ThreadID>
      
       You can also type "t -list" to list all threads in VBMDbgTargetApp.exe.
           

Step5. In VBMDbgTargetApp.exe, type "ad hello world". This command is to create an
       AppDomain, whose FriendlyName is "hello world". You will see following 
       message in the VBMDbgTrackManagedProcessActivities.exe.

           <Time>
           Create AppDomain. DomainID: <DomainID> DomainName: Domain <DomainID>

       You may find that the DomainName is not "hello world", this is because that
       the AppDomain.CreateDomain method will create the domain with the default name
       "Domain <DomainID>" first, and then set the FriendlyName. The debugger will be 
       notified just after the AppDomain is created.
     
       You can also type "ad -list" to list all AppDomains in VBMDbgTargetApp.exe.

Step6. In VBMDbgTargetApp.exe, type "uad hello world". This command is to unload the 
       AppDomain, whose FriendlyName is "hello world". You will see following 
       message in the VBMDbgTrackManagedProcessActivities.exe.

           <Time>
           Create Thread. ThreadID: <ThreadID1>

           <Time>
           AppDomain Exit. DomainID: <DomainID> DomainName:  hello world

           <Time>
           Create Thread. ThreadID: <ThreadID2>

       You may find that there are 2 threads are created, this is because that
       1. In the .NET Framework version 2.0 there is a thread dedicated to unloading
          application domains. When you unload an AppDomain for the first time, CLR
          will create a new thread.
       2. After the AppDomain is unloaded, CLR will create a new thread to call the 
          internal static DomainUnloaded method of the 
          System.Runtime.Remoting.RemotingServices class.

Step7. In VBMDbgTargetApp.exe, type "err hello world". This command is to throw an
       exception, whose Message is "hello world". You will see following message 
       in the VBMDbgTrackManagedProcessActivities.exe.

           <Time>
           Event Type: DEBUG_EXCEPTION_FIRST_CHANCE 
            System.Exception:"hello world"
           
           <Time>
           Event Type: DEBUG_EXCEPTION_CATCH_HANDLER_FOUND 
            System.Exception:"hello world"
                  
      Check this link to see the detailed information of event type:
      http://msdn.microsoft.com/en-us/library/ms231391.aspx

Step7. In VBMDbgTargetApp.exe, type "log hello world". This command is to log a 
       message in the debugger. You will see following message in the 
       VBMDbgTrackManagedProcessActivities.exe.

           <Time>
           Log Message: hello world

/////////////////////////////////////////////////////////////////////////////
Code Logic:

1. Check whether a running process is managed, and whether an executable file is
   managed.
   
   To determine whether a running process is managed, we could check the loaded
   runtime.

         Public Shared Function IsManagedProcess(ByVal processID As Integer) As Boolean
             Dim host As New CLRMetaHost()
        
             Dim enumerable As IEnumerable(Of CLRRuntimeInfo) =
                 host.EnumerateLoadedRuntimes(processID)
        
             Return enumerable.Count() > 0
         End Function

   To determine whether an executable file is managed, we could check it has default
   runtime version.

        Public Shared Function IsManagedExecutableFile(ByVal applicationPath As String,
                                                       <Out()> ByRef version As String) As Boolean
            version = MdbgVersionPolicy.GetDefaultRuntimeForFile(applicationPath)
            Return Not String.IsNullOrEmpty(version)
        End Function

2. Attach a debugger to the target process, or launch an application to debug.

        Public ReadOnly Property Debugger() As MDbgEngine
            Get
                If _debugger Is Nothing Then
                    _debugger = New MDbgEngine()
                End If
                Return _debugger
            End Get
        End Property

        Public Function AttachTo(ByVal processID As Integer) As ManagedProcess
        ...
            Dim version As String = MdbgVersionPolicy.GetDefaultAttachVersion(processID
            Dim mdbgProcess = Me.Debugger.Attach(processID, version)
        ...
        End Function

        Public Function CreateProcess(ByVal applicationPath As String) As ManagedProcess
        ...
            Dim mdbgProcess = Me.Debugger.CreateProcess(applicationPath, String.Empty, DebugModeFlag.Debug, version)
            Dim managedProcess = New ManagedProcess(mdbgProcess)
        ...
        End Function

3. Register the PostDebugEvent of the MDbgProcess.
    
       AddHandler Me.MDbgProcess.PostDebugEvent, AddressOf MDbgProcess_PostDebugEvent

   In the handler, we will monitor following events.
   a. A thread is created or a thread exits.
   b. An AppDomain is created or an AppDomain is unloaded.
   c. An exception is thrown. 
   d. Other output information like Debugger.Log() 
   e. The process exits. 

   If there is an unhandled exception in the debuggee, the OperationErrorOccurred event
   will be raised.

        Private Sub MDbgProcess_PostDebugEvent(ByVal sender As Object,
                                               ByVal e As CustomPostCallbackEventArgs)
            Try
                Select Case e.CallbackType
                    Case ManagedCallbackType.OnProcessExit
                        Me.OnProcessExit()
                    Case ManagedCallbackType.OnException2
                        Dim exceptionEventArgs = TryCast(e.CallbackArgs, CorException2EventArgs)

                        If exceptionEventArgs IsNot Nothing Then
                            Dim exceptionValue As New MDbgValue(
                                Me.MDbgProcess, exceptionEventArgs.Thread.CurrentException)

                            Dim exceptionType As String = exceptionValue.GetStringValue(False)
                            Dim exceptionMessage As String = exceptionValue.GetField("_message").GetStringValue(True)

                            ' If there is an unhandled exception in the debuggee.
                            If exceptionEventArgs.EventType = CorDebugExceptionCallbackType.DEBUG_EXCEPTION_UNHANDLED Then
                                Me.OnOperationErrorOccurred(New ErrorEventArgs With
                                                            {.Message = "Unhandled exception occurred in the debuggee.",
                                                             .Error = New ApplicationException(
                                                                 String.Format("Unhandled exception occurred in the debuggee.{2}Type:{0}{2}Message:{1}",
                                                                               exceptionType, exceptionMessage, Environment.NewLine)),
                                                             .Ignorable = True})
                            Else
                                AddActivity("Event Type: {0} {3} {1}:{2}",
                                            exceptionEventArgs.EventType,
                                            exceptionType,
                                            exceptionMessage,
                                            Environment.NewLine)

                            End If
                        End If

                        ' Make the process continue.
                        exceptionEventArgs.Continue = True

                    Case ManagedCallbackType.OnCreateThread

                        Dim createThreadEventArgs = TryCast(e.CallbackArgs, CorThreadEventArgs)

                        If createThreadEventArgs IsNot Nothing Then
                            AddActivity("Create Thread. ThreadID: {0}",
                                        createThreadEventArgs.Thread.Id)
                        End If

                    Case ManagedCallbackType.OnThreadExit
                        Dim threadExitEventArgs As CorThreadEventArgs = TryCast(e.CallbackArgs, CorThreadEventArgs)

                        If threadExitEventArgs IsNot Nothing Then
                            AddActivity("Thread Exit. ThreadID: {0}",
                                        threadExitEventArgs.Thread.Id)
                        End If

                    Case ManagedCallbackType.OnCreateAppDomain
                        Dim createAppDomainEventArgs = TryCast(e.CallbackArgs, CorAppDomainEventArgs)

                        If createAppDomainEventArgs IsNot Nothing Then
                            AddActivity("Create AppDomain. DomainID: {0} DomainName: {1}",
                                        createAppDomainEventArgs.AppDomain.Id,
                                        createAppDomainEventArgs.AppDomain.Name)
                        End If

                    Case ManagedCallbackType.OnAppDomainExit
                        Dim appDomainExitEventArgs = TryCast(e.CallbackArgs, CorAppDomainEventArgs)

                        If appDomainExitEventArgs IsNot Nothing Then
                            AddActivity("AppDomain Exit. DomainID: {0} DomainName: {1}",
                                        appDomainExitEventArgs.AppDomain.Id,
                                        appDomainExitEventArgs.AppDomain.Name)
                        End If

                    Case ManagedCallbackType.OnLogMessage
                        Dim logMessageEventArgs = TryCast(e.CallbackArgs, CorLogMessageEventArgs)

                        If logMessageEventArgs IsNot Nothing Then
                            AddActivity("Log Message: {0}", logMessageEventArgs.Message)
                        End If
                    Case Else
                End Select
            Catch
            End Try
        End Sub

        ''' <summary>
        ''' Log the activity.
        ''' </summary>
        Private Sub AddActivity(ByVal format As String, ByVal ParamArray arguments() As Object)
            Dim msg As String = String.Format(format, arguments)
            AddActivity(msg)
        End Sub

        ''' <summary>
        ''' Log the activity.
        ''' </summary>
        Private Sub AddActivity(ByVal msg As String)
            Me.OnPostEvent(New PostEventArgs With {.EventMessage = msg})
        End Sub

        ''' <summary>
        ''' Raise the PostEvent event.
        ''' </summary>
        Protected Overridable Sub OnPostEvent(ByVal e As PostEventArgs)
            RaiseEvent PostEvent(Me, e)
        End Sub

        ''' <summary>
        ''' Raise the ProcessExit event.
        ''' </summary>
        Protected Overridable Sub OnProcessExit()
            RaiseEvent ProcessExit(Me, EventArgs.Empty)
        End Sub

        ''' <summary>
        ''' Raise the OperationErrorOccurred event.
        ''' </summary>
        Protected Overridable Sub OnOperationErrorOccurred(ByVal e As ErrorEventArgs)
            RaiseEvent OperationErrorOccurred(Me, e)
        End Sub
        
4. Design the MainForm as the UI.
   
   Because the main thread of WinForm Application is STAThread, but the debugger needs MTAThread,
   design the MTAThreadHelper class to call the debugging methods in a MTAThread.


/////////////////////////////////////////////////////////////////////////////
References:

Debugging (Unmanaged API Reference)
http://msdn.microsoft.com/en-us/library/ms404520.aspx

MDbg.exe (.NET Framework Command-Line Debugger)
http://msdn.microsoft.com/en-us/library/ms229861.aspx

MTAThreadAttribute Class
http://msdn.microsoft.com/en-us/library/system.mtathreadattribute.aspx
/////////////////////////////////////////////////////////////////////////////
