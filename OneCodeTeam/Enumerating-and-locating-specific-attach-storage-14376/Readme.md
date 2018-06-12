# Enumerating and locating specific attach storage devices. (CppStorageEnum)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* WDK
* Windows Driver
## Topics
* Storage
* DeviceIoControl
* SetupDiGetClassDevs
## IsPublished
* True
## ModifiedDate
* 2012-09-03 08:20:36
## Description

<h1>Enumerating and locating specific attach storage devices. (<span class="SpellE">CppStorageEnum</span>)</h1>
<h2>Introduction</h2>
<p>The code sample demonstrates the use of DeviceIoControl and SetupDiGetClassDevs in the everyday operations of enumerating and locating specific attach storage devices.</p>
<h2>Prerequisite</h2>
<p>To run this sample, you need to install the <a href="http://www.microsoft.com/download/en/details.aspx?id=11800">
Windows Driver Kit (WDK)</a>.</p>
<h2>Building the Sample</h2>
<p>Before building this sample, you should configure your Visual Studio environment. Go to project &quot;CppStorageEnumDll&quot; property pages, add WinDDk Include/Library paths like below:</p>
<p><img src="/site/view/file/47064/1/image001.png" alt="" width="600" height="155"></p>
<p>Please NOTE:</p>
<ul>
<li>Make sure the WinDDK include paths are behind the $(VCInstallDir)include. Otherwise, you may encounter some errors while compiling the sample.
</li><li>If you want to build this sample targets to platform x64, please set the 64bit WDK library path. Such as: D:\WinDDK\7600.16385.1\lib\win7\amd64
</li><li>Choose the right WinDDK library based on your system. </li></ul>
<h2>Running the Sample</h2>
<p>After building the sample successfully, just press Ctrl &#43; F5 to run it. Then you may see something like this:</p>
<p><img src="/site/view/file/47066/1/image002.png" alt="" width="564" height="308"></p>
<p>Please note that, for non-SCSI devices, the GetStorageDeviceIdDescriptor function failed to get the device ID. Since this code sample fetches the device ID for disks using mode page 83h, it&rsquo;s meant for SCSI devices.</p>
<h2>Using the Code</h2>
<p>The main usage of the demo is through the client application (CppStorageEnum).&nbsp; As you can see, this module is only about 64 lines total, mainly using the APIs:</p>
<p>&nbsp;&nbsp;&nbsp; FindFirstStorageDevice and FindNextStorageDevice</p>
<p>The type of storage located is defined in the header: CppStorageEnumDll.h, the following code snippet shows how it works:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">BOOL WINAPI FindFirstStorageDevice(
        HANDLE *hIntDevInfo,
        LPGUID DeviceClassGuid,
        LPTSTR lpszDeviceName, 
        DWORD cchNameBufferLength, 
        LPTSTR lpszSerialNumber, 
        DWORD cchSerialNumberBufferLength
    )
{
    BOOL status = TRUE;
    HANDLE lhIntDevInfo = NULL;
 
    if (NULL == hIntDevInfo &amp;&amp; NULL == *hIntDevInfo) 
    {
        SetLastError(ERROR_INVALID_PARAMETER);
        return FALSE;
    }
 
    if (NULL == lpszDeviceName || NULL == lpszSerialNumber) 
    {
        SetLastError(ERROR_INVALID_PARAMETER);
        return FALSE;
    }
 
    if (0 == cchNameBufferLength || 0 == cchSerialNumberBufferLength) 
    {
        SetLastError(ERROR_INVALID_PARAMETER);
        return FALSE;
    }
 
    lhIntDevInfo = SetupDiGetClassDevs (
                 (LPGUID)DeviceClassGuid,
                 NULL,                                   // Enumerator
                 NULL,                                   // Parent Window
                 (DIGCF_PRESENT | DIGCF_INTERFACEDEVICE  // Only Devices present &amp; Interface class
                 ));
 
    if( lhIntDevInfo == INVALID_HANDLE_VALUE )
    {
        // ERROR_INVALID_HANDLE
        return FALSE;
    }
 
    index = 0;
    status = GetDeviceProperty(lhIntDevInfo, DeviceClassGuid, index, lpszDeviceName, cchNameBufferLength, lpszSerialNumber, cchSerialNumberBufferLength);
    if (status == FALSE) 
    {
        // ERROR_NO_MORE_ITEMS
        SetupDiDestroyDeviceInfoList(lhIntDevInfo);
    }
 
    *hIntDevInfo = lhIntDevInfo;
 
    return status;
}</pre>
<div class="preview">
<pre class="cplusplus"><span class="cpp__datatype">BOOL</span>&nbsp;WINAPI&nbsp;FindFirstStorageDevice(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HANDLE</span>&nbsp;*hIntDevInfo,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LPGUID&nbsp;DeviceClassGuid,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">LPTSTR</span>&nbsp;lpszDeviceName,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">DWORD</span>&nbsp;cchNameBufferLength,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">LPTSTR</span>&nbsp;lpszSerialNumber,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">DWORD</span>&nbsp;cchSerialNumberBufferLength&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BOOL</span>&nbsp;status&nbsp;=&nbsp;TRUE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HANDLE</span>&nbsp;lhIntDevInfo&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(NULL&nbsp;==&nbsp;hIntDevInfo&nbsp;&amp;&amp;&nbsp;NULL&nbsp;==&nbsp;*hIntDevInfo)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetLastError(ERROR_INVALID_PARAMETER);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(NULL&nbsp;==&nbsp;lpszDeviceName&nbsp;||&nbsp;NULL&nbsp;==&nbsp;lpszSerialNumber)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetLastError(ERROR_INVALID_PARAMETER);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(<span class="cpp__number">0</span>&nbsp;==&nbsp;cchNameBufferLength&nbsp;||&nbsp;<span class="cpp__number">0</span>&nbsp;==&nbsp;cchSerialNumberBufferLength)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetLastError(ERROR_INVALID_PARAMETER);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;lhIntDevInfo&nbsp;=&nbsp;SetupDiGetClassDevs&nbsp;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(LPGUID)DeviceClassGuid,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NULL,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Enumerator</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NULL,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Parent&nbsp;Window</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(DIGCF_PRESENT&nbsp;|&nbsp;DIGCF_INTERFACEDEVICE&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Only&nbsp;Devices&nbsp;present&nbsp;&amp;&nbsp;Interface&nbsp;class</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;));&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(&nbsp;lhIntDevInfo&nbsp;==&nbsp;INVALID_HANDLE_VALUE&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;ERROR_INVALID_HANDLE</span><span class="cpp__keyword">return</span>&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;index&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;status&nbsp;=&nbsp;GetDeviceProperty(lhIntDevInfo,&nbsp;DeviceClassGuid,&nbsp;index,&nbsp;lpszDeviceName,&nbsp;cchNameBufferLength,&nbsp;lpszSerialNumber,&nbsp;cchSerialNumberBufferLength);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(status&nbsp;==&nbsp;FALSE)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;ERROR_NO_MORE_ITEMS</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetupDiDestroyDeviceInfoList(lhIntDevInfo);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;*hIntDevInfo&nbsp;=&nbsp;lhIntDevInfo;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;status;&nbsp;
}</pre>
</div>
</div>
</div>
<p>Basically, FindFirstStorageDevice calls SetupDiGetClassDevs to get a handle to the interface class and attempts to locate the first instance of the class using SetupDiEnumDeviceInterfaces and SetupDiGetDeviceInterfaceDetail.&nbsp; Once the first device has
 been identified, which is controlled by the ordinal (Index - a global variable that is maintained across DLL/API invocations), calls to DeviceIoControl are made to gather detail information about the device.&nbsp; Currently, the IOCTLs implemented are IOCTL_STORAGE_QUERY_PROPERTY
 and IOCTL_STORAGE_GET_DEVICE_NUMBER.</p>
