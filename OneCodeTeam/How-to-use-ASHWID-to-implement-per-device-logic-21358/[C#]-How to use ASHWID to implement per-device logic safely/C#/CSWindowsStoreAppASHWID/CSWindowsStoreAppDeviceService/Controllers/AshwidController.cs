/****************************** Module Header ******************************\
 * Module Name:  AshwidController.cs
 * Project:      CSWindowsStoreAppASHWID
 * Copyright (c) Microsoft Corporation.
 * 
 * AshwidController class for client to upload Ashwid and verify the genuine of the
 * Hardware Id and deal with the Hardware drift.
 *  
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Http;
using CSWindowsStoreAppDeviceService.Properties;
using CSWindowsStoreAppDeviceService.Models;
using Security.Cryptography;

namespace CSWindowsStoreAppDeviceService.Controllers
{
    public class AshwidController : ApiController
    {
        private CSWindowsStoreAppDeviceServiceContext db = new CSWindowsStoreAppDeviceServiceContext();
        private OneTimePassword _otp;

        #region Public Key
        /// <summary>
        /// Public Key for "Microsoft Assurance Designation Root 2011"
        /// </summary>
        private static readonly byte[] GRootPublicKey = new byte[] {
            0x30, 0x82, 0x02, 0x0a, 0x02, 0x82, 0x02, 0x01, 0x00, 0xa8, 0xef, 0xce, 0xef, 0xec, 0x12, 0x8b,
            0x92, 0x94, 0xed, 0xcf, 0xaa, 0xa5, 0x81, 0x8d, 0x4f, 0xa4, 0xad, 0x4a, 0xec, 0xa5, 0xf0, 0xda,
            0xa8, 0x3d, 0xb6, 0xe5, 0x61, 0x01, 0x99, 0xce, 0x3a, 0x23, 0x73, 0x5a, 0x58, 0x67, 0x9f, 0xf5,
            0xb6, 0x5b, 0xf5, 0x4f, 0xf9, 0xa0, 0x9b, 0x75, 0x1e, 0xcc, 0x53, 0x62, 0x10, 0x3c, 0xa7, 0xa5,
            0x3a, 0x3b, 0xe6, 0x24, 0x22, 0xf4, 0x18, 0x96, 0x2e, 0xf2, 0xfc, 0xd9, 0xa5, 0x88, 0xc6, 0xfd,
            0x51, 0xf0, 0x31, 0xc3, 0xbd, 0x01, 0xdc, 0x45, 0xb6, 0xf6, 0x40, 0x2b, 0xb7, 0x45, 0x7b, 0x45,
            0x4f, 0xed, 0xc0, 0xb4, 0x7c, 0x58, 0x44, 0xf9, 0x89, 0xfb, 0x6a, 0x75, 0x3b, 0x6d, 0xf1, 0x2e,
            0xac, 0x35, 0xa1, 0x5f, 0x7a, 0x94, 0xcd, 0x3a, 0x6d, 0x98, 0xb8, 0xb8, 0x29, 0xe6, 0x33, 0x98,
            0x2e, 0x33, 0x83, 0x7a, 0x86, 0xb7, 0xa8, 0x0a, 0x10, 0xf2, 0x07, 0x32, 0x63, 0xe4, 0x32, 0xed,
            0x4d, 0xab, 0x05, 0x0c, 0xa1, 0xd7, 0x72, 0x49, 0xac, 0x35, 0x2c, 0x2e, 0x70, 0xed, 0xee, 0x12,
            0xfc, 0x23, 0xb1, 0xdc, 0x5a, 0xdf, 0x61, 0xe9, 0x2c, 0x44, 0xcd, 0xae, 0xdb, 0x06, 0x54, 0x8f,
            0x4f, 0xc1, 0xd6, 0x15, 0x72, 0xae, 0x50, 0x89, 0x39, 0x89, 0xf5, 0x95, 0x82, 0xdc, 0xff, 0x41,
            0xeb, 0x89, 0x6f, 0xbc, 0xe0, 0x9f, 0x79, 0x5d, 0x24, 0x16, 0xf7, 0x1d, 0x38, 0xaa, 0xde, 0xd8,
            0x24, 0x97, 0xf6, 0x97, 0x47, 0x74, 0x5b, 0x23, 0x38, 0xc8, 0x9d, 0x2e, 0xaa, 0xd1, 0x1f, 0xce,
            0x09, 0x5c, 0xf1, 0xb9, 0x9f, 0x92, 0x38, 0xd2, 0x11, 0x68, 0x3e, 0xcc, 0x5d, 0x4e, 0xcf, 0x94,
            0x9f, 0xd2, 0x42, 0xbd, 0xe2, 0xf1, 0x4b, 0xf1, 0xa7, 0xa9, 0x5c, 0x79, 0x05, 0xfb, 0x25, 0xf7,
            0xc1, 0x53, 0xf7, 0xd9, 0xc4, 0x4d, 0x79, 0x0f, 0x8a, 0x4d, 0xb4, 0x30, 0x71, 0xa6, 0xe9, 0x51,
            0xe5, 0x8e, 0xe0, 0xc8, 0x83, 0xc7, 0x31, 0xfc, 0x98, 0x46, 0xf6, 0xa2, 0x76, 0xfc, 0xa6, 0x81,
            0x6d, 0x76, 0x90, 0x8d, 0x32, 0x21, 0x1f, 0x2d, 0x3e, 0x69, 0x2b, 0x4f, 0xaa, 0xec, 0x7b, 0xd3,
            0xb9, 0x64, 0xc1, 0xd6, 0xbb, 0x5f, 0xfa, 0x38, 0xc4, 0x41, 0xa6, 0x6d, 0x5a, 0xc3, 0x11, 0x87,
            0xfb, 0xbc, 0x33, 0x70, 0x4a, 0x26, 0x8b, 0xe6, 0x44, 0xdd, 0xcb, 0xb8, 0x30, 0xd3, 0x9b, 0x7b,
            0x1a, 0x0e, 0x03, 0xb4, 0x51, 0xe0, 0xca, 0xbf, 0x7b, 0x3c, 0x57, 0x9a, 0xa0, 0xd8, 0x4b, 0xfe,
            0x7e, 0x36, 0xd8, 0x81, 0xfa, 0x25, 0xbd, 0x7e, 0x03, 0xf5, 0x59, 0x2c, 0xf6, 0xd7, 0xa7, 0x6d,
            0xdd, 0x10, 0x77, 0x77, 0x09, 0xae, 0x76, 0xe2, 0x85, 0x33, 0xa6, 0x7d, 0x71, 0x20, 0xf8, 0x3a,
            0x4f, 0x2a, 0xb6, 0xea, 0x42, 0x29, 0xd0, 0xd3, 0xc6, 0x29, 0x4b, 0x05, 0x2c, 0xe7, 0xb8, 0x4a,
            0xcf, 0xd2, 0xbb, 0x82, 0x20, 0x30, 0x9b, 0xa2, 0x4d, 0x1f, 0x78, 0x2c, 0xd9, 0x54, 0x13, 0xd8,
            0x2a, 0x28, 0x68, 0x51, 0x56, 0xa5, 0xf7, 0xdb, 0xae, 0x59, 0x0e, 0xb9, 0xd1, 0x30, 0x97, 0x82,
            0x04, 0x66, 0xa5, 0x02, 0x3c, 0x25, 0xfa, 0xdd, 0xed, 0x09, 0xc2, 0x60, 0xbc, 0x17, 0x6c, 0xa1,
            0x5a, 0xb6, 0x97, 0xcc, 0x8a, 0x13, 0x56, 0xf6, 0xb4, 0xae, 0xdf, 0xcf, 0x7e, 0x40, 0x2f, 0x49,
            0x41, 0xe0, 0x63, 0x8e, 0x58, 0x20, 0xcc, 0xa3, 0x4f, 0x33, 0x3b, 0x9b, 0xcf, 0x3c, 0x72, 0x7e,
            0x48, 0x41, 0x42, 0x3d, 0x63, 0xe3, 0x5e, 0xe7, 0x75, 0x6c, 0x7f, 0xef, 0x6d, 0x80, 0x09, 0xa4,
            0x2b, 0xa4, 0x3e, 0xde, 0xe4, 0x2b, 0x2c, 0x2b, 0xa9, 0x44, 0x56, 0x83, 0xbe, 0xb6, 0x6e, 0x60,
            0xb9, 0x16, 0x1a, 0xe1, 0x62, 0xe9, 0x54, 0x9d, 0xbf, 0x02, 0x03, 0x01, 0x00, 0x01};
        #endregion

        /// <summary>
        /// POST api/Ashwid
        /// 1. Validate the trustworthiness and the validity of the Hardware Id posted
        /// 2. Handle the hardware drift within the cloud service.
        /// </summary>
        /// <param name="ashwid"></param>
        /// <returns></returns>
        public HttpResponseMessage PostAshwid(Ashwid ashwid)
        {
            const int thresholdForBeingTheSameDevice = 0;
            if (ModelState.IsValid)
            {
                if (!NonceIsValid)
                {
                    // RequestTimeout 408
                    var rm = Request.CreateErrorResponse(HttpStatusCode.RequestTimeout,
                        Resources.NonceInValid);
                    rm.ReasonPhrase = Resources.NonceInValid;
                    return rm;
                }

                //HttpResponseMessage resMsg;
                string reasonPhraseMsg = string.Empty;
                switch (VerifyDataGenuine(ashwid))
                {
                    case DataGenuineResult.NoLeafCert:
                        reasonPhraseMsg = Resources.LeafCertificateNotFound;
                        break;
                    case DataGenuineResult.CertificationChainVerificationFailure:
                        reasonPhraseMsg = Resources.CertificationChainVerificationFailure;
                        break;
                    case DataGenuineResult.RootCertificateInvalid:
                        reasonPhraseMsg = Resources.RootCertificateInvalid;
                        break;
                    case DataGenuineResult.SignatureInvalid:
                        reasonPhraseMsg = Resources.SignatureInvalid;
                        break;
                    case DataGenuineResult.Invalid:
                        reasonPhraseMsg = Resources.DataInValid;
                        break;
                }

                if (!string.IsNullOrEmpty(reasonPhraseMsg))
                {
                    // Forbidden 403
                    return Request.CreateErrorResponse(
                        HttpStatusCode.Forbidden, reasonPhraseMsg);
                }

                var baseHardwareId = db.Ashwids.Find(ashwid.CustomerId);

                if (baseHardwareId != null && ashwid.HardwareId != null)
                {
                    var diffValue = DiffDeviceDictionary(ConvertHwIdToDevDic(baseHardwareId.HardwareId),
                                         ConvertHwIdToDevDic(ashwid.HardwareId));

                    if (diffValue > thresholdForBeingTheSameDevice)
                    {
                        return Request.CreateErrorResponse(
                            HttpStatusCode.Forbidden, Resources.LicenseRefused);
                    }
                }
                else
                {
                    db.Ashwids.Add(ashwid);
                    db.SaveChanges();
                }

                var response = Request.CreateResponse(HttpStatusCode.Created, ashwid);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = ashwid.CustomerId }));
                return response;
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Determine if the returned nonce is valid. By default, nonce will be expired in 1 min.
        /// </summary>
        private bool NonceIsValid
        {
            get
            {
                var userAgent = Request.Headers.UserAgent.ToString();
                if (userAgent.StartsWith("AllInOneCode-"))
                {
                    userAgent = userAgent.Substring("AllInOneCode-".Length);
                    var userAgentGuid = new Guid(userAgent);
                    _otp = db.OneTimePasswords.Find(userAgentGuid);

                    if (_otp != null && (DateTime.Compare(_otp.ExpiredTime, DateTime.UtcNow) > 0))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Enum type of DataGenuineResult, used in the error handling of HttpResponseMessage.
        /// </summary>
        private enum DataGenuineResult
        {
            Genuine,
            NoLeafCert,
            CertificationChainVerificationFailure,
            RootCertificateInvalid,
            SignatureInvalid,
            Invalid,
        }

        /// <summary>
        /// Verify the trustworthiness and genuine of the posted Hardware Id
        /// by using nonce, signature and certificate.
        /// </summary>
        /// <param name="ashwid">
        /// ASHWID with Hardware Id, certificate and signature
        /// </param>
        /// <returns>The enum type of DataGenuineResult</returns>
        private DataGenuineResult VerifyDataGenuine(Ashwid ashwid)
        {
            const string basicConstraintName = "Basic Constraints";
            const string leafCertEku = "1.3.6.1.4.1.311.10.5.40";
            try
            {
                // Extract certificates from the ASHWID certificate blob.
                // Certificate blob is a PKCS#7 formatted certification chain.
                var cms = new SignedCms();
                cms.Decode(ashwid.Certificate);

                // Looping through all certificates to find the leaf certificate. 
                X509Certificate2 leafCert = null;
                foreach (var x509 in cms.Certificates)
                {
                    bool basicConstraintExtensionExists = false;
                    foreach (X509Extension extension in x509.Extensions)
                    {
                        if (extension.Oid.FriendlyName == basicConstraintName)
                        {
                            basicConstraintExtensionExists = true;
                            var ext = (X509BasicConstraintsExtension)extension;
                            if (!ext.CertificateAuthority)
                            {
                                leafCert = x509;
                                break;
                            }
                        }
                    }

                    if (leafCert != null)
                    {
                        break;
                    }

                    if (!basicConstraintExtensionExists)
                    {
                        if (x509.Issuer != x509.Subject)
                        {
                            leafCert = x509;
                            break;
                        }
                    }
                }

                if (leafCert == null)
                {
                    return DataGenuineResult.NoLeafCert;
                }

                // Validating the certificate chain. Ignore the errors due to online revocation check not 
                // being available. Also we are not failing validation due to expired certificates. Microsoft
                // will be revoking the certificates that were exploided. 
                var chain = new X509Chain
                {
                    ChainPolicy =
                    {
                        RevocationFlag = X509RevocationFlag.EntireChain,
                        RevocationMode = X509RevocationMode.Online,
                        VerificationFlags = X509VerificationFlags.IgnoreNotTimeValid |
                                            X509VerificationFlags.IgnoreCtlNotTimeValid |
                                            X509VerificationFlags.IgnoreCertificateAuthorityRevocationUnknown |
                                            X509VerificationFlags.IgnoreEndRevocationUnknown |
                                            X509VerificationFlags.IgnoreCtlSignerRevocationUnknown
                    }
                };
                chain.ChainPolicy.ApplicationPolicy.Add(new Oid(leafCertEku));
                var valid = chain.Build(leafCert);

                if (!valid)
                {
                    foreach (X509ChainStatus status in chain.ChainStatus)
                    {
                        switch (status.Status)
                        {
                            case X509ChainStatusFlags.NoError:
                            case X509ChainStatusFlags.NotTimeValid:
                            case X509ChainStatusFlags.NotTimeNested:
                            case X509ChainStatusFlags.CtlNotTimeValid:
                            case X509ChainStatusFlags.RevocationStatusUnknown:
                            case X509ChainStatusFlags.OfflineRevocation:
                                break;

                            default:
                                return DataGenuineResult.CertificationChainVerificationFailure;
                        }
                    }
                }

                // GRootPublicKey is the hard coded public key for the root certificate. 
                // Compare the public key on the root certificate with the hard coded one. 
                // They must match.
                var rootCertificate = chain.ChainElements[chain.ChainElements.Count - 1].Certificate;
                if (!rootCertificate.PublicKey.EncodedKeyValue.RawData.SequenceEqual(GRootPublicKey))
                {
                    return DataGenuineResult.RootCertificateInvalid;
                }

                // Using the leaf Certificate we verify the signature of blob.
                // The RSACryptoServiceProvider does not provide a way to pass in different padding mode.
                // We use CLR Security API by CLR Security's team under:
                // http://clrsecurity.codeplex.com/wikipage?title=Security.Cryptography.RSACng

                // Concatenate nonce and HardwareId
                var nonce = Encoding.UTF8.GetBytes(_otp.Nonce);
                var rawData = new byte[nonce.Length + ashwid.HardwareId.Length];
                Buffer.BlockCopy(nonce, 0, rawData, 0, nonce.Length);
                Buffer.BlockCopy(ashwid.HardwareId, 0, rawData, nonce.Length, ashwid.HardwareId.Length);

                var publicKey = leafCert.PublicKey.Key as RSACryptoServiceProvider;
                if (publicKey != null)
                {
                    var rsa = new RSACng(1024)
                    {
                        EncryptionHashAlgorithm = CngAlgorithm.Sha256,
                        SignatureHashAlgorithm = CngAlgorithm.Sha1,
                        // Use Pss padding here by CLR Security API
                        SignaturePaddingMode = AsymmetricPaddingMode.Pss,
                        SignatureSaltBytes = 0,
                    };
                    var parameters = publicKey.ExportParameters(false);
                    rsa.ImportParameters(parameters);

                    // Use the leaf certificate to verify that the signed hash signature 
                    // matches the original nonce that was sent from the cloud service 
                    // and the received hardware byte stream.
                    bool isSignatureValid = rsa.VerifyData(rawData, ashwid.Signature);
                    if (!isSignatureValid)
                    {
                        return DataGenuineResult.SignatureInvalid;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                return DataGenuineResult.Invalid;
            }

            return DataGenuineResult.Genuine;
        }

        /// <summary>
        /// Convert serialized hardwareId to well formed HardwareId structures so that 
        /// it can be easily consumed. 
        /// </summary>
        /// <param name="hardwareId"></param>
        /// <returns></returns>
        private static IDictionary<int, List<string>> ConvertHwIdToDevDic(Byte[] hardwareId)
        {
            var hardwareIdString = BitConverter.ToString(hardwareId).Replace("-", "");
            // make the empty Device Dictionary data structure
            var deviceDic = new Dictionary<int, List<string>>
                {
                    {0, new List<string>()}, // Invalid
                    {1, new List<string>()}, // Processor
                    {2, new List<string>()}, // Memory
                    {3, new List<string>()}, // Disk Device
                    {4, new List<string>()}, // Network Adapter
                    {5, new List<string>()}, // Audio Adapter
                    {6, new List<string>()}, // Docking Station
                    {7, new List<string>()}, // Mobile Broadband
                    {8, new List<string>()}, // Bluetooth
                    {9, new List<string>()}, // System BIOS
                };

            for (var i = 0; i < hardwareIdString.Length / 8; i++)
            {
                switch (hardwareIdString.Substring(i * 8, 4))
                {
                    case "0100": // Processor
                        deviceDic[1].Add(hardwareIdString.Substring(i * 8 + 4, 4));
                        break;
                    case "0200": // Memory
                        deviceDic[2].Add(hardwareIdString.Substring(i * 8 + 4, 4));
                        break;
                    case "0300": // Disk Device
                        deviceDic[3].Add(hardwareIdString.Substring(i * 8 + 4, 4));
                        break;
                    case "0400": // Network Adapter
                        deviceDic[4].Add(hardwareIdString.Substring(i * 8 + 4, 4));
                        break;
                    case "0500": // Audio Adapter
                        deviceDic[5].Add(hardwareIdString.Substring(i * 8 + 4, 4));
                        break;
                    case "0600": // Docking Station
                        deviceDic[6].Add(hardwareIdString.Substring(i * 8 + 4, 4));
                        break;
                    case "0700": // Mobile Broadband
                        deviceDic[7].Add(hardwareIdString.Substring(i * 8 + 4, 4));
                        break;
                    case "0800": // Bluetooth
                        deviceDic[8].Add(hardwareIdString.Substring(i * 8 + 4, 4));
                        break;
                    case "0900": // System BIOS
                        deviceDic[9].Add(hardwareIdString.Substring(i * 8 + 4, 4));
                        break;
                }
            }

            return deviceDic;
        }

        /// <summary>
        /// Compare two devices to see the difference.
        /// The granularity for the difference is 0.1
        /// </summary>
        /// <param name="devDicBase">Base Device Dictionary</param>
        /// <param name="devDicNew">New Device Dictionary</param>
        /// <returns></returns>
        private static double DiffDeviceDictionary(IDictionary<int, List<string>> devDicBase, IDictionary<int, List<string>> devDicNew)
        {
            // Component Weight in Percentage, updated per the business logic.
            int[] compWeightPercentage =
                {
                    0,  // 0 - Invalid - 0%
                    10, // 1 - Processor - 10%
                    10, // 2 - Memory - 10%
                    20, // 3 - Disk Device - 20%
                    10, // 4 - Network Adapter - 10%
                    10, // 5 - Audio Adapater - 10%
                    5,  // 6 - Docking Station - 5%
                    10, // 7 - Mobile Broadband - 10%
                    5,  // 8 - Bluetooth - 5%
                    20  // 9 - System BIOS - 20%
                };

            double diffValue = 0;
            for (var i = 1; i < 10; ++i)
            {
                var diffCount = devDicBase[i].Count - devDicNew[i].Count;

                // the base component size is bigger than the New one.
                if (diffCount >= 0)
                {
                    diffCount += devDicNew[i].Count(component => !devDicBase[i].Contains(component));
                }
                else
                {
                    diffCount += devDicBase[i].Count(component => !devDicNew[i].Contains(component));
                }

                diffValue += (diffCount * compWeightPercentage[i]);
            }

            return diffValue / 100;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}