using System;
/****************************** Module Header ******************************\
* Module Name: CustomFile.cs
* Project:     CSASPNETAccessResourceInAssembly
* Copyright (c) Microsoft Corporation
*
* This project illustrates how to access user controls and web pages from class
* library via virtual path. Here we inherit VirtualPathProvider and VirtualFile 
* class for creating a custom path provider. In CSASPNETAccessResourceAssembly,
* we can load embed resource files use specify virtual path in assembly.
* 
* This class inherits VirtualFile class and override Open method for loading
* assembly files.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/



using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Hosting;
using System.Reflection;
using System.IO;

namespace CSASPNETAccessResourceInAssembly
{
    public class CustomFile:VirtualFile
    {
        string path
        {
            get;
            set;
        }

        public CustomFile(string virtualPath)
            : base(virtualPath)
        {
            path = VirtualPathUtility.ToAppRelative(virtualPath);
        }

        /// <summary>
        /// Override Open method to load resource files of assembly.
        /// </summary>
        /// <returns></returns>
        public override System.IO.Stream Open()
        {
            string[] strs = path.Split('/');
            string name = strs[2];
            string resourceName = strs[3];
            name = Path.Combine(HttpRuntime.BinDirectory, name);
            Assembly assembly = Assembly.LoadFile(name);
            if (assembly != null)
            {
                Stream s = assembly.GetManifestResourceStream(resourceName);
                return s;
            }
            else
            {
                return null;
            }
        }
    }
}
