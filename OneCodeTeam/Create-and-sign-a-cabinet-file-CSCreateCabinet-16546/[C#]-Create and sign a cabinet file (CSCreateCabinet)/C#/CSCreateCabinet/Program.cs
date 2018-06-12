/****************************** Module Header ******************************\
 * Module Name:  Program.cs
 * Project:      CSCreateCabinet
 * Copyright (c) Microsoft Corporation.
 * 
 * The Console UI of this application.
 * Use can type following commands:
 * 
 *  pack <cabfile> <sourcefolder>
 *  unpack <cabfile> <destiFolder>
 *  sign <cabfile> <pfxFile> <password>
 *  verify <cabfile>";
 * 
 * This application also supports command line arguments.
 *  
 *     CSCreateCabinet pack <cabfile> <sourcefolder>
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
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CSCreateCabinet
{
    class Program
    {

        // Some Error....
        const string helpMsg = @"
Type command in following formats:
    pack <cabfile> <sourcefolder>
    unpack <cabfile> <destiFolder>
    sign <cabfile> <pfxFile> <password>
    verify <cabfile>";


        static void Main(string[] args)
        {
            try
            {

                // Arguments are supplied.
                if (args == null && args.Length != 0)
                {
                    bool flag = Run(args);
                    Environment.ExitCode = flag ? 0 : 100;
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine(helpMsg);
                        string input = Console.ReadLine();
                        string[] arguments = null;
                        if (ResolveArguments(input, out arguments))
                        {
                            Run(arguments);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Resolve the input as the arguments.
        /// For example, [pack d:\temp\my.cab "C:\My folder"] will be recognized as 
        /// args[0] = pack
        /// args[1] = d:\temp\my.cab
        /// args[2] = c:\My Folder
        /// </summary>
        static bool ResolveArguments(string input, out string[] args)
        {
            input = input.Trim();
            if (string.IsNullOrEmpty(input))
            {
                args = null;
                return false;
            }

            // Match "<some words>" first, and then use whitespace to split the 
            // input.
            string pattern = @"("".+?"" )|("".+?""$)|(.+? )|(.+?$)";

            var matches = Regex.Matches(input, pattern);

            if (matches != null)
            {
                var argList = new List<string>();
                foreach (Match match in matches)
                {
                    argList.Add(match.Value.Replace("\"", string.Empty).Trim());
                }
                args = argList.ToArray();
                return true;
            }
            else
            {
                args = null;
                return false;
            }
        }

        /// <summary>
        /// Run the method specified by the first argument.
        /// </summary>
        /// <returns>
        /// True if the method runs successfully.
        /// </returns>
        static bool Run(string[] args)
        {
            try
            {
                switch (args[0].ToLower())
                {
                    case "pack":
                        if (args.Length == 3)
                        {
                            RunPackMethod(args[1], args[2]);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Please use this format:");
                            Console.WriteLine("    pack cabfile sourcefolder");
                            return false;
                        }
                    case "unpack":
                        if (args.Length == 3)
                        {
                            RunUnpackMethod(args[1], args[2]);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Please use this format:");
                            Console.WriteLine("    unpack cabfile destifolder");
                            return false;
                        }
                    case "sign":
                        if (args.Length == 4)
                        {
                            RunSignMethod(args[1], args[2], args[3]);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Please use this format:");
                            Console.WriteLine("    sign cabfile pfxFile password");
                            return false;
                        }
                    case "verify":
                        if (args.Length == 2)
                        {
                            RunVerifyMethod(args[1]);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Please use this format:");
                            Console.WriteLine("    verify cabfile");
                            return false;
                        }
                    default:
                        return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Pack a folder to the cabinet.
        /// </summary>
        static void RunPackMethod(string cabFilePath, string sourceFolder)
        {
            try
            {
                SignableCabinetPackage pkg = SignableCabinetPackage.LoadOrCreateCab(cabFilePath);
                pkg.Pack(
                    sourceFolder,
                    true,
                    Microsoft.Deployment.Compression.CompressionLevel.Normal,
                    ProcessHandle);
                Console.WriteLine("Packing cabinet succeeded.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Packing cabinet failed.");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Unpack files from a cabinet.
        /// </summary>
        static void RunUnpackMethod(string cabFilePath, string destinationFolder)
        {
            try
            {
                SignableCabinetPackage pkg = SignableCabinetPackage.LoadCab(cabFilePath);
                pkg.Unpack(destinationFolder, ProcessHandle);
                Console.WriteLine("Unpacking cabinet succeeded.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unpacking cabinet failed.");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Sign a cabinet.
        /// </summary>
        static void RunSignMethod(string cabFilePath, string pfxFilePath, string password)
        {
            try
            {
                SignableCabinetPackage pkg = SignableCabinetPackage.LoadCab(cabFilePath);
                pkg.Sign(pfxFilePath, password);
                Console.WriteLine("Cabinet signature succeeded.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cabinet signature failed.");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Verify the signature of a cabinet.
        /// </summary>
        static void RunVerifyMethod(string cabFilePath)
        {
            try
            {
                SignableCabinetPackage pkg = SignableCabinetPackage.LoadCab(cabFilePath);
                pkg.Verify();
                Console.WriteLine("Cabinet signature verification succeeded.");
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                Console.WriteLine("Cabinet signature verification failed.");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Handle the event that a file is being processed. 
        /// </summary>
        static void ProcessHandle(object sender, Microsoft.Deployment.Compression.ArchiveProgressEventArgs e)
        {
            
        }
    }
}
