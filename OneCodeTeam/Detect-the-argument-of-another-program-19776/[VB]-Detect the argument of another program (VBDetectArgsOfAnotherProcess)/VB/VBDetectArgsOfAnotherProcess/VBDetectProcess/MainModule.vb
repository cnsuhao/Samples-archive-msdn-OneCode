'******************************* Module Header *********************************'
' Module Name:  MainForm.vb
' Project:      VBDetectArgsOfAnotherProcess
' Copyright (c) Microsoft Corporation.
'
' This project demonstrates how to get the argument of another running application.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*******************************************************************************'
Imports System.Management

Module MainModule

    Sub Main()

        Do
            Console.WriteLine("Please enter the process name: ")
            Dim processName As String = Console.ReadLine()

            ' Create a WMI Query
            Dim wmiQuery As String = String.Format("select CommandLine from Win32_Process where Name='{0}'", processName)

            ' Create a ManagementObjectSearcher to retrieve a collection of management objects
            ' based on a specified query
            Using searcher As New ManagementObjectSearcher(wmiQuery)
                ' Get the query result
                Dim results As ManagementObjectCollection = searcher.Get()

                If results.Count <> 0 Then
                    ' Output the CommandLine property of the process
                    For Each result As ManagementObject In results
                        Dim CommandLine As String = result("CommandLine").ToString()
                        Console.WriteLine()
                        Console.WriteLine("The arguments of this process are:" & vbLf & " {0}", CommandLine)
                    Next
                    Console.WriteLine()
                    Console.WriteLine("Press any key to continue, press 'Q' to exit.")
                    Console.WriteLine()
                Else
                    Console.WriteLine()
                    Console.WriteLine("This process couldn't be found. Press any key to continue, press 'Q' to exit.")
                    Console.WriteLine()
                End If
            End Using
        Loop While Console.ReadKey().Key <> ConsoleKey.Q

    End Sub

End Module
