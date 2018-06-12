================================================================================
	            Windows APPLICATION: CSMDbgEvaluateFunction                        
===============================================================================

/////////////////////////////////////////////////////////////////////////////
Summary:
The sample demonstrates how to debug a managed process and supplies following 
features:
1. Stop and continue the target process.
2. List the threads of the target process, and get the local variables in the
   frame which has source code. 
3. Evaluate a function in the target process.
   The function may have no paramter, or have value type Parameters, Reference 
   Type Parameters, or even generic type parameters.

NOTE:
The debugging API supports to debug a managed process without symbol file or source 
code, but to test the features, you have to debug a process/application with 
symbol file and source code. 
   
////////////////////////////////////////////////////////////////////////////////
Demo:
Step1. Build the sample project in Visual Studio 2010.

Step2. Run CSMDbgEvaluateFunction.exe. 

Step3. In the ProcessSelector dialog, check "Launch an application to debug" and 
       browse the CSMDbgTargetApp.exe. Click OK.

       You will see the MainForm of the application, and the CSMDbgTargetApp.exe
       is running now.

Step4. Click the button "Stop". You will find that the CSMDbgTargetApp.exe stops and 
       see the threads in the mainform.

Step5. Click a row in the threads gridview, you will see the local viriables in the 
       second gridview. 

Step6. Select an expression in the combobox, like "this.GenericMethod([3,4])" and then
       press the "Evaluate" button, you will get "Three,Four," as the result.

Step7. Click the "Continue" button, you will find the the CSMDbgTargetApp.exe is 
       running again. 

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

3. Stop or Continue the debuggee.
    
   this.MDbgProcess.AsyncStop().WaitOne(); 
   or 
   this.MDbgProcess.Go(); 
   
   
4. Get the local variables in the frame which has source. 

   When the debuggee is stpped, it maybe executing a method without source code, like the 
   method body of the System.Int32.ToString. Although we can get the local variables in the 
   method body, it does not make sense to view the internal variables.

   So if the current frame has no source code, we will step it out till it has source code. 
   Make sure that the debuggee has symbol files and source files before you start to debug it
   in this sample.

         while (this.MDbgThread.HaveCurrentFrame &&
             this.MDbgThread.CurrentFrame.SourcePosition == null)
         {
             this.Process.MDbgProcess.StepOut().WaitOne();
         }
   
        public List<ManagedValue> GetLocalVariables(ManagedThread thread)
        {

            if (thread.MDbgThread.HaveCurrentFrame)
            {
                var frame = thread.SourcePositionFrame;
                var localVars = frame.Function.GetActiveLocalVars(frame);
                var args = frame.Function.GetArguments(frame);

                // The compiler will add some additional variables that start with "CS$"
                // or "VB$".
                var sourceCodeVars = from value in localVars.Concat(args)
                                     where !value.Name.StartsWith("CS$") && !value.Name.StartsWith("VB$")
                                     select new ManagedValue(value);
               
                return sourceCodeVars.ToList();
            }
            else
            {
                return null;
            }
        } 

5. Evaluate an expression. The expression format is 
   a. Instance Method: obj.Method(args)
   b. Static Method: Class.Method(args)
   
   The args should be like following formats
   a. Empty
   b. Integer : 100
   c. String:   "Hello World"
   d. Generic Type (List<int>): [1,2,3,4] 
   
   To parse the expression, we have to  
   5.1 Use regular expressions to get each part of the expression.
       
           string pattern = @"^(?<obj>.*)\.(?<method>.+)\((?<args>.*)\)$";
           Regex rx = new Regex(pattern);
           var match = rx.Match(expression)
           
           var obj = match.Groups["obj"].Value;
           var method = match.Groups["method"].Value;
           var args = match.Groups["args"].Value;

   5.2 Resolve the obj and method.
       
           MDbgValue objValue = process.ResolveVariable(obj, scope);

       If the objValue is not null, we can consider the method is an instance method,
       else, it is a static method.

                if (objValue != null)
                {

                    string functionName = string.Format("{0}.{1}", objValue.TypeName, method);
                    function = process.ResolveFunctionName(
                        null,
                        objValue.TypeName,
                        method,
                        scope.Thread.CorThread.AppDomain);
                }
                else
                {
                    string functionName = string.Format("{0}.{1}", obj, method);
                    function = process.ResolveFunctionNameFromScope(
                        functionName,
                        scope.Thread.CorThread.AppDomain);
                }

   
   5.3 Resolve the argument.
       a. Determine the argument type. The supported argument types are Empty, System.Int32,
          System.String and System.Collections.Generic.List<System.Int32>
       b. Create an Integer value.
       
               static CorValue CreateIntegerValue(MDbgProcess process, MDbgFrame scope, int arg)
               {
                   var eval = scope.Thread.CorThread.CreateEval();
                   var value = eval.CreateValue(CorElementType.ELEMENT_TYPE_I4, null).CastToGenericValue();
                   value.SetValue(arg);
                   return value;
               }     
       c. Create a String value.
               
               static CorValue CreateStringValue(MDbgProcess process, MDbgFrame scope, string arg)
               {
                   var eval = scope.Thread.CorThread.CreateEval();
                   eval.NewString(arg);
                   process.Go().WaitOne();
                   if (!(process.StopReason is EvalCompleteStopReason))
                   {
                       throw new ApplicationException("Wrong stop reason while evaluating function.");
                   }
                   return (process.StopReason as EvalCompleteStopReason).Eval.Result.CastToReferenceValue();
               }
       d. Create an List<int> value. To create a genric type value (List<Type>) with items,
          Step1. Get the constructor.
          Step2. Pass the types and other arguments to the constructor.
          Step3. Evaluate the System.Collections.Generic.List`1.Add function.   

              static CorValue CreateGenericTypeValue(MDbgProcess process, MDbgFrame scope, string arg)
              {
                  var constructor = process.ResolveFunctionName(
                      null,
                      "System.Collections.Generic.List`1",
                      ".ctor",
                      scope.Thread.CorThread.AppDomain);

                  var intType = process.ResolveType("System.Int32");

                  var eval = scope.Thread.CorThread.CreateEval();
              
                  eval.NewParameterizedObject(
                      constructor.CorFunction,
                      new CorType[] { intType },
                      new CorValue[0]);
              
                  process.Go().WaitOne();
                  if (!(process.StopReason is EvalCompleteStopReason))
                  {
                      throw new ApplicationException("Wrong stop reason while evaluating function.");
                  }
              
                  var integerList = (process.StopReason as EvalCompleteStopReason).Eval.Result;
              
                  var addFunction = process.ResolveFunctionName(
                      null,
                      "System.Collections.Generic.List`1",
                      "Add",
                      scope.Thread.CorThread.AppDomain);
              
                  string[] args = arg.Split(new char[] { '[', ']', ',' }, 
                      StringSplitOptions.RemoveEmptyEntries);

                  for (int i = 0; i < args.Length; i++)
                  {
                      int intArg = 0;
              
                      if (int.TryParse(args[i], out intArg))
                      {
                          var value = eval.CreateValue(CorElementType.ELEMENT_TYPE_I4, null).CastToGenericValue();
                          value.SetValue(intArg);
                          eval.CallParameterizedFunction(
                              addFunction.CorFunction,
                              new CorType[] { intType },
                              new CorValue[] { integerList, value });
              
                          process.Go().WaitOne();
                          if (!(process.StopReason is EvalCompleteStopReason))
                          {
                              throw new ApplicationException("Wrong stop reason while evaluating function.");
                          }              
                      }
                  }
              
                  return integerList;
              }
        
6. Design the MainForm as the UI.
   
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
