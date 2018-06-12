/****************************** Module Header ******************************\
 * Module Name:  OneTimePassword.cs
 * Project:      CSWindowsStoreAppASHWID
 * Copyright (c) Microsoft Corporation.
 * 
 * Model class for OTP Nonce storage.
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
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CSWindowsStoreAppDeviceService.Models
{
    /// <summary>
    /// Model class for One Time Password repository
    /// The class is used as Json objects accross C/S.
    /// </summary>
    [DataContract]
    public class OneTimePassword
    {
        [IgnoreDataMember]
        [Key]
        public Guid AgentId { get; set; }

        [DataMember]
        public string Nonce { get; set; }

        [IgnoreDataMember]
        public DateTime ExpiredTime { get; set; }
    }
}