'****************************** Module Header ******************************\
' Module Name: PersonCommand.vb
' Project:     VBSL4DataGridBindingInMVVM
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to bind data source with using two way mode with
' frequent changed data, the clients can be notified when properties has been 
' changed. The sample designed by MVVM pattern, the lightly pattern provides a 
' flexible way for improving code re-use, simply maintenance and testing.
' 
' The PersonCommand class is used to respond when Model instance value changed.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/



Imports System.IO.IsolatedStorage

''' <summary>
''' The class implements ICommand interface and displays a dialog box
''' to show data.
''' </summary>
''' <remarks></remarks>
Public Class PersonCommand
    Implements ICommand
    Public viewModel As PersonViewModel
    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Private appSetting As IsolatedStorageSettings
    Public Sub New(ByVal view As PersonViewModel)
        Me.viewModel = view
        appSetting = IsolatedStorageSettings.ApplicationSettings
    End Sub

    Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute
        Dim validateFlag As Boolean = False
        If appSetting.Contains("validateFlag") Then
            validateFlag = CBool(appSetting("validateFlag"))
        End If
        If validateFlag Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute
        viewModel.UpdatePerson(viewModel.person)
    End Sub

End Class
