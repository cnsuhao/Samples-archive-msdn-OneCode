'****************************** Module Header ******************************\
'Module Name: CacheUtil.vb
'Project:     RetryCacheRole
'Copyright (c) Microsoft Corporation.
'
'This module is used to get the DataCacheFactory object. 
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports Microsoft.ApplicationServer.Caching

Public Class CacheUtil
    Public Shared Function GetCacheConfig() As DataCache
        ' Cache client configured by settings in application configuration file.
        Dim cacheFactory As New DataCacheFactory()
        Dim cache As DataCache = cacheFactory.GetDefaultCache()

        Return cache
    End Function
End Class
