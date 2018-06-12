# Printing in Windows Forms (CSWinFormPrinting)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* Windows Forms
## Topics
* Printing
## IsPublished
* True
## ModifiedDate
* 2012-07-22 07:00:13
## Description

<h1><span style="font-family:新宋体">WINDOWS FORMS APPLICATION</span> (<span style="font-family:新宋体">CSWinFormPrinting</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This Printing sample demonstrates how to create a standard print job in a Windows Forms application.<span style=""> The foundation of printing in Windows Forms is the
<span class="SpellE">PrintDocument</span> component — more specifically, the <span class="SpellE">
PrintPage</span> event. By writing code to handle this event, you can specify what to print and how to print it.</span>
<span style="">You may also want to write code for the <span class="SpellE">BeginPrint</span> and
<span class="SpellE">EndPrint</span> events, perhaps including an integer representing the total number of pages to print that is decremented as each page prints.</span>
<span style=""></span></p>
<p class="MsoNormal"><span style="">Note: You can add a <span class="SpellE">
PrintDialog</span> component to your form to provide a clean and efficient user interface to your users. Setting the Document property of the
<span class="SpellE">PrintDialog</span> component allows you to set properties related to the print document you are working with on your form. For more information about the
<span class="SpellE">PrintDialog</span> component, see <span class="SpellE">PrintDialog</span> Component</span>.<span style="">
<span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span></span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style=""><img src="/site/view/file/61559/1/image.png" alt="" width="720" height="486" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/61560/1/image.png" alt="" width="720" height="630" align="middle">
</span>. </p>
<h2>Using the Code</h2>
<p class="MsoListParagraphCxSpFirst" style="margin-left:24.75pt; text-indent:5.0pt">
<span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Add a <span class="SpellE">PrintDocument</span> component named &quot;printDocument1&quot;, a
<span class="SpellE">PrintPreviewDialog</span> <span class="GramE">component<span style="">&nbsp;
</span>named</span> &quot;printPreviewDialog1&quot;, and a button control named&quot;</span>
<span class="SpellE"><span style="">btnPrint</span></span><span style="">&quot; from Toolbox to your main form.
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:24.75pt; text-indent:5.0pt">
<span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Right-click your form and choose View Code. In the main
<span class="GramE">form's<span style="">&nbsp; </span><span class="SpellE">frmPrinting</span></span><span class="SpellE">_Load</span> event handler code initial the</span><span style="color:black"> printDocument1</span><span style=""> and
</span><span style="color:black">printPreviewDialog1</span><span style="">. </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
      private void frmPrinting_Load(object sender, EventArgs e)
      {
          // The example assumes your form has a Button control, 
          // a PrintDocument component named myDocument, 
          // and a PrintPreviewDialog control. 


          // Handle the PrintPage event to write the print logic.
          this.printDocument1.PrintPage &#43;= 
              new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);


          // Specify a PrintDocument instance for the PrintPreviewDialog component.
          this.printPreviewDialog1.Document = this.printDocument1;
      }

</pre>
<pre id="codePreview" class="csharp">
      private void frmPrinting_Load(object sender, EventArgs e)
      {
          // The example assumes your form has a Button control, 
          // a PrintDocument component named myDocument, 
          // and a PrintPreviewDialog control. 


          // Handle the PrintPage event to write the print logic.
          this.printDocument1.PrintPage &#43;= 
              new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);


          // Specify a PrintDocument instance for the PrintPreviewDialog component.
          this.printPreviewDialog1.Document = this.printDocument1;
      }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:24.75pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:24.75pt; text-indent:5.0pt">
<span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Write code to handle the PrintPage event and show the printPreviewDialog.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
      void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
      {
          // Specify what to print and how to print in this event handler.
          // The follow code specify a string and a rectangle to be print 


          using (Font f = new Font(&quot;Vanada&quot;, 12))
          using (SolidBrush br = new SolidBrush(Color.Black))
          using (Pen p = new Pen(Color.Black)) 
          {
              e.Graphics.DrawString(&quot;This is a text.&quot;, f, br, 50, 50);


              e.Graphics.DrawRectangle(p, 50, 100, 300, 150);
          }
      }


      private void btnPrint_Click(object sender, EventArgs e)
      {
          this.printPreviewDialog1.ShowDialog();
      }

</pre>
<pre id="codePreview" class="csharp">
      void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
      {
          // Specify what to print and how to print in this event handler.
          // The follow code specify a string and a rectangle to be print 


          using (Font f = new Font(&quot;Vanada&quot;, 12))
          using (SolidBrush br = new SolidBrush(Color.Black))
          using (Pen p = new Pen(Color.Black)) 
          {
              e.Graphics.DrawString(&quot;This is a text.&quot;, f, br, 50, 50);


              e.Graphics.DrawRectangle(p, 50, 100, 300, 150);
          }
      }


      private void btnPrint_Click(object sender, EventArgs e)
      {
          this.printPreviewDialog1.ShowDialog();
      }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal" style="margin-left:18.0pt"><span class="GramE">Creating Standard Windows Forms Print Jobs<span style="">.</span></span><span style="">&nbsp;
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-left:18.0pt"><span style=""><a href="http://msdn.microsoft.com/en-us/library/aa984337(VS.71).aspx">http://msdn.microsoft.com/en-us/library/aa984337(VS.71).aspx</a>
</span></p>
<p class="MsoNormal" style="margin-left:18.0pt"><span class="GramE">Windows Forms General FAQ.</span><span style="">
</span></p>
<p class="MsoNormal" style="margin-left:18.0pt"><span style=""><a href="http://social.msdn.microsoft.com/Forums/en-US/winforms/thread/77a66f05-804e-4d58-8214-0c32d8f43191">http://social.msdn.microsoft.com/Forums/en-US/winforms/thread/77a66f05-804e-4d58-8214-0c32d8f43191</a>
</span></p>
<p class="MsoNormal" style="margin-left:18.0pt"><span class="SpellE"><span style="">PrintPageEventArgs</span></span><span style=""> Class
</span></p>
<p class="MsoNormal" style="margin-left:18.0pt"><span style=""><a href="http://msdn.microsoft.com/en-us/library/system.drawing.printing.printpageeventargs(v=vs.71).aspx">http://msdn.microsoft.com/en-us/library/system.drawing.printing.printpageeventargs(v=vs.71).aspx</a>
</span></p>
<p class="MsoNormal" style="margin-left:18.0pt"><span class="SpellE"><span style="">PrintDocument</span></span><span style=""> Component (Windows Forms)
</span></p>
<p class="MsoNormal" style="margin-left:18.0pt"><span style=""><a href="http://msdn.microsoft.com/en-us/library/aa984152(v=vs.71).aspx">http://msdn.microsoft.com/en-us/library/aa984152(v=vs.71).aspx</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
