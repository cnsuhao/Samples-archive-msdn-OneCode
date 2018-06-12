'***************************** Module Header *******************************\
' Module Name:  TFSContext.vb
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
Imports System.Net
Imports VBWinformTFSTreeView.Microsoft.OneCode.Utilities
Imports Microsoft.TeamFoundation
Imports Microsoft.TeamFoundation.Client
Imports Microsoft.TeamFoundation.VersionControl.Client

''' <summary>
''' TFS Context class
''' </summary>
''' <remarks></remarks>
Public Class TfsContext

#Region "Constructors"

    ''' <summary>
    ''' Initialize TFSContext
    ''' </summary>
    ''' <param name="tfsCollectionUri">Team Foundation Server Name</param>
    ''' <param name="tvRootName">Team Foundation Server Port</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal tfsCollectionUri As Uri, ByVal tvRootName As String)
        TeamFoundationServerCollectionUri = tfsCollectionUri
        RootName = tvRootName
    End Sub

#End Region

#Region "Public Properties"
    ''' <summary>
    ''' Root Project Collection Name
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RootName As String


    ''' <summary>
    ''' Complete TFS Uri per other TFS properties.
    ''' </summary>
    Public Property TeamFoundationServerCollectionUri As Uri


    ''' <summary>
    ''' VersionControlServer service
    ''' </summary>
    ''' <value></value>
    ''' <returns>If connection created successfully, return true</returns>
    ''' <remarks></remarks>
    Property TfsVersionControlServer As VersionControlServer

#End Region

#Region "Public Methods"
    ''' <summary>
    ''' Create connection to tfs Version Control Service
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Connect() As Boolean
        Try
            TfsVersionControlServer = New TfsTeamProjectCollection(
                TeamFoundationServerCollectionUri).GetService(Of VersionControlServer)()

            Return (Not GetChildLevelTfsVcsItems("$/") Is Nothing)
        Catch tfsUnavailableException As TeamFoundationServiceUnavailableException
            CommonUtilities.ShowWarning(tfsUnavailableException.Message)
        Catch tfsUnauthorizedException As TeamFoundationServerUnauthorizedException
            CommonUtilities.ShowError(tfsUnauthorizedException.Message)
        Catch tfInvalidServerNameException As TeamFoundationInvalidServerNameException
            CommonUtilities.ShowError(tfInvalidServerNameException.Message)
        Catch tfsInvalidResponseException As TeamFoundationServerInvalidResponseException
            CommonUtilities.ShowError(tfsInvalidResponseException.Message)
        Catch secException As System.Security.SecurityException
            CommonUtilities.ShowError(secException.Message)
        Catch webException As WebException
            CommonUtilities.ShowError(webException.Message)
        End Try

        Return False
    End Function

    ''' <summary>
    ''' Get the TFS Version Control Server children items of the ServerNodePath
    ''' </summary>
    ''' <param name="serverNodePath">
    ''' The server node path, for example, "$/WorkSpace/ServerItems.vb"
    ''' </param>
    ''' <returns>
    ''' The collection of children tfs version control server items
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetChildLevelTfsVcsItems(ByVal serverNodePath As String) As ItemSet
        Try
            Return TfsVersionControlServer.GetItems(serverNodePath,
                                                    RecursionType.OneLevel)
        Catch tfsUnavailableException As TeamFoundationServiceUnavailableException
            CommonUtilities.ShowWarning(tfsUnavailableException.Message)
        Catch tfsUnauthorizedException As TeamFoundationServerUnauthorizedException
            CommonUtilities.ShowError(tfsUnauthorizedException.Message)
        Catch tfInvalidServerNameException As TeamFoundationInvalidServerNameException
            CommonUtilities.ShowError(tfInvalidServerNameException.Message)
        Catch tfsInvalidResponseException As TeamFoundationServerInvalidResponseException
            CommonUtilities.ShowError(tfsInvalidResponseException.Message)
        Catch secException As System.Security.SecurityException
            CommonUtilities.ShowError(secException.Message)
        Catch webException As WebException
            CommonUtilities.ShowError(webException.Message)
        End Try

        Return Nothing
    End Function
#End Region

End Class