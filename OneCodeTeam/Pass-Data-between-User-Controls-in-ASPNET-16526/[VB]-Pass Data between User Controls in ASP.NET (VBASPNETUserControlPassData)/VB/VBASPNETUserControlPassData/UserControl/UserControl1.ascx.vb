'****************************** Module Header ******************************\
' Module Name: UserControl1.ascx.vb
' Project:     VBASPNETUserControlPassData
' Copyright (c) Microsoft Corporation
'
' This project illustrates how to pass data from one user control to another.
' A user control can contain other controls like TextBoxes or Labels, These 
' control are declared as protected members, We cannot get the use control from
' another one directly.
' 
' The control is use to be called by UserControl2 user control.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/



Public Class UserControl1
    Inherits System.Web.UI.UserControl


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            StrCallee = "I come from UserControl1."
            lbPublicVariable.Text = StrCallee
        End If
    End Sub
    ''' <summary>
    ''' UserControl2 message.
    ''' </summary>
    Public Property StrCallee As String = "I come from UserControl1."

End Class