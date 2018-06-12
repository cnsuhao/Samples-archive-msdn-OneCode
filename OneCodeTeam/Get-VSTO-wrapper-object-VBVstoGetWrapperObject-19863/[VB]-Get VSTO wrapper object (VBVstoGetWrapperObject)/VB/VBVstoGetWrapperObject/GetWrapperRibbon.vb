'************************************* Module Header *************************\
' Module Name:	GetWrapperRibbon.vb
' Project:		VBVstoGetWrapperObject
' Copyright (c) Microsoft Corporation.
' 
' The VBVstoGetWrapperObject project demonstrates how to get a VSTO wrapper
' object from an existing Office COM object.
'
' This feature requires Visual Studio Tools for Office 3.0 SP1 (included in 
' Visual Studio 2008 SP1) for both design-time and runtime support.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

#Region "Import directives"
Imports System.Windows.Forms
Imports System.Diagnostics
Imports Microsoft.Office.Tools.Ribbon
#End Region

Public Class GetWrapperRibbon
    Private getWrapperForm As GetWrapperForm = Nothing

    Private Sub GetWrapperRibbon_Load(ByVal sender As System.Object, ByVal e As RibbonUIEventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnShowGetWrapperVB_Click(sender As Object, e As RibbonControlEventArgs) Handles btnShowGetWrapperVB.Click
        If GetWrapperForm Is Nothing OrElse GetWrapperForm.IsDisposed Then
            GetWrapperForm = New GetWrapperForm()
            GetWrapperForm.Show(NativeWindow.FromHandle(Process.GetCurrentProcess().MainWindowHandle))
        Else
            GetWrapperForm.Activate()
        End If
    End Sub
End Class
