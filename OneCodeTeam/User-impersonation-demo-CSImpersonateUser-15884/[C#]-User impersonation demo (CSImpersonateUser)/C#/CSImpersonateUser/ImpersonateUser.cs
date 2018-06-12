/****************************** Module Header ********************************\
 * Module Name:  ImpersonateUser.cs
 * Project:      CSImpersonateUser
 * Copyright (c) Microsoft Corporation.
 * 
 *
 * This class supplies a static method to impersonate an user to do some work.
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
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;

namespace CSImpersonateUser
{
    /// <summary>
    /// The wrapper class for impersonating user
    /// </summary>
    public class ImpersonateUser
    {
        /// <summary>
        /// A delegate that will be called under the impersonation context
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <typeparam name="TParameter"></typeparam>
        /// <param name="paramter"></param>
        /// <returns></returns>
        public delegate TReturn
            ImpersonationWorkFunction<TReturn, TParameter>(TParameter paramter);

        /// <summary>
        /// This method calles LogonUser API to impersonation the user and is 
        /// a wrapper around the code exposed by the delegate which makes it 
        /// run while impersonating 
        /// </summary>
        /// <typeparam name="TReturn">
        /// Generic return type of the delegated function
        /// </typeparam>
        /// <typeparam name="TParameter">
        /// Generic parameter of the delegated function
        /// </typeparam>
        /// <param name="userName">The user name</param>
        /// <param name="domain">Domain</param>
        /// <param name="password">Password</param>
        /// <param name="parameter">Parameter of the delegated function</param>
        /// <param name="impersonationWork">
        /// Called method while impersonating
        /// </param>
        /// <param name="logonMethod">
        /// The type of logon operation to perform
        /// </param>
        /// <param name="provider">The logon provider</param>
        /// <returns>The return of the delegated function</returns>
        [SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
        public static TReturn Impersonate<TReturn, TParameter>(
            string userName,
            string domain,
            SecureString password,
            TParameter parameter,
            ImpersonationWorkFunction<TReturn, TParameter> impersonationWork,
            NativeMethods.LogonType logonMethod,
            NativeMethods.LogonProvider provider)
        {
            // Check the parameters
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("userName");
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            if (impersonationWork == null)
            {
                throw new ArgumentNullException("impersonationWork");
            }
            if (logonMethod < NativeMethods.LogonType.LOGON32_LOGON_INTERACTIVE |
                NativeMethods.LogonType.LOGON32_LOGON_NEW_CREDENTIALS < logonMethod)
            {
                throw new ArgumentOutOfRangeException("logonMethod");
            }
            if (provider < NativeMethods.LogonProvider.LOGON32_PROVIDER_DEFAULT |
                NativeMethods.LogonProvider.LOGON32_PROVIDER_WINNT50 < provider)
            {
                throw new ArgumentOutOfRangeException("provider");
            }

            IntPtr passwordPtr = IntPtr.Zero;
            IntPtr tokenHandle;
            WindowsImpersonationContext context = null;


            try
            {
                // Convert the password to a string
                passwordPtr = Marshal.SecureStringToBSTR(password);
                IntPtr handle = IntPtr.Zero;

                // Attempts to log a user on to the local computer
                if (!NativeMethods.LogonUser(userName, domain, passwordPtr,
                    logonMethod, provider, out tokenHandle))
                {
                    throw new Win32Exception();
                }
                else
                {
                    context = WindowsIdentity.Impersonate(tokenHandle);

                    // Call out to the work function
                    return impersonationWork(parameter);

                }
            }
            finally
            {
                // Erase the memory that the password was stored in
                if (!IntPtr.Zero.Equals(passwordPtr))
                {
                    Marshal.ZeroFreeBSTR(passwordPtr);
                }

                // Clean up
                if (context != null)
                {
                    context.Undo();
                    context = null;
                }
            }
        }

        /// <summary>
        /// This method calles LogonUser API to impersonation the user and is 
        /// a wrapper around the code exposed by the delegate which makes it 
        /// run while impersonating 
        /// </summary>
        /// <typeparam name="TReturn">
        /// Generic return type of the delegated function
        /// </typeparam>
        /// <typeparam name="TParameter">
        /// Generic parameter of the delegated function
        /// </typeparam>
        /// <param name="userName">The user name</param>
        /// <param name="domain">Domain</param>
        /// <param name="password">Password</param>
        /// <param name="parameter">Parameter of the delegated function</param>
        /// <param name="impersonationWork">
        /// Called method while impersonating
        /// </param>
        /// <returns>The return of the delegated function</returns>
        public static TReturn Impersonate<TReturn, TParameter>(
            string userName,
            string domain,
            SecureString password,
            TParameter parameter,
            ImpersonationWorkFunction<TReturn, TParameter> impersonationWork)
        {
            return Impersonate(
                userName,
                domain,
                password,
                parameter,
                impersonationWork,
                NativeMethods.LogonType.LOGON32_LOGON_INTERACTIVE,
                NativeMethods.LogonProvider.LOGON32_PROVIDER_DEFAULT);
        }
    }
}

