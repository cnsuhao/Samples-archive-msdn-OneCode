/****************************** Module Header ******************************\
 * Module Name:  OneTimePasswordController.cs
 * Project:      CSWindowsStoreAppASHWID
 * Copyright (c) Microsoft Corporation.
 * 
 * OneTimePasswordController for client to retrieve OTP nonce from the server.
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
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Web.Http;
using CSWindowsStoreAppDeviceService.Models;

namespace CSWindowsStoreAppDeviceService.Controllers
{
    public class OneTimePasswordController : ApiController
    {
        private readonly CSWindowsStoreAppDeviceServiceContext db = new CSWindowsStoreAppDeviceServiceContext();

        /// <summary>
        /// GET api/OneTimePassword
        /// Get OTP nonce from the cloud
        /// </summary>
        /// <returns></returns>
        public OneTimePassword GetOneTimePasswords()
        {
            var userAgent = Request.Headers.UserAgent.ToString();
            if (!userAgent.StartsWith("AllInOneCode-"))
            {
                return null;
            }

            userAgent = userAgent.Substring("AllInOneCode-".Length);
            var userAgentGuid = new Guid(userAgent);

            OneTimePassword otp = null;
            if (ModelState.IsValid)
            {
                otp = db.OneTimePasswords.Find(userAgentGuid);
                if (otp != null)
                {
                    // Found the original otp in the database, renew the expired time.
                    otp.ExpiredTime = DateTime.UtcNow.AddMinutes(1);
                    otp.Nonce = Guid.NewGuid().ToString().Substring(0, 6);
                    db.Entry(otp).State = EntityState.Modified;
                }
                else
                {
                    otp = new OneTimePassword
                    {
                        AgentId = new Guid(userAgent),
                        // Password will be expired in one minute by default.
                        ExpiredTime = DateTime.UtcNow.AddMinutes(1),
                        // Nonce will be generated randomly in a substring of GUID value.
                        Nonce = Guid.NewGuid().ToString().Substring(0, 6)
                    };
                    db.OneTimePasswords.Add(otp);
                }

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException duce)
                {
                    Debug.WriteLine(duce.Message);
                    Debug.WriteLine(duce.StackTrace);
                }
            }

            return otp;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}