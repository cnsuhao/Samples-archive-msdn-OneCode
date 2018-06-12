/****************************** Module Header ******************************\
 * Module Name:  WMIObjectFactory.cs
 * Project:      CSMACAddress
 * Copyright (c) Microsoft Corporation.
 *
 * The class is used to initialize a .NET class object from a WMI object.
 * 
 * The .NET class must have the WMIClassAttribute which has the same ClassName
 * as the WMI object. Then get the properties of the WMI object and use reflection 
 * to set the value of the .NET class object properties.
 * 
 * 
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Linq;
using System.Management;

namespace CSMACAddress.WMIHelper
{
    internal class WMIObjectFactory
    {

        /// <summary>
        /// Initialize a .NET class object from a ManagementObject
        /// </summary>
        /// <param name="t">
        /// The .NET type.
        /// </param>
        /// <param name="scope">
        /// The scope contains the ConnectionOptions, which includes the credential.
        /// </param>
        /// <returns></returns>
        public static object GetInstance(ManagementBaseObject wmiObject, Type t,
            ManagementScope scope)
        {
            object instance = null;

            try
            {

                // The .NET type must have the WMIClassAttribute.
                if (t.GetCustomAttributes(typeof(WMIClassAttribute), true).Count() > 0)
                {
                    WMIClassAttribute classAttribute =
                        t.GetCustomAttributes(typeof(WMIClassAttribute), true).First()
                        as WMIClassAttribute;

                    // Check whether the ClassName property of the WMIClassAttribute is the 
                    // same as the WMI object.
                    if (classAttribute.ClassName.Equals(wmiObject.ClassPath.ClassName))
                    {

                        // Get the default constructor of the .NET type.
                        var ctor = t.GetConstructor(Type.EmptyTypes);

                        // Invoke the constructor to create an instance. 
                        instance = ctor.Invoke(null);

                        if (instance != null)
                        {

                            // Use reflection to set the value of the .NET type object
                            // properties. 
                            SetInstancePropertiesValue(t, instance, wmiObject, scope);

                        }
                    }
                }
                return instance;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Use reflection to set the value of the .NET class object properties.
        /// </summary>
        /// <param name="t">The .NET type.</param>
        /// <param name="instance">The .NET object.</param>
        /// <param name="wmiObject">The WMI object.</param>
        /// <param name="scope">
        /// The scope contains the ConnectionOptions, which includes the credential.
        /// In sometime, the WMI object may refer to another WMI object, and we have 
        /// to use the scope to get the referred object.
        /// </param>
        static void SetInstancePropertiesValue(Type t, object instance,
            ManagementBaseObject wmiObject, ManagementScope scope)
        {
            foreach (var property in t.GetProperties())
            {

                // The property must have the WMIPropertyAttribute.
                if (property.GetCustomAttributes(typeof(WMIPropertyAttribute), true).Count() > 0)
                {
                    WMIPropertyAttribute wmiPropertyAttribute =
                        property.GetCustomAttributes(typeof(WMIPropertyAttribute), true).First() as WMIPropertyAttribute;

                    // Get the related property name of the WMI object.
                    string propertyName = string.IsNullOrEmpty(wmiPropertyAttribute.PropertyName)
                        ? property.Name : wmiPropertyAttribute.PropertyName;

                    // Get the property value of the WMI object.
                    // The type of the WMI object property value may be not the same as the 
                    // .NET type. For example, date time or the referred WMI object.
                    object value = wmiObject.Properties[propertyName].Value;

                    if (value == null)
                    {
                        if (!property.PropertyType.IsValueType)
                        {
                            property.SetValue(instance, null, null);
                        }
                        continue;
                    }

                    // Convert the type of the the property value of the WMI object.
                    object propertyValue = null;

                    switch (wmiPropertyAttribute.PropertyType)
                    {

                        // The WMI object refers to another WMI object.
                        // It may refer to the object directly, or just contain the path
                        // of another object.
                        case WMIPropertyType.WMIObject:

                            if (value is ManagementBaseObject)
                            {
                                propertyValue = GetInstance(
                                    value as ManagementBaseObject,
                                    wmiPropertyAttribute.AssociatedWMIClass,
                                    scope);
                            }
                            else if (value is string)
                            {
                                ManagementBaseObject obj = null;
                                try
                                {
                                    ManagementPath path = new ManagementPath(value as string);

                                    if (scope != null)
                                    {
                                        obj = new ManagementObject(
                                            scope, path, new ObjectGetOptions());
                                    }
                                    else
                                    {
                                        obj = new ManagementObject(path);
                                    }
                                    propertyValue = GetInstance(
                                       obj,
                                       wmiPropertyAttribute.AssociatedWMIClass,
                                       scope);
                                }
                                catch
                                {
                                    propertyValue = null;
                                }
                                finally
                                {
                                    if (obj != null)
                                    {
                                        obj.Dispose();
                                    }
                                }
                            }
                            else
                            {
                                propertyValue = null;
                            }
                            break;
                        case WMIPropertyType.DateTime:
                            if (value is string)
                            {
                                propertyValue = ManagementDateTimeConverter.ToDateTime(
                                    value as string);
                            }
                            break;
                        default:
                            propertyValue = value;
                            break;
                    }

                    if (propertyValue != null)
                    {
                        property.SetValue(instance, propertyValue, null);
                    }
                }
            }
        }
    }
}
