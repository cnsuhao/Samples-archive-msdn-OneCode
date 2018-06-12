

#include "stdafx.h"


CRITICAL_SECTION g_csection;

//================================================================================// 
//=                                                                              =//
//= ConnectToWMINamespace()                                                      =//
//=                                                                              =//
//= Input: BSTR that indicates the namespace to connect to.                      =//
//=                                                                              =//
//= Output: Returns a IWbemServices* pointer for the namespace or NULL on        =//
//=         failure.                                                             =// 
//=                                                                              =//
//================================================================================// 

IWbemServices* ConnectToWMINamespace(char* strNamespace,char* strUsername,char* strPassword)
{
  HRESULT hres;

  hres =  CoInitializeEx(0, COINIT_MULTITHREADED); // Initialize COM.

  if (FAILED(hres))
  {
    //cout << "Failed to initialize COM library. Error code = 0x" << hex << hres << endl;
    //return NULL;                  // Program has failed.
  }


  hres =  CoInitializeSecurity( NULL, 
                                -1, 
                                NULL, 
                                NULL,

                                // *** to allow sink callbacks without using unsecapp.exe ***
                                RPC_C_AUTHN_LEVEL_NONE,       
                                //RPC_C_AUTHN_LEVEL_DEFAULT,

                                RPC_C_IMP_LEVEL_IMPERSONATE, 
                                NULL, 
                                EOAC_NONE, 
                                0);
  if (FAILED(hres))
  {
    //cout << "Failed to initialize security. Error code = 0x" << hex << hres << endl;
    //CoUninitialize();
    //return NULL;                  // Program has failed.
  }

  IWbemLocator *pLoc = 0;

  hres = CoCreateInstance(CLSID_WbemLocator, 0, 
      CLSCTX_INPROC_SERVER, IID_IWbemLocator, (LPVOID *) &pLoc);

  if (FAILED(hres))
  {
    cout << "Failed to create IWbemLocator object. Err code = 0x"<< hex << hres << endl;
    CoUninitialize();
    return NULL;     // Program has failed.
  }


  IWbemServices *pSvc = 0;

  _bstr_t bstrNamespace = strNamespace;
  _bstr_t bstrUsername = strUsername;
  _bstr_t bstrPassword = strPassword;

  // Connect to the namespace with the current user.
  hres = pLoc->ConnectServer( bstrNamespace, 
                              bstrUsername,
                              bstrPassword,
                              0,                                  
                              NULL,
                              0,                                  
                              0,                                  
                              &pSvc);

  if (FAILED(hres))
  {
    cout << "Could not connect. Error code = 0x" << hex << hres << endl;
    pLoc->Release();     
    CoUninitialize();
    return NULL;      // Program has failed.
  }

  //cout << "Connected to WMI" << endl << endl;




  // Set the proxy so that impersonation of the client occurs.
  // if you allow impersonation in the CoInitializeSecurity call
  // then you could omit this step.
  hres = SetInterfaceSecurity(pSvc,strUsername,strPassword);

  if (FAILED(hres))
  {
    cout << "Could not set proxy blanket. Error code = 0x" << hex << hres << endl;
    pSvc->Release();
    pLoc->Release();     
    CoUninitialize();
    return NULL;      // Program has failed.
  }


  // ========
  // Cleanup
  // ========

  pLoc->Release();     

  return pSvc;   // Program successfully completed.
}





//================================================================================// 
//=                                                                              =//
//= ConnectToWMINamespace()                                                      =//
//=                                                                              =//
//= Input: BSTR that indicates the namespace to connect to.                      =//
//=                                                                              =//
//= Output: Returns a IWbemServices* pointer for the namespace or NULL on        =//
//=         failure.                                                             =// 
//=                                                                              =//
//================================================================================// 

