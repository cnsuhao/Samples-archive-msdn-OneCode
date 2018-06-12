'****************************** Module Header **********************************\
' Module Name:  NativeMethods.vb
' Project:      VBMailslotServer
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
'*********************************************************************************

Imports System.Runtime.ConstrainedExecution
Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Security.Permissions
Imports Microsoft.Win32.SafeHandles

<SuppressUnmanagedCodeSecurity()> _
Friend NotInheritable Class NativeMethods
    ''' <summary>
    ''' Mailslot waits forever for a message 
    ''' </summary>
    Friend Const MAILSLOT_WAIT_FOREVER As Integer = -1

    ''' <summary>
    ''' There is no next message
    ''' </summary>
    Friend Const MAILSLOT_NO_MESSAGE As Integer = -1


    ''' <summary>
    ''' Represents a wrapper class for a mailslot handle. 
    ''' </summary>
    <SecurityCritical(SecurityCriticalScope.Everything), HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort:=True), SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode:=True)> _
    Friend NotInheritable Class SafeMailslotHandle
        Inherits SafeHandleZeroOrMinusOneIsInvalid
        Private Sub New()
            MyBase.New(True)
        End Sub

        Public Sub New(ByVal preexistingHandle As IntPtr, ByVal ownsHandle As Boolean)
            MyBase.New(ownsHandle)
            MyBase.SetHandle(preexistingHandle)
        End Sub

        <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
        Private Shared Function CloseHandle(ByVal handle As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        Protected Overrides Function ReleaseHandle() As Boolean
            Return CloseHandle(MyBase.handle)
        End Function
    End Class


    ''' <summary>
    ''' The SECURITY_ATTRIBUTES structure contains the security descriptor for 
    ''' an object and specifies whether the handle retrieved by specifying 
    ''' this structure is inheritable. This structure provides security 
    ''' settings for objects created by various functions, such as CreateFile, 
    ''' CreateNamedPipe, CreateProcess, RegCreateKeyEx, or RegSaveKeyEx.
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Friend Class SECURITY_ATTRIBUTES
        Public nLength As Integer
        Public lpSecurityDescriptor As SafeLocalMemHandle
        Public bInheritHandle As Boolean
    End Class


    ''' <summary>
    ''' Represents a wrapper class for a local memory pointer. 
    ''' </summary>
    <SuppressUnmanagedCodeSecurity(), HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort:=True)> _
    Friend NotInheritable Class SafeLocalMemHandle
        Inherits SafeHandleZeroOrMinusOneIsInvalid
        Public Sub New()
            MyBase.New(True)
        End Sub

        Public Sub New(ByVal preexistingHandle As IntPtr, ByVal ownsHandle As Boolean)
            MyBase.New(ownsHandle)
            MyBase.SetHandle(preexistingHandle)
        End Sub

        <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
        Private Shared Function LocalFree(ByVal hMem As IntPtr) As IntPtr
        End Function

        Protected Overrides Function ReleaseHandle() As Boolean
            Return (LocalFree(MyBase.handle) = IntPtr.Zero)
        End Function
    End Class



    ''' <summary>
    ''' Creates an instance of a mailslot and returns a handle for subsequent 
    ''' operations.
    ''' </summary>
    ''' <param name="mailslotName">Mailslot name</param>
    ''' <param name="nMaxMessageSize">
    ''' The maximum size of a single message
    ''' </param>
    ''' <param name="lReadTimeout">
    ''' The time a read operation can wait for a message.
    ''' </param>
    ''' <param name="securityAttributes">Security attributes</param>
    ''' <returns>
    ''' If the function succeeds, the return value is a handle to the server 
    ''' end of a mailslot instance.
    ''' </returns>
    <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Public Shared Function CreateMailslot(ByVal mailslotName As String, ByVal nMaxMessageSize As UInteger, ByVal lReadTimeout As Integer, ByVal securityAttributes As SECURITY_ATTRIBUTES) As SafeMailslotHandle
    End Function


    ''' <summary>
    ''' Retrieves information about the specified mailslot.
    ''' </summary>
    ''' <param name="hMailslot">A handle to a mailslot</param>
    ''' <param name="lpMaxMessageSize">
    ''' The maximum message size, in bytes, allowed for this mailslot.
    ''' </param>
    ''' <param name="lpNextSize">
    ''' The size of the next message in bytes.
    ''' </param>
    ''' <param name="lpMessageCount">
    ''' The total number of messages waiting to be read.
    ''' </param>
    ''' <param name="lpReadTimeout">
    ''' The amount of time, in milliseconds, a read operation can wait for a 
    ''' message to be written to the mailslot before a time-out occurs. 
    ''' </param>
    ''' <returns></returns>
    <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Public Shared Function GetMailslotInfo(ByVal hMailslot As SafeMailslotHandle, ByVal lpMaxMessageSize As IntPtr, <System.Runtime.InteropServices.Out()> ByRef lpNextSize As Integer, <System.Runtime.InteropServices.Out()> ByRef lpMessageCount As Integer, ByVal lpReadTimeout As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function


    ''' <summary>
    ''' Reads data from the specified file or input/output (I/O) device.
    ''' </summary>
    ''' <param name="handle">
    ''' A handle to the device (for example, a file, file stream, physical 
    ''' disk, volume, console buffer, tape drive, socket, communications 
    ''' resource, mailslot, or pipe).
    ''' </param>
    ''' <param name="bytes">
    ''' A buffer that receives the data read from a file or device.
    ''' </param>
    ''' <param name="numBytesToRead">
    ''' The maximum number of bytes to be read.
    ''' </param>
    ''' <param name="numBytesRead">
    ''' The number of bytes read when using a synchronous IO.
    ''' </param>
    ''' <param name="overlapped">
    ''' A pointer to an OVERLAPPED structure if the file was opened with 
    ''' FILE_FLAG_OVERLAPPED.
    ''' </param> 
    ''' <returns>
    ''' If the function succeeds, the return value is true. If the function 
    ''' fails, or is completing asynchronously, the return value is false.
    ''' </returns>
    <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Public Shared Function ReadFile(ByVal handle As SafeMailslotHandle, ByVal bytes() As Byte, ByVal numBytesToRead As Integer, <System.Runtime.InteropServices.Out()> ByRef numBytesRead As Integer, ByVal overlapped As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function


    ''' <summary>
    ''' The ConvertStringSecurityDescriptorToSecurityDescriptor function 
    ''' converts a string-format security descriptor into a valid, 
    ''' functional security descriptor.
    ''' </summary>
    ''' <param name="sddlSecurityDescriptor">
    ''' A string containing the string-format security descriptor (SDDL) 
    ''' to convert.
    ''' </param>
    ''' <param name="sddlRevision">
    ''' The revision level of the sddlSecurityDescriptor string. 
    ''' Currently this value must be 1.
    ''' </param>
    ''' <param name="pSecurityDescriptor">
    ''' A pointer to a variable that receives a pointer to the converted 
    ''' security descriptor.
    ''' </param>
    ''' <param name="securityDescriptorSize">
    ''' A pointer to a variable that receives the size, in bytes, of the 
    ''' converted security descriptor. This parameter can be IntPtr.Zero.
    ''' </param>
    ''' <returns>
    ''' If the function succeeds, the return value is true.
    ''' </returns>
    <DllImport("advapi32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Public Shared Function ConvertStringSecurityDescriptorToSecurityDescriptor(ByVal sddlSecurityDescriptor As String, ByVal sddlRevision As Integer, <System.Runtime.InteropServices.Out()> ByRef pSecurityDescriptor As SafeLocalMemHandle, ByVal securityDescriptorSize As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

End Class

