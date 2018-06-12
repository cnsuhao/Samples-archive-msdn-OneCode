/****************************** Module Header ******************************\
* Module Name: CustomPathProvider.cs
* Project:     CSASPNETAccessResourceInAssembly
* Copyright (c) Microsoft Corporation
*
* This project illustrates how to access user controls and web pages from class
* library via virtual path. Here we inherit VirtualPathProvider and VirtualFile 
* class for creating a custom path provider. In CSASPNETAccessResourceAssembly,
* we can load embed resource files using specified virtual path in assembly.
* 
* This class inherits VirtualPathProvider class for creating a custom path
* provider, here we need override FileExists, GetFile, GetCacheDependency methods.
* The application will invoke CustomFile.Open method when it finds the specifical
* folder name.
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
using System.Web;
using System.Web.Hosting;
using System.Web.Caching;
using System.Collections;

namespace CSASPNETAccessResourceInAssembly
{
    public class CustomPathProvider : VirtualPathProvider
    {
        /// <summary>
        /// Make a judgment that application find path contains specifical folder name.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool AssemblyPathExist(string path)
        {
            string relateivePath = VirtualPathUtility.ToAppRelative(path);
            return relateivePath.StartsWith("~/Assembly/", StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// If we can find this virtual path, return true.
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <returns></returns>
        public override bool FileExists(string virtualPath)
        {
            if (this.AssemblyPathExist(virtualPath))
            {
                return true;
            }
            else
            {
                return base.FileExists(virtualPath);
            }
        }

        /// <summary>
        /// Use custom VirtualFile class to load assembly resources.
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <returns></returns>
        public override VirtualFile GetFile(string virtualPath)
        {
            if (AssemblyPathExist(virtualPath))
            {
                return new CustomFile(virtualPath);
            }
            else
            {
                return base.GetFile(virtualPath);
            }
        }

        /// <summary>
        /// Return null when application use virtual file path.
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <param name="virtualPathDependencies"></param>
        /// <param name="utcStart"></param>
        /// <returns></returns>
        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            if (AssemblyPathExist(virtualPath))
            {
                return null;
            }
            else
            {
                return base.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
            }
        }
    }

}
