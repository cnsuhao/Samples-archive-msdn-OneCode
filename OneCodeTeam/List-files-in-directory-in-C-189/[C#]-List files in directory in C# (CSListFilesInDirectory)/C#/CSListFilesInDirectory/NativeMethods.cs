/****************************** Module Header ******************************\
 Module Name:  NativeMethods.cs
 Project:      CSListFilesInDirectory
 Copyright (c) Microsoft Corporation.

 The CSListFilesInDirectory project demonstrates how to implement an IEnumerable<string>
 that utilizes the Win32 File Management functions to enable application to get files and
 sub-directories in a specified directory one item a time.

 This source is subject to the Microsoft Public License.
 See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
 All other rights reserved.

 THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;

/// <summary>
/// Contains information about the file that is found by the FindFirstFile,
/// FindFirstFileEx, or FindNextFile function.
/// </summary>
[Serializable, StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto), 
BestFitMapping(false)]
internal class WIN32_FIND_DATA
{
    internal int dwFileAttributes;
    internal int ftCreationTime_dwLowDateTime;
    internal int ftCreationTime_dwHighDateTime;
    internal int ftLastAccessTime_dwLowDateTime;
    internal int ftLastAccessTime_dwHighDateTime;
    internal int ftLastWriteTime_dwLowDateTime;
    internal int ftLastWriteTime_dwHighDateTime;
    internal int nFileSizeHigh;
    internal int nFileSizeLow;
    internal int dwReserved0;
    internal int dwReserved1;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    internal string cFileName;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
    internal string cAlternateFileName;
}

/// <summary>
/// Win32 Native P/Invoke
/// </summary>
internal static class NativeMethods
{
    /// <summary>
    /// Searches a directory for a file or subdirectory with a name that matches
    /// a specific name (or partial name if wildcards are used).
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/aa364418(v=vs.85).aspx
    /// </summary>
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    internal static extern SafeFindHandle FindFirstFile(
        string fileName, [In, Out] WIN32_FIND_DATA data);

    /// <summary>
    /// Continues a file search from a previous call to the FindFirstFile or 
    /// FindFirstFileEx function.
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/aa364428(v=VS.85).aspx
    /// </summary>
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    internal static extern bool FindNextFile(
        SafeFindHandle hndFindFile, 
        [In, Out, MarshalAs(UnmanagedType.LPStruct)] 
        WIN32_FIND_DATA lpFindFileData);

    /// <summary>
    /// Closes a file search handle opened by the FindFirstFile, FindFirstFileEx, 
    /// FindFirstFileNameW, FindFirstFileNameTransactedW, FindFirstFileTransacted,
    /// FindFirstStreamTransactedW, or FindFirstStreamW functions.
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/aa364413(v=VS.85).aspx
    /// </summary>
    /// <param name="handle"></param>
    /// <returns></returns>
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), DllImport("kernel32.dll")]
    internal static extern bool FindClose(IntPtr handle);

    internal const int ERROR_SUCCESS = 0;
    internal const int ERROR_NO_MORE_FILES = 18;
    internal const int ERROR_FILE_NOT_FOUND = 2;
    internal const int FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
}

/// <summary>
/// Safe handle for using with the Find File APIs.
/// </summary>
internal sealed class SafeFindHandle : SafeHandleZeroOrMinusOneIsInvalid
{
    [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
    internal SafeFindHandle()
        : base(true)
    {
    }

    protected override bool ReleaseHandle()
    {
        // Close the search handle.
        return NativeMethods.FindClose(base.handle);
    }
}