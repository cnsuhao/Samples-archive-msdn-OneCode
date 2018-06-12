/****************************** Module Header ******************************\
Module Name:  DefaultSettingsProvider.cs
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
using System.Collections.Generic;
using CSWinformTFSTreeView.Properties;
using Microsoft.TeamFoundation.Client;

namespace CSWinformTFSTreeView
{
    /// <summary>
    /// Provide default selection to the tfs connection dialog.
    /// </summary>
    internal class DefaultSettingsProvider : ITeamProjectPickerDefaultSelectionProvider
    {
        /// <summary>
        /// Return the default collection id from the default settings.
        /// </summary>
        /// <param name="instanceUri"></param>
        /// <returns></returns>
        public Guid? GetDefaultCollectionId(Uri instanceUri)
        {
            return Settings.Default.DefaultCollectionId;
        }

        /// <summary>
        /// Always return null
        /// </summary>
        /// <param name="collectionId"></param>
        /// <returns></returns>
        public IEnumerable<string> GetDefaultProjects(Guid collectionId)
        {
            return null;
        }

        /// <summary>
        /// Return the default server Uri from the default settings.
        /// </summary>
        /// <returns></returns>
        public Uri GetDefaultServerUri()
        {
            string defaultUriString = Settings.Default.DefaultServerUri;

            return Uri.IsWellFormedUriString(defaultUriString, UriKind.Absolute) ? new Uri(defaultUriString) : null;
        }

        /// <summary>
        /// Save settings into the default settings.
        /// </summary>
        /// <param name="collection"></param>
        public static void SaveSettings(TfsTeamProjectCollection collection)
        {
            Settings.Default.DefaultServerUri = collection.ConfigurationServer.Uri.AbsoluteUri;
            Settings.Default.DefaultCollectionId = collection.InstanceId;
            Settings.Default.Save();
        }
    }
}
