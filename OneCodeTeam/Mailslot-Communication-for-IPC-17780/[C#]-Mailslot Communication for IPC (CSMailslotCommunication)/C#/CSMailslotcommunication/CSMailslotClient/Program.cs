/********************************** Module Header **********************************\
 * Module Name:  Program.cs
 * Project:      CSMailslotClient
 * Copyright (c) Microsoft Corporation.
 * 
 * Mailslot is a mechanism for one-way inter-process communication in the local machine
 * or across the computers in the intranet. Any clients can store messages in a mailslot. 
 * The creator of the slot, i.e. the server, retrieves the messages that are stored 
 * there:
 * 
 * Client (GENERIC_WRITE) ---> Server (GENERIC_READ)
 * 
 * This sample demonstrates a mailslot client that connects and writes to the mailslot 
 * "\\.\mailslot\SampleMailslot". 
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***********************************************************************************/

#region Using directives
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
#endregion


namespace CSMailslotClient
{
    class Program
    {
        // The full name of the mailslot is in the format of \\.\mailslot\[path]name
        // The name field must be unique. The name may include multiple levels of 
        // pseudo directories separated by backslashes. For example, both 
        // \\.\mailslot\mailslot_name and \\.\mailslot\abc\def\ghi are valid.
        internal const string MailslotName = @"\\.\mailslot\SampleMailslot";


        static void Main(string[] args)
        {
            NativeMethods. SafeMailslotHandle hMailslot = null;

            try
            {
                // Try to open the mailslot with the write access.
                hMailslot = NativeMethods.CreateFile(
                    MailslotName,                           // The name of the mailslot
                    NativeMethods.FileDesiredAccess.GENERIC_WRITE,        // Write access 
                    NativeMethods.FileShareMode.FILE_SHARE_READ,          // Share mode
                    IntPtr.Zero,                            // Default security attributes
                    NativeMethods.FileCreationDisposition.OPEN_EXISTING,  // Opens existing mailslot
                    0,                                      // No other attributes set
                    IntPtr.Zero                             // No template file
                    );
                if (hMailslot.IsInvalid)
                {
                    throw new Win32Exception();
                }

                Console.WriteLine("The mailslot ({0}) is opened.", MailslotName);

                // Write messages to the mailslot.

                // Append '\0' at the end of each message considering the native C++ 
                // Mailslot server (CppMailslotServer).
                WriteMailslot(hMailslot, "Message 1 for mailslot\0");
                WriteMailslot(hMailslot, "Message 2 for mailslot\0");
                Thread.Sleep(3000); // Sleep for 3 seconds for the demo purpose
                WriteMailslot(hMailslot, "Message 3 for mailslot\0");

            }
            catch (Win32Exception ex)
            {
                Console.WriteLine("The client throws the error: {0}", ex.Message);
            }
            finally
            {
                if (hMailslot != null)
                {
                    hMailslot.Close();
                    hMailslot = null;
                }
            }
        }


        /// <summary>
        /// Write a message to the specified mailslot
        /// </summary>
        /// <param name="hMailslot">Handle to the mailslot</param>
        /// <param name="lpszMessage">The message to be written to the slot</param>
        static void WriteMailslot(NativeMethods.SafeMailslotHandle hMailslot, string message)
        {
            int cbMessageBytes = 0;         // Message size in bytes
            int cbBytesWritten = 0;         // Number of bytes written to the slot

            byte[] bMessage = Encoding.Unicode.GetBytes(message);
            cbMessageBytes = bMessage.Length;

            bool succeeded = NativeMethods.WriteFile(
                hMailslot,                  // Handle to the mailslot
                bMessage,                   // Message to be written
                cbMessageBytes,             // Number of bytes to write
                out cbBytesWritten,         // Number of bytes written
                IntPtr.Zero                 // Not overlapped
                );
            if (!succeeded || cbMessageBytes != cbBytesWritten)
            {
                Console.WriteLine("WriteFile failed w/err 0x{0:X}", 
                    Marshal.GetLastWin32Error());
            }
            else
            {
                Console.WriteLine("The message \"{0}\" is written to the slot", 
                    message);
            }
        }

    }
}