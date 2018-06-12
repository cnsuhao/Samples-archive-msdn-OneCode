/****************************** Module Header ******************************\
* Module Name:  NativeMethods.cs
* Project:      CSSL5DIBFromClipboard
* Copyright (c) Microsoft Corporation.
* 
* This code sample demonstrates accessing the Windows Clipboard and retrieving a 
* Device Independent Bitmap (DIB) and saving the DIB to a file.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Runtime.InteropServices;


namespace CSSL5DIBFromClipboard
{
    public static class NativeMethods
    {
        [DllImport("user32.dll", EntryPoint = "OpenClipboard", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("user32.dll", EntryPoint = "CloseClipboard", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool CloseClipboard();

        [DllImport("user32.dll", EntryPoint = "IsClipboardFormatAvailable", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool IsClipboardFormatAvailable(uint fmt);

        [DllImport("user32.dll", EntryPoint = "GetClipboardData", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetClipboardData(uint fmt);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GlobalLock(IntPtr hObject);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GlobalSize(IntPtr hGlobal);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool GlobalUnlock(IntPtr hObject);

        // See http://msdn.microsoft.com/en-us/library/windows/desktop/ff729168(v=vs.85).aspx for clipboard formats
        public const uint CF_DIB = 8;
    }
}
