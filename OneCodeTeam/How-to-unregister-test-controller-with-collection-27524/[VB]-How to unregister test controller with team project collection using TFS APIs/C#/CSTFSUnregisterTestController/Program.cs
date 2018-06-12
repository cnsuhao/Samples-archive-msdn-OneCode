/****************************** Module Header ******************************\
 * Module Name:  Program.cs
 * Project:      CSTFSUnregisterTestController
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample shows how to UnRegister test controller with team project 
 * collection using TFS APIs 
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.TestManagement.Client;
using System;
using System.Collections.Generic;

namespace UnregisterTestController
{
    class Program
    {
        public static int selectedController;
        public static string[] listController;
        public static ITestManagementService testManagementService;
        public static IEnumerable<ITestController> testControllers;

        static void Main(string[] args)
        {

            if (args.Length != 1)
            {
                Console.Error.WriteLine("Usage: UnregisterTestController <collectionUrl>");
                Environment.Exit(-1);
            }

            string tfsUri = args[0];
            int i = 0;

            try
            {
                listController = new string[256];

                using (TfsTeamProjectCollection collection = new TfsTeamProjectCollection(new Uri(tfsUri)))
                {
                    testManagementService = collection.GetService<ITestManagementService>();
                    testControllers = testManagementService.TestControllers.Query();


                    foreach (var testController in testControllers)
                    {
                        i = i + 1;

                        Console.Out.Write(i);
                        Console.Out.Write("   ");
                        Console.Out.Write(testController.Name);
                        Console.Out.WriteLine();
                        listController[i - 1] = testController.Name;

                    }

                    // Select the controller which you want to manipulate
                    // So from the list, select the number 1, 2, or..
                    Console.Out.WriteLine("Select the controller you want to manipulate properties for..(select the number above)");

                    selectedController = Int32.Parse(Console.ReadLine());
                    Console.Out.WriteLine(listController[selectedController - 1]);

                    Console.Out.WriteLine("Select any of the below for manipulating the selected controller");
                    Console.Out.WriteLine("1    Register");
                    Console.Out.WriteLine("2    UnRegister");
                    Console.Out.WriteLine("3    Update");

                    int propertyManipulate = Int32.Parse(Console.ReadLine());

                    switch (propertyManipulate)
                    {

                        case 2:
                            selectedController = selectedController - 1;
                            int j = 0;
                            foreach (var testController in testControllers)
                            {
                                if (j == selectedController)
                                {
                                    testController.Unregister();
                                    break;
                                }

                                j = j + 1;

                            }
                            break;

                        case 3:

                            Console.WriteLine("Sorry..Not in the scope of current sample, will be implemented later");

                            break;

                        case 1:

                            Console.WriteLine("Sorry..Not in the scope of current sample, will be implemented later");

                            break;

                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error while performing the operation: " + e.Message);
            }

        }
    }
}

