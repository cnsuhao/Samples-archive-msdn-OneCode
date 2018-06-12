'**************************** Module Header ******************************\
' Module Name:    IDelegateCommand.vb
' Project:        VBWindowsStoreAppCommandBindingInDataTemplate
' Copyright (c) Microsoft Corporation.
'
' This class implements ICommand interface and add a method to fire CanExecuteChanged event.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Windows.Input

Namespace Command
    Public Interface IDelegateCommand
        Inherits ICommand
        Sub RaiseCanExecuteChanged()
    End Interface
End Namespace