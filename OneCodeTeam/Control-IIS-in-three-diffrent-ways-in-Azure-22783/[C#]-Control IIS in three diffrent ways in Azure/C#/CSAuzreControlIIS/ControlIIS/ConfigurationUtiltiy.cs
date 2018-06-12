/****************************** Module Header ******************************\
Module Name:  ConfigurationUtiltiy.cs
Project:     ControlIIS
Copyright (c) Microsoft Corporation.
 
As we know, cloud service can full control IIS. If someone want to change IIS, 
they will probably first think about using startup script, since it has been 
documented in Azure training kit.
That's a good way but not the only way.
Actually we can use site class and Configuration config to achieve that.
This sample will show you how can we control IIS by two different ways in Azure
Cloud service.

Use this method to configure specific xml file.
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlIIS
{
    public static class ConfigurationUtiltiy
    {
        
        public static ConfigurationElement FindElement(ConfigurationElementCollection collection, string elementTagName, params string[] keyValues)
        {
            foreach (ConfigurationElement element in collection)
            {
                if (String.Equals(element.ElementTagName, elementTagName, StringComparison.OrdinalIgnoreCase))
                {
                    bool matches = true;

                    for (int i = 0; i < keyValues.Length; i += 2)
                    {
                        object o = element.GetAttributeValue(keyValues[i]);
                        string value = null;
                        if (o != null)
                        {
                            value = o.ToString();
                        }

                        if (!String.Equals(value, keyValues[i + 1], StringComparison.OrdinalIgnoreCase))
                        {
                            matches = false;
                            break;
                        }
                    }
                    if (matches)
                    {
                        return element;
                    }
                }
            }
            return null;
        }
    }
}