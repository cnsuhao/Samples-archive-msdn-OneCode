# Sample StorPort Virtual Miniport (WDKStorPortVirtualMiniport)
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* WDK
* Windows Driver
## Topics
* StorPort virtual miniport
* Host Bus Adapters
## IsPublished
* True
## ModifiedDate
* 2012-12-13 02:00:01
## Description

<p><span style="font-size:16.0pt; line-height:115%">Sample <span class="SpellE">
StorPort</span> Virtual Miniport</span></p>
<div class="WordSection1">
<p>&nbsp;</p>
<p>The sample is a <span class="SpellE">StorPort</span> virtual miniport that presents the appearance of 1 or more
<span class="SpellE">Fibre</span> Channel Host Bus Adapters (HBA). Under an HBA, the sample creates LUNs/disks, which can be formatted and used by a file system such as NTFS.</p>
<p>A <span class="SpellE">StorPort</span> virtual miniport is much like a <span class="SpellE">
StorPort</span> real miniport. A virtual miniport differs in several ways:</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>1.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span>The virtual miniport does not control hardware in a way supported by
<span class="SpellE">StorPort</span>. It may conceivably control hardware by other means.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>2.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span>Since there is no
<span class="SpellE">StorPort</span> support for hardware control, the miniport does not use DMA or DMA operations (via
<span class="SpellE">StorPort</span> <span class="GramE">APIs, that</span> is). There is no Interrupt object or lock.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>3.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span>The miniport can employ any API documented in the WDK for WDM drivers.</p>
<p>A virtual miniport is like a real miniport in important ways:</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>1.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE">StorPort</span> as port driver handles PnP and power operations.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>2.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE">StorPort</span> supports the handling of other I/<span class="SpellE">Os</span> with the miniport&rsquo;s
 support (through callbacks). That handling makes it possible for miniport-provided LUNs to be handled much as any other disk might be handled, including having a drive letter, mounting a file system and doing open, read/write, close and other kinds of I/O.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>3.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE">StorPort</span> handles the details of I/O queuing when and as needed (e.g.,
<span class="GramE">queue depth</span>, pausing, resuming).</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>4.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span>Along with
<span class="SpellE">ClassPnP</span>, <span class="SpellE">StorPort</span> can retry
<span class="GramE">I/<span class="SpellE">Os</span></span>.</p>
<p>The sample assumes some familiarity with <span class="SpellE">StorPort</span> miniports. Sample documentation is minimal, consisting of this file and of comments in the sample&rsquo;s buildable files. The WDK should be studied for more information about
 miniports.</p>
<h3 style="margin-top:30.0pt"><span>The files</span></h3>
<p>These are the sample files, with some important routines or pieces noted:</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>1.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE">mp.c</span></p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>a.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE"><span class="GramE">DriverEntry</span></span><span class="GramE">(</span>)<br>
Gets some resources, call <span class="SpellE">StorPortInitialize</span>().</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>b.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE"><span class="GramE">MpHwFindAdapter</span></span><span class="GramE">(</span>)<br>
Gets more resources, sets configuration parameters.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>c.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE"><span class="GramE">MpHwStartIo</span></span><span class="GramE">(</span>)<br>
Entry point for an I/O. This calls the appropriate support routine, e.g., <span class="SpellE">
<span class="GramE">ScsiExecuteMain</span></span><span class="GramE">(</span>).</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>2.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE">scsi.c</span></p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>a.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE"><span class="GramE">ScsiExecuteMain</span></span><span class="GramE">(</span>)<br>
Handles SCSI SRBs with <span class="SpellE">opcodes</span> needed to support file system operations by calling subroutines. Fails SRBs with other
<span class="SpellE">opcodes</span>.<br>
Note: In a real-world virtual miniport, it may be necessary to handle other <span class="SpellE">
opcodes</span>.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>b.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE"><span class="GramE">ScsiOpInquiry</span></span><span class="GramE">(</span>)<br>
Handles Inquiry, including creating a new LUN as needed.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>c.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE"><span class="GramE">ScsiOpVPD</span></span><span class="GramE">(</span>)<br>
Handles Vital Product Data.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>d.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE"><span class="GramE">ScsiOpRead</span></span><span class="GramE">(</span>)<br>
Beginning of a SCSI Read operation.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>e.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE"><span class="GramE">ScsiOpWrite</span></span><span class="GramE">(</span>)<br>
Beginning of a SCSI Write operation.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>f.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE"><span class="GramE">ScsiReadWriteSetup</span></span><span class="GramE">(</span>)<br>
Sets up a work element for SCSI Read or Write and <span class="SpellE">enqueues</span> the element.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>g.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE"><span class="GramE">ScsiOpReportLuns</span></span><span class="GramE">(</span>)<br>
Handles Report LUNs.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>3.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE">wmi.c</span></p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>a.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE"><span class="GramE">HandleWmiSrb</span></span><span class="GramE">(</span>)<br>
Handles WMI SRBs, possibly by calling a subroutine.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>b.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE"><span class="GramE">QueryWmiDataBlock</span></span><span class="GramE">(</span>)<br>
Supports WMI Query Data Block.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>c.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE"><span class="GramE">ExecuteWmiMethod</span></span><span class="GramE">(</span>)<br>
Supports WMI Execute Method.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>4.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE">utils.c</span></p>
<p style="margin-left:1.0in; text-indent:-.25in"><span><span>a.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE"><span class="GramE">MpQueryRegParameters</span></span><span class="GramE">(</span>)<br>
Does registry lookup of parameters.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>5.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE">WkRtn.c</span></p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:5.0pt; margin-left:1.0in; text-indent:-.25in">
<span><span>a.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE"><span class="GramE">MpGeneralWkRtn</span></span><span class="GramE">(</span>)<br>
Handles queued work elements by calling <span class="SpellE">MpWkRtn</span>.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:5.0pt; margin-left:1.0in; text-indent:-.25in">
<span><span>b.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><span class="SpellE"><span class="GramE">MpWkRtn</span></span><span class="GramE">(</span>)<br>
Handles work elements, completes them.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>6.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>sources: Build directives</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>a.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span>Warning level; optimization level.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>b.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span>Files to build.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>c.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
</span></span>Include and <span class="SpellE">targetlib</span> directories.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>d.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span>WPP directives.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>e.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span>.<span class="SpellE">inx</span> and MOF handling.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>7.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>makefile.inc: More build directives</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>a.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span>Building .<span class="SpellE">inf</span> file.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>b.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span>MOF handling.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>8.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Header files under the <span class="SpellE"><span class="GramE">inc</span></span> subdirectory.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>a.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE"><span class="GramE">mp.h</span></span><br>
Main header file.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>b.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE"><span class="GramE">mpwmi.h</span></span><br>
Generated by build.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>c.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="GramE">trace</span>.<br>
WPP directives.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>d.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><span class="GramE">trcmp.ini</span><br>
More WPP directives.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>9.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE">mp.inx</span>:</p>
<p style="margin-left:.75in"><span class="GramE">Template for building mp.inf.</span> Values under
<span class="SpellE">pnpsafe_isa_addreg</span> cause registry settings.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>a.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE">VirtualDiskSize</span><br>
Size of an in-memory LUN/disk in bytes. If this doesn&rsquo;t match <span class="SpellE">
PhysicalDiskSize</span>, <span class="SpellE">PhysicalDiskSize</span> will override.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>b.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE">PhysicalDiskSize</span><br>
Size of an in-memory LUN/disk in bytes.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>c.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE">NbrLUNsperHBA</span><br>
Number of in-memory LUNs/disks.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>d.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE">CombineVirtDisks</span><br>
Combine the data buffers for in-memory LUNs/disks if set to 1.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>10.<span style="font:7.0pt">&nbsp;&nbsp;
</span></span></span><span class="SpellE">mp.mof</span>: WMI class directives.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in">
MSFC class directives are done by including <span class="SpellE">hbaapi.mof</span>, which isn&rsquo;t in the sample but which should be copied from %<span class="SpellE">WinDir</span>%\system32\<span class="SpellE">wbem</span> on the target system before
 building.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>11.<span style="font:7.0pt">&nbsp;&nbsp;
</span></span></span><span class="SpellE">mp.rc</span>: Resource <span class="GramE">
file</span>, including <span class="SpellE">mp.bmf</span>, the binary (built) form of
<span class="SpellE">mp.mof</span>.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>12.<span style="font:7.0pt">&nbsp;&nbsp;
</span></span></span>ReadMe.htm: This file.</p>
<h3 style="margin-top:30.0pt"><span>Building</span></h3>
<p>The sample should be built with the Win7 WDK (7600.16385.1) or later. One can build for Win2003, Vista/Win2008 or Win7/Win2008 R2, for x86 or x64, for free or checked. (Win8 Developer Preview has been found to work with the sample built for Win7 x64 free.)
 The build should complete without errors or warnings.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>1.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Open a build window.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>2.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Go the sample directory.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>3.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Copy <span class="SpellE">hbaapi.mof</span> from %<span class="SpellE">WinDir</span>%\system32\<span class="SpellE">wbem</span> to the sample directory.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>4.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>For a full build, do <span class="SpellE"><strong>bcz</strong></span>. For a build processing only files changed since the last full build, do
<span class="SpellE"><span class="GramE"><strong>bz</strong></span></span>.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>5.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>If the target system is Win2008 x64 or any later x64 system, the driver binary mp.sys must be signed, e.g., test-signed. Signing is not covered here.</p>
<h3 style="margin-top:30.0pt"><span>Installing</span></h3>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>1.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span>Once the build and signing (if needed) are done, copy these files to the test (<span class="SpellE">debuggee</span>)
 system in a working directory:</p>
<p style="margin-left:1.0in">mp.sys, mp.inf, the appropriate WDF <span class="SpellE">
coinstaller</span> (e.g., WdfCoInstaller01009.dll for WDK 7600) and devcon.exe</p>
<p style="margin-left:.5in">The WDF <span class="SpellE">coinstaller</span> can be found under the appropriate architecture directory in the WDK, e.g., c:\WinDDK\7600.16385.1\redist\wdf\amd64. Similarly, devcon.exe can be found in the WDK, e.g., c:\WinDDK\7600.16385.1\tools\devcon\amd64.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>2.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span>Login to the test system with administrator privileges.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>3.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span>If the driver is test-signed, do
<span class="SpellE"><strong>bcdedit</strong></span><strong> /set <span class="SpellE">
testsigning</span> on</strong> in an elevated window and reboot.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>4.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span>In an elevated window on the test system, where the current directory is the working directory, do
<span class="SpellE"><strong>devcon</strong></span><strong> install mp.inf root\<span class="SpellE"><span class="GramE">mp</span></span></strong><span class="GramE">.</span> If the system is x64 and if the driver binary is test-signed, say OK to the
 prompt to install.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>5.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span>If one wants a second (or third &hellip;) instance of the virtual HBA, repeat step 4) above. (There will not be a prompt
 about installing a test-signed driver on a second or later installation.)</p>
<h3 style="margin-top:30.0pt"><span>Uninstalling</span></h3>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>1.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Login as an administrator to the test system.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>2.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>In an elevated window, do <span class="SpellE"><strong>devcon</strong></span><strong> remove root\<span class="SpellE">mp</span></strong> to uninstall the
<span class="GramE">miniport.</span></p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>3.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>In an elevated window, <span class="GramE">do</span> <span class="SpellE">
<strong>sc</strong></span><strong> delete <span class="SpellE">mp</span> </strong>
to remove the driver service.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>4.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Delete mp.sys from %<span class="SpellE">WinDir</span>%\system32\drivers.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>5.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Reboot.</p>
<h3 style="margin-top:30.0pt"><span>Exercising the sample</span></h3>
<p style="margin-left:.25in">The following assumes that the test system is Win7/Win2008 R2 and that one or more instances of the virtual HBA have been installed (see
<a href="#Install">installation by <span class="SpellE">devcon</span></a>).</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>1.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Login as an administrator to the test system.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>2.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Start Device Manager (e.g., <span class="SpellE">diskmgmt.msc</span>).</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>a.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span>On one of the miniport&rsquo;s LUNs, where the disk is described as &ldquo;Unknown,&rdquo; right-click and choose Online.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>b.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span>Right-click again in the same place and choose Initialize Disk.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>c.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span>Right-click on the same disk, where the
<span class="GramE">disk is described as &ldquo;Unallocated,&rdquo; and choose</span> New Simple Volume. Follow the instructions.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>d.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span>Right-click on the same disk, where &ldquo;New Volume&rdquo; is shown, and
<span class="GramE">choose</span> Explore, to start Windows Explorer on the newly formatted disk.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>3.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Start Windows Explorer</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>a.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span>Create a directory.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>b.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span>Under that directory, create a file.</p>
<p style="margin-top:.25in; margin-right:0in; margin-bottom:6.0pt; margin-left:.5in; text-indent:-.25in">
<span><span>4.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
</span></span>Start Storage Explorer (<span class="SpellE">StorExpl.msc</span>). The miniport will appear under the Servers node. (Note: The miniport will not appear under
<span class="SpellE">Fibre</span> Channel Fabrics.)</p>
<p style="margin-top:6.0pt; margin-right:0in; margin-bottom:12.0pt; margin-left:.5in; text-indent:-.25in">
<span><span>5.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
</span></span>In an elevated window, start wbemtest.exe.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>a.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span>Click on Connect and connect to root\WMI.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>b.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span>Click on
<span class="SpellE">Enum</span> Classes and click OK.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>c.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
</span></span>Scroll down to the MSFC classes. Choose one, such as <span class="SpellE">
MSFC_FibrePortHBAAttributes</span>.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>d.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span>Click on Instances.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>e.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span>Double-click on an instance.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>f.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span>Click on Show MOF and examine the data.</p>
<h3 style="margin-top:30.0pt"><span>High-level logic</span></h3>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>1.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE"><span class="GramE">DriverEntry</span></span><span class="GramE">(</span>) gets control because the
 miniport is a WDM driver for the FDO device object enumerated off the PnP root. <span class="SpellE">
