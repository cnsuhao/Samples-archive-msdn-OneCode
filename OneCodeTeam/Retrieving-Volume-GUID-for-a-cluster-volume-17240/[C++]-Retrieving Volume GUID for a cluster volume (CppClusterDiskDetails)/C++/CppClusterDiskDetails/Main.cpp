/****************************** Module Header ******************************\
* Module Name:    Main.cpp
* Project:        CppClusterDiskDetails
* Copyright (c) Microsoft Corporation
*
* Main.cpp Defines the entry point for the console application.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

#include "stdafx.h"
#include <windows.h>
#include <clusapi.h>
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

/// <summary>
/// Forward declaration for the function to be called in main.
/// </summary>
BOOL CheckDiskResourceAndGetDetails( HRESOURCE hResource, LPWSTR szGUID, LPWSTR szPath);

/// <summary>
/// Entry point for the program 
/// </summary>
int wmain(int argc, WCHAR* argv[])
{

	HCLUSTER hCluster = NULL;
	HCLUSENUM hClusEnum = NULL;
	DWORD dwSignature = 0;
	WCHAR szVolGUID[MAX_PATH]; 
	WCHAR szPath[MAX_PATH];


	WCHAR* lpwClusterName = NULL;

	if( argc > 1 ) // We have a parameter
	{
		lpwClusterName = argv[1];
		wprintf( L"Cluster: \"%s\"\n", lpwClusterName );
	}

	hCluster = OpenCluster( lpwClusterName );

	DWORD dw = GetLastError(); 

	if( NULL == hCluster )
	{ 
		wprintf( L"Could not open cluster\n" );
	}
	else
	{
		hClusEnum = ClusterOpenEnum( hCluster, CLUSTER_ENUM_RESOURCE );

		if( NULL == hClusEnum )
		{
			wprintf( L"Could not open enum.\n" );
		}
		else
		{ 
			WCHAR lpwName[MAX_PATH];
			DWORD dwCBName;

			DWORD dwType;
			DWORD dwIndex;

			DWORD dwRetVal;

			HRESOURCE hResource = NULL;

			dwIndex = 0;
			dwCBName = 100 * sizeof( WCHAR );
			dwRetVal = ClusterEnum(
			hClusEnum,
			dwIndex,
			&dwType,
			lpwName,
			&dwCBName
			);

			wprintf( L"Physical disks: \n" );

			while( ERROR_SUCCESS == dwRetVal )
			{
				hResource = OpenClusterResource( hCluster, lpwName );

				if( NULL == hResource )
				{
				wprintf( L"Error: could not open resource %s\n", lpwName );
				}
				else
				{

					if(CheckDiskResourceAndGetDetails( hResource, szVolGUID, szPath ) )
					{
					wprintf( L" \"%s(%s)\" Volume GUID = %s\n", lpwName, szPath,szVolGUID);
					}

					CloseClusterResource( hResource );
					hResource = NULL;
				}

				dwIndex++;
				dwCBName = 100 * sizeof( WCHAR );
				dwRetVal = ClusterEnum(
				hClusEnum,
				dwIndex,
				&dwType,
				lpwName,
				&dwCBName
				);
			} // while

			wprintf( L"\n" );

			ClusterCloseEnum( hClusEnum );
			hClusEnum = NULL;
		}

		CloseCluster( hCluster );
		hCluster = NULL;
	}


	return 0;
}

/// <summary>
/// Checks if the resource is a valid cluster disk resource and returns its GUID and Path via out parameters. 
/// </summary>
/// <param name="hResource">Handle for a cluster resource</param>
/// <returns>TRUE if the GUID and Path is retrieved successfully else returns FALSE</returns>
BOOL CheckDiskResourceAndGetDetails( HRESOURCE hResource, LPWSTR szGUID, LPWSTR szPath)
{
		BOOL bIsDisk = FALSE;
		CLUSPROP_VALUE *cv = NULL;
		BYTE* lpbBuffer = NULL;
		DWORD dwRetVal;
		DWORD dwBytes = 0;

		dwRetVal = ClusterResourceControl(
											hResource,
											NULL,
											CLUSCTL_RESOURCE_STORAGE_GET_DISK_INFO_EX,
											NULL,
											0,
											lpbBuffer,
											0,
											&dwBytes 
											);

		if( ERROR_MORE_DATA == dwRetVal || ERROR_SUCCESS == dwRetVal )
		{
			if(lpbBuffer)
			delete [] lpbBuffer;

			lpbBuffer = new BYTE[dwBytes];

			if( NULL == lpbBuffer )
			{
				wprintf( L"Error: could not allocate memory.\n" );
				return FALSE;
			}

			dwRetVal = ClusterResourceControl(
												hResource,
												NULL,
												CLUSCTL_RESOURCE_STORAGE_GET_DISK_INFO_EX,
												NULL,
												0,
												lpbBuffer,
												dwBytes,
												&dwBytes 
												);

			if( ERROR_SUCCESS != dwRetVal && ERROR_INVALID_FUNCTION != dwRetVal )
			{
				if( ERROR_MORE_DATA == dwRetVal )
				{
				wprintf( L"Error: more data needed.\n" );
				}
				else
				{
				wprintf( L"ClusterResourceControl failed: %d\n", dwRetVal );
				}
			}
			else
			{
				cv = (CLUSPROP_VALUE *)lpbBuffer;

				while( (NULL != cv) && (CLUSPROP_TYPE_PARTITION_INFO_EX != cv->Syntax.wType) )
				{
					cv = (CLUSPROP_VALUE *) (((BYTE*)&(cv->cbLength)) + cv->cbLength 
					+ sizeof(DWORD));

					if(cv >= (CLUSPROP_VALUE *) &lpbBuffer[dwBytes])
					{
					cv = NULL;
					}
				}

				if( NULL != cv )
				{
					bIsDisk = TRUE; 
					GUID guid = ((CLUSPROP_PARTITION_INFO_EX*)cv)->VolumeGuid;
					::StringFromGUID2( guid,szGUID,MAX_PATH);
					wsprintf(szGUID,L"%s",szGUID);
					wsprintf(szPath,L"%s",((CLUSPROP_PARTITION_INFO_EX*)cv)->szDeviceName);
				}
			} // else error_success

			delete [] lpbBuffer;
		}
		else if( ERROR_SUCCESS != dwRetVal && ERROR_INVALID_FUNCTION != dwRetVal )
		{
			wprintf( L"ClusterResourceControl failed: %d\n", dwRetVal );
		}

		return bIsDisk;
}
