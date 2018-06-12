/****************************** Module Header ******************************\
 * Module Name:  MainViewModel.cs
 * Project:      CSWindowsStoreAppDeviceClient
 * Copyright (c) Microsoft Corporation.
 * 
 * ViewModel for the MainPage.
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
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using CSWindowsStoreAppDeviceClient.Common;
using CSWindowsStoreAppDeviceService.Models;
using Windows.Data.Json;
using Windows.Security.Cryptography;
using Windows.Storage.Streams;
using Windows.System.Profile;
using Windows.UI.Popups;

namespace CSWindowsStoreAppDeviceClient.ViewModel
{
    /// <summary>
    /// ViewModel for MainPage View.
    /// </summary>
    internal class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Nested class for const property names for NotifyProperty in data binding.
        /// </summary>
        private static class PropertyNames
        {
            internal const string RegisterDeviceBtnTextPropertyName = "RegisterDeviceBtnText";
            internal const string OutputTextPropertyName = "OutputText";
        }

        #region Private fields

        private readonly Guid _customerId;
        private readonly string _clientAgentId;
        private const string MediaTypeHeaderJson = "application/json";
        private string _outputText;
        private bool _canVerifyLicense;
        private DelegateCommand _registerDeviceCommand;
        private DelegateCommand _footerCommand;

        // Specify the cloud service base Uri here.
        private const string ServiceBaseUri = @"http://localhost:12345/";
        // Use following relative path to retrieve the OTP nonce from the cloud.
        private const string GetNonceApiUriPath = "api/OneTimePassword";
        // Use following relative path to post ASHWID token to the cloud.
        private const string PostASHWIDApiUriPath = "api/ASHWID";

        #endregion
        
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MainViewModel()
        {
            // CustomerId varies, could be the Microsoft Account identification.
            // Hardcode the CustomerId here for demostration purpose.
            _customerId = new Guid("00000000-0000-0000-0000-000000000001");
            _clientAgentId = "AllInOneCode-" + Guid.NewGuid();
            CanVerifyLicense = false;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Update the text on RegisterDevice button.
        /// For the first time, "Register Device on cloud" is shown.
        /// After registration, "Verify Device on cloud" text is replaced.
        /// </summary>
        bool CanVerifyLicense
        {
            get
            {
                return _canVerifyLicense;
            }
            set
            {
                _canVerifyLicense = value;
                RegisterDeviceBtnText = _canVerifyLicense ? "Verify Device on Cloud" : "Register Device on Cloud";
                NotifyPropertyChanged(PropertyNames.RegisterDeviceBtnTextPropertyName);
            }
        }

        /// <summary>
        /// Properties bound to the RegisterDevice button.
        /// </summary>
        public string RegisterDeviceBtnText { get; set; }

        /// <summary>
        /// Properties bound to the OutputText TextBlock.
        /// </summary>
        public string OutputText
        {
            get
            {
                return _outputText;
            }
            set
            {
                _outputText = value;
                NotifyPropertyChanged(PropertyNames.OutputTextPropertyName);
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// DelegateCommand for "Register Device on Cloud" Button
        /// </summary>
        public DelegateCommand RegisterDeviceCommand
        {
            get
            {
                return _registerDeviceCommand ?? 
                    (_registerDeviceCommand = new DelegateCommand(o => RegisterDevice()));
            }
        }

        /// <summary>
        /// DelegateCommand for "Footer" HyperLinkButton
        /// </summary>
        public DelegateCommand FooterCommand
        {
            get
            {
                return _footerCommand ??
                       (_footerCommand = new DelegateCommand(o => NavigateToOneCodeSite()));
            }
        }

        /// <summary>
        /// Register Device Execute delegate handler.
        /// The registration follows the steps below:
        /// 1. Retrieve random nounce from the cloud.
        /// 2. Retrieve ASHWID hardware token through HardwareIdentification.GetPackageSpecificToken
        /// 3. Register/Verify the ASHWID token from app to the cloud.
        /// 4. Show the post result in the client.
        /// </summary>
        private async void RegisterDevice()
        {
            // Get the randomly one time nonce (expired in 1 mins) from the server.
            var nonce = GetNonce().Result;
            if (nonce == null)
            {
                WriteToOutputText("Retrieve random nonce from the cloud failure.  Please check the network connectivity...");
                return;
            }
            var nonceBytes = Utilities.ConvertBufferToByteArray(nonce);
            WriteToOutputText(String.Format("Get random nonce from the cloud: {0}",
                new UTF8Encoding().GetString(nonceBytes, 0, nonceBytes.Length)));

            // Hardware id, signature, certificate IBuffer objects that can be accessed through properties.
            HardwareToken packageSpecificToken = HardwareIdentification.GetPackageSpecificToken(nonce);
            var hwId = new Ashwid
                {
                    CustomerId = _customerId,
                    HardwareId = Utilities.ConvertBufferToByteArray(packageSpecificToken.Id),
                    Certificate = Utilities.ConvertBufferToByteArray(packageSpecificToken.Certificate),
                    Signature = Utilities.ConvertBufferToByteArray(packageSpecificToken.Signature),
                };
            WriteToOutputText(String.Format(
                "Call API \"HardwareIdentification.GetPackageSpecificToken(nonce)\" " +
                "to retrieve Hardware identification on the current device:\r\n  {0}",
                BitConverter.ToString(hwId.HardwareId)));

            WriteToOutputText(String.Format(
                "Current customer id (Hardcoded, " +
                "need be replaced by Microsoft Account Id or per your business logic):" +
                "\r\n  {0}", _customerId));

            WriteToOutputText(String.Format("Start to {0} Hardware Id to the cloud...", 
                CanVerifyLicense ? "verify" : "register"));
            if (await PostASHWID(hwId))
            {
                WriteToOutputText(String.Format("{0} ASHWID to the cloud successfully.",
                    CanVerifyLicense ? "Verify" : "Register"));
            }
            else
            {
                WriteToOutputText(String.Format("{0} ASHWID on the cloud failure.",
                    CanVerifyLicense ? "Verify" : "Register"));
            }
            WriteToOutputText("--------------------------------------------" +
                              "--------------------------------------------"); 
            CanVerifyLicense = true;
        }

        private static async void NavigateToOneCodeSite()
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("http://blogs.msdn.com/b/onecode"));
        }
        #endregion

        #region WebApi Request to the Cloud

        /// <summary>
        /// Request a nonce from the server
        /// </summary>
        /// <returns>
        /// Return the nonce from the cloud.
        /// If get the request error, return null by default.
        /// </returns>
        private async Task<IBuffer> GetNonce()
        {
            String errMsg = String.Empty;

            try
            {
                using (var client = new HttpClient())
                {
                    // Add a unique AgentId to the request header.
                    client.DefaultRequestHeaders.UserAgent.ParseAdd(_clientAgentId);

                    // Use JSON request to get the nonce from the cloud side.
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeHeaderJson));
                    client.BaseAddress = new Uri(ServiceBaseUri);

                    string content = client.GetStringAsync(GetNonceApiUriPath).Result;

                    var stream = new MemoryStream(Encoding.Unicode.GetBytes(content));

                    // Deserialize the OneTimePassword
                    var serializer = new DataContractJsonSerializer(typeof(OneTimePassword));
                    var otpObj = serializer.ReadObject(stream) as OneTimePassword;
                    if (otpObj != null && !string.IsNullOrEmpty(otpObj.Nonce))
                    {
                        return CryptographicBuffer.ConvertStringToBinary(otpObj.Nonce, BinaryStringEncoding.Utf8);
                    }
                }
            }
            catch (HttpRequestException hReqEx)
            {
                errMsg = String.Format("HttpRequest error: {0}", hReqEx.Message);
            }
            catch (Exception ex)
            {
                errMsg = String.Format("HttpRequest error: {0}", ex.Message);
            }

            if (!String.IsNullOrEmpty(errMsg))
            {
                await (new MessageDialog(errMsg)).ShowAsync();
            }

            return null;
        }

        /// <summary>
        /// Post ASHWID to the cloud.
        /// </summary>
        /// <param name="hwId"></param>
        private async Task<bool> PostASHWID(Ashwid hwId)
        {
            String errMsg = String.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    // Add a unique AgentId to the request header.
                    client.DefaultRequestHeaders.UserAgent.ParseAdd(_clientAgentId);

                    // Use JSON request to post the ASHWID to the cloud side.
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeHeaderJson));
                    client.BaseAddress = new Uri(ServiceBaseUri);

                    // Use Json serializer
                    var serializer = new DataContractJsonSerializer(typeof(Ashwid));
                    using (var stream = new MemoryStream())
                    {
                        serializer.WriteObject(stream, hwId);
                        stream.Seek(0, SeekOrigin.Begin);

                        var jsonContent = new StreamReader(stream).ReadToEnd();
                        var response = await client.PostAsync(PostASHWIDApiUriPath,
                            new StringContent(jsonContent, Encoding.UTF8, MediaTypeHeaderJson));
                        if (response.IsSuccessStatusCode)
                        {
                            return true;
                        }

                        // If errors happen during the certification & signature validation,
                        // show the error message in the MessageDialog.
                        var data = await response.Content.ReadAsStringAsync();
                        if (data != null)
                        {
                            JsonObject content;
                            JsonObject.TryParse(data, out content);
                            if (content != null)
                            {
                                IJsonValue val;
                                content.TryGetValue("Message", out val);
                                if (val != null)
                                {
                                    await (new MessageDialog(string.Format("{0}: {1}",
                                        response.ReasonPhrase, val.GetString()))).ShowAsync();
                                }
                            }
                        }
                    }
                }
            }
            catch (HttpRequestException hReqEx)
            {
                errMsg = string.Format("HttpRequest error: {0}", hReqEx.Message);
            }

            if (!String.IsNullOrEmpty(errMsg))
            {
                await (new MessageDialog(errMsg)).ShowAsync();
            }

            return false;
        }

        #endregion

        #region Utilities

        private void WriteToOutputText(String message)
        {
            OutputText += string.Format("- {0}\r\n\r\n", message);
        }

        #endregion
    }
}
