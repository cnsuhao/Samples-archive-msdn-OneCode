/****************************** Module Header ******************************\
Module Name: Default.aspx.cs
Project:     RetryCacheRole
Copyright (c) Microsoft Corporation.

When using cloud based services, it is very common to receive exceptions similar
to below while performing cache operations such as get, put. These are called transient errors.  
Developer is required to implement Retrylogic to successfully complete their cache operations. 

ErrorCode<ERRCA0017>:SubStatus<ES0006>:There is a temporary failure. Please retry later. 
(One or more specified cache servers are unavailable, which could be caused by busy 
network or servers. For on-premises cache clusters, also verify the following conditions. 
Ensure that security permission has been granted for this client account, and check 
that the AppFabric Caching Service is allowed through the firewall on all cache hosts. 
Also the MaxBufferSize on the server must be greater than or equal to the serialized 
object size sent from the client.)
 
This sample implements retrylogic to protect the application from crashing in the 
event of transient errors. This sample uses Transient Fault Handling Application 
Block to implement retry mechanism

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.ApplicationServer.Caching;

using Microsoft.Practices.TransientFaultHandling;
using Microsoft.Practices.EnterpriseLibrary.WindowsAzure.TransientFaultHandling;
using Microsoft.Practices.EnterpriseLibrary.WindowsAzure.TransientFaultHandling.Cache;

namespace RetryCacheRole
{

    public partial class _Default : System.Web.UI.Page
    {
        // Define DataCache object
        DataCache cache;

        // Global variable for retry strategy
        FixedInterval retryStrategy;

        // Global variable for retry policy
        RetryPolicy retryPolicy;

        protected void Page_Load(object sender, EventArgs e)
        {
           // Configure retry policies, strategies, actions
            SetupRetryPolicy();

           // Create cache object using the cache settings specified web.config 
           cache = CacheUtil.GetCacheConfig();
        }

        protected void btnReadFromCache_Click(object sender, EventArgs e)
        {
            try
            {
                // In order to use the retry policies, strategies defined in Transient Fault 
                // Handling Application Block , user calls to cache must be wrapped with in 
                // ExecuteAction delegate.
                retryPolicy.ExecuteAction(
                    () =>
                    {
                        
                        // Getting the object from azure cache and printing it on the page. 
                        Response.Write(cache.Get("MyDataSet"));
                    });
            }
            catch (DataCacheException dc)
            {
                // Exception occurred after implementing the Retry logic.
                // Ideally you should log the exception to your application logs and show user 
                // friendly error message on the webpage.
                Trace.Write(dc.GetType().ToString() + dc.Message.ToString() + dc.StackTrace.ToString());
            }
        }

          
        protected void btnAddToCache_Click(object sender, EventArgs e)
        {
            try
            {
                // In order to use the retry policies, strategies defined in Transient Fault Handling
                // Application Block , user calls to cache must be wrapped with in ExecuteAction delegate
                retryPolicy.ExecuteAction(
                    () =>
                    {
                        // I'm just storing simple string object here .. Assuming this call fails, 
                        // this sample retries the same call 3 times with 1 second interval before it gives up.
                        cache.Put("MyDataSet", "My Cache");
                        Response.Write("String object added to cache!");
                    });
                                                
            }
            catch (DataCacheException dc)
            {
                // Exception occurred after implementing the Retry logic.
                // Ideally you should log the exception to your application logs and show user friendly 
                // error message on the webpage.
                Trace.Write(dc.GetType().ToString() + dc.Message.ToString() + dc.StackTrace.ToString());
            }
        }

        /// <summary>
        /// This method configures strategies, policies, actions required for performing retries.
        /// </summary> 
        protected void SetupRetryPolicy()
        {
            // Define your retry strategy: in this sample, I'm retrying operation 3 times with 1 second interval
            retryStrategy = new FixedInterval(3, TimeSpan.FromSeconds(1));

            // Define your retry policy here. This sample uses CacheTransientErrorDetectionStrategy 
            retryPolicy = new RetryPolicy<CacheTransientErrorDetectionStrategy>(retryStrategy);

            // Get notifications from retries from  Transient Fault Handling Application Block code
            retryPolicy.Retrying += (sender1, args) =>
            {
                // Log details of the retry.
                var msg = String.Format("Retry - Count:{0}, Delay:{1}, Exception:{2}",
                    args.CurrentRetryCount, args.Delay, args.LastException);

                // Logging the notification details to the application trace. 
                Trace.Write(msg);
            };
        }
     

     
    }
}
