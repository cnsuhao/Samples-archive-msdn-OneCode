'**************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBOffice365RestoreItems
' Copyright (c) Microsoft Corporation.
' 
' Outlook Web App(OWA) currently allows us to recover deleted items. But it is 
' inconvenient to recover large number of deleted items. Additionally, we may 
' need to recover items of specific type. In this sample, we will demonstrate 
' how to recover deleted items in Office 365 Exchange Online.
' We can recover deleted items from the following folders:
' 1. DeletedItems: The Deleted Items folder.
' 2. RecoverableItemsDeletions: The root of the folder hierarchy of recoverable items that 
'    have been soft-deleted from the Deleted Items folder.
' 3. RecoverableItemsPurges: The root of the folder hierarchy of recoverable items that 
'    have been hard-deleted from the Deleted Items folder.
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

Namespace VBOffice365RestoreItems
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

            ' Restore the folders under DeletedItems.
            RestoreFolders(service, WellKnownFolderName.DeletedItems, Nothing)
            Console.WriteLine()

            ' Restore the items under DeletedItems in last two weeks.
            Dim endDate As Date = Date.Now
            Dim startDate As Date = endDate.AddDays(-14)
            RestoreItems(service, WellKnownFolderName.DeletedItems, Nothing, startDate, endDate)
            Console.WriteLine()

            Console.WriteLine("Press any key to exit......")
            Console.ReadKey()
        End Sub

        ''' <summary>
        ''' Restore the folders from the rootFolder.
        ''' </summary>
        ''' <param name="rootFolder">
        ''' We recover deleted folders from the following folders:
        ''' 1. DeletedItems: The Deleted Items folder.
        ''' 2. RecoverableItemsDeletions: The root of the folder hierarchy of recoverable items that 
        ''' have been soft-deleted from the Deleted Items folder.
        ''' 3. RecoverableItemsPurges: The root of the folder hierarchy of recoverable items that 
        ''' have been hard-deleted from the Deleted Items folder.
        ''' </param>
        ''' <param name="displayName">We can restore the specific folders by DisplayName property 
        ''' of the folders</param>
        Private Shared Sub RestoreFolders(ByVal service As ExchangeService,
                                          ByVal rootFolder As WellKnownFolderName,
                                          ByVal displayName As String)
            If rootFolder <> WellKnownFolderName.DeletedItems AndAlso
                rootFolder <> WellKnownFolderName.RecoverableItemsDeletions AndAlso
                rootFolder <> WellKnownFolderName.RecoverableItemsPurges Then
                Return
            End If

            Dim searchFilter As SearchFilter = Nothing
            If String.IsNullOrWhiteSpace(displayName) Then
                searchFilter = New SearchFilter.Exists(FolderSchema.DisplayName)
            Else
                searchFilter = New SearchFilter.ContainsSubstring(FolderSchema.DisplayName, displayName)
            End If

            ' Get all the subfolders from the rootFolder
            Dim folders As List(Of Folder) = GetFolders(service, searchFilter, rootFolder, False,
                                                        PropertySet.FirstClassProperties)

            For Each folder As Folder In folders
                Console.WriteLine(folder.FolderClass)

                ' Move folder and the subfolders to the specific folder.
                Select Case folder.FolderClass
                    Case "IPF.Appointment"
                        folder.Move(WellKnownFolderName.Calendar)
                        Console.WriteLine("Move Folder-{0}-to Calendar", folder.DisplayName)
                    Case "IPF.Contact"
                        folder.Move(WellKnownFolderName.Contacts)
                        Console.WriteLine("Move Folder-{0}-to Contacts", folder.DisplayName)
                    Case "IPF.Journal"
                        folder.Move(WellKnownFolderName.Journal)
                        Console.WriteLine("Move Folder-{0}-to Journal", folder.DisplayName)
                    Case "IPF.Note"
                        folder.Move(WellKnownFolderName.Inbox)
                        Console.WriteLine("Move Folder-{0}-to Inbox", folder.DisplayName)
                    Case "IPF.StickyNote"
                        folder.Move(WellKnownFolderName.Notes)
                        Console.WriteLine("Move Folder-{0}-to Notes", folder.DisplayName)
                    Case "IPF.Task"
                        folder.Move(WellKnownFolderName.Tasks)
                        Console.WriteLine("Move Folder-{0}-to Tasks", folder.DisplayName)
                    Case Else
                        folder.Move(WellKnownFolderName.Root)
                        Console.WriteLine("Move Folder-{0}-to Root", folder.DisplayName)
                End Select
            Next folder
        End Sub

        ''' <summary>
        ''' Restore the items from the rootFolder.
        ''' </summary>
        ''' <param name="rootFolder">
        ''' We recover deleted items from the following folders:
        ''' 1. DeletedItems: The Deleted Items folder.
        ''' 2. RecoverableItemsDeletions: The root of the folder hierarchy of recoverable items that 
        ''' have been soft-deleted from the Deleted Items folder.
        ''' 3. RecoverableItemsPurges: The root of the folder hierarchy of recoverable items that 
        ''' have been hard-deleted from the Deleted Items folder.
        ''' </param>
        ''' <param name="subject">We can restore the specific items by Subject property of the items</param>
        ''' <param name="startDate">We can restore the specific items by LastModifiedTime 
        ''' property of the items, and the startDate defines the start time.</param>
        ''' <param name="endDate">We can restore the specific items by LastModifiedTime
        ''' property of the items, and the endDate defines the end time.</param>
        Private Shared Sub RestoreItems(ByVal service As ExchangeService,
                                        ByVal rootFolder As WellKnownFolderName,
                                        ByVal subject As String,
                                        ByVal startDate As Date,
                                        ByVal endDate As Date)
            If rootFolder <> WellKnownFolderName.DeletedItems AndAlso
                rootFolder <> WellKnownFolderName.RecoverableItemsDeletions AndAlso
                rootFolder <> WellKnownFolderName.RecoverableItemsPurges Then
                Return
            End If

            Dim filterCollection As New SearchFilter.SearchFilterCollection(LogicalOperator.And)

            Dim subjectFilter As SearchFilter = Nothing
            If String.IsNullOrWhiteSpace(subject) Then
                subjectFilter = New SearchFilter.Exists(ItemSchema.Subject)
            Else
                subjectFilter = New SearchFilter.ContainsSubstring(ItemSchema.Subject, subject)
            End If

            Dim startTimeFilter As SearchFilter =
                New SearchFilter.IsGreaterThanOrEqualTo(ItemSchema.LastModifiedTime, startDate)
            Dim endTimeFilter As SearchFilter =
                New SearchFilter.IsLessThanOrEqualTo(ItemSchema.LastModifiedTime, endDate)

            filterCollection.Add(subjectFilter)
            filterCollection.Add(startTimeFilter)
            filterCollection.Add(endTimeFilter)

            ' Get all the items from the rootFolder
            Dim items As List(Of Item) =
                GetItems(service, filterCollection, rootFolder, PropertySet.FirstClassProperties)

            For Each item As Item In items
                Console.WriteLine(item.ItemClass)

                ' Move the item to the specific folder.
                Select Case item.ItemClass
                    Case "IPM.Appointment"
                        item.Move(WellKnownFolderName.Calendar)
                        Console.WriteLine("Move Item-{0}-to Calendar", item.Subject)
                    Case "IPM.Contact"
                        item.Move(WellKnownFolderName.Contacts)
                        Console.WriteLine("Move Item-{0}-to Contacts", item.Subject)
                    Case "IPM.Activity"
                        item.Move(WellKnownFolderName.Journal)
                        Console.WriteLine("Move Item-{0}-to Journal", item.Subject)
                    Case "IPM.Note"
                        If item.IsFromMe Then
                            item.Move(WellKnownFolderName.SentItems)
                            Console.WriteLine("Move Item-{0}-to SentItems", item.Subject)
                        Else
                            item.Move(WellKnownFolderName.Inbox)
                            Console.WriteLine("Move Item-{0}-to Inbox", item.Subject)
                        End If
                    Case "IPM.StickyNote"
                        item.Move(WellKnownFolderName.Notes)
                        Console.WriteLine("Move Item-{0}-to Notes", item.Subject)
                    Case "IPM.Task"
                        item.Move(WellKnownFolderName.Tasks)
                        Console.WriteLine("Move Item-{0}-to Tasks", item.Subject)
                    Case Else
                        item.Move(WellKnownFolderName.Inbox)
                        Console.WriteLine("Move Item-{0}-to Inbox", item.Subject)
                End Select
            Next item
        End Sub

        Private Shared Function GetFolders(ByVal service As ExchangeService,
                                           ByVal filter As SearchFilter,
                                           ByVal folder As WellKnownFolderName,
                                           ByVal isDeep As Boolean,
                                           ByVal propertySet As PropertySet) As List(Of Folder)
            If service Is Nothing Then
                Return Nothing
            End If

            Dim folders As New List(Of Folder)()

            If propertySet Is Nothing Then
                propertySet = New PropertySet(BasePropertySet.IdOnly)
            End If

            Const pageSize As Int32 = 10
            Dim folderView As New FolderView(pageSize)
            folderView.PropertySet = propertySet
            If isDeep Then
                folderView.Traversal = FolderTraversal.Deep
            End If

            Dim searchResults As FindFoldersResults = Nothing
            Do
                searchResults = service.FindFolders(folder, filter, folderView)
                folders.AddRange(searchResults.Folders)

                folderView.Offset += pageSize
            Loop While searchResults.MoreAvailable

            Return folders
        End Function

        Private Shared Function GetItems(ByVal service As ExchangeService,
                                         ByVal filter As SearchFilter,
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
