'****************************** Module Header ******************************\
' Module Name:  Helper.vb
' Project:      VBTFSUpdateHyperLink
' Copyright (c) Microsoft Corporation.
'
' This sample demonstrates how to bulk update the hyperlink field for TFS workitems.
' Helper class try to get the collection uri from either the input or the environment variable.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace UpdateHyperLink
    Public NotInheritable Class Helper
        Private Sub New()
        End Sub
#Region "Methods"

        Public Shared Function GetCollectionUri(args As String()) As Uri
            Dim collectionUri As [String]

            If (args.Length > 0) AndAlso (Not [String].IsNullOrEmpty(args(0))) AndAlso Uri.IsWellFormedUriString(args(0), UriKind.Absolute) Then
                collectionUri = args(0)
            Else
                collectionUri = Environment.GetEnvironmentVariable("TFS_COLLECTION_URI")
            End If

            While [String].IsNullOrEmpty(collectionUri)
                Console.WriteLine("Please enter your TFS Team Project Collection URI," & vbLf + "or you can set it in TFS_COLLECTION_URI environment variable:")

                collectionUri = Console.ReadLine()

                If Not Uri.IsWellFormedUriString(collectionUri, UriKind.Absolute) Then
                    collectionUri = Nothing
                End If
            End While

            Return New Uri(collectionUri)
        End Function

#End Region
    End Class
End Namespace


