'********************************** Module Header ***********************************\
' Module Name:	Node.vb
' Project:		VBSLTreeViewCRUDDragDrop
' Copyright (c) Microsoft Corporation.
' 
' Data bound to TreeView
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
' EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
' MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\*****************n*******************************************************************

#Region "Using directives"

Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.ComponentModel
Imports System.Collections.ObjectModel

#End Region

Namespace VBSLTreeViewCRUDDragDrop
    ''' <summary>
    ''' Data bound to tree view
    ''' </summary>
    Public Class Node
#Region "Private Members"

        ''' <summary>
        ''' Text to display in each tree view item
        ''' </summary>
        Private _text As [String]
        ''' <summary>
        ''' Children of tree view item
        ''' </summary>
        Private _children As ObservableCollection(Of Node)

        ''' <summary>
        ''' Event Handler for PropertyChanged Event
        ''' </summary>
        Public Event PropertyChanged As PropertyChangedEventHandler

#End Region

#Region "Public Properties"

        ''' <summary>
        ''' Gets or sets the Children of node
        ''' </summary>
        Public Property Children() As ObservableCollection(Of Node)
            Get
                Return _children
            End Get
            Set(ByVal value As ObservableCollection(Of Node))
                _children = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the Text of node
        ''' </summary>
        Public Property Text() As [String]
            Get
                Return _text
            End Get
            Set(ByVal value As [String])
                _text = value
            End Set
        End Property

#End Region

#Region "Constructor"

        ''' <summary>
        ''' Creates a new instance of Node
        ''' </summary>
        ''' <param name="_text"></param>
        Public Sub New(ByVal _text As [String])
            Children = New ObservableCollection(Of Node)()
            Text = _text
        End Sub

#End Region

#Region "Public Methods"

        ''' <summary>
        ''' Adds a child node
        ''' </summary>
        ''' <param name="node">Node to be added</param>
        Public Sub Add(ByVal node As Node)
            _children.Add(node)
            NotifyPropertyChanged("Children")
        End Sub

        ''' <summary>
        ''' Deletes a child node
        ''' </summary>
        ''' <param name="node">Node to be deleted</param>
        Public Sub Delete(ByVal node As Node)
            _children.Remove(node)
            NotifyPropertyChanged("Children")
        End Sub

#End Region

#Region "Private Methods"

        ''' <summary>
        ''' Event handler for PropertyChange
        ''' </summary>
        ''' <param name="info"></param>
        Private Sub NotifyPropertyChanged(ByVal info As [String])
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
        End Sub

#End Region
    End Class
End Namespace