IWbemServices* ConnectToWMINamespace(_bstr_t bstrNamespace,_bstr_t bstrUsername,_bstr_t bstrPassword)
{
  HRESULT hres;

  hres =  CoInitializeEx(0, COINIT_MULTITHREADED); // Initialize COM.

  if (FAILED(hres))
  {
    //cout << "Failed to initialize COM library. Error code = 0x" << hex << hres << endl;
    //return NULL;                  // Program has failed.
  }


  hres =  CoInitializeSecurity( NULL, 
                                -1, 
                                NULL, 
                                NULL,

                                RPC_C_AUTHN_LEVEL_NONE,       // *** to allow sink callbacks ***
//                                RPC_C_AUTHN_LEVEL_DEFAULT,

                                RPC_C_IMP_LEVEL_IMPERSONATE, 
                                NULL, 
                                EOAC_NONE, 
                                0);
  if (FAILED(hres))
  {
    //cout << "Failed to initialize security. Error code = 0x" << hex << hres << endl;
    //CoUninitialize();
    //return NULL;                  // Program has failed.
  }

  IWbemLocator *pLoc = 0;

  hres = CoCreateInstance(CLSID_WbemLocator, 0, 
      CLSCTX_INPROC_SERVER, IID_IWbemLocator, (LPVOID *) &pLoc);

  if (FAILED(hres))
  {
    cout << "Failed to create IWbemLocator object. Err code = 0x"<< hex << hres << endl;
    CoUninitialize();
    return NULL;     // Program has failed.
  }


  IWbemServices *pSvc = 0;

  // Connect to the namespace with the current user.
  hres = pLoc->ConnectServer( bstrNamespace, 
                              bstrUsername,
                              bstrPassword,
                              0,                                  
                              NULL,
                              0,                                  
                              0,                                  
                              &pSvc);

  if (FAILED(hres))
  {
    cout << "Could not connect. Error code = 0x" << hex << hres << endl;
    pLoc->Release();     
    CoUninitialize();
    return NULL;      // Program has failed.
  }

  //cout << "Connected to WMI" << endl << endl;




  // Set the proxy so that impersonation of the client occurs.
  // if you allow impersonation in the CoInitializeSecurity call
  // then you could omit this step.
  hres = SetInterfaceSecurity(pSvc,bstrUsername,bstrPassword);

  if (FAILED(hres))
  {
    cout << "Could not set proxy blanket. Error code = 0x" << hex << hres << endl;
    pSvc->Release();
    pLoc->Release();     
    CoUninitialize();
    return NULL;      // Program has failed.
  }


  // ========
  // Cleanup
  // ========

  pLoc->Release();     

  return pSvc;   // Program successfully completed.
}




bool CMySink::m_bInit = false;

CMySink::CMySink()
{
  m_cRef = 1; 

  if (!m_bInit)
  {
    InitializeCriticalSection(&g_csection);
  }
}



//***************************************************************************
//
//***************************************************************************

STDMETHODIMP CMySink::QueryInterface(REFIID riid, LPVOID * ppv)
{
    *ppv = 0;

    if (IID_IUnknown==riid || IID_IWbemObjectSink == riid)
    {
        *ppv = (IWbemObjectSink *) this;
        AddRef();
        return NOERROR;
    }

    return E_NOINTERFACE;
}


//***************************************************************************
//
//***************************************************************************

ULONG CMySink::AddRef()
{
    m_cRef++;
    
    printf("*** AddRef() ---> Refcount now %i ***\n",m_cRef);

    return m_cRef;
}

//***************************************************************************
//
//***************************************************************************

ULONG CMySink::Release()
{
    m_cRef--;

    printf("*** Release() ---> Refcount now %i ***\n",m_cRef);

    if (m_cRef)
        return m_cRef;

    delete this;
    return 0;
}

//***************************************************************************
//
//***************************************************************************

HRESULT CMySink::Indicate(
    long lObjectCount,
    IWbemClassObject __RPC_FAR *__RPC_FAR *ppObjArray
    )
{
  IWbemClassObject* pInstance;

  EnterCriticalSection(&g_csection);

//  Sleep(20000);

  cout << endl << endl;

  for (long i=0; i<lObjectCount; i++)
  {
    pInstance = ppObjArray[i];

    DisplayInstance(pInstance,0);    
  }

  LeaveCriticalSection(&g_csection);

  return WBEM_NO_ERROR;
}


//***************************************************************************
//
//***************************************************************************

HRESULT CMySink::SetStatus(
    /* [in] */ long lFlags,
    /* [in] */ HRESULT hResult,
    /* [in] */ BSTR strParam,
    /* [in] */ IWbemClassObject __RPC_FAR *pObjParam
    )
{
    _bstr_t Param = strParam;

    if (strParam == NULL)
      Param = "<NULL>";

    EnterCriticalSection(&g_csection);

      cout << "\n*** Status Information ***" << endl;
      cout << "HRESULT : " << hex << hResult << "   Param : " << (char*)Param << "   Flags : " << lFlags << endl << endl;

      if (pObjParam)
          DisplayInstance(pObjParam,8);    
 
    LeaveCriticalSection(&g_csection);

        
    return WBEM_NO_ERROR;
}









