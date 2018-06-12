# Thread synchronization via Threading.Monitor (VBThreadingMonitor)
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
* 2012-08-22 04:10:03
## Description

<h1><span style="font-family:新宋体">Console Application</span> (<span style="font-family:新宋体">VBThreadingMonitor</span>)</h1>
<h2>Introduction</h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">The following example shows how synchronization can be accomplished using the VB SyncLock keyword and the Pulse method of the Monitor object. The Pulse
 method notifies a thread in the waiting queue of a change in the object's state (for more details on pulses, see the
<a href="http://msdn.microsoft.com/en-us/library/system.threading.monitor.pulse(VS.71).aspx">
Monitor.Pulse Method</a>). </span></h2>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style=""><img src="/site/view/file/65157/1/image.png" alt="" width="576" height="651" align="middle">
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
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Class Cell
       Public Function ReadFromCell() As Integer
           SyncLock Me
               If Not Me.readerFlag Then
                   Try
                       Monitor.Wait(Me)
                   Catch e As SynchronizationLockException
                       Console.WriteLine(e)
                   Catch e As ThreadInterruptedException
                       Console.WriteLine(e)
                   End Try
               End If
               Console.WriteLine(&quot;Consume: {0}&quot;, Me.cellContents)
               Me.readerFlag = False
               Monitor.Pulse(Me)
           End SyncLock
           Return Me.cellContents
       End Function


       Public Sub WriteToCell(ByVal n As Integer)
           SyncLock Me
               If Me.readerFlag Then
                   Try
                       Monitor.Wait(Me)
                   Catch e As SynchronizationLockException
                       Console.WriteLine(e)
                   Catch e As ThreadInterruptedException
                       Console.WriteLine(e)
                   End Try
               End If
               Me.cellContents = n
               Console.WriteLine(&quot;Produce: {0}&quot;, Me.cellContents)
               Me.readerFlag = True
               Monitor.Pulse(Me)
           End SyncLock
       End Sub




       ' Fields
       Private cellContents As Integer
       Private readerFlag As Boolean = False
   End Class

</pre>
<pre id="codePreview" class="vb">
Public Class Cell
       Public Function ReadFromCell() As Integer
           SyncLock Me
               If Not Me.readerFlag Then
                   Try
                       Monitor.Wait(Me)
                   Catch e As SynchronizationLockException
                       Console.WriteLine(e)
                   Catch e As ThreadInterruptedException
                       Console.WriteLine(e)
                   End Try
               End If
               Console.WriteLine(&quot;Consume: {0}&quot;, Me.cellContents)
               Me.readerFlag = False
               Monitor.Pulse(Me)
           End SyncLock
           Return Me.cellContents
       End Function


       Public Sub WriteToCell(ByVal n As Integer)
           SyncLock Me
               If Me.readerFlag Then
                   Try
                       Monitor.Wait(Me)
                   Catch e As SynchronizationLockException
                       Console.WriteLine(e)
                   Catch e As ThreadInterruptedException
                       Console.WriteLine(e)
                   End Try
               End If
               Me.cellContents = n
               Console.WriteLine(&quot;Produce: {0}&quot;, Me.cellContents)
               Me.readerFlag = True
               Monitor.Pulse(Me)
           End SyncLock
       End Sub




       ' Fields
       Private cellContents As Integer
       Private readerFlag As Boolean = False
   End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><b style=""><span style="">Cell Prod Class </span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Class CellProd
       ' Methods
       Public Sub New(ByVal box As Cell, ByVal request As Integer)
           Me.cell = box
           Me.quantity = request
       End Sub


       Public Sub ThreadRun()
           Dim looper As Integer = 1
           Do While (looper &lt;= Me.quantity)
               Me.cell.WriteToCell(looper)
               looper &#43;= 1
           Loop
       End Sub




       ' Fields
       Private cell As Cell
       Private quantity As Integer = 1
   End Class

</pre>
<pre id="codePreview" class="vb">
Public Class CellProd
       ' Methods
       Public Sub New(ByVal box As Cell, ByVal request As Integer)
           Me.cell = box
           Me.quantity = request
       End Sub


       Public Sub ThreadRun()
           Dim looper As Integer = 1
           Do While (looper &lt;= Me.quantity)
               Me.cell.WriteToCell(looper)
               looper &#43;= 1
           Loop
       End Sub




       ' Fields
       Private cell As Cell
       Private quantity As Integer = 1
   End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><b style=""><span style=""></span></b></p>
<p class="MsoNormal"><b style=""><span style="">Cell Cons Class </span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Class CellCons
        ' Methods
        Public Sub New(ByVal box As Cell, ByVal request As Integer)
            Me.cell = box
            Me.quantity = request
        End Sub


        Public Sub ThreadRun()
            Dim looper As Integer = 1
            Do While (looper &lt;= Me.quantity)
                Dim valReturned As Integer = Me.cell.ReadFromCell
                looper &#43;= 1
            Loop
        End Sub




        ' Fields
        Private cell As Cell
        Private quantity As Integer = 1
    End Class

</pre>
<pre id="codePreview" class="vb">
Public Class CellCons
        ' Methods
        Public Sub New(ByVal box As Cell, ByVal request As Integer)
            Me.cell = box
            Me.quantity = request
        End Sub


        Public Sub ThreadRun()
            Dim looper As Integer = 1
            Do While (looper &lt;= Me.quantity)
                Dim valReturned As Integer = Me.cell.ReadFromCell
                looper &#43;= 1
            Loop
        End Sub




        ' Fields
        Private cell As Cell
        Private quantity As Integer = 1
    End Class

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
