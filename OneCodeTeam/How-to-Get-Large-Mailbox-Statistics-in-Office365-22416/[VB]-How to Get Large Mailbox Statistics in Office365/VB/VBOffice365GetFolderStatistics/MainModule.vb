'**************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBOffice365GetFolderStatistics
' Copyright (c) Microsoft Corporation.
' 
' Some of you find your Outlook is frozen when receiving emails. One workaround 
' is moving the large emails to a new folder to allow Outlook finish the 
' synchronization. But before moving these large emails, we need to identify 
' these large email messages and find a proper destination folder for these 
' emails. In this sample, we will demonstrate how to get the statistics of the 
' folders and the subfolders.
' In this sample, we will use two extended properties:
' 1. PidTagMessageSize(Property ID: 0x0E08);
' 2. PR_FOLDER_PATHNAME (Property ID: 0x66B5).
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Linq
Imports Microsoft.Exchange.WebServices.Data
Imports System.Net
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates

Namespace VBOffice365GetFolderStatistics
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

            ' Get the statistics of the folders in Inbox. 
            Dim folderName As String = "Inbox"
            ' Email is the large email if it's more than 1 MB.
            GetFoldersStatistics(service, folderName, 1024 * 1024)
            Console.WriteLine()

            Console.WriteLine("Press any key to exit......")
            Console.ReadKey()
        End Sub

        Private Shared Sub GetFoldersStatistics(ByVal service As ExchangeService,
                                                ByVal folderName As String, ByVal largeSize As Int32)
            ' The PidTagMessageSizeExtended extended property will return the size 
            ' of the folder and the subfolders.
            Const pidTagMessageSizeExtended As Int32 = 3592
            Dim exPropFolderSize As New ExtendedPropertyDefinition(pidTagMessageSizeExtended,
                                                                   MapiPropertyType.Integer)
            ' The PR_FOLDER_PATHNAME extended property will return the path of the folder.
            Const PR_FOLDER_PATHNAME As Int32 = 26293
            Dim exPropDefPathName As New ExtendedPropertyDefinition(PR_FOLDER_PATHNAME,
                                                                    MapiPropertyType.String)

            Dim folderPropertySet As New PropertySet(BasePropertySet.IdOnly, FolderSchema.DisplayName,
                                            FolderSchema.ChildFolderCount, FolderSchema.TotalCount)
            folderPropertySet.Add(exPropFolderSize)
            folderPropertySet.Add(exPropDefPathName)

            Dim rootFilter As SearchFilter = New SearchFilter.IsEqualTo(FolderSchema.DisplayName, "Inbox")

            ' First get the root folders.
            Dim rootFolders As List(Of Folder) = GetFolders(service, rootFilter,
                                WellKnownFolderName.MsgFolderRoot, False, folderPropertySet)
            Console.WriteLine("Get the root folders.")
            Console.WriteLine()

            Console.WriteLine("{0,-11} {1,-20} {2,-8} {3,-9} {4,-14} {5,-11}",
                              "DisplayName", "Path", "Size(MB)", "ItemCount",
                              "HasAttachments", "LargeEmails")

            For Each root As Folder In rootFolders
                ' Get the statics of the root folders.
                GetItemsStatics(root, largeSize)

                Dim subFolders As List(Of Folder) = GetFolders(root, Nothing, True, folderPropertySet)

                For Each folder As Folder In subFolders
                    GetItemsStatics(folder, largeSize)
                Next folder
            Next root
        End Sub

        Private Shared Sub GetItemsStatics(ByVal folder As Folder, ByVal largeSize As Int32)
            Dim itemPropertySet As New PropertySet(BasePropertySet.IdOnly,
                            ItemSchema.Subject, ItemSchema.Size, ItemSchema.HasAttachments)

            Const pageSize As Int32 = 100

            Dim filters As New SearchFilter.SearchFilterCollection(LogicalOperator.Or)

            ' Get the emails that is larger or have the attachments
            Dim filterAttachment As SearchFilter =
                New SearchFilter.IsEqualTo(ItemSchema.HasAttachments, True)
            Dim filterLargeEmail As SearchFilter =
                New SearchFilter.IsGreaterThan(ItemSchema.Size, largeSize)
            filters.Add(filterAttachment)
            filters.Add(filterLargeEmail)

            Dim itemView As New ItemView(pageSize)
            itemView.PropertySet = itemPropertySet
            itemView.Traversal = ItemTraversal.Shallow

            Dim searchResults As FindItemsResults(Of Item) = Nothing
            Dim items As New List(Of Item)()

            Do
                searchResults = folder.FindItems(filters, itemView)
                items.AddRange(searchResults.Items)

                itemView.Offset += pageSize
            Loop While searchResults.MoreAvailable

            ' The number of the emails that have the attachments.
            Dim itemsWithAttachmentNum As Int32 = (
                From i In items
                Where i.HasAttachments
                Select i).Count()

            ' The number of the large emails.
            Dim largeItemNum As Int32 = (
                From i In items
                Where i.Size > largeSize
                Select i).Count()

            Dim sizeInMb As Double =
                Double.Parse(folder.ExtendedProperties(0).Value.ToString()) / (1024 * 1024)
            Console.WriteLine("{0,-11} {1,-20} {2,-8:N2} {3,-9} {4,-14} {5,-11}",
                              folder.DisplayName, folder.ExtendedProperties(1).Value,
                              sizeInMb, folder.TotalCount, itemsWithAttachmentNum, largeItemNum)
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

        Private Shared Function GetFolders(ByVal root As Folder,
                                           ByVal filter As SearchFilter,
                                           ByVal isDeep As Boolean,
                                           ByVal propertySet As PropertySet) As List(Of Folder)
            If root Is Nothing Then
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
                searchResults = root.FindFolders(filter, folderView)
                folders.AddRange(searchResults.Folders)

                folderView.Offset += pageSize
            Loop While searchResults.MoreAvailable

            Return folders
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