//================================================================================// 
//=                                                                              =//
//= AddIndent()                                                                  =//
//=                                                                              =//
//= Input: Integer indicating the number of spaces to indent the next line of    =//
//=        output.                                                               =//
//=                                                                              =//
//= Output: console output.                                                      =// 
//=                                                                              =//
//================================================================================// 

void AddIndent(int indent)
{
  for (int i=0; i<indent; i++)
    cout << " ";
}



//================================================================================// 
//=                                                                              =//
//= DisplayInstance()                                                            =//
//=                                                                              =//
//= Input: IWbemClassObject* that references the WMI instance to be displayed.   =//
//=        Integer that indicates the indenting for this instance.               =//
//=                                                                              =//
//= Output: console output.                                                      =// 
//=                                                                              =//
//================================================================================// 

void DisplayInstance(IWbemClassObject* pInst,int Indent)
{
  /*****************************************************************************/ 
  /* Lets get a enumeration of all the properties of this class                */ 
  /*****************************************************************************/ 
  SAFEARRAY* psaPropNames = NULL;

  HRESULT hr = pInst->GetNames(NULL,WBEM_FLAG_ALWAYS|WBEM_FLAG_NONSYSTEM_ONLY,NULL,&psaPropNames);
  if (FAILED(hr))
  {
    cout << "*** GetNames on instance Failed!!!. Error code = 0x *** " << hex << hr << endl;
    return;
  }

  long LBound;
  long UBound;

  SafeArrayGetLBound(psaPropNames,1,&LBound);
  SafeArrayGetUBound(psaPropNames,1,&UBound);

  _variant_t vtClassName;
  _bstr_t bstrClassName;
  if (SUCCEEDED(pInst->Get(L"__CLASS",0,&vtClassName,NULL,NULL)))
  {
    bstrClassName = vtClassName.bstrVal;
    AddIndent(Indent);
    cout << "Instance Of " << (char*)bstrClassName << endl;
    AddIndent(Indent);
    cout << "{" << endl;
  }

  // Walk each property in the class...
  BSTR bstr;
  _bstr_t tempbstr;
  for (long x=LBound; x<=UBound; x++)
  {
    SafeArrayGetElement(psaPropNames,&x,(void*)&bstr);
    tempbstr = bstr;
    DisplayProperty(tempbstr,pInst,Indent+4);
  }

  AddIndent(Indent);
  cout << "}" << endl;

  SafeArrayDestroy(psaPropNames);
}





//================================================================================// 
//=                                                                              =//
//= DisplayProperty()                                                            =//
//=                                                                              =//
//= Input: _bstr_t that contains the BSTR name of the property to be displayed.  =//
//=        IWbemClassObject* that references the WMI instance for the property.  =//
//=        Integer that indicates the indenting for this property.               =//
//=                                                                              =//
//= Output: console output.                                                      =// 
//=                                                                              =//
//================================================================================// 

