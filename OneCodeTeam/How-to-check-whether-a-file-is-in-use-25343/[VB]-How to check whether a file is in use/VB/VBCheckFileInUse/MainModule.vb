'***************************** Module Header *******************************\ 
' Module Name: MainModule.vb 
' Project: VBCheckFileInUse.proj
' Copyright (c) Microsoft Corporation. 
' 
' The project illustrates how to check whether a file is in use or not.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
'***************************************************************************/ 

Imports System.IO

Module MainModule

    Sub Main()
        Dim fileName As String = ""
        Dim status As String = ""

        While True
            ' Get the filename along with its path 
            Console.WriteLine("Please type a valid file path: (type 'exit' to exit)")

            fileName = Console.ReadLine()
            If fileName.Equals("exit", StringComparison.OrdinalIgnoreCase) Then
                Return
            End If
            If Not File.Exists(fileName) Then
                Console.WriteLine("The file does not exist.")
                Continue While
            End If

            If IsFileInUse(fileName) Then
                status = "File is in use"
            Else
                status = "File is not in use"
            End If
            Console.WriteLine("Status: {0}", status)
        End While
    End Sub

    ' <summary>
    ' This function checks whether the file is in use or not.
    ' </summary>
    ' <param name="filename">File Name</param>
    ' <returns>Return True if file in use else false</returns>

    Public Function IsFileInUse(filename As String) As Boolean
        Dim Locked As Boolean = False
        Try
            ' Open the file in a try block in exclusive mode. 
            ' If the file is in use, it will throw an IOException.
            Dim fs As FileStream = File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)
            fs.Close()
            ' If an exception is caught, it means that the file is in Use
        Catch ex As IOException
            Locked = True
        End Try
        Return Locked
    End Function

End Module
