# Silverlight TreeView supports CRUD and drag&drop (CSSLTreeViewCRUDDragDrop)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Silverlight
## Topics
* Drag and Drop
* TreeView
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:28:09
## Description

<p style="font-family:Courier New"></p>
<h2>APPLICATION : CSSLTreeViewCRUDDragDrop Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary: </h3>
<p style="font-family:Courier New"><br>
This Application showcases a custom TreeView with added functionalities of <br>
CRUD and Drag-And-Drop operations<br>
</p>
<h3>Prerequisite:</h3>
<p style="font-family:Courier New"><br>
You must have the following components installed on your machine<br>
1) Microsoft Visual Studio 2010<br>
2) Microsoft Silverlight 4 SDK<br>
3) Microsoft Silverlight 4 Toolkit April 2010<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
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
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
Step1. Create a new Silverlight Application called CSSLTreeViewCRUDDragDrop<br>
<br>
Step2. Add a new class Node. Replace the code with this<br>
<br>
&nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp;/// Data bound to tree view<br>
&nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp;public class Node<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;#region Private Members<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Text to display in each tree view item<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private String text;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Children of tree view item<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private ObservableCollection&lt;Node&gt; children;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Event Handler for PropertyChanged Event<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public event PropertyChangedEventHandler PropertyChanged;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;#endregion<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;#region Public Properties<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Gets or sets the Children of node<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public ObservableCollection&lt;Node&gt; Children<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get { return children; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;set { children = value; }<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Gets or sets the Text of node<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public String Text<br>
&nbsp; &nbsp; &nbsp; &nbsp;{ get { return text; } set { text = value; } }<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;#endregion<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;#region Constructor<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Creates a new instance of Node<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;text&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public Node(String text)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Children = new ObservableCollection&lt;Node&gt;();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Text = text;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;#endregion<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;#region Public Methods<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Adds a child lnode<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;node&quot;&gt;Node to be added&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public void Add(Node node)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;children.Add(node);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;NotifyPropertyChanged(&quot;Children&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Deletes a child node<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;node&quot;&gt;Node to be deleted&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public void Delete(Node node)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;children.Remove(node);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;NotifyPropertyChanged(&quot;Children&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;#endregion &nbsp; &nbsp; &nbsp; &nbsp;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;#region Private Methods<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Event handler for PropertyChange<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;info&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void NotifyPropertyChanged(String info)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (PropertyChanged != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;PropertyChanged(this, new PropertyChangedEventArgs(info));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;#endregion<br>
&nbsp; &nbsp;}<br>
<br>
Step3. Add a new Silverlight User Control called TreeViewCRUDDragDrop<br>
<br>
Replace the code in TreeViewCrudDragDrop.xaml by the following code<br>
<br>
&lt;UserControl <br>
&nbsp; &nbsp;xmlns:sdk=&quot;<a target="_blank" href="http://schemas.microsoft.com/winfx/2006/xaml/presentation/sdk&quot;">http://schemas.microsoft.com/winfx/2006/xaml/presentation/sdk&quot;</a> &nbsp;<br>
&nbsp; &nbsp;x:Class=&quot;CSSLTreeViewCRUDDragDrop.TreeViewCrudDragDrop&quot;<br>
&nbsp; &nbsp;xmlns=&quot;<a target="_blank" href="http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;">http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</a><br>
&nbsp; &nbsp;xmlns:x=&quot;<a target="_blank" href="http://schemas.microsoft.com/winfx/2006/xaml&quot;">http://schemas.microsoft.com/winfx/2006/xaml&quot;</a><br>
&nbsp; &nbsp;xmlns:d=&quot;<a target="_blank" href="http://schemas.microsoft.com/expression/blend/2008&quot;">http://schemas.microsoft.com/expression/blend/2008&quot;</a><br>
&nbsp; &nbsp;xmlns:mc=&quot;<a target="_blank" href="http://schemas.openxmlformats.org/markup-compatibility/2006&quot;">http://schemas.openxmlformats.org/markup-compatibility/2006&quot;</a><br>
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
Replace the code in TreeViewCrudDragDrop.xaml.cs with the following code<br>
<br>
&nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp;/// Code Behind of Custom Silverlight User Control which implements <br>
&nbsp; &nbsp;/// a TreeView with added functionalities of CRUD and Drag-And-Drop<br>
&nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp;public partial class TreeViewCrudDragDrop : UserControl<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;#region Member Variables<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Collection bound to TreView<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;ObservableCollection&lt;Node&gt; objectTree;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Data bound to currently selected TreeViewItem<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Node selectedNode;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;#endregion<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;#region Properties<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Gets or sets the data bound to TreeView<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public List&lt;Node&gt; Items<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return objectTree.ToList&lt;Node&gt;();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;set<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;objectTree = new ObservableCollection&lt;Node&gt;(value);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TreeViewMain.ItemsSource = objectTree;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;#endregion<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;#region Constructors<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Creates a new instance of TreeViewCrudDragDrop<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public TreeViewCrudDragDrop()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;InitializeComponent();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;objectTree = new ObservableCollection&lt;Node&gt;();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TreeViewMain.ItemsSource = objectTree;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;#endregion<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;#region Event Handlers<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Event handler for MouseRightButtonDown of TreeView and TreeViewItem<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;sender&quot;&gt;Object on which event occurred&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;e&quot;&gt;Event Arguements for the event&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void TreeViewMain_MouseRightButtonDown(object sender, MouseButtonEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;DisableEditForSelectedItem();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;e.Handled = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Event handler for MouseRightButtonUp of TreeView and TreeViewItem<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;sender&quot;&gt;Object on which event occurred&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;e&quot;&gt;Event Arguements for the event&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void TreeViewMain_MouseRightButtonUp(object sender, MouseButtonEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;DisableEditForSelectedItem();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (sender is TextBlock)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;selectedNode = (Node)((sender as TextBlock).DataContext);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;selectedNode = null;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ShowContextMenu(e);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Event handler for MouseLeftButtonDown of TreeView and TreeViewItem<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;sender&quot;&gt;Object on which event occurred&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;e&quot;&gt;Event Arguements for the event&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void TreeViewMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;DisableEditForSelectedItem();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HideContextMenu();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Event handler for Add Button Click Event<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;sender&quot;&gt;Add Button&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;e&quot;&gt;Event arguements for event&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void AddButton_Click(object sender, RoutedEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Node newNode = new Node(&quot;New Node&quot;);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (selectedNode != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;selectedNode.Add(newNode);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (objectTree != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;objectTree.Add(newNode);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;objectTree = new ObservableCollection&lt;Node&gt;();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;objectTree.Add(newNode);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HideContextMenu();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Event handler for Edit Button Click Event<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;sender&quot;&gt;Edit Button&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;e&quot;&gt;Event arguements for event&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void EditButton_Click(object sender, RoutedEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;EnalbleEditForSelectedItem();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TreeViewItem selectedTreeViewItem =<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TreeViewExtensions.GetContainerFromItem(TreeViewMain, selectedNode);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HideContextMenu();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Event handler for Delete Button Click Event<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;sender&quot;&gt;Delete Button&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;e&quot;&gt;Event arguements for event&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void DeleteButton_Click(object sender, RoutedEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TreeViewItem selectedTreeViewItem =<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TreeViewExtensions.GetContainerFromItem(TreeViewMain, selectedNode);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (selectedTreeViewItem != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TreeViewItem selectedTreeViewItemParent =<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TreeViewExtensions.GetParentTreeViewItem(selectedTreeViewItem);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (selectedTreeViewItemParent != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Node seleactedParentNode = (Node)selectedTreeViewItemParent.DataContext;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;seleactedParentNode.Delete(selectedNode);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;objectTree.Remove(selectedNode);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HideContextMenu();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;#endregion<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;#region Methods<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Show context menu<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;e&quot;&gt;Mouse Button Event Arguements for getting cursor position&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void ShowContextMenu(MouseButtonEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;e.Handled = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Point p = e.GetPosition(null);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ContextMenu.Visibility = Visibility.Visible;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ContextMenu.IsOpen = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ContextMenu.SetValue(Canvas.LeftProperty, (double)p.X);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ContextMenu.SetValue(Canvas.TopProperty, (double)p.Y);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Hide context menu<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void HideContextMenu()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ContextMenu.Visibility = Visibility.Collapsed;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ContextMenu.IsOpen = false;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Enable Edit Mode for selected TreeViewItem<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void EnalbleEditForSelectedItem()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (selectedNode != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SetTemplateForSelectedItem(&quot;TreeViewMainEditTemplate&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Disable Edit mode for selected TreeViewItem<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void DisableEditForSelectedItem()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (selectedNode != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SetTemplateForSelectedItem(&quot;TreeViewMainReadTemplate&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;selectedNode = null;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Set Template for Selected TreeViewItem<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;templateName&quot;&gt;Template Name&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void SetTemplateForSelectedItem(String templateName)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HierarchicalDataTemplate hdt = (HierarchicalDataTemplate)Resources[templateName];<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TreeViewItem selectedTreeViewItem =<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TreeViewExtensions.GetContainerFromItem(TreeViewMain, selectedNode);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (selectedTreeViewItem != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;selectedTreeViewItem.HeaderTemplate = hdt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;#endregion<br>
&nbsp; &nbsp;}<br>
<br>
Step3. Add instance of TreeViewCrudDragDrop in MainPage<br>
<br>
Add the following attribute in the UserControl attribute of MainPage<br>
<br>
xmlns:Crud=&quot;clr-namespace:CSSLTreeViewCRUDDragDrop&quot;<br>
<br>
Add the following code inside the grid tag<br>
<br>
&lt;Crud:TreeViewCrudDragDrop /&gt; &nbsp; &nbsp; &nbsp;<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MichaelSnow: Silverlight Tip of the Day #3 – Mouse Right Clicks<br>
<a target="_blank" href="http://www.michaelsnow.com/2010/04/23/silverlight-tip-of-the-day-3-mouse-right-clicks/">http://www.michaelsnow.com/2010/04/23/silverlight-tip-of-the-day-3-mouse-right-clicks/</a><br>
<br>
MSDN: DataBinding Silverlight<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc278072(v=vs.95).aspx">http://msdn.microsoft.com/en-us/library/cc278072(v=vs.95).aspx</a><br>
<br>
Codeplex: Silverlight Toolkit<br>
<a target="_blank" href="http://timheuer.com/blog/archive/2009/10/19/silverlight-toolkit-adds-drag-drop-support.aspx">http://timheuer.com/blog/archive/2009/10/19/silverlight-toolkit-adds-drag-drop-support.aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
