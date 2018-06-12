'**************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBO365SearchByRetention
' Copyright (c) Microsoft Corporation.
' 
' Now we can easily search email messages by retention policy in Outlook. But 
' this feature is not available in Outlook Web App(OWA). In this application, 
' we demonstrate how to search email messages with retention policy enabled in 
' Office 365 Exchange Online by using Exchange Web Service Managed API.
' We use the following extend properties to search and get the information: 
' 1. PidTagRetentionPeriod (Property ID:0x301A);
' 2. PidTagRetentionDate (Property ID:0x301C).
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

Namespace VBO365SearchByRetention
    Friend Class MainModule
        Shared Sub Main(ByVal args() As String)
            Console.WriteLine("Please input the Retention Period that you want to search(Split by Space):")
            Dim searchPeriods As List(Of Int32) = GetRetentionPeriod()
            Console.WriteLine()

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

            SearchByRetentionPeriod(service, WellKnownFolderName.Inbox, searchPeriods)
            Console.WriteLine()

            Console.WriteLine("Press any key to exit......")
            Console.ReadKey()
        End Sub

        ''' <summary>
        ''' Search the Items by the retention period
        ''' </summary>
        Private Shared Sub SearchByRetentionPeriod(ByVal service As ExchangeService,
                                                   ByVal rootFolder As WellKnownFolderName,
                                                   ByVal periods As List(Of Int32))
            ' Use two extend properties to get the retention period and the expire date.
            Const pidTagRetentionPeriod As Int32 = 12314
            Dim exPropRetentionPeriod As New ExtendedPropertyDefinition(pidTagRetentionPeriod,
                                                                        MapiPropertyType.Integer)

            Const pidTagRetentionDate As Int32 = 12316
            Dim exPropRetentionDate As New ExtendedPropertyDefinition(pidTagRetentionDate,
                                                                      MapiPropertyType.SystemTime)

            Dim propertySet As New PropertySet(BasePropertySet.IdOnly,
                                               EmailMessageSchema.Subject,
                                               EmailMessageSchema.ParentFolderId)

            propertySet.Add(exPropRetentionPeriod)
            propertySet.Add(exPropRetentionDate)

            Dim searchFilterCollection As New SearchFilter.SearchFilterCollection()

            ' If specify the retention periods, we can set the search filter by them.
            If periods IsNot Nothing Then
                searchFilterCollection.LogicalOperator = LogicalOperator.Or

                For Each period As Int32 In periods
                    Dim searchFilter As New SearchFilter.IsEqualTo(exPropRetentionPeriod, period)
                    searchFilterCollection.Add(searchFilter)
                Next period
            Else
                Dim searchFilter As SearchFilter = New SearchFilter.Exists(exPropRetentionPeriod)
                searchFilterCollection.Add(searchFilter)
            End If

            Dim itemView As New ItemView(100)
            itemView.PropertySet = propertySet

            ' Use search folder to search.
            Dim searchFolder As New SearchFolder(service)
            searchFolder.SearchParameters.RootFolderIds.Add(rootFolder)
            searchFolder.SearchParameters.Traversal = SearchFolderTraversal.Deep
            searchFolder.SearchParameters.SearchFilter = searchFilterCollection
            searchFolder.DisplayName = Date.Now.ToString("yyyyMMddhhmmss")
            searchFolder.Save(WellKnownFolderName.SearchFolders)

            Dim findResults As FindItemsResults(Of Item) = Nothing
            Dim mailboxFolderNames As New Dictionary(Of String, String)()
            Console.WriteLine("Following are the search results:")
            Console.WriteLine("Subject             FolderName     RententionPeriod  ExpireDateTime")
            Do
                findResults = searchFolder.FindItems(itemView)

                For Each findResult As Item In findResults
                    Dim rPeriod As Object = findResult.ExtendedProperties(0).Value
                    Dim expireDateTime As Object = findResult.ExtendedProperties(1).Value

                    If Not mailboxFolderNames.ContainsKey(findResult.ParentFolderId.UniqueId) Then
                        Dim folder As Folder = folder.Bind(service, findResult.ParentFolderId)
                        mailboxFolderNames.Add(findResult.ParentFolderId.UniqueId, folder.DisplayName)
                    End If


                    Dim folderName As String = mailboxFolderNames(findResult.ParentFolderId.UniqueId)

                    Console.WriteLine("{0,-20}{1,-15}{2,-18}{3}", findResult.Subject, folderName,
                                      rPeriod, expireDateTime)
                Next findResult
            Loop While findResults.MoreAvailable


            searchFolder.Delete(DeleteMode.HardDelete)
        End Sub

        ''' <summary>
        ''' Get the retention period that the users input.
        ''' </summary>
        Private Shared Function GetRetentionPeriod() As List(Of Int32)
            Dim isNumber As Boolean = True
            Do
                isNumber = True
                Dim retentionPeriod As String = Console.ReadLine()

                ' '*' means to get all the Items that were applied the retention policy, or means get 
                ' the Items in specific retention periods.
                If String.Compare(retentionPeriod.Trim(), "*") <> 0 Then
                    Dim periods() As String = retentionPeriod.Split(New Char() {" "c},
                                                                    StringSplitOptions.RemoveEmptyEntries)
                    Dim searchPeriods As New List(Of Int32)()

                    For Each period As String In periods
                        Dim periodValue As Int32
                        If Int32.TryParse(period, periodValue) Then
                            searchPeriods.Add(periodValue)
                        Else
                            Console.WriteLine("Please input numbers!")
                            isNumber = False
                            Exit For
                        End If
                    Next period

                    If isNumber Then
                        Return searchPeriods
                    End If
                End If
            Loop While Not isNumber

            Return Nothing
        End Function

        Private Shared Function AutodiscoverUrl(ByVal service As ExchangeService, ByVal user As UserInfo) As Boolean
            Dim isSuccess As Boolean = False

            Try
                Console.WriteLine("Connecting the Exchange Online......")
                service.AutodiscoverUrl(user.Account, AddressOf CallbackMethods.RedirectionUrlValidationCallback)
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
