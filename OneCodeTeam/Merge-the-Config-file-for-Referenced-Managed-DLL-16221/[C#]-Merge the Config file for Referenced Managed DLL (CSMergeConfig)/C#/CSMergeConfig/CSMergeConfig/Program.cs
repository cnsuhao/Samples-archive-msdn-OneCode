/****************************** Module Header ******************************\
 Module Name:    Program.cs
 Project:        CSMergeConfig
 Copyright (c) Microsoft Corporation

 CSMergeConfig ---> a console application
 ServiceRefenreceddll---> C# class library that has a service reference.
 
This program is a generic sample for a scenario where the config file of the 
dll needs to be merged with the Console application so that the Configaration 
of the class library can be accessed during application run to initialize the class. 

Purpose of the sample:

Merging the configuration file for a referenced managed dll with the console 
application such that the Specified Section from the config file of Class Library 
will be merged with the console application. 

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Linq;
using System.Reflection;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Xml;
using System.Xml.Linq;


namespace CSMergeConfig
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var doc = XElement.Load(@"ServiceReferenceddll.dll.config");

                var query = from ele in doc.Elements("system.serviceModel")
                            select ele;

                var doc1 = XElement.Load(@"..\CSMergeConfig\App.config");

                var node1 = doc.Descendants("system.serviceModel").FirstOrDefault();
                var node2 = doc1.Descendants("system.serviceModel").FirstOrDefault();

                XNode node = doc1.Element("system.serviceModel");

                // Lets iterate the node of the console until the last node is reached 
                if (!XElement.DeepEquals(node1, node2))
                {
                    node2.Add(node1.Nodes());
                    doc1.Save(@"..\CSMergeConfig\App.config");
                }

                // This piece if code loaded the class library which has the service reference
                // and instantiates the class object 
                // Note that, this initialization will throw a target invocation Exception 
                // if the config file of dll is not loaded when the console application is run. 
                // Once the App.config of the Application is merged with the required node of 
                // class library, we will see that the application runs fine. 

                Assembly a = Assembly.LoadFrom("ServiceReferenceddll.dll");

                var o = Activator.CreateInstance(a.GetType("ServiceReferenceddll.Class1"));
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine("The specified directory does not exist. {0}", e);
            }
            catch (System.Reflection.TargetInvocationException e)
            {
                Console.WriteLine("Configuration for the dll is not merged with the executable, try running it again and the issue should go away, if not, contact the developer {0}", e);
            }

        }
    }
}
