# How to check the state of Caps Lock in Windows Store apps
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* Windows Store app
* Windows Store app Development
* Windows 8.1
## Topics
* code snippets
* Capslock
## IsPublished
* True
## ModifiedDate
* 2014-07-02 02:22:11
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<h1><strong>How to check the state of Caps Lock in Windows Store apps using C#/VB/C&#43;&#43;.</strong></h1>
<h2><strong>Introduction</strong></h2>
<p>This code snippet demonstrates how to check if the Caps Lock is off or not. The
<a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.core.corevirtualkeystates(v=win.10).aspx?cs-save-lang=1&cs-lang=cpp">
CoreVirtualKeyStates</a> offers us 3 states. We can check if a key is in pressed down state, in modified state or in no specific state. When we press down the Caps Lock key and switch the Caps Lock to on, the state will switch to CoreVirtualKeyStates.Locked
 | CoreVirtualKeyStates.Down.&nbsp;</p>
<h2><strong>Using the Code</strong></h2>
<p>1. We add the KeyDown event handler and GotFocus event handler to the textbox control. We'll check the Caps Lock key's state when this key is pressed or the textbox gets the focus.&nbsp;</p>
<ol>
</ol>
<h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Grid Background=&quot;{ThemeResource ApplicationPageBackgroundThemeBrush}&quot;&gt;
        &lt;Grid.RowDefinitions&gt;
            &lt;RowDefinition Height=&quot;300&quot;&gt;&lt;/RowDefinition&gt;
            &lt;RowDefinition Height=&quot;*&quot;&gt;&lt;/RowDefinition&gt;
        &lt;/Grid.RowDefinitions&gt;
        &lt;Grid.ColumnDefinitions&gt;
            &lt;ColumnDefinition Width=&quot;100&quot;&gt;&lt;/ColumnDefinition&gt;
            &lt;ColumnDefinition Width=&quot;auto&quot;&gt;&lt;/ColumnDefinition&gt;
            &lt;ColumnDefinition Width=&quot;auto&quot;&gt;&lt;/ColumnDefinition&gt;
        &lt;/Grid.ColumnDefinitions&gt;
        &lt;TextBox x:Name=&quot;textBox&quot; Grid.Row=&quot;1&quot; Grid.Column=&quot;1&quot; Height=&quot;55&quot; Width=&quot;500&quot; FontSize=&quot;22&quot; KeyDown=&quot;textBox_KeyDown&quot; GotFocus=&quot;textBox_GotFocus&quot; VerticalAlignment=&quot;Top&quot;/&gt;
        &lt;TextBlock x:Name=&quot;textBlock&quot; Grid.Row=&quot;1&quot; Grid.Column=&quot;2&quot; Visibility=&quot;Collapsed&quot; Text=&quot;Caps Locked&quot; Width=&quot;320&quot; Height=&quot;55&quot; FontSize=&quot;22&quot; VerticalAlignment=&quot;Top&quot;/&gt;
    &lt;/Grid&gt;
</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Grid</span><span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;{ThemeResource&nbsp;ApplicationPageBackgroundThemeBrush}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span><span class="xaml__tag_start">&lt;Grid</span>.RowDefinitions<span class="xaml__tag_start">&gt;&nbsp;
</span><span class="xaml__tag_start">&lt;RowDefinition</span><span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;300&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/RowDefinition&gt;</span><span class="xaml__tag_start">&lt;RowDefinition</span><span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;*&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/RowDefinition&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.ColumnDefinitions<span class="xaml__tag_start">&gt;&nbsp;
</span><span class="xaml__tag_start">&lt;ColumnDefinition</span><span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;100&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/ColumnDefinition&gt;</span><span class="xaml__tag_start">&lt;ColumnDefinition</span><span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;auto&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/ColumnDefinition&gt;</span><span class="xaml__tag_start">&lt;ColumnDefinition</span><span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;auto&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/ColumnDefinition&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.ColumnDefinitions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBox</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;textBox&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Column</span>=<span class="xaml__attr_value">&quot;1&quot;</span><span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;55&quot;</span><span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;500&quot;</span><span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;22&quot;</span><span class="xaml__attr_name">KeyDown</span>=<span class="xaml__attr_value">&quot;textBox_KeyDown&quot;</span><span class="xaml__attr_name">GotFocus</span>=<span class="xaml__attr_value">&quot;textBox_GotFocus&quot;</span><span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span><span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;textBlock&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Column</span>=<span class="xaml__attr_value">&quot;2&quot;</span><span class="xaml__attr_name">Visibility</span>=<span class="xaml__attr_value">&quot;Collapsed&quot;</span><span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Caps&nbsp;Locked&quot;</span><span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;320&quot;</span><span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;55&quot;</span><span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;22&quot;</span><span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span><span class="xaml__tag_start">/&gt;</span><span class="xaml__tag_end">&lt;/Grid&gt;</span></pre>
</div>
</div>
</div>
</h2>
<p>2. And process the check operation in the handler function.</p>
<ol>
</ol>
<p>Note that when Caps Lock is on, the state value will be CoreVirtualKeyStates::Locked | CoreVirtualKeyStates::Down in the KeyDown handler function.</p>
<h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span><span class="hidden">cplusplus</span>
<pre class="hidden">private void textBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            CoreVirtualKeyStates state = CoreWindow.GetForCurrentThread().GetKeyState(Windows.System.VirtualKey.CapitalLock);
            if (e.Key == Windows.System.VirtualKey.CapitalLock)
            {
                switch (state)
                {
                    case CoreVirtualKeyStates.Locked | CoreVirtualKeyStates.Down:
                        textBlock.Visibility = Windows.UI.Xaml.Visibility.Visible;
                        break;
                    default:
                        textBlock.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                        break;
                }
            }

        }
