/****************************** Module Header ******************************\ 
Module Name:  NetworkAct.cpp 
Project:      CppNetworkActIPv4
Copyright (c) Microsoft Corporation. 

The file has the code to shows the TCP and UDP endpoints on the system currently.
This sample only covers IPv4 endpoints.

This source is subject to the Microsoft Public License. 
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL. 

All other rights reserved. 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,  
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED  
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
\***************************************************************************/ 


#include<Winsock2.h>
#include<windows.h>
#include<stdio.h>
#include<Iprtrmib.h>
#include<iphlpapi.h>
#include<Mstcpip.h>

#pragma comment(lib, "ws2_32.lib" )
#pragma comment(lib, "Iphlpapi.lib")

void GetTcpConnections()
{
#define SMALL_SIZE  10
	BYTE * pTcpTable= (BYTE*)malloc(SMALL_SIZE);
	DWORD dwSize = SMALL_SIZE;
	BOOL bOrder=TRUE;
	ULONG ulAf1 = AF_INET;
	
	DWORD dwResult = 0;

	dwResult = GetExtendedTcpTable(pTcpTable,&dwSize,bOrder,ulAf1,TCP_TABLE_CLASS::TCP_TABLE_OWNER_PID_ALL,0);
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

	if(pTcpTable!=NULL)
	{
		free(pTcpTable);
		pTcpTable=NULL;
	}

	pTcpTable = (BYTE*)malloc(dwSize);
	dwResult = GetExtendedTcpTable(pTcpTable,&dwSize,bOrder,ulAf1,TCP_TABLE_CLASS::TCP_TABLE_OWNER_PID_ALL,0);
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

	PMIB_TCPTABLE_OWNER_PID pTcpTableOwnerPID=NULL;
	pTcpTableOwnerPID = (PMIB_TCPTABLE_OWNER_PID)pTcpTable;
	printf("\n Number of TCP end points (IPv4) - %d\n",pTcpTableOwnerPID->dwNumEntries);
	DWORD dwNum = pTcpTableOwnerPID->dwNumEntries;
	printf("\n PID      LocalAddr      LocalPort      RemoteAddr      RemotePort      ConnState");
	printf("\n ===      =========      =========      ==========      ===========     ========");
	char  * pMsg []   = {"CLOSED", "LISTEN", "SYN SENT", "SYN RECVD", "ESTABLISHED", "FIN-WAIT-1",\
		"FIN-WAIT-2", "CLOSE WAIT", "CLOSING", "LAST ACK", "TIME WAIT", "DELETE TCB"};
	in_addr inAddr_local={0};
	 in_addr inAddr_remote={0};

#define SIZE_40	40 
	  
	 char *pLocalAdd=(char*)malloc(SIZE_40);
	 char *pRemoteAdd=(char*)malloc(SIZE_40);
	char * pRet=NULL;

	int index =0;
	for(DWORD i=0;i<dwNum;i++)
	{
		switch(pTcpTableOwnerPID->table[i].dwState)
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
		
		 
		::memset(pLocalAdd,'\0',SIZE_40);
		inAddr_local.S_un.S_addr =  (ULONG) (pTcpTableOwnerPID->table[i].dwLocalAddr);
		pRet = inet_ntoa(inAddr_local);
		memcpy(pLocalAdd,pRet,strlen(pRet));

		 
		::memset(pRemoteAdd,'\0',SIZE_40);
		inAddr_remote.S_un.S_addr =  (ULONG)  (pTcpTableOwnerPID->table[i].dwRemoteAddr);
		pRet = inet_ntoa(inAddr_remote);
		memcpy(pRemoteAdd,pRet,strlen(pRet));
					
		printf("\n%5d     %14s     %5d     %14s     %5d     %s",pTcpTableOwnerPID->table[i].dwOwningPid, pLocalAdd,	ntohs((u_short)pTcpTableOwnerPID->table[i].dwLocalPort), pRemoteAdd, ntohs((u_short)pTcpTableOwnerPID->table[i].dwRemotePort),pMsg[index]);
	}

	if(pTcpTable!=NULL)
	{
		free(pTcpTable);
		pTcpTable=NULL;
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



void GetUdpConnections()
{
	#define SMALL_SIZE  10
	BYTE * pUdpTable= (BYTE*)malloc(SMALL_SIZE);
	DWORD dwSize = SMALL_SIZE;
	BOOL bOrder=TRUE;
	ULONG ulAf1 = AF_INET;
	
	DWORD dwResult = 0;

	dwResult = GetExtendedUdpTable(pUdpTable,&dwSize,bOrder,ulAf1,UDP_TABLE_CLASS::UDP_TABLE_OWNER_PID,0);
	if(dwResult != NO_ERROR )
	{
		if(dwResult == ERROR_INSUFFICIENT_BUFFER)
		{
			// no need to print first time as we expct it to fail this way
			//printf("\nGetExtendedUdpTable failed with error	ERROR_INSUFFICIENT_BUFFER");
		}
		if(dwResult == ERROR_INVALID_PARAMETER)
		{
			printf("\nGetExtendedUdpTable failed with error	ERROR_INVALID_PARAMETER");
			return;
		}
	}

	if(pUdpTable!=NULL)
	{
		free(pUdpTable);
		pUdpTable=NULL;
	}
	

	pUdpTable = (BYTE*)malloc(dwSize);
	dwResult = GetExtendedUdpTable (pUdpTable,&dwSize,bOrder,ulAf1,UDP_TABLE_CLASS::UDP_TABLE_OWNER_PID,0);
	if(dwResult != NO_ERROR )
	{
		if(dwResult == ERROR_INSUFFICIENT_BUFFER)
		{
			 printf("\nGetExtendedUdpTable failed with error	ERROR_INSUFFICIENT_BUFFER");
			 return;
		}
		if(dwResult == ERROR_INVALID_PARAMETER)
		{
			printf("\nGetExtendedUdpTable failed with error	ERROR_INVALID_PARAMETER");
			return;
		}
	}

	PMIB_UDPTABLE_OWNER_PID pUdpTableOwnerPID=NULL;
	pUdpTableOwnerPID = (PMIB_UDPTABLE_OWNER_PID)pUdpTable;
	printf("\n\n Number of UDP end points (IPv4)- %d\n",pUdpTableOwnerPID->dwNumEntries);
	DWORD dwNum = pUdpTableOwnerPID->dwNumEntries;
	
	printf("\n PID\t\tLocalAddr\tLocalPort");
	printf("\n ===\t\t=========\t==========");
	 
	in_addr inAddr_local={0};
	 
	#define SIZE_40	40 
	 char *pLocalAdd=NULL;
	 
	
	 
	for(DWORD i=0;i<dwNum;i++)
	{
		inAddr_local.S_un.S_addr = (ULONG)pUdpTableOwnerPID->table[i].dwLocalAddr; 
		
		pLocalAdd = inet_ntoa(inAddr_local);
		printf("\n%5d\t%16s\t%d",pUdpTableOwnerPID->table[i].dwOwningPid,	pLocalAdd,	ntohs((u_short)pUdpTableOwnerPID->table[i].dwLocalPort));
	}

	if(pUdpTable!=NULL)
	{
		free(pUdpTable);
		pUdpTable=NULL;
	}
	 
}



int main(int argc, char*argv[])
{
	GetTcpConnections();
	GetUdpConnections();
	printf("\n");
	return 0;
}