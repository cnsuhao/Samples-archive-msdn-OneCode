' **************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBO365GetDelegates
' Copyright (c) Microsoft Corporation.
' 
' Currently, you can easily get delegates in Outlook. But you'll find this feature 
' is not available in Outlook Web App (OWA). In this application, we will 
' demonstrate how get the delegate information of multi accounts.
' 1. Get the accounts that users input
' 2. Set the ImpersonatedUserId property if the login account has the 
' impersonation permission.
' 3. Get all the delegate information of the accounts. 
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

Namespace VBO365GetDelegates
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

            GetDelegates(service, user.Account)
            Console.WriteLine()

            Console.WriteLine("Press any key to exit......")
            Console.ReadKey()
        End Sub

        ''' <summary>
        ''' Get the delegate information of the accounts that users input
        ''' </summary>
        Private Shared Sub GetDelegates(ByVal service As ExchangeService, ByVal currentAddress As String)
            Do
                service.ImpersonatedUserId = Nothing
                ' If we have the impersonation permission, we can impersonate the other accounts 
                ' to get the delegate information, or we can only get the delegate information of 
                ' the login account. 
                Console.WriteLine("Please input the user identity you want to get the " &
                        "information of delegate(or you can directly press Enter to get delegates" &
                        " of current account):")
                Dim inputInfo As String = Console.ReadLine()

                If Not String.IsNullOrWhiteSpace(inputInfo) Then
                    ' You can input the "EXIT" to exit.
                    If inputInfo.ToUpper().CompareTo("EXIT") = 0 Then
                        Return
                    End If

                    Dim identities() As String = inputInfo.Split(","c)

                    For Each identity As String In identities
                        ' If the user identity is valid, we will set it as the ImpersonatedUserId.
                        Dim nameResolutions As NameResolutionCollection =
                            service.ResolveName(identity, ResolveNameSearchLocation.DirectoryOnly, True)
                        If nameResolutions.Count <> 1 Then
                            Console.WriteLine("{0} is invalid user identity.", identity)
                        Else
                            Dim emailAddress As String = nameResolutions(0).Mailbox.Address
                            service.ImpersonatedUserId =
                                New ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress)
                            GetAccountDelegates(service, emailAddress)
                        End If
                    Next identity
                Else
                    ' We can also directly press Enter to get the delegate information of the 
                    ' login account.
                    GetAccountDelegates(service, currentAddress)
                End If
            Loop While True
        End Sub

        ''' <summary>
        ''' Get the delegate information of the specific account.
        ''' </summary>
        Private Shared Sub GetAccountDelegates(ByVal service As ExchangeService,
                                               ByVal emailAddress As String,
                                               ByVal ParamArray userIds() As UserId)
            Dim emailBox = New Mailbox(emailAddress)

            Dim result As DelegateInformation = service.GetDelegates(emailBox, True, userIds)

            For Each response In result.DelegateUserResponses
                If response.ErrorCode <> ServiceError.NoError Then
                    Console.WriteLine(response.ErrorMessage)
                Else
                    Console.WriteLine("{0,-30}:{1}", "Identity", emailAddress)
                    Console.WriteLine("{0,-30}:{1}", "MeetingRequestsDeliveryScope",
                                      result.MeetingRequestsDeliveryScope)
                    Console.WriteLine("{0,-30}:{1}", "DelegateUser",
                                      response.DelegateUser.UserId.PrimarySmtpAddress)
                    Console.WriteLine("{0,-30}:{1}", "ReceiveCopiesOfMeetingMessages",
                                      response.DelegateUser.ReceiveCopiesOfMeetingMessages)
                    Console.WriteLine("{0,-30}:{1}", "ViewPrivateItems",
                                      response.DelegateUser.ViewPrivateItems)
                    Console.WriteLine("{0,-30}:{1}", "CalendarFolderPermissionLevel",
                                      response.DelegateUser.Permissions.CalendarFolderPermissionLevel)
                    Console.WriteLine("{0,-30}:{1}", "TasksFolderPermissionLevel",
                                      response.DelegateUser.Permissions.TasksFolderPermissionLevel)
                    Console.WriteLine("{0,-30}:{1}", "InboxFolderPermissionLevel",
                                      response.DelegateUser.Permissions.InboxFolderPermissionLevel)
                    Console.WriteLine("{0,-30}:{1}", "ContactsFolderPermissionLevel",
                                      response.DelegateUser.Permissions.ContactsFolderPermissionLevel)
                    Console.WriteLine("{0,-30}:{1}", "NotesFolderPermissionLevel",
                                      response.DelegateUser.Permissions.NotesFolderPermissionLevel)
                    Console.WriteLine("{0,-30}:{1}", "JournalFolderPermissionLevel",
                                      response.DelegateUser.Permissions.JournalFolderPermissionLevel)

                    Console.WriteLine()
                End If
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
