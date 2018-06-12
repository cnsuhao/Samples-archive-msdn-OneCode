'****************************** Module Header ******************************\
' Module Name: PersonModel.vb
' Project:     VBSL4DataGridBindingInMVVM
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to bind data source with using two way mode with
' frequent changed data, the clients can be notified when properties has been 
' changed. The sample designed by MVVM pattern, the lightly pattern provides a 
' flexible way for improving code re-use, simply maintenance and testing.
' 
' The Model class is used for storing user information.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/



Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class PersonModel
    Implements INotifyPropertyChanged

    Private m_name As String
    Private m_age As Integer
    Private m_telephone As String
    Private m_comment As String
    Private regexInt As New Regex("^-?\d*$")
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Public Sub New(ByVal name As String, ByVal age As Integer, ByVal telephone As String, ByVal comment As String)
        Me.m_name = name
        Me.m_age = age
        Me.m_telephone = telephone
        Me.m_comment = comment
    End Sub

    Public Sub Changed(ByVal newValue As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(newValue))
    End Sub

    Public Property Name() As String
        Get
            Return m_name
        End Get
        Set(ByVal value As String)
            If value = String.Empty Then
                Throw New Exception("Name can not be empty.")
            End If
            m_name = value
            Changed("Name")
        End Set
    End Property

    Public Property Age() As Integer
        Get
            Return m_age
        End Get
        Set(ByVal value As Integer)
            Dim outPut As Integer
            If Integer.TryParse(value.ToString(), outPut) Then
                If outPut < 0 Then
                    Throw New Exception("Age must be greater than zero.")
                End If
                m_age = outPut
                'outPut.ToString();
                Changed("Age")
            Else
                Throw New Exception("Age must be an integer number.")
            End If
        End Set
    End Property

    Public Property Telephone() As String
        Get
            Return m_telephone
        End Get
        Set(ByVal value As String)
            If value = String.Empty Then
                Throw New Exception("Telephone can not be empty.")
            End If
            If Not regexInt.IsMatch(value) Then
                Throw New Exception("Telephone number must be comprised of numbers.")
            End If
            m_telephone = value
            Changed("Telephone")
        End Set
    End Property

    Public Property Comment() As String
        Get
            Return m_comment
        End Get
        Set(ByVal value As String)
            If value = String.Empty Then
                Throw New Exception("Comment can not be empty.")
            End If
            m_comment = value
            Changed("Comment")
        End Set
    End Property

End Class