void DisplayProperty(_bstr_t bstrPropName,IWbemClassObject* pObj, int Indent)
{
  _bstr_t bstr;
  _variant_t vt;
  CIMTYPE ct;
  BSTR tempbstr;
  IWbemClassObject* pInst = NULL;
  bool bVal;
  DWORD NumVal;
  long x;

  long LBound;
  long UBound;

  AddIndent(Indent);

  HRESULT hr = pObj->Get(bstrPropName,0,&vt,&ct,NULL);
  if (FAILED(hr))
  {
    cout << "*** Failed to retrieve " << (char*)bstrPropName << "!!!. Error code = 0x ***" << hex << hr << endl;
    return;
  }

  if (vt.vt == VT_NULL)
  {
    cout << (char*)bstrPropName << ": *** VT_NULL ***" << endl;
  }
  else 
    switch(ct)
    {
      case CIM_SINT8:
      case CIM_UINT8:
      case CIM_SINT16:
      case CIM_UINT16:
      case CIM_SINT32:
      case CIM_UINT32:
      case CIM_REAL32:
      case CIM_REAL64:

        vt.ChangeType(VT_BSTR);

      case CIM_SINT64:
      case CIM_UINT64:
      case CIM_STRING:
      case CIM_REFERENCE:
      case CIM_DATETIME:

        bstr = vt.bstrVal;
        cout << (char*)bstrPropName << ": " << (char*)bstr << endl;
        break;

      case CIM_BOOLEAN:
        
        if (vt.boolVal == false)
          cout << (char*)bstrPropName << ": FALSE" << endl;
        else
          cout << (char*)bstrPropName << ": TRUE" << endl;
        break;

      case CIM_OBJECT:
          bstr = "CIM_OBJECT ...";
          cout << (char*)bstrPropName << ": " << (char*)bstr << endl << endl;
          DisplayInstance((IWbemClassObject*)vt.punkVal,Indent+8);
          cout << endl;
        break;                               

      default:
        
        if (ct&CIM_FLAG_ARRAY)
        {          

          SafeArrayGetLBound(vt.parray,1,&LBound);
          SafeArrayGetUBound(vt.parray,1,&UBound);


          // Handle Arrays
          switch (ct^CIM_FLAG_ARRAY)
          {
            case CIM_SINT8:
            case CIM_UINT8:
            case CIM_SINT16:
            case CIM_UINT16:
            case CIM_SINT32:
            case CIM_UINT32:
            case CIM_REAL32:

                bstr = "Numeric Array ...";
                cout << (char*)bstrPropName << ": " << (char*)bstr << endl << endl;

                AddIndent(Indent+8);
                cout << "{";

                for (x = LBound; x<=UBound; x++)
                {
                  SafeArrayGetElement(vt.parray,&x,(void*)&NumVal);

                  switch (ct^CIM_FLAG_ARRAY)
                  {
                    case CIM_SINT8:
                      cout << (char)NumVal;
                      break;

                    case CIM_UINT8:
                      cout << (unsigned char)NumVal;
                      break;

                    case CIM_SINT16:
                      cout << (short)NumVal;
                      break;

                    case CIM_UINT16:
                      cout << (unsigned short)NumVal;
                      break;

                    case CIM_SINT32:
                      cout << (long)NumVal;
                      break;

                    case CIM_UINT32:
                      cout << (unsigned long)NumVal;
                      break;

                    case CIM_REAL32:
                      cout << (float)NumVal;
                      break;

                    default:
                      cout << "Unknown Numeric type";
                  }

                  if (x != UBound)
                    cout << ",";
                }
                cout << "}" << endl << endl;

                break;

            case CIM_REAL64:

                break;

            case CIM_SINT64:
            case CIM_UINT64:
            case CIM_STRING:
            case CIM_REFERENCE:
            case CIM_DATETIME:

                bstr = "String Array ...";
                cout << (char*)bstrPropName << ": " << (char*)bstr << endl << endl;

                AddIndent(Indent+8);
                cout << "Array of Strings" << endl;
                AddIndent(Indent+8);
                cout << "{" << endl;

                for (x = LBound; x<=UBound; x++)
                {
                  SafeArrayGetElement(vt.parray,&x,(void*)&tempbstr);
                  bstr = "\"";
                  bstr += tempbstr;
                  bstr += "\"";
                  AddIndent(Indent+12);
                  cout << (char*)bstr << endl;
                }

                AddIndent(Indent+8);
                cout << "}" << endl << endl;
              break;

            case CIM_BOOLEAN:
                bstr = "Boolean Array ...";
                cout << (char*)bstrPropName << ": " << (char*)bstr << endl << endl;

                AddIndent(Indent+8);
                cout << "Array of Boolean" << endl;
                AddIndent(Indent+8);
                cout << "{" << endl;

                for (x = LBound; x<=UBound; x++)
                {
                  SafeArrayGetElement(vt.parray,&x,(void*)&bVal);
                  if (bVal == false)
                    bstr = "FALSE";
                  else
                    bstr = "TRUE";
                  AddIndent(Indent+12);
                  cout << (char*)bstr << endl;
                }

                AddIndent(Indent+8);
                cout << "}" << endl << endl;
              break;

            case CIM_OBJECT:
                bstr = "Object Array ...";
                cout << (char*)bstrPropName << ": " << (char*)bstr << endl << endl;

                AddIndent(Indent+8);
                cout << "Array of Objects" << endl;
                AddIndent(Indent+8);
                cout << "{" << endl;

                for (x = LBound; x<=UBound; x++)
                {
                  pInst = NULL;
                  SafeArrayGetElement(vt.parray,&x,(void*)&pInst);
                  cout << endl;
                  DisplayInstance(pInst,Indent+12);
                  cout << endl;
                }

                AddIndent(Indent+8);
                cout << "}" << endl << endl;
              break;                               

            default:
                bstr = "*** Unknown Array type ***";
                cout << (char*)bstrPropName << ": " << (char*)bstr << endl << endl;
          };
        }
        else
        {
          vt.ChangeType(VT_BSTR);        
          bstr = vt.bstrVal;
          cout << (char*)bstrPropName << ": " << (char*)bstr << endl;
        }
    };
}



