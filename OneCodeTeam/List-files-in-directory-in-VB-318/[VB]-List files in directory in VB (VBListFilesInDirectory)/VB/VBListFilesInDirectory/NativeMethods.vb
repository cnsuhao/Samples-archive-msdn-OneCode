'**************************** Module Header ******************************'
' Module Name:  NativeMethods.vb
' Project:      VBListFilesInDirectory
' Copyright (c) Microsoft Corporation.
'
' The CSListFilesInDirectory project demonstrates how to implement an IEnumerable<string>
' that utilizes the Win32 File Management functions to enable application to get files and
' sub-directories in a specified directory one item a time.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************'

Imports System
Imports System.Runtime.InteropServices
Imports System.Runtime.ConstrainedExecution
Imports System.Security.Permissions
Imports Microsoft.Win32.SafeHandles


<Serializable(), StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto), _
BestFitMapping(False)> _
Friend Class WIN32_FIND_DATA
    Friend dwFileAttributes As Integer
    Friend ftCreationTime_dwLowDateTime As Integer
    Friend ftCreationTime_dwHighDateTime As Integer
    Friend ftLastAccessTime_dwLowDateTime As Integer
    Friend ftLastAccessTime_dwHighDateTime As Integer
    Friend ftLastWriteTime_dwLowDateTime As Integer
    Friend ftLastWriteTime_dwHighDateTime As Integer
    Friend nFileSizeHigh As Integer
    Friend nFileSizeLow As Integer
    Friend dwReserved0 As Integer
    Friend dwReserved1 As Integer
    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
    Friend cFileName As String
    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=14)> _
    Friend cAlternateFileName As String
End Class


''' <summary>
''' Win32 Native P/Invoke
''' </summary>
Friend Module NativeMethods
    ''' <summary>
    ''' Searches a directory for a file or subdirectory with a name that matches
    ''' a specific name (or partial name if wildcards are used).
    ''' http://msdn.microsoft.com/en-us/library/windows/desktop/aa364418(v=vs.85).aspx
    ''' </summary>
    <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Friend Function FindFirstFile( _
        ByVal fileName As String, _
        <[In](), Out()> ByVal data As WIN32_FIND_DATA) As SafeFindHandle
    End Function

    ''' <summary>
    ''' Continues a file search from a previous call to the FindFirstFile or 
    ''' FindFirstFileEx function.
    ''' http://msdn.microsoft.com/en-us/library/windows/desktop/aa364428(v=VS.85).aspx
    ''' </summary>
    <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Friend Function FindNextFile( _
        ByVal hndFindFile As SafeFindHandle, _
        <[In](), Out(), MarshalAs(UnmanagedType.LPStruct)> ByVal _
         lpFindFileData As WIN32_FIND_DATA) As Boolean
    End Function

    ''' <summary>
    ''' Closes a file search handle opened by the FindFirstFile, FindFirstFileEx, 
    ''' FindFirstFileNameW, FindFirstFileNameTransactedW, FindFirstFileTransacted,
    ''' FindFirstStreamTransactedW, or FindFirstStreamW functions.
    ''' http://msdn.microsoft.com/en-us/library/windows/desktop/aa364413(v=VS.85).aspx
    ''' </summary>
    ''' <param name="handle"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), DllImport("kernel32.dll")> _
    Friend Function FindClose(ByVal handle As IntPtr) As Boolean
    End Function

    Friend Const ERROR_SUCCESS As Integer = 0
    Friend Const ERROR_NO_MORE_FILES As Integer = 18
    Friend Const ERROR_FILE_NOT_FOUND As Integer = 2
    Friend Const FILE_ATTRIBUTE_DIRECTORY As Integer = &H10
End Module


''' <summary>
''' Safe handle for using with the Find File APIs.
''' </summary>
Friend NotInheritable Class SafeFindHandle
    Inherits SafeHandleZeroOrMinusOneIsInvalid

    <SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode:=True)> _
    Friend Sub New()
        MyBase.New(True)
    End Sub

    Protected Overrides Function ReleaseHandle() As Boolean
        ' Close the search handle.
        Return NativeMethods.FindClose(MyBase.handle)
    End Function
End Class