/****************************** Module Header ********************************\
 * Module Name:  Program.cs
 * Project:      CSImpersonateUser
 * Copyright (c) Microsoft Corporation.
 * 
 *
 * Windows Impersonation is a powerful feature Windows uses frequently in its 
 * security model. In general Windows also uses impersonation in its client/
 * server programming model.Impersonation lets a server to temporarily adopt 
 * the security profile of a client making a resource request. The server can
 * then access resources on behalf of the client, and the OS carries out the 
 * access validations.
 * A server impersonates a client only within the thread that makes the 
 * impersonation request. Thread-control data structures contain an optional 
 * entry for an impersonation token. However, a thread's primary token, which
 * represents the thread's real security credentials, is always accessible in 
 * the process's control structure.
 * 
 * After the server thread finishes its task, it reverts to its primary 
 * security profile. These forms of impersonation are convenient for carrying 
 * out specific actions at the request of a client and for ensuring that object
 * accesses are audited correctly.
 * 
 * In this code sample we use the LogonUser API and the WindowsIdentity.
 * Impersonate method to impersonate the user represented by the specified user
 * token. Then display the current user via the WindowsIdentity.GetCurrent 
 * method to show user impersonation. LogonUser can only be used to log onto 
 * the local machine; it cannot log you onto a remote computer. The account 
 * that you use in the LogonUser() call must also be known to the local 
 * machine, either as a local account or as a domain account that is visible
 * to the local computer. If LogonUser is successful, then it will give you an
 * access token that specifies the credentials of the user account you chose.
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Security;
using System.Security.Principal;

namespace CSImpersonateUser
{


    class Program
    {
        static void Main(string[] args)
        {
            /////////////////////////////////////////////////////////////////////
            // Gather the credential information of the impersonated user.
            // 

            Console.WriteLine("Before impersonation ...");
            Console.WriteLine("Current user is {0}",
                WindowsIdentity.GetCurrent().Name);

            Console.WriteLine(@"Input user name DomainName\UserName");
            string username = Console.ReadLine();

            string domain = string.Empty;
            int index = username.IndexOf('\\');
            if (index != -1)
            {
                domain = username.Substring(0, index);
                username = username.Substring(index + 1);
            }
            else
            {
                Console.WriteLine(@"Please enter as DomainName\UserName");
                return;
            }
            Console.WriteLine("Input password");
            SecureString password = GetPassword();


            /////////////////////////////////////////////////////////////////////
            // Impersonate the specified user. The impersonation is automatically 
            // undone after the Impersonate method.
            // 
            try
            {
                ImpersonateUser.Impersonate<object, object>(username,
                    domain, password, null, delegate
                {

                    Console.WriteLine("\nDuring impersonation ...");
                    Console.WriteLine("Current user is {0}",
                    WindowsIdentity.GetCurrent().Name);

                    return null;
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return;
            }
            finally
            {
                password.Dispose();
            }

            Console.WriteLine("\nAfter impersonation is undone ...");
            Console.WriteLine("Current user is {0}",
                WindowsIdentity.GetCurrent().Name);
        }

        /// <summary>
        /// Get user's password with SecureString
        /// </summary>
        /// <returns></returns>
        public static SecureString GetPassword()
        {
            SecureString password = new SecureString();

            // Get the first character of the password
            ConsoleKeyInfo nextKey = Console.ReadKey(true);
            while (nextKey.Key != ConsoleKey.Enter)
            {
                if (nextKey.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password.RemoveAt(password.Length - 1);
                        // Erase the last * as well
                        Console.Write(nextKey.KeyChar);
                        Console.Write(" ");
                        Console.Write(nextKey.KeyChar);
                    }
                }
                else
                {
                    password.AppendChar(nextKey.KeyChar);
                    Console.Write("*");
                }
                nextKey = Console.ReadKey(true);
            }
            Console.WriteLine();

            // Lock the password down
            password.MakeReadOnly();
            return password;
        }
    }
}