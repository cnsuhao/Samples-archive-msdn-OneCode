/****************************** Module Header ******************************\
Module Name:  MainPage.xaml.cs
Project:      CSWP7SecondaryTile
Copyright (c) Microsoft Corporation.

This example illustrates basic usage of MediaElement.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace CSWP7SecondaryTile
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (this.NavigationContext.QueryString.ContainsKey("Param"))
            {
                string param = this.NavigationContext.QueryString["Param"];//Get "Param" this query string.
                textBlock1.Text = "Welcome back from " + param;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string tileParameter = "Param=" + ((Button)sender).Name;
            ShellTile tile = CheckIfTileExist(tileParameter);
            if (tile == null)
            {
                StandardTileData secondaryTile = new StandardTileData
                {
                    Title = tileParameter,
                    BackgroundImage = new Uri("Background-Secondary.png", UriKind.Relative),
                    Count = 2,
                    BackContent = "Secondary Tile Test"

                };
                ShellTile.Create(new Uri("/MainPage.xaml?" + tileParameter, UriKind.Relative), secondaryTile);
            }
        }

        private ShellTile CheckIfTileExist(string tileUri)
        {
            ShellTile shellTile = ShellTile.ActiveTiles.FirstOrDefault(
                    tile => tile.NavigationUri.ToString().Contains(tileUri));
            return shellTile;
        }

    }
}