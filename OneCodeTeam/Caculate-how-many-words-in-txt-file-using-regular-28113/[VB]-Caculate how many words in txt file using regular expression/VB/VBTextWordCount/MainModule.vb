'****************************** Module Header ******************************\
' Module Name:    MainModule.vb
' Project:        VBTextWordCount
' Copyright (c) Microsoft Corporation
'
' The sample demonstrates the following features:
'
' 1. How to calculate how many words in txt file using regular expression.
'
' 2. How to calculate the occurrence count of a word.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports System.Text.RegularExpressions
Imports System.IO

Module MainModule

    Sub Main()
        Dim choice As Integer = 0

        ' Input the text file Location
        Console.Write("Input File Location : ")
        Dim filename As String = Console.ReadLine()
        While choice <> 3
            printMenu()
            Try
                choice = Convert.ToInt32(Console.ReadLine())
                Select Case choice
                    Case 1
                        Console.WriteLine("Total word count = " & totalWords(filename))
                        Exit Select
                    Case 2
                        Console.WriteLine("Enter the specific word : ")
                        Dim word As String = Console.ReadLine()
                        Console.WriteLine("Total word occurrence = " & wordCount(filename, word))
                        Exit Select
                    Case 3
                        Exit Select
                End Select
            Catch e As System.FormatException
                Console.WriteLine("Please enter valid choice!")
            End Try
        End While
    End Sub

    ' <summary>
    ' This function prints the main menu.
    ' </summary>
    Private Sub printMenu()
        Console.WriteLine(vbLf & "1. Calculate Total Number of words in the Input file")
        Console.WriteLine("2. Calculate occurence count of a word")
        Console.WriteLine("3. Exit")
    End Sub

    ' <summary>
    ' This function counts the total number of words in the input text file.
    ' </summary>
    ' <param name="filename">File Name</param>
    ' <returns>Return the total word count</returns>

    Private Function totalWords(filename As String) As Integer
        Dim count As Integer = 0
        Dim sr As New StreamReader(filename)
        Dim input As String
        Dim pattern As String = "\b\w+\b"

        While sr.Peek() >= 0
            input = sr.ReadLine()
            Dim rgx As New Regex(pattern, RegexOptions.IgnoreCase)
            Dim matches As MatchCollection = rgx.Matches(input)
            count += matches.Count
        End While
        sr.Close()
        Return count
    End Function

    ' <summary>
    ' This function counts the number of times a specific word is present in the input text file.
    ' </summary>
    ' <param name="filename">File Name</param>
    ' <returns>Return the word count for a specific word</returns>

    Private Function wordCount(filename As String, word As String) As Integer
        Dim count As Integer = 0
        Dim sr As New StreamReader(filename)
        Dim input As String

        Dim pattern As String = word
        While sr.Peek() >= 0
            input = sr.ReadLine()
            Dim rgx As New Regex(pattern, RegexOptions.IgnoreCase)
            Dim matches As MatchCollection = rgx.Matches(input)
            count += matches.Count
        End While
        sr.Close()
        Return count
    End Function

End Module
