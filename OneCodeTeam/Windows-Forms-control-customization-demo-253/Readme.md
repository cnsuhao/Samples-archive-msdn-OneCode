# Windows Forms control customization demo (CSWinFormControls)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* Windows Forms
## Topics
* Controls
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:41:58
## Description

<h1>WINDOWS FORMS APPLICATION (CSWinFormControls)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The Control Customization sample demonstrates how to customize the Windows Forms controls.</p>
<p class="MsoNormal">In this sample, there're 4 examples: </p>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Multiple Column ComboBox.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>ListBox Items With Different ToolTips.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Numeric-only TextBox.</p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>A Round Button.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">1. Multiple Column ComboBox.</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>Demonstrates how to display multiple columns of data in the dropdown of a ComboBox<span style="">
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53217/1/image.png" alt="" width="576" height="391" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal">2. ListBox Items With Different ToolTips.</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>Demonstrates how to display different tooltips on each items of the ListBox<span style="">
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53218/1/image.png" alt="" width="576" height="391" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal">3. Numeric-only TextBox.</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>Demonstrates how to make a TextBox only accepts numbers<span style="">
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53219/1/image.png" alt="" width="576" height="391" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal">4. A Round Button.</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>Demonstrates how to create a Button with irregular shape<span style="">
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53220/1/image.png" alt="" width="576" height="393" align="middle">
</span><span style=""></span></p>
<h2><span style="">Using the code </span></h2>
<p class="MsoNormal"><span style="">1. Example 1: &quot;Multiple Column ComboBox&quot;.
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>1). Create a DataTable with several columns and rows of data;
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>2). Data bind the ComboBox control to the DataTable;
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>3). Enable the owner draw on ComboBox by setting the DrawMode property to DrawMode.OwnerDrawFixed;
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>4). Handle the DrawItem event on the ComboBox;
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>5). In the DrawItem event handler, compute the bounds for each column and draw corresponding value for each column on its bounds.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
             //  DataSource setup:
           //  
           //  Create a Table named Test and add 2 columns
           //   ID:     int
           //   Name:   string
           //
           DataTable dtTest = new DataTable();
           dtTest.Columns.Add(&quot;ID&quot;, typeof(int));
           dtTest.Columns.Add(&quot;Name&quot;, typeof(string));


           dtTest.Rows.Add(1, &quot;John&quot;);
           dtTest.Rows.Add(2, &quot;Amy&quot;);
           dtTest.Rows.Add(3, &quot;Tony&quot;);
           dtTest.Rows.Add(4, &quot;Bruce&quot;);
           dtTest.Rows.Add(5, &quot;Allen&quot;);


           // Bind the ComboBox to the DataTable
           this.comboBox1.DataSource = dtTest;
           this.comboBox1.DisplayMember = &quot;Name&quot;;
           this.comboBox1.ValueMember = &quot;ID&quot;;


           // Enable the owner draw on the ComboBox.
           this.comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
           // Handle the DrawItem event to draw the items.
           this.comboBox1.DrawItem &#43;= delegate(object cmb, DrawItemEventArgs args)
           {
               // Draw the default background
               args.DrawBackground();




               // The ComboBox is bound to a DataTable,
               // so the items are DataRowView objects.
               DataRowView drv = (DataRowView)this.comboBox1.Items[args.Index];


               // Retrieve the value of each column.
               string id = drv[&quot;id&quot;].ToString();
               string name = drv[&quot;name&quot;].ToString();


               // Get the bounds for the first column
               Rectangle r1 = args.Bounds;
               r1.Width /= 2;


               // Draw the text on the first column
               using (SolidBrush sb = new SolidBrush(args.ForeColor))
               {
                   args.Graphics.DrawString(id, args.Font, sb, r1);
               }


               // Draw a line to isolate the columns 
               using (Pen p = new Pen(Color.Black))
               {
                   args.Graphics.DrawLine(p, r1.Right, 0, r1.Right, r1.Bottom);
               }


               // Get the bounds for the second column
               Rectangle r2 = args.Bounds;
               r2.X = args.Bounds.Width/2;
               r2.Width /= 2;


               // Draw the text on the second column
               using (SolidBrush sb = new SolidBrush(args.ForeColor))
               {
                   args.Graphics.DrawString(name, args.Font, sb, r2);
               }
           };

