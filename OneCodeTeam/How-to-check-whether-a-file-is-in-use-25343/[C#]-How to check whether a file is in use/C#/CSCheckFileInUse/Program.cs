/****************************** Module Header ******************************\
* Module Name:    Program.cs
* Project:        CSCheckFileInUse
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to check whether a file is in use or not.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
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
                // Get the filename along with its path 
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
              
                if (IsFileInUse(fileName))
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

        // <summary>
        // This function checks whether the file is in use or not.
        // </summary>
        // <param name="filename">File Name</param>
        // <returns>Return True if file in use else false</returns>

        public static bool IsFileInUse(string filename)
        {
            bool Locked = false;
            try
            {
                // Open the file in a try block in exclusive mode. 
                // If the file is in use, it will throw an IOException.
                FileStream fs =
                    File.Open(filename, FileMode.OpenOrCreate,
                    FileAccess.ReadWrite, FileShare.None);
                fs.Close();
            }
            // If an exception is caught, it means that the file is in Use
            catch (IOException ex)
            {
                Locked = true;
            }
            return Locked;
        }
    }
}
