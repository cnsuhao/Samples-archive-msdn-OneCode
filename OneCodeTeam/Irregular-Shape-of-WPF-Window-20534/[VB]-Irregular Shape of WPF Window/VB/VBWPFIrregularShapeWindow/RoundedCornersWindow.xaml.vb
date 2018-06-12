'******************************** Module Header **********************************'
'Module Name:  RoundedCornersWindow.xaml.vb
'Project:      VBWPFIrregularShapeWindow
'Copyright (c) Microsoft Corporation.
'
'The RoundedCornersWindow.xaml.vb file defines a RoundedCornersWindow class is responsible for 
'command binding and relationship between command and menu item or button
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
'All other rights reserved.
'''
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**********************************************************************************'

Imports System.Text

''' <summary>
''' Interaction logic for IrregularWindow.xaml
''' </summary>
Partial Public Class RoundedCornersWindow
    Inherits Window
    Public Sub New()
        Me.InitializeComponent()

        ' Insert code required on object creation below this point
        Dim cb As New CommandBinding()
        cb.Command = UICommandBase.CloseCmd
        AddHandler cb.Executed, AddressOf CloseCmdExecuted
        AddHandler cb.CanExecute, AddressOf CloseCmdCanExecute

        Dim minb As New CommandBinding()
        minb.Command = UICommandBase.MinimizeCmd
        AddHandler minb.Executed, AddressOf MinimizeCmdExecuted
        AddHandler minb.CanExecute, AddressOf MinimizeCmdCanExecute

        Dim maxb As New CommandBinding()
        maxb.Command = UICommandBase.MaximizeCmd
        AddHandler maxb.Executed, AddressOf MaximizeCmdExecuted
        AddHandler maxb.CanExecute, AddressOf MaximizeCmdCanExecute

        Dim restoreb As New CommandBinding()
        restoreb.Command = UICommandBase.RestoreCmd
        AddHandler restoreb.Executed, AddressOf RestoreCmdExecuted
        AddHandler restoreb.CanExecute, AddressOf RestoreCmdCanExecute

        'Will execute the command object added to form the command object set
        Me.CommandBindings.Add(cb)
        Me.CommandBindings.Add(minb)
        Me.CommandBindings.Add(maxb)
        Me.CommandBindings.Add(restoreb)

        Me.mnuInvokeClose.Command = UICommandBase.CloseCmd
        Me.mnuInvokeClose.CommandTarget = btnInvokeClose
        Me.btnInvokeClose.Command = UICommandBase.CloseCmd

        Me.mnuInvokeMaximize.Command = UICommandBase.MaximizeCmd
        Me.mnuInvokeMaximize.CommandTarget = btnInvokeMaximize
        Me.btnInvokeMaximize.Command = UICommandBase.MaximizeCmd

        Me.mnuInvokeMinimize.Command = UICommandBase.MinimizeCmd
        Me.mnuInvokeMinimize.CommandTarget = btnInvokeMinimize
        Me.btnInvokeMinimize.Command = UICommandBase.MinimizeCmd

        Me.mnuInvokeRestore.Command = UICommandBase.RestoreCmd
        Me.mnuInvokeRestore.CommandTarget = btnInvokeRestore
        Me.btnInvokeRestore.Command = UICommandBase.RestoreCmd

    End Sub

    ''' <summary>
    ''' Minimize window behavior
    ''' </summary>
    Private Sub MinimizeCmdExecuted(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
        Me.WindowState = WindowState.Minimized
    End Sub

    ''' <summary>
    ''' CanExecuteRoutedEventHandler for the custom MinimizeCmd command
    ''' </summary>
    Private Sub MinimizeCmdCanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
        e.CanExecute = True
    End Sub

    ''' <summary>
    '''  Maximize window behavior
    ''' </summary>
    Private Sub MaximizeCmdExecuted(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)

        ' If canExcute could be used,then menu item and button which used by Maximize should switch
        Dim canExecute As Boolean = AvalonCommandsHelper.CanExecuteCommandSource(btnInvokeRestore)
        If canExecute = True Then
            Me.btnInvokeRestore.Visibility = Visibility.Visible
            Me.btnInvokeMaximize.Visibility = Visibility.Hidden
            Me.mnuInvokeMaximize.IsEnabled = False
            Me.mnuInvokeRestore.IsEnabled = True
        End If

        Me.WindowState = WindowState.Maximized
    End Sub

    ''' <summary>
    ''' CanExecuteRoutedEventHandler for the custom MaximizeCmd command
    ''' </summary>
    Private Sub MaximizeCmdCanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
        e.CanExecute = True
    End Sub

    ''' <summary>
    ''' Restore window behavior
    ''' </summary>
    Private Sub RestoreCmdExecuted(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)

        ' If canExcute could be used,then menu item and button which used by Restore should switch
        Dim canExecute As Boolean = AvalonCommandsHelper.CanExecuteCommandSource(btnInvokeRestore)
        If canExecute = True Then
            Me.btnInvokeRestore.Visibility = Visibility.Hidden
            Me.btnInvokeMaximize.Visibility = Visibility.Visible
            Me.mnuInvokeMaximize.IsEnabled = True
            Me.mnuInvokeRestore.IsEnabled = False
        End If
        Me.WindowState = WindowState.Normal

    End Sub

    ''' <summary>
    ''' CanExecuteRoutedEventHandler for the custom RestoreCmd command
    ''' </summary>
    Private Sub RestoreCmdCanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
        e.CanExecute = True
    End Sub

    ''' <summary>
    ''' Close window behavior
    ''' </summary>
    Private Sub CloseCmdExecuted(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
        Me.Close()
    End Sub

    ''' <summary>
    ''' CanExecuteRoutedEventHandler for the custom CloseCmd command
    ''' </summary>
    Private Sub CloseCmdCanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
        e.CanExecute = True
    End Sub

    ''' <summary>
    ''' delegate event for Drag shape window
    ''' </summary>
    Private Sub Window_MouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        Me.DragMove()
    End Sub

End Class
