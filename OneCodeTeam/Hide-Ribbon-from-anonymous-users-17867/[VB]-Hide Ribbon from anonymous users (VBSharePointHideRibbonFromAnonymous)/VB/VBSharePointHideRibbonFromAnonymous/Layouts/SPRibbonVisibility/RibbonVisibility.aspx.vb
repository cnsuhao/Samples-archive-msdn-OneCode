'***************************** Module Header ******************************\
' Module Name:  RibbonVisibilitySettings.vb
' Project:      VBSharePointHideRibbonFromAnonymous
' Copyright (c) Microsoft Corporation.
'
' Operation of the hide ribbon from Anonymous.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/


Imports Microsoft.SharePoint
Imports Microsoft.SharePoint.WebControls
Imports Microsoft.SharePoint.Utilities
Imports System.Web
Imports System.Web.UI
Imports System.Text

Namespace RibbonVisibility.Layouts
    Partial Public Class RibbonVisibilitySettings
        Inherits LayoutsPageBase

        Private _web As SPWeb = Nothing

#Region "Properties"
        Private ReadOnly Property selectedValue() As [String]
            Get
                Dim builder As New StringBuilder()
                builder.AppendFormat("{0};", chkAnonymous.Checked.ToString())
                Return builder.ToString()
            End Get
        End Property


        Private ReadOnly Property redirectUrl() As String
            Get
                If Request.QueryString("Source") IsNot Nothing Then
                    Return Request.QueryString("Source")
                End If
                Return [String].Empty
            End Get
        End Property
        Private currentSPWeb As SPWeb = SPContext.Current.Web

#End Region

#Region "override"
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            Try
                _web = currentSPWeb
                If Not IsPostBack Then
                    ApplyInitialValue()
                End If
            Catch ex As Exception
                Me.Controls.Clear()
                Me.Controls.Add(New LiteralControl("Error : " & ex.Message))
            End Try
        End Sub

        Protected Overrides Sub OnInit(ByVal e As EventArgs)

        End Sub

        Public Overrides Sub Dispose()
            If _web IsNot Nothing Then
                _web.Dispose()
            End If
        End Sub
#End Region

#Region "Event Handlers"
        Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
            ApplyValue(_web, selectedValue, chkApplyToChildren.Checked)
            DoRedirect()
        End Sub

        Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            DoRedirect()
        End Sub
#End Region

#Region "Private"
        Protected Function GetValues() As String
            If _web.Properties.ContainsKey(Helper.Constants.KEY) Then
                Return _web.Properties(Helper.Constants.KEY)
            Else
                Return [String].Empty
            End If
        End Function

        Protected Sub ApplyInitialValue()
            Dim values As String = GetValues()
            If String.IsNullOrEmpty(values) Then
                Return
            End If

            chkAnonymous.Checked = [Boolean].Parse(values.Split(";"c)(0))
        End Sub

        Protected Sub DoRedirect()
            If redirectUrl <> [String].Empty Then
                SPUtility.Redirect(redirectUrl, SPRedirectFlags.[Default], HttpContext.Current)
            Else
                SPUtility.Redirect(SPContext.Current.Web.Url + "/_layouts/settings.aspx", SPRedirectFlags.[Default], HttpContext.Current)
            End If
        End Sub

        Private Sub ApplyValue(ByVal web As SPWeb, ByVal value As String, ByVal recursive As Boolean)
            Dim allowunsafe As Boolean = _web.AllowUnsafeUpdates
            web.AllowUnsafeUpdates = True

            Try
                Dim accountid As String = selectedValue
                If web.Properties.ContainsKey(Helper.Constants.KEY) Then
                    web.Properties(Helper.Constants.KEY) = value
                Else
                    web.Properties.Add(Helper.Constants.KEY, value)
                End If

                web.Properties.Update()
            Finally
                web.AllowUnsafeUpdates = allowunsafe
            End Try

            If recursive Then
                For Each subweb As SPWeb In web.Webs
                    ApplyValue(subweb, Helper.Constants.[INHERITS], recursive)
                Next
            End If
        End Sub
#End Region

    End Class
End Namespace