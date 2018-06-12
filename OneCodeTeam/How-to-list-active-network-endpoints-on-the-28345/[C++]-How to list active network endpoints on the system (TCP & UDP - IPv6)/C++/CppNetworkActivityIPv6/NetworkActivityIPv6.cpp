/****************************** Module Header ******************************\ 
Module Name:  NetworkActivityIPv6.cpp 
Project:      CppNetworkActivityIPv6
Copyright (c) Microsoft Corporation. 

The file has the code to shows the TCP and UDP endpoints on the system currently.> 
This sample only covers IPv6 endpoints.

This source is subject to the Microsoft Public License. 
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL. 

All other rights reserved. 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,  
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED  
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
\***************************************************************************/ 


#include<Winsock2.h>
#include<ws2ipdef.h>
#include<iphlpapi.h>

#include<Udpmib.h>
#include<windows.h>
#include<stdio.h>

#include<Mstcpip.h>
#pragma comment(lib, "ws2_32.lib" )
#pragma comment(lib, "Iphlpapi.lib")

void GetTcpConnectionsIPv6()
{
#define SMALL_SIZE  10
	BYTE * pTcp6Table= (BYTE*)malloc(SMALL_SIZE);
	DWORD dwSize = SMALL_SIZE;
	BOOL bOrder=TRUE;
	ULONG ulAf1 = AF_INET6;
	
	DWORD dwResult = 0;

	dwResult = GetExtendedTcpTable(pTcp6Table,&dwSize,bOrder,ulAf1,TCP_TABLE_CLASS::TCP_TABLE_OWNER_PID_ALL,0);
	if(dwResult != NO_ERROR )
	{
		if(dwResult == ERROR_INSUFFICIENT_BUFFER)
		{
			// no need to print first time as we expct it to fail this way
			//printf("\nGetExtendedTcpTable failed with error	ERROR_INSUFFICIENT_BUFFER");
		}
		if(dwResult == ERROR_INVALID_PARAMETER)
		{
			printf("\nGetExtendedTcpTable failed with error	ERROR_INVALID_PARAMETER");
			return;
		}
	}

	if(pTcp6Table!=NULL)
	{
		free(pTcp6Table);
		pTcp6Table=NULL;
	}

	pTcp6Table = (BYTE*)malloc(dwSize);
	dwResult = GetExtendedTcpTable(pTcp6Table,&dwSize,bOrder,ulAf1,TCP_TABLE_CLASS::TCP_TABLE_OWNER_PID_ALL,0);
	if(dwResult != NO_ERROR )
	{
		if(dwResult == ERROR_INSUFFICIENT_BUFFER)
		{
			 printf("\nGetExtendedTcpTable failed with error	ERROR_INSUFFICIENT_BUFFER");
			 return;
		}
		if(dwResult == ERROR_INVALID_PARAMETER)
		{
			printf("\nGetExtendedTcpTable failed with error	ERROR_INVALID_PARAMETER");
			return;
		}
	}

	PMIB_TCP6TABLE_OWNER_PID pTcp6TableOwnerPID=NULL;
	pTcp6TableOwnerPID = (PMIB_TCP6TABLE_OWNER_PID)pTcp6Table;
	printf("\n Number of TCP end points (IPv6) - %d\n",pTcp6TableOwnerPID->dwNumEntries);
	DWORD dwNum = pTcp6TableOwnerPID->dwNumEntries;
	printf("\n PID      LocalAddr      LocalPort      RemoteAddr      RemotePort      ConnState");
	printf("\n ===      =========      =========      ==========      ===========     ========");
	char  * pMsg []   = {"CLOSED", "LISTEN", "SYN SENT", "SYN RECVD", "ESTABLISHED", "FIN-WAIT-1", "FIN-WAIT-2",\
		"CLOSE WAIT", "CLOSING", "LAST ACK", "TIME WAIT", "DELETE TCB"};
	 
#define SIZE_50T	50 
	 char*pTemp =  (char*)malloc(SIZE_50T);
	 char *pLocalAdd=(char*)malloc(SIZE_50T);
	 char *pRemoteAdd=(char*)malloc(SIZE_50T);
		
	int index =0;
	for(DWORD i=0;i<dwNum;i++)
	{
		switch(pTcp6TableOwnerPID->table[i].dwState)
		{
		case MIB_TCP_STATE_CLOSED :
			index = 0; break;
 
		case MIB_TCP_STATE_LISTEN  :
			index = 1; break;
 
		case MIB_TCP_STATE_SYN_SENT  :
			index = 2; break;
 
		case MIB_TCP_STATE_SYN_RCVD  :
			index = 3; break;
 
		case MIB_TCP_STATE_ESTAB  :
			index = 4; break;
 
		case MIB_TCP_STATE_FIN_WAIT1  :
			 index = 5; break;

		case MIB_TCP_STATE_FIN_WAIT2  :
			index = 6; break;
 
		case MIB_TCP_STATE_CLOSE_WAIT  :
			index = 7; break;
 
		case MIB_TCP_STATE_CLOSING:
			index = 8; break;

		case MIB_TCP_STATE_LAST_ACK:
			index = 9; break;

		case MIB_TCP_STATE_TIME_WAIT:
			index = 10; break;

		case MIB_TCP_STATE_DELETE_TCB  :
			index = 11; break;
		}
		
		::memset(pTemp,'\0',SIZE_50T);
		::memset(pLocalAdd,'\0',SIZE_50T);
		IN6_ADDR in6addr_local = {0};

		for(int x=0;x<16;x++)
		{
			in6addr_local.u.Byte[x] = pTcp6TableOwnerPID->table[i].ucLocalAddr[x];
		}
		RtlIpv6AddressToStringA(&in6addr_local,pTemp);
		 
		memcpy(pLocalAdd,pTemp,strlen(pTemp));

		::memset(pTemp,'\0',SIZE_50T);
		::memset(pRemoteAdd,'\0',SIZE_50T);
		IN6_ADDR in6addr_remote = {0};

		for(int x=0;x<16;x++)
		{
			in6addr_remote.u.Byte[x] = pTcp6TableOwnerPID->table[i].ucRemoteAddr[x];
		}
		RtlIpv6AddressToStringA(&in6addr_remote,pTemp);
		 
		memcpy(pRemoteAdd,pTemp,strlen(pTemp));
		 
		printf("\n%5d     %14s     %5d     %14s     %5d     %s",pTcp6TableOwnerPID->table[i].dwOwningPid,	pLocalAdd,	ntohs((u_short)pTcp6TableOwnerPID->table[i].dwLocalPort),		pRemoteAdd,		ntohs((u_short)pTcp6TableOwnerPID->table[i].dwRemotePort),pMsg[index]);
	}


	if(pTcp6Table!=NULL)
	{
		free(pTcp6Table);
		pTcp6Table=NULL;
	}
	if(pLocalAdd!=NULL)
	{
		free(pLocalAdd);
		pLocalAdd=NULL;
	}
	if(pRemoteAdd!=NULL)
	{
		free(pRemoteAdd);
		pRemoteAdd=NULL;
	}
	 

	}

