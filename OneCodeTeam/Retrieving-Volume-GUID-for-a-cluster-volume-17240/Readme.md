# Retrieving Volume GUID for a cluster volume (CppClusterDiskDetails)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows SDK
## Topics
* Cluster API
## IsPublished
* True
## ModifiedDate
* 2012-06-11 02:19:53
## Description

<h1><span>R</span>etrieve the Volume GUID of the Cluster Disks (<span class="SpellE">CppClusterDiskDetails</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to retrieve the Volume GUID of the Cluster Disks.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">To test the sample, compile the program using Visual Studio 2010 and run on any of Windows 2008/Windows2008 R2 cluster nodes with/without cluster name as a command line parameter. It will then output all the cluster disks along with their
 Volume GUID.</p>
<h2>Using the Code</h2>
<p class="MsoNormal">You can use this project to programmatically retrieve the Volume GUID for the cluster disks, which can then be used with storage applications that requires Volume GUID as input for its operation.</p>
<p class="MsoNormal">The following code snippet is the key point of this sample. It checks if the resource is a valid cluster disk resource and returns its GUID and Path via out parameters.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">/// &lt;summary&gt;
/// Checks if the resource is a valid cluster disk resource and returns its GUID and Path via out parameters. 
/// &lt;/summary&gt;
/// &lt;param name=&quot;hResource&quot;&gt;Handle for a cluster resource&lt;/param&gt;
/// &lt;returns&gt;TRUE if the GUID and Path is retrieved successfully else returns FALSE&lt;/returns&gt;
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
                                            &amp;dwBytes 
                                            );


        if( ERROR_MORE_DATA == dwRetVal || ERROR_SUCCESS == dwRetVal )
        {
            if(lpbBuffer)
            delete [] lpbBuffer;


            lpbBuffer = new BYTE[dwBytes];


            if( NULL == lpbBuffer )
            {
                wprintf( L&quot;Error: could not allocate memory.\n&quot; );
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
                                                &amp;dwBytes 
                                                );


            if( ERROR_SUCCESS != dwRetVal &amp;&amp; ERROR_INVALID_FUNCTION != dwRetVal )
            {
                if( ERROR_MORE_DATA == dwRetVal )
                {
                wprintf( L&quot;Error: more data needed.\n&quot; );
                }
                else
                {
                wprintf( L&quot;ClusterResourceControl failed: %d\n&quot;, dwRetVal );
                }
            }
            else
            {
                cv = (CLUSPROP_VALUE *)lpbBuffer;


                while( (NULL != cv) &amp;&amp; (CLUSPROP_TYPE_PARTITION_INFO_EX != cv-&gt;Syntax.wType) )
                {
                    cv = (CLUSPROP_VALUE *) (((BYTE*)&amp;(cv-&gt;cbLength)) &#43; cv-&gt;cbLength 
                    &#43; sizeof(DWORD));


                    if(cv &gt;= (CLUSPROP_VALUE *) &amp;lpbBuffer[dwBytes])
                    {
                    cv = NULL;
                    }
                }


                if( NULL != cv )
                {
                    bIsDisk = TRUE; 
                    GUID guid = ((CLUSPROP_PARTITION_INFO_EX*)cv)-&gt;VolumeGuid;
                    ::StringFromGUID2( guid,szGUID,MAX_PATH);
                    wsprintf(szGUID,L&quot;%s&quot;,szGUID);
                    wsprintf(szPath,L&quot;%s&quot;,((CLUSPROP_PARTITION_INFO_EX*)cv)-&gt;szDeviceName);
                }
            } // else error_success


            delete [] lpbBuffer;
        }
        else if( ERROR_SUCCESS != dwRetVal &amp;&amp; ERROR_INVALID_FUNCTION != dwRetVal )
        {
            wprintf( L&quot;ClusterResourceControl failed: %d\n&quot;, dwRetVal );
        }


        return bIsDisk;
}

