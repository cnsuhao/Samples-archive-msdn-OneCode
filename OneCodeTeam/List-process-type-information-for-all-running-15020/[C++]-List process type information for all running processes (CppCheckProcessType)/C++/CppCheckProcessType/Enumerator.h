/****************************** Module Header ******************************\
* Module Name:  Enumerator.h
* Project:      CppCheckProcessType
* Copyright (c) Microsoft Corporation.
* 
* Enumerate all running processes' information.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
#ifndef CODE_ENUMERATOR_H
#define CODE_ENUMERATOR_H 

#include <Windows.h>
#include "ProcessInfo.h"

class Enumerator
{
public:
	BOOL EnumerateProcessInfo(ProcessInfo *lpProcesses, DWORD cb, LPDWORD lpcbNeeded);
};

#endif