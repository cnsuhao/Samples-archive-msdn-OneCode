'******************************* Module Header *********************************'
' Module Name:  MainForm.vb
' Project:      VBDetectArgsOfAnotherProcess
' Copyright (c) Microsoft Corporation.
'
' This Project is used to simulate a running process
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*******************************************************************************'
Module MainModule

    Sub Main(ByVal args() As String)

        If args.Length > 0 Then
            For i As Integer = 0 To args.Length - 1
                Console.WriteLine("This is the {0} user input argument: {1}", i + 1, args(i))
            Next
        Else
            Console.WriteLine("No argument was passed in.")
        End If

        Console.ReadLine()

    End Sub

End Module
