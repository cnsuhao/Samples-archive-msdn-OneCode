'************************************* Module Header ***********************\
' Module Name:  DelegateCommand.vb
' Project:      VBWindowsStoreAppASHWID
' Copyright (c) Microsoft Corporation.
' 
' Helper class to create a quick ICommand object.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports System.Windows.Input

''' <summary>
''' Helper class to create a quick ICommand object.
''' </summary>
''' <remarks></remarks>
Public Class DelegateCommand
    Implements ICommand

    Private ReadOnly _canExecute As Predicate(Of Object)
    Private ReadOnly _execute As Action(Of Object)

    Public Sub New(ByVal method As Action(Of Object))
        Me.New(method, Nothing)
    End Sub

    Public Sub New(ByVal execute As Action(Of Object), ByVal canExecute As Predicate(Of Object))
        _execute = execute
        _canExecute = canExecute
    End Sub

    Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute
        Return (_canExecute Is Nothing OrElse _canExecute(parameter))
    End Function

    Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute
        If (Not _execute Is Nothing) Then
            _execute(parameter)
        End If
    End Sub

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Protected Overridable Sub OnCanExecuteChanged(ByVal e As EventArgs)
        RaiseEvent CanExecuteChanged(Me, e)
    End Sub

    Public Sub RaiseCanExecuteChanged()
        OnCanExecuteChanged(EventArgs.Empty)
    End Sub

End Class


