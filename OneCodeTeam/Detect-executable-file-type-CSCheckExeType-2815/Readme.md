# Detect executable file type (CSCheckExeType)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Windows General
## Topics
* PE
* Exe type
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:14:14
## Description

<p style="font-family:Courier New"></p>
<h2>Windows APPLICATION: CSCheckEXEType Overview </h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New">The sample demonstrates how to check an executable file type. Given an exe or a dll,<br>
the sample application detects:<br>
<br>
1. exe type (console or GUI, or other exe type) by checking the subsystem flag in PE<br>
2. Is it a .NET assembly? <br>
&nbsp; &nbsp;If no, <br>
&nbsp; &nbsp; &nbsp; &nbsp;- detect the exe bitness (x86 or x64)<br>
&nbsp; &nbsp;If yes, <br>
&nbsp; &nbsp; &nbsp; &nbsp;- detect the exe bitness (ANY CPU, x86, x64)<br>
&nbsp; &nbsp; &nbsp; &nbsp;- detect compiled .NET runtime version <br>
&nbsp; &nbsp; &nbsp; &nbsp;- print the full name of the assembly <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(e.g. System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089, processorArchitecture=MSIL)<br>
&nbsp; </p>
<h3>Demo:</h3>
<p style="font-family:Courier New">Step1. Build the sample project in Visual Studio 2010.<br>
<br>
Step2. Run CSCheckEXEType.exe. This application will show following help text.<br>
Please type the exe file path:<br>
&lt;Empty to exit&gt;<br>
<br>
Step3. Type a valid path of a native executable and press Enter, like <br>
&nbsp; &nbsp; &nbsp; &quot;D:\NativeConsole32.exe&quot;, you can see all following information.<br>
<br>
ConsoleApplication: True<br>
.NetApplication: False<br>
32bit application: True<br>
<br>
Step4. Type a valid path of a .Net executable and press Enter, like <br>
&nbsp; &nbsp; &nbsp; &quot;D:\NetWinFormAnyCPU.exe&quot;, you can see all following information.<br>
<br>
ConsoleApplication: False<br>
.NetApplication: True<br>
Compiled .NET Runtime: v4.0.30319<br>
Full Name: NetWinFormAnyCPU, Version=1.0.0.0, Culture=neutral, PublicKeyToken=neutral, processorArchitecture=MSIL<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
First, create an ExecutableFile class that represents an executable file. It could get
<br>
the image file header, image optional header and data directories from the image file.
<br>
Form these headers, we can get whether this is a console application, whether this is
<br>
a .Net application and whether this is a 32bit native application. <br>
<br>
Note: The IMAGE_OPTIONAL_HEADER structures of 32bit and 64 bit application are <br>
&nbsp; &nbsp; &nbsp;different. The difference is that 64 bit application does not have BaseOfData<br>
&nbsp; &nbsp; &nbsp;field and the data type of ImageBase/SizeOfStackReserve/SizeOfStackCommit/<br>
&nbsp; &nbsp; &nbsp;SizeOfHeapReserve/SizeOfHeapCommit is UInt64. <br>
<br>
Second, to generate the full display name of .NET application, we can use the fusion API.
<br>
<br>
&nbsp;Char[] buffer = new Char[1024];<br>
<br>
&nbsp;// Get the IReferenceIdentity interface.<br>
&nbsp;Fusion.IReferenceIdentity referenceIdentity =<br>
&nbsp; &nbsp; Fusion.NativeMethods.GetAssemblyIdentityFromFile(ExeFilePath,<br>
&nbsp; &nbsp; ref Fusion.NativeMethods.ReferenceIdentityGuid) as Fusion.IReferenceIdentity;<br>
&nbsp;Fusion.IIdentityAuthority IdentityAuthority = Fusion.NativeMethods.GetIdentityAuthority(); &nbsp;<br>
&nbsp;<br>
&nbsp;IdentityAuthority.ReferenceToTextBuffer(0, referenceIdentity, 1024, buffer);<br>
<br>
&nbsp;string fullName = new string(buffer);<br>
<br>
Third, to detect the compiled .NET runtime version, we can use the hosting API.<br>
<br>
&nbsp;object metahostInterface=null;<br>
&nbsp;Hosting.NativeMethods.CLRCreateInstance(<br>
&nbsp; &nbsp; &nbsp;ref Hosting.NativeMethods.CLSID_CLRMetaHost,<br>
&nbsp; &nbsp; &nbsp;ref Hosting.NativeMethods.IID_ICLRMetaHost, <br>
&nbsp; &nbsp; &nbsp;out metahostInterface);<br>
<br>
&nbsp;if (metahostInterface == null || !(metahostInterface is Hosting.IClrMetaHost))<br>
&nbsp;{<br>
&nbsp; &nbsp; &nbsp;throw new ApplicationException(&quot;Can not get IClrMetaHost interface.&quot;);<br>
&nbsp;}<br>
<br>
&nbsp;Hosting.IClrMetaHost ClrMetaHost = metahostInterface as Hosting.IClrMetaHost;<br>
&nbsp;StringBuilder buffer=new StringBuilder(1024);<br>
&nbsp;uint bufferLength=1024; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp;ClrMetaHost.GetVersionFromFile(this.ExeFilePath, buffer, ref bufferLength);<br>
&nbsp;string runtimeVersion = buffer.ToString(); </p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
An In-Depth Look into the Win32 Portable Executable File Format<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/magazine/cc301805.aspx">http://msdn.microsoft.com/en-us/magazine/cc301805.aspx</a><br>
<br>
Exploring pe file headers using managed code<br>
<a target="_blank" href="http://blogs.msdn.com/b/kstanton/archive/2004/03/31/105060.aspx">http://blogs.msdn.com/b/kstanton/archive/2004/03/31/105060.aspx</a><br>
<br>
Getting the full display name of an assembly given the path to the manifest file<br>
<a target="_blank" href="http://blogs.msdn.com/b/junfeng/archive/2005/09/13/465373.aspx">http://blogs.msdn.com/b/junfeng/archive/2005/09/13/465373.aspx</a><br>
<br>
IReferenceIdentity Interface<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms231949.aspx">http://msdn.microsoft.com/en-us/library/ms231949.aspx</a><br>
<br>
IIdentityAuthority Interface<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms231265(VS.80).aspx">http://msdn.microsoft.com/en-us/library/ms231265(VS.80).aspx</a><br>
<br>
GetIdentityAuthority Function<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms231607(VS.80).aspx">http://msdn.microsoft.com/en-us/library/ms231607(VS.80).aspx</a><br>
<br>
GetAssemblyIdentityFromFile Function<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms230508.aspx">http://msdn.microsoft.com/en-us/library/ms230508.aspx</a><br>
<br>
CLRCreateInstance Function<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd537633.aspx">http://msdn.microsoft.com/en-us/library/dd537633.aspx</a><br>
<br>
ICLRMetaHost::GetVersionFromFile Method<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd233127.aspx">http://msdn.microsoft.com/en-us/library/dd233127.aspx</a><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
