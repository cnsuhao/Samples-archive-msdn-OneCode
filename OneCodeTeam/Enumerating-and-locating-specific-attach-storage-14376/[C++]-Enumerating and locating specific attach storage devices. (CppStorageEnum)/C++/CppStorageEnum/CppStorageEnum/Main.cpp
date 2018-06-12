/****************************** Module Header ******************************\
Module Name:  Main.cpp
Project:      CppStorageEnum
Copyright (c) Microsoft Corporation.

The code in this file imports the C++ code from CppStorageEnumDll.dll that allows you 
enumerate storage devices.

This module imports the following interfaces:
    FindFirstStorageDevice
    FindNextStorageDevice
which are exported by CppStorageEnumDll.dll

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

#include <stdio.h> 
#include <windows.h>  
#include <initguid.h>
#include "CppStorageEnumDll.h"

int __cdecl wmain(int argc, WCHAR **argv)
{
    UINT DeviceNumber;
    WCHAR DeviceName[256];
    WCHAR SerialNumber[256];
    HANDLE hTape = NULL;
    BOOL bRes;

    DeviceNumber = -1;
	RtlZeroMemory(DeviceName, sizeof(DeviceName));
    RtlZeroMemory(SerialNumber, sizeof(SerialNumber));

    bRes = FindFirstStorageDevice(&hTape, (LPGUID) &DiskClassGuid, DeviceName, sizeof(DeviceName), 
		SerialNumber, sizeof(SerialNumber));

	if(!bRes)
	{
		wprintf(L"reason for not being able to get first device %d\n", GetLastError());
	}

    while(bRes)
	{
        wprintf(L"device: (%ws) serial num: (%ws) \n", DeviceName, SerialNumber);
        RtlZeroMemory(DeviceName, sizeof(DeviceName));
        RtlZeroMemory(SerialNumber, sizeof(SerialNumber));

        bRes = FindNextStorageDevice(hTape, (LPGUID) &DiskClassGuid, DeviceName, 
			sizeof(DeviceName), SerialNumber, sizeof(SerialNumber));

        if (!bRes)
		{
            wprintf(L"reason for next device returning false %d\n", GetLastError());
        }
    } 
    return 0;
}
