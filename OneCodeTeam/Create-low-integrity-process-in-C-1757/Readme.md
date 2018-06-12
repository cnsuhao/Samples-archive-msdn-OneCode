# Create low-integrity process in C++ (CppCreateLowIntegrityProcess)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* Windows SDK
## Topics
* Security
* UAC
* Integrity Level
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:36:55
## Description

<h1><span style="font-family:������">WIN32 APPLICATION</span> (<span style="font-family:������">CppCreateLowIntegrityProcess</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The code sample demonstrates how to start a low-integrity process. The application launches itself at the low integrity level when you click the &quot;Launch myself at low integrity level&quot; button on the application. Low integrity
 processes can only write to low integrity locations, such as the %USERPROFILE%\AppData\LocalLow folder or the HKEY_CURRENT_USER\Software\AppDataLow key. If you attempt to gain write access to objects at a higher integrity levels, you will get an access denied
 error even though the user's SID is granted write access in the discretionary access control list (DACL).
</p>
<p class="MsoNormal">By default, child processes inherit the integrity level of their parent process. To start a low-integrity process, you must start a new child process<span style="">
</span>with a low-integrity access token by using CreateProcessAsUser. Please refer to the CreateLowIntegrityProcess sample function for details.<span style="">&nbsp;
</span><span style=""></span></p>
<h2><span style="">Compiling the code </span></h2>
<p class="MsoNormal"><span style="">You must run this sample on Windows Vista or newer operating systems.
</span></p>
<h2>Running the<span style=""> sample </span></h2>
<p class="MsoNormal"><span style="">Step1. After you successfully build the sample project in Visual Studio 2008, you will get the application: CppCreateLowIntegrityProcess.exe.
</span></p>
<p class="MsoNormal"><span style="">Step2. Run the application as an ordinary user on a Windows Vista or Windows 7 system with UAC fully enabled. The application should display the following main dialog.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53166/1/image.png" alt="" width="241" height="189" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">The process is running at the Medium integrity level. If you click on the [Write to the LocalAppData folder] button or the [Write to the LocalAppDataLow folder] button, you will get a message box saying that the file write
 operation succeeds as follow: </span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53167/1/image.png" alt="" width="380" height="171" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">Step3. Click on the [Launch myself at low integrity level] button. A new instance of the CppCreateLowIntegrityProcess application is launched as follow, but this time, it is running at the Low integrity level.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53168/1/image.png" alt="" width="241" height="189" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">If you click on the [Write to the LocalAppData folder] button, you will get the 0x80070005 error (Access Denied) with the following message.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53169/1/image.png" alt="" width="478" height="171" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">This indicates that the low-integrity process is denied to write to the LocalAppData known folder (%USERPROFILE%\AppData\Local\) because the folder has a higher (Medium) integrity level:
</span></p>
<p class="MsoNormal"><span style="">If you click on the [Write to the LocalAppDataLow folder] button, the low-integrity process is able to write to the LocalAppDataLow known folder (%USERPROFILE%\AppData\LocalLow\) when you click the [Write to the LocalAppDataLow
 folder] button, because the folder has the same Low integrity level: </span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53170/1/image.png" alt="" width="380" height="171" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">Step4. Close the application and clean up the test files (testfile.txt) created by the application in %USERPROFILE%\AppData\Local\ and %USERPROFILE%\AppData\LocalLow\.
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">A. Starting a process at low integrity </p>
<p class="MsoNormal">By default, child processes inherit the integrity level of their parent process. To start a low-integrity process, you must start a new child process with a low-integrity access token using the function CreateProcessAsUser.
</p>
<p class="MsoNormal">To start a low-integrity process </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
  // Open the primary access token of the process.
  if (!OpenProcessToken(GetCurrentProcess(), TOKEN_DUPLICATE | TOKEN_QUERY |
      TOKEN_ADJUST_DEFAULT | TOKEN_ASSIGN_PRIMARY, &hToken))
  {
      dwError = GetLastError();
      goto Cleanup;
  }


  // Duplicate the primary token of the current process.
  if (!DuplicateTokenEx(hToken, 0, NULL, SecurityImpersonation, 
      TokenPrimary, &hNewToken))
  {
      dwError = GetLastError();
      goto Cleanup;
  }


  // Create the low integrity SID.
  if (!AllocateAndInitializeSid(&MLAuthority, 1, SECURITY_MANDATORY_LOW_RID, 
      0, 0, 0, 0, 0, 0, 0, &pIntegritySid))
  {
      dwError = GetLastError();
      goto Cleanup;
  }


  tml.Label.Attributes = SE_GROUP_INTEGRITY;
  tml.Label.Sid = pIntegritySid;


  // Set the integrity level in the access token to low.
  if (!SetTokenInformation(hNewToken, TokenIntegrityLevel, &tml, 
      (sizeof(tml) &#43; GetLengthSid(pIntegritySid))))
  {
      dwError = GetLastError();
      goto Cleanup;
  }


  // Create the new process at the Low integrity level.
  if (!CreateProcessAsUser(hNewToken, NULL, pszCommandLine, NULL, NULL, 
      FALSE, 0, NULL, NULL, &si, &pi))
  {
      dwError = GetLastError();
      goto Cleanup;
  }

</pre>
<pre id="codePreview" class="cplusplus">
  // Open the primary access token of the process.
  if (!OpenProcessToken(GetCurrentProcess(), TOKEN_DUPLICATE | TOKEN_QUERY |
      TOKEN_ADJUST_DEFAULT | TOKEN_ASSIGN_PRIMARY, &hToken))
  {
      dwError = GetLastError();
      goto Cleanup;
  }


  // Duplicate the primary token of the current process.
  if (!DuplicateTokenEx(hToken, 0, NULL, SecurityImpersonation, 
      TokenPrimary, &hNewToken))
  {
      dwError = GetLastError();
      goto Cleanup;
  }


  // Create the low integrity SID.
  if (!AllocateAndInitializeSid(&MLAuthority, 1, SECURITY_MANDATORY_LOW_RID, 
      0, 0, 0, 0, 0, 0, 0, &pIntegritySid))
  {
      dwError = GetLastError();
      goto Cleanup;
  }


  tml.Label.Attributes = SE_GROUP_INTEGRITY;
  tml.Label.Sid = pIntegritySid;


  // Set the integrity level in the access token to low.
  if (!SetTokenInformation(hNewToken, TokenIntegrityLevel, &tml, 
      (sizeof(tml) &#43; GetLengthSid(pIntegritySid))))
  {
      dwError = GetLastError();
      goto Cleanup;
  }


  // Create the new process at the Low integrity level.
  if (!CreateProcessAsUser(hNewToken, NULL, pszCommandLine, NULL, NULL, 
      FALSE, 0, NULL, NULL, &si, &pi))
  {
      dwError = GetLastError();
      goto Cleanup;
  }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">CreateProcessAsUser updates the security descriptor in the new child process and the security descriptor for the access token to match the integrity level of the low-integrity access token. The CreateLowIntegrityProcess function in the
 code sample demonstrates this process. </p>
<p class="MsoNormal">B. Detecting the integrity level of the current process </p>
<p class="MsoNormal">The GetProcessIntegrityLevel function in the code sample demonstrates how to get the integrity level of the current process.
<span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
BOOL GetProcessIntegrityLevel(PDWORD pdwIntegrityLevel)
{
    DWORD dwError = ERROR_SUCCESS;
    HANDLE hToken = NULL;
    DWORD cbTokenIL = 0;
    PTOKEN_MANDATORY_LABEL pTokenIL = NULL;


    if (pdwIntegrityLevel == NULL)
    {
        dwError = ERROR_INVALID_PARAMETER;
        goto Cleanup;
    }


    // Open the primary access token of the process with TOKEN_QUERY.
    if (!OpenProcessToken(GetCurrentProcess(), TOKEN_QUERY, &hToken))
    {
        dwError = GetLastError();
        goto Cleanup;
    }


    // Query the size of the token integrity level information. Note that 
    // we expect a FALSE result and the last error ERROR_INSUFFICIENT_BUFFER
    // from GetTokenInformation because we have given it a NULL buffer. On 
    // exit cbTokenIL will tell the size of the integrity level information.
    if (!GetTokenInformation(hToken, TokenIntegrityLevel, NULL, 0, &cbTokenIL))
    {
        if (ERROR_INSUFFICIENT_BUFFER != GetLastError())
        {
            // When the process is run on operating systems prior to Windows 
            // Vista, GetTokenInformation returns FALSE with the 
            // ERROR_INVALID_PARAMETER error code because TokenElevation 
            // is not supported on those operating systems.
            dwError = GetLastError();
            goto Cleanup;
        }
    }


    // Now we allocate a buffer for the integrity level information.
    pTokenIL = (TOKEN_MANDATORY_LABEL *)LocalAlloc(LPTR, cbTokenIL);
    if (pTokenIL == NULL)
    {
        dwError = GetLastError();
        goto Cleanup;
    }


    // Retrieve token integrity level information.
    if (!GetTokenInformation(hToken, TokenIntegrityLevel, pTokenIL, 
        cbTokenIL, &cbTokenIL))
    {
        dwError = GetLastError();
        goto Cleanup;
    }


    // Integrity Level SIDs are in the form of S-1-16-0xXXXX. (e.g. 
    // S-1-16-0x1000 stands for low integrity level SID). There is one and 
    // only one subauthority.
    *pdwIntegrityLevel = *GetSidSubAuthority(pTokenIL-&gt;Label.Sid, 0);


Cleanup:
    // Centralized cleanup for all allocated resources.
    if (hToken)
    {
        CloseHandle(hToken);
        hToken = NULL;
    }
    if (pTokenIL)
    {
        LocalFree(pTokenIL);
        pTokenIL = NULL;
        cbTokenIL = 0;
    }


    if (ERROR_SUCCESS != dwError)
    {
        // Make sure that the error code is set for failure.
        SetLastError(dwError);
        return FALSE;
    }
    else
    {
        return TRUE;
    }
}

</pre>
<pre id="codePreview" class="cplusplus">
BOOL GetProcessIntegrityLevel(PDWORD pdwIntegrityLevel)
{
    DWORD dwError = ERROR_SUCCESS;
    HANDLE hToken = NULL;
    DWORD cbTokenIL = 0;
    PTOKEN_MANDATORY_LABEL pTokenIL = NULL;


    if (pdwIntegrityLevel == NULL)
    {
        dwError = ERROR_INVALID_PARAMETER;
        goto Cleanup;
    }


    // Open the primary access token of the process with TOKEN_QUERY.
    if (!OpenProcessToken(GetCurrentProcess(), TOKEN_QUERY, &hToken))
    {
        dwError = GetLastError();
        goto Cleanup;
    }


    // Query the size of the token integrity level information. Note that 
    // we expect a FALSE result and the last error ERROR_INSUFFICIENT_BUFFER
    // from GetTokenInformation because we have given it a NULL buffer. On 
    // exit cbTokenIL will tell the size of the integrity level information.
    if (!GetTokenInformation(hToken, TokenIntegrityLevel, NULL, 0, &cbTokenIL))
    {
        if (ERROR_INSUFFICIENT_BUFFER != GetLastError())
        {
            // When the process is run on operating systems prior to Windows 
            // Vista, GetTokenInformation returns FALSE with the 
            // ERROR_INVALID_PARAMETER error code because TokenElevation 
            // is not supported on those operating systems.
            dwError = GetLastError();
            goto Cleanup;
        }
    }


    // Now we allocate a buffer for the integrity level information.
    pTokenIL = (TOKEN_MANDATORY_LABEL *)LocalAlloc(LPTR, cbTokenIL);
    if (pTokenIL == NULL)
    {
        dwError = GetLastError();
        goto Cleanup;
    }


    // Retrieve token integrity level information.
    if (!GetTokenInformation(hToken, TokenIntegrityLevel, pTokenIL, 
        cbTokenIL, &cbTokenIL))
    {
        dwError = GetLastError();
        goto Cleanup;
    }


    // Integrity Level SIDs are in the form of S-1-16-0xXXXX. (e.g. 
    // S-1-16-0x1000 stands for low integrity level SID). There is one and 
    // only one subauthority.
    *pdwIntegrityLevel = *GetSidSubAuthority(pTokenIL-&gt;Label.Sid, 0);


Cleanup:
    // Centralized cleanup for all allocated resources.
    if (hToken)
    {
        CloseHandle(hToken);
        hToken = NULL;
    }
    if (pTokenIL)
    {
        LocalFree(pTokenIL);
        pTokenIL = NULL;
        cbTokenIL = 0;
    }


    if (ERROR_SUCCESS != dwError)
    {
        // Make sure that the error code is set for failure.
        SetLastError(dwError);
        return FALSE;
    }
    else
    {
        return TRUE;
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/bb625960.aspx">MSDN: Designing Applications to Run at a Low Integrity Level</a>
</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/bb250462(VS.85).aspx">MSDN: Understanding and Working in Protected Mode Internet Explorer</a>
</p>
<p class="MsoListParagraphCxSpLast"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
