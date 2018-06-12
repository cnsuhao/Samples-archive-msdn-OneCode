/****************************** Module Header ******************************\
Module Name:  BitCheck.h
Project:      CppCheckProcessType
Copyright (c) Microsoft Corporation.

The code sample demonstrates how to determine whether the given process is
a 64-bit process or not.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

#ifndef BIT_CHECK_H
#define BIT_CHECK_H 

#include <Windows.h>

BOOL WINAPI SafeIsWow64Process(HANDLE hProcess, PBOOL Wow64Process);
BOOL Is64BitOS();
BOOL Is64BitProcess(void);
BOOL Is64BitProcess(HANDLE hProcess);

#endif