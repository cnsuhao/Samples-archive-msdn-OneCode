/****************************** Module Header ******************************\
* Module Name:    Program.cs
* Project:        CSCheckFileInUse
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to check whether a file is in use or not.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
* All other rights reserved.
*
\*****************************************************************************/
using System;
using System.IO;

namespace CSCheckFileInUse
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = string.Empty;
            string status = string.Empty;

            while (true)
            {
                Console.WriteLine("Please type a valid file path: (type 'exit' to exit)");

                fileName = Console.ReadLine();
                if (fileName.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }
                if (!File.Exists(fileName))
                {
                    Console.WriteLine("The file does not exist.");
                    continue;
                }
                
                if (FileInUse.IsFileInUse(fileName))
                {
                    status = "File is in use";
                }
                else
                {
                    status = "File is not in use";
                }
                Console.WriteLine("Status: {0}", status);
            }
        }
    }
}
