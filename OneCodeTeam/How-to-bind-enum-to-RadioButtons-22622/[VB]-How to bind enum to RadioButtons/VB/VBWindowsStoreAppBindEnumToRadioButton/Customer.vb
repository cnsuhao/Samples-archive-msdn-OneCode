'***************************** Module Header ******************************\
' Module Name:  Customer.vb
' Project:      VBWindowsStoreAppBindEnumToRadioButton
' Copyright (c) Microsoft Corporation.
'  
' This is the demo data
'   
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'  
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Public Class Customer
    Implements INotifyPropertyChanged

    Private m_name As String
    Public Property Name() As String
        Get
            Return m_name
        End Get
        Set(value As String)
            m_name = value
            NotifyPropertyChanged("Name")
        End Set
    End Property

    Private m_age As Integer
    Public Property Age() As Integer
        Get
            Return m_age
        End Get
        Set(value As Integer)
            m_age = value
            NotifyPropertyChanged("Age")
        End Set
    End Property

    Private m_sex As Boolean
    Public Property Sex() As Boolean
        Get
            Return m_sex
        End Get
        Set(value As Boolean)
            m_sex = value
            NotifyPropertyChanged("Sex")
        End Set
    End Property

    Private m_favouriteSport As Sport
    Public Property FavouriteSport() As Sport
        Get
            Return m_favouriteSport
        End Get
        Set(value As Sport)
            m_favouriteSport = value
            NotifyPropertyChanged("FavouriteSport")
        End Set
    End Property

    Public Sub NotifyPropertyChanged(propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class

Public Enum Sport
    Football
    Basketball
    Baseball
    Swimming
End Enum