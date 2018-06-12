using System;
using System.Windows;
using Microsoft.WindowsAzure.MobileServices;
using System.Net.Http;
using System.Collections.Generic;

namespace WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MobileServiceClient MobileService = new MobileServiceClient(
           "https://azuremobileservicegeneratesas.azure-mobile.net/",
           "IOeRiGBQbOOhVacBSXqabTUTOmRsuw79"
       );

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = await MobileService.LoginAsync(MobileServiceAuthenticationProvider.MicrosoftAccount);
                AddToDebug("User: {0}", user.UserId);
                HttpMethod httpMethod = new HttpMethod("GET");
                Dictionary<string,string> dic=new Dictionary<string,string>(); 
                var apiResult = await MobileService.InvokeApiAsync("generateazuretablesas",httpMethod,dic);
                AddToDebug("Json result: {0}", apiResult);
                AddToDebug("SAS token={0}")

            }
            catch (Exception ex)
            {
                AddToDebug("Error: {0}", ex);
            }
        }

        private void AddToDebug(string text, params object[] args)
        {
            if (args != null && args.Length > 0) text = string.Format(text, args);
            this.txtDebug.Text = this.txtDebug.Text + text + Environment.NewLine;
        }
    }
}