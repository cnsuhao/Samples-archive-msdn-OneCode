# Use PowerShell & other techs to manage NAV Services (CSDynamicsPowerShellAdmin)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Dynamics
## Topics
* Powershell
* NAV
* Dynamics NAV Web Services
## IsPublished
* True
## ModifiedDate
* 2011-11-01 06:48:31
## Description

<h1>Microsoft Dynamics NAV APPLICATION: CSDynamicsPowerShellAdmin</h1>
<h2>Introduction</h2>
<p>This sample uses PowerShell to list and manage NAV Services:<br>
&nbsp; - List NAV Services<br>
&nbsp; - Start and stop services<br>
&nbsp; - Enter the name of a remote computer to manager NAV Services on that computer</p>
<p>The sample also uses xml to show and update CustomSettings.config.</p>
<p>The purpose of this sample is to illustrate how to use PowerShell and other technologies for managing NAV Services. It is on purpose developed to be just about useful as it is, but with lots of scope for further development.</p>
<p><br>
The definition of a NAV Service for this purpose is a service where the name of the executable contains &quot;Dynamics.Nav&quot;, and it is assumed that any such service is a Dynamics NAV2009 middle-tier Service for connections from either RoleTailored Client or NAV
 Web Services.</p>
<h2><span style="font-size:medium">Demo</span></h2>
<p>The solution in this sample consists of a form with the following functionality:</p>
<p><strong>Step1.</strong> Click &quot;Get NAV Services&quot; to list the NAV Services running on the local machine.</p>
<p><strong>Step2.</strong> Enter a ComputerName in &quot;NAV Server Name&quot; and then click the same button to list&nbsp;NAV Services on a remote computer.</p>
<p><strong>Step3.</strong> Select a NAV Service from the list, then click Start/Stop to start or stop that&nbsp;service. Note: This part of the sample requires that you first build the project,&nbsp;then run it as Administrator.</p>
<p><strong>Step4.</strong> Select a NAV Service from the list, then click &quot;Get Config&quot; to get selected values&nbsp;from CustomSettings.config belonging to that NAV Service.</p>
<p><strong>Step5.</strong> After &quot;Get Config&quot;, overwrite any of the values, then click &quot;Update Config&quot; to&nbsp;save those to CustomSettings.config.</p>
<p>&nbsp;</p>
<p><span style="font-size:medium; font-weight:bold">Implementation</span></p>
<p>Functionalities demonstrated in this sample:</p>
<p>Step1. List NAV Services, either on local machine or on a remote machine.</p>
<p>Step2. Start and stop any of the services listed.</p>
<p>Step3. View and update values from CustomSettings.config for the selected NAV Service.</p>
<p><span style="font-size:small; font-weight:bold">&nbsp;</span></p>
<p><span style="font-size:medium; font-weight:bold">References</span></p>
<p>Further information and samples for coding with NAV and PowerShell:</p>
<p>C# app invokes PowerShell script (CSPowerShell)<br>
<a href="http://code.msdn.microsoft.com/CSPowerShell-1f44f80dNAV">http://code.msdn.microsoft.com/CSPowerShell-1f44f80d</a><a href="http://code.msdn.microsoft.com/CSPowerShell-1f44f80dNAV"></a></p>
<p>Team Blog<br>
<a href="http://blogs.msdn.com/b/nav">http://blogs.msdn.com/b/nav</a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
