/****************************** Module Header ******************************\
 * Module Name:  Helper.cs
 * Project:      Common
 * Copyright (c) Microsoft Corporation.
 * 
 * Helper class try to get collection uri from either the input or the environment variable. 
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

namespace Common
{
    using System;

    public static class Helper
    {
        #region Methods

        public static Uri GetCollectionUri(string[] args)
        {
            String collectionUri;
            
            if ((args.Length > 0) && (!String.IsNullOrEmpty(args[0])) && 
                Uri.IsWellFormedUriString(args[0], UriKind.Absolute))
            {
                collectionUri = args[0];               
            }
            else
            {
                collectionUri = Environment.GetEnvironmentVariable("TFS_COLLECTION_URI");
            }

            while (String.IsNullOrEmpty(collectionUri))
            {
                Console.WriteLine(
                    "Please enter your TFS Team Project Collection URI,\n" +
                    "or you can set it in TFS_COLLECTION_URI environment variable:");

                collectionUri = Console.ReadLine();

                if (!Uri.IsWellFormedUriString(collectionUri, UriKind.Absolute))
                {
                    collectionUri = null;
                }
            }

            return new Uri(collectionUri);
        }

        #endregion Methods
    }
}