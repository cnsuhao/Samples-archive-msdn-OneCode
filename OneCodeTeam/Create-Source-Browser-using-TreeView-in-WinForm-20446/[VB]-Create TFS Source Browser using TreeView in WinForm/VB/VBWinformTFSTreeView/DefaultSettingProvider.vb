'***************************** Module Header *******************************\
' Module Name:  DefaultSettingProvider.vb
' Project:      VBWinformTFSTreeView
' Copyright (c) Microsoft Corporation.
' 
' TFS Context class to deal with tfs connection, tfs operations.
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
Imports System.Collections.Generic
Imports Microsoft.TeamFoundation.Client

''' <summary>
''' Provide default selection to the tfs connection dialog.
''' </summary>
''' <remarks></remarks>
Public Class DefaultSettingProvider
    Implements ITeamProjectPickerDefaultSelectionProvider

    ''' <summary>
    ''' Return the default collection id from the default settings.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDefaultServerUri() As Uri Implements ITeamProjectPickerDefaultSelectionProvider.GetDefaultServerUri
        Dim defaultUriString As String = My.Settings.DefaultServerUri
        If (Uri.IsWellFormedUriString(defaultUriString, UriKind.Absolute)) Then
            Return New Uri(defaultUriString)
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Return the default collection id from the default settings.
    ''' </summary>
    ''' <param name="instanceUri"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDefaultCollectionId(ByVal instanceUri As Uri) As Guid? Implements ITeamProjectPickerDefaultSelectionProvider.GetDefaultCollectionId
        Return My.Settings.DefaultCollectionId
    End Function

    ''' <summary>
    ''' Always return null for default projects.
    ''' </summary>
    ''' <param name="collectionId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDefaultProjects(ByVal collectionId As Guid) As IEnumerable(Of String) Implements ITeamProjectPickerDefaultSelectionProvider.GetDefaultProjects
        Return Nothing
    End Function

    ''' <summary>
    ''' Save settings into the default settings.
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <remarks></remarks>
    Public Shared Sub SaveSettings(ByVal collection As TfsTeamProjectCollection)
        My.Settings.DefaultServerUri = collection.ConfigurationServer.Uri.AbsoluteUri
        My.Settings.DefaultCollectionId = collection.InstanceId
        My.Settings.Save()
    End Sub
End Class
