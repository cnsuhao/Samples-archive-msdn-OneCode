'****************************** Module Header ******************************\
' Module Name:    default.vb
' Project:        VBASPNETRunScriptsAfterServerSideValidation
' Copyright (c) Microsoft Corporation.

' The default page demonstrates how to run scripts after server side validation

' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.

' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strMail As String = Request.Form("tbEmail")

        If IsPostBack Then
            If Not [String].IsNullOrEmpty(strMail) Then
                ' Declare the pattern to validate the email.
                Dim strPattern As String = "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"

                If System.Text.RegularExpressions.Regex.IsMatch(strMail, strPattern) Then
                    ' Register a script to run at client side.
                    Page.ClientScript.RegisterStartupScript([GetType](), "Alert", "<script>document.getElementById('divTask').style.display='block';</script>")
                Else
                    CustomValidator1.IsValid = False
                End If
            End If
        End If
    End Sub

End Class