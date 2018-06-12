/****************************** Module Header ******************************\
* Module Name:  ProcessInfo.h
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

#ifndef CODE_PROCESS_H
#define CODE_PROCESS_H 

#include <Windows.h>
#include "Constants.h"

class ProcessInfo
{
public:
	DWORD m_dwProcessID;
	TCHAR m_szFileName[MAX_PATH];
	BOOL m_fIsConsole;
	BOOL m_fIsManaged;
	BOOL m_fIsDotNet4;
	BOOL m_fIsWPF;
	BOOL m_fIs64Bit;
	BOOL m_fIsValid;

	ProcessInfo();
	ProcessInfo(DWORD dwProcessID);

	~ProcessInfo();
	
private:	
	BOOL GetInfo();
};

#endif