# Enable NetBIOS over TCP/IP (CppEnableNetBiosOverTCPIP)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows SDK
* Network
## Topics
* netbios
## IsPublished
* True
## ModifiedDate
* 2012-03-01 07:31:30
## Description

<div class="WordSection1">
<h1>Set the NetBIOS o<span class="GramE">ver</span> TCP/IP on the server. (<span class="SpellE">CppEnableNetBiosOverTCPIP</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
This sample application demonstrates how to set the NetBIOS <span class="GramE">
Over</span> TCP/IP on the server. We are using here WMI&rsquo;s class <span style="font-size:9.5pt; font-family:Consolas; color:#a31515">
Win32_NetworkAdapterConfiguration </span>under <span style="font-size:9.5pt; font-family:Consolas; color:#a31515">
ROOT\CimV2 </span>namespace.&nbsp;&nbsp;</p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
This namespace is provided by Microsoft to manage most of the WMI Classes.<span>&nbsp;
</span>This application takes the advantages of WMI classes and executes the method
<span class="SpellE"><span style="font-size:9.5pt; font-family:Consolas; color:#a31515">SetTCPIPNetBIOS</span></span>.&nbsp;</p>
<p class="MsoNormal">To know more about Net BIOS Over TCP IP, please visit <a href="http://technet.microsoft.com/en-us/library/bb727013.aspx">
http://technet.microsoft.com/en-us/library/bb727013.aspx</a><span>&nbsp; </span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal">In order to execute this sample code, we need a Server where NIC is IP Enabled. You must execute this application under Administrator privileges as this requires admin privileges to update NIC configuration.</p>
<p class="MsoNormal">We should know which we are going to pass to the method <span class="SpellE">
SetTcpipNetBIOS</span>. This can be found here, <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa393601(v=vs.85).aspx">
http://msdn.microsoft.com/en-us/library/windows/desktop/aa393601(v=vs.85).aspx</a>. In our case, it should be 1 (0x1<span class="GramE">)<span>&nbsp;
</span>Enable</span> <span class="SpellE">Netbios</span>.</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Since this is a C&#43;&#43; Application, we need to include certain header files: <span class="SpellE">
<span style="font-size:9.5pt; font-family:Consolas; color:#a31515">comdef.h</span></span> for COM &amp;
<span class="SpellE"><span style="font-size:9.5pt; font-family:Consolas; color:#a31515">Wbemidl.h</span></span> for WMI. In the code, first we need to initialize COM by calling (<span class="SpellE"><span style="font-size:9.5pt; font-family:Consolas">CoInitializeEx</span></span>).
 Once the COM is initialized we need to set the COM general security calling (<span class="SpellE"><span style="font-size:9.5pt; font-family:Consolas">CoInitializeSecurity</span></span>). Then we require
<span class="GramE">to get</span> the WMI Locator in order to connect to a WMI service by calling (<span class="SpellE"><span style="font-size:9.5pt; font-family:Consolas">CoCreateInstance</span></span>) &amp; (<span class="SpellE"><span style="font-size:9.5pt; font-family:Consolas">IWbemServices</span></span>::<span class="SpellE"><span style="font-size:9.5pt; font-family:Consolas">ConnectServer</span></span>).
 While connecting to the WMI service we need to connect to the <span style="font-size:9.5pt; font-family:Consolas; color:#a31515">
ROOT\CimV2 </span>namespace. This namespace gives us the facilities to work with the most of the base WMI classes. After we obtain the connection to the WMI service we would require to setting the proxy setting via
<span class="SpellE"><span style="font-size:9.5pt; font-family:Consolas">CoSetProxyBlanket</span></span>, make sure we use the impersonation level as
<span style="font-size:9.5pt; font-family:Consolas">RPC_C_IMP_LEVEL_IMPERSONATE</span>.&nbsp;</p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
For executing this method <span class="SpellE">SetTCPIPNetBios</span> we need to first get the Network adapter where the IP is enabled. For this we would need to fire a WQL as &ldquo;<span style="font-size:9.5pt; font-family:Consolas; color:#a31515">Select
 * From Win32_NetworkAdapterConfiguration Where <span class="SpellE">IPEnabled</span> = True</span>&rdquo; Once we get this record, we need to get the instance of this record by getting the __RELPATH and then we need to execute the method &ldquo;<span class="SpellE">SetTCPIPNetBIOS</span>&rdquo;&nbsp;</p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
This takes one parameter: <span class="GramE">uint32</span> <span class="SpellE">
TcpipNetbiosOptions</span>, which can be:</p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<strong><span style="font-size:9.5pt; font-family:Consolas; color:#a31515">&nbsp;</span></strong></p>
<table class="MsoNormalTable" border="0" cellspacing="0" cellpadding="0" style="margin-left:.5in; border-collapse:collapse">
<tbody>
<tr>
<td valign="top" style="border:none; border-bottom:solid #DBDBDB 1.0pt; padding:7.5pt 6.0pt 7.5pt 6.0pt">
<p class="MsoNormal" style="margin-top:0in; margin-right:7.5pt; margin-bottom:.0001pt; margin-left:7.5pt; line-height:normal">
<span style="font-size:9.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:#2a2a2a">0 (0x0)
</span></p>
</td>
<td valign="top" style="border:none; border-bottom:solid #DBDBDB 1.0pt; padding:7.5pt 6.0pt 7.5pt 6.0pt">
<p class="MsoNormal" style="margin-top:0in; margin-right:7.5pt; margin-bottom:.0001pt; margin-left:7.5pt; line-height:13.5pt">
<span style="font-size:9.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:#2a2a2a">Enable
<span class="SpellE">Netbios</span> via DHCP</span></p>
</td>
</tr>
<tr>
<td valign="top" style="border:none; border-bottom:solid #DBDBDB 1.0pt; padding:7.5pt 6.0pt 7.5pt 6.0pt">
<p class="MsoNormal" style="margin-top:0in; margin-right:7.5pt; margin-bottom:.0001pt; margin-left:7.5pt; line-height:normal">
<span style="font-size:9.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:#2a2a2a">1 (0x1)
</span></p>
</td>
<td valign="top" style="border:none; border-bottom:solid #DBDBDB 1.0pt; padding:7.5pt 6.0pt 7.5pt 6.0pt">
<p class="MsoNormal" style="margin-top:0in; margin-right:7.5pt; margin-bottom:.0001pt; margin-left:7.5pt; line-height:13.5pt">
<span style="font-size:9.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:#2a2a2a">Enable
<span class="SpellE">Netbios</span></span></p>
</td>
</tr>
<tr>
<td valign="top" style="border:none; border-bottom:solid #DBDBDB 1.0pt; padding:7.5pt 6.0pt 7.5pt 6.0pt">
<p class="MsoNormal" style="margin-top:0in; margin-right:7.5pt; margin-bottom:.0001pt; margin-left:7.5pt; line-height:normal">
<span style="font-size:9.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:#2a2a2a">2 (0x2)
</span></p>
</td>
<td valign="top" style="border:none; border-bottom:solid #DBDBDB 1.0pt; padding:7.5pt 6.0pt 7.5pt 6.0pt">
<p class="MsoNormal" style="margin-top:0in; margin-right:7.5pt; margin-bottom:.0001pt; margin-left:7.5pt; line-height:13.5pt">
<span style="font-size:9.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:#2a2a2a">Disable
<span class="SpellE">Netbios</span></span></p>
</td>
</tr>
</tbody>
</table>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
In our case it will be Enable NetBIOS i.e. 0x1.</p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span>We will execute the method with the help of <span class="SpellE">IWbemServices</span>::<span class="SpellE">ExecMethod</span>. This method returns the HRESULT and if successful we need to release all the pointers and must exit out gracefully.</span></p>
<h2>More Information</h2>
<p class="MsoNormal">For more information on:</p>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Working on WMI via C&#43;&#43;:</p>
<p class="MsoNormal" style="margin-left:.5in"><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa394558(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/aa394558(v=vs.85).aspx</a></p>
<p class="MsoNormal" style="margin-left:.5in"><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa389762(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/aa389762(v=vs.85).aspx</a></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Win32_NetworkConfigurationClass:</p>
<p class="MsoListParagraphCxSpLast"><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa394217(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/aa394217(v=vs.85).aspx</a></p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
<p></p>
<p class="MsoNormal">&nbsp;</p>
</div>
