/****************************** Module Header ******************************\
* Module Name:  IOleCommandTarget.cs
* Project:	    CSIEToolbarButton
* Copyright (c) Microsoft Corporation.
* 
* This interface enables objects and their containers to dispatch commands to 
* each other. For example, an object's toolbars may contain buttons for 
* commands such as Print, Print Preview, Save, New, and Zoom. 
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/


using System;
using System.Runtime.InteropServices;
using System.Security;

namespace CSIEToolbarButton.NativeMethods
{
    [ComImport]
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [SuppressUnmanagedCodeSecurity]
    [SecurityCritical]
    [Guid("B722BCCB-4E68-101B-A2BC-00AA00404770")]
    public interface IOleCommandTarget
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int QueryStatus(
            NativeMethods.GUID pguidCmdGroup, 
            int cCmds,
            [In, Out] NativeMethods.OLECMD prgCmds, 
            [In, Out] IntPtr pCmdText);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Exec(
            NativeMethods.GUID pguidCmdGroup, 
            int nCmdID, int nCmdexecopt, 
            [In, MarshalAs(UnmanagedType.LPArray)] object[] pvaIn,
            int pvaOut);
    }










}
