/****************************** Module Header ******************************\
Module Name:  Program.cs
Project:      CSHyperVCloneVM
Copyright (c) Microsoft Corporation.

This sample demonstrate how to create VM from an existing VM template without 
copying the VHD file.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Management;

namespace CSHyperVCloneVM
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input the name of the VM and the directory path where the clones VMs 
            // may be stored and number of VM to be created
            ExportVirtualSystemEx.CloneVirtualSystemEx("VMCopy0", "C:\\TempVm", 10);
        }
    }
}