</pre>
<pre id="codePreview" class="csharp">
             //  DataSource setup:
           //  
           //  Create a Table named Test and add 2 columns
           //   ID:     int
           //   Name:   string
           //
           DataTable dtTest = new DataTable();
           dtTest.Columns.Add(&quot;ID&quot;, typeof(int));
           dtTest.Columns.Add(&quot;Name&quot;, typeof(string));


           dtTest.Rows.Add(1, &quot;John&quot;);
           dtTest.Rows.Add(2, &quot;Amy&quot;);
           dtTest.Rows.Add(3, &quot;Tony&quot;);
           dtTest.Rows.Add(4, &quot;Bruce&quot;);
           dtTest.Rows.Add(5, &quot;Allen&quot;);


           // Bind the ComboBox to the DataTable
           this.comboBox1.DataSource = dtTest;
           this.comboBox1.DisplayMember = &quot;Name&quot;;
           this.comboBox1.ValueMember = &quot;ID&quot;;


           // Enable the owner draw on the ComboBox.
           this.comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
           // Handle the DrawItem event to draw the items.
           this.comboBox1.DrawItem &#43;= delegate(object cmb, DrawItemEventArgs args)
           {
               // Draw the default background
               args.DrawBackground();




               // The ComboBox is bound to a DataTable,
               // so the items are DataRowView objects.
               DataRowView drv = (DataRowView)this.comboBox1.Items[args.Index];


               // Retrieve the value of each column.
               string id = drv[&quot;id&quot;].ToString();
               string name = drv[&quot;name&quot;].ToString();


               // Get the bounds for the first column
               Rectangle r1 = args.Bounds;
               r1.Width /= 2;


               // Draw the text on the first column
               using (SolidBrush sb = new SolidBrush(args.ForeColor))
               {
                   args.Graphics.DrawString(id, args.Font, sb, r1);
               }


               // Draw a line to isolate the columns 
               using (Pen p = new Pen(Color.Black))
               {
                   args.Graphics.DrawLine(p, r1.Right, 0, r1.Right, r1.Bottom);
               }


               // Get the bounds for the second column
               Rectangle r2 = args.Bounds;
               r2.X = args.Bounds.Width/2;
               r2.Width /= 2;


               // Draw the text on the second column
               using (SolidBrush sb = new SolidBrush(args.ForeColor))
               {
                   args.Graphics.DrawString(name, args.Font, sb, r2);
               }
           };

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><span style="">2. Example 2: &quot;ListBox Items With Different ToolTips&quot;.
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>1). Add some items to the ListBox control;
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>2). Handle the MouseMove event on the ListBox control;
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>3). Call the ListBox.IndexFromPoint method to retrieve the item index at where the mouse hovers;
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>4). If the mouse is over the items, call ToolTip.SetToolTip method to display a tooltip for the individual item.<span style="">&nbsp;&nbsp;
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
           // Setup the ListBox items
           this.listBox1.Items.Add(&quot;Item1&quot;);
           this.listBox1.Items.Add(&quot;Item2&quot;);
           this.listBox1.Items.Add(&quot;Item3&quot;);
           this.listBox1.Items.Add(&quot;Item4&quot;);
           this.listBox1.Items.Add(&quot;Item5&quot;);


           this.listBox1.MouseMove &#43;= delegate(object lst, MouseEventArgs args)
           {
               // Retrieve the item index at where the mouse hovers
               int hoverIndex = this.listBox1.IndexFromPoint(args.Location);


               // If the mouse is over the items, display a tooltip
               if (hoverIndex &gt;= 0 && hoverIndex &lt; listBox1.Items.Count)
               {
                   this.toolTip1.SetToolTip(listBox1, listBox1.Items[hoverIndex].ToString());
               }
           };

</pre>
<pre id="codePreview" class="csharp">
           // Setup the ListBox items
           this.listBox1.Items.Add(&quot;Item1&quot;);
           this.listBox1.Items.Add(&quot;Item2&quot;);
           this.listBox1.Items.Add(&quot;Item3&quot;);
           this.listBox1.Items.Add(&quot;Item4&quot;);
           this.listBox1.Items.Add(&quot;Item5&quot;);


           this.listBox1.MouseMove &#43;= delegate(object lst, MouseEventArgs args)
           {
               // Retrieve the item index at where the mouse hovers
               int hoverIndex = this.listBox1.IndexFromPoint(args.Location);


               // If the mouse is over the items, display a tooltip
               if (hoverIndex &gt;= 0 && hoverIndex &lt; listBox1.Items.Count)
               {
                   this.toolTip1.SetToolTip(listBox1, listBox1.Items[hoverIndex].ToString());
               }
           };

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><span style="">3. Example 3: &quot;Numeric-only TextBox&quot;.
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>The make a TextBox accepts only numbers, we can handle the TextBox.KeyPress event, in the event handler use char.IsNumber method to filter the input keys.<span style="">&nbsp;
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
           // Handle the TextBox.KeyPress event to filter the input characters.
           this.textBox1.KeyPress &#43;= delegate(object tb, KeyPressEventArgs args)
           {
               if (!(char.IsNumber(args.KeyChar) || args.KeyChar == '\b'))
               {
                   // If the input character is not number or Backspace key
                   // Then set the Handled property to true to indicate that 
                   // the KeyPress event is handled, so that the TextBox just 
                   // bypass the input character.
                   args.Handled = true;
               }
           };

</pre>
<pre id="codePreview" class="csharp">
           // Handle the TextBox.KeyPress event to filter the input characters.
           this.textBox1.KeyPress &#43;= delegate(object tb, KeyPressEventArgs args)
           {
               if (!(char.IsNumber(args.KeyChar) || args.KeyChar == '\b'))
               {
                   // If the input character is not number or Backspace key
                   // Then set the Handled property to true to indicate that 
                   // the KeyPress event is handled, so that the TextBox just 
                   // bypass the input character.
                   args.Handled = true;
               }
           };

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><span style="">4. Example 4: &quot;A Round Button&quot;. </span>
</p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>The key point of creating a round button is changing its Region property.<span style="">&nbsp;&nbsp;
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
  public class RoundButton : Button
  {
      protected override void OnPaint(PaintEventArgs pevent)
      {
          // Change the region for the button so that when clicks outside the ellipse bounds,
          // the Click event won't fire.
          GraphicsPath path = new GraphicsPath();
          path.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
          this.Region = new Region(path);


          base.OnPaint(pevent);
      }
  }

</pre>
<pre id="codePreview" class="csharp">
  public class RoundButton : Button
  {
      protected override void OnPaint(PaintEventArgs pevent)
      {
          // Change the region for the button so that when clicks outside the ellipse bounds,
          // the Click event won't fire.
          GraphicsPath path = new GraphicsPath();
          path.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
          this.Region = new Region(path);


          base.OnPaint(pevent);
      }
  }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style=""><a href="http://social.msdn.microsoft.com/Forums/en-US/winforms/thread/77a66f05-804e-4d58-8214-0c32d8f43191">Windows Forms General FAQ.</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style=""><a href="http://msdn.microsoft.com/en-us/library/aa289517.aspx">Shaped Windows Forms and Controls in Visual Studio .NET</a>
</span></p>
<p class="MsoListParagraphCxSpLast" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style=""><a href="http://www.codeproject.com/KB/buttons/RoundButton_csharp.aspx">Round Button in C#</a>
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
