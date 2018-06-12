'****************************** Module Header ******************************\
' Module Name:    Default.aspx.vb
' Project:        VBASPNETCheckPageRefresh
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to check whether the page is refreshed or not.
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

        If IsNotRefresh() Then
            WriteMsg("Page is not refreshed.")
            ' Do your logic code here
        Else
            WriteMsg("Page is refreshed.")
            ' Do your logic code here
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs)
        If IsNotRefresh() Then
            ' Do your logic code here
            WriteMsg("Page is not refreshed.")
        End If
    End Sub


    ''' <summary>
    ''' Output some message
    ''' </summary>
    ''' <param name="strMsg"></param>
    Private Sub WriteMsg(ByVal strMsg As String)
        Response.Clear()
        Response.Write(strMsg)
    End Sub

    ''' <summary>
    ''' Determine whether is refresh or not
    ''' </summary>
    ''' <returns></returns>
    Private Function IsNotRefresh() As Boolean
        Dim _isNotRefresh As Boolean = True

        ' User Control
        Dim cruc As CheckRefreshUserControl = TryCast(Me.FindControl("CheckRefreshUserControl1"), CheckRefreshUserControl)

        ' Result
        _isNotRefresh = If(cruc.ReFreshCheck = False, True, False)
        Return _isNotRefresh
    End Function

End Class