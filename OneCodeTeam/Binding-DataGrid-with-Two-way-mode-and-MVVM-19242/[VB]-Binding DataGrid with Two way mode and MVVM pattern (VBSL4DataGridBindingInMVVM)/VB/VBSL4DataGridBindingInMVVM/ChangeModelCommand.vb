'****************************** Module Header ******************************\
' Module Name: ChangeModelCommand.vb
' Project:     VBSL4DataGridBindingInMVVM
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to bind data source with using two way mode with
' frequent changed data, the clients can be notified when properties has been 
' changed. The sample designed by MVVM pattern, the lightly pattern provides a 
' flexible way for improving code re-use, simply maintenance and testing.
' 
' The class is used to respond ChangeModelByCode button onclick event.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/



Public Class ChangeModelCommand
    Implements ICommand
    ''' <summary>
    ''' This class is used to change model instance via code, and view layer will update 
    ''' when background data source has been changed.
    ''' </summary>
    Private viewModel As PersonViewModel
    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Public Sub New(ByVal viewModel As PersonViewModel)
        Me.viewModel = viewModel
    End Sub

    Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute
        If parameter.ToString() <> String.Empty Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Change Model instance by Execute method.
    ''' </summary>
    ''' <param name="parameter"></param>
    Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute
        Dim model As PersonModel
        model = viewModel.person
        model.Name = "Default Name"
        model.Age = 0
        model.Telephone = "11111111111"
        model.Comment = "Default Comment"
    End Sub

End Class
