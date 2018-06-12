/****************************** Module Header ******************************\
Module Name:  ExportVirtualSystemEx.cs
Project:      CSHyperVCloneVM
Copyright (c) Microsoft Corporation.

The class provides function for creating VMs by copying the settings from 
an existing template VM. The function actually renames a VM to a new VM then 
export it and then import it back. Once the importing is done, rename the 
source vm to its original name.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Management;
using System.IO;


namespace CSHyperVCloneVM
{
    class ExportVirtualSystemEx
    {
        /// <summary>
        /// Creates Msvm_VirtualSystemExportSettingData object to be used with 
        /// ExportVirtualSystemEx Method of the Msvm_VirtualSystemManagementService class
        /// </summary>
        /// <param name="scope">
        /// ManagementScope object for root\virtualization namespace
        /// </param>
        /// <returns></returns>
        static string GetVirtualSystemExportSettingDataInstance(ManagementScope scope)
        {
            ManagementPath settingPath = new ManagementPath("Msvm_VirtualSystemExportSettingData");

            ManagementClass exportSettingDataClass = new ManagementClass(scope, settingPath, null);
            ManagementObject exportSettingData = exportSettingDataClass.CreateInstance();

            exportSettingData["CopySnapshotConfiguration"] = 0;
            exportSettingData["CopyVmRuntimeInformation"] = false;
            exportSettingData["CopyVmStorage"] = false;
            exportSettingData["CreateVmExportSubdirectory"] = true;

            string settingData = exportSettingData.GetText(TextFormat.CimDtd20);

            exportSettingData.Dispose();
            exportSettingDataClass.Dispose();

            return settingData;
        }

        /// <summary>
        /// Function to retrieve the import settings data for a vm from the Import Directory
        /// </summary>
        /// <param name="scope">
        /// ManagementScope object for root\virtualization namespace
        /// </param>
        /// <param name="importDirectory">
        /// Directory where the VMs are previously exported to
        /// </param>
        /// <param name="strnewname">New name for the VM being imported</param>
        /// <returns></returns>
        static ManagementBaseObject GetVirtualSystemImportSettingData(ManagementScope scope, string importDirectory, string strnewname)
        {
            ManagementObject virtualSystemService = Utility.GetServiceObject(scope, "Msvm_VirtualSystemManagementService");
            ManagementBaseObject importSettingData = null;
            ManagementBaseObject inParams = virtualSystemService.GetMethodParameters("GetVirtualSystemImportSettingData");
            inParams["ImportDirectory"] = importDirectory;

            ManagementBaseObject outParams = virtualSystemService.InvokeMethod("GetVirtualSystemImportSettingData", inParams, null);

            if ((UInt32)outParams["ReturnValue"] == ReturnCode.Started)
            {
                if (Utility.JobCompleted(outParams, scope))
                {
                    importSettingData = (ManagementBaseObject)outParams["ImportSettingData"];
                    Console.WriteLine("Import Setting Data for the ImportDirectory '{0}' was retrieved successfully.", importDirectory);
                }
                else
                {
                    Console.WriteLine("Failed to get the Import Setting Data");
                }
            }
            else if ((UInt32)outParams["ReturnValue"] == ReturnCode.Completed)
            {
                importSettingData = (ManagementBaseObject)outParams["ImportSettingData"];
                Console.WriteLine("Import Setting Data for the ImportDirectory '{0}' was retrieved successfully.", importDirectory);
            }
            else
            {
                Console.WriteLine("Failed to get the Import Setting Data for the Import Directory :{0}", (UInt32)outParams["ReturnValue"]);
            }

            inParams.Dispose();
            outParams.Dispose();
            virtualSystemService.Dispose();

            importSettingData["GenerateNewId"] = true;
            importSettingData["CreateCopy"] = false;
            importSettingData["Name"] = strnewname;
            importSettingData["SourceResourcePaths"] = importSettingData["CurrentResourcePaths"];

            return importSettingData;
        }

        /// <summary>
        /// Function to imports VM from a VM definition file
        /// </summary>
        /// <param name="importDirectory">
        /// The exported directory containing the definition of the VM
        /// </param>
        /// <param name="strNewName">
        /// Name for the new machine being imported
        /// </param>
        static void ImportVirtualSystemEx(string importDirectory, string strNewName)
        {
            string importCopyDirectory = importDirectory; //Path specified should exist            

            ManagementScope scope = new ManagementScope(@"root\virtualization", null);
            ManagementObject virtualSystemService = Utility.GetServiceObject(scope, "Msvm_VirtualSystemManagementService");

            ManagementBaseObject importSettingData = GetVirtualSystemImportSettingData(scope, importDirectory, strNewName);

            ManagementBaseObject inParams = virtualSystemService.GetMethodParameters("ImportVirtualSystemEx");
            inParams["ImportDirectory"] = importDirectory;
            inParams["ImportSettingData"] = importSettingData.GetText(TextFormat.CimDtd20);

            ManagementBaseObject outParams = virtualSystemService.InvokeMethod("ImportVirtualSystemEx", inParams, null);

            if ((UInt32)outParams["ReturnValue"] == ReturnCode.Started)
            {
                if (Utility.JobCompleted(outParams, scope))
                {
                    Console.WriteLine("VM were Imported successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to Imported VM");
                }
            }
            else if ((UInt32)outParams["ReturnValue"] == ReturnCode.Completed)
            {
                Console.WriteLine("VM were Imported successfully.");
            }
            else
            {
                Console.WriteLine("Import virtual system failed with error:{0}", outParams["ReturnValue"]);
            }

            inParams.Dispose();
            outParams.Dispose();
            virtualSystemService.Dispose();
        }

        /// <summary>
        /// This function is the entry point for Creating VMs by copying the settings from 
        /// an existing template VM. The function actually renames a VM to a new VM then 
        /// export it and then import it back. Once the importing is done, rename the 
        /// source vm to its original name
        /// </summary>
        /// <param name="vmName">Template VM</param>
        /// <param name="exportDirectory">
        /// Name of the directory where the VMs are stored
        /// </param>
        /// <<param name="nMachines">Number of  VMs to be created</param>
        public static void CloneVirtualSystemEx(string vmName, string exportDirectory, int nMachines)
        {
            ManagementScope scope = new ManagementScope(@"root\virtualization", null);
            ManagementObject virtualSystemService = Utility.GetServiceObject(scope, 
                "Msvm_VirtualSystemManagementService");
            ManagementObject vm = Utility.GetTargetComputer(vmName, scope);
            ManagementObject settingData = null;
            ManagementObjectCollection settingsData;
            ManagementBaseObject inParams = null;
            ManagementBaseObject outParams = null;

            //Loop to create as many VMs required (Time being it is 10)
            for (int i = 0; i < nMachines; i++)
            {
                string strNewName = "VMCopy" + i.ToString(); //Name of the newly creating VM

                //Retrieving the input parameters for 
                //Msvm_VirtualSystemManagementService::ModifyVirtualSystem() method
                inParams = virtualSystemService.GetMethodParameters("ModifyVirtualSystem");

                inParams["ComputerSystem"] = vm.Path.Path;

                //Retrieving the virtualization-specific settings the vm using the associator class Msvm_SettingsDefineState.
                settingsData = vm.GetRelated("Msvm_VirtualSystemSettingData",
                    "Msvm_SettingsDefineState", 
                    null,
                    null,
                    "SettingData",
                    "ManagedElement",
                    false,
                    null);

                foreach (ManagementObject data in settingsData)
                {
                    settingData = data;
                }

                //Temporarily renaming the source vm
                settingData["ElementName"] = strNewName;

                inParams["SystemsettingData"] = settingData.GetText(TextFormat.CimDtd20);

                //Invoking the method to rename the vm
                outParams = virtualSystemService.InvokeMethod("ModifyVirtualSystem", inParams, null);

                if ((UInt32)outParams["ReturnValue"] == ReturnCode.Started)
                {
                    if (Utility.JobCompleted(outParams, scope))
                    {
                        Console.WriteLine("VM '{0}' was renamed successfully.", vm["ElementName"]);
                    }
                    else
                    {
                        Console.WriteLine("Failed to Modify VM");
                    }
                }
                else if ((UInt32)outParams["ReturnValue"] == ReturnCode.Completed)
                {
                    Console.WriteLine("VM '{0}' was renamed successfully.", vm["ElementName"]);
                }
                else
                {
                    Console.WriteLine("Failed to modify VM. Error {0}", outParams["ReturnValue"]);
                }

                //Start exporting the renamed VM
                inParams = virtualSystemService.GetMethodParameters("ExportVirtualSystemEx");

                inParams["ComputerSystem"] = vm.Path.Path;

                if (!Directory.Exists(exportDirectory))
                {
                    Directory.CreateDirectory(exportDirectory);
                }
                inParams["ExportDirectory"] = exportDirectory;
                inParams["ExportSettingData"] = GetVirtualSystemExportSettingDataInstance(scope);

                outParams = virtualSystemService.InvokeMethod("ExportVirtualSystemEx", inParams, null);

                if ((UInt32)outParams["ReturnValue"] == ReturnCode.Started)
                {
                    if (Utility.JobCompleted(outParams, scope))
                    {
                        Console.WriteLine("VM '{0}' were exported successfully.", vm["ElementName"]);
                    }
                    else
                    {
                        Console.WriteLine("Failed to export VM");
                    }
                }
                else if ((UInt32)outParams["ReturnValue"] == ReturnCode.Completed)
                {
                    Console.WriteLine("VM '{0}' were exported successfully.", vm["ElementName"]);
                }
                else
                {
                    Console.WriteLine("Export virtual system failed with error:{0}", outParams["ReturnValue"]);
                }

                inParams.Dispose();
                outParams.Dispose();

                ImportVirtualSystemEx(exportDirectory + "\\" + strNewName, strNewName);
            }

            //Now setting the name of source vm to its original name
            settingData = null;
            settingsData = vm.GetRelated("Msvm_VirtualSystemSettingData",
                "Msvm_SettingsDefineState",
                null,
                null,
                "SettingData",
                "ManagedElement",
                false,
                null);
            inParams = virtualSystemService.GetMethodParameters("ModifyVirtualSystem");

            inParams["ComputerSystem"] = vm.Path.Path;

            foreach (ManagementObject data in settingsData)
            {
                settingData = data;
            }

            settingData["ElementName"] = vmName;

            inParams["SystemsettingData"] = settingData.GetText(TextFormat.CimDtd20);

            outParams = virtualSystemService.InvokeMethod("ModifyVirtualSystem", inParams, null);

            if ((UInt32)outParams["ReturnValue"] == ReturnCode.Started)
            {
                if (Utility.JobCompleted(outParams, scope))
                {
                    Console.WriteLine("VM '{0}' was renamed successfully.", vm["ElementName"]);
                }
                else
                {
                    Console.WriteLine("Failed to Modify VM");
                }
            }
            else if ((UInt32)outParams["ReturnValue"] == ReturnCode.Completed)
            {
                Console.WriteLine("VM '{0}' was renamed successfully.", vm["ElementName"]);
            }
            else
            {
                Console.WriteLine("Failed to modify VM. Error {0}", outParams["ReturnValue"]);
            }

            vm.Dispose();
            virtualSystemService.Dispose();
        }
    }
}