</pre>
<pre class="hidden">Private Sub textBox_KeyDown(sender As Object, e As KeyRoutedEventArgs)
        Dim state As CoreVirtualKeyStates = CoreWindow.GetForCurrentThread().GetKeyState(Windows.System.VirtualKey.CapitalLock)
        If e.Key = Windows.System.VirtualKey.CapitalLock Then
            Select Case state
                Case CoreVirtualKeyStates.Locked Or CoreVirtualKeyStates.Down
                    textBlock.Visibility = Windows.UI.Xaml.Visibility.Visible
                    Exit Select
                Case Else
                    textBlock.Visibility = Windows.UI.Xaml.Visibility.Collapsed
                    Exit Select
            End Select
        End If

    End Sub
</pre>
<pre class="hidden">void CapsLockApp::MainPage::TextBox_KeyDown(Platform::Object^ sender, Windows::UI::Xaml::Input::KeyRoutedEventArgs^ e)
{
    CoreVirtualKeyStates state = CoreWindow::GetForCurrentThread()-&gt;GetKeyState(Windows::System::VirtualKey::CapitalLock);
    if (e-&gt;Key == Windows::System::VirtualKey::CapitalLock)
    {
        switch (state)
        {
        case CoreVirtualKeyStates::Down | CoreVirtualKeyStates::Locked:
            textBlock-&gt;Visibility = Windows::UI::Xaml::Visibility::Visible;
            break;
        default:
            textBlock-&gt;Visibility = Windows::UI::Xaml::Visibility::Collapsed;
            break;
        }
    }

}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;textBox_KeyDown(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;KeyRoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CoreVirtualKeyStates&nbsp;state&nbsp;=&nbsp;CoreWindow.GetForCurrentThread().GetKeyState(Windows.System.VirtualKey.CapitalLock);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(e.Key&nbsp;==&nbsp;Windows.System.VirtualKey.CapitalLock)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">switch</span>&nbsp;(state)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;CoreVirtualKeyStates.Locked&nbsp;|&nbsp;CoreVirtualKeyStates.Down:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBlock.Visibility&nbsp;=&nbsp;Windows.UI.Xaml.Visibility.Visible;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">default</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBlock.Visibility&nbsp;=&nbsp;Windows.UI.Xaml.Visibility.Collapsed;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span><span class="hidden">cplusplus</span>
<pre class="hidden">private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            CoreVirtualKeyStates state = CoreWindow.GetForCurrentThread().GetKeyState(Windows.System.VirtualKey.CapitalLock);
            switch (state)
            {
                case CoreVirtualKeyStates.Locked:
                    textBlock.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    break;
                default:
                    textBlock.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    break;
            }
        }
</pre>
<pre class="hidden">Private Sub textBox_GotFocus(sender As Object, e As RoutedEventArgs)
        Dim state As CoreVirtualKeyStates = CoreWindow.GetForCurrentThread().GetKeyState(Windows.System.VirtualKey.CapitalLock)
        Select Case state
            Case CoreVirtualKeyStates.Locked
                textBlock.Visibility = Windows.UI.Xaml.Visibility.Visible
                Exit Select
            Case Else
                textBlock.Visibility = Windows.UI.Xaml.Visibility.Collapsed
                Exit Select
        End Select
    End Sub
</pre>
<pre class="hidden">void CapsLockApp::MainPage::textBox_GotFocus(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
    CoreVirtualKeyStates state = CoreWindow::GetForCurrentThread()-&gt;GetKeyState(Windows::System::VirtualKey::CapitalLock);
    switch (state)
    {

    case CoreVirtualKeyStates::Locked:
        textBlock-&gt;Visibility = Windows::UI::Xaml::Visibility::Visible;
        break;
    default:
        textBlock-&gt;Visibility = Windows::UI::Xaml::Visibility::Collapsed;
        break;
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;textBox_GotFocus(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CoreVirtualKeyStates&nbsp;state&nbsp;=&nbsp;CoreWindow.GetForCurrentThread().GetKeyState(Windows.System.VirtualKey.CapitalLock);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">switch</span>&nbsp;(state)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;CoreVirtualKeyStates.Locked:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBlock.Visibility&nbsp;=&nbsp;Windows.UI.Xaml.Visibility.Visible;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">default</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBlock.Visibility&nbsp;=&nbsp;Windows.UI.Xaml.Visibility.Collapsed;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
</div>
</h2>
<p>&nbsp;</p>
<h2><strong>More Information</strong></h2>
<ul>
<li>CoreVirtualKeyStates enumeration </li></ul>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.core.corevirtualkeystates(v=win.10).aspx" target="_blank">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.core.corevirtualkeystates(v=win.10).aspx</a></p>
<ul>
<li>CoreWindow.GetKeyState method </li></ul>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.core.corewindow.getkeystate.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.core.corewindow.getkeystate.aspx</a></p>
<ul>
<li>CoreWindow.GetForCurrentThread method </li></ul>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.core.corewindow.getforcurrentthread" target="_blank">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.core.corewindow.getforcurrentthread</a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
