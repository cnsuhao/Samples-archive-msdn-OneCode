# Silverlight Treeview (SL4TreeViewCRUDDragDrop)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Silverlight
## Topics
* Controls
* TreeView
## IsPublished
* True
## ModifiedDate
* 2012-10-25 02:03:16
## Description
=============================================================================<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;APPLICATION : VBSLTreeViewCRUDDragDrop Project Overview<br>
=============================================================================<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Summary: <br>
<br>
This Application showcases a custom TreeView with added functionalities of <br>
CRUD and Drag-And-Drop operations<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Prerequisite:<br>
<br>
You must have the following components installed on your machine<br>
1) Microsoft Visual Studio 2010<br>
2) Microsoft Silverlight 4 SDK<br>
3) Microsoft Silverlight 4 Toolkit April 2010<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Demo:<br>
<br>
The following steps walk through a demonstration of the sample.<br>
<br>
Step1. Build the sample project in Visual Studio 2010, <br>
<br>
Step2. Start the Application by selecting &quot;Start Debugging&quot; or &quot;Start without Debugging&quot; in the build menu.<br>
<br>
Step3. Right-Click in the box and select &quot;Add&quot; in the context menu. Add more root nodes and also child nodes to existing nodes.<br>
<br>
Step4. Right-Click a node, and select &quot;Edit&quot;. Edit the content of the node.<br>
<br>
Step5. Right-Click a node, and select &quot;Delete&quot;. This will delete the node.<br>
<br>
Step6. Select any child node, drag and drop it to any other node.<br>
<br>
Step7. Close the application<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Implementation:<br>
<br>
Step1. Create a new Silverlight Application called VBSLTreeViewCRUDDragDrop<br>
<br>
Step2. Add a new class Node. Replace the code with this<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Data bound to tree view<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;Public Class Node<br>
&nbsp; &nbsp;#Region &quot;Private Members&quot;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Text to display in each tree view item<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private _textAs [String]<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Children of tree view item<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private _children &nbsp;As ObservableCollection(Of Node)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Event Handler for PropertyChanged Event<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Event PropertyChanged As PropertyChangedEventHandler<br>
<br>
&nbsp; &nbsp;#End Region<br>
<br>
&nbsp; &nbsp;#Region &quot;Public Properties&quot;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Gets or sets the Children of node<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Property Children() As ObservableCollection(Of Node)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return _children <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Set(ByVal value As ObservableCollection(Of Node))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;_children &nbsp;= value<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Set<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Property<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Gets or sets the Text of node<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Property Text() As [String]<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return _text<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Set(ByVal value As [String])<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;_text= value<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Set<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Property<br>
<br>
&nbsp; &nbsp;#End Region<br>
<br>
&nbsp; &nbsp;#Region &quot;Constructor&quot;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Creates a new instance of Node<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;_text&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Sub New(ByVal _textAs [String])<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Children = New ObservableCollection(Of Node)()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Text = _text<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;#End Region<br>
<br>
&nbsp; &nbsp;#Region &quot;Public Methods&quot;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Adds a child lnode<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;node&quot;&gt;Node to be added&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Sub Add(ByVal node As Node)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;_children .Add(node)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;NotifyPropertyChanged(&quot;Children&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Deletes a child node<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;node&quot;&gt;Node to be deleted&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Sub Delete(ByVal node As Node)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;_children .Remove(node)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;NotifyPropertyChanged(&quot;Children&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;#End Region<br>
<br>
&nbsp; &nbsp;#Region &quot;Private Methods&quot;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Event handler for PropertyChange<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;info&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub NotifyPropertyChanged(ByVal info As [String])<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;#End Region<br>
&nbsp; &nbsp;End Class<br>
<br>
Step3. Add a new Silverlight User Control called TreeViewCRUDDragDrop<br>
<br>
Replace the code in TreeViewCrudDragDrop.xaml by the following code<br>
<br>
&lt;UserControl <br>
&nbsp; &nbsp;xmlns:sdk=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation/sdk&quot; &nbsp;<br>
&nbsp; &nbsp;x:Class=&quot;VBSLTreeViewCRUDDragDrop.TreeViewCrudDragDrop&quot;<br>
&nbsp; &nbsp;xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;<br>
&nbsp; &nbsp;xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;<br>
&nbsp; &nbsp;xmlns:d=&quot;http://schemas.microsoft.com/expression/blend/2008&quot;<br>
&nbsp; &nbsp;xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;<br>
&nbsp; &nbsp;mc:Ignorable=&quot;d&quot;<br>
&nbsp; &nbsp;d:DesignHeight=&quot;300&quot; d:DesignWidth=&quot;400&quot;<br>
&nbsp; &nbsp;xmlns:toolkit=&quot;clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Toolkit&quot;<br>
&nbsp; &nbsp;xmlns:mswindows=&quot;clr-namespace:Microsoft.Windows;assembly=System.Windows.Controls.Toolkit&quot;&gt;<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;&lt;UserControl.Resources&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;!-- Template for Edit mode of TreeViewItem --&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;sdk:HierarchicalDataTemplate x:Key=&quot;TreeViewMainEditTemplate&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ItemsSource=&quot;{Binding Children}&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;TextBox Text=&quot;{Binding Text,Mode=TwoWay}&quot; &gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/TextBox&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/sdk:HierarchicalDataTemplate&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;!-- Template for Read mode for TreeViewItem --&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;sdk:HierarchicalDataTemplate x:Key=&quot;TreeViewMainReadTemplate&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ItemsSource=&quot;{Binding Children}&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;TextBlock Text=&quot;{Binding Text,Mode=TwoWay}&quot; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MouseRightButtonDown=&quot;TreeViewMain_MouseRightButtonDown&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MouseRightButtonUp=&quot;TreeViewMain_MouseRightButtonUp&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MouseLeftButtonDown=&quot;TreeViewMain_MouseLeftButtonDown&quot; &gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/TextBlock&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/sdk:HierarchicalDataTemplate&gt; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp;&lt;/UserControl.Resources&gt;<br>
<br>
&nbsp; &nbsp;&lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;White&quot;&gt; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;!-- TreeViewDragDropTarget from Toolkit to add DragAndDrop feature --&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;toolkit:TreeViewDragDropTarget AllowDrop=&quot;True&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;!-- Custom TreeView &nbsp;--&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;sdk:TreeView Name=&quot;TreeViewMain&quot; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ItemTemplate=&quot;{StaticResource TreeViewMainReadTemplate}&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MouseRightButtonDown=&quot;TreeViewMain_MouseRightButtonDown&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MouseRightButtonUp=&quot;TreeViewMain_MouseRightButtonUp&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MouseLeftButtonDown=&quot;TreeViewMain_MouseLeftButtonDown&quot; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Width=&quot;400&quot; Height=&quot;400&quot; &nbsp;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/sdk:TreeView&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/toolkit:TreeViewDragDropTarget&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;!-- Context Menu --&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;Canvas&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Popup Name=&quot;ContextMenu&quot; Visibility=&quot;Collapsed&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Border BorderThickness=&quot;1&quot; BorderBrush=&quot;Black&quot; Background=&quot;White&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;StackPanel&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;HyperlinkButton Content=&quot;Add&quot; Name=&quot;AddButton&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Click=&quot;AddButton_Click&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;HyperlinkButton Content=&quot;Edit&quot; Name=&quot;EditButton&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Click=&quot;EditButton_Click&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;HyperlinkButton Content=&quot;Delete&quot; Name=&quot;DeleteButton&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Click=&quot;DeleteButton_Click&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/StackPanel&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/Border&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/Popup&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/Canvas&gt;<br>
&nbsp; &nbsp;&lt;/Grid&gt;<br>
&nbsp; &nbsp;<br>
&lt;/UserControl&gt;<br>
<br>
Replace the code in TreeViewCrudDragDrop.xaml.vb with the following code<br>
<br>
&nbsp; &nbsp;Partial Public Class TreeViewCrudDragDrop<br>
&nbsp; &nbsp;Inherits UserControl<br>
&nbsp; &nbsp;#Region &quot;Member Variables&quot;<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Collection bound to TreView<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;Private objectTree As ObservableCollection(Of Node)<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Data bound to currently selected TreeViewItem<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;Private selectedNode As Node<br>
<br>
&nbsp; &nbsp;#End Region<br>
<br>
&nbsp; &nbsp;#Region &quot;Properties&quot;<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Gets or sets the data bound to TreeView<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;Public Property Items() As List(Of Node)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Get<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;'objectTree.ToList()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return objectTree.ToList()<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Get<br>
&nbsp; &nbsp; &nbsp; &nbsp;Set(ByVal value As List(Of Node))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;objectTree = New ObservableCollection(Of Node)(value)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TreeViewMain.ItemsSource = objectTree<br>
<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Set<br>
&nbsp; &nbsp;End Property<br>
<br>
&nbsp; &nbsp;#End Region<br>
<br>
&nbsp; &nbsp;#Region &quot;Constructors&quot;<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Creates a new instance of TreeViewCrudDragDrop<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;Public Sub New()<br>
&nbsp; &nbsp; &nbsp; &nbsp;InitializeComponent()<br>
&nbsp; &nbsp; &nbsp; &nbsp;objectTree = New ObservableCollection(Of Node)()<br>
&nbsp; &nbsp; &nbsp; &nbsp;TreeViewMain.ItemsSource = objectTree<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;#End Region<br>
&nbsp; &nbsp;#Region &quot;Event Handlers&quot;<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Event handler for MouseRightButtonDown of TreeView and TreeViewItem<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;sender&quot;&gt;Object on which event occurred&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;e&quot;&gt;Event Arguments for the event&lt;/param&gt;<br>
&nbsp; &nbsp;Private Sub TreeViewMain_MouseRightButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp;DisableEditForSelectedItem()<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;e.Handled = True<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Event handler for MouseRightButtonUp of TreeView and TreeViewItem<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;sender&quot;&gt;Object on which event occurred&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;e&quot;&gt;Event Arguments for the event&lt;/param&gt;<br>
&nbsp; &nbsp;Private Sub TreeViewMain_MouseRightButtonUp(ByVal sender As Object, ByVal e As MouseButtonEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp;DisableEditForSelectedItem()<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;If TypeOf sender Is TextBlock Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;selectedNode = DirectCast(TryCast(sender, TextBlock).DataContext, Node)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;selectedNode = Nothing<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;ShowContextMenu(e)<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Event handler for MouseLeftButtonDown of TreeView and TreeViewItem<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;sender&quot;&gt;Object on which event occurred&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;e&quot;&gt;Event Arguments for the event&lt;/param&gt;<br>
&nbsp; &nbsp;Private Sub TreeViewMain_MouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp;DisableEditForSelectedItem()<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;HideContextMenu()<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Event handler for Add Button Click Event<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;sender&quot;&gt;Add Button&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;e&quot;&gt;Event arguments for event&lt;/param&gt;<br>
&nbsp; &nbsp;Private Sub AddButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim newNode As New Node(&quot;New Node&quot;)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;If selectedNode IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;selectedNode.Add(newNode)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If objectTree IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;objectTree.Add(newNode)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;objectTree = New ObservableCollection(Of Node)()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;objectTree.Add(newNode)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;HideContextMenu()<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Event handler for Edit Button Click Event<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;sender&quot;&gt;Edit Button&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;e&quot;&gt;Event arguments for event&lt;/param&gt;<br>
&nbsp; &nbsp;Private Sub EditButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp;EnalbleEditForSelectedItem()<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim selectedTreeViewItem As TreeViewItem = TreeViewExtensions.GetContainerFromItem(TreeViewMain, selectedNode)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;HideContextMenu()<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Event handler for Delete Button Click Event<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;sender&quot;&gt;Delete Button&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;e&quot;&gt;Event arguments for event&lt;/param&gt;<br>
&nbsp; &nbsp;Private Sub DeleteButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim selectedTreeViewItem As TreeViewItem = TreeViewExtensions.GetContainerFromItem(TreeViewMain, selectedNode)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;If selectedTreeViewItem IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim selectedTreeViewItemParent As TreeViewItem = TreeViewExtensions.GetParentTreeViewItem(selectedTreeViewItem)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If selectedTreeViewItemParent IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim seleactedParentNode As Node = DirectCast(selectedTreeViewItemParent.DataContext, Node)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;seleactedParentNode.Delete(selectedNode)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;objectTree.Remove(selectedNode)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;HideContextMenu()<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;#End Region<br>
<br>
<br>
&nbsp; &nbsp;#Region &quot;Methods&quot;<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Show context menu<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;e&quot;&gt;Mouse Button Event Arguments for getting cursor position&lt;/param&gt;<br>
&nbsp; &nbsp;Private Sub ShowContextMenu(ByVal e As MouseButtonEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp;e.Handled = True<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim p As Point = e.GetPosition(Me)<br>
&nbsp; &nbsp; &nbsp; &nbsp;ContextMenu.Visibility = Visibility.Visible<br>
&nbsp; &nbsp; &nbsp; &nbsp;ContextMenu.IsOpen = True<br>
&nbsp; &nbsp; &nbsp; &nbsp;ContextMenu.SetValue(Canvas.LeftProperty, CDbl(p.X))<br>
&nbsp; &nbsp; &nbsp; &nbsp;ContextMenu.SetValue(Canvas.TopProperty, CDbl(p.Y))<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Hide context menu<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;Private Sub HideContextMenu()<br>
&nbsp; &nbsp; &nbsp; &nbsp;ContextMenu.Visibility = Visibility.Collapsed<br>
&nbsp; &nbsp; &nbsp; &nbsp;ContextMenu.IsOpen = False<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Enable Edit Mode for selected TreeViewItem<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;Private Sub EnalbleEditForSelectedItem()<br>
&nbsp; &nbsp; &nbsp; &nbsp;If selectedNode IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SetTemplateForSelectedItem(&quot;TreeViewMainEditTemplate&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Disable Edit mode for selected TreeViewItem<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;Private Sub DisableEditForSelectedItem()<br>
&nbsp; &nbsp; &nbsp; &nbsp;If selectedNode IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SetTemplateForSelectedItem(&quot;TreeViewMainReadTemplate&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;selectedNode = Nothing<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Set Template for Selected TreeViewItem<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;templateName&quot;&gt;Template Name&lt;/param&gt;<br>
&nbsp; &nbsp;Private Sub SetTemplateForSelectedItem(ByVal templateName As [String])<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim hdt As HierarchicalDataTemplate = DirectCast(Resources(templateName), HierarchicalDataTemplate)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim selectedTreeViewItem As TreeViewItem = TreeViewExtensions.GetContainerFromItem(TreeViewMain, selectedNode)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;If selectedTreeViewItem IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;selectedTreeViewItem.HeaderTemplate = hdt<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;#End Region<br>
End Class<br>
<br>
Step3. Add instance of TreeViewCrudDragDrop in MainPage<br>
<br>
Add the following attribute in the UserControl attribute of MainPage<br>
<br>
xmlns:Crud=&quot;clr-namespace:VBSLTreeViewCRUDDragDrop&quot;<br>
<br>
Add the following code inside the grid tag<br>
<br>
&lt;Crud:TreeViewCrudDragDrop /&gt; &nbsp; &nbsp; &nbsp;<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
References:<br>
<br>
MichaelSnow: Silverlight Tip of the Day #3 – Mouse Right Clicks<br>
http://www.michaelsnow.com/2010/04/23/silverlight-tip-of-the-day-3-mouse-right-clicks/<br>
<br>
MSDN: DataBinding Silverlight<br>
http://msdn.microsoft.com/en-us/library/cc278072(v=vs.95).aspx<br>
<br>
Codeplex: Silverlight Toolkit<br>
http://timheuer.com/blog/archive/2009/10/19/silverlight-toolkit-adds-drag-drop-support.aspx<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
