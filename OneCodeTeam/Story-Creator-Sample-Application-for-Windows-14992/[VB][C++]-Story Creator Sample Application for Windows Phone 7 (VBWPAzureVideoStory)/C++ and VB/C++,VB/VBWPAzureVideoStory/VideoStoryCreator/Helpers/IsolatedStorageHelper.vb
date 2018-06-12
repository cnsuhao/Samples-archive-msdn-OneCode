'********************************* Module Header *********************************\
' Module Name: IsolatedStorageHelper.vb
' Project: VideoStoryCreator
' Copyright (c) Microsoft Corporation.
' 
' A helper class that performs I/O against isolated storage.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/


Imports System.IO.IsolatedStorage
Imports System.IO

Public NotInheritable Class IsolatedStorageHelper
    ''' <summary>
    ''' Delete a file
    ''' </summary>
    ''' <param name="name">The name of the file to be deleted.</param>
    Public Shared Sub DeleteFile(name As String)
        Dim userStore As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
        If userStore.FileExists(name) Then
            userStore.DeleteFile(name)
        End If
    End Sub

    ''' <summary>
    ''' Rename the file.
    ''' First create a new file and copy the contents of the original file.
    ''' Then delete the original file.
    ''' </summary>
    Public Shared Sub RenameFile(originalName As String, newName As String)
        Dim userStore As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
        If userStore.FileExists(originalName) Then
            Using originalFileStream As FileStream = userStore.OpenFile(originalName, System.IO.FileMode.Open)
                Using newFileStream As FileStream = userStore.CreateFile(newName)
                    Dim buffer As Byte() = New Byte(originalFileStream.Length - 1) {}
                    originalFileStream.Read(buffer, 0, buffer.Length)
                    newFileStream.Write(buffer, 0, buffer.Length)
                End Using
            End Using
            userStore.DeleteFile(originalName)
        End If
    End Sub

    ''' <summary>
    ''' Checks if the file with the specified name already exists.
    ''' </summary>
    Public Shared Function FileExists(name As String) As Boolean
        Dim userStore As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
        Return userStore.FileExists(name)
    End Function
End Class
