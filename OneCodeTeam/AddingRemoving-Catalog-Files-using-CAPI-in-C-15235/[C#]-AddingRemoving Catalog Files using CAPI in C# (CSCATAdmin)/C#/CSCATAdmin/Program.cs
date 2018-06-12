/****************************** Module Header ******************************\
* Module Name:  Program.cs
* Project:      CSCATAdmin
* Copyright (c) Microsoft Corporation.
* 
* This sample demonstrates CAPI/Wintrust native functions that allow the user 
* to add/remove third party authenticode signed catalog files to the system. 
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/


using System;
using System.IO;                    // File operations
using System.Security.Principal;    // For admin user checking
using System.Runtime.InteropServices;

/* definitions of CAPI functions used in this sample:
 * CryptCATAdminAcquireContext
 * CryptCATAdminReleaseContext
 * CryptCATAdminReleastCatalogContext
 * CryptCATAdminAddCatalog
 * CryptCATAdminRemoveCatalog
 * 
 * Note: string to WCHAR parameters can be passed when defined as [MarshalAs(UnmanagedType.LPWStr)]string strFile
 */

public partial class CAPIFunctions
{
    [DllImport("wintrust.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool CryptCATAdminAcquireContext(
        [Out] out IntPtr CatAdminHandle,
        [In] [MarshalAs(UnmanagedType.LPStruct)] Guid Subsystem,
        [In] int Flags
    );

    [DllImport("wintrust.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool CryptCATAdminReleaseContext(
        [In] IntPtr CatAdminHandle,
        [In] int Flags
    );

    [DllImport("wintrust.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool CryptCATAdminReleaseCatalogContext(
        [In] IntPtr CatAdminHandle,
        [In] IntPtr CatInfoHandle,
        [In] int Flags
    );

    [DllImport("wintrust.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr CryptCATAdminAddCatalog(
        [In] IntPtr CatAdminHandle,
        [In] [MarshalAs(UnmanagedType.LPWStr)]string strFile,
        [In] [MarshalAs(UnmanagedType.LPWStr)]string strBase,
        [In] Int64 Flags
    );

    [DllImport("wintrust.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool CryptCATAdminRemoveCatalog(
        [In] IntPtr CatAdminHandle,
        [In] [MarshalAs(UnmanagedType.LPWStr)]string strFile,
        [In] int Flags
    );
}

namespace CSCATAdmin
{
    class Program
    {
        // This specifies the 3rd party authenticode store...
        static public readonly Guid DriverActionVerify = new Guid("{f750e6c3-38ee-11d1-85e5-00c04fc295ee}");

        static int Usage()
        {
            Console.WriteLine("Usage: CSCATAdmin [/A] [/R] [/?] [Catalog full file path]\n");
            Console.WriteLine("       /A Add a catalog file");
            Console.WriteLine("       /R Remove a catalog file\n");
            Console.WriteLine(@"Example: CSCATAdmin /A C:\TESTLOCATION\TESTFILE.CAT");
            return 0;
        }

        // C# version of IsAdministrator From: http://msdn.microsoft.com/en-us/library/aa376389(VS.85).aspx

        static bool IsAdministrator()
        {
            // Greatly simplified from the C version...
            WindowsIdentity  identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal (identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        // AddCatalog method from: http://msdn.microsoft.com/en-us/library/ff547575

        static bool AddCatalog(string strFullPath, string strFilePart)
        {
            IntPtr catAdmin;
            IntPtr catInfo;

            // Acquire a handle to a catalog administrator context
            if (!CAPIFunctions.CryptCATAdminAcquireContext(out catAdmin, DriverActionVerify, 0))
            {
                Console.WriteLine("CAPI Error: Unable to obtain catalog administrator context");
                return false;
            }

            // Attempt to add the catalog file...
            catInfo = CAPIFunctions.CryptCATAdminAddCatalog(catAdmin, strFullPath, strFilePart, 0);

            // Cleanup...
            if (catInfo==null)
            {
                CAPIFunctions.CryptCATAdminReleaseContext(catAdmin, 0);
                Console.WriteLine("CAPI Error: Unable to add catalog file %s",strFilePart);
                return false;
            }
            else
            {
                CAPIFunctions.CryptCATAdminReleaseCatalogContext(catAdmin, catInfo, 0);
                CAPIFunctions.CryptCATAdminReleaseContext(catAdmin, 0);
                Console.WriteLine("%s added successfully", strFilePart);
            }

            return true;
        }

        /* RemoveCatalog calls the native function CryptCATAdminRemoveCatalog.
         * This function takes as the argument only the filename part of the catalog to be removed
         * The strFile parameter must be the filename part only and must not contain any path information
         * e.g. CATALOG.CAT only and not C:\MYDIR\CATALOG.CAT
         */
         
        static bool RemoveCatalog(string strFile)
        {
            IntPtr catAdmin;

            // Acquire a handle to a catalog administrator context...
            if (!CAPIFunctions.CryptCATAdminAcquireContext(out catAdmin, DriverActionVerify, 0))
            {
                Console.WriteLine("CAPI Error: Unable to obtain catalog administrator context");
                return false;
            }

            // Attempt to remove the catalog file...
            if (!CAPIFunctions.CryptCATAdminRemoveCatalog(catAdmin, strFile, 0))
            {
                Console.WriteLine("CAPI Error: Unable to remove catalog");
            }
            else Console.WriteLine("%s removed successfully", strFile);

            // Cleanup...
            if (catAdmin != null) CAPIFunctions.CryptCATAdminReleaseContext(catAdmin, 0);

            return true;
        }
    
        static int Main(string[] args)
        {
            int nCount = 0;
            string strFullPath;
            string strFilePart;
            string strCommand;

            // Set the DRIVER_ACTION_VERIFY equivalent
            // This defines where the catalog file will be stored (third party Authenticode)
            Guid devGuid = new Guid("{0xf750e6c3,0x38ee,0x11d1,{ 0x85,0xe5,0x0,0xc0,0x4f,0xc2,0x95,0xee}}");

            // Check to see if the user is elevated administrative user...
            if (!IsAdministrator())
            {
                Console.WriteLine("UserError: Current user is not elevated or part of the administrators group.");
                return 0;
            }

            // Command line checking and parsing...

            foreach (string arg in args) nCount++;
            if (nCount != 2) return Usage();

            strCommand = args[0].ToUpper();
            strFullPath = args[1];

            if (!File.Exists(strFullPath))
            {
                Console.WriteLine("FileError: File %s does not exist!", strFullPath);
                return 0;
            } 

            strFilePart = Path.GetFileName(strFullPath);

            // Execute the command...

            switch (strCommand[0])
            {
                case '/':
                case '-':
                    switch (strCommand[1])
                    {
                        case 'A':
                            AddCatalog(strFullPath,strFilePart);
                           break;
                        case 'R':
                            RemoveCatalog(strFilePart);
                            break;
                    }
                    break;
            }
            return 0;
        }
    }
}
