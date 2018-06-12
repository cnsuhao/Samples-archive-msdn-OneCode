
/***************************************************************************

THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR 
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.TestManagement.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterTestController
{
    class Program
    {
        public static int selectedController;
        public static string[] listController;
        public static ITestManagementService testManagementService;
        public static IEnumerable<ITestController> testControllers;
        //  public static IEnumerable<ITestController> testControllertoregister;


        static void Main(string[] args)
        {

            if (args.Length != 1)
            {
                Console.Error.WriteLine("Usage: FindTestControllers <collectionUrl>");
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

                Console.Out.WriteLine("Select any of the below for manipulat for the selected controller");
                Console.Out.WriteLine("1    Register");
                Console.Out.WriteLine("2    Unregister");
                Console.Out.WriteLine("3    Update");

                int propertyManipulate = Int32.Parse(Console.ReadLine());

                switch (propertyManipulate)
                {

                    case 2: 
                        
                        Console.WriteLine("Sorry..Not in the scope of current sample, will be implemente later");

                        break;

                    case 3:
                        Console.WriteLine("Sorry..Not in the scope of current sample, will be implemente later");

                            break;

                    case 1:
                        string controllerName = Console.ReadLine();

                        ITestManagementService testManagementService1;
                        ITestController testControllers2;
                        using (TfsTeamProjectCollection collection1 = new TfsTeamProjectCollection(new Uri(tfsUri)))
                        {
                            testManagementService1 = collection1.GetService<ITestManagementService>();
                            //testControllers1 = testManagementService1.TestControllers.Query();
                            testControllers2 = testManagementService1.TestControllers.Create();
                            testControllers2.Name = controllerName;
                            List<ITestController> icollection = new List<ITestController>();
                            icollection.Add(testControllers2);
                            testManagementService1.TestControllers.Register(icollection);
                        }

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
