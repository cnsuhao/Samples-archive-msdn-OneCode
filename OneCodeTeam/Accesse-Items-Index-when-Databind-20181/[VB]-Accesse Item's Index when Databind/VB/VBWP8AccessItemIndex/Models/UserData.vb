'****************************** Module Header ******************************\
' Module Name:  UserData.vb
' Project:      VBWP8AccessItemIndex
' Copyright (c) Microsoft Corporation
'
' This class is the data model.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Imports System.ComponentModel
Imports System.Windows.Media

Namespace Models
    Public Class UserData
        Implements INotifyPropertyChanged

        ' Constructor
        Public Sub New(i As Integer)
            Me.Index = i
            Me.Name = "Name" & (Me.Index + 1)
            Me.Age = i + 5
        End Sub

        ' id
        Private _index As Integer
        Public Property Index() As Integer
            Get
                Return _index
            End Get
            Set(value As Integer)
                _index = value
                RaisePropertyChanged("Index")
            End Set
        End Property

        ' name
        Private _name As String
        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(value As String)
                _name = value
                RaisePropertyChanged("Name")
            End Set
        End Property

        ' age
        Private _age As Integer
        Public Property Age() As Integer
            Get
                Return _age
            End Get
            Set(value As Integer)
                _age = value
                RaisePropertyChanged("Age")
            End Set
        End Property

        ' Background Brush
        Public Property BackgroundBrush() As SolidColorBrush
            Get
                Dim index As Integer = App.ViewModel.UserDatas.IndexOf(Me)
                Dim backgroundColor As Color = If((index Mod 2 = 0), Colors.Gray, Colors.Blue)
                Return New SolidColorBrush(backgroundColor)
            End Get
            Set(value As SolidColorBrush)
            End Set
        End Property

        ' PropertyChangedEventHandler
        Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

        Protected Sub RaisePropertyChanged(propertyName As String)
            Try
                Dim e = New PropertyChangedEventArgs(propertyName)
                RaiseEvent PropertyChanged(Me, e)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub
    End Class
End Namespace
