'****************************** Module Header **********************************'
' Module Name:  MainModule.vb
' Project:      VBMailslotClient
' Copyright (c) Microsoft Corporation.
' 
' Mailslot is a mechanism for one-way inter-process communication in the local machine
' or across the computers in the intranet. Any clients can store messages in a mailslot. 
' The creator of the slot, i.e. the server, retrieves the messages that are stored 
' there:
' 
' Client (GENERIC_WRITE) ---> Server (GENERIC_READ)
' 
' This sample demonstrates a mailslot client that connects and writes to the mailslot 
' "\\.\mailslot\SampleMailslot". 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*********************************************************************************'

Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.ComponentModel


Friend Module MainModule
    ' The full name of the mailslot is in the format of \\.\mailslot\[path]name
    ' The name field must be unique. The name may include multiple levels of 
    ' pseudo directories separated by backslashes. For example, both 
    ' \\.\mailslot\mailslot_name and \\.\mailslot\abc\def\ghi are valid.
    Friend Const MailslotName As String = "\\.\mailslot\SampleMailslot"


    Sub Main(ByVal args() As String)
        Dim hMailslot As NativeMethods.SafeMailslotHandle = Nothing

        Try
            ' Try to open the mailslot with the write access.
            hMailslot = NativeMethods.CreateFile(MailslotName, _
                                                 NativeMethods.FileDesiredAccess.GENERIC_WRITE, _
                                                 NativeMethods.FileShareMode.FILE_SHARE_READ, _
                                                 IntPtr.Zero, _
                                                 NativeMethods.FileCreationDisposition.OPEN_EXISTING, _
                                                 0, _
                                                 IntPtr.Zero) ' No template file -  No other attributes set -  Opens existing mailslot -  Default security attributes -  Share mode -  Write access -  The name of the mailslot
            If hMailslot.IsInvalid Then
                Throw New Win32Exception()
            End If

            Console.WriteLine("The mailslot ({0}) is opened.", MailslotName)

            ' Write messages to the mailslot.

            ' Append '\0' at the end of each message considering the native C++ 
            ' Mailslot server (CppMailslotServer).
            WriteMailslot(hMailslot, "Message 1 for mailslot" & vbNullChar)
            WriteMailslot(hMailslot, "Message 2 for mailslot" & vbNullChar)
            Thread.Sleep(3000) ' Sleep for 3 seconds for the demo purpose
            WriteMailslot(hMailslot, "Message 3 for mailslot" & vbNullChar)

        Catch ex As Win32Exception
            Console.WriteLine("The client throws the error: {0}", ex.Message)
        Finally
            If hMailslot IsNot Nothing Then
                hMailslot.Close()
                hMailslot = Nothing
            End If
        End Try
    End Sub


    ''' <summary>
    ''' Write a message to the specified mailslot
    ''' </summary>
    ''' <param name="hMailslot">Handle to the mailslot</param>
    ''' <param name="lpszMessage">The message to be written to the slot</param>
    Private Sub WriteMailslot(ByVal hMailslot As NativeMethods.SafeMailslotHandle, _
                              ByVal message As String)
        Dim cbMessageBytes As Integer = 0 ' Message size in bytes
        Dim cbBytesWritten As Integer = 0 ' Number of bytes written to the slot

        Dim bMessage() As Byte = Encoding.Unicode.GetBytes(message)
        cbMessageBytes = bMessage.Length

        Dim succeeded As Boolean = NativeMethods.WriteFile(hMailslot, _
                                                           bMessage, _
                                                           cbMessageBytes, _
                                                           cbBytesWritten, _
                                                           IntPtr.Zero) ' Not overlapped -  Number of bytes written -  Number of bytes to write -  Message to be written -  Handle to the mailslot
        If (Not succeeded) OrElse cbMessageBytes <> cbBytesWritten Then
            Console.WriteLine("WriteFile failed w/err 0x{0:X}", Marshal.GetLastWin32Error())
        Else
            Console.WriteLine("The message ""{0}"" is written to the slot", message)
        End If
    End Sub

End Module
