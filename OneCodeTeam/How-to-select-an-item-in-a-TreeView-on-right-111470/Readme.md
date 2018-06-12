# How to select an item in a TreeView on right click in WPF applications
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* WPF
* .NET Framework
* Windows Desktop App Development
## Topics
* TreeView
## IsPublished
* True
## ModifiedDate
* 2015-01-04 08:32:04
## Description

<h1>
<hr>
<div><a href="http://blogs.msdn.com/b/onecode"><img src="http://bit.ly/onecodesampletopbanner" alt=""></a></div>
</h1>
<h1>How to select an item in a TreeView on right click in WPF applications</h1>
<h2>Introduction</h2>
<p>This code snippet project will show how to select an item in a TreeView on right click in WPF applications.</p>
<h2>Using the Code</h2>
<p>Step 1. Create a WPF application in Visual Studio.</p>
<p>Step 2. Create a static class named &quot;<strong>TreeViewExtension</strong>&quot;. In this class, we define a DependencyProperty &quot;<strong>SelectItemOnRightClickProperty</strong>&quot;.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System.Windows;

using System.Windows.Controls;

using System.Windows.Input;

using System.Windows.Media;

namespace WpfApplication1

{

    public static class TreeViewExtension

    {

        public static readonly DependencyProperty SelectItemOnRightClickProperty = DependencyProperty.RegisterAttached(

           &quot;SelectItemOnRightClick&quot;,

           typeof(bool),

           typeof(TreeViewExtension),

           new UIPropertyMetadata(false, OnSelectItemOnRightClickChanged));

        public static bool GetSelectItemOnRightClick(DependencyObject d)

        {

            return (bool)d.GetValue(SelectItemOnRightClickProperty);

        }

        public static void SetSelectItemOnRightClick(DependencyObject d, bool value)

        {

            d.SetValue(SelectItemOnRightClickProperty, value);

        }

        private static void OnSelectItemOnRightClickChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)

        {

            bool selectItemOnRightClick = (bool)e.NewValue;

            TreeView treeView = d as TreeView;

            if (treeView != null)

            {

                if (selectItemOnRightClick)

                    treeView.PreviewMouseRightButtonDown &#43;= OnPreviewMouseRightButtonDown;

                else

                    treeView.PreviewMouseRightButtonDown -= OnPreviewMouseRightButtonDown;

            }

        }

