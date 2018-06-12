'/****************************** Module Header ******************************\
' Module Name:   CustomTaskPanel.vb
' Project:       VBExcelNewEventForShapes
' Copyright (c)  Microsoft Corporation.
' 
' This Class is the custom Task Panel.
' The ListBox is used to show the event messages.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx..
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\***************************************************************************/



Public Class CustomTaskPanel

    ''' <summary>
    ''' Add Message into ListBox to show 
    ''' </summary>
    ''' <param name="message">message string</param>
    Public Sub AddMessage(ByVal message As String)
        Dim index As Integer = lstMessage.Items.Add(message)
        lstMessage.SelectedIndex = index

    End Sub

    ' Clear Message in ListBox
    Public Sub Clear()
        lstMessage.Items.Clear()
        lstMessage.SelectedIndex = -1
    End Sub

   
End Class
