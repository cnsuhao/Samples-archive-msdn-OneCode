'************************** Module Header ********************************'
' Module Name:  ImpersonateUser.vb
' Project:      VBImpersonateUser
' Copyright (c) Microsoft Corporation.
' 
'
' This class supplies a static method to impersonate an user to do some work.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************'

Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Security.Permissions
Imports System.Security.Principal


''' <summary>
''' The wrapper class for impersonating user
''' </summary>
Public Class ImpersonateUser
    ''' <summary>
    ''' A delegate that will be called under the impersonation context
    ''' </summary>
    ''' <typeparam name="TReturn"></typeparam>
    ''' <typeparam name="TParameter"></typeparam>
    ''' <param name="paramter"></param>
    ''' <returns></returns>
    Public Delegate Function ImpersonationWorkFunction(Of TReturn, TParameter)(ByVal paramter As TParameter) As TReturn

    ''' <summary>
    ''' This method calles LogonUser API to impersonation the user and is 
    ''' a wrapper around the code exposed by the delegate which makes it 
    ''' run while impersonating 
    ''' </summary>
    ''' <typeparam name="TReturn">
    ''' Generic return type of the delegated function
    ''' </typeparam>
    ''' <typeparam name="TParameter">
    ''' Generic parameter of the delegated function
    ''' </typeparam>
    ''' <param name="userName">The user name</param>
    ''' <param name="domain">Domain</param>
    ''' <param name="password">Password</param>
    ''' <param name="parameter">Parameter of the delegated function</param>
    ''' <param name="impersonationWork">
    ''' Called method while impersonating
    ''' </param>
    ''' <param name="logonMethod">
    ''' The type of logon operation to perform
    ''' </param>
    ''' <param name="provider">The logon provider</param>
    ''' <returns>The return of the delegated function</returns>
    <SecurityPermission(SecurityAction.Demand, UnmanagedCode:=True)>
    Public Shared Function Impersonate(Of TReturn, TParameter)(ByVal userName As String,
                                                               ByVal domain As String,
                                                               ByVal password As SecureString,
                                                               ByVal parameter As TParameter,
                                                               ByVal impersonationWork As ImpersonationWorkFunction(Of TReturn, TParameter),
                                                               ByVal logonMethod As NativeMethods.LogonType,
                                                               ByVal provider As NativeMethods.LogonProvider) As TReturn
        ' Check the parameters
        If String.IsNullOrEmpty(userName) Then
            Throw New ArgumentNullException("userName")
        End If
        If password Is Nothing Then
            Throw New ArgumentNullException("password")
        End If
        If impersonationWork Is Nothing Then
            Throw New ArgumentNullException("impersonationWork")
        End If
        If logonMethod < NativeMethods.LogonType.LOGON32_LOGON_INTERACTIVE Or
            NativeMethods.LogonType.LOGON32_LOGON_NEW_CREDENTIALS < logonMethod Then
            Throw New ArgumentOutOfRangeException("logonMethod")
        End If
        If provider < NativeMethods.LogonProvider.LOGON32_PROVIDER_DEFAULT Or
            NativeMethods.LogonProvider.LOGON32_PROVIDER_WINNT50 < provider Then
            Throw New ArgumentOutOfRangeException("provider")
        End If

        Dim passwordPtr As IntPtr = IntPtr.Zero
        Dim tokenHandle As IntPtr
        Dim context As WindowsImpersonationContext = Nothing


        Try
            ' Convert the password to a string
            passwordPtr = Marshal.SecureStringToBSTR(password)
            Dim handle As IntPtr = IntPtr.Zero

            ' Attempts to log a user on to the local computer
            If Not NativeMethods.LogonUser(userName, domain, passwordPtr, logonMethod, provider, tokenHandle) Then
                Throw New Win32Exception()
            Else
                context = WindowsIdentity.Impersonate(tokenHandle)

                ' Call out to the work function
                Return impersonationWork(parameter)

            End If
        Finally
            ' Erase the memory that the password was stored in
            If Not IntPtr.Zero.Equals(passwordPtr) Then
                Marshal.ZeroFreeBSTR(passwordPtr)
            End If

            ' Clean up
            If context IsNot Nothing Then
                context.Undo()
                context = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' This method calles LogonUser API to impersonation the user and is 
    ''' a wrapper around the code exposed by the delegate which makes it 
    ''' run while impersonating 
    ''' </summary>
    ''' <typeparam name="TReturn">
    ''' Generic return type of the delegated function
    ''' </typeparam>
    ''' <typeparam name="TParameter">
    ''' Generic parameter of the delegated function
    ''' </typeparam>
    ''' <param name="userName">The user name</param>
    ''' <param name="domain">Domain</param>
    ''' <param name="password">Password</param>
    ''' <param name="parameter">Parameter of the delegated function</param>
    ''' <param name="impersonationWork">
    ''' Called method while impersonating
    ''' </param>
    ''' <returns>The return of the delegated function</returns>
    Public Shared Function Impersonate(Of TReturn, TParameter)(ByVal userName As String,
                                                               ByVal domain As String,
                                                               ByVal password As SecureString,
                                                               ByVal parameter As TParameter,
                                                               ByVal impersonationWork As ImpersonationWorkFunction(Of TReturn, TParameter)) As TReturn
        Return Impersonate(userName, domain, password, parameter, impersonationWork,
                           NativeMethods.LogonType.LOGON32_LOGON_INTERACTIVE,
                           NativeMethods.LogonProvider.LOGON32_PROVIDER_DEFAULT)
    End Function
End Class


