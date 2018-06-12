'****************************** Module Header ******************************\
' Module Name:    HeadInTag.ascx.vb
' Project:        VBSharePointAddElementToHeadTag
' Copyright (c) Microsoft Corporation
'
' This page is used to set the custom Meta information.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports Microsoft.SharePoint
Imports Microsoft.SharePoint.WebControls
Imports Microsoft.SharePoint.Utilities
Imports System.Web.UI.WebControls
Imports System.Web.UI


Namespace Layouts.AddElementToHeadTag
    Partial Public Class SetMeta
        Inherits LayoutsPageBase
        ' Current web
        Private myWeb As SPWeb = SPContext.Current.Web

        ' Keyword
        Private strCustomMetaKey As String = String.Empty

        ' Description
        Private strCustomMetaDescription As String = String.Empty

        ' Set the Meta for the specified page
        Protected Sub cmdAddMeta_Click(sender As Object, e As EventArgs)
            Dim strPage As String = tbPageName.Text.Trim()
            Dim file As SPFile = myWeb.GetFile("/SitePages/" & strPage & "")
            If file.Exists Then
                strCustomMetaKey = strPage & "-CustomMetaKey"
                strCustomMetaDescription = strPage & "-CustomMetaDescription"

                ' Custom Meta
                SetOrModifyCustomMeta(tbKey.Text, tbDescription.Text)

                myWeb.Update()

                SPUtility.Redirect("settings.aspx", SPRedirectFlags.RelativeToLayoutsPage, Me.Context)
            Else
                ltrMsg.Text = "No Such file Exists"
            End If
        End Sub

        ' Set the Default Meta
        Protected Sub cmdAddDefaultMeta_Click(sender As Object, e As EventArgs)
            strCustomMetaKey = "Default-CustomMetaKey"
            strCustomMetaDescription = "Default-CustomMetaDescription"

            SetOrModifyCustomMeta(tbDefaultKey.Text, tbDefaultDescription.Text)

            myWeb.Update()

            SPUtility.Redirect("settings.aspx", SPRedirectFlags.RelativeToLayoutsPage, Me.Context)
        End Sub

        ''' <summary>
        ''' Use the value to add or modify the Meta information in AllProperties.
        ''' </summary>
        ''' <param name="strKey">New keyword</param>
        ''' <param name="strDescription">New description</param>
        Private Sub SetOrModifyCustomMeta(strKey As String, strDescription As String)
            ' Add or modify the keyword
            If String.IsNullOrEmpty(TryCast(SPContext.Current.Web.GetProperty(strCustomMetaKey), String)) Then
                myWeb.AllProperties.Add(strCustomMetaKey, strKey)
            Else
                myWeb.AllProperties(strCustomMetaKey) = strKey
            End If

            ' Add or modify the description
            If String.IsNullOrEmpty(TryCast(myWeb.GetProperty(strCustomMetaDescription), String)) Then
                myWeb.AllProperties.Add(strCustomMetaDescription, strDescription)
            Else
                myWeb.AllProperties(strCustomMetaDescription) = strDescription
            End If
        End Sub

        Protected Overrides Sub OnInit(e As EventArgs)
            AddHandler cmdAddMeta.Click, AddressOf cmdAddMeta_Click
            AddHandler cmdAddDefaultMeta.Click, AddressOf cmdAddDefaultMeta_Click
        End Sub

        Protected Overrides Sub OnPreRender(e As EventArgs)
            ' Initialize the default meta information
            tbDefaultKey.Text = TryCast(myWeb.GetProperty("Default-CustomMetaKey"), String)
            tbDefaultDescription.Text = TryCast(myWeb.GetProperty("Default-CustomMetaDescription"), String)
        End Sub
    End Class
End Namespace



