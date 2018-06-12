# Enumerate and interface with volumes on a system with VDS (CppVDSQueryVolumes)
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
* 2012-09-03 08:21:14
## Description

<p style="font-family:Courier New">&nbsp;</p>
<h2>CONSOLE APPLICATION : CppVDSQueryVolumes Project Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
This sample demonstrates how to use VDS to enumerate and interface with <br>
volumes on a system.<br>
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
The code sample must be run as administrator. Otherwise, the sample project <br>
will output the following error, which means COR_E_UNAUTHORIZEDACCESS.<br>
&nbsp; &nbsp;LoadService failed: hr=80070005<br>
<br>
This sample takes no user input, it is executed as just the name of the app, <br>
and the result is a list of volumes, their properties, and the disk extents <br>
that back the volume. &nbsp;Here is an example output of the sample.<br>
<br>
&nbsp; &nbsp;Provider #: 1 name: Microsoft Virtual Disk Service Dynamic Provider<br>
&nbsp; &nbsp;Pack #: 1<br>
&nbsp; &nbsp;Provider #: 2 name: Microsoft Virtual Disk Service Basic Provider<br>
&nbsp; &nbsp;Pack #: 1<br>
&nbsp; &nbsp;Volume #: 1<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Volume Id: {619631A8-8F87-4AB0-B769-78B84A9D10DC}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Type: SIMPLE<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Status: NO_MEDIA<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Health: HEALTHY<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TransitionState: STABLE<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Size: 0<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Flags: 2000<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Recommended file system: UNKNOWN<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Win32 name: \\?\GLOBALROOT\Device\CdRom0<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;... dumping disk extents ...<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Number of extents: 1<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Extent #1:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Disk Id: {F10B8064-B7B2-47D8-BE1C-447854AFE575}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;type: UNKNOWN<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Offset: 0<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Size: 0<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Volume Id: {619631A8-8F87-4AB0-B769-78B84A9D10DC}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Plex Id: {29DFC345-559F-47B5-98F0-1BB796561A8F}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Member Id: 0<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;GetFileSystemProperties failed: hr=80042412<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Number of access paths: 1<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;E:\<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Number of reparse points: 0<br>
&nbsp; &nbsp;Pack #: 2<br>
&nbsp; &nbsp;Volume #: 1<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Volume Id: {EAEC0907-CEC1-49B8-AC5E-AAE7B31BDD25}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Type: SIMPLE<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Status: ONLINE<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Health: HEALTHY<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TransitionState: STABLE<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Size: 104857600<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Flags: a0465<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Recommended file system: NTFS<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Win32 name: \\?\GLOBALROOT\Device\HarddiskVolume1<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;... dumping disk extents ...<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Number of extents: 1<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Extent #1:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Disk Id: {51662905-42AF-49D2-9B28-CC151F6F4F61}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;type: DATA<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Offset: 1048576<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Size: 104857600<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Volume Id: {EAEC0907-CEC1-49B8-AC5E-AAE7B31BDD25}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Plex Id: {ABA368A2-3695-4E8B-B9FC-9253BFF8326B}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Member Id: 0<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;File System: NTFS<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Flags: 0<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AllocationUnitSize: 4096<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TotalAllocationUnits: 25599<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AvailableAllocationUnits: 18399<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Label: System Reserved<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Number of access paths: 0<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Number of reparse points: 0<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;File system type: NTFS<br>
&nbsp; &nbsp;......<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
The main logic of this code is:<br>
<br>
1. connect to the VDS service<br>
2. loop over all software providers: basic and dynamic<br>
3. for a given provider, list the packs and the volumes contained in those packs.<br>
4. for each volume, provide the properties of the volume<br>
5. for each volume display the file system information.<br>
6. for each volume list the disk extents backing the volume<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
The location for complete information on VDS is:<br>
<a href="http://msdn.microsoft.com/en-us/library/bb986750.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/bb986750.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
