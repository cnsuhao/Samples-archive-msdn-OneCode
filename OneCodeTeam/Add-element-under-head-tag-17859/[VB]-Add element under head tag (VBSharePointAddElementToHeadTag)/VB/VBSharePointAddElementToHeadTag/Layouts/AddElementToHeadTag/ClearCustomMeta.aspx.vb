'****************************** Module Header ******************************\
' Module Name:    ClearCustomMeta.ascx.vb
' Project:        VBSharePointAddElementToHeadTag
' Copyright (c) Microsoft Corporation
'
' This page is used to clear the custom Meta information.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports System
Imports Microsoft.SharePoint
Imports Microsoft.SharePoint.WebControls
Imports Microsoft.SharePoint.Utilities

Namespace Layouts.AddElementToHeadTag

    Partial Public Class ClearCustomMeta
        Inherits LayoutsPageBase

        Private myWeb As SPWeb = SPContext.Current.Web

        Protected Sub cmdClearMeta_Click(sender As Object, e As EventArgs)
            ' A List to store the Meta which we need to remove.
            Dim listKey As New List(Of String)()

            ' Loop AllProperties to identify the items which need to be removed.
            For Each objDE As System.Collections.DictionaryEntry In myWeb.AllProperties
                If objDE.Key.ToString().Contains("-CustomMeta") Then
                    listKey.Add(objDE.Key.ToString())
                End If
            Next

            ' Remove the custom Meta
            For i As Integer = 0 To listKey.Count - 1
                myWeb.AllProperties.Remove(listKey(i))
            Next

            myWeb.Update()

            SPUtility.Redirect("settings.aspx", SPRedirectFlags.RelativeToLayoutsPage, Me.Context)

        End Sub

        Protected Overrides Sub OnInit(e As EventArgs)
            AddHandler cmdClearMeta.Click, AddressOf cmdClearMeta_Click
        End Sub

    End Class

End Namespace
