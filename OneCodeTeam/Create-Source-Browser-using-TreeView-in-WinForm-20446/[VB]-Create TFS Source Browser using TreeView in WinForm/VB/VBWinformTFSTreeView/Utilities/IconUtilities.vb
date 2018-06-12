'***************************** Module Header *******************************\
' Module Name:  IconUtilities.vb
' Project:      VBWinformTFSTreeView
' Copyright (c) Microsoft Corporation.
' 
' Utility class to help get registered file type associated icons
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Imports System
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Drawing
Imports Microsoft.Win32

Namespace Microsoft.OneCode.Utilities

    ''' <summary>
    ''' Icon Utilities
    ''' </summary>
    ''' <remarks></remarks>
    Public Class IconUtilities

        ''' <summary>
        ''' Get the small icon associated with registered file types.
        ''' </summary>
        ''' <param name="fileType">
        ''' Support "unknown", "folder" and other ".*" extensions.
        ''' </param>
        ''' <returns>Icons that associated with file extensions.</returns>
        ''' <remarks></remarks>
        Friend Shared Function GetSmallIconByFileType(ByVal fileType As String) As Icon

            ' Parameter check is in the GetIconPathFromClassesRoot
            Dim regIconString As String = GetIconPathFromClassesRoot(fileType)

            Dim fileIcon As String() = regIconString.Split(New Char() {","c})

            ' Undefined icon
            If (fileIcon.Length <> 2) Then
                fileIcon = New String() {Path.Combine(Environment.SystemDirectory,
                                                      "shell32.dll"), "2"}
            End If

            Dim hIconSmall As IntPtr() = New IntPtr() {IntPtr.Zero}
            Dim extractedIcon As Icon = Nothing
            Try
                Dim readIconCount As Integer = NativeMethods.ExtractIconEx(fileIcon(0),
                    Integer.Parse(fileIcon(1)), Nothing, hIconSmall, 1)

                If (readIconCount > 0 AndAlso hIconSmall(0) <> IntPtr.Zero) Then
                    extractedIcon = DirectCast(Icon.FromHandle(hIconSmall(0)).Clone, Icon)
                End If
            Catch comExp As COMException
            Finally
                For Each ptr As IntPtr In hIconSmall
                    If (ptr <> IntPtr.Zero) Then
                        NativeMethods.DestroyIcon(ptr)
                    End If
                Next
            End Try

            If (extractedIcon Is Nothing) Then
                Return GetSmallIconByFileType("")
            Else
                Return extractedIcon
            End If

        End Function

        ''' <summary>
        ''' Get the icon path from the Classes Root Registry per the file extension
        ''' </summary>
        ''' <param name="fileExtention">
        ''' Support "unknown", "folder" and other ".*" extensions.
        ''' </param>
        ''' <returns>
        ''' The icon path such as
        ''' "C:\Program Files\Microsoft Visual Studio 10.0\VC#\VCSPackages\csproj.dll,1"
        ''' </returns>
        ''' <remarks></remarks>
        Private Shared Function GetIconPathFromClassesRoot(ByVal fileExtention As String) As String

            Dim regIconPath As String = String.Empty
            Const unknownFileTypeIcon As String = "shell32.dll,0"
            Const folderFileTypeIcon As String = "shell32.dll,3"
            Const folderStr As String = "folder"
            Const unknownStr As String = "unknown"
            Const defaultIconStr As String = "DefaultIcon"
            Const defaultRegValue As String = ""
            Const extensionPrefix As Char = "."c

            If (String.IsNullOrEmpty(fileExtention) OrElse _
                (String.Compare(fileExtention, unknownStr, _
                StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return Path.Combine(Environment.SystemDirectory, unknownFileTypeIcon)
            End If

            If (String.Compare(fileExtention, folderStr,
                StringComparison.OrdinalIgnoreCase) = 0) Then
                Return Path.Combine(Environment.SystemDirectory, folderFileTypeIcon)
            End If

            If (fileExtention.Chars(0) = extensionPrefix) Then
                Dim regKey As RegistryKey =
                    Registry.ClassesRoot.OpenSubKey(fileExtention, False)

                If (Not regKey Is Nothing) Then
                    Dim regFileTypePath As String =
                        TryCast(regKey.GetValue(defaultRegValue), String)
                    regKey.Close()

                    If Not String.IsNullOrEmpty(regFileTypePath) Then
                        regKey = Registry.ClassesRoot.OpenSubKey(
                            Path.Combine(regFileTypePath, defaultIconStr), False)

                        If (Not regKey Is Nothing) Then
                            regIconPath =
                                TryCast(regKey.GetValue(defaultRegValue), String)
                            regKey.Close()
                        End If
                    End If
                End If
            End If

            If String.IsNullOrEmpty(regIconPath) Then
                regIconPath = Path.Combine(Environment.SystemDirectory, unknownFileTypeIcon)
            End If

            Return regIconPath
        End Function




    End Class

End Namespace
