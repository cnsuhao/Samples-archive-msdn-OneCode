/****************************** Module Header ******************************\
* Module Name:    CustomService.cs
* Project:        CSSharePointCallClaimsAwareWCF
* Copyright (c) Microsoft Corporation
*
* This class is the server side of CustomService
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Administration;

namespace CustomService
{
    [System.Runtime.InteropServices.Guid("E82CD185-E958-43a9-B032-FFE433FCE324")]
    public class CustomService : SPIisWebService, IServiceAdministration
    {
        /// <summary>
        /// Internal use only.
        /// </summary>
        public CustomService() { }

        /// <summary>
        /// Creates a new service proxy.
        /// </summary>
        /// <param name="farm">The parent farm object.</param>
        public CustomService(SPFarm farm) : base(farm) { }

        #region IServiceAdministration Members
        public SPServiceApplication CreateApplication(string name, Type serviceApplicationType, SPServiceProvisioningContext provisioningContext)
        {
            #region validation
            if (provisioningContext == null)
                throw new ArgumentNullException("provisioningContext");
            if (serviceApplicationType != typeof(CustomServiceApplication))
                throw new NotSupportedException();
            #endregion

            // check to see if this service application already exists
            CustomServiceApplication application = 
                this.Farm.GetObject(
                    name,
                    this.Id,
                    serviceApplicationType) as CustomServiceApplication;

            if (application == null)
            {

                // Generate a unique database name based on the application name, using the default SQL Server
                SPDatabaseParameters databaseParameters = SPDatabaseParameters.CreateParameters(
                    name,
                    SPDatabaseParameterOptions.GenerateUniqueName);

                // Create the service application
                application = CustomServiceApplication.Create(
                    name,
                    this,
                    provisioningContext.IisWebServiceApplicationPool,
                    databaseParameters);
            }

            return application;
        }

        public SPServiceApplicationProxy CreateProxy(string name, SPServiceApplication serviceApplication, SPServiceProvisioningContext provisioningContext)
        {
            #region validation
            if (serviceApplication == null)
                throw new ArgumentNullException("serviceApplication");
            if (serviceApplication.GetType() != typeof(CustomServiceApplication))
                throw new NotSupportedException();

            // verify service proxy exists
            CustomServiceProxy serviceProxy = (CustomServiceProxy)this.Farm.GetObject(
                string.Empty,
                this.Farm.Id,
                typeof(CustomServiceProxy));
            if (serviceProxy == null)
                throw new InvalidOperationException("CustomServiceApplicationProxy does not exist in the farm");
            #endregion

            // if no app proxy exists, create it
            CustomServiceApplicationProxy appProxy = serviceProxy.ApplicationProxies.GetValue<CustomServiceApplicationProxy>(name);
            if (appProxy == null)
            {
                appProxy = new CustomServiceApplicationProxy(
                    name,
                    serviceProxy,
                    ((CustomServiceApplication)serviceApplication).Uri);
            }

            return appProxy;
        }

        /// <summary>
        /// Gets a description of the specified service application type.
        /// </summary>
        /// <param name="serviceApplicationType">The service application type.</param>
        /// <returns>A description of the specified type suitable for display.</returns>
        public SPPersistedTypeDescription GetApplicationTypeDescription(Type serviceApplicationType)
        {
            if (serviceApplicationType != typeof(CustomServiceApplication))
                throw new NotSupportedException();

            return new SPPersistedTypeDescription("Custom Service Application", "A custom service application sample by AC.");
        }

        /// <summary>
        /// Gets an array of the service application types supported by the service.
        /// </summary>
        /// <returns>An array of supported types.</returns>
        public Type[] GetApplicationTypes()
        {
            return new Type[] { typeof(CustomServiceApplication) };
        }

        /// <summary>
        /// Gets the link used to create a service application of a specified type.
        /// </summary>
        /// <param name="serviceApplicationType">The service application type.</param>
        /// <returns>The requested link.</returns>
        public override SPAdministrationLink GetCreateApplicationLink(Type serviceApplicationType)
        {
            return new SPAdministrationLink("/_admin/CreateCustomServiceApplication");
        }
        #endregion
    }
}