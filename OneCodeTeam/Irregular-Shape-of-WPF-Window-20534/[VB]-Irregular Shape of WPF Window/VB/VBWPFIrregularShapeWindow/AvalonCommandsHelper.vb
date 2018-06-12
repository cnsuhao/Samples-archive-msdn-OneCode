'******************************** Module Header **********************************'
'Module Name:  AvalonCommandsHelper.vb
'Project:      VBWPFIrregularShapeWindow
'Copyright (c) Microsoft Corporation.
'
'The AvalonCommandsHelper.vb file defines a CanExecuteCommandSource method which is 
'responsible for Can Execute of a specific command or not
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*********************************************************************************'

Imports System.Text

''' <summary>
''' Helper class for WPF commands
''' </summary>
Public NotInheritable Class AvalonCommandsHelper
    ''' <summary>
    ''' Gets the Can Execute of a specific command
    ''' </summary>
    ''' <param name="commandSource">The command to verify</param>
    ''' <returns></returns>
    Private Sub New()
    End Sub
    Public Shared Function CanExecuteCommandSource(ByVal commandSource As ICommandSource) As Boolean
        Dim baseCommand As ICommand = commandSource.Command
        If baseCommand Is Nothing Then
            Return False
        End If


        Dim commandParameter As Object = commandSource.CommandParameter
        Dim commandTarget As IInputElement = commandSource.CommandTarget
        Dim command As RoutedCommand = TryCast(baseCommand, RoutedCommand)
        If command Is Nothing Then
            Return baseCommand.CanExecute(commandParameter)
        End If
        If commandTarget Is Nothing Then
            commandTarget = TryCast(commandSource, IInputElement)
        End If
        Return command.CanExecute(commandParameter, commandTarget)
    End Function


End Class

