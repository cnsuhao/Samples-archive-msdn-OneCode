/****************************** Module Header ******************************\ 
Module Name:  Source.cpp 
Project:      CppRegistryExport 
Copyright (c) Microsoft Corporation. 

The file has the sample to save the registry to the file on disk.

This source is subject to the Microsoft Public License. 
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL. 

All other rights reserved. 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,  
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED  
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
\***************************************************************************/ 


#include<windows.h>
#include<stdio.h>


#define SUBKEY_PATH_SIZE	256
#define FILE_PATH_SIZE	256


int main(int argc, char*argv[])
{
	if(argc !=4)
	{
		printf("Usage:\n");
		printf("RegistryExport.exe <Root Key> <Subkey> <Full file path>\n");
		printf("Example:\n");
		printf("RegistryExport.exe HKLM  Software\\Microsoft\\Storage  C:\\temp\\regexport.txt \n");
		printf("\n\n");
		printf("Root Keys-\n");
				printf("HKLM\tHKEY_LOCAL_MACHINE\n");
				printf("HKCU\tHKEY_CURRENT_USER\n");
				printf("HKCR\tHKEY_CLASSES_ROOT\n");
				printf("HKU\tHKEY_USERS\n");
		return 1;
	}


	HKEY hRootKey=NULL;
	const char *sHKLM="HKLM";
	const char *sHKCU="HKCU";
	const char *sHKCR="HKCR";
	const char *sHKU="HKU";
	if(strcmp(sHKLM ,  argv[1] )==0)
		hRootKey = HKEY_LOCAL_MACHINE;
	else if(strcmp(sHKCU ,  argv[1] )==0)
		hRootKey = HKEY_CURRENT_USER;
	else if(strcmp(sHKCR ,  argv[1] )==0)
		hRootKey = HKEY_CLASSES_ROOT;
	else if(strcmp(sHKU ,  argv[1] )==0)
		hRootKey = HKEY_USERS;

	char * szSubkey = (char*)malloc(SUBKEY_PATH_SIZE);
	memset(szSubkey,'\0',SUBKEY_PATH_SIZE);
	memcpy(szSubkey,argv[2],strlen(argv[2]));

	char * szFilePath = (char*)malloc(FILE_PATH_SIZE);
	memset(szFilePath,'\0',FILE_PATH_SIZE);
	memcpy(szFilePath,argv[3],strlen(argv[3]));

	HANDLE hToken = NULL; 

	if (!OpenProcessToken(GetCurrentProcess(), 
                          TOKEN_ADJUST_PRIVILEGES, 
                          &hToken)) 
       {
          printf("OpenProcessToken failed: %u\n", GetLastError()); 
         return 1;
       } 


	//BOOL bEnablePrivilege=FALSE;
	TOKEN_PRIVILEGES tp;
    LUID luid;

    if ( !LookupPrivilegeValue( 
            NULL,            // lookup privilege on local system
            SE_BACKUP_NAME,   // privilege to lookup 
            &luid ) )        // receives LUID of privilege
    {
        printf("LookupPrivilegeValue error: %u\n", GetLastError() ); 
        return 1; 
    }

    tp.PrivilegeCount = 1;
    tp.Privileges[0].Luid = luid;
    
    tp.Privileges[0].Attributes = SE_PRIVILEGE_ENABLED;
    

    // Enable the privilege  

    if ( !AdjustTokenPrivileges(
           hToken, 
           FALSE, 
           &tp, 
           sizeof(TOKEN_PRIVILEGES), 
           (PTOKEN_PRIVILEGES) NULL, 
           (PDWORD) NULL) )
    { 
          printf("AdjustTokenPrivileges error: %u\n", GetLastError() ); 
          return 1; 
    } 

    if (GetLastError() == ERROR_NOT_ALL_ASSIGNED)

    {
          printf("The token does not have the specified privilege. \n");
          return FALSE;
    } 



	HKEY hKey=NULL;
	LONG lResult=-1;

	lResult = RegOpenKeyEx( hRootKey, szSubkey , 0,	KEY_READ,	&hKey);
	   if( lResult != ERROR_SUCCESS)
	   {
			printf("RegOpenKeyEx error: %u\n", lResult ); 
			return 1; 
	   }

	if(hRootKey == HKEY_CLASSES_ROOT)
	{
		lResult = -1;
		lResult = RegSaveKey(hKey, szFilePath, NULL);
	   if(lResult != ERROR_SUCCESS)
	   {
		   printf("RegSaveKey error: %u\n",lResult ); 
			return 1; 
	   }
	}
	else
	{
		
		lResult = -1;
		lResult = RegSaveKeyEx(hKey, szFilePath, NULL,REG_STANDARD_FORMAT);
	   if(lResult != ERROR_SUCCESS)
	   {
		   printf("RegSaveKeyEx error: %u\n",lResult ); 
			return 1; 
	   }
	}
   RegCloseKey(hKey);

   free(szSubkey);
   free(szFilePath);
   printf("\nExport successfully!\n");

}