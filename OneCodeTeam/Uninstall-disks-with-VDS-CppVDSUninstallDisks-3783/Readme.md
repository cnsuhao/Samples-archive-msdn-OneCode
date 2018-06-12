# Uninstall disks with VDS (CppVDSUninstallDisks)
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
* 2012-09-03 08:21:32
## Description

<p style="font-family:Courier New">&nbsp;</p>
<h2>CONSOLE APPLICATION : CppVDSUninstallDisks Project Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
This sample demonstrates how to use VDS to uninstall disks and volumes.<br>
<br>
Warning: uninstalling a disk may lead to potential data loss. &nbsp;Use this <br>
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
This sample takes the disk number performs a complete uninstall, including the <br>
dismount of the volume and uninstall underlying disks.<br>
<br>
To use this sample you will need to provide the disk number for input. <br>
This can be found by right clicking on my computer choosing manage, once the <br>
Manage UI is open choose Disk Management and look for the TEST disk that you <br>
wish to uninstall. &nbsp;The number associated with this TEST disk will be the input
<br>
parameter. &nbsp;After you run the sample this TEST disk should disappear from Disk<br>
Management. &nbsp;If you are not using VHD's for this test you will need to reboot<br>
your system for the disk to be recognized by Disk Management.<br>
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
&nbsp; &nbsp;hr = pService-&gt;QueryProviders(VDS_QUERY_SOFTWARE_PROVIDERS, &amp;pEnum );<br>
&nbsp; &nbsp;hr = pUnk-&gt;QueryInterface(IID_IVdsProvider, (void **)&amp;pProvider);<br>
&nbsp; &nbsp;IVdsSwProvider *pSwProvider;<br>
&nbsp; &nbsp;hr = pProvider-&gt;QueryInterface(IID_IVdsSwProvider, (void **)&amp;pSwProvider);<br>
<br>
4. for a given provider, list the packs and the disks contained in those packs.<br>
<br>
&nbsp; &nbsp;hr = pSwProvider-&gt;QueryPacks(&amp;pEnumPack);<br>
<br>
5. for each disk, check for the disk number requested in the user input.<br>
<br>
&nbsp; &nbsp;hr = pPack-&gt;QueryDisks(&amp;pEnumDisk);<br>
&nbsp; &nbsp;hr = GetDiskIds(pEnumDisk, bVerbose, &amp;pDiskArray, ulDisk);<br>
<br>
6. if the disk is found, uninstall it.<br>
<br>
&nbsp; &nbsp;hr = pService-&gt;QueryInterface(<br>
&nbsp; &nbsp; &nbsp; &nbsp;IID_IVdsServiceUninstallDisk, <br>
&nbsp; &nbsp; &nbsp; &nbsp;(void **)&amp;pUninstallIntf<br>
&nbsp; &nbsp; &nbsp; &nbsp;);<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
The location for complete information on VDS is:<br>
<a href="http://msdn.microsoft.com/en-us/library/aa382815(v=VS.85).aspx" target="_blank">http://msdn.microsoft.com/en-us/library/aa382815(v=VS.85).aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
