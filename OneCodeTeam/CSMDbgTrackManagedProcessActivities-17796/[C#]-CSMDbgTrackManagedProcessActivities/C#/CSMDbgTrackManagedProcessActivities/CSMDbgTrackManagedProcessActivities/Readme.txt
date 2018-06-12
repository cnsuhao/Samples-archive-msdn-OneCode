================================================================================
	            Windows APPLICATION: CSMDbgTrackManagedProcessActivities                        
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

Step2. Run CSMDbgTrackManagedProcessActivities.exe. 

Step3. In the ProcessSelector dialog, check "Launch an application to debug" and 
       browse the CSMDbgTargetApp.exe. Click OK.

       You will see the MainForm of the application, and the CSMDbgTargetApp.exe
       is running now.

Step4. In CSMDbgTargetApp.exe, type "t". This command is to create a thread, and  
       it will exit in 5 seconds. You will see following message in the 
       CSMDbgTrackManagedProcessActivities.exe.

           <Time>
           Create Thread. ThreadID: <ThreadID>

           <Time>
           Thread Exit. ThreadID: <ThreadID>
      
       You can also type "t -list" to list all threads in CSMDbgTargetApp.exe.
           

Step5. In CSMDbgTargetApp.exe, type "ad hello world". This command is to create an
       AppDomain, whose FriendlyName is "hello world". You will see following 
       message in the CSMDbgTrackManagedProcessActivities.exe.

           <Time>
           Create AppDomain. DomainID: <DomainID> DomainName: Domain <DomainID>

       You may find that the DomainName is not "hello world", this is because that
       the AppDomain.CreateDomain method will create the domain with the default name
       "Domain <DomainID>" first, and then set the FriendlyName. The debugger will be 
       notified just after the AppDomain is created.
     
       You can also type "ad -list" to list all AppDomains in CSMDbgTargetApp.exe.

Step6. In CSMDbgTargetApp.exe, type "uad hello world". This command is to unload the 
       AppDomain, whose FriendlyName is "hello world". You will see following 
       message in the CSMDbgTrackManagedProcessActivities.exe.

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

Step7. In CSMDbgTargetApp.exe, type "err hello world". This command is to throw an
       exception, whose Message is "hello world". You will see following message 
       in the CSMDbgTrackManagedProcessActivities.exe.

           <Time>
           Event Type: DEBUG_EXCEPTION_FIRST_CHANCE 
            System.Exception:"hello world"
           
           <Time>
           Event Type: DEBUG_EXCEPTION_CATCH_HANDLER_FOUND 
            System.Exception:"hello world"
                  
      Check this link to see the detailed information of event type:
      http://msdn.microsoft.com/en-us/library/ms231391.aspx

Step7. In CSMDbgTargetApp.exe, type "log hello world". This command is to log a 
       message in the debugger. You will see following message in the 
       CSMDbgTrackManagedProcessActivities.exe.

           <Time>
           Log Message: hello world

/////////////////////////////////////////////////////////////////////////////
Code Logic:

1. Check whether a running process is managed, and whether an executable file is
   managed.
   
   To determine whether a running process is managed, we could check the loaded
   runtime.

        public static bool IsManagedProcess(int processID)
        {
            CLRMetaHost host = new CLRMetaHost();

            IEnumerable<CLRRuntimeInfo> enumerable = 
                host.EnumerateLoadedRuntimes(processID);

            return enumerable.Count() > 0;
        }

   To determine whether an executable file is managed, we could check it has default
   runtime version.

        public static bool IsManagedExecutableFile(string applicationPath,
            out string version)
        {
            version = MdbgVersionPolicy.GetDefaultRuntimeForFile(applicationPath);
            return !string.IsNullOrEmpty(version);
        }

2. Attach a debugger to the target process, or launch an application to debug.

        public MDbgEngine Debugger
        {
            get
            {
                if (debugger == null)
                {
                    debugger = new MDbgEngine();
                }
                return debugger;
            }
        }

        public ManagedProcess AttachTo(int processID)
        {
        ...
            string version = MdbgVersionPolicy.GetDefaultAttachVersion(processID
            var mdbgProcess = this.Debugger.Attach(processID, version);
        ...
        }

        public ManagedProcess CreateProcess(string applicationPath)
        {
        ...
             var mdbgProcess = this.Debugger.CreateProcess(applicationPath,
                    string.Empty, DebugModeFlag.Debug, version);
        ...
        }

3. Register the PostDebugEvent of the MDbgProcess.
    
       this.MDbgProcess.PostDebugEvent += MDbgProcess_PostDebugEvent;

   In the handler, we will monitor following events.
   a. A thread is created or a thread exits.
   b. An AppDomain is created or an AppDomain is unloaded.
   c. An exception is thrown. 
   d. Other output information like Debugger.Log() 
   e. The process exits. 

   If there is an unhandled exception in the debuggee, the OperationErrorOccurred event
   will be raised.

        private void MDbgProcess_PostDebugEvent(object sender, CustomPostCallbackEventArgs e)
        {
            try
            {
                switch (e.CallbackType)
                {
                    case ManagedCallbackType.OnProcessExit:
                        this.OnProcessExit();
                        break;
                    case ManagedCallbackType.OnException2:
                        var exceptionEventArgs = e.CallbackArgs as CorException2EventArgs;

                        if (exceptionEventArgs != null)
                        {
                            MDbgValue exceptionValue = new MDbgValue(this.MDbgProcess,
                                 exceptionEventArgs.Thread.CurrentException);

                            string exceptionType = exceptionValue.GetStringValue(false);
                            string exceptionMessage = exceptionValue.GetField("_message").GetStringValue(true);

                            if (exceptionEventArgs.EventType == CorDebugExceptionCallbackType.DEBUG_EXCEPTION_UNHANDLED)
                            {
                                this.OnOperationErrorOccurred(new ErrorEventArgs
                                {
                                    Message = "Unhandled exception occurred in the debuggee.",
                                    Error = new ApplicationException(string.Format(
                                        "Unhandled exception occurred in the debuggee.{2}Type:{0}{2}Message:{1}",
                                        exceptionType, exceptionMessage, Environment.NewLine)),
                                    Ignorable = true
                                });
                            }
                            else
                            {
                                AddActivity("Event Type: {0} {3} {1}:{2}",
                                    exceptionEventArgs.EventType, exceptionType,
                                    exceptionMessage, Environment.NewLine);

                            }
                        }

                        exceptionEventArgs.Continue = true;
                        break;

                    case ManagedCallbackType.OnCreateThread:

                        var createThreadEventArgs = e.CallbackArgs as CorThreadEventArgs;

                        if (createThreadEventArgs != null)
                        {
                            AddActivity("Create Thread. ThreadID: {0}", createThreadEventArgs.Thread.Id);
                        }
                        break;
                    case ManagedCallbackType.OnThreadExit:
                        CorThreadEventArgs threadExitEventArgs = e.CallbackArgs as CorThreadEventArgs;

                        if (threadExitEventArgs != null)
                        {
                            AddActivity("Thread Exit. ThreadID: {0}", threadExitEventArgs.Thread.Id);
                        }
                        break;

                    case ManagedCallbackType.OnCreateAppDomain:
                        var createAppDomainEventArgs = e.CallbackArgs as CorAppDomainEventArgs;

                        if (createAppDomainEventArgs != null)
                        {
                            AddActivity("Create AppDomain. DomainID: {0} DomainName: {1}",
                                createAppDomainEventArgs.AppDomain.Id,
                                createAppDomainEventArgs.AppDomain.Name);
                        }
                        break;
                    case ManagedCallbackType.OnAppDomainExit:
                        var appDomainExitEventArgs = e.CallbackArgs as CorAppDomainEventArgs;

                        if (appDomainExitEventArgs != null)
                        {
                            AddActivity("AppDomain Exit. DomainID: {0} DomainName: {1}",
                                appDomainExitEventArgs.AppDomain.Id,
                                appDomainExitEventArgs.AppDomain.Name);
                        }
                        break;
                    case ManagedCallbackType.OnLogMessage:
                        var logMessageEventArgs = e.CallbackArgs as CorLogMessageEventArgs;

                        if (logMessageEventArgs != null)
                        {
                            AddActivity("Log Message: {0}", logMessageEventArgs.Message);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }

        void AddActivity(string format, params object[] arguments)
        {         
            string msg = string.Format(format, arguments);
            AddActivity(msg);
        }

        void AddActivity(string msg)
        {
            this.OnPostEvent(new PostEventArgs
                {
                    EventMessage = msg
                });
        }

        protected virtual void OnPostEvent(PostEventArgs e)
        {
            if (this.PostEvent != null)
            {
                this.PostEvent(this, e);
            }
        }
        
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
