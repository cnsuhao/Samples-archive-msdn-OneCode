/****************************** Module Header ******************************\
Module Name:  FileManagerModuler.cs
Project:      ServeFilesFromBlobStorageWebRole
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates a way to serve files from storage via a web role.
A file from blob storage(such as http://xxx.cloudapp.net/files/File1) can be
reached as the normal files in your application by relative path ("files/File1").
And this http module can also filter some specify types files.

This HttpModuler runs before HttpHandler and can check the type of each requests,
in this sample, you can access .aspx, .jpg and .css files, other request will be 
thrown into NoHandler.aspx page. If you want to add more types, please try to add
them into GetContentType method.

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
using TableStorageManager;

namespace ServeFilesFromBlobStorageWebRole
{
    public class FileManagerModuler: IHttpModule
    {
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {           
            context.BeginRequest += new EventHandler(this.Application_BeginRequest);
        }

        /// <summary>
        /// Check file types and request it by cloud blob API.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void Application_BeginRequest(Object source,EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.ToString();
            string fileName = url.Substring(url.LastIndexOf('/') + 1).ToString();
            string extensionName = string.Empty;
            if (fileName.Substring(fileName.LastIndexOf('.') + 1).ToString().Equals("aspx"))
            {
                return;
            }

            if (!fileName.Equals(string.Empty))
            {
                extensionName = fileName.Substring(fileName.LastIndexOf('.') + 1).ToString();
                if (!extensionName.Equals(string.Empty))
                {
                    string contentType = this.GetContentType(fileName);
                    if (contentType.Equals(string.Empty))
                    {
                        HttpContext.Current.Server.Transfer("NoHandler.aspx");
                    };
                    {
                        FileDataSource dataSource = new FileDataSource();
                        string paritionKey = this.GetPartitionName(extensionName);
                        if (String.IsNullOrEmpty(paritionKey))
                        {
                            HttpContext.Current.Server.Transfer("NoHandler.aspx");
                        }
                        FileEntity entity = dataSource.GetEntitiesByName(paritionKey, "Files/" + fileName);
                        if (entity != null)
                            HttpContext.Current.Response.Redirect(entity.FileUrl);
                        else
                            HttpContext.Current.Server.Transfer("NoResources.aspx");
                    }
                }
            }
        }

        /// <summary>
        /// Get file's Content-Type.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public string GetContentType(string filename)
        {
            string res = string.Empty;

            switch (filename.Substring(filename.LastIndexOf('.') + 1).ToString().ToLower())
            {
                case "jpg":
                    res = "image/jpg";
                    break;
                case "css":
                    res = "text/css";
                    break;
            }

            return res;
        }

        /// <summary>
        /// Get file's partitionKey.
        /// </summary>
        /// <param name="extensionName"></param>
        /// <returns></returns>
        public string GetPartitionName(string extensionName)
        {
            string partitionName = string.Empty;
            switch(extensionName)
            {
                case "jpg":
                    partitionName = "image";
                    break;
                case "css":
                    partitionName = "css";
                    break;
            }
            return partitionName;
        }
    }
}