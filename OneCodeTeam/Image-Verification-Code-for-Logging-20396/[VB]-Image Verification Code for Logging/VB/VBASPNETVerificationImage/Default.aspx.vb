'****************************** Module Header ******************************\
' Module Name:    Default.vb
' Project:        VBASPNETVerificationImage
' Copyright (c) Microsoft Corporation
'
' This is the test page.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    ''' <summary>
    ''' Compare the value in session and type. If equal, set a success to the text of Literal, otherwise failed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOK.Click

        If tbCode.Text.Trim().ToLower.Equals(Session("ValidateCode").ToString().ToLower()) Then
            ltrMessage.Text = "success"
        Else
            ltrMessage.Text = "failed"
        End If

    End Sub
End Class