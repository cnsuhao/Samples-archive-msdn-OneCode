/****************************** Module Header ******************************\
* Module Name:    Program.cs
* Project:        CSProcess
* Copyright (c) Microsoft Corporation
*
* This Project is used to simulate a running process
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
*
\*****************************************************************************/
using System;

namespace CSProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check if there are arguments passed into the Main method
            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine("This is the {0} user input argument: {1}", i + 1, args[i]);
                }
            }
            else
            {
                Console.WriteLine("No argument was passed in.");
            }
            Console.ReadLine();
        }
    }
}
