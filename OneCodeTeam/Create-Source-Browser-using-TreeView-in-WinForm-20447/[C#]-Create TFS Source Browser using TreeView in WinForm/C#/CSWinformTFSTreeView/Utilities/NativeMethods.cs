/****************************** Module Header ******************************\
Module Name:  NativeMethods.cs
Project:      CSWinformTFSTreeView
Copyright (c) Microsoft Corporation.

Utility class to include all P/Invoke methods

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Runtime.InteropServices;

namespace Microsoft.OneCode.Utilities
{
    /// <summary>
    /// P/Invoke methods
    /// </summary>
    internal sealed class NativeMethods
    {
        [DllImport("shell32.dll", EntryPoint = "ExtractIconEx", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int ExtractIconEx(string szFileName, int nIconIndex,
           IntPtr[] phiconLarge, IntPtr[] phiconSmall, uint nIcons);

        [DllImport("user32.dll", EntryPoint = "DestroyIcon", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int DestroyIcon(IntPtr hIcon);
    }
}
