/****************************** Module Header ******************************\
Module Name:  main.cpp
Project:      CppEnableNetBiosOverTCPIP
Copyright (c) Microsoft Corporation.

main.cpp : Defines the entry point for the console application.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

#include "stdafx.h"
#define _Win32_DCOM
#include<iostream>
using namespace std;
#include<comdef.h>
#include<wbemidl.h>
#include<atlbase.h>
#pragma comment(lib, "wbemuuid.lib")

int _tmain(int argc, _TCHAR* argv[])
{
	// Initialize COM. ------------------------------------------
	HRESULT hres = CoInitializeEx(NULL, COINIT_APARTMENTTHREADED);
	if (FAILED(hres))
	{
		wcout << "CoInitializeEx() failure:" << hex << (unsigned long)hres;
		return 0;
	}

	// Obtain the initial locator to Windows Management
	// on a particular host computer.
	IWbemLocator *pLoc = NULL;
	hres = CoCreateInstance(CLSID_WbemLocator, 0, CLSCTX_INPROC_SERVER,IID_IWbemLocator, (LPVOID *)&pLoc);
	if (FAILED(hres))
	{
		CoUninitialize();
		wcout << "CreateInstance failure:" << hex << (unsigned long)hres;
		return 0;
	}

	// Connect to WMI through the IWbemLocator::ConnectServer method
	// Connect to the local ROOT\CIMV2 namespace
	// and obtain pointer pSvc to make IWbemServices calls.
	IWbemServices *pSvc = NULL;
	hres = pLoc->ConnectServer(L"ROOT\\CimV2", NULL,NULL, 0, NULL, 0,  0,  &pSvc);

	if (FAILED(hres))
	{
		pLoc->Release();
		CoUninitialize();
		wcout << "ConnectServer() failure:" << hex << (unsigned long)hres;
		return 0;
	}

	// Set security levels for the proxy 
	hres = CoSetProxyBlanket(pSvc, RPC_C_AUTHN_WINNT, RPC_C_AUTHZ_NONE,NULL,RPC_C_AUTHN_LEVEL_CALL, RPC_C_IMP_LEVEL_IMPERSONATE,NULL, EOAC_NONE);
	if (FAILED(hres))
	{
		pSvc->Release();
		pLoc->Release();
		CoUninitialize();
		wcout << "CoSetProxyBlanket() failure:" << hex << (unsigned long)hres;
		return 0;
	}

	IEnumWbemClassObject *pEnumerator = NULL;
	//Using the WQL we need to get the Network adapter where the IP is enabled, by firing the query: 
	//Select * From Win32_NetworkAdapterConfiguration Where IPEnabled = True
	hres = pSvc->ExecQuery(
								bstr_t("WQL"),
								bstr_t("Select * From Win32_NetworkAdapterConfiguration Where IPEnabled = True"),
								WBEM_FLAG_FORWARD_ONLY | WBEM_FLAG_RETURN_IMMEDIATELY,
								NULL,
								&pEnumerator
							);

	if (FAILED(hres))
	{
		pSvc->Release();
		pLoc->Release();
		CoUninitialize();
		wcout << "ExecQuery() failure::" << hex << (unsigned long)hres;
		return 0;
	}

	IWbemClassObject *pObjInstance = NULL;
	ULONG uReturn = 0;

	// Enumerate over every adapter configuration
	while (pEnumerator)
	{
		HRESULT hr = pEnumerator->Next(WBEM_INFINITE, 1, &pObjInstance, &uReturn);

		if (!uReturn)
			break;

		VARIANT vtProp;

		_variant_t vtWMIObjectPath;
		IWbemClassObject* pNetworkConfigClass = NULL;
		IWbemClassObject* pInSig = NULL;
		IWbemClassObject* pInSigObj = NULL;

		//By getting the __RelPath we need to get the instance of this record.
		if (SUCCEEDED(pObjInstance->Get(L"__RELPATH",0,&vtWMIObjectPath,NULL,NULL)))
		{
			// Get the class definitions so that we can retrieve method paramteters...
			hr = pSvc->GetObject(_bstr_t("Win32_NetworkAdapterConfiguration"),0,NULL,&pNetworkConfigClass,NULL);

			// Get the signature of the input arguments for EnableStatic()...
			hr = pNetworkConfigClass->GetMethod(L"SetTCPIPNetBIOS",0,&pInSig,NULL);    
			pNetworkConfigClass->Release();

			// Creating new input arguments EnableStatic()...
			hr = pInSig->SpawnInstance(0,&pInSigObj);
			pInSig->Release();


			// Ok, at this point we're ready to fill in our arguments.  
			VARIANT var;
			VariantInit(&var);
			V_VT(&var) = VT_BSTR;
			V_BSTR(&var) = SysAllocString(L"1");
			
			hr = pInSigObj->Put(L"TcpipNetbiosOptions",0,&var,NULL);
			VariantClear(&var);

			// Now we actually tell WMI to set the IP address based on our arguments we've supplied...
			hr = pSvc->ExecMethod(_bstr_t(vtWMIObjectPath), _bstr_t("SetTCPIPNetBIOS"), 0, NULL, pInSigObj, NULL, NULL);
			pInSigObj->Release();

			if (FAILED(hr))
			{
				printf("Execution of SetTCPIPNetBIOS Method Failed. Error code = 0x%8X",hr);
			}
			else
			{
				printf("*** SetTCPIPNetBIOS Successfully configured ***");
			}					
			VariantClear(&vtProp);
			if (pObjInstance) pObjInstance->Release();
		}
	}

	// Cleanup
	if (pEnumerator) pEnumerator->Release();
	if (pSvc)         pSvc->Release();
	if (pLoc)         pLoc->Release();
	CoUninitialize();    
	return 0;

}
			  