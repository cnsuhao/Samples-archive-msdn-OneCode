# Create and sign a cabinet file (CSCreateCabinet)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows SDK
## Topics
* CAB
## IsPublished
* True
## ModifiedDate
* 2012-04-20 04:56:57
## Description

<h1>How to create and sign a cabinet file (<span class="SpellE">CSCreateCabinet</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The cabinet format provides a way to efficiently package multiple files. Creating and signing a cabinet is very useful to deploy IE ActiveX control or other products.</p>
<p class="MsoNormal">To create a cabinet package, we can use the SDK supplied <span style="">
by</span> <a href="http://wix.codeplex.com/releases/view/60102">WiX Toolset</a>, then use
<a href="http://msdn.microsoft.com/en-us/library/8s9b9yaz.aspx">signtool.exe</a> to sign the cabinet package.
</p>
<p class="MsoNormal"></p>
<h2>Running the Sample</h2>
<p class="MsoNormal">After you successfully build the sample project in Visual Studio 2010, you will get the application CSCreateCabinet.exe.<span style="">&nbsp;
</span>Run the application and you will see following Console Window.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/56636/1/image.png" alt="" width="380" height="225" align="middle">
</span></p>
<h3>Pack a folder</h3>
<p class="MsoNormal"></p>
<p class="MsoNormal">Suppose <b style="">D:\temp\</b>a is an existing folder with files and sub folders, type following command and you will get a cabinet package
<b style="">d:\temp\a.cab</b>.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/56637/1/image.png" alt="" width="379" height="172" align="middle">
<span style="">&nbsp;</span> </span></p>
<h3>Unpack a cabinet</h3>
<p class="MsoNormal">Type following command and the cabinet will be extracted to
<b style="">d:\temp\a2. </b></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/56638/1/image.png" alt="" width="377" height="129" align="middle">
</span></p>
<h3>Sign a cabinet</h3>
<p class="MsoNormal"><span style="">To sign a cabinet, we need a Personal Information Exchange (PFX) file. This project supplies Test.pfx, its password is 123456, you can also create your own PFX file.
</span></p>
<p class="MsoNormal"><span class="GramE">Type following command.</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/56639/1/image.png" alt="" width="375" height="135" align="middle">
</span><span style=""></span></p>
<h3>Verify the signature</h3>
<p class="MsoNormal"></p>
<p class="MsoNormal">If the PFX file is trusted, type following command and you will see:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/56640/1/image.png" alt="" width="374" height="137" align="middle">
</span></p>
<p class="MsoNormal">Otherwise, you will see</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/56641/1/image.png" alt="" width="953" height="149" align="middle">
</span></p>
<p class="MsoNormal">To trust a certificate, double click the PFX file, and add it in to
<b style="">Trusted Root Certification Authorities</b> Store using <b style="">Certificate Import Wizard</b>.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/56642/1/image.png" alt="" width="295" height="269" align="middle">
</span></p>
<h2>Using the Code</h2>
<h3>How to <span style="">create a cabinet and extract files from a cabinet</span>?</h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
/// Pack a folder to the cabinet.
/// &lt;/summary&gt;
static void RunPackMethod(string cabFilePath, string sourceFolder)
{
    try
    {
        SignableCabinetPackage pkg = SignableCabinetPackage.LoadOrCreateCab(cabFilePath);
        pkg.Pack(
            sourceFolder,
            true,
            Microsoft.Deployment.Compression.CompressionLevel.Normal,
            ProcessHandle);
        Console.WriteLine(&quot;Packing cabinet succeeded.&quot;);
    }
    catch (Exception ex)
    {
        Console.WriteLine(&quot;Packing cabinet failed.&quot;);
        Console.WriteLine(ex.Message);
    }
}


/// &lt;summary&gt;
/// Unpack files from a cabinet.
/// &lt;/summary&gt;
static void RunUnpackMethod(string cabFilePath, string destinationFolder)
{
    try
    {
        SignableCabinetPackage pkg = SignableCabinetPackage.LoadCab(cabFilePath);
        pkg.Unpack(destinationFolder, ProcessHandle);
        Console.WriteLine(&quot;Unpacking cabinet succeeded.&quot;);
    }
    catch (Exception ex)
    {
        Console.WriteLine(&quot;Unpacking cabinet failed.&quot;);
        Console.WriteLine(ex.Message);
    }
}

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
/// Pack a folder to the cabinet.
/// &lt;/summary&gt;
static void RunPackMethod(string cabFilePath, string sourceFolder)
{
    try
    {
        SignableCabinetPackage pkg = SignableCabinetPackage.LoadOrCreateCab(cabFilePath);
        pkg.Pack(
            sourceFolder,
            true,
            Microsoft.Deployment.Compression.CompressionLevel.Normal,
            ProcessHandle);
        Console.WriteLine(&quot;Packing cabinet succeeded.&quot;);
    }
    catch (Exception ex)
    {
        Console.WriteLine(&quot;Packing cabinet failed.&quot;);
        Console.WriteLine(ex.Message);
    }
}


/// &lt;summary&gt;
/// Unpack files from a cabinet.
/// &lt;/summary&gt;
static void RunUnpackMethod(string cabFilePath, string destinationFolder)
{
    try
    {
        SignableCabinetPackage pkg = SignableCabinetPackage.LoadCab(cabFilePath);
        pkg.Unpack(destinationFolder, ProcessHandle);
        Console.WriteLine(&quot;Unpacking cabinet succeeded.&quot;);
    }
    catch (Exception ex)
    {
        Console.WriteLine(&quot;Unpacking cabinet failed.&quot;);
        Console.WriteLine(ex.Message);
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<a name="OLE_LINK1"><span style="">succe</span></a>
<p class="MsoNormal"><span style="">The </span><span class="SpellE"><b style=""><span style="color:black">SignableCabinetPackage</span></b></span><span style="color:black"> class inherits from the
<span class="SpellE">CabInfo</span> class in Microsoft.Deployment.Compression.Cab.dll. For more information about how to create and extract a cabinet, see
<a href="http://wix.codeplex.com/releases/view/60102">http://wix.codeplex.com/releases/view/60102</a>.
</span><span style=""></span></p>
<h3>How to <span style="">sign a cabinet</span>?<span style=""> </span></h3>
<p class="MsoNormal"><span style="">To sign a cabinet, we can use the signtool.exe in the Windows SDK. The sample also includes this tool in the _<span class="SpellE">External_Dependencies</span>.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public void Sign(string pfxFilePath, string password)
{
    ProcessStartInfo signtool = new ProcessStartInfo
    {
        Arguments = string.Format(&quot;sign /f {0} /p {1} {2}&quot;,
        pfxFilePath, password, this.FullPath),
        FileName = &quot;signtool.exe&quot;,
        CreateNoWindow = true,
        RedirectStandardOutput = true,
        UseShellExecute = false
    };


    Process signtoolProc = Process.Start(signtool);
    signtoolProc.WaitForExit();


    if (signtoolProc.ExitCode != 0)
    {
        throw new ApplicationException(signtoolProc.StandardOutput.ReadToEnd());
    }
}

</pre>
<pre id="codePreview" class="csharp">
public void Sign(string pfxFilePath, string password)
{
    ProcessStartInfo signtool = new ProcessStartInfo
    {
        Arguments = string.Format(&quot;sign /f {0} /p {1} {2}&quot;,
        pfxFilePath, password, this.FullPath),
        FileName = &quot;signtool.exe&quot;,
        CreateNoWindow = true,
        RedirectStandardOutput = true,
        UseShellExecute = false
    };


    Process signtoolProc = Process.Start(signtool);
    signtoolProc.WaitForExit();


    if (signtoolProc.ExitCode != 0)
    {
        throw new ApplicationException(signtoolProc.StandardOutput.ReadToEnd());
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h3>How to <span style="">verify the signature of a cabinet file</span>?<span style="">
</span></h3>
<p class="MsoNormal"><span style="">The <span class="SpellE">WinVerifyTrust</span> API can be used to verify the signature of a cabinet file.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
[DllImport(&quot;wintrust.dll&quot;, SetLastError = true, CharSet = CharSet.Auto)]
public static extern int WinVerifyTrust(
     [In] IntPtr hwnd,
     [In] [MarshalAs(UnmanagedType.LPStruct)] Guid pgActionID,
     [In] WINTRUST_DATA pWVTData
);

</pre>
<pre id="codePreview" class="csharp">
[DllImport(&quot;wintrust.dll&quot;, SetLastError = true, CharSet = CharSet.Auto)]
public static extern int WinVerifyTrust(
     [In] IntPtr hwnd,
     [In] [MarshalAs(UnmanagedType.LPStruct)] Guid pgActionID,
     [In] WINTRUST_DATA pWVTData
);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public void Verify()
{
    using (NativeMethods.WINTRUST_DATA wtd = new NativeMethods.WINTRUST_DATA(this.FullPath))
    {


        Guid guidAction = new Guid(NativeMethods.WINTRUST_ACTION_GENERIC_VERIFY_V2);
        int result = NativeMethods.WinVerifyTrust(
            NativeMethods.INVALID_HANDLE_VALUE,
            guidAction,
            wtd);


        if (result != 0)
        {
            var exception = Marshal.GetExceptionForHR(result);
            throw exception;
        }
    }
}

</pre>
<pre id="codePreview" class="csharp">
public void Verify()
{
    using (NativeMethods.WINTRUST_DATA wtd = new NativeMethods.WINTRUST_DATA(this.FullPath))
    {


        Guid guidAction = new Guid(NativeMethods.WINTRUST_ACTION_GENERIC_VERIFY_V2);
        int result = NativeMethods.WinVerifyTrust(
            NativeMethods.INVALID_HANDLE_VALUE,
            guidAction,
            wtd);


        if (result != 0)
        {
            var exception = Marshal.GetExceptionForHR(result);
            throw exception;
        }
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/bb417343.aspx#res_space_code_sig">Microsoft Cabinet Format</a></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style=""><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387764.aspx"><span class="SpellE">SignTool</span></a></span>
</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa388208(v=vs.85).aspx"><span class="SpellE">WinVerifyTrust</span> function</a>
</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/aa382384(VS.85).aspx">Example C Program: Verifying the Signature of a PE File</a></p>
<p class="MsoListParagraphCxSpLast" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://wix.codeplex.com/releases/view/60102">WiX Toolset</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
