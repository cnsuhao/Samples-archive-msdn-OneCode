Imports System.Activities
Imports System.Activities.Statements
Imports System.Diagnostics
Imports System.Linq
Imports System.Xaml
Imports System.Activities.XamlIntegration

Module Module1

    '****************************** Module Header ******************************\
    'Module Name:    Module1.vb
    'Project:        VBLoadAssemblyWF4
    'Copyright (c) Microsoft Corporation

    'The project illustrates how to check whether a file is in use or not.

    'This source is subject to the Microsoft Public License.
    'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
    'All other rights reserved.

    '*****************************************************************************/

    Sub Main()

        ' Sepcify LocalAssembly in XamlXmlReaderSettings
        Dim reader As XamlReader = New XamlXmlReader("..\..\..\ActivityLibrarySample\SampleActivity.xaml", New XamlXmlReaderSettings() With { _
              .LocalAssembly = GetType(ActivityLibrarySample.SampleActivity).Assembly _
        })

        ' Read the xaml contents
        Dim xamlReader As XamlReader = ActivityXamlServices.CreateReader(reader)

        ' Invoke the workflow XAML data
        WorkflowInvoker.Invoke(ActivityXamlServices.Load(xamlReader))

        Console.WriteLine("Activity library successfully imported !!!")

        Console.ReadLine()

    End Sub

End Module