        private static void OnPreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)

        {

            TreeViewItem treeViewItem = VisualUpwardSearch(e.OriginalSource as DependencyObject);

            if (treeViewItem != null)

            {

                treeViewItem.Focus();

                e.Handled = true;

            }

        }

        public static TreeViewItem VisualUpwardSearch(DependencyObject source)

        {

            while (source != null &amp;&amp; !(source is TreeViewItem))

                source = VisualTreeHelper.GetParent(source);

            return source as TreeViewItem;

        }

    }

}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System.Windows;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Windows.Controls;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Windows.Input;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Windows.Media;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;WpfApplication1&nbsp;
&nbsp;
{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;TreeViewExtension&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;DependencyProperty&nbsp;SelectItemOnRightClickProperty&nbsp;=&nbsp;DependencyProperty.RegisterAttached(&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;SelectItemOnRightClick&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">bool</span>),&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">typeof</span>(TreeViewExtension),&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;UIPropertyMetadata(<span class="cs__keyword">false</span>,&nbsp;OnSelectItemOnRightClickChanged));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;GetSelectItemOnRightClick(DependencyObject&nbsp;d)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;(<span class="cs__keyword">bool</span>)d.GetValue(SelectItemOnRightClickProperty);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;SetSelectItemOnRightClick(DependencyObject&nbsp;d,&nbsp;<span class="cs__keyword">bool</span>&nbsp;<span class="cs__keyword">value</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.SetValue(SelectItemOnRightClickProperty,&nbsp;<span class="cs__keyword">value</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnSelectItemOnRightClickChanged(DependencyObject&nbsp;d,&nbsp;DependencyPropertyChangedEventArgs&nbsp;e)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;selectItemOnRightClick&nbsp;=&nbsp;(<span class="cs__keyword">bool</span>)e.NewValue;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TreeView&nbsp;treeView&nbsp;=&nbsp;d&nbsp;<span class="cs__keyword">as</span>&nbsp;TreeView;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(treeView&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(selectItemOnRightClick)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;treeView.PreviewMouseRightButtonDown&nbsp;&#43;=&nbsp;OnPreviewMouseRightButtonDown;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;treeView.PreviewMouseRightButtonDown&nbsp;-=&nbsp;OnPreviewMouseRightButtonDown;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnPreviewMouseRightButtonDown(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;MouseButtonEventArgs&nbsp;e)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TreeViewItem&nbsp;treeViewItem&nbsp;=&nbsp;VisualUpwardSearch(e.OriginalSource&nbsp;<span class="cs__keyword">as</span>&nbsp;DependencyObject);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(treeViewItem&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;treeViewItem.Focus();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Handled&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;TreeViewItem&nbsp;VisualUpwardSearch(DependencyObject&nbsp;source)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(source&nbsp;!=&nbsp;<span class="cs__keyword">null</span>&nbsp;&amp;&amp;&nbsp;!(source&nbsp;<span class="cs__keyword">is</span>&nbsp;TreeViewItem))&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;source&nbsp;=&nbsp;VisualTreeHelper.GetParent(source);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;source&nbsp;<span class="cs__keyword">as</span>&nbsp;TreeViewItem;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
}</pre>
</div>
</div>
</div>
<p>Step 3. The following XAML code shows a simple UI.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Window x:Class=&quot;WpfApplication1.MainWindow&quot;

        xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;

        xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;

        xmlns:mvvmhelper=&quot;clr-namespace:WpfApplication1&quot;

        Title=&quot;MainWindow&quot; Height=&quot;350&quot; Width=&quot;525&quot;&gt;

    &lt;Grid&gt;

        &lt;TreeView mvvmhelper:TreeViewExtension.SelectItemOnRightClick=&quot;true&quot;&gt;

            &lt;TreeViewItem Header=&quot;Node1&quot;/&gt;

            &lt;TreeViewItem Header=&quot;Node2&quot;/&gt;

            &lt;TreeViewItem Header=&quot;Node3&quot;/&gt;

            &lt;TreeView.ContextMenu&gt;

                &lt;ContextMenu&gt;

                    &lt;MenuItem Header=&quot;Menu1&quot;/&gt;

                    &lt;MenuItem Header=&quot;Menu2&quot;/&gt;

                &lt;/ContextMenu&gt;

            &lt;/TreeView.ContextMenu&gt;

        &lt;/TreeView&gt;

    &lt;/Grid&gt;

&lt;/Window&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Window</span>&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;WpfApplication1.MainWindow&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">mvvmhelper</span>=<span class="xaml__attr_value">&quot;clr-namespace:WpfApplication1&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Title</span>=<span class="xaml__attr_value">&quot;MainWindow&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;350&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;525&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TreeView</span>&nbsp;mvvmhelper:TreeViewExtension.<span class="xaml__attr_name">SelectItemOnRightClick</span>=<span class="xaml__attr_value">&quot;true&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TreeViewItem</span>&nbsp;<span class="xaml__attr_name">Header</span>=<span class="xaml__attr_value">&quot;Node1&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TreeViewItem</span>&nbsp;<span class="xaml__attr_name">Header</span>=<span class="xaml__attr_value">&quot;Node2&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TreeViewItem</span>&nbsp;<span class="xaml__attr_name">Header</span>=<span class="xaml__attr_value">&quot;Node3&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TreeView</span>.ContextMenu<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ContextMenu</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;MenuItem</span>&nbsp;<span class="xaml__attr_name">Header</span>=<span class="xaml__attr_value">&quot;Menu1&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;MenuItem</span>&nbsp;<span class="xaml__attr_name">Header</span>=<span class="xaml__attr_value">&quot;Menu2&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ContextMenu&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/TreeView.ContextMenu&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/TreeView&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;
&nbsp;
<span class="xaml__tag_end">&lt;/Window&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<p>Step 4. You can build and run the project. If everything goes well, you will see the following form, and you can validate the function.</p>
<p><img id="132012" src="https://i1.code.msdn.s-msft.com/how-to-select-an-item-in-a-f8d71da6/image/file/132012/1/1.png" alt="" width="524" height="348"></p>
<h2>More Information</h2>
<p>TreeView Class</p>
<p><a href="http://msdn.microsoft.com/en-us/library/system.windows.controls.treeview(v=vs.110).aspx">http://msdn.microsoft.com/en-us/library/system.windows.controls.treeview(v=vs.110).aspx</a></p>
<p>UIElement.PreviewMouseRightButtonDown Event</p>
<p><a href="http://msdn.microsoft.com/en-us/library/system.windows.uielement.previewmouserightbuttondown(v=vs.110).aspx">http://msdn.microsoft.com/en-us/library/system.windows.uielement.previewmouserightbuttondown(v=vs.110).aspx</a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
