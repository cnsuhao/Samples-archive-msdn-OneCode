// UserGroupInfo.cpp : Defines the entry point for the console application.
//


#include <windows.h>
#include <stdio.h>
#include<tchar.h>
#pragma comment(lib, "advapi32.lib")

#define MAX_NAME 256


int _tmain(int argc, TCHAR* argv[])
{

	DWORD i, dwSize = 0, dwResult = 0;
    HANDLE hToken;
    PTOKEN_GROUPS pGroupInfo;
    SID_NAME_USE SidType;
    TCHAR lpName[MAX_NAME];
    TCHAR lpDomain[MAX_NAME];
    PSID pSID = NULL;
    SID_IDENTIFIER_AUTHORITY SIDAuth = SECURITY_NT_AUTHORITY;
       
    // Open a handle to the access token for the calling process.

    if (!OpenProcessToken( GetCurrentProcess(), TOKEN_QUERY, &hToken )) 
    {
        _tprintf( L"OpenProcessToken Error %u\n", GetLastError() );
        return FALSE;
    }

    // Call GetTokenInformation to get the buffer size.

    if(!GetTokenInformation(hToken, TokenGroups, NULL, dwSize, &dwSize)) 
    {
        dwResult = GetLastError();
        if( dwResult != ERROR_INSUFFICIENT_BUFFER ) {
            _tprintf( L"GetTokenInformation Error %u\n", dwResult );
            return FALSE;
        }
    }

    // Allocate the buffer.

    pGroupInfo = (PTOKEN_GROUPS) GlobalAlloc( GPTR, dwSize );

    // Call GetTokenInformation again to get the group information.

    if(! GetTokenInformation(hToken, TokenGroups, pGroupInfo, 
                            dwSize, &dwSize ) ) 
    {
        _tprintf( L"GetTokenInformation Error %u\n", GetLastError() );
        return FALSE;
    }

    // Create a SID for the BUILTIN\Administrators group.

    if(! AllocateAndInitializeSid( &SIDAuth, 2,
                     SECURITY_BUILTIN_DOMAIN_RID,
                     DOMAIN_ALIAS_RID_ADMINS,
                     0, 0, 0, 0, 0, 0,
                     &pSID) ) 
    {
        _tprintf( L"AllocateAndInitializeSid Error %u\n", GetLastError() );
        return FALSE;
    }

    // Loop through the group SIDs looking for the administrator SID.

    for(i=0; i< pGroupInfo->GroupCount; i++) 
    {
            // Lookup the account name and print it.

            dwSize = MAX_NAME;
            if( !LookupAccountSid( NULL, pGroupInfo->Groups[i].Sid,
                                  lpName, &dwSize, lpDomain, 
                                  &dwSize, &SidType ) ) 
            {
                dwResult = GetLastError();
                if( dwResult == ERROR_NONE_MAPPED )
                   _tcscpy_s(lpName, dwSize, L"NONE_MAPPED" );
				else if(dwResult == 1789)		// for disconnect scenario, continue 
					continue;
                else 
                {
                    _tprintf(L"LookupAccountSid Error %u\n", GetLastError());
                    return FALSE;
                }
            }
         
			if(_tcslen(lpDomain) != 0)
			{
				_tprintf( L"\t%d	%s\\%s \n", i+1,lpDomain, lpName );
			}
			else
			{
				_tprintf( L"\t%d	%s \n", i+1, lpName );
			}

        
    }

    if (pSID)
        FreeSid(pSID);
    if ( pGroupInfo )
        GlobalFree( pGroupInfo );
     
	CloseHandle(hToken);

	return 0;
}

