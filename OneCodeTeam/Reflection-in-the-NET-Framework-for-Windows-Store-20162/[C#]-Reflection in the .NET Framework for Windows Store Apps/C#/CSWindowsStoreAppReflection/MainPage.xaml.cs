/****************************** Module Header ******************************\
* Module Name:  MainPage.cs
* Project:	    CSWindowsStoreAppReflection
* Copyright (c) Microsoft Corporation.
* 
* The main UI of this app.
* 
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Linq;
using System.Reflection;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CSWindowsStoreAppReflection
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Common.LayoutAwarePage
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            // Get current assembly.
            Assembly asm = typeof(MainPage).GetTypeInfo().Assembly;

            // Bind all classes under CSWindowsStoreAppReflection.Types to typeCombobox
            typeCombobox.ItemsSource = asm.DefinedTypes
                .Where(t=>t.IsClass && t.Namespace=="CSWindowsStoreAppReflection.Types");

            // Bind all interfaces under CSWindowsStoreAppReflection.Types to interfaceCombobox
            interfaceCombobox.ItemsSource = asm.DefinedTypes
                .Where(t => t.IsInterface && t.Namespace == "CSWindowsStoreAppReflection.Types");

        }

        private void typeCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && (sender as ComboBox).SelectedItem is TypeInfo)
            {

                // Get the selected type.
                TypeInfo selectedType = (sender as ComboBox).SelectedItem as TypeInfo;

                // Find all the derived classes of the selected type.
                Assembly asm = typeof(MainPage).GetTypeInfo().Assembly;
                var subTypes = asm.DefinedTypes
                    .Where(t => t.IsClass && t.IsSubclassOf(selectedType.AsType()));

                StringBuilder result = new StringBuilder();

                if (subTypes == null || subTypes.Count() == 0)
                {
                    result.Append("There is no class that inherits " + selectedType.FullName);
                }
                else
                {
                    result.AppendLine("The following classes inherit from" + selectedType.FullName);
                    result.AppendLine();

                    foreach (var subType in subTypes)
                    {
                        result.AppendLine(subType.FullName);
                    }
                }

                typeResultText.Text = result.ToString();
            }
        }

        private void interfaceCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && (sender as ComboBox).SelectedItem is TypeInfo)
            {

                // Get the selected interface.
                TypeInfo selectedInterface = (sender as ComboBox).SelectedItem as TypeInfo;

                // Get all classes that implement the selected interface 
                Assembly asm = typeof(MainPage).GetTypeInfo().Assembly;
                var subTypes = asm.DefinedTypes
                    .Where(t => t.IsClass && t.ImplementedInterfaces.Any(i=> i ==selectedInterface.AsType()));

                StringBuilder result = new StringBuilder();

                if (subTypes == null || subTypes.Count() == 0)
                {
                    result.Append("There is no class that implements " + selectedInterface.FullName);
                }
                else
                {
                    result.AppendLine("The following classes implement " + selectedInterface.FullName);
                    result.AppendLine();

                    foreach (var subType in subTypes)
                    {
                        result.AppendLine(subType.FullName);
                    }
                }

                interfaceResultText.Text = result.ToString();
            }
        }


        #region Common methods

        async private void Footer_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri((sender as HyperlinkButton).Tag.ToString()));
        }

        public void NotifyUser(string message)
        {
            textStatus.Text = message;
        }

        #endregion
    }
}
