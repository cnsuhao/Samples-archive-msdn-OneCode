# How to implement auto-scroll when doing drag in WPF
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* .NET
* Windows
* Windows Desktop App Development
* Windows Presentation Framework (WPF)
## Topics
* auto scroll
* drag
## IsPublished
* True
## ModifiedDate
* 2014-06-26 07:14:05
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to implement auto-scroll when doing drag in WPF</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This code snippet demonstrates how to implement automatic scrolling when dragging over a control in WPF.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">We register an attached property as a dependency property by using the
</span><a href="http://msdn.microsoft.com/en-us/library/system.windows.dependencyproperty.registerattached.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">RegisterAttached</span></a><span style="font-size:11pt"> method.
 This property can be set on the controls which have ScrollViewer in the visual tree.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">See code for attached behavior below:</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
namespace WpfApplication1
{
    
    public static class DragDropExtension
    {
        #region ScrollOnDragDropProperty
        public static readonly DependencyProperty ScrollOnDragDropProperty =
            DependencyProperty.RegisterAttached(&quot;ScrollOnDragDrop&quot;,
                typeof(bool),
                typeof(DragDropExtension),
                new PropertyMetadata(false, HandleScrollOnDragDropChanged));
        public static bool GetScrollOnDragDrop(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(&quot;element&quot;);
            }
            return (bool)element.GetValue(ScrollOnDragDropProperty);
        }
        public static void SetScrollOnDragDrop(DependencyObject element, bool value)
        {
            if (element == null)
            {
                throw new ArgumentNullException(&quot;element&quot;);
            }
            element.SetValue(ScrollOnDragDropProperty, value);
        }
        private static void HandleScrollOnDragDropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement container = d as FrameworkElement;
            if (d == null)
            {
                Debug.Fail(&quot;Invalid type!&quot;);
                return;
            }
            Unsubscribe(container);
            if (true.Equals(e.NewValue))
            {
                Subscribe(container);
            }
        }
        private static void Subscribe(FrameworkElement container)
        {
            container.PreviewDragOver &#43;= OnContainerPreviewDragOver;
        }
        private static void OnContainerPreviewDragOver(object sender, DragEventArgs e)
        {
            FrameworkElement container = sender as FrameworkElement;
            if (container == null)
            {
                return;
            }
            ScrollViewer scrollViewer = GetFirstVisualChild&lt;ScrollViewer&gt;(container);
            if (scrollViewer == null)
            {
                return;
            }
            double tolerance = 60;
            double verticalPos = e.GetPosition(container).Y;
            double offset = 5;
            if (verticalPos &lt; tolerance) 
            {
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - offset); 
            }
            else if (verticalPos &gt; container.ActualHeight - tolerance) 
            {
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset &#43; offset); 
            }
        }
        private static void Unsubscribe(FrameworkElement container)
        {
            container.PreviewDragOver -= OnContainerPreviewDragOver;
        }
        public static T GetFirstVisualChild&lt;T&gt;(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i &lt; VisualTreeHelper.GetChildrenCount(depObj); i&#43;&#43;)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        return (T)child;
                    }
                    T childItem = GetFirstVisualChild&lt;T&gt;(child);
                    if (childItem != null)
                    {
                        return childItem;
                    }
                }
            }
            return null;
        }
        #endregion
    }
}
</pre>
<pre class="hidden">
Public NotInheritable Class DragDropExtension
    Private Sub New()
    End Sub
#Region &quot;ScrollOnDragDropProperty&quot;
    Public Shared ReadOnly ScrollOnDragDropProperty As DependencyProperty =
        DependencyProperty.RegisterAttached(&quot;ScrollOnDragDrop&quot;, GetType(Boolean), GetType(DragDropExtension),
                                            New PropertyMetadata(False, New PropertyChangedCallback(AddressOf HandleScrollOnDragDropChanged)))
    Public Shared Function GetScrollOnDragDrop(element As DependencyObject) As Boolean
        If element Is Nothing Then
            Throw New ArgumentNullException(&quot;element&quot;)
        End If
        Return CBool(element.GetValue(ScrollOnDragDropProperty))
    End Function
    Public Shared Sub SetScrollOnDragDrop(element As DependencyObject, value As Boolean)
        If element Is Nothing Then
            Throw New ArgumentNullException(&quot;element&quot;)
        End If
        element.SetValue(ScrollOnDragDropProperty, value)
    End Sub
    Private Shared Sub HandleScrollOnDragDropChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim container As FrameworkElement = TryCast(d, FrameworkElement)
        If d Is Nothing Then
            Debug.Fail(&quot;Invalid type!&quot;)
            Return
        End If
        Unsubscribe(container)
        If True.Equals(e.NewValue) Then
            Subscribe(container)
        End If
    End Sub
    Private Shared Sub Subscribe(container As FrameworkElement)
        AddHandler container.PreviewDragOver, AddressOf OnContainerPreviewDragOver
    End Sub
    Private Shared Sub OnContainerPreviewDragOver(sender As Object, e As DragEventArgs)
        Dim container As FrameworkElement = TryCast(sender, FrameworkElement)
        If container Is Nothing Then
            Return
        End If
        Dim scrollViewer As ScrollViewer = GetFirstVisualChild(Of ScrollViewer)(container)
        If scrollViewer Is Nothing Then
            Return
        End If
        Dim tolerance As Double = 60
        Dim verticalPos As Double = e.GetPosition(container).Y
        Dim offset As Double = 5
        If verticalPos &lt; tolerance Then
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - offset)
        ElseIf verticalPos &gt; container.ActualHeight - tolerance Then
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset &#43; offset)
        End If
    End Sub
    Private Shared Sub Unsubscribe(container As FrameworkElement)
        RemoveHandler container.PreviewDragOver, AddressOf OnContainerPreviewDragOver
    End Sub
    Public Shared Function GetFirstVisualChild(Of T As DependencyObject)(depObj As DependencyObject) As T
        If depObj IsNot Nothing Then
            For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(depObj) - 1
                Dim child As DependencyObject = VisualTreeHelper.GetChild(depObj, i)
                If child IsNot Nothing AndAlso TypeOf child Is T Then
                    Return DirectCast(child, T)
                End If
                Dim childItem As T = GetFirstVisualChild(Of T)(child)
                If childItem IsNot Nothing Then
                    Return childItem
                End If
            Next
        End If
        Return Nothing
    End Function
#End Region
End Class
</pre>
<pre id="codePreview" class="csharp">
namespace WpfApplication1
{
    
    public static class DragDropExtension
    {
        #region ScrollOnDragDropProperty
        public static readonly DependencyProperty ScrollOnDragDropProperty =
            DependencyProperty.RegisterAttached(&quot;ScrollOnDragDrop&quot;,
                typeof(bool),
                typeof(DragDropExtension),
                new PropertyMetadata(false, HandleScrollOnDragDropChanged));
        public static bool GetScrollOnDragDrop(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(&quot;element&quot;);
            }
            return (bool)element.GetValue(ScrollOnDragDropProperty);
        }
        public static void SetScrollOnDragDrop(DependencyObject element, bool value)
        {
            if (element == null)
            {
                throw new ArgumentNullException(&quot;element&quot;);
            }
            element.SetValue(ScrollOnDragDropProperty, value);
        }
        private static void HandleScrollOnDragDropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement container = d as FrameworkElement;
            if (d == null)
            {
                Debug.Fail(&quot;Invalid type!&quot;);
                return;
            }
            Unsubscribe(container);
            if (true.Equals(e.NewValue))
            {
                Subscribe(container);
            }
        }
        private static void Subscribe(FrameworkElement container)
        {
            container.PreviewDragOver &#43;= OnContainerPreviewDragOver;
        }
        private static void OnContainerPreviewDragOver(object sender, DragEventArgs e)
        {
            FrameworkElement container = sender as FrameworkElement;
            if (container == null)
            {
                return;
            }
            ScrollViewer scrollViewer = GetFirstVisualChild&lt;ScrollViewer&gt;(container);
            if (scrollViewer == null)
            {
                return;
            }
            double tolerance = 60;
            double verticalPos = e.GetPosition(container).Y;
            double offset = 5;
            if (verticalPos &lt; tolerance) 
            {
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - offset); 
            }
            else if (verticalPos &gt; container.ActualHeight - tolerance) 
            {
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset &#43; offset); 
            }
        }
        private static void Unsubscribe(FrameworkElement container)
        {
            container.PreviewDragOver -= OnContainerPreviewDragOver;
        }
        public static T GetFirstVisualChild&lt;T&gt;(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i &lt; VisualTreeHelper.GetChildrenCount(depObj); i&#43;&#43;)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        return (T)child;
                    }
                    T childItem = GetFirstVisualChild&lt;T&gt;(child);
                    if (childItem != null)
                    {
                        return childItem;
                    }
                }
            }
            return null;
        }
        #endregion
    }
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">We need add the namespace to the XAML first:</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;Window x:Class=&quot;WpfApplication1.MainWindow&quot;
        xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
        xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
        xmlns:system=&quot;clr-namespace:System;assembly=mscorlib&quot;
        xmlns:WpfExtensions=&quot;clr-namespace:WpfApplication1&quot; 
        Title=&quot;MainWindow&quot; Height=&quot;350&quot; Width=&quot;525&quot;&gt;
