'**************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBO365SearchSharedMailbox
' Copyright (c) Microsoft Corporation.
' 
' Currently, Outlook Web App doesn't allow you to search calendar items in a 
' shared mailbox. But some of you require this feature for some reasons. In 
' this sample, we will demonstrate how to search calendar items from shared 
' mailbox:
' 1. Get the shared mailbox that users input
' 2. Get the search filter, such as the start date, end date, subject.
' 3. Set the ImpersonatedUserId property if the login account has the impersonation 
' permission.
' 4. Search the items in the shared mailbox. 
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

Namespace VBO365SearchSharedMailbox
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

            GetSharedMailboxItems(service, user.Account)
            Console.WriteLine()

            Console.WriteLine("Press any key to exit......")
            Console.ReadKey()
        End Sub

        ''' <summary>
        ''' Search the calendar items in Shared Mailbox
        ''' </summary>
        Private Shared Sub GetSharedMailboxItems(ByVal service As ExchangeService,
                                                 ByVal currentAddress As String)
            Do
                service.ImpersonatedUserId = Nothing
                ' If we have the impersonation permission, we can impersonate the shared mailbox 
                ' to search the calendar items.
                Console.WriteLine("Please input the Shared Mailbox identity you want to get the " & "items")
                Dim identity As String = Console.ReadLine()

                If Not String.IsNullOrWhiteSpace(identity) Then
                    ' You can input the "EXIT" to exit.
                    If identity.ToUpper().CompareTo("EXIT") = 0 Then
                        Return
                    End If

                    ' If the shared mailbox identity is valid, we will set it as the ImpersonatedUserId.
                    Dim nameResolutions As NameResolutionCollection =
                        service.ResolveName(identity, ResolveNameSearchLocation.DirectoryOnly, False)
                    If nameResolutions.Count <> 1 Then
                        Console.WriteLine("{0} is invalid Shared Mailbox identity.", identity)
                        Console.WriteLine()
                    Else
                        Dim emailAddress As String = nameResolutions(0).Mailbox.Address

                        Console.WriteLine()
                        Console.WriteLine("Please input the start date (15 days before today is the defined date.):")
                        Dim startDate As String = Console.ReadLine()
                        Console.WriteLine("Please input the end date (30 days after start date is the defined date.):")
                        Dim endDate As String = Console.ReadLine()

                        Console.WriteLine("Please input the subject that you want to search(Press Enter directly to get all the itmes):")
                        Dim searchSubject As String = Console.ReadLine()
                        Console.WriteLine()

                        service.ImpersonatedUserId =
                            New ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress)
                        GetSharedMailboxCalendarItems(service, emailAddress, searchSubject,
                                                      startDate, endDate)
                    End If
                Else
                    Console.WriteLine("Identity cannot be null.")
                End If
            Loop While True
        End Sub

        ''' <summary>
        ''' Search the calendar items in Shared Mailbox
        ''' </summary>
        Private Shared Sub GetSharedMailboxCalendarItems(ByVal service As ExchangeService,
                                                         ByVal emailAddress As String,
                                                         ByVal searchSubject As String,
                                                         ByVal startDate As String,
                                                         ByVal endDate As String)
            ' If the date is invaild, we will set 15 days before today as the start date.
            Dim startSearchDate As Date
            startSearchDate = If(Date.TryParse(startDate, startSearchDate), startSearchDate,
                                 Date.Now.AddDays(-15))
            ' If the date is invaild, we will set 30 days after the start date as the end date.
            Dim endSearchDate As Date
            endSearchDate = If(Date.TryParse(endDate, endSearchDate) AndAlso
                               endSearchDate >= startSearchDate, endSearchDate,
                               startSearchDate.AddDays(30))

            Dim folderId As New FolderId(WellKnownFolderName.Calendar)

            Dim searchFilterCollection As New SearchFilter.SearchFilterCollection()
            searchFilterCollection.LogicalOperator = LogicalOperator.And

            ' If you want search the specified subject, you can define the filter; or you will get all
            ' the items that contain the Subject schema.
            If String.IsNullOrWhiteSpace(searchSubject) Then
                Dim searchFilter As SearchFilter = New SearchFilter.Exists(AppointmentSchema.Subject)
                searchFilterCollection.Add(searchFilter)
            Else
                Dim searchFilter As SearchFilter =
                    New SearchFilter.ContainsSubstring(AppointmentSchema.Subject, searchSubject)
                searchFilterCollection.Add(searchFilter)
            End If

            Dim startDateFilter As SearchFilter =
                New SearchFilter.IsGreaterThanOrEqualTo(AppointmentSchema.DateTimeCreated, startSearchDate)
            Dim endDateFilter As SearchFilter =
                New SearchFilter.IsLessThanOrEqualTo(AppointmentSchema.DateTimeCreated, endSearchDate)

            searchFilterCollection.Add(startDateFilter)
            searchFilterCollection.Add(endDateFilter)

            Dim itemView As New ItemView(100)
            itemView.PropertySet = New PropertySet(BasePropertySet.FirstClassProperties)

            Dim findItems As FindItemsResults(Of Item) = Nothing
            Console.WriteLine("{0,-20}{1,-25}{2,-25}{3,-10}", "Subject", "Start", "End", "Duration")
            Do
                findItems = service.FindItems(folderId, searchFilterCollection, itemView)
                For Each item As Item In findItems
                    Console.Write("{0,-20}", If(item.Subject.Length > 18, item.Subject.Substring(0, 15) & "...", item.Subject))

                    If TypeOf item Is Appointment Then
                        Dim appointment As Appointment = TryCast(item, Appointment)
                        Console.Write("{0,-25}", appointment.Start)
                        Console.Write("{0,-25}", appointment.End)
                        Console.Write("{0,-10}", appointment.Duration)
                    End If
                    Console.WriteLine()
                Next item
            Loop While findItems.MoreAvailable

            Console.WriteLine()

        End Sub

        Private Shared Function AutodiscoverUrl(ByVal service As ExchangeService, ByVal user As UserInfo) As Boolean
            Dim isSuccess As Boolean = False

            Try
                Console.WriteLine("Connecting the Exchange Online......")
                service.AutodiscoverUrl(user.Account,
                                        AddressOf CallbackMethods.RedirectionUrlValidationCallback)
                Console.WriteLine()
                Console.WriteLine("Connect the Exchange Online successfully.")

                isSuccess = True
            Catch e As Exception
                Console.WriteLine("There's an error.")
                Console.WriteLine(e.Message)
            End Try

            Return isSuccess
        End Function
    End Class
End Namespace
