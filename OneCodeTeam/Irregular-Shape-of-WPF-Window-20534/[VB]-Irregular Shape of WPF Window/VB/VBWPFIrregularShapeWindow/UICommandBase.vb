'******************************** Module Header **********************************'
'Module Name:  UICommandBase.vb
'Project:      VBWPFIrregularShapeWindow
'Copyright (c) Microsoft Corporation.
'
'The UICommandBase.vb file defines a RoutedUICommand inherit RoutedCommand by implementing the 
'shortcuts bound to command instance variables
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**********************************************************************************'

Imports System.Text

Public MustInherit Class UICommandBase
    Inherits Window


    '<summary>
    'Command to Minimize the windows
    'As you can see the command also hooks to the F3 key of the keyboard
    '</summary>
    Public Shared MinimizeCmd As New RoutedUICommand("MinimizeCmd", "MinimizeCmd", GetType(UICommandBase), New InputGestureCollection(New InputGesture() {New KeyGesture(Key.F3, ModifierKeys.None, "Minimize Cmd")}))

    ''' <summary>
    ''' Command to Maximize the windows
    '''As you can see the command also hooks to the F4 key of the keyboard
    ''' </summary>
    Public Shared MaximizeCmd As New RoutedUICommand("MaximizeCmd", "MaximizeCmd", GetType(UICommandBase), New InputGestureCollection(New InputGesture() {New KeyGesture(Key.F4, ModifierKeys.None, "Maximize Cmd")}))

    ''' <summary>
    ''' Command to Restore the windows
    ''' As you can see the command also hooks to the F5 key of the keyboard
    ''' </summary>
    Public Shared RestoreCmd As New RoutedUICommand("RestoreCmd", "RestoreCmd", GetType(UICommandBase), New InputGestureCollection(New InputGesture() {New KeyGesture(Key.F5, ModifierKeys.None, "Restore Cmd")}))

    ''' <summary>
    ''' Command to Close the windows
    ''' As you can see the command also hooks to the F6 key of the keyboard
    ''' </summary>
    Public Shared CloseCmd As New RoutedUICommand("CloseCmd", "CloseCmd", GetType(UICommandBase), New InputGestureCollection(New InputGesture() {New KeyGesture(Key.F6, ModifierKeys.None, "Close Cmd")}))


    Public Sub New()

    End Sub

End Class
