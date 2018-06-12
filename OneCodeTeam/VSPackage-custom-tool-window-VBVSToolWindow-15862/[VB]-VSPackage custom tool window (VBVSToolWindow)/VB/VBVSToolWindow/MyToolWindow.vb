'**************************** Module Header ******************************'
' Module Name:  MyToolWindow.vb
' Project:      VBVSToolWindow
' Copyright (c) Microsoft Corporation.
' 
' Define the ToolWindow, and set its ToolBar.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************'

Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports Microsoft.VisualStudio.Shell
Imports Microsoft.VisualStudio.Shell.Interop
Imports Microsoft.Win32

''' <summary>
''' This class implements the tool window exposed by this package and hosts a user control.
'''
''' In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane, 
''' usually implemented by the package implementer.
'''
''' This class derives from the ToolWindowPane class provided from the MPF in order to use its 
''' implementation of the IVsUIElementPane interface.
''' </summary>
<Guid("cda0c418-55c4-45de-8e85-4c54ab697179")> _
Public Class MyToolWindow
    Inherits ToolWindowPane

    Dim control As MyControl = Nothing

    ''' <summary>
    ''' Standard constructor for the tool window.
    ''' </summary>
    Public Sub New()
        MyBase.New(Nothing)
        ' Set the window title reading it from the resources.
        Me.Caption = Resources.ToolWindowTitle
        ' Set the image that will appear on the tab of the window frame
        ' when docked with an other window
        ' The resource ID correspond to the one defined in the resx file
        ' while the Index is the offset in the bitmap strip. Each image in
        ' the strip being 16x16.
        Me.BitmapResourceID = 301
        Me.BitmapIndex = 1

        ' Create the toolbar.
        Me.ToolBar = New CommandID(GuidList.guidVBVSToolWindowCmdSet, PkgCmdIDList.ToolbarID)
        Me.ToolBarLocation = CInt(Fix(VSTWT_LOCATION.VSTWT_TOP))

        ' Create the handlers for the toolbar commands.
        Dim mcs = TryCast(GetService(GetType(IMenuCommandService)), OleMenuCommandService)
        If Nothing IsNot mcs Then
            Dim toolbarbtnCmdID = New CommandID(GuidList.guidVBVSToolWindowCmdSet, PkgCmdIDList.cmdidOpenImage)
            Dim menuItem = New MenuCommand(New EventHandler(AddressOf ButtonHandler), toolbarbtnCmdID)
            mcs.AddCommand(menuItem)
        End If


        ' This is the user control hosted by the tool window
        control = New MyControl()
        MyBase.Content = control
    End Sub

    Private Sub ButtonHandler(ByVal sender As Object, ByVal arguments As EventArgs)
        Dim fd As New OpenFileDialog()
        fd.Filter = "image files |*.bmp;*.png;*.jpg;*.jpeg"
        fd.Multiselect = False
        If True = fd.ShowDialog() Then
            control.Image = New System.Windows.Media.Imaging.BitmapImage(New Uri(fd.FileName))
        End If
    End Sub

End Class
