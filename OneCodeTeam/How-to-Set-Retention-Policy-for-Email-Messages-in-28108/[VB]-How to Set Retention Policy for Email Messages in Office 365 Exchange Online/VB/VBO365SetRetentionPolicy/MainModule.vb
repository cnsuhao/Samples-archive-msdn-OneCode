'**************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBO365SetRetentionPolicy
' Copyright (c) Microsoft Corporation.
' 
' Currently, you can easily set email messages with retention policy enabled in 
' Outlook and Outlook Web App. But you may find it is not very convenient to set 
' retention policy for email messages in a specific time range. In this 
' application, we will demonstrate how to set retention policy for email 
' messages in office 365:
' 1. Select the email messages you want to appply the retention policy to;
' 2. Choose the retention policy you want to set for the email messages;
' 3. Set the retention policy for the email messages.
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
Imports System.IO

Namespace VBO365SetRetentionPolicy
    Friend Class MainModule
        Shared Sub Main(ByVal args() As String)
            ServicePointManager.ServerCertificateValidationCallback =
                AddressOf CallbackMethods.CertificateValidationCallBack
            Dim service As New ExchangeService(ExchangeVersion.Exchange2013)

            ' Get the information of the account.
            Dim user As New UserInfo()
            service.Credentials = New WebCredentials(user.Account, user.Pwd)

            ' Set the url of server.
            If Not AutodiscoverUrl(service, user) Then
                Return
            End If
            Console.WriteLine()

            Dim today As Date = Date.Now
            SetRetentionPolicyTags(service, user.Account, Nothing, today.AddDays(-30), today,
                                   Nothing, Nothing, Nothing)
            Console.WriteLine()

            Console.WriteLine("Press any key to exit......")
            Console.ReadKey()
        End Sub

        ''' <summary>
        ''' Select the email message basing the subject, start date, end date, from, displayTo, displayCc
        ''' </summary>
        Private Shared Function SearchEmailMessages(ByVal service As ExchangeService,
                                                    ByVal subject As String, ByVal startDate As Date,
                                                    ByVal endDate As Date, ByVal [from] As String,
                                                    ByVal displayTo As String, ByVal displayCc As String) As List(Of Item)
            Dim itemPropertySet As New PropertySet(BasePropertySet.FirstClassProperties,
                                                   EmailMessageSchema.PolicyTag)

            Dim searchFilterCollection As New SearchFilter.SearchFilterCollection(LogicalOperator.And)

            Dim startDateFilter As SearchFilter =
                New SearchFilter.IsGreaterThanOrEqualTo(EmailMessageSchema.DateTimeCreated, startDate)
            Dim endDateFilter As SearchFilter =
                New SearchFilter.IsLessThanOrEqualTo(EmailMessageSchema.DateTimeCreated, endDate)
            ' Just select the email message items.
            Dim itemClassFilter As SearchFilter =
                New SearchFilter.IsEqualTo(EmailMessageSchema.ItemClass, "IPM.Note")
            searchFilterCollection.Add(startDateFilter)
            searchFilterCollection.Add(endDateFilter)
            searchFilterCollection.Add(itemClassFilter)

            If Not String.IsNullOrWhiteSpace(subject) Then
                Dim subjectFilter As SearchFilter =
                    New SearchFilter.ContainsSubstring(EmailMessageSchema.Subject, subject)
                searchFilterCollection.Add(subjectFilter)
            End If

            If Not String.IsNullOrWhiteSpace([from]) Then
                Dim fromFilter As SearchFilter =
                    New SearchFilter.ContainsSubstring(EmailMessageSchema.From, [from])
                searchFilterCollection.Add(fromFilter)
            End If

            If Not String.IsNullOrWhiteSpace(displayTo) Then
                Dim displayToFilter As SearchFilter =
                    New SearchFilter.ContainsSubstring(EmailMessageSchema.DisplayTo, displayTo)
                searchFilterCollection.Add(displayToFilter)
            End If

            If Not String.IsNullOrWhiteSpace(displayCc) Then
                Dim displayCcFilter As SearchFilter =
                    New SearchFilter.ContainsSubstring(EmailMessageSchema.DisplayCc, displayCc)
                searchFilterCollection.Add(displayCcFilter)
            End If

            Dim items As List(Of Item) =
                GetItems(service, searchFilterCollection, WellKnownFolderName.Inbox, itemPropertySet)

            Console.WriteLine("{0,-30}{1}", "Subject", "PolicyTag")
            For Each item As Item In items
                Console.WriteLine("{0,-30}{1}", item.Subject, item.PolicyTag)
            Next item
            Console.WriteLine()

            Return items
        End Function

        ''' <summary>
        ''' Return the retention policy that the users choose.
        ''' </summary>
        Private Shared Function GetRetentionPolicyTag(ByVal service As ExchangeService,
                                                      ByVal userAddress As String) As RetentionPolicyTag
            service.GetPasswordExpirationDate(userAddress)

            If service.ServerInfo.MajorVersion < 15 Then
                Console.WriteLine("This version of Exchange don't support PolicyTag.")
                Return Nothing
            End If

            Dim getUserRetentionPolicyTagsResponse As GetUserRetentionPolicyTagsResponse =
                service.GetUserRetentionPolicyTags()

            If getUserRetentionPolicyTagsResponse.ErrorCode <> ServiceError.NoError Then
                Console.WriteLine("Error:{0}", getUserRetentionPolicyTagsResponse.ErrorMessage)
                Return Nothing
            End If

            Dim retentionPolicyTags() As RetentionPolicyTag =
                getUserRetentionPolicyTagsResponse.RetentionPolicyTags

            Do
                Dim policyTagsCount As Int32 = -1
                For Each retentionPolicyTag As RetentionPolicyTag In retentionPolicyTags
                    policyTagsCount += 1
                    Console.WriteLine("{0,-3}: {1}", policyTagsCount, retentionPolicyTag.DisplayName)
                Next retentionPolicyTag

                Console.Write("Please choose the Retention Policy Tag you want to set for the email messages(0-{0}):", policyTagsCount)
                Dim selectedPolicyTag As String = Console.ReadLine()
                Dim selectedPolicyTagNum As Int32 = -1

                If Int32.TryParse(selectedPolicyTag, selectedPolicyTagNum) AndAlso
                    selectedPolicyTagNum >= 0 AndAlso selectedPolicyTagNum <= policyTagsCount Then
                    Return retentionPolicyTags(selectedPolicyTagNum)
                End If
            Loop While True

        End Function

        ''' <summary>
        ''' Set the retention policy for the selected email messages.
        ''' </summary>
        Private Shared Sub SetRetentionPolicyTags(ByVal service As ExchangeService,
                                                  ByVal userAddress As String, ByVal subject As String,
                                                  ByVal startDate As Date, ByVal endDate As Date,
                                                  ByVal [from] As String, ByVal displayTo As String,
                                                  ByVal displayCc As String)
            Console.WriteLine("Email messages before setting Retention Policy")
            Dim items As List(Of Item) = SearchEmailMessages(service, subject, startDate, endDate,
                                                             [from], displayTo, displayCc)

            Console.WriteLine("Retention Policy Tags:")
            Dim retentionPolicyTag As RetentionPolicyTag = GetRetentionPolicyTag(service, userAddress)
            Console.WriteLine()

            If retentionPolicyTag IsNot Nothing Then
                Console.WriteLine("Setting the Retention Policy...")
                Dim policyTag As New PolicyTag(True, retentionPolicyTag.RetentionId)

                For Each item As Item In items
                    item.PolicyTag = policyTag
                    item.Update(ConflictResolutionMode.AlwaysOverwrite)
                Next item
            Else
                Return
            End If
            Console.WriteLine()

            Console.WriteLine("Email messages after setting Retention Policy:")
            SearchEmailMessages(service, subject, startDate, endDate, [from], displayTo, displayCc)
        End Sub

        Private Shared Function GetItems(ByVal service As ExchangeService, ByVal filter As SearchFilter,
                                         ByVal folder As WellKnownFolderName,
                                         ByVal propertySet As PropertySet) As List(Of Item)
            If service Is Nothing Then
                Return Nothing
            End If

            Dim items As New List(Of Item)()

            If propertySet Is Nothing Then
                propertySet = New PropertySet(BasePropertySet.IdOnly)
            End If

            Const pageSize As Int32 = 10
            Dim itemView As New ItemView(pageSize)
            itemView.PropertySet = propertySet

            Dim searchResults As FindItemsResults(Of Item) = Nothing
            Do
                searchResults = service.FindItems(folder, filter, itemView)
                items.AddRange(searchResults.Items)

                itemView.Offset += pageSize
            Loop While searchResults.MoreAvailable

            Return items
        End Function

        Private Shared Function AutodiscoverUrl(ByVal service As ExchangeService, ByVal user As UserInfo) As Boolean
            Dim isSuccess As Boolean = False

            Try
                Console.WriteLine("Connecting the Exchange Online......")
                service.AutodiscoverUrl(user.Account, AddressOf CallbackMethods.RedirectionUrlValidationCallback)
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