</pre>
<pre id="codePreview" class="xaml">
&lt;Window x:Class=&quot;WpfApplication1.MainWindow&quot;
        xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
        xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
        xmlns:system=&quot;clr-namespace:System;assembly=mscorlib&quot;
        xmlns:WpfExtensions=&quot;clr-namespace:WpfApplication1&quot; 
        Title=&quot;MainWindow&quot; Height=&quot;350&quot; Width=&quot;525&quot;&gt;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Then we set ScrollOnDragDrop property to true on</span><span style="font-size:11pt"> the scrollable control, for example,</span><span style="font-size:11pt"> a ListBox:</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;ListBox Name=&quot;listBox1&quot; AllowDrop=&quot;True&quot; WpfExtensions:DragDropExtension.ScrollOnDragDrop =&quot;true&quot;  HorizontalAlignment=&quot;Left&quot; Height=&quot;100&quot; Margin=&quot;91,105,0,0&quot;&gt;
            &lt;system:String&gt;Microsoft 1&lt;/system:String&gt;
            &lt;system:String&gt;Microsoft 2&lt;/system:String&gt;
            &lt;system:String&gt;Microsoft 3&lt;/system:String&gt;
            &lt;system:String&gt;Microsoft 4&lt;/system:String&gt;
            &lt;system:String&gt;Microsoft 5&lt;/system:String&gt;
            &lt;system:String&gt;Microsoft 6&lt;/system:String&gt;
        &lt;/ListBox&gt;
</pre>
<pre id="codePreview" class="xaml">
&lt;ListBox Name=&quot;listBox1&quot; AllowDrop=&quot;True&quot; WpfExtensions:DragDropExtension.ScrollOnDragDrop =&quot;true&quot;  HorizontalAlignment=&quot;Left&quot; Height=&quot;100&quot; Margin=&quot;91,105,0,0&quot;&gt;
            &lt;system:String&gt;Microsoft 1&lt;/system:String&gt;
            &lt;system:String&gt;Microsoft 2&lt;/system:String&gt;
            &lt;system:String&gt;Microsoft 3&lt;/system:String&gt;
            &lt;system:String&gt;Microsoft 4&lt;/system:String&gt;
            &lt;system:String&gt;Microsoft 5&lt;/system:String&gt;
            &lt;system:String&gt;Microsoft 6&lt;/system:String&gt;
        &lt;/ListBox&gt;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Note to set AllowDrop property to true.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">We use a Label for dragging. When
</span><span style="font-size:11pt">we </span><span style="font-size:11pt">drag</span><a name="_GoBack"></a><span style="font-size:11pt"> this label to the ListBox, the auto-scroll will occur when the conditions are met.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                DragDrop.DoDragDrop((DependencyObject)sender, label.Content, DragDropEffects.All);
        }
</pre>
<pre class="hidden">
Private Sub Label_MouseDown(sender As Object, e As MouseButtonEventArgs)
        If e.ButtonState = MouseButtonState.Pressed Then
            DragDrop.DoDragDrop(DirectCast(sender, DependencyObject), label.Content, DragDropEffects.All)
        End If
    End Sub
</pre>
<pre id="codePreview" class="csharp">
private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                DragDrop.DoDragDrop((DependencyObject)sender, label.Content, DragDropEffects.All);
        }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">RegisterAttached</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/system.windows.dependencyproperty.registerattached.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/system.windows.dependencyproperty.registerattached.aspx</span></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Custom Attached Properties</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/ms749011.aspx#custom" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/ms749011.aspx#custom</span></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">WPF Drag&amp;Drop Auto-scroll</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://www.codeproject.com/Tips/635510/WPF-Drag-Drop-Auto-scroll%23_articleTop" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://www.codeproject.com/Tips/635510/WPF-Drag-Drop-Auto-scroll#_articleTop</span></a></span>
</p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers’ pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers’ frequently asked programming tasks, and allow
 developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
