'****************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBTFSUnregisterTestController
' Copyright (c) Microsoft Corporation.
'
' This sample demonstrates how to unregister Test Controller from team project 
' collection using TFS APIs.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Imports System
Imports Microsoft.TeamFoundation.Client
Imports Microsoft.TeamFoundation.TestManagement.Client
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks


Module UnregisterTestControllerVB


    Class Program
        Public Shared selectedController As Integer
        Public Shared listController As String()
        Public Shared testManagementService As ITestManagementService
        Public Shared testControllers As IEnumerable(Of ITestController)


        Public Shared Sub Main(args As String())
            If args.Length <> 1 Then
                Console.[Error].WriteLine("Usage: UnregisterTestControllerVB <collectionUrl>")
                Environment.[Exit](-1)
            End If
            Dim tfsUri As String = args(0)
            Dim i As Integer = 0
            Try
                listController = New String(255) {}
                Using collection As New TfsTeamProjectCollection(New Uri(tfsUri))
                    TestManagementService = collection.GetService(Of ITestManagementService)()
                    testControllers = TestManagementService.TestControllers.Query()
                    For Each testController In testControllers
                        i = i + 1
                        Console.Out.Write(i)
                        Console.Out.Write("   ")
                        Console.Out.Write(testController.Name)
                        Console.Out.WriteLine()
                        listController(i - 1) = testController.Name
                    Next
                    ' Select the controller which you want to manipulate  
                    ' So from the list, select the number 1, 2, or..   
                    Console.Out.WriteLine("Select the controller you want to manipulate properties for..(select the number above)")
                    selectedController = Int32.Parse(Console.ReadLine())
                    Console.Out.WriteLine(listController(selectedController - 1))
                    Console.Out.WriteLine("Select any of the below for manipulating the selected controller")
                    Console.Out.WriteLine("1    Register")
                    Console.Out.WriteLine("2    Unregister")
                    Console.Out.WriteLine("3    Update")
                    Dim propertyManipulate As Integer = Int32.Parse(Console.ReadLine())
                    Select Case propertyManipulate


                        Case 2
                            selectedController = selectedController - 1
                            Dim j As Integer = 0
                            For Each testController In testControllers

                                If j = selectedController Then

                                    testController.Unregister()
                                    Exit For
                                End If
                                j = j + 1
                            Next
                            Exit Select
                        Case 3
                            Console.WriteLine("Sorry..Not in the scope of current sample, will be implemented later")
                            Exit Select
                        Case 1
                            Console.WriteLine("Sorry..Not in the scope of current sample, will be implemented later")
                            Exit Select
                    End Select
                End Using
            Catch ex As Exception
                Console.WriteLine("Error while performing the operation: " & ex.Message)
            End Try

        End Sub
    End Class
End Module

