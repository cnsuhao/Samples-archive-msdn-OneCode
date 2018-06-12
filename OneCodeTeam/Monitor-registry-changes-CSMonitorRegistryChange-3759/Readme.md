# Monitor registry changes (CSMonitorRegistryChange)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* Windows Base
## Topics
* Registry Monitor
## IsPublished
* True
## ModifiedDate
* 2012-09-27 10:17:14
## Description

<h1>How to monitor the registry key change event using WMI event (<span class="SpellE">CSMonitorRegistryChange</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The sample demonstrates how to monitor the registry key change event using WMI event.<span style="">
</span>The change event will be raised when one of the following operations happened.
</p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Rename or delete the key.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Add, rename or delete a sub key under the key.</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Add, rename, edit or delete a value of the key.</p>
<p class="MsoNormal">This WMI event does not return the changed value and type. It just tells that there is a change. The properties that you can get from the event are Hive,
<span class="SpellE">KeyPath</span>, SECURITY_DESCRIPTOR and TIME_CREATED.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Step1. Build the sample project in Visual Studio 20<span style="">12</span>.</p>
<p class="MsoNormal">Step2. Select a hive &quot;HKEY_LOCAL_MACHINE&quot; in the
<span class="SpellE">comboBox</span>, and then type the key path &quot;SOFTWARE\\Microsoft&quot; in the textbox.</p>
<p class="MsoNormal">Notice that you have to use double slash &quot;\\&quot; in the registry path.
</p>
<p class="MsoNormal">Step3. Click button &quot;Start Monitor&quot;.</p>
<p class="MsoNormal">Step4. Run &quot;<span class="SpellE">Regedit</span>&quot; in run command to open Registry Editor.</p>
<p class="MsoNormal">Step5. Navigate to HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft in Registry Editor. Right click the key and create a new key. You'll see a new item &quot;The key HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft changed&quot; in the list box.</p>
<h2>Using the Code</h2>
<p class="MsoNormal">First, initialize the <span class="SpellE">combobox</span>
<span class="SpellE">cmbHives</span> that contains all supported hives. Only </p>
<p class="MsoNormal">HKEY_LOCAL_MACHINE, HKEY_USERS and HKEY_CURRENT_CONFIG are supported by
<span class="SpellE">RegistryEvent</span><span style=""> </span>or classes derived from it, such as
<span class="SpellE">RegistryKeyChangeEvent</span>.<span style=""> </span>Second, when a user typed key path and clicked Start Monitor button, create a new instance<span style="">
</span>of <span class="SpellE">RegistryWatcher</span>. The constructor of <span class="SpellE">
RegistryWatcher</span> will check whether the key exists or<span style=""> </span>
the user has permission to access the key, <span class="GramE">then</span> constructs a
<span class="SpellE">WqlEventQuery</span>.<span style=""> </span>Third, create a handler to listen for
<span class="SpellE">RegistryKeyChangeEvent</span> of <span class="SpellE">RegistryWatcher</span>.</p>
<p class="MsoNormal">At last, when a registry-change event arrived, displays the notification in a
<span class="SpellE">listbox</span>.</p>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/aa393040(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa393040(VS.85).aspx</a></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/aa392388(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa392388(VS.85).aspx</a></p>
<p class="MsoNormal"><a href="http://www.codeproject.com/KB/system/WMI_RegistryMonitor.aspx">http://www.codeproject.com/KB/system/WMI_RegistryMonitor.aspx</a></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
