'**************************** Module Header ******************************\
' Module Name:    Customer.vb
' Project:        VBWindowsStoreAppCommandBindingInDataTemplate
' Copyright (c) Microsoft Corporation.
' 
' This is a Model class
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.ComponentModel


Namespace Model
    Public Class Customer
        Implements INotifyPropertyChanged

#Region "private fields"
        Private m_id As Integer
        Private m_name As String
        Private m_sex As Boolean
        Private m_age As Integer
        Private m_vip As Boolean
#End Region

#Region "Properties"
        Public Property Id() As Integer
            Get
                Return m_id
            End Get
            Set(value As Integer)
                If m_id <> value Then
                    m_id = value
                    OnNotifyPropertyChanged("Id")
                End If
            End Set
        End Property

        Public Property Name() As String
            Get
                Return m_name
            End Get
            Set(value As String)
                If m_name <> value Then
                    m_name = value
                    OnNotifyPropertyChanged("Name")
                End If
            End Set
        End Property

        Public Property Sex() As Boolean
            Get
                Return m_sex
            End Get
            Set(value As Boolean)
                If m_sex <> value Then
                    m_sex = value
                    OnNotifyPropertyChanged("Sex")
                End If
            End Set
        End Property

        Public Property Age() As Integer
            Get
                Return m_age
            End Get
            Set(value As Integer)
                If m_age <> value Then
                    m_age = value
                    OnNotifyPropertyChanged("Age")
                End If
            End Set
        End Property

        Public Property Vip() As Boolean
            Get
                Return m_vip
            End Get
            Set(value As Boolean)
                If m_vip <> value Then
                    m_vip = value
                    OnNotifyPropertyChanged("Vip")
                End If
            End Set
        End Property

#End Region

#Region "INotifyPropertyChanged Interface"
        Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
        Private Sub OnNotifyPropertyChanged(propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub
#End Region

    End Class
End Namespace