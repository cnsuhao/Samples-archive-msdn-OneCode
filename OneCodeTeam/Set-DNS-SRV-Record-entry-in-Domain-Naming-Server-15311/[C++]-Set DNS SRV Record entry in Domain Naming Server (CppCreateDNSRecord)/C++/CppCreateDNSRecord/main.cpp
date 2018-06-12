/****************************** Module Header ******************************\
Module Name:  main.cpp
Project:      CppCreateDNSRecord
Copyright (c) Microsoft Corporation.

main.cpp : Defines the entry point for the console application.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

#include "stdafx.h"
#define _WIN32_DCOM
#include <iostream>
using namespace std;
#include <comdef.h>
#include <Wbemidl.h>

# pragma comment(lib, "wbemuuid.lib")


int _tmain(int argc, _TCHAR* argv[])
{
	HRESULT hres;

	// Step 1: --------------------------------------------------
	// Initialize COM. ------------------------------------------

	hres =  CoInitializeEx(0, COINIT_MULTITHREADED); 
	if (FAILED(hres))
	{
		cout << "Failed to initialize COM library. Error code = 0x"  << hex << hres << endl;
		return 1;                  // Program has failed.
	}

	// Step 2: --------------------------------------------------
	// Set general COM security levels --------------------------
	// Note: If you are using Windows 2000, you must specify -
	// the default authentication credentials for a user by using
	// a SOLE_AUTHENTICATION_LIST structure in the pAuthList ----
	// parameter of CoInitializeSecurity ------------------------

	hres =  CoInitializeSecurity(
									NULL, 
									-1,                          // COM negotiates service
									NULL,                        // Authentication services
									NULL,                        // Reserved
									RPC_C_AUTHN_LEVEL_DEFAULT,   // Default authentication 
									RPC_C_IMP_LEVEL_IMPERSONATE, // Default Impersonation  
									NULL,                        // Authentication info
									EOAC_NONE,                   // Additional capabilities 
									NULL                         // Reserved
								);

	                  
	if (FAILED(hres))
	{
		cout << "Failed to initialize security. Error code = 0x" << hex << hres << endl;
		CoUninitialize();
		return 1;                      // Program has failed.
	}

	// Step 3: ---------------------------------------------------
	// Obtain the initial locator to WMI -------------------------

	IWbemLocator *pLoc = NULL;

	hres = CoCreateInstance(CLSID_WbemLocator,0, CLSCTX_INPROC_SERVER,IID_IWbemLocator, (LPVOID *) &pLoc);

	if (FAILED(hres))
	{
		cout << "Failed to create IWbemLocator object. "<< "Err code = 0x"<< hex << hres << endl;
		CoUninitialize();
		return 1;                 // Program has failed.
	}

	// Step 4: ---------------------------------------------------
	// Connect to WMI through the IWbemLocator::ConnectServer method

	IWbemServices *pSvc = NULL;

	// Connect to the local ROOT\MicrosoftDNS namespace
	// and obtain pointer pSvc to make IWbemServices calls.
	hres = pLoc->ConnectServer(	_bstr_t(L"ROOT\\MicrosoftDNS"), NULL,NULL, 0, NULL, 0, 0,&pSvc);
	    
	if (FAILED(hres))
	{
		cout << "Could not connect. Error code = 0x" << hex << hres << endl;
		pLoc->Release();     
		CoUninitialize();
		return 1;                // Program has failed.
	}

	cout << "Connected to ROOT\\MicrosoftDNS WMI namespace" << endl;


	// Step 5: --------------------------------------------------
	// Set security levels for the proxy ------------------------

	hres = CoSetProxyBlanket(
								pSvc,                        // Indicates the proxy to set
								RPC_C_AUTHN_WINNT,           // RPC_C_AUTHN_xxx 
								RPC_C_AUTHZ_NONE,            // RPC_C_AUTHZ_xxx 
								NULL,                        // Server principal name 
								RPC_C_AUTHN_LEVEL_CALL,      // RPC_C_AUTHN_LEVEL_xxx 
								RPC_C_IMP_LEVEL_IMPERSONATE, // RPC_C_IMP_LEVEL_xxx
								NULL,                        // client identity
								EOAC_NONE                    // proxy capabilities 
							);

	if (FAILED(hres))
	{
		cout << "Could not set proxy blanket. Error code = 0x"  << hex << hres << endl;
		pSvc->Release();
		pLoc->Release();     
		CoUninitialize();
		return 1;               // Program has failed.
	}

	// Step 6: --------------------------------------------------
	// Use the IWbemServices pointer to make requests of WMI ----
	// set up to call the MicrosoftDNS_SRVType::CreateInstanceFromPropertyData method

	BSTR MethodName = SysAllocString(L"CreateInstanceFromPropertydata");
	BSTR ClassName = SysAllocString(L"MicrosoftDNS_SRVType");

	IWbemClassObject* pClass = NULL;
	hres = pSvc->GetObject(ClassName, 0, NULL, &pClass, NULL);

	IWbemClassObject* pInParamsDefinition = NULL;
	hres = pClass->GetMethod(MethodName, 0, &pInParamsDefinition, NULL);

	IWbemClassObject* pClassInstance = NULL;
	hres = pInParamsDefinition->SpawnInstance(0, &pClassInstance);

	// Create the values for the in parameters
	// DnsServerName
	VARIANT varDnsServerName;
	varDnsServerName.vt = VT_BSTR;

	varDnsServerName.bstrVal = L"SHALOINT.SHAOLINT.COM"; //FQDN of the DNS Server

	// ContainerName
	VARIANT varContainerName;
	varContainerName.vt = VT_BSTR;
	varContainerName.bstrVal = L"SHAOLINT.COM"; // FQDN of domain controller or called Container

	// OwnerName
	VARIANT varOwnerName;
	varOwnerName.vt = VT_BSTR;
	varOwnerName.bstrVal = L"_telnet._tcp.SHAOLINT.COM"; // New alias name, in FQDN format

	// RecordClass
	VARIANT varRecordClass;
	varRecordClass.intVal = VT_INT;
	varRecordClass.intVal = 0; 

	// TTL
	VARIANT varTTL;
	varTTL.vt = VT_INT;
	varTTL.intVal = 0;	// must set to 0 else you will get "Generic Error" 

	// Priority
	VARIANT varPriority;
	VariantInit(&varPriority);
	V_VT(&varPriority) = VT_BSTR;
	V_BSTR(&varPriority) = SysAllocString(L"0");	

	// Weight
	VARIANT varWeight;
	VariantInit(&varWeight);
	V_VT(&varWeight) = VT_BSTR;
	V_BSTR(&varWeight) = SysAllocString(L"0");

	// Port	
	VARIANT varPort; 
	VariantInit(&varPort);
	V_VT(&varPort) = VT_BSTR;
	V_BSTR(&varPort) = SysAllocString(L"23"); 

	// DomainName
	VARIANT varDomainName;
	varDomainName.vt = VT_BSTR;
	varDomainName.bstrVal = L"shal.shaolint.com"; 	

	// Store the value for the in parameters
	hres = pClassInstance->Put(L"DnsServerName", 0,&varDnsServerName, 0);	
	hres = pClassInstance->Put(L"ContainerName", 0,&varContainerName, 0);
	hres = pClassInstance->Put(L"OwnerName", 0,&varOwnerName, 0);
	hres = pClassInstance->Put(L"Priority", 0,&varPriority, CIM_UINT16);
	hres = pClassInstance->Put(L"Weight", 0,&varWeight, CIM_UINT16);
	hres = pClassInstance->Put(L"Port", 0,&varPort, CIM_UINT16);
	hres = pClassInstance->Put(L"DomainName", 0,&varDomainName, 0);

	// Execute WMI Method
	IWbemClassObject* pOutParams = NULL;
	hres = pSvc->ExecMethod(ClassName, MethodName, 0, NULL, pClassInstance, &pOutParams, NULL);

	if (FAILED(hres))
	{
		cout << "Could not execute method. Error code = 0x" << hex << hres << endl;
		VariantClear(&varDnsServerName);
		VariantClear(&varContainerName);
		VariantClear(&varOwnerName);
		VariantClear(&varPriority);
		VariantClear(&varWeight);		
		VariantClear(&varPort);	
		VariantClear(&varDomainName);

		SysFreeString(ClassName);
		SysFreeString(MethodName);
		pClass->Release();
		pInParamsDefinition->Release();
		pOutParams->Release();
		pSvc->Release();
		pLoc->Release();     
		CoUninitialize();
		return 1;               // Program has failed.
	}



	// Clean up
	//--------------------------
	VariantClear(&varDnsServerName);
	VariantClear(&varContainerName);
	VariantClear(&varOwnerName);
	VariantClear(&varPriority);
	VariantClear(&varWeight);		
	VariantClear(&varPort);	
	VariantClear(&varDomainName);

	SysFreeString(ClassName);
	SysFreeString(MethodName);
	pClass->Release();
	pInParamsDefinition->Release();
	pOutParams->Release();
	pLoc->Release();
	pSvc->Release();
	CoUninitialize();
	return 0;

}

