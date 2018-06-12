/****************************** Module Header ******************************\
* Module Name:    CustomServiceApplication.cs
* Project:        CSSharePointCallClaimsAwareWCF
* Copyright (c) Microsoft Corporation
*
* This class is used to implement the Service interface and create ServiceApplication.
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
using System.Security.Principal;
using System.ServiceModel;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.AccessControl;
using Microsoft.SharePoint.Utilities;
using Microsoft.IdentityModel.Claims;

namespace CustomService
{
    [IisWebServiceApplicationBackupBehavior]
    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.PerSession,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        IncludeExceptionDetailInFaults = true,
        AddressFilterMode = AddressFilterMode.Any)
        ]
    [System.Runtime.InteropServices.Guid("A12A5C1C-9784-4118-BF9D-B58B24337E34")]
    public sealed class CustomServiceApplication : SPIisWebServiceApplication, ICustomServiceContract
    {
        [Persisted]
        private int _setting;

        [Persisted]
        private CustomServiceDatabase _database;

        #region constructors
        public CustomServiceApplication() { }

        private CustomServiceApplication(
            string name,
            CustomService service,
            SPIisWebServiceApplicationPool applicationPool,
            CustomServiceDatabase database)
            : base(name, service, applicationPool)
        {
            if (database == null)
                throw new ArgumentNullException("database");

            _database = database;
        }
        #endregion

        public static CustomServiceApplication Create(string name, CustomService service, SPIisWebServiceApplicationPool applicationPool, SPDatabaseParameters databaseParameters)
        {
            #region validation
            if (null == name)
                throw new ArgumentNullException("name");

            if (null == service)
                throw new ArgumentNullException("service");

            if (null == applicationPool)
                throw new ArgumentNullException("applicationPool");

            if (null == databaseParameters)
                throw new ArgumentNullException("databaseParameters");
            #endregion

            // Register the database
            CustomServiceDatabase database = new CustomServiceDatabase(databaseParameters);
            database.Update();

            // Create and persist the service application
            CustomServiceApplication serviceApplication = new CustomServiceApplication(
                name,
                service,
                applicationPool,
                database);
            serviceApplication.Update();

            // register supported endpoints
            serviceApplication.AddServiceEndpoint("tcp", SPIisWebServiceBindingType.NetTcp);
            serviceApplication.AddServiceEndpoint("tcp-ssl", SPIisWebServiceBindingType.NetTcp, "secure");
            serviceApplication.AddServiceEndpoint("http", SPIisWebServiceBindingType.Http);
            serviceApplication.AddServiceEndpoint("https", SPIisWebServiceBindingType.Https, "secure");

            return serviceApplication;
        }

        #region Required serice app details...
        protected override string DefaultEndpointName
        {
            get { return "http"; }
        }

        public override string TypeName
        {
            get { return "Custom Service Application"; }
        }

        // The InstallPath property tells SharePoint where to find our service files
        protected override string InstallPath
        {
            get { return SPUtility.GetGenericSetupPath(@"WebServices\CustomService"); }
        }

        // The VirtualPath property tells SharePoint the URI of your service endpoint relative to the InstallPath directory, in this case, “CustomService.svc? 
        protected override string VirtualPath
        {
            get { return "CustomService.svc"; }
        }

        public override Guid ApplicationClassId
        {
            get { return new Guid("A12A5C1C-9784-4118-BF9D-B58B24337E34"); }
        }

        public override Version ApplicationVersion
        {
            get { return new Version("1.0.0.0"); }
        }
        #endregion

        /// <summary>
        /// Setting persisted in configuration database.
        /// </summary>
        public int Setting
        {
            get { return _setting; }

            // NOTE: Since this method requires an access check, it must impersonate the client.
            [OperationBehavior(Impersonation = ImpersonationOption.Required)]
            set
            {
                // Demand the "Write" custom administration right
                DemandAdministrationAccess(CustomServiceCentralAdministrationRights.Write);

                _setting = value;
            }
        }

        public override void Provision()
        {
            _database.Provision();
            base.Provision();
        }

        public override void Unprovision(bool deleteData)
        {
            base.Unprovision(deleteData);
            _database.Unprovision();
        }

        protected override void OnProcessIdentityChanged(SecurityIdentifier processSecurityIdentifier)
        {
            base.OnProcessIdentityChanged(processSecurityIdentifier);
            _database.GrantApplicationPoolAccess(processSecurityIdentifier);
        }

        /// <summary>
        /// Target location admin is sent to from within CA when clicking on Service App or 
        /// selecting it and picking Manage in the ribbon from CA > Manage Service Apps page.
        /// </summary>
        public override SPAdministrationLink ManageLink
        {
            get { return new SPAdministrationLink("/_admin/ManageSample?id=" + this.Id.ToString()); }
        }

        /// <summary>
        /// Target location admin is sent to from within CA when selecting the service all
        /// and picking Properties in the ribbon from CA > Manage Service Apps page.
        /// </summary>
        public override SPAdministrationLink PropertiesLink
        {
            get { return new SPAdministrationLink("/_admin/EditSample?id=" + this.Id.ToString()); }
        }

        #region Custom Permissions & Access Rights
        /// <summary>
        /// Override the default named administration access rights to include custom rights.
        /// These options will show in the CA > Manage Service Apps > [select service app] > Administrators
        /// </summary>
        /// <remarks>The returned items will be used for display in the ACL editor UI 
        /// control and the PowerShell Grant and Revoke Cmdlets.</remarks>
        protected override SPNamedCentralAdministrationRights[] AdministrationAccessRights
        {
            get
            {
                return new SPNamedCentralAdministrationRights[]
                {
                    SPNamedCentralAdministrationRights.FullControl,
                    new SPNamedCentralAdministrationRights("Modify", SPCentralAdministrationRights.Read | CustomServiceCentralAdministrationRights.Write),
                    SPNamedCentralAdministrationRights.Read,
                };
            }
        }

        /// <summary>
        /// Override the default access rights to include custom rights.
        /// These optiosn will show in the CA > Manage Service Apps > [select service app] > Permissions
        /// </summary>
        /// <remarks>These can be used to ensure the caller has specific rights granted to it, and enforced in 
        /// the caller below using the DemandAccess() method.</remarks>
        protected override SPNamedIisWebServiceApplicationRights[] AccessRights
        {
            get
            {
                return new SPNamedIisWebServiceApplicationRights[]{
                    SPNamedIisWebServiceApplicationRights.FullControl, 
                    new SPNamedIisWebServiceApplicationRights("Add", CustomServiceAccessRights.Add),
                    new SPNamedIisWebServiceApplicationRights("Subtract", CustomServiceAccessRights.Subtract),
                    SPNamedIisWebServiceApplicationRights.Read
                };
            }
        }
        #endregion

        #region All the methods that do the work within the service application. {ISampleWebServiceContract Members}
        public int Add(int a, int b)
        {
            DemandAccess(CustomServiceAccessRights.Add);
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            DemandAccess(CustomServiceAccessRights.Subtract);
            return a - b;
        }

        public string HelloWorld()
        {
            DemandAccess(CustomServiceAccessRights.Hello);
            string id = GetIdentityClass.GetIdentity();           

            return "Hello World from WCF and SharePoint 2010; GetIdentity" + id;
        }   
    
        #endregion
    }
}