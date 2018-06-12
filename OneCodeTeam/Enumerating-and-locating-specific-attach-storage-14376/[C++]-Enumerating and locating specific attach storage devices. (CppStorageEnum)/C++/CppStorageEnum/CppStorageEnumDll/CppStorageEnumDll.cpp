/****************************** Module Header ******************************\
Module Name:  CppStorageEnumDll.cpp
Project:      CppStorageEnumDll
Copyright (c) Microsoft Corporation.

The code in this file implements the C++ code that allows you 
to call enumerate storage devices from a C++ client application.

This module creates the following interfaces:
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

#include <wchar.h>
#include <stdio.h> 
#include <stdlib.h> 
#include <stddef.h>
#include <windows.h>  
#include <initguid.h>   // Guid definition
#include <devguid.h>    // Device guids
#include <setupapi.h>   // for SetupDiXxx functions.
#include <cfgmgr32.h>   // for SetupDiXxx functions.
#include <devioctl.h>  
#define _NTSRB_
#include <scsi.h>
#include <ntdddisk.h>

DWORD       index = 0;

ULONG GetStorageDeviceDescriptor(
    HANDLE hDevice, 
    wchar_t *lpszSerialNumber, 
    DWORD cchSerialNumberBufferLength,
    USHORT *DeviceType);

ULONG GetStorageDeviceIdDescriptor(
    HANDLE hDevice, 
    wchar_t *lpszSerialNumber, 
    DWORD cchSerialNumberBufferLength);

ULONG GetStorageDeviceNumber(
    HANDLE device, 
    PSTORAGE_DEVICE_NUMBER number);

BOOL GetDeviceProperty(
        HDEVINFO IntDevInfo,
        LPGUID DeviceClassGuid,
        DWORD Index,
        wchar_t *lpszDeviceName, 
        DWORD cchNameBufferLength, 
        wchar_t *lpszSerialNumber, 
        DWORD cchSerialNumberBufferLength);

ULONG GetStorageDeviceDescriptor(HANDLE hDevice, wchar_t *lpszSerialNumber, DWORD cchSerialNumberBufferLength, USHORT *DevType)
{
	// Make a query for the device's properties
	STORAGE_PROPERTY_QUERY query;
	PSTORAGE_DEVICE_DESCRIPTOR	pDevDesc;
    PVOID outBuf;
	PUCHAR p;
	BOOL status;
	ULONG returned_length;
	ULONG i,j;
    ULONG errorCode = ERROR_SUCCESS;

	outBuf = malloc(8 * 1024);
	
    // mode page 80
    // query for the STORAGE_DEVICE_DESCRIPTOR
    //    query.QueryType = PropertyStandardQuery;
    //    query.PropertyId = StorageDeviceProperty;
    // 
    query.QueryType = PropertyStandardQuery;
    query.PropertyId = StorageDeviceProperty;

    status = DeviceIoControl(
                        hDevice,                
                        IOCTL_STORAGE_QUERY_PROPERTY,
                        &query,
                        sizeof( STORAGE_PROPERTY_QUERY ),
                        outBuf,                   
                        8 * 1024,                      
                        &returned_length,      
                        NULL                    
                        );
            
    if ( !status ) 
	{
        errorCode = GetLastError();
        wprintf(L"IOCTL failed with error code (%d).\n\n", errorCode);
    } 
	else 
	{
        pDevDesc = (PSTORAGE_DEVICE_DESCRIPTOR) outBuf;
        if ( pDevDesc->DeviceTypeModifier ) 
		{
            // wprintf(L"Device Modifier : 0x%x\n", pDevDesc->DeviceTypeModifier);
        }
        *DevType = pDevDesc->DeviceType;
        p = (PUCHAR) outBuf; 

        if ( pDevDesc->SerialNumberOffset && p[pDevDesc->SerialNumberOffset] ) 
		{
            // wprintf(L"Serial Number   : " );
            for ( j = 0, i = pDevDesc->SerialNumberOffset; 
                p[i] != (UCHAR) NULL && 
                i < returned_length && j < cchSerialNumberBufferLength; 
                i++, j++ ) 
				{

                // wprintf(L"%c", p[i] );
                lpszSerialNumber[j] = p[i];
            }
            lpszSerialNumber[j] = '\0';
            // wprintf(L"\n");
        }
    }

    if (NULL != outBuf) 
	{
        free(outBuf);
    }

    return errorCode;
}

ULONG GetStorageDeviceIdDescriptor(HANDLE hDevice, wchar_t *lpszSerialNumber, DWORD cchSerialNumberBufferLength)
{
	// Make a query for the device's properties
	STORAGE_PROPERTY_QUERY query;
	PSTORAGE_DEVICE_ID_DESCRIPTOR	pDevIdDesc;
	PSTORAGE_IDENTIFIER pStorageId;
    PVOID outBuf;
	BOOL status;
	ULONG returned_length;
	ULONG Index, i;
    ULONG errorCode = ERROR_SUCCESS;

	outBuf = malloc(8 * 1024);
	
    // mode page 83
    // query for STORAGE_DEVICE_ID_DESCRIPTOR
    //    query.QueryType = PropertyStandardQuery;
    //    query.PropertyId = StorageDeviceIdProperty;
    // 
    query.QueryType = PropertyStandardQuery;
    query.PropertyId = StorageDeviceIdProperty;

    status = DeviceIoControl(
                        hDevice,                
                        IOCTL_STORAGE_QUERY_PROPERTY,
                        &query,
                        sizeof( STORAGE_PROPERTY_QUERY ),
                        outBuf,                   
                        8 * 1024,                      
                        &returned_length,      
                        NULL                    
                        );
            
    if ( !status ) 
	{
        errorCode = GetLastError();
        wprintf(L"IOCTL failed with error code (%d).\n\n", errorCode);
    } 
	else 
	{
        pDevIdDesc = (PSTORAGE_DEVICE_ID_DESCRIPTOR) outBuf;
		pStorageId = (PSTORAGE_IDENTIFIER) pDevIdDesc->Identifiers;
		wprintf(L"num IDs: %d\n", pDevIdDesc->NumberOfIdentifiers);

       for (Index = 0; Index < pDevIdDesc->NumberOfIdentifiers; Index++) {
            // Find an  identification descriptor that
            // is guaranteed to be unique for this device.
            if ( ( pStorageId->Type == StorageIdTypeScsiNameString  ||
                   pStorageId->Type == StorageIdTypeFCPHName        ||
                   pStorageId->Type == StorageIdTypeEUI64           ||
                   pStorageId->Type == StorageIdTypeVendorId            ) &&
                 ( pStorageId->Association == StorageIdAssocDevice      ) &&
                 ( pStorageId->CodeSet == StorageIdCodeSetUtf8      ||
                   pStorageId->CodeSet == StorageIdCodeSetAscii     ||
                   pStorageId->CodeSet == StorageIdCodeSetBinary        ) ) {

                 for (i = 0; i < pStorageId->IdentifierSize; i++) {
					 lpszSerialNumber[i] = pStorageId->Identifier[i];
                 }
				 break;
            }
            pStorageId = (PSTORAGE_IDENTIFIER)((ULONG_PTR)pStorageId + pStorageId->NextOffset);
        }
    }

    if (NULL != outBuf) {
        free(outBuf);
    }

    return errorCode;
}

ULONG GetStorageDeviceNumber(HANDLE device, PSTORAGE_DEVICE_NUMBER number)
{
    BOOL status;
    ULONG returned_bytes;
    ULONG errorCode = ERROR_SUCCESS;

    status = DeviceIoControl(device,
                             IOCTL_STORAGE_GET_DEVICE_NUMBER,
                             NULL,
                             0,
                             number,
                             sizeof(STORAGE_DEVICE_NUMBER),
                             &returned_bytes,
                             FALSE);
                
    if (!status) 
	{
        errorCode = GetLastError();
        wprintf(L"Error getting tape storage number: status %d, returned %d\n", errno, returned_bytes);
        return errorCode;
    }

    return errorCode;

}

BOOL _declspec(dllexport) WINAPI FindFirstStorageDevice(
        HANDLE *hIntDevInfo,
        LPGUID DeviceClassGuid,
        wchar_t *lpszDeviceName, 
        DWORD cchNameBufferLength, 
        wchar_t *lpszSerialNumber, 
        DWORD cchSerialNumberBufferLength
    )
{
    BOOL status = TRUE;
    HANDLE lhIntDevInfo = NULL;

	if (NULL == hIntDevInfo && NULL == *hIntDevInfo) 
	{
		SetLastError(ERROR_INVALID_PARAMETER);
		return FALSE;
	}

	if (NULL == lpszDeviceName || NULL == lpszSerialNumber) 
	{
		SetLastError(ERROR_INVALID_PARAMETER);
		return FALSE;
	}

	if (0 == cchNameBufferLength || 0 == cchSerialNumberBufferLength) 
	{
		SetLastError(ERROR_INVALID_PARAMETER);
		return FALSE;
	}

    lhIntDevInfo = SetupDiGetClassDevs (
                 (LPGUID)DeviceClassGuid,
                 NULL,                                   // Enumerator
                 NULL,                                   // Parent Window
                 (DIGCF_PRESENT | DIGCF_INTERFACEDEVICE  // Only Devices present & Interface class
                 ));

    if( lhIntDevInfo == INVALID_HANDLE_VALUE )
	{
        // ERROR_INVALID_HANDLE
        return FALSE;
    }

    index = 0;
    status = GetDeviceProperty(lhIntDevInfo, DeviceClassGuid, index, lpszDeviceName, cchNameBufferLength, lpszSerialNumber, cchSerialNumberBufferLength);
    if (status == FALSE) 
	{
        // ERROR_NO_MORE_ITEMS
        SetupDiDestroyDeviceInfoList(lhIntDevInfo);
    }

    *hIntDevInfo = lhIntDevInfo;

    return status;
}

BOOL _declspec(dllexport) WINAPI FindNextStorageDevice(
        HANDLE hIntDevInfo,
        LPGUID DeviceClassGuid,
        wchar_t *lpszDeviceName, 
        DWORD cchNameBufferLength, 
        wchar_t *lpszSerialNumber, 
        DWORD cchSerialNumberBufferLength
    )
{
    BOOL bRes;

    index++;
    bRes = GetDeviceProperty(hIntDevInfo, DeviceClassGuid, index, lpszDeviceName, cchNameBufferLength, lpszSerialNumber, cchSerialNumberBufferLength);
    if (bRes == FALSE) 
	{
        // ERROR_NO_MORE_ITEMS
        SetupDiDestroyDeviceInfoList(hIntDevInfo);
    }

    return bRes;
}

BOOL GetDeviceProperty(
        HDEVINFO IntDevInfo,
        LPGUID DeviceClassGuid,
        DWORD Index,
        wchar_t *lpszDeviceName, 
        DWORD cchNameBufferLength, 
        wchar_t *lpszSerialNumber, 
        DWORD cchSerialNumberBufferLength)
/*++

Routine Description:

    This routine enumerates the tape devices using the Device interface
    GUID TapeClassGuid. Gets the Adapter & Device property from the port
    driver. Then sends IOCTL through SPTI to get the device Inquiry data.

Arguments:

    IntDevInfo - Handles to the interface device information list

    Index      - Device member 

Return Value:

  TRUE / FALSE. This decides whether to continue or not
  ERROR_NO_MORE_ITEMS


--*/
{
    SP_DEVICE_INTERFACE_DATA            interfaceData;
    PSP_DEVICE_INTERFACE_DETAIL_DATA    interfaceDetailData = NULL;
    STORAGE_DEVICE_NUMBER               number;
    HANDLE                              hDevice = INVALID_HANDLE_VALUE;
    BOOL                                status;
    DWORD                               interfaceDetailDataSize,
                                        reqSize,
                                        errorCode; 
    USHORT                              deviceType;

    interfaceData.cbSize = sizeof (SP_INTERFACE_DEVICE_DATA);

    status = SetupDiEnumDeviceInterfaces ( 
                IntDevInfo,             // Interface Device Info handle
                0,                      // Device Info data
                DeviceClassGuid,
                Index,                  // Member
                &interfaceData          // Device Interface Data
                );

    if ( status == FALSE ) 
	{
        errorCode = GetLastError();
        if ( errorCode == ERROR_NO_MORE_ITEMS ) 
		{
            wprintf(L"No more interfaces\n" );
        }
        else 
		{
            wprintf(L"SetupDiEnumDeviceInterfaces failed with error: %d\n", errorCode  );
        }
        return FALSE;
    }
        
    //
    // Find out required buffer size, so pass NULL 
    status = SetupDiGetDeviceInterfaceDetail (
                IntDevInfo,         // Interface Device info handle
                &interfaceData,     // Interface data for the event class
                NULL,               // Checking for buffer size
                0,                  // Checking for buffer size
                &reqSize,           // Buffer size required to get the detail data
                NULL                // Checking for buffer size
                );

    //
    // This call returns ERROR_INSUFFICIENT_BUFFER with reqSize 
    // set to the required buffer size. Ignore the above error and
    // pass a bigger buffer to get the detail data
    //

    if ( status == FALSE ) 
	{
        errorCode = GetLastError();
        if ( errorCode != ERROR_INSUFFICIENT_BUFFER ) 
		{
            wprintf(L"SetupDiGetDeviceInterfaceDetail failed with error: %d\n", errorCode   );
            return FALSE;
        }
    }

    //
    // Allocate memory to get the interface detail data
    // This contains the devicepath we need to open the device
    //

    interfaceDetailDataSize = reqSize;
    interfaceDetailData = (PSP_DEVICE_INTERFACE_DETAIL_DATA) malloc (interfaceDetailDataSize);
    if ( interfaceDetailData == NULL ) 
	{
        wprintf(L"Unable to allocate memory to get the interface detail data.\n" );
        return FALSE;
    }

    interfaceDetailData->cbSize = sizeof (SP_INTERFACE_DEVICE_DETAIL_DATA);

    status = SetupDiGetDeviceInterfaceDetail (
                  IntDevInfo,               // Interface Device info handle
                  &interfaceData,           // Interface data for the event class
                  interfaceDetailData,      // Interface detail data
                  interfaceDetailDataSize,  // Interface detail data size
                  &reqSize,                 // Buffer size required to get the detail data
                  NULL);                    // Interface device info

    if ( status == FALSE ) 
	{
        wprintf(L"Error in SetupDiGetDeviceInterfaceDetail failed with error: %d\n", GetLastError() );
        return FALSE;
    }

    wprintf(L"Interface: %ws\n", interfaceDetailData->DevicePath);

    hDevice = CreateFile(
                interfaceDetailData->DevicePath,    // device interface name
                GENERIC_READ | GENERIC_WRITE,       // dwDesiredAccess
                FILE_SHARE_READ | FILE_SHARE_WRITE, // dwShareMode
                NULL,                               // lpSecurityAttributes
                OPEN_EXISTING,                      // dwCreationDistribution
                0,                                  // dwFlagsAndAttributes
                NULL                                // hTemplateFile
                );

    free (interfaceDetailData);

    if (hDevice == INVALID_HANDLE_VALUE) 
	{
        wprintf(L"CreateFile failed with error: %d\n", GetLastError() );
        return TRUE;
    }

    errorCode = GetStorageDeviceNumber(hDevice, &number); 
    if (ERROR_SUCCESS != errorCode) {
        wprintf(L"failed GetStorageDeviceNumber %d\n", errorCode);
        goto error_exit;
    }

    errorCode = GetStorageDeviceDescriptor(hDevice, lpszSerialNumber, cchSerialNumberBufferLength, &deviceType);
    if (ERROR_SUCCESS != errorCode) {
        wprintf(L"failed GetStorageDeviceDescriptor %d\n", errorCode);
        goto error_exit;
    }

    switch (deviceType) 
	{
        case DIRECT_ACCESS_DEVICE:
            swprintf((wchar_t *) lpszDeviceName, L"\\\\.\\PhysicalDrive%d\0", number.DeviceNumber);

            errorCode = GetStorageDeviceIdDescriptor(hDevice, lpszSerialNumber, cchSerialNumberBufferLength);
            if (ERROR_SUCCESS != errorCode) {
                wprintf(L"failed GetStorageDeviceIdDescriptor %d\n", errorCode);
                goto error_exit;
            }

            break;
        case SEQUENTIAL_ACCESS_DEVICE:
            swprintf((wchar_t *) lpszDeviceName, L"\\\\.\\Tape%d\0", number.DeviceNumber);

            break;
    }
    wprintf(L"device type: %d -> %ws\n", deviceType, lpszDeviceName);

error_exit:

    if (INVALID_HANDLE_VALUE != hDevice) 
	{
        CloseHandle(hDevice);
    }

    return TRUE;
}
