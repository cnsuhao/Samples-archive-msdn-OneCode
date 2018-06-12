'****************************** Module Header ******************************\
' Module Name:    HeadInTag.ascx.vb
' Project:        VBSharePointAddElementToHeadTag
' Copyright (c) Microsoft Corporation
'
' The User Control is used to render the custom Meta information.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports Microsoft.SharePoint
Imports System.Globalization
Imports Microsoft.SharePoint.Utilities


Namespace CONTROLTEMPLATES.AddElementToHeadTag
    Partial Public Class HeadInTag
        Inherits UserControl

        ' You actually must override the Render method, because normally any control in ASP.NET
        ' renders additional <span> (or another HTML element) around its contents. 
        ' None of these elements are allowed in the <head> section.        
        Protected Overrides Sub Render(writer As HtmlTextWriter)
            ' The default keyword
            Dim keyword As String = TryCast(SPContext.Current.Web.GetProperty("Default-CustomMetaKey"), String)

            ' The default description
            Dim description As String = TryCast(SPContext.Current.Web.GetProperty("Default-CustomMetaDescription"), String)

            ' Get current page.
            Dim file As SPFile = SPContext.Current.File

            ' If the page does not exist or there is no special settings for it, use the default settings.
            ' Otherwise, apply the specified configuration.
            If file IsNot Nothing Then
                If file.Exists Then
                    Dim fileName As String = file.Name
                    Dim strCurrentPageKeyword As String = TryCast(SPContext.Current.Web.GetProperty(fileName & "-CustomMetaKey"), String)
                    Dim strCurrentPageDescription As String = TryCast(SPContext.Current.Web.GetProperty(fileName & "-CustomMetaDescription"), String)

                    If Not String.IsNullOrEmpty(strCurrentPageKeyword) Then
                        keyword = strCurrentPageKeyword
                    End If
                    If Not String.IsNullOrEmpty(strCurrentPageDescription) Then
                        description = strCurrentPageDescription
                    End If
                End If
            End If

            ' Output the value
            writer.Write([String].Format(CultureInfo.CurrentCulture, "<meta name=""description"" content=""{0}"" />", description))
            writer.Write([String].Format(CultureInfo.CurrentCulture, "<meta name=""keywords"" content=""{0}"" />", keyword))
        End Sub
    End Class

End Namespace

