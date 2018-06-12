'********************************** Module Header ***********************************\
' Module Name:	TreeViewCrudDragDrop.xaml.vb
' Project:		VBSLTreeViewCRUDDragDrop
' Copyright (c) Microsoft Corporation.
' 
' Code Behind of Custom Silverlight User Control which implements a TreeView with added
' functionalities of CRUD and Drag-And-Drop
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
' EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
' MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\*************************************************************************************
#Region "Using Directives"
Imports System.Collections.ObjectModel
Imports VBSLTreeViewCRUDDragDrop.VBSLTreeViewCRUDDragDrop
#End Region

Namespace VBSLTreeViewCRUDDragDrop

End Namespace

Partial Public Class TreeViewCrudDragDrop
    Inherits UserControl
#Region "Member Variables"

    ''' <summary>
    ''' Collection bound to TreView
    ''' </summary>
    Private objectTree As ObservableCollection(Of Node)

    ''' <summary>
    ''' Data bound to currently selected TreeViewItem
    ''' </summary>
    Private selectedNode As Node

#End Region

#Region "Properties"

    ''' <summary>
    ''' Gets or sets the data bound to TreeView
    ''' </summary>
    Public Property Items() As List(Of Node)
        Get

            'objectTree.ToList()
            Return objectTree.ToList()
        End Get
        Set(ByVal value As List(Of Node))
            objectTree = New ObservableCollection(Of Node)(value)
            TreeViewMain.ItemsSource = objectTree


        End Set
    End Property

#End Region

#Region "Constructors"

    ''' <summary>
    ''' Creates a new instance of TreeViewCrudDragDrop
    ''' </summary>
    Public Sub New()
        InitializeComponent()
        objectTree = New ObservableCollection(Of Node)()
        TreeViewMain.ItemsSource = objectTree
    End Sub

#End Region
#Region "Event Handlers"

    ''' <summary>
    ''' Event handler for MouseRightButtonDown of TreeView and TreeViewItem
    ''' </summary>
    ''' <param name="sender">Object on which event occurred</param>
    ''' <param name="e">Event Arguments for the event</param>
    Private Sub TreeViewMain_MouseRightButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        DisableEditForSelectedItem()

        e.Handled = True
    End Sub

    ''' <summary>
    ''' Event handler for MouseRightButtonUp of TreeView and TreeViewItem
    ''' </summary>
    ''' <param name="sender">Object on which event occurred</param>
    ''' <param name="e">Event Arguments for the event</param>
    Private Sub TreeViewMain_MouseRightButtonUp(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        DisableEditForSelectedItem()

        If TypeOf sender Is TextBlock Then
            selectedNode = DirectCast(TryCast(sender, TextBlock).DataContext, Node)
        Else
            selectedNode = Nothing
        End If

        ShowContextMenu(e)
    End Sub

    ''' <summary>
    ''' Event handler for MouseLeftButtonDown of TreeView and TreeViewItem
    ''' </summary>
    ''' <param name="sender">Object on which event occurred</param>
    ''' <param name="e">Event Arguments for the event</param>
    Private Sub TreeViewMain_MouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        DisableEditForSelectedItem()

        HideContextMenu()
    End Sub

    ''' <summary>
    ''' Event handler for Add Button Click Event
    ''' </summary>
    ''' <param name="sender">Add Button</param>
    ''' <param name="e">Event arguments for event</param>
    Private Sub AddButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim newNode As New Node("New Node")

        If selectedNode IsNot Nothing Then
            selectedNode.Add(newNode)
        Else
            If objectTree IsNot Nothing Then
                objectTree.Add(newNode)
            Else
                objectTree = New ObservableCollection(Of Node)()
                objectTree.Add(newNode)
            End If
        End If

        HideContextMenu()
    End Sub

    ''' <summary>
    ''' Event handler for Edit Button Click Event
    ''' </summary>
    ''' <param name="sender">Edit Button</param>
    ''' <param name="e">Event arguments for event</param>
    Private Sub EditButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        EnalbleEditForSelectedItem()

        Dim selectedTreeViewItem As TreeViewItem = TreeViewExtensions.GetContainerFromItem(TreeViewMain, selectedNode)

        HideContextMenu()
    End Sub

    ''' <summary>
    ''' Event handler for Delete Button Click Event
    ''' </summary>
    ''' <param name="sender">Delete Button</param>
    ''' <param name="e">Event arguments for event</param>
    Private Sub DeleteButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim selectedTreeViewItem As TreeViewItem = TreeViewExtensions.GetContainerFromItem(TreeViewMain, selectedNode)

        If selectedTreeViewItem IsNot Nothing Then
            Dim selectedTreeViewItemParent As TreeViewItem = TreeViewExtensions.GetParentTreeViewItem(selectedTreeViewItem)

            If selectedTreeViewItemParent IsNot Nothing Then
                Dim seleactedParentNode As Node = DirectCast(selectedTreeViewItemParent.DataContext, Node)
                seleactedParentNode.Delete(selectedNode)
            Else
                objectTree.Remove(selectedNode)
            End If
        End If

        HideContextMenu()
    End Sub

#End Region


#Region "Methods"

    ''' <summary>
    ''' Show context menu
    ''' </summary>
    ''' <param name="e">Mouse Button Event Arguments for getting cursor position</param>
    Private Sub ShowContextMenu(ByVal e As MouseButtonEventArgs)
        e.Handled = True
        Dim p As Point = e.GetPosition(Me)
        ContextMenu.Visibility = Visibility.Visible
        ContextMenu.IsOpen = True
        ContextMenu.SetValue(Canvas.LeftProperty, CDbl(p.X))
        ContextMenu.SetValue(Canvas.TopProperty, CDbl(p.Y))
    End Sub

    ''' <summary>
    ''' Hide context menu
    ''' </summary>
    Private Sub HideContextMenu()
        ContextMenu.Visibility = Visibility.Collapsed
        ContextMenu.IsOpen = False
    End Sub

    ''' <summary>
    ''' Enable Edit Mode for selected TreeViewItem
    ''' </summary>
    Private Sub EnalbleEditForSelectedItem()
        If selectedNode IsNot Nothing Then
            SetTemplateForSelectedItem("TreeViewMainEditTemplate")
        End If
    End Sub

    ''' <summary>
    ''' Disable Edit mode for selected TreeViewItem
    ''' </summary>
    Private Sub DisableEditForSelectedItem()
        If selectedNode IsNot Nothing Then
            SetTemplateForSelectedItem("TreeViewMainReadTemplate")
            selectedNode = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Set Template for Selected TreeViewItem
    ''' </summary>
    ''' <param name="templateName">Template Name</param>
    Private Sub SetTemplateForSelectedItem(ByVal templateName As [String])
        Dim hdt As HierarchicalDataTemplate = DirectCast(Resources(templateName), HierarchicalDataTemplate)

        Dim selectedTreeViewItem As TreeViewItem = TreeViewExtensions.GetContainerFromItem(TreeViewMain, selectedNode)

        If selectedTreeViewItem IsNot Nothing Then
            selectedTreeViewItem.HeaderTemplate = hdt
        End If
    End Sub

#End Region
End Class
