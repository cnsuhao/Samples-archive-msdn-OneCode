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

Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports Microsoft.VisualStudio.Shell.Interop
Imports Microsoft.VisualStudio.Shell
Imports System.ComponentModel.Design

''' <summary>
''' This class implements the tool window exposed by this package and hosts a user control.
'''
''' In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane, 
''' usually implemented by the package implementer.
'''
''' This class derives from the ToolWindowPane class provided from the MPF in order to use its 
''' implementation of the IVsWindowPane interface.
''' </summary>
<Guid("b8e804e2-5525-4cfe-980e-c9a31c7c3cba")> _
Public Class MyToolWindow
    Inherits ToolWindowPane
    ' This is the user control hosted by the tool window; it is exposed to the base class 
    ' using the Window property. Note that, even if this class implements IDispose, we are
    ' not calling Dispose on this object. This is because ToolWindowPane calls Dispose on 
    ' the object returned by the Window property.
    Private control As MyControl

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
        Me.ToolBarLocation = CInt(VSTWT_LOCATION.VSTWT_TOP)

        ' Create the handlers for the toolbar commands.
        Dim mcs As OleMenuCommandService = TryCast(GetService(GetType(IMenuCommandService)), OleMenuCommandService)
        If Nothing IsNot mcs Then
            Dim toolbarbtnCmdID As CommandID = New CommandID(GuidList.guidVBVSToolWindowCmdSet, PkgCmdIDList.cmdidOpenImage)
            Dim menuItem As MenuCommand = New MenuCommand(New EventHandler(AddressOf ButtonHandler), toolbarbtnCmdID)
            mcs.AddCommand(menuItem)
        End If


        ' This is the user control hosted by the tool window
        control = New MyControl()       
    End Sub

    ''' <summary>
    ''' This property returns the handle to the user control that should
    ''' be hosted in the Tool Window.
    ''' </summary>
    Public Overrides ReadOnly Property Window() As IWin32Window
        Get
            Return CType(control, IWin32Window)
        End Get
    End Property


    Private Sub ButtonHandler(ByVal sender As Object, ByVal arguments As EventArgs)
        Dim fd As New OpenFileDialog()
        fd.Filter = "image files |*.bmp;*.png;*.jpg;*.jpeg"
        fd.Multiselect = False
        If DialogResult.OK = fd.ShowDialog() Then
            control.Image = New Bitmap(fd.FileName)
        End If
    End Sub

End Class