'****************************** Module Header **********************************'
' Module Name:  NativeMethods.vb
' Project:      VBMailslotClient
' Copyright (c) Microsoft Corporation.
' 
' 
' Native API Signatures and Types 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*********************************************************************************'

Imports System.Runtime.ConstrainedExecution
Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Security.Permissions
Imports Microsoft.Win32.SafeHandles


<SuppressUnmanagedCodeSecurity()> _
Friend NotInheritable Class NativeMethods
    ''' <summary>
    ''' Desired Access of File/Device
    ''' </summary>
    <Flags()> _
    Friend Enum FileDesiredAccess As UInteger
        GENERIC_READ = &H80000000L
        GENERIC_WRITE = &H40000000
        GENERIC_EXECUTE = &H20000000
        GENERIC_ALL = &H10000000
    End Enum

    ''' <summary>
    ''' File share mode
    ''' </summary>
    <Flags()> _
    Friend Enum FileShareMode As UInteger
        Zero = &H0 ' No sharing
        FILE_SHARE_DELETE = &H4
        FILE_SHARE_READ = &H1
        FILE_SHARE_WRITE = &H2
    End Enum

    ''' <summary>
    ''' File Creation Disposition
    ''' </summary>
    Friend Enum FileCreationDisposition As UInteger
        CREATE_NEW = 1
        CREATE_ALWAYS = 2
        OPEN_EXISTING = 3
        OPEN_ALWAYS = 4
        TRUNCATE_EXISTING = 5
    End Enum


    ''' <summary>
    ''' Represents a wrapper class for a mailslot handle. 
    ''' </summary>
    <SecurityCritical(SecurityCriticalScope.Everything), _
    HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort:=True), _
    SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode:=True)> _
    Friend NotInheritable Class SafeMailslotHandle
        Inherits SafeHandleZeroOrMinusOneIsInvalid
        Private Sub New()
            MyBase.New(True)
        End Sub

        Public Sub New(ByVal preexistingHandle As IntPtr, ByVal ownsHandle As Boolean)
            MyBase.New(ownsHandle)
            MyBase.SetHandle(preexistingHandle)
        End Sub

        <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), _
        DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
        Private Shared Function CloseHandle(ByVal handle As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        Protected Overrides Function ReleaseHandle() As Boolean
            Return CloseHandle(MyBase.handle)
        End Function
    End Class



    ''' <summary>
    ''' Creates or opens a file, directory, physical disk, volume, console 
    ''' buffer, tape drive, communications resource, mailslot, or named pipe.
    ''' </summary>
    ''' <param name="fileName">
    ''' The name of the file or device to be created or opened.
    ''' </param>
    ''' <param name="desiredAccess">
    ''' The requested access to the file or device, which can be summarized 
    ''' as read, write, both or neither (zero).
    ''' </param>
    ''' <param name="shareMode">
    ''' The requested sharing mode of the file or device, which can be read, 
    ''' write, both, delete, all of these, or none (refer to the following 
    ''' table). 
    ''' </param>
    ''' <param name="securityAttributes">
    ''' A SECURITY_ATTRIBUTES object that contains two separate but related 
    ''' data members: an optional security descriptor, and a Boolean value 
    ''' that determines whether the returned handle can be inherited by 
    ''' child processes.
    ''' </param>
    ''' <param name="creationDisposition">
    ''' An action to take on a file or device that exists or does not exist.
    ''' </param>
    ''' <param name="flagsAndAttributes">
    ''' The file or device attributes and flags.
    ''' </param>
    ''' <param name="hTemplateFile">Handle to a template file.</param>
    ''' <returns>
    ''' If the function succeeds, the return value is an open handle to the 
    ''' specified file, device, named pipe, or mail slot.
    ''' If the function fails, the return value is an invalid handle.
    ''' </returns>
    <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Public Shared Function CreateFile(ByVal fileName As String, _
                                      ByVal desiredAccess As FileDesiredAccess, _
                                      ByVal shareMode As FileShareMode, _
                                      ByVal securityAttributes As IntPtr, _
                                      ByVal creationDisposition As FileCreationDisposition, _
                                      ByVal flagsAndAttributes As Integer, _
                                      ByVal hTemplateFile As IntPtr) As SafeMailslotHandle
    End Function


    ''' <summary>
    ''' Writes data to the specified file or input/output (I/O) device.
    ''' </summary>
    ''' <param name="handle">
    ''' A handle to the file or I/O device (for example, a file, file stream,
    ''' physical disk, volume, console buffer, tape drive, socket, 
    ''' communications resource, mailslot, or pipe). 
    ''' </param>
    ''' <param name="bytes">
    ''' A buffer containing the data to be written to the file or device.
    ''' </param>
    ''' <param name="numBytesToWrite">
    ''' The number of bytes to be written to the file or device.
    ''' </param>
    ''' <param name="numBytesWritten">
    ''' The number of bytes written when using a synchronous IO.
    ''' </param>
    ''' <param name="overlapped">
    ''' A pointer to an OVERLAPPED structure is required if the file was 
    ''' opened with FILE_FLAG_OVERLAPPED.
    ''' </param>
    ''' <returns>
    ''' If the function succeeds, the return value is true. If the function 
    ''' fails, or is completing asynchronously, the return value is false.
    ''' </returns>
    <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Public Shared Function WriteFile(ByVal handle As SafeMailslotHandle, _
                                     ByVal bytes() As Byte, _
                                     ByVal numBytesToWrite As Integer, _
                                     <Out()> ByRef numBytesWritten As Integer, _
                                     ByVal overlapped As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function
End Class


