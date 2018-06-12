'**************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBOffice365GetFolderSize
' Copyright (c) Microsoft Corporation.
' 
' In this sample, we will demonstrate how to get the size of the folders and 
' the subfolders.
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

Imports System.Net
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports Microsoft.Exchange.WebServices.Data

Namespace VBOffice365GetFolderSize
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

            ' Define the search filter.
            Dim searchFilter As SearchFilter.RelationalFilter =
                New SearchFilter.IsEqualTo(FolderSchema.DisplayName, "Inbox")
            Console.WriteLine("{0,-15}{1,-30}{2,-10}", "DisplayName", "PathName", "Size(MB)")
            GetFoldersSize(service, searchFilter)

            Console.WriteLine()
            Console.WriteLine("Press any key to exit......")
            Console.ReadKey()
        End Sub

        Private Shared Sub GetFoldersSize(ByVal service As ExchangeService,
                                          ByVal filter As SearchFilter.RelationalFilter)
            GetFoldersSize(service, filter, Nothing)
        End Sub

        Private Shared Sub GetFoldersSize(ByVal service As ExchangeService, ByVal folder As Folder)
            GetFoldersSize(service, Nothing, folder)
        End Sub

        ''' <summary>
        ''' We will get size of the folder and the subfolders in this method.
        ''' </summary>
        Private Shared Sub GetFoldersSize(ByVal service As ExchangeService,
                                          ByVal filter As SearchFilter.RelationalFilter, ByVal folder As Folder)
            If filter Is Nothing AndAlso folder Is Nothing Then
                Return
            End If

            ' The PidTagMessageSizeExtended extended property will return the size of the folder and the subfolders.
            Const PidTagMessageSizeExtended As Int32 = 3592
            Dim exPropFolderSize As New ExtendedPropertyDefinition(PidTagMessageSizeExtended, MapiPropertyType.Integer)

            ' The PR_FOLDER_PATHNAME extended property will return the path of the folder.
            Const PR_FOLDER_PATHNAME As Int32 = 26293
            Dim exPropPathName As New ExtendedPropertyDefinition(PR_FOLDER_PATHNAME, MapiPropertyType.String)

            Dim properSet As New PropertySet(BasePropertySet.IdOnly,
                                             FolderSchema.ChildFolderCount, FolderSchema.DisplayName)
            properSet.Add(exPropFolderSize)
            properSet.Add(exPropPathName)

            Const pageSize As Int32 = 50
            Dim folderView = New FolderView(pageSize)
            folderView.PropertySet = properSet

            Dim searchResults As FindFoldersResults = Nothing

            Do
                If filter IsNot Nothing Then
                    ' If we set the filter, we just first get the root folder.
                    searchResults = service.FindFolders(WellKnownFolderName.MsgFolderRoot, filter, folderView)
                ElseIf folder IsNot Nothing Then
                    ' If we get the folder, we can use FolderTraversal.Deep to get all the subfolders.
                    folderView.Traversal = FolderTraversal.Deep
                    searchResults = folder.FindFolders(folderView)
                End If

                For Each f As Folder In searchResults.Folders
                    Dim size As Single = Single.Parse(f.ExtendedProperties(0).Value.ToString()) / 1048576
                    Console.WriteLine("{0,-15}{1,-30}{2,-10:N2}", f.DisplayName, f.ExtendedProperties(1).Value, size)

                    If filter IsNot Nothing Then
                        ' After we got the root folder, we show also get the subfolders.
                        GetFoldersSize(service, f)
                    End If
                Next f

                folderView.Offset += pageSize
            Loop While searchResults.MoreAvailable
        End Sub

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