//================================================================================// 
//=                                                                              =//
//= PolishEmbeddedString()                                                       =//
//=                                                                              =//
//= Input: BSTR representing a path that will be embedded in another path.       =//
//=                                                                              =//
//= Output: ANSI string path formatted to be embedded in another path.           =// 
//=                                                                              =//
//================================================================================// 

char* PolishEmbeddedString(BSTR rawbstr)
{
  _bstr_t bstr;
  bstr = rawbstr;

  char* str = (char*)bstr;
  int index = 0;

  char* buffer = new char[strlen(str) *2];

  for (unsigned int i=0; i<=strlen(str); i++)
  {
    if (str[i] == '\\')
    {
        buffer[index++] = '\\';
        buffer[index++] = '\\';
    }
    else if (str[i] == '\"')
    {
        buffer[index++] = '\\';
        buffer[index++] = '\"';
    }
    else
        buffer[index++] = str[i];
  }

  return buffer;
}



//================================================================================// 
//=                                                                              =//
//= ShowValueMapString()                                                         =//
//=                                                                              =//
//================================================================================// 

char* ShowValueMapString()
{
  return NULL;    
}




HRESULT SetInterfaceSecurity(IUnknown* pI,char* strUsername,char* strPassword)
{
  HRESULT hres;

  // Set the proxy so that impersonation of the client occurs.
  // if you allow impersonation in the CoInitializeSecurity call
  // then you could omit this step.

  if (strUsername == NULL)
  {
    hres = CoSetProxyBlanket(pI,
                             RPC_C_AUTHN_WINNT,
                             RPC_C_AUTHZ_NONE,
                             NULL,
                             RPC_C_AUTHN_LEVEL_PKT,       // *** PKT for Windows XP ***
                             RPC_C_IMP_LEVEL_IMPERSONATE,
                             NULL,
                             EOAC_NONE);

    return hres;
  }
  else
  {

    char* ptok = NULL;
    char  buffer[256];

    strcpy(buffer,strUsername);
    ptok = strtok(buffer,"\\");

    _bstr_t bstrUsername = strUsername;
    _bstr_t bstrPassword = strPassword;
    _bstr_t bstrDomain;

    if (ptok)    
    {
      bstrDomain = ptok;
      ptok = strtok(NULL,"\\");
      bstrUsername = ptok;
    }


    COAUTHIDENTITY* cID = (COAUTHIDENTITY*) CoTaskMemAlloc(sizeof(COAUTHIDENTITY));

    cID->User = (unsigned short*) CoTaskMemAlloc(bstrUsername.length());
    wcscpy(cID->User,(wchar_t*)bstrUsername);
    cID->UserLength = bstrUsername.length();

    cID->Password = (unsigned short*) CoTaskMemAlloc(bstrPassword.length());
    wcscpy(cID->Password,(wchar_t*)bstrPassword);
    cID->PasswordLength = bstrPassword.length();

    cID->Domain = (unsigned short*) CoTaskMemAlloc(bstrDomain.length());
    wcscpy(cID->Domain,(wchar_t*)bstrDomain);
    cID->DomainLength = bstrDomain.length();
    cID->Flags = SEC_WINNT_AUTH_IDENTITY_UNICODE;


    hres = CoSetProxyBlanket(pI,
                             RPC_C_AUTHN_DEFAULT,
                             RPC_C_AUTHZ_NONE,
                             NULL,
                             RPC_C_AUTHN_LEVEL_DEFAULT,
                             RPC_C_IMP_LEVEL_IMPERSONATE,
                             cID,
                             EOAC_NONE);


    IUnknown* pUnknown = NULL;
    hres = pI->QueryInterface(IID_IUnknown,(void**)&pUnknown);
    hres = CoSetProxyBlanket(pUnknown,
                             RPC_C_AUTHN_DEFAULT,
                             RPC_C_AUTHZ_NONE,
                             NULL,
                             RPC_C_AUTHN_LEVEL_DEFAULT,
                             RPC_C_IMP_LEVEL_IMPERSONATE,
                             cID,
                             EOAC_NONE);

    //pUnknown->Release();

    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    // !!! Free memory as follows sometime before CoUninitialize() !!!
    // !!! After the WMI interfaces have been released             !!!
    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    //CoTaskMemFree(cID->User);
    //CoTaskMemFree(cID->Password);
    //CoTaskMemFree(cID->Domain);
    //CoTaskMemFree(cID);

    return hres;
  }
}