<span class="GramE">DriverEntry</span></span><span class="GramE">(</span>) calls
<span class="SpellE">StorPortInitialize</span>() with initial configuration parameters.
<span class="SpellE">StorPort</span> takes over the miniport&rsquo;s entry points defined in the driver object, e.g.,
<span class="SpellE">AddDevice</span> and <span class="SpellE">InternalDeviceIoControl</span> (IRP_MJ_SCSI).</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>2.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE"><span class="GramE">MpHwFindAdapter</span></span><span class="GramE">(</span>) gets control
 as part of the initialization of a virtual HBA. (There is 1 virtual HBA for each installed instance of the miniport.) More configuration parameters are set.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>3.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE"><span class="GramE">MpHwStartIo</span></span><span class="GramE">(</span>) gets control for
 an I/O in the form of a SCSI Request Block (SRB). The routine calls appropriate subroutines.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>a.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE"><span class="GramE">ScsiExecuteMain</span></span><span class="GramE">(</span>) is the subroutine called for SCSI-type (SRB_FUNCTION_EXECUTE_SCSI)
 SRBs.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.5in; text-indent:-1.5in">
<span><span><span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>i.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE"><span class="GramE">ScsiOpRead</span></span><span class="GramE">(</span>) and
<span class="SpellE">ScsiOpWrite</span>() are called for SCSI Read and Write, respectively. Each calls
<span class="SpellE"><span class="GramE">ScsiReadWriteSetup</span></span><span class="GramE">(</span>).</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.5in; text-indent:-1.5in">
<span><span><span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>ii.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE"><span class="GramE">ScsiReadWriteSetup</span></span><span class="GramE">(</span>) creates a work element and
<span class="SpellE">enqueues</span> it.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.5in; text-indent:-1.5in">
<span><span><span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>iii.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><span class="SpellE"><span class="GramE">MpGeneralWkRtn</span></span><span class="GramE">(</span>), running under a kernel-mode thread in System,
<span class="SpellE">dequeues</span> a work element, does the work and calls <span class="SpellE">
StorPortNotification</span>() to complete the I/O.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>b.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><span class="SpellE"><span class="GramE">HandleWmiSrb</span></span><span class="GramE">(</span>) is the subroutine called for WMI-type (SRB_FUNCTION_WMI) SRBs.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:1.0in; text-indent:-.25in">
<span><span>c.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
</span></span><span class="SpellE"><span class="GramE">MpHwHandlePnP</span></span><span class="GramE">(</span>) is the subroutine called for PnP-type (SRB_FUNCTION_PNP) SRBs.</p>
<p style="margin-top:12.0pt; margin-right:0in; margin-bottom:.0001pt; margin-left:.5in">
<span class="SpellE"><span class="GramE">MpHwStartIo</span></span><span class="GramE">(</span>) completes the I/O if it is not completed elsewhere.</p>
<p style="margin-top:12.0pt; margin-right:0in; margin-bottom:.0001pt; margin-left:.5in; text-indent:-.25in">
<span><span>4.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span><span class="SpellE"><span class="GramE">MpHwFreeAdapterResources</span></span><span class="GramE">(</span>) gets control when the virtual HBA is being removed (Remove
 Device IRP).</p>
<h3 style="margin-top:30.0pt"><span>Notes</span></h3>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>1.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span>The backing store for the LUNs is virtual memory. Consequently the contents are lost upon reboot or upon disabling the
 HBA.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>2.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span>Because there is no DMA object,
<span class="SpellE">BuildIo</span>, Interrupt and DPC callbacks from <span class="SpellE">
StorPort</span> won&rsquo;t get control.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>3.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span>The sample has support for MPIO testing in that it allows 2 (or more) virtual HBAs to share buffers for each LUN presented.
 It is probably best to ignore this feature, which was developed for certain tests. This feature is retained for completeness, but the file
<span class="SpellE">mp.inx</span> does not create the registry flag needed to bring MPIO support into play.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>4.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span>Support for virtual miniports was introduced as an update in Win2003 SP1; refer to
<a href="http://support.microsoft.com/?kbid=943295">http://support.microsoft.com/?kbid=943295</a>.</p>
<p style="margin-left:.5in; text-indent:-.25in"><span><span>5.<span style="font:7.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></span>WPP tracing is supported. To get verbose tracing, do (in an elevated window beginning with Vista):
<span class="SpellE"><strong>tracelog</strong></span><strong> /start <span class="SpellE">
myMPTrace</span> /<span class="SpellE">guid</span> #C689C5E6-5219-4774-BE15-9B1F92F949FD /f
<span class="SpellE">tracelogoutMP</span> /flags 0xFFFF /level 5 /min 32 /max 64 /<span class="SpellE">UseSystemTime</span> /b 2048</strong><span>&nbsp;</span></p>
<p style="margin-left:.5in; text-indent:-.25in"><span><br>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
</div>
