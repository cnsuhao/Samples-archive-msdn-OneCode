# Shut down a computer using .NET (CSShutdownComputer)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows SDK
## Topics
* shutdown
## IsPublished
* True
## ModifiedDate
* 2012-03-28 08:23:39
## Description

<div class="WordSection1">
<h1>The application demonstrates how to shut down a computer using .net. (<span class="SpellE">CSShutdownComputer</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal" style="text-align:justify; text-justify:inter-ideograph">The application demonstrates how to shut down a computer using .net. I&rsquo;ve
<span class="SpellE">pinvoked</span> the native API&rsquo;s to get this going. Following are the API&rsquo;s implemented&hellip;</p>
<p class="MsoListParagraphCxSpFirst" style="text-align:justify; text-justify:inter-ideograph; text-indent:-.25in">
<span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE">ExitWindowsEx</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-align:justify; text-justify:inter-ideograph; text-indent:-.25in">
<span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE">InitiateShutdown</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-align:justify; text-justify:inter-ideograph; text-indent:-.25in">
<span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE">InitiateSystemShutdownEx</span></p>
<p class="MsoListParagraphCxSpLast" style="text-align:justify; text-justify:inter-ideograph; text-indent:-.25in">
<span><span>4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE">AbortSystemShutdown</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal">I&rsquo;ve provided links which points towards the documentation in the application itself. Select any of the four radios to activate corresponding API. Fill in the options as per the documentation. Also note that I haven&rsquo;t provided
 much validation since I would like the user to invoke the API as would like to, no restrictions. Read the documentation carefully.</p>
<p class="MsoNormal">Also note that remote shutdown will only work if the remote computer has remote shutdown enabled. Use
<span class="SpellE">secpol.msc</span> to enable this feature for the remote computer.</p>
<p class="MsoNormal"><span class="SpellE">InitiateShutdown</span> and <span class="SpellE">
InitiateSystemShutdownEx</span> will end up showing a message box before shutting down the computer. Once the timeout expires the system automatically shutdowns. If you want to prevent this shutdown invoke &ldquo;<span class="SpellE">AbortSystemShutdown</span>&rdquo;.</p>
<p class="MsoNormal" style="text-align:justify; text-justify:inter-ideograph">This is how the application looks like&hellip;</p>
<p class="MsoNormal" style="text-align:justify; text-justify:inter-ideograph"><img src="/site/view/file/55355/1/image001.png" alt="" width="632" height="710"></p>
<p class="MsoNormal"><span>&nbsp;</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">The gist of the application lies in <span class="SpellE">
MainForm.cs</span> file. This is how the API calls look like&hellip;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">[DllImport(&quot;user32.dll&quot;, CharSet = CharSet.Auto,  SetLastError = true)]
[return: MarshalAs(UnmanagedType.Bool)]
static extern bool ExitWindowsEx(uint uFlags, uint uReason);
protected void CallExitWindowsEx()
{
    CheckBox [] chkFlags = { chkEWX_FORCE, 
                             chkEWX_FORCEIFHUNG, 
                             chkEWX_HYBRID_SHUTDOWN, 
                             chkEWX_LOGOFF, 
                             chkEWX_POWEROFF, 
                             chkEWX_REBOOT, 
                             chkEWX_RESTARTAPPS,
                             chkEWX_SHUTDOWN };
 
    UInt32 dwFlags = GetFlags(chkFlags);
    UInt32 reason = 0;
    if (HexToNum(txtReasonEWE.Text, out reason))
    {
        if (!ExitWindowsEx(dwFlags, reason))
        {
            ShowLastError();
        }
    }
}
 
// Call InitiateShutdown
[DllImport(&quot;advapi32.dll&quot;, CharSet = CharSet.Auto, SetLastError = true)]
[return: MarshalAs(UnmanagedType.Bool)]
static extern bool InitiateShutdown(string lpMachineName, 
                                    string lpMessage, 
                                    UInt32 dwGracePeriod, 
                                    UInt32 dwShutdownFlags, 
                                    UInt32 dwReason);
 
void CallInitiateShutdown()
{            
    CheckBox [] chkFlags = { chkSHUTDOWN_FORCE_OTHERS, 
                             chkSHUTDOWN_FORCE_SELF, 
                             chkSHUTDOWN_GRACE_OVERRIDE, 
                             chkSHUTDOWN_HYBRID, 
                             chkSHUTDOWN_INSTALL_UPDATES, 
                             chkSHUTDOWN_NOREBOOT, 
                             chkSHUTDOWN_POWEROFF,
                             chkSHUTDOWN_RESTART,
                             chkSHUTDOWN_RESTARTAPPS };
    UInt32 flags = GetFlags(chkFlags);
    UInt32 reason = 0;
    if (HexToNum(txtReasonIS.Text, out reason))
    {
        UInt32 gracePeriod;
        if (HexToNum(txtGracePeriodIS.Text, out gracePeriod))
        {
            if (!InitiateShutdown(txtMachineNameIS.Text, txtMessageIS.Text, gracePeriod, flags, reason))
            {
                ShowLastError();
            }
        }
    }
}
 
// Call InitiateSystemShutdownEx
[DllImport(&quot;advapi32.dll&quot;, CharSet = CharSet.Auto, SetLastError = true)]
[return: MarshalAs(UnmanagedType.Bool)]
public static extern bool InitiateSystemShutdownEx(
    string lpMachineName,
    string lpMessage,
    uint dwTimeout,
    bool bForceAppsClosed,
    bool bRebootAfterShutdown,
    UInt32 dwReason);
void CallInitiateSystemShutdownEx()
{
    UInt32 timeout = 0;
    if (HexToNum(txtTimeOutISSE.Text, out timeout))
    {
        UInt32 reason = 0;
        if (HexToNum(txtReasonISSE.Text, out reason))
        {
            if (!InitiateSystemShutdownEx(txtMachineNameISSE.Text, txtMessageISSE.Text, timeout, chkForceAppsClosed.Checked, chkRebootAfterShutdown.Checked, reason))
            {
                ShowLastError();
            }
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp">[DllImport(<span class="cs__string">&quot;user32.dll&quot;</span>,&nbsp;CharSet&nbsp;=&nbsp;CharSet.Auto,&nbsp;&nbsp;SetLastError&nbsp;=&nbsp;<span class="cs__keyword">true</span>)]&nbsp;
[<span class="cs__keyword">return</span>:&nbsp;MarshalAs(UnmanagedType.Bool)]&nbsp;
<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">extern</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;ExitWindowsEx(<span class="cs__keyword">uint</span>&nbsp;uFlags,&nbsp;<span class="cs__keyword">uint</span>&nbsp;uReason);&nbsp;
<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;CallExitWindowsEx()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CheckBox&nbsp;[]&nbsp;chkFlags&nbsp;=&nbsp;{&nbsp;chkEWX_FORCE,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chkEWX_FORCEIFHUNG,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chkEWX_HYBRID_SHUTDOWN,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chkEWX_LOGOFF,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chkEWX_POWEROFF,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chkEWX_REBOOT,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chkEWX_RESTARTAPPS,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chkEWX_SHUTDOWN&nbsp;};&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;UInt32&nbsp;dwFlags&nbsp;=&nbsp;GetFlags(chkFlags);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;UInt32&nbsp;reason&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(HexToNum(txtReasonEWE.Text,&nbsp;<span class="cs__keyword">out</span>&nbsp;reason))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!ExitWindowsEx(dwFlags,&nbsp;reason))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShowLastError();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;&nbsp;
<span class="cs__com">//&nbsp;Call&nbsp;InitiateShutdown</span>&nbsp;
[DllImport(<span class="cs__string">&quot;advapi32.dll&quot;</span>,&nbsp;CharSet&nbsp;=&nbsp;CharSet.Auto,&nbsp;SetLastError&nbsp;=&nbsp;<span class="cs__keyword">true</span>)]&nbsp;
[<span class="cs__keyword">return</span>:&nbsp;MarshalAs(UnmanagedType.Bool)]&nbsp;
<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">extern</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;InitiateShutdown(<span class="cs__keyword">string</span>&nbsp;lpMachineName,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;lpMessage,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UInt32&nbsp;dwGracePeriod,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UInt32&nbsp;dwShutdownFlags,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UInt32&nbsp;dwReason);&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">void</span>&nbsp;CallInitiateShutdown()&nbsp;
{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CheckBox&nbsp;[]&nbsp;chkFlags&nbsp;=&nbsp;{&nbsp;chkSHUTDOWN_FORCE_OTHERS,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chkSHUTDOWN_FORCE_SELF,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chkSHUTDOWN_GRACE_OVERRIDE,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chkSHUTDOWN_HYBRID,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chkSHUTDOWN_INSTALL_UPDATES,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chkSHUTDOWN_NOREBOOT,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chkSHUTDOWN_POWEROFF,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chkSHUTDOWN_RESTART,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chkSHUTDOWN_RESTARTAPPS&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;UInt32&nbsp;flags&nbsp;=&nbsp;GetFlags(chkFlags);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;UInt32&nbsp;reason&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(HexToNum(txtReasonIS.Text,&nbsp;<span class="cs__keyword">out</span>&nbsp;reason))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UInt32&nbsp;gracePeriod;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(HexToNum(txtGracePeriodIS.Text,&nbsp;<span class="cs__keyword">out</span>&nbsp;gracePeriod))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!InitiateShutdown(txtMachineNameIS.Text,&nbsp;txtMessageIS.Text,&nbsp;gracePeriod,&nbsp;flags,&nbsp;reason))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShowLastError();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;&nbsp;
<span class="cs__com">//&nbsp;Call&nbsp;InitiateSystemShutdownEx</span>&nbsp;
[DllImport(<span class="cs__string">&quot;advapi32.dll&quot;</span>,&nbsp;CharSet&nbsp;=&nbsp;CharSet.Auto,&nbsp;SetLastError&nbsp;=&nbsp;<span class="cs__keyword">true</span>)]&nbsp;
[<span class="cs__keyword">return</span>:&nbsp;MarshalAs(UnmanagedType.Bool)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">extern</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;InitiateSystemShutdownEx(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;lpMachineName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;lpMessage,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">uint</span>&nbsp;dwTimeout,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;bForceAppsClosed,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;bRebootAfterShutdown,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;UInt32&nbsp;dwReason);&nbsp;
<span class="cs__keyword">void</span>&nbsp;CallInitiateSystemShutdownEx()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;UInt32&nbsp;timeout&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(HexToNum(txtTimeOutISSE.Text,&nbsp;<span class="cs__keyword">out</span>&nbsp;timeout))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UInt32&nbsp;reason&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(HexToNum(txtReasonISSE.Text,&nbsp;<span class="cs__keyword">out</span>&nbsp;reason))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!InitiateSystemShutdownEx(txtMachineNameISSE.Text,&nbsp;txtMessageISSE.Text,&nbsp;timeout,&nbsp;chkForceAppsClosed.Checked,&nbsp;chkRebootAfterShutdown.Checked,&nbsp;reason))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShowLastError();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal">&nbsp;</p>
<h2 class="MsoNormal">More Information</h2>
<p class="MsoNormal" style="text-align:justify; text-justify:inter-ideograph"><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa376868(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/aa376868(v=vs.85).aspx</a><strong>&nbsp;</strong></p>
<p class="MsoNormal">&nbsp; </p>
<hr>
<a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a>
<p></p>
<p class="MsoNormal">&nbsp;</p>
</div>
