'**************************** Module Header ******************************\
' Module Name:  UserInfo.vb
' Project:      VBO365GetInboxRules
' Copyright (c) Microsoft Corporation.
' 
' Currently, most of you manage email messages by inbox rules. Especially, 
' when you become an owner of a shared mailbox, you find the former owner created 
' a lot of inbox rules to manage email messages efficiently. But you need to modify 
' these inbox rules to meet the new business needs. Before changing these inbox 
' rules, you want to find a solution to document these inbox rules in case something 
' goes wrong. But you don't have an out-of-box solution.
' In this application, we will demonstrate how to get Inbox rules in Office 365.
' This file includes the class that stores the user information.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Linq

Namespace VBO365GetInboxRules
    Public Class UserInfo
        Private accountInfo As String = Nothing
        Private pwdInfo As String = Nothing

        ' When we create the user, we get the information of the account.
        Public Sub New()
            SetUserInfo()
        End Sub

        Public Sub SetUserInfo()
            Console.WriteLine("Please input your account and password.")

            Console.Write("Account:")
            Dim accountName As String = Console.ReadLine()

            Console.Write("Password:")
            Dim password As IList(Of Char) = New List(Of Char)()

            Dim top As Integer = Console.CursorTop
            Do
                Dim left As Integer = Console.CursorLeft
                Dim info As ConsoleKeyInfo = Console.ReadKey()

                If info.Key = ConsoleKey.Enter OrElse (info.Key <> ConsoleKey.Backspace AndAlso
                                                       info.Key <> ConsoleKey.Escape AndAlso
                                                       info.Key <> ConsoleKey.Tab AndAlso
                                                       info.KeyChar <> ControlChars.NullChar) Then
                    If password.Count > 0 Then
                        Console.SetCursorPosition(left - 1, top)

                        Console.Write("*")

                        Console.SetCursorPosition(left + 1, top)
                    End If

                    If info.Key = ConsoleKey.Enter Then
                        Console.WriteLine()

                        Exit Do
                    Else
                        password.Add(info.KeyChar)
                    End If
                ElseIf info.Key = ConsoleKey.Backspace Then
                    If password.Count > 0 Then
                        password.RemoveAt(password.Count - 1)
                        If password.Count > 0 Then
                            Console.SetCursorPosition(left - 2, top)
                            Console.Write(AscW(password(password.Count - 1)) & " ")
                        Else
                            Console.SetCursorPosition(left - 1, top)
                            Console.Write(" ")
                        End If

                        Console.SetCursorPosition(left - 1, top)
                    Else
                        Console.SetCursorPosition(left, top)
                    End If
                End If
            Loop

            accountInfo = accountName
            pwdInfo = New String(password.ToArray())

            If String.IsNullOrWhiteSpace(accountInfo) OrElse String.IsNullOrWhiteSpace(Pwd) Then
                Console.WriteLine("Can't input the empty account or password," & " please input the right account and password.")
                Console.WriteLine()
                SetUserInfo()
            End If
        End Sub

        Public ReadOnly Property Account() As String
            Get
                Return accountInfo
            End Get
        End Property

        Public ReadOnly Property Pwd() As String
            Get
                Return pwdInfo
            End Get
        End Property
    End Class
End Namespace
