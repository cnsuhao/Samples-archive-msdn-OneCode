# Thread synchronization via Threading.Monitor (CSThreadingMonitor)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* .NET Framework
## Topics
* threading
## IsPublished
* True
## ModifiedDate
* 2012-08-22 04:10:32
## Description

<h1><span style="font-family:新宋体">Console Application</span> (<span style="font-family:新宋体">CSThreadingMonitor</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">This </span>example shows how synchronization can be accomplished using the C# lock keyword and the Pulse method of the Monitor object. The Pulse method<span style="">
</span>notifies a thread in the waiting queue of a change in the object's state (for more details on pulses, see the
<a href="http://msdn.microsoft.com/en-us/library/system.threading.monitor.pulse(VS.71).aspx">
Monitor.Pulse Method</a> <span style="">) </span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style=""><img src="/site/view/file/65160/1/image.png" alt="" width="576" height="651" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">The example creates a Cell object that has two methods: ReadFromCell and WriteToCell. Two other objects are created from classes CellProd and<span style="">
</span>CellCons; these objects both have a method ThreadRun whose job is to call ReadFromCell and WriteToCell. Synchronization is accomplished by waiting for<span style="">
</span>&quot;pulses&quot; from the Monitor object, which come in order. That is, first an item is produced (the consumer at this point is waiting for a pulse), then<span style="">
</span>a pulse occurs, then the consumer consumes the production (while the producer<span style="">
</span>is waiting for a pulse), and so on.<span style=""> </span></p>
<p class="MsoNormal"><b style=""><span style="">Cell Class </span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public class Cell
   {
       int cellContents;         // Cell contents
       bool readerFlag = false;  // State flag
       public int ReadFromCell()
       {
           lock (this)   // Enter synchronization block
           {
               if (!readerFlag)
               {            // Wait until Cell.WriteToCell is done producing
                   try
                   {
                       // Waits for the Monitor.Pulse in WriteToCell
                       Monitor.Wait(this);
                   }
                   catch (SynchronizationLockException e)
                   {
                       Console.WriteLine(e);
                   }
                   catch (ThreadInterruptedException e)
                   {
                       Console.WriteLine(e);
                   }
               }
               Console.WriteLine(&quot;Consume: {0}&quot;, cellContents);
               readerFlag = false;    // Reset the state flag to say consuming
               // is done.
               Monitor.Pulse(this);   // Pulse tells Cell.WriteToCell that
               // Cell.ReadFromCell is done.
           }   // Exit synchronization block
           return cellContents;
       }


       public void WriteToCell(int n)
       {
           lock (this)  // Enter synchronization block
           {
               if (readerFlag)
               {      // Wait until Cell.ReadFromCell is done consuming.
                   try
                   {
                       Monitor.Wait(this);   // Wait for the Monitor.Pulse in
                       // ReadFromCell
                   }
                   catch (SynchronizationLockException e)
                   {
                       Console.WriteLine(e);
                   }
                   catch (ThreadInterruptedException e)
                   {
                       Console.WriteLine(e);
                   }
               }
               cellContents = n;
               Console.WriteLine(&quot;Produce: {0}&quot;, cellContents);
               readerFlag = true;    // Reset the state flag to say producing
               // is done
               Monitor.Pulse(this);  // Pulse tells Cell.ReadFromCell that 
               // Cell.WriteToCell is done.
           }   // Exit synchronization block
       }
   }

