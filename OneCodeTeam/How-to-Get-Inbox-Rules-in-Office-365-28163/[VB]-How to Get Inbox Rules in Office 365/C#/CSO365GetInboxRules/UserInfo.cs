/****************************** Module Header ******************************\
Module Name:  UserInfo.cs
Project:      CSO365GetInboxRules
Copyright (c) Microsoft Corporation.

Currently, most of you manage email messages by inbox rules. Especially, 
when you become an owner of a shared mailbox, you find the former owner created 
a lot of inbox rules to manage email messages efficiently. But you need to modify 
these inbox rules to meet the new business needs. Before changing these inbox 
rules, you want to find a solution to document these inbox rules in case something 
goes wrong. But you don't have an out-of-box solution.
In this application, we will demonstrate how to get Inbox rules in Office 365.
This file includes the class that stores the user information.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

namespace CSO365GetInboxRules
{
    public class UserInfo
    {
        private String account = null;
        private String pwd = null;

        // When we create the user, we get the information of the account.
        public UserInfo()
        {
            SetUserInfo();
        }

        public void SetUserInfo()
        {
            Console.WriteLine("Please input your account and password.");

            Console.Write("Account:");
            String accountName = Console.ReadLine();

            Console.Write("Password:");
            IList<Char> password = new List<Char>();

            int top = Console.CursorTop;
            while (true)
            {
                int left = Console.CursorLeft;
                ConsoleKeyInfo info = Console.ReadKey();

                if (info.Key == ConsoleKey.Enter
                    || (info.Key != ConsoleKey.Backspace
                    && info.Key != ConsoleKey.Escape
                    && info.Key != ConsoleKey.Tab
                    && info.KeyChar != '\0'))
                {
                    if (password.Count > 0)
                    {
                        Console.SetCursorPosition(left - 1, top);

                        Console.Write("*");

                        Console.SetCursorPosition(left + 1, top);
                    }

                    if (info.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine();

                        break;
                    }
                    else
                    {
                        password.Add(info.KeyChar);
                    }
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (password.Count > 0)
                    {
                        password.RemoveAt(password.Count - 1);
                        if (password.Count > 0)
                        {
                            Console.SetCursorPosition(left - 2, top);
                            Console.Write(password[password.Count - 1] + " ");
                        }
                        else
                        {
                            Console.SetCursorPosition(left - 1, top);
                            Console.Write(" ");
                        }

                        Console.SetCursorPosition(left - 1, top);
                    }
                    else
                    {
                        Console.SetCursorPosition(left, top);
                    }
                }
            }

            account = accountName;
            pwd = new String(password.ToArray());

            if (String.IsNullOrWhiteSpace(account) || String.IsNullOrWhiteSpace(pwd))
            {
                Console.WriteLine("Can't input the empty account or password," +
                    " please input the right account and password.");
                Console.WriteLine();
                SetUserInfo();
            }
        }

        public String Account
        { get { return account; } }

        public String Pwd
        { get { return pwd; } }
    }
}
