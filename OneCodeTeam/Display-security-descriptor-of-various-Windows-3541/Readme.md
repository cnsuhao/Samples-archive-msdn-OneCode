# Display security descriptor of various Windows kernel objects (CppCheckSD)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Windows Security
* Windows General
## Topics
* Security Descriptor
* SDDL
## IsPublished
* True
## ModifiedDate
* 2011-06-19 09:25:21
## Description

<p style="font-family:Courier New">&nbsp;</p>
<h2>Windows Console APPLICATION: CppCheckSD Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The sample demonstrates how to obtain and display the security descriptor for<br>
various Kernel Objects in Windows. &nbsp;The sample by default only obtains the <br>
Access Allowed Aces (DACLs) and NOT the System Audit Acess (SACLs) although<br>
Integrity Aces are SACLs so these will be displayed as well. &nbsp;By default<br>
the Security Descriptor is displayed in Security Descriptor Definition<br>
Language (SDDL) format. &nbsp;There is a switch to get more detailed information <br>
on the security descriptor.<br>
<br>
You can obtain the security descriptor for the following kernel objects:<br>
<br>
&nbsp; &nbsp;* mailslot<br>
&nbsp; &nbsp;* service control manager<br>
&nbsp; &nbsp;* directory <br>
&nbsp; &nbsp;* event<br>
&nbsp; &nbsp;* file<br>
&nbsp; &nbsp;* thread<br>
&nbsp; &nbsp;* memory mapped file<br>
&nbsp; &nbsp;* job object<br>
&nbsp; &nbsp;* desktop<br>
&nbsp; &nbsp;* printer<br>
&nbsp; &nbsp;* mutex<br>
&nbsp; &nbsp;* named pipe<br>
&nbsp; &nbsp;* process access token<br>
&nbsp; &nbsp;* process<br>
&nbsp; &nbsp;* registry key<br>
&nbsp; &nbsp;* sempahore<br>
&nbsp; &nbsp;* network share<br>
&nbsp; &nbsp;* service<br>
&nbsp; &nbsp;* window station<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Step1. Build the sample project in Visual Studio 2010.<br>
<br>
Step2. Start a cmd.exe window and Run CppCheckSD.exe. This application will show <br>
the following help text.<br>
<br>
&nbsp; &nbsp;Usage: CppCheckSD [object] [name] &lt;/v&gt; &lt;/a&gt;<br>
&nbsp; &nbsp; /v : VERBOSE<br>
&nbsp; &nbsp; /a : Show Audit Aces<br>
<br>
&nbsp; &nbsp; -a : mailslot, use \\[server]\mailslot\[mailslotname]<br>
&nbsp; &nbsp; -c : service control manager<br>
&nbsp; &nbsp; -d : directory or driver letter, use \\.\[driveletter]<br>
&nbsp; &nbsp; -e : event<br>
&nbsp; &nbsp; -f : file<br>
&nbsp; &nbsp; -h : thread, use tid instead of name<br>
&nbsp; &nbsp; -i : memory mapped file<br>
&nbsp; &nbsp; -j : job object<br>
&nbsp; &nbsp; -k : desktop, use [window station\desktop]<br>
&nbsp; &nbsp; -l : printer, use \\[server]\[printername]<br>
&nbsp; &nbsp; -m : mutex<br>
&nbsp; &nbsp; -n : named pipe, use \\[server or .]\pipe\[pipename]<br>
&nbsp; &nbsp; -o : process access token, use pid instead of name<br>
&nbsp; &nbsp; -p : process, use pid instead of name<br>
&nbsp; &nbsp; -r : registry key, use CLASSES_ROOT, CURRENT_USER, MACHINE, or USERS suchas MACHINE\Software<br>
&nbsp; &nbsp; -s : sempahore<br>
&nbsp; &nbsp; -t : network share, use [\\server\sharename]<br>
&nbsp; &nbsp; -v : service, use [\\server\service]<br>
&nbsp; &nbsp; -w : window station<br>
&nbsp; &nbsp; -x : 32 bit registry key<br>
&nbsp; &nbsp; -y : kernel transaction<br>
&nbsp; &nbsp; -z : waitable timer<br>
<br>
Step3. Type CppCheckSD.exe and a valid command and press Enter, like <br>
&nbsp; &nbsp; &nbsp; &quot;D:\CppCheckSD.exe -d c:\&quot;, you can see all following information.<br>
<br>
&nbsp; &nbsp;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;<br>
&nbsp; &nbsp;&gt;&gt; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; SECURITY INFORMATION &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&gt;&gt;<br>
&nbsp; &nbsp;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;&gt;<br>
<br>
&nbsp; &nbsp;object name ........ c:\<br>
&nbsp; &nbsp;object type ........ directory<br>
&nbsp; &nbsp;sd ................. O:S-1-5-80-956008885-3418522649-1831038044-1853292631-2271478464G:S-1-5-80-9560<br>
&nbsp; &nbsp;08885-3418522649-1831038044-1853292631-2271478464D:PAI(A;;FA;;;BA)(A;OICIIO;GA;;;BA)(A;;FA;;;SY)(A;O<br>
&nbsp; &nbsp;ICIIO;GA;;;SY)(A;OICI;0x1200a9;;;BU)(A;OICIIO;SDGXGWGR;;;AU)(A;;LC;;;AU)S:(ML;OINPIO;NW;;;HI)<br>
&nbsp; &nbsp;length ............. 282<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
1.In order to obtain a security descriptor to any kernel object, you need<br>
to obtain a handle with the following access permissions:<br>
<br>
&nbsp; &nbsp;READ_CONTROL<br>
<br>
If you specify the auditing switch, you also need the following access <br>
permissions:<br>
<br>
&nbsp; &nbsp;ACCESS_SYSTEM_SECURITY<br>
<br>
and you need to enable the SE_SECURITY_NAME privilege before requesting this<br>
access right. &nbsp;<br>
<br>
<br>
2. Some Kernel Objects, the security APIs will internally obtain the handle for the<br>
targeted object while others you have to obtain the handle yourself. &nbsp;There are 2<br>
functions for doing this:<br>
<br>
&nbsp; &nbsp;DumpObjectWithHandle()<br>
&nbsp; &nbsp;DumpObjectWithName()<br>
<br>
By default we are requesting the following security information:<br>
<br>
&nbsp; &nbsp;a. Owner<br>
&nbsp; &nbsp;b. Group<br>
&nbsp; &nbsp;c. Dacl<br>
&nbsp; &nbsp;d. Label<br>
<br>
If you request to see the audit aces, you also need to specify:<br>
<br>
&nbsp; &nbsp;a. Sacl<br>
<br>
3. Once you have obtained the Security Descriptor, by default we are displaying <br>
the Security Descriptor in SDDL format using the following function:<br>
<br>
&nbsp; &nbsp;ConvertSecurityDescriptorToStringSecurityDescriptor()<br>
<br>
This is done in the DumpSD function. &nbsp;To obtain the full binary security <br>
descriptor, you need to use various helper functions in the sample. &nbsp;See <br>
SD.cpp for more information.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Security Descriptors:<br>
<a href="http://msdn.microsoft.com/en-us/library/aa379563.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/aa379563.aspx</a><br>
<br>
SDDL:<br>
<a href="http://msdn.microsoft.com/en-us/library/aa379567.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/aa379567.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