<p>Once the interface has been obtained and properties for the interface are complete, string is compiled to create a NT-like namespace of the device.&nbsp; Currently, only DISK devices and TAPE devices are supported, but again this is left to the user to extend
 to any device desired.</p>
<p>Note this API requires a pointer to a handle to be used by subsequent calls FindNextStorageDevice. The next argument is the GUID, which specifies the type of device to be enumerated.&nbsp; These GUIDS can be found in devguid.h, and are also defined at:</p>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/hardware/ff545824(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/hardware/ff545824(v=vs.85).aspx</a></p>
<p>The remaining arguments are buffers and lengths to be allocated and managed by the client application, not the DLL. It is an error to provide NULL or zero for these arguments respectively.</p>
<p>Once FindFirstStorageDevice has been called, and returned TRUE, the hIntDevInfo, can then be used to call FindNextStorageDevice repetitively, until FALSE is returned.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">BOOL WINAPI FindNextStorageDevice(
        HANDLE hIntDevInfo,
        LPGUID DeviceClassGuid,
        LPTSTR lpszDeviceName, 
        DWORD cchNameBufferLength, 
        LPTSTR lpszSerialNumber, 
        DWORD cchSerialNumberBufferLength
    )
{
    BOOL bRes;
 
    index&#43;&#43;;
    bRes = GetDeviceProperty(hIntDevInfo, DeviceClassGuid, index, lpszDeviceName, cchNameBufferLength, lpszSerialNumber, cchSerialNumberBufferLength);
    if (bRes == FALSE) 
    {
        // ERROR_NO_MORE_ITEMS
        SetupDiDestroyDeviceInfoList(hIntDevInfo);
    }
 
    return bRes;
}</pre>
<div class="preview">
<pre class="cplusplus"><span class="cpp__datatype">BOOL</span>&nbsp;WINAPI&nbsp;FindNextStorageDevice(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HANDLE</span>&nbsp;hIntDevInfo,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LPGUID&nbsp;DeviceClassGuid,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">LPTSTR</span>&nbsp;lpszDeviceName,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">DWORD</span>&nbsp;cchNameBufferLength,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">LPTSTR</span>&nbsp;lpszSerialNumber,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">DWORD</span>&nbsp;cchSerialNumberBufferLength&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BOOL</span>&nbsp;bRes;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;index&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bRes&nbsp;=&nbsp;GetDeviceProperty(hIntDevInfo,&nbsp;DeviceClassGuid,&nbsp;index,&nbsp;lpszDeviceName,&nbsp;cchNameBufferLength,&nbsp;lpszSerialNumber,&nbsp;cchSerialNumberBufferLength);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(bRes&nbsp;==&nbsp;FALSE)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;ERROR_NO_MORE_ITEMS</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetupDiDestroyDeviceInfoList(hIntDevInfo);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;bRes;&nbsp;
}</pre>
</div>
</div>
</div>
<h2 class="endscriptcode">More Information</h2>
<p>The location for information SetupAPI is:<br>
<a href="http://msdn.microsoft.com/en-us/library/windows/hardware/ff551015(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/hardware/ff551015(v=vs.85).aspx</a></p>
<p>Information on device specific GUIDS can be found at:<br>
<a href="http://msdn.microsoft.com/en-us/library/windows/hardware/ff545824(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/hardware/ff545824(v=vs.85).aspx</a></p>
<div class="WordSection1">
<p>&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
</div>
