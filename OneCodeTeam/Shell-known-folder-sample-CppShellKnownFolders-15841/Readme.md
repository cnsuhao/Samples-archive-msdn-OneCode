# Shell known folder sample (CppShellKnownFolders)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows Shell
* Windows SDK
## Topics
* Shell known folder
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:33:51
## Description

<h1><span style="font-family:������">CONSOLE APPLICATION</span> (<span style="font-family:������">CppShellKnownFolders</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/bb776911(v=vs.85).aspx">
Known Folder</a> system provides a way to interact with certain high-profile folders that are present by default in Microsoft Windows. It also allows those same interactions with folders installed and registered with the Known Folder system by applications.
 This sample demonstrates those possible interactions as they are provided by the Known Folder APIs.<span style="">
</span></p>
<p class="MsoNormal"><span style="">A. Enumerate and print all known folders. (PrintAllKnownFolders)
</span></p>
<p class="MsoNormal"><span style="">B. Print some built-in known folders like FOLDERID_ProgramFiles in three different ways. (PrintSomeDefaultKnownFolders)
</span></p>
<p class="MsoNormal"><span style="">C. Extend known folders with custom folders.
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp; </span>1. Register and create a known folder named &quot;Sample KnownFolder&quot; under the user profile folder: C:\Users\&lt;username&gt;\SampleKnownFolder. The known folder displays the localized
 name &quot;Sample KnownFolder LocalizedName&quot;, and <span style="">&nbsp;&nbsp;</span>shows a folder icon with the Sample logo. (CreateKnownFolder, RegisterKnownFolder)<span style="">&nbsp;
</span></span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp; </span>2 Print the known folder. (PrintKnownFolder)<span style="">&nbsp;
</span></span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp; </span>3 Remove and unregister the known folder. (RemoveKnownFolder, UnregisterKnownFolder)
</span></p>
<h2><span style="">Compiling the code </span></h2>
<p class="MsoNormal"><span style="">Most Known Folder APIs and interfaces demonstrated in this sample, such as IKnownFolderManager and SHGetKnownFolderPath, are new in Windows Vista. You must run the sample on Windows Vista or later operating systems.
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53132/1/image.png" alt="" width="576" height="485" align="middle">
</span><span style=""></span></p>
<h2><span style="">Using the code </span></h2>
<h3>A. Enumerate and print all known folders. (PrintAllKnownFolders) </h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
void PrintAllKnownFolders()
{
    HRESULT hr;
    PWSTR pszPath = NULL;


    // Create an IKnownFolderManager instance
    IKnownFolderManager* pkfm = NULL;
    hr = CoCreateInstance(CLSID_KnownFolderManager, NULL, 
        CLSCTX_INPROC_SERVER, IID_PPV_ARGS(&pkfm));
    if (SUCCEEDED(hr))
    {
        KNOWNFOLDERID *rgKFIDs = NULL;
        UINT cKFIDs = 0;
        // Get the IDs of all known folders
        hr = pkfm-&gt;GetFolderIds(&rgKFIDs, &cKFIDs);
        if (SUCCEEDED(hr))
        {
            IKnownFolder *pkfCurrent = NULL;
            // Enumerate the known folders. rgKFIDs[i] has the KNOWNFOLDERID
            for (UINT i = 0; i &lt; cKFIDs; &#43;&#43;i)
            {
                hr = pkfm-&gt;GetFolder(rgKFIDs[i], &pkfCurrent);
                if (SUCCEEDED(hr))
                {
                    // Get the non-localized, canonical name for the known 
                    // folder from KNOWNFOLDER_DEFINITION
                    KNOWNFOLDER_DEFINITION kfd;
                    hr = pkfCurrent-&gt;GetFolderDefinition(&kfd);
                    if (SUCCEEDED(hr))
                    {
                        // Next, get the path of the known folder
                        hr = pkfCurrent-&gt;GetPath(0, &pszPath);
                        if (SUCCEEDED(hr))
                        {
                            wprintf(L&quot;%s: %s\n&quot;, kfd.pszName, pszPath);
                            CoTaskMemFree(pszPath);
                        }
                        FreeKnownFolderDefinitionFields(&kfd);
                    }
                    pkfCurrent-&gt;Release();
                }
            }
            CoTaskMemFree(rgKFIDs);
        }
        pkfm-&gt;Release();
    }
}

</pre>
<pre id="codePreview" class="cplusplus">
void PrintAllKnownFolders()
{
    HRESULT hr;
    PWSTR pszPath = NULL;


    // Create an IKnownFolderManager instance
    IKnownFolderManager* pkfm = NULL;
    hr = CoCreateInstance(CLSID_KnownFolderManager, NULL, 
        CLSCTX_INPROC_SERVER, IID_PPV_ARGS(&pkfm));
    if (SUCCEEDED(hr))
    {
        KNOWNFOLDERID *rgKFIDs = NULL;
        UINT cKFIDs = 0;
        // Get the IDs of all known folders
        hr = pkfm-&gt;GetFolderIds(&rgKFIDs, &cKFIDs);
        if (SUCCEEDED(hr))
        {
            IKnownFolder *pkfCurrent = NULL;
            // Enumerate the known folders. rgKFIDs[i] has the KNOWNFOLDERID
            for (UINT i = 0; i &lt; cKFIDs; &#43;&#43;i)
            {
                hr = pkfm-&gt;GetFolder(rgKFIDs[i], &pkfCurrent);
                if (SUCCEEDED(hr))
                {
                    // Get the non-localized, canonical name for the known 
                    // folder from KNOWNFOLDER_DEFINITION
                    KNOWNFOLDER_DEFINITION kfd;
                    hr = pkfCurrent-&gt;GetFolderDefinition(&kfd);
                    if (SUCCEEDED(hr))
                    {
                        // Next, get the path of the known folder
                        hr = pkfCurrent-&gt;GetPath(0, &pszPath);
                        if (SUCCEEDED(hr))
                        {
                            wprintf(L&quot;%s: %s\n&quot;, kfd.pszName, pszPath);
                            CoTaskMemFree(pszPath);
                        }
                        FreeKnownFolderDefinitionFields(&kfd);
                    }
                    pkfCurrent-&gt;Release();
                }
            }
            CoTaskMemFree(rgKFIDs);
        }
        pkfm-&gt;Release();
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">&nbsp; </span></p>
<p class="MsoNormal">B. Print some built-in known folders like FOLDERID_ProgramFiles in three different ways. (PrintSomeDefaultKnownFolders)
</p>
<p class="MsoNormal"></p>
<p class="MsoNormal"><span style="">&nbsp; </span>Method 1. Use SHGetKnownFolderPath (The function is new in Windows Vista)<span style="">&nbsp;
</span>The system <a href="http://msdn.microsoft.com/en-us/library/bb762584(VS.85).aspx">
default KNOWNFOLDERIDs</a> <span style="">. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">  
    hr = SHGetKnownFolderPath(FOLDERID_ProgramFiles, 0, NULL, 
        &pszPath);
    if (SUCCEEDED(hr))
    {
        wprintf(L&quot;FOLDERID_ProgramFiles: %s\n&quot;, pszPath);


        // The calling application is responsible for calling CoTaskMemFree 
        // to free this resource after use.
        CoTaskMemFree(pszPath);
    }

</pre>
<pre id="codePreview" class="cplusplus">  
    hr = SHGetKnownFolderPath(FOLDERID_ProgramFiles, 0, NULL, 
        &pszPath);
    if (SUCCEEDED(hr))
    {
        wprintf(L&quot;FOLDERID_ProgramFiles: %s\n&quot;, pszPath);


        // The calling application is responsible for calling CoTaskMemFree 
        // to free this resource after use.
        CoTaskMemFree(pszPath);
    }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal"><span style="">&nbsp; </span>Method 2. Use IKnownFolderManager::GetGetFolder, IKnownFolder::GetPath
<span style="">&nbsp;</span>(The functions are new in Windows Vista) </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
    IKnownFolderManager* pkfm = NULL;
    hr = CoCreateInstance(CLSID_KnownFolderManager, NULL, 
        CLSCTX_INPROC_SERVER, IID_PPV_ARGS(&pkfm));
    if (SUCCEEDED(hr))
    {
        IKnownFolder* pkf = NULL;
        hr = pkfm-&gt;GetFolder(FOLDERID_ProgramFiles, &pkf);
        if (SUCCEEDED(hr))
        {
            hr = pkf-&gt;GetPath(0, &pszPath);
            if (SUCCEEDED(hr))
            {
                wprintf(L&quot;FOLDERID_ProgramFiles: %s\n&quot;, pszPath);


                // The calling application is responsible for calling 
                // CoTaskMemFree to free this resource after use.
                CoTaskMemFree(pszPath);
            }
            pkf-&gt;Release();
        }
        pkfm-&gt;Release();
    }

</pre>
<pre id="codePreview" class="cplusplus">
    IKnownFolderManager* pkfm = NULL;
    hr = CoCreateInstance(CLSID_KnownFolderManager, NULL, 
        CLSCTX_INPROC_SERVER, IID_PPV_ARGS(&pkfm));
    if (SUCCEEDED(hr))
    {
        IKnownFolder* pkf = NULL;
        hr = pkfm-&gt;GetFolder(FOLDERID_ProgramFiles, &pkf);
        if (SUCCEEDED(hr))
        {
            hr = pkf-&gt;GetPath(0, &pszPath);
            if (SUCCEEDED(hr))
            {
                wprintf(L&quot;FOLDERID_ProgramFiles: %s\n&quot;, pszPath);


                // The calling application is responsible for calling 
                // CoTaskMemFree to free this resource after use.
                CoTaskMemFree(pszPath);
            }
            pkf-&gt;Release();
        }
        pkfm-&gt;Release();
    }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">&nbsp; </span>Method 3. Use SHGetFolderPath (The function is deprecated. As of Windows
<span style="">&nbsp;</span>Vista, this function is merely a wrapper for SHGetKnownFolderPath.)
</p>
<p class="MsoNormal"><span style="">&nbsp; </span>The CSIDLs of the system <a href="http://msdn.microsoft.com/en-us/library/bb762494(VS.85).aspx">
default known folders</a> <span style="">.</span><span style="">&nbsp; </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
    TCHAR szFolderPath[MAX_PATH];
    hr = SHGetFolderPath(NULL, CSIDL_PROGRAM_FILES, NULL, SHGFP_TYPE_CURRENT, 
        szFolderPath);
    if (SUCCEEDED(hr))
    {
        _tprintf(_T(&quot;FOLDERID_ProgramFiles: %s\n&quot;), szFolderPath);
    }

</pre>
<pre id="codePreview" class="cplusplus">
    TCHAR szFolderPath[MAX_PATH];
    hr = SHGetFolderPath(NULL, CSIDL_PROGRAM_FILES, NULL, SHGFP_TYPE_CURRENT, 
        szFolderPath);
    if (SUCCEEDED(hr))
    {
        _tprintf(_T(&quot;FOLDERID_ProgramFiles: %s\n&quot;), szFolderPath);
    }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">C. Extend known folders with custom folders. </p>
<p class="MsoNormal">Independent software vendors (ISVs) can extend the set of known folders on a system by registering known folders of their own. Once registered, those third-party folders are known to the system. They are found by any call to GetFolderIds.
 Note that a known folder must be a per-machine folder. You cannot create a per-user known folder. Registering or unregistering a known folder requires dministrator privilege.
</p>
<p class="MsoNormal"><span style="">&nbsp; </span>1 Register and create a known folder named &quot;Sample KnownFolder&quot; under the
<span style="">&nbsp;&nbsp;</span>user profile folder: C:\Users\&lt;username&gt;\SampleKnownFolder. The known
<span style="">&nbsp;&nbsp;</span>folder displays the localized name &quot;Sample KnownFolder LocalizedName&quot;, and shows a folder icon with the Sample logo.
<span style="">&nbsp;</span>(CreateKnownFolder, RegisterKnownFolder)<span style="">&nbsp;
</span>CreateKnownFolder calls RegisterKnownFolder to register a known folder. In
</p>
<p class="MsoNormal"><span style="">&nbsp; </span>RegisterKnownFolder, first define the known folder through a
<span style="">&nbsp;</span>KNOWNFOLDER_DEFINITION structure. You can specify the known folder's canonical name, localized name, tooltip, folder icon, etc. Then register
<span style="">&nbsp;&nbsp;</span>the known folder through a call to IKnownFolderManager::RegisterFolder.
<span style="">&nbsp;</span>IKnownFolderManager::RegisterFolder requires that the current process is
<span style="">&nbsp;</span>run as administrator to succeed. <span style="">&nbsp;&nbsp;</span>
</p>
<p class="MsoNormal"><span style="">&nbsp; </span>After the known folder is register, CreateKnownFolder initializes and creates the folder with SHGetKnownFolderPath with the flags KF_FLAG_CREATE | KF_FLAG_INIT so that the Shell will write desktop.ini in the
 folder. This <span style="">&nbsp;</span>is how our customizations (i.e. pszIcon, pszTooltip, pszLocalizedName) get picked up by the Shell. If SHGetKnownFolderPath fails, the function UnregisterKnownFolder is invoked to undo the registration.<span style="">&nbsp;
</span></p>
<p class="MsoNormal"><span style="">&nbsp; </span>2 Print the known folder. (PrintKnownFolder)
</p>
<p class="MsoNormal"></p>
<p class="MsoNormal"></p>
<p class="MsoNormal"><span style="">&nbsp; </span>3 Remove and unregister the known folder.
<span style="">&nbsp;</span>(RemoveKnownFolder, UnregisterKnownFolder)<span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
HRESULT RemoveKnownFolder(REFKNOWNFOLDERID kfid)
{
    // Get the physical folder of the known folder.
    PWSTR pszPath = NULL;
    HRESULT hr = SHGetKnownFolderPath(kfid, 0, NULL, &pszPath);
    if (FAILED(hr))
    {
        // Failed to get the physical folder of the known folder.
        _tprintf(_T(&quot;SHGetKnownFolderPath failed w/err 0x%08lx\n&quot;), hr);
    }
    else
    {
        // Attempt to remove the physical folder of the known folder.
        SHFILEOPSTRUCT fos = {};
        fos.wFunc = FO_DELETE;
        fos.pFrom = pszPath;
        fos.fFlags = FOF_NOCONFIRMATION | FOF_NOERRORUI | FOF_SILENT;
        int err = SHFileOperation(&fos);
        if (0 != err)
        {
            // Failed to remove the physical folder
            _tprintf(_T(&quot;SHFileOperation failed w/err 0x%08lx\n&quot;), err);
            hr = E_FAIL;
        }
        else
        {
            // If the physical folder was deleted successfully, attempt to 
            // unregister the known folder.
            hr = UnregisterKnownFolder(kfid);
            if (SUCCEEDED(hr))
            {
                wprintf(L&quot;The known folder is unregistered and removed:\n%s\n&quot;, 
                    pszPath);
            }
        }


        // Must free the pszPath output of SHGetKnownFolderPath
        CoTaskMemFree(pszPath);
    }
    return hr;
}

</pre>
<pre id="codePreview" class="cplusplus">
HRESULT RemoveKnownFolder(REFKNOWNFOLDERID kfid)
{
    // Get the physical folder of the known folder.
    PWSTR pszPath = NULL;
    HRESULT hr = SHGetKnownFolderPath(kfid, 0, NULL, &pszPath);
    if (FAILED(hr))
    {
        // Failed to get the physical folder of the known folder.
        _tprintf(_T(&quot;SHGetKnownFolderPath failed w/err 0x%08lx\n&quot;), hr);
    }
    else
    {
        // Attempt to remove the physical folder of the known folder.
        SHFILEOPSTRUCT fos = {};
        fos.wFunc = FO_DELETE;
        fos.pFrom = pszPath;
        fos.fFlags = FOF_NOCONFIRMATION | FOF_NOERRORUI | FOF_SILENT;
        int err = SHFileOperation(&fos);
        if (0 != err)
        {
            // Failed to remove the physical folder
            _tprintf(_T(&quot;SHFileOperation failed w/err 0x%08lx\n&quot;), err);
            hr = E_FAIL;
        }
        else
        {
            // If the physical folder was deleted successfully, attempt to 
            // unregister the known folder.
            hr = UnregisterKnownFolder(kfid);
            if (SUCCEEDED(hr))
            {
                wprintf(L&quot;The known folder is unregistered and removed:\n%s\n&quot;, 
                    pszPath);
            }
        }


        // Must free the pszPath output of SHGetKnownFolderPath
        CoTaskMemFree(pszPath);
    }
    return hr;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">&nbsp; </span>RemoveKnownFolder is responsible for remove and unregister the
<span class="GramE">specified <span style="">&nbsp;</span>known</span> folder. It first gets the physical folder path of the known folder, and attempts to delete it. When the deletion succeeds, the function calls UnregisterKnownFolder to unregister the known
 folder from registry. <span style="">&nbsp;&nbsp;</span>UnregisterKnownFolder requires administrator privilege, so please make sure that the routine is run as administrator.
</p>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/bb776912(VS.85).aspx">MSDN: Working with Known Folders in Applications</a>
</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/dd378457(VS.85).aspx">MSDN: Default Known Folders in Windows</a>
</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/bb776910(VS.85).aspx">MSDN: Extending Known Folders with Custom Folders</a>
</p>
<p class="MsoListParagraphCxSpLast"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
