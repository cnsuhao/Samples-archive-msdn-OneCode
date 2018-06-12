'****************************** Module Header ******************************\
' Module Name:  OCDIOObject.vb
' Project:	    VBASPNETOnlineFileSystem
' Copyright (c) Microsoft Corporation.
' 
' The class OCDIOObject supplies following features:
' 1. Create a folder
' 2. Delete a folder  
' 3. Rename a folder
' 4. Delete a file
' 5. Rename a file
' 6. Download a file
' 7. Get all files and subfolders in a folder
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Imports System
Imports System.IO
Imports System.Data

Friend Class OCDIOObject

    Private Shared DirInformation As DirectoryInfo
    Private Shared FileInformation As FileInfo

    ''' <summary>
    ''' Create a folder
    ''' </summary>
    ''' <param name="folderPath">The name of folder you want to create</param>
    ''' <returns>The result of the create folder operation</returns>
    ''' <remarks></remarks>
    Public Shared Function CreateFolder(ByVal folderPath As String) As String
        Dim folderName As String = String.Empty

        Try
            OCDIOObject.DirInformation = New DirectoryInfo(folderPath)
            folderName = OCDIOObject.DirInformation.Name
            Dim folderLocation As String =
                folderPath.Substring(0, (folderPath.LastIndexOf("\"c) + 1))

            If Directory.Exists(folderPath) Then
                Return String.Format(
                    "There is already a folder with the name ""{0}"" in the location ""{1}"".",
                    folderName,
                    folderLocation.Replace(OnlineFileSystem.RootPath, "FileServerRoot"))
            End If

            Directory.CreateDirectory(folderPath)
        Catch agEx As System.ArgumentException
            Return String.Format(
                "Failed to create the folder, because of the following error: <br>{0}",
                agEx.Message)
        Catch ptlEx As PathTooLongException
            Return String.Format(
                "Failed to create the folder, because of the following error: <br>{0}",
                ptlEx.Message)
        Catch dnfEx As DirectoryNotFoundException
            Return String.Format(
                "Failed to create the folder, because of the following error: <br>{0}",
                dnfEx.Message)
        End Try

        Return String.Format("The folder ""{0}"" was created successfully!", folderName)
    End Function

    ''' <summary>
    ''' Delete a folder
    ''' </summary>
    ''' <param name="folderPath">The full path of the folder you want to delete</param>
    ''' <returns>The result of the delete folder operation</returns>
    ''' <remarks></remarks>
    Public Shared Function DeleteFolder(ByVal folderPath As String) As String
        Dim folderName As String = String.Empty

        Try
            OCDIOObject.DirInformation = New DirectoryInfo(folderPath)
            folderName = OCDIOObject.DirInformation.Name
            Dim folderLocation As String =
                folderPath.Substring(0, (folderPath.LastIndexOf("\"c) + 1))

            If Not Directory.Exists(folderPath) Then
                Return String.Format(
                    "There is no folder with the name ""{0}"" in the location ""{1}"".",
                    folderName,
                    folderLocation.Replace(OnlineFileSystem.RootPath, "FileServerRoot"))
            End If

            Directory.Delete(folderPath, True)
        Catch dnfEx As DirectoryNotFoundException
            Return String.Format(
                "Failed to delete the folder, because of the following error: <br>{0}",
                dnfEx.Message)
        End Try
        Return String.Format("The folder ""{0}"" was deleted successfully!", folderName)

    End Function

    ''' <summary>
    ''' Rename a folder
    ''' </summary>
    ''' <param name="folderPath">The full path of the folder</param>
    ''' <param name="newName">The new name of the foder</param>
    ''' <returns>The result of the rename operatio</returns>
    ''' <remarks></remarks>
    Public Shared Function RenameFolder(ByVal folderPath As String,
                                        ByVal newName As String) As String
        Dim folderName As String = String.Empty
        Dim newFolderPath As String = String.Empty
        Dim folderLocation As String = String.Empty

        Try
            OCDIOObject.DirInformation = New DirectoryInfo(folderPath)
            folderName = OCDIOObject.DirInformation.Name
            newFolderPath =
                (folderPath.Substring(0, (folderPath.LastIndexOf("\"c) + 1)) & newName)
            folderLocation = folderPath.Substring(0, (folderPath.LastIndexOf("\"c) + 1))

            If Not Directory.Exists(folderPath) Then
                Return String.Format(
                    "There is no folder with the name ""{0}"" in the location ""{1}"".",
                    folderName,
                    folderLocation.Replace(OnlineFileSystem.RootPath, "FileServerRoot"))
            End If

            If (folderName.Equals(newName, StringComparison.OrdinalIgnoreCase)) Then
                Return "The new folder name you input is same with the old one(The folder name is not case sensitive)."
            End If

            If Directory.Exists(newFolderPath) Then
                Return String.Format(
                    "There is already a folder with the name ""{0}"" in the location ""{1}"".",
                    newName, folderLocation.Replace(OnlineFileSystem.RootPath, "FileServerRoot"))
            End If

            Directory.Move(folderPath,
                           (folderPath.Substring(0, (folderPath.LastIndexOf("\"c) + 1)) & newName))
        Catch agEx As System.ArgumentException
            Return String.Format(
                "Failed to rename the folder, because of the following error: <br>{0}",
                agEx.Message)
        Catch ptlEx As PathTooLongException
            Return String.Format(
                "Failed to rename the folder, because of the following error: <br>{0}",
                ptlEx.Message)
        Catch dnfEx As DirectoryNotFoundException
            Return String.Format(
                "Failed to rename the folder, because of the following error: <br>{0}",
                dnfEx.Message)
        End Try
        Return String.Format(
            "The folder ""{0}"" was renamed to ""{1}"" successfully!",
            folderName, newName)
    End Function

    ''' <summary>
    ''' Delete a file
    ''' </summary>
    ''' <param name="filePath">The name of the folder you want to delete</param>
    ''' <returns>The result of deete file operation</returns>
    ''' <remarks></remarks>
    Public Shared Function DeleteFile(ByVal filePath As String) As String
        Dim fileName As String = String.Empty
        Dim fileLocation As String = String.Empty

        Try
            OCDIOObject.FileInformation = New FileInfo(filePath)
            fileName = OCDIOObject.FileInformation.Name
            fileLocation = filePath.Substring(0, (filePath.LastIndexOf("\"c) + 1))
            If Not File.Exists(filePath) Then
                Return String.Format(
                    "There is not a file with the name ""{0}"" in the location ""{1}"".",
                    fileName, fileLocation)
            End If
            File.Delete(filePath)
        Catch dnfEx As DirectoryNotFoundException
            Return String.Format(
                "Failed to delete the file, because of the following error: <br>{0}",
                dnfEx.Message)
        End Try

        Return String.Format("The file ""{0}"" was deleted successfully!",
                             OCDIOObject.FileInformation.Name)

    End Function

    ''' <summary>
    ''' Rename a file
    ''' </summary>
    ''' <param name="filePath">The full path of the file</param>
    ''' <param name="newName">The new name of the file</param>
    ''' <returns>The result of the renaem operation</returns>
    ''' <remarks></remarks>
    Public Shared Function RenameFile(ByVal filePath As String,
                                      ByVal newName As String) As String
        Dim fileName As String = String.Empty
        Dim fileExtension As String = String.Empty
        Dim newFilePath As String = String.Empty
        Dim fileLocation As String = String.Empty

        Try
            OCDIOObject.FileInformation = New FileInfo(filePath)
            fileName = OCDIOObject.FileInformation.Name
            fileExtension = OCDIOObject.FileInformation.Extension
            newFilePath =
                (filePath.Substring(0, (filePath.LastIndexOf("\"c) + 1)) & newName & fileExtension)
            fileLocation = filePath.Substring(0, (filePath.LastIndexOf("\"c) + 1))

            If Not File.Exists(filePath) Then
                Return String.Format(
                    "There is not a file with the name  ""{0}"" in the location ""{1}"".",
                    fileName, fileLocation.Replace(OnlineFileSystem.RootPath, "FileServerRoot"))
            End If

            If (fileName.Equals(newName, StringComparison.OrdinalIgnoreCase)) Then
                Return "The new file name you input is same with the old one(The file name is not case sensitive)."
            End If

            If File.Exists(newFilePath) Then
                Return String.Format(
                    "There is already a file with the name ""{0}"" in the location ""{1}"".",
                    newName, fileLocation.Replace(OnlineFileSystem.RootPath, "FileServerRoot"))
            End If

            File.Move(filePath, (filePath.Substring(0, (filePath.LastIndexOf("\"c) + 1)) &
                                 newName & fileExtension))
        Catch agEx As System.ArgumentException
            Return String.Format(
                "Failed to rename the file, because of the following error: <br>{0}",
                agEx.Message)
        Catch dnfEx As DirectoryNotFoundException
            Return String.Format(
                "Failed to rename the file, because of the following error: <br>{0}",
                dnfEx.Message)
        Catch ptlEx As PathTooLongException
            Return String.Format(
                "Failed to rename the file, because of the following error: <br>{0}",
                ptlEx.Message)
        End Try

        Return String.Format("The file ""{0}"" was renamed to ""{1}"" successfully!",
                             OCDIOObject.FileInformation.Name, newName)

    End Function

    ''' <summary>
    ''' Download a file from the server
    ''' </summary>
    ''' <param name="filePath">The full path of the file on the server</param>
    ''' <remarks></remarks>
    Public Shared Sub DownloadFile(ByVal filePath As String)
        OCDIOObject.FileInformation = New FileInfo(filePath)
        Dim response As HttpResponse = HttpContext.Current.Response
        response.ClearContent()
        response.Clear()
        response.ContentType = "text/plain"
        response.AddHeader("Content-Disposition",
                            ("attachment; filename=" &
                            OCDIOObject.FileInformation.Name & ";"))
        response.TransmitFile(filePath)
        response.Flush()
        response.End()
    End Sub

    ''' <summary>
    ''' Get all files and folders in a folder
    ''' </summary>
    ''' <param name="folderPath">The full path of a folder</param>
    ''' <returns>All files and folders in the folder</returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllItemsInTheDirectory(
                                                ByVal folderPath As String) As DataTable
        Dim dtAllItems As New DataTable
        dtAllItems.Columns.Add("Type")
        dtAllItems.Columns.Add("Name")
        dtAllItems.Columns.Add("Size")
        dtAllItems.Columns.Add("UploadTime")
        dtAllItems.Columns.Add("Location")
        dtAllItems.Columns.Add("FullPath")

        Dim subFolders As String() = Directory.GetDirectories(folderPath)
        Dim subFolderPath As String

        For Each subFolderPath In subFolders
            Dim subFolder As New DirectoryInfo(subFolderPath)
            dtAllItems.Rows.Add(
                New Object() {"Folder",
                              subFolder.Name,
                              "",
                              subFolder.CreationTime.ToString,
                              subFolder.Parent.FullName,
                              subFolder.FullName})
        Next

        Dim files As String() = Directory.GetFiles(folderPath)
        Dim filePath As String

        For Each filePath In files
            Dim file As New FileInfo(filePath)
            dtAllItems.Rows.Add(
                New Object() {
                    Path.GetExtension(file.Name),
                    file.Name,
                    CommonUse.FormatFileSize(file.Length),
                    file.CreationTime.ToString,
                    file.DirectoryName,
                    file.FullName})
        Next
        Return dtAllItems

    End Function

End Class
