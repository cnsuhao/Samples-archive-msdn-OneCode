/****************************** Module Header ******************************\
 * Module Name:  LoadVisualStateManager.cs
 * Project:      CSWindowsStoreAppLoadVisualStateManager
 * Copyright (c) Microsoft Corporation.
 * 
 * This page used to load VisualStateManager and attach it to the page.
 *  
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

namespace CSWindowsStoreAppLoadVisualStateManager.VisualStateResources
{
    public static class LoadVisualStateManager
    {
        public static void AttachVisualStateGroups(Grid RootGrid, string VisualStateGroupKey = "ApplicationViewStates")
        {
            // Creates a VisualStateManager and attaches it to the RootGrid in GroupedItemsPage.xaml
            VisualStateManager manager = new VisualStateManager();
            VisualStateManager.SetCustomVisualStateManager(RootGrid, manager);

            // Gets a reference to the VisualStateGroup collection that now exists in the RootGrid (thanks to the above code)
            IList<VisualStateGroup> states = VisualStateManager.GetVisualStateGroups(RootGrid);

            // Dynamically loads the ResourceDictionary that contains the VisualState XAML
            ResourceDictionary loadedResource = GetVisualStateXaml();

            // Get the VisualStateGroup from Resource Dictionary
            VisualStateGroup vsgDynamic = loadedResource[VisualStateGroupKey] as VisualStateGroup;
            loadedResource.Clear();

            // Add the dynamically loaded VisualState into the RootGrid's VisualStateGroup's collection
            states.Add(vsgDynamic);
        }

        private static ResourceDictionary GetVisualStateXaml()
        {
            // Get the namespace for this class that lives in the same namespace location as the ResourceDictionary 
            var RunTimeNamespace = typeof(LoadVisualStateManager).GetTypeInfo().Namespace;

            // Load the resource dictionary into a stream
            string ResourceDictionaryFilename = "VisualStatePage.xaml";
            Stream resource = typeof(LoadVisualStateManager).GetTypeInfo()
                .Assembly.GetManifestResourceStream(RunTimeNamespace + "." + ResourceDictionaryFilename);

            // Create an instance of a ResourceDictionary from the resource Stream
            ResourceDictionary loadedResource =
                XamlReader.Load(new StreamReader(resource).ReadToEnd()) as ResourceDictionary;

            return loadedResource;
        }
    }
}
