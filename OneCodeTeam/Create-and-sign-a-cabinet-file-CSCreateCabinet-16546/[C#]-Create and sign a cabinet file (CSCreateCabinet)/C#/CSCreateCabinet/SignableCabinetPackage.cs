/****************************** Module Header ******************************\
 * Module Name:  SignedCabinetPackage.cs
 * Project:      CSCreateCabinet
 * Copyright (c) Microsoft Corporation.
 * 
 * This class represents a signable cabinet package. 
 * 
 * It inherits Microsoft.Deployment.Compression.Cab.CabInfo class, which could 
 * be used to create a cabinet package. For more detailed information about creating
 * a normal cabinet package, see the SDK documents of WiX Toolset
 * http://wix.codeplex.com/releases/view/60102
 * 
 * The Sign method uses Signtool.exe to sign the cabinet package. 
 * http://msdn.microsoft.com/en-us/library/8s9b9yaz.aspx
 * 
 * To verify the signature of a cabinet package, we can use WinVerifyTrust function.
 * The WinVerifyTrust function performs a trust verification action on a specified object.
 * The function passes the inquiry to a trust provider that supports the action identifier,
 * if one exists.
 * http://msdn.microsoft.com/en-us/library/windows/desktop/aa388208(v=vs.85).aspx
 * 
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using CSCreateCabinet.Signature;
using Microsoft.Deployment.Compression.Cab;

namespace CSCreateCabinet
{

    [Serializable]
    public class SignableCabinetPackage : CabInfo
    {
        public SignableCabinetPackage(string path)
            : base(path)
        {}

        protected SignableCabinetPackage(SerializationInfo info, StreamingContext context)
            :base(info, context)
        {}

        /// <summary>
        /// Sign the cabinet using signtool.exe.
        /// </summary>
        /// <param name="pfxFilePath"></param>
        /// <param name="password"></param>
        [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        public void Sign(string pfxFilePath, string password)
        {
            ProcessStartInfo signtool = new ProcessStartInfo
            {
                Arguments = string.Format("sign /f {0} /p {1} {2}",
                pfxFilePath, password, this.FullPath),
                FileName = "signtool.exe",
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };

            Process signtoolProc = Process.Start(signtool);
            signtoolProc.WaitForExit();

            if (signtoolProc.ExitCode != 0)
            {
                throw new ApplicationException(signtoolProc.StandardOutput.ReadToEnd());
            }
        }

        /// <summary>
        /// Verify the signature of a cabinet.
        /// </summary>
        public void Verify()
        {
            using (NativeMethods.WINTRUST_DATA wtd = new NativeMethods.WINTRUST_DATA(this.FullPath))
            {

                Guid guidAction = new Guid(NativeMethods.WINTRUST_ACTION_GENERIC_VERIFY_V2);
                int result = NativeMethods.WinVerifyTrust(
                    NativeMethods.INVALID_HANDLE_VALUE,
                    guidAction,
                    wtd);

                if (result != 0)
                {
                    var exception = Marshal.GetExceptionForHR(result);
                    throw exception;
                }
            }
        }


        #region Static Helper Functions

        public static SignableCabinetPackage LoadOrCreateCab(string path)
        {
            if (File.Exists(path))
            {
                return LoadCab(path);
            }
            else
            {
                return CreateCab(path);
            }
        }

        public static SignableCabinetPackage LoadCab(string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException("Cannot find the path " + path);
            }

            SignableCabinetPackage pkg = new SignableCabinetPackage(path);

            if (!pkg.IsValid())
            {
                throw new ArgumentException("This is not a valid cabinet file.");
            }

            return pkg;
        }

        public static SignableCabinetPackage CreateCab(string path)
        {
            return CreateCab(path, true);
        }

        public static SignableCabinetPackage CreateCab(string path, bool overrideExistingFile)
        {
            if (File.Exists(path))
            {
                if (overrideExistingFile)
                {
                    File.Delete(path);
                }
                else
                {
                    throw new ArgumentException("There is already a file named " + path);
                }
            }

            SignableCabinetPackage pkg = new SignableCabinetPackage(path);
            return pkg;
        }

        #endregion

    }
}