</pre>
<pre id="codePreview" class="csharp">
public class Cell
   {
       int cellContents;         // Cell contents
       bool readerFlag = false;  // State flag
       public int ReadFromCell()
       {
           lock (this)   // Enter synchronization block
           {
               if (!readerFlag)
               {            // Wait until Cell.WriteToCell is done producing
                   try
                   {
                       // Waits for the Monitor.Pulse in WriteToCell
                       Monitor.Wait(this);
                   }
                   catch (SynchronizationLockException e)
                   {
                       Console.WriteLine(e);
                   }
                   catch (ThreadInterruptedException e)
                   {
                       Console.WriteLine(e);
                   }
               }
               Console.WriteLine(&quot;Consume: {0}&quot;, cellContents);
               readerFlag = false;    // Reset the state flag to say consuming
               // is done.
               Monitor.Pulse(this);   // Pulse tells Cell.WriteToCell that
               // Cell.ReadFromCell is done.
           }   // Exit synchronization block
           return cellContents;
       }


       public void WriteToCell(int n)
       {
           lock (this)  // Enter synchronization block
           {
               if (readerFlag)
               {      // Wait until Cell.ReadFromCell is done consuming.
                   try
                   {
                       Monitor.Wait(this);   // Wait for the Monitor.Pulse in
                       // ReadFromCell
                   }
                   catch (SynchronizationLockException e)
                   {
                       Console.WriteLine(e);
                   }
                   catch (ThreadInterruptedException e)
                   {
                       Console.WriteLine(e);
                   }
               }
               cellContents = n;
               Console.WriteLine(&quot;Produce: {0}&quot;, cellContents);
               readerFlag = true;    // Reset the state flag to say producing
               // is done
               Monitor.Pulse(this);  // Pulse tells Cell.ReadFromCell that 
               // Cell.WriteToCell is done.
           }   // Exit synchronization block
       }
   }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><b style=""><span style="">Cell Prod Class </span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public class CellProd
   {
       Cell cell;         // Field to hold cell object to be used
       int quantity = 1;  // Field for how many items to produce in cell


       public CellProd(Cell box, int request)
       {
           cell = box;          // Pass in what cell object to be used
           quantity = request;  // Pass in how many items to produce in cell
       }
       public void ThreadRun()
       {
           for (int looper = 1; looper &lt;= quantity; looper&#43;&#43;)
               cell.WriteToCell(looper);  // &quot;producing&quot;
       }
   }

</pre>
<pre id="codePreview" class="csharp">
public class CellProd
   {
       Cell cell;         // Field to hold cell object to be used
       int quantity = 1;  // Field for how many items to produce in cell


       public CellProd(Cell box, int request)
       {
           cell = box;          // Pass in what cell object to be used
           quantity = request;  // Pass in how many items to produce in cell
       }
       public void ThreadRun()
       {
           for (int looper = 1; looper &lt;= quantity; looper&#43;&#43;)
               cell.WriteToCell(looper);  // &quot;producing&quot;
       }
   }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><b style=""><span style="">Cell Cons Class </span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public class CellCons
   {
       Cell cell;         // Field to hold cell object to be used
       int quantity = 1;  // Field for how many items to consume from cell


       public CellCons(Cell box, int request)
       {
           cell = box;          // Pass in what cell object to be used
           quantity = request;  // Pass in how many items to consume from cell
       }
       public void ThreadRun()
       {
           int valReturned;
           for (int looper = 1; looper &lt;= quantity; looper&#43;&#43;)
               // Consume the result by placing it in valReturned.
               valReturned = cell.ReadFromCell();
       }
   }

</pre>
<pre id="codePreview" class="csharp">
public class CellCons
   {
       Cell cell;         // Field to hold cell object to be used
       int quantity = 1;  // Field for how many items to consume from cell


       public CellCons(Cell box, int request)
       {
           cell = box;          // Pass in what cell object to be used
           quantity = request;  // Pass in how many items to consume from cell
       }
       public void ThreadRun()
       {
           int valReturned;
           for (int looper = 1; looper &lt;= quantity; looper&#43;&#43;)
               // Consume the result by placing it in valReturned.
               valReturned = cell.ReadFromCell();
       }
   }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h2>More Information</h2>
<p class="MsoListParagraph" style="margin-bottom:0cm; margin-bottom:.0001pt; text-indent:5.0pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:新宋体"><a href="http://msdn.microsoft.com/en-us/library/system.threading.monitor.pulse.aspx">Monitor Pulse</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
