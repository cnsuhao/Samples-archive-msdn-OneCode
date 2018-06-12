/****************************** Module Header ******************************\
Module Name: CacheUtil.cs
Project:     RetryCacheRole
Copyright (c) Microsoft Corporation.

This module is used to get the DataCacheFactory object. 
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/


using System;
using Microsoft.ApplicationServer.Caching;
using System.Collections.Generic;
using System.Security;

/// <summary>
/// Summary description for Cache
/// </summary>
public class CacheUtil
{
    public static DataCache GetCacheConfig()
    {
        // Cache client configured by settings in application configuration file.
        DataCacheFactory cacheFactory = new DataCacheFactory();
        DataCache cache = cacheFactory.GetDefaultCache();

        return cache;
    }
}
