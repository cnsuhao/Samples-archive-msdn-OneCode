/****************************** Module Header ******************************\
Module Name:  CppStorageEnumDll.h
Project:      CppStorageEnumDll
Copyright (c) Microsoft Corporation.

This module defines the following interfaces:
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


extern BOOL _declspec(dllexport) WINAPI FindFirstStorageDevice(
        HANDLE *hIntDevInfo,
        LPGUID DeviceClassGuid,
        wchar_t *lpszDeviceName, 
        DWORD cchNameBufferLength, 
        wchar_t *lpszSerialNumber, 
        DWORD cchSerialNumberBufferLength
    );

extern BOOL _declspec(dllexport) WINAPI FindNextStorageDevice(
        HANDLE hIntDevInfo,
        LPGUID DeviceClassGuid,
        wchar_t *lpszDeviceName, 
        DWORD cchNameBufferLength, 
        wchar_t *lpszSerialNumber, 
        DWORD cchSerialNumberBufferLength
    );
