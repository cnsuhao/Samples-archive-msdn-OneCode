/****************************** Module Header ******************************\
 * Module Name:   XsdWrapper.cs
 * Project:       CSAddEventType
 * Copyright (c) Microsoft Corporation.
 * 
 * This class supplies a method to use xsd.exe to generate a schema.
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Diagnostics;
using System.IO;
using System.Configuration;

namespace CSAddEventType
{
    class XsdWrapper
    {
        /// <summary>
        /// Launch the xsd.exe with assembly, type, namespace and output arguments
        /// </summary>
        public static string GenerateSchemaFile(string assembly, string type, string nameSpace, string outputDir)
        {
            // Start xsd.exe to generate the xsd file.
            ProcessStartInfo xsdStart = new ProcessStartInfo
            {
                Arguments = string.Format("{0} /t:{1} /o:\"{2}\" /n:{3} /nologo",
                assembly, type, outputDir, nameSpace),
                FileName = ConfigurationManager.AppSettings["xsdPath"],
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };

            using (Process xsdProc = Process.Start(xsdStart))
            {
                xsdProc.WaitForExit();

                if (xsdProc.ExitCode != 0)
                {
                    throw new ApplicationException(xsdProc.StandardError.ReadToEnd());
                }


                string[] outputFiles = Directory.GetFiles(outputDir, "*.xsd", SearchOption.TopDirectoryOnly);
                if (outputFiles.Length == 0)
                {
                    throw new ApplicationException("Cannot find the output file");
                }

                return outputFiles[0];
            }

        }
    }
}