</pre>
<pre id="codePreview" class="cplusplus">/// &lt;summary&gt;
/// Checks if the resource is a valid cluster disk resource and returns its GUID and Path via out parameters. 
/// &lt;/summary&gt;
/// &lt;param name=&quot;hResource&quot;&gt;Handle for a cluster resource&lt;/param&gt;
/// &lt;returns&gt;TRUE if the GUID and Path is retrieved successfully else returns FALSE&lt;/returns&gt;
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
                                            &amp;dwBytes 
                                            );


        if( ERROR_MORE_DATA == dwRetVal || ERROR_SUCCESS == dwRetVal )
        {
            if(lpbBuffer)
            delete [] lpbBuffer;


            lpbBuffer = new BYTE[dwBytes];


            if( NULL == lpbBuffer )
            {
                wprintf( L&quot;Error: could not allocate memory.\n&quot; );
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
                                                &amp;dwBytes 
                                                );


            if( ERROR_SUCCESS != dwRetVal &amp;&amp; ERROR_INVALID_FUNCTION != dwRetVal )
            {
                if( ERROR_MORE_DATA == dwRetVal )
                {
                wprintf( L&quot;Error: more data needed.\n&quot; );
                }
                else
                {
                wprintf( L&quot;ClusterResourceControl failed: %d\n&quot;, dwRetVal );
                }
            }
            else
            {
                cv = (CLUSPROP_VALUE *)lpbBuffer;


                while( (NULL != cv) &amp;&amp; (CLUSPROP_TYPE_PARTITION_INFO_EX != cv-&gt;Syntax.wType) )
                {
                    cv = (CLUSPROP_VALUE *) (((BYTE*)&amp;(cv-&gt;cbLength)) &#43; cv-&gt;cbLength 
                    &#43; sizeof(DWORD));


                    if(cv &gt;= (CLUSPROP_VALUE *) &amp;lpbBuffer[dwBytes])
                    {
                    cv = NULL;
                    }
                }


                if( NULL != cv )
                {
                    bIsDisk = TRUE; 
                    GUID guid = ((CLUSPROP_PARTITION_INFO_EX*)cv)-&gt;VolumeGuid;
                    ::StringFromGUID2( guid,szGUID,MAX_PATH);
                    wsprintf(szGUID,L&quot;%s&quot;,szGUID);
                    wsprintf(szPath,L&quot;%s&quot;,((CLUSPROP_PARTITION_INFO_EX*)cv)-&gt;szDeviceName);
                }
            } // else error_success


            delete [] lpbBuffer;
        }
        else if( ERROR_SUCCESS != dwRetVal &amp;&amp; ERROR_INVALID_FUNCTION != dwRetVal )
        {
            wprintf( L&quot;ClusterResourceControl failed: %d\n&quot;, dwRetVal );
        }


        return bIsDisk;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<h2>More Information</h2>
<p class="MsoNormal"><span>For more information on the control code CLUSCTL_RESOURCE_STORAGE_GET_DISK_INFO_EX click<br>
</span><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/bb309097.aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/bb309097.aspx</a><span>
</span></p>
<p class="MsoNormal"><span>MSDN: <span class="SpellE">ClusterResourceControl</span> function<br>
</span><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa369016.aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/aa369016.aspx</a><span>
</span></p>
<p class="MsoNormal"><span>MSDN: Resource Control Codes<br>
</span><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa372232.aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/aa372232.aspx</a><span>
</span></p>
<p class="MsoNormal"><span>MSDN: CLUSPROP_VALUE structure<br>
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa368393.aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/aa368393.aspx</a>
</span></p>
<p class="MsoNormal"><span>MSDN: CLUSPROP_PARTITION_INFO_EX<br>
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/bb309113.aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/bb309113.aspx</a>
</span></p>
<p class="MsoNormal"><span>&nbsp;</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
