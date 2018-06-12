/****************************** Module Header ******************************\
Module Name:  TFSContext.cs
Project:      CSWinformTFSTreeView
Copyright (c) Microsoft Corporation.

TFS Context class to deal with tfs connection, tfs operations.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Net;
using Microsoft.OneCode.Utilities;
using Microsoft.TeamFoundation;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;

namespace CSWinformTFSTreeView
{
    /// <summary>
    /// TFS Context class
    /// </summary>
    internal class TfsContext
    {
        #region Constructors

        /// <summary>
        /// Initialize TFSContext
        /// </summary>
        /// <param name="tfsCollectionUri"></param>
        /// <param name="rootName">root Project collection name</param>
        public TfsContext(Uri tfsCollectionUri, string rootName)
        {
            TeamFoundationServerCollectionUri = tfsCollectionUri;
            RootName = rootName;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Root Project Collection Name
        /// </summary>
        public string RootName
        {
            get;
            private set;
        }

        /// <summary>
        /// Complete TFS Uri per other TFS properties.
        /// </summary>
        public Uri TeamFoundationServerCollectionUri
        {
            get;
            private set;
        }

        /// <summary>
        /// VersionControlServer service
        /// </summary>
        public VersionControlServer TfsVersionControlServer
        {
            get;
            private set;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Create connection to tfs Version Control Service
        /// </summary>
        /// <returns>If connection created successfully, return true</returns>
        public bool Connect()
        {
            try
            {
                var tpc = new TfsTeamProjectCollection(TeamFoundationServerCollectionUri);
                TfsVersionControlServer = tpc.GetService<VersionControlServer>();

                // connect to the service at connection time.
                return GetChildLevelTfsVcsItems("$/") != null;
            }
            catch (TeamFoundationServiceUnavailableException tfsUnavailableException)
            {
                CommonUtilities.ShowWarning(tfsUnavailableException.Message);
            }
            catch (TeamFoundationServerUnauthorizedException tfsUnauthorizedException)
            {
                CommonUtilities.ShowError(tfsUnauthorizedException.Message);
            }
            catch (TeamFoundationInvalidServerNameException tfInvalidServerNameException)
            {
                CommonUtilities.ShowError(tfInvalidServerNameException.Message);
            }
            catch (TeamFoundationServerInvalidResponseException tfsInvalidResponseException)
            {
                CommonUtilities.ShowError(tfsInvalidResponseException.Message);
            }
            catch (System.Security.SecurityException secException)
            {
                CommonUtilities.ShowError(secException.Message);
            }
            catch (WebException webException)
            {
                CommonUtilities.ShowError(webException.Message);
            }

            return false;
        }

        /// <summary>
        /// Get the TFS Version Control Server children items of the ServerNodePath
        /// </summary>
        /// <param name="serverNodePath">
        /// The server node path, for example, "$/WorkSpace/ServerItems.cs"
        /// </param>
        /// <returns>
        /// The collection of children tfs version control server items
        /// </returns>
        public ItemSet GetChildLevelTfsVcsItems(string serverNodePath)
        {
            try
            {
                return TfsVersionControlServer.GetItems(serverNodePath, 
                    RecursionType.OneLevel);
            }
            catch (TeamFoundationServiceUnavailableException tfsUnavailableException)
            {
                CommonUtilities.ShowWarning(tfsUnavailableException.Message);
            }
            catch (TeamFoundationServerUnauthorizedException tfsUnauthorizedException)
            {
                CommonUtilities.ShowError(tfsUnauthorizedException.Message);
            }
            catch (TeamFoundationInvalidServerNameException tfInvalidServerNameException)
            {
                CommonUtilities.ShowError(tfInvalidServerNameException.Message);
            }
            catch (TeamFoundationServerInvalidResponseException tfsInvalidResponseException)
            {
                CommonUtilities.ShowError(tfsInvalidResponseException.Message);
            }
            catch (System.Security.SecurityException secException)
            {
                CommonUtilities.ShowError(secException.Message);
            }
            catch (WebException webException)
            {
                CommonUtilities.ShowError(webException.Message);
            }

            return null;
        } 

        #endregion
    }
}
