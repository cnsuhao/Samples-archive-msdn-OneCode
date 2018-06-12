'************************** Module Header ********************************'
' Module Name:  MainModule.vb
' Project:      VBImpersonateUser
' Copyright (c) Microsoft Corporation.
' 
'
' Windows Impersonation is a powerful feature Windows uses frequently in its 
' security model. In general Windows also uses impersonation in its client/
' server programming model.Impersonation lets a server to temporarily adopt 
' the security profile of a client making a resource request. The server can
' then access resources on behalf of the client, and the OS carries out the 
' access validations.
' A server impersonates a client only within the thread that makes the 
' impersonation request. Thread-control data structures contain an optional 
' entry for an impersonation token. However, a thread's primary token, which
' represents the thread's real security credentials, is always accessible in 
' the process's control structure.
' 
' After the server thread finishes its task, it reverts to its primary 
' security profile. These forms of impersonation are convenient for carrying 
' out specific actions at the request of a client and for ensuring that object
' accesses are audited correctly.
' 
' In this code sample we use the LogonUser API and the WindowsIdentity.
' Impersonate method to impersonate the user represented by the specified user
' token. Then display the current user via the WindowsIdentity.GetCurrent 
' method to show user impersonation. LogonUser can only be used to log onto 
' the local machine; it cannot log you onto a remote computer. The account 
' that you use in the LogonUser() call must also be known to the local 
' machine, either as a local account or as a domain account that is visible
' to the local computer. If LogonUser is successful, then it will give you an
' access token that specifies the credentials of the user account you chose.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************'

Imports System.Security
Imports System.Security.Principal

Friend Module MainModule
    Sub Main(ByVal args() As String)
        '///////////////////////////////////////////////////////////////////
        ' Gather the credential information of the impersonated user.
        ' 

        Console.WriteLine("Before impersonation ...")
        Console.WriteLine("Current user is {0}", WindowsIdentity.GetCurrent().Name)

        Console.WriteLine("Input user name DomainName\UserName")
        Dim username As String = Console.ReadLine()

        Dim domain As String = String.Empty
        Dim index As Integer = username.IndexOf("\"c)
        If index <> -1 Then
            domain = username.Substring(0, index)
            username = username.Substring(index + 1)
        Else
            Console.WriteLine("Please enter as DomainName\UserName")
            Return
        End If
        Console.WriteLine("Input password")
        Dim password As SecureString = GetPassword()


        '///////////////////////////////////////////////////////////////////
        ' Impersonate the specified user. The impersonation is automatically 
        ' undone after the Impersonate method.
        ' 
        Try
            ImpersonateUser.Impersonate(Of Object, Object)(username, domain, password, Nothing, AddressOf DoSomeWork)
        Catch ex As Exception
            Console.WriteLine(ex.Message.ToString())
            Return
        Finally
            password.Dispose()
        End Try

        Console.WriteLine(vbLf & "After impersonation is undone ...")
        Console.WriteLine("Current user is {0}", WindowsIdentity.GetCurrent().Name)
    End Sub

    Private Function DoSomeWork(ByVal obj As Object) As Object
        Console.WriteLine(vbLf & "During impersonation ...")
        Console.WriteLine("Current user is {0}", WindowsIdentity.GetCurrent().Name)
        Return Nothing
    End Function

    ''' <summary>
    ''' Get user's password with SecureString
    ''' </summary>
    ''' <returns></returns>
    Public Function GetPassword() As SecureString
        Dim password As New SecureString()

        ' Get the first character of the password
        Dim nextKey As ConsoleKeyInfo = Console.ReadKey(True)
        Do While nextKey.Key <> ConsoleKey.Enter
            If nextKey.Key = ConsoleKey.Backspace Then
                If password.Length > 0 Then
                    password.RemoveAt(password.Length - 1)
                    ' Erase the last * as well
                    Console.Write(nextKey.KeyChar)
                    Console.Write(" ")
                    Console.Write(nextKey.KeyChar)
                End If
            Else
                password.AppendChar(nextKey.KeyChar)
                Console.Write("*")
            End If
            nextKey = Console.ReadKey(True)
        Loop
        Console.WriteLine()

        ' Lock the password down
        password.MakeReadOnly()
        Return password
    End Function
End Module