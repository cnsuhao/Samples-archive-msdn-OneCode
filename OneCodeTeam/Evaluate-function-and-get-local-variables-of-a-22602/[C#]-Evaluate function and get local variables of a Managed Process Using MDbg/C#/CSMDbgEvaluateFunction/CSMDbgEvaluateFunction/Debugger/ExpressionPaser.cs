/****************************** Module Header ******************************\
 * Module Name:  ExpressionPaser.cs
 * Project:      CSMDbgEvaluateFunction
 * Copyright (c) Microsoft Corporation.
 * 
 * The class is used to parse the expression to a function with arguments.
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Text.RegularExpressions;
using Microsoft.Samples.Debugging.CorDebug;
using Microsoft.Samples.Debugging.CorDebug.NativeApi;
using Microsoft.Samples.Debugging.MdbgEngine;

namespace CSMDbgEvaluateFunction.Debugger
{
    public class ExpressionPaser
    {

        /// <summary>
        /// This paser only supports function with the supported parameter types.
        /// </summary>
        /// <param name="expression">
        /// Description: The expression format is 
        /// 1. Instance Method: obj.Method(args)
        /// 2. Static Method: Class.Method(args)
        /// 
        /// The args should be like following formats
        /// 1. Empty
        /// 2. Integer : 100
        /// 3. String:   "Hello World"
        /// 4. Generic Type (List<int>): [1,2,3,4] 
        /// </param>
        /// <returns>
        /// True: Parse successfully.
        /// </returns>
        public static bool TryParse(
            MDbgProcess process,
            MDbgFrame scope,
            string expression,
            out MDbgFunction function,
            out CorValue[] arguments
            )
        {

            // Determine whether the expression match the supported format.
            string pattern = @"^(?<obj>.*)\.(?<method>.+)\((?<args>.*)\)$";

            Regex rx = new Regex(pattern);
            var match = rx.Match(expression);

            if (match == null)
            {
                function = null;
                arguments = null;
                return false;
            }

            try
            {

                // For instance method, get the instance, method name and arguments.
                // Like this.StringMethod("Hello world")
                // For static method, obj.method is the full name of the method.
                // Like System.Diagnostics.Process.GetCurrentProcess()
                var obj = match.Groups["obj"].Value;
                var method = match.Groups["method"].Value;
                var args = match.Groups["args"].Value;

                // Resolve the instance.
                MDbgValue objValue = process.ResolveVariable(obj, scope);

                // Parse the arguments to CorValue.
                CorValue argumentValue = GetArguments(process, scope, args);

                // The function is an instance method.
                if (objValue != null)
                {

                    // Resolve the function name.
                    string functionName = string.Format("{0}.{1}", objValue.TypeName, method);
                    function = process.ResolveFunctionName(
                        null,
                        objValue.TypeName,
                        method,
                        scope.Thread.CorThread.AppDomain);

                    // For instance method, the first argument is the instance.
                    if (argumentValue != null)
                    {
                        arguments = new CorValue[] { objValue.CorValue, argumentValue };
                    }
                    else
                    {
                        arguments = new CorValue[] { objValue.CorValue };
                    }
                }
                // The function is a static method.
                else
                {

                    // Resolve the function name.
                    string functionName = string.Format("{0}.{1}", obj, method);
                    function = process.ResolveFunctionNameFromScope(
                        functionName,
                        scope.Thread.CorThread.AppDomain);

                    if (argumentValue != null)
                    {
                        arguments = new CorValue[] { argumentValue };
                    }
                    else
                    {
                        arguments = new CorValue[0];
                    }
                }

                return function != null && arguments != null;
            }
            catch
            {
                function = null;
                arguments = null;
                return false;
            }
        }

        /// <summary>
        /// Parse the arguments to CorValue
        /// </summary>
        private static CorValue GetArguments(
            MDbgProcess process,
            MDbgFrame scope,
            string arguments)
        {
            
            // The arguments format is like [1,2,3], then convert is to a List<int> object.
            string listPattern = @"\[(\d+,)+\d+\]";

            // The arguments format is like "Hello world", then convert is to a string object.
            string stringPattern = @""".*""";

            // The arguments format is like 1234, then convert is to a Int32 object.
            string intPattern = @"\d+";

            if (Regex.IsMatch(arguments, listPattern))
            {
                var value = CreateGenericTypeValue(process, scope, arguments);
                return value;
            }
            else if (Regex.IsMatch(arguments, stringPattern))
            {
                var value = CreateStringValue(process, scope, arguments.Substring(1, arguments.Length - 2));
                return value;
            }
            else if (Regex.IsMatch(arguments, intPattern))
            {
                var value = CreateIntegerValue(process, scope, int.Parse(arguments));
                return value;
            }
            else
            {
                return null;
            }


        }

        /// <summary>
        /// Create an Integer value.
        /// </summary>
        private static CorValue CreateIntegerValue(MDbgProcess process, MDbgFrame scope, int arg)
        {
            var eval = scope.Thread.CorThread.CreateEval();
            var value = eval.CreateValue(CorElementType.ELEMENT_TYPE_I4, null).CastToGenericValue();
            value.SetValue(arg);
            return value;
        }

        /// <summary>
        /// Create a String value.
        /// </summary>
        private static CorValue CreateStringValue(MDbgProcess process, MDbgFrame scope, string arg)
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

        /// <summary>
        /// Create an List<int> value.
        /// To create a genric type value (List<Type>) with items,
        /// 1. Get the constructor.
        /// 2. Pass the types and other arguments to the constructor.
        /// 3. Evaluate the System.Collections.Generic.List`1.Add function.
        /// </summary>
        private static CorValue CreateGenericTypeValue(MDbgProcess process, MDbgFrame scope, string arg)
        {

            // Get the constructor of List<T>.
            var constructor = process.ResolveFunctionName(
                null,
                "System.Collections.Generic.List`1",
                ".ctor",
                scope.Thread.CorThread.AppDomain);

            // Get the Type of T (System.Int32).
            var intType = process.ResolveType("System.Int32");

            // Evaluate the constructor to create a List<int> object.
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

            // Get the result of the constructor.
            var integerList = (process.StopReason as EvalCompleteStopReason).Eval.Result;

            // Resolve the System.Collections.Generic.List`1.Add method.
            var addFunction = process.ResolveFunctionName(
                null,
                "System.Collections.Generic.List`1",
                "Add",
                scope.Thread.CorThread.AppDomain);

            // Split "[1,2,3]" to a String array.
            string[] args = arg.Split(new char[] { '[', ']', ',' }, 
                StringSplitOptions.RemoveEmptyEntries);

            // Add the items to the integerList.
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
    }
}
