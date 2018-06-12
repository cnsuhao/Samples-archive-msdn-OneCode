'**************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBO365AddDelegates
' Copyright (c) Microsoft Corporation.
' 
' Currently, you can easily add delegates in Outlook. But you may find this feature 
' is not available in Outlook Web App (OWA). In this application, we will 
' demonstrate how to add multi delegates in Office 365 Exchange Online.
' 1. Get the addresses of delegates;
' 2. Get the addresses of primary accounts;
' 3. Set the ImpersonatedUserId property if the login account has the impersonation 
' permission.
' 4. Add all the delegates into all the primary accounts.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports Microsoft.Exchange.WebServices.Data
Imports System.Net
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports System.Reflection
Imports System.Collections.ObjectModel

Namespace VBO365AddDelegates
    Friend Class MainModule
        Shared Sub Main(ByVal args() As String)
            ServicePointManager.ServerCertificateValidationCallback =
                AddressOf CallbackMethods.CertificateValidationCallBack
            Dim service As New ExchangeService(ExchangeVersion.Exchange2010_SP2)

            ' Get the information of the account.
            Dim user As New UserInfo()
            service.Credentials = New WebCredentials(user.Account, user.Pwd)

            ' Set the url of server.
            If Not AutodiscoverUrl(service, user) Then
                Return
            End If
            Console.WriteLine()

            ' We can set any delegate permission in AddDelegates method, but now we specify 
            ' the CalendarFolderPermissionLevel property.
            AddDelegates(service, user.Account, "CalendarFolderPermissionLevel",
                         DelegateFolderPermissionLevel.Reviewer)
            Console.WriteLine()

            Console.WriteLine("Press any key to exit......")
            Console.ReadKey()
        End Sub

        ''' <summary>
        ''' Add multi delegates to the multi accounts
        ''' </summary>
        Private Shared Sub AddDelegates(ByVal service As ExchangeService,
                                        ByVal currentAddress As String,
                                        ByVal permissionLevelName As String,
                                        ByVal permissionLevel As DelegateFolderPermissionLevel)
            Do
                Console.WriteLine("Please input the user identity(s) that were used as the delegates:")

                Dim delegateInfo As String = Console.ReadLine()

                ' We get the addresses related to the identities of delegates.
                Dim delegateIdentities As New List(Of String)()
                If Not String.IsNullOrWhiteSpace(delegateInfo) Then
                    ' You can input the "EXIT" to exit.
                    If delegateInfo.ToUpper().CompareTo("EXIT") = 0 Then
                        Return
                    End If

                    For Each delegateIdentity As String In delegateInfo.Split(","c)
                        Dim nameResolutions As NameResolutionCollection =
                    service.ResolveName(delegateIdentity, ResolveNameSearchLocation.DirectoryOnly, True)
                        If nameResolutions.Count <> 1 Then
                            Console.WriteLine("{0} is invalid user identity as the delegate.",
                                              delegateIdentity)
                        Else
                            delegateIdentities.Add(nameResolutions(0).Mailbox.Address)
                        End If
                    Next delegateIdentity

                    If delegateIdentities.Count = 0 Then
                        Console.WriteLine("There's not any valid user identity as the delegate.")
                        Continue Do
                    End If
                Else
                    Console.WriteLine("The delegates cannot be null!")
                    Continue Do
                End If

                ' If we have the impersonation permission, we can impersonate the other accounts 
                ' to add delegates, or we can only add delegates to the login account. 
                Console.WriteLine("Please input the user identity you want to set the " &
            "delegates(or you can directly press Enter to set delegates in current account):")
                Dim primaryInfo As String = Console.ReadLine()

                If Not String.IsNullOrWhiteSpace(primaryInfo) Then
                    ' You can input the "EXIT" to exit.
                    If primaryInfo.ToUpper().CompareTo("EXIT") = 0 Then
                        Return
                    End If

                    Dim primaryIdentities() As String = primaryInfo.Split(","c)

                    For Each primaryIdentity As String In primaryIdentities
                        ' If the user identity is valid, we will set it as the ImpersonatedUserId.
                        Dim nameResolutions As NameResolutionCollection =
                            service.ResolveName(primaryIdentity, ResolveNameSearchLocation.DirectoryOnly,
                                                True)
                        If nameResolutions.Count <> 1 Then
                            Console.WriteLine("{0} is invalid user identity.", primaryIdentity)
                        Else
                            Dim emailAddress As String = nameResolutions(0).Mailbox.Address
                            service.ImpersonatedUserId =
                                New ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress)

                            For Each delegateIdentity As String In delegateIdentities
                                AddAccountDelegates(service, emailAddress, delegateIdentity,
                                                    permissionLevelName, permissionLevel)
                            Next delegateIdentity
                        End If
                    Next primaryIdentity
                Else
                    ' We can also directly press Enter to add the delegates to the login account. 
                    For Each delegateIdentity As String In delegateIdentities
                        AddAccountDelegates(service, currentAddress, delegateIdentity,
                                            permissionLevelName, permissionLevel)
                    Next delegateIdentity
                End If

                service.ImpersonatedUserId = Nothing
                Console.WriteLine()
            Loop While True
        End Sub

        ''' <summary>
        ''' Add the delegate to the specific account.
        ''' </summary>
        Private Shared Sub AddAccountDelegates(ByVal service As ExchangeService,
                                               ByVal primaryAddress As String,
                                               ByVal delegateAddress As String,
                                               ByVal permissionLevelName As String,
                                               ByVal permissionLevel As DelegateFolderPermissionLevel)
            Dim delegateUser As New DelegateUser(delegateAddress)

            ' Set the permission property of the delegate user.
            For Each [property] As PropertyInfo In GetType(DelegatePermissions).GetProperties()
                If String.Compare([property].Name, permissionLevelName) = 0 Then
                    [property].SetValue(delegateUser.Permissions, permissionLevel)
                    Exit For
                End If
            Next [property]

            Dim emailBox As New Mailbox(primaryAddress)
            Dim responses As Collection(Of DelegateUserResponse) =
                service.AddDelegates(emailBox,
                                     MeetingRequestsDeliveryScope.DelegatesAndSendInformationToMe,
                                     delegateUser)
            For Each response As DelegateUserResponse In responses
                Console.WriteLine("Add {0} as the delegate to the account {1}:{2}",
                                  delegateAddress, primaryAddress, response.Result)
                Console.WriteLine()
            Next response
        End Sub

        Private Shared Function AutodiscoverUrl(ByVal service As ExchangeService,
                                                ByVal user As UserInfo) As Boolean
            Dim isSuccess As Boolean = False

            Try
                Console.WriteLine("Connecting the Exchange Online......")
                service.AutodiscoverUrl(user.Account,
                                        AddressOf CallbackMethods.RedirectionUrlValidationCallback)
                Console.WriteLine()
                Console.WriteLine("It's success to connect the Exchange Online.")

                isSuccess = True
            Catch e As Exception
                Console.WriteLine("There's an error.")
                Console.WriteLine(e.Message)
            End Try

            Return isSuccess
        End Function
    End Class
End Namespace
