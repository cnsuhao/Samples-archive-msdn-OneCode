'****************************** Module Header ******************************\
' Module Name:    RenameDocumentDuringUpload.vb
' Project:        VBSharePointRenameDocumentDuringUpload
' Copyright (c) Microsoft Corporation
'
' The sample code will show you how to rename the document using event receiver during upload. 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/
Option Explicit On
Option Strict On

Imports System
Imports System.Security.Permissions
Imports Microsoft.SharePoint
Imports Microsoft.SharePoint.Utilities
Imports Microsoft.SharePoint.Workflow
Imports System.Text.RegularExpressions

Public Class RenameDocumentDuringUpload
    Inherits SPItemEventReceiver

    ''' <summary>
    ''' An item was added.
    ''' </summary>
    Public Overrides Sub ItemAdded(ByVal properties As SPItemEventProperties)
        Dim eventHandlerClassName = Me.[GetType]().FullName
        'Trace Information
        Trace.TraceInformation("[TIES]: Entering event handler " & eventHandlerClassName)
        Try
            ' Sets the value that indicates whether event firing is enabled to false.
            EventFiringEnabled = False

            ' This url should be like:sharepointlist/filename (for example: books/mybook.doc)
            Dim url As String = properties.AfterUrl

            ' Define a new url (for example: books/ ID_mybook.doc).      
            Dim newUrl As String = String.Empty

            ' Get the file
            Dim file As SPFile = properties.ListItem.File

            newUrl = properties.ListTitle + "/" & CleanupFileName(file.Name)

            ' Rename the document by moving the file to a specified destination url
            file.MoveTo(newUrl, True)

            ' Trace Information
            Trace.TraceInformation("[TIES]: Leaving event handler " & eventHandlerClassName)
        Catch ex As Exception
            ' Trace Information
            Trace.TraceInformation(("[TIES]: Error in event handler " & eventHandlerClassName) + ex.Message + ex.StackTrace)
            properties.Cancel = True
            properties.ErrorMessage = "Error in event"
        Finally
            ' Sets the value that indicates whether event firing is enabled to true
            EventFiringEnabled = True
        End Try

    End Sub

    ''' <summary>
    ''' Clean up FileName
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns></returns>
    Public Shared Function CleanupFileName(ByVal fileName As String) As String
        ' Special Characters Not Allowed: ~ " # % & * : < > ? / \ { | }      
        If Not String.IsNullOrEmpty(fileName) Then
            ' Regex to Replace the Special Character
            fileName = Regex.Replace(fileName, "[~#'%&*:<>?/\{|}\n]", "")

            If fileName.Contains("""") Then
                fileName = fileName.Replace("""", "")
            End If

            If fileName.StartsWith(".", StringComparison.OrdinalIgnoreCase) OrElse fileName.EndsWith(".", StringComparison.OrdinalIgnoreCase) Then
                fileName = fileName.TrimStart(New Char() {"."c})
                fileName = fileName.TrimEnd(New Char() {"."c})
            End If
            If fileName.IndexOf("..", StringComparison.OrdinalIgnoreCase) > -1 Then
                fileName = fileName.Replace("..", "")
            End If
            fileName = fileName.Replace("/n", String.Empty)
        End If

        Return (Guid.NewGuid().ToString()) + fileName
    End Function

End Class
