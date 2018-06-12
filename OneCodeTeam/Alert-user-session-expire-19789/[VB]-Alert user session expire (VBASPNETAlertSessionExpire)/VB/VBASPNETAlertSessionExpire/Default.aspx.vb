'*************************** Module Header ********************************\
' Module Name:    Default.aspx.vb
' Project:        VBASPNETAlertSessionExpired
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to design a simple user control, which is used to 
' alert the user when the session is about to expired. 
' 
' In this file, get the session state.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL..
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************/
Imports System.Web.UI
Imports VBASPNETAlertSessionExpired.Util

Namespace VBASPNETAlertSessionExpired
    Partial Public Class _Default
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

#Region "Get Session State"

        Protected Sub SessionState_Click(ByVal sender As Object, ByVal e As EventArgs)
            If Session("SessionForTest") Is Nothing Then

                Response.Redirect("SessionExpired.htm")

            Else
                lbSessionState.Text = SessionStates.Exist.ToString()

            End If
        End Sub

#End Region


    End Class
End Namespace


