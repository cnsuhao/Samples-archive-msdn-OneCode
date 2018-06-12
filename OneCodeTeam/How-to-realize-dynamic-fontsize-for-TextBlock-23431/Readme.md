# How to realize dynamic fontsize for TextBlock
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows 8
* Windows Store app Development
## Topics
* TextBlock
* windows8
## IsPublished
* True
## ModifiedDate
* 2013-06-25 11:20:20
## Description

<h1><span style="">How to set dynamic FontSize for TextBlock (VBWindowsStoreAppDynamicFontsize)
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to set dynamic FontSize for a fixed size TextBlock, so that no matter how long the content is, it will be displayed in the TextBlock completely without ScrollBar.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal"></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Start Visual Studio Express&nbsp;2012 for Windows&nbsp;8 and select&nbsp;File&nbsp;&gt;&nbsp;Open&nbsp;&gt;&nbsp;Project/Solution.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Go to the directory in which you unzipped the sample. Go to the directory named for the sample, and double-click the Visual Studio Express&nbsp;2012 for Windows&nbsp;8 Solution (.sln) file.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press F6 or use&nbsp;Build&nbsp;&gt;&nbsp;Build Solution&nbsp;to build the sample.</p>
<p class="MsoListParagraphCxSpLast"></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>After launching the sample, this screen will display.</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/86566/1/image.png" alt="" width="576" height="328" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle"></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>You can enter any text in the left TextBox, when the content is too long, that the right TextBlock couldn't display all of them without ScrollBar, you will find the FontSize will automatically change, all of the content will be displayed
 in it without ScrollBar.</p>
<p class="MsoListParagraphCxSpLast"><span style=""><img src="/site/view/file/86567/1/image.png" alt="" width="576" height="326" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">The code below shows how to set FontSize dynamically in SizeChanged event.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub TextBlock_SizeChanged(sender As Object, e As SizeChangedEventArgs)
    Dim contentTextBlock As TextBlock = TryCast(sender, TextBlock)
    If contentTextBlock IsNot Nothing Then
        Dim height As Double = contentTextBlock.Height
        If Me.ContentTextBlock.ActualHeight &gt; height Then
            ' Get how many times the TextBlock's height compares with the existing one
            Dim fontsizeMultiplier As Double = Math.Sqrt(height / Me.ContentTextBlock.ActualHeight)


            ' Set the new FontSize
            Me.ContentTextBlock.FontSize = Math.Floor(Me.ContentTextBlock.FontSize * fontsizeMultiplier)
        End If
        Me.ContentTextBlock.Height = height
    End If
End Sub


' When user delete some text, TextBlock_SizeChanged event will not raised.
' In this scenario, we should manually raise it.
Private Sub ContextText_TextChanged(sender As Object, e As TextChangedEventArgs)
    If previousTextLength &gt; Me.ContentTextBox.Text.Length Then
        ' By doing this, TextBlock_SizeChanged event may be fired.
        Me.ContentTextBlock.FontSize = originalFontSize
    End If
    previousTextLength = Me.ContentTextBox.Text.Length
End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub TextBlock_SizeChanged(sender As Object, e As SizeChangedEventArgs)
    Dim contentTextBlock As TextBlock = TryCast(sender, TextBlock)
    If contentTextBlock IsNot Nothing Then
        Dim height As Double = contentTextBlock.Height
        If Me.ContentTextBlock.ActualHeight &gt; height Then
            ' Get how many times the TextBlock's height compares with the existing one
            Dim fontsizeMultiplier As Double = Math.Sqrt(height / Me.ContentTextBlock.ActualHeight)


            ' Set the new FontSize
            Me.ContentTextBlock.FontSize = Math.Floor(Me.ContentTextBlock.FontSize * fontsizeMultiplier)
        End If
        Me.ContentTextBlock.Height = height
    End If
End Sub


' When user delete some text, TextBlock_SizeChanged event will not raised.
' In this scenario, we should manually raise it.
Private Sub ContextText_TextChanged(sender As Object, e As TextChangedEventArgs)
    If previousTextLength &gt; Me.ContentTextBox.Text.Length Then
        ' By doing this, TextBlock_SizeChanged event may be fired.
        Me.ContentTextBlock.FontSize = originalFontSize
    End If
    previousTextLength = Me.ContentTextBox.Text.Length
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal"><span class="SpellE">FrameworkElement.SizeChanged</span> Event</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.frameworkelement.sizechanged">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.frameworkelement.sizechanged</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
