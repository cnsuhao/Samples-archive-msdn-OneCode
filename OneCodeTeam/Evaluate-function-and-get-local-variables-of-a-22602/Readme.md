# Evaluate function and get local variables of a Managed Process Using MDbg
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* .NET Development
## Topics
* MDbg
## IsPublished
* True
## ModifiedDate
* 2013-06-13 10:05:11
## Description
================================================================================<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Windows APPLICATION: CSMDbgEvaluateFunction &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
===============================================================================<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Summary:<br>
The sample demonstrates how to debug a managed process and supplies following <br>
features:<br>
1. Stop and continue the target process.<br>
2. List the threads of the target process, and get the local variables in the<br>
&nbsp; frame which has source code. <br>
3. Evaluate a function in the target process.<br>
&nbsp; The function may have no paramter, or have value type Parameters, Reference
<br>
&nbsp; Type Parameters, or even generic type parameters.<br>
<br>
NOTE:<br>
The debugging API supports to debug a managed process without symbol file or source
<br>
code, but to test the features, you have to debug a process/application with <br>
symbol file and source code. <br>
&nbsp; <br>
////////////////////////////////////////////////////////////////////////////////<br>
Demo:<br>
Step1. Build the sample project in Visual Studio 2010.<br>
<br>
Step2. Run CSMDbgEvaluateFunction.exe. <br>
<br>
Step3. In the ProcessSelector dialog, check &quot;Launch an application to debug&quot; and <br>
&nbsp; &nbsp; &nbsp; browse the CSMDbgTargetApp.exe. Click OK.<br>
<br>
&nbsp; &nbsp; &nbsp; You will see the MainForm of the application, and the CSMDbgTargetApp.exe<br>
&nbsp; &nbsp; &nbsp; is running now.<br>
<br>
Step4. Click the button &quot;Stop&quot;. You will find that the CSMDbgTargetApp.exe stops and
<br>
&nbsp; &nbsp; &nbsp; see the threads in the mainform.<br>
<br>
Step5. Click a row in the threads gridview, you will see the local viriables in the
<br>
&nbsp; &nbsp; &nbsp; second gridview. <br>
<br>
Step6. Select an expression in the combobox, like &quot;this.GenericMethod([3,4])&quot; and then<br>
&nbsp; &nbsp; &nbsp; press the &quot;Evaluate&quot; button, you will get &quot;Three,Four,&quot; as the result.<br>
<br>
Step7. Click the &quot;Continue&quot; button, you will find the the CSMDbgTargetApp.exe is <br>
&nbsp; &nbsp; &nbsp; running again. <br>
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
3. Stop or Continue the debuggee.<br>
&nbsp; &nbsp;<br>
&nbsp; this.MDbgProcess.AsyncStop().WaitOne(); <br>
&nbsp; or <br>
&nbsp; this.MDbgProcess.Go(); <br>
&nbsp; <br>
&nbsp; <br>
4. Get the local variables in the frame which has source. <br>
<br>
&nbsp; When the debuggee is stpped, it maybe executing a method without source code, like the
<br>
&nbsp; method body of the System.Int32.ToString. Although we can get the local variables in the
<br>
&nbsp; method body, it does not make sense to view the internal variables.<br>
<br>
&nbsp; So if the current frame has no source code, we will step it out till it has source code.
<br>
&nbsp; Make sure that the debuggee has symbol files and source files before you start to debug it<br>
&nbsp; in this sample.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; while (this.MDbgThread.HaveCurrentFrame &&<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; this.MDbgThread.CurrentFrame.SourcePosition == null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; this.Process.MDbgProcess.StepOut().WaitOne();<br>
&nbsp; &nbsp; &nbsp; &nbsp; }<br>
&nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp;public List&lt;ManagedValue&gt; GetLocalVariables(ManagedThread thread)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (thread.MDbgThread.HaveCurrentFrame)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var frame = thread.SourcePositionFrame;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var localVars = frame.Function.GetActiveLocalVars(frame);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var args = frame.Function.GetArguments(frame);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// The compiler will add some additional variables that start with &quot;CS$&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// or &quot;VB$&quot;.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var sourceCodeVars = from value in localVars.Concat(args)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; where !value.Name.StartsWith(&quot;CS$&quot;) && !value.Name.StartsWith(&quot;VB$&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; select new ManagedValue(value);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return sourceCodeVars.ToList();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return null;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;} <br>
<br>
5. Evaluate an expression. The expression format is <br>
&nbsp; a. Instance Method: obj.Method(args)<br>
&nbsp; b. Static Method: Class.Method(args)<br>
&nbsp; <br>
&nbsp; The args should be like following formats<br>
&nbsp; a. Empty<br>
&nbsp; b. Integer : 100<br>
&nbsp; c. String: &nbsp; &quot;Hello World&quot;<br>
&nbsp; d. Generic Type (List&lt;int&gt;): [1,2,3,4] <br>
&nbsp; <br>
&nbsp; To parse the expression, we have to &nbsp;<br>
&nbsp; 5.1 Use regular expressions to get each part of the expression.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; string pattern = @&quot;^(?&lt;obj&gt;.*)\.(?&lt;method&gt;.&#43;)\((?&lt;args&gt;.*)\)$&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Regex rx = new Regex(pattern);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; var match = rx.Match(expression)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; var obj = match.Groups[&quot;obj&quot;].Value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; var method = match.Groups[&quot;method&quot;].Value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; var args = match.Groups[&quot;args&quot;].Value;<br>
<br>
&nbsp; 5.2 Resolve the obj and method.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MDbgValue objValue = process.ResolveVariable(obj, scope);<br>
<br>
&nbsp; &nbsp; &nbsp; If the objValue is not null, we can consider the method is an instance method,<br>
&nbsp; &nbsp; &nbsp; else, it is a static method.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (objValue != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string functionName = string.Format(&quot;{0}.{1}&quot;, objValue.TypeName, method);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;function = process.ResolveFunctionName(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;null,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;objValue.TypeName,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;method,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;scope.Thread.CorThread.AppDomain);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string functionName = string.Format(&quot;{0}.{1}&quot;, obj, method);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;function = process.ResolveFunctionNameFromScope(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;functionName,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;scope.Thread.CorThread.AppDomain);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; <br>
&nbsp; 5.3 Resolve the argument.<br>
&nbsp; &nbsp; &nbsp; a. Determine the argument type. The supported argument types are Empty, System.Int32,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;System.String and System.Collections.Generic.List&lt;System.Int32&gt;<br>
&nbsp; &nbsp; &nbsp; b. Create an Integer value.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; static CorValue CreateIntegerValue(MDbgProcess process, MDbgFrame scope, int arg)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; var eval = scope.Thread.CorThread.CreateEval();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; var value = eval.CreateValue(CorElementType.ELEMENT_TYPE_I4, null).CastToGenericValue();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; value.SetValue(arg);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; return value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; } &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; c. Create a String value.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; static CorValue CreateStringValue(MDbgProcess process, MDbgFrame scope, string arg)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; var eval = scope.Thread.CorThread.CreateEval();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; eval.NewString(arg);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; process.Go().WaitOne();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; if (!(process.StopReason is EvalCompleteStopReason))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; throw new ApplicationException(&quot;Wrong stop reason while evaluating function.&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; return (process.StopReason as EvalCompleteStopReason).Eval.Result.CastToReferenceValue();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; }<br>
&nbsp; &nbsp; &nbsp; d. Create an List&lt;int&gt; value. To create a genric type value (List&lt;Type&gt;) with items,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Step1. Get the constructor.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Step2. Pass the types and other arguments to the constructor.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Step3. Evaluate the System.Collections.Generic.List`1.Add function. &nbsp;
<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;static CorValue CreateGenericTypeValue(MDbgProcess process, MDbgFrame scope, string arg)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var constructor = process.ResolveFunctionName(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;null,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&quot;System.Collections.Generic.List`1&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&quot;.ctor&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;scope.Thread.CorThread.AppDomain);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var intType = process.ResolveType(&quot;System.Int32&quot;);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var eval = scope.Thread.CorThread.CreateEval();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;eval.NewParameterizedObject(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;constructor.CorFunction,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;new CorType[] { intType },<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;new CorValue[0]);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;process.Go().WaitOne();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (!(process.StopReason is EvalCompleteStopReason))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw new ApplicationException(&quot;Wrong stop reason while evaluating function.&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var integerList = (process.StopReason as EvalCompleteStopReason).Eval.Result;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var addFunction = process.ResolveFunctionName(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;null,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&quot;System.Collections.Generic.List`1&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&quot;Add&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;scope.Thread.CorThread.AppDomain);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string[] args = arg.Split(new char[] { '[', ']', ',' },
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;StringSplitOptions.RemoveEmptyEntries);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;for (int i = 0; i &lt; args.Length; i&#43;&#43;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;int intArg = 0;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (int.TryParse(args[i], out intArg))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var value = eval.CreateValue(CorElementType.ELEMENT_TYPE_I4, null).CastToGenericValue();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;value.SetValue(intArg);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;eval.CallParameterizedFunction(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;addFunction.CorFunction,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;new CorType[] { intType },<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;new CorValue[] { integerList, value });<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;process.Go().WaitOne();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (!(process.StopReason is EvalCompleteStopReason))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw new ApplicationException(&quot;Wrong stop reason while evaluating function.&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;} &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return integerList;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
6. Design the MainForm as the UI.<br>
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
