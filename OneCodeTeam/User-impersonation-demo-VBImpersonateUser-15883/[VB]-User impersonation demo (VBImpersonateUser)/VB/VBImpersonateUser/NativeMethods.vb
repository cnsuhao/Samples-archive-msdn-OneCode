'************************** Module Header ********************************'
' Module Name:  NativeMethods.vb
' Project:      VBImpersonateUser
' Copyright (c) Microsoft Corporation.
' 
'
' This is a wrapper class of P/Invoke signatures for impersonating user
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************'

Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Runtime.ConstrainedExecution


Public NotInheritable Class NativeMethods
    ''' <summary>
    ''' The LogonUser function attempts to log a user on to the local computer.
    ''' The local computer is the computer from which LogonUser was called.
    ''' You cannot use LogonUser to log on to a remote computer. You specify 
    ''' the user with a user name and domain and authenticate the user with a
    ''' plaintext password. If the function succeeds, you receive a handle to 
    ''' a token that represents the logged-on user. You can then use this token 
    ''' handle to impersonate the specified user or, in most cases, to create 
    ''' a process that runs in the context of the specified user.
    ''' </summary>
    ''' <param name="lpszUsername">he name of the user</param>
    ''' <param name="lpszDomain">The name of the domain</param>
    ''' <param name="lpszPassword">The user's password</param>
    ''' <param name="dwLogonType">The type of logon operation to perform</param>
    ''' <param name="dwLogonProvider">The logon provider</param>
    ''' <param name="phToken">Token handle of the specified user</param>
    ''' <returns></returns>
    <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Friend Shared Function LogonUser(<MarshalAs(UnmanagedType.LPWStr)> ByVal lpszUsername As String,
                                     <MarshalAs(UnmanagedType.LPWStr)> ByVal lpszDomain As String,
                                     ByVal lpszPassword As IntPtr,
                                     ByVal dwLogonType As LogonType,
                                     ByVal dwLogonProvider As LogonProvider,
                                     <Out()> ByRef phToken As IntPtr) As Boolean
    End Function

    Public Enum LogonType As Integer
        ' This logon type is intended for users who will be interactively 
        ' using the computer
        LOGON32_LOGON_INTERACTIVE = 2

        ' This logon type is intended for high performance servers to 
        ' authenticate plaintext passwords
        LOGON32_LOGON_NETWORK = 3

        ' This logon type is intended for batch servers
        LOGON32_LOGON_BATCH = 4

        ' Indicates a service-type logon
        LOGON32_LOGON_SERVICE = 5

        ' This logon type is for GINA DLLs that log on users who will be 
        ' interactively using the computer       
        LOGON32_LOGON_UNLOCK = 7

        ' This logon type preserves the name and password in the 
        ' authentication package
        LOGON32_LOGON_NETWORK_CLEARTEXT = 8

        ' This logon type allows the caller to clone its current token 
        ' and specify new credentials for outbound connections.        
        LOGON32_LOGON_NEW_CREDENTIALS = 9
    End Enum

    Public Enum LogonProvider As Integer
        ' Use the standard logon provider for the system        
        LOGON32_PROVIDER_DEFAULT = 0
        ' Use the negotiate logon provider
        LOGON32_PROVIDER_WINNT50 = 1
        ' Use the NTLM logon provider
        LOGON32_PROVIDER_WINNT40 = 2
    End Enum
End Class

