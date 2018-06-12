# Format volume with VDS (CppVDSFormatVolume)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* WDK
* Windows Driver
## Topics
* VDS
## IsPublished
* True
## ModifiedDate
* 2012-09-03 08:21:58
## Description

<p style="font-family:Courier New">&nbsp;</p>
<h2>CONSOLE APPLICATION : CppVDSFormatVolume Project Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
This sample demonstrates how to use VDS to format volumes.<br>
<br>
Warning: formatting a volume may result in unexpected data loss. &nbsp;Use this <br>
sample with care.<br>
<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
The minimum supported client system of VDS API is Windows Vista. &nbsp;The minimum
<br>
supported server system is Windows Server 2003. <br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
You must run this sample project as administrator. &nbsp;The sample takes the <br>
volume number and the target file system type as user input:<br>
<br>
&nbsp; &nbsp;CppVDSFormatVolume.exe [-options]...<br>
&nbsp; &nbsp; &nbsp;-v &lt;volume number (decimal)&gt; REQUIRED INPUT<br>
&nbsp; &nbsp; &nbsp;-t &lt;target file system type: NTFS, FAT32, etc.&gt; UPPER CASE ONLY, REQUIRED INPUT<br>
&nbsp; &nbsp; &nbsp;e.g.: &nbsp;CppVDSFormatVolume.exe -v 3 -t NTFS <br>
<br>
The sample project tries to find the volume based on the volume number, and <br>
format the volume with the specified file system type.<br>
<br>
To get the volume number of a certain volume (e.g. &quot;E:\&quot;), you can download <br>
and run the sample project &quot;CppVDSQueryVolumes&quot; from All-In-One Code <br>
Framework. CppVDSQueryVolumes lists all volumes in your system and displays <br>
their volume number appended to the Win32 name output:<br>
<br>
&nbsp; &nbsp;Win32 name: \\?\GLOBALROOT\Device\HarddiskVolume&lt;volume number&gt;<br>
<br>
For example, <br>
<br>
&nbsp; &nbsp;Win32 name: \\?\GLOBALROOT\Device\HarddiskVolume5<br>
<br>
Formatting a volume may result in unexpected data loss, so please use this <br>
sample with care. &nbsp;To play with the sample project safely, you may consider <br>
plugging in a useless USB flash drive. Find its volume number using the <br>
CppVDSQueryVolumes sample project. Then pass the volume number to <br>
CppVDSFormatVolume to format the volume. <br>
<br>
&nbsp; &nbsp;CppVDSFormatVolume.exe -v &lt;volume number (decimal)&gt; -t &lt;target file system type e.g. FAT32&gt;<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
The main logic of this code is:<br>
<br>
1. connect to the VDS service<br>
<br>
&nbsp; &nbsp;IVdsServiceLoader *pLoader;<br>
&nbsp; &nbsp;hr = CoCreateInstance(CLSID_VdsLoader,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;NULL,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CLSCTX_LOCAL_SERVER | CLSCTX_REMOTE_SERVER,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;IID_IVdsServiceLoader,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;(void **)&amp;pLoader<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;);<br>
&nbsp; &nbsp;...<br>
&nbsp; &nbsp;IVdsService *pService;<br>
&nbsp;&nbsp;&nbsp;&nbsp;hr = pLoader-&gt;LoadService( L&quot;&quot;, &amp;pService );<br>
&nbsp; &nbsp;...<br>
<br>
2. validate user input<br>
<br>
3. loop over all software providers: basic and dynamic<br>
<br>
&nbsp; &nbsp;IVdsProvider *pProvider;<br>
&nbsp; &nbsp;hr = pUnk-&gt;QueryInterface(IID_IVdsProvider, (void **)&amp;pProvider);<br>
&nbsp;&nbsp;&nbsp;&nbsp;...<br>
&nbsp;&nbsp;&nbsp;&nbsp;VDS_PROVIDER_PROP provProp;<br>
&nbsp; &nbsp;hr = pProvider-&gt;GetProperties(&amp;provProp);<br>
&nbsp; &nbsp;...<br>
&nbsp;&nbsp;&nbsp;&nbsp;IVdsSwProvider *pSwProvider;<br>
&nbsp; &nbsp;hr = pProvider-&gt;QueryInterface(IID_IVdsSwProvider, (void **)&amp;pSwProvider);<br>
&nbsp; &nbsp;...<br>
<br>
4. for a given provider, list the packs and the volumes contained in those packs.<br>
<br>
&nbsp; &nbsp;hr = pPack-&gt;QueryVolumes( &amp;pEnumVolume );<br>
&nbsp;&nbsp;&nbsp;&nbsp;// Get IVdsVolume &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp;IVdsVolume *pVolume;<br>
&nbsp; &nbsp;hr = pVolumeUnk-&gt;QueryInterface(IID_IVdsVolume, (void **)&amp;pVolume);<br>
<br>
5. for each volume, check for the volume number requested in the user input.<br>
<br>
6. if the volume is found, format it with the file system requested in the user input.<br>
<br>
&nbsp; &nbsp;hr = pVolumeMF3-&gt;FormatEx2(wszFsType,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Revision,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; UnitAllocationSize,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Label,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; (DWORD) Options,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &amp;pAsync);<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
The location for complete information on VDS is:<br>
<a href="http://msdn.microsoft.com/en-us/library/dd405618(v=VS.85).aspx" target="_blank">http://msdn.microsoft.com/en-us/library/dd405618(v=VS.85).aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
