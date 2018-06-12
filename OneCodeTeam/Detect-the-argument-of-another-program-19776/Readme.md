# Detect the argument of another program (VBDetectArgsOfAnotherProcess)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows SDK
## Topics
* process
## IsPublished
* True
## ModifiedDate
* 2012-12-03 07:58:33
## Description

<h1>How to detect arguments of another process (<span style="">VB</span>DetectArgsOfAnotherProcess)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This solution contains two projects:</p>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">VB</span>Process</p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">VB</span>DetectProcess</p>
<p class="MsoNormal"><span style="">VB</span>Process project is used to simulate a running process and the
<span style="">VB</span>DetectProcess is used to detect the CommandLine arguments of the running process.</p>
<h2>Building the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Right click the solution and build it.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Set &quot;<span style="">VB</span>Process&quot; as the startup project.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Right click &quot;VBProcess&quot; and click &quot;Properties&quot;.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Under &quot;Debug&quot; item, set arguments in &quot;Command line arguments&quot;.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press &quot;Ctrl&#43;F5&quot; to run &quot;VBProcess&quot;.</p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Right click &quot;<span style="">VB</span>DetectProcess&quot; project, click &quot;Start new instance&quot; under &quot;Debug&quot; item.</p>
<p class="MsoNormal" style="margin-left:.25in">NOTE: <span style="">Any running processes can be detected.</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">VB</span>Process:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/71685/1/image.png" alt="" width="677" height="150" align="middle">
</span></p>
<p class="MsoNormal"><span style="">VB</span>DetectProcess:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/71686/1/image.png" alt="" width="677" height="207" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">The code below demonstrates how to use WMI query to detect arguments of another running project.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Console.WriteLine(&quot;Please enter the process name: &quot;)
            Dim processName As String = Console.ReadLine()


            ' Create a WMI Query
            Dim wmiQuery As String = String.Format(&quot;select CommandLine from Win32_Process where Name='{0}'&quot;, processName)


            ' Create a ManagementObjectSearcher to retrieve a collection of management objects
            ' based on a specified query
            Using searcher As New ManagementObjectSearcher(wmiQuery)
                ' Get the query result
                Dim results As ManagementObjectCollection = searcher.Get()


                If results.Count &lt;&gt; 0 Then
                    ' Output the CommandLine property of the process
                    For Each result As ManagementObject In results
                        Dim CommandLine As String = result(&quot;CommandLine&quot;).ToString()
                        Console.WriteLine()
                        Console.WriteLine(&quot;The arguments of this process are:&quot; & vbLf & &quot; {0}&quot;, CommandLine)
                    Next
                    Console.WriteLine()
                    Console.WriteLine(&quot;Press any key to continue, press 'Q' to exit.&quot;)
                    Console.WriteLine()
                Else
                    Console.WriteLine()
                    Console.WriteLine(&quot;This process couldn't be found. Press any key to continue, press 'Q' to exit.&quot;)
                    Console.WriteLine()
                End If
            End Using

</pre>
<pre id="codePreview" class="vb">
Console.WriteLine(&quot;Please enter the process name: &quot;)
            Dim processName As String = Console.ReadLine()


            ' Create a WMI Query
            Dim wmiQuery As String = String.Format(&quot;select CommandLine from Win32_Process where Name='{0}'&quot;, processName)


            ' Create a ManagementObjectSearcher to retrieve a collection of management objects
            ' based on a specified query
            Using searcher As New ManagementObjectSearcher(wmiQuery)
                ' Get the query result
                Dim results As ManagementObjectCollection = searcher.Get()


                If results.Count &lt;&gt; 0 Then
                    ' Output the CommandLine property of the process
                    For Each result As ManagementObject In results
                        Dim CommandLine As String = result(&quot;CommandLine&quot;).ToString()
                        Console.WriteLine()
                        Console.WriteLine(&quot;The arguments of this process are:&quot; & vbLf & &quot; {0}&quot;, CommandLine)
                    Next
                    Console.WriteLine()
                    Console.WriteLine(&quot;Press any key to continue, press 'Q' to exit.&quot;)
                    Console.WriteLine()
                Else
                    Console.WriteLine()
                    Console.WriteLine(&quot;This process couldn't be found. Press any key to continue, press 'Q' to exit.&quot;)
                    Console.WriteLine()
                End If
            End Using

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/ms186146(v=vs.80).aspx">WMI Queries</a></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/system.management.managementobjectsearcher.aspx">ManagementObjectSearcher Class</a></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/system.management.managementobject.aspx">ManagementObject Class</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
