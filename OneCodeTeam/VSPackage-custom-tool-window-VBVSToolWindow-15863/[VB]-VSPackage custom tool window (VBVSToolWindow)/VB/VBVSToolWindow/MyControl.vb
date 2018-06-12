'*************************** Module Header ******************************'
' Module Name:  MyControl.vb
' Project:      VBVSToolWindow
' Copyright (c) Microsoft Corporation.
' 
' This UserControl will be displayed as the content of the ToolWindow.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************'

Imports System.Windows.Forms
Imports System.Drawing

'''<summary>
'''  Summary description for MyControl.
'''</summary>
Public Class MyControl
    Inherits UserControl

    Public Property Image() As Image

        Get
            Return Me.picDisplay.Image
        End Get
        Set(ByVal value As Image)
            Me.picDisplay.Image = value
        End Set
    End Property

End Class