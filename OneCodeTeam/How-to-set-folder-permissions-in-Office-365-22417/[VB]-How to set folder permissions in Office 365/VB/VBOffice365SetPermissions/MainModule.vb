'**************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBOffice365SetPermissions
' Copyright (c) Microsoft Corporation.
' 
' In this sample, we will demonstrate how to set the permissions in the 
' folder of Office 365 Exchange Online so that the customers can share their 
' folders with the other customers.
' We will finish the following steps in the sample:
' 1. Add two permissions into the Calendar folder;
' 2. Update one permission in the Calendar;
' 3. Remove two permissions from the Calendar.
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
Imports System.Net
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports Microsoft.Exchange.WebServices.Data

Namespace VBOffice365SetPermissions
    Friend Class MainModule
        Private Shared users(1) As UserId

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

            ' Get the Calendar folder.
            Dim searchFilter As SearchFilter.RelationalFilter =
                New SearchFilter.IsEqualTo(FolderSchema.DisplayName, "Calendar")
            Dim calendar As Folder = GetFolder(service, searchFilter)

            If calendar IsNot Nothing Then
                Console.WriteLine("It's success to bind the Calendar folder.")
                Console.WriteLine()

                ' Load the Permissions property of Calendar.
                Dim propertySet As New PropertySet(FolderSchema.Permissions)
                calendar.Load(propertySet)
            Else
                Console.WriteLine("Failed to get the Calendar folder.")
                Console.ReadKey()
                Return
            End If

            Console.WriteLine("Before any operations:")
            OutputFolderPermissionInformation(calendar)

            InputTwoUsers()

            AddFolderPermission(calendar)
            Console.WriteLine("After add two permissions:")
            OutputFolderPermissionInformation(calendar)

            UpdateFolderPermission(calendar, users(0))
            Console.WriteLine("After update one permission:")
            OutputFolderPermissionInformation(calendar)

            RemoveFolderPermission(calendar)
            Console.WriteLine("After remove two permissions:")
            OutputFolderPermissionInformation(calendar)

            Console.WriteLine("Press any key to exit......")
            Console.ReadKey()
        End Sub

        ''' <summary>
        ''' This method will add two permissions.
        ''' </summary>
        Private Shared Sub AddFolderPermission(ByVal folder As Folder)
            Dim newPermissions() As FolderPermission =
                {
                    New FolderPermission(users(0), FolderPermissionLevel.None),
                    New FolderPermission(users(1), FolderPermissionLevel.Editor)
                }

            ' We can't add duplicate permissions. So if we want to add one permission 
            ' and there's permission belong to the same user, we should first remove it.
            Dim permission As FolderPermission
            permission = (
From op In folder.Permissions
Join np In newPermissions On
GetUpperString(op.UserId.PrimarySmtpAddress) Equals np.UserId.PrimarySmtpAddress.ToUpper()
Select op).FirstOrDefault()

            If permission IsNot Nothing Then
                RemoveFolderPermission(folder)
            End If

            folder.Permissions.AddRange(newPermissions)
            folder.Update()

            Console.WriteLine("It's success to add two permissions.")
        End Sub

        ''' <summary>
        ''' This method will update one permission
        ''' </summary>
        Private Shared Sub UpdateFolderPermission(ByVal folder As Folder, ByVal user As UserId)
            ' We should first get the permission that we want to update.
            Dim permission As FolderPermission = (
                From op In folder.Permissions
                Where String.Compare(op.UserId.PrimarySmtpAddress, user.PrimarySmtpAddress, True) = 0
                Select op).FirstOrDefault()

            If permission Is Nothing Then
                Console.WriteLine("The permission of {0} is null.", user.PrimarySmtpAddress)
                Return
            End If

            ' We can change the properties of Permission.
            permission.PermissionLevel = FolderPermissionLevel.Reviewer
            permission.ReadItems = FolderPermissionReadAccess.FullDetails
            permission.IsFolderVisible = True
            permission.EditItems = PermissionScope.None

            folder.Update()

            Console.WriteLine("It's success to update the permission.")
        End Sub

        ''' <summary>
        ''' This method will remove two permissions.
        ''' </summary>
        Private Shared Sub RemoveFolderPermission(ByVal folder As Folder)
            ' We should first get all the permissions that we want to remove.
            Dim permissions As IList(Of FolderPermission)
            permissions = (
               From op In folder.Permissions
               Join u In users On
               GetUpperString(op.UserId.PrimarySmtpAddress) Equals u.PrimarySmtpAddress.ToUpper()
               Select op).ToList()

            For Each permission As FolderPermission In permissions
                If folder.Permissions.Remove(permission) Then
                    folder.Update()
                    Console.WriteLine("It's success to remove the permission of {0}.",
                                      permission.UserId.PrimarySmtpAddress)
                Else
                    Console.WriteLine("Failed to remove the permission of {0}.",
                                      permission.UserId.PrimarySmtpAddress)
                End If
            Next permission
        End Sub

        Private Shared Sub OutputFolderPermissionInformation(ByVal folder As Folder)
            Console.WriteLine("All the Permissions:")

            For Each permission As FolderPermission In folder.Permissions
                Console.WriteLine("{0,-20} {1}", permission.PermissionLevel, permission.UserId.PrimarySmtpAddress)
            Next permission

            Console.WriteLine()
        End Sub

        Private Shared Sub InputTwoUsers()
            Console.WriteLine("Please input two user e-mail address:")
            Console.Write("First Address:")
            Dim firstAddress As String = Console.ReadLine()
            Console.Write("Second Address:")
            Dim secondAddress As String = Console.ReadLine()

            If String.IsNullOrWhiteSpace(firstAddress) OrElse String.IsNullOrWhiteSpace(secondAddress) Then
                Console.WriteLine("Address cannot be null.")
                InputTwoUsers()
                Return
            End If

            Dim firstUser As New UserId(firstAddress)
            Dim secondUser As New UserId(secondAddress)

            users(0) = firstUser
            users(1) = secondUser

            Console.WriteLine("It's success to add two users.")
            Console.WriteLine()
        End Sub

        Private Shared Function GetFolder(ByVal service As ExchangeService,
                                          ByVal filter As SearchFilter.RelationalFilter) As Folder
            Dim propertySet As New PropertySet(BasePropertySet.IdOnly)

            Dim folderView As New FolderView(5)
            folderView.PropertySet = propertySet

            Dim searchResults As FindFoldersResults
            searchResults = service.FindFolders(WellKnownFolderName.MsgFolderRoot, filter, folderView)

            Return searchResults.FirstOrDefault()
        End Function

        Private Shared Function AutodiscoverUrl(ByVal service As ExchangeService,
                                                ByVal user As UserInfo) As Boolean
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

        Private Shared Function GetUpperString(ByVal str As String) As String

            If str IsNot Nothing Then
                Return str.ToUpper()
            Else
                Return str
            End If

        End Function

    End Class
End Namespace
