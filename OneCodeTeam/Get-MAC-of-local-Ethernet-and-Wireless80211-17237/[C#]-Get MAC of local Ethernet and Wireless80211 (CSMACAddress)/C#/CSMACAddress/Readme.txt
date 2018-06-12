================================================================================
	   Console APPLICATION: CSMACAddress Overview                        
===============================================================================

/////////////////////////////////////////////////////////////////////////////
Summary:
The sample demonstrates how to get the MAC of local Ethernet and Wireless80211 
adapters or remote host using 3 approaches.


1. Use Win32 WMI classes.
2. Use IP Helper APIs.
3. Use NDIS WMI classes.

Note: 
1. To support IPv6 and the latest NDIS, this sample uses some APIs / WMI classes 
   introduced in Windows Vista / Windows Server 2008 or later versions, so it must
   run on these OS version.

2. The result of local adapters using these approaches may vary, because WMI will 
   get the adapters, and IP Helper APIs will get the network interfaces (including 
   some software loopback interfaces), you can add filters to get the specific
   interface type.

3. Using WMI to connect remote host, you must have the permission to access it, and 
   may have to supply a valid credential.
 
4. Using IP Helper APIs to get the MAC, you don't have to supply the credential, 
   but you can only get the hosts in the same subnet.      

5. If there is any issue while using WMI, you can check following documents:
   
   WMI Troubleshooting 
   http://msdn.microsoft.com/en-us/library/aa394603(VS.85).aspx
   
   Connecting to WMI on a Remote Computer
   http://msdn.microsoft.com/en-us/library/aa389290(VS.85).aspx

   You can also download WMI Administrative Tools to check whether the WMI classes are 
   available, or the remote host could be connected.
   http://www.microsoft.com/download/en/details.aspx?id=24045


////////////////////////////////////////////////////////////////////////////////
Demo:
Step1. Build the project in Visual Studio 2010.

Step2. Run CSMACAddress.exe. This application will show following help text.

            Choose a method to get MAC Address:
            1. WMI.
            2. NetworkInformation (IPHelper API)
            3. MSNdis (WMI)
            0: Exit.

Following steps are to demo Win32 WMI. The steps pf IPHelper API and MSNdis 
are similar.

Step3. Type 1 and press Enter, you can see the WMI options.
       
            Use WMI to get MAC Address.
            1. Get all the MAC Addresses of local adapters.
            2. Get remote MAC address.
            0. Back to main options.
           

Step4. Type 1 and press Enter, you can see the MAC of all local.

Step5. Type 2 and press Enter, you can see following instruction.

            Type the remote machine and credentials (if necessary). Empty to back.
            MachineName|IP [Domain UserName Password]

       If you are in a domain and you have the permission to access the remote host,
       you can just type the machine name. Otherwise, you have to type the domain, 
       username and password, like

           testHost domainA userB user@123

       Then you can see the MAC of the remote host.


/////////////////////////////////////////////////////////////////////////////
Code Logic:

A. The IMACManager interface defines the basic methods used to get the MAC of local or 
   remote host.

         public interface IMACManager
         {
             Dictionary<string, PhysicalAddress> GetLocalAdaptersMAC();
             Dictionary<string, PhysicalAddress> GetRemoteMachineMAC(
                 string remoteHost, NetworkCredential credential);
             void Refresh();
         }

B. The WMIObjectFactory class is used to initialize a .NET type object from a WMI object.

   To use the WMI object and its properties more easily, we will design a .NET type to 
   represent a WMI class. The WMIObjectFactory class supplies a static method to convert
   a WMI object to a custom .NET type instance. The WMIClassAttribute, WMIPropertyAttribute
   and WMIPropertyType classes are used in the conversion. 

C. Use Win32 WMI classes to get MAC of the local or remote host. 

   1. Design Win32_NetworkAdapterSetting, Win32_NetworkAdapterConfiguration and 
      Win32_NetworkAdapter classes to represent the WMI classes.

   2. Use WQL to get the adapters.
   
      To get local adapters, we can pass a local scope. 
      To get remote adapters, we can pass a remote scope, which includes the credentials 
      to connect the remote host.  

        List<Win32_NetworkAdapterSetting> GetAdapters(ManagementScope scope)
        {
            var adapters = new List<Win32_NetworkAdapterSetting>();

            // Query the MSNdis_EthernetCurrentAddress objects in the specified scope.
            SelectQuery query = new SelectQuery("Win32_NetworkAdapterSetting");
            ManagementObjectSearcher searcher = null;
            ManagementObjectCollection queryCollection = null;

            try
            {
                searcher = new ManagementObjectSearcher(scope, query);
                queryCollection = searcher.Get();

                foreach (ManagementObject adapterobject in queryCollection)
                {

                    // Convert the ManagementObject to a MSNdis_EthernetCurrentAddress 
                    //instance.
                    Win32_NetworkAdapterSetting adapter = WMIObjectFactory.GetInstance(
                        adapterobject, typeof(Win32_NetworkAdapterSetting), scope)
                        as Win32_NetworkAdapterSetting;

                    if (adapter != null)
                    {
                        adapters.Add(adapter);
                    }
                }
                return adapters;
            }
            finally
            {
                if (queryCollection != null)
                {
                    queryCollection.Dispose();
                }

                if (searcher != null)
                {
                    searcher.Dispose();
                }
            }
        }
      
       public Dictionary<string, PhysicalAddress> GetRemoteMachineMAC(string remoteHost, 
            NetworkCredential credential)
        {

            // Initialize a ConnectionOptions instance, which contains the credential
            // to connect the remote host.
            ConnectionOptions option = new ConnectionOptions();

            if (credential != null)
            {
                option.Username = string.Format("{0}\\{1}", 

                    credential.Domain, credential.UserName);
                option.Password = credential.Password;
            }

            option.EnablePrivileges = true;
            option.Impersonation = ImpersonationLevel.Impersonate;
            option.Authentication = AuthenticationLevel.Default;
            option.Timeout = new TimeSpan(0, 0, 5);

            string path = string.Empty;

            IPAddress ipAddress = null;
            bool success = IPAddress.TryParse(remoteHost, out ipAddress);

            // If the remoteHost parameter is an IP Address, then add '.' to the path.
            // Like \\192.168.1.1.\root\wmi
            if (success)
            {
                path = string.Format(@"\\{0}.\root\cimv2", ipAddress);
            }
            else
            {
                path = string.Format(@"\\{0}\root\cimv2", remoteHost);
            }

            ManagementScope scope = new ManagementScope(path,option);

            // Get the adapters of the remote host.
            var adapters = GetAdapters(scope);

            var adaptersMAC = new Dictionary<string, PhysicalAddress>();

            foreach (var adapter in adapters)
            {
                if (string.IsNullOrEmpty(adapter.Setting.MACAddress))
                {
                    adaptersMAC.Add(adapter.Element.Name, PhysicalAddress.Parse(
                            adapter.Setting.MACAddress.Replace(":", string.Empty)));
                }
            }

            return adaptersMAC;         
        }

D. Use NDIS WMI classes to get MAC of the local or remote host. 
   
   1. Design MSNdis_NetworkAddress and MSNdis_EthernetCurrentAddress classes to
      represent the WMI classes.

   2. Use WQL to get the adapters. The code logic is the same as the WIN32 WMI.
   
    
E. Use IPHelper APIs to get MAC of the local or remote host. 
   
   1. To get local adapters, System.Net.NetworkInformation.NetworkInterface class
      supplies a static method GetAllNetworkInterfaces to get all local adapter. And
      it also supplies the GetPhysicalAddress method. 

   2. To get the remote MAC, we can use the GetIpNetTable2 method in Iphlpapi.dll.
      http://msdn.microsoft.com/en-us/library/aa814420(VS.85).aspx. This API supports
      both IPv4 and IPv6. The SendArp API only supports IPv4.
      
              [DllImport("iphlpapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
              internal static extern int GetIpNetTable2(
                  ushort Family,
                  [Out] out IntPtr Table);   
     
      The out parameter Table represents the pointer of a MIB_IPNET_TABLE2 struct instance,
      which contains the MIB_IPNET_ROW2 array. Then we can check whether the remote host 
      exists in the table, and get its MAC.

F. Design the Main methods of this application.
   
   As the WMINetworkManager, NetworkInformationManager and NDISNetworkManager
   classes all implements the IMACManager interface, we only have to pass an
   IMACManager instance to get the MAC of local adapters or remote host.



/////////////////////////////////////////////////////////////////////////////
References:

Exploring NDIS’s WMI classes
http://blogs.msdn.com/b/ndis/archive/2011/04/06/exploring-ndis-s-wmi-classes.aspx

PWN* your network adapter
http://blogs.msdn.com/b/ndis/archive/2010/12/16/pwn-your-network-adapter.aspx

Win32_NetworkAdapterSetting Class
http://msdn.microsoft.com/en-us/library/aa394218(VS.85).aspx

Win32_NetworkAdapter Class
http://msdn.microsoft.com/en-us/library/aa394216(VS.85).aspx

Win32_NetworkAdapterConfiguration Class
http://msdn.microsoft.com/en-us/library/aa394217(VS.85).aspx

NetworkInterface Class
http://msdn.microsoft.com/en-us/library/system.net.networkinformation.networkinterface.aspx

GetIpNetTable2 Function
http://msdn.microsoft.com/en-us/library/aa814420(VS.85).aspx

MIB_IPNET_TABLE2 Structure
http://msdn.microsoft.com/en-us/library/aa814499(VS.85).aspx

MIB_IPNET_ROW2 Structure
http://msdn.microsoft.com/en-us/library/aa814498(VS.85).aspx

/////////////////////////////////////////////////////////////////////////////
