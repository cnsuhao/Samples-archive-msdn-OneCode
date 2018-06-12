'**************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBO365GetInboxRules
' Copyright (c) Microsoft Corporation.
' 
' Currently, most of you manage email messages by inbox rules. Especially, 
' when you become an owner of a shared mailbox, you find the former owner created 
' a lot of inbox rules to manage email messages efficiently. But you need to modify 
' these inbox rules to meet the new business needs. Before changing these inbox 
' rules, you want to find a solution to document these inbox rules in case something 
' goes wrong. But you don't have an out-of-box solution.
' In this application, we will demonstrate how to get Inbox rules in Office 365:
' 1. Get the accounts that users input
' 2. Set the ImpersonatedUserId property if the login account has the impersonation 
' permission.
' 3. Get Inbox rules of the accounts. 
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

Namespace VBO365GetInboxRules
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

            GetInboxRules(service, user.Account)
            Console.WriteLine()

            Console.WriteLine("Press any key to exit......")
            Console.ReadKey()
        End Sub

        ''' <summary>
        ''' Get the Inbox rules of the accounts that users input
        ''' </summary>
        Private Shared Sub GetInboxRules(ByVal service As ExchangeService,
                                         ByVal currentAddress As String)
            Do
                service.ImpersonatedUserId = Nothing
                ' If we have the impersonation permission, we can impersonate the other accounts 
                ' to get the Inbox rules, or we can only get the Inbox rules of the login account. 
                Console.WriteLine("Please input the user identity you want to get the " &
                                  "Inbox rules(or you can directly press Enter to get Inbox rules")
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
                            GetAccountGetInboxRules(service, emailAddress)
                        End If
                    Next identity
                Else
                    ' We can also directly press Enter to get the Inbox rules of the 
                    ' login account.
                    GetAccountGetInboxRules(service, currentAddress)
                End If
            Loop While True
        End Sub

        ''' <summary>
        ''' Get the Inbox rules of the specific account.
        ''' </summary>
        Private Shared Sub GetAccountGetInboxRules(ByVal service As ExchangeService,
                                                   ByVal emailAddress As String,
                                                   ByVal ParamArray userIds() As UserId)
            Dim emailBox = New Mailbox(emailAddress)

            Dim rules As RuleCollection = service.GetInboxRules(emailAddress)

            If rules.Count <= 0 Then
                Console.WriteLine("There's no rule for the account {0}.", emailAddress)
                Console.WriteLine()
            Else
                For Each rule As Rule In rules
                    Console.WriteLine("{0,-20}:{1}", "Account Identity", emailAddress)
                    Console.WriteLine("{0,-20}:{1}", "Id", rule.DisplayName)
                    Console.WriteLine("{0,-20}:{1}", "Priority", rule.Priority)
                    Console.WriteLine("{0,-20}:{1}", "IsEnabled", rule.IsEnabled)
                    Console.WriteLine("{0,-20}:{1}", "IsNotSupported", rule.IsNotSupported)
                    Console.WriteLine("{0,-20}:{1}", "IsInError", rule.IsInError)
                    Console.WriteLine("{0,-20}:{1}", "Conditions", rule.Conditions)
                    Console.WriteLine("{0,-20}:{1}", "Actions", rule.Actions)
                    Console.WriteLine("{0,-20}:{1}", "Account Identity", rule.Exceptions)

                    Console.WriteLine()
                Next rule
            End If
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
