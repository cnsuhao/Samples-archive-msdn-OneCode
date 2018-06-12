'****************************** Module Header **********************************\
' Module Name:  MainModule.vb
' Project:      VBMailslotServer
' Copyright (c) Microsoft Corporation.
' 
' Mailslot is a mechanism for one-way inter-process communication in the local machine
' or across the computers in the intranet. Any clients can store messages in a mailslot. 
' The creator of the slot, i.e. the server, retrieves the messages that are stored 
' there:
' 
' Client (GENERIC_WRITE) ---> Server (GENERIC_READ)
' 
' This code sample demonstrates calling CreateMailslot to create a mailslot named 
' "\\.\mailslot\SampleMailslot". The security attributes of the slot are customized to 
' allow Authenticated Users read and write access to the slot, and to allow the 
' Administrators group full access to it. The sample first creates such a mailslot, 
' then it reads and displays new messages in the slot when user presses ENTER in the 
' console.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*********************************************************************************

Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Text




Friend Module MainModule
    ' The full name of the mailslot is in the format of \\.\mailslot\[path]name
    ' The name field must be unique. The name may include multiple levels of 
    ' pseudo directories separated by backslashes. For example, both 
    ' \\.\mailslot\mailslot_name and \\.\mailslot\abc\def\ghi are valid.
    Friend Const MailslotName As String = "\\.\mailslot\SampleMailslot"


    Sub Main(ByVal args() As String)
        Dim hMailslot As NativeMethods.SafeMailslotHandle = Nothing

        Try
            ' Prepare the security attributes (the lpSecurityAttributes parameter 
            ' in CreateMailslot) for the mailslot. This is optional. If the 
            ' lpSecurityAttributes parameter of CreateMailslot is NULL, the 
            ' mailslot gets a default security descriptor and the handle cannot 
            ' be inherited. The ACLs in the default security descriptor of a 
            ' mailslot grant full control to the LocalSystem account, (elevated) 
            ' administrators, and the creator owner. They also give only read 
            ' access to members of the Everyone group and the anonymous account. 
            ' However, if you want to customize the security permission of the 
            ' mailslot, (e.g. to allow Authenticated Users to read from and 
            ' write to the mailslot), you need to create a SECURITY_ATTRIBUTES 
            ' structure.
            Dim sa As NativeMethods.SECURITY_ATTRIBUTES = Nothing
            sa = CreateMailslotSecurity()

            ' Create the mailslot.
            hMailslot = NativeMethods.CreateMailslot(MailslotName, _
                                                     0, _
                                                     NativeMethods.MAILSLOT_WAIT_FOREVER, _
                                                     sa) ' Mailslot security attributes -  Waits forever for a message -  No maximum message size -  The name of the mailslot

            If hMailslot.IsInvalid Then
                Throw New Win32Exception()
            End If

            Console.WriteLine("The mailslot ({0}) is created.", MailslotName)

            ' Check messages in the mailslot.
            Console.Write("Press ENTER to check new messages or press Q to quit ...")
            Dim cmd As String = Console.ReadLine()
            Do While Not cmd.Equals("Q", StringComparison.OrdinalIgnoreCase)
                Console.WriteLine("Checking new messages...")
                ReadMailslot(hMailslot)

                Console.Write("Press ENTER to check new messages or press Q to quit ...")
                cmd = Console.ReadLine()
            Loop
        Catch ex As Win32Exception
            Console.WriteLine("The server throws the error: {0}", ex.Message)
        Finally
            If hMailslot IsNot Nothing Then
                hMailslot.Close()
                hMailslot = Nothing
            End If
        End Try
    End Sub


    ''' <summary>
    ''' The CreateMailslotSecurity function creates and initializes a new 
    ''' SECURITY_ATTRIBUTES object to allow Authenticated Users read and 
    ''' write access to a mailslot, and to allow the Administrators group full 
    ''' access to the mailslot.
    ''' </summary>
    ''' <returns>
    ''' A SECURITY_ATTRIBUTES object that allows Authenticated Users read and 
    ''' write access to a mailslot, and allows the Administrators group full 
    ''' access to the mailslot.
    ''' </returns>
    ''' <see cref="http://msdn.microsoft.com/en-us/library/aa365600.aspx"/>
    Private Function CreateMailslotSecurity() As NativeMethods.SECURITY_ATTRIBUTES
        ' Define the SDDL for the security descriptor.
        Dim sddl As String = "D:" & "(A;OICI;GRGW;;;AU)" & "(A;OICI;GA;;;BA)" ' Allow full control to administrators -  Allow read/write to authenticated users -  Discretionary ACL

        Dim pSecurityDescriptor As NativeMethods.SafeLocalMemHandle = Nothing
        If Not NativeMethods.ConvertStringSecurityDescriptorToSecurityDescriptor(sddl, 1, pSecurityDescriptor, IntPtr.Zero) Then
            Throw New Win32Exception()
        End If

        Dim sa As New NativeMethods.SECURITY_ATTRIBUTES()
        sa.nLength = Marshal.SizeOf(sa)
        sa.lpSecurityDescriptor = pSecurityDescriptor
        sa.bInheritHandle = False
        Return sa
    End Function


    ''' <summary>
    ''' Read the messages from a mailslot by using the mailslot handle in a call 
    ''' to the ReadFile function. 
    ''' </summary>
    ''' <param name="hMailslot">The handle of the mailslot</param>
    ''' <returns> 
    ''' If the function succeeds, the return value is true.
    ''' </returns>
    Private Function ReadMailslot(ByVal hMailslot As NativeMethods.SafeMailslotHandle) As Boolean
        Dim cbMessageBytes As Integer = 0 ' Size of the message in bytes
        Dim cbBytesRead As Integer = 0 ' Number of bytes read from the mailslot
        Dim cMessages As Integer = 0 ' Number of messages in the slot
        Dim nMessageId As Integer = 0 ' Message ID

        Dim succeeded As Boolean = False

        ' Check for the number of messages in the mailslot.
        succeeded = NativeMethods.GetMailslotInfo(hMailslot, IntPtr.Zero, cbMessageBytes, cMessages, IntPtr.Zero) ' No read time-out -  Number of messages -  Size of next message -  No maximum message size -  Handle of the mailslot
        If Not succeeded Then
            Console.WriteLine("GetMailslotInfo failed w/err 0x{0:X}", Marshal.GetLastWin32Error())
            Return succeeded
        End If

        If cbMessageBytes = NativeMethods.MAILSLOT_NO_MESSAGE Then
            ' There are no new messages in the mailslot at present
            Console.WriteLine("No new messages.")
            Return succeeded
        End If

        ' Retrieve the messages one by one from the mailslot.
        Do While cMessages <> 0
            nMessageId += 1

            ' Declare a byte array to fetch the data
            Dim bBuffer(cbMessageBytes - 1) As Byte
            succeeded = NativeMethods.ReadFile(hMailslot, bBuffer, cbMessageBytes, cbBytesRead, IntPtr.Zero) ' Not overlapped I/O -  Number of bytes read from mailslot -  Size of buffer in bytes -  Buffer to receive data -  Handle of mailslot
            If Not succeeded Then
                Console.WriteLine("ReadFile failed w/err 0x{0:X}", Marshal.GetLastWin32Error())
                Exit Do
            End If

            ' Display the message. 
            Console.WriteLine("Message #{0}: {1}", nMessageId, Encoding.Unicode.GetString(bBuffer))

            ' Get the current number of un-read messages in the slot. The number
            ' may not equal the initial message number because new messages may 
            ' arrive while we are reading the items in the slot.
            succeeded = NativeMethods.GetMailslotInfo(hMailslot, IntPtr.Zero, cbMessageBytes, cMessages, IntPtr.Zero) ' No read time-out -  Number of messages -  Size of next message -  No maximum message size -  Handle of the mailslot
            If Not succeeded Then
                Console.WriteLine("GetMailslotInfo failed w/err 0x{0:X}", Marshal.GetLastWin32Error())
                Exit Do
            End If
        Loop

        Return succeeded
    End Function
End Module
