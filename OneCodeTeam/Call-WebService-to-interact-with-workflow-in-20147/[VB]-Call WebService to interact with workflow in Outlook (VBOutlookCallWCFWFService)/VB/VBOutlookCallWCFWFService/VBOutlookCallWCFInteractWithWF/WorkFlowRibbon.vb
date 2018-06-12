'/****************************** Module Header ******************************\
' Module Name:  WorkFlowRibbon.vb
' Project:      VBOutlookCallWCFInteractWithWF
' Copyright(c) Microsoft Corporation.
' 
' This Class is to create ribbon of outlook, we can show Leave main form via 
' this ribbon.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\***************************************************************************/

Imports Microsoft.Office.Tools.Ribbon

Public Class WorkFlowRibbon

    Private Sub WorkFlowRibbon_Load(ByVal sender As System.Object, ByVal e As RibbonUIEventArgs) Handles MyBase.Load

    End Sub

    ''' <summary>
    '''  Start Leave WorkFlow
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnLeaveWF_Click(sender As System.Object, e As Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs) Handles btnLeaveWF.Click
        ' Show the Leave workflow Main Form
        Dim createLeaveForm As New LeaveMainForm()
        createLeaveForm.ShowDialog()
    End Sub
End Class
