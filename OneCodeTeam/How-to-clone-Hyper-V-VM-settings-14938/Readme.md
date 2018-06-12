# How to clone Hyper-V VM settings
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* .NET Development
## Topics
* Hyper-V
* VM
## IsPublished
* True
## ModifiedDate
* 2013-09-05 12:14:06
## Description

<h1>Clone Hyper-V VM Settings (CSHyperVCloneVM)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to create VM from an existing VM template without copying the VHD file.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">To run the sample, modify the below function call in the <span class="GramE">
Main(</span>) method with suitable values (The name of the template VM, Target directory for the newly created VM and the number of VM) and build using Visual Studio. As of now the sample creates VMs with name VMCopy0, VmCopy1<span class="GramE">,VMCopy2</span>,
 etc., <span style="">&nbsp;</span>and the Target directory should not already contain folders with newly created VM names. Once the sample is built you should execute it under
<b style="">elevated privilege</b>.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Input the name of the VM and the directory path where the clones VMs 
// may be stored and number of VM to be created
ExportVirtualSystemEx.CloneVirtualSystemEx(&quot;VMCopy0&quot;, &quot;C:\\TempVm&quot;, 10);

</pre>
<pre id="codePreview" class="csharp">
// Input the name of the VM and the directory path where the clones VMs 
// may be stored and number of VM to be created
ExportVirtualSystemEx.CloneVirtualSystemEx(&quot;VMCopy0&quot;, &quot;C:\\TempVm&quot;, 10);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>Using the Code</h2>
<p class="MsoNormal">You can use this project to programmatically clone VMs without copying VHD.<span style="">&nbsp;&nbsp;
</span>This is done by renaming a VM to a new VM, then exporting it and importing it back.<span style="">&nbsp;
</span>Once the importing is done, rename the source VM to its original name.<span style="">&nbsp;
</span>The code logic is implemented in the function ExportVirtualSystemEx.CloneVirtualSystemEx.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
/// This function is the entry point for Creating VMs by copying the settings from 
/// an existing template VM. The function actually renames a VM to a new VM then 
/// export it and then import it back. Once the importing is done, rename the 
/// source vm to its original name
/// &lt;/summary&gt;
/// &lt;param name=&quot;vmName&quot;&gt;Template VM&lt;/param&gt;
/// &lt;param name=&quot;exportDirectory&quot;&gt;
/// Name of the directory where the VMs are stored
/// &lt;/param&gt;
/// &lt;&lt;param name=&quot;nMachines&quot;&gt;Number of  VMs to be created&lt;/param&gt;
public static void CloneVirtualSystemEx(string vmName, string exportDirectory, int nMachines)
{
    ManagementScope scope = new ManagementScope(@&quot;root\virtualization&quot;, null);
    ManagementObject virtualSystemService = Utility.GetServiceObject(scope, 
        &quot;Msvm_VirtualSystemManagementService&quot;);
    ManagementObject vm = Utility.GetTargetComputer(vmName, scope);
    ManagementObject settingData = null;
    ManagementObjectCollection settingsData;
    ManagementBaseObject inParams = null;
    ManagementBaseObject outParams = null;


    //Loop to create as many VMs required (Time being it is 10)
    for (int i = 0; i &lt; nMachines; i&#43;&#43;)
    {
        string strNewName = &quot;VMCopy&quot; &#43; i.ToString(); //Name of the newly creating VM


        //Retrieving the input parameters for 
        //Msvm_VirtualSystemManagementService::ModifyVirtualSystem() method
        inParams = virtualSystemService.GetMethodParameters(&quot;ModifyVirtualSystem&quot;);


        inParams[&quot;ComputerSystem&quot;] = vm.Path.Path;


        //Retrieving the virtualization-specific settings the vm using the associator class Msvm_SettingsDefineState.
        settingsData = vm.GetRelated(&quot;Msvm_VirtualSystemSettingData&quot;,
            &quot;Msvm_SettingsDefineState&quot;, 
            null,
            null,
            &quot;SettingData&quot;,
            &quot;ManagedElement&quot;,
            false,
            null);


        foreach (ManagementObject data in settingsData)
        {
            settingData = data;
        }


        //Temporarily renaming the source vm
        settingData[&quot;ElementName&quot;] = strNewName;


        inParams[&quot;SystemsettingData&quot;] = settingData.GetText(TextFormat.CimDtd20);


        //Invoking the method to rename the vm
        outParams = virtualSystemService.InvokeMethod(&quot;ModifyVirtualSystem&quot;, inParams, null);


        if ((UInt32)outParams[&quot;ReturnValue&quot;] == ReturnCode.Started)
        {
            if (Utility.JobCompleted(outParams, scope))
            {
                Console.WriteLine(&quot;VM '{0}' was renamed successfully.&quot;, vm[&quot;ElementName&quot;]);
            }
            else
            {
                Console.WriteLine(&quot;Failed to Modify VM&quot;);
            }
        }
        else if ((UInt32)outParams[&quot;ReturnValue&quot;] == ReturnCode.Completed)
        {
            Console.WriteLine(&quot;VM '{0}' was renamed successfully.&quot;, vm[&quot;ElementName&quot;]);
        }
        else
        {
            Console.WriteLine(&quot;Failed to modify VM. Error {0}&quot;, outParams[&quot;ReturnValue&quot;]);
        }


        //Start exporting the renamed VM
        inParams = virtualSystemService.GetMethodParameters(&quot;ExportVirtualSystemEx&quot;);


        inParams[&quot;ComputerSystem&quot;] = vm.Path.Path;


        if (!Directory.Exists(exportDirectory))
        {
            Directory.CreateDirectory(exportDirectory);
        }
        inParams[&quot;ExportDirectory&quot;] = exportDirectory;
        inParams[&quot;ExportSettingData&quot;] = GetVirtualSystemExportSettingDataInstance(scope);


        outParams = virtualSystemService.InvokeMethod(&quot;ExportVirtualSystemEx&quot;, inParams, null);


        if ((UInt32)outParams[&quot;ReturnValue&quot;] == ReturnCode.Started)
        {
            if (Utility.JobCompleted(outParams, scope))
            {
                Console.WriteLine(&quot;VM '{0}' were exported successfully.&quot;, vm[&quot;ElementName&quot;]);
            }
            else
            {
                Console.WriteLine(&quot;Failed to export VM&quot;);
            }
        }
        else if ((UInt32)outParams[&quot;ReturnValue&quot;] == ReturnCode.Completed)
        {
            Console.WriteLine(&quot;VM '{0}' were exported successfully.&quot;, vm[&quot;ElementName&quot;]);
        }
        else
        {
            Console.WriteLine(&quot;Export virtual system failed with error:{0}&quot;, outParams[&quot;ReturnValue&quot;]);
        }


        inParams.Dispose();
        outParams.Dispose();


        ImportVirtualSystemEx(exportDirectory &#43; &quot;\\&quot; &#43; strNewName, strNewName);
    }


    //Now setting the name of source vm to its original name
    settingData = null;
    settingsData = vm.GetRelated(&quot;Msvm_VirtualSystemSettingData&quot;,
        &quot;Msvm_SettingsDefineState&quot;,
        null,
        null,
        &quot;SettingData&quot;,
        &quot;ManagedElement&quot;,
        false,
        null);
    inParams = virtualSystemService.GetMethodParameters(&quot;ModifyVirtualSystem&quot;);


    inParams[&quot;ComputerSystem&quot;] = vm.Path.Path;


    foreach (ManagementObject data in settingsData)
    {
        settingData = data;
    }


    settingData[&quot;ElementName&quot;] = vmName;


    inParams[&quot;SystemsettingData&quot;] = settingData.GetText(TextFormat.CimDtd20);


    outParams = virtualSystemService.InvokeMethod(&quot;ModifyVirtualSystem&quot;, inParams, null);


    if ((UInt32)outParams[&quot;ReturnValue&quot;] == ReturnCode.Started)
    {
        if (Utility.JobCompleted(outParams, scope))
        {
            Console.WriteLine(&quot;VM '{0}' was renamed successfully.&quot;, vm[&quot;ElementName&quot;]);
        }
        else
        {
            Console.WriteLine(&quot;Failed to Modify VM&quot;);
        }
    }
    else if ((UInt32)outParams[&quot;ReturnValue&quot;] == ReturnCode.Completed)
    {
        Console.WriteLine(&quot;VM '{0}' was renamed successfully.&quot;, vm[&quot;ElementName&quot;]);
    }
    else
    {
        Console.WriteLine(&quot;Failed to modify VM. Error {0}&quot;, outParams[&quot;ReturnValue&quot;]);
    }


    vm.Dispose();
    virtualSystemService.Dispose();
}

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
/// This function is the entry point for Creating VMs by copying the settings from 
/// an existing template VM. The function actually renames a VM to a new VM then 
/// export it and then import it back. Once the importing is done, rename the 
/// source vm to its original name
/// &lt;/summary&gt;
/// &lt;param name=&quot;vmName&quot;&gt;Template VM&lt;/param&gt;
/// &lt;param name=&quot;exportDirectory&quot;&gt;
/// Name of the directory where the VMs are stored
/// &lt;/param&gt;
/// &lt;&lt;param name=&quot;nMachines&quot;&gt;Number of  VMs to be created&lt;/param&gt;
public static void CloneVirtualSystemEx(string vmName, string exportDirectory, int nMachines)
{
    ManagementScope scope = new ManagementScope(@&quot;root\virtualization&quot;, null);
    ManagementObject virtualSystemService = Utility.GetServiceObject(scope, 
        &quot;Msvm_VirtualSystemManagementService&quot;);
    ManagementObject vm = Utility.GetTargetComputer(vmName, scope);
    ManagementObject settingData = null;
    ManagementObjectCollection settingsData;
    ManagementBaseObject inParams = null;
    ManagementBaseObject outParams = null;


    //Loop to create as many VMs required (Time being it is 10)
    for (int i = 0; i &lt; nMachines; i&#43;&#43;)
    {
        string strNewName = &quot;VMCopy&quot; &#43; i.ToString(); //Name of the newly creating VM


        //Retrieving the input parameters for 
        //Msvm_VirtualSystemManagementService::ModifyVirtualSystem() method
        inParams = virtualSystemService.GetMethodParameters(&quot;ModifyVirtualSystem&quot;);


        inParams[&quot;ComputerSystem&quot;] = vm.Path.Path;


        //Retrieving the virtualization-specific settings the vm using the associator class Msvm_SettingsDefineState.
        settingsData = vm.GetRelated(&quot;Msvm_VirtualSystemSettingData&quot;,
            &quot;Msvm_SettingsDefineState&quot;, 
            null,
            null,
            &quot;SettingData&quot;,
            &quot;ManagedElement&quot;,
            false,
            null);


        foreach (ManagementObject data in settingsData)
        {
            settingData = data;
        }


        //Temporarily renaming the source vm
        settingData[&quot;ElementName&quot;] = strNewName;


        inParams[&quot;SystemsettingData&quot;] = settingData.GetText(TextFormat.CimDtd20);


        //Invoking the method to rename the vm
        outParams = virtualSystemService.InvokeMethod(&quot;ModifyVirtualSystem&quot;, inParams, null);


        if ((UInt32)outParams[&quot;ReturnValue&quot;] == ReturnCode.Started)
        {
            if (Utility.JobCompleted(outParams, scope))
            {
                Console.WriteLine(&quot;VM '{0}' was renamed successfully.&quot;, vm[&quot;ElementName&quot;]);
            }
            else
            {
                Console.WriteLine(&quot;Failed to Modify VM&quot;);
            }
        }
        else if ((UInt32)outParams[&quot;ReturnValue&quot;] == ReturnCode.Completed)
        {
            Console.WriteLine(&quot;VM '{0}' was renamed successfully.&quot;, vm[&quot;ElementName&quot;]);
        }
        else
        {
            Console.WriteLine(&quot;Failed to modify VM. Error {0}&quot;, outParams[&quot;ReturnValue&quot;]);
        }


        //Start exporting the renamed VM
        inParams = virtualSystemService.GetMethodParameters(&quot;ExportVirtualSystemEx&quot;);


        inParams[&quot;ComputerSystem&quot;] = vm.Path.Path;


        if (!Directory.Exists(exportDirectory))
        {
            Directory.CreateDirectory(exportDirectory);
        }
        inParams[&quot;ExportDirectory&quot;] = exportDirectory;
        inParams[&quot;ExportSettingData&quot;] = GetVirtualSystemExportSettingDataInstance(scope);


        outParams = virtualSystemService.InvokeMethod(&quot;ExportVirtualSystemEx&quot;, inParams, null);


        if ((UInt32)outParams[&quot;ReturnValue&quot;] == ReturnCode.Started)
        {
            if (Utility.JobCompleted(outParams, scope))
            {
                Console.WriteLine(&quot;VM '{0}' were exported successfully.&quot;, vm[&quot;ElementName&quot;]);
            }
            else
            {
                Console.WriteLine(&quot;Failed to export VM&quot;);
            }
        }
        else if ((UInt32)outParams[&quot;ReturnValue&quot;] == ReturnCode.Completed)
        {
            Console.WriteLine(&quot;VM '{0}' were exported successfully.&quot;, vm[&quot;ElementName&quot;]);
        }
        else
        {
            Console.WriteLine(&quot;Export virtual system failed with error:{0}&quot;, outParams[&quot;ReturnValue&quot;]);
        }


        inParams.Dispose();
        outParams.Dispose();


        ImportVirtualSystemEx(exportDirectory &#43; &quot;\\&quot; &#43; strNewName, strNewName);
    }


    //Now setting the name of source vm to its original name
    settingData = null;
    settingsData = vm.GetRelated(&quot;Msvm_VirtualSystemSettingData&quot;,
        &quot;Msvm_SettingsDefineState&quot;,
        null,
        null,
        &quot;SettingData&quot;,
        &quot;ManagedElement&quot;,
        false,
        null);
    inParams = virtualSystemService.GetMethodParameters(&quot;ModifyVirtualSystem&quot;);


    inParams[&quot;ComputerSystem&quot;] = vm.Path.Path;


    foreach (ManagementObject data in settingsData)
    {
        settingData = data;
    }


    settingData[&quot;ElementName&quot;] = vmName;


    inParams[&quot;SystemsettingData&quot;] = settingData.GetText(TextFormat.CimDtd20);


    outParams = virtualSystemService.InvokeMethod(&quot;ModifyVirtualSystem&quot;, inParams, null);


    if ((UInt32)outParams[&quot;ReturnValue&quot;] == ReturnCode.Started)
    {
        if (Utility.JobCompleted(outParams, scope))
        {
            Console.WriteLine(&quot;VM '{0}' was renamed successfully.&quot;, vm[&quot;ElementName&quot;]);
        }
        else
        {
            Console.WriteLine(&quot;Failed to Modify VM&quot;);
        }
    }
    else if ((UInt32)outParams[&quot;ReturnValue&quot;] == ReturnCode.Completed)
    {
        Console.WriteLine(&quot;VM '{0}' was renamed successfully.&quot;, vm[&quot;ElementName&quot;]);
    }
    else
    {
        Console.WriteLine(&quot;Failed to modify VM. Error {0}&quot;, outParams[&quot;ReturnValue&quot;]);
    }


    vm.Dispose();
    virtualSystemService.Dispose();
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2></h2>
<h2>More Information</h2>
<p class="MsoNormal">For more information on Hyper-V virtualization classes <a href="http://msdn.microsoft.com/en-us/library/cc136986.aspx">
http://msdn.microsoft.com/en-us/library/cc136986.aspx</a> </p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
