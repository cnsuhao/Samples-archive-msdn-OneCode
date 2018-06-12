
#define _WIN32_DCOM

#include <stdlib.h>
#include <iostream>
using namespace std;
#include <wbemcli.h>
#include <comdef.h>
#include <objbase.h>
#include <conio.h>


extern CRITICAL_SECTION g_csection;


//================================================================================//  
//=                                                                              =// 
//= CMySink class for Asynchronous calls                                         =//
//=                                                                              =//
//================================================================================// 

class CMySink : public IWbemObjectSink
{
    UINT m_cRef;

  public:

    static bool m_bInit;

    CMySink(); 
   ~CMySink() { }

    //
    // IUnknown members
    //
    STDMETHODIMP         QueryInterface(REFIID, LPVOID *);
    STDMETHODIMP_(ULONG) AddRef(void);
    STDMETHODIMP_(ULONG) Release(void);

    virtual HRESULT STDMETHODCALLTYPE Indicate(
            /* [in] */ long lObjectCount,
            /* [size_is][in] */ IWbemClassObject __RPC_FAR *__RPC_FAR *ppObjArray);

    virtual HRESULT STDMETHODCALLTYPE SetStatus(
            /* [in] */ long lFlags,
            /* [in] */ HRESULT hResult,
            /* [in] */ BSTR strParam,
            /* [in] */ IWbemClassObject __RPC_FAR *pObjParam);
};



//================================================================================//  
//=                                                                              =// 
//= ConnectToWMINamespace()                                                      =//
//=                                                                              =//
//=                                                                              =//
//= Input: BSTR that indicates the namespace to connect to.                      =//
//=                                                                              =//
//= Output: Returns a IWbemServices* pointer for the namespace or NULL on        =//
//=         failure.                                                             =// 
//=                                                                              =//
//================================================================================// 
IWbemServices* ConnectToWMINamespace(char* strNamespace,
                                     char* strUsername=NULL,
                                     char* strPassword=NULL);

IWbemServices* ConnectToWMINamespace(_bstr_t bstrNamespace,
                                     _bstr_t bstrUsername,
                                     _bstr_t strPassword);


//================================================================================// 
//=                                                                              =//
//= DisplayInstance()                                                            =//
//=                                                                              =//
//=                                                                              =//
//= Input: IWbemClassObject* that references the WMI instance to be displayed.   =//
//=        Integer that indicates the indenting for this instance.               =//
//=                                                                              =//
//= Output: console output.                                                      =// 
//=                                                                              =//
//================================================================================// 
void DisplayInstance(IWbemClassObject* pInst,int Indent=0);



//================================================================================// 
//=                                                                              =//
//= DisplayProperty()                                                            =//
//=                                                                              =//
//=                                                                              =//
//= Input: _bstr_t that contains the BSTR name of the property to be displayed.  =//
//=        IWbemClassObject* that references the WMI instance for the property.  =//
//=        Integer that indicates the indenting for this property.               =//
//=                                                                              =//
//= Output: console output.                                                      =// 
//=                                                                              =//
//================================================================================// 
void DisplayProperty(_bstr_t bstrPropName,IWbemClassObject* pObj, int Indent);



//================================================================================// 
//=                                                                              =//
//= PolishEmbeddedString()                                                       =//
//=                                                                              =//
//= embedded quotes (") use C string escape sequence (\") as also                =//
//= embedded (\) use (\\)                                                        =//
//=                                                                              =//
//=                                                                              =//
//= Input: BSTR representing a path that will be embedded in another path.       =//
//=                                                                              =//
//= Output: ANSI string path formatted to be embedded in another path.           =// 
//=                                                                              =//
//================================================================================// 

char* PolishEmbeddedString(BSTR rawbstr);



HRESULT SetInterfaceSecurity(IUnknown* pI,char* strUsername=NULL,char* strPassword=NULL);
HRESULT SetInterfaceSecurity(IUnknown* pI,_bstr_t bstrUsername,_bstr_t bstrPassword,_bstr_t bstrPrincipal="");



BOOL EnablePrivilege(LPCTSTR szPrivilege);
BOOL EnableTokenPrivilege(HANDLE htok, LPCTSTR szPrivilege, TOKEN_PRIVILEGES& tpOld);
