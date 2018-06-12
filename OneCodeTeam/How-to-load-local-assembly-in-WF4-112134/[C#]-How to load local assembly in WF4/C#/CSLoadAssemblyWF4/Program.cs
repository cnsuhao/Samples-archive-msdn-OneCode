using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Xaml;
using System.Activities.XamlIntegration;

namespace CSLoadAssemblyWF4
{
    //****************************** Module Header ******************************\
    //Module Name:    Program.cs
    //Project:        CSLoadAssemblyWF4
    //Copyright (c) Microsoft Corporation

    // The project illustrates how to check whether a file is in use or not.

    //This source is subject to the Microsoft Public License.
    //See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
    //All other rights reserved.

    //*****************************************************************************/

    class Program
    {
        static void Main(string[] args)
        {
            // Sepcify LocalAssembly in XamlXmlReaderSettings
            XamlReader reader = new XamlXmlReader(@"..\..\..\ActivityLibrarySample\SampleActivity.xaml", new XamlXmlReaderSettings { LocalAssembly = typeof(ActivityLibrarySample.SampleActivity).Assembly });

            // Read the xaml contents
            XamlReader xamlReader = ActivityXamlServices.CreateReader(reader);
            
            // Invoke the workflow XAML data
            WorkflowInvoker.Invoke(ActivityXamlServices.Load(xamlReader));

            Console.WriteLine("Activity library successfully imported !!!");

            Console.ReadLine();
        }
    }
}
