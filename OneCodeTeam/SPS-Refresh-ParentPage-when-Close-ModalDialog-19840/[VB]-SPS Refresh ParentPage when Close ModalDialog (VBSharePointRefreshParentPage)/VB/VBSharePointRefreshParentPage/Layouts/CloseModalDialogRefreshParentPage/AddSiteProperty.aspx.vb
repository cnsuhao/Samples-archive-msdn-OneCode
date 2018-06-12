'****************************** Module Header ******************************\
' Module Name:    AddSiteProperty.aspx.vb
' Project:        VBSharePointRefreshParentPage
' Copyright (c) Microsoft Corporation
'
' Add SiteProperty page
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
Imports Microsoft.SharePoint
Imports Microsoft.SharePoint.WebControls
Imports Microsoft.SharePoint.Utilities

Namespace Layouts.CloseModalDialogRefreshParentPage

    Partial Public Class AddSiteProperty
        Inherits LayoutsPageBase

        Private strSource As String = String.Empty

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            strSource = Request.QueryString("Source")
        End Sub

        ''' <summary>
        ''' Add Property to web
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub OKButton_Click(sender As Object, e As EventArgs)
            If Not Page.IsValid Then
                Return
            End If

            ' Get propertyName and propertyValue.
            Dim propertyName As String = NameInputFormTextBox.Text.Trim()
            Dim propertyValue As String = ValueInputFormTextBox.Text.Trim()

            If [String].IsNullOrEmpty(propertyName) Then
                NameErrorLabel.Text = "Site property name cannot be empty."
                Return
            End If

            Try
                If Web.GetProperty(propertyName) IsNot Nothing Then
                    NameErrorLabel.Text = "Site property name already exists."
                    Return
                End If

                Web.AddProperty(propertyName, propertyValue)
                Web.Update()
            Catch ex As Exception
                Throw New SPException(ex.Message)
            End Try

            ' Refresh the page when the dialog is closed by writing JS directly to the
            ' http Response object that will close the dialog         
            If SPContext.Current.IsPopUI Then
                Response.Clear()
                Response.Write([String].Format("<script language=""javascript"" type=""text/javascript"">window.frameElement.commonModalDialogClose(1, ""{0}"");</script>", "Site property is successfully added."))
                Response.[End]()
            Else
                SPUtility.Redirect(strSource, SPRedirectFlags.UseSource, Me.Context)
            End If
        End Sub


        Protected Overrides ReadOnly Property RequireSiteAdministrator() As Boolean
            Get
                Return True
            End Get
        End Property

    End Class

End Namespace
