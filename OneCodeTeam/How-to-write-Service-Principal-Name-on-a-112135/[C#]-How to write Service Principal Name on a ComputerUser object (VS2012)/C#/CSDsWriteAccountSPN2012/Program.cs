using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices; 

namespace CSDsWriteAccountSPN2012
{
    //****************************** Module Header ******************************\
    //Module Name:    TextInputToVisibilityConverter.cs
    //Project:        CSAddHintText2Textbox
    //Copyright (c) Microsoft Corporation

    // The project illustrates how to check whether a file is in use or not.

    //This source is subject to the Microsoft Public License.
    //See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
    //All other rights reserved.

    //*****************************************************************************/

    class Program
    {
        const Int32 ERROR_BUFFER_OVERFLOW = 111;
        const Int32 NO_ERROR = 0; 

        #region Native functions
        /// <summary> 
        /// Signature for DsGetSPN, which constructs an array of one or more SPNs.  
        /// </summary> 
        /// <param name="ServiceType"></param> 
        /// <param name="serviceClass"></param> 
        /// <param name="serviceName"></param> 
        /// <param name="InstancePort"></param> 
        /// <param name="cInstanceNames"></param> 
        /// <param name="pInstanceNames"></param> 
        /// <param name="pInstancePorts"></param> 
        /// <param name="SpnCount"></param> 
        /// <param name="SpnArrayPointer"></param> 
        /// <returns></returns> 
        [DllImport("ntdsapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern UInt32 DsGetSpn
        (
            DS_SPN_NAME_TYPE ServiceType,
            string serviceClass,
            string serviceName,
            ushort InstancePort,
            ushort cInstanceNames,
            string[] pInstanceNames,
            ushort[] pInstancePorts,
            ref Int32 SpnCount,
            ref System.IntPtr SpnArrayPointer
        );

        /// <summary> 
        /// ENUM for spn Type 
        /// </summary> 
        public enum DS_SPN_NAME_TYPE
        {
            DS_SPN_DNS_HOST = 0,
            DS_SPN_DN_HOST = 1,
            DS_SPN_NB_HOST = 2,
            DS_SPN_DOMAIN = 3,
            DS_SPN_NB_DOMAIN = 4,
            DS_SPN_SERVICE = 5
        }

        /// <summary> 
        /// DsCrackSpn parses a spn into its component strings 
        /// </summary> 
        /// <param name="pszSPN"></param> 
        /// <param name="pcServiceClass"></param> 
        /// <param name="serviceClass"></param> 
        /// <param name="pcServicename"></param> 
        /// <param name="serviceName"></param> 
        /// <param name="pcInstanceName"></param> 
        /// <param name="instanceName"></param> 
        /// <param name="pinstancePort"></param> 
        /// <returns></returns> 
        [DllImport("Ntdsapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern UInt32 DsCrackSpn
        (
            string pszSPN,
            ref Int32 pcServiceClass,
            StringBuilder serviceClass,
            ref Int32 pcServicename,
            StringBuilder serviceName,
            ref Int32 pcInstanceName,
            StringBuilder instanceName,
            out ushort pinstancePort
        );

        /// <summary> 
        /// DsWriteAccountSpn writes an array of SPNs to the servicePrincipalName attribute of a 
        /// specified user or computer object in AD. 
        /// </summary> 
        /// <param name="hDS"></param> 
        /// <param name="Operation"></param> 
        /// <param name="pszAccount"></param> 
        /// <param name="cSpn"></param> 
        /// <param name="SPNArray"></param> 
        /// <returns></returns> 
        [DllImport("ntdsapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern uint DsWriteAccountSpn
        (
           System.IntPtr hDS,
           DS_SPN_WRITE_OP Operation,
           string pszAccount,
           Int32 cSpn,
           System.IntPtr SPNArray
         );

        /// <summary> 
        /// DSBind binds to a domain controller/Domain 
        /// </summary> 
        /// <param name="DomainControllerName"></param> 
        /// <param name="DnsDomainName"></param> 
        /// <param name="phDS"></param> 
        /// <returns></returns> 
        [DllImport("ntdsapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern uint DsBind
        (
           string DomainControllerName,
           string DnsDomainName,
           out System.IntPtr phDS
        );

        /// <summary> 
        /// Enum for spn Writing operation 
        /// </summary> 
        public enum DS_SPN_WRITE_OP
        {
            DS_SPN_ADD_SPN_OP = 0,
            DS_SPN_REPLACE_SPN_OP = 1,
            DS_SPN_DELETE_SPN_OP = 2
        }
        #endregion  

        static void Main(string[] args)
        {
            // Input Variable values 
            string spn = @"Machine/NewSPN";                        // spn name 
            string servicePrincipalName = "CN=ACTUser,CN=Users,DC=SHAOLINT,DC=COM"; // DistinguishedName of the user/Computer 
            string domainControllerName = "SHALOINT";                               // Domain controller name 
            string dnsDomainName = "SHAOLINT.COM";                           // DNS domain name 

            int serviceClassSize = 1;
            int serviceNameSize = 1;
            int instanceNameSize = 1;
            ushort port;

            StringBuilder sTemp = new StringBuilder(1);

            // Initial call to DsCrackSpn should result in BUFFER_OVERFLOW... 
            uint crackSpnResult = DsCrackSpn(spn, ref serviceClassSize, sTemp, ref serviceNameSize,
                sTemp, ref instanceNameSize, sTemp, out port);

            // Check for buffer overflow 
            if (crackSpnResult == ERROR_BUFFER_OVERFLOW)
            {
                // Resize our SB's 
                StringBuilder serviceClass = new StringBuilder(serviceClassSize);
                StringBuilder serviceName = new StringBuilder(serviceNameSize);
                StringBuilder instanceName = new StringBuilder(instanceNameSize);

                // Crack this spn using DsCrackSpn 
                crackSpnResult = DsCrackSpn(spn, ref serviceClassSize, serviceClass, ref serviceNameSize,
                    serviceName, ref instanceNameSize, instanceName, out port);

                // If Success 
                if (crackSpnResult == NO_ERROR)
                {
                    string[] hostArray = { serviceName.ToString() };
                    ushort[] portArray = { port };
                    ushort spnCount = 1;
                    IntPtr spnArrayPointer = new IntPtr();
                    Int32 spnArrayCount = 0;

                    // Call to DsBind to get handle for Directory 
                    System.IntPtr hDS;
                    uint result = DsBind(domainControllerName, dnsDomainName, out hDS);

                    if (result != NO_ERROR)
                    {
                        Console.WriteLine("DSBind Failed.");
                        return;
                    }

                    // Call to DsgetSpn to construct an spn 
                    uint getSPNResult = DsGetSpn(DS_SPN_NAME_TYPE.DS_SPN_DNS_HOST, serviceClass.ToString(),
                        null, port, spnCount, hostArray, portArray, ref spnArrayCount, ref spnArrayPointer);

                    if (getSPNResult == NO_ERROR)
                    {
                        // Call the CSDsWriteAccountSPN for writing this spn to the object 
                        uint dsWriteSpnResult = DsWriteAccountSpn(hDS, DS_SPN_WRITE_OP.DS_SPN_ADD_SPN_OP,
                            servicePrincipalName, spnArrayCount, spnArrayPointer);

                        if (dsWriteSpnResult == NO_ERROR)
                        {
                            Console.WriteLine("DsWriteAccountSpn Succeed. Please check the user/Computer object for ServicePrincipalName.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("DsWriteAccountSpn Failed.");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("DsGetSPN Failed.");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("DsCrackSpn Failed.");
                    return;
                }
            }
        }
    }
}
