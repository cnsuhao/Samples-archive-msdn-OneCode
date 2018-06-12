# Virtual Volume Driver (WDKVirtualVolume)
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* WDK
* Windows Driver
## Topics
* Virtual Device Driver
* Virtual Volume
## IsPublished
* True
## ModifiedDate
* 2012-12-13 02:00:17
## Description

<div class="WordSection1"></div>
<h1 class="WordSection1">VIRTUAL DEVICE DRIVER (WDKVirtualVolume)</h1>
<div class="WordSection1"></div>
<h2 class="WordSection1">Introduction</h2>
<div class="WordSection1"></div>
<p class="WordSection1">This is the Virtvol sample driver.&nbsp; This version of the driver has been modified to support the driver frameworks. This driver basically creates a nonpaged pool and exposes that as a storage media. User can find the device in
 the disk manager and format the media to use as FAT or NTFS volume. In addition, Virtvol integrates with Mount Manager, so that it is not necessary for you to assign a drive letter, the system will do this automatically.</p>
<div class="WordSection1"></div>
<h2 class="WordSection1">Running the Sample</h2>
<div class="WordSection1"></div>
<p class="WordSection1">First, you should build this sample as normal. Then please follow the following steps to install this driver:</p>
<div class="WordSection1"></div>
<div class="WordSection1">
<ol>
<li>Copy inf and sys files to directory </li><li>Copy Wdf DLL to same directory </li><li>Open device manager. </li><li>Right-click on machine name and pick Add Legacy Hardware </li><li>Install manually </li><li>Have Disk, navigate to directory and install. </li><li>Done. </li></ol>
</div>
<p>Alternatively, you can copy the files over as above and then run devcon.exe: DEVCON.EXE INSTALL virtvol.inf virtvol</p>
<p>The devcon.exe application can be found in the WDK in the tools directory.</p>
<p>Finally, please validate if you&rsquo;ve installed the driver successfully.</p>
<p class="MsoNormal"><span><img src="http://i1.code.msdn.s-msft.com/wdkramdisk-c3322885/image/file/49528/1/image001.png" alt="" width="996" height="408"></span></p>
<p class="MsoNormal"><img src="http://i1.code.msdn.s-msft.com/wdkramdisk-c3322885/image/file/49529/1/image002.png" alt="" width="788" height="500">&nbsp;&nbsp;</p>
<p class="MsoNormal"><strong>Remove devices:</strong></p>
<p>You can run devcon.exe: <strong>DEVCON.EXE -remove virtvol.inf virtvol </strong>
to remove the devices.</p>
<p>&nbsp;</p>
<h2>Using the Code</h2>
<p>The main logic of this code is:</p>
<ol>
<li>Add a single instance of a VirtVol to the system. </li><li>Register with the mount manager the existence of this volume. </li><li>Locate the drive by observing File Explorer. </li><li>Use the volume as-is. </li></ol>
<h2>More Information</h2>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span>The location for complete information on
 the KMDF framework is:<br>
<a href="http://msdn.microsoft.com/en-us/windows/hardware/gg463279">http://msdn.microsoft.com/en-us/windows/hardware/gg463279</a></p>
<p class="MsoListParagraph" style="text-indent:-.25in">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; The location of how to interact with the mount manager is:<br>
<a href="http://msdn.microsoft.com/en-us/library/windows/hardware/ff562298(v=VS.85).aspx">http://msdn.microsoft.com/en-us/library/windows/hardware/ff562298(v=VS.85).aspx</a></p>
<p style="text-indent:-0.25in; margin-left:0.5in"><span><br>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
<p class="MsoListParagraph" style="text-indent:-.25in">&nbsp;</p>
