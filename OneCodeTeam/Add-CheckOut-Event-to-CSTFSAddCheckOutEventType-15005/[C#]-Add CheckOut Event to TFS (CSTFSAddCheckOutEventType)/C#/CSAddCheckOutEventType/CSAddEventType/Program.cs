/****************************** Module Header ******************************\
 * Module Name:   Program.cs
 * Project:       CSAddEventType
 * Copyright (c) Microsoft Corporation.
 * 
 * The main method of this application. This application could be used using 2 
 * approaches:
 * 1. Launch this application with valid arguments.
 * 2. Launch this application, and then type the arguments.
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
using System.IO;

namespace CSAddEventType
{
    class Program
    {
        const string helpInfo = @"
Please type the command in following format.
<assembly> <Type> <CollectionName> <EventTypeName> <ToolType>";

        const string schemaNamespace = "http://microsoft.com/VisualStudio";

        static void Main(string[] args)
        {
            string[] inputs = new string[5];
           
            
            if (args.Length == 5)
            {
                args.CopyTo(inputs, 0);
            }
            else
            {

                // Analyze the input and get the valid arguments.
                try
                {
                    Console.WriteLine(helpInfo);
                    string input = Console.ReadLine().Trim();

                    int index = 0;
                    int argumentCount = 0;

                    while (index < input.Length)
                    {
                        if (input[index].Equals('"'))
                        {
                            int nextQuotation = input.IndexOf('"', index + 1);
                            inputs[argumentCount] = input.Substring(index, nextQuotation - index+1);
                            index = nextQuotation + 1;
                            argumentCount++;
                            continue;
                        }
                        else if (input[index].Equals(' '))
                        {
                            int nextSpace = input.IndexOf(' ', index + 1);
                            if (nextSpace == 0)
                            {
                                nextSpace = input.Length;
                            }
                            inputs[argumentCount] = input.Substring(index+1, nextSpace - index-1);
                            index = nextSpace + 1;
                            argumentCount++;
                            continue;
                        }
                        else
                        {
                            int nextSpace = input.IndexOf(' ', index + 1);
                            if (nextSpace < 0 )
                            {
                                nextSpace = input.Length;
                            }
                            inputs[argumentCount] = input.Substring(index, nextSpace - index);
                            index = nextSpace + 1;
                            argumentCount++;
                            continue;
                        }
                    }
                    if (inputs.Length != 5)
                    {
                        Console.WriteLine("Wrong input");
                        return;
                    }
                }
                catch
                {
                    Console.WriteLine("Wrong input");
                    return;
                }
            }

            // Create the folder of output.
            string outputPath = Path.Combine(Environment.CurrentDirectory, "Output");
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }
            Directory.CreateDirectory(outputPath);

            try
            {

                // Generate the schema file.
                string schemaFile = XsdWrapper.GenerateSchemaFile(inputs[0], inputs[1], schemaNamespace, outputPath);
               
                // Get the content of the schema file.
                string schema = File.ReadAllText(schemaFile);

                Console.WriteLine("The schema has been generated.");
               
                // Add the event type to TFS.
                using (EventTypeImporter impoter = new EventTypeImporter(inputs[2]))
                {
                    impoter.AddEventType(inputs[3], inputs[4], schema);
                    Console.WriteLine("The event type has been imported.");
                }           
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
