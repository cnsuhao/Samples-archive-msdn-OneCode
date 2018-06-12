/****************************** Module Header ******************************\
* Module Name:  ProcessInfo.cpp
* Project:      CppCheckProcessType
* Copyright (c) Microsoft Corporation.
* 
* This class is responsible for getting process information by ProcessID.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

#include "ProcessInfo.h"
#include "Constants.h"
#include <Shlwapi.h>
#include <Psapi.h>
#include "BitCheck.h"

ProcessInfo::ProcessInfo()
{

}

ProcessInfo::ProcessInfo(DWORD dwProcessID) :
	m_dwProcessID(dwProcessID)
{	
	GetInfo();
}

BOOL ProcessInfo::GetInfo()
{
	HANDLE hStdOutput;
	HANDLE hProcess;
	BOOL fResult;	
	HMODULE lphModule[SIZE];	
	DWORD cbNeeded;
	DWORD dwResult;
	DWORD dwError;
	DWORD cModules;
	TCHAR szModuleFileName[MAX_PATH];
	UINT i;
	DWORD dwConsoleMode;

	m_fIsConsole = FALSE;

	fResult = AttachConsole(m_dwProcessID);
	if(fResult)
	{
		hStdOutput = GetStdHandle(STD_OUTPUT_HANDLE);
		m_fIsConsole = GetConsoleMode(hStdOutput,&dwConsoleMode);
		FreeConsole();
	}

	hProcess = OpenProcess( PROCESS_QUERY_INFORMATION | PROCESS_VM_READ, FALSE, m_dwProcessID);

	if( hProcess == NULL )
	{
		dwError = GetLastError();
		m_fIsValid = FALSE;	
		goto cleanup;
	}

	fResult = EnumProcessModulesEx(hProcess, lphModule, sizeof(lphModule), &cbNeeded, LIST_MODULES_ALL);

	if( fResult == FALSE )
	{
		dwError = GetLastError();
		m_fIsValid = FALSE;	
		goto cleanup;
	}

	dwResult = GetModuleBaseName(hProcess, lphModule[0], m_szFileName, MAX_PATH);

	if( dwResult == 0 )
	{		
		dwError = GetLastError();
		m_fIsValid = FALSE;	
		goto cleanup;
	}

	cModules = cbNeeded / sizeof(HMODULE);

	m_fIsManaged = FALSE;
	m_fIsDotNet4 = FALSE;
	m_fIsWPF = FALSE;

	for( i = 0; i < cModules; i++ )
	{
		dwResult = GetModuleFileNameEx(hProcess, lphModule[i], szModuleFileName, MAX_PATH);

		if(dwResult == 0)
		{
			continue;
		}

		PathStripPath(szModuleFileName);

		dwResult = lstrcmpi(MSCOREE_DLL, szModuleFileName);

		if(dwResult==0)
		{
			m_fIsManaged = TRUE;
		}

		dwResult = lstrcmpi(CLR_DLL, szModuleFileName);

		if(dwResult==0)
		{
			m_fIsDotNet4 = TRUE;
		}

		dwResult = lstrcmpi(PRESENTATIONCORE_DLL, szModuleFileName);

		if(dwResult==0)
		{
			m_fIsWPF = TRUE;
		}
		
		dwResult = lstrcmpi(PRESENTATIONCORENI_DLL, szModuleFileName);

		if(dwResult==0)
		{
			m_fIsWPF = TRUE;
		}
	}
	m_fIs64Bit = Is64BitProcess(hProcess);

	m_fIsValid = true;

cleanup:
	CloseHandle(hProcess);
	return m_fIsValid;
}



ProcessInfo::~ProcessInfo()
{
	
}