/****************************** Module Header ******************************\
* Module Name:  main.cpp
* Project:      CppCATAdmin
* Copyright (c) Microsoft Corporation.
* 
* This sample demonstrates CAPI/Wintrust native functions that allow the user 
* to add/remove third party authenticode signed catalog files to the system. 
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

#include "stdafx.h"
#include <windows.h>
#include <strsafe.h>
#include <mscat.h>
#include <softpub.h>

BOOL AddCatalog(LPCTSTR strPath,LPCTSTR strFile);
BOOL RemoveCatalog(LPCTSTR strPath);
BOOL IsAdminUserAndGroup(void);

// Specifies the third party store...
GUID PolicyGUID = DRIVER_ACTION_VERIFY; // Defined in softpub.h

// From: http://msdn.microsoft.com/en-us/library/aa376389(VS.85).aspx

BOOL IsAdminUserAndGroup(void)
{
	BOOL bRet;
    SID_IDENTIFIER_AUTHORITY NtAuthority = SECURITY_NT_AUTHORITY;
    PSID AdministratorsGroup;
    
	bRet = AllocateAndInitializeSid(
        &NtAuthority,
        2,
        SECURITY_BUILTIN_DOMAIN_RID,
        DOMAIN_ALIAS_RID_ADMINS,
        0, 0, 0, 0, 0, 0,
        &AdministratorsGroup);
    
	if(bRet)
    {
        if (!CheckTokenMembership( NULL, AdministratorsGroup, &bRet))
        {
             bRet = FALSE;
        }
        FreeSid(AdministratorsGroup);
    }

    return(bRet?TRUE:FALSE);
}

//--------------------------------------------------------------------
//
// Usage
//
// Tell user how to use the program.
//
//--------------------------------------------------------------------
int Usage(VOID) 
{
	_tprintf(_T("Usage: CppCATAdmin [-a<add> | -r<remove>] [catalog file]\n"));
	_tprintf(_T("Example: CppCATAdmin -a C:\\MYWORK\\MYCAT.CAT\n"));

    return -1;
}

// Quick check to see if the file exists for further operations...

BOOL FileExists(TCHAR* searchPath)
{
	HANDLE OutHandle;

	OutHandle = CreateFile(searchPath,
                       GENERIC_READ | GENERIC_WRITE,
                       FILE_SHARE_READ | FILE_SHARE_WRITE,
                       NULL,
                       OPEN_EXISTING,
                       FILE_FLAG_OVERLAPPED,
                       NULL);

	if(OutHandle!=INVALID_HANDLE_VALUE) 
	{
			CloseHandle(OutHandle);
			return TRUE;
	}

	return FALSE;
}

int _tmain(int argc, _TCHAR* argv[])
{
	TCHAR		searchPath[MAX_PATH];
	PWCHAR		filePart;

	if(argc!=3) return Usage();

	if(!IsAdminUserAndGroup()) 
	{
		_tprintf(_T("Administrative elevation required.\n"));
		return -1;
	}

	
	GetFullPathName( argv[argc-1], MAX_PATH, searchPath, &filePart );

	if(!FileExists(searchPath))
	{
		_tprintf(_T("File Error: \"%s\" does not exist!\n"),searchPath);
		return Usage();
	}

	for( int i = 1; i < argc; i++ ) 
	{
		switch(argv[i][0])
		{
			case '/':
			case '-':
		
				switch(argv[i][1])
				{
					case 'A':
					case 'a':
						return(AddCatalog(searchPath,filePart)?0:-1);
					case 'R':
					case 'r':
						return(RemoveCatalog(filePart)?0:-1);
				}
				break;
		}
	}

	return Usage();
}

//From: http://msdn.microsoft.com/en-us/library/ff547575

BOOL AddCatalog(LPCTSTR strCatfile,LPCTSTR strFile)
{
	HCATADMIN hAdmin=NULL;
	BOOL bRet=FALSE;
	HCATINFO hInfo=NULL;
	WCHAR strFILE[MAX_PATH];
	WCHAR strBASE[MAX_PATH];

	StringCchCopyW(&strFILE[0],MAX_PATH,strCatfile);
	StringCchCopyW(&strBASE[0],MAX_PATH,strFile);

	// Get crypto context
	if(CryptCATAdminAcquireContext(&hAdmin, &PolicyGUID, 0))
	{
		hInfo = CryptCATAdminAddCatalog(hAdmin,strFILE,strBASE, 0);

		if(hInfo)
		{
			bRet = CryptCATAdminReleaseCatalogContext(hAdmin,hInfo,0);
		}

		if (NULL != hAdmin)
			CryptCATAdminReleaseContext(hAdmin, 0);

		return TRUE;
	}

	return FALSE;
}

BOOL RemoveCatalog(LPCTSTR strCatfile)
{
	HCATADMIN hAdmin=NULL;
	BOOL bRet=FALSE;
	WCHAR strFILE[MAX_PATH];

	StringCchCopyW(&strFILE[0],MAX_PATH,strCatfile);

	// Get crypto context
	if(CryptCATAdminAcquireContext(&hAdmin, &PolicyGUID, 0))
	{
		bRet = CryptCATAdminRemoveCatalog(hAdmin,strFILE,0);

		if (hAdmin) CryptCATAdminReleaseContext(hAdmin, 0);
	}

	return bRet;
}



