'**************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBO365ImportMasterCategory
' Copyright (c) Microsoft Corporation.
' 
' Currently, Outlook Web App (OWA) do not allow user to export and import Master 
' Category List. But some customers relies on this feature for handling their 
' email messages efficiently. So they need a workaround to mitigate this issue. 
' In this application, we will demonstrate how to export and import Master 
' Category List in O365:
' 1. Export the Master Category List
' a. Get the account(s) you want to export the Master Category List from
' b. Get the user configuration of the account(s)
' c. Export the Master Category List from the user configuration
' 2. Import the Master Category List
' a. Get the account(s) you want to import the Master Category List into
' b. Get the file that stores Master Category List
' c. Get the user configuration of the account(s)
' d. Import the Master Category List from the file
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
Imports System.Reflection
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Text

Namespace VBO365ImportMasterCategory
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

            ' Export Master Category List.
            ' If you have Impersonation permission, you can get the Category list of the other 
            ' accounts in the same domain; or if the accounts provide your account the permission 
            ' of Calendar, you can finish the same work. Except the two ways, you can only export 
            ' the Master Category List from your current account.
            ExportMasterCategoryList(service, user.Account, True)
            Console.WriteLine()

            ' Import Master Category List.
            ' If you have Impersonation permission, you can import the Category list into the other 
            ' accounts in the same domain; or if the accounts provide your account the permission 
            ' of Calendar, you can finish the same work. Except the two ways, you can only import 
            ' the Master Category List into your current account.
            ImportMasterCategoryList(service, user.Account, True)
            Console.WriteLine()

            Console.WriteLine("Press any key to exit......")
            Console.ReadKey()
        End Sub

        ''' <summary>
        ''' Export the Master Category List
        ''' </summary>
        ''' <param name="usingImpersonation">If you have Impersonation permission, you can set it as true; 
        ''' or you should set it as false.</param>
        Private Shared Sub ExportMasterCategoryList(ByVal service As ExchangeService,
                                                    ByVal currentAddress As String,
                                                    ByVal usingImpersonation As Boolean)
            Console.WriteLine("Please input the user identity that you want to export " & "Master Category List from(or you can directly press Enter to export the list " & "from current account):")
            Dim inputInfo As String = Console.ReadLine()

            Dim words As String = Nothing
            Dim path As String = Nothing
            If Not String.IsNullOrWhiteSpace(inputInfo) Then
                Dim identities() As String = inputInfo.Split(","c)

                If identities.Length > 1 Then
                    words = "Please input the folder path:"
                    path = InputPath(words, False, True)
                Else
                    words = "Please input the folder or file(.xml) path:"
                    path = InputPath(words, False, False)
                End If

                For Each identity As String In identities
                    Dim nameResolutions As NameResolutionCollection =
                        service.ResolveName(identity, ResolveNameSearchLocation.DirectoryOnly, True)
                    If nameResolutions.Count <> 1 Then
                        Console.WriteLine("{0} is invalid user identity.", identity)
                    Else
                        Dim emailAddress As String = nameResolutions(0).Mailbox.Address
                        Dim filePath As String = GetFilePath(path, identity)

                        ' If our account have Impersonation permission, we can set it.
                        If usingImpersonation Then
                            service.ImpersonatedUserId =
                                New ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress)
                            ExportMasterCategoryListWithImpersonation(service, filePath)
                            service.ImpersonatedUserId = Nothing
                        Else
                            ExportMasterCategoryListWithoutImpersonation(service, emailAddress, filePath)
                        End If
                    End If
                Next identity
            Else
                words = "Please input the folder or file(.xml) path:"
                path = InputPath(words, False, False)
                Dim filePath As String = GetFilePath(path, currentAddress)

                ExportMasterCategoryListWithImpersonation(service, filePath)
            End If
        End Sub

        ''' <summary>
        ''' If our account has permission to access the Calendar of the other users, we use this method 
        ''' to export Mater Category List.
        ''' </summary>
        ''' <param name="userAddress">The user mail address that you want to export the Master Category 
        ''' List from</param>
        ''' <param name="filePath">The path of file that stores the Master Category List</param>
        Private Shared Sub ExportMasterCategoryListWithoutImpersonation(ByVal service As ExchangeService, ByVal userAddress As String, ByVal filePath As String)
            Dim mailbox As New Mailbox(userAddress)
            Dim folderId As New FolderId(WellKnownFolderName.Calendar, mailbox)

            ' Get the UserConfiguration.
            Dim userConfiguration As UserConfiguration =
                userConfiguration.Bind(service, "CategoryList", folderId,
                                       UserConfigurationProperties.XmlData)

            ' Get the data of Master Category List
            Dim categoryListString As String = UTF8Encoding.UTF8.GetString(userConfiguration.XmlData)

            ' Export to the file.
            WriteFile(categoryListString, filePath)
        End Sub

        ''' <summary>
        ''' If our account has Impersonation permission, we can use this method to export the Master 
        ''' Category List; or we can use this method to export the Master Category List from our current 
        ''' account.
        ''' </summary>
        ''' <param name="filePath">The path of file that stores the Master Category List</param>
        Private Shared Sub ExportMasterCategoryListWithImpersonation(ByVal service As ExchangeService,
                                                                     ByVal filePath As String)
            Dim userConfiguration As UserConfiguration =
                userConfiguration.Bind(service, "CategoryList", WellKnownFolderName.Calendar,
                                       UserConfigurationProperties.XmlData)

            Dim categoryListString As String = UTF8Encoding.UTF8.GetString(userConfiguration.XmlData)

            WriteFile(categoryListString, filePath)
        End Sub

        ''' <summary>
        ''' Import the Master Category List.
        ''' </summary>
        ''' <param name="usingImpersonation">If you have Impersonation permission, you can set it as true;
        ''' or you should set it as false.</param>
        Private Shared Sub ImportMasterCategoryList(ByVal service As ExchangeService,
                                                    ByVal currentAddress As String,
                                                    ByVal usingImpersonation As Boolean)
            Console.WriteLine("Please input the user identity that you want to import " & "Master Category List into(or you can directly press Enter to export the list " & "from current account):")
            Dim inputInfo As String = Console.ReadLine()

            Dim words As String = Nothing
            Dim path As String = Nothing
            If Not String.IsNullOrWhiteSpace(inputInfo) Then
                Dim identities() As String = inputInfo.Split(","c)

                If identities.Length > 1 Then
                    words = "Please input the folder path:"
                    path = InputPath(words, True, True)
                Else
                    words = "Please input the folder or file(.xml) path:"
                    path = InputPath(words, True, False)
                End If

                For Each identity As String In identities
                    Dim nameResolutions As NameResolutionCollection =
                        service.ResolveName(identity, ResolveNameSearchLocation.DirectoryOnly, True)
                    If nameResolutions.Count <> 1 Then
                        Console.WriteLine("{0} is invalid user identity.", identity)
                    Else
                        Dim emailAddress As String = nameResolutions(0).Mailbox.Address
                        Dim filePath As String = GetFilePath(path, identity)

                        ' If our account has Impersonation permission, we can set it.
                        If usingImpersonation Then
                            service.ImpersonatedUserId =
                                New ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress)
                            ImportMasterCategoryListWithImpersonation(service, filePath)
                            service.ImpersonatedUserId = Nothing
                        Else
                            ImportMasterCategoryListWithoutImpersonation(service, emailAddress, filePath)
                        End If
                        Console.WriteLine("Import Master Category List into {0}", emailAddress)
                    End If
                Next identity
            Else
                words = "Please input the folder or file(.xml) path:"
                path = InputPath(words, True, False)
                Dim filePath As String = GetFilePath(path, currentAddress)

                ImportMasterCategoryListWithImpersonation(service, filePath)

                Console.WriteLine("Import Master Category List into {0}", currentAddress)
            End If
        End Sub

        ''' <summary>
        ''' If our account has permission to access the Calendar of the other users, we use this method
        ''' to import Master Category List.
        ''' </summary>
        ''' <param name="filePath">The path of file that stores the Master Category List</param>
        Private Shared Sub ImportMasterCategoryListWithoutImpersonation(ByVal service As ExchangeService,
                                                                        ByVal userAddress As String,
                                                                        ByVal filePath As String)
            Dim mailbox As New Mailbox(userAddress)
            Dim folderId As New FolderId(WellKnownFolderName.Calendar, mailbox)

            ' Get UserConfiguration
            Dim userConfiguration As UserConfiguration = userConfiguration.Bind(service, "CategoryList",
                                                                                folderId,
                                                                                UserConfigurationProperties.XmlData)

            ' Set Category List
            Dim categoryListString As String = ReadFile(filePath)
            Dim categoryListBytes() As Byte = UTF8Encoding.UTF8.GetBytes(categoryListString)

            userConfiguration.XmlData = categoryListBytes
            userConfiguration.Update()
        End Sub

        ''' <summary>
        ''' If our account has Impersonation permission, we can use this method to import the Master 
        ''' Category List; or we can use this method to import the Master Category List into our current 
        ''' account.
        ''' </summary>
        ''' <param name="filePath">The path of file that stores the Master Category List</param>
        Private Shared Sub ImportMasterCategoryListWithImpersonation(ByVal service As ExchangeService,
                                                                     ByVal filePath As String)
            Dim userConfiguration As UserConfiguration = userConfiguration.Bind(service, "CategoryList",
                                    WellKnownFolderName.Calendar, UserConfigurationProperties.XmlData)

            Dim categoryListString As String = ReadFile(filePath)
            Dim categoryListBytes() As Byte = UTF8Encoding.UTF8.GetBytes(categoryListString)

            userConfiguration.XmlData = categoryListBytes
            userConfiguration.Update()
        End Sub

        ''' <summary>
        ''' Get the path of folder and file that store the Master Category List.
        ''' </summary>
        Private Shared Function InputPath(ByVal words As String, ByVal isMustExists As Boolean,
                                          ByVal isOnlyFolder As Boolean) As String
            Do
                Console.Write(words)

                Dim path As String = Console.ReadLine()

                If String.IsNullOrWhiteSpace(System.IO.Path.GetExtension(path)) Then
                    If Directory.Exists(path) Then
                        Return path
                    ElseIf Not isMustExists Then
                        Directory.CreateDirectory(path)
                        Return path
                    End If
                ElseIf Not isOnlyFolder Then
                    If System.IO.Path.GetExtension(path).ToUpper() = ".XML" Then
                        If File.Exists(path) Then
                            Return path
                        ElseIf Not isMustExists Then
                            If Not Directory.Exists(System.IO.Path.GetDirectoryName(path)) Then
                                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path))
                            End If

                            Return path
                        End If
                    End If
                End If

                Console.WriteLine("The path is invalid.")
            Loop While True
        End Function

        ''' <summary>
        ''' Get the path of file that store the 
        ''' </summary>
        Private Shared Function GetFilePath(ByVal path As String, ByVal fileName As String) As String
            If String.IsNullOrWhiteSpace(System.IO.Path.GetExtension(path)) Then
                Return System.IO.Path.Combine(path, fileName & ".xml")
            Else
                Return path
            End If
        End Function

        ''' <summary>
        ''' Write the data into file.
        ''' </summary>
        Private Shared Sub WriteFile(ByVal data As String, ByVal filePath As String)
            Using writer As New StreamWriter(filePath)
                writer.Write(data)
            End Using

            Console.WriteLine("Export data into {0} file.", filePath)
        End Sub

        ''' <summary>
        ''' Read data from the file.
        ''' </summary>
        Private Shared Function ReadFile(ByVal filePath As String) As String
            Using reader As New StreamReader(filePath)
                Return reader.ReadToEnd()
            End Using
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
