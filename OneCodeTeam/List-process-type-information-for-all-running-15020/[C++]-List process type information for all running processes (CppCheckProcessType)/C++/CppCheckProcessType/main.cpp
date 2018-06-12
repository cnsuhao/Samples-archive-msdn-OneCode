#include <Windows.h>
#include <strsafe.h>
#include "Constants.h"
#include "Enumerator.h"
#include "ProcessInfo.h"

// Enable Visual Style
#if defined _M_IX86
#pragma comment(linker,"/manifestdependency:\"type='win32' name='Microsoft.Windows.Common-Controls' version='6.0.0.0' processorArchitecture='x86' publicKeyToken='6595b64144ccf1df' language='*'\"")
#elif defined _M_IA64
#pragma comment(linker,"/manifestdependency:\"type='win32' name='Microsoft.Windows.Common-Controls' version='6.0.0.0' processorArchitecture='ia64' publicKeyToken='6595b64144ccf1df' language='*'\"")
#elif defined _M_X64
#pragma comment(linker,"/manifestdependency:\"type='win32' name='Microsoft.Windows.Common-Controls' version='6.0.0.0' processorArchitecture='amd64' publicKeyToken='6595b64144ccf1df' language='*'\"")
#else
#pragma comment(linker,"/manifestdependency:\"type='win32' name='Microsoft.Windows.Common-Controls' version='6.0.0.0' processorArchitecture='*' publicKeyToken='6595b64144ccf1df' language='*'\"")
#endif
#pragma endregion


static HINSTANCE g_hInst;
static HWND g_hRefButton;
static HWND g_hProListBox;

LRESULT CALLBACK WindowProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam);

void Button_Click()
{
	ProcessInfo piProcesssesInfo[SIZE];
	DWORD cbProcessInfo;
	DWORD cProcessInfo;
	DWORD fResult;
	UINT i;
	TCHAR line[SIZE] = L"";	

	Enumerator enumerator;

	fResult = enumerator.EnumerateProcessInfo(piProcesssesInfo,sizeof(piProcesssesInfo),&cbProcessInfo);

	if(!fResult)
	{
		return;
	}

	cProcessInfo = cbProcessInfo / sizeof(ProcessInfo);	

	SendMessage(g_hProListBox, LB_RESETCONTENT , 0, 0);

	for( i = 0; i < cProcessInfo; i++)
	{
		if(piProcesssesInfo[i].m_fIsValid)
		{
			StringCchPrintf(line,SIZE,L"PID : %d",piProcesssesInfo[i].m_dwProcessID);			
			SendMessage(g_hProListBox, LB_ADDSTRING, 0, (LPARAM)line);	
			SendMessage(g_hProListBox, LB_ADDSTRING, 0, (LPARAM)piProcesssesInfo[i].m_szFileName);
			SendMessage(g_hProListBox, LB_ADDSTRING, 0, (LPARAM)(piProcesssesInfo[i].m_fIsManaged?L"Managed Application":L"Native Application"));	
			SendMessage(g_hProListBox, LB_ADDSTRING, 0, (LPARAM)(piProcesssesInfo[i].m_fIsDotNet4?L".NET 4.0 Application":L"Not .NET 4.0 Application"));	
			SendMessage(g_hProListBox, LB_ADDSTRING, 0, (LPARAM)(piProcesssesInfo[i].m_fIsWPF?L"WPF Application":L"Not WPF Application"));	
			SendMessage(g_hProListBox, LB_ADDSTRING, 0, (LPARAM)(piProcesssesInfo[i].m_fIs64Bit?L"64 Bit Application":L"32 Bit Application"));	
			SendMessage(g_hProListBox, LB_ADDSTRING, 0, (LPARAM)(piProcesssesInfo[i].m_fIsConsole?L"Console Application":L"Windows Application"));	
			SendMessage(g_hProListBox, LB_ADDSTRING, 0, (LPARAM)L"");	
		}
	}
}

LRESULT CALLBACK WindowProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{ 
	switch(uMsg)
	{
	case WM_COMMAND:
		if(((HWND)lParam) && (HIWORD(wParam) == BN_CLICKED))
		{
			int iMID;
            iMID = LOWORD(wParam);
            switch(iMID)
			{
			case IDC_BUTTON_REF:				
				Button_Click();
				break;
			default:
				break;
			}
		}

		break;

	case WM_DESTROY:
		PostQuitMessage(0);
		return 0;
	case WM_GETMINMAXINFO:
	case WM_SIZING:
		return 0;

	case WM_CREATE:
		{
			g_hRefButton = CreateWindowEx(0,            /* more or ''extended'' styles */
				TEXT("BUTTON"),                         /* GUI ''class'' to create */
				TEXT("Refresh"),                        /* GUI caption */
				WS_CHILD|WS_VISIBLE|BS_DEFPUSHBUTTON,   /* control styles separated by | */
				10,                                     /* LEFT POSITION (Position from left) */
				10,                                     /* TOP POSITION  (Position from Top) */
				100,                                    /* WIDTH OF CONTROL */
				30,                                     /* HEIGHT OF CONTROL */
				hwnd,                                   /* Parent window handle */
				(HMENU)IDC_BUTTON_REF,                  /* control''s ID for WM_COMMAND */
				g_hInst,                                /* application instance */
				NULL);

			g_hProListBox = CreateWindowEx(0,
				L"LISTBOX",
				L"",
				WS_CHILD | WS_VISIBLE | WS_VSCROLL | WS_BORDER,
				10,
				50,
				315,
				360,
				hwnd,
				(HMENU)IDC_LISTBOX_PRO,
				g_hInst,
				NULL);

			return 1;
		}                
	}

	return DefWindowProc(hwnd, uMsg, wParam, lParam);	
}

int WINAPI wWinMain(HINSTANCE hInstance, HINSTANCE, PWSTR , int nCmdShow)
{
	const wchar_t CLASS_NAME[] = L"CppCheckProcessType";

	WNDCLASSEX wcex = { sizeof(wcex) };

    wcex.style          = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc    = WindowProc;
    wcex.cbClsExtra     = 0;
    wcex.cbWndExtra     = DLGWINDOWEXTRA;
    wcex.hInstance      = hInstance;
    wcex.hCursor        = LoadCursor(NULL, IDC_ARROW);
    wcex.hbrBackground  = (HBRUSH)(COLOR_BTNFACE+1);
    wcex.lpszMenuName   = 0;
    wcex.lpszClassName  = CLASS_NAME;

    RegisterClassEx(&wcex);

	g_hInst = hInstance;

	HWND hwnd = CreateWindowEx(
		0,
		CLASS_NAME,
		CLASS_NAME,
		WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_MINIMIZEBOX,
		5, 5, 350, 450,
		NULL,
		NULL,
		hInstance,
		NULL);

	if( hwnd == NULL )
	{
		return 0;
	}

	ShowWindow(hwnd, nCmdShow);
	UpdateWindow(hwnd);

	MSG msg = { };

	while(GetMessage(&msg,NULL,0,0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}

	return 0;
}
