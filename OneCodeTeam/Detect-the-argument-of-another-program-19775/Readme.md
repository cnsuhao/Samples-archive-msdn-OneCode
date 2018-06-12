# Detect the argument of another program (CSDetectArgsOfAnotherProcess)
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
* 2012-12-03 07:58:48
## Description

<h1>How to detect arguments of another process (CSDetectArgsOfAnotherProcess)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This solution contains two projects: </p>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE">CSProcess</span> </p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE">CSDetectProcess</span>. </p>
<p class="MsoNormal"><span class="SpellE">CSProcess</span> project is used to simulate a running process and the CSDetectProcess is used to detect the CommandLine arguments of the running process.</p>
<h2>Building the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Right click the solution and build it.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Set &quot;CSProcess&quot; as the startup project.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Right click &quot;CSProcess&quot; and click &quot;Properties&quot;.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Under &quot;Debug&quot; item, set arguments in &quot;Command line arguments&quot;.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press &quot;Ctrl&#43;F5&quot; to run &quot;CSProcess&quot;.</p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Right click &quot;CSDetectProcess&quot; project, click &quot;Start new instance&quot; under &quot;Debug&quot; item.</p>
<p class="MsoNormal" style="margin-left:.25in">NOTE: Any running processes can be detected.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">CSProcess:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/71688/1/image.png" alt="" width="677" height="150" align="middle">
</span></p>
<p class="MsoNormal"><span class="SpellE">CSDetectProcess</span>:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/71689/1/image.png" alt="" width="675" height="201" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">The code below demonstrates how to use WMI query to detect arguments of another running project.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
Console.WriteLine(&quot;Please enter the process name: &quot;);
                string processName = Console.ReadLine();


                // Create a WMI Query
                string wmiQuery = string.Format(&quot;select CommandLine from Win32_Process where Name='{0}'&quot;, processName);


                // Create a ManagementObjectSearcher to retrieve a collection of management objects
                // based on a specified query
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiQuery))
                {
                    // Get the query result
                    ManagementObjectCollection results = searcher.Get();


                    if (results.Count != 0)
                    {
                        // Output the CommandLine property of the process
                        foreach (ManagementObject result in results)
                        {
                            string CommandLine = result[&quot;CommandLine&quot;].ToString();
                            Console.WriteLine();
                            Console.WriteLine(&quot;The arguments of this process are:\n {0}&quot;, CommandLine);
                        }
                        Console.WriteLine();
                        Console.WriteLine(&quot;Press any key to continue, press 'Q' to exit.&quot;);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine(&quot;This process couldn't be found. Press any key to continue, press 'Q' to exit.&quot;);
                        Console.WriteLine();
                    }
                }

</pre>
<pre id="codePreview" class="csharp">
Console.WriteLine(&quot;Please enter the process name: &quot;);
                string processName = Console.ReadLine();


                // Create a WMI Query
                string wmiQuery = string.Format(&quot;select CommandLine from Win32_Process where Name='{0}'&quot;, processName);


                // Create a ManagementObjectSearcher to retrieve a collection of management objects
                // based on a specified query
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiQuery))
                {
                    // Get the query result
                    ManagementObjectCollection results = searcher.Get();


                    if (results.Count != 0)
                    {
                        // Output the CommandLine property of the process
                        foreach (ManagementObject result in results)
                        {
                            string CommandLine = result[&quot;CommandLine&quot;].ToString();
                            Console.WriteLine();
                            Console.WriteLine(&quot;The arguments of this process are:\n {0}&quot;, CommandLine);
                        }
                        Console.WriteLine();
                        Console.WriteLine(&quot;Press any key to continue, press 'Q' to exit.&quot;);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine(&quot;This process couldn't be found. Press any key to continue, press 'Q' to exit.&quot;);
                        Console.WriteLine();
                    }
                }

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
