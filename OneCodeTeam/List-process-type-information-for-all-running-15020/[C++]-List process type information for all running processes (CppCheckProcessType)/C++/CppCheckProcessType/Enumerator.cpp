/****************************** Module Header ******************************\
* Module Name:  Enumerator.cpp
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

#include "Enumerator.h"
#include "ProcessInfo.h"
#include "Constants.h"
#include <Psapi.h>

BOOL Enumerator::EnumerateProcessInfo(ProcessInfo *lpProcessesInfo, DWORD cb, LPDWORD lpcbNeeded)
{
	DWORD dwProcessID[SIZE];
	BOOL fResult = FALSE;
	DWORD cbProcess;
	DWORD cProcessID;
	DWORD index;	

	fResult = EnumProcesses(dwProcessID, sizeof(dwProcessID), &cbProcess);

	if(!fResult)
	{
		return FALSE;
	}

	cProcessID = cbProcess / sizeof(DWORD);

	*lpcbNeeded = cProcessID * sizeof(ProcessInfo);

	if(*lpcbNeeded > cb)
	{
		*lpcbNeeded = cb;
		cProcessID = cb / sizeof(ProcessInfo);
	}

	for( index = 0; index < cProcessID; index++ )
	{
		ProcessInfo piProcessInfo(dwProcessID[index]);
		lpProcessesInfo[index] = piProcessInfo;
	}

	return TRUE;
}
