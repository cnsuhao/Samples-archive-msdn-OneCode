'**************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBOffice365SortTasks
' Copyright (c) Microsoft Corporation.
' 
' We can sort the task list items in Outlook, but the feature isn’t implemented 
' in Outlook Web App (OWA). In this sample, we will demonstrate how to sort 
' task list items by categories in Office 365 Exchange Online.
' We will add the category name as a prefix in the Subject property of a task 
' item so that we can use sort by Subject to sort by category.
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

Namespace VBOffice365SortTasks
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

            SortTasksByCategories(service, Nothing)
            Console.WriteLine()

            Console.WriteLine("Press any key to exit......")
            Console.ReadKey()
        End Sub

        ''' <summary>
        ''' This method will rename the tasks so that we can sort the tasks by the categories.
        ''' </summary>
        Private Shared Sub SortTasksByCategories(ByVal service As ExchangeService,
                                                 ByVal folderName As String)
            Dim filters As New SearchFilter.SearchFilterCollection(LogicalOperator.And)

            If Not String.IsNullOrEmpty(folderName) Then
                Dim searchFilterName As SearchFilter =
                    New SearchFilter.IsEqualTo(FolderSchema.DisplayName, folderName)
                filters.Add(searchFilterName)
            End If

            'Get the Task folders.
            Dim searchFilterClass As SearchFilter =
                New SearchFilter.IsEqualTo(FolderSchema.FolderClass, "IPF.Task")
            filters.Add(searchFilterClass)

            Dim taskFolders As List(Of Folder) =
                GetFolders(service, filters, WellKnownFolderName.Root, True)

            For Each folder In taskFolders
                Dim propertySet As New PropertySet(FolderSchema.DisplayName)
                folder.Load(propertySet)
                Console.WriteLine("Rename the tasks in {0}:", folder.DisplayName)

                Const pageSize As Int32 = 50
                Dim itemView As New ItemView(pageSize)

                Dim findResults As FindItemsResults(Of Item) = Nothing
                Do
                    findResults = folder.FindItems(itemView)
                    For Each item As Item In findResults.Items
                        ' If the item is the task, rename the item.
                        If TypeOf item Is Task Then
                            RenameTask(TryCast(item, Task))
                        End If
                    Next item

                    itemView.Offset += pageSize
                Loop While findResults.MoreAvailable
            Next folder
        End Sub

        ''' <summary>
        ''' Add the category of the task as the prefix of task's subject.
        ''' </summary>
        Private Shared Sub RenameTask(ByVal task As Task)
            If Not (TypeOf task Is Task) Then
                Return
            End If

            Dim preCategory As String = "[" & task.Categories(0).ToString() & "]"

            If Not task.Subject.Contains(preCategory) Then
                task.Subject = preCategory & task.Subject
                task.Update(ConflictResolutionMode.AutoResolve)
                Console.WriteLine("Rename task as {0}", task.Subject)
            End If
        End Sub

        ''' <summary>
        ''' Get the folders in the specific folder.
        ''' </summary>
        Private Shared Function GetFolders(ByVal service As ExchangeService,
                                           ByVal filter As SearchFilter,
                                           ByVal folder As WellKnownFolderName,
                                           ByVal isDeep As Boolean) As List(Of Folder)
            If service Is Nothing Then
                Return Nothing
            End If

            Dim folders As New List(Of Folder)()

            Dim propertySet As New PropertySet(BasePropertySet.IdOnly)

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
