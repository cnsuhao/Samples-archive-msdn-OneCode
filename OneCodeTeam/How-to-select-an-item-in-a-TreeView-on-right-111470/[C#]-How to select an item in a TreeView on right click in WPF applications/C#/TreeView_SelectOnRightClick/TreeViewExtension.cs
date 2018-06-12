
/****************************** Module Header ******************************\
Module Name:  TreeViewExtension.cs
Project:      TreeView_SelectOnRightClick
Copyright (c) Microsoft Corporation.

TreeViewExtension is a class to represent an attached property for TreeView to enable selection on Right click.
This helps us to have a common code which can be used in any TreeView we create in the application.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TreeView_SelectOnRightClick
{
    /// <summary>
    /// Class which acts as an extension for TreeView to enable selection on right click.
    /// </summary>
    public static class TreeViewExtension
    {
        /// <summary>
        /// Property for user to set if selection on right click should be enabled or disabled.
        /// </summary>
        public static readonly DependencyProperty SelectItemOnRightClickProperty = DependencyProperty.RegisterAttached(
            "SelectItemOnRight",
            typeof(bool),
            typeof(TreeViewExtension),
            new UIPropertyMetadata(false, OnSelectItemOnRightClickChanged));

        public static bool GetSelectItemOnRightClick(DependencyObject d)
        {
            return (bool)d.GetValue(SelectItemOnRightClickProperty);
        }

        public static void SetSelectItemOnRightClick(DependencyObject d, bool value)
        {
            d.SetValue(SelectItemOnRightClickProperty, value);
        }

        private static void OnSelectItemOnRightClickChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            bool selectItemOnRightClick = (bool)e.NewValue;

            TreeView treeView = d as TreeView;
            if (treeView != null)
            {
                if (selectItemOnRightClick)
                {
                    treeView.PreviewMouseRightButtonDown += treeView_PreviewMouseRightButtonDown;
                }
                else
                {
                    treeView.PreviewMouseRightButtonDown -= treeView_PreviewMouseRightButtonDown;
                }
            }
        }

        static void treeView_PreviewMouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TreeViewItem treeViewItem = VisualSearch(e.OriginalSource as DependencyObject);

            if (treeViewItem != null)
            {
                treeViewItem.Focus();
                e.Handled = true;
            }
        }

        static TreeViewItem VisualSearch(DependencyObject source)
        {
            while (source != null && !(source is TreeViewItem))
                source = VisualTreeHelper.GetParent(source);

            return source as TreeViewItem;
        }
    }
}
