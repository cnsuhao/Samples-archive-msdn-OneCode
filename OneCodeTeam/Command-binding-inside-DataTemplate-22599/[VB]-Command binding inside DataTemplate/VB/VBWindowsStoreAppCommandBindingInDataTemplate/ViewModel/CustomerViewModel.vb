'***************************** Module Header ******************************\
' Module Name:    CustomerViewModel.vb
' Project:        VBWindowsStoreAppCommandBindingInDataTemplate
' Copyright (c) Microsoft Corporation.
' 
' This is a ViewModel class which defines properties and Command will be used 
' by View.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Linq
Imports System.Collections.ObjectModel
Imports VBWindowsStoreAppCommandBindingInDataTemplate.Model
Imports VBWindowsStoreAppCommandBindingInDataTemplate.Command
Imports System.ComponentModel

Namespace ViewModel
    Public Class CustomerViewModel
        Implements INotifyPropertyChanged

#Region "Fields and Properties"

        ' This property will be bound to GridView's ItemsDataSource property for providing data
        Private m_customers As ObservableCollection(Of Customer)

        ' This property will be bound to button's Command property for deleting item
        Public Property DeleteCommand() As IDelegateCommand
            Get
                Return m_DeleteCommand
            End Get
            Protected Set(value As IDelegateCommand)
                m_DeleteCommand = value
            End Set
        End Property
        Private m_DeleteCommand As IDelegateCommand

        Public Property Customers() As ObservableCollection(Of Customer)
            Get
                Return m_customers
            End Get
            Set(value As ObservableCollection(Of Customer))
                If m_customers IsNot value Then
                    m_customers = value
                    OnPropertyChanged("Customers")
                End If
            End Set
        End Property

#End Region

#Region "Constructor"
        Public Sub New()
            ' create a DeleteCommand instance
            Me.DeleteCommand = New DelegateCommand(AddressOf ExecuteDeleteCommand)

            ' Get data source
            Customers = InitializeSampleData.GetData()
        End Sub
#End Region


#Region "Execute and CanExecute methods"

        Private Sub ExecuteDeleteCommand(param As Object)
            Dim id As Integer = CType(param, Int32)
            Dim cus As Customer = GetCustomerById(id)
            If cus IsNot Nothing Then
                Customers.Remove(cus)
            End If
        End Sub

#End Region

        ' Get the deleting item by Id property
        Private Function GetCustomerById(id As Integer) As Customer
            Return Customers.First(Function(x) x.Id = id)
        End Function

#Region "INotifyPropertyChanged"

        Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
        Private Sub OnPropertyChanged(propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub
#End Region

    End Class
End Namespace