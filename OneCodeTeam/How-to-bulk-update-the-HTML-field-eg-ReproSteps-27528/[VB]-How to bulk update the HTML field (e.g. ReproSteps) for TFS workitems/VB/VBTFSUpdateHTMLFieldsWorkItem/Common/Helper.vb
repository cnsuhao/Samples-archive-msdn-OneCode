'****************************** Module Header ******************************\
' Module Name:  Helper.vb
' Project:      Common
' Copyright (c) Microsoft Corporation.
'
' Helper class try to get collection uri from either the input or the environment variable. 
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Namespace Common

    Public Class Helper
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

