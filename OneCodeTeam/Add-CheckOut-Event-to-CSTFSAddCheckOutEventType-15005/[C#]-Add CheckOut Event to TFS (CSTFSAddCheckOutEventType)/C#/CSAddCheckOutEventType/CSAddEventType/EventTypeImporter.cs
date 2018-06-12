/****************************** Module Header ******************************\
 * Module Name:   EventTypeImporter.cs
 * Project:       CSAddEventType
 * Copyright (c) Microsoft Corporation.
 * 
 * This class uses TFS Server Object Model to add an EventType.
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.Framework.Server;

namespace CSAddEventType
{
    public class EventTypeImporter:IDisposable
    {
        // The ApplicationServiceHost.
        private ApplicationServiceHost applicationHost;

        // The CollectionServiceHost.
        private CollectionServiceHost collectionHost;

        private bool disposed;

        /// <summary>
        /// Initialize the EventTypeImporter instance using the parameters.
        /// </summary>
        public EventTypeImporter(
            string applicationDatabaseConnectionString,
            string toolPath,
            string collectionName)
        {
            InitializeAppHost(applicationDatabaseConnectionString, toolPath);
            InitializeCollectionHost(collectionName);
        }

        /// <summary>
        ///  Initialize the EventTypeImporter instance using the values in app.config.
        /// </summary>
        public EventTypeImporter(string collectionName)
        {
            InitializeAppHost(ConfigurationManager.AppSettings["applicationDatabase"],
                ConfigurationManager.AppSettings["ToolsPath"]);
            InitializeCollectionHost(collectionName);
        }

        #region Initialize AppHost and CollectionHost
        
        /// <summary>
        /// Initialize AppHost using its constructor.
        /// </summary>
        private void InitializeAppHost(string applicationDatabaseConnectionString,
            string toolPath)
        {
            if (string.IsNullOrEmpty(applicationDatabaseConnectionString)
                || string.IsNullOrEmpty(toolPath))
            {
                throw new ArgumentException("applicationDatabase or toolPah should not be null.");
            }

            this.applicationHost = new ApplicationServiceHost(
                Guid.Empty,
                applicationDatabaseConnectionString,
                "unused",
                Path.Combine(toolPath, "Plugins"),
                "/tfs",
                true);
        }

        /// <summary>
        /// Get CollectionHost using TeamProjectCollectionService.
        /// </summary>
        private void InitializeCollectionHost(string collectionName)
        {
            if (this.applicationHost == null)
            {
                throw new ApplicationException("AppHost is null.");
            }

            // Generate a SystemContext.
            TeamFoundationRequestContext systemRequest = applicationHost.CreateSystemContext();

            Guid collectionId = Guid.Empty;

            // Get TeamProjectCollectionService using the SystemContext.
            TeamProjectCollectionService tpcService = systemRequest.GetService<TeamProjectCollectionService>();
            
            // Query the properties to find the GUID of the specified collection.
            List<TeamProjectCollectionProperties> collectionProperties =
                tpcService.GetCollectionProperties(systemRequest, ServiceHostFilterFlags.None);

            foreach (TeamProjectCollectionProperties properties in collectionProperties)
            {
                if (string.Equals(properties.Name, collectionName, StringComparison.OrdinalIgnoreCase)
                    && properties.State == TeamFoundationServiceHostStatus.Started)
                {
                    collectionId = properties.Id;
                }
            }

            if (collectionId == Guid.Empty)
            {
                throw new ApplicationException("Cannot find the collection :" + collectionName);
            }

            this.collectionHost = applicationHost.GetServiceHost(collectionId) as CollectionServiceHost;
            
        }

        #endregion


        #region IDisposable Interface

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Protect from being called multiple times.
            if (disposed) return;

            if (disposing)
            {
                // Clean up all managed resources.
                if (this.collectionHost != null)
                {
                    this.collectionHost.Dispose();                   
                }
                if (this.applicationHost != null)
                {
                    this.applicationHost.Dispose();
                }
            }

            disposed = true;
        }

        #endregion

        /// <summary>
        /// Add an EventTYpe using TeamFoundationNotificationService.
        /// </summary>
        /// <param name="schema"></param>
        public void AddEventType(string name, string toolType, string schema)
        {
            // Generate a SystemContext.
            TeamFoundationRequestContext systemRequest =  this.collectionHost.CreateSystemContext();

            // Get TeamFoundationNotificationService using the SystemContext.
            TeamFoundationNotificationService notificationService = 
                systemRequest.GetService<TeamFoundationNotificationService>();

            RegistrationEventType eventType = new RegistrationEventType(name, schema);

            notificationService.AddEventTypes(systemRequest, toolType,
                new RegistrationEventType[] { eventType });
        }

    }
}
