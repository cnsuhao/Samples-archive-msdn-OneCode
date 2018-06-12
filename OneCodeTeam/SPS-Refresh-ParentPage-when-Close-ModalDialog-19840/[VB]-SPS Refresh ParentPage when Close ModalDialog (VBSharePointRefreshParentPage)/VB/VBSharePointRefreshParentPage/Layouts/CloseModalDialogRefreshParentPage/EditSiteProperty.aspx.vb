'****************************** Module Header ******************************\
' Module Name:    EditSiteProperty.aspx.vb
' Project:        VBSharePointRefreshParentPage
' Copyright (c) Microsoft Corporation
'
' Edit SiteProperty page
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

    Partial Public Class EditSiteProperty
        Inherits LayoutsPageBase

        ' Source url
        Private strSource As String = String.Empty
        ' Property Name
        Private propertyName As String = String.Empty

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            strSource = Request.QueryString("Source")
            propertyName = Request.QueryString("Property")

            If Not Page.IsPostBack Then
                If Web.GetProperty(propertyName) Is Nothing Then
                    Throw New SPException("Site property not found.")
                End If

                If Not (TypeOf Web.GetProperty(propertyName) Is [String]) Then
                    OKButton.Enabled = False
                End If

                Dim propertyValue As String = Web.GetProperty(propertyName).ToString()
                NameInputFormTextBox.Text = propertyName
                ValueInputFormTextBox.Text = propertyValue
            End If
        End Sub

        ''' <summary>
        ''' Update property Value
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub OKButton_Click(sender As Object, e As EventArgs)
            If Not Page.IsValid Then
                Return
            End If

            Dim propertyValue As String = ValueInputFormTextBox.Text.Trim()

            Try
                If propertyName = "MyTest" Then
                    ' This is a test
                    Web.SetProperty(propertyName, propertyValue)
                    Web.Update()

                End If
            Catch ex As Exception
                Throw New SPException(ex.Message)
            End Try

            Dim strMsg As String = "Site property is successfully updated."
            ModalDialogClose(strMsg)

        End Sub

        ''' <summary>
        ''' Close the Modal Dialog
        ''' </summary>
        ''' <param name="strMsg">Tip</param>
        Protected Sub ModalDialogClose(strMsg As String)
            If SPContext.Current.IsPopUI Then
                ' Refresh the page when the dialog is closed by writing JS directly to the
                ' http Response object that will close the dialog 
                Response.Clear()
                Response.Write([String].Format("<script language=""javascript"" type=""text/javascript"">window.frameElement.commonModalDialogClose(1, ""{0}"");</script>", strMsg))
                Response.[End]()
            Else
                SPUtility.Redirect(strSource, SPRedirectFlags.UseSource, Context)
            End If
        End Sub

        Protected Overrides ReadOnly Property RequireSiteAdministrator() As Boolean
            Get
                Return True
            End Get
        End Property

    End Class

End Namespace