HRESULT SetInterfaceSecurity(IUnknown* pI,_bstr_t bstrUsername,_bstr_t bstrPassword,_bstr_t bstrPrincipal)
{
  HRESULT hres;

  // Set the proxy so that impersonation of the client occurs.
  // if you allow impersonation in the CoInitializeSecurity call
  // then you could omit this step.

  if (bstrUsername.length == 0)
  {
    hres = CoSetProxyBlanket(pI,
                             RPC_C_AUTHN_GSS_KERBEROS,
                             RPC_C_AUTHZ_DEFAULT,
                             bstrPrincipal,
                             RPC_C_AUTHN_LEVEL_PKT,       // *** PKT for Windows XP ***
                             RPC_C_IMP_LEVEL_IMPERSONATE,
                             NULL,
                             EOAC_NONE);

    return hres;
  }
  else
  {
    COAUTHIDENTITY cID;

    wchar_t* ptok = NULL;
    wchar_t  buffer[256];

    wcscpy(buffer,bstrUsername);
    ptok = wcstok(buffer,L"\\");

    _bstr_t bstrDomain;

    if (ptok)    
    {
      bstrDomain = ptok;
      ptok = wcstok(NULL,L"\\");
      bstrUsername = ptok;
    }

    cID.User = bstrUsername;
    cID.UserLength = bstrUsername.length();
    cID.Password = bstrPassword;
    cID.PasswordLength = bstrPassword.length();
    cID.Domain = bstrDomain;
    cID.DomainLength = bstrDomain.length();
    cID.Flags = SEC_WINNT_AUTH_IDENTITY_UNICODE;


    hres = CoSetProxyBlanket(pI,
                             RPC_C_AUTHN_GSS_KERBEROS,
                             RPC_C_AUTHZ_DEFAULT,
                             bstrPrincipal,
                             RPC_C_AUTHN_LEVEL_PKT,       // *** PKT for Windows XP ***
                             RPC_C_IMP_LEVEL_IMPERSONATE,
                             &cID,
                             EOAC_NONE);

    return hres;
  }
}



//--------------------------------------------------------------------
// based on Keith Brown (MSJ August 1999 column)
// 
BOOL EnablePrivilege(LPCTSTR szPrivilege)
{
   BOOL bReturn = FALSE;

   HANDLE hToken;
   if (!::OpenProcessToken(::GetCurrentProcess(), TOKEN_QUERY | TOKEN_ADJUST_PRIVILEGES, &hToken))
      return(FALSE);

   TOKEN_PRIVILEGES tpOld;
   bReturn = (EnableTokenPrivilege(hToken, szPrivilege, tpOld));

// don't forget to close the token handle
   ::CloseHandle(hToken);

   return(bReturn);
}



// Useful helper function for enabling a single privilege
BOOL EnableTokenPrivilege(HANDLE htok, LPCTSTR szPrivilege, TOKEN_PRIVILEGES& tpOld)
{
   TOKEN_PRIVILEGES tp;
   tp.PrivilegeCount = 1;
   tp.Privileges[0].Attributes = SE_PRIVILEGE_ENABLED;
   if (LookupPrivilegeValue(0, szPrivilege, &tp.Privileges[0].Luid))
   {
   // htok must have been opened with the following permissions:
   // TOKEN_QUERY (to get the old priv setting)
   // TOKEN_ADJUST_PRIVILEGES (to adjust the priv)
      DWORD cbOld = sizeof tpOld;
      if (AdjustTokenPrivileges(htok, FALSE, &tp, cbOld, &tpOld, &cbOld))
      // Note that AdjustTokenPrivileges may succeed, and yet
      // some privileges weren't actually adjusted.
      // You've got to check GetLastError() to be sure!
         return(ERROR_NOT_ALL_ASSIGNED != GetLastError());
      else
         return(FALSE);
   }
   else
      return(FALSE);
}