void GetUdpConnectionsIPv6()
{

	#define SMALL_SIZE  10
	BYTE * pUdp6Table= (BYTE*)malloc(SMALL_SIZE);
	DWORD dwSize = SMALL_SIZE;
	BOOL bOrder=TRUE;
	ULONG ulAf1 = AF_INET6;
	
	DWORD dwResult = 0;

	dwResult = GetExtendedUdpTable(pUdp6Table,&dwSize,bOrder,ulAf1,UDP_TABLE_CLASS::UDP_TABLE_OWNER_PID,0);
	if(dwResult != NO_ERROR )
	{
		if(dwResult == ERROR_INSUFFICIENT_BUFFER)
		{
			// no need to print first time as we expct it to fail this way
			//printf("\nGetExtendedUdpTable failed with error	ERROR_INSUFFICIENT_BUFFER");
		}
		if(dwResult == ERROR_INVALID_PARAMETER)
			printf("\nGetExtendedUdpTable failed with error	ERROR_INVALID_PARAMETER");
	}

	free(pUdp6Table);
	pUdp6Table = (BYTE*)malloc(dwSize);
	dwResult = GetExtendedUdpTable (pUdp6Table,&dwSize,bOrder,ulAf1,UDP_TABLE_CLASS::UDP_TABLE_OWNER_PID,0);
	if(dwResult != NO_ERROR )
	{
		if(dwResult == ERROR_INSUFFICIENT_BUFFER)
		{
			 printf("\nGetExtendedUdpTable failed with error	ERROR_INSUFFICIENT_BUFFER");
		}
		if(dwResult == ERROR_INVALID_PARAMETER)
			printf("\nGetExtendedUdpTable failed with error	ERROR_INVALID_PARAMETER");
	}
	

	PMIB_UDP6TABLE_OWNER_PID pUdp6TableOwnerPID=NULL;
	pUdp6TableOwnerPID = (PMIB_UDP6TABLE_OWNER_PID)pUdp6Table;
	printf("\n Number of UDP end points- %d",pUdp6TableOwnerPID->dwNumEntries);
	DWORD dwNum = pUdp6TableOwnerPID->dwNumEntries;
	
	printf("\nPID\t\t\tLocalAddr\t\t\tLocalPort");
	printf("\n===\t\t\t=========\t\t\t==========");
	
	 
#define SIZE_50U	50 
	 char *pLocalAdd= (char*)malloc(SIZE_50U);
		
	 for(DWORD i=0;i<dwNum;i++)
	{
		::memset(pLocalAdd,'\0',SIZE_50U);
		IN6_ADDR in6addr_remote = {0};

		for(int x=0;x<16;x++)
		{
			in6addr_remote.u.Byte[x] = pUdp6TableOwnerPID->table[i].ucLocalAddr[x];
		}
		RtlIpv6AddressToStringA(&in6addr_remote,pLocalAdd);
		
		printf("\n%5d\t\t%20s\t\t\t%5d",pUdp6TableOwnerPID->table[i].dwOwningPid,	pLocalAdd,	ntohs((u_short)pUdp6TableOwnerPID->table[i].dwLocalPort));
	}

	free(pUdp6Table);
	//free(pLocalAdd);
}


int main(int argc, char* argv[])
{

	 GetTcpConnectionsIPv6();
	 GetUdpConnectionsIPv6();
	 printf("\n");
	return 0;
}

