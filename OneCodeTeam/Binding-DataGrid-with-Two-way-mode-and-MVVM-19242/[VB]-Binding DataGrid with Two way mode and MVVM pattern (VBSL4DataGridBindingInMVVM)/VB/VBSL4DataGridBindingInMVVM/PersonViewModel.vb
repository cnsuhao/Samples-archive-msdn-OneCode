'****************************** Module Header ******************************\
' Module Name: PersonViewModel.vb
' Project:     VBSL4DataGridBindingInMVVM
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to bind data source with using two way mode with
' frequent changed data, the clients can be notified when properties has been 
' changed. The sample designed by MVVM pattern, the lightly pattern provides a 
' flexible way for improving code re-use, simply maintenance and testing.
' 
' The ViewModel class is used to bind data to view layer and calls the 
' Command class when relative button is triggered.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/



''' <summary>
''' The MainPage.xaml page bind this class with Grid control, PersonViewModel
''' class is the ViewModel layer in MVVM pattern design, this class contains 
''' a model instances and invoke Command class.
''' </summary>
''' <remarks></remarks>
Public Class PersonViewModel
    Public Property person As PersonModel

    Public Sub New()
        Me.person = New PersonModel("John", 1, "13745654587", "Hello")
    End Sub

    Public Sub New(ByVal name As String, ByVal age As Integer, ByVal telephone As String, ByVal comment As String)
        Me.person = New PersonModel(name, age, telephone, comment)
    End Sub

    Public ReadOnly Property GetInformation() As ICommand
        Get
            Return New PersonCommand(Me)
        End Get
    End Property

    Public ReadOnly Property SetInformation() As ICommand
        Get
            Return New ChangeModelCommand(Me)
        End Get
    End Property

    Public Sub UpdatePerson(ByVal entity As PersonModel)
        MessageBox.Show([String].Format("Name: {0} " & vbCr & vbLf & " Age: {1} " & vbCr & vbLf & " Telephone: {2} " & vbCr & vbLf & " Comment: {3}", person.Name, person.Age, person.Telephone, person.Comment), "Display Message", MessageBoxButton.OK)
    End Sub

End Class
