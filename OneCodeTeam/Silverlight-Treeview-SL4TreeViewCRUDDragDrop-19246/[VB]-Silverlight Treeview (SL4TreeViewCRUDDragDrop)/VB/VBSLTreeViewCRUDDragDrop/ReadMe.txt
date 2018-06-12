=============================================================================
          APPLICATION : VBSLTreeViewCRUDDragDrop Project Overview
=============================================================================

/////////////////////////////////////////////////////////////////////////////
Summary: 

This Application showcases a custom TreeView with added functionalities of 
CRUD and Drag-And-Drop operations

/////////////////////////////////////////////////////////////////////////////
Prerequisite:

You must have the following components installed on your machine
1) Microsoft Visual Studio 2010
2) Microsoft Silverlight 4 SDK
3) Microsoft Silverlight 4 Toolkit April 2010

/////////////////////////////////////////////////////////////////////////////
Demo:

The following steps walk through a demonstration of the sample.

Step1. Build the sample project in Visual Studio 2010, 

Step2. Start the Application by selecting "Start Debugging" or "Start without Debugging" in the build menu.

Step3. Right-Click in the box and select "Add" in the context menu. Add more root nodes and also child nodes to existing nodes.

Step4. Right-Click a node, and select "Edit". Edit the content of the node.

Step5. Right-Click a node, and select "Delete". This will delete the node.

Step6. Select any child node, drag and drop it to any other node.

Step7. Close the application

/////////////////////////////////////////////////////////////////////////////
Implementation:

Step1. Create a new Silverlight Application called VBSLTreeViewCRUDDragDrop

Step2. Add a new class Node. Replace the code with this

    ''' <summary>
    ''' Data bound to tree view
    ''' </summary>
    Public Class Node
    #Region "Private Members"

        ''' <summary>
        ''' Text to display in each tree view item
        ''' </summary>
        Private _textAs [String]
        ''' <summary>
        ''' Children of tree view item
        ''' </summary>
        Private _children  As ObservableCollection(Of Node)

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
                _children  = value
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
                _text= value
            End Set
        End Property

    #End Region

    #Region "Constructor"

        ''' <summary>
        ''' Creates a new instance of Node
        ''' </summary>
        ''' <param name="_text"></param>
        Public Sub New(ByVal _textAs [String])
            Children = New ObservableCollection(Of Node)()
            Text = _text
        End Sub

    #End Region

    #Region "Public Methods"

        ''' <summary>
        ''' Adds a child lnode
        ''' </summary>
        ''' <param name="node">Node to be added</param>
        Public Sub Add(ByVal node As Node)
            _children .Add(node)
            NotifyPropertyChanged("Children")
        End Sub

        ''' <summary>
        ''' Deletes a child node
        ''' </summary>
        ''' <param name="node">Node to be deleted</param>
        Public Sub Delete(ByVal node As Node)
            _children .Remove(node)
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

Step3. Add a new Silverlight User Control called TreeViewCRUDDragDrop

Replace the code in TreeViewCrudDragDrop.xaml by the following code

<UserControl 
    xmlns:sdk="http://schemas.microsoft.com/winfx/2006/xaml/presentation/sdk"  
    x:Class="VBSLTreeViewCRUDDragDrop.TreeViewCrudDragDrop"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    d:DesignHeight="300" d:DesignWidth="400"
    xmlns:toolkit="clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Toolkit"
    xmlns:mswindows="clr-namespace:Microsoft.Windows;assembly=System.Windows.Controls.Toolkit">
    
    <UserControl.Resources>
        <!-- Template for Edit mode of TreeViewItem -->
        <sdk:HierarchicalDataTemplate x:Key="TreeViewMainEditTemplate" 
                                      ItemsSource="{Binding Children}">
            <TextBox Text="{Binding Text,Mode=TwoWay}" >
            </TextBox>
        </sdk:HierarchicalDataTemplate>
        <!-- Template for Read mode for TreeViewItem -->
        <sdk:HierarchicalDataTemplate x:Key="TreeViewMainReadTemplate" 
                                      ItemsSource="{Binding Children}">
            <TextBlock Text="{Binding Text,Mode=TwoWay}"               
                      MouseRightButtonDown="TreeViewMain_MouseRightButtonDown" 
                      MouseRightButtonUp="TreeViewMain_MouseRightButtonUp" 
                      MouseLeftButtonDown="TreeViewMain_MouseLeftButtonDown" >
            </TextBlock>
        </sdk:HierarchicalDataTemplate>        
    </UserControl.Resources>

    <Grid x:Name="LayoutRoot" Background="White">        
        <!-- TreeViewDragDropTarget from Toolkit to add DragAndDrop feature -->
        <toolkit:TreeViewDragDropTarget AllowDrop="True">
            <!-- Custom TreeView  -->
            <sdk:TreeView Name="TreeViewMain"    
                      ItemTemplate="{StaticResource TreeViewMainReadTemplate}"
                      MouseRightButtonDown="TreeViewMain_MouseRightButtonDown" 
                      MouseRightButtonUp="TreeViewMain_MouseRightButtonUp" 
                      MouseLeftButtonDown="TreeViewMain_MouseLeftButtonDown"                       
                      Width="400" Height="400"  >
            </sdk:TreeView>
        </toolkit:TreeViewDragDropTarget>
        
        <!-- Context Menu -->
        <Canvas>
            <Popup Name="ContextMenu" Visibility="Collapsed">
                <Border BorderThickness="1" BorderBrush="Black" Background="White">
                    <StackPanel>
                        <HyperlinkButton Content="Add" Name="AddButton" 
                                         Click="AddButton_Click" />
                        <HyperlinkButton Content="Edit" Name="EditButton" 
                                         Click="EditButton_Click"/>
                        <HyperlinkButton Content="Delete" Name="DeleteButton" 
                                         Click="DeleteButton_Click"/>
                    </StackPanel>
                </Border>
            </Popup>
        </Canvas>
    </Grid>
    
</UserControl>

Replace the code in TreeViewCrudDragDrop.xaml.vb with the following code

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

Step3. Add instance of TreeViewCrudDragDrop in MainPage

Add the following attribute in the UserControl attribute of MainPage

xmlns:Crud="clr-namespace:VBSLTreeViewCRUDDragDrop"

Add the following code inside the grid tag

<Crud:TreeViewCrudDragDrop />      

/////////////////////////////////////////////////////////////////////////////
References:

MichaelSnow: Silverlight Tip of the Day #3 – Mouse Right Clicks
http://www.michaelsnow.com/2010/04/23/silverlight-tip-of-the-day-3-mouse-right-clicks/

MSDN: DataBinding Silverlight
http://msdn.microsoft.com/en-us/library/cc278072(v=vs.95).aspx

Codeplex: Silverlight Toolkit
http://timheuer.com/blog/archive/2009/10/19/silverlight-toolkit-adds-drag-drop-support.aspx

/////////////////////////////////////////////////////////////////////////////