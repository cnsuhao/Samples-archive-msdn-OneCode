using System;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Collections;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace CSMDbgTargetApp
{
    class Program
    {

        const string newThreadCmd = "t";
        const string newAppDomainCmd = "ad";
        const string unloadAppDomainCmd = "uad";
        const string throwExceptionCmd = "err";
        const string logMessageCmd = "log";

        static ReadOnlyCollection<string> allowedCmdList = new ReadOnlyCollection<string>(
            new string[] {
                newThreadCmd ,
                newAppDomainCmd ,
                unloadAppDomainCmd ,
                throwExceptionCmd,
                logMessageCmd});

        const string helpMsg =
@"Choose an activity:
t: Create a thread. Syntax: 
   t [-list]
   
ad: Create an appdomain. Syntax:
   ad [friendly name | -list ]

uad: Unload an appdomain. Syntax:
   uad [app domain friendly name | -list ]

err: Throw an exception. Syntax:
   err <error message>

log: Add a log. Syntax:
   log <message>

help: Print this help message again.
   help | ? 
  
";

        static Dictionary<string, AppDomain> appDomains = new Dictionary<string, AppDomain>();

        static void Main(string[] args)
        {
            appDomains.Add(AppDomain.CurrentDomain.FriendlyName, AppDomain.CurrentDomain);

            try
            {
                Console.WriteLine(helpMsg);

                while (true)
                {
                    string input = Console.ReadLine();
                    string cmd = null;
                    string arguments = null;
                    TryParseCommand(input, out cmd, out arguments);

                    switch (cmd.ToLower())
                    {
                        case newThreadCmd:
                            ThreadCmd(arguments);
                            break;
                        case newAppDomainCmd:
                            NewAppDomainCmd(arguments);
                            break;
                        case unloadAppDomainCmd:
                            UnloadAppDomainCmd(arguments);
                            break;
                        case throwExceptionCmd:
                            ThrowExceptionCmd(arguments);
                            break;
                        case logMessageCmd:
                            LogCmd(arguments);
                            break;
                        case "help":
                        case "?":
                            Console.WriteLine(helpMsg);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }


        static void TryParseCommand(string input, out string commandName,
            out string commandArguments)
        {
            var commandLineText = input.Trim();
            int length = commandLineText.Length;
            int index = 0;
            while ((index < length) && !char.IsWhiteSpace(commandLineText, index))
            {
                index++;
            }
            commandName = commandLineText.Substring(0, index);
            commandArguments = commandLineText.Substring(index).Trim();
        }


        static void ThreadCmd(string arguments)
        {
            if (string.IsNullOrWhiteSpace(arguments))
            {
                Thread newThread = new Thread(new ThreadStart(SleepThread));
                newThread.Start();
            }
            else if (arguments.Equals("-list", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Print all threads:");

                foreach (ProcessThread procThread in Process.GetCurrentProcess().Threads)
                {
                    Console.WriteLine("\tThread ID: {0} State:{1} WaitReason:{2}",
                        procThread.Id, procThread.ThreadState,
                        procThread.ThreadState == System.Diagnostics.ThreadState.Wait? procThread.WaitReason.ToString():string.Empty);

                }
            }
        }

        static void SleepThread()
        {
            Console.WriteLine("Create thread : {0}", NativeMethods.GetCurrentThreadId());
            Thread.Sleep(5000);
            Console.WriteLine("Exit thread : {0}", NativeMethods.GetCurrentThreadId());
        }


        static void NewAppDomainCmd(string arguments)
        {

            if (string.IsNullOrWhiteSpace(arguments)
                || arguments.Equals("-list", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Print all AppDomains:");

                foreach (var item in appDomains)
                {
                    Console.WriteLine("\tAppDomain ID:{0} FriendlyName :{1}",
                        item.Value.Id,item.Value.FriendlyName);
                }
            }
            else if (!appDomains.ContainsKey(arguments))
            {
                var appDomain = AppDomain.CreateDomain(arguments);
                appDomains.Add(arguments, appDomain);
                Console.WriteLine("Create AppDomain : {0} {1}",
                    appDomain.Id,
                    appDomain.FriendlyName);
            }
            else
            {
                Console.WriteLine("There is already an AppDomain with this name.");
            }
        }

        static void UnloadAppDomainCmd(string arguments)
        {
            if (string.IsNullOrWhiteSpace(arguments) 
                || arguments.Equals("-list",StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Print all AppDomains:");

                foreach (var item in appDomains)
                {
                    Console.WriteLine("\tAppDomain ID:{0} FriendlyName :{1}",
                        item.Value.Id, item.Value.FriendlyName);
                }
            }
            else if (appDomains.ContainsKey(arguments))
            {
                AppDomain.Unload(appDomains[arguments]);
                appDomains.Remove(arguments);
                Console.WriteLine("Unload AppDomain : {0}", arguments);
            }
            else
            {
                Console.WriteLine("No AppDomain with this name.");
            }
        }

        static void ThrowExceptionCmd(string msg)
        {

            if (string.IsNullOrWhiteSpace(msg))
            {
                msg = "Default Exception.";
            }

            try
            {
                throw new Exception(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static void LogCmd(string msg)
        {
            if (string.IsNullOrWhiteSpace(msg))
            {
                Debugger.Log(0, "Default Category", "Default Message.");
            }
            else
            {
                Debugger.Log(0, "Default Category", msg);
            }
        }

    }
}
