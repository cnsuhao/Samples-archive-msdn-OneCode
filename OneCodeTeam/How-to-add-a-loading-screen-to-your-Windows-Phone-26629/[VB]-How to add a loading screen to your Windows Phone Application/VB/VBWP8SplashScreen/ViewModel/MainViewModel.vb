'****************************** Module Header ******************************\
' Module Name:  MainViewModel.vb
' Project:      VBWP8SplashScreen
' Copyright (c) Microsoft Corporation.
' 
' MainViewModel. 
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Imports System
Imports System.ComponentModel
Imports System.Net.Http

Namespace ViewModels
    Public Class MainViewModel
        Implements INotifyPropertyChanged
        Private _httpClient As HttpClient
        Public Sub New()
            _dataLoaded = False
            _status = ""
            _httpClient = New HttpClient()
            LoadViewModelData()
        End Sub

        Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
        Private Sub NotifyPropertyChanged(propName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propName))
        End Sub

        Private _dataLoaded As Boolean

        Public Property DataLoaded() As Boolean
            Get
                Return _dataLoaded
            End Get
            Set(value As Boolean)
                _dataLoaded = value
                NotifyPropertyChanged("DataLoaded")
            End Set
        End Property

        Private _status As String

        Public Property Status() As String
            Get
                Return _status
            End Get
            Set(value As String)
                _status = value
                NotifyPropertyChanged("Status")
            End Set
        End Property


        Public Async Sub LoadViewModelData()
            DataLoaded = False
            Dim response As HttpResponseMessage = Await _httpClient.GetAsync("http://blogs.msdn.com/b/onecode/")
            Status = [String].Format("Status: {0}", response.StatusCode)
            DataLoaded = True
        End Sub

    End Class

End Namespace