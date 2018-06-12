/****************************** Module Header ******************************\
* Module Name:    Program.cs
* Project:        CSDetectProcess
* Copyright (c) Microsoft Corporation
*
* This project demonstrates how to get the argument of another running application.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
*
\*****************************************************************************/
using System;
using System.Management;

namespace CSDetectArgsOfAnotherProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Please enter the process name: ");
                string processName = Console.ReadLine();

                // Create a WMI Query
                string wmiQuery = string.Format("select CommandLine from Win32_Process where Name='{0}'", processName);

                // Create a ManagementObjectSearcher to retrieve a collection of management objects
                // based on a specified query
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiQuery))
                {
                    // Get the query result
                    ManagementObjectCollection results = searcher.Get();

                    if (results.Count != 0)
                    {
                        // Output the CommandLine property of the process
                        foreach (ManagementObject result in results)
                        {
                            string CommandLine = result["CommandLine"].ToString();
                            Console.WriteLine();
                            Console.WriteLine("The arguments of this process are:\n {0}", CommandLine);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue, press 'Q' to exit.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("This process couldn't be found. Press any key to continue, press 'Q' to exit.");
                        Console.WriteLine();
                    }
                }
            }
            while (Console.ReadKey().Key != ConsoleKey.Q);
        }
    }
}
