/********************************** Module Header **********************************\
 * Module Name:  Program.cs
 * Project:      CSMailslotServer
 * Copyright (c) Microsoft Corporation.
 * 
 * Mailslot is a mechanism for one-way inter-process communication in the local machine
 * or across the computers in the intranet. Any clients can store messages in a mailslot. 
 * The creator of the slot, i.e. the server, retrieves the messages that are stored 
 * there:
 * 
 * Client (GENERIC_WRITE) ---> Server (GENERIC_READ)
 * 
 * This code sample demonstrates calling CreateMailslot to create a mailslot named 
 * "\\.\mailslot\SampleMailslot". The security attributes of the slot are customized to 
 * allow Authenticated Users read and write access to the slot, and to allow the 
 * Administrators group full access to it. The sample first creates such a mailslot, 
 * then it reads and displays new messages in the slot when user presses ENTER in the 
 * console.

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

#endregion


namespace CSMailslotServer
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
            NativeMethods.SafeMailslotHandle hMailslot = null;

            try
            {
                // Prepare the security attributes (the lpSecurityAttributes parameter 
                // in CreateMailslot) for the mailslot. This is optional. If the 
                // lpSecurityAttributes parameter of CreateMailslot is NULL, the 
                // mailslot gets a default security descriptor and the handle cannot 
                // be inherited. The ACLs in the default security descriptor of a 
                // mailslot grant full control to the LocalSystem account, (elevated) 
                // administrators, and the creator owner. They also give only read 
                // access to members of the Everyone group and the anonymous account. 
                // However, if you want to customize the security permission of the 
                // mailslot, (e.g. to allow Authenticated Users to read from and 
                // write to the mailslot), you need to create a SECURITY_ATTRIBUTES 
                // structure.
                NativeMethods.SECURITY_ATTRIBUTES sa = null;
                sa =  CreateMailslotSecurity();

                // Create the mailslot.
                hMailslot = NativeMethods.CreateMailslot(
                    MailslotName,               // The name of the mailslot
                    0,                          // No maximum message size
                    NativeMethods. MAILSLOT_WAIT_FOREVER,      // Waits forever for a message
                    sa                          // Mailslot security attributes
                    );

                if (hMailslot.IsInvalid)
                {
                    throw new Win32Exception();
                }

                Console.WriteLine("The mailslot ({0}) is created.", MailslotName);

                // Check messages in the mailslot.
                Console.Write("Press ENTER to check new messages or press Q to quit ...");
                string cmd = Console.ReadLine();
                while (!cmd.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Checking new messages...");
                    ReadMailslot(hMailslot);

                    Console.Write("Press ENTER to check new messages or press Q to quit ...");
                    cmd = Console.ReadLine();
                }
            }
            catch (Win32Exception ex)
            {
                Console.WriteLine("The server throws the error: {0}", ex.Message);
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
        /// The CreateMailslotSecurity function creates and initializes a new 
        /// SECURITY_ATTRIBUTES object to allow Authenticated Users read and 
        /// write access to a mailslot, and to allow the Administrators group full 
        /// access to the mailslot.
        /// </summary>
        /// <returns>
        /// A SECURITY_ATTRIBUTES object that allows Authenticated Users read and 
        /// write access to a mailslot, and allows the Administrators group full 
        /// access to the mailslot.
        /// </returns>
        /// <see cref="http://msdn.microsoft.com/en-us/library/aa365600.aspx"/>
        static NativeMethods.SECURITY_ATTRIBUTES CreateMailslotSecurity()
        {
            // Define the SDDL for the security descriptor.
            string sddl = "D:" +        // Discretionary ACL
                "(A;OICI;GRGW;;;AU)" +  // Allow read/write to authenticated users
                "(A;OICI;GA;;;BA)";     // Allow full control to administrators

            NativeMethods.SafeLocalMemHandle pSecurityDescriptor = null;
            if (!NativeMethods.ConvertStringSecurityDescriptorToSecurityDescriptor(
                sddl, 1, out pSecurityDescriptor, IntPtr.Zero))
            {
                throw new Win32Exception();
            }

            NativeMethods.SECURITY_ATTRIBUTES sa = new NativeMethods.SECURITY_ATTRIBUTES();
            sa.nLength = Marshal.SizeOf(sa);
            sa.lpSecurityDescriptor = pSecurityDescriptor;
            sa.bInheritHandle = false;
            return sa;
        }


        /// <summary>
        /// Read the messages from a mailslot by using the mailslot handle in a call 
        /// to the ReadFile function. 
        /// </summary>
        /// <param name="hMailslot">The handle of the mailslot</param>
        /// <returns> 
        /// If the function succeeds, the return value is true.
        /// </returns>
        static bool ReadMailslot(NativeMethods.SafeMailslotHandle hMailslot)
        {
            int cbMessageBytes = 0;         // Size of the message in bytes
            int cbBytesRead = 0;            // Number of bytes read from the mailslot
            int cMessages = 0;              // Number of messages in the slot
            int nMessageId = 0;             // Message ID

            bool succeeded = false;

            // Check for the number of messages in the mailslot.
            succeeded = NativeMethods.GetMailslotInfo(
                hMailslot,                  // Handle of the mailslot
                IntPtr.Zero,                // No maximum message size 
                out cbMessageBytes,         // Size of next message 
                out cMessages,              // Number of messages 
                IntPtr.Zero                 // No read time-out
                );
            if (!succeeded)
            {
                Console.WriteLine("GetMailslotInfo failed w/err 0x{0:X}",
                    Marshal.GetLastWin32Error());
                return succeeded;
            }

            if (cbMessageBytes == NativeMethods. MAILSLOT_NO_MESSAGE)
            {
                // There are no new messages in the mailslot at present
                Console.WriteLine("No new messages.");
                return succeeded;
            }

            // Retrieve the messages one by one from the mailslot.
            while (cMessages != 0)
            {
                nMessageId++;

                // Declare a byte array to fetch the data
                byte[] bBuffer = new byte[cbMessageBytes];
                succeeded = NativeMethods.ReadFile(
                    hMailslot,              // Handle of mailslot
                    bBuffer,                // Buffer to receive data
                    cbMessageBytes,         // Size of buffer in bytes
                    out cbBytesRead,        // Number of bytes read from mailslot
                    IntPtr.Zero             // Not overlapped I/O
                    );
                if (!succeeded)
                {
                    Console.WriteLine("ReadFile failed w/err 0x{0:X}", 
                        Marshal.GetLastWin32Error());
                    break;
                }

                // Display the message. 
                Console.WriteLine("Message #{0}: {1}", nMessageId, 
                    Encoding.Unicode.GetString(bBuffer));

                // Get the current number of un-read messages in the slot. The number
                // may not equal the initial message number because new messages may 
                // arrive while we are reading the items in the slot.
                succeeded = NativeMethods.GetMailslotInfo(
                    hMailslot,              // Handle of the mailslot
                    IntPtr.Zero,            // No maximum message size 
                    out cbMessageBytes,     // Size of next message 
                    out cMessages,          // Number of messages 
                    IntPtr.Zero             // No read time-out 
                    );
                if (!succeeded)
                {
                    Console.WriteLine("GetMailslotInfo failed w/err 0x{0:X}",
                        Marshal.GetLastWin32Error());
                    break;
                }
            }

            return succeeded;
        }
    }
}