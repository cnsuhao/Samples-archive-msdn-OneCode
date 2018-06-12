'****************************** Module Header ******************************\
' Module Name: UserControl2.ascx.vb
' Project:     VBASPNETUserControlPassData
' Copyright (c) Microsoft Corporation
'
' This project illustrates how to pass data from one user control to another.
' A user control can contain other controls like TextBoxes or Labels, These 
' control are declared as protected members, We cannot get the use control from
' another one directly.
' 
' The control is use to call UserControl1 user control's property.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/



Public Class UserControl2
    Inherits System.Web.UI.UserControl
    Private userControl1 As UserControl1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ' Output UserControl2 user control message.
            lbPublicVariable2.Text = StrCaller

            ' Find UserControl1 user control.
            Dim control As Control = Page.FindControl("UserControl1ID")
            userControl1 = DirectCast(control, UserControl1)
            If userControl1 IsNot Nothing Then
                ' Output UserControl1 user control message.
                Dim lbUserControl1 As Label = TryCast(userControl1.FindControl("lbPublicVariable"), Label)
                If lbUserControl1 IsNot Nothing Then
                    lbUserControl1.Text = userControl1.StrCallee
                    tbModifyUserControl1.Text = userControl1.StrCallee
                End If
            End If
        End If

    End Sub
    ''' <summary>
    ''' UserControl2 message.
    ''' </summary>
    Public Property StrCaller As String = "I come from UserControl2."

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        If Not tbModifyUserControl1.Text.Trim().Equals(String.Empty) Then
            Dim control As Control = TryCast(Session("UserControl1"), Control)
            userControl1 = TryCast(control, UserControl1)
            If userControl1 IsNot Nothing Then
                ' Set UserControl1 user control message.
                lbFormatMessage.Text = String.Format("forward message: {0} ", userControl1.StrCallee)
                userControl1.StrCallee = tbModifyUserControl1.Text
                Session("UserControl1") = userControl1
                Dim pageUserControl1 As UserControl1 = TryCast(Page.FindControl("UserControl1ID"), UserControl1)
                Dim lbUserControl1 As Label = TryCast(pageUserControl1.FindControl("lbPublicVariable"), Label)
                lbUserControl1.Text = tbModifyUserControl1.Text
            Else
                control = Page.FindControl("UserControl1ID")
                userControl1 = DirectCast(control, UserControl1)
                userControl1.StrCallee = tbModifyUserControl1.Text.Trim()
                Dim lbUserControl1 As Label = TryCast(userControl1.FindControl("lbPublicVariable"), Label)
                lbUserControl1.Text = userControl1.StrCallee
                Session("UserControl1") = userControl1
            End If
        Else
            lbMessage.Text = "The message can not be null."
        End If
    End Sub
End Class