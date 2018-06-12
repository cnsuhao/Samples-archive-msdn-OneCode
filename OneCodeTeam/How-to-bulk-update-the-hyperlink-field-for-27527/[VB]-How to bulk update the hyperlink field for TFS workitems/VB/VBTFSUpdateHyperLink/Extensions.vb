'****************************** Module Header ******************************\
' Module Name:  Extensions.vb
' Project:      VBTFSUpdateHyperLink
' Copyright (c) Microsoft Corporation.
'
' This sample demonstrates how to bulk update the hyperlink field for TFS workitems.
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
Imports Microsoft.TeamFoundation.WorkItemTracking.Client

Namespace UpdateHyperLink

    Public NotInheritable Class Extensions
        Private Sub New()
        End Sub
#Region "Methods"


        Public Shared Function IsDisplayable(field As Field, revision As Integer) As Boolean
            If field.FieldDefinition Is Nothing Then
                Return False
            End If

            Select Case DirectCast(field.Id, CoreField)
                Case CoreField.History, CoreField.ChangedDate, CoreField.RevisedDate, CoreField.ChangedBy, CoreField.AuthorizedAs
                    Return False
                Case Else

                    Exit Select
            End Select

            If revision = 0 Then
                If field.Value Is Nothing OrElse Equals(field.Value, [String].Empty) OrElse Equals(field.Value, 0) Then
                    Return False
                End If
            End If

            Return True
        End Function

#End Region
    End Class
End Namespace

