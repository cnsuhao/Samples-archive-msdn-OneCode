# Get MAC of local Ethernet and Wireless80211 (CSMACAddress)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows SDK
* Network
## Topics
* MAC
## IsPublished
* True
## ModifiedDate
* 2012-06-11 01:11:15
## Description
================================================================================<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; Console APPLICATION: CSMACAddress Overview &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
===============================================================================<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Summary:<br>
The sample demonstrates how to get the MAC of local Ethernet and Wireless80211 <br>
adapters or remote host using 3 approaches.<br>
<br>
<br>
1. Use Win32 WMI classes.<br>
2. Use IP Helper APIs.<br>
3. Use NDIS WMI classes.<br>
<br>
Note: <br>
1. To support IPv6 and the latest NDIS, this sample uses some APIs / WMI classes <br>
&nbsp; introduced in Windows Vista / Windows Server 2008 or later versions, so it must<br>
&nbsp; run on these OS version.<br>
<br>
2. The result of local adapters using these approaches may vary, because WMI will
<br>
&nbsp; get the adapters, and IP Helper APIs will get the network interfaces (including
<br>
&nbsp; some software loopback interfaces), you can add filters to get the specific<br>
&nbsp; interface type.<br>
<br>
3. Using WMI to connect remote host, you must have the permission to access it, and
<br>
&nbsp; may have to supply a valid credential.<br>
<br>
4. Using IP Helper APIs to get the MAC, you don't have to supply the credential, <br>
&nbsp; but you can only get the hosts in the same subnet. &nbsp; &nbsp; &nbsp;<br>
<br>
5. If there is any issue while using WMI, you can check following documents:<br>
&nbsp; <br>
&nbsp; WMI Troubleshooting <br>
&nbsp; http://msdn.microsoft.com/en-us/library/aa394603(VS.85).aspx<br>
&nbsp; <br>
&nbsp; Connecting to WMI on a Remote Computer<br>
&nbsp; http://msdn.microsoft.com/en-us/library/aa389290(VS.85).aspx<br>
<br>
&nbsp; You can also download WMI Administrative Tools to check whether the WMI classes are
<br>
&nbsp; available, or the remote host could be connected.<br>
&nbsp; http://www.microsoft.com/download/en/details.aspx?id=24045<br>
<br>
<br>
////////////////////////////////////////////////////////////////////////////////<br>
Demo:<br>
Step1. Build the project in Visual Studio 2010.<br>
<br>
Step2. Run CSMACAddress.exe. This application will show following help text.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Choose a method to get MAC Address:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;1. WMI.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;2. NetworkInformation (IPHelper API)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;3. MSNdis (WMI)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;0: Exit.<br>
<br>
Following steps are to demo Win32 WMI. The steps pf IPHelper API and MSNdis <br>
are similar.<br>
<br>
Step3. Type 1 and press Enter, you can see the WMI options.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Use WMI to get MAC Address.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;1. Get all the MAC Addresses of local adapters.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;2. Get remote MAC address.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;0. Back to main options.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
<br>
Step4. Type 1 and press Enter, you can see the MAC of all local.<br>
<br>
Step5. Type 2 and press Enter, you can see following instruction.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Type the remote machine and credentials (if necessary). Empty to back.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MachineName|IP [Domain UserName Password]<br>
<br>
&nbsp; &nbsp; &nbsp; If you are in a domain and you have the permission to access the remote host,<br>
&nbsp; &nbsp; &nbsp; you can just type the machine name. Otherwise, you have to type the domain,
<br>
&nbsp; &nbsp; &nbsp; username and password, like<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; testHost domainA userB user@123<br>
<br>
&nbsp; &nbsp; &nbsp; Then you can see the MAC of the remote host.<br>
<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Code Logic:<br>
<br>
A. The IMACManager interface defines the basic methods used to get the MAC of local or
<br>
&nbsp; remote host.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; public interface IMACManager<br>
&nbsp; &nbsp; &nbsp; &nbsp; {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Dictionary&lt;string, PhysicalAddress&gt; GetLocalAdaptersMAC();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Dictionary&lt;string, PhysicalAddress&gt; GetRemoteMachineMAC(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; string remoteHost, NetworkCredential credential);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; void Refresh();<br>
&nbsp; &nbsp; &nbsp; &nbsp; }<br>
<br>
B. The WMIObjectFactory class is used to initialize a .NET type object from a WMI object.<br>
<br>
&nbsp; To use the WMI object and its properties more easily, we will design a .NET type to
<br>
&nbsp; represent a WMI class. The WMIObjectFactory class supplies a static method to convert<br>
&nbsp; a WMI object to a custom .NET type instance. The WMIClassAttribute, WMIPropertyAttribute<br>
&nbsp; and WMIPropertyType classes are used in the conversion. <br>
<br>
C. Use Win32 WMI classes to get MAC of the local or remote host. <br>
<br>
&nbsp; 1. Design Win32_NetworkAdapterSetting, Win32_NetworkAdapterConfiguration and
<br>
&nbsp; &nbsp; &nbsp;Win32_NetworkAdapter classes to represent the WMI classes.<br>
<br>
&nbsp; 2. Use WQL to get the adapters.<br>
&nbsp; <br>
&nbsp; &nbsp; &nbsp;To get local adapters, we can pass a local scope. <br>
&nbsp; &nbsp; &nbsp;To get remote adapters, we can pass a remote scope, which includes the credentials
<br>
&nbsp; &nbsp; &nbsp;to connect the remote host. &nbsp;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;List&lt;Win32_NetworkAdapterSetting&gt; GetAdapters(ManagementScope scope)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var adapters = new List&lt;Win32_NetworkAdapterSetting&gt;();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Query the MSNdis_EthernetCurrentAddress objects in the specified scope.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SelectQuery query = new SelectQuery(&quot;Win32_NetworkAdapterSetting&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ManagementObjectSearcher searcher = null;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ManagementObjectCollection queryCollection = null;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;searcher = new ManagementObjectSearcher(scope, query);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;queryCollection = searcher.Get();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;foreach (ManagementObject adapterobject in queryCollection)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Convert the ManagementObject to a MSNdis_EthernetCurrentAddress
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;//instance.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Win32_NetworkAdapterSetting adapter = WMIObjectFactory.GetInstance(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;adapterobject, typeof(Win32_NetworkAdapterSetting), scope)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;as Win32_NetworkAdapterSetting;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (adapter != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;adapters.Add(adapter);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return adapters;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;finally<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (queryCollection != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;queryCollection.Dispose();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (searcher != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;searcher.Dispose();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; public Dictionary&lt;string, PhysicalAddress&gt; GetRemoteMachineMAC(string remoteHost,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;NetworkCredential credential)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Initialize a ConnectionOptions instance, which contains the credential<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// to connect the remote host.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ConnectionOptions option = new ConnectionOptions();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (credential != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;option.Username = string.Format(&quot;{0}\\{1}&quot;,
<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;credential.Domain, credential.UserName);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;option.Password = credential.Password;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;option.EnablePrivileges = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;option.Impersonation = ImpersonationLevel.Impersonate;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;option.Authentication = AuthenticationLevel.Default;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;option.Timeout = new TimeSpan(0, 0, 5);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string path = string.Empty;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;IPAddress ipAddress = null;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;bool success = IPAddress.TryParse(remoteHost, out ipAddress);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// If the remoteHost parameter is an IP Address, then add '.' to the path.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Like \\192.168.1.1.\root\wmi<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (success)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;path = string.Format(@&quot;\\{0}.\root\cimv2&quot;, ipAddress);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;path = string.Format(@&quot;\\{0}\root\cimv2&quot;, remoteHost);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ManagementScope scope = new ManagementScope(path,option);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Get the adapters of the remote host.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var adapters = GetAdapters(scope);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var adaptersMAC = new Dictionary&lt;string, PhysicalAddress&gt;();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;foreach (var adapter in adapters)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (string.IsNullOrEmpty(adapter.Setting.MACAddress))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;adaptersMAC.Add(adapter.Element.Name, PhysicalAddress.Parse(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;adapter.Setting.MACAddress.Replace(&quot;:&quot;, string.Empty)));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return adaptersMAC; &nbsp; &nbsp; &nbsp; &nbsp;
<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
D. Use NDIS WMI classes to get MAC of the local or remote host. <br>
&nbsp; <br>
&nbsp; 1. Design MSNdis_NetworkAddress and MSNdis_EthernetCurrentAddress classes to<br>
&nbsp; &nbsp; &nbsp;represent the WMI classes.<br>
<br>
&nbsp; 2. Use WQL to get the adapters. The code logic is the same as the WIN32 WMI.<br>
&nbsp; <br>
&nbsp; &nbsp;<br>
E. Use IPHelper APIs to get MAC of the local or remote host. <br>
&nbsp; <br>
&nbsp; 1. To get local adapters, System.Net.NetworkInformation.NetworkInterface class<br>
&nbsp; &nbsp; &nbsp;supplies a static method GetAllNetworkInterfaces to get all local adapter. And<br>
&nbsp; &nbsp; &nbsp;it also supplies the GetPhysicalAddress method. <br>
<br>
&nbsp; 2. To get the remote MAC, we can use the GetIpNetTable2 method in Iphlpapi.dll.<br>
&nbsp; &nbsp; &nbsp;http://msdn.microsoft.com/en-us/library/aa814420(VS.85).aspx. This API supports<br>
&nbsp; &nbsp; &nbsp;both IPv4 and IPv6. The SendArp API only supports IPv4.<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;[DllImport(&quot;iphlpapi.dll&quot;, SetLastError = true, CharSet = CharSet.Auto)]<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;internal static extern int GetIpNetTable2(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ushort Family,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;[Out] out IntPtr Table); &nbsp;
<br>
&nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp;The out parameter Table represents the pointer of a MIB_IPNET_TABLE2 struct instance,<br>
&nbsp; &nbsp; &nbsp;which contains the MIB_IPNET_ROW2 array. Then we can check whether the remote host
<br>
&nbsp; &nbsp; &nbsp;exists in the table, and get its MAC.<br>
<br>
F. Design the Main methods of this application.<br>
&nbsp; <br>
&nbsp; As the WMINetworkManager, NetworkInformationManager and NDISNetworkManager<br>
&nbsp; classes all implements the IMACManager interface, we only have to pass an<br>
&nbsp; IMACManager instance to get the MAC of local adapters or remote host.<br>
<br>
<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
References:<br>
<br>
Exploring NDIS’s WMI classes<br>
http://blogs.msdn.com/b/ndis/archive/2011/04/06/exploring-ndis-s-wmi-classes.aspx<br>
<br>
PWN* your network adapter<br>
http://blogs.msdn.com/b/ndis/archive/2010/12/16/pwn-your-network-adapter.aspx<br>
<br>
Win32_NetworkAdapterSetting Class<br>
http://msdn.microsoft.com/en-us/library/aa394218(VS.85).aspx<br>
<br>
Win32_NetworkAdapter Class<br>
http://msdn.microsoft.com/en-us/library/aa394216(VS.85).aspx<br>
<br>
Win32_NetworkAdapterConfiguration Class<br>
http://msdn.microsoft.com/en-us/library/aa394217(VS.85).aspx<br>
<br>
NetworkInterface Class<br>
http://msdn.microsoft.com/en-us/library/system.net.networkinformation.networkinterface.aspx<br>
<br>
GetIpNetTable2 Function<br>
http://msdn.microsoft.com/en-us/library/aa814420(VS.85).aspx<br>
<br>
MIB_IPNET_TABLE2 Structure<br>
http://msdn.microsoft.com/en-us/library/aa814499(VS.85).aspx<br>
<br>
MIB_IPNET_ROW2 Structure<br>
http://msdn.microsoft.com/en-us/library/aa814498(VS.85).aspx<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
