# Drag-and-drop operations in Windows Forms (CSWinFormDragAndDrop)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* Windows Forms
## Topics
* Drag &amp; Drop
## IsPublished
* True
## ModifiedDate
* 2012-03-11 06:50:14
## Description

<h1><span style="font-family:������">WINDOWS FORMS APPLICATION</span> (<span style="font-family:������">CSWinFormDragAndDrop</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">Windows users fall into two general categories: those who prefer to use the keyboard and those who prefer to use the mouse. Programmers have been taught to look after the needs of keyboard users by providing access keys
 (the underlined letter in a command or menu) and shortcuts (such as a CTRL &#43; letter combination), but the needs of mouse users have largely been ignored. Programmers tend to primarily be keyboard users, so the emphasis on keyboard-oriented features is understandable,
 but every programmer should consider providing mouse support as well. </span></p>
<p class="MsoNormal"><span style="">One thing that mouse users expect is the ability to drag and drop. If you look at most major applications or at Windows itself, drag and drop is everywhere. For example, users are accustomed to dragging and dropping files
 in the Windows Explorer and to dragging and dropping text in Microsoft Word. </span>
</p>
<p class="MsoNormal"><span style="">Despite these expectations, few programmers provide drag-and-drop capability in their applications �� most likely because implementing drag and drop appears to be much more difficult than it actually is.
</span>This example demonstrates how to perform drag-and-drop operations in a Windows Forms Application.<span style="">
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">To see the result, press the left key of your mouse down, and drag an item from the
<span class="SpellE">ListBox</span>(on the right side) and drop it to the <span class="SpellE">
TreeView</span>(on the left side), then release your mouse. </span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/54147/1/image.png" alt="" width="720" height="483" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">The items are added into the <span class="SpellE">
TreeView</span> control. </span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/54148/1/image.png" alt="" width="720" height="483" align="middle">
</span><span style=""></span></p>
<h2><span style="">Using the code </span></h2>
<p class="MsoNormal"><span style="">1. Enable dropping on the destination control(it's TreeView in this example) by setting AllowDrop property to true.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Enable dropping on the TreeView  
this.treeView1.AllowDrop = true;

</pre>
<pre id="codePreview" class="csharp">
// Enable dropping on the TreeView  
this.treeView1.AllowDrop = true;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">2. Handle the MouseDown event on the source
<span class="GramE">control(</span>here is ListBox) to start the drag operation. And call the DoDragDrop method to enable data to be collected when dragging begins.<span style="">&nbsp;&nbsp;
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
      void listBox1_MouseDown(object sender, MouseEventArgs e)
      {
          // In the MouseDown event for the ListBox where the drag will begin, 
          // use the DoDragDrop method to set the data to be dragged 
          // and the allowed effect dragging will have.
          if (this.listBox1.SelectedItem != null)
          {
              this.listBox1.DoDragDrop(this.listBox1.SelectedItem, DragDropEffects.Copy);
          }
      }

</pre>
<pre id="codePreview" class="csharp">
      void listBox1_MouseDown(object sender, MouseEventArgs e)
      {
          // In the MouseDown event for the ListBox where the drag will begin, 
          // use the DoDragDrop method to set the data to be dragged 
          // and the allowed effect dragging will have.
          if (this.listBox1.SelectedItem != null)
          {
              this.listBox1.DoDragDrop(this.listBox1.SelectedItem, DragDropEffects.Copy);
          }
      }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">3. Handle the DragEnter event on the destination control to set the effect that will happen when the drop occurs.<span style="">&nbsp;
</span></span></p>
<p class="MsoNormal"><span style="">4. Handle the DragDrop event on the destination control to retrieve the
<span class="GramE">data<span style="">&nbsp; </span>dragged</span> from the source control.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
     void treeView1_DragDrop(object sender, DragEventArgs e)
     {
         // In the DragDrop event for the TreeView where the drop will occur, 
         // use the GetData method to retrieve the data being dragged.
         string item = (string)e.Data.GetData(e.Data.GetFormats()[0]);


         // Add the item strib
         this.treeView1.Nodes.Add(item);
     }

</pre>
<pre id="codePreview" class="csharp">
     void treeView1_DragDrop(object sender, DragEventArgs e)
     {
         // In the DragDrop event for the TreeView where the drop will occur, 
         // use the GetData method to retrieve the data being dragged.
         string item = (string)e.Data.GetData(e.Data.GetFormats()[0]);


         // Add the item strib
         this.treeView1.Nodes.Add(item);
     }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><span style="">Windows Forms General FAQ.<span style="">&nbsp;
</span></span></p>
<p class="MsoNormal"><span style=""><a href="http://social.msdn.microsoft.com/Forums/en-US/winforms/thread/77a66f05-804e-4d58-8214-0c32d8f43191"><span style="font-family:������">http://social.msdn.microsoft.com/Forums/en-US/winforms/thread/77a66f05-804e-4d58-8214-0c32d8f43191</span></a>
</span></p>
<p class="MsoNormal"><span style="">Performing Drag-and-Drop Operations in Windows Forms
</span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/aa984430(VS.71).aspx"><span style="font-family:������">http://msdn.microsoft.com/en-us/library/aa984430(VS.71).aspx</span></a></span>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
