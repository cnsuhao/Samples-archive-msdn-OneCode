# How to drag item between groups in grouped gridview
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows 8
## Topics
* Windows 8
## IsPublished
* True
## ModifiedDate
* 2015-02-08 10:33:09
## Description

<h1><span><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144425" target="_blank"><img id="79968" src="http://i1.code.msdn.s-msft.com/cswindowsstoreappadditem-a5d7fbcc/image/file/79968/1/dpe_w8_728x90_1022_v2.jpg" alt="" width="728" height="90" style="width:100%"></a></span></h1>
<h1>How to drag and drop item between groups in a grouped GridView (CSWindowsStoreAppDragAndDropBetweenGroups)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to drag and drop item between groups in a grouped GridView.</p>
<h2 class="MsoNormal">Video</h2>
<p><a href="http://channel9.msdn.com/Blogs/OneCode/How-to-drag-items-between-groups-in-grouped-GridView" target="_blank"><img id="133567" src="https://i1.code.msdn.s-msft.com/how-to-drag-item-between-c66cc4d2/image/file/133567/1/how%20to%20drag%20items%20between%20groups%20in%20grouped%20gridview%20%20%20channel%209.png" alt="" width="640" height="360" style="border:1px solid black"></a></p>
<h2>Building the Sample</h2>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:.5in; text-indent:-.25in; line-height:12.75pt">
<span style="color:black">1.</span><span style="font-size:7.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:black">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="color:black">Start Visual Studio 2012 and select File &gt; Open &gt; Project/Solution.
</span></p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:.5in; text-indent:-.25in; line-height:12.75pt">
<span style="color:black">2.</span><span style="font-size:7.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:black">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="color:black">Go to the directory in which you download the sample. Go to the directory
 named for the sample, and double-click the Microsoft Visual Studio Solution(.sln) file.
</span></p>
<p class="MsoNormal" style="margin-left:.5in; text-indent:-.25in; line-height:12.75pt">
<span style="color:black">3.</span><span style="font-size:7.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:black">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="color:black">Press F7 or use Build &gt; Build Solution to build the sample.</span><span style="color:black">
</span></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press F5 to run it.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>After the sample is launched, you will see this screen.</p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/78757/1/image.png" alt="" width="866" height="488" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>You can drag one item from one group to <span class="GramE">
another,</span> the dragged item will be removed from the original group and insert to the destination group.</p>
<p class="MsoListParagraphCxSpLast"><span><img src="/site/view/file/78758/1/image.png" alt="" width="866" height="490" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoListParagraph" style="text-indent:-.25in"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Get the dragged item in GridView.DragItemsStarting event handler.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void ItemsByCategory_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; draggedItem = e.Items[0] as Book;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
<pre id="codePreview" class="csharp">private void ItemsByCategory_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; draggedItem = e.Items[0] as Book;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst">&nbsp;</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Remove the dragged item from the original group and add it to the destination group in VariableSizedWrapGrid.Drop event handler.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void VariableSizedWrapGrid_Drop(object sender, DragEventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (draggedItem != null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var sourceCategory = draggedItem.Cate;
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var child = (((VariableSizedWrapGrid)sender).Children[0] as GridViewItem).Content as Book;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; draggedItem.Cate = child.Cate;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; child.Cate.BookList.Add(draggedItem);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; sourceCategory.BookList.Remove(draggedItem);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; draggedItem = null;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; catch (Exception ex)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NotifyUser(ex.ToString());
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
<pre id="codePreview" class="csharp">private void VariableSizedWrapGrid_Drop(object sender, DragEventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (draggedItem != null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var sourceCategory = draggedItem.Cate;
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var child = (((VariableSizedWrapGrid)sender).Children[0] as GridViewItem).Content as Book;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; draggedItem.Cate = child.Cate;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; child.Cate.BookList.Add(draggedItem);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; sourceCategory.BookList.Remove(draggedItem);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; draggedItem = null;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; catch (Exception ex)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NotifyUser(ex.ToString());
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph">&nbsp;</p>
<h2>More Information</h2>
<p class="MsoNormal">ListViewBase.DragItemStarting event (Windows)</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.listviewbase.dragitemsstarting">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.listviewbase.dragitemsstarting</a></p>
<p class="MsoNormal">UIElement.Drop event (Windows)</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.uielement.drop">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.uielement.drop</a></p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal">&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
