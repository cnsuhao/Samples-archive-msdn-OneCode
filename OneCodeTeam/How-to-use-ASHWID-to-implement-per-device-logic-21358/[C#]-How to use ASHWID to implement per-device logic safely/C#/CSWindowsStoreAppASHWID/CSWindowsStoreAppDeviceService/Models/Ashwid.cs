/****************************** Module Header ******************************\
 * Module Name:  Ashwid.cs
 * Project:      CSWindowsStoreAppASHWID
 * Copyright (c) Microsoft Corporation.
 * 
 * Model class for Hardware ID ASHWID storage.
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
    /// Model class for ASHWID Hardware token
    /// The class is used as Json objects accross C/S.
    /// </summary>
    [DataContract]
    public class Ashwid
    {
        [Key]
        [DataMember]
        public Guid CustomerId { get; set; }

        [DataMember]
        public byte[] HardwareId { get; set; }

        [DataMember]
        public byte[] Certificate { get; set; }

        [DataMember]
        public byte[] Signature { get; set; }
    }
}