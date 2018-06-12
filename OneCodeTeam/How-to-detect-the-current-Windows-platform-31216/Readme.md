# How to detect the current Windows platform information
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Windows Desktop App Development
## Topics
* Platform Detector
## IsPublished
* True
## ModifiedDate
* 2014-10-07 10:26:47
## Description

<h2>
<hr>
<div><a href="http://blogs.msdn.com/b/onecode"><img src="http://bit.ly/onecodesampletopbanner" alt=""></a></div>
</h2>
<h2>How to detect the current Windows platform information</h2>
<h2>Introduction</h2>
<p>The sample demonstrates how we can detect the following information about the current Windows platform:</p>
<ol>
<li>Operating System Name </li><li>Service Pack Level Installed on the machine </li><li>Computer Name </li><li>Machine Bitness </li><li>Workgroup/Domain </li></ol>
<p><a href="http://stackoverflow.com/questions/1953377/how-to-know-a-process-is-32-bit-or-64-bit-programmatically">http://stackoverflow.com/questions/1953377/how-to-know-a-process-is-32-bit-or-64-bit-programmatically</a>&nbsp;&nbsp;&nbsp;
<br>
<a href="http://social.msdn.microsoft.com/Forums/en-US/csharpgeneral/thread/24792cdc-2d8e-454b-9c68-31a19892ca53">http://social.msdn.microsoft.com/Forums/en-US/csharpgeneral/thread/24792cdc-2d8e-454b-9c68-31a19892ca53</a>&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
<h2>Running the Sample</h2>
<p>Press Ctrl &#43; F5 to run this sample to see the form.</p>
<p><img id="126573" src="/site/view/file/126573/1/134213.png" alt="" width="519" height="410"></p>
<h2>Using the Code</h2>
<p>Declare the following structure to store the Operating System Information.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public struct OSVERSIONINFO
{
    public int dwOSVersionInfoSize;
    public int dwMajorVersion;
    public int dwMinorVersion;
    public int dwBuildNumber;
    public int dwPlatformId;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string szCSDVersion;
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">struct</span>&nbsp;OSVERSIONINFO&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">int</span>&nbsp;dwOSVersionInfoSize;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">int</span>&nbsp;dwMajorVersion;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">int</span>&nbsp;dwMinorVersion;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">int</span>&nbsp;dwBuildNumber;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">int</span>&nbsp;dwPlatformId;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[MarshalAs(UnmanagedType.ByValTStr,&nbsp;SizeConst&nbsp;=&nbsp;<span class="cs__number">128</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;szCSDVersion;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;The following function fills the OSVERSIONINFO structure and also add a reference to the System.Runtime.InteropServices.dll.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">[DllImport(&quot;kernel32.Dll&quot;)]
public static extern short GetVersionEx(ref OSVERSIONINFO o);
static public string GetServicePack()
{
    OSVERSIONINFO os = new OSVERSIONINFO();
    os.dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFO));
    GetVersionEx(ref os);
    if (os.szCSDVersion == &quot;&quot;)
        return &quot;No Service Pack Installed&quot;;
    else
        return os.szCSDVersion;
}
</pre>
<div class="preview">
<pre class="csharp">[DllImport(<span class="cs__string">&quot;kernel32.Dll&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span><span class="cs__keyword">static</span><span class="cs__keyword">extern</span><span class="cs__keyword">short</span>&nbsp;GetVersionEx(<span class="cs__keyword">ref</span>&nbsp;OSVERSIONINFO&nbsp;o);&nbsp;
<span class="cs__keyword">static</span><span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;GetServicePack()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;OSVERSIONINFO&nbsp;os&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OSVERSIONINFO();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;os.dwOSVersionInfoSize&nbsp;=&nbsp;Marshal.SizeOf(<span class="cs__keyword">typeof</span>(OSVERSIONINFO));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;GetVersionEx(<span class="cs__keyword">ref</span>&nbsp;os);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(os.szCSDVersion&nbsp;==&nbsp;<span class="cs__string">&quot;&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span><span class="cs__string">&quot;No&nbsp;Service&nbsp;Pack&nbsp;Installed&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span><span class="cs__keyword">return</span>&nbsp;os.szCSDVersion;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;The following function returns if it is a Server version of OS on the machine. Also add a reference to the System.Management.dll.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public bool IsServerVersion()
{
    using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(&quot;SELECT * FROM Win32_OperatingSystem&quot;))
    {
        foreach (ManagementObject managementObject in searcher.Get())
        {
            // ProductType will be one of:
            // 1: Workstation
            // 2: Domain Controller
            // 3: Server
            uint productType = (uint)managementObject.GetPropertyValue(&quot;ProductType&quot;);
            return productType != 1;
        }
    }
    return false;
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">bool</span>&nbsp;IsServerVersion()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(ManagementObjectSearcher&nbsp;searcher&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ManagementObjectSearcher(<span class="cs__string">&quot;SELECT&nbsp;*&nbsp;FROM&nbsp;Win32_OperatingSystem&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(ManagementObject&nbsp;managementObject&nbsp;<span class="cs__keyword">in</span>&nbsp;searcher.Get())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;ProductType&nbsp;will&nbsp;be&nbsp;one&nbsp;of:</span><span class="cs__com">//&nbsp;1:&nbsp;Workstation</span><span class="cs__com">//&nbsp;2:&nbsp;Domain&nbsp;Controller</span><span class="cs__com">//&nbsp;3:&nbsp;Server</span><span class="cs__keyword">uint</span>&nbsp;productType&nbsp;=&nbsp;(<span class="cs__keyword">uint</span>)managementObject.GetPropertyValue(<span class="cs__string">&quot;ProductType&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;productType&nbsp;!=&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span><span class="cs__keyword">false</span>;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
</div>
<div class="endscriptcode">Declare the following Interop class to call GetSystemMetrics which will help us distinguish between Windows Server 2003 and Windows Server 2003 R2</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public partial class WindowsAPI
{
    [DllImport(&quot;user32.dll&quot;)]
    public static extern int GetSystemMetrics(int smIndex);
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;WindowsAPI&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DllImport(<span class="cs__string">&quot;user32.dll&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">static</span><span class="cs__keyword">extern</span><span class="cs__keyword">int</span>&nbsp;GetSystemMetrics(<span class="cs__keyword">int</span>&nbsp;smIndex);&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>Add the following code to the Form Load Event Handler and also add a reference to the System.DirectoryServices.dll.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">//Set textBox5 and textBox6 appropriately based on the bitness of the machine and the process
if (Environment.Is64BitOperatingSystem)
{
    textBox5.Text = &quot;64-Bit&quot;;
}
else
{
    textBox5.Text = &quot;32-Bit&quot;;
}

if (Environment.Is64BitProcess)
{
    textBox6.Text = &quot;64-Bit&quot;;
}
else
{
    textBox6.Text = &quot;32-Bit&quot;;
}

//Set the textbox1 to the Operating System name by checking the OS version. 
Version vs = Environment.OSVersion.Version;

bool isServer = IsServerVersion();

switch (vs.Major)
{
    case 3:
        textBox1.Text = &quot;Windows NT 3.51&quot;;
        break;
    case 4:
        textBox1.Text = &quot;Windows NT 4.0&quot;;
        break;
    case 5:
        if (vs.Minor == 0)
            textBox1.Text = &quot;Windows 2000&quot;;
        else if (vs.Minor == 1)
            textBox1.Text = &quot;Windows XP&quot;;
        else
        {
            if (isServer)
            {
                if (WindowsAPI.GetSystemMetrics(89) == 0)
                    textBox1.Text = &quot;Windows Server 2003&quot;;
                else
                    textBox1.Text = &quot;Windows Server 2003 R2&quot;;
            }
            else
                textBox1.Text = &quot;Windows XP&quot;;
        }
        break;
    case 6:
        if (vs.Minor == 0)
        {
            if (isServer)
                textBox1.Text = &quot;Windows Server 2008&quot;;
            else
                textBox1.Text = &quot;Windows Vista&quot;;
        }
        else if (vs.Minor == 1)
        {
            if (isServer)
                textBox1.Text = &quot;Windows Server 2008 R2&quot;;
            else
                textBox1.Text = &quot;Windows 7&quot;;
        }
        else if (vs.Minor == 2)
            textBox1.Text = &quot;Windows 8&quot;;
        else
        {
            if (isServer)
                textBox1.Text = &quot;Windows Server 2012 R2&quot;;
            else
                textBox1.Text = &quot;Windows 8.1&quot;;
        }
        break;
} 

//Set the textBox2 to the machine name
textBox2.Text = Environment.MachineName;

//Set the textBox4 to the domain name to which the machine is connected else set it to Workgroup
try
{
    textBox4.Text = System.DirectoryServices.ActiveDirectory.Domain.GetComputerDomain().Name; 
}
catch (ActiveDirectoryObjectNotFoundException ex)
{
    textBox4.Text = &quot;WORKGROUP&quot;;     
}

//Set textBox3 to the current service pack level installed on the machine
textBox3.Text = GetServicePack();
        }
    }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//Set&nbsp;textBox5&nbsp;and&nbsp;textBox6&nbsp;appropriately&nbsp;based&nbsp;on&nbsp;the&nbsp;bitness&nbsp;of&nbsp;the&nbsp;machine&nbsp;and&nbsp;the&nbsp;process</span><span class="cs__keyword">if</span>&nbsp;(Environment.Is64BitOperatingSystem)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;textBox5.Text&nbsp;=&nbsp;<span class="cs__string">&quot;64-Bit&quot;</span>;&nbsp;
}&nbsp;
<span class="cs__keyword">else</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;textBox5.Text&nbsp;=&nbsp;<span class="cs__string">&quot;32-Bit&quot;</span>;&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">if</span>&nbsp;(Environment.Is64BitProcess)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;textBox6.Text&nbsp;=&nbsp;<span class="cs__string">&quot;64-Bit&quot;</span>;&nbsp;
}&nbsp;
<span class="cs__keyword">else</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;textBox6.Text&nbsp;=&nbsp;<span class="cs__string">&quot;32-Bit&quot;</span>;&nbsp;
}&nbsp;
&nbsp;
<span class="cs__com">//Set&nbsp;the&nbsp;textbox1&nbsp;to&nbsp;the&nbsp;Operating&nbsp;System&nbsp;name&nbsp;by&nbsp;checking&nbsp;the&nbsp;OS&nbsp;version.&nbsp;</span>&nbsp;
Version&nbsp;vs&nbsp;=&nbsp;Environment.OSVersion.Version;&nbsp;
&nbsp;
<span class="cs__keyword">bool</span>&nbsp;isServer&nbsp;=&nbsp;IsServerVersion();&nbsp;
&nbsp;
<span class="cs__keyword">switch</span>&nbsp;(vs.Major)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span><span class="cs__number">3</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Windows&nbsp;NT&nbsp;3.51&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span><span class="cs__number">4</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Windows&nbsp;NT&nbsp;4.0&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span><span class="cs__number">5</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(vs.Minor&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Windows&nbsp;2000&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span><span class="cs__keyword">if</span>&nbsp;(vs.Minor&nbsp;==&nbsp;<span class="cs__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Windows&nbsp;XP&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(isServer)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(WindowsAPI.GetSystemMetrics(<span class="cs__number">89</span>)&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Windows&nbsp;Server&nbsp;2003&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Windows&nbsp;Server&nbsp;2003&nbsp;R2&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Windows&nbsp;XP&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span><span class="cs__number">6</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(vs.Minor&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(isServer)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Windows&nbsp;Server&nbsp;2008&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Windows&nbsp;Vista&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span><span class="cs__keyword">if</span>&nbsp;(vs.Minor&nbsp;==&nbsp;<span class="cs__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(isServer)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Windows&nbsp;Server&nbsp;2008&nbsp;R2&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Windows&nbsp;7&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span><span class="cs__keyword">if</span>&nbsp;(vs.Minor&nbsp;==&nbsp;<span class="cs__number">2</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Windows&nbsp;8&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(isServer)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Windows&nbsp;Server&nbsp;2012&nbsp;R2&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Windows&nbsp;8.1&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
}&nbsp;&nbsp;
&nbsp;
<span class="cs__com">//Set&nbsp;the&nbsp;textBox2&nbsp;to&nbsp;the&nbsp;machine&nbsp;name</span>&nbsp;
textBox2.Text&nbsp;=&nbsp;Environment.MachineName;&nbsp;
&nbsp;
<span class="cs__com">//Set&nbsp;the&nbsp;textBox4&nbsp;to&nbsp;the&nbsp;domain&nbsp;name&nbsp;to&nbsp;which&nbsp;the&nbsp;machine&nbsp;is&nbsp;connected&nbsp;else&nbsp;set&nbsp;it&nbsp;to&nbsp;Workgroup</span><span class="cs__keyword">try</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;textBox4.Text&nbsp;=&nbsp;System.DirectoryServices.ActiveDirectory.Domain.GetComputerDomain().Name;&nbsp;&nbsp;
}&nbsp;
<span class="cs__keyword">catch</span>&nbsp;(ActiveDirectoryObjectNotFoundException&nbsp;ex)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;textBox4.Text&nbsp;=&nbsp;<span class="cs__string">&quot;WORKGROUP&quot;</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
}&nbsp;
&nbsp;
<span class="cs__com">//Set&nbsp;textBox3&nbsp;to&nbsp;the&nbsp;current&nbsp;service&nbsp;pack&nbsp;level&nbsp;installed&nbsp;on&nbsp;the&nbsp;machine</span>&nbsp;
textBox3.Text&nbsp;=&nbsp;GetServicePack();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h2>More Information</h2>
<p>How to Determine the Operation System Service Pack Level in Visual C#.NET<br>
<a href="http://support.microsoft.com/kb/304721">http://support.microsoft.com/kb/304721</a></p>
<p>MSDN: Environment Properties<br>
<a href="http://msdn.microsoft.com/en-us/library/System.Environment_properties(v=vs.110).aspx">http://msdn.microsoft.com/en-us/library/System.Environment_properties(v=vs.110).aspx</a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="endscriptcode">
<div class="endscriptcode">
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
</div>
</div>
