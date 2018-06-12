'****************************** Module Header ******************************\
' Module Name:  ReadinessAndLevel.vb
' Project:      VBWP8CollectionViewSource
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
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace ModelNamespace
    Public Class ReadinessAndLevel
        Implements INotifyPropertyChanged

        ' The name of the readinessAndLevel.
        Public Property Name() As String

        ' The type of the readinessAndLevel, Item or Level.
        Public Property Type() As String

        ' The number of each item that has been collected.
        Private _count As Integer
        Public Property Count() As Integer
            Get
                Return _count
            End Get
            Set(value As Integer)
                _count = value
                RaisePropertyChanged("Count")
            End Set
        End Property

        ' Whether a level has been completed or not
        Private _completed As Boolean
        Public Property Completed() As Boolean
            Get
                Return _completed
            End Get
            Set(value As Boolean)
                _completed = value
                RaisePropertyChanged("Completed")
            End Set
        End Property

        Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

        Private Sub RaisePropertyChanged(propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub

        ' Create a copy of an readinessAndLevel to save.
        ' If your object is databound, this copy is not databound.
        Public Function GetCopy() As ReadinessAndLevel
            Dim copy As ReadinessAndLevel = DirectCast(Me.MemberwiseClone(), ReadinessAndLevel)
            Return copy
        End Function
    End Class
End Namespace

