'****************************** Module Header ******************************\
' Module Name:  ViewModel.vb
' Project:      VBWP8AccessItemIndex
' Copyright (c) Microsoft Corporation
'
' This is the ViewModel.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Imports System.Collections.ObjectModel
Imports VBWP8AccessItemIndex.Models

Namespace ViewModels
    Public Class ViewModel
        Public Sub New()
            ' Instantiated
            Me.UserDatas = New ObservableCollection(Of UserData)()

            ' Insert test data.
            UserDatas.Add(New UserData(8))
            UserDatas.Add(New UserData(6))
            UserDatas.Add(New UserData(2))
            UserDatas.Add(New UserData(3))
            UserDatas.Add(New UserData(4))
            UserDatas.Add(New UserData(5))
            UserDatas.Add(New UserData(9))
            UserDatas.Add(New UserData(7))
            UserDatas.Add(New UserData(1))
            UserDatas.Add(New UserData(10))
            UserDatas.Add(New UserData(12))
            UserDatas.Add(New UserData(13))
        End Sub

        ' Collection of UserData
        Private _userDatas As ObservableCollection(Of UserData)
        Public Property UserDatas() As ObservableCollection(Of UserData)
            Get
                Return _userDatas
            End Get
            Set(value As ObservableCollection(Of UserData))
                _userDatas = value
            End Set
        End Property
    End Class

End Namespace

