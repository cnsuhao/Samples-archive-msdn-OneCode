'***************************** Module Header ******************************\
' Module Name:  RibbonVisibilityControl.vb
' Project:      VBSharePointHideRibbonFromAnonymous
' Copyright (c) Microsoft Corporation.
'
' The Delegate Control of the Project.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/


Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports Microsoft.SharePoint

Namespace RibbonVisibility.ControlTemplates
    Partial Public Class RibbonVisibilityControl
        Inherits UserControl

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim values As String = GetValues()
            If values = [String].Empty OrElse values = Helper.Constants.[INHERITS] Then
                Return
            End If

            Dim hideForAnonymous As Boolean = [Boolean].Parse(values.Split(";"c)(0))
            ' Check whether the user is anonymous or not.
            If SPContext.Current.Web.CurrentUser Is Nothing Then
                If hideForAnonymous Then
                    InjectScript()
                Else
                    Return
                End If
            End If
        End Sub

        Private Function GetValues() As String
            Dim web As SPWeb = SPContext.Current.Web

            While web IsNot Nothing
                Dim value As String = GetValues(web)
                If value <> Helper.Constants.[INHERITS] Then
                    Return value
                Else
                    web = web.ParentWeb
                End If
            End While

            Return String.Empty
        End Function

        Private Function GetValues(ByVal web As SPWeb) As String
            If web.Properties.ContainsKey(Helper.Constants.KEY) Then
                Return web.Properties(Helper.Constants.KEY)
            Else
                Return Helper.Constants.[INHERITS]
            End If
        End Function

        Private Sub InjectScript()
            Dim scriptfile As String = "/_controltemplates/SPRibbonVisibility/RibbonVisibility.js"

            ScriptManager.RegisterClientScriptInclude(Me, GetType(RibbonVisibilityControl), "SPRibbonVisibility", scriptfile)
        End Sub
    End Class
End Namespace